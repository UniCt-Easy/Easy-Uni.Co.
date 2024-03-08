
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
using System.Collections.ObjectModel;

namespace Creport {
    public class MainTableDataSource {
        public static Collection<Element> Create() {
            return new Collection<Element>
                {
                    new Element
                        {
                            Id1 = 2017,
                            Id2 = 1,
                            Tipo = "AGR -Generico NoAvcp",
                            Name = -10,
                        },
                    new Element
                        {
                            Id1 = 2017,
                            Id2 = 2,
                            Tipo = "AGR -Generico NoAvcp",
                            Name = 29404.2,
                        },
                    new Element
                        {
                            Id1 = 2017,
                            Id2 = 3,
                            Tipo = "AGR -Generico NoAvcp",
                            Name = 253253,
                        },
                    new Element
                        {
                            Id1 = 2016,
                            Id2 = 1,
                            Tipo = "AGR -Generico NoAvcp",
                            Name = 0,
                        },
                                        new Element
                        {
                            Id1 = 2016,
                            Id2 = 1,
                            Tipo = "AGR -Specialistico NoAvcp",
                            Name = 52,
                        },
                     new Element
                        {
                            Id1 = 2016,
                            Id2 = 2,
                            Tipo = "AGR -Generico NoAvcp",
                            Name = 553,
                        },
                     new Element
                        {
                            Id1 = 2016,
                            Id2 = 3,
                            Tipo = "AGR -Generico NoAvcp",
                            Name = 2334,
                        },
                };
        }
    }
}
