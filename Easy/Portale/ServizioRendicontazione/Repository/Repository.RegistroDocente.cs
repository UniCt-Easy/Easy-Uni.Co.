
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


using ServizioRendicontazione.Models;

namespace ServizioRendicontazione.Repositories
{
	public partial class Repository
	{
		public List<registryMin> RegistryByCf(List<string> listCf)
		{
			List<registryMin> regs = _context.registries
				.Where(w => listCf.Contains(w.Cf))
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
	}
}
