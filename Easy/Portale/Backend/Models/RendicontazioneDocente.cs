
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
	//            "erogazioneDataOraFine": "2023-05-02T10:00:00.000Z", 
	//            "erogazioneDescrizione": "Descrizione della lezione tenuta in aula", 
	//            "erogazioneLuogo": { 
	//               "luogoDescrizione": "Sede centrale università", 
	//               "luogoNome": "Roma", 
	//               "luogoProvinciaSigla": "RM", 
	//               "luogoCodiceIstat": "058091", 
	//               "luogoCodiceCatastale": "H501" 
	//            } 
	//         }], 
	//         "didatticheIntegrative": [{ 
	//            "erogazioneData": "2023-05-02T00:00:00.000Z", 
	//            "erogazioneOreComplessive": 2, 
	//            "erogazioneTipoAttivita": "Ricevimento" 
	//         }], 
	//         "altreAttivita": [{ 
	//            "erogazioneData": "2023-05-02T00:00:00.000Z", 
	//            "erogazioneOreComplessive": 8, 
	//            "erogazioneTipoAttivita": "AltraAttivita" 
	//         }] 
	//      }] 

	/// <summary>
	/// Rendicontazione Docente
	/// </summary>
	public class RendicontazioneDocente
	{
		public Docente docente { get; set; }
		public List<DidatticaFrontale> didatticheFrontali { get; set; }
		public List<Erogazione> didatticheIntegrative { get; set; }
		public List<Erogazione> altreAttivita { get; set; }
	}

	public class Docente
	{
		public Guid id { get; set; }
		public string codiceFiscale { get; set; }
	}

	public class DidatticaFrontale
	{
		public string erogazioneDataOraInizio { get; set; }
		public string erogazioneDataOraFine { get; set; }
		public string erogazioneDescrizione { get; set; }
		public ErogazioneLuogo erogazioneLuogo { get; set; }
	}

	public class ErogazioneLuogo
	{
		public string luogoDescrizione { get; set; }
		public string luogoNome { get; set; }
		public string luogoProvinciaSigla { get; set; }
		public string luogoCodiceIstat { get; set; }
		public string luogoCodiceCatastale { get; set; }
	}

	public class Erogazione
	{
		public string erogazioneData { get; set; }
		public int erogazioneOreComplessive { get; set; }
		public string erogazioneTipoAttivita { get; set; }
	}
}



        
