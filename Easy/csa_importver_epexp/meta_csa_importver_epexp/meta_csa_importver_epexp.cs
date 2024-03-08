
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


using System;
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_csa_importver_epexp {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_csa_importver_epexp : Meta_easydata {
        public Meta_csa_importver_epexp(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
                base(Conn, Dispatcher, "csa_importver_epexp") {
            EditTypes.Add("detail");
            ListingTypes.Add("default");
            ListingTypes.Add("detail");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "detail") {
                Name = "Dettaglio";
                return MetaData.GetFormByDllName("csa_importver_epexp_detail");
            }
            return null;
        }


    


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default" || ListingType=="detail") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ndetail", "#", nPos++);
                DescribeAColumn(T, "quota", "Quota", nPos++);
                DescribeAColumn(T, "!phase", "Fase", "epexp_ver.phase", nPos++);
                DescribeAColumn(T, "!yepexp", "Eserc. Imp. Budget", "epexp_ver.yepexp", nPos++);
                DescribeAColumn(T, "!nepexp", "Num. Imp. Budget", "epexp_ver.nepexp", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p4");
            }
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            return base.SelectOne(ListingType, filter, searchtable, Exclude);
        }

    }
}


