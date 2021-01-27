
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace no_table_cud {
    public partial class FormCud : Form {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        NumberFormatInfo numberFormat = CultureInfo.GetCultureInfo(0x410).NumberFormat;

        public FormCud() {
            InitializeComponent();
        }

        private Type getTipo(DataRow r) {
            if (r["stringa"] != DBNull.Value) return typeof(string);
            if (r["intero"] != DBNull.Value) return typeof(int);
            if (r["data"] != DBNull.Value) return typeof(DateTime);
            if (r["decimale"] != DBNull.Value) return typeof(decimal);
            return null;
        }

        private object getValore(DataRow r) {
            if (r["stringa"] != DBNull.Value) return r["stringa"];
            if (r["intero"] != DBNull.Value) return r["intero"];
            if (r["data"] != DBNull.Value) return r["data"];
            if (r["decimale"] != DBNull.Value) return r["decimale"];
            return null;
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.SearchEnabled = false;
        }

        private void salvaColonnaDC017(SortedList ht, string dc017) {
            char c = 'a';
            for (int i = 0; i < 12; i++) {
                if ((dc017[i]=='1') && (ht["DC017" + c] == null)) {
                    ht["DC017" + c] = 'X';
                }
                c++;
            }
        }

        private void salvaColonnaDC016(SortedList ht, string dc016) {
            if (dc016 == "1") {
                ht["DC016"] = 'X';
            }
        }

        private void salvaColonnaDB003(SortedList ht, int db003) {
            object old = ht["DB003"];
            if (old == null) {
                ht["DB003"] = db003;
            }
            else {
                int numGiorni = ((int)old) + db003;
                if (numGiorni > 365) {
                    numGiorni = 365;
                }
                ht["DB003"] = numGiorni;
            }
        }

        private void salvaNormaleCampo(SortedList ht, string campo, DataRow rRecordG) {
            if (rRecordG["data"] != DBNull.Value) {
                DateTime data = (DateTime)rRecordG["data"];
                char[] c = new char[] { 'g', 'm', 'a' };
                int[] parte = new int[] { data.Day, data.Month, data.Year };
                for (int i=0; i<3; i++) {
                    string tag = campo + c[i];
                    object vecchio = ht[tag];
                    if (vecchio == null) {
                        ht[tag] = parte[i];
                    }
                    else {
                        if (!vecchio.Equals(parte[i])) {
                            ht.Remove(tag);
                            //MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Campo: " + tag + "\r\n" + vecchio + "\r\n" + getValore(rRecordG), "ERRORE");
                        }
                    }
                }
                return;
            }
            object old = ht[campo];
            if (old == null) {
                ht[campo] = getValore(rRecordG);
            }
            else {
                if (old is int) {
                    ht[campo] = ((int)old) + ((int)rRecordG["intero"]);
                } else
                if (old is decimal) {
                    ht[campo] = ((decimal)old) + ((decimal)rRecordG["decimale"]);
                }
                else {
                    if (!old.Equals(getValore(rRecordG))) {
                        ht.Remove(campo);
                        //MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Campo: " + campo + "\r\n" + old + "\r\n" + getValore(rRecordG), "ERRORE");
                    }
                }
            }
        }

        private XmlText createTextNode(XmlDocument doc, object valore) {
            if (valore is decimal) {
                decimal dec = (decimal)valore;
                return doc.CreateTextNode(((decimal)valore).ToString("n", numberFormat));
            }
            return doc.CreateTextNode(valore.ToString());
        }

        private void stampaXml(SortedList ht, string commento) {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", ""));
            doc.AppendChild(doc.CreateComment(commento));
            doc.AppendChild(doc.CreateProcessingInstruction("xfa", "generator=\"XFA2_4\" APIVersion=\"2.6.7120.0\""));
            XmlNode xdp = doc.AppendChild(doc.CreateElement("xdp", "xdp", "http://ns.adobe.com/xdp/"));
            XmlNode datasets = xdp.AppendChild(doc.CreateElement("xfa", "datasets", "http://www.xfa.org/schema/xfa-data/1.0/"));
            XmlNode data = datasets.AppendChild(doc.CreateElement("xfa", "data", "http://www.xfa.org/schema/xfa-data/1.0/"));
            XmlNode topmostSubform = data.AppendChild(doc.CreateElement("topmostSubform"));
            foreach (DictionaryEntry de in ht) {
                XmlNode campo = topmostSubform.AppendChild(doc.CreateElement(de.Key.ToString()));
                campo.AppendChild(createTextNode(doc, de.Value));
            }
            foreach (string campo in new string[] {"DA001", "cf", "DA003", "DA002", "DA005g", "DA005m", "DA005a", "DA007", "DA006", "DA004", "anno"}) {
                if (ht.Contains(campo)) {
                    topmostSubform.AppendChild(doc.CreateElement(campo + "bis")).AppendChild(createTextNode(doc, ht[campo]));
                }
            }
            foreach (string campo in new string[] {"DA001"}) {
                if (ht.Contains(campo)) {
                    topmostSubform.AppendChild(doc.CreateElement(campo + "ter")).AppendChild(createTextNode(doc, ht[campo]));
                }
            }
            XmlElement pdf = doc.CreateElement("pdf", "http://ns.adobe.com/xdp/pdf/");
            pdf.SetAttribute("href", "CUDmod_2010.pdf");
            xdp.AppendChild(pdf);
            string nomeFile = Path.Combine(txtCartella.Text, ht["DA001"] + ".xdp");
            doc.Save(nomeFile);
        }

        private void btnGeneraCud_Click(object sender, EventArgs e) {
            QHS = Meta.Conn.GetQueryHelper();
            if (!Meta.GetSys("esercizio").Equals(2010)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Questa procedura produce solo modelli cud per l'anno 2010", "Errore");
                return;
            }
            if (txtCartella.Text == "") {
                faiScegliereCartella();
                if (txtCartella.Text == "") {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Occorre specificare la cartella in cui creare i modelli CUD", "errore");
                    return;
                }
            }
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            string moduloPdf = Path.Combine(txtCartella.Text, "CUDmod_2010.pdf");
            try {
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CUDmod_2010.pdf"), moduloPdf, true);
            }
            catch (Exception ex) {
                if (!File.Exists(moduloPdf)) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, ex.Message, "Errore");
                }
            }
            if (!verificaContrattiNonPagati()) return;
            if (!verificaPrestazioniCertificazioniCUD()) return;
            if (!verificaPrestazioniCertificazioniInNonCUD()) return;
            if (!verificaPrestazioniCertificazioniNonCUD()) return;

            DataSet ds = Meta.Conn.CallSP("exp_modello770_10_g", new object[] {"cud"}, true, 0);
            if ((ds == null) || (ds.Tables.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "La procedura di estrazione dati ha riscontrato un errore o non ha restituito risultati");
                return;
            }
            DataTable tRecordG = ds.Tables[0];

            DataTable tComunicazioni = new DataTable("comunicazioni");
            tComunicazioni.Columns.Add("progr", typeof(int));
            tComunicazioni.Columns.Add("cf", typeof(string));

            ArrayList collaboratori = new ArrayList();

            foreach (DataRow rRecordG in tRecordG.Select("quadro='DA' and colonna='001'")) {
                DataRow rCom = tComunicazioni.Rows.Add(new object[] {rRecordG["progr"], rRecordG["stringa"]});
                int pos = collaboratori.BinarySearch(rRecordG["stringa"]);
                if (pos < 0) {
                    collaboratori.Insert(-pos - 1, rRecordG["stringa"]);
                }
            }
            IDictionary campiPresiDallaLicenza = new Hashtable();
            DataTable tLicenza = Meta.Conn.RUN_SELECT("license", null, null, null, null, true);
            DataRow rLicenza = tLicenza.Rows[0];
            campiPresiDallaLicenza["cf"] = rLicenza["cf"] is DBNull ? rLicenza["p_iva"] : rLicenza["cf"];
            campiPresiDallaLicenza["agencyname"] = rLicenza["agencyname"];
            campiPresiDallaLicenza["location"] = rLicenza["location"];
            campiPresiDallaLicenza["country"] = rLicenza["country"];
            campiPresiDallaLicenza["cap"] = rLicenza["cap"];
            campiPresiDallaLicenza["address1"] = rLicenza["address1"];

            // Legge il responsabile della trasmissione del CUD, e dal suo contatto legge le info 
            // di tel, fax, e-mail. Se non ci sono continua a leggerle da license.
            object telefono = DBNull.Value;
            DataTable tContattoResp = null;

            string filterRespCUD = QHS.CmpEq("idtrasmissiondocument", "CUD");
            DataTable tRespCUD = Meta.Conn.RUN_SELECT("trasmissionmanager", null, null, filterRespCUD, null, true);
            if (tRespCUD.Rows.Count>0)
            {
                DataRow rRespCUD = tRespCUD.Rows[0];
                filterRespCUD = QHS.AppAnd(QHS.CmpEq("idreg", rRespCUD["idreg"]), QHS.CmpEq("flagdefault", "S"));
                tContattoResp = Meta.Conn.RUN_SELECT("registryreference", null, null, filterRespCUD, null, true);
                if (tContattoResp.Rows.Count>0){ 
                    DataRow rContattoResp = tContattoResp.Rows[0];
                    if (rContattoResp["phonenumber"] != DBNull.Value){
                        telefono = "T" + rContattoResp["phonenumber"];
                    }
                    else{
                        if (rContattoResp["faxnumber"] != DBNull.Value){
                            telefono = "F" + rContattoResp["faxnumber"];
                        }
                    }
                    campiPresiDallaLicenza["phonenumber"] = telefono;
                    campiPresiDallaLicenza["email"] = rContattoResp["email"];
                }
            }
            if (tContattoResp == null || tContattoResp.Rows.Count==0){
                // Vuol dire che o non esiste il responsabile della Tx del CUD 
                // oppure esiste MA nella sua anagrafica non ci sono le info richieste.
                if (rLicenza["phonenumber"] != DBNull.Value)
                {
                    telefono = "T" + rLicenza["phonenumber"];
                }
                else
                {
                    if (rLicenza["fax"] != DBNull.Value)
                    {
                        telefono = "F" + rLicenza["fax"];
                    }
                }
                campiPresiDallaLicenza["phonenumber"] = telefono;
                campiPresiDallaLicenza["email"] = rLicenza["email"];
            }
            

            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            DataTable tConfig = Meta.Conn.RUN_SELECT("config", null, null,filteresercizio,null, true);
            DataRow rConfig = tConfig.Rows[0];
            campiPresiDallaLicenza["TextField10"] = rConfig["cudactivitycode"];
            campiPresiDallaLicenza["anno"] = 2009;

            foreach (object cf in collaboratori) {
                DataRow[] rCom = tComunicazioni.Select(QHC.CmpEq("cf", cf));
                string commento = "";
                foreach (DataRow r in rCom) {
                    DataRow[] rHrg04 = tRecordG.Select(QHC.AppAnd(QHC.CmpEq("progr",r["progr"]),
                        QHC.CmpEq("quadro","HRG"), QHC.CmpEq("colonna", "04")));
                    DataRow[] rHrg08 = tRecordG.Select(QHC.AppAnd(QHC.CmpEq("progr",r["progr"]),
                        QHC.CmpEq("quadro","HRG"), QHC.CmpEq("colonna", "08")));
                    if (commento != "") {
                        commento += " - ";
                    }
                    commento += rHrg04[0]["stringa"] + " " + rHrg08[0]["stringa"];
                }
                string filtroProgr = QHC.FieldIn("progr", rCom);
                SortedList ht = new SortedList(campiPresiDallaLicenza);
                foreach (DataRow rRecordG in tRecordG.Select(filtroProgr)) {
                    string campo = rRecordG["quadro"].ToString() + rRecordG["colonna"];
                    switch (campo) {
                        case "DC017": {
                                salvaColonnaDC017(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DC016": {
                                salvaColonnaDC016(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB003": {
                                salvaColonnaDB003(ht, (int)rRecordG["intero"]);
                                break;
                            }
                        case "DB245": {
                                // Nota AI
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB246": {
                                // Nota AJ
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB248": {
                                // Nota AL
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB249": {
                                // Nota AM
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB250": {
                                // Nota AN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB254": {
                                // Nota AR
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB256": {
                                // Nota AT
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB2262": {
                                // Nota AZ
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        //case "HRG04":
                        //case "HRG08":
                        //case "HRG01":
                        //case "HRG02":
                        //case "HRG03":
                        //case "HRG06":
                        //case "DC081":
                        //case "DC082":
                        //case "DC083":
                        //    break;
                        default: salvaNormaleCampo(ht, campo, rRecordG); break;
                    }
                }
                stampaXml(ht, commento);
            }
            Cursor = null;
            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Sono stati generati " + collaboratori.Count + " modelli CUD (.xdp) nella cartella:\n" 
                + txtCartella.Text
                + "\nIl file CUDmod_2010.pdf va ignorato perchè contiene solo il modello CUD vuoto.", "Salvataggio effettuato");
        }

        private void faiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtCartella.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void riempiNote(SortedList ht, string nota) {
            if (ht["TextField213"] != null) {
                ht["TextField213"] += "\r\n";
            }
            ht["TextField213"] = ht["TextField213"] + nota;
        }

        private void btnCartella_Click(object sender, EventArgs e) {
            faiScegliereCartella();
        }

        //private DataTable getPrestazioniUfficiali() {
        //    DataTable tPrestUff = new DataTable();
        //    tPrestUff.Columns.Add("idser");
        //    tPrestUff.Columns.Add("rec770kind");
        //    tPrestUff.Columns.Add("idmot");
        //    tPrestUff.Rows.Add(new object[] { "05_ASSRICM", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_ASSRINM", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_COORDM", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_COORDN", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_COORDP", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_COOSTRA", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_CORNOINPS", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_COSTCON", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_TUTORM", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "05_TUTORNM", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "07_COPENOINPS", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "BORSESTCON", "H", "M" });
        //    tPrestUff.Rows.Add(new object[] { "BORSESTRA", "H", "M" });
        //    tPrestUff.Rows.Add(new object[] { "BORSISTI", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "BORSISTIES", "H", "M" });
        //    tPrestUff.Rows.Add(new object[] { "COMPSTCON", "H", "M" });
        //    tPrestUff.Rows.Add(new object[] { "COMPSTRA", "H", "M" });
        //    tPrestUff.Rows.Add(new object[] { "CTERZIRICE", "G", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "DIRAUMUTU", "H", "B" });
        //    tPrestUff.Rows.Add(new object[] { "DIRAUNNMUT", "H", "B" });
        //    tPrestUff.Rows.Add(new object[] { "DIRAUP.IVA", "H", "B" });
        //    tPrestUff.Rows.Add(new object[] { "DIRAUPENSI", "H", "B" });
        //    tPrestUff.Rows.Add(new object[] { "DIRAUTUND35", "H", "B" });
        //    tPrestUff.Rows.Add(new object[] { "GENERICA", DBNull.Value, DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "MISSASS", "", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "MISSDIP", "", DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "MISSESTRANEI", DBNull.Value, DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "MISSRICEST", DBNull.Value, DBNull.Value });
        //    tPrestUff.Rows.Add(new object[] { "OCCIRAMUTU", "H", "M" });
        //    tPrestUff.Rows.Add(new object[] { "OCCIRANMUT", "H", "M" });
        //    tPrestUff.Rows.Add(new object[] { "OCCIRAPENS", "H", "M" });
        //    tPrestUff.Rows.Add(new object[] { "PRESTPROF", "H", "A" });
        //    return tPrestUff;
        //}

        private bool stessoRecord(object rec1, object rec2) {
            string r1 = rec1.ToString();
            string r2 = rec1.ToString();
            if ((r1 == "G") && (r2 == "G")) return true;
            if ((r1 == "H") && (r2 == "H")) return true;
            if ((r1 != "G") && (r1 != "H") && ((r2 == "G") || (r2 == "H"))) return false;
            if (((r1 == "G") || (r1 == "H")) && (r2 != "G") && (r2 != "H")) return false;
            return false;
        }

        private DataTable controlloCompleto() {
            //DataTable tPrestUff = getPrestazioniUfficiali();
            DataTable t = getConfigurazionePrestazioni();
            DataTable z = new DataTable();
            z.Columns.Add("Attiva", t.Columns["active"].DataType);
            z.Columns.Add("# prestazione", t.Columns["idser"].DataType);
            z.Columns.Add("Codice prestazione", t.Columns["codeser"].DataType);
            z.Columns.Add("Prestazione", t.Columns["description"].DataType);
            z.Columns.Add("Record 770", t.Columns["rec770kind"].DataType);
            z.Columns.Add("Causale", t.Columns["idmot"].DataType);
            z.Columns.Add("Modulo", t.Columns["module"].DataType);
            z.Columns.Add("Certificazione", t.Columns["certificate"].DataType);
            z.Columns.Add("Ritenute fiscali", typeof(string));
            z.Columns.Add("Problema");
            foreach (DataRow r in t.Rows) {
                string rec770kind = r["rec770kind"].ToString().ToUpper();
                string idmot = r["idmot"].ToString().ToUpper();
                //DataRow[] rPrestUff = tPrestUff.Select("idser='" + r["idser"] + "'");
                //if (rPrestUff.Length > 0) {
                //    if (!stessoRecord(r["rec770kind"], rPrestUff[0]["rec770kind"]) || !r["idmot"].Equals(rPrestUff[0]["idmot"])) {
                //        z.Rows.Add(r["active"], r["idser"], r["codeser"], r["description"], r["rec770kind"], r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                //    "Prestazione ufficiale: deve essere Record770='" + rPrestUff[0]["rec770kind"] + "' e Causale='" + rPrestUff[0]["idmot"] + "'");
                //    }
                //}
                //else {
                    string module = r["module"].ToString().ToUpper();
                    string certificatekind = r["certificatekind"].ToString().ToUpper();
                    string ciSonoRitFiscali = (string)r["cisonoritfiscali"];
                    string codeser = r["codeser"].ToString();

                    if ((rec770kind == "G") && (((module != "COCOCO") && (module != "DIPENDENTE")) || (idmot != ""))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], r["description"], 
                                   r["rec770kind"], r["idmot"], r["module"], r["certificate"], 
                                   r["cisonoritfiscali"],
                        "Se il record770 è G allora il modulo deve essere COCOCO o DIPENDENTE e " +
                        "non ci deve essere la causale ");
                    }
                    if ((rec770kind == "H") && ((module != "OCCASIONALE") && (module != "PROFESSIONALE") ||
                        (idmot != "A") && (idmot != "M") && (idmot != "B") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], r["description"],
                                   r["rec770kind"], r["idmot"], r["module"], 
                                   r["certificate"], r["cisonoritfiscali"],
                        "Se il record770 è H allora il modulo deve essere OCCASIONALE o PROFESSIONALE, " +
                        "la causale deve essere A, M o B e non si deve usare il modello CUD");
                    }
                    if ((idmot == "A") && ((module != "PROFESSIONALE") || 
                        (rec770kind != "H") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], 
                                   r["description"], r["rec770kind"], r["idmot"], 
                                   r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se la causale è A allora il record770 deve essere H, " +
                        "il modulo deve essere PROFESSIONALE e non si deve usare il modello CUD");
                    }
                    if ((codeser == "07_DAT_I") && ((module != "PROFESSIONALE") || 
                        (rec770kind != "H") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], 
                                   r["description"], r["rec770kind"], r["idmot"], 
                                   r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Per 'Diritti d'autore titolari part. IVA' il record770 " +
                        "deve essere H, il modulo deve essere PROFESSIONALE " +
                        "e non si deve usare il modello CUD");
                    }
                    if ((idmot == "B") && (codeser != "07_DAT_I") && 
                        ((module != "OCCASIONALE") || (rec770kind != "H") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], 
                                   r["description"], r["rec770kind"], r["idmot"], r["module"], 
                                   r["certificate"], r["cisonoritfiscali"],
                        "Per 'Diritti d'autore SENZA part. IVA' il record770 deve essere H, " +
                        "il modulo deve essere OCCASIONALE e non si deve usare il modello CUD");
                    }
                    if ((idmot == "M") && ((module != "OCCASIONALE") || 
                        (rec770kind != "H") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], 
                                   r["description"], r["rec770kind"], 
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se la causale è M allora il record770 deve essere H, " +
                        "il modulo deve essere OCCASIONALE e non si deve usare il modello CUD");
                    }
                    if ((module == "PROFESSIONALE") && (codeser != "07_DAT_I") && ((rec770kind != "H") ||
                       (idmot != "A") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], 
                                   r["description"], r["rec770kind"], r["idmot"], 
                                   r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se il modulo è PROFESSIONALE e non si tratta di " +
                        "'Diritti d'autore per titolari part. IVA'" + 
                        "allora il record770 deve essere H, " +
                        "la causale deve essere A e non si deve usare il modello CUD");
                    }
                    if ((module == "OCCASIONALE") && ((rec770kind != "H") ||
                        (idmot != "M") && (idmot != "B") || 
                        (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], r["description"], 
                                   r["rec770kind"], r["idmot"], r["module"], r["certificate"], 
                                   r["cisonoritfiscali"],
                        "Se il modulo è OCCASIONALE allora il record770 deve essere H, " +
                        "la causale deve essere M o B e non si deve usare il modello CUD");
                    }

                    if ((certificatekind == "U") && ((rec770kind != "G") || 
                        (module != "COCOCO") && (module != "DIPENDENTE") || (idmot != ""))) {
                        z.Rows.Add(r["active"], r["idser"], r["codeser"], r["description"], 
                                   r["rec770kind"], r["idmot"], r["module"], 
                                   r["certificate"], r["cisonoritfiscali"],
                        "Se si usa il modello CUD allora il record770 deve essere G, " +
                        "il modulo deve essere COCOCO o DIPENDENTE, la causale deve essere vuota");
                    }
            }
            return z;
        }
        private DataTable getConfigurazionePrestazioni() {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "select distinct idser from expensetax "
                + "join expenselast on expenselast.idexp=expensetax.idexp "
                + "join expense on expense.idexp = expenselast.idexp "
                + "where ymov>=" + (esercizio - 1)
                + " and idser is not null";
            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);
            string prestazioni = QueryCreator.ColumnValues(t, null, "idser", true);
            string filtroPrestazioni = prestazioni == "" ? "0=1" : "service.idser in (" + prestazioni + ")";
            string s = @"select service.active, service.idser, service.codeser, service.description, service.rec770kind, motive770service.idmot, 
                        service.module, service.certificatekind, certificate=certificationmodel.description,
                        cisonoritfiscali=case when exists (select * from servicetax join tax on service.idser=servicetax.idser and servicetax.taxcode=tax.taxcode and taxkind=1) then 'S' else 'N' end
                        from service
                        left outer join motive770service on service.idser=motive770service.idser and motive770service.ayear="
                        + esercizio
                        + @" left outer join certificationmodel on service.certificatekind=certificationmodel.idcertificationmodel
                        where " + filtroPrestazioni;
            return DataAccess.SQLRunner(Meta.Conn, s);
        }

        private void btnProblemi_Click(object sender, EventArgs e) {
            DataTable z = controlloCompleto();
            if (z.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non ci sono problemi di configurazione delle prestazioni", "Nessun problema riscontrato");
            }
            exportclass.DataTableToExcel(z, true);
        }
        //todo: questo metodo deve essere testato; va chiamato prima di generare il cud e poi la stessa cosa
        //va fatta anche nel form del 770
        private bool verificaContrattiNonPagati() {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "select distinct parasubcontract.ycon, parasubcontract.ncon, exhibitedcud.idexhibitedcud "
                + "FROM parasubcontract "
                + "join payroll on payroll.idcon = parasubcontract.idcon "
                + "left outer join exhibitedcud on exhibitedcud.idcon = parasubcontract.idcon "
                + "where not exists (select * from expensepayroll "
                + "join expenselink ON expenselink.idparent = expensepayroll.idexp "
                + "join expenselast on expenselast.idexp = expenselink.idchild "
                + "join payment on payment.kpay = expenselast.kpay "
                + "where payment.kpaymenttransmission is not null "
                + "and payroll.idpayroll = expensepayroll.idpayroll)"
                + "and isnull(payroll.flagbalance,'N')='N' "
                + "and payroll.fiscalyear = " + (esercizio - 1)
                + " and exhibitedcud.fiscalyear = " + (esercizio - 1);
            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Esistono dei cedolini nei seguenti contratti i cui pagamenti non sono ancora stati trasmessi in banca:";
                foreach (DataRow r in t.Rows) {
                    errore += "\nn° " + r["ncon"] + " del " + r["ycon"] + ";";
                    if (r["idexhibitedcud"] != DBNull.Value) {
                        errore += " (in tale contratto è presente anche il cud n° " + r["idexhibitedcud"] + ")";
                    }
                }
                errore += "\n\npoichè in tali contratti ci sono cedolini non pagati,"
                    + "tali cedolini vanno trasferiti nella competenza dell'esercizio attuale."
                    + "\nL'operazione è stata annullata.";
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, errore);
                return false;
            }
            return true;
        }


        //Questo metodo va chiamato prima di generare il mod770, è presenta anche nel modello CUD
        private bool verificaPrestazioniCertificazioniCUD () {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "SELECT DISTINCT service.description, parasubcontract.ycon, "
                   + "parasubcontract.ncon "
                   + "FROM parasubcontract "
                   + "JOIN parasubcontractyear "
                   + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                   + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " " 
                   + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                   + "JOIN exhibitedcud on exhibitedcud.idlinkedcon = parasubcontract.idcon "
                   + "JOIN service ON service.idser = parasubcontract.idser "
                   + "WHERE EXISTS (select * from payroll JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll "
                   + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                   + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                   + "WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear =  " + (esercizio - 1) + ") "
                   + "AND   exhibitedcud.fiscalyear = " + (esercizio - 1) + " "
                   + "AND   ISNULL(service.certificatekind,'')<> 'U' ";

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Esistono dei contratti esibiti come CUD in altri contratti, le cui prestazioni " +
                                "però non sono associate al modello di certificazione fiscale CUD ";
                foreach (DataRow r in t.Rows) {
                    errore += "\nn° " + r["ncon"] + " del " + r["ycon"] + "-" + r["description"];
                }
                errore += "\nL'operazione è stata annullata.";
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, errore);
                return false;
            }
            return true;
        }

        //Questo metodo va chiamato prima di generare il mod770, è presenta anche nel modello CUD
        private bool verificaPrestazioniCertificazioniInNonCUD() {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "SELECT DISTINCT service.description, parasubcontract.ycon, "
                   + "parasubcontract.ncon "
                   + "FROM parasubcontract "
                   + "JOIN parasubcontractyear "
                   + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                   + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " "
                   + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                   + "JOIN exhibitedcud on exhibitedcud.idcon = parasubcontract.idcon "
                   + "JOIN service ON service.idser = parasubcontract.idser "
                   + "WHERE EXISTS (select * from payroll JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll "
                   + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                   + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                   + "WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear =  " + (esercizio - 1) + ") "
                   + "AND   exhibitedcud.fiscalyear = " + (esercizio - 1) + " "
                   + "AND   ISNULL(service.certificatekind,'')<> 'U' ";

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Ci sono CUD allegati a contratti che a loro volta non generano CUD (es. assegnisti di ricerca)";
                foreach (DataRow r in t.Rows) {
                    errore += "\nn° " + r["ncon"] + " del " + r["ycon"] + "-" + r["description"];
                }
                errore += "\nL'operazione è stata annullata.";
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, errore);
                return false;
            }
            return true;
        }

        private bool verificaPrestazioniCertificazioniNonCUD () {
            int esercizio = (int)Meta.GetSys("esercizio");

            string query = "SELECT COUNT(parasubcontract.idcon) as numero, registry.title "
                    + "FROM parasubcontract "
                    + "JOIN parasubcontractyear "
                    + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                    + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " " 
                    + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                    + "JOIN service ON service.idser = parasubcontract.idser "
                    + "WHERE EXISTS (select * from payroll JOIN expensepayroll "
                    + "ON payroll.idpayroll = expensepayroll.idpayroll "
                    + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                    + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                    + "WHERE payroll.idcon = parasubcontract.idcon "
                    + "and payroll.fiscalyear = " + (esercizio - 1) + " )"
                    + "AND NOT EXISTS "
                    + "(select * from exhibitedcud "
                    + "where idlinkedcon = parasubcontract.idcon "
                    + "and exhibitedcud.fiscalyear = " + (esercizio - 1) + " )"
                    + "AND ISNULL(service.certificatekind,'') = 'U' "
                    + "GROUP BY registry.title "
                    + "HAVING COUNT(parasubcontract.idcon) > 1 ";

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Esistono dei percipienti di contratti non esibiti come CUD in altri contratti, le cui prestazioni " +
                                "però sono associate al modello di certificazione fiscale CUD ";
                foreach (DataRow r in t.Rows) {
                    errore += "\n" + r["title"];
                }
                errore += "\nL'operazione è stata annullata.";
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, errore);
                return false;
            }
            return true;
        }

        private void btnPrestazioni_Click(object sender, EventArgs e) {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = @"select distinct expenselast.idser 
                            from expenselast
                            join expenselink on expenselink.idchild = expenselast.idexp
                            join expensetax on expensetax.idexp = expenselink.idparent
                            join expense on expense.idexp=expensetax.idexp 
                            where ymov>="+(esercizio-1)+" and idser is not null";
            DataTable tPrestAttive = DataAccess.SQLRunner(Meta.Conn, query);
            DataTable tPrestazioni = DataAccess.RUN_SELECT(Meta.Conn, "service", null, null, null, null, null, true);
            DataTable t = new DataTable();
            t.Columns.Add("Prestazioni del modello CUD");
            t.Columns.Add("Prestazioni non inserite nel modello CUD");
            t.Columns.Add("Prestazioni non usate nel " + (esercizio - 1));
            List<string> lg = new List<string>();
            List<string> ll = new List<string>();
            List<string> lnU = new List<string>();
            List<string> lnN = new List<string>();
            foreach (DataRow rp in tPrestazioni.Rows) {
                if (tPrestAttive.Select("idser='" + rp["idser"] + "'").Length > 0) {
                    switch (rp["certificatekind"].ToString().ToUpper()) {
                        case "U": lg.Add(rp["codeser"] + " - " + rp["description"]); break;
                        default: ll.Add(rp["codeser"] + " - " + rp["description"]); break;
                    }
                }
                else {
                    switch (rp["certificatekind"].ToString().ToUpper()) {
                        case "U": lnU.Add("U - " + rp["codeser"] + " - " + rp["description"]); break;
                        default: lnN.Add("* - " + rp["codeser"] + " - " + rp["description"]); break;
                    }
                }
            }
            List<string> ln = new List<string>(lnU);
            ln.AddRange(lnN);
            int max = lg.Count;
            if (ll.Count > max) max = ll.Count;
            if (ln.Count > max) max = ln.Count;
            for (int i = 0; i < max; i++) {
                DataRow r = t.NewRow();
                if (lg.Count > i) r[0] = lg[i];
                if (ll.Count > i) r[1] = ll[i];
                if (ln.Count > i) r[2] = ln[i];
                t.Rows.Add(r);
            }
            exportclass.DataTableToExcel(t, true);
        }
    }
}
