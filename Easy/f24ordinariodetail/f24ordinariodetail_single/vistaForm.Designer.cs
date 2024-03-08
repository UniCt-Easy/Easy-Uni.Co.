
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
namespace f24ordinariodetail_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24ordinariodetail 		=> Tables["f24ordinariodetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24sezione 		=> Tables["f24sezione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24entilocali 		=> Tables["f24entilocali"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24altrientiprevidenzialiassicurativi 		=> Tables["f24altrientiprevidenzialiassicurativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24sediinail 		=> Tables["f24sediinail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fiscaltaxregion 		=> Tables["fiscaltaxregion"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24sedialtrienti 		=> Tables["f24sedialtrienti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable PROVINCIA 		=> Tables["PROVINCIA"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24tributi 		=> Tables["f24tributi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// F24ORDINARIODETAIL /////////////////////////////////
	var tf24ordinariodetail= new DataTable("f24ordinariodetail");
	C= new DataColumn("idf24ordinario", typeof(int));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("codicetributo", typeof(string));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	tf24ordinariodetail.Columns.Add( new DataColumn("codiceufficio", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("codiceatto", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("riferimentoa", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("riferimentob", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("importoadebito", typeof(decimal)));
	tf24ordinariodetail.Columns.Add( new DataColumn("importoacredito", typeof(decimal)));
	tf24ordinariodetail.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("ravvedimentooperoso", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("immobilivariati", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("accontosaldo", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("numeroimmobili", typeof(int)));
	tf24ordinariodetail.Columns.Add( new DataColumn("detrazioneabitazione", typeof(decimal)));
	tf24ordinariodetail.Columns.Add( new DataColumn("idaltrienti", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("idcodicesedealtrienti", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("codiceposizione", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	tf24ordinariodetail.Columns.Add( new DataColumn("idprovincia", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("identificativooperazione", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("identelocale", typeof(int)));
	tf24ordinariodetail.Columns.Add( new DataColumn("catastalecomune", typeof(string)));
	C= new DataColumn("idf24sezione", typeof(string));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	tf24ordinariodetail.Columns.Add( new DataColumn("codiceditta", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("cc_codiceditta", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("numerodiriferimento", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("causaleinail", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("codicesedeinail", typeof(string)));
	Tables.Add(tf24ordinariodetail);
	tf24ordinariodetail.PrimaryKey =  new DataColumn[]{tf24ordinariodetail.Columns["idf24ordinario"], tf24ordinariodetail.Columns["iddetail"]};


	//////////////////// F24SEZIONE /////////////////////////////////
	var tf24sezione= new DataTable("f24sezione");
	C= new DataColumn("idf24sezione", typeof(string));
	C.AllowDBNull=false;
	tf24sezione.Columns.Add(C);
	C= new DataColumn("descrizione", typeof(string));
	C.AllowDBNull=false;
	tf24sezione.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24sezione.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24sezione.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24sezione.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24sezione.Columns.Add(C);
	tf24sezione.Columns.Add( new DataColumn("printingorder", typeof(string)));
	Tables.Add(tf24sezione);
	tf24sezione.PrimaryKey =  new DataColumn[]{tf24sezione.Columns["idf24sezione"]};


	//////////////////// F24ENTILOCALI /////////////////////////////////
	var tf24entilocali= new DataTable("f24entilocali");
	C= new DataColumn("attivo", typeof(string));
	C.AllowDBNull=false;
	tf24entilocali.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24entilocali.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24entilocali.Columns.Add(C);
	C= new DataColumn("descrizione", typeof(string));
	C.AllowDBNull=false;
	tf24entilocali.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24entilocali.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24entilocali.Columns.Add(C);
	C= new DataColumn("identelocale", typeof(int));
	C.AllowDBNull=false;
	tf24entilocali.Columns.Add(C);
	Tables.Add(tf24entilocali);
	tf24entilocali.PrimaryKey =  new DataColumn[]{tf24entilocali.Columns["identelocale"]};


	//////////////////// F24ALTRIENTIPREVIDENZIALIASSICURATIVI /////////////////////////////////
	var tf24altrientiprevidenzialiassicurativi= new DataTable("f24altrientiprevidenzialiassicurativi");
	C= new DataColumn("descrizione", typeof(string));
	C.AllowDBNull=false;
	tf24altrientiprevidenzialiassicurativi.Columns.Add(C);
	C= new DataColumn("attivo", typeof(string));
	C.AllowDBNull=false;
	tf24altrientiprevidenzialiassicurativi.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24altrientiprevidenzialiassicurativi.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24altrientiprevidenzialiassicurativi.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24altrientiprevidenzialiassicurativi.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24altrientiprevidenzialiassicurativi.Columns.Add(C);
	C= new DataColumn("idaltrienti", typeof(string));
	C.AllowDBNull=false;
	tf24altrientiprevidenzialiassicurativi.Columns.Add(C);
	Tables.Add(tf24altrientiprevidenzialiassicurativi);
	tf24altrientiprevidenzialiassicurativi.PrimaryKey =  new DataColumn[]{tf24altrientiprevidenzialiassicurativi.Columns["idaltrienti"]};


	//////////////////// F24SEDIINAIL /////////////////////////////////
	var tf24sediinail= new DataTable("f24sediinail");
	C= new DataColumn("codicesede", typeof(string));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	tf24sediinail.Columns.Add( new DataColumn("nomesede", typeof(string)));
	tf24sediinail.Columns.Add( new DataColumn("indirizzo", typeof(string)));
	tf24sediinail.Columns.Add( new DataColumn("cap", typeof(string)));
	tf24sediinail.Columns.Add( new DataColumn("citta", typeof(string)));
	tf24sediinail.Columns.Add( new DataColumn("provincia", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	Tables.Add(tf24sediinail);
	tf24sediinail.PrimaryKey =  new DataColumn[]{tf24sediinail.Columns["codicesede"]};


	//////////////////// FISCALTAXREGION /////////////////////////////////
	var tfiscaltaxregion= new DataTable("fiscaltaxregion");
	C= new DataColumn("idfiscaltaxregion", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	tfiscaltaxregion.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tfiscaltaxregion.Columns.Add( new DataColumn("idregion", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	Tables.Add(tfiscaltaxregion);
	tfiscaltaxregion.PrimaryKey =  new DataColumn[]{tfiscaltaxregion.Columns["idfiscaltaxregion"]};


	//////////////////// F24SEDIALTRIENTI /////////////////////////////////
	var tf24sedialtrienti= new DataTable("f24sedialtrienti");
	C= new DataColumn("idaltrienti", typeof(string));
	C.AllowDBNull=false;
	tf24sedialtrienti.Columns.Add(C);
	C= new DataColumn("codicesede", typeof(string));
	C.AllowDBNull=false;
	tf24sedialtrienti.Columns.Add(C);
	tf24sedialtrienti.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tf24sedialtrienti.Columns.Add( new DataColumn("active", typeof(string)));
	tf24sedialtrienti.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tf24sedialtrienti.Columns.Add( new DataColumn("cu", typeof(string)));
	tf24sedialtrienti.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tf24sedialtrienti.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tf24sedialtrienti);
	tf24sedialtrienti.PrimaryKey =  new DataColumn[]{tf24sedialtrienti.Columns["idaltrienti"], tf24sedialtrienti.Columns["codicesede"]};


	//////////////////// PROVINCIA /////////////////////////////////
	var tPROVINCIA= new DataTable("PROVINCIA");
	C= new DataColumn("IDPROVINCIA", typeof(int));
	C.AllowDBNull=false;
	tPROVINCIA.Columns.Add(C);
	tPROVINCIA.Columns.Add( new DataColumn("IDREGIONE", typeof(int)));
	tPROVINCIA.Columns.Add( new DataColumn("DIZIONEPROVINCIA", typeof(string)));
	tPROVINCIA.Columns.Add( new DataColumn("CODISTATPROVINCIA", typeof(string)));
	tPROVINCIA.Columns.Add( new DataColumn("SIGLAPROV", typeof(string)));
	tPROVINCIA.Columns.Add( new DataColumn("CODISTATCAPOLPROV", typeof(string)));
	Tables.Add(tPROVINCIA);

	//////////////////// F24TRIBUTI /////////////////////////////////
	var tf24tributi= new DataTable("f24tributi");
	C= new DataColumn("codicetributo", typeof(string));
	C.AllowDBNull=false;
	tf24tributi.Columns.Add(C);
	tf24tributi.Columns.Add( new DataColumn("modalitadiutilizzo", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("tipotributo", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("riferimento_a", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("riferimento_b", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("flagcodiceufficio", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("codiceatto", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("idf24sezione", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("idaltrienti", typeof(string)));
	tf24tributi.Columns.Add( new DataColumn("attivo", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24tributi.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24tributi.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24tributi.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24tributi.Columns.Add(C);
	tf24tributi.Columns.Add( new DataColumn("codicetributoep", typeof(string)));
	Tables.Add(tf24tributi);
	tf24tributi.PrimaryKey =  new DataColumn[]{tf24tributi.Columns["codicetributo"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{f24sezione.Columns["idf24sezione"]};
	var cChild = new []{f24ordinariodetail.Columns["idf24sezione"]};
	Relations.Add(new DataRelation("f24sezione_f24ordinariodetail",cPar,cChild,false));

	cPar = new []{f24entilocali.Columns["identelocale"]};
	cChild = new []{f24ordinariodetail.Columns["identelocale"]};
	Relations.Add(new DataRelation("f24entilocali_f24ordinariodetail",cPar,cChild,false));

	cPar = new []{f24sediinail.Columns["codicesede"]};
	cChild = new []{f24ordinariodetail.Columns["codicesedeinail"]};
	Relations.Add(new DataRelation("f24sediinail_f24ordinariodetail",cPar,cChild,false));

	cPar = new []{fiscaltaxregion.Columns["idfiscaltaxregion"]};
	cChild = new []{f24ordinariodetail.Columns["idfiscaltaxregion"]};
	Relations.Add(new DataRelation("fiscaltaxregion_f24ordinariodetail",cPar,cChild,false));

	cPar = new []{PROVINCIA.Columns["SIGLAPROV"]};
	cChild = new []{f24ordinariodetail.Columns["idprovincia"]};
	Relations.Add(new DataRelation("PROVINCIA_f24ordinariodetail",cPar,cChild,false));

	cPar = new []{f24tributi.Columns["codicetributo"]};
	cChild = new []{f24ordinariodetail.Columns["codicetributo"]};
	Relations.Add(new DataRelation("f24tributi_f24ordinariodetail",cPar,cChild,false));

	cPar = new []{f24altrientiprevidenzialiassicurativi.Columns["idaltrienti"]};
	cChild = new []{f24ordinariodetail.Columns["idaltrienti"]};
	Relations.Add(new DataRelation("f24altrientiprevidenzialiassicurativi_f24ordinariodetail",cPar,cChild,false));

	cPar = new []{f24sedialtrienti.Columns["codicesede"]};
	cChild = new []{f24ordinariodetail.Columns["idcodicesedealtrienti"]};
	Relations.Add(new DataRelation("f24sedialtrienti_f24ordinariodetail",cPar,cChild,false));

	#endregion

}
}
}
