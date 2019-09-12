/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using metadatalibrary;
using metaeasylibrary;
using ep_functions;
using q = metadatalibrary.MetaExpression;
using DBConn;
using generaSQL;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using gestioneclassificazioni;
using funzioni_configurazione;
namespace TestHelper {
   
    public class WindowFinder
    {
        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        public static IntPtr FindWindow(string caption)
        {
            return FindWindowByCaption(IntPtr.Zero, caption);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);

        private const UInt32 WM_CLOSE          = 0x0010;
        private const int IDOK = 1;
        private const uint WM_COMMAND = 0x0111;
        private const int BN_CLICKED = 245;

        public static void CloseWindow(IntPtr hwnd,int result) {
            SendMessage(hwnd, WM_COMMAND,  (BN_CLICKED << 16) | result, hwnd);
            
        }
    }

 

    public class TestHelp {
        public static void autoCloseByMessageTitle(string title, DialogResult d=DialogResult.OK,int interval=1) {
            int res = 1;
            if (d == DialogResult.Cancel) res = 2;
            if (d == DialogResult.Ignore) res = 5;
            if (d == DialogResult.None) res = 0;
            if (d == DialogResult.Retry) res = 4;
            if (d == DialogResult.Yes) res = 6;
            if (d == DialogResult.No) res = 7;

            var ttt = new Timer();
            ttt.Tick += (x, y) => {
                var formHook = WindowFinder.FindWindow(title);
                if (formHook== IntPtr.Zero)return;                
                WindowFinder.CloseWindow(formHook,res);
                ttt.Stop();
            };
            ttt.Interval = interval;
            ttt.Start();
        }

        public TestHelp( DateTime aDate, string dsnSample = "sample", string dsnTest = "test") {
            
            testConn = DbConn.getEasyAccess(aDate.Year, aDate, dsnTest);
            
            sampleConn = DbConn.getEasyAccess(aDate.Year, aDate, dsnSample);
            
        }

        #region script generation and run

       private static bool readLine(string s, ref int posizione, out string riga, out string ritornoACapo) {
            if ((posizione<0)||(posizione>=s.Length)) {
                riga = null;
                ritornoACapo = null;
                return false;
            }

            int pos = s.IndexOfAny(new char[] {'\r','\n'}, posizione);

            if (pos == -1) {
                ritornoACapo = null;
                riga = s.Substring(posizione);
                posizione = s.Length;
                return true;
            }

            if (s[pos]=='\n') {
                ritornoACapo = "\n";
                riga = s.Substring(posizione, pos-posizione);
                posizione = pos+1;
                return true;
            }

            if((pos+1<s.Length)&&(s[pos+1]=='\n')) {
                ritornoACapo = "\r\n";
                riga = s.Substring(posizione, pos-posizione);
                posizione = pos+2;
                return true;
            } 

            ritornoACapo = "\r";
            riga = s.Substring(posizione, pos-posizione);
            posizione = pos+1;
            return true;
        }

        static ArrayList DivideScript(string script){
            ArrayList CmdList= new ArrayList();
            string currline;
            string Cmd = "";
            int posizione = 0;
            string aCapo;
            while (readLine(script, ref posizione, out currline, out aCapo)) {
                if (currline.Trim().TrimStart().ToUpper() == "GO") {
                    if (Cmd.Trim() != "") {
                        CmdList.Add(Cmd);
                    }
                    Cmd = "";
                } else {
                    Cmd += currline + aCapo;
                }
            }
            if (Cmd.TrimEnd() != "") {
                CmdList.Add(Cmd);
            }
            return CmdList;
        }
        /// <summary>
        /// Esegue il comando di uno script
        /// </summary>
        /// <param name="cmd">comando da eseguire</param>
        /// <param name="Conn">Connessione</param>
        /// <param name="error">errore se non null</param>
        /// <returns>True se va a buon fine</returns>
        private static string RunScriptCmd(IDataAccess Conn, string cmd) {
            //			cmd= QueryCreator.GetPrintable(cmd);
            string error = null;
            DataTable T = Conn.SQLRunner(cmd,6000, out error);
            return error;
        }

        private static string RUN_SCRIPT(IDataAccess Conn, StringBuilder script) {
            ArrayList CmdList = DivideScript(script.ToString());           
            string error = null;
            for (int i = 0; i < CmdList.Count; i++) {
                string sql = CmdList[i].ToString();
                
                error = RunScriptCmd(Conn, sql);
                if (error!=null) {
                    QueryCreator.ShowError(null, "Errore eseguendo lo script " +
                                                 sql,
                        Conn.LastError, "");
                    return error;
                }
            }
            return null;
        }

    

        #endregion


        public IDataAccess testConn;
        public IDataAccess sampleConn;
        /// <summary>
        /// Copia una tabella nel db dest
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="tSource"></param>
        /// <param name="tipoCopia"></param>
        public static bool binaryCopy(IDataAccess dest, DataTable tSource,UpdateType tipoCopia=UpdateType.insertAndUpdate) {
            //var tDest =  dest.CreateTableByName(tSource.TableName,"*");
            if (tSource.Rows.Count == 0) return true;

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            dest.AddExtendedProperty(tSource);
            GeneraSQL.GetSQLData(tSource,tipoCopia,sw);
            sw.Flush();
            string error = RUN_SCRIPT(dest, sb);
            return (error == null);
        }

        /// <summary>
        /// Copia dal db di origine a db di destinazione le righe filtrate di una tabella
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="tableName"></param>
        /// <param name="filter"></param>
        /// <param name="tipoCopia"></param>
        public static void binaryCopy(IDataAccess source, IDataAccess dest, string tableName, q filter,UpdateType tipoCopia) {
            DataTable tSource = source.readTable(tableName, filter);
            binaryCopy(dest, tSource, tipoCopia);
        }

        /// <summary>
        /// Copia una tabella nel db di test
        /// </summary>
        /// <param name="tSource"></param>
        /// <param name="tipoCopia"></param>
        public void binaryCopy(DataTable t,UpdateType tipoCopia=UpdateType.insertAndUpdate) {
            binaryCopy(testConn, t, tipoCopia);
        }

        /// <summary>
        /// Copia le righe dal db di origine al db destinazione filtrando, non cancella righe esistenti nella destinazione
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="filter"></param>
        /// <param name="tipoCopia"></param>
        public void binaryCopy(string tableName, q filter,UpdateType tipoCopia=UpdateType.insertAndUpdate) {
            binaryCopy(sampleConn, testConn, tableName, filter, tipoCopia);
        }
        
