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
using metadatalibrary;
using metaeasylibrary;


namespace supplierinvoice_default
{
    public partial class Frm_supplierinvoice_default : Form
    {
        MetaData Meta;

        public Frm_supplierinvoice_default()
        {
            InitializeComponent();
        }

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;
        }
        public void MetaData_AfterFill()
        {
            grpGenerale.Enabled = false;
        }

        public void MetaData_AfterClear()
        {
            grpGenerale.Enabled = true;
        }

       
    }
}