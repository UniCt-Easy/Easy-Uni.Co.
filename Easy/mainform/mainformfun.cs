
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
//using classificazioneestesadettagli;
//using traduzioneclassificazioni;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Reflection;
using metaeasylibrary;


namespace mainform//mainformfunctions//
{
	/// <summary>
	/// Summary description for mainformfun.
	/// </summary>
	public class mainformfun
	{
        

        public mainformfun()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static void CreateOneGigaFile(Form F, SaveFileDialog FileSaver){
			DialogResult Res =  FileSaver.ShowDialog(F);
			if (Res!= DialogResult.OK) return;
			FileStream My =  File.Create(FileSaver.FileName, 1024*1024);
			BinaryWriter WR = new BinaryWriter(My);

			for (int i=0; i<1024; i++){
				char []C = new char[1024*1024];
				WR.Write(C,0,1024*1024);
			}
			WR.Close();
		}
/*
		public static void EditExtClass(Form F, DataAccess MyDataAccess) {
			frmSelectClassificazione frm = new frmSelectClassificazione(MyDataAccess);
			DialogResult res = frm.ShowDialog(F);
			if (res == DialogResult.OK){
				EditExtClass frm2 = new EditExtClass(frm.SelectedCodiceTipoClass, MyDataAccess);
				frm2.ShowDialog(F);
				frm2.Dispose();
			}
			frm.Dispose();
		}

		public static void doTraduzioneClassificazioni(Form F, DataAccess MyDataAccess){
			SelezionaOrigineClass Frm = new SelezionaOrigineClass(MyDataAccess);
			Frm.ShowDialog(F);
			Frm.Dispose(); 
		}
*/

		/// <summary>
		/// Export the MetaData Structure of MetaData DLL into a XML file
		/// </summary>
		public static void WriteMetaDataStructureToXml(Form F, DataAccess MyDataAccess, SaveFileDialog FileSaver){
			if (MyDataAccess==null) return;
			DialogResult Res =  FileSaver.ShowDialog(F);
			if (Res!= DialogResult.OK) return;
			dbstructure DS = MyDataAccess.GetStructure("customobject");
			DataSet DSCopy = DS.Clone();
			DSCopy.Clear();
			dbanalyzer.ExportDataSetToXML(FileSaver.FileName, MyDataAccess, DSCopy, true);
		}

        static string getFormAskDate(Form F, string Label, string Caption) {
            Assembly a = Assembly.Load("ConfigLiveUpdate");
            foreach (Type FormType in a.GetTypes()) {
                if (FormType.Name == "frmAskDate") {
                    ConstructorInfo FormBuilder = FormType.GetConstructor(new System.Type[] {typeof(string),typeof(string) });
                    Form ask = (Form)FormBuilder.Invoke(new object[] {Label,Caption});
                    frmMain.signalCreateForm(ask,null);
                    DialogResult askRes = ask.ShowDialog(F);
                    if (askRes != DialogResult.OK) return null;
                    FieldInfo dataInfo = ask.GetType().GetField("txtData");
                    TextBox tt = (TextBox) dataInfo.GetValue(ask);
                    return tt.Text;
                }
            }
            return null;
        }

        


        /// <summary>
        /// Merge structure and data of a datatable to an XML file
        /// </summary>
        public static void MergeToDataBase(Form F, DataAccess MyDataAccess, 
				OpenFileDialog FilePicker,
			SaveFileDialog FileSaver){
			if (MyDataAccess==null) return;
			DialogResult Res =  FilePicker.ShowDialog(F);
			if (Res!= DialogResult.OK) return;

			DataSet DS;
			bool res = dbanalyzer.ImportDataSetFromXML(FilePicker.FileName, 
				MyDataAccess, out DS);

            string tablename = getFormAskDate(F,"Nome tabella da esportare","Merge to XML");
            if (tablename==null)return;

			DataTable T = MyDataAccess.CreateTableByName(tablename,null);
			if (T.Columns.Count==0){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Tabella non esistente.");
				return;
			}
            MyDataAccess.AddExtendedProperty(T);

			if (MetaFactory.factory.getSingleton<IMessageShower>().Show(F,"Esporto anche il contenuto della tabella?",
				"Conferma",
				MessageBoxButtons.YesNo)==DialogResult.Yes){
				string editedfilter = getFormAskDate(F,"Filtro SQL da applicare", "Parametri Import");
                if (editedfilter==null)return;
			    
                string filter = null;
				if (editedfilter!="") filter=editedfilter;

				DataAccess.RUN_SELECT_INTO_TABLE(MyDataAccess,T,null,filter,null,true);				
			}
			DS.Merge(T);

			DialogResult Res2 =  FileSaver.ShowDialog(F);
			if (Res2!= DialogResult.OK) return;

			dbanalyzer.ExportDataSetToXML(FileSaver.FileName, MyDataAccess,
				DS,false);
		}


