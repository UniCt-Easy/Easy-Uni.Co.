
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_banktransactionsorting
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_banktransactionsorting : Meta_easydata {
        public Meta_banktransactionsorting(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "banktransactionsorting") {
            Name = "Movimento bancario";
            EditTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Classificazione della transazione Bancaria";
                return GetFormByDllName("banktransactionsorting_default");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            DescribeAColumn(T, "yban", "");
            DescribeAColumn(T, "nban", "");
            DescribeAColumn(T, "idsorkind", "");
            DescribeAColumn(T, "idsor", "");
            DescribeAColumn(T, "!tipoclass", "Tipo class.", "sortingview.sortingkind");
            DescribeAColumn(T, "!codiceclass", "Codice class.", "sortingview.sortcode");
            DescribeAColumn(T, "!descrizione", "Descrizione class.", "sortingview.description");
            DescribeAColumn(T, "amount", "Importo");
        }
    }
}
