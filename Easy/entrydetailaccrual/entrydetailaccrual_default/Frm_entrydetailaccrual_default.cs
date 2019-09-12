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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace entrydetailaccrual_default
{
    public partial class Frm_entrydetailaccrual_default : Form
    {
        public Frm_entrydetailaccrual_default()
        {
            InitializeComponent();
        }
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        private DataRow parentRow;
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.entrydetailview_linked, "entrydetailview");
            DataAccess.SetTableForReading(DS.entrykind_linked, "entrykind");
            parentRow = Meta.SourceRow.GetParentRow("entrydetailentrydetailaccrual");
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone) return;
            DataRow Curr = DS.entrydetailaccrual.Rows[0];
            if (T.TableName == "entrydetailaccrualview") {
                if (R != null) {
                    
                    decimal N = CfgFn.GetNoNullDecimal(R["available"]);
                    if (CfgFn.GetNoNullDecimal(parentRow["amount"]) > 0) {
                        if (R["flagap"].ToString() == "P") N = -N; //il segno normale sarebbe dovuto essere una A (rateo attivo)
                    }
                    else {
                        if (R["flagap"].ToString() == "A") N = -N;//il segno normale sarebbe dovuto essere una P (rateo passivo)
                    }
                    Curr["amount"] = N;
                    txtImporto.Text = N.ToString("c");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tablename = "entrydetailaccrualview";
            string MyFilter = CalculateFilter(false);
            
            string command = "choose." + tablename + ".default." + MyFilter;
            if (!MetaData.Choose(this, command)) return;
          }

        string CalculateFilter(bool pluriennale)
        {
            int esercizio = Conn.GetEsercizio();
            string MyFilter = QHS.CmpGt("available", 0);

            if (DS.entrydetailview.Rows.Count > 0) {
                //DataRow R = DS.entrydetailview.Rows[0];
                
                if (parentRow == null) return MyFilter;
                MyFilter = QHS.AppAnd(MyFilter, QHS.NullOrEq("idepexp", parentRow["idepexp"]));

                if (pluriennale == false) {
                    //R["competencystart"] != DBNull.Value || R["competencystop"] == DBNull.Value
                    object inizioCompetenza = parentRow["competencystart"];
                    object fineCompetenza = parentRow["competencystop"];

                    if (inizioCompetenza != DBNull.Value && fineCompetenza != DBNull.Value) {
                        MyFilter = QHS.AppAnd(MyFilter,
                            QHS.DoPar(QHS.AppOr(QHS.Between("competencystart", inizioCompetenza, fineCompetenza),
                                QHS.Between("competencystop", inizioCompetenza, fineCompetenza))));
                    }
                }



                if (parentRow["idupb"] != DBNull.Value) {
                    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idupb", parentRow["idupb"]));
                    if (pluriennale) {
                        object idepupbkind = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", parentRow["idupb"]), "idepupbkind");
                        if (idepupbkind != null && idepupbkind != DBNull.Value) {
                            object idacc = Conn.DO_READ_VALUE("epupbkindyear", QHS.AppAnd(
                                QHS.CmpEq("idepupbkind", idepupbkind), QHS.CmpEq("ayear", esercizio)), "idacc_accruals");
                            if (idacc != DBNull.Value && idacc != null)
                                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idacc", idacc));
                        }
                    }
                }

                if (pluriennale == false) {
                    foreach (string f in new string[] {"idsor1", "idsor2", "idsor3", "idreg"}) {
                        object val = parentRow[f];
                        if (val != DBNull.Value) MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq(f, val));
                    }
                }
                if (pluriennale) {
                    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("yentry", esercizio));
                    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("identrykind", 7));
                    MyFilter = QHS.AppAnd(MyFilter, QHS.IsNull("idreg"));
                }
                else {
                    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLt("yentry", esercizio));
                    //string flagAP = "";
                    if (CfgFn.GetNoNullDecimal(parentRow["amount"]) > 0) {
                        //flagAP = "A";
                        MyFilter = QHS.AppAnd(MyFilter, QHS.BitSet("flagaccountusage", 0));//ratei attivi
                    }
                    else {
                        //flagAP = "P";
                        MyFilter = QHS.AppAnd(MyFilter, QHS.BitSet("flagaccountusage", 1));//ratei passivi
                    }
                    //MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagap", flagAP));
                    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("identrykind", 2));
                }

                DataTable ParentRateo = Meta.SourceRow.Table;
                DataRow[] Added = ParentRateo.Select(QHC.IsNotNull("ndetaillinked"), null, DataViewRowState.Added);
                // Ciclo per escludere le righe già inserite 
                if (Added.Length > 0) {
                    foreach (DataRow Row in Added) {
                        // costruisco il filtro sulla chiave per le righe inserite nel form chiamante
                        MyFilter = QHS.AppAnd(MyFilter,
                            QHS.DoPar(QHS.AppOr(QHS.CmpNe("yentry", Row["yentrylinked"]),
                                QHS.CmpNe("nentry", Row["nentrylinked"]), QHS.CmpNe("ndetail", Row["ndetaillinked"]))));
                    }
                }
            }
            else return MyFilter;

            return MyFilter;
        }

        private void btnRateoPluriennale_Click(object sender, EventArgs e) {
            string tablename = "entrydetailaccrualview";
            string MyFilter = CalculateFilter(true);

            string command = "choose." + tablename + ".default." + MyFilter;
            if (!MetaData.Choose(this, command)) return;
        }
    }
}