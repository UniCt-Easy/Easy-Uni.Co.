
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
		// SEDE
		// ==============================================================
		public List<sede> AllSede()
		{
			return _context.sedes.ToList();
		}

		public sede AddSede(int idreg, string title)
		{
			int idsede = 0;
			if (_context.sedes.Any())
				idsede = _context.sedes.Max(m => m.idsede);

			int? idCity = GetIdCity(title);

			idsede++;

			sede s = new sede()
			{
				idsede = idsede,
				title = title,
				idcity = idCity,
				idnation = 1,
				idreg = idreg,

				address = null,
				annotations = null,
				cap = null,
				idsedemiur = null,
				latitude = null,
				longitude = null
			};

			_context.Add(s);
			_context.SaveChanges();

			return s;
		}
	}
}
