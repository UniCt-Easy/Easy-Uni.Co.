
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
using metadatalibrary;
using metaeasylibrary;
using export_default;//ExportForm
using System.Windows.Forms;

namespace meta_export{//meta_export//
	/// <summary>
	/// Summary description for export.
	/// </summary>
	public class Meta_export : Meta_easydata {
	
		public Meta_export(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "export") {	
			EditTypes.Add("default");
			Name = "Export Parameter";	
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
			    if (ExtraParameter == null) return null;
				frmExport F = new frmExport();
			    ErrorLogger.Logger.warnEvent($"OpenForm: frmExport {ExtraParameter}");
				//	ExtraParameter  contiene il parametro da passare a BuildForm				
				if (!F.BuildForm(ExtraParameter.ToString(),this)){
					QueryCreator.ShowError(null,"Non è stato possibile avviare l'esportazione ",
						"Errore nella costruzione del form dei parametri. Provare ad aggiornare il menu.");
					return null;
				}
				return F;
			}
			return null;
		}			

	}
}
