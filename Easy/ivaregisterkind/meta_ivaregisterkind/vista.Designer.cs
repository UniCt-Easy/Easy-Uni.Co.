
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
namespace meta_ivaregisterkind {
public class ivaregisterkindRow: MetaRow  {
	public ivaregisterkindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///data creazione
	///</summary>
	public DateTime? ct{ 
		get {if (this["ct"]==DBNull.Value)return null; return  (DateTime?)this["ct"];}
		set {if (value==null) this["ct"]= DBNull.Value; else this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {if (value==null|| value==DBNull.Value) this["ct"]= DBNull.Value; else this["ct"]= value;}
	}
	public DateTime? ctOriginal { 
		get {if (this["ct",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["ct",DataRowVersion.Original];}
	}
	///<summary>
	///nome utente creazione
	///</summary>
	public String cu{ 
		get {if (this["cu"]==DBNull.Value)return null; return  (String)this["cu"];}
		set {if (value==null) this["cu"]= DBNull.Value; else this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {if (value==null|| value==DBNull.Value) this["cu"]= DBNull.Value; else this["cu"]= value;}
	}
	public String cuOriginal { 
		get {if (this["cu",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cu",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
	///</summary>
	public String description{ 
		get {if (this["description"]==DBNull.Value)return null; return  (String)this["description"];}
		set {if (value==null) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {if (value==null|| value==DBNull.Value) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {if (this["description",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["description",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
	public DateTime? lt{ 
		get {if (this["lt"]==DBNull.Value)return null; return  (DateTime?)this["lt"];}
		set {if (value==null) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {if (value==null|| value==DBNull.Value) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public DateTime? ltOriginal { 
		get {if (this["lt",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lt",DataRowVersion.Original];}
	}
	///<summary>
	///nome ultimo utente modifica
	///</summary>
	public String lu{ 
		get {if (this["lu"]==DBNull.Value)return null; return  (String)this["lu"];}
		set {if (value==null) this["lu"]= DBNull.Value; else this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {if (value==null|| value==DBNull.Value) this["lu"]= DBNull.Value; else this["lu"]= value;}
	}
	public String luOriginal { 
		get {if (this["lu",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lu",DataRowVersion.Original];}
	}
	///<summary>
	///Classe registro (Acquisti/Vendite/ Protocollo generale)
	///Un tipo documento può essere legato a più registri, ma di norma ad un solo registro che non sia di tipo generale.
	///Le fatture acquisti intracom sono registrate ad un registro di  acquisti ed uno di vendita
	///	 A: Acquisti
	///	 P: Protocollo generale
	///	 V: Vendite
	///</summary>
	public String registerclass{ 
		get {if (this["registerclass"]==DBNull.Value)return null; return  (String)this["registerclass"];}
		set {if (value==null) this["registerclass"]= DBNull.Value; else this["registerclass"]= value;}
	}
	public object registerclassValue { 
		get{ return this["registerclass"];}
		set {if (value==null|| value==DBNull.Value) this["registerclass"]= DBNull.Value; else this["registerclass"]= value;}
	}
	public String registerclassOriginal { 
		get {if (this["registerclass",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["registerclass",DataRowVersion.Original];}
	}
	///<summary>
	///id registro nel consolidamento, ormai non più usato
	///</summary>
	public String idivaregisterkindunified{ 
		get {if (this["idivaregisterkindunified"]==DBNull.Value)return null; return  (String)this["idivaregisterkindunified"];}
		set {if (value==null) this["idivaregisterkindunified"]= DBNull.Value; else this["idivaregisterkindunified"]= value;}
	}
	public object idivaregisterkindunifiedValue { 
		get{ return this["idivaregisterkindunified"];}
		set {if (value==null|| value==DBNull.Value) this["idivaregisterkindunified"]= DBNull.Value; else this["idivaregisterkindunified"]= value;}
	}
	public String idivaregisterkindunifiedOriginal { 
		get {if (this["idivaregisterkindunified",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idivaregisterkindunified",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo attività (1= istituzionale, 2= commerciale, 3=promiscuo, 4=qualsiasi)
	///	 1: istituzionale
	///	 2: commerciale
	///	 3: promiscuo
	///	 4: qualsiasi/non specificato
	///</summary>
	public Int16? flagactivity{ 
		get {if (this["flagactivity"]==DBNull.Value)return null; return  (Int16?)this["flagactivity"];}
		set {if (value==null) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public object flagactivityValue { 
		get{ return this["flagactivity"];}
		set {if (value==null|| value==DBNull.Value) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public Int16? flagactivityOriginal { 
		get {if (this["flagactivity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["flagactivity",DataRowVersion.Original];}
	}
	///<summary>
	///Codice registro, 16TESSERASANITARIA è il codice del registro progetto tessera sanitaria
	///</summary>
	public String codeivaregisterkind{ 
		get {if (this["codeivaregisterkind"]==DBNull.Value)return null; return  (String)this["codeivaregisterkind"];}
		set {if (value==null) this["codeivaregisterkind"]= DBNull.Value; else this["codeivaregisterkind"]= value;}
	}
	public object codeivaregisterkindValue { 
		get{ return this["codeivaregisterkind"];}
		set {if (value==null|| value==DBNull.Value) this["codeivaregisterkind"]= DBNull.Value; else this["codeivaregisterkind"]= value;}
	}
	public String codeivaregisterkindOriginal { 
		get {if (this["codeivaregisterkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeivaregisterkind",DataRowVersion.Original];}
	}
	///<summary>
	///id tipo registro iva (tabella ivaregisterkind) 
	///</summary>
	public Int32? idivaregisterkind{ 
		get {if (this["idivaregisterkind"]==DBNull.Value)return null; return  (Int32?)this["idivaregisterkind"];}
		set {if (value==null) this["idivaregisterkind"]= DBNull.Value; else this["idivaregisterkind"]= value;}
	}
	public object idivaregisterkindValue { 
		get{ return this["idivaregisterkind"];}
		set {if (value==null|| value==DBNull.Value) this["idivaregisterkind"]= DBNull.Value; else this["idivaregisterkind"]= value;}
	}
	public Int32? idivaregisterkindOriginal { 
		get {if (this["idivaregisterkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivaregisterkind",DataRowVersion.Original];}
	}
	///<summary>
	///Corrispettivi
	///</summary>
	public String compensation{ 
		get {if (this["compensation"]==DBNull.Value)return null; return  (String)this["compensation"];}
		set {if (value==null) this["compensation"]= DBNull.Value; else this["compensation"]= value;}
	}
	public object compensationValue { 
		get{ return this["compensation"];}
		set {if (value==null|| value==DBNull.Value) this["compensation"]= DBNull.Value; else this["compensation"]= value;}
	}
	public String compensationOriginal { 
		get {if (this["compensation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["compensation",DataRowVersion.Original];}
	}
	///<summary>
	///Id cassiere (tabella treasurer)
	///</summary>
	public Int32? idtreasurer{ 
		get {if (this["idtreasurer"]==DBNull.Value)return null; return  (Int32?)this["idtreasurer"];}
		set {if (value==null) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public object idtreasurerValue { 
		get{ return this["idtreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public Int32? idtreasurerOriginal { 
		get {if (this["idtreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurer",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Registro IVA
///</summary>
public class ivaregisterkindTable : MetaTableBase<ivaregisterkindRow> {
	public ivaregisterkindTable() : base("ivaregisterkind"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("registerclass")){ 
			defineColumn("registerclass", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idivaregisterkindunified")){ 
			defineColumn("idivaregisterkindunified", typeof(System.String));
		}
		if (definedColums.ContainsKey("flagactivity")){ 
			defineColumn("flagactivity", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("codeivaregisterkind")){ 
			defineColumn("codeivaregisterkind", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idivaregisterkind")){ 
			defineColumn("idivaregisterkind", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("compensation")){ 
			defineColumn("compensation", typeof(System.String));
		}
		if (definedColums.ContainsKey("idtreasurer")){ 
			defineColumn("idtreasurer", typeof(System.Int32));
		}
		#endregion

	}
}
}
