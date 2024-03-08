
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


using ServizioRendicontazione.Models;

namespace ServizioRendicontazione.Repositories
{
	public partial class Repository
	{
		// ==============================================================
		// CORSO DI STUDIO
		// ==============================================================
		public List<corsostudio> AllCorsoStudio()
		{
			return _context.corsostudios.ToList();
		}

		public corsostudio AddCorsoStudio(int idcorsostudio,
										 int? annoistituz,
									   string codice, 
									   string title, 
									   string title_en,
										  int idcorsostudiokind,
									     int? idcorsostudiolivello,
									     int? idcorsostudionorma,
									     int? idduratakind,
									     int? idstruttura,
									     int? durata)
		{
			corsostudio cs = new corsostudio()
			{
				idcorsostudio = idcorsostudio,		// Id Corso di Studio è quello di Esse3
				annoistituz = annoistituz,
				codice = codice,
				title = title,
				title_en = title_en,
				idcorsostudiokind = idcorsostudiokind,
				durata = durata,
				idcorsostudiolivello = idcorsostudiolivello,
				idcorsostudionorma = idcorsostudionorma,
				idduratakind = idduratakind,
				idstruttura = idstruttura,

				almalaureasurvey = null,
				basevoto = null,
				codicemiur = null,
				codicemiurlungo = null,
				obbform = null,
				sboccocc = null,
				crediti = null
			};

			_context.Add(cs);
			_context.SaveChanges();

			return cs;
		}
	}
}
