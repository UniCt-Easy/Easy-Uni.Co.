using System;

namespace Document.SDI {
    /// <summary>
    /// Definisce un documento transitato sul Sistema di Interscambio.
    /// </summary>
    public interface ISDIDocument {
        string NomeDocumento { get; set; }
        DateTime DataDocumento { get; set; }
        string OggettoDocumento { get; set; }

        string Xml { get; set; }
        string SignedXml { get; set; }

        long? IdentificativoSdi { get; set; }
        int? Position { get; set; }
        int IdSdi { get; set; }

        /// <summary>
        /// Tipo del documento.
        /// </summary>
        TDocument DocumentType { get; set; }
        /// <summary>
        /// Direzione del documento.
        /// </summary>
        TDirection DirectionType { get; set; }

        //ISoggetto Mittente { get; }
        //ISoggetto Destinatario { get; }
    }
}
