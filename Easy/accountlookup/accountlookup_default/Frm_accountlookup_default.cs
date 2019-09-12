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

namespace accountlookup_default
{
    public partial class Frm_accountlookup_default : Form
    {
        public Frm_accountlookup_default()
        {
            InitializeComponent();
        }
        MetaData Meta;
        DataAccess Conn;
        string filteresercizio;
        string filteresercizionew;
        QueryHelper QHS;
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.account1, "account");
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.account, filteresercizio);

            int annonext = Convert.ToInt32(Meta.GetSys("esercizio")) + 1;
            filteresercizionew = QHS.CmpEq("ayear", annonext);

            GetData.SetStaticFilter(DS.account1, filteresercizionew);

            string filteraccount = QHS.Like("oldidacc", Meta.GetSys("esercizio").ToString().Substring(2, 2) + "%");
            GetData.SetStaticFilter(DS.accountlookup, filteraccount);
            GetData.SetStaticFilter(DS.accountlookupview, filteraccount);

            GetData.CacheTable(DS.accountlevel, filteresercizio, null, false);
            grpAnnoCorrente.Text = "Anno " + Meta.GetSys("esercizio").ToString();
            grpAnnoSuccessivo.Text = "Anno " + annonext.ToString();
        }
    }
}