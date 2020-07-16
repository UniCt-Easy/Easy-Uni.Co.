/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using System.IO;
using funzioni_configurazione;

namespace bookingdetail_default
{
    public partial class Frm_bookingdetail_default : Form
    {
        MetaData Meta;
        DataAccess Conn; 
        public Frm_bookingdetail_default()
        {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            //Meta.CanCancel = false;
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
            QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0))
            {
                DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value)
                {
                    tabControl1.TabPages.Remove(tabPageAnalitico);
                }
            }
            //Meta.CanSave = false;
        }
        void SetGBoxClass(int num, object sortingkind)
        {
            string nums = num.ToString();
            if (sortingkind == DBNull.Value)
            {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + nums);
                G.Visible = false;
            }
            else
            {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + nums);
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + nums);
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                gboxclass.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
                btnCodice.Tag = "manage.sorting" + nums + ".tree." + filter;
                DS.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }
        object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(this);
        }

        public void MetaData_AfterFill()
        {
            FreshLogo();
            enableControls(false);

            decimal evaso;

            if (Meta.IsFirstFillForThisRow) {
                
                DataRow R = DS.bookingdetail.Rows[0];

                if (R["authorized"].ToString() == "S") {
                decimal inevaso = CfgFn.GetNoNullDecimal( Conn.DO_READ_VALUE("booktotal",
                            QHS.MCmp(R, "idstore", "idlist", "idbooking"),
                            "number"));
                decimal ordine = CfgFn.GetNoNullDecimal(R["number"]);
                evaso = ordine - inevaso;
                }
                else {
                    evaso = 0;
                }
                txtEvaso.Text = evaso.ToString("n");

                if (R["authorized"] == DBNull.Value)
                {
                    chkAuthorizeed.Text = " In attesa di autorizzazione ";
                }
                else
                {
                    chkAuthorizeed.Text = " Autorizzato ";
                }
            }

        }

        public void MetaData_AfterClear()
        {
            enableControls(true);
            txtEvaso.Text = "";
        }


        private void enableControls(bool abilita)
        {
            bool readOnly = !abilita;
            gboxListClass.Enabled = abilita;
            gboxclass1.Enabled = abilita;
            gboxclass2.Enabled = abilita;
            gboxclass3.Enabled = abilita;
            chkAuthorizeed.Enabled = abilita;
            txtPrice.Enabled = abilita;
        }

      private void btnListClassCode_Click (object sender, EventArgs e) {
            string filter = QHS.BitSet("flagvisiblekind", 0);//bit 0: visibile nelle prenotazioni di magazzino e nella vetrina. BitSet confronta con <> 0

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                MetaData.DoMainCommand(this, "choose.listclass.default." + filter);
                return;
            }
            //DS.listclass.ExtendedProperties[MetaData.ExtraParams] = filter;
            MetaData.DoMainCommand(this, "manage.listclass.bookingtree");   
           }
        void FreshLogo()
        {
            if (DS.bookingdetail.Rows[0] == null) return;
            DataRow Curr = DS.bookingdetail.Rows[0];
            int idlist = CfgFn.GetNoNullInt32(Curr["idlist"]);
            object image =  HasImage(idlist);
            try
            {
                if (image!= DBNull.Value)
                {
                    MemoryStream MS = new MemoryStream((byte[])image);
                    Image IM = new Bitmap(MS, false);
                    pbox.Image = IM;
                }
                else
                {
                    pbox.Image = null;
                }
            }
            catch
            {
                pbox.Image = null;
            }
        }

        public object HasImage(int idlist)
        {
            string filter = QHS.CmpEq("idlist", idlist);
            DataTable T = Conn.RUN_SELECT("list", "*", null, filter, null, false);
            if (T == null || T.Rows.Count == 0) return false;
            DataRow DR = T.Rows[0];
             return DR["pic"];

        }
    }
}