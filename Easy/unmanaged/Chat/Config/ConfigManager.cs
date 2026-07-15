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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chat.Config {

    // questa classe generica potrebbe essere utilizzata per fare il parse della configurazione su db che sia in un campo nel formato "valore1|valore2|...|valoreN"
    // andrebbe definita in una dipendenza comune (mdl?)
    // si potrebbe usare il campo description della tabella app_config per definire lo schema del campo param e fare un parse dinamico di esso (forse meglio) se non si volesse usare T
    // ed evitare di creare uno schema statico sul codice
    class Manager<T> where T : new() {

        private readonly Dictionary<PropertyInfo, int> fieldNamePositions;

        public Manager(string[] positionFieldNames) {

            var props = typeof(T).GetProperties();

            if (!props.All(prop => prop.PropertyType == typeof(string))) {

                throw new FormatException($"All of \"{typeof(T)}\" properties should be of type \"{typeof(string)}\"");
            }

            if (positionFieldNames.AsEnumerable().Select(fieldName => fieldName.ToLowerInvariant())
                .Except(props.Select(prop => prop.Name.ToLowerInvariant())).Any()) {

                throw new FormatException($"All of \"{typeof(T)}\" properties should be defined in \"fields\"");
            }

            foreach (var prop in props) {
                fieldNamePositions.Add(prop, Array.FindIndex(positionFieldNames, fieldName => fieldName.ToLowerInvariant() == prop.Name.ToLowerInvariant()));
            }
        }

        public T Parse(string param, char separator) {

            var values = param.Split(separator);

            if (values.Count() != fieldNamePositions.Count) {
                throw new Exception($"param string does not contain exactly {fieldNamePositions.Count} values, as per definition");
            }

            T instance = new T();

            foreach (var field in fieldNamePositions) {
                field.Key.SetValue(instance, values[field.Value]);
            }

            return instance;
        }
    }
}
