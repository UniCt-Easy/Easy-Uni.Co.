
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
using metaeasylibrary;
using metadatalibrary;

namespace macroareaboard_lista
{
    public partial class Frm_macroareaboard_lista : Form
    {
        MetaData Meta;
        public Frm_macroareaboard_lista()
        {
            InitializeComponent();
        }

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();

            bool IsAdmin = false;

            if (Meta.GetSys("IsSystemAdmin") != null)
            {
                IsAdmin = (bool)Meta.GetSys("IsSystemAdmin");
            }
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;

        }


    }
}
