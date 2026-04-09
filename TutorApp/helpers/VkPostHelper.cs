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

        public async Task<long> PublishMaterialAsync(string filePath, List<string> imageUrls = null)
        {
            LogToFile("=== НАЧАЛО ПУБЛИКАЦИИ ===");

            // 1. Извлекаем текст из Word
            var (postContent, _) = ExtractFromWord(filePath);
            LogToFile($"Текст из Word: {(postContent?.Length ?? 0)} символов");

            // 2. Формируем финальный текст поста
            string finalMessage = postContent;

            // 3. Если переданы ссылки на картинки, добавляем их в конец сообщения
            if (imageUrls != null && imageUrls.Any())
            {
                LogToFile($"Добавление {imageUrls.Count} картинок в пост");
                finalMessage += "\n\n";
                finalMessage += string.Join("\n", imageUrls);
                LogToFile($"Финальный текст поста (первые 300 символов): {finalMessage.Substring(0, Math.Min(300, finalMessage.Length))}");
            }

            // 4. Публикуем пост
            LogToFile("Публикация поста...");
            var wallPostParams = new WallPostParams
            {
                OwnerId = _groupId,
                FromGroup = true,
                Message = finalMessage,
                Attachments = new List<MediaAttachment>(), // Вложения не нужны, картинки в тексте
                PublishDate = null
            };

            LogToFile($"Параметры поста: OwnerId={_groupId}, FromGroup=true, MessageLength={finalMessage?.Length ?? 0}");

            var postId = await _vkApi.Wall.PostAsync(wallPostParams);
            LogToFile($"Пост опубликован! ID: {postId}");
            LogToFile("=== КОНЕЦ ПУБЛИКАЦИИ ===");

            return postId;
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


        private (string text, List<byte[]> images) ExtractFromWord(string filePath)
        {
            var imagesData = new List<byte[]>();
            var sb = new StringBuilder();

            using (var wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                var mainPart = wordDoc.MainDocumentPart;

                // Извлекаем текст из всех абзацев
                var paragraphs = mainPart.Document.Body.Elements<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    var paragraphText = paragraph.InnerText;
                    if (!string.IsNullOrWhiteSpace(paragraphText))
                        sb.AppendLine(paragraphText);
                }

                // Изображения НЕ извлекаем (оставляем для совместимости, но не используем)
                // var imageParts = mainPart.ImageParts;
                // foreach (var imagePart in imageParts) { ... }
            }

            return (sb.ToString(), imagesData);
        }

        public class WallUploadResponse
        {
            [JsonProperty("server")]
            public long server { get; set; }

            [JsonProperty("photo")]
            public string photo { get; set; }

            [JsonProperty("hash")]
            public string hash { get; set; }
        }

    }
}