        /// <summary>
        /// Cancella le righe una tabella del db di destinazione
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="t"></param>
        public static bool binaryDelete(IDataAccess dest, DataTable t) {
            bool result = true;
            foreach (DataRow r in t.Rows) {
                q filter = q.keyCmp(r);
                string err = dest.DO_DELETE(t.TableName, dest.compile(filter));
                if (err != null) result = false;
            }

            return result;
        }

        /// <summary>
        /// Cancella le righe di una tabella nel db di destinazione
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="tableName"></param>
        /// <param name="filter"></param>
        public static bool binaryDelete(IDataAccess dest, string tableName, q filter) {
             string result = dest.DO_DELETE(tableName, dest.compile(filter));
            return (result == null);
        }

        /// <summary>
        /// Cancella dal db di test le righe tramite filtro
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="filter"></param>
        public bool binaryDelete(string tableName, q filter) {
            return binaryDelete(testConn,tableName,filter);
        }
        
        /// <summary>
        /// Cancella le righe date dal db di test
        /// </summary>
        /// <param name="t"></param>
        public bool binaryDelete(DataTable t) {
            return binaryDelete( testConn, t);
        }

        public void mergeDataset(DataSet dest,DataSet source) {
            foreach (DataTable t in source.Tables) {
                if (dest.Tables.Contains(t.TableName)) {
                    dest.Tables[t.TableName].Merge(source.Tables[t.TableName],false);
                }
                else {
                    dest.Tables.Add(t.Copy());
                }
            }
        }
        public enum mainObject {
            registry,mandate,estimate,invoice,itineration, paymenttransmission, proceedstransmission,
			profservice,pettycashoperation,casualcontract, wageaddition,entry
        };

        static  string[] setRegistryTable = new[] {"registry", "registryreference", "registrydurc", "registrysorting","registrytaxablestatus","registryaddress"};
        static  string[] setMandateTable = new[] {"mandate", "mandatedetail", "mandatesorting", "mandatecig","mandateavcp","mandateavcpdetail","mandateattachment"};
        static  string[] setEstimateTable = new[] {"estimate", "estimatedetail", "estimatesorting","estimateattachment"};
        static  string[] setInvoiceTable = new[] {"invoice", "invoicedetail", "invoicedeferred","invoiceattachment","invoicesorting","ivaregister"};
        static  string[] setItinerationTable = new[] {
            "itineration", "itinerationrefund", "itinerationattachment","itinerationauthagency","itinerationsorting","itinerationflights",
                                "itinerationtax","itinerationlap"
        };
		static  string[] setProfServiceTable = new[] {
			"profservice",  "expenseprofservice","pettycashoperationprofservice","profservice",
			"profserviceavcp", "profserviceavcpdetail", "profservicecig", "profservicerefund","profservicesorting","profservicetax"
		};
		static  string[] setCasualContractTable = new[] {
			"casualcontract", "casualcontractdeduction","casualcontractexemption",
			"casualcontractrefund","casualcontractsorting","casualcontracttax","casualcontracttaxbracket",
			"casualcontractyear","expensecasualcontract","pettycashoperationcasualcontract"
		};
		static  string[] setWageAdditionTable = new[] {
			"expensewageaddition",
			"wageaddition",
			"wageadditionsorting",
			"wageadditiontax",
			"wageadditionyear"
		};
		static  string[] setPettyCashOperationTable = new[] {
			"pettycashoperation", "pettycashoperationcasualcontract", "pettycashoperationinvoice",
			"pettycashoperationitineration", "pettycashoperationprofservice","pettycashoperationsorted","pettycashoperationunderwriting"
		};

		static  string[] setPaymentTransmissionTable = new[] {
			"paymenttransmission" /*, "paymentview", "expensevar"*/
		};
		static  string[] setProceedsTransmissionTable = new[] {
			"proceedstransmission" /*, "proceedsview", "incomevar" */
		};

        private static string[] setEntryTable = new[] {
            "entrydetail", "entrydetailaccrual", "entry"
        };

		Dictionary<mainObject, string[]> allSet= new Dictionary<mainObject, string[]>() {
            { mainObject.registry , setRegistryTable},
            { mainObject.mandate , setMandateTable },
            { mainObject.estimate , setEstimateTable },
            { mainObject.invoice , setInvoiceTable },
            { mainObject.itineration , setItinerationTable },
			{ mainObject.paymenttransmission , setPaymentTransmissionTable },
			{ mainObject.proceedstransmission , setProceedsTransmissionTable },
			{ mainObject.profservice , setProfServiceTable },
			{ mainObject.pettycashoperation , setPettyCashOperationTable },
			{ mainObject.casualcontract , setCasualContractTable },
			{ mainObject.wageaddition , setWageAdditionTable },
		    { mainObject.entry , setEntryTable }
		};

        public string[] getTableSet(mainObject set) {
            return allSet[set];
        }
      
       /// <summary>
       /// Legge un set di dati dal db di origine
       /// </summary>
       /// <param name="source"></param>
       /// <param name="filter"></param>
       /// <param name="tableNames"></param>
       /// <returns></returns>
        public static DataSet binaryGetSet(IDataAccess source, q filter,string[] tableNames) {
            DataSet d=new DataSet();
            foreach (string tableName in tableNames) {
                DataTable t = source.readTable(tableName, filter);
                d.Tables.Add(t);
            }
            return d;
        }

        /// <summary>
        /// Legge un set di dati dal db di origine
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public DataSet binaryGetSet(q filter,string[] tableNames) {
            return binaryGetSet(sampleConn, filter, tableNames);
        }

        /// <summary>
        /// Copia un dataset nel db di destinazione
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="dSource"></param>
        /// <param name="tipoCopia"></param>
        public static bool binaryCopySet(IDataAccess dest, DataSet dSource, UpdateType tipoCopia=UpdateType.insertAndUpdate) {
            var res = true;
            foreach (DataTable tSource in dSource.Tables) {
                if (tSource.Rows.Count==0)continue;
                res &=binaryCopy(dest,tSource, tipoCopia);                
            }

            return res;
        }

        /// <summary>
        /// Copia un dataset nel db di test
        /// </summary>
        /// <param name="dSource"></param>
        /// <param name="tipoCopia"></param>
        public bool  binaryCopySet(DataSet dSource, UpdateType tipoCopia=UpdateType.insertAndUpdate) {
            return binaryCopySet(testConn, dSource, tipoCopia);
        }

        /// <summary>
        /// Copia dati dal db di test
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="tableNames"></param>
        public void binaryCopySet(q filter,string[] tableNames, UpdateType tipoCopia=UpdateType.insertAndUpdate) {
            foreach (string tableName in tableNames.Reverse().ToArray()) {
                binaryCopy(tableName,filter,tipoCopia);                
            }
        }

