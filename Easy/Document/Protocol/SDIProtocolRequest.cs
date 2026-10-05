using System;

using Document.SDI;

namespace Document.Protocol {
    /// <summary>
    /// Definisce una richiesta di protocollazione per un documento transitato sul Sistema di Interscambio.
    /// </summary>
    public class SDIProtocolRequest : ISDIDocument {
        public string NomeDocumento { get; set; }
        public DateTime DataDocumento { get; set; }
        public string OggettoDocumento { get; set; }

        public string Xml { get; set; }
        public string SignedXml { get; set; }

        public long? IdentificativoSdi { get; set; }
        public int? Position { get; set; }
        public int IdSdi { get; set; }

        /// <summary>
        /// Tipo del documento.
        /// </summary>
        public TDocument DocumentType { get; set; }
        /// <summary>
        /// Direzione del documento.
        /// </summary>
        public TDirection DirectionType { get; set; }

        /// <summary>
        /// Identificativo serializzato del documento transitato sul Sistema di Interscambio
        /// usato per identificare la richiesta di protocollazione.
        /// </summary>
        public string SerializedDocumentID {
            // quando potremo, usare il serializzatore JSON incluso in versioni più recenti di .NET
            get {
                string identificativo = IdentificativoSdi.HasValue ? IdentificativoSdi.Value.ToString() : "null";
                string position = Position.HasValue ? Position.Value.ToString() : "null";

                return $"{{\"IdentificativoSdi\":{identificativo},\"Position\":{position},\"IdSdi\":{IdSdi}}}";
            }
        }
    }
}
