
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
		// TIPO LEZIONE
		// ==============================================================
		public List<orakind> AllTipoLezione()
		{
			return _context.orakinds.ToList();
		}

		public orakind AddTipoLezione(string title)
		{
			int idorakind = 0;
			if (_context.orakinds.Any())
				idorakind = _context.orakinds.Max(m => m.idorakind);

			int sortcode = 0;
			if (_context.orakinds.Any())
				sortcode = _context.orakinds.Max(m => m.idorakind);

			idorakind++;
			sortcode++;

			orakind csk = new orakind()
			{
				idorakind = idorakind,
				active = "S",
				description = null,
				sortcode = sortcode,
				ripetizioni = "N",
				title = title
			};

			_context.Add(csk);
			_context.SaveChanges();

			return csk;
		}
	}
}
