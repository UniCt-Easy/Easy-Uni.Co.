
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
		// CORSO STUDIO NORMA
		// ==============================================================
		public List<corsostudionorma> AllCorsoStudioNorma()
		{
			return _context.corsostudionormas.AsNoTracking().ToList();
		}

		public corsostudionorma AddCorsoStudioNorma(string title, int idistitutokind)
		{
			try
			{
				int idcorsostudionorma = 0;
				if (_context.corsostudionormas.Any())
					idcorsostudionorma = _context.corsostudionormas.AsNoTracking().Max(m => m.idcorsostudionorma);

				idcorsostudionorma++;

				corsostudionorma cns = new corsostudionorma()
				{
					idcorsostudionorma = idcorsostudionorma,
					idistitutokind = idistitutokind,
					title = title,

					Lt = DateTime.Now,
					Lu = common.cu
				};

				_context.Add(cns);
				_context.SaveChanges();

				return cns;
			}
			catch (Exception Ex)
			{
				common.logInfo($"AddCorsoStudioNorma({idistitutokind}, {title}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
				return null;
			}
		}
	}
}
