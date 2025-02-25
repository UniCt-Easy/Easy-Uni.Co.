
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
		public List<registryMin> RegistryByCf(List<string> listCf, int lastYear, int thisYear)
		{
			// Lista membri con progetto nel currYear
			List<int> listaMembriConProgetto = _context.progettoresponsabiliviews
				.AsNoTracking()
				.Where(w => lastYear <= w.year && w.year <= thisYear)
				.Select(s => s.idreg_membro ?? 0)
				.Distinct()
				.ToList();

			List<registryMin> regs = _context.registries
				.AsNoTracking()
				.Where(w => listCf.Contains(w.Cf) && listaMembriConProgetto.Contains(w.Idreg))
				.OrderBy(w => w.Cf)
				.ThenByDescending(w => w.Active)
				.Select(s => new registryMin() { Idreg = s.Idreg, Cf = s.Cf })
				.ToList();

			List<registryMin> ret = new List<registryMin>();
			foreach (string cf in listCf)
			{
				if (regs.Any(w => w.Cf == cf))
				{
					ret.Add(new registryMin()
					{
						Cf = cf,
						Idreg = regs.FirstOrDefault(w => w.Cf == cf).Idreg
					});
				}
			}

			return ret;
		}

        public string RegistryCfByRegId(int regId)
        {
            return _context.registries.AsNoTracking().FirstOrDefault(w => w.Idreg == regId)?.Cf;
        }

        public int RegistryIdByRegFc(string cf)
        {
            return _context.registries.AsNoTracking().FirstOrDefault(w => w.Cf == cf)?.Idreg ?? 0;
        }

        public List<lezdb> Lezioni(int regId)
        {
            return _context.leziones.AsNoTracking()
				.Where(w => w.idreg_docenti == regId)
				.OrderBy(o => o.start)
				.Select(s => new lezdb {
					data = s.start, 
					id = s.idlezione, 
					valdb = s.start.ToString("HH:mm") + " - " + s.stop.ToString("HH:mm") 
				})
				.ToList();
        }

        public void DelLez(int lezione)
        {
            lezione lez = _context.leziones.AsNoTracking().FirstOrDefault(w => w.idlezione == lezione);
			if (lez != null)
			{
				_context.leziones.Remove(lez);
				_context.SaveChanges();
            }
        }

        public List<diadb> Diari(int regId)
        {
            return _context.rendicontaltros.AsNoTracking()
				.Where(w => w.idreg_docenti == regId)
				.OrderBy(o => o.data)
				.Select(s => new diadb() {
					data = s.data,
					id = s.idrendicontaltro,
					idrendicontaltrokind = s.idrendicontaltrokind,
					valdb = s.ore.ToString("F2") + " ore"
				}).ToList();
        }

        public void DelDia(int idDiario)
        {
            rendicontaltro dia = _context.rendicontaltros.AsNoTracking().FirstOrDefault(w => w.idrendicontaltro == idDiario);
            if (dia != null)
            {
                _context.rendicontaltros.Remove(dia);
                _context.SaveChanges();
            }
        }
    }
}
