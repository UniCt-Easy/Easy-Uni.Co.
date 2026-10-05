using System;

namespace ADPv2 {

    // TODO: usare il chiamante per indicare dove è stata generata l'eccezione
    public static class Errors {
        
        public static Exception Uri(string data) {

            string message = string.Format("La stringa \"{0}\" non è un URL valido.", data);

            return new Exception(message);
        }

        public static Exception Conferente (object item) {

            string message = string.Format("{0} non è un formato di conferente riconosciuto.", item);

            return new Exception(message);
        }
    }
}
