
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace apfinancialactivity_default{
    public partial class Frm_apfinancialactivity_default : MetaDataForm{
        private MetaData Meta;
        public Frm_apfinancialactivity_default(){
            InitializeComponent();
            HelpForm.SetDenyNull(DS.apfinancialactivity.Columns["active"], true);
        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            GetData.CacheTable(DS.apfinancialactivitylevel, null, null, true);
        }

        public void MetaData_AfterClear(){
            cmbLivello.Enabled = true;
            txtCodice.ReadOnly = false;
            txtDenominazione.ReadOnly = false;
            Meta.CanInsert = false;
        }

        public void MetaData_AfterFill(){
            if (!Meta.CanInsert)
            {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
            //abilita/disabilita i controlli
            bool ModoInsert = Meta.InsertMode;
            cmbLivello.Enabled = false;
            if (ModoInsert)
            {
                DataRow R = HelpForm.GetLastSelected(DS.apfinancialactivity);
                if (R == null) return;
                string livello = R["nlevel"].ToString();
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R){
            if (T.TableName != "apfinancialactivity") return;
            cmbLivello.Enabled = false;
            bool ModoInsert = Meta.InsertMode;
            if (Operativo(R))
            {
                object livello = R["nlevel"].ToString();
                txtCodice.ReadOnly = !(ModoInsert && !TipoNumerico(livello));
            }
            else
            {
                txtCodice.ReadOnly = true;
            }
        }

        private bool Operativo(DataRow R){
            if (R == null) return false;
            object livellorow = R["nlevel"];
            DataRow[] Res = DS.apfinancialactivitylevel.Select("(nlevel=" +
                QueryCreator.quotedstrvalue(livellorow, true) + ")");
            if (Res.Length != 1) return false;
            int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            bool usable = ((flag & 2) != 0);
            return usable;
        }

        private bool TipoNumerico(object codicelivello)
        {
            DataRow[] Res = DS.apfinancialactivitylevel.Select("(nlevel=" +
                QueryCreator.quotedstrvalue(codicelivello, true) + ")");
            if (Res.Length != 1) return false;
            int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            bool numerico = ((flag & 1) == 0);
            return numerico;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((!Meta.IsEmpty) && (!Meta.CanInsert))
            {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
        }
    }
}
