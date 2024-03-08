
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
		// CLASSE SCUOLA
		// ==============================================================
		public List<classescuola> AllClasseScuola()
		{
			return _context.classescuolas.ToList();
		}

		public classescuola AddClasseScuola(string sigla, string title, string idclassescuolakind, int? idcorsostudionorma, int? idclassescuolaarea)
		{
			int idclassescuola = 0;
			if (_context.classescuolas.Any())
				idclassescuola = _context.classescuolas.Max(m => m.idclassescuola);

			idclassescuola++;

			classescuola csk = new classescuola()
			{
				idclassescuola = idclassescuola,
				idclassescuolaarea = idclassescuolaarea,
				idclassescuolakind = idclassescuolakind,
				idcorsostudionorma = idcorsostudionorma,
				indicecineca = null,
				obbform = null,
				prospocc = null,
				sigla = sigla,
				title  = title
			};
		
			_context.Add(csk);
			_context.SaveChanges();

			return csk;
		}
	}
}
