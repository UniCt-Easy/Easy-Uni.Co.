
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


using RestSharp;
using System.Net;

namespace ReportGenClient
{
	public static class Extensions
	{
		public static bool IsSuccessful(this IRestResponse response)
		{
			return response.StatusCode.IsSuccessStatusCode()
				&& response.ResponseStatus == ResponseStatus.Completed;
		}

		public static bool IsSuccessStatusCode(this HttpStatusCode responseCode)
		{
			int numericResponse = (int)responseCode;
			return numericResponse >= 200
				&& numericResponse <= 299;
		}
	}
}
