using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using VkNet.Abstractions;
using Newtonsoft.Json.Linq;



namespace TutorApp.helpers
{
    public class VkPostHelper
    {
        private readonly VkApi _vkApi;
        private readonly long _groupId;

        public VkPostHelper(string accessToken, long groupId)
        {
            _vkApi = new VkApi();
            _vkApi.Authorize(new ApiAuthParams { AccessToken = accessToken });
            _groupId = groupId;
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                var group = await _vkApi.Groups.GetByIdAsync(new[] { _groupId.ToString().TrimStart('-') }, null, null);
                return group != null && group.Any();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Публикация поста с текстом из Word и прикреплёнными изображениями
        /// </summary>
        /// <param name="filePath">Путь к .docx файлу</param>
        /// <param name="imagePaths">Список путей к файлам изображений (JPG, PNG)</param>
        /// <returns>ID поста</returns>
        public async Task<long> PublishMaterialWithImagesAsync(string filePath, List<string> imagePaths = null)
        {
            LogToFile("=== НАЧАЛО ПУБЛИКАЦИИ ===");

            // 1. Извлекаем текст из Word
            string postContent = ExtractTextFromWord(filePath);
            LogToFile($"Текст из Word: {(postContent?.Length ?? 0)} символов");

            var attachments = new List<MediaAttachment>();

            // 2. Загружаем изображения в альбом сообщества
            if (imagePaths != null && imagePaths.Any())
            {
                LogToFile($"Найдено {imagePaths.Count} изображений для загрузки");

                foreach (var imagePath in imagePaths)
                {
                    if (!File.Exists(imagePath))
                    {
                        LogToFile($"Файл не найден: {imagePath}");
                        continue;
                    }

                    string photoId = await UploadPhotoToAlbum(imagePath);
                    if (!string.IsNullOrEmpty(photoId))
                    {
                        // Парсим photo{owner_id}_{photo_id}
                        var parts = photoId.Replace("photo", "").Split('_');
                        if (parts.Length == 2)
                        {
                            var photo = new Photo
                            {
                                OwnerId = long.Parse(parts[0]),
                                Id = long.Parse(parts[1])
                            };
                            attachments.Add(photo);
                            LogToFile($"Изображение прикреплено: {Path.GetFileName(imagePath)}");
                        }
                    }
                }
            }

            // 3. Публикуем пост
            var wallPostParams = new WallPostParams
            {
                OwnerId = _groupId,
                FromGroup = true,
                Message = postContent,
                Attachments = attachments,
                PublishDate = null
            };

            LogToFile($"Параметры поста: OwnerId={_groupId}, FromGroup=true, MessageLength={postContent?.Length ?? 0}, AttachmentsCount={attachments.Count}");

            var postId = await _vkApi.Wall.PostAsync(wallPostParams);
            LogToFile($"Пост опубликован! ID: {postId}");

            return postId;
        }

        /// <summary>
        /// Загрузка фото в альбом сообщества (обход ошибки Invalid hash)
        /// </summary>
        private async Task<string> UploadPhotoToAlbum(string imagePath)
        {
            try
            {
                LogToFile($"Загрузка файла: {imagePath}");
                long positiveGroupId = Math.Abs(_groupId);

                // Шаг 1: Получаем сервер для загрузки НА СТЕНУ (НЕ В АЛЬБОМ)
                var uploadServer = await _vkApi.Photo.GetWallUploadServerAsync(positiveGroupId);
                LogToFile($"Сервер загрузки получен: {uploadServer?.UploadUrl}");

                // Шаг 2: Загружаем файл на сервер
                using (var webClient = new System.Net.WebClient())
                {
                    var responseBytes = await webClient.UploadFileTaskAsync(new Uri(uploadServer.UploadUrl), imagePath);
                    var responseString = Encoding.UTF8.GetString(responseBytes);
                    LogToFile($"Ответ сервера загрузки: {responseString}");

                    var uploadResult = JObject.Parse(responseString);

                    string photoParam = uploadResult["photo"]?.ToString();
                    string serverParam = uploadResult["server"]?.ToString();
                    string hashParam = uploadResult["hash"]?.ToString();

                    // Шаг 3: Сохраняем фото на стене
                    using (var saveClient = new System.Net.WebClient())
                    {
                        var saveParams = new System.Collections.Specialized.NameValueCollection
                        {
                            ["photo"] = photoParam,
                            ["server"] = serverParam,
                            ["hash"] = hashParam,
                            ["group_id"] = positiveGroupId.ToString(),
                            ["access_token"] = _vkApi.Token,
                            ["v"] = "5.131"
                        };

                        var saveResponse = await saveClient.UploadValuesTaskAsync(
                            "https://api.vk.com/method/photos.saveWallPhoto",
                            "POST",
                            saveParams);

                        var saveResult = JObject.Parse(Encoding.UTF8.GetString(saveResponse));
                        LogToFile($"Результат сохранения: {saveResult}");

                        if (saveResult["response"] != null && saveResult["response"].Any())
                        {
                            var photo = saveResult["response"][0];
                            string photoId = $"photo{photo["owner_id"]}_{photo["id"]}";
                            LogToFile($"Фото сохранено: {photoId}");
                            return photoId;
                        }
                        else if (saveResult["error"] != null)
                        {
                            LogToFile($"Ошибка API: {saveResult["error"]["error_msg"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogToFile($"Ошибка загрузки фото {Path.GetFileName(imagePath)}: {ex.Message}");
                if (ex.InnerException != null)
                    LogToFile($"Внутренняя ошибка: {ex.InnerException.Message}");
            }

            return null;
        }

        /// <summary>
        /// Извлечение текста из Word документа
        /// </summary>
        private string ExtractTextFromWord(string filePath)
        {
            var sb = new StringBuilder();

            using (var wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                var mainPart = wordDoc.MainDocumentPart;
                var paragraphs = mainPart.Document.Body.Elements<Paragraph>();

                foreach (var paragraph in paragraphs)
                {
                    var paragraphText = paragraph.InnerText;
                    if (!string.IsNullOrWhiteSpace(paragraphText))
                        sb.AppendLine(paragraphText);
                }
            }

            return sb.ToString();
        }

        private void LogToFile(string message)
        {
            try
            {
                string logPath = Path.Combine(Path.GetTempPath(), "TutorApp_VkLog.txt");
                File.AppendAllText(logPath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {message}{Environment.NewLine}");
            }
            catch { }
        }
    }
}
