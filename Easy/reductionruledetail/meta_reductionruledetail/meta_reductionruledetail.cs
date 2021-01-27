
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_reductionruledetail {
    public class Meta_reductionruledetail : Meta_easydata {
        public Meta_reductionruledetail(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "reductionruledetail"){
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Dettaglio della regola";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("reductionruledetail_default");
            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idreductionrule");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                DescribeAColumn(T, "idreductionrule", "", -1);
                DescribeAColumn(T, "iddetail", "", -1); 
                DescribeAColumn(T, "!description", "Riduzione", "reduction.description",1);
                DescribeAColumn(T, "idreduction", "",-1);
                DescribeAColumn(T, "reductionpercentage", "Perc.riduzione",2);
                HelpForm.SetFormatForColumn(T.Columns["reductionpercentage"], "p4");
            }
            return;
        }
    }
}

