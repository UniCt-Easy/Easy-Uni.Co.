
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
        // ATTIVITA DIDATTICA
        // ==============================================================
        public List<insegn> AllAttivitaDidattica()
		{
			return _context.insegns.AsNoTracking().ToList();
		}

		public insegn AddAttivitaDidattica(int idinsegn, string codice, string denominazione, int? idcorsostudiokind, int? idstruttura, int? idcorsostudio)
		{
			try
			{
				insegn csk = new insegn()
				{
					idinsegn = idinsegn,
					codice = codice,
					denominazione = denominazione,
					idcorsostudiokind = idcorsostudiokind,
					idstruttura = idstruttura,
					idcorsostudio = idcorsostudio,

					Ct = DateTime.Now,
					Cu = common.cu,

					Lt = DateTime.Now,
					Lu = common.cu
				};

				_context.Add(csk);
				_context.SaveChanges();

				return csk;
			}
			catch (Exception Ex)
			{
				common.logInfo($"AddAttivitaDidattica({idinsegn}, {codice}, {denominazione}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
				return null;
			}
		}
	}
}
