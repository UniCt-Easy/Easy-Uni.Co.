
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
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace ServizioRendicontazione.ApiModels
{
	// /<summary>
	// /API Struttura - GET /corsiFull/{cdsId}
	// /</summary>
	public class CorsoDiStudioConDettagli : ApiModel<CorsoDiStudioConDettagli>
	{
		public override string getMethod() { return "corsiFull/{0}"; }
		public override string getService() { return service_Struttura; }
		public override bool needAuthorize() { return true; }
		public override string getOrder() { return ""; }
		public override string getField() { return
				"aaAttId,urlSitoWeb," +
				"ordinamentiConPercorsi.aaOrdId,ordinamentiConPercorsi.cdsOrdCod,ordinamentiConPercorsi.cdsOrdDes," +
				"ordinamentiConPercorsi.valoreMin,ordinamentiConPercorsi.durataAnni," +
				"ordinamentiConPercorsi.percorsiDiStudio.pdsCod,ordinamentiConPercorsi.percorsiDiStudio.pdsDes," +
				"sediCorso.sedeDes," +
				"struttureCorso.facId,struttureCorso.facCod,struttureCorso.facDes,struttureCorso.facDesEng,struttureCorso.facCitta";
		}

		// ===========================================================================
		// 				Anno Attivazione/Disattivazione corso
		// ===========================================================================
		// es: 2016
		// anno di attivazione del corso
		public int? aaAttId { get; set; }

		//example: Esempio di url
		//URL del sito web del corso di studio
		public string urlSitoWeb { get; set; }

		public OrdinamentoConPercorsi[] ordinamentiConPercorsi { get; set; }
		public SediCorso[] sediCorso { get; set; }
		public StruttureCorso[] struttureCorso { get; set; }
	}

	public class OrdinamentoConPercorsi
	{
		//example: 2016
		//anno di ordinamento del corso di studioa
		public int aaOrdId { get; set; }

		// es: CDS_1
		// codice dell'ordinamento
		public string cdsOrdCod { get; set; }

		// es: Esempio di CDS_1
		// descrizione dell'ordinamento
		public string cdsOrdDes { get; set; }

		// es: 180
		// valore minimo di crediti, che devono essere ottenuti per poter conseguire il titolo di studio
		public Int64? valoreMin { get; set; }

		// es: 3
		// numero di anni di durata del corso di studio effettiva
		public int? durataAnni { get; set; }

		public PercorsoDiStudio[] percorsiDiStudio { get; set; }
	}

	public class PercorsoDiStudio
	{
		// es: PDS_1
		// codice del percorso di studio
		public string pdsCod { get; set; }

		// es: Esempio di PDS_1
		// descrizione del percorso di studio
		public string pdsDes { get; set; }
	}

	public class StruttureCorso
	{
		// es: 1
		// chiave della struttura di riferimento
		public Int64? facId { get; set; }

		// es: FAC_1
		// codice della struttura di riferimento
		public string facCod { get; set; }

		// es: Esempio di FAC
		// descrizione della struttura di riferimento
		public string facDes { get; set; }

		// es: Esempio di FAC
		// descrizione della struttura di riferimento in inglese
		public string facDesEng { get; set; }

		// es: ROMA
		// città della facoltà
		public string facCitta { get; set; }
	}

	public class SediCorso
	{
		// es: Roma
		// descrizione della sede
		public string sedeDes { get; set; }
	}
}
