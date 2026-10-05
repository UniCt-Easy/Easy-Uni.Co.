using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace preserve.UniStorage {

    /// <summary>
    /// Metodi di utilità per il parsing di stringhe di configurazione impostate sul DB di Easy.
    /// </summary>
    public static class EasyConfigReader {

        public static string ConfigTableName = "app_config";


        /// <summary>
        /// Estrae le coppie di chiavi e valori di configurazione da una stringa di in formato "key":"value","key2":"value2"
        /// sia con chiavi e valori quotati che non quotati.
        /// </summary>
        /// <param name="input">Stringa di configurazione.</param>
        /// <returns>Coppie di chiavi-valore.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Dictionary<string, string> Parse(string input) {

            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));

            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // Regex: key:"value" or key:value, with support for quoted/unquoted keys and values
            var regex = new Regex(@"(?:""([^""]+)""|(\w+))\s*:\s*(?:""((?:\\.|[^""])*)""|(\w+))");

            foreach (Match match in regex.Matches(input)) {
                string key = match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value;
                string value = match.Groups[3].Success ? match.Groups[3].Value : match.Groups[4].Value;

                // Unescape \" → "
                value = value.Replace("\\\"", "\"");

                result[key] = value;
            }

            return result;
        }

    }
}
