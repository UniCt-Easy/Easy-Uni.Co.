/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using metadatalibrary;
using System.Collections;
using System.Globalization;
using funzioni_configurazione;
using System.Security;

namespace avcptrasmission_default {
    public partial class FrmNoTable_AvcpTrasmission : Form {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        DataAccess Conn;

        public void AzzeraAvvisi() {
            listaErrori.Clear();            
        }
        public void VisualizzaAvvisi() {
            StringBuilder sb = new StringBuilder();
            foreach (string m in listaErrori) {
                sb.AppendLine(m);
            }
            txtAvvisi.Text = sb.ToString();
            if (listaErrori.Count > 0) {
                tabMain.SelectedTab = tabAvvisi;
            }
        }
        public void AddAvviso(string message) {
            listaErrori.Add(message);
        }

        public FrmNoTable_AvcpTrasmission() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.SearchEnabled = false;
            Conn=Meta.Conn;

            string filteresercizio = QHS.CmpEq("annoRiferimento", Meta.GetSys("esercizio"));

            int numrighe = Meta.Conn.RUN_SELECT_COUNT("avcptrasmission", filteresercizio, true);
            if (numrighe == 1) {
                CanGoInsert = false;
                CanGoEdit = true;
            }
            else {
                CanGoInsert = true;
                CanGoEdit = false;
            }
            GetData.SetStaticFilter(DS.avcptrasmission, filteresercizio);

            DataTable avcp_choice = Conn.RUN_SELECT("avcpchoice", "*", null, null, null, false);
            foreach (DataRow r in avcp_choice.Rows) avcpchoice[r["idavcp_choice"].ToString()] = r["idavcp_choice"].ToString()+"-"+r["description"].ToString();
            DataTable avcp_role = Conn.RUN_SELECT("avcprole", "*", null, null, null, false);
            foreach (DataRow r in avcp_role.Rows) avcprole[r["idavcp_role"].ToString()] = r["idavcp_role"].ToString()+"-"+r["description"].ToString();

            envelopeSize = openmain.Length + closemain.Length + opendata.Length + closedata.Length + htmlpref.Length;
        }
        bool CanGoEdit;
        bool CanGoInsert;

        public void MetaData_AfterClear() {
            if (CanGoInsert) {
                CanGoInsert = false;
                MetaData.DoMainCommand(this, "maininsert");
            }
            if (CanGoEdit) {
                CanGoEdit = false;
                MetaData.DoMainCommand(this, "maindosearch.default"); //edyttype associato
            }

        }

        public void MetaData_AfterFill() {
        }

        void generaXml(DataRow rAvcp,string filedir) {
            AzzeraAvvisi();
            int esercizio= CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            string header = getMetaDataSection(rAvcp);
            List<string> lotti = new List<string>();
           

            DataTable tLotti = Conn.RUN_SELECT("mandatecig", "*", null, QHS.CmpEq("yman", esercizio), null, false);
            DataTable tLottiProf = Conn.RUN_SELECT("profservicecig", "*", null, QHS.CmpEq("ycon", esercizio), null, false);

            foreach (DataRow r in tLotti.Select()) {
                //Salta i lotti di importo 0 collegati solo a dettagli  annullati
                if (CfgFn.GetNoNullDecimal(r["contractamount"]) == 0) {
                    if (Conn.RUN_SELECT_COUNT("mandatedetail",
                            QHS.AppAnd(QHS.IsNull("stop"), QHS.MCmp(r, "idmankind", "yman", "nman", "cigcode")), false) == 0)
                        r.Delete();
                        continue;
                }
                lotti.Add(GetLotto(rAvcp, r));
            }
            tLotti.AcceptChanges();

            foreach (DataRow r in tLottiProf.Select()) {
                //Salta i lotti di importo 0 
                if (CfgFn.GetNoNullDecimal(r["contractamount"]) == 0) {
                        r.Delete();
                    continue;
                }
                lotti.Add(GetLottoProf(rAvcp, r));
            }
            tLottiProf.AcceptChanges();

            int nlotti = tLotti.Rows.Count + tLottiProf.Rows.Count;
            MessageBox.Show("Lotti trovati:" + nlotti, "Avviso");
            if (nlotti == 0) {
                VisualizzaAvvisi();
                return;
            }

            int empty_size = header.Length+envelopeSize;
            int limitSize= maxDsSize-empty_size;

            List<StringBuilder> allDataSet = new List<StringBuilder>();
            StringBuilder currDS = new StringBuilder();            
            foreach (string lotto in lotti) {
                if (currDS.Length + lotto.Length > limitSize) {
                    allDataSet.Add(currDS);
                    currDS = new StringBuilder();  
                }
                currDS.Append(lotto);
            }
            

            if (allDataSet.Count == 0) {
                string filename = filedir + getSimpleDataFilename(0);
                StringBuilder s=getDataFile(header,currDS);
                writeStringToFile(filename, s.ToString());
                MessageBox.Show("Creato il file " + filename, "Avviso");
                VisualizzaAvvisi();
                return;
            }
            
            allDataSet.Add(currDS);
            StringBuilder main = getIndexFile(rAvcp, allDataSet.Count);
            string indexname = filedir + getSimpleIndexName;
            writeStringToFile(indexname, main.ToString());

            for (int i = 0; i < allDataSet.Count; i++) {
                int num = i + 1;
                string newhead = Renumber(header, 0, num, rAvcp);
                StringBuilder d = getDataFile(newhead, allDataSet[i]);
                string fdataName = filedir + getSimpleDataFilename(num);
                writeStringToFile(fdataName, d.ToString());
            }
            MessageBox.Show("Creati i file: " + getSimpleIndexName + " e " + getSimpleDataFilename(1) +
                  " - " + getSimpleDataFilename(allDataSet.Count) + " nella cartella " +
                  filedir, "Avviso");
            VisualizzaAvvisi();

        }