        /// <summary>
        /// Cancella dati dal db di test
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="tableNames"></param>
        public bool binaryDeleteSet(q filter,string[] tableNames) {
            var res = true;
            foreach (string tableName in tableNames.Reverse().ToArray()) {
                res &= binaryDelete(testConn,tableName,filter);                
            }

            return res;
        }

        /// <summary>
        /// Cancella tutte le righe di un ds dal database di test
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool binaryDeleteSet(DataSet d) {
            var res = true;
            for (int i=0;i<d.Tables.Count;i++) {
                DataTable t = d.Tables[i];
                res &= binaryDelete(t);                
            }
            return res;
        }

        /// <summary>
        /// Sostituisce i dati nel db di test con quelli del db di esempio
        /// </summary>
        /// <param name="dSource"></param>
        /// <returns></returns>
        public static void binaryReplaceSet(IDataAccess source, IDataAccess dest, q keyFilter, string[]tableNames) {
            DataSet dSource = binaryGetSet(source,keyFilter, tableNames);
            foreach (string tableName in tableNames.Reverse().ToArray()) {
                binaryDelete(dest,tableName,keyFilter);
            }
            binaryCopySet(dest,dSource,UpdateType.bulkinsert);
        }

        public void binaryReplaceSet(q keyFilter, string[] tableNames) {
            binaryReplaceSet(sampleConn,testConn,keyFilter,tableNames);
        }

        /// <summary>
        /// Copia una fattura con tutti i suoi dettagli e dati collegati 
        /// </summary>
        /// <param name="idinvkind"></param>
        /// <param name="yinv"></param>
        /// <param name="ninv"></param>
        public void copiaFattura(object idinvkind, object yinv, object ninv, bool withExternals) {
            q mainFilter = q.eq("idinvkind", idinvkind) & q.eq("yinv", yinv) & q.eq("ninv", ninv);
            binaryCopySet(mainFilter, setInvoiceTable, UpdateType.insertAndUpdate);
        }

        public void generaClassAutomatica(DataSet ds, DataRow r) {
            string metaTableName = r.Table.TableName;
            Meta_EasyDispatcher md = new Meta_EasyDispatcher(testConn);
            var meta = md.Get(metaTableName);
            var getd = new GetData();
            getd.InitClass(ds, testConn, metaTableName);

            //riempie il dataset
            ds.Tables[metaTableName]._getFromDb(testConn, q.keyCmp(r));
            getd.DO_GET(false, null);
            meta.DS = ds;
            
            GestioneClassificazioni ManageClassificazioni;
            ManageClassificazioni = new GestioneClassificazioni(meta, null, null, null, null, null, null, null, null);
            ManageClassificazioni.ClassificaTramiteClassDocumento(ds, null);
        }

        public static MetaData editDataRow(IDataAccess source,  q keyFilter, string tableName,
            string editType, string listType = null) {
            var sDisp = new Meta_EasyDispatcher(source);
            var mSource = sDisp.Get(tableName);
            mSource.Edit(null, editType,false);
            if (string.IsNullOrEmpty(listType)) listType= mSource.DefaultListType;
            var r = mSource.SelectOne(listType, source.compile(keyFilter), null, null);
            if (r == null) return null;
            mSource.formController.SelectRow(r, listType);
            return mSource;
        }

        /// <summary>
        /// Effettua l'inserisci copia "da programma"
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="keyFilter"></param>
        /// <param name="tableName"></param>
        /// <param name="editType"></param>
        /// <param name="listType"></param>
        /// <returns>null on errors, otherwise copied data</returns>
        public static DataSet insertCopyData(IDataAccess source, IDataAccess dest, q keyFilter, string tableName,
            string editType,string listType=null) {            
            var mSource = editDataRow(source,  keyFilter, tableName, editType, listType);
            if (mSource == null) return null;
            var ds = mSource.DS;

            //if (tableName == "mandate") {
            //    MetaData.SetDefault(ds.Tables["mandate"],"idmankind",ds.Tables["mandate"].Rows[0]["idmankind"]);
            //}
            //if (tableName == "mandatekind") {
            //    MetaData.SetDefault(ds.Tables["mandatekind"],"idmankind",ds.Tables["mandatekind"].Rows[0]["idmankind"]+"_1");
            //}
            //if (tableName == "estimate") {
            //    MetaData.SetDefault(ds.Tables["estimate"],"idestimkind",ds.Tables["estimate"].Rows[0]["idestimkind"]);
            //}
            //if (tableName == "estimatekind") {
            //    MetaData.SetDefault(ds.Tables["estimatekind"],"idestimkind",ds.Tables["estimatekind"].Rows[0]["idestimkind"]+"_1");
            //}
            if (!mSource.EditNewCopy()) return null;
            return saveFormDataNoBL(mSource,dest);
         
        }

        /// <summary>
        /// Salva il dataset del form collegato al metadato nel db di destinazione
        /// </summary>
        /// <param name="metaForm"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public static DataSet saveFormDataNoBL(MetaData metaForm,IDataAccess dest) {
            DataSet ds = metaForm.DS;
            //A questo punto salva il DS nel db di destinazione
            var post = new Easy_PostData_NoBL();
            post.initClass(ds, dest);
            PostData.setInnerPosting(ds, null);
            var res =post.DO_POST_SERVICE();
            if (res.Count > 0) {
                foreach (ProcedureMessage msg in res) {
                    QueryCreator.MarkEvent(msg.GetKey()+":"+msg.LongMess);
                }
                return null;
            }
            var resDataSet = ds.Copy();
            metaForm.DontWarnOnInsertCancel = true;
            ds.AcceptChanges();
            metaForm.formController.linkedForm.Close();            
            return resDataSet;
        }

        public  DataSet saveFormDataNoBL(MetaData metaForm) {
            return saveFormDataNoBL(metaForm, testConn);
        }

        /// <summary>
        /// Effettua la cancellazione "da programma"
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="keyFilter"></param>
        /// <param name="tableName"></param>
        /// <param name="editType"></param>
        /// <param name="listType"></param>
        /// <returns>null if ok, dataset otherwise</returns>
        public static DataSet maindeleteData( IDataAccess dest, q keyFilter, string tableName,
            string editType,string listType=null) {
            var sDisp = new Meta_EasyDispatcher(dest);
            var mDest = sDisp.Get(tableName);
            mDest.Edit(null, editType,false);
            if (string.IsNullOrEmpty(listType)) listType= mDest.DefaultListType;
            var r = mDest.SelectOne(listType, dest.compile(keyFilter), null, null);
            if (r == null) return null;

            testE2EFrmHelper thelp = new testE2EFrmHelper(mDest.linkedForm);

            var shower = MetaFactory.factory.getSingleton<IMessageShower>();
            var testResp  = new testResponder();
            
            shower.setAutoResponder(testResp);
            testResp.responsesToGive.Add(DialogResult.OK);//Respond true to question "want to delete"

            mDest.formController.SelectRow(r, listType);
            var curr=  HelpForm.GetLastSelected(mDest.PrimaryDataTable);
            if (curr == null) return null;
            MetaFactory.factory.registerType(typeof(Easy_PostDataTest), typeof(Easy_PostData));
            mDest.DoMainCommand("maindelete");
            if (mDest.formController.IsEmpty) {
                mDest.formController.linkedForm.Close();   
                return null;
            }
            mDest.formController.linkedForm.Close();   
            return mDest.DS;
        }


