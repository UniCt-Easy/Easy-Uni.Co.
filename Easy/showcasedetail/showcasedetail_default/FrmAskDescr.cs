
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace showcasedetail_default{
    public partial class FrmAskDescr : MetaDataForm {
        MetaDataDispatcher Disp;
        MetaData Meta;
        DataAccess Conn;
        DataSet D;
        public DataRow Selected;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmAskDescr(MetaDataDispatcher Disp)
        {
            InitializeComponent();
            this.Disp = Disp;
            this.Conn = Disp.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            Meta = Disp.Get("listclass");
            D = new DataSet();
        }

        private void btnClassMerc_Click(object sender, EventArgs e){
            string filter = QHS.CmpEq("active","S");
            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filter;
            Meta.ExtraParameter = filter;
            string edittype;
            edittype = "bookingtree";

            bool res = Meta.Edit(this, edittype, true);
            if (!res) return;
            Selected = Meta.LastSelectedRow;
            riempiTextBox(Selected);
        }

        private void riempiTextBox(DataRow ClassRow){
            txtCodClassMerc.Text = (ClassRow != null) ? ClassRow["codelistclass"].ToString() : "";
            txtDescClassMerc.Text = (ClassRow != null) ? ClassRow["title"].ToString() : "";
        }

        private void txtCodClassMerc_Leave(object sender, EventArgs e){
            if (txtCodClassMerc.Text.Trim() == ""){
                 txtCodClassMerc.Text = "";
                 txtDescClassMerc.Text = "";
                return;
            }
            string filter = QHS.CmpEq("active", "S");

            string Code = txtCodClassMerc.Text;
            if (!Code.EndsWith("%")) Code += "%";
            if (!Code.StartsWith("%")) Code = "%" + Code;
            filter = QHC.AppAnd(filter, QHC.Like("codelistclass", Code));

            MetaData E = Meta.Dispatcher.Get("listclass");
            E.FilterLocked = true;
            E.DS = D.Clone();
            Selected = E.SelectOne("default", filter, "listclass", null);

            riempiTextBox(Selected);
        }

    }
}
