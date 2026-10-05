using metadatalibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CurrencyManager {
    public class DBCurrency {
        public string codecurrency;
        public int idcurrency;

        public DBCurrency(DataRow row) {
            codecurrency = row.Field<string>("codecurrency").Trim();
            idcurrency = row.Field<int>("idcurrency");
        }
    }

    public class ApiResponse<T> {
        private readonly DateTime? _timestamp;
        private readonly TimeSpan? _validity;
        private readonly IEnumerable<T> items;

        public DateTime Timestamp { get { return _timestamp ?? DateTime.MinValue; } }
        public bool Stale { get {
                if (_validity == null)
                    return false;
                else
                    return Timestamp + _validity < DateTime.Now;
            } 
        }
        public IEnumerable<T> Items { get { return items; } }

        public ApiResponse(TimeSpan? validity = null) {
            _timestamp = null;
            _validity = validity;
            items = new List<T>();
        }

        public ApiResponse(IEnumerable<T> results, TimeSpan? validity = null) {
			_timestamp = DateTime.Now;
            _validity = validity;
            items = new List<T>(results);  
        }
	}

	public class DBCommit {
        private readonly DateTime? _timestamp;
        private readonly ProcedureMessageCollection _messages;

        public DateTime Timestamp { get { return _timestamp ?? DateTime.MinValue; } }
        public ProcedureMessageCollection Messages { get { return _messages; } }

        public DBCommit() {
            _timestamp = null;
            _messages = new ProcedureMessageCollection();
        }

		public DBCommit(ProcedureMessageCollection messages) {
			_timestamp = DateTime.Now;
			_messages = messages;
		}
	}

    /// <summary>
    /// Cache che estrae un dizionario con campi chiave e valore definiti su un enumerabile di tipo T.
    /// </summary>
    /// <typeparam name="T">Tipo dell'enumerabile da cui estrarre chiave e valore.</typeparam>
    /// <typeparam name="TKey">Tipo della chiave.</typeparam>
    /// <typeparam name="TValue">Tipo del valore.</typeparam>
    public class IdCache<T, TKey, TValue> : Dictionary<TKey, TValue> {
        /// <summary>
        /// Inizializza la cache con un enumerabile di tipo T usando keyName e valueName per estrarre chiave e valore.
        /// </summary>
        /// <param name="objects">Lista di oggetti di tipo T da cui estrarre chiave e valore.</param>
        /// <param name="keyName">Nome del campo chiave.</param>
        /// <param name="valueName">Nome del campo valore.</param>
        public IdCache(IEnumerable<T> objects, string keyName, string valueName) {
            try {
                Type objectType = typeof(T);

                FieldInfo keyField = objectType.GetField(keyName);
                if (keyField.FieldType != typeof(TKey))
                    throw new FormatException(string.Format("{0} not of type {1}", keyField.Name, typeof(TKey).ToString()));

                FieldInfo valueField = objectType.GetField(valueName);
                if (valueField.FieldType != typeof(TValue))
                    throw new FormatException(string.Format("{0} not of type {1}", valueField.Name, typeof(TValue).ToString()));

                foreach (T o in objects) {
                    try {
                        Add((TKey)keyField.GetValue(o), (TValue)valueField.GetValue(o));
                    }
                    catch (Exception e) {
                        throw new Exception(string.Format("error adding {0} {1}", keyField.GetValue(o), valueField.GetValue(o)), e);
                    }
                }
            }
            catch (Exception e) {
                throw e;
            }
        }
    }

    /// <summary>
    /// Associa un timestamp ad una Cache di ID di tipo IdCache.
    /// </summary>
    /// <typeparam name="T">Tipo di oggetti da contenere nella cache.</typeparam>
    public class DBResponse<T, TKey, TValue> : IdCache<T, TKey, TValue> {
        private readonly DateTime? _timestamp;
        public DateTime Timestamp { get { return _timestamp ?? DateTime.MinValue; } }

        /// <summary>
        /// Crea una versione della cache associata ad un timestamp di creazione.
        /// </summary>
        /// <param name="items">Oggetti contenuti nella cache</param>
        /// <param name="keyname">Nome del campo chiave della cache</param>
        /// <param name="valuename">Nome del campo valore della cache</param>
        public DBResponse(IEnumerable<T> items, string keyName, string valueName) : base(items, keyName, valueName) {
            _timestamp = DateTime.Now;
        }
    }
}
