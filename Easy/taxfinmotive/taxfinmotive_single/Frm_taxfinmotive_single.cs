
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace taxfinmotive_single {
    public partial class Frm_taxfinmotive_single : MetaDataForm {
        public Frm_taxfinmotive_single() {
            InitializeComponent();
        }

        QueryHelper QHS;
        /*
        CONTRIBUTI
            idmotincomeintra -> causale di entrata 
            idmotadmintax ->Causale di spesa
            idmotexpensecontra-> Causale di spesa per Lx periodica 
    
        RITENUTE c/DIPENDENTE
            idmotincomeemploy-> Causale di entrata
            idmotexpenseemploy-> causale di spese per Lx periodica
         */
        public void MetaData_AfterLink() {
            MetaData Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.finmotive_incomeintra, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_admintax, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_incomeemploy, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_expensecontra, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_expenseemploy, "finmotive");

        }

    }
}
