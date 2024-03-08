
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
        // LEZIONE
        // ==============================================================
        public List<lezione> AllLezione(List<int> idaffidamentoList)
        {
            return _context.leziones.Where(
                w => idaffidamentoList.Contains(w.idaffidamento)
            ).ToList();
        }

        public lezione AddLezione(int idcorsostudio,
								  int iddidprog,
								  int iddidprogcurr,
								  int iddidprogori,
								  int iddidproganno,
								  int iddidprogporzanno,
								  int idattivform,
								  int idsede,
								  int idaffidamento,
								  int idcanale,
								  int idreg_docenti,
							 DateTime start,
							 DateTime stop,
							string aa)
		{
			int idlezione = 0;
			if (_context.leziones.Any())
				idlezione = _context.leziones.Max(m => m.idlezione);

			idlezione++;

			lezione lez = new lezione()
			{
				idlezione = idlezione,
				idaffidamento = idaffidamento,
				idcanale = idcanale,
				idattivform = idattivform,
				iddidprogporzanno = iddidprogporzanno,
				iddidproganno = iddidproganno,
				iddidprogori = iddidprogori,
				iddidprogcurr = iddidprogcurr,
				iddidprog = iddidprog,
				idsede = idsede,
				idcorsostudio = idcorsostudio,
				aa = aa,
				idreg_docenti = idreg_docenti,
				start = start,
				stop = stop,

				idaula = 0,
				idedificio = 0,

				nonsvolta = null,
				stage = null,
				visita = null

			};

			_context.Add(lez);
			_context.SaveChanges();

			return lez;
		}

        public void DeleteLezione(int idlezione)
        {
            lezione lez = _context.leziones.FirstOrDefault(w => w.idlezione == idlezione);

            _context.Remove(lez);
            _context.SaveChanges();
        }
    }
}
