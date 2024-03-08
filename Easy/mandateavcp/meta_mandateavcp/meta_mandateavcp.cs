
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_mandateavcp {
    public class Meta_mandateavcp : Meta_easydata {
        public Meta_mandateavcp(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "mandateavcp") {
            EditTypes.Add("single");
            ListingTypes.Add("lista");
        }
        protected override Form GetForm(string EditType) {
            if (EditType == "single") {
                Name = "Partecipanti";
                return GetFormByDllName("mandateavcp_single");
            }
            return null;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idmankind");
            RowChange.SetSelector(T, "yman");
            RowChange.SetSelector(T, "nman");
            RowChange.MarkAsAutoincrement(T.Columns["idavcp"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        override public void SetDefaults(DataTable Primary) {
            base.SetDefaults(Primary);
            SetDefault(Primary, "flagcontractor", "S");
            SetDefault(Primary, "flagnonparticipating", "N");
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idavcp", "#", nPos++);
                DescribeAColumn(T, "title", "Ragione sociale", nPos++);
                DescribeAColumn(T, "flagcontractor", "Partecipante singolo", nPos++);
                DescribeAColumn(T, "flagnonparticipating", "Invitato non Partecipante", nPos++);
                DescribeAColumn(T, "!capogruppo", "Capogruppo", nPos++);
                ComputeRowsAs(T, listtype);
                //DescribeAColumn(T, "idmain_avcp", "Capogruppo", nPos++);
            }
        }

        public override void CalculateFields(DataRow R, string list_type) {
            base.CalculateFields(R, list_type);
            if (list_type == "lista") {
                DataTable Partecipanti = R.Table;
                if (R["idmain_avcp"] != DBNull.Value) {
                    DataRow []f= Partecipanti.Select(QHC.CmpEq("idavcp",R["idmain_avcp"]));
                    if (f.Length == 1) {
                        R["!capogruppo"] = f[0]["title"];
                    }
                }
            }
        }


        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (R["idmankind"].ToString() == "") {
                errfield = "description";
                errmess = "E' necessario scegliere il tipo contratto";
                return false;
            }

            
            if (R["flagcontractor"].ToString() == "N"
                   && R["idavcp_role"] == DBNull.Value
                 ) {
                errmess = "E' necessario scegliere il ruolo per questo partecipante";
                errfield = "idavcp_role";
                return false;
            }
            if (R["flagcontractor"].ToString() == "N" && R["idmain_avcp"] == DBNull.Value
                  && R["idavcp_role"].ToString()!="04"
                ) {
                    errmess = "E' necessario scegliere il capogruppo per questo partecipante.";
                    errfield = "idmain_avcp";
                    return false;
            }
            if ((R["cf"] == DBNull.Value) && (R["foreigncf"] == DBNull.Value)) {
                errmess = "Specificare il Codice Fiscale/Partita IVA o il Codice Identificativo Estero del partecipante.";
                errfield = "cf";
                return false;
                }
            string codicefiscale = R["cf"].ToString().ToUpper();
            if ((codicefiscale.ToString()!="") && (codicefiscale.Length != 16) && (codicefiscale.Length != 11)) {
                errmess = "Il codice fiscale/Partita IVA deve essere composto da 16 caratteri o da 11 caratteri.";
                errfield = "cf";
                return false;
                }

            if (R["title"].ToString().Trim() == "") {
                errmess = "Indicare la Ragione sociale";
                errfield = "title";
                return false;
                }
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
        }
    }
}