        public  MetaData editDataRow(q keyFilter, string tableName,
            string editType, string listType = null) {
            var sDisp = new Meta_EasyDispatcher(sampleConn);
            var mSource = sDisp.Get(tableName);
            mSource.Edit(null, editType,false);
            if (string.IsNullOrEmpty(listType)) listType= mSource.DefaultListType;
            var r = mSource.SelectOne(listType, sampleConn.compile(keyFilter), null, null);
            if (r == null) return null;
            mSource.formController.SelectRow(r, listType);
            return mSource;
        }

        /// <summary>
        /// Effettua la copia di un dato "da programma"
        /// </summary>
        /// <param name="keyFilter"></param>
        /// <param name="tableName"></param>
        /// <param name="editType"></param>
        /// <param name="listType"></param>
        /// <returns></returns>
        public DataSet insertCopyData(q keyFilter, string tableName, string editType,string listType=null) {
            return insertCopyData(sampleConn, testConn, keyFilter, tableName, editType);
        }

        public DataSet maindeleteData(q keyFilter, string tableName, string editType,string listType=null) {
            return maindeleteData( testConn, keyFilter, tableName, editType);
        }

        /// <summary>
        /// Uses reflection functions to detect the DataSet linked to a Form
        /// </summary>
        DataSet getFormDataSet(Form f) {
            var dsInfo = f.GetType().GetField("DS");
            if (dsInfo == null) return null;
            if (!typeof(DataSet).IsAssignableFrom(dsInfo.FieldType)) return null;
            return (DataSet) dsInfo.GetValue(f);
        }


        public DataSet SampleDataSet(DataRow r, string editTypeToUse = null) {
            string metaTableName = r.Table.TableName;
            Meta_EasyDispatcher md = new Meta_EasyDispatcher(testConn);
            var meta = md.Get(metaTableName);

            string editType = null;
            if (editTypeToUse != null) {
                editType = editTypeToUse;
            }
            else {
                switch (metaTableName) {
                    case "mandate":
                        editType = "default";
                        break;
                    default:
                        editType = "default";
                        break;
                }
            }
            meta.Edit(null, editType, false);
            var ds = meta.DS.Copy();

            meta.ds.AcceptChanges();
            meta.linkedForm.Close();

            //if (metaTableName == "invoice" && ds.Tables.Contains("invoicekind")) {
            //    ds.Tables["invoicekind"]._get(testConn, q.eq("idinvkind", r["idinvkind"]));
            //}

            return ds;
        }
        /// <summary>
        /// Cancella movimenti e scritture sulla riga r. 
        /// </summary>
        /// <param name="r"></param>
        public void deleteEp(DataRow r) {
            generaCancellaImpegniScritture(r, true);
        }

        /// <summary>
        /// Cancella un movimento di spesa con tutti i suoi eventuali figli e dati collegati
        /// </summary>
        /// <param name="idexp"></param>
        public void cancellaMovimentoSpesa(object idexp) {
            q mainFilter = q.eq("idexp", idexp);
            var tChild = testConn.readTable("expenselink", q.eq("idparent", idexp),"*","nlevel desc");
            foreach (DataRow rChild in tChild.Rows) {
                cancellaMovimentoSpesaSingolo(rChild["idchild"]);
            }
        }

        /// <summary>
        /// Copia un movimento di spesa con tutti i suoi eventuali figli e dati collegati 
        /// </summary>
        /// <param name="idexp"></param>
        public void copiaMovimentoSpesa(object idexp, bool withExternals) {
            q mainFilter = q.eq("idexp", idexp);
            var tChild = sampleConn.readTable("expenselink", q.eq("idparent", idexp),"*","nlevel asc");
            foreach (DataRow rChild in tChild.Rows) {
                copiaMovimentoSpesaSingolo(rChild["idchild"],withExternals);
            }
        }

        static  string[] setExpenseTable = new[] {
            "expense", "expensevar","expenseyear","expenselast", "expensebill","expensecasualcontract","expenseclawback",
            "expensemandate","expenseinvoice","pettycashexpense",
            "expenseitineration","expensepayroll","expenseprofservice","expensewageaddition",
            "expensesorted","expensetax","expensetaxcorrige","expensetaxofficial",
            "ivapayexpense","mainivapayexpense","pccexpense","pccpayment","taxpayexpense",
            "csa_importriep_expense","csa_importver_expense",
            "underwritingappropriation","underwritingpayment","csa_import_expense",
            "assetloadexpense","authpaymentexpense","csa_contractexpense","csa_contracttaxexpense",
            "expensetotal"                
        };

