
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


namespace ServizioRendicontazione.ApiModels
{
    public interface IApiModel<T>
    {
		public string getMethod();
		public string getService();
		public bool needAuthorize();
		public string getOrder();
		public string getField();
	}

	public abstract class ApiModel<T> : IApiModel<T>
	{
		public const string service_Struttura = "/e3rest/api/struttura-service-v1/";

		public const string service_Rendicontazione = "/e3rest/api/rendicontazione-doc-service-v1/";

		public abstract string getMethod();

		public abstract string getService();

		public abstract bool needAuthorize();

		public abstract string getOrder();

		public abstract string getField();
	}
}
