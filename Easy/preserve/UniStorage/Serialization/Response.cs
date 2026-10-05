using System.Collections.Generic;

namespace preserve.UniStorage.Serialization {

    /// <summary>
    /// Esito dell'operazione di storage sull'API di UniStorage.
    /// </summary>
    public enum TEsito {
        OK,
        KO
    }

    public class EsitoConsegna {
        public string id { get; set; }
        public Chiave chiave { get; set; }
        public List<object> errori { get; set; }
    }

    public class Response {
        public TEsito esitoComplessivo { get; set; }
        public string pdvUuid { get; set; }
        public string dataDiCarico { get; set; }
        public List<object> erroriGenerali { get; set; }
        public List<EsitoConsegna> esitoConsegna { get; set; }
    }
}
