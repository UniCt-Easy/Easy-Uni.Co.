
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
		// DIDATTICA PROGRAMMATA
		// ==============================================================
		public List<didprog> AllDidatticaProgrammata(string aa)
		{
            return _context.didprogs.Where(w => w.aa == aa).ToList();
        }

        public didprog AddDidatticaProgrammata(int idcorsostudio,
										 string aa,
										 string title,
										 string title_en,
										 string codice,
										   int? annosolare,
										   int? idareadidattica,
										   int? iderogazkind,
										   int? idsede,
										 string website)
		{
			int iddidprog = 0;
			if (_context.didprogs.Any())
				iddidprog = _context.didprogs.Max(m => m.iddidprog);

			iddidprog++;

			didprog dp = new didprog()
			{
				iddidprog = iddidprog,
				idcorsostudio = idcorsostudio,
				aa = aa,
				title = title,
				title_en = title_en,
				codice = codice,
				annosolare = annosolare,
				idareadidattica = idareadidattica,
				iderogazkind = iderogazkind,
				idsede = idsede,
				website = website,

				codicemiur = null,
				attribdebiti = null,
				ciclo = null,
				dataconsmaxiscr = null,
				freqobbl = null,
				idconvenzione = null,
				iddidprognumchiusokind = null,
				iddidprogsuddannokind = null,
				idgraduatoria = null,
				idnation_lang = null,
				idnation_lang2 = null,
				idnation_langvis = null,
				idreg_docenti = null,
				idsessione = null,
				idtitolokind = null,
				immatoltreauth = null,
				modaccesso = null,
				modaccesso_en = null,
				obbformativi = null,
				obbformativi_en = null,
				preimmatoltreauth = null,
				progesamamm = null,
				prospoccupaz = null,
				provafinaledesc = null,
				regolamentotax = null,
				regolamentotaxurl = null,
				startiscrizioni = null,
				stopiscrizioni = null,
				utenzasost = null
			};

			_context.Add(dp);
			_context.SaveChanges();

			return dp;
		}		
	}
}
