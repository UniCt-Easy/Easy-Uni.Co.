using System;
using System.Collections.Generic;
using System.Linq;
using eventLog;
using sdiLog;

using preserve.Storage;

namespace preserve.Tenancy {

    /// <summary>
    /// Organizzazione o gruppo di utenti che utilizza un servizio.
    /// </summary>
    public class Tenant {

        /// <summary>
        /// Identificativo.
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// Indica se il tenant è abilitato per l'invio alla conservazione remota.
        /// </summary>
        public bool SendEnabled => !string.IsNullOrWhiteSpace(Username);

        /// <summary>
        /// Username per la conservazione remota.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Password per la conservazione remota.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Nome descrittivo.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Spazio di memorizzazione locale.
        /// </summary>
        public IStorage Storage { get; }

        /// <summary>
        /// Logger.
        /// </summary>
        public IPreserveLogger Logger => Storage.Logger;

        /// <summary>
        /// Uffici del tenant.
        /// </summary>
        public List<Office> Offices { get; } = new List<Office>();

        /// <summary>
        /// Inizializzo un oggetto che rappresenta una entità che effettua la conservazione con un'identificativo,
        /// una password per la conservazione remota, un nome descrittivo e un insieme di entità figlie.
        /// </summary>
        /// <param name="id">Identificativo del tenant.</param>
        /// <param name="username">Username per la conservazione remota.</param>
        /// <param name="password">Password per la conservazione remota.</param>
        /// <param name="name">Nome descrittivo.</param>
        /// <param name="storage">Spazio di memorizzazione locale.</param>
        /// <param name="offices">Uffici del tenant.</param>
        public Tenant(string id, string username, string password, string name, IStorage storage, IEnumerable<Office> offices) {

            ID = string.IsNullOrWhiteSpace(id) ? throw new Exception("id can't be empty.") : id;
            Username = username;
            Password = password;
            Name = string.IsNullOrWhiteSpace(name) ? throw new Exception("name can't be empty.") : name;

            Storage = storage;
            Offices = offices.ToList();
        }

        /// <summary>
        /// Crea una copia del tenant e le assegna un insieme di uffici.
        /// </summary>
        /// <param name="t">Tenant da copiare.</param>
        /// <param name="offices">Uffici da assegnare alla copia.</param>
        public Tenant(Tenant t, IEnumerable<Office> offices) {

            ID = t.ID;
            Username = t.Username;
            Password = t.Password;
            Name = t.Name;

            Storage = t.Storage;
            Offices = offices.ToList();
        }

        /// <summary>
        /// Proprietà espresse in formato human-readable, utile per i log.
        /// </summary>
        public object StringReferences => new {

            ID,
            Name,
            Username,
            Work = Storage.Work?.FullName,
            OK = Storage.OK?.FullName,
            KO = Storage.KO?.FullName,

            Offices = Offices.Select(o => new {

                o.ID,
                Work = o.Storage.Work?.FullName,
                OK = o.Storage.OK?.FullName,
                KO = o.Storage.KO?.FullName,
            }),
        };
    }
}
