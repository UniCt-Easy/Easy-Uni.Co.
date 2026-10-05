using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;

using ApiClient;

using preserve.Tenancy;

using preserve.Storage;
using sdiLog;
using eventLog;

namespace preserve.UniStorage {

    /// <summary>
    /// Modalità di lavoro del servizio che ospita la funzionalità di conservazione.
    /// </summary>
    enum TMode {
        Multi,
        Single
    };

    public partial class Manager { // resto della definizione in Manager.cs

        /// <summary>
        /// Imposta l'autenticazione per l'API di conservazione remota.
        /// </summary>
        /// <param name="username">Username da utilizzare sull'API di conservazione remota.</param>
        /// <param name="password">Password da utilizzare sull'API di conservazione remota.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager> OptionAuth(string username, string password) {

            return m => {

                var optionAuth = Client.OptionBasicAuth(username, password);
                optionAuth(m.rest);
            };
        }

        /// <summary>
        /// Imposta il logger.
        /// </summary>
        /// <param name="l">Logger.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager> OptionLogger(IPreserveLogger l) {

            if (l == null) {

                throw new Exception("Invalid logger specified");
            }

            return (Manager m) => {

                m.Storage.Logger = l;
            };
        }

        /// <summary>
        /// Imposta il tempo di attesa minimo e il jitter tra le richieste.
        /// </summary>
        /// <param name="minWait">Tempo di attesa minimo tra la ricezione di una risposta e l'invio di una richiesta.</param>
        /// <param name="maxJitter">Tempo massimo usato come limite superiore per la selezione del jitter casuale.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager> OptionRequestWait(TimeSpan minWait, TimeSpan maxJitter) {

            return m => {

                m.minRequestWait = minWait > TimeSpan.Zero || minWait < TimeSpan.FromSeconds(7) ? minWait : throw new ArgumentException("Wait time must be comprised between 0 and 7 seconds");
                m.maxRequestJitter = maxJitter > TimeSpan.Zero || maxJitter < TimeSpan.FromSeconds(3) ? maxJitter : throw new ArgumentException("Jitter must be comprised between 0 and 3 seconds");
            };
        }

        /// <summary>
        /// Imposta la configurazione per un singolo tenant. Il tenant ed i suoi office utilizzano il filesystem come storage.
        /// </summary>
        /// <param name="t">Tenant da utilizzare.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        /// <exception cref="Exception"></exception>
        public static Action<Manager> OptionTenant(Tenant t) {

            if (t == null) {
                throw new Exception("No tenant specified");
            }

            return (Manager m) => {

                m.OfficeSearchMode = TMode.Single;

                m.Tenants = new List<Tenant>() { t };
            };
        }

        /// <summary>
        /// Imposta la configurazione dei tenant. I tenant ed i loro office utilizzano il filesystem come storage.
        /// </summary>
        /// <param name="config">Tabella di configurazione dei tenant.</param>
        /// <param name="filter">Filtro da applicare sulla tabella di configurazione.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        /// Imposta la configurazione dei tenant. I tenant ed i loro office utilizzano il filesystem come storage.
        /// </summary>
        /// <param name="config">Tabella di configurazione dei tenant.</param>
        /// <param name="filter">Filtro da applicare sulla tabella di configurazione.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager> OptionTableTenants(DataTable config, Predicate<DataRow> filter = null) {

            if (config == null) {
                throw new Exception("No configuration specified");
            }

            if (config.Rows.Count == 0) {
                throw new Exception("Empty configuration specified");
            }

            var neededColumnNames = new string[] {
                "cf_ente",
                "cons_login",
                "cons_pwd",
                "cons_denom",
            };

            var missingColumnNames = neededColumnNames.Except(config.Columns.Cast<DataColumn>().Select(column => column.ColumnName));

            if (missingColumnNames.Any()) {
                throw new Exception($"Invalid configuration schema, \"{string.Join(", ", missingColumnNames)}\" missing");
            }

            IEnumerable<DataRow> filteredConfig;
            try {
                filteredConfig = config.AsEnumerable().Where(r => filter?.Invoke(r) ?? true);   // invochiamo il filtro solo se specificato
            }
            catch (Exception e) {

                throw new Exception($"Invalid filter specified: {e.Message}");
            }

            return (Manager m) => {

                m.OfficeSearchMode = config.Columns.Contains("ipa") ? TMode.Multi : TMode.Single;

                string officeColumnName = m.OfficeSearchMode == TMode.Multi ? "ipa" : "cons_login"; // sarebbe da migliorare la configurazione,
                                                                                                    // facciamo questo per unificare concettualmente
                                                                                                    // le configurazioni di singolo e multi

                string tenantColumnName = m.OfficeSearchMode == TMode.Multi ? "cf_ente" : "cons_login";

                var tenantsOffices = filteredConfig
                .GroupBy(row => new {
                    ID = row[tenantColumnName].ToString(),
                    Username = row["cons_login"].ToString(),
                    Password = row["cons_pwd"].ToString(),
                    Name = row["cons_denom"].ToString()
                })
                .Select(group => {

                    var tenantWork = new DirectoryInfo(Path.Combine(m.Storage.Work.FullName, group.Key.ID));

                    // Windows ha una limitazione sulla creazione dei log sul registro eventi: la chiave del nome del log sono i primi 8 caratteri del nome
                    // L'eccezione alla creazione della sorgente per il registro eventi è mascherata (scritta su Debug) da SdiLog
                    // var tenantLogger = new Mlogger(string.Join(" - ", m.logger.Name, group.Key.Name));

                    var tenantStorage = new FileSystem(tenantWork, m.Logger);   // per i tenant usiamo il logger del manager: non abbiamo garanzia
                                                                                // che i primi 8 caratteri dell'ID siano unici
                    return new Tenant(
                        group.Key.ID,
                        group.Key.Username,
                        group.Key.Password,
                        group.Key.Name,
                        m.Storage,
                        group.Select(row => {

                            var officeID = row[officeColumnName].ToString();

                            DirectoryInfo ipaRoot = new DirectoryInfo(Path.Combine(tenantStorage.Work.FullName, officeID)); // sottodirectory OfficeID sulla directory Work del filesystem padre

                            DirectoryInfo officeWork = new DirectoryInfo(Path.Combine(ipaRoot.FullName, "work"));
                            DirectoryInfo officeOK = new DirectoryInfo(Path.Combine(ipaRoot.FullName, "ok"));
                            DirectoryInfo officeKO = new DirectoryInfo(Path.Combine(ipaRoot.FullName, "ko"));

                            return new Office(
                                officeID,
                                new FileSystem(
                                    officeWork,
                                    new Mlogger(officeID, group.Key.Name) ,  // usiamo un logger che ha l'IPA come nome (officeID) e che che indichi il tenant sui messaggi (group.Key.Name)
                                    officeOK,
                                    officeKO
                                )
                            );
                        })
                    );
                });

                m.Tenants = tenantsOffices.ToList();
            };
        }
    }
}
