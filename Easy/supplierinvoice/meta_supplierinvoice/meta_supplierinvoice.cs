/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_supplierinvoice
{
    /// <summary>
    /// Summary description for meta_documentoiva
    /// </summary>
    public class Meta_supplierinvoice : Meta_easydata
    {
        public Meta_supplierinvoice(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "supplierinvoice")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")
            {
                Name = "Fornitori Fatture di Acquisto";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("supplierinvoice_default");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "iddbdepartment", "Dipartimento");
                DescribeAColumn(T, "idinvkind", "Tipo Fattura");
                DescribeAColumn(T, "yinv", "Esercizio");
                DescribeAColumn(T, "ninv", "Numero");
                DescribeAColumn(T, "idreg", "Fornitore");
                DescribeAColumn(T, "description", "Descrizione");
                DescribeAColumn(T, "doc", "Documento");
                DescribeAColumn(T, "docdate", "Data Documento");
            }
        }

    }
}
