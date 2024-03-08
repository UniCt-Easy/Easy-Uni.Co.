
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

namespace AskCurrencyExchange {
    class Errors {
        public static string NoData(DateTime referenceDate, uint previousDays, string codeCurrency) {
            return string.Format(
                "Nessun tasso di cambio disponibile per {0} o per i {1} giorni precedenti per {2}. Il valore del tasso di cambio non è stato modificato.", 
                referenceDate.Date.ToString("D"), 
                previousDays, 
                codeCurrency
            );
        }

        public static string Unrecoverable() { return string.Format("Errore durante la comunicazione col servizio, il valore del tasso di cambio non è stato modificato."); }
    }
}
