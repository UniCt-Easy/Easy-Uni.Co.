/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_users_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_users_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_users 		=> (MetaTable)Tables["firenet_users"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_users_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_users_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_users_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_users_default.xsd";

	#region create DataTables
	//////////////////// FIRENET_USERS /////////////////////////////////
	var tfirenet_users= new MetaTable("firenet_users");
	tfirenet_users.defineColumn("anpr", typeof(string));
	tfirenet_users.defineColumn("attivo", typeof(decimal));
	tfirenet_users.defineColumn("badge", typeof(decimal));
	tfirenet_users.defineColumn("cap", typeof(string));
	tfirenet_users.defineColumn("cap_domicilio", typeof(string));
	tfirenet_users.defineColumn("cellulare", typeof(string));
	tfirenet_users.defineColumn("citta", typeof(string));
	tfirenet_users.defineColumn("citta_domicilio", typeof(string));
	tfirenet_users.defineColumn("codfisc", typeof(string));
	tfirenet_users.defineColumn("created", typeof(DateTime));
	tfirenet_users.defineColumn("dataammis", typeof(string));
	tfirenet_users.defineColumn("datanascita", typeof(string));
	tfirenet_users.defineColumn("diploma", typeof(string));
	tfirenet_users.defineColumn("diplsup", typeof(decimal));
	tfirenet_users.defineColumn("domicilio_corrispondente", typeof(decimal));
	tfirenet_users.defineColumn("dsa", typeof(decimal));
	tfirenet_users.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_users.defineColumn("email", typeof(string));
	tfirenet_users.defineColumn("email_privata", typeof(string));
	tfirenet_users.defineColumn("fax", typeof(decimal));
	tfirenet_users.defineColumn("foto", typeof(decimal));
	tfirenet_users.defineColumn("id", typeof(int),false);
	tfirenet_users.defineColumn("indirizzo", typeof(string));
	tfirenet_users.defineColumn("indirizzo_domicilio", typeof(string));
	tfirenet_users.defineColumn("lastlogin", typeof(string));
	tfirenet_users.defineColumn("location_id", typeof(decimal));
	tfirenet_users.defineColumn("luogonascita", typeof(string));
	tfirenet_users.defineColumn("modified", typeof(DateTime));
	tfirenet_users.defineColumn("name", typeof(string));
	tfirenet_users.defineColumn("nazionalita", typeof(string));
	tfirenet_users.defineColumn("nazione", typeof(string));
	tfirenet_users.defineColumn("note", typeof(string));
	tfirenet_users.defineColumn("operator_user_id", typeof(int));
	tfirenet_users.defineColumn("password", typeof(string));
	tfirenet_users.defineColumn("permessi", typeof(string));
	tfirenet_users.defineColumn("privacy", typeof(decimal));
	tfirenet_users.defineColumn("provincia", typeof(string));
	tfirenet_users.defineColumn("provincia_domicilio", typeof(string));
	tfirenet_users.defineColumn("provincianascita", typeof(string));
	tfirenet_users.defineColumn("puntiammis", typeof(decimal));
	tfirenet_users.defineColumn("region_id", typeof(string));
	tfirenet_users.defineColumn("sesso", typeof(decimal));
	tfirenet_users.defineColumn("surname", typeof(string));
	tfirenet_users.defineColumn("telefono", typeof(string));
	tfirenet_users.defineColumn("utente", typeof(string));
	tfirenet_users.defineColumn("visualizza", typeof(decimal));
	Tables.Add(tfirenet_users);
	tfirenet_users.defineKey("id");

	#endregion

}
}
}
