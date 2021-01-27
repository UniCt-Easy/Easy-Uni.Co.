
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace requestmandatekind_associa
{
    public partial class Frm_requestmandatekind_associa : Form
    {
        MetaData Meta;
        public Frm_requestmandatekind_associa()
        {
            InitializeComponent();
        }
        DataAccess Conn = null;
        QueryHelper QHS = null;

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = MetaData.GetConnection(this);
            QHS = Conn.GetQueryHelper();
            GetData.CacheTable(DS.mandatekind_original);
            GetData.CacheTable(DS.mandatekind);
            DataAccess.SetTableForReading(DS.mandatekind_original, "mandatekind");
            GetData.SetStaticFilter(DS.mandatekind_original, QHS.CmpEq("isrequest","S"));
            GetData.SetStaticFilter(DS.mandatekind, QHS.NullOrEq("isrequest", "N"));
        }
    }
}
