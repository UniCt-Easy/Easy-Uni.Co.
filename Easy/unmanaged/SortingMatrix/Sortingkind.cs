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
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SortingMatrix {

    /// <summary>
    /// Enumerazione di tipi di un campo addizionale.
    /// </summary>
    public enum TField {
        Date = 'D',
        DecimalNumber = 'V',
        IntegerNumber = 'N',
        Text = 'S',
    }

    /// <summary>
    /// Identificatore di un elemento.
    /// </summary>
    public struct Key {

        // siamo obbligati ad usare un tipo valore come chiave per la comparazione delle istanze
        /// <summary>
        /// Tupla degli elementi che costituiscono l'identificatore.
        /// </summary>
        public Tuple<string, string> Values { get; }

        /// <summary>
        /// Istanzia l'identificatore utilizzando i valori indicati.
        /// </summary>
        /// <param name="values">Valori che costituiscono l'identificatore.</param>
        public Key(IEnumerable<string> values) {

            if (!values.Any()) {
                throw new ArgumentException();
            }

            IEnumerator<string> enumerator = values.GetEnumerator();
            enumerator.MoveNext();

            string value1 = enumerator.Current;

            if (!enumerator.MoveNext())
                throw new ArgumentException();

            string value2 = enumerator.Current;

            Values = new Tuple<string, string>(value1, value2);
        }

        /// <summary>
        /// Restituisce la rappresentazione in formato stringa dell'indentificatore.
        /// </summary>
        /// <returns>Rappresentazione in formato stringa dell'identificatore.</returns>
        public override string ToString() => string.Concat(Values.Item1, Values.Item2);
    }

    /// <summary>
    /// Modella il comportamento di un campo aggiuntivo.
    /// </summary>
    public class Descriptor {
        public bool forced;
        public string label;
        public HashSet<string> allowed;
        public bool locked;
    }

    // https://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
    // https://devblogs.microsoft.com/premier-developer/dissecting-new-generics-constraints-in-c-7-3/
    /// <summary>
    /// Estrae da una DataRow la modellazione che esprime i campi aggiuntivi ed i loro comportamenti.
    /// </summary>
    /// <typeparam name="TTField">Tipo dell'enumerazione che rappresenta i tipi dei valori contenuti nei campi aggiuntivi.</typeparam>
    /// <typeparam name="TDescriptor">Classe che modella il comportamento di un campo aggiuntivo.</typeparam>
    public class SortingKind<TTField, TDescriptor> where TTField : Enum where TDescriptor : new() {    // constraint a Enum per TTField (vedere riferimenti, introdotto in C# 7.3)

        /// <summary>
        /// Espressione regolare che rappresenta il nome di un campo sulla DataRow che a sua volta esprime una caratteristica specifica del campo addizionale
        /// di un campo aggiuntivo specifico.
        /// </summary>
        private readonly Regex matcher = new Regex(string.Empty);

        /// <summary>
        /// DataRow che esprime i campi aggiuntivi ed i loro comportamenti.
        /// </summary>
        private readonly DataRow sortingKindDescriptor;

        /// <summary>
        /// Cache che associa l'identificativo di un tipo di campo in formato stringa alla sua espressione come enumerazione.
        /// </summary>
        public Dictionary<string, TTField> TypesMap { get; }

        /// <summary>
        /// Collezione dei descrittori dei campi addizionali.
        /// </summary>
        public Dictionary<Key, TDescriptor> AdditionalFields {

            // calcoliamo in maniera "lazy" i campi aggiuntivi quando serve
            get {
                var descriptors = new Dictionary<Key, TDescriptor>();

                if (sortingKindDescriptor == null) {
                    return descriptors;
                }

                var sortingKindFeatures = sortingKindDescriptor.Table.Columns.Cast<DataColumn>()
                    .Where(column => matcher.IsMatch(column.ColumnName) && sortingKindDescriptor[column] != null && sortingKindDescriptor[column] != DBNull.Value);

                foreach (var column in sortingKindFeatures) {    // questo potrebbe essere scritto in maniera funzionale con GroupBy

                    IEnumerable<string> split = matcher.Split(column.ColumnName).Where(match => !string.IsNullOrWhiteSpace(match));

                    var key = new Key(split.Skip(1));    // potremmo rendere questo comportamento condizionato al pattern della regexp
                    var featureFieldName = split.First();

                    if (!descriptors.Keys.Contains(key)) {
                        descriptors.Add(key, new TDescriptor());
                    }

                    try {
                        FieldInfo feature = typeof(TDescriptor).GetFields().Where(field => field.Name == featureFieldName).FirstOrDefault();
                        object convertedValue = Conversions.Delegates[feature.FieldType].Invoke(sortingKindDescriptor[column]);  // non possiamo usare uno switch
                        feature.SetValue(descriptors[key], convertedValue);
                    }
                    catch (Exception e) {
                        throw new FormatException($"{typeof(TDescriptor).FullName} is not compatible with provided data: {e.Message}", e);
                    }
                }

                return descriptors;
            }
        }

        /// <summary>
        /// Prepara l'oggetto all'estrazione dei campi aggiuntivi ed i loro comportamenti. Imposta lo schema di denominazione dei campi 
        /// e rileva quali siano quelli rilevanti.
        /// </summary>
        /// <param name="dr">DataRow che esprime i campi aggiuntivi ed i loro comportamenti.</param>
        public SortingKind(DataRow dr) {

            sortingKindDescriptor = dr;

            var TFieldValues = Enum.GetValues(typeof(TTField)).Cast<TTField>();

            try {
                TypesMap = TFieldValues.ToDictionary(fieldType => ((char)(int)(object)fieldType).ToString(), fieldType => fieldType);  // castiamo prima a object, poi a int, questo perchè è un tipo generico di Enum come da constraint, e finalmente a char
            }
            catch (Exception e) {
                throw new FormatException($"{typeof(TTField).FullName} cannot initialize {GetType().Name}: {e.Message}", e);
            }

            string typePattern = string.Join("|", TypesMap.Keys);                                                          // valori dell'enumerazione dei tipi di campo addizionale TTField
            string featuresPattern = string.Join("|", typeof(TDescriptor).GetFields().Select(field => field.Name));        // nomi dei campi della classe TAdditionalField
            string instancePattern = "[0-9]*";                                                                             // identificatore dell'istanza di campo addizionale

            matcher = new Regex($"^({featuresPattern})({typePattern})({instancePattern})$", RegexOptions.IgnoreCase);   // questa regex potrebbe essere impostata da opzioni funzionali anche nella sua creazione
        }
    }
}
