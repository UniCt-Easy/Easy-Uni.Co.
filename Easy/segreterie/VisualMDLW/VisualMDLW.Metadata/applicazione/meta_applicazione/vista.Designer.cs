
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace meta_applicazione {
public class applicazioneRow: MetaRow  {
	public applicazioneRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Cartella del Backend
	///</summary>
	public String backend{ 
		get {if (this["backend"]==DBNull.Value)return null; return  (String)this["backend"];}
		set {if (value==null) this["backend"]= DBNull.Value; else this["backend"]= value;}
	}
	public object backendValue { 
		get{ return this["backend"];}
		set {if (value==null|| value==DBNull.Value) this["backend"]= DBNull.Value; else this["backend"]= value;}
	}
	public String backendOriginal { 
		get {if (this["backend",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["backend",DataRowVersion.Original];}
	}
	///<summary>
	///Cartella del Client
	///</summary>
	public String client{ 
		get {if (this["client"]==DBNull.Value)return null; return  (String)this["client"];}
		set {if (value==null) this["client"]= DBNull.Value; else this["client"]= value;}
	}
	public object clientValue { 
		get{ return this["client"];}
		set {if (value==null|| value==DBNull.Value) this["client"]= DBNull.Value; else this["client"]= value;}
	}
	public String clientOriginal { 
		get {if (this["client",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["client",DataRowVersion.Original];}
	}
	///<summary>
	///Cartella di metadatalibrary.dll
	///</summary>
	public String dllcorefolder{ 
		get {if (this["dllcorefolder"]==DBNull.Value)return null; return  (String)this["dllcorefolder"];}
		set {if (value==null) this["dllcorefolder"]= DBNull.Value; else this["dllcorefolder"]= value;}
	}
	public object dllcorefolderValue { 
		get{ return this["dllcorefolder"];}
		set {if (value==null|| value==DBNull.Value) this["dllcorefolder"]= DBNull.Value; else this["dllcorefolder"]= value;}
	}
	public String dllcorefolderOriginal { 
		get {if (this["dllcorefolder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dllcorefolder",DataRowVersion.Original];}
	}
	///<summary>
	///Cartella di cpoia delle DLL in Post Build
	///</summary>
	public String dlloutputfolder{ 
		get {if (this["dlloutputfolder"]==DBNull.Value)return null; return  (String)this["dlloutputfolder"];}
		set {if (value==null) this["dlloutputfolder"]= DBNull.Value; else this["dlloutputfolder"]= value;}
	}
	public object dlloutputfolderValue { 
		get{ return this["dlloutputfolder"];}
		set {if (value==null|| value==DBNull.Value) this["dlloutputfolder"]= DBNull.Value; else this["dlloutputfolder"]= value;}
	}
	public String dlloutputfolderOriginal { 
		get {if (this["dlloutputfolder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dlloutputfolder",DataRowVersion.Original];}
	}
	///<summary>
	///Identificativo
	///</summary>
	public Int32? idapplicazione{ 
		get {if (this["idapplicazione"]==DBNull.Value)return null; return  (Int32?)this["idapplicazione"];}
		set {if (value==null) this["idapplicazione"]= DBNull.Value; else this["idapplicazione"]= value;}
	}
	public object idapplicazioneValue { 
		get{ return this["idapplicazione"];}
		set {if (value==null|| value==DBNull.Value) this["idapplicazione"]= DBNull.Value; else this["idapplicazione"]= value;}
	}
	public Int32? idapplicazioneOriginal { 
		get {if (this["idapplicazione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapplicazione",DataRowVersion.Original];}
	}
	///<summary>
	///Identificativo della radice del men√π
	///</summary>
	public Int32? idmenuweb{ 
		get {if (this["idmenuweb"]==DBNull.Value)return null; return  (Int32?)this["idmenuweb"];}
		set {if (value==null) this["idmenuweb"]= DBNull.Value; else this["idmenuweb"]= value;}
	}
	public object idmenuwebValue { 
		get{ return this["idmenuweb"];}
		set {if (value==null|| value==DBNull.Value) this["idmenuweb"]= DBNull.Value; else this["idmenuweb"]= value;}
	}
	public Int32? idmenuwebOriginal { 
		get {if (this["idmenuweb",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmenuweb",DataRowVersion.Original];}
	}
	///<summary>
	///Cartella dei meta_dati
	///</summary>
	public String metadati{ 
		get {if (this["metadati"]==DBNull.Value)return null; return  (String)this["metadati"];}
		set {if (value==null) this["metadati"]= DBNull.Value; else this["metadati"]= value;}
	}
	public object metadatiValue { 
		get{ return this["metadati"];}
		set {if (value==null|| value==DBNull.Value) this["metadati"]= DBNull.Value; else this["metadati"]= value;}
	}
	public String metadatiOriginal { 
		get {if (this["metadati",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["metadati",DataRowVersion.Original];}
	}
	///<summary>
	///Cartella delle meta_page
	///</summary>
	public String metapagefolder{ 
		get {if (this["metapagefolder"]==DBNull.Value)return null; return  (String)this["metapagefolder"];}
		set {if (value==null) this["metapagefolder"]= DBNull.Value; else this["metapagefolder"]= value;}
	}
	public object metapagefolderValue { 
		get{ return this["metapagefolder"];}
		set {if (value==null|| value==DBNull.Value) this["metapagefolder"]= DBNull.Value; else this["metapagefolder"]= value;}
	}
	public String metapagefolderOriginal { 
		get {if (this["metapagefolder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["metapagefolder",DataRowVersion.Original];}
	}
	public String scriptFolder{ 
		get {if (this["scriptFolder"]==DBNull.Value)return null; return  (String)this["scriptFolder"];}
		set {if (value==null) this["scriptFolder"]= DBNull.Value; else this["scriptFolder"]= value;}
	}
	public object scriptFolderValue { 
		get{ return this["scriptFolder"];}
		set {if (value==null|| value==DBNull.Value) this["scriptFolder"]= DBNull.Value; else this["scriptFolder"]= value;}
	}
	public String scriptFolderOriginal { 
		get {if (this["scriptFolder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["scriptFolder",DataRowVersion.Original];}
	}
	///<summary>
	///File della solution
	///</summary>
	public String solutionfile{ 
		get {if (this["solutionfile"]==DBNull.Value)return null; return  (String)this["solutionfile"];}
		set {if (value==null) this["solutionfile"]= DBNull.Value; else this["solutionfile"]= value;}
	}
	public object solutionfileValue { 
		get{ return this["solutionfile"];}
		set {if (value==null|| value==DBNull.Value) this["solutionfile"]= DBNull.Value; else this["solutionfile"]= value;}
	}
	public String solutionfileOriginal { 
		get {if (this["solutionfile",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["solutionfile",DataRowVersion.Original];}
	}
	public String testFolder{ 
		get {if (this["testFolder"]==DBNull.Value)return null; return  (String)this["testFolder"];}
		set {if (value==null) this["testFolder"]= DBNull.Value; else this["testFolder"]= value;}
	}
	public object testFolderValue { 
		get{ return this["testFolder"];}
		set {if (value==null|| value==DBNull.Value) this["testFolder"]= DBNull.Value; else this["testFolder"]= value;}
	}
	public String testFolderOriginal { 
		get {if (this["testFolder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["testFolder",DataRowVersion.Original];}
	}
	///<summary>
	///Nome
	///</summary>
	public String title{ 
		get {if (this["title"]==DBNull.Value)return null; return  (String)this["title"];}
		set {if (value==null) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {if (value==null|| value==DBNull.Value) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public String titleOriginal { 
		get {if (this["title",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title",DataRowVersion.Original];}
	}
	#endregion

}
public class applicazioneTable : MetaTableBase<applicazioneRow> {
	public applicazioneTable() : base("applicazione"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"backend",createColumn("backend",typeof(string),true,false)},
			{"client",createColumn("client",typeof(string),true,false)},
			{"dllcorefolder",createColumn("dllcorefolder",typeof(string),true,false)},
			{"dlloutputfolder",createColumn("dlloutputfolder",typeof(string),true,false)},
			{"idapplicazione",createColumn("idapplicazione",typeof(int),false,false)},
			{"idmenuweb",createColumn("idmenuweb",typeof(int),true,false)},
			{"metadati",createColumn("metadati",typeof(string),true,false)},
			{"metapagefolder",createColumn("metapagefolder",typeof(string),true,false)},
			{"scriptFolder",createColumn("scriptFolder",typeof(string),true,false)},
			{"solutionfile",createColumn("solutionfile",typeof(string),true,false)},
			{"testFolder",createColumn("testFolder",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
