
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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


using ServizioRendicontazione.ApiModels;

#pragma warning disable CS8618

namespace ServizioRendicontazione.Models
{
	/// <summary>
	/// API Rendicontazione - GET /diari/{diarioId}
	/// </summary>
	public class DiarioDocenteConDettagli : ApiModel<DiarioDocenteConDettagli>
	{
		public override string getMethod() { return "diari/{0}"; }
		public override string getService() { return service_Rendicontazione; }
		public override bool needAuthorize() { return true; }
		public override string getOrder() { return "+diarioId,+aaId,+docenteId"; }
		public override string getField() { return
				"codFis," +
				"attivita.data,attivita.ore,attivita.minuti," +
				"attivita.tipoAttDes"; }
		
		//example: MRORSS55F12H456F
		//minLength: 16
		//maxLength: 16
		//cognome del docente a cui apprtiene il registro
		public string codFis { get; set; }

		public DiarioDocenteDett[] attivita { get; set; }
	}

	public class DiarioDocenteDett
	{
        //example: Lezione
        //maxLength: 10
        //descrizione tipo attività
        public string tipoAttDes { get; set; }

		//example: 10/12/2021
		//pattern: ([0][1 - 9]|[12][0-9]|[3][01])/([0][1 - 9]|[1][012])/(19|20)([0 - 9]{2})
		//data dell'attività rendicontata nel formato DD/MM/YYYY
		public string data { get; set; }

        //example: 2
        //ore rendicontate
        public int ore { get; set; }

        //example: 30
        //minuti rendicontati
        public int minuti { get; set; }
    }
}
