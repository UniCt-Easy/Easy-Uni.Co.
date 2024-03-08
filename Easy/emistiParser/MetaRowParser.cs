
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


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//using metadatalibrary;

//namespace MetaRowParser {
//    class Definition {
//        public int StartIndex { get; }
//        public int Length { get; }

//        public int StopIndex => StartIndex + Length;

//        public Definition(int start, int len) {
//            StartIndex = start;
//            Length = len;
//        }

//        public bool Overlaps(Definition d) {
//            return StartIndex < d.StopIndex || d.StartIndex < StopIndex;
//        }
//    }

//    class DefinitionEqualityComparer : EqualityComparer<Definition> {
//        public override bool Equals(Definition x, Definition y) {
//            return x.Overlaps(y) || y.Overlaps(x);
//        }

//        public override int GetHashCode(Definition obj) {
//            return obj.GetHashCode();
//        }
//    }

//    interface IMetaRowParser {
//        void Define(string propertyName, int start, int length);
//        void Parse(string line, dynamic output);
//    }

//    class MetaRowParser<TMetaRow> where TMetaRow : MetaRow {

//        private readonly Dictionary<PropertyInfo, Definition> propertiesDefinitions = new Dictionary<PropertyInfo, Definition>();

//        public MetaRowParser() {

//            foreach (var p in typeof(TMetaRow).GetProperties()) {
//                propertiesDefinitions.Add(p, new Definition(0, 0));
//            }
//        }

//        public void Define(string propertyName, int start, int length) {

//            var prop = typeof(TMetaRow).GetProperty(propertyName);
//            var def = new Definition(start, length);

//            if (propertiesDefinitions.ContainsKey(prop)) {

//                if (propertiesDefinitions.Values.Contains(def, new DefinitionEqualityComparer())) {

//                    propertiesDefinitions.Add(prop, def);

//                }
//                else {

//                    throw new InvalidOperationException(string.Format("impossibile definire {0}, rilevata una collisione con una definizione esistente", propertyName));

//                }

//            }
//            else {

//                throw new KeyNotFoundException(string.Format("la proprietà {0} non fa parte di {1}", propertyName, typeof(TMetaRow).Name));
//            }
//        }

//        public void Parse(string line, dynamic destRow) {

//            var definedProperties = propertiesDefinitions.Where(p => p.Value != new Definition(0, 0));

//            foreach (var pd in propertiesDefinitions) {

//                PropertyInfo pi = pd.Key;
//                Definition d = pd.Value;

//                var stringValue = line.Substring(d.StartIndex, d.Length);

//                if (pi.PropertyType == typeof(string))
//                    pi.SetValue(destRow, stringValue);

//                if (pi.PropertyType == typeof(int))
//                    pi.SetValue(destRow, int.Parse(stringValue));

//                if (pi.PropertyType == typeof(DateTime))
//                    pi.SetValue(destRow, DateTime.Parse(stringValue));
//            }
//        }
//    }
//}
