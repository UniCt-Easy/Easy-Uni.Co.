
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
 
namespace meta_customusergroup 
{
	/// <summary>
	/// Summary description for customusergroup
	/// </summary>
	public class Meta_customusergroup : Meta_easydata
	{
		public Meta_customusergroup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "customusergroup") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
 
			//
			// TODO: Add constructor logic here
			//
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				Name="Associazione Utenti - Gruppi";
				DefaultListType="default";
				return MetaData.GetFormByDllName("customusergroup_default"); 
			}
	
			return null;
		}


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude)
        {
            if (ListingType == "default")
                return base.SelectOne("default", filter, "customusergroupview", Exclude);

            return base.SelectOne(ListingType, filter, "customusergroupview", Exclude);
        }

		 
	}
}

