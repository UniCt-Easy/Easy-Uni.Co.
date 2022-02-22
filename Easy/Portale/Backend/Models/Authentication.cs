
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.ComponentModel.DataAnnotations;

namespace Backend.Models {

    /// <summary>
    /// Dati del form di registrazione.
    /// </summary>
    public sealed class RegistrationFormData {

        /// <summary>
        /// Nome utente.
        /// </summary>
        [Required, MinLength(8), MaxLength(16)]
        public string userName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required, MinLength(8), MaxLength(16)]
        public string password { get; set; }

        /// <summary>
        /// Indirizzo e-mail.
        /// </summary>
        [Required, EmailAddress]
        public string email { get; set; }

        /// <summary>
        /// Codice fiscale.
        /// </summary>
        public string codiceFiscale { get; set; }

        /// <summary>
        /// Partita IVA.
        /// </summary>
        public string partitaIva { get; set; }

        /// <summary>
        /// Cognome.
        /// </summary>
        public string cognome { get; set; }

        /// <summary>
        /// Ruolo all'interno della app
        /// </summary>
        public string role { get; set; }

        /// <summary>
        /// Nome.
        /// </summary>
        public string nome { get; set; }

        private string _denominazione;

        /// <summary>
        /// Denominazione.
        /// </summary>
        public string denominazione {
            get {
                if (string.IsNullOrEmpty(_denominazione)) {
                    return string.Format("{0} {1}", cognome, nome);
                }

                return _denominazione;
            }
            set { _denominazione = value; }
        }

        /// <summary>
        /// Data di nascita.
        /// </summary>
        public DateTime dataNascita { get; set; }

    }

    /// <summary>
    /// Dati del form di login.
    /// </summary>
    public sealed class LoginFormData {

        /// <summary>
        /// Nome utente.
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Data contabile
        /// </summary>
        public DateTime datacontabile { get; set; }

    }

    /// <summary>
    /// Dati del form di login.
    /// </summary>
    public sealed class LoginFormDataSSO {

        /// <summary>
        /// Nome utente.
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string session { get; set; }

        /// <summary>
        /// Data contabile
        /// </summary>
        public DateTime datacontabile { get; set; }

    }

    /// <summary>
    /// Dati del form di registrazione.
    /// </summary>
    public sealed class AdminRegistrationFormData {

        public string login { get; set; }

        /// <summary>
        /// se si vuole che l'utente abbia accesso anche a easy
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// password su portale
        /// </summary>
        public string passwordweb { get; set; }

        public string surname { get; set; }

        /// <summary>
        /// forename
        /// </summary>
        public string forename { get; set; }

        /// <summary>
        /// Partita IVA.
        /// </summary>
        public string cf { get; set; }

        /// <summary>
        /// Cognome.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Ruolo all'interno della app
        /// </summary>
        public string codeflowchart { get; set; }

        /// <summary>
        /// esercizio.
        /// </summary>
        public string esercizio { get; set; }


        /// <summary>
        /// Ruolo all'interno della app
        /// </summary>
        public string usertype { get; set; }

        /// <summary>
        /// matricola.
        /// </summary>
        public string matricola { get; set; }

        public string userkind { get; set; }

        public string idregistrationuser { get; set; }
    }

    /// <summary>
    /// Dati del form cambio ruolo
    /// </summary>
    public sealed class CambioRuoloFormData {
        /// <summary>
        /// ndetail.
        /// </summary>
        [Required]
        public string ndetail { get; set; }

        /// <summary>
        /// idflowchart.
        /// </summary>
        [Required]
        public string idflowchart { get; set; }

    }

}
