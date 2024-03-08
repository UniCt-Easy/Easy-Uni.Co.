
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
	/// API Rendicontazione - GET /registri
	/// </summary>
	public class RegistroDocente : ApiModel<RegistroDocente>
	{
		public override string getMethod() { return "registri"; }
		public override string getService() { return service_Rendicontazione; }
		public override bool needAuthorize() { return true; }
		public override string getOrder() { return "+regId"; }
		public override string getField() { return "regId,codFis"; }

		//example: 10523
		//id del registro docente
		public Int64 regId { get; set; }

		//example: MRORSS55F12H456F
		//minLength: 16
		//maxLength: 16
		//cognome del docente a cui apprtiene il registro
		public string codFis { get; set; }
	}
}
