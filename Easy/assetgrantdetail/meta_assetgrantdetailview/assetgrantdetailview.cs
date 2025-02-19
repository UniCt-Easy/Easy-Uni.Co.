
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;
using System.Collections;
using System.Windows.Forms;

namespace meta_assetgrantdetailview
{
    public class Meta_assetgrantdetailview :Meta_easydata {
        public Meta_assetgrantdetailview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "assetgrantdetailview") {
            Name = "Risconti applicati";

            ListingTypes.Add("default");
        }

        public string[] k = { "idasset", "idpiece","idgrant", "iddetail" };
        public override string[] primaryKey() {
            return k;
        }
        protected override Form GetForm(string FormName) {

            if (FormName == "default") {
                Name = "Risconti/Riserve utilizzati";
                return GetFormByDllName("assetgrantdetail_default");
            }


            return null;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);

            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "ydetail", "Anno risconto", nPos++);
                DescribeAColumn(T, "amount", "Importo risconto", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Numero inventario", nPos++);
                DescribeAColumn(T, "idpiece", "N.Parte", nPos++);
                DescribeAColumn(T, "codeinv", "Cod. Class. Inv.", nPos++);
                DescribeAColumn(T, "codeinvdescription", "Class. Inv.", nPos++);
                DescribeAColumn(T, "inventoryagencydescription", "Ente inventariale", nPos++);
                DescribeAColumn(T, "idgrant", "Numero contributo", nPos++);
                DescribeAColumn(T, "flag_financesource", "Tipo finanziamento", nPos++);
                DescribeAColumn(T, "grantdescription", "Descrizione contributo", nPos++);


            }

        }






    }
}
