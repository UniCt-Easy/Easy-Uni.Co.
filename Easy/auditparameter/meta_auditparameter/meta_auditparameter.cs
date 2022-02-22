
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
using metadatalibrary;
using metaeasylibrary;
//using ruleparameter_recalc;//parameterrecalc
using System.Windows.Forms;

namespace meta_auditparameter//meta_parameter//
{
	/// <summary>
	/// Summary description for Meta_parameter.
	/// </summary>
	public class Meta_auditparameter : Meta_easydata 
	{
		public Meta_auditparameter(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "auditparameter") {
			EditTypes.Add("recalc");
			Name = "parameter";
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="recalc") {
				//FrmParameterRecalc F = new FrmParameterRecalc();
				return MetaData.GetFormByDllName("auditparameter_recalc");
			}

			return null;
		}			
	}
}
