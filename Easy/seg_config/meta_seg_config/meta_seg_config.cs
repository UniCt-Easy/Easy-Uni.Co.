
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


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace meta_seg_config {
//	class meta_seg_config {
//	}
//}

using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_seg_config {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_seg_config : Meta_easydata {
		public Meta_seg_config(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "seg_config") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T, "dummykey", 1);
			SetDefault(T, "flag", 0);
		}

		protected override Form GetForm(string FormName) {
			Name = "Configurazione Pluriennale Comune";
			return MetaData.GetFormByDllName("seg_config_default");
		}
	}
}
