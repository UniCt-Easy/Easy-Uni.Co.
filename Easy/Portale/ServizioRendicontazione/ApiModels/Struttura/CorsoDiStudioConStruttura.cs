
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


#pragma warning disable CS8618

namespace ServizioRendicontazione.ApiModels
{
	/// <summary>
	/// API Struttura - GET /corsi
	/// </summary>
	public class CorsoDiStudioConStruttura : ApiModel<CorsoDiStudioConStruttura>
	{
		public override string getMethod() { return "corsi"; }
		public override string getService() { return service_Struttura; }
		public override bool needAuthorize() { return false; }
		public override string getOrder() { return "+cdsId"; }
		public override string getField() { return 
				"cdsDesEng," +
				"ateneoId," +
				"tipoCorsoCod,tipoCorsoDes," +
				"claCod,claDes," +
				"normDes," +
				"tipoTititCod,tipoTititDes," +
				"iscedDes"; }

		// ===========================================================================
		// 				DESCRIZIONE CORSO STUDIO ENG
		// ===========================================================================
		// es: LAW
		// descrizione del corso di studio in inglese
		public string cdsDesEng { get; set; }

		// ===========================================================================
		// 				ID ATENEO
		// ===========================================================================
		// es: 24
		//chiave dell'ateneo di riferimento
		public Int64? ateneoId { get; set; }

		// ===========================================================================
		// 				TIPO CORSO STUDIO - tipo del corso di studio
		// ===========================================================================
		// es: LM5
		// codice del tipo di corso di studio
		public string tipoCorsoCod { get; set; }

		// es: Laurea Magistrale Ciclo Unico 5 anni
		// descrizione del tipo di corso di studio
		public string tipoCorsoDes { get; set; }

		// ===========================================================================
		// 				CLASSE CORSO STUDIO - classe del corso di studio
		// ===========================================================================
		//example: LM-40
		//codice della classe MIUR del corso di studio
		public string claCod { get; set; }

		// es: Classe delle lauree magistrali in giurisprudenza
		// descrizione della classe MIUR del corso di studio
		public string claDes { get; set; }

		// ===========================================================================
		// 				CORSO STUDIO NORMA - normativa del corso di studio
		// ===========================================================================
		// es: D.M. 270/2004
		// descrizione della normativa del corso di studio
		public string normDes { get; set; }


		// ===========================================================================
		// 				TITOLO CORSO STUDIO - titolo del corso di studio
		// ===========================================================================
		// es: LM
		// codice del tipo di titolo del corso di studio
		public string tipoTititCod { get; set; }

		// es: Laurea Magistrale
		// descrizione del tipo di titolo del corso di studio
		public string tipoTititDes { get; set; }

		// ===========================================================================
		// 								AREA DIDATTICA
		// ===========================================================================
		// es: Area Umanistica
		// Descrizione area ISCED
		public string iscedDes { get; set; }
	}
}
