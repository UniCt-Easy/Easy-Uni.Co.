
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


namespace FirmaRemotaUsign.ApiModels
{
    public interface IApiModel<T>
    {
		string getMethod();
		string getService();
		bool needAuthorize();
		bool isPost();
        int code { get; set; }
        string message { get; set; }
    }

	public abstract class ApiModel<T> : IApiModel<T>
	{
		public abstract string getMethod();

		public abstract string getService();

		public abstract bool needAuthorize();
		
		public abstract bool isPost();

        public int code { get; set; }

        public string message { get; set; }
	}
}


// 1) CreateProcess
// 2) Upload
// 3) SendOtpToUser
// 4) SignProcess
// 5) DownloadSingleFile
