
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
using System.Collections.Generic;
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_f24ordinariodetail {
public class f24ordinariodetailRow: MetaRow  {
	public f24ordinariodetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idf24ordinario{ 
		get {return  (Int32)this["idf24ordinario"];}
		set {this["idf24ordinario"]= value;}
	}
	public object idf24ordinarioValue { 
		get{ return this["idf24ordinario"];}
		set {this["idf24ordinario"]= value;}
	}
	public Int32 idf24ordinarioOriginal { 
		get {return  (Int32)this["idf24ordinario",DataRowVersion.Original];}
	}
	public Int32 iddetail{ 
		get {return  (Int32)this["iddetail"];}
		set {this["iddetail"]= value;}
	}
	public object iddetailValue { 
		get{ return this["iddetail"];}
		set {this["iddetail"]= value;}
	}
	public Int32 iddetailOriginal { 
		get {return  (Int32)this["iddetail",DataRowVersion.Original];}
	}
	public String codicetributo{ 
		get {return  (String)this["codicetributo"];}
		set {this["codicetributo"]= value;}
	}
	public object codicetributoValue { 
		get{ return this["codicetributo"];}
		set {this["codicetributo"]= value;}
	}
	public String codicetributoOriginal { 
		get {return  (String)this["codicetributo",DataRowVersion.Original];}
	}
	public String codiceufficio{ 
		get {if (this["codiceufficio"]==DBNull.Value)return null; return  (String)this["codiceufficio"];}
		set {if (value==null) this["codiceufficio"]= DBNull.Value; else this["codiceufficio"]= value;}
	}
	public object codiceufficioValue { 
		get{ return this["codiceufficio"];}
		set {if (value==null|| value==DBNull.Value) this["codiceufficio"]= DBNull.Value; else this["codiceufficio"]= value;}
	}
	public String codiceufficioOriginal { 
		get {if (this["codiceufficio",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceufficio",DataRowVersion.Original];}
	}
	public String codiceatto{ 
		get {if (this["codiceatto"]==DBNull.Value)return null; return  (String)this["codiceatto"];}
		set {if (value==null) this["codiceatto"]= DBNull.Value; else this["codiceatto"]= value;}
	}
	public object codiceattoValue { 
		get{ return this["codiceatto"];}
		set {if (value==null|| value==DBNull.Value) this["codiceatto"]= DBNull.Value; else this["codiceatto"]= value;}
	}
	public String codiceattoOriginal { 
		get {if (this["codiceatto",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceatto",DataRowVersion.Original];}
	}
	public String riferimentoa{ 
		get {if (this["riferimentoa"]==DBNull.Value)return null; return  (String)this["riferimentoa"];}
		set {if (value==null) this["riferimentoa"]= DBNull.Value; else this["riferimentoa"]= value;}
	}
	public object riferimentoaValue { 
		get{ return this["riferimentoa"];}
		set {if (value==null|| value==DBNull.Value) this["riferimentoa"]= DBNull.Value; else this["riferimentoa"]= value;}
	}
	public String riferimentoaOriginal { 
		get {if (this["riferimentoa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["riferimentoa",DataRowVersion.Original];}
	}
	public String riferimentob{ 
		get {if (this["riferimentob"]==DBNull.Value)return null; return  (String)this["riferimentob"];}
		set {if (value==null) this["riferimentob"]= DBNull.Value; else this["riferimentob"]= value;}
	}
	public object riferimentobValue { 
		get{ return this["riferimentob"];}
		set {if (value==null|| value==DBNull.Value) this["riferimentob"]= DBNull.Value; else this["riferimentob"]= value;}
	}
	public String riferimentobOriginal { 
		get {if (this["riferimentob",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["riferimentob",DataRowVersion.Original];}
	}
	public Decimal? importoadebito{ 
		get {if (this["importoadebito"]==DBNull.Value)return null; return  (Decimal?)this["importoadebito"];}
		set {if (value==null) this["importoadebito"]= DBNull.Value; else this["importoadebito"]= value;}
	}
	public object importoadebitoValue { 
		get{ return this["importoadebito"];}
		set {if (value==null|| value==DBNull.Value) this["importoadebito"]= DBNull.Value; else this["importoadebito"]= value;}
	}
	public Decimal? importoadebitoOriginal { 
		get {if (this["importoadebito",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["importoadebito",DataRowVersion.Original];}
	}
	public Decimal? importoacredito{ 
		get {if (this["importoacredito"]==DBNull.Value)return null; return  (Decimal?)this["importoacredito"];}
		set {if (value==null) this["importoacredito"]= DBNull.Value; else this["importoacredito"]= value;}
	}
	public object importoacreditoValue { 
		get{ return this["importoacredito"];}
		set {if (value==null|| value==DBNull.Value) this["importoacredito"]= DBNull.Value; else this["importoacredito"]= value;}
	}
	public Decimal? importoacreditoOriginal { 
		get {if (this["importoacredito",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["importoacredito",DataRowVersion.Original];}
	}
	public String idfiscaltaxregion{ 
		get {if (this["idfiscaltaxregion"]==DBNull.Value)return null; return  (String)this["idfiscaltaxregion"];}
		set {if (value==null) this["idfiscaltaxregion"]= DBNull.Value; else this["idfiscaltaxregion"]= value;}
	}
	public object idfiscaltaxregionValue { 
		get{ return this["idfiscaltaxregion"];}
		set {if (value==null|| value==DBNull.Value) this["idfiscaltaxregion"]= DBNull.Value; else this["idfiscaltaxregion"]= value;}
	}
	public String idfiscaltaxregionOriginal { 
		get {if (this["idfiscaltaxregion",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfiscaltaxregion",DataRowVersion.Original];}
	}
	public String ravvedimentooperoso{ 
		get {if (this["ravvedimentooperoso"]==DBNull.Value)return null; return  (String)this["ravvedimentooperoso"];}
		set {if (value==null) this["ravvedimentooperoso"]= DBNull.Value; else this["ravvedimentooperoso"]= value;}
	}
	public object ravvedimentooperosoValue { 
		get{ return this["ravvedimentooperoso"];}
		set {if (value==null|| value==DBNull.Value) this["ravvedimentooperoso"]= DBNull.Value; else this["ravvedimentooperoso"]= value;}
	}
	public String ravvedimentooperosoOriginal { 
		get {if (this["ravvedimentooperoso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ravvedimentooperoso",DataRowVersion.Original];}
	}
	public String immobilivariati{ 
		get {if (this["immobilivariati"]==DBNull.Value)return null; return  (String)this["immobilivariati"];}
		set {if (value==null) this["immobilivariati"]= DBNull.Value; else this["immobilivariati"]= value;}
	}
	public object immobilivariatiValue { 
		get{ return this["immobilivariati"];}
		set {if (value==null|| value==DBNull.Value) this["immobilivariati"]= DBNull.Value; else this["immobilivariati"]= value;}
	}
	public String immobilivariatiOriginal { 
		get {if (this["immobilivariati",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["immobilivariati",DataRowVersion.Original];}
	}
	public String accontosaldo{ 
		get {if (this["accontosaldo"]==DBNull.Value)return null; return  (String)this["accontosaldo"];}
		set {if (value==null) this["accontosaldo"]= DBNull.Value; else this["accontosaldo"]= value;}
	}
	public object accontosaldoValue { 
		get{ return this["accontosaldo"];}
		set {if (value==null|| value==DBNull.Value) this["accontosaldo"]= DBNull.Value; else this["accontosaldo"]= value;}
	}
	public String accontosaldoOriginal { 
		get {if (this["accontosaldo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["accontosaldo",DataRowVersion.Original];}
	}
	public Int32? numeroimmobili{ 
		get {if (this["numeroimmobili"]==DBNull.Value)return null; return  (Int32?)this["numeroimmobili"];}
		set {if (value==null) this["numeroimmobili"]= DBNull.Value; else this["numeroimmobili"]= value;}
	}
	public object numeroimmobiliValue { 
		get{ return this["numeroimmobili"];}
		set {if (value==null|| value==DBNull.Value) this["numeroimmobili"]= DBNull.Value; else this["numeroimmobili"]= value;}
	}
	public Int32? numeroimmobiliOriginal { 
		get {if (this["numeroimmobili",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["numeroimmobili",DataRowVersion.Original];}
	}
	public Decimal? detrazioneabitazione{ 
		get {if (this["detrazioneabitazione"]==DBNull.Value)return null; return  (Decimal?)this["detrazioneabitazione"];}
		set {if (value==null) this["detrazioneabitazione"]= DBNull.Value; else this["detrazioneabitazione"]= value;}
	}
	public object detrazioneabitazioneValue { 
		get{ return this["detrazioneabitazione"];}
		set {if (value==null|| value==DBNull.Value) this["detrazioneabitazione"]= DBNull.Value; else this["detrazioneabitazione"]= value;}
	}
	public Decimal? detrazioneabitazioneOriginal { 
		get {if (this["detrazioneabitazione",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["detrazioneabitazione",DataRowVersion.Original];}
	}
	public String idaltrienti{ 
		get {if (this["idaltrienti"]==DBNull.Value)return null; return  (String)this["idaltrienti"];}
		set {if (value==null) this["idaltrienti"]= DBNull.Value; else this["idaltrienti"]= value;}
	}
	public object idaltrientiValue { 
		get{ return this["idaltrienti"];}
		set {if (value==null|| value==DBNull.Value) this["idaltrienti"]= DBNull.Value; else this["idaltrienti"]= value;}
	}
	public String idaltrientiOriginal { 
		get {if (this["idaltrienti",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaltrienti",DataRowVersion.Original];}
	}
	public String idcodicesedealtrienti{ 
		get {if (this["idcodicesedealtrienti"]==DBNull.Value)return null; return  (String)this["idcodicesedealtrienti"];}
		set {if (value==null) this["idcodicesedealtrienti"]= DBNull.Value; else this["idcodicesedealtrienti"]= value;}
	}
	public object idcodicesedealtrientiValue { 
		get{ return this["idcodicesedealtrienti"];}
		set {if (value==null|| value==DBNull.Value) this["idcodicesedealtrienti"]= DBNull.Value; else this["idcodicesedealtrienti"]= value;}
	}
	public String idcodicesedealtrientiOriginal { 
		get {if (this["idcodicesedealtrienti",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idcodicesedealtrienti",DataRowVersion.Original];}
	}
	public String codiceposizione{ 
		get {if (this["codiceposizione"]==DBNull.Value)return null; return  (String)this["codiceposizione"];}
		set {if (value==null) this["codiceposizione"]= DBNull.Value; else this["codiceposizione"]= value;}
	}
	public object codiceposizioneValue { 
		get{ return this["codiceposizione"];}
		set {if (value==null|| value==DBNull.Value) this["codiceposizione"]= DBNull.Value; else this["codiceposizione"]= value;}
	}
	public String codiceposizioneOriginal { 
		get {if (this["codiceposizione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceposizione",DataRowVersion.Original];}
	}
	public DateTime ct{ 
		get {return  (DateTime)this["ct"];}
		set {this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {this["ct"]= value;}
	}
	public DateTime ctOriginal { 
		get {return  (DateTime)this["ct",DataRowVersion.Original];}
	}
	public String cu{ 
		get {return  (String)this["cu"];}
		set {this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {this["cu"]= value;}
	}
	public String cuOriginal { 
		get {return  (String)this["cu",DataRowVersion.Original];}
	}
	public DateTime lt{ 
		get {return  (DateTime)this["lt"];}
		set {this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {this["lt"]= value;}
	}
	public DateTime ltOriginal { 
		get {return  (DateTime)this["lt",DataRowVersion.Original];}
	}
	public String lu{ 
		get {return  (String)this["lu"];}
		set {this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {this["lu"]= value;}
	}
	public String luOriginal { 
		get {return  (String)this["lu",DataRowVersion.Original];}
	}
	public String idprovincia{ 
		get {if (this["idprovincia"]==DBNull.Value)return null; return  (String)this["idprovincia"];}
		set {if (value==null) this["idprovincia"]= DBNull.Value; else this["idprovincia"]= value;}
	}
	public object idprovinciaValue { 
		get{ return this["idprovincia"];}
		set {if (value==null|| value==DBNull.Value) this["idprovincia"]= DBNull.Value; else this["idprovincia"]= value;}
	}
	public String idprovinciaOriginal { 
		get {if (this["idprovincia",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idprovincia",DataRowVersion.Original];}
	}
	public String identificativooperazione{ 
		get {if (this["identificativooperazione"]==DBNull.Value)return null; return  (String)this["identificativooperazione"];}
		set {if (value==null) this["identificativooperazione"]= DBNull.Value; else this["identificativooperazione"]= value;}
	}
	public object identificativooperazioneValue { 
		get{ return this["identificativooperazione"];}
		set {if (value==null|| value==DBNull.Value) this["identificativooperazione"]= DBNull.Value; else this["identificativooperazione"]= value;}
	}
	public String identificativooperazioneOriginal { 
		get {if (this["identificativooperazione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["identificativooperazione",DataRowVersion.Original];}
	}
	public Int32? identelocale{ 
		get {if (this["identelocale"]==DBNull.Value)return null; return  (Int32?)this["identelocale"];}
		set {if (value==null) this["identelocale"]= DBNull.Value; else this["identelocale"]= value;}
	}
	public object identelocaleValue { 
		get{ return this["identelocale"];}
		set {if (value==null|| value==DBNull.Value) this["identelocale"]= DBNull.Value; else this["identelocale"]= value;}
	}
	public Int32? identelocaleOriginal { 
		get {if (this["identelocale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["identelocale",DataRowVersion.Original];}
	}
	public String catastalecomune{ 
		get {if (this["catastalecomune"]==DBNull.Value)return null; return  (String)this["catastalecomune"];}
		set {if (value==null) this["catastalecomune"]= DBNull.Value; else this["catastalecomune"]= value;}
	}
	public object catastalecomuneValue { 
		get{ return this["catastalecomune"];}
		set {if (value==null|| value==DBNull.Value) this["catastalecomune"]= DBNull.Value; else this["catastalecomune"]= value;}
	}
	public String catastalecomuneOriginal { 
		get {if (this["catastalecomune",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["catastalecomune",DataRowVersion.Original];}
	}
	public String idf24sezione{ 
		get {return  (String)this["idf24sezione"];}
		set {this["idf24sezione"]= value;}
	}
	public object idf24sezioneValue { 
		get{ return this["idf24sezione"];}
		set {this["idf24sezione"]= value;}
	}
	public String idf24sezioneOriginal { 
		get {return  (String)this["idf24sezione",DataRowVersion.Original];}
	}
	public String codiceditta{ 
		get {if (this["codiceditta"]==DBNull.Value)return null; return  (String)this["codiceditta"];}
		set {if (value==null) this["codiceditta"]= DBNull.Value; else this["codiceditta"]= value;}
	}
	public object codicedittaValue { 
		get{ return this["codiceditta"];}
		set {if (value==null|| value==DBNull.Value) this["codiceditta"]= DBNull.Value; else this["codiceditta"]= value;}
	}
	public String codicedittaOriginal { 
		get {if (this["codiceditta",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceditta",DataRowVersion.Original];}
	}
	public String cc_codiceditta{ 
		get {if (this["cc_codiceditta"]==DBNull.Value)return null; return  (String)this["cc_codiceditta"];}
		set {if (value==null) this["cc_codiceditta"]= DBNull.Value; else this["cc_codiceditta"]= value;}
	}
	public object cc_codicedittaValue { 
		get{ return this["cc_codiceditta"];}
		set {if (value==null|| value==DBNull.Value) this["cc_codiceditta"]= DBNull.Value; else this["cc_codiceditta"]= value;}
	}
	public String cc_codicedittaOriginal { 
		get {if (this["cc_codiceditta",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cc_codiceditta",DataRowVersion.Original];}
	}
	public String numerodiriferimento{ 
		get {if (this["numerodiriferimento"]==DBNull.Value)return null; return  (String)this["numerodiriferimento"];}
		set {if (value==null) this["numerodiriferimento"]= DBNull.Value; else this["numerodiriferimento"]= value;}
	}
	public object numerodiriferimentoValue { 
		get{ return this["numerodiriferimento"];}
		set {if (value==null|| value==DBNull.Value) this["numerodiriferimento"]= DBNull.Value; else this["numerodiriferimento"]= value;}
	}
	public String numerodiriferimentoOriginal { 
		get {if (this["numerodiriferimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["numerodiriferimento",DataRowVersion.Original];}
	}
	public String causale{ 
		get {if (this["causale"]==DBNull.Value)return null; return  (String)this["causale"];}
		set {if (value==null) this["causale"]= DBNull.Value; else this["causale"]= value;}
	}
	public object causaleValue { 
		get{ return this["causale"];}
		set {if (value==null|| value==DBNull.Value) this["causale"]= DBNull.Value; else this["causale"]= value;}
	}
	public String causaleOriginal { 
		get {if (this["causale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["causale",DataRowVersion.Original];}
	}
	public String codicesedeinail{ 
		get {if (this["codicesedeinail"]==DBNull.Value)return null; return  (String)this["codicesedeinail"];}
		set {if (value==null) this["codicesedeinail"]= DBNull.Value; else this["codicesedeinail"]= value;}
	}
	public object codicesedeinailValue { 
		get{ return this["codicesedeinail"];}
		set {if (value==null|| value==DBNull.Value) this["codicesedeinail"]= DBNull.Value; else this["codicesedeinail"]= value;}
	}
	public String codicesedeinailOriginal { 
		get {if (this["codicesedeinail",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicesedeinail",DataRowVersion.Original];}
	}
	#endregion

}
public class f24ordinariodetailTable : MetaTableBase<f24ordinariodetailRow> {
	public f24ordinariodetailTable() : base("f24ordinariodetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idf24ordinario",createColumn("idf24ordinario",typeof(int),false,false)},
			{"iddetail",createColumn("iddetail",typeof(int),false,false)},
			{"codicetributo",createColumn("codicetributo",typeof(string),false,false)},
			{"codiceufficio",createColumn("codiceufficio",typeof(string),true,false)},
			{"codiceatto",createColumn("codiceatto",typeof(string),true,false)},
			{"riferimentoa",createColumn("riferimentoa",typeof(string),true,false)},
			{"riferimentob",createColumn("riferimentob",typeof(string),true,false)},
			{"importoadebito",createColumn("importoadebito",typeof(decimal),true,false)},
			{"importoacredito",createColumn("importoacredito",typeof(decimal),true,false)},
			{"idfiscaltaxregion",createColumn("idfiscaltaxregion",typeof(string),true,false)},
			{"ravvedimentooperoso",createColumn("ravvedimentooperoso",typeof(string),true,false)},
			{"immobilivariati",createColumn("immobilivariati",typeof(string),true,false)},
			{"accontosaldo",createColumn("accontosaldo",typeof(string),true,false)},
			{"numeroimmobili",createColumn("numeroimmobili",typeof(int),true,false)},
			{"detrazioneabitazione",createColumn("detrazioneabitazione",typeof(decimal),true,false)},
			{"idaltrienti",createColumn("idaltrienti",typeof(string),true,false)},
			{"idcodicesedealtrienti",createColumn("idcodicesedealtrienti",typeof(string),true,false)},
			{"codiceposizione",createColumn("codiceposizione",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"idprovincia",createColumn("idprovincia",typeof(string),true,false)},
			{"identificativooperazione",createColumn("identificativooperazione",typeof(string),true,false)},
			{"identelocale",createColumn("identelocale",typeof(int),true,false)},
			{"catastalecomune",createColumn("catastalecomune",typeof(string),true,false)},
			{"idf24sezione",createColumn("idf24sezione",typeof(string),false,false)},
			{"codiceditta",createColumn("codiceditta",typeof(string),true,false)},
			{"cc_codiceditta",createColumn("cc_codiceditta",typeof(string),true,false)},
			{"numerodiriferimento",createColumn("numerodiriferimento",typeof(string),true,false)},
			{"causale",createColumn("causale",typeof(string),true,false)},
			{"codicesedeinail",createColumn("codicesedeinail",typeof(string),true,false)},
		};
	}
}
}
