
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
        // PORZIONE ANNO
        // ==============================================================
        public List<didprogporzanno> AllPorzioneAnno(List<int> iddidprogannoList)
        {
            return _context.didprogporzannos.Where(
                w => iddidprogannoList.Contains(w.iddidproganno)
            ).ToList();
        }

        public didprogporzanno AddPorzioneAnno(int idcorsostudio,
											   int iddidprog,
											   int iddidprogcurr,
											   int iddidprogori,
											   int iddidproganno,
											  int? iddidprogporzannokind,
											string aa,
										 DateTime? start,
										 DateTime? stop,
											string title)
		{
			int iddidprogporzanno = 0;
			if (_context.didprogporzannos.Any())
				iddidprogporzanno = _context.didprogporzannos.Max(m => m.iddidprogporzanno);

			iddidprogporzanno++;

			didprogporzanno dppa = new didprogporzanno()
			{
				iddidprogporzanno = iddidprogporzanno,
				iddidproganno = iddidproganno,
				iddidprogori = iddidprogori,
				iddidprogcurr = iddidprogcurr,
				iddidprog = iddidprog,
				idcorsostudio = idcorsostudio,
				aa = aa,
				iddidprogporzannokind = iddidprogporzannokind,
				start = start,
				stop = stop,
				title = title,

				indice = null
			};

			_context.Add(dppa);
			_context.SaveChanges();

			return dppa;
		}		
	}
}
