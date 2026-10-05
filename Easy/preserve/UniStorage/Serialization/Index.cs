using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using preserve.Storage;
using preserve.Tenancy;

namespace preserve.UniStorage.Serialization {

    /// <summary>
    /// Encoding degli hash.
    /// </summary>
    public enum TEncoding {
        Hex,
    }

    /// <summary>
    /// Algoritmi di hashing.
    /// </summary>
    public enum THash {
        Sha256,
        Sha512,
    }

    public class Allegati {
        public Guid id { get; set; }
        public string nomeFile { get; set; }
        public string formatoFile { get; set; }
        public Hash hash { get; set; }
        public Metadati metadati { get; set; }
        public ParametriDocumento parametriDocumento { get; set; }
    }

    public class Chiave {
        public Guid numero { get; set; }
        public string anno { get; set; }
        public string registro { get; set; }
    }

    public class Documenti {
        public string id { get; set; }
        public Chiave chiave { get; set; }
        public string nomeFile { get; set; }
        public string formatoFile { get; set; }
        public Hash hash { get; set; }
        public Metadati metadati { get; set; }
        public ParametriDocumento parametriDocumento { get; set; }
        public List<Allegati> allegati { get; set; }

        public Documenti() { }

        public Documenti(Guid identifier, string register, FileInfo documentFile, byte[] documentContents, FileInfo metadataFile, byte[] metadataContents) {

            id = documentFile.Name;
            nomeFile = documentFile.Name;
            chiave = new Chiave() { // la chiave possiamo valorizzarla noi (tenendo traccia di quelle generate) oppure farcela generare da loro (a quanto pare non accettano null)
                anno = DateTime.Now.Year.ToString(),
                numero = identifier,
                registro = !string.IsNullOrWhiteSpace(register) ? register : "unico",   // unistorage rifiuta gli invii che abbiano questo campo a null, e sulla versione singola di sdiftp riceviamo i preserveData con questo campo a null
            };
            formatoFile = documentFile.Extension;
            hash = new Hash() {
                algoritmo = THash.Sha256,
                codifica = TEncoding.Hex,
                impronta = BitConverter.ToString(new SHA256Managed().ComputeHash(documentContents)).Replace("-", "").ToLowerInvariant(),
            };
            metadati = new Metadati() {
                hash = new Hash() {
                    algoritmo = THash.Sha256,
                    codifica = TEncoding.Hex,
                    impronta = BitConverter.ToString(new SHA256Managed().ComputeHash(metadataContents)).Replace("-", "").ToLowerInvariant(),
                },
                nomeFile = metadataFile.Name,
            };
            allegati = new List<Allegati>();
            parametriDocumento = new ParametriDocumento() {
                aggiungiFirma = false,
                verificaFirma = false,
            };
        }
    }

    public class Hash {
        public string impronta { get; set; }
        public TEncoding codifica { get; set; }
        public THash algoritmo { get; set; }
    }

    public class Metadati {
        public string nomeFile { get; set; }
        public Hash hash { get; set; }
    }

    public class ParametriDocumento {
        public bool aggiungiFirma { get; set; }
        public bool verificaFirma { get; set; }
    }

    public class Profilo {
        public string tenant { get; set; }
        public string classeDocumentale { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class UniStorageIndex : ITenantIndex {

        public string TenantID => profilo.tenant;
        public string OfficeID => documenti.Any() ? documenti.First().chiave.registro : null;

        [JsonProperty]
        public Profilo profilo { get; set; }

        [JsonProperty]
        public List<Documenti> documenti { get; set; }

        /// <summary>
        /// Serializza una Request e la scrive su un file.
        /// </summary>
        /// <param name="f">File su cui scrivere la Request serializzata.</param>
        public void Store(IFileReference f) {

            string requestContents;
            var serializer = new JsonSerializer() {
                Formatting = Formatting.Indented,
            };

            foreach (JsonConverter jc in Converters.Json) {
                serializer.Converters.Add(jc);
            }

            StringWriter sw = new StringWriter(new StringBuilder());
            var jtw = new JsonTextWriter(sw);

            try {
                serializer.Serialize(jtw, this);
                requestContents = sw.ToString();
            }
            catch (Exception e) {
                throw new Exception($"Could not serialize: {e.Message}", e);
            }

            try {
                File.WriteAllText(f.FullName, requestContents);
            }
            catch (Exception e) {
                throw new Exception($"Could not write data to {f.FullName}: {e.Message}", e);
            }
        }

        /// <summary>
        /// Deserializza il contenuto di un file in una Request.
        /// </summary>
        /// <param name="f">File contenente i dati da deserializzare.</param>
        /// <returns>Request deserializzata.</returns>
        public static UniStorageIndex Load(IFileReference f) {

            string fileContents;
            var serializer = new JsonSerializer();

            foreach (JsonConverter jc in Converters.Json) {
                serializer.Converters.Add(jc);
            }

            UniStorageIndex i;

            try {
                fileContents = File.ReadAllText(f.FullName);
            }
            catch (Exception e) {
                throw new Exception($"Could not load data from {f.FullName}: {e.Message}", e);
            }

            StringReader sr = new StringReader(fileContents);
            var jtr = new JsonTextReader(sr);

            try {
                i = serializer.Deserialize(jtr, typeof(UniStorageIndex)) as UniStorageIndex;
            }
            catch (Exception e) {
                throw new Exception($"Could not deserialize: {e.Message}", e);
            }

            return i;
        }
    }
}
