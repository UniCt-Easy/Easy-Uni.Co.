
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//Pino: using licenzauso; diventato inutile
using checkflags;//checkflags

namespace meta_license//meta_licenzauso//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_license : Meta_easydata 
	{
		public Meta_license(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "license") 
		{
			EditTypes.Add("default");
			EditTypes.Add("estesa");
			ListingTypes.Add("licenzauso");
			Name = "Informazioni ente contabile";
		}
		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"dummykey","A");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="licenzauso";
				Form F = GetFormByDllName("license_default");
				return F;
			}
			if (FormName=="estesa") {
				DefaultListType="licenzauso";
				Name="Informazioni sul cliente";
				Form F = GetFormByDllName("license_estesa");
				return F;
			}

			if (FormName=="manage") {
				DefaultListType="licenzauso";
				Name="Informazioni sulla licenza";
				Form F = GetFormByDllName("license_manage");
				return F;
			}
			return null;
		}		
	
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			DescribeAColumn(T, "departmentname", "");
		}   

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (edit_type=="default")return base.IsValid (R, out errmess, out errfield);

			if (edit_type=="manage"){
				if (CheckFlags.CalcolaCheckLic(R)!=R["checklic"].ToString()){
					errmess="Licenza non valida";
					errfield="checklic";
					return false;
				}
				if (CheckFlags.CalcolaCheckMan(R)!=R["checkman"].ToString()){
					errmess="Licenza non valida";
					errfield="checkman";
					return false;
				}
				if (CheckFlags.CalcolaCheckFlag(R)!=R["checkflag"].ToString()){
					errmess="Licenza non valida";
					errfield="checkflag";
					return false;
				}
				if (R.Table.Columns["serverbackup1"]!=null){
					if ((R["serverbackup1"].ToString()!="")&&
							(CalcolaCheckBackup1(R).ToUpper()!=R["checkbackup1"].ToString().ToUpper())){
						errmess="Licenza backup 1 non valida";
						errfield="checkbackup1";
						return false;
					}
				}
				if (R.Table.Columns["serverbackup2"]!=null){
					if ((R["serverbackup2"].ToString()!="")&&
							(CalcolaCheckBackup2(R).ToUpper()!=R["checkbackup2"].ToString().ToUpper())){
						errmess="Licenza backup 2 non valida";
						errfield="checkbackup2";
						return false;
					}
				}

				
			}
			if (edit_type=="estesa"){
				if (R["phonenumber"].ToString().Length<=8){
					errfield="phonenumber";					
					errmess="Per cortesia "+R["referent"].ToString()+
						" inserisca il n. di telefono ";
					return false;
				}
				if (R["fax"].ToString().Length<=8){
					errfield="fax";					
					errmess="Per cortesia "+R["referent"].ToString()+
						" inserisca il n. di fax ";
					return false;
				}
				if ((R["email"].ToString().Length<=8)||
					(R["email"].ToString().IndexOf("@")<=0) ||
					(R["email"].ToString().IndexOf(".")<=0)
					){
					errfield="email";					
					errmess="Per cortesia "+R["referent"].ToString()+
						" inserisca l'indirizzo e-mail corretto";
					return false;
				}

			}
	
			return base.IsValid (R, out errmess, out errfield);

		}
		string CalcolaCheckBackup1(DataRow R){
			string S= "1"+QueryCreator.quotedstrvalue(R["iddb"],true)+
				QueryCreator.quotedstrvalue(R["serverbackup1"].ToString().ToUpper(),true)+
				QueryCreator.quotedstrvalue(R["dbname"],true)+
				QueryCreator.quotedstrvalue(R["swmoreflag"],true)+
				QueryCreator.quotedstrvalue(R["swmorecode"],true);
			string Check = CheckFlags.GetCheck(S);
			return Check;
		}
		string CalcolaCheckBackup2(DataRow R){
			string S= "2"+QueryCreator.quotedstrvalue(R["iddb"],true)+
				QueryCreator.quotedstrvalue(R["serverbackup2"].ToString().ToUpper(),true)+
				QueryCreator.quotedstrvalue(R["dbname"],true)+
				QueryCreator.quotedstrvalue(R["swmoreflag"],true)+
				QueryCreator.quotedstrvalue(R["swmorecode"],true);
			string Check = CheckFlags.GetCheck(S);
			return Check;
		}

	}
}
