
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
        // AFFIDAMENTO
        // ==============================================================
        public List<affidamento> AllAffidamento(List<int> idcanaleList)
        {
            return _context.affidamentos.Where(
                w => idcanaleList.Contains(w.idcanale)
            ).ToList();
        }

        public affidamento AddAffidamento(int idcorsostudio,
										  int iddidprog, 
										  int iddidprogcurr, 
										  int iddidprogori, 
										  int iddidproganno, 
										  int iddidprogporzanno, 
										  int idattivform,
										  int idcanale,
										  int idsede, 
									   string aa, 
									   string title,
										 int? iderogazkind,
										 int? idreg_docenti,
										  int idaffidamentokind,
									   string jsonancestor)
		{
			int idaffidamento = 0;
			if (_context.affidamentos.Any())
				idaffidamento = _context.affidamentos.Max(m => m.idaffidamento);

			idaffidamento++;

			affidamento aff = new affidamento()
			{
				idaffidamento = idaffidamento,
				idattivform = idattivform,
				iddidprogporzanno = iddidprogporzanno,
				iddidproganno = iddidproganno,
				iddidprogori = iddidprogori,
				iddidprogcurr = iddidprogcurr,
				iddidprog = iddidprog,
				idcorsostudio = idcorsostudio,
				idcanale = idcanale,
				aa = aa,
				idsede = idsede,
				title = title,

				iderogazkind = iderogazkind,
				idreg_docenti = idreg_docenti,
				idaffidamentokind = idaffidamentokind,

				riferimento = "N",
				gratuito = "S",

				paridaffidamento = null,
				freqobbl = null,
				frequenzaminima = null,
				frequenzaminimadebito = null,				
				json = null,
				jsonancestor = jsonancestor,
				orariric = null,
				orariric_en = null,
				prog = null,
				prog_en = null,				
				start = null,
				stop = null,
				testi = null,
				testi_en = null,
				urlcorso = null
			};

			_context.Add(aff);
			_context.SaveChanges();

			return aff;
		}		
	}
}
