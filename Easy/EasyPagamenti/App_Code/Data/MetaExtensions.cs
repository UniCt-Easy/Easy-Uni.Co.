
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


using metadatalibrary;
using System;
using System.Data;
using System.IO;


namespace EasyPagamenti.Data {
    /// <summary>
    /// Metodi di estensione per la classe MetaData.
    /// </summary>
    public static class MetaExtensions {

        /// <summary>
        /// Restituisce un DataSet, caricando lo schema da un file su disco.
        /// </summary>
        /// <param name="meta">Il meta.</param>
        /// <param name="editType">Tipo di modifica.</param>
        /// <returns>Un DataSet vuoto con schema.</returns>
        public static DataSet LoadDataSet(this MetaData meta, string editType) {
            var fileName = string.Format("{0}_{1}.xsd", meta.Name, editType);
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (!File.Exists(filePath)) return null;

            var ds = new DataSet();
            ds.ReadXmlSchema(fileName);

            return ds;
        }

        /// <summary>
        /// Istanzia un DataSet definito a design-time.
        /// </summary>
        /// <param name="meta">Il meta.</param>
        /// <param name="editType">Tipo di modifica.</param>
        /// <returns>Un DataSet vuoto con schema.</returns>
        public static DataSet GetDataSet(this MetaData meta, string editType) {
            DataSet ds;
            try {
                // Il nome del meta e l'edit-type fanno parte del namespace.
                // Il DataSet deve avere nome "Vista".
                var dsName = string.Format("Backend.Data.{0}.{1}", meta.TableName, editType);
                var type = Type.GetType(dsName, true, true);

                ds = Activator.CreateInstance(type) as DataSet;

                // Se l'istanza implementa IExtendedDataSet inizializza la classe
                if (ds is IExtendedDataSet) {
                    var dsExt = ds as IExtendedDataSet;
                    dsExt.InitClass(meta.Conn);
                }
            }
            catch {
                return null;
            }

            return ds;
        }

    }
}

