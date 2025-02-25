
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
		// ====================================================
		// Add RendicontaAltro
		// ====================================================
		public void AddRendicontaAltro(List<RendicontAltroMin> rendicontAltroMinList)
		{
			try
			{
				int idrendicontaltro = _context.rendicontaltros.AsNoTracking().Max(m => m.idrendicontaltro);

				foreach (RendicontAltroMin rendicontAltroMin in rendicontAltroMinList)
				{
					// indice++
					idrendicontaltro++;

					// 2023/2024
					DateTime nuovoAnnoAccademico = new DateTime(rendicontAltroMin.data.Year, 11, 1);
					int aaaa = rendicontAltroMin.data.Year + (rendicontAltroMin.data > nuovoAnnoAccademico ? 0 : -1);
					string aa = $"{aaaa}/{aaaa + 1}";

					// ==============================================================
					// Nuovo RendicontAltro
					// ==============================================================
					rendicontaltro s = new rendicontaltro()
					{
						idrendicontaltro = idrendicontaltro,
						aa = aa,
						idreg_docenti = rendicontAltroMin.idreg_docenti,
						data = rendicontAltroMin.data,
						idrendicontaltrokind = rendicontAltroMin.idkind,
						ore = rendicontAltroMin.ore,

						Ct = DateTime.Now,
						Cu = common.cu,

						Lt = DateTime.Now,
						Lu = common.cu

					};

					_context.Add(s);
				}

				_context.SaveChanges();
			}
			catch (Exception Ex)
			{
				common.logInfo($"AddRendicontaAltro(): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}
		}

		// ====================================================
		// Remove RendicontaAltro
		// ====================================================
		public void RemoveRendicontaAltro(List<RendicontAltroMin> rendicontAltroMinList)
		{
			try
			{
				// ====================================================
				// Remove
				// ====================================================
				foreach (RendicontAltroMin rendicontAltroMin in rendicontAltroMinList)
				{
					rendicontaltro s = _context.rendicontaltros
						.AsNoTracking()
						.FirstOrDefault(w =>
							w.idreg_docenti == rendicontAltroMin.idreg_docenti &&
							w.idrendicontaltrokind == rendicontAltroMin.idkind &&
							w.data == rendicontAltroMin.data);

					if (s != null)
						_context.rendicontaltros.Remove(s);
				}

				_context.SaveChanges();
			}
			catch (Exception Ex)
			{
				common.logInfo($"RemoveRendicontaAltro(): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}
		}

		public List<RendicontAltroMin> GetRendicontaAltro(int idregdocenti, int yearStart)
		{
			// select distinct data, idrendicontaltrokind from rendicontaltro where idreg_docenti = 50033 order by data
			return _context.rendicontaltros.AsNoTracking()
				.Where(w => w.idreg_docenti == idregdocenti && w.data.Year >= yearStart)
				.Select(s => new RendicontAltroMin { data= s.data, idkind = s.idrendicontaltrokind, ore = s.ore, idreg_docenti = idregdocenti })
				.ToList();
		}

		public void ClearRendicontaAltro()
		{
			string sql = @"delete rendicontaltro where cu = 'ApiEsse3';";

			_context.Database.ExecuteSqlRaw(sql);
		}
	}
}
