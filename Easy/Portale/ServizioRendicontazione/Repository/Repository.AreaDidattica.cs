
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
		// AREA DIDATTICA
		// ==============================================================
		public List<areadidattica> AllAreaDidattica()
		{
			return _context.areadidatticas.ToList();
		}

		public areadidattica AddAreaDidattica(string title, int idmacroareadidattica, int idcorsostudiokind)
		{
			int idareadidattica = 0;
			if (_context.areadidatticas.Any())
				idareadidattica = _context.areadidatticas.Max(m => m.idareadidattica);

			int sortcode = 0;
			if (_context.areadidatticas.Any())
				sortcode = _context.areadidatticas.Max(m => m.sortcode);

			idareadidattica++;
			sortcode++; 

			areadidattica a = new areadidattica()
			{
				idareadidattica = idareadidattica,
				active = "S",
				idmacroareadidattica = idmacroareadidattica,
				idcorsostudiokind = idcorsostudiokind,
				title = title,
				sortcode = sortcode,
				subtitle = null
			};

			_context.Add(a);
			_context.SaveChanges();

			return a;
		}
	}
}
