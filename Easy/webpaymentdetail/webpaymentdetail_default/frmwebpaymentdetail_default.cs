
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace webpaymentdetail_default {
	public partial class frmwebpaymentdetail_default : MetaDataForm {
		MetaData Meta;
		DataAccess Conn;
		CQueryHelper QHC = new CQueryHelper();
		QueryHelper QHS;
		EntityDispatcher Dispatcher;
		int esercizio;
		public frmwebpaymentdetail_default() {
			InitializeComponent();
		}
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Dispatcher = Meta.Dispatcher as EntityDispatcher;
			Conn = Meta.Conn;
			esercizio = Conn.GetEsercizio();
			QHS = Conn.GetQueryHelper();
			//bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");

			Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;

			DataAccess.SetTableForReading(DS.sorting1, "sorting");
			DataAccess.SetTableForReading(DS.sorting2, "sorting");
			DataAccess.SetTableForReading(DS.sorting3, "sorting");

			string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
				filterEsercizio, null, null, true);
			
			//GetData.SetStaticFilter(DS.webpaymentdetail, QHS.CmpEq("ywebpayment", Meta.GetSys("esercizio")));
			GetData.SetStaticFilter(DS.webpaymentdetailview, QHS.CmpEq("ywebpayment", Meta.GetSys("esercizio")));

			if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
				DataRow R = tExpSetup.Rows[0];
				object idsorkind1 = R["idsortingkind1"];
				object idsorkind2 = R["idsortingkind2"];
				object idsorkind3 = R["idsortingkind3"];
				CfgFn.SetGBoxClass(this, 1, idsorkind1);
				CfgFn.SetGBoxClass(this, 2, idsorkind2);
				CfgFn.SetGBoxClass(this, 3, idsorkind3);
			}
		}

		public void MetaData_AfterFill() {
			enableControls(false);
		}

		public void MetaData_AfterClear() {
			enableControls(true);
			txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
		}

		private void enableControls(bool abilita)
		{
			bool readOnly = !abilita;
			grpDettaglio.Enabled = abilita;
			gboxclass1.Enabled = abilita;
			gboxclass2.Enabled = abilita;
			gboxclass3.Enabled = abilita;
			txtAnnotazioni.Enabled = abilita;
			txtPrenotazione.ReadOnly = readOnly;
			txtEsercizio.ReadOnly = readOnly;
			txtNumPrenotazione.ReadOnly = readOnly;
			txtNumDettaglio.ReadOnly = readOnly;
			grpAnagrafica.Enabled = abilita;
			txtIUV.ReadOnly = readOnly;
			txtIdFlussoCrediti.ReadOnly = readOnly;
			cmbStatoCorrente.Enabled = abilita;
		}
	}
}
