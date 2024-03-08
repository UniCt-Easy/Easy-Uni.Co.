
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


using Creport.Report;

namespace Creport {
    public class ElementProperty {
        private static string id1;
        private static string id2;
        private static string name;
        private static string tipo;

        public static string Id1 {
            get {
                return id1 ?? (id1 = ReflectOn<Element>.GetProperty(p => p.Id1).Name);
            }
        }

        public static string Id2 {
            get {
                return id2 ?? (id2 = ReflectOn<Element>.GetProperty(p => p.Id2).Name);
            }
        }

        public static string Name {
            get {
                return name ?? (name = ReflectOn<Element>.GetProperty(p => p.Name).Name);
            }
        }

        public static string Tipo {
            get {
                return tipo ?? (tipo = ReflectOn<Element>.GetProperty(p => p.Tipo).Name);
            }
        }

    }
}
