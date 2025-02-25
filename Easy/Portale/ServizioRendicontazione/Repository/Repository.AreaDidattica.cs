
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


using Microsoft.EntityFrameworkCore;
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
			return _context.areadidatticas.AsNoTracking().ToList();
		}

		public areadidattica AddAreaDidattica(string title, int idmacroareadidattica, int idcorsostudiokind)
		{
			try
			{
				int idareadidattica = 0;
				if (_context.areadidatticas.Any())
					idareadidattica = _context.areadidatticas.AsNoTracking().Max(m => m.idareadidattica);

				int sortcode = 0;
				if (_context.areadidatticas.Any())
					sortcode = _context.areadidatticas.AsNoTracking().Max(m => m.sortcode);

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
					subtitle = null,

					Ct = DateTime.Now,
					Cu = common.cu,

					Lt = DateTime.Now,
					Lu = common.cu
				};

				_context.Add(a);
				_context.SaveChanges();

				return a;
			}
			catch (Exception Ex)
			{
				common.logInfo($"AddAreaDidattica({idmacroareadidattica}, {idcorsostudiokind}, {title}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
				return null;
			}
		}
	}
}
