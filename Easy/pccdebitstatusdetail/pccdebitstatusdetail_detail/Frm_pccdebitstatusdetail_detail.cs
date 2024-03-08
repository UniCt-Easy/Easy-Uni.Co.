
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
using System.IO;
using funzioni_configurazione;
using metadatalibrary;

namespace pccdebitstatusdetail_detail {
	public partial class Frm_pccdebitstatusdetail_detail : MetaDataForm {
		MetaData Meta;
		QueryHelper QHS;
		private DataAccess Conn;
		public Frm_pccdebitstatusdetail_detail() {
			InitializeComponent();
		}

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			QHS = Meta.Conn.GetQueryHelper();
			this.Conn = Meta.Conn;
		}
		public void MetaData_AfterFill() {
			DataRow Curr = DS.pccdebitstatusdetail.Rows[0];
			bool Enable = Curr["idpcc"] == DBNull.Value;
			AbilitaControlli(Enable);
		}
		public void MetaData_AfterPost() {
			Meta.SourceRow.Table.ExtendedProperties["RigaModificataPCC"] = Meta.SourceRow;
		}
		public void AbilitaControlli(bool Enable) {
			grpNonCommerciale.Enabled = Enable;
			grpNonliquidabile.Enabled = Enable;
			grpSospesoContenzioso.Enabled = Enable;
			grpSospesoContestazione.Enabled = Enable;
			grpSospesoDataRegolare.Enabled = Enable;

		}
		private void label3_Click(object sender, EventArgs e) {

		}
	}
}
