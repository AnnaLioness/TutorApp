using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VkSettingsService
    {
        private readonly string _settingsPath;
        private readonly byte[] _encryptionKey;

        public VkSettingsService()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(appData, "TutorApp");
            Directory.CreateDirectory(appFolder);
            _settingsPath = Path.Combine(appFolder, "vksettings.json");

            // Создаём или загружаем ключ шифрования (сохраняется отдельно)
            _encryptionKey = GetOrCreateEncryptionKey(appFolder);
        }

        /// <summary>
        /// Получить или создать ключ шифрования
        /// </summary>
        private byte[] GetOrCreateEncryptionKey(string appFolder)
        {
            string keyPath = Path.Combine(appFolder, "key.bin");

            if (File.Exists(keyPath))
            {
                return File.ReadAllBytes(keyPath);
            }
            else
            {
                // Генерируем новый ключ
                byte[] key = RandomNumberGenerator.GetBytes(32); // 256 бит
                File.WriteAllBytes(keyPath, key);
                return key;
            }
        }

        /// <summary>
        /// Зашифровать строку
        /// </summary>
        private string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            using (Aes aes = Aes.Create())
            {
                aes.Key = _encryptionKey;
                aes.GenerateIV();
                byte[] iv = aes.IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, iv))
                using (var ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Расшифровать строку
        /// </summary>
        private string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            byte[] fullCipher = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = _encryptionKey;
                byte[] iv = new byte[aes.BlockSize / 8];
                byte[] cipher = new byte[fullCipher.Length - iv.Length];

                Array.Copy(fullCipher, iv, iv.Length);
                Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(cipher))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public VkSettings Load()
        {
            if (File.Exists(_settingsPath))
            {
                string json = File.ReadAllText(_settingsPath);
                var settings = JsonSerializer.Deserialize<VkSettings>(json);

                if (settings != null && !string.IsNullOrEmpty(settings.AccessToken))
                {
                    // Расшифровываем токен
                    settings.AccessToken = Decrypt(settings.AccessToken);
                }
                return settings ?? new VkSettings();
            }
            return new VkSettings();
        }

        public void Save(VkSettings settings)
        {
            // Создаём копию для сохранения с зашифрованным токеном
            var settingsToSave = new VkSettings
            {
                GroupId = settings.GroupId,
                IsConfigured = settings.IsConfigured,
                AccessToken = string.IsNullOrEmpty(settings.AccessToken)
                    ? string.Empty
                    : Encrypt(settings.AccessToken)
            };

            string json = JsonSerializer.Serialize(settingsToSave);
            File.WriteAllText(_settingsPath, json);
        }
    }
}

