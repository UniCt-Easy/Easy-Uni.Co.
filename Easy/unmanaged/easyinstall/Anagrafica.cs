/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metadatalibrary;
using System.Windows.Forms;
using System.Text;
using LiveUpdate;
using funzioni_configurazione;
using System.Collections;

/*
1) La P.IVA se presente - solo per anagrafiche di tipo Ditta commerciale
Se questa ha un match con il db di destinazione, allora è da unire. 
1b) Il CF se presente (non alfanum) - solo per anagrafiche di tipo Ditta commerciale
Se questa ha un match con il db di destinazione, allora è da unire. 
1c) Il CF se presente (non alfanum) - solo per anagrafiche di tipo Ditta commerciale
Se questa ha un match incrociato con la p.iva o viceversa con il db di destinazione, allora è da unire. 


 
2) Il Codice Fiscale se presente - solo per persone fisiche  
Se questo ha un match nel db di dest., allora è da unire. 

3)Per ditte commerciali:
Si può fare un match per denominazione uguale. Se esiste, e non c'è conflitto di CF/P.IVA allora si può unire

4)Per enti non commerciali:
Se la denominazione è uguale, e anche il CF allora si può unire. Attenzione, non basta che sia uguale il CF

5)Per enti non commerciali:
Se il CF è uguale, è necessaria una selezione/decisione manuale delle anagr. con pari cf   al fine di creare un mapping.


Per tutte le altre:
Rimangono separate a meno che non esista un'altra anagrafica con pari denominazione_estesa. In tal caso si richiederà la modifica manuale di una delle due anagrafiche.
*/

namespace EasyInstall
{
	/// <summary>
	/// Summary description for Anagrafica.
	/// </summary>
	public class Anagrafica
	{
        public static Hashtable lookupidpreg = new Hashtable();

        /// <summary>
        /// Verifica qualsiasi circostanza che può causare problemi nella migrazione, ed eventualmente
        /// risolve i problemi manualmente
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        /// <returns></returns>
        public static bool CheckAnagrafiche(Form form, DataAccess sourceConn, DataAccess destConn) {

            return true;
        }


        public static bool migraAnagrafica(Form form, DataAccess sourceConn, DataAccess destConn) {

            return true;
        }
	}
}
