
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


using metadatalibrary;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using funzioni_configurazione;

namespace showcasedetail_single {

    public partial class Frm_showcasedetail_single : MetaDataForm {

        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        private double aliquota = 0;
        DataAccess Conn;
        public Frm_showcasedetail_single() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
			DataAccess.SetTableForReading(DS.upb_iva, "upb");
			Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			DataAccess.SetTableForReading(DS.sorting1, "sorting");
			DataAccess.SetTableForReading(DS.sorting2, "sorting");
			DataAccess.SetTableForReading(DS.sorting3, "sorting");
			DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                filter, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);
            }
        }
        void SetGBoxClass(int num, object sortingkind) {
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DS.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }
        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }
        public void MetaData_AfterFill() {
            CalcolaIVA();
            FreshLogo();

            if (Meta.EditMode) {
                btnListino.Enabled = false;
                txtCodiceListino.ReadOnly = true;
                txtDescrizioneListino.ReadOnly = true;
            }
        }

        void CalcolaIVA() {
            if (DS.showcasedetail.Rows.Count == 0) return;
            DataRow Curr = DS.showcasedetail.Rows[0];

            if (Curr.IsNull("unitprice")) return;
            if (Curr.IsNull("idivakind")) return;

            try {
                DataRow DR = Curr.GetParentRow("ivakind_showcasedetail");

                var prezzounitario = Curr.Field<decimal>("unitprice");
                var aliquotaIVA = DR.Field<decimal>("rate");
                var importoIVA = prezzounitario * aliquotaIVA;

                txtImportoIVA.Text = importoIVA.ToString("c");
            }
            catch {
                txtImportoIVA.Text = string.Empty;
            }
        }

        void FreshLogo() {
            if (DS.showcasedetail.Rows.Count == 0) return;
            DataRow Curr = DS.showcasedetail.Rows[0];

            if (Curr.IsNull("idlist")) return;
            DataRow DR = Curr.GetParentRow("listview_showcasedetail");
            if (DR!=null) { 
                try {
   
                    if (!DR.IsNull("pic")) {
                        using (var stream = new MemoryStream(DR.Field<byte[]>("pic"))) {
                            pbox.Image = new Bitmap(stream, false);
                        }
                    }
                    else {
                        pbox.Image = null;
                    }
                }
                catch {
                    pbox.Image = null;
                }
            }
        }

        private void btnListino_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;

            DataRow Curr = DS.showcasedetail.Rows[0];

            string filter = QHS.DoPar(
                QHS.AppOr(
                    QHS.IsNull("validitystop"),
                    QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))
                )
            );

            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 0)); //bit 0: visibile nelle prenotazioni di magazzino e nella vetrina. BitSet confronta con <> 0
            filter = QHS.AppAnd(filter, QHS.IsNotNull("idtassonomia")); //bit 0: visibile nelle prenotazioni di magazzino e nella vetrina. BitSet confronta con <> 0

            if (chkFiltraDescrizioneClassificazione.Checked) {
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher);

                if (FR.ShowDialog(this) != DialogResult.OK) return;

                if (FR.Selected != null) {
                    object idlistclass = FR.Selected["idlistclass"];
                    filter = QHC.AppAnd(filter, QHC.CmpEq("idlistclass", FR.Selected["idlistclass"]));
                }

                if (FR.txtDescrizione.Text != "") {
                    string Description = FR.txtDescrizione.Text;
                    if (!Description.EndsWith("%")) Description += "%";
                    if (!Description.StartsWith("%")) Description = "%" + Description;
                    filter = QHC.AppAnd(filter, QHC.Like("description", Description));
                }
            }

            Meta.DoMainCommand("choose.listview.default." + filter);
        }

        private void txtListino_Leave(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;

            if (txtCodiceListino.Text == "") {
                FreshLogo();

                return;
            }
            DataRow Curr = DS.showcasedetail.Rows[0];

            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));

            string IntCode = txtCodiceListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = QHC.AppAnd(filter, QHS.Like("intcode", IntCode));

            Meta.DoMainCommand("choose.listview.default." + filter);
        }

        private void CalcolaImporti(bool LeggiDati) {
            if (Meta.formController.isClosing) return;
            if (Meta.destroyed) return;
            if (DS.showcasedetail.Rows.Count == 0) return;

            if (LeggiDati) Meta.GetFormData(true);
            DataRow Curr = DS.showcasedetail.Rows[0];

            try {
                double imponibile = CfgFn.GetNoNullDouble(Curr["unitprice"]);//Prezzo unitario
                double ivaEUR = CfgFn.RoundValuta(imponibile * aliquota);
                txtImportoIVA.Text = HelpForm.StringValue(ivaEUR, "x.y.fixed.2...1");
            }
            catch {
                txtImportoIVA.Text = "";
            }

        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.destroyed || Meta.formController.isClosing) return;
            if (T.TableName == "ivakind") {
                if (R != null) {
                    aliquota = CfgFn.GetNoNullDouble(R["rate"]);
                }
                else {
                    aliquota = 0;
                }
                if (Meta.DrawStateIsDone) {
                    CalcolaImporti(Meta.DrawStateIsDone);
                }
            }
        }
        private void txtPrezzoUnitario_Leave(object sender, EventArgs e) {
            if (Meta.formController.isClosing) return;
            if (Meta.destroyed) return;
            if (DS.showcasedetail.Rows.Count == 0) return;

            if (!Meta.DrawStateIsDone) return;
            CalcolaImporti(true);
        }
    }

}
