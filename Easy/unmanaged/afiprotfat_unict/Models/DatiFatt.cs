/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using System.Collections.Generic;

namespace afiprotfat_unict.Models {

    public class Attach {
        public string Base64 { get; set; }
        public string Nome { get; set; }
    }

    public class DatiFatt {
        public List<Attach> Attach { get; set; }
        public string CFOper { get; set; }
        public string DataProt { get; set; }
        public string Indirizzo { get; set; }
        public string Mezzo { get; set; }
        public string NumProt { get; set; }
        public string Oggetto { get; set; }
        public string PartitaIva { get; set; }
        public string RagSoc { get; set; }
        public long Tipo { get; set; }
        public string UOR { get; set; }
    }
}
