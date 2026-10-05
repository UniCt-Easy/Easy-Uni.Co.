/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Data;
using System.Linq;
using System.Net.Mail;

using metadatalibrary;

using Backend.CommonBackend;

using Document.IPA;
using Document.Protocol;

namespace Backend.Extra {

    /// <summary>
    /// Descrive una amministrazione configurata sul database di Easy.
    /// </summary>
    public class Administration {
        /// <summary>
        /// Dati anagrafici e IPA dell'amministrazione principale.
        /// </summary>
        public ISoggetto AdministrativeSubject { get; }
        /// <summary>
        /// Identificativo dell'anagrafica sul database di Easy.
        /// </summary>
        public int IDRegistry { get; }
        /// <summary>
        /// Indirizzo email principale.
        /// </summary>
        public MailAddress EmailAddress =>
            AdministrativeSubject?.IndirizziDigitali?
                .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x)) is string addr
                    ? new MailAddress(addr)
                    : null;


        /// <summary>
        /// Istanzia una amministrazione.
        /// </summary>
        /// <param name="s">Dati anagrafici e IPA dell'amministrazione.</param>
        /// <param name="idreg">Identificativo dell'anagrafica sul database di Easy.</param>
        /// <param name="email">Indirizzo email principale.</param>
        public Administration(ProtocolSoggetto s, int idreg, string email) {

            AdministrativeSubject = s ?? throw new ArgumentNullException(nameof(s));

            string mailAddress;
            try {

                mailAddress = new MailAddress(email).ToString();
            }
            catch (Exception e) {

                throw new Exception("Could not parse the mail address.", e);
            }

            IDRegistry = idreg;
            s.IndirizziDigitali = new string[] { mailAddress };
        }

        /// <summary>
        /// Recupera i dati dell'amministrazione da DB.
        /// </summary>
        /// <param name="d">Dispatcher.</param>
        /// <returns></returns>
        public static Administration Get(Dispatcher d) {

            DataRow istituto;
            try {

                istituto = d.Connection.RUN_SELECT("istitutoprinc", "*", null, null, "1", false).First();
            }
            catch (Exception e) {

                throw new Exception("Impossibile recuperare i dati dell'amministrazione.", e);
            }

            try {

                var denominazione = d.Connection.GetSys("agency")?.ToString();
                var partitaiva = d.Connection.GetSys("p_ivaagency")?.ToString();
                var cf = d.Connection.GetSys("cfagency")?.ToString();

                var codiceammipa = istituto["codiceammipa"]?.ToString();                                             // codice IPA Amministrazione principale
                var codiceaooipa = d.Connection.DO_READ_VALUE("aoo", null, "codiceaooipa")?.ToString();              // codice IPA AOO principale (prima riga mi dicono)
                var strutturacodiceipa = d.Connection.DO_READ_VALUE("struttura", null, "codiceipa")?.ToString();     // codice IPA UOR principale (prima riga mi dicono)

                var administrativeSubject = new ProtocolSoggetto() {
                    Denominazione = !string.IsNullOrWhiteSpace(denominazione) ? denominazione : null,
                    PartitaIVA = !string.IsNullOrWhiteSpace(partitaiva) ? partitaiva : null,
                    CodiceFiscale = !string.IsNullOrWhiteSpace(cf) ? cf : null,
                    IPAAmm = !string.IsNullOrWhiteSpace(codiceammipa) ? codiceammipa : null,
                    IPAAOO = !string.IsNullOrWhiteSpace(codiceaooipa) ? codiceaooipa : null,
                    IPAUOR = !string.IsNullOrWhiteSpace(strutturacodiceipa) ? strutturacodiceipa : null,
                };

                //    if (dsRegIstitutiPrinc.Tables["registryreference"].Rows.Count > 0)
                //        rowProtocolloDestinatario["destmail"] = dsRegIstitutiPrinc.Tables["registryreference"].Rows[0]["email"];

                var idreg = Convert.ToInt32(istituto["idreg"]);
                var email = d.Connection.DO_READ_VALUE("registryreference", $"idreg = {idreg}", "email").ToString();

                return new Administration(administrativeSubject, idreg, email);
            }
            catch (Exception e) {

                throw new Exception("Impossibile inizializzare i dati dell'amministrazione.", e);
            }
        }
    }
}