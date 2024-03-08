
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
        // ==============================================================
        // ORIENTAMENTO
        // ==============================================================
        public List<didprogori> AllOrientamento(List<int> iddidprogcurrList)
        {
            return _context.didprogoris.Where(
                w => iddidprogcurrList.Contains(w.iddidprogcurr)
            ).ToList();
        }

        public didprogori AddOrientamento(int idcorsostudio,
										  int iddidprog,
										  int iddidprogcurr,
									   string title)
		{
			int iddidprogori = 0;
			if (_context.didprogoris.Any())
				iddidprogori = _context.didprogoris.Max(m => m.iddidprogori);

			iddidprogori++;

			didprogori dpo = new didprogori()
			{
				iddidprogori = iddidprogori,
				iddidprogcurr = iddidprogcurr,
				iddidprog = iddidprog,
				idcorsostudio = idcorsostudio,
				codice = null,
				title = title
			};

			_context.Add(dpo);
			_context.SaveChanges();

			return dpo;
		}		
	}
}
