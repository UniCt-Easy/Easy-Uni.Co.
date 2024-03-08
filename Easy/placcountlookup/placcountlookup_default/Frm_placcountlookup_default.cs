
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

namespace placcountlookup_default
{
    public partial class Frm_placcountlookup_default : MetaDataForm
    {
        public Frm_placcountlookup_default()
        {
            InitializeComponent();
        }
        MetaData Meta;
        DataAccess Conn;
        string filteresercizio;
        string filteresercizionew;
        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.placcount1, "placcount");
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.placcount, filteresercizio);

            int annonext = Convert.ToInt32(Meta.GetSys("esercizio")) + 1;
            filteresercizionew = QHS.CmpEq("ayear", annonext);

            GetData.SetStaticFilter(DS.placcount1, filteresercizionew);

            string filterbilancio = QHS.Like("oldidplaccount", 
            Meta.GetSys("esercizio").ToString().Substring(2, 2) + "%");
            GetData.SetStaticFilter(DS.placcountlookup, filterbilancio);
            GetData.SetStaticFilter(DS.placcountlookupview, filterbilancio);

            GetData.CacheTable(DS.placcountlevel, filteresercizio, null, false);
            grpAnnoCorrente.Text = "Anno " + Meta.GetSys("esercizio").ToString();
            grpAnnoSuccessivo.Text = "Anno " + annonext.ToString();
        }

        public void MetaData_BeforeFill()
        {
            if ((Meta.InsertMode) && (Meta.FirstFillForThisRow))
            {
                rdbCostoCorr.Tag = "C";
            }
            else
            {
                SetTagCostoCorr();
            }
        }

        public void MetaData_AfterFill()
        {
            rdbCostoSucc.Checked = rdbCostoCorr.Checked;
            rdbRicavoSucc.Checked = rdbPassivitaCorr.Checked;
            if ((Meta.InsertMode) || (Meta.EditMode))
            {
                rdbCostoSucc.Enabled = false;
                rdbRicavoSucc.Enabled = false;
            }
        }

        public void SetTagCostoCorr()
        {
            rdbCostoCorr.Tag = "placcount.placcpart:C?placcountlookupview.oldplaccpart:C";
        }

        public void MetaData_AfterClear()
        {
            // Di default pongo Costo in fase di ricerca
            rdbCostoCorr.Checked = true;//false; sa
            rdbCostoSucc.Checked = true;//false; sa
            rdbPassivitaCorr.Checked = false;
            rdbRicavoSucc.Checked = false; 
        }

        private void rdbCostoCorr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCostoCorr.Checked)
            {
                btnContoEcon.Tag = "manage.placcount.treec";
                grpContoEconCorr.Tag = "AutoManage.txtContoEcon.treec";
                rdbCostoSucc.Checked = true;
            }
            if (!Meta.DrawStateIsDone) return;
            DS.placcount.Clear();
            txtContoEcon.Text = "";
            txtDescrizione.Text = "";
            if (Meta.IsEmpty) return;
        }

        private void rdbRicavoCorr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPassivitaCorr.Checked)
            {
                btnContoEcon.Tag = "manage.placcount.treer";
                grpContoEconCorr.Tag = "AutoManage.txtContoEcon.treer";
                rdbRicavoSucc.Checked = true;
                SetTagCostoCorr();
            }
            if (!Meta.DrawStateIsDone) return;
            DS.placcount.Clear();
            txtContoEcon.Text = "";
            txtDescrizione.Text = "";
            if (Meta.IsEmpty) return;
        }

        private void rdbCostoSucc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCostoSucc.Checked)
            {
                btnNewContoEcon.Tag = "manage.placcount1.treecnew";
                grpContoEconSucc.Tag = "AutoManage.txtNewContoEcon.treecnew";
            }
            if (!Meta.DrawStateIsDone) return;
            DS.placcount1.Clear();
            txtNewContoEcon.Text = "";
            txtNewDescrizione.Text = "";
            if (Meta.IsEmpty) return;
        }

        private void rdbRicavoSucc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRicavoSucc.Checked)
            {
                btnNewContoEcon.Tag = "manage.placcount1.treernew";
                grpContoEconSucc.Tag = "AutoManage.txtContoEcon.treernew";
            }
            if (!Meta.DrawStateIsDone) return;
            DS.placcount1.Clear();
            txtNewContoEcon.Text = "";
            txtNewDescrizione.Text = "";
            if (Meta.IsEmpty) return;
        }
    }
}
