
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
        // ANNO
        // ==============================================================
        public List<didproganno> AllAnno(List<int> iddidprogoriList)
        {
            return _context.didprogannos.AsNoTracking().Where(w => iddidprogoriList.Contains(w.iddidprogori)).ToList();
        }

		public didproganno AddAnno(int idcorsostudio,
								   int iddidprog,
								   int iddidprogcurr,
								   int iddidprogori,
								string aa,
								  int? anno,
								string title,
							  decimal? creditiformativi)
		{
			try
			{
				int iddidproganno = 0;
				if (_context.didprogannos.Any())
					iddidproganno = _context.didprogannos.AsNoTracking().Max(m => m.iddidproganno);

				iddidproganno++;

				didproganno dpa = new didproganno()
				{
					iddidproganno = iddidproganno,
					iddidprogori = iddidprogori,
					iddidprogcurr = iddidprogcurr,
					iddidprog = iddidprog,
					aa = aa,
					idcorsostudio = idcorsostudio,
					anno = anno,
					cf = creditiformativi,
					title = title,

					Ct = DateTime.Now,
					Cu = common.cu,

					Lt = DateTime.Now,
					Lu = common.cu
				};

				_context.Add(dpa);
				_context.SaveChanges();

				return dpa;
			}
			catch (Exception Ex)
			{
				common.logInfo($"AddAnno({idcorsostudio}, {iddidprog}, {aa}, {title}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
				return null;
			}
		}
	}
}
