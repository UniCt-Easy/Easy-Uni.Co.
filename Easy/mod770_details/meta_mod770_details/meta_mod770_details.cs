
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;
using System.Windows.Forms;


namespace meta_mod770_details
{
	/// <summary>
	/// Summary description for meta_mod770_details.
	/// </summary>
	public class Meta_mod770_details : Meta_easydata {
		public Meta_mod770_details(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "mod770_details") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}


		protected override Form GetForm(string FormName) {
			switch (FormName) {
				case "default": {
					DefaultListType = "default";
					Name = "Modello 770";
					return MetaData.GetFormByDllName("mod770_details_default");
				}
			}
          
            switch (FormName) {
                case "consolidamento": {
                        DefaultListType = "default";
                        Name = "Modello 770";
                        return MetaData.GetFormByDllName("mod770_details_consolidamento");
                    }
            }
            return null;
		}


	}
}