        string getIndexMetaDataSection(DataRow rAvcp) {
            StringBuilder s = new StringBuilder();
            foreach (string f in new string[] {"titolo","abstract"}) {
                AddTaggedContent(s, f, format(rAvcp[f]));
            }
            AddTaggedContent(s, "dataPubblicazioneIndice", format(rAvcp["dataPubbicazioneDataset"]));
            AddTaggedContent(s, "entePubblicatore", format(rAvcp["entePubblicatore"]));
            AddTaggedContent(s, "dataUltimoAggiornamentoIndice", format(rAvcp["dataUltimoAggiornamentoDataset"]));
            AddTaggedContent(s, "annoRiferimento", format(rAvcp["annoRiferimento"]));
            AddTaggedContent(s, "urlFile", getIndexFilename(rAvcp));
            AddTaggedContent(s, "licenza", format(rAvcp["licenza"]));
            SurroundWithTag(s, "metadata");
            return s.ToString();
        }

        StringBuilder getIndexFile(DataRow rAvcp, int nDs) {
            StringBuilder s = new StringBuilder();
            s.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            s.Append("<?xml-stylesheet type=\"text/xsl\" href=\"xslt_datasetAppaltiL190.xslt\"?>");
            s.Append("<indici xsi:noNamespaceSchemaLocation=\"datasetIndiceAppaltiL190.xsd\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
            s.Append(getIndexMetaDataSection(rAvcp));
            s.Append("<indice>");
            for(int i=1;i<=nDs;i++){
                s.Append("<dataset id=\"ID_"+i.ToString()+"\">");
                AddTaggedContent(s,"linkDataset",getDataFilename(rAvcp,i));
                AddTaggedContent(s, "dataUltimoAggiornamento", format(rAvcp["dataUltimoAggiornamentoDataset"]));
                s.Append("</dataset>");
            }

            s.Append("</indice>");
            s.Append("</indici>");
            return s;

        }


        StringBuilder getDataFile(string head, StringBuilder body) {
            StringBuilder s = new StringBuilder();
            s.Append(htmlpref);
            s.Append(openmain);
            s.Append(head);
            s.Append(opendata);
            s.Append(body.ToString());
            s.Append(closedata);
            s.Append(closemain);
            return s;
        }
        List<string> listaErrori = new List<string>();

        private void btnGenera_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.avcptrasmission.Rows[0];
            if(!Meta.GetFormData(false))return;
            if (folderAsk.ShowDialog(this) != DialogResult.OK) return;
            string fdir = folderAsk.SelectedPath;
            if (!fdir.EndsWith("\\")) fdir += "\\";
            generaXml(curr, fdir);
            Meta.SaveFormData();
        }


