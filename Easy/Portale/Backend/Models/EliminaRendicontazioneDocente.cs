
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


using System.Collections.Generic;

namespace Backend.Models
{
	//		"rendicontazioni": [{
	//         "docente": {
	//            "id": "5CA98D45-C6BB-4355-9FBB-C29DDFBC9B64",
	//            "codiceFiscale": "PNRPLG59P01L316E"
	//         },
	//         "didatticheFrontali": [{ 
	//            "erogazioneDataOraInizio": "2023-05-02T08:00:00.000Z", 
	//            "erogazioneDataOraFine": "2023-05-02T10:00:00.000Z"
	//         }], 
	//         "didatticheIntegrative": [{ 
	//            "erogazioneData": "2023-05-02T00:00:00.000Z"
	//         }], 
	//         "altreAttivita": [{ 
	//            "erogazioneData": "2023-05-02T00:00:00.000Z"
	//         }] 
	//      }] 

	/// <summary>
	/// Rendicontazione Docente
	/// </summary>
	public class EliminaRendicontazioneDocente
	{
		public Docente docente { get; set; }
		public List<DelDidatticaFrontale> didatticheFrontali { get; set; }
		public List<DelErogazione> didatticheIntegrative { get; set; }
		public List<DelErogazione> altreAttivita { get; set; }
	}

	public class DelDidatticaFrontale
	{
		public string erogazioneDataOraInizio { get; set; }
		public string erogazioneDataOraFine { get; set; }
	}

	public class DelErogazione
    {
		public string erogazioneData { get; set; }
        public int erogazioneOreComplessive { get; set; }
    }
}



        
