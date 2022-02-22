
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
using metaeasylibrary;

namespace patrimonylookup_default
{
    public partial class Frm_patrimonylookup_default : MetaDataForm
    {
        public Frm_patrimonylookup_default()
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
            DataAccess.SetTableForReading(DS.patrimony1, "patrimony");
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.patrimony, filteresercizio);

            int annonext = Convert.ToInt32(Meta.GetSys("esercizio")) + 1;
            filteresercizionew = QHS.CmpEq("ayear", annonext);

            GetData.SetStaticFilter(DS.patrimony1, filteresercizionew);

            string filterstatopatrimoniale = QHS.Like("oldidpatrimony",
                Meta.GetSys("esercizio").ToString().Substring(2, 2) + "%");
            GetData.SetStaticFilter(DS.patrimonylookup, filterstatopatrimoniale);
            GetData.SetStaticFilter(DS.patrimonylookupview, filterstatopatrimoniale);

            GetData.CacheTable(DS.patrimonylevel, filteresercizio, null, false);
            grpAnnoCorrente.Text = "Anno " + Meta.GetSys("esercizio").ToString();
            grpAnnoSuccessivo.Text = "Anno " + annonext.ToString();
        }

        public void MetaData_BeforeFill()
        {
            if ((Meta.InsertMode) && (Meta.FirstFillForThisRow))
            {
                rdbAttivitaCorr.Tag = "A";
            }
            else
            {
                SetTagAttivitaCorr();
            }
        }

        public void MetaData_AfterFill()
        {
            rdbAttivitaSucc.Checked = rdbAttivitaCorr.Checked;
            rdbPassivitaSucc.Checked = rdbPassivitaCorr.Checked;
            if ((Meta.InsertMode) || (Meta.EditMode))
            {
                rdbAttivitaSucc.Enabled = false;
                rdbPassivitaSucc.Enabled = false;
            }
        }

        public void SetTagAttivitaCorr()
        {
            rdbAttivitaCorr.Tag = "patrimony.patpart:A?patrimonylookupview.oldpatpart:A";
        }

        public void MetaData_AfterClear()
        {
            // Di default pongo Attivita in fase di ricerca
            rdbAttivitaCorr.Checked = true;//false; sa
            rdbAttivitaSucc.Checked = true;//false; sa

            rdbPassivitaCorr.Checked = false;
            rdbPassivitaSucc.Checked = false;
        }

        private void rdbAttivitaCorr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAttivitaCorr.Checked)
            {
                btnStatoPatrim.Tag = "manage.patrimony.treea";
                grpStatoPatrimCorr.Tag = "AutoManage.txtStatoPatrim.treea";
                rdbAttivitaSucc.Checked = true;
            }
            if (!Meta.DrawStateIsDone) return;
            DS.patrimony.Clear();
            txtStatoPatrim.Text = "";
            if (Meta.IsEmpty) return;
        }

        private void rdbPassivitaCorr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPassivitaCorr.Checked)
            {
                btnStatoPatrim.Tag = "manage.patrimony.treep";
                grpStatoPatrimCorr.Tag = "AutoManage.txtStatoPatrim.treep";
                rdbPassivitaSucc.Checked = true;

                SetTagAttivitaCorr();
            }
            if (!Meta.DrawStateIsDone) return;
            DS.patrimony.Clear();
            txtStatoPatrim.Text = "";
            if (Meta.IsEmpty) return;
        }

        private void rdbAttivitaSucc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAttivitaSucc.Checked)
            {
                btnNewStatoPatrim.Tag = "manage.patrimony1.treeanew";
                grpStatoPatrimSucc.Tag = "AutoManage.txtNewStatoPatrim.treeanew";
            }
            if (!Meta.DrawStateIsDone) return;
            DS.patrimony1.Clear();
            txtNewStatoPatrim.Text = "";
            if (Meta.IsEmpty) return;
        }

        private void rdbPassivitaSucc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPassivitaSucc.Checked)
            {
                btnNewStatoPatrim.Tag = "manage.patrimony1.treepnew";
                grpStatoPatrimSucc.Tag = "AutoManage.txtNewStatoPatrim.treepnew";
            }
            if (!Meta.DrawStateIsDone) return;
            DS.patrimony1.Clear();
            txtNewStatoPatrim.Text = "";
            if (Meta.IsEmpty) return;
        }
    }
}
