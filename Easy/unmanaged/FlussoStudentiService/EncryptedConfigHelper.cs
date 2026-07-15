/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using FlussoStudentiCryptoHelper;
using System;
using System.IO;
using System.Xml;

namespace FlussoStudentiService
{
    public static class EncryptedConfigHelper
    {
        public static string ReadEncryptedConfigValue(string key, string password)
        {
            try
            {
                string configFile = GetConfigFilePath();

                if (!File.Exists(configFile))
                {
                    throw new FileNotFoundException("File di configurazione non trovato", configFile);
                }

                string encryptedContent = File.ReadAllText(configFile);

                string decryptedContent;

                if (IsConfigEncrypted())
                    decryptedContent = CryptoHelper.DecryptString(encryptedContent, password);
                else
                    decryptedContent = encryptedContent;

                return GetValueFromXml(decryptedContent, key);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore lettura config: {ex.Message}");
                return null;
            }
        }

        public static string GetConfigFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                              $"Secure.config");
        }

        private static string GetValueFromXml(string xmlContent, string key)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlContent);

                var node = xmlDoc.SelectSingleNode($"/configuration/appSettings/add[@key='{key}']");
                return node?.Attributes?["value"]?.Value;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsConfigEncrypted()
        {
            try
            {
                string configFile = GetConfigFilePath();
                if (!File.Exists(configFile)) return false;

                string content = File.ReadAllText(configFile);
                return IsEncryptedContent(content);
            }
            catch
            {
                return false;
            }
        }

        private static bool IsEncryptedContent(string content)
        {
            // Controlla se il contenuto ha caratteristiche tipiche di dati cifrati
            if (string.IsNullOrEmpty(content)) return false;

            // 1. Controlla se inizia con un header comune di cifratura
            if (content.StartsWith("ENC|") || content.StartsWith("$2a$") ||
                content.StartsWith("$2b$") || content.StartsWith("$2y$"))
                return true;

            // 2. Controlla se contiene solo caratteri base64 (comuni in dati cifrati)
            if (IsBase64String(content))
                return true;

            // 3. Controlla se mancano caratteri tipici di file di configurazione
            if (!content.Contains("=") && !content.Contains("{") && !content.Contains("<"))
                return true;

            return false;
        }

        private static bool IsBase64String(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length % 4 != 0)
                return false;

            try
            {
                Convert.FromBase64String(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
