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

namespace autoincomesorting_single
{
    public partial class Frm_autoincomesorting_single : Form{
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        DataAccess Conn;
        public Frm_autoincomesorting_single(){
            InitializeComponent();
        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataRow ParentRow = Meta.SourceRow;
            //string filterupb = QHS.CmpEq("idupb", ParentRow["idupb"]);
            //string filter = QHS.AppAnd(QHS.IsNull("idfin"), QHS.IsNull("idman"), QHS.IsNull("idsorreg"), QHS.IsNull("idsorkindreg"));
            //filter = QHS.AppAnd(filter, filtereserc, filterupb);
            //GetData.SetStaticFilter(DS.autoincomesorting, filter);
            //GetData.SetStaticFilter(DS.autoincomesortingview, filter);
            
            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI_SK = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
            QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive,
            QHS.IsNotNull("nphaseincome"))), QHS.CmpEq("idsorkind", 0)));
            QueryCreator.SetFilterForInsert(DS.sortingkind, filterI_SK);
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R){
            if (T.TableName == "sortingkind"){
                if (MetaData.GetMetaData(this).DrawState == MetaData.form_drawstates.done){
                    if ((!MetaData.Empty(this)))
                    {
                        DS.autoincomesorting.Rows[0]["idsor"] = DBNull.Value;
                        DS.autoincomesorting.Rows[0]["idsorkind"] = 0;
                    }
                    txtCodiceMov.Text = "";
                    txtDescrizioneMov.Text = "";
                    DS.sorting.Clear();
                }
                SetCodiceMovim();
                AggiornaEtichette();
            }
        }

        void AggiornaEtichette()
        {

            string codtipomov = cmbTipoMov.SelectedValue.ToString();
            DataRow Rtipo = DS.sortingkind.Select(QHC.CmpEq("idsorkind", codtipomov))[0];

            if (Rtipo["flagdate"].ToString().ToLower() != "s")
            {
                chkIgnoraDate.Visible = false;
                labelignoradate.Visible = false;
                HelpForm.SetDenyNull(DS.autoincomesorting.Columns["flagnodate"], false);
            }
            else
            {
                chkIgnoraDate.Visible = true;
                labelignoradate.Visible = true;
                HelpForm.SetDenyNull(DS.autoincomesorting.Columns["flagnodate"], true);
            }
        }


        void NascondiEtichette()
        {
            chkIgnoraDate.Visible = false;
            labelignoradate.Visible = false;

        }

        public void MetaData_AfterClear()
        {
            TxtDenominatore.TextAlign = HorizontalAlignment.Center;
            TxtNumeratore.TextAlign = HorizontalAlignment.Center;
        }

        public void MetaData_AfterFill()
        {
            SetCodiceMovim();
        }

        void SetCodiceMovim()
        {
            btnCodiceMov.Enabled = (cmbTipoMov.SelectedIndex > 0);
            txtCodiceMov.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
            if (cmbTipoMov.SelectedIndex <= 0)
            {
                txtCodiceMov.Text = "";
                txtDescrizioneMov.Text = "";
            }
            else
            {
                string filter = QHS.CmpEq("idsorkind", cmbTipoMov.SelectedValue);
                DataTable Available = Conn.RUN_SELECT("sorting", "*", null, filter, null, null, true);
                btnCodiceMov.Tag = "manage.sorting.tree." + filter;
                gboxClassMov.Tag = "AutoManage.txtCodiceMov.tree." + filter;
                MetaData.AutoInfo AI = Meta.GetAutoInfo(txtCodiceMov.Name);
                if (AI != null) AI.startfilter = filter;

                //Meta.SetAutoMode(gboxClassMov);
                //label per il form di selezione della voce di classificazione +"."+ filtro
                DS.sorting.ExtendedProperties[MetaData.ExtraParams] = Available;
            }
        }

    }
}