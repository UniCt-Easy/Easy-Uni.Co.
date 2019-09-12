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

using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace foreignallowancerule_default {
    public partial class Frm_foreignallowancerule_default : Form {
        public Frm_foreignallowancerule_default() {
            InitializeComponent();
        }
        MetaData Meta;
        bool IsAdmin;
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            IsAdmin = (Meta.GetSys("manage_prestazioni") != null)
                ? Meta.GetSys("manage_prestazioni").ToString() == "S"
                : false;
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;
        }

    }
}