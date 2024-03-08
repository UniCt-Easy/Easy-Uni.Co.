
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
using System.Collections.Generic;
using System.Data;
using System.IO;
using metadatalibrary;
using metaeasylibrary;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Xml;
using System.Xml.Xsl;

namespace funzioni_configurazione {
    public class AttachmentsManager {

        //enum dei tipi di documento
        public enum DocType { 
            estimate, 
            mandate, 
            invoicebuy, 
            invoicesell, 
            itineration,
            itinerationrefund
        }

        //dizionario che associa al tipo di documento la chiave della tabella degli attachments
        public static readonly Dictionary<DocType, string[]> ViewKeysLookupDict = new Dictionary<DocType, string[]> {
            {DocType.estimate, new [] { "idestimkind", "yestim", "nestim", "idattachment" } },
            {DocType.mandate, new [] { "idmankind", "yman", "nman", "idattachment" } },
            {DocType.invoicebuy, new [] { "idinvkind", "yinv", "ninv", "idattachment" } },
            {DocType.invoicesell, new [] { "idinvkind", "yinv", "ninv", "idattachment" } },
            {DocType.itineration, new [] { "iditineration", "idattachment" } },
            {DocType.itinerationrefund, new [] { "iditineration", "nrefund", "idattachment" } } 
        };

        //dizionario che associa al tipo di documento il prefisso da usare nei nomi dei file
        private static readonly Dictionary<DocType, string> FilePrefixLookupDict = new Dictionary<DocType, string> {
            {DocType.estimate, "ca_all"},
            {DocType.mandate, "cp_all"},
            {DocType.invoicebuy, "fatt_all"},
            {DocType.invoicesell, "fatt_all"},
            {DocType.itineration, "miss_all"},
            {DocType.itinerationrefund, "miss_spesa_all"}
        };

        //tipo di documento gestito dal manager
        private DocType docType;

        //tabella dei contenuti dei file allegati
        private DataTable attachmentsTable;

        private DataAccess Conn;
        private DataTable filteredView;

        private string viewName;
        private string viewFilter;

        private string dstDir;

        //tablename lo recuperiamo da viewname(dal nome che assegnamo alla vista)
        public AttachmentsManager(DataAccess _conn, DocType _docType, string _dstDir, string _viewName = null, string _viewFilter = null) {

            Conn = _conn;
            docType = _docType;

            dstDir = _dstDir;

            viewName = _viewName ?? _docType.ToString() + "attachmentview";
            viewFilter = _viewFilter;

            attachmentsTable = new DataTable();

            fillFilteredView();
            fillAttachmentsTable();
        }
        public AttachmentsManager(DataAccess _conn, string _dstDir) {

            Conn = _conn;
            dstDir = _dstDir;

            attachmentsTable = new DataTable();
        }
        private void fillFilteredView() {
            filteredView = Conn.RUN_SELECT(viewName, "*", null, viewFilter, null, false);
        }

        private void fillAttachmentsTable() {
            string attachmentsTablename;

            switch (docType) {
                case DocType.invoicebuy:
                case DocType.invoicesell:
                    attachmentsTablename = "invoiceattachment";
                    break;
                default:
                    attachmentsTablename = docType.ToString() + "attachment";
                    break;
            }

            QueryHelper qHelper = Conn.GetQueryHelper();

            string[] keyFields = ViewKeysLookupDict[docType];
            string[] andParameters = new string[keyFields.Length];


            foreach (DataRow filteredViewRow in filteredView.Select()) {

                //creazione parametri da mettere in AND
                keyFields._forEach((fieldName, paramsIndex) => { andParameters[paramsIndex] = qHelper.CmpEq(fieldName, filteredViewRow[fieldName]); });

                //creazione filtro per interrogare la tabella degli attachment su db
                string attachmentsFilter = qHelper.AppAnd(andParameters);

                DataTable temp = Conn.RUN_SELECT(attachmentsTablename, "*", null, attachmentsFilter, null, false);
          
                attachmentsTable.Merge(temp);
            }
        }

