
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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;

namespace meta_itinerationrefundruledetail {
    public class Meta_itinerationrefundruledetail : Meta_easydata {
        public Meta_itinerationrefundruledetail(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "itinerationrefundruledetail") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Dettaglio per gruppi";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("itinerationrefundruledetail_default");
            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "iditinerationrefundrule");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "iditinerationrefundrule", "", nPos++);
                DescribeAColumn(T, "iddetail", "", nPos++);
                DescribeAColumn(T, "iditinerationrefundkindgroup", "", nPos++);
                DescribeAColumn(T, "!itinerationrefundkindgroup", "Gruppo di class.spese missione", "itinerationrefundkindgroup.description", nPos++);
                DescribeAColumn(T, "idposition", "", nPos++);
                DescribeAColumn(T, "!position", "Qualifica", "position.description", nPos++);
                DescribeAColumn(T, "livello", "Livello", nPos++);
                DescribeAColumn(T, "minincomeclass", "Min.classe stip.", nPos++);
                DescribeAColumn(T, "maxincomeclass", "Max.classe stip.", nPos++);
                DescribeAColumn(T, "flag_italy", "Italia", nPos++);
                DescribeAColumn(T, "flag_eu", "Europa", nPos++);
                DescribeAColumn(T, "flag_extraeu", "Altro", nPos++);
                DescribeAColumn(T, "nhour_min", "Min. ore", nPos++);
                DescribeAColumn(T, "nhour_max", "Max. ore", nPos++);
                DescribeAColumn(T, "limit", "Limite", nPos++);
                DescribeAColumn(T, "advancepercentage", "Perc.anticipo", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["advancepercentage"], "p");
            }
            return;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) {
                return false;
            }
            int iditinerationrefundkindgroup = CfgFn.GetNoNullInt32(R["iditinerationrefundkindgroup"]);
            if (iditinerationrefundkindgroup==0) {
                errmess = "Specificare il gruppo di class. spese missione";
                errfield = "iditinerationrefundkindgroup";
                return false;
            }
            DataRow rPosition = R.GetParentRow("position_itinerationrefundruledetail");
            int minincomeclass = CfgFn.GetNoNullInt32(R["minincomeclass"]);
            int maxincomeclass = CfgFn.GetNoNullInt32(R["maxincomeclass"]);
            int max = CfgFn.GetNoNullInt32(rPosition["maxincomeclass"]);
            if (minincomeclass < 0) {
                errmess = "La classe minima deve essere maggiore o uguale a zero";
                errfield = "minincomeclass";
                return false;
            }
            if (minincomeclass > maxincomeclass) {
                errmess = "La classe minima deve essere <= della classe massima";
                errfield = "minincomeclass";
                return false;
            }
            if (maxincomeclass > max) {
                errmess = "Per la qualifica '" + rPosition["description"] + "' la massima classe stipendiale è " + max;
                errfield = "maxincomeclass";
                return false;
            }
            return true;
        }
    }
}
