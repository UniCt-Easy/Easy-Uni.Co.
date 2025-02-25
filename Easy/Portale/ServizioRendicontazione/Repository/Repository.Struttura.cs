
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
		// STRUTTURA
		// ==============================================================
		public List<struttura> AllStruttura()
		{
			return _context.strutturas.AsNoTracking().ToList();
		}

		public struttura AddStruttura(int idstruttura, string codice, string denominazione, string denominazioneEng, int idstrutturakind, int idcorsostudio, int idreg, int idsede, int? paridstruttura)
		{
			try
			{
				struttura csk = new struttura()
				{
					idstruttura = idstruttura,
					codice = codice,
					title = denominazione,
					title_en = denominazioneEng,
					idstrutturakind = idstrutturakind,
					idreg = idreg,
					idsede = idsede,
					active = "S",
					paridstruttura = paridstruttura,

					codiceipa = null,
					email = null,
					fax = null,
					idaoo = null,
					idupb = null,
					telefono = null,
					pesoindicatori = null,
					pesoobiettivi = null,
					pesoprogaltreuo = null,
					pesoproguo = null,

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
				common.logInfo($"AddStruttura({idstruttura}, {codice}, {denominazione}, {denominazioneEng}, {idstrutturakind}, {idcorsostudio}, {idreg}, {idsede}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
				return null;
			}
		}

		public int UpdateStruttura(string strutturaDes, string codice, string denominazioneEng)
		{
			try
			{
				if (_context.strutturas.Any(w => w.title == strutturaDes))
				{
					struttura s = _context.strutturas.AsNoTracking().FirstOrDefault(w => w.title == strutturaDes);

					if (string.IsNullOrEmpty(s.codice) || string.IsNullOrEmpty(s.title_en))
					{
						if (string.IsNullOrEmpty(s.codice))
							s.codice = codice;

						if (string.IsNullOrEmpty(s.title_en))
							s.title_en = denominazioneEng;

						_context.SaveChanges();
					}

					return s.idstruttura;
				}
				return 0;
			}
			catch (Exception Ex)
			{
				common.logInfo($"UpdateStruttura({strutturaDes}, {codice}, {denominazioneEng}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
				return 0;
			}
		}
	}
}
