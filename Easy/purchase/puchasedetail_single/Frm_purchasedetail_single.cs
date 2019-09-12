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

ï»¿using metadatalibrary;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace purchasedetail_single {

    public partial class Frm_purchasedetail_single : Form {

        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;

        public Frm_purchasedetail_single() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }

        public void MetaData_AfterFill() {
            FreshLogo();
        }

        void FreshLogo() {
            if (DS.purchasedetail.Rows.Count == 0) return;
            DataRow Curr = DS.purchasedetail.Rows[0];

            if (Curr.IsNull("idlist")) return;

            try {
                DataRow DR = Curr.GetParentRow("listview_purchasedetail");
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

        private void btnListino_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;

            DataRow Curr = DS.purchasedetail.Rows[0];

            string filter = QHS.DoPar(
                QHS.AppOr(
                    QHS.IsNull("validitystop"),
                    QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))
                )
            );

            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 0));

            Meta.DoMainCommand("choose.listview.default." + filter);
        }

    }

}
