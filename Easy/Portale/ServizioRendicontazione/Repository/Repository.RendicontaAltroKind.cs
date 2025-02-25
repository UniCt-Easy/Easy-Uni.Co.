
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
        // RENDICONTAALTROKIND
        // ==============================================================
        public bool AnyRendicontaAltroKind(string title)
		{
			return _context.rendicontaltrokinds.AsNoTracking().Any(w => w.title == title);
		}

		public void AddRendicontaAltroKind(string title)
		{
			try
			{
				int idrendicontaltrokind = 0;
				if (_context.rendicontaltrokinds.Any())
					idrendicontaltrokind = _context.rendicontaltrokinds.AsNoTracking().Max(m => m.idrendicontaltrokind);

				idrendicontaltrokind++;

				rendicontaltrokind s = new rendicontaltrokind()
				{
					idrendicontaltrokind = idrendicontaltrokind,
					active = "S",
					description = title,
					sortcode = 0,
					title = title,

					Ct = DateTime.Now,
					Cu = common.cu,

					Lt = DateTime.Now,
					Lu = common.cu
				};

				_context.Add(s);
				_context.SaveChanges();
			}
			catch (Exception Ex)
			{
				common.logInfo($"AddRendicontaAltroKind({title}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}
		}

		public List<RendicontaltroKindTitle> GetAllRendicontaAltro()
		{
			return _context.rendicontaltrokinds
                .AsNoTracking()
                .Select(s => 
					new RendicontaltroKindTitle
					{
							idkind = s.idrendicontaltrokind,
							title = s.title
						})
				.ToList();
		}
	}
}