        public void cancellaMovimentoSpesaSingolo(object idexp) {
            //Cancella le tabelle principali con tale id
            binaryDeleteSet(q.eq("idexp",idexp), setExpenseTable);

            //pone a null gli id delle tabelle collegate a expense 
            foreach (string tableName in new string[] {
                "finvardetail","pettycashoperation","banktransaction","csa_contract","csa_contracttax",
                "csa_importriep",
            }) {
                testConn.DO_UPDATE(tableName, testConn.compile(q.eq("idexp", idexp)),
                    new[] {"idexp"}, new[] {"null"}, 1);
            }
            testConn.DO_UPDATE("invoicedetail", testConn.compile(q.eq("idexp_taxable", idexp)),
                new[] {"idexp_taxable"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("invoicedetail", testConn.compile(q.eq("idexp_iva", idexp)),
                new[] {"idexp_iva"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("mandatedetail", testConn.compile(q.eq("idexp_taxable", idexp)),
                new[] {"idexp_taxable"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("mandatedetail", testConn.compile(q.eq("idexp_iva", idexp)),
                new[] {"idexp_iva"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("import_flow", testConn.compile(q.eq("id_liq", idexp)),
                new[] {"id_liq"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("csa_importver", testConn.compile(q.eq("idexp_cost", idexp)),
                new[] {"idexp_cost"}, new[] {"null"}, 1);

        }

        public void copiaMovimentoSpesaSingolo(object idexp, bool withExternals) {
            //Cancella le tabelle principali con tale id
            binaryCopySet(q.eq("idexp",idexp), setExpenseTable,UpdateType.insertAndUpdate);

            if (!withExternals)return;

            //valorizza id mov. di spesa sulle tabelle esterne copiandolo dai dati
            binaryCopySet(q.eq("idexp",idexp),  new string[] {
                "finvardetail","pettycashoperation","banktransaction","csa_contract","csa_contracttax",
                "csa_importriep",
            },UpdateType.onlyUpdate);

            binaryCopy("invoicedetail",q.eq("idexp_taxable", idexp),UpdateType.onlyUpdate);   
            binaryCopy("invoicedetail",q.eq("idexp_iva", idexp),UpdateType.onlyUpdate);  
            binaryCopy("mandatedetail",q.eq("idexp_taxable", idexp),UpdateType.onlyUpdate);  
            binaryCopy("mandatedetail",q.eq("idexp_iva", idexp),UpdateType.onlyUpdate);  
            binaryCopy("import_flow",q.eq("id_liq", idexp),UpdateType.onlyUpdate);  
            binaryCopy("csa_importver",q.eq("idexp_cost", idexp),UpdateType.onlyUpdate);  

        }

        static  string[] setIncomeTable = new[] {
            "income", "incomevar","incomeyear","incomelast", "incomebill",
            "incomeestimate","incomeinvoice","pettycashincome",
            "assetunloadincome","creditpart","proceedspart",
            "csa_import_income",
            "incomesorted",
            "incometotal"                
        };

        public void cancellaMovimentoEntrataSingolo(object idinc) {
            //Cancella le tabelle principali con tale id
            binaryDeleteSet(q.eq("idinc",idinc), setIncomeTable);

            //pone a null gli id delle tabelle collegate a income 
            foreach (string tableName in new string[] {"banktransaction","expensetax"}) {
                testConn.DO_UPDATE(tableName, testConn.compile(q.eq("idinc", idinc)),new[] {"idexp"}, new[] {"null"}, 1);
            }

            testConn.DO_UPDATE("invoicedetail", testConn.compile(q.eq("idinc_taxable", idinc)),new[] {"idinc_taxable"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("invoicedetail", testConn.compile(q.eq("idinc_iva", idinc)),new[] {"idinc_iva"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("estimatedetail", testConn.compile(q.eq("idinc_taxable", idinc)),new[] {"idinc_taxable"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("estimatedetail", testConn.compile(q.eq("idinc_iva", idinc)),new[] {"idinc_iva"}, new[] {"null"}, 1);
            testConn.DO_UPDATE("import_flow", testConn.compile(q.eq("id_inc", idinc)),new[] {"id_inc"}, new[] {"null"}, 1);
        }
        /// <summary>
        /// Copia un movimento di spesa con tutti i suoi eventuali figli e dati collegati 
        /// </summary>
        /// <param name="idexp"></param>
        public void copiaMovimentoEntrata(object idinc, bool withExternals) {
            q mainFilter = q.eq("idinc", idinc);
            var tChild = sampleConn.readTable("incomelink", q.eq("idparent", idinc),"*","nlevel asc");
            foreach (DataRow rChild in tChild.Rows) {
                copiaMovimentoEntrataSingolo(rChild["idchild"],withExternals);
            }
        }

        public void copiaMovimentoEntrataSingolo(object idinc, bool withExternals) {
            //Cancella le tabelle principali con tale id
            binaryCopySet(q.eq("idinc",idinc), setIncomeTable,UpdateType.insertAndUpdate);

            if (!withExternals)return;

            //valorizza id mov. di spesa sulle tabelle esterne copiandolo dai dati
            binaryCopySet(q.eq("idinc",idinc),  new string[] {"banktransaction","expensetax"},UpdateType.onlyUpdate);
            binaryCopy("invoicedetail",q.eq("idinc_taxable", idinc),UpdateType.onlyUpdate);   
            binaryCopy("invoicedetail",q.eq("idinc_iva", idinc),UpdateType.onlyUpdate);  
            binaryCopy("estimatedetail",q.eq("idinc_taxable", idinc),UpdateType.onlyUpdate);  
            binaryCopy("estimatedetail",q.eq("idinc_iva", idinc),UpdateType.onlyUpdate);  
            binaryCopy("import_flow",q.eq("id_inc", idinc),UpdateType.onlyUpdate);  
        }

        /// <summary>
        /// Cancella un movimento di spesa con tutti i suoi eventuali figli e dati collegati
        /// </summary>
        /// <param name="idinc"></param>
        public void cancellaMovimentoEntrata(object idinc) {
            q mainFilter = q.eq("idinc", idinc);
            var tChild = testConn.readTable("incomelink", q.eq("idparent", idinc),"*","nlevel desc");
            foreach (DataRow rChild in tChild.Rows) {
                cancellaMovimentoEntrataSingolo(rChild["idchild"]);
            }

        }

          public void GetEntryForDocument(DataSet D, IDataAccess Conn, string idrelated) {
              var QHS = Conn.GetQueryHelper();

              string filterrelated = QHS.CmpEq("idrelated", idrelated);
              var entries = D.Tables["entry"]._safeMergeFromDb(Conn, q.eq("idrelated", idrelated));

            if (entries.Length == 0) {              
                return;
            }

            foreach (DataRow entry in entries) {
                Conn.RUN_SELECT_INTO_TABLE(D.Tables["entrydetail"], null, QHS.CmpKey(entry), null, true);
                Conn.RUN_SELECT_INTO_TABLE(D.Tables["entrydetailaccrual"], null, QHS.CmpKey(entry), null, true);                
            }

        }

        public DataSet getEpData(IDataAccess conn, DataRow document) {            
            string idForEntry = EP_functions.GetIdForDocument(document);
            string idForMov = BudgetFunction.GetIdForDocument(document);
            var ds = BudgetFunction.CreateDataset(conn);
            getEpMovForDocument(ds, conn, idForMov);
            GetEntryForDocument(ds,conn,idForEntry);
            return ds;
        }

          public bool getEpMovForDocument(DataSet D, IDataAccess Conn,  string idrelated) {
             var QHS = Conn.GetQueryHelper();
            string filterOriginal = BudgetFunction.getDocChildCondition(QHS, idrelated);

            string filterrelated = filterOriginal;
              foreach (string table in new List<string>() {"epexp", "epacc"}) {
                  string idmov = "id" + table;

                  Conn.RUN_SELECT_INTO_TABLE(D.Tables[table], null,filterrelated, null, false);

                  DataTable tsort = D.Tables[table + "sorting"];
                  DataTable tyear = D.Tables[table + "year"];
                  DataTable tvar = D.Tables[table + "var"];
                  DataTable tEntryDetail = D.Tables["entrydetail"];
                  DataTable tEntryDetailAccrual = D.Tables["entrydetailaccrual"];

                  string filterAlias = BudgetFunction.getDocChildCondition(table + ".idrelated", QHS, idrelated);
                  string querySortColumns = DataTools.aliasColumns(tsort, tsort.TableName);
                  string querySort = "select " + querySortColumns +
                                     " from " + table +
                                     " join " + tsort.TableName + " on " + tsort.TableName + "." + idmov + " = " +
                                     table +
                                     "." + idmov +
                                     //" and " + tsort.TableName + ".ayear = " + QHS.quote(esercizio) +
                                     " and " + filterAlias;
                  DataTools.MergeRows(Conn as DataAccess, tsort, querySort);


                  string queryVarColumns = DataTools.aliasColumns(tvar, tvar.TableName);
                  string queryVar = "select " + queryVarColumns +
                                    " from " + table +
                                    " join " + tvar.TableName + " on " + tvar.TableName + "." + idmov + " = " +
                                    table + "." + idmov +
                                    //" and " + tvar.TableName + ".yvar = " + QHS.quote(esercizio) +
                                    " and " + filterAlias;
                  DataTools.MergeRows(Conn as DataAccess, tvar, queryVar);
                  //string filtervar = QHS.AppAnd(QHS.CmpEq(idmov, epExp[idmov]), QHS.CmpEq("yvar", esercizio));
                  //Conn.RUN_SELECT_INTO_TABLE(tvar, null, filtervar, null, false);
                  string queryYearColumns = DataTools.aliasColumns(tyear, tyear.TableName);
                  string queryYear = "select " + queryYearColumns +
                                     " from " + table +
                                     " join " + tyear.TableName + " on " + tyear.TableName + "." + idmov + " = " +
                                     table + "." + idmov +
                                     //" and " + tyear.TableName + ".ayear = " + QHS.quote(esercizio) +
                                     " and " + filterAlias;
                  DataTools.MergeRows(Conn as DataAccess, tyear, queryYear);
                  //Conn.RUN_SELECT_INTO_TABLE(tyear, null, filter, null, false);

                  //lastread = tyear.Select(QHC.CmpEq(idmov, epExp[idmov]));
    

                  string queryEntryDetailsColumns = DataTools.aliasColumns(tEntryDetail, tEntryDetail.TableName);
                  string queryEntryDetails = "select " + queryEntryDetailsColumns +
                                             " from " + table +
                                             " join " + tEntryDetail.TableName + " on " + tEntryDetail.TableName + "." +
                                             idmov + " = " +
                                             table + "." + idmov +
                                             //" and " + tEntryDetail.TableName + ".yentry = " + QHS.quote(esercizio) +
                                             " and " + filterAlias;
                  
                  DataTools.MergeRows(Conn as DataAccess, tEntryDetail, queryEntryDetails);


                  string queryEntryDetailsAccrualsColumns = DataTools.aliasColumns(tEntryDetailAccrual, tEntryDetailAccrual.TableName);
                  string queryEntryDetailsAccruals = "select " + queryEntryDetailsAccrualsColumns +
                                                     " from " + table +
                                                     " join " + tEntryDetail.TableName + " on " +
                                                     tEntryDetail.TableName + "." +
                                                     idmov + " = " +
                                                     table + "." + idmov +
                                                     //" and " + tEntryDetail.TableName + ".yentry = " + QHS.quote(esercizio) +
                                                     " and " + filterAlias +
                                                     " join entrydetailaccrual on entrydetailaccrual.yentry=entrydetail.yentry " +
                                                     " and entrydetailaccrual.nentry=entrydetail.nentry "+
                                                     " and entrydetailaccrual.ndetail=entrydetail.ndetail "+
                                                     " and " + tEntryDetail.TableName + ".yentry = " +testConn.Security.GetEsercizio();
                                             
                  
                  DataTools.MergeRows(Conn as DataAccess, tEntryDetailAccrual, queryEntryDetailsAccruals);
              }
              return true;
        }

        public bool binaryDeleteEp(DataRow r) {
            var ds = getEpData(testConn, r);
            var dsExtended = new DataSet();
            if (r.Table.TableName == "mandate" || r.Table.TableName == "mandatedetail") {
                foreach (DataRow rEpExp in ds.Tables["epexp"].Rows) {
                    testConn.DO_UPDATE("mandatedetail", testConn.compile(q.eq("idepexp", rEpExp["idepexp"])),
                        new[] {"idepexp"}, new[] {"null"},1);
                    testConn.DO_UPDATE("mandatedetail", testConn.compile(q.eq("idepexp_pre", rEpExp["idepexp"])),
                        new[] {"idepexp_pre"}, new[] {"null"},1);
                }
            }
            if (r.Table.TableName == "invoice" || r.Table.TableName == "invoicedetail") {
                foreach (DataRow rEpExp in ds.Tables["epexp"].Rows) {
                    testConn.DO_UPDATE("invoicedetail", testConn.compile(q.eq("idepexp", rEpExp["idepexp"])),
                        new[] {"idepexp"}, new[] {"null"},1);
                    testConn.DO_UPDATE("invoicedetail", testConn.compile(q.eq("idepexp_pre", rEpExp["idepexp"])),
                        new[] {"idepexp_pre"}, new[] {"null"},1);
                }
                foreach (DataRow rEpAcc in ds.Tables["epacc"].Rows) {
                    testConn.DO_UPDATE("invoicedetail", testConn.compile(q.eq("idepacc", rEpAcc["idepacc"])),
                        new[] {"idepacc"}, new[] {"null"},1);                   
                }
            }
            if (r.Table.TableName == "estimate" || r.Table.TableName == "estimatedetail") {
                foreach (DataRow rEpAcc in ds.Tables["epacc"].Rows) {
                    testConn.DO_UPDATE("estimatedetail", testConn.compile(q.eq("idepacc", rEpAcc["idepacc"])),
                        new[] {"idepacc"}, new[] {"null"},1);
                    testConn.DO_UPDATE("estimatedetail", testConn.compile(q.eq("idepacc_pre", rEpAcc["idepacc"])),
                        new[] {"idepacc_pre"}, new[] {"null"},1);
                }
            }

            bool res= binaryDeleteSet(ds);
            testConn.SQLRunner("exec rebuild_epexptotal " + testConn.Security.GetEsercizio());
            testConn.SQLRunner("exec rebuild_epacctotal " + testConn.Security.GetEsercizio());
            return res;
        }

        public bool binaryCopyEp(DataRow r) {
            var ds = getEpData(sampleConn, r);
            var qhs = testConn.GetQueryHelper();
            if (!binaryDeleteEp(r))return  false;
            if (! binaryCopySet(ds))return  false;

            testConn.SQLRunner("exec rebuild_epexptotal " + testConn.Security.GetEsercizio());
            testConn.SQLRunner("exec rebuild_epacctotal " + testConn.Security.GetEsercizio());

            var res = true;
            if (r.Table.TableName == "mandate" || r.Table.TableName == "mandatedetail") {
                foreach (DataRow rEpExp in ds.Tables["epexp"].Rows) {
                    DataTable tManDetail = sampleConn.readTable("mandatedetail", q.eq("idepexp", rEpExp["idepexp"]));
                    foreach(DataRow rManDet in tManDetail.Rows) {
                        if (testConn.doUpdate(rManDet, fields: new[] {"idepexp"})!=null)res=false;
                    }
                    tManDetail = sampleConn.readTable("mandatedetail", q.eq("idepexp_pre", rEpExp["idepexp"]));
                    foreach(DataRow rManDet in tManDetail.Rows) {
                        if (testConn.doUpdate(rManDet, fields: new[] {"idepexp_pre"})!=null)res=false;
                    }                    
                }
            }
            if (r.Table.TableName == "invoice" || r.Table.TableName == "invoicedetail") {
                foreach (DataRow rEpExp in ds.Tables["epexp"].Rows) {
                    DataTable tInvDetail = sampleConn.readTable("invoicedetail", q.eq("idepexp", rEpExp["idepexp"]));
                    foreach(DataRow rInvDet in tInvDetail.Rows) {
                        if (testConn.doUpdate(rInvDet, fields: new[] {"idepexp"})!=null)res= false;
                    }
                    tInvDetail = sampleConn.readTable("invoicedetail", q.eq("idepexp_pre", rEpExp["idepexp"]));
                    foreach(DataRow rInvDet in tInvDetail.Rows) {
                        if (testConn.doUpdate(rInvDet, fields: new[] {"idepexp_pre"})!=null)res=false;
                    }                    
                }
                foreach (DataRow rEpAcc in ds.Tables["epacc"].Rows) {
                    DataTable tInvDetail = sampleConn.readTable("invoicedetail", q.eq("idepacc", rEpAcc["idepacc"]));
                    foreach(DataRow rInvDet in tInvDetail.Rows) {
                        if (testConn.doUpdate(rInvDet, fields: new[] {"idepacc"})!=null)res=false;
                    }                                    
                }
            }
            if (r.Table.TableName == "estimate" || r.Table.TableName == "estimatedetail") {
                foreach (DataRow rEpAcc in ds.Tables["epacc"].Rows) {
                    DataTable tEstimDetail = sampleConn.readTable("estimatedetail", q.eq("idepacc", rEpAcc["idepacc"]));
                    foreach(DataRow rEstimDet in tEstimDetail.Rows) {
                        if (testConn.doUpdate(rEstimDet, fields: new[] {"idepacc"})!=null)res=false;
                    }
                    tEstimDetail = sampleConn.readTable("estimatedetail", q.eq("idepacc_pre", rEpAcc["idepacc"]));
                    foreach(DataRow rEstimDet in tEstimDetail.Rows) {
                        if (testConn.doUpdate(rEstimDet, fields: new[] {"idepacc_pre"})!=null)res=false;
                    }                    
                }
                
            }

            return res;

        }


        public bool binaryReplaceEp(DataRow r) {
            binaryDeleteEp(r);
            return binaryCopyEp(r);
        }

        void generaCancellaImpegniScritture(DataRow r,bool cancella) {
            string metaTableName = r.Table.TableName;
            Meta_EasyDispatcher md = new Meta_EasyDispatcher(testConn);
            var meta = md.Get(metaTableName);

            var ds = SampleDataSet(r);
            var getd = new GetData();
            getd.InitClass(ds, testConn, metaTableName);
           
            if (metaTableName=="mandate" && ! ds.Tables.Contains("mandatedetail"))throw new Exception("Dettaglio contratti passivi mancante nel ds");
            if (metaTableName=="estimate" && ! ds.Tables.Contains("estimatedetail"))throw new Exception("Dettaglio contratti attivi mancante nel ds");
            if (metaTableName=="invoice" && ! ds.Tables.Contains("invoicedetail"))throw new Exception("Dettaglio fatture mancante nel ds");
            if (metaTableName=="assetunload" && ! ds.Tables.Contains("assetamortizationunloadview"))throw new Exception("assetamortizationunloadview mancante nel ds");
            if (metaTableName=="grantload" && ! ds.Tables.Contains("assetgrant"))throw new Exception("assetgrant mancante nel ds");
            if (metaTableName=="grantload" && ! ds.Tables.Contains("assetgrantdetail"))throw new Exception("assetgrantdetail mancante nel ds");
            if (metaTableName=="assetload" && ! ds.Tables.Contains("assetacquireview"))throw new Exception("assetacquireview mancante nel ds");
            if (metaTableName=="provision" && ! ds.Tables.Contains("provisiondetail"))throw new Exception("provisiondetail mancante nel ds");
            if (metaTableName=="assetload" && ! ds.Tables.Contains("assetacquireview"))throw new Exception("assetacquireview mancante nel ds");

            //riempie il dataset
            ds.Tables[metaTableName]._getFromDb(testConn, q.keyCmp(r));
            getd.DO_GET(false, null);
            meta.DS = ds;
            r = ds.Tables[metaTableName]._Filter(q.keyCmp(r))._First();

            EP_Manager ep= new EP_Manager(meta,null,null,null,null,null,null,null,null,metaTableName);
            ep.metaTableForPosting = cancella?"nobusinessrule":"epexp";
            ep.silentPosting = true;
            ep.autoIgnore = !cancella;
            ep.disableIntegratedPosting();
            ep.setForcedCurrentRow(r);
            ep.beforePost(cancella);
            ep.afterPost(true);

            if (cancella) {
                if (metaTableName == "mandate") {
                    testConn.DO_UPDATE("mandatedetail", testConn.compile(q.keyCmp(r)),
                        new[] {"idepexp","idepacc"}, new[] {"null","null"}, 2);
                }
                if (metaTableName == "estimate") {
                    testConn.DO_UPDATE("estimatedetail", testConn.compile(q.keyCmp(r)),
                        new[] {"idepacc"}, new[] {"null"}, 1);
                }
                if (metaTableName == "invoice") {
                    testConn.DO_UPDATE("invoicedetail", testConn.compile(q.keyCmp(r)),
                        new[] {"idepexp","idepacc"}, new[] {"null","null"}, 2);
                }
            }
        }

        public void generateEP(DataRow r) {
            generaCancellaImpegniScritture(r, false);
        }
        public bool checkScrittura(DataRow doc,   string codiceConto = null, string codiceUPB = null, string codiceCausale=null, q filterDetail=null) {
            q filter = q.eq("idrelated", EP_functions.GetIdForDocument(doc));
            if (filterDetail == null) filterDetail = q.constant(true);
            if (codiceConto!=null) {
                object idacc = testConn.readValue("account",
                    q.eq("codeacc", codiceConto) & q.eq("ayear", testConn.Security.GetEsercizio()), "idacc");
                if (idacc == null || idacc==DBNull.Value) return false;
                filterDetail &= q.eq("idacc", idacc);
            }
            if (codiceUPB!=null) {
                object idupb = testConn.readValue("upb",
                    q.eq("codeupb", codiceUPB), "idupb");
                if (idupb == null || idupb==DBNull.Value) return false;
                filterDetail &= q.eq("idupb", idupb);
            }

            if (codiceCausale != null) {
                object idAccMotive=testConn.readValue("accmotive",
                    q.eq("codemotive", codiceCausale), "idaccmotive");
                if (idAccMotive == null || idAccMotive==DBNull.Value) return false;
                filterDetail &= q.eq("idaccmotive", idAccMotive);
            }
            DataTable tEntry = testConn.readTable("entry", filter);
            DataTable tEntryDetail = testConn.CreateTableByName("entrydetail","*");
            testConn.readTableJoined(tEntryDetail, "entry", filterDetail, filter, "yentry", "nentry");
            if (tEntryDetail.Rows.Count > 0) return true;
            
            return false;
        }

        public bool checkScritturaAvere(DataRow doc, decimal importo, 
            string codiceConto = null, string codiceUPB = null,string codiceCausale=null,q filterDetail=null) {
            if (filterDetail == null) filterDetail = q.constant(true);
            filterDetail &= q.eq("amount", importo);
            return checkScrittura(doc, codiceConto, codiceUPB,codiceCausale,filterDetail);
        }
        public bool checkScritturaDare(DataRow doc, decimal importo, 
            string codiceConto = null, string codiceUPB = null,string codiceCausale=null,q filterDetail=null) {
            if (filterDetail == null) filterDetail = q.constant(true);
            filterDetail &= q.eq("amount", -importo);
            return checkScrittura(doc, codiceConto, codiceUPB,codiceCausale,filterDetail);
        }

        public bool checkImpegnoBudget(DataRow doc, bool withChild=false, bool preImpegno=false,
            string codiceConto = null, string codiceUPB = null,string codiceCausale=null, q filterDetail=null) {
            string idDoc = BudgetFunction.GetIdForDocument(doc);
            q filter = withChild ? q.like("idrelated", idDoc+"%")| q.eq("idrelated", idDoc) : q.eq("idrelated", idDoc);
            filter &= (preImpegno ? q.eq("nphase", 1) : q.eq("nphase", 2));
           filter &= q.eq("ayear",testConn.Security.GetEsercizio());
            if (filterDetail != null) filter &= filterDetail;
            if (codiceConto!=null) {
                object idacc = testConn.readValue("account",
                    q.eq("codeacc", codiceConto) & q.eq("ayear", testConn.Security.GetEsercizio()), "idacc");
                if (idacc == null || idacc==DBNull.Value) return false;
                filter &= q.eq("idacc", idacc);
            }
            if (codiceUPB!=null) {
                object idupb = testConn.readValue("upb",
                    q.eq("codeupb", codiceUPB), "idupb");
                if (idupb == null || idupb==DBNull.Value) return false;
                filter &= q.eq("idupb", idupb);
            }
            if (codiceCausale != null) {
                object idAccMotive=testConn.readValue("accmotive",
                    q.eq("codemotive", codiceCausale), "idaccmotive");
                if (idAccMotive == null || idAccMotive==DBNull.Value) return false;
                filterDetail &= q.eq("idaccmotive", idAccMotive);
            }
            DataTable tEpExpView = testConn.readTable("epexpview", filter);
            if (tEpExpView.Rows.Count > 0) return true;
            return false;

        }

        public bool checkAccertamentoBudget(DataRow doc, bool withChild=false, bool preAccertamento=false,
            string codiceConto = null, string codiceUPB = null,string codiceCausale=null, q filterDetail=null) {
            string idDoc = BudgetFunction.GetIdForDocument(doc);
            q filter = withChild ? q.like("idrelated", idDoc+"%")| q.eq("idrelated", idDoc) : q.eq("idrelated", idDoc);
            filter &= (preAccertamento ? q.eq("nphase", 1) : q.eq("nphase", 2));
            filter &= q.eq("ayear",testConn.Security.GetEsercizio());
            if (filterDetail != null) filter &= filterDetail;
            if (codiceConto!=null) {
                object idacc = testConn.readValue("account",
                    q.eq("codeacc", codiceConto) & q.eq("ayear", testConn.Security.GetEsercizio()), "idacc");
                if (idacc == null || idacc==DBNull.Value) return false;
                filter &= q.eq("idacc", idacc);
            }
            if (codiceUPB!=null) {
                object idupb = testConn.readValue("upb",
                    q.eq("codeupb", codiceUPB), "idupb");
                if (idupb == null || idupb==DBNull.Value) return false;
                filter &= q.eq("idupb", idupb);
            }
            if (codiceCausale != null) {
                object idAccMotive=testConn.readValue("accmotive",
                    q.eq("codemotive", codiceCausale), "idaccmotive");
                if (idAccMotive == null || idAccMotive==DBNull.Value) return false;
                filterDetail &= q.eq("idaccmotive", idAccMotive);
            }
            DataTable tEpAccView = testConn.readTable("epaccview", filter);
            if (tEpAccView.Rows.Count > 0) return true;
            return false;

        }
    }

    public class testResponder : DefaultResponder {
        public List<string> messagesReceived = new List<string>();
        public List<DialogResult> responsesToGive = new List<DialogResult>();
        public override bool getResponse(IWin32Window ctrl,string text, string caption,  out DialogResult result) {
            messagesReceived.Add(text);
            if (responsesToGive.Count > 0) {
                result = responsesToGive[0];
                responsesToGive.RemoveAt(0);
                return true;
            }

            result = DialogResult.Cancel;
            return false;

        }

        public override bool getResponse(IWin32Window ctrl, string text, string caption, MessageBoxButtons btns, out DialogResult result) {
            messagesReceived.Add(text);
            if (responsesToGive.Count > 0) {
                result = responsesToGive[0];
                responsesToGive.RemoveAt(0);
                return true;
            }

            result = DialogResult.Cancel;
            return false;
        }
    }
}
