
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
        // ANNO
        // ==============================================================
        public List<didproganno> AllAnno(List<int> iddidprogoriList)
        {
            return _context.didprogannos.Where(
                w => iddidprogoriList.Contains(w.iddidprogori)
            ).ToList();
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
			int iddidproganno = 0;
			if (_context.didprogannos.Any())
				iddidproganno = _context.didprogannos.Max(m => m.iddidproganno);

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
				title = title
			};

			_context.Add(dpa);
			_context.SaveChanges();

			return dpa;
		}		
	}
}
