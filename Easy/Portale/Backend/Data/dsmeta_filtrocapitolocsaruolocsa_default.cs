
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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_filtrocapitolocsaruolocsa_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_filtrocapitolocsaruolocsa_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ruolocsa 		=> (MetaTable)Tables["ruolocsa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable filtrocapitolocsaruolocsa 		=> (MetaTable)Tables["filtrocapitolocsaruolocsa"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_filtrocapitolocsaruolocsa_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_filtrocapitolocsaruolocsa_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_filtrocapitolocsaruolocsa_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_filtrocapitolocsaruolocsa_default.xsd";

	#region create DataTables
	//////////////////// POSITIONDEFAULTVIEW /////////////////////////////////
	var tpositiondefaultview= new MetaTable("positiondefaultview");
	tpositiondefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpositiondefaultview.defineColumn("idposition", typeof(int),false);
	tpositiondefaultview.defineColumn("position_active", typeof(string));
	Tables.Add(tpositiondefaultview);
	tpositiondefaultview.defineKey("idposition");

	//////////////////// RUOLOCSA /////////////////////////////////
	var truolocsa= new MetaTable("ruolocsa");
	truolocsa.defineColumn("idruolocsa", typeof(string),false);
	Tables.Add(truolocsa);
	truolocsa.defineKey("idruolocsa");

	//////////////////// FILTROCAPITOLOCSARUOLOCSA /////////////////////////////////
	var tfiltrocapitolocsaruolocsa= new MetaTable("filtrocapitolocsaruolocsa");
	tfiltrocapitolocsaruolocsa.defineColumn("ct", typeof(DateTime));
	tfiltrocapitolocsaruolocsa.defineColumn("cu", typeof(string));
	tfiltrocapitolocsaruolocsa.defineColumn("idfiltrocapitolocsa", typeof(int),false);
	tfiltrocapitolocsaruolocsa.defineColumn("idfiltrocapitolocsaruolocsa", typeof(int),false);
	tfiltrocapitolocsaruolocsa.defineColumn("idposition", typeof(int),false);
	tfiltrocapitolocsaruolocsa.defineColumn("idruolocsa", typeof(string),false);
	tfiltrocapitolocsaruolocsa.defineColumn("lt", typeof(DateTime));
	tfiltrocapitolocsaruolocsa.defineColumn("lu", typeof(string));
	Tables.Add(tfiltrocapitolocsaruolocsa);
	tfiltrocapitolocsaruolocsa.defineKey("idfiltrocapitolocsa", "idfiltrocapitolocsaruolocsa");

	#endregion


	#region DataRelation creation
	var cPar = new []{positiondefaultview.Columns["idposition"]};
	var cChild = new []{filtrocapitolocsaruolocsa.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsaruolocsa_positiondefaultview_idposition",cPar,cChild,false));

	cPar = new []{ruolocsa.Columns["idruolocsa"]};
	cChild = new []{filtrocapitolocsaruolocsa.Columns["idruolocsa"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsaruolocsa_ruolocsa_idruolocsa",cPar,cChild,false));

	#endregion

}
}
}
