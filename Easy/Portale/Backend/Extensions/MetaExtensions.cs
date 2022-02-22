
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


using Backend.Data;
using metadatalibrary;
using System;
using System.Data;

namespace Backend.Extensions {

    /// <summary>
    /// Metodi di estensione per la classe MetaData.
    /// </summary>
    public static class MetaExtensions {

        /// <summary>
        /// Restituisce una tabella derivata dal meta e aggiunge le informazioni sulle colonne.
        /// </summary>
        /// <param name="meta">Oggetto Meta.</param>
        /// <param name="listType">Tipo di lista.</param>
        /// <returns>Tabella di dati vuota.</returns>
        public static DataTable getDataTable(this MetaData meta, string listType) {
            var ds = new DataSet();
            var dt = meta.Conn.CreateTableByName(meta.TableName, null);
            ds.Tables.Add(dt);

            meta.DescribeColumns(dt, listType);

            return dt;
        }

        /// <summary>
        /// Istanzia un DataSet definito a design-time.
        /// </summary>
        /// <param name="meta">Il meta.</param>
        /// <param name="editType">Tipo di modifica.</param>
        /// <returns>Un DataSet vuoto con schema.</returns>
        public static DataSet GetDataSet(this MetaData meta, string editType)
        {
            DataSet ds;
            try
            {
                // Il nome del meta e l'edit-type fanno parte del namespace.
                // Il DataSet deve avere nome "Vista".
                var dsName = $"Backend.Data.{meta.TableName}.{editType}";
                var type = Type.GetType(dsName, true, true);

                ds = Activator.CreateInstance(type) as DataSet;

                // Se l'istanza implementa IExtendedDataSet inizializza la classe
                if (ds is IExtendedDataSet)
                {
                    var dsExt = ds as IExtendedDataSet;
                    dsExt.InitClass(meta.Conn);
                }
            }
            catch
            {
                return null;
            }

            return ds;
        }

    }

}
