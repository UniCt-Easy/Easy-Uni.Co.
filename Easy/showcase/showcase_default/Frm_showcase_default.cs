
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
using metaeasylibrary;

namespace showcase_default
{
    public partial class Frm_showcase_default : MetaDataForm
    {
        MetaData Meta;

        public Frm_showcase_default(){
            InitializeComponent();
        }
        public void MetaData_AfterClear() {
            Meta.UnMarkTableAsNotEntityChild(DS.showcasedetail_related);
        }

            public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Meta.DefaultListType = "default";
			GetData.CacheTable(DS.invoicekind);
			DataAccess.SetTableForReading(DS.upb_iva1, "upb");
            Meta.MarkTableAsNotEntityChild(DS.showcasedetail_related);
        }

        public void MetaData_AfterFill() {
            Meta.MarkTableAsNotEntityChild(DS.showcasedetail_related);
        }
        public void MetaData_BeforePost() {
            if (DS.showcase.Rows.Count == 0) {
                DS.showcasedetail.Clear();
                return; //Insert/Cancel sequence
            }
            var R = DS.showcase.Rows[0];
            if (R.RowState == DataRowState.Deleted) {
                foreach (var A in DS.showcasedetail_related.Select()) {
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();
                }
            }
        }

    }
}
