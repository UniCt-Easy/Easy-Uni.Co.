
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
using System;

namespace ServizioRendicontazione.Repositories
{
	public partial class Repository
	{
		// ==============================================================
		// CANALE
		// ==============================================================
		public List<canale> AllCanale(List<int> idattivformList)
        {
            return _context.canales.AsNoTracking().Where(w => idattivformList.Contains(w.idattivform)).ToList();
        }

		public canale AddCanale(int idcorsostudio,
								int iddidprog,
								int iddidprogcurr,
								int iddidprogori,
								int iddidproganno,
								int iddidprogporzanno,
								int idattivform,
								int idsede,
							 string aa,
							 string title)
		{
			try
			{
				int idcanale = 0;
				if (_context.canales.Any())
					idcanale = _context.canales.AsNoTracking().Max(m => m.idcanale);

				idcanale++;

				canale c = new canale()
				{
					idcanale = idcanale,
					idattivform = idattivform,
					iddidprogporzanno = iddidprogporzanno,
					iddidproganno = iddidproganno,
					iddidprogori = iddidprogori,
					iddidprogcurr = iddidprogcurr,
					iddidprog = iddidprog,
					idcorsostudio = idcorsostudio,
					aa = aa,
					idsede = idsede,
					title = title,

					CUIN = null,
					numerostud = null,
					sortcode = null,

					Ct = DateTime.Now,
					Cu = common.cu,

					Lt = DateTime.Now,
					Lu = common.cu
				};

				_context.Add(c);
				_context.SaveChanges();

				return c;
			}
			catch (Exception Ex)
			{
				common.logInfo($"AddCanale({idcorsostudio}, {iddidprog}, {aa}, {title}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
				return null;
			}
		}
	}
}
