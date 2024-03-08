
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


using ServizioRendicontazione.ApiModels;

#pragma warning disable CS8618

namespace ServizioRendicontazione.Models
{
	/// <summary>
	/// API Rendicontazione - GET /registri/{regid}
	/// </summary>
	public class RegistroDocenteConDettagli : ApiModel<RegistroDocenteConDettagli>
	{
		public override string getMethod() { return "registri/{0}"; }
		public override string getService() { return service_Rendicontazione; }
		public override bool needAuthorize() { return true; }
		public override string getOrder() { return "+regId,+aaOffId,+docenteId"; }
		public override string getField() { return
				"codFis," +
				"logistica.cdsId,logistica.cdsCod,logistica.cdsDes," +
				"logistica.adId,logistica.adCod,logistica.adDes," +
				"attivita.data,attivita.oraInizio,attivita.oraFine,attivita.oreAccademiche," +
				"attivita.tipoAttDes,attivita.titolo"; }
		
		//example: MRORSS55F12H456F
		//minLength: 16
		//maxLength: 16
		//cognome del docente a cui apprtiene il registro
		public string codFis { get; set; }

		public RegistroDocenteLog[] logistica { get; set; }

		public RegistroDocenteDett[] attivita { get; set; }
	}

	public class RegistroDocenteLogComparer : IEqualityComparer<RegistroDocenteLog>
	{
		public bool Equals(RegistroDocenteLog x, RegistroDocenteLog y)
		{
			return x.cdsId == y.cdsId;
		}

		public int GetHashCode(RegistroDocenteLog obj)
		{
			return HashCode.Combine(obj.cdsId, obj.adId);
		}
	}	

	public class RegistroDocenteLog
	{
		//example: 11
		//id del corso di studio di erogazione dell'attività didattica
		public Int64 cdsId { get; set; }

		//example: CDS_COD1
		//codice del corso di studio di erogazione dell'attività didattica
		public string cdsCod { get; set; }

		//example: Corso di studio 1
		//descrizione del corso di studio di erogazione dell'attività didattica
		public string cdsDes { get; set; }

		//example: 111
		//id del dell'attività didattica
		public Int64 adId { get; set; }

		//example: AD_COD1
		//codice dell'attività didattica
		public string adCod { get; set; }

		//example: Attività didattica 1
		//descrizione dell'attività didattica
		public string adDes { get; set; }
	}

	public class RegistroDocenteDett
	{
		//example: Lezione
		//maxLength: 10
		//descrizione tipo attività
		public string tipoAttDes { get; set; }

		//example: 10/12/2021
		//pattern: ([0][1 - 9]|[12][0-9]|[3][01])/([0][1 - 9]|[1][012])/(19|20)([0 - 9]{2})
		//data dell'attività rendicontata nel formato DD/MM/YYYY
		public string data { get; set; }

		//example: 900
		//pattern: ([01][0 - 9]|2[0-3]):[0-5]
		//[0-9]
		//ora di inizio dell'attivita nel formato hh:mm
		public string oraInizio { get; set; }

		//example: 900
		//pattern: ([01][0 - 9]|2[0-3]):[0-5]
		//[0-9]
		//ora di fine dell'attivita nel formato hh:mm
		public string oraFine { get; set; }

		//example: 12.5
		//Durata in ore accademiche dell'attività inserita dal docente (non necessariamente coincide con la differenza tra ORA_FINE e ORA_INIZIO).
		public float oreAccademiche { get; set; }

		//example: titolo lezione
		//maxLength: 255
		//titolo dell'attività rendicontata
		public string titolo { get; set; }
	}
}
