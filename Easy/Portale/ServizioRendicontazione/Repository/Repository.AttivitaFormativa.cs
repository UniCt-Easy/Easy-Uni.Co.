
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
        // ATTIVITA' FORMATIVA
        // ==============================================================
        public List<attivform> AllAttivitaFormativa(List<int> iddidprogporzannoList)
        {
            return _context.attivforms.Where(
                w => iddidprogporzannoList.Contains(w.iddidprogporzanno)
            ).ToList();
        }

        public attivform AddAttivitaFormativa(int idcorsostudio,
											  int iddidprog,
											  int iddidprogcurr,
											  int iddidprogori,
											  int iddidproganno,
											  int iddidprogporzanno,
											  int idsede,
											  int idinsegn,
										   string aa,
										   string title)
		{
			int idattivform = 0;
			if (_context.attivforms.Any())
				idattivform = _context.attivforms.Max(m => m.idattivform);

			int sortcode = 0;
			if (_context.areadidatticas.Any())
				sortcode = _context.areadidatticas.Max(m => m.sortcode);

			idattivform++;
			sortcode++;

			attivform at = new attivform()
			{
				idattivform = idattivform,
				iddidprogporzanno = iddidprogporzanno,
				iddidproganno = iddidproganno,
				iddidprogori = iddidprogori,
				iddidprogcurr = iddidprogcurr,
				iddidprog = iddidprog,
				idcorsostudio = idcorsostudio,
				aa = aa,
				idsede = idsede,
				idinsegn = idinsegn,
				title = title,
                sortcode = sortcode,

                start = null,
				stop = null,
				iddidproggrupp = null,
				idinsegninteg = null,
				obbform = null,
				obbform_en = null,
				tipovalutaz = null
			};

			_context.Add(at);
			_context.SaveChanges();

			return at;
		}		
	}
}