		/// <summary>
		/// Write the structure of ALL tables in the database (all tables and columns)
		/// </summary>
		public static void WriteEntireDBStructureToXML(Form F, DataAccess MyDataAccess, SaveFileDialog FileSaver){
			if (MyDataAccess==null) return;
			DialogResult Res =  FileSaver.ShowDialog(F);
			if (Res!= DialogResult.OK) return;
			DataSet DS= dbanalyzer.GetOverallDataSet(MyDataAccess);
			dbanalyzer.ExportDataSetToXML(FileSaver.FileName, MyDataAccess, DS, true);			
		}

		/// <summary>
		/// Gets the structure of ALL tables of a database and applies it to current DB
		/// </summary>
		public static void ReadEntireDBStructureFromXML(Form F, DataAccess MyDataAccess,OpenFileDialog FilePicker){
			if (MyDataAccess==null) return;
			DialogResult Res =  FilePicker.ShowDialog(F);
			if (Res!= DialogResult.OK) return;

			DataSet DS;
			bool res = dbanalyzer.ImportDataSetFromXML(FilePicker.FileName, 
				MyDataAccess, out DS);			
			if (res){
				dbanalyzer.WriteDataSetToDB(DS, MyDataAccess, false, true, null);
			}		

		}

		/// <summary>
		/// Reads MetaData Info (objects, lists, forms, views, etc. from DB)
		/// </summary>
		public static void ImportStructureFromDB(Form F, DataAccess MyDataAccess, 
						OpenFileDialog FilePicker){
			if (MyDataAccess==null) return;
			DialogResult Res =  FilePicker.ShowDialog(F);
			if (Res!= DialogResult.OK) return;

			
            string editedfilter = getFormAskDate(F, "Filtro SQL da applicare", "Parametri Import");
            if (editedfilter == null) return;
			
			string filter = null;
			if (editedfilter!="") filter=editedfilter;

			DataSet DS;
			bool res = dbanalyzer.ImportDataSetFromXML(FilePicker.FileName, 
				MyDataAccess, out DS);
			DS.Tables["columntypes"].Clear();
			if (res){
				dbanalyzer.WriteDataSetToDB(DS, MyDataAccess, false, true, filter);
			}		
		}

		/*
		/// <summary>
		/// Export Structure and Info (lists, forms, views, etc) of all MetaData to DB 
		/// </summary>
		public static void ExportStructureToDB(Form F, DataAccess MyDataAccess, SaveFileDialog FileSaver){
			if (MyDataAccess==null) return;
			DialogResult Res =  FileSaver.ShowDialog(F);
			if (Res!= DialogResult.OK) return;

			frmAskDate Ask = new frmAskDate("Filtro SQL da applicare","Parametri Export");
			DialogResult AskRes = Ask.ShowDialog(F);
			if (AskRes != DialogResult.OK) return;
			string editedfilter = Ask.txtData.Text.ToString();
			
			string filter = null;
			if (editedfilter!="") filter=editedfilter;
			
			dbstructure DS = MyDataAccess.GetEntireStructure(filter);

			DialogResult ColumnSave = MetaFactory.factory.getSingleton<IMessageShower>().Show("Salvo anche la tabella columntypes?",
				"Conferma",
				MessageBoxButtons.YesNo);

			if (ColumnSave== DialogResult.No) DS.Tables["columntypes"].Clear();
			
			dbanalyzer.ExportDataSetToXML(FileSaver.FileName, MyDataAccess, DS, false);			

		}
		
		*/
        public static string MakeRules(EntityDispatcher E) {
			if (E==null) return null;
            return MakeRules(E.Conn);
        }
		/// <summary>
		/// Esegue il make delle regole modificate presenti nella tabella sptocompile
		/// </summary>
		/// <param name="Conn">Connessione</param>
		/// <returns>NULL se va a buon fine, altrimenti il msg di errore. In caso di errore
		/// la tabella non viene svuotata</returns>
		public static string MakeRules(DataAccess MainConn) {
            if (MainConn.GetSys("filterrule") == null) {
                return "Terminare l'aggiornamento, chiudere e riaprire il programma";
            }
            string filterrule = MainConn.GetSys("filterrule").ToString();

            DataAccess Conn = MainConn.Duplicate();

            Conn.SetSys("filterrule", filterrule);
            //Indispensabile per calcolare le regole
		    foreach (string  k in MainConn.EnumSysKeys()) {
		        Conn.SetSys(k, MainConn.GetSys(k));
		    }
          
            string filtereserc="(ayear="+QueryCreator.quotedstrvalue(
                MainConn.GetSys("esercizio"),true)+")";
            
			
			
            string filter_rules="opkind <> 'M'";
			DataTable Tsptocompile = Conn.RUN_SELECT("sptocompile","tablename,opkind",null,null,null,true);
            if (Tsptocompile == null) return "Terminare l'aggiornamento, chiudere e riaprire il programma";
			bool executed=false;
            
			//compilazione nuove regole
			foreach (DataRow R in Tsptocompile.Select(filter_rules)) {
				string s=EasyAudits.RecalcAudit(Conn,R["tablename"].ToString(),R["opkind"].ToString(),filterrule);
				if (s!=null) return s;
				executed=true;
			}
            
            string cmd = "delete from sptocompile where opkind <> 'M'";
			if (executed) Conn.SQLRunner(cmd);

			
		    Conn.Destroy();
			return null;
		}

	
	}
}
