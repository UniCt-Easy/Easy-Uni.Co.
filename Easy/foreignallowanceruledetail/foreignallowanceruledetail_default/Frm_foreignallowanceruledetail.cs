/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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


namespace foreignallowanceruledetail_default {
    public partial class Frm_foreignallowanceruledetail : Form {
        public Frm_foreignallowanceruledetail() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            DataAccess.SetTableForReading(DS.foreigngroup1, "foreigngroup");
            string filtro = "start=(select max(start) from foreigngroup g2 where foreigngroup.foreigngroupnumber=g2.foreigngroupnumber)";
            GetData.CacheTable(DS.foreigngroup, filtro, "foreigngroupnumber", false);
            GetData.CacheTable(DS.foreigngroup1, filtro, "foreigngroupnumber", false);
        }
    }
}