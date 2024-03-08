
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace notable_importazione {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaCorsoLaurea"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaCorsoLaurea: DataSet {

	#region Table members declaration
	///<summary>
	///elenco corsi laurea prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_corsolaurea 		=> Tables["stip_corsolaurea"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaCorsoLaurea(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaCorsoLaurea (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaCorsoLaurea";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaCorsoLaurea.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// STIP_CORSOLAUREA /////////////////////////////////
	var tstip_corsolaurea= new DataTable("stip_corsolaurea");
	C= new DataColumn("idstipcorsolaurea", typeof(int));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	C= new DataColumn("codicecorsolaurea", typeof(string));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("descrizionecorsolaurea", typeof(string)));
	C= new DataColumn("codicedipartimento", typeof(string));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("dipartimento", typeof(string)));
	C= new DataColumn("codicesede", typeof(string));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("sede", typeof(string)));
	C= new DataColumn("codicepercorso", typeof(string));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("percorso", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("anno", typeof(int)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("cu", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("lu", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("codicecausale", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("causale", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idstiptassa", typeof(int)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idstipvoce", typeof(int)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idsor3", typeof(int)));
	Tables.Add(tstip_corsolaurea);
	tstip_corsolaurea.PrimaryKey =  new DataColumn[]{tstip_corsolaurea.Columns["idstipcorsolaurea"]};


	#endregion

}
}
}