        const string htmlpref = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";
         const string openmain=   "<legge190:pubblicazione xsi:schemaLocation=\"legge190_1_0 datasetAppaltiL190.xsd\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:legge190=\"legge190_1_0\">";
         const string closemain = "</legge190:pubblicazione>\r\n";
         const string opendata = "<data>";
         const string closedata = "</data>\r\n";
         int envelopeSize;
         const int maxDsSize = 5 * 1024 * 1024 - 100000;

        string getTaggedContent(string tag, string content) {
            return "<" + tag + ">" +  content + "</" + tag + ">\r\n";
        }
        void AddTaggedContent(StringBuilder sb, string tag, string content) {
            if (content == "" ||content==null) return;
            sb.Append(getTaggedContent(tag,content));
        }
        void SurroundWithTag(StringBuilder sb, string tag){
            sb.Insert(0, "<" + tag + ">");
            sb.AppendLine("</" + tag + ">");
        }
        string FormatData(DateTime Data) {
            return Data.Year.ToString() +"-"+ Data.Month.ToString().PadLeft(2, '0') +"-"+ Data.Day.ToString().PadLeft(2, '0');
        }
        string FormatDecimal(Decimal d) {
            return d.ToString("F2", CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Formatta un oggetto secondo lo stanard avcp
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        string format(object o) {
            if (o == null || o == DBNull.Value) return "";
            if (o.GetType() == typeof(DateTime)) return SecurityElement.Escape(FormatData((DateTime)o));
            if (o.GetType() == typeof(Decimal)) return SecurityElement.Escape(FormatDecimal((Decimal)o));
            return SecurityElement.Escape(o.ToString());
        }

        /// <summary>
        /// Restituisce il nome dell'indice avcp per trasmissioni multi file
        /// </summary>
        /// <param name="rAvcp"></param>
        /// <returns></returns>
        string getIndexFilename(DataRow rAvcp) {
            string pref = rAvcp["baseUrl"].ToString();
            if (!pref.EndsWith("/"))pref+="/";
            pref += getSimpleIndexName;
            return pref;
        }

        /// <summary>
        /// Restituisce il nome di un file dati per una trasm. singola (index=0) o multifile 
        /// </summary>
        /// <param name="rAvcp"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        string getDataFilename(DataRow rAvcp,int index) {
            string pref = rAvcp["baseUrl"].ToString();
            if (!pref.EndsWith("/")) pref += "/";
            pref += getSimpleDataFilename(index);
            return pref;
        }

        const string getSimpleIndexName = "dataindex.xml";

        string getSimpleDataFilename( int index) {
            string pref = "data_";
            if (index > 0)
                pref += index.ToString().PadLeft(4, '0');
            else
                pref += "avcp";
            pref += ".xml";
            return pref;
        }

        /// <summary>
        /// Restituisce la  sezione metadata compilata per un dataset singolo
        /// </summary>
        /// <param name="rAvcp"></param>
        string getMetaDataSection(DataRow rAvcp) {
            StringBuilder s = new StringBuilder();
            foreach (string f in new string[] { "titolo", "abstract" }) {
                AddTaggedContent(s, f, format(rAvcp[f]));
            }
            AddTaggedContent(s, "dataPubbicazioneDataset", format(rAvcp["dataPubbicazioneDataset"]));
            AddTaggedContent(s, "entePubblicatore", format(rAvcp["entePubblicatore"]));
            AddTaggedContent(s, "dataUltimoAggiornamentoDataset", format(rAvcp["dataUltimoAggiornamentoDataset"]));
            AddTaggedContent(s, "annoRiferimento", format(rAvcp["annoRiferimento"]));
            AddTaggedContent(s, "urlFile", getDataFilename(rAvcp, 0));
            AddTaggedContent(s, "licenza", format(rAvcp["licenza"]));
            SurroundWithTag(s, "metadata");
            return s.ToString();
        }
        string Renumber(string header, int oldindex, int newindex, DataRow rAvcp) {
            string old = getDataFilename(rAvcp, oldindex);
            string new_ = getDataFilename(rAvcp, newindex);
            return header.Replace(old, new_);
        }


        void writeStringToFile(string fname, string content) {
            File.WriteAllText(fname,content);            
        }

        
        string getStrutturaProponente(DataRow rAvcp) {
            StringBuilder s = new StringBuilder();
            AddTaggedContent(s,"codiceFiscaleProp",format(rAvcp["codiceFiscaleProp"]));
            AddTaggedContent(s, "denominazione",format( rAvcp["denominazione"]));
            SurroundWithTag(s, "strutturaProponente");
            return s.ToString();

        }

        Dictionary<string, string> avcpchoice = new Dictionary<string, string>();
        string getSceltaContraente(object idavcp_choice) {
            if(avcpchoice.ContainsKey(idavcp_choice.ToString())) return avcpchoice[idavcp_choice.ToString()];
            return "";
        }
        Dictionary<string, string> avcprole = new Dictionary<string, string>();
        string getRuolo(object idavcp_role) {
            if (avcprole.ContainsKey(idavcp_role.ToString())) return avcprole[idavcp_role.ToString()];
            return "";
        }

        
        /// <summary>
        /// restituisce l'xml di un lotto data una riga di mandatecig
        /// </summary>
        /// <param name="rManCig"></param>
        /// <returns></returns>
        string GetLotto(DataRow rAvcp, DataRow rManCig) {
            object cigcode = rManCig["cigcode"];
            DataTable Partecipanti = Conn.SQLRunner(
                    "select a.* from mandateavcp a "+
                    "join mandateavcpdetail d "
                    + " on a.idmankind=d.idmankind and a.yman=d.yman and a.nman=d.nman "
                    + "and isnull(a.idmain_avcp,a.idavcp)=d.idavcp " +       //10256 tutto il gruppo è da considerarsi in blocco
                    " where " + QHS.AppAnd(QHS.CmpEq("d.idmankind", rManCig["idmankind"]),
                                    QHS.CmpEq("d.yman", rManCig["yman"]),
                                    QHS.CmpEq("d.nman", rManCig["nman"]),
                                    QHS.CmpEq("d.cigcode", cigcode)), false);

            StringBuilder s = new StringBuilder();
            AddTaggedContent(s, "cig", cigcode.ToString());
            s.Append(getStrutturaProponente(rAvcp));
            AddTaggedContent(s, "oggetto", format(rManCig["description"]));
            AddTaggedContent(s, "sceltaContraente", format(getSceltaContraente(rManCig["idavcp_choice"])));
            s.Append(getListaPartecipanti(rManCig, Partecipanti));
            s.Append(getListaAggiudicatari(rManCig, Partecipanti));
            AddTaggedContent(s, "importoAggiudicazione", format(rManCig["contractamount"]));
            s.Append(getTempiCompletamento(rManCig));
            AddTaggedContent(s, "importoSommeLiquidate", format(getTotaleLiquidato(rManCig)));

            SurroundWithTag(s, "lotto"); 
            return s.ToString();
        }

        string GetLottoProf(DataRow rAvcp, DataRow rProfCig) {
            object cigcode = rProfCig["cigcode"];
            DataTable Partecipanti = Conn.SQLRunner(
                    "select a.* from profserviceavcp a " +
                    "join profserviceavcpdetail d "
                    + " on a.ycon = d.ycon and a.ncon = d.ncon "
                    + "and isnull(a.idmain_avcp,a.idavcp)=d.idavcp " +       //10256 tutto il gruppo è da considerarsi in blocco
                    " where " + QHS.AppAnd(QHS.CmpEq("d.ycon", rProfCig["ycon"]),
                                    QHS.CmpEq("d.ncon", rProfCig["ncon"]),
                                    QHS.CmpEq("d.cigcode", cigcode)), false);

            StringBuilder s = new StringBuilder();
            AddTaggedContent(s, "cig", cigcode.ToString());
            s.Append(getStrutturaProponente(rAvcp));
            AddTaggedContent(s, "oggetto", format(rProfCig["description"]));
            AddTaggedContent(s, "sceltaContraente", format(getSceltaContraente(rProfCig["idavcp_choice"])));
            s.Append(getListaPartecipanti(rProfCig, Partecipanti));
            s.Append(getListaAggiudicatari(rProfCig, Partecipanti));
            AddTaggedContent(s, "importoAggiudicazione", format(rProfCig["contractamount"]));
            s.Append(getTempiCompletamento(rProfCig));
            AddTaggedContent(s, "importoSommeLiquidate", format(getTotaleLiquidatoProf(rProfCig)));

            SurroundWithTag(s, "lotto");
            return s.ToString();
        }
        string getPartecipanteoMembro(DataRow rMandateAvcp,string envelope) {
            StringBuilder s = new StringBuilder();
            AddTaggedContent(s, "codiceFiscale", format(rMandateAvcp["cf"]));
            if (rMandateAvcp["cf"].ToString().Trim() == "") {
                AddTaggedContent(s, "identificativoFiscaleEstero", format(rMandateAvcp["foreigncf"]));
            }
            AddTaggedContent(s, "ragioneSociale", format(rMandateAvcp["title"]));
            if (rMandateAvcp["idavcp_role"] != DBNull.Value) {
                AddTaggedContent(s, "ruolo", format(getRuolo(rMandateAvcp["idavcp_role"])));
            }
            SurroundWithTag(s, envelope);
            return s.ToString();
        }

        string getListaPartecipanti(DataRow rManCig, DataTable Partecipanti) {
            StringBuilder s = new StringBuilder();
            //mette prima i raggruppamenti
            foreach (DataRow capo in Partecipanti.Select(QHC.CmpEq("idavcp_role", "04"))) {
                StringBuilder t = new StringBuilder();
                t.Append(getPartecipanteoMembro(capo,"membro"));
                foreach (DataRow membro in Partecipanti.Select(
                    QHC.AppAnd(     QHC.CmpEq("idmain_avcp", capo["idavcp"]),
                                    QHC.CmpNe("idavcp",capo["idavcp"]))  
                    )) {
                        t.Append(getPartecipanteoMembro(membro, "membro"));
                }
                SurroundWithTag(t, "raggruppamento");
                s.Append(t.ToString());
            }
            foreach (DataRow singolo in Partecipanti.Select(QHC.IsNull("idavcp_role"))) {
                s.Append(getPartecipanteoMembro(singolo, "partecipante"));
            }
            SurroundWithTag(s,"partecipanti");
            return s.ToString();
        }
        string getListaAggiudicatari(DataRow rManCig, DataTable Partecipanti) {
            StringBuilder s = new StringBuilder();
            //Stabilisce chi è l'aggiudicatario
            object idavcp = rManCig["idavcp"];
            DataRow []found = Partecipanti.Select(QHC.CmpEq("idavcp", idavcp));
            if (found.Length == 0) {
                AddAvviso("Errore nei dati, partecipante di id " + idavcp.ToString() + " non associato al lotto " + rManCig["cigcode"].ToString());
            }
            else {
                DataRow capo = found[0];
                if (capo["idavcp_role"] == DBNull.Value) {
                    s.Append(getPartecipanteoMembro(capo, "aggiudicatario"));
                }
                else {
                    StringBuilder t = new StringBuilder();
                    t.Append(getPartecipanteoMembro(capo, "membro"));
                    foreach (DataRow membro in Partecipanti.Select(
                        QHC.AppAnd(QHC.CmpEq("idmain_avcp", capo["idavcp"]),
                                        QHC.CmpNe("idavcp", capo["idavcp"]))
                        )) {
                        t.Append(getPartecipanteoMembro(membro, "membro"));
                    }
                    SurroundWithTag(t, "aggiudicatarioRaggruppamento");
                    s.Append(t.ToString());
                }
            }

            SurroundWithTag(s, "aggiudicatari");
            return s.ToString();
        }
        string getTempiCompletamento(DataRow rManCig) {
              StringBuilder s = new StringBuilder();
              AddTaggedContent(s, "dataInizio", format(rManCig["start_contract"]));
              AddTaggedContent(s, "dataUltimazione", format(rManCig["stop_contract"])); 
            SurroundWithTag(s, "tempiCompletamento");
            return s.ToString();
            
        }
        Decimal getTotaleLiquidato(DataRow rManCig) {
            decimal tot = 0;
            String MyQuery =
            " SELECT distinct idexp_taxable " +
            " FROM mandatedetail " +
            " where " + QHS.AppAnd(QHS.CmpEq("idmankind", rManCig["idmankind"]), QHS.CmpEq("yman", rManCig["yman"]), QHS.CmpEq("nman", rManCig["nman"]),
            QHS.CmpEq("cigcode", rManCig["cigcode"]), QHS.IsNotNull("idexp_taxable"));
            DataTable tImpegni = Meta.Conn.SQLRunner(MyQuery);
            object esercizio = Meta.GetSys("esercizio");
            foreach (DataRow R in tImpegni.Rows) {
                // A : importo corrente degli impegni che contabilizzano i dettagli in questione
                object ImportoImpegnato = Meta.Conn.DO_READ_VALUE("expenseview",
                    QHS.AppAnd(QHS.CmpEq("ayear", rManCig["yman"]), QHS.CmpEq("idexp", R["idexp_taxable"])), "curramount");
                string FilterDettcontabilizzati = QHS.AppAnd(QHS.CmpEq("idmankind", rManCig["idmankind"]), QHS.CmpEq("yman", rManCig["yman"]), QHS.CmpEq("nman", rManCig["nman"]),
                        QHS.CmpEq("cigcode", rManCig["cigcode"]), QHS.CmpEq("idexp_taxable", R["idexp_taxable"]));
                // B : imponibile di tutti i dettagli che finiscono in tali impegni
                object ImponibileOrdine = Meta.Conn.DO_READ_VALUE("mandatedetailview", FilterDettcontabilizzati, "sum(taxable_euro)");
                // C : Pagato per il singolo impegno
                object QuotaPagata = PagatoDelSingoloImpegno(R["idexp_taxable"]);
                if (CfgFn.GetNoNullDecimal(ImportoImpegnato) > 0) {
                    tot = tot + (CfgFn.GetNoNullDecimal(QuotaPagata) * CfgFn.GetNoNullDecimal(ImponibileOrdine) / CfgFn.GetNoNullDecimal(ImportoImpegnato));
                }
                }
            return tot;
        }

        Decimal getTotaleLiquidatoProf(DataRow rManCig) {
            decimal tot = 0;
            String MyQuery =
            " SELECT distinct EP.idexp " +
            " FROM expenseprofservice EP" +
            " join expense E "+
            " on E.idexp = EP.idexp "+
            " where " + QHS.AppAnd(QHS.CmpEq("EP.ycon", rManCig["ycon"]), QHS.CmpEq("EP.ncon", rManCig["ncon"]),
            QHS.CmpEq("E.cigcode", rManCig["cigcode"]));
            DataTable tImpegni = Meta.Conn.SQLRunner(MyQuery);
            object esercizio = Meta.GetSys("esercizio");
            foreach (DataRow R in tImpegni.Rows) {
                // A : importo corrente degli impegni che contabilizzano il contratto in questione
                object ImportoImpegnato = Meta.Conn.DO_READ_VALUE("expenseview",
                    QHS.AppAnd(QHS.CmpEq("ayear", rManCig["ycon"]), QHS.CmpEq("idexp", R["idexp"])), "curramount");
                string Filtercontabilizzati = QHS.AppAnd(QHS.CmpEq("ycon", rManCig["ycon"]), QHS.CmpEq("ncon", rManCig["ncon"]),
                        QHS.CmpEq("cigcode", rManCig["cigcode"]));
                // B : imponibile di tutti i dettagli che finiscono in tali impegni
                object ImponibileContratto = Meta.Conn.DO_READ_VALUE("profservicecig", Filtercontabilizzati, "contractamount");
                // C : Pagato per il singolo impegno
                object QuotaPagata = PagatoDelSingoloImpegno(R["idexp"]);
                if (CfgFn.GetNoNullDecimal(ImportoImpegnato) > 0) {
                    tot = tot + (CfgFn.GetNoNullDecimal(QuotaPagata) * CfgFn.GetNoNullDecimal(ImponibileContratto) / CfgFn.GetNoNullDecimal(ImportoImpegnato));
                }
            }
            return tot;
        }
        decimal PagatoDelSingoloImpegno(object idexp) {
        decimal Pagato = 0;
            object esercizio = Meta.GetSys("esercizio");
            string MyQuery =
                " select isnull(sum(ET.curramount),0) as curramount" +
                " from expense E " +
                " 	JOIN expenselink ELK " +
                " 		ON ELK.idparent = E.idexp  " +
                " 	JOIN expenselast EL " +
                " 		on  ELK.idchild = EL.idexp " +
                " 	join expensetotal ET " +
                " 		ON ET.idexp = EL.idexp " +
                " WHERE  " + QHS.CmpEq("E.idexp", idexp);
            DataTable tPagato = Meta.Conn.SQLRunner(MyQuery);
            if ((tPagato != null) && (tPagato.Rows.Count > 0)) {
            Pagato = CfgFn.GetNoNullDecimal(tPagato.Rows[0]["curramount"]);
                }
            return Pagato;
            }


    }
}
