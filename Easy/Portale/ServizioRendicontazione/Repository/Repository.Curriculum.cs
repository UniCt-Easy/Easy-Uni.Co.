
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
        // CURRICULUM
        // ==============================================================
        public List<didprogcurr> AllCurriculum(List<int> iddidprogList)
        {
            return _context.didprogcurrs.AsNoTracking().Where(w => iddidprogList.Contains(w.iddidprog)).ToList();
        }

		public didprogcurr AddCurriculum(int iddidprog,
										 int idcorsostudio,
									  string codice,
									  string title)
		{
			try
			{
				int iddidprogcurr = 0;
				if (_context.didprogcurrs.Any())
					iddidprogcurr = _context.didprogcurrs.AsNoTracking().Max(m => m.iddidprogcurr);

				iddidprogcurr++;

				didprogcurr dpc = new didprogcurr()
				{
					iddidprogcurr = iddidprogcurr,
					iddidprog = iddidprog,
					idcorsostudio = idcorsostudio,
					codice = codice,
					title = title,

					codicemiur = null,

					Ct = DateTime.Now,
					Cu = common.cu,

					Lt = DateTime.Now,
					Lu = common.cu
				};

				_context.Add(dpc);
				_context.SaveChanges();

				return dpc;
			}
			catch (Exception Ex)
			{
				common.logInfo($"AddCurriculum({idcorsostudio},{iddidprog}, {title}, {codice}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
				return null;
			}
		}	
	}
}
