
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


using metadatalibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logemail_default {
	public partial class frmLogEmail : MetaDataForm {

		private MetaData Meta;

		public frmLogEmail() {
			InitializeComponent();
		}

		public void MetaData_AfterLink() {
			Meta= MetaData.GetMetaData(this);

			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanCancel=false;
			Meta.CanSave=false;			
		}
		public void MetaData_AfterClear() {			
			EnableDisableControls(false);				
		}

		public void MetaData_AfterFill() {
			EnableDisableControls(true);
		}

		void EnableDisableControls(bool enable)	{
			txtSent.ReadOnly = enable;
			txtAllegato.ReadOnly = enable;
			txtSender.ReadOnly = enable;
			txtReceiver.ReadOnly = enable;
			txtCc.ReadOnly = enable;
			textBox1.ReadOnly = enable;
			txtSubject.ReadOnly = enable;
			txtMessage.ReadOnly = enable;
			txtErrorMess.ReadOnly = enable;
		}
	}
}
