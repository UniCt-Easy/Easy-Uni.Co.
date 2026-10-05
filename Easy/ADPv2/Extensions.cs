using System;

namespace ADPv2 {
    public static class Extensions {
        /// <summary>
        /// Tenta il cast di un'oggetto generico in un oggetto di tipo T.
        /// </summary>
        /// <typeparam name="T">Tipo al quale effettuare il cast</typeparam>
        /// <param name="item">Oggetto sul quale tentare il cast</param>
        /// <param name="casted">Oggetto risultante dal cast</param>
        /// <returns>true se il cast ha avuto successo, false in caso contrario</returns>
        public static bool TryCast<T>(this object item, out T casted) where T : new() {
            try {
                casted = (T)item;
            }
            catch (Exception) {
                casted = new T();
                return false;
            }

            return true;
        }
    }
}