        private void saveFile(string fileName, byte[] fileContents) {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            if (fileContents.Length == 0) return;
            try {
                fileStream.Write(fileContents, 0, fileContents.Length);
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static DataTable createStampaReversaleTable() {
            var myPrimaryTable = new DataTable("export_payment");
            //Create a dummy primary key
            var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
            myPrimaryTable.Columns.Add(dcpk);
            myPrimaryTable.PrimaryKey = new[] { dcpk };

            DataColumn column;
            myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("printkind", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("startnpro", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("stopnpro", typeof(int)));

            myPrimaryTable.Columns.Add(new DataColumn("printdate", typeof(DateTime)));
            myPrimaryTable.Columns.Add(new DataColumn("official", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("oneprint", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("idtreasurer", typeof(int)));

            var r = myPrimaryTable.NewRow();
            myPrimaryTable.Rows.Add(r);
            return myPrimaryTable;
        }
        public static DataTable createStampaMandatoTable() {
            var myPrimaryTable = new DataTable("export_payment");
            //Create a dummy primary key
            var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
            myPrimaryTable.Columns.Add(dcpk);
            myPrimaryTable.PrimaryKey = new[] { dcpk };

            DataColumn column;
            myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("printkind", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("startnpay", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("stopnpay", typeof(int)));

            myPrimaryTable.Columns.Add(new DataColumn("printdate", typeof(DateTime)));
            myPrimaryTable.Columns.Add(new DataColumn("official", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("oneprint", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("idtreasurer", typeof(int)));
            column = new DataColumn("nota", typeof(string));
            column.AllowDBNull = true;
            myPrimaryTable.Columns.Add(column);

            var r = myPrimaryTable.NewRow();
            myPrimaryTable.Rows.Add(r);
            return myPrimaryTable;
        }
        public static bool exportToPdf(ReportDocument rd, string fileName, string relativePath, out string error) {
            error = "";
            var tempfilename = relativePath + fileName;

            rd.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            rd.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions { DiskFileName = tempfilename };
            rd.ExportOptions.DestinationOptions = diskOpts;

            // Export the report
            try {
                rd.Export();
                bool existfile = File.Exists(tempfilename);
                if (!existfile) error = "export fallito";
                return existfile;
            }
            catch (Exception e) {
                if (!e.ToString().Contains("0x8000030E")) {
                    error =
                        "E' necessario disinstallare l'aggiornamento di windows KB3102429 per poter effettuare la stampa. - " +
                        e.Message;
                    return false;
                }
                error = e.Message;
                return false;
            }
        }

        public bool stampaFatturaFEvendita(DataAccess Conn, string FilePath, DataRow Rsdi_venditaext, out string errmess) {
            errmess = "";
            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            string tempFileName = "fevendita_" + Rsdi_venditaext["idsdi_vendita"].ToString() + ".htm";
            //Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";

            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Rsdi_venditaext["xml"].ToString());
            string versione = doc.DocumentElement.Attributes["versione"].Value;
            DateTime dataCont = (DateTime)Conn.GetSys("datacontabile");
            DateTime dataOttobre2020 = new DateTime(2020, 10, 1);
            string xsl = "";
            bool isPA = Rsdi_venditaext["ipa_ven_cliente"].ToString().Length == 6;
            
            try {
                if (dataCont != null && dataCont > dataOttobre2020) {
                    //PRENDO I NUOVI FILE XSLT CHE VANNO IN VIGORE DAL 1/10/2020
                    string xslNew = isPA ? "fatturapa_v1.2.1.xslt" : "fatturaordinaria_v1.2.1.xslt";
                    xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : xslNew;
                    XslCompiledTransform xsltransform = new XslCompiledTransform();
                    xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + xsl);
                    xsltransform.Transform(doc, null, xw);
                    xw.Flush();
                    xw.Close();
                    if (File.Exists(FilePath + tempFileName)) {
                        File.Delete(FilePath + tempFileName);
                    }
                    File.Move(AppDomain.CurrentDomain.BaseDirectory + tempFileName, FilePath + tempFileName);
                }
                else {
                    string xslNew = isPA ? "fatturapa_v1.2.xslt" : "fatturaordinaria_v1.2.xslt";
                    xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : xslNew;

                    XslCompiledTransform xsltransform = new XslCompiledTransform();
                    xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + xsl);

                    xsltransform.Transform(doc, null, xw);
                    xw.Flush();
                    xw.Close();
                    if (File.Exists(FilePath + tempFileName)) {
                        File.Delete(FilePath + tempFileName);
                    }

                    File.Move(AppDomain.CurrentDomain.BaseDirectory + tempFileName, FilePath + tempFileName);
                }
            }
            catch (Exception ee) {
                errmess = "Errore nella creazione del file FE " + ee;
                return false;
            }
            return true;
        }

        public void writeToFile(string fileName, XmlDocument doc) {
            if (doc != null) {
                doc.Save(fileName);
            }
        }
        public bool stampaXML_FEacquisto(DataAccess Conn, string FilePath, DataRow Rsdi_acquisto, out string errmess) {
            errmess = "";
            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            string tempFileName = "feacquisto_xml_" + Rsdi_acquisto["idsdi_acquisto"].ToString() + ".xml";

            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Rsdi_acquisto["xml"].ToString());
            try {
                if (doc != null) {
                    string nomeFileXml = Path.Combine(FilePath, tempFileName);
                    if (File.Exists(nomeFileXml)) {
                        File.Delete(nomeFileXml);
                    }
                    writeToFile(nomeFileXml, doc);
                  
                }
            }
            catch (Exception ee) {
                errmess = "Errore nella creazione del file FE " + ee;
                return false;
            }
            return true;
        }

        public bool stampaXML_FEvendita(DataAccess Conn, string FilePath, DataRow Rsdi_vendita, out string errmess) {
            errmess = "";
            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            string tempFileName = "fevendita_xml_" + Rsdi_vendita["idsdi_vendita"].ToString() + ".xml";

            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Rsdi_vendita["xml"].ToString());
            try {
                if (doc != null) {
                    string nomeFileXml = Path.Combine(FilePath, tempFileName);
                    if (File.Exists(nomeFileXml)) {
                        File.Delete(nomeFileXml);
                    }
                    writeToFile(nomeFileXml, doc);

                }
            }
            catch (Exception ee) {
                errmess = "Errore nella creazione del file FE " + ee;
                return false;
            }
            return true;
        }
        public bool stampaFatturaFEacquisto(DataAccess Conn, string FilePath, DataRow Rsdi_acquisto, out string errmess) {
            errmess = "";
            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            string tempFileName = "feacquisto_" + Rsdi_acquisto["idsdi_acquisto"].ToString()+ ".htm";
             //Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";

            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Rsdi_acquisto["xml"].ToString());
            string versione = doc.DocumentElement.Attributes["versione"].Value;
            string xsl;
            DateTime dataCont = (DateTime)Conn.GetSys("datacontabile");
            DateTime dataOttobre2020 = new DateTime(2020, 10, 1);

            if (dataCont != null && dataCont > dataOttobre2020) {
                xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : "fatturapa_v1.2.1.xslt";
            }
            else {
                xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : "fatturapa_v1.2.xslt";
            }

            try {
                XslCompiledTransform xsltransform = new XslCompiledTransform();
                xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + xsl);//FilePath + xsl

                xsltransform.Transform(doc, null, xw);
                xw.Flush();
                xw.Close();
                if (File.Exists(FilePath + tempFileName)) {
                    File.Delete(FilePath + tempFileName);
                }
                File.Move(AppDomain.CurrentDomain.BaseDirectory + tempFileName, FilePath+ tempFileName);
            }
            catch (Exception ee) {
                errmess= "Errore nella creazione del file FE " + ee;
                return false;
            }
            return true;
        }
        public bool stampaMandato(DataAccess Conn, string FilePath, DataRow curr,  out string errmess) {
            errmess = "";
            string ReportName = "mandato_pagamento";
            DataTable myPrymaryTable = createStampaMandatoTable();
            myPrymaryTable.Rows[0]["reportname"] = ReportName;

            myPrymaryTable.Rows[0]["ayear"] = Conn.GetSys("esercizio");
            myPrymaryTable.Rows[0]["printkind"] = "I";
            
            myPrymaryTable.Rows[0]["startnpay"] = CfgFn.GetNoNullInt32(curr["npay"]); 
            myPrymaryTable.Rows[0]["stopnpay"] = CfgFn.GetNoNullInt32(curr["npay"]);
            myPrymaryTable.Rows[0]["printdate"] = Conn.GetSys("datacontabile");
            myPrymaryTable.Rows[0]["official"] = "N";
            myPrymaryTable.Rows[0]["oneprint"] = "N";
            myPrymaryTable.Rows[0]["idtreasurer"] = CfgFn.GetNoNullInt32(curr["idtreasurer"]); ;
            myPrymaryTable.Rows[0]["nota"] = DBNull.Value ;

            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("reportname", ReportName);

            DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

            if (Report == null) {
                errmess = "Report: '" + ReportName + "' non trovato.";
                return false;
            }

            var rep = Report._First();
            var par = myPrymaryTable.Rows[0];

            ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
            if (myRptDoc == null) {
                if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
                return false;
            }

            if (!FilePath.EndsWith("\\")) FilePath += "\\";

            var tempfilename = "stampamandato_" + curr["ypay"].ToString() + "_" + curr["npay"].ToString() + ".pdf";
            //pdfFileName = @"ReportPDF/" + tempfilename;
            string error;
            bool retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
            if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
            return retExp;
        }

        public bool stampaReversale(DataAccess Conn, string FilePath, DataRow curr, out string errmess) {
            errmess = "";
            string ReportName = "reversale_incasso";
            DataTable myPrymaryTable = createStampaReversaleTable();
            myPrymaryTable.Rows[0]["reportname"] = ReportName;

            myPrymaryTable.Rows[0]["ayear"] = Conn.GetSys("esercizio");
            myPrymaryTable.Rows[0]["printkind"] = "I";

            myPrymaryTable.Rows[0]["startnpro"] = CfgFn.GetNoNullInt32(curr["npro"]);
            myPrymaryTable.Rows[0]["stopnpro"] = CfgFn.GetNoNullInt32(curr["npro"]);
            myPrymaryTable.Rows[0]["printdate"] = Conn.GetSys("datacontabile");
            myPrymaryTable.Rows[0]["official"] = "N";
            myPrymaryTable.Rows[0]["oneprint"] = "N";
            myPrymaryTable.Rows[0]["idtreasurer"] = CfgFn.GetNoNullInt32(curr["idtreasurer"]); ;

            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("reportname", ReportName);

            DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

            if (Report == null) {
                errmess = "Report: '" + ReportName + "' non trovato.";
                return false;
            }

            var rep = Report._First();
            var par = myPrymaryTable.Rows[0];

            ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
            if (myRptDoc == null) {
                if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
                return false;
            }

            if (!FilePath.EndsWith("\\")) FilePath += "\\";

            var tempfilename = "stampareversale_" + curr["ypro"].ToString() + "_" + curr["npro"].ToString() + ".pdf";
            //pdfFileName = @"ReportPDF/" + tempfilename;
            string error;
            bool retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
            if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
            return retExp;
        }

        public int saveAttachments() {
            int filesCount = 0;

            if (attachmentsTable.Rows.Count == 0) return filesCount;            

            if (!Directory.Exists(dstDir)) {
                Directory.CreateDirectory(dstDir);
            }

		    foreach (DataRow attachmentRow in attachmentsTable.Rows) {
                if (attachmentRow["attachment"] == DBNull.Value) continue;
                byte[] fileContents = (byte[])attachmentRow["attachment"];
				string fileName = attachmentRow["filename"].ToString();
				string dstPath = Path.Combine (dstDir, FilePrefixLookupDict[docType] + "_" + attachmentRow["idattachment"].ToString() + "_" + fileName);

				try {
					saveFile(dstPath, fileContents);
				} catch (Exception e) {
					QueryCreator.ShowException(e);
				}

				filesCount++;
			}

			return filesCount;
        }
    }
}

