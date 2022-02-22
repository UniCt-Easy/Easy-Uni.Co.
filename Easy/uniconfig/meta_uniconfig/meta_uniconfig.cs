
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_uniconfig
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_uniconfig : Meta_easydata 
	{
		public Meta_uniconfig(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "uniconfig") 
		{
			EditTypes.Add("default");
			EditTypes.Add("pwd_config");
			ListingTypes.Add("default");
		}
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "dummykey", 1);
			SetDefault(T, "pwd_requiredlength", 0);
			SetDefault(T, "pwd_requireduniquechars", 1);
			SetDefault(T, "pwd_requirenonalphanumeric", "N");
			SetDefault(T, "pwd_requirelowercase", "N");
			SetDefault(T, "pwd_requireuppercase", "N");
			SetDefault(T, "pwd_requiredigit", "N");
		}

		protected override Form GetForm(string FormName)
		{
            switch (FormName)
            {
				case "default":
					Name = "Configurazione Pluriennale";
					break;
				case "pwd_config":
					Name = "Criteri di complessità della password";
					break;
				default:
					return null;
                    break;
            }
			return GetFormByDllName("uniconfig_default");
		}
	}
}
