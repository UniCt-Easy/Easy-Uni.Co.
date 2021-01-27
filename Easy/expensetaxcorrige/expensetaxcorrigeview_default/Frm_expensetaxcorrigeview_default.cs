
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
using funzioni_configurazione;

namespace expensetaxcorrigeview_default
{
    public partial class Frm_expensetaxcorrigeview_default : Form
    {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        public Frm_expensetaxcorrigeview_default()
        {
            InitializeComponent();
        }
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.CanCancel = false;
            Meta.CanInsertCopy = false;
            string filter = "(ymov = '" + Meta.GetSys("esercizio") + "')";
            GetData.SetStaticFilter(DS.expensetaxcorrigeview, filter);
        }

        public void MetaData_AfterClear()
        {
            txtEsercMov.Text = Meta.GetSys("esercizio").ToString();
            grpCity.Visible = false;
            grpRegion.Visible = false;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            if (T.TableName == "tax")
            {
                if (!Meta.DrawStateIsDone) return;
                if (R == null)
                {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                }
                else
                {
                    DataRow[] Tax = DS.tax.Select(QHC.CmpEq("taxcode", R["taxcode"]));
                    if (Tax.Length > 0)
                    {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo)
                        {
                            case "C":
                                {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                    break;
                                }
                            case "R":
                                {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    txtGeoComune0101.Text = "";
                                    txtProvincia.Text = "";
                                    break;
                                }
                            default:
                                {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    txtGeoComune0101.Text = "";
                                    txtProvincia.Text = "";
                                    HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                    break;
                                }
                        }
                    }
                }
            }
        }

        public void MetaData_AfterFill()
        {
            if ((Meta.FirstFillForThisRow) && (DS.expensetaxcorrigeview.Rows.Count > 0))
            {
                DataRow Curr = DS.expensetaxcorrigeview.Rows[0];
                if (CfgFn.GetNoNullInt32(Curr["taxcode"]) == 0)
                {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                }
                else
                {
                    DataRow[] Tax = DS.tax.Select(QHC.CmpEq("taxcode", Curr["taxcode"]));
                    if (Tax.Length > 0)
                    {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo)
                        {
                            case "C":
                                {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    break;
                                }
                            case "R":
                                {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    break;
                                }
                            default:
                                {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    break;
                                }
                        }
                    }
                }
            }
        }



    }
}
