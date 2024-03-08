
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

namespace ServizioRendicontazione.Models
{
	public class DettaglioErrore
	{
		//example: 200
		//Http Status Code
		public int statusCode { get; set; }

		//example: -1
		//codice di errore
		public int retCode { get; set; }

		//example: Parametri non corretti
		//descrizione dell'errore
		public string retErrMsg { get; set; }

		DettaglioErroreAggiuntivo[] errDetails { get; set; }
	}

	public class DettaglioErroreAggiuntivo
	{
		//example: stackTrace
		//descrizione del tipo di errore aggiuntivo
		public string errorType { get; set; }

		//example: SocketTimeoutException....
		//descrizione dell'errore
		public string value { get; set; }
	}
}
