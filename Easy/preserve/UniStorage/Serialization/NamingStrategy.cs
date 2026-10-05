using System;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace preserve.UniStorage.Serialization {

    /// <summary>
    /// Convertitori necessari per la comunicazione con l'API di UniStorage.
    /// </summary>
    public static class Converters {

        public static JsonConverter[] Json = new JsonConverter[] {
            new StringEnumConverter(new UnimaticaNamingStrategy()),
        };
    }

    /// <summary>
    /// Strategia per la serializzazione in stringhe delle enumerazioni di UniStorage.
    /// </summary>
    public class UnimaticaNamingStrategy : NamingStrategy {

        public static readonly Dictionary<THash, string> HashValues = new Dictionary<THash, string>() {
            { THash.Sha256, "SHA-256" },
            { THash.Sha512, "SHA-512"},
        };

        public static readonly Dictionary<TEncoding, string> EncodingValues = new Dictionary<TEncoding, string>() {
            { TEncoding.Hex, "HEX" },
        };

        public static readonly Dictionary<TEsito, string> EsitoValues = new Dictionary<TEsito, string>() {
            { TEsito.OK, "OK" },
            { TEsito.KO, "KO"},
        };

        protected override string ResolvePropertyName(string name) {

            List<string> results = new List<string>();

            if (Enum.TryParse(name, out THash hashKey)) {
                results.Add(HashValues[hashKey]);
            };

            if (Enum.TryParse(name, out TEncoding encodingKey)) {
                results.Add(EncodingValues[encodingKey]);
            };

            if (Enum.TryParse(name, out TEsito esitoKey)) {
                results.Add(EsitoValues[esitoKey]);
            };

            return results.FirstOrDefault();
        }
    }
}
