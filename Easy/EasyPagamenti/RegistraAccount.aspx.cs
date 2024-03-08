
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


using metadatalibrary;
using metaeasylibrary;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using EasyPagamentiDataSet;
using EasyPagamenti.Extra;
using EasyPagamenti.Extensions;
using System.Web.Configuration;
using EasyPagamenti;
using System.Text.RegularExpressions;
using meta_registry;
using meta_registryaddress;
using meta_registryreference;
using q = metadatalibrary.MetaExpression;
using System.Collections.Generic;

public partial class RegistraAccount : System.Web.UI.Page {
    private string NomeUtente, Passw, Email, ConfermaPassword, Pec, CodiceDestinatario;
    private bool AccountAzienda = false;
    private bool SplitPayment = false;
    private string Nome, Cognome, Denominazione, PartIVA, CodFiscale, CFestero, DataNascita;
    private const int REGISTRY_CLASS_COMPANY = 21;
    private const int REGISTRY_CLASS_PRIVATE = 22;

    private void PulisciCampi() {
        //txtUserName.Text = "";
        //txtPassword.Text = "";
        //txtEmail.Text = "";
        //txtNome.Text = "";
        //txtCognome.Text = "";
        //txtpartitaiva.Text = "";
        //txtCodiceFiscale.Text = "";
        //txtDataDiNascita.Text = "";

        //txtPec.Text = "";
        //txtcodicedestinatario.Text = "";
        //CheckBoxSplitPayment.Checked = false;
    }

    private void NascondiCampi() {
        campi.Style.Add(HtmlTextWriterStyle.Display, "none");
        AttivaAccount.Style.Add(HtmlTextWriterStyle.Display, "block!important");
        AttivaAccount.Style.Add(HtmlTextWriterStyle.Width, "150px");
        AttivaAccount.Style.Add(HtmlTextWriterStyle.Margin, "auto");
    }

    public static bool isValidEmail(string inputEmail) {
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputEmail))
            return (true);
        else
            return (false);
    }

    public void MostraText(string tipoutente) {
        txtNome.Visible = (tipoutente == "1");
        lblNome.Visible = (tipoutente == "1");
        txtCognome.Visible = (tipoutente == "1");
        lblCognome.Visible = (tipoutente == "1");
        txtdenominazione.Visible = (tipoutente == "2");
        lbldenominazione.Visible = (tipoutente == "2");
        txtDataDiNascita.Visible = (tipoutente == "1");
        lblDataDiNascita.Visible = (tipoutente == "1");
        txtpartitaiva.Visible = (tipoutente == "2");
        lblpartitaiva.Visible = (tipoutente == "2");

        CheckBoxSplitPayment.Visible = (tipoutente == "2");
        lblSplitPayment.Visible = (tipoutente == "2");
        txtcodicedestinatario.Visible = (tipoutente == "1" | tipoutente == "2"); //caso 2 aggiunto a seguito di task 14310
        lblcodicedestinatario.Visible = (tipoutente == "1" | tipoutente == "2"); //caso 2 aggiunto a seguito di task 14310
    }

    public void valorizzaPunto4Privacy(DataAccess DepConn) {
        int found = 0;
        string strTofind = "4. ";
        found = TextBoxConsensoPrivacy.Text.ToString().IndexOf(strTofind);
        if (found > 0) return;

        object titolaredatiprivacy = DepConn.DO_READ_VALUE("config_pagopa", null, "titolaredatiprivacy");
        if ((titolaredatiprivacy != DBNull.Value) && (titolaredatiprivacy != null)) {
            TextBoxConsensoPrivacy.Text = TextBoxConsensoPrivacy.Text + "\n" + "4. " + titolaredatiprivacy.ToString();
        }
    }

    object idCityFromString(DataAccess conn, string comune_provincia) {
        if (comune_provincia == null) return null;
        var last_openpar = comune_provincia.LastIndexOf('(');
        if (last_openpar < 0) return null;
        string city = comune_provincia.Substring(0, last_openpar);
        string province = comune_provincia.Substring(last_openpar + 1).Replace(")", "");
        var qhs = conn.GetQueryHelper();
        var t = conn.RUN_SELECT("geo_cityview", "*", null, qhs.AppAnd(
                qhs.CmpEq("title", city),
                qhs.CmpEq("provincecode", province),
                qhs.IsNull("newcity"),
                qhs.IsNull("stop")),
            "20", false);
        if (t == null || t.Rows.Count == 0) return null;
        return t.Rows[0]["idcity"];
    }
    object idNationFromString(DataAccess conn, string nazione) {
        if (nazione == null) return null;
        var qhs = conn.GetQueryHelper();
        var t = conn.RUN_SELECT("geo_nation", "*", null, qhs.AppAnd(
                qhs.CmpEq("title", nazione),
                qhs.IsNull("newnation"),
                qhs.IsNull("stop")),
            "20", false);

        if (t == null || t.Rows.Count == 0) return null;
        return t.Rows[0]["idnation"];
    }

    
    protected void Page_Load(object sender, EventArgs e) {

        string errori;
        int idregistryclass;
        string depcode_given = configManager.getCfg("codicedipartimento").ToString();
        string ErroreDepConn;
        var DepConn = AccessKit.GetDepartmentConn(depcode_given, Page, out ErroreDepConn);

        // Dati dell'università
        string Query = "SELECT a.Agency, a.Address1, a.Cap, a.Country, a.P_Iva, b.Title from license a left outer join geo_city b on a.idcity = b.idcity ";
        DataTable tLicence = DataAccess.SQLRunner(DepConn as DataAccess, Query);

        var privacy_Nome = tLicence.Rows[0]["Agency"].ToString();
        var privacy_Indirizzo = tLicence.Rows[0]["Address1"].ToString();
        var privacy_Cap = tLicence.Rows[0]["Cap"].ToString();
        var privacy_Piva = tLicence.Rows[0]["P_Iva"].ToString();
        var privacy_Citta = tLicence.Rows[0]["Title"].ToString();
        var privacy_Provincia = tLicence.Rows[0]["Country"].ToString();

        Div1.InnerHtml = string.Format(privacy, privacy_Nome, privacy_Indirizzo, privacy_Cap, privacy_Piva, privacy_Citta, privacy_Provincia);

        //if (rbTipoUtente.SelectedValue.ToString() != "") {
        //    MostraText(rbTipoUtente.SelectedValue);
        //}
        if (!string.IsNullOrEmpty(ErroreDepConn)) {
            lblMessaggio.Text = ErroreDepConn;
            return;
        }

        valorizzaPunto4Privacy(DepConn);

        txtLuogoNascita.wantsID = true;
        txtNazione.wantsID = true;
        txtLuogoIndirizzo.wantsID = true;
        txtNazioneIndirizzo.wantsID = true;

        if (IsPostBack) {
            object idcityIndirizzo = DBNull.Value;
            object idnationIndirizzo = DBNull.Value;
            object idcityNascita = DBNull.Value;
            object idnationNascita = DBNull.Value;

            object idaddresskindDefault = DepConn.readValue("address", q.eq("codeaddress", "07_SW_DEF"), "idaddress");
            NomeUtente = txtUserName.Text;
            if (string.IsNullOrEmpty(NomeUtente)) {
                lblMessaggio.Text = "Specificare un nome utente.";
                return;
            }
            if (NomeUtente.Length > 64) {
                lblMessaggio.Text = "Nome utente troppo lungo.";
                return;
            }


            Passw = txtPassword.Text;
            ConfermaPassword = txtConfermaPassword.Text;
            Email = txtEmail.Text;
            Nome = txtNome.Text;
            Cognome = txtCognome.Text;
            PartIVA = txtpartitaiva.Text;
            CodFiscale = txtCodiceFiscale.Text;
            CFestero = txtCFestero.Text;

            Pec = txtPec.Text;
            CodiceDestinatario = txtcodicedestinatario.Text;
            SplitPayment = CheckBoxSplitPayment.Checked;

            if (string.IsNullOrEmpty(Passw)) {
                lblMessaggio.Text = "Specificare una password.";
                return;
            }
            if (Passw.Length > 20) {
                lblMessaggio.Text = "Password troppo lunga.";
                return;
            }

            if (rbTipoUtente.SelectedValue == "1") {
                Denominazione = Cognome + " " + Nome;
            } else {
                Denominazione = txtdenominazione.Text;
            }

            DataNascita = txtDataDiNascita.Text;
            string LuogoNascita = txtLuogoNascita.Text;
            string NazioneNascita = txtNazione.Text;

            string LuogoIndirizzo = txtLuogoIndirizzo.Text;
            string NazioneIndirizzo = txtNazioneIndirizzo.Text;

            if (Passw != ConfermaPassword) {
                //txtPassword.Text = "";
                //txtConfermaPassword.Text = "";
                lblMessaggio.Text = "le Password non corrispondono.";
                return;
            }

            if (!isValidEmail(Email)) {
                lblMessaggio.Text = "la Email non è valida.";
                return;
            }

            if (!isValidEmail(Pec) && Pec != "") {
                lblMessaggio.Text = "la Pec non è valida.";
                return;
            }

            if (rbTipoUtente.SelectedValue.ToString() == "") {
                lblMessaggio.Text = "Indicare il proprio profilo.";
                return;
            }

            if (rdbtiporesidenza.SelectedValue.ToString() == "") {
                lblMessaggio.Text = "Indicare il Tipo residenza.";
                return;
            }



            var piva = PartIVA?.ToUpper();
            var cf = CodFiscale?.ToUpper();
            bool personafisica = false;
            if (rbTipoUtente.SelectedValue == "1") {
                personafisica = true;
                idregistryclass = REGISTRY_CLASS_PRIVATE;
            } else {
                idregistryclass = REGISTRY_CLASS_COMPANY;
            }

            int residence = 1;

            switch (rdbtiporesidenza.SelectedValue.ToString()) {
                case "I":
                    residence = 1;
                    break;
                case "J":
                    residence = 2;
                    break;
                case "X":
                    residence = 3;
                    break;
            }
 

            if (personafisica) {
                //if (string.IsNullOrEmpty(Pec) && string.IsNullOrEmpty(CodiceDestinatario)) {
                //    lblMessaggio.Text = "Compilare almeno uno tra i campi Pec e Codice Destinatario.";
                //    return;
                //}
                if (string.IsNullOrEmpty(DataNascita)) {
                    lblMessaggio.Text = "il campo Data Di Nascita deve essere compilato.";
                    return;
                } else {
                    DateTime dataN;
                    bool res = DateTime.TryParse(DataNascita, out dataN);
                    if (!res) {
                        lblMessaggio.Text = "il campo Data Di Nascita non ha un formato valido.";
                        return;
                    }
                }

                string tipoNascita = rdbItaliaEstero.Text;
                if (string.IsNullOrEmpty(tipoNascita)) {
                    lblMessaggio.Text = "il campo Luogo di nascita deve essere valorizzato.";
                    return;
                }

                if (tipoNascita == "I") {
                    if (string.IsNullOrEmpty(LuogoNascita)) {
                        lblMessaggio.Text = "Il campo Città nascita deve essere compilato.";
                        return;
                    }

                    idcityNascita = idCityFromString(DepConn, LuogoNascita);
                    if (idcityNascita == null) {
                        lblMessaggio.Text = "Il campo Città nascita deve essere selezionato dall'elenco.";
                        return;
                    }
                }
                else {
                    if (string.IsNullOrEmpty(NazioneNascita)) {
                        lblMessaggio.Text = "Il campo Stato nascita deve essere compilato.";
                        return;
                    }

                    idnationNascita = idNationFromString(DepConn, NazioneNascita);
                    if (idnationNascita == null) {
                        lblMessaggio.Text = "Il campo Stato nascita deve essere selezionato dall'elenco.";
                        return;
                    }
                }

            }

            if (rdbtiporesidenza.SelectedValue == "I") {
                if (string.IsNullOrEmpty(LuogoIndirizzo)) {
                    lblMessaggio.Text = "Il campo Città indirizzo deve essere compilato.";
                    return;
                }

                idcityIndirizzo = idCityFromString(DepConn, LuogoIndirizzo);
                if (idcityIndirizzo == null) {
                    lblMessaggio.Text = "Il campo Città Indirizzo deve essere selezionato dall'elenco.";
                    return;
                }

            }

            if (rdbtiporesidenza.SelectedValue != "I") {
                if (string.IsNullOrEmpty(NazioneIndirizzo)) {
                    lblMessaggio.Text = "Il campo Nazione Indirizzo deve essere compilato.";
                    return;
                }

                idnationIndirizzo = idNationFromString(DepConn, NazioneIndirizzo);
                if (idnationIndirizzo == null) {
                    lblMessaggio.Text = "Il campo Nazione Indirizzo deve essere selezionato dall'elenco.";
                    return;
                }
            }





            if (!personafisica) {
                if (string.IsNullOrEmpty(Denominazione)) {
                    lblMessaggio.Text = "Inserire la denominazione";
                    return;
                }

                //Come da task, se Persona Giuridica non residente in Italia ==> CF estero obbligatorio
                if (rdbtiporesidenza.SelectedValue != "I") {
                    if (string.IsNullOrEmpty(CFestero)) {
                        lblMessaggio.Text = "Il campo Codice fiscale estero o Identificativo IVA deve essere compilato.";
                        return;
                    }
                }

            }

            //Controlli a prescindere se perosna fisica o meno
            //se Persona fisisa o Persona Giuridica, residente in Italia ==> CF obbligatorio

            if (rdbtiporesidenza.SelectedValue == "I") {
                if (string.IsNullOrEmpty(cf)) {
                    lblMessaggio.Text = "Il campo Codice fiscale deve essere compilato.";
                    return;
                }
            }





            // Se valorizzato, Controlla il codice fiscale
            if (!string.IsNullOrEmpty(cf)) {
                if (personafisica) {
                    errori = CodiceFiscale.CheckCF(cf);
                    if (!string.IsNullOrEmpty(errori)) {
                        lblMessaggio.Text = "Il codice fiscale non è valido: " + errori;
                        return;
                    }
                }
                //se Persona Giuridica, Controlla solo l'ultimo carattere
                else {
                    if (cf.Length == 16) {
                        bool IsValid;
                        string codice = cf.Substring(0, (cf.Length - 1));
                        string lastchar = CodiceFiscale.GetLastChar(codice, out IsValid).ToString();
                        if ((!IsValid) || (lastchar != cf[cf.Length - 1].ToString())) {
                            lblMessaggio.Text = "Ultimo carattere del Codice Fiscale non valido";
                            return;
                            // Non c'è il return, è solo un essaggio informativo Nino: lo rimetto, non vedo lo scopo di inserire un CF errato
                        }
                    }
                }
            }

            QueryHelper QHS = DepConn.GetQueryHelper();
            DataTable tRegistryclassregistry = DepConn.RUN_SELECT("registryclass", "*", null,
                QHS.CmpEq("idregistryclass", idregistryclass), null, false);
            if (tRegistryclassregistry == null || tRegistryclassregistry.Rows.Count == 0) return;
            string flagp_iva_forced = tRegistryclassregistry.Rows[0]["flagp_iva_forced"].ToString();
            //Se Persona Giuridica, residente in Italia con P.iva ogglibatoria nella config. della tipologia ==> Piva obbligatoria (Altrimenti è sufficiente il CF)
            if (!personafisica && rdbtiporesidenza.SelectedValue == "I" && (flagp_iva_forced == "S")) {
                if (string.IsNullOrEmpty(piva)) {
                    lblMessaggio.Text = "Il campo partita iva deve essere compilato.";
                    return;
                }
            }

            //Se valorizzata, controlla la p.iva
            if (!string.IsNullOrEmpty(piva)) {
                errori = PartitaIVA.ControllaPartitaIva(piva);
                if (!string.IsNullOrEmpty(errori)) {
                    lblMessaggio.Text = "La partita iva non è valida: " + errori;
                    return;
                }
            }

            if (!Consenso.Checked) {
                lblMessaggio.Text = "Accettare il consenso al trattamento dei dati.";
                return;
            }

            var dispatcher = new Meta_EasyDispatcher(DepConn);

            var metaRegistry = dispatcher.Get("registry");
            var metaReference = dispatcher.Get("registryreference");
            var metaRegistryAddress = dispatcher.Get("registryaddress");

            var ds = new dsmeta_registry();
            metaRegistry.SetDefaults(ds.registry);
            metaReference.SetDefaults(ds.registryreference);

            var getData = new GetData();
            getData.InitClass(ds, DepConn, "registry");

            var QHC = new CQueryHelper();
            var filterRegistry = QHS.CmpEq("active", "S");
            if (idregistryclass == REGISTRY_CLASS_PRIVATE) {
                filterRegistry = QHS.AppAnd(
                    filterRegistry,
                    QHS.CmpEq("cf", cf),
                    QHS.CmpEq("idregistryclass", idregistryclass)
                );
            } else if (idregistryclass == REGISTRY_CLASS_COMPANY) {
                filterRegistry = QHS.AppAnd(
                    filterRegistry,
                    QHS.CmpEq("p_iva", piva),
                    QHS.CmpEq("idregistryclass", idregistryclass)
                );
            }

            int nEmail = DepConn.count("registryreference",
                q.eq("email", Email) & q.isNotNull("userweb"));
            if (nEmail > 0) {
                lblMessaggio.Text = "indirizzo di mail già in uso per un altro contatto.";
                PulisciCampi();
                return;
            }

            int nUserweb = DepConn.count("registryreference", q.eq("userweb", NomeUtente));
            if (nUserweb > 0) {
                lblMessaggio.Text = "Nome utente già in uso per un altro contatto.";
                PulisciCampi();
                return;
            }

            getData.GET_PRIMARY_TABLE(filterRegistry);

            //
            // Crea l'anagrafica o carica dettagli ed indirizzi di quella esistente
            //
            var registryRow = ds.registry.First();
            if (registryRow == null) {
                var idaccmotivecredit = WebConfigurationManager.AppSettings["CausaleCredito"];
                var idaccmotivedebit = WebConfigurationManager.AppSettings["CausaleDebito"];

                registryRow = metaRegistry.Get_New_Row(null, ds.registry) as registryRow;
                registryRow["idregistryclass"] = idregistryclass;
                registryRow["idaccmotivecredit"] = idaccmotivecredit;
                registryRow["idaccmotivedebit"] = idaccmotivedebit;
                registryRow["cf"] = cf;
                registryRow["title"] = Denominazione;
                registryRow["foreigncf"] = CFestero;
                registryRow["residence"] = residence;
                registryRow["email_fe"] = string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email;
                registryRow["pec_fe"] = string.IsNullOrEmpty(Pec) ? DBNull.Value : (object)Pec; //= Pec;

                if (idregistryclass == REGISTRY_CLASS_COMPANY) {
                    registryRow["p_iva"] = piva;
                    registryRow["flag_pa"] = (SplitPayment) ? "S" : "N";
                    registryRow["ipa_fe"] = CodiceDestinatario;	//aggiunto dopo task 14310
                } else {
                    registryRow["surname"] = Cognome;
                    registryRow["forename"] = Nome;
                    registryRow["birthdate"] = DataNascita;
                    registryRow["gender"] = rdbSesso.Text == "M" ? "M" : "F";
                    registryRow["ipa_fe"] = CodiceDestinatario;
                    registryRow["idcity"] = idcityNascita;
                    registryRow["idnation"] = idnationNascita;
                }
            } else {
                registryRow["email_fe"] = string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email;
                registryRow["pec_fe"] = string.IsNullOrEmpty(Pec) ? DBNull.Value : (object)Pec; //= Pec;
                registryRow["ipa_fe"] = CodiceDestinatario; //aggiunto dopo task 14310
                if(registryRow["gender"] == DBNull.Value) {
                    registryRow["gender"] = InfoDaCodiceFiscale.Sesso(cf);
                }
                if (registryRow["foreigncf"] == DBNull.Value) {
                    registryRow["foreigncf"] = CFestero;
                }
                if (registryRow["flag_pa"] == DBNull.Value) {
                    registryRow["flag_pa"] = (SplitPayment) ? "S" : "N";
                }
                if ((idregistryclass== REGISTRY_CLASS_PRIVATE) && (registryRow["idcity"]==DBNull.Value)) {
                    registryRow["idcity"] = idcityNascita;
                }
                if ((idregistryclass == REGISTRY_CLASS_PRIVATE) && (registryRow["idnation"] == DBNull.Value)) {
                    registryRow["idnation"] = idnationNascita;
                }

                var idaccmotivecredit = WebConfigurationManager.AppSettings["CausaleCredito"];
                var idaccmotivedebit = WebConfigurationManager.AppSettings["CausaleDebito"];

                if (registryRow["idaccmotivecredit"] == DBNull.Value) registryRow["idaccmotivecredit"] = idaccmotivecredit;
                if (registryRow["idaccmotivedebit"] == DBNull.Value) registryRow["idaccmotivedebit"] = idaccmotivedebit;
            
                getData.DO_GET(false, registryRow);
            }

            // Crea un nuovo contatto o riutilizza quello già esistente
            var filterByEmail = QHC.CmpEq("email", Email);
            var referenceRow = ds.registryreference.First(filterByEmail);
            if (referenceRow == null) {
                referenceRow = metaReference.Get_New_Row(registryRow, ds.registryreference) as registryreferenceRow;
                referenceRow["email"] = (Email == "") ? DBNull.Value : (object)Email;
                referenceRow["pec"] = (Pec == "") ? DBNull.Value : (object)Pec;
                referenceRow["referencename"] = "Registrazione Web";
            } else {
                if (referenceRow.email == null) {
                    referenceRow["email"] = (Email == "") ? DBNull.Value : (object)Email;
                }
                if (referenceRow.pec == null) {
                    referenceRow["pec"] = (Pec == "") ? DBNull.Value : (object)Pec;
                }

                if (!referenceRow.IsNull("passwordweb")) {
                    lblMessaggio.Text = "Utente già registrato";
                    PulisciCampi();
                    return;
                }
            }

            // Imposta il contatto di default in caso non ce ne sia già uno
            var filterDefault = QHC.CmpEq("flagdefault", "S");
            var defaultReferenceRow = ds.registryreference.First(filterDefault);
            if (defaultReferenceRow == null) {
                referenceRow["flagdefault"] = "S";
            }



            var iterations = DateTime.Now.Millisecond * DateTime.Now.Second + 1;
            var salt = KeyChain.GenerateSalt();
            var hash = Password.GenerateHash(Passw, salt, iterations);

            referenceRow["userweb"] = NomeUtente;
            referenceRow["iterweb"] = iterations;
            referenceRow["saltweb"] = salt.ToHexString();
            referenceRow["passwordweb"] = hash.ToHexString();


            string errmess, errfield;
            if (!metaReference.IsValid(referenceRow, out errmess, out errfield)) {
                lblMessaggio.Text = errmess;
                return;
            }



            int AnnoCorrente = DateTime.Now.Year;
            var inizioAnno = new DateTime(AnnoCorrente, 1, 1);
            var fineAnnoPrec = new DateTime(AnnoCorrente - 1, 12, 31);

            //Imposta l'indirizzo 
            //Cerca l'indirizzo predefinito esistente
            var filterAddress = q.eq("idaddresskind", idaddresskindDefault) & q.isNull("stop");
            var currAddressRow = ds.registryaddress.First(filterAddress);
            if (currAddressRow != null) {
                if (currAddressRow.start.Year < DateTime.Now.Year) {
                    bool match = currAddressRow.address == txtIndirizzo.Text;
                    if (match) {
                        var location = string.IsNullOrEmpty(txtLocalitaIndirizzo.Text)
                            ? DBNull.Value
                            : (object)txtLocalitaIndirizzo.Text;
                        match = currAddressRow.locationValue.ToString() == location.ToString();
                    }
                    if (match) {
                        var cap = string.IsNullOrEmpty(txtCAP.Text)
                            ? DBNull.Value
                            : (object)txtCAP.Text;
                        match = currAddressRow.capValue.ToString() == cap.ToString();
                    }

                    if (match) {
                        if (rdbtiporesidenza.SelectedValue == "I") {
                            match = currAddressRow.flagforeign == "N" & currAddressRow.idcity.ToString() == idcityIndirizzo.ToString();
                        } else {
                            match = currAddressRow.flagforeign == "S" & currAddressRow.idnation.ToString() == idnationIndirizzo.ToString();
                        }
                    }
                    //14767 All'atto della registrazione ha creato un secondo indirizzo di residenza predefinito a quanto pare in tutto simile a quello già esistente
                    if (!match) {
                        var oldAddressRow = currAddressRow;
                        oldAddressRow.stop = fineAnnoPrec;
                        currAddressRow = null;
                    }
                } else {
                    if (currAddressRow.start.Year == DateTime.Now.Year) {
                        //Se c'è match di città e cap, aggiorna l'indirizzo e pace 
                        bool match = true;
                        var cap = string.IsNullOrEmpty(txtCAP.Text)
                            ? DBNull.Value
                            : (object)txtCAP.Text;
                        match = currAddressRow.capValue.ToString() == cap.ToString();
                        if (match) {
                            if (rdbtiporesidenza.SelectedValue == "I") {
                                match = currAddressRow.flagforeign == "N" &
                                        currAddressRow.idcity.ToString() == idcityIndirizzo.ToString();
                            } else {
                                match = currAddressRow.flagforeign == "S" &
                                        currAddressRow.idnation.ToString() == idnationIndirizzo.ToString();
                            }
                        }

                        if (match) {
                            currAddressRow["address"] = txtIndirizzo.Text;
                            currAddressRow["location"] = string.IsNullOrEmpty(txtLocalitaIndirizzo.Text)
                                ? DBNull.Value
                                : (object)txtLocalitaIndirizzo.Text;
                        }

                    }
                }
            }

            if (currAddressRow == null) {
                ds.registryaddress.setDefault("idaddresskind", idaddresskindDefault);
                ds.registryaddress.setDefault("start", inizioAnno);
                var rAddr = (registryaddressRow)metaRegistryAddress.Get_New_Row(registryRow, ds.registryaddress);
                rAddr["active"] = "S";
                rAddr["address"] = txtIndirizzo.Text;

                rAddr["location"] = string.IsNullOrEmpty(txtLocalitaIndirizzo.Text) ? DBNull.Value : (object)txtLocalitaIndirizzo.Text;
                rAddr["cap"] = string.IsNullOrEmpty(txtCAP.Text) ? DBNull.Value : (object)txtCAP.Text;
      
                if (rdbtiporesidenza.SelectedValue == "I") { 
                    rAddr["flagforeign"] = "N";
                    rAddr["idcity"] = idcityIndirizzo;

                } else {
                    rAddr["flagforeign"] = "S";
                    rAddr["idnation"] = idnationIndirizzo;
                }
                currAddressRow = rAddr;

                if (!metaRegistryAddress.IsValid(currAddressRow, out errmess, out errfield)) {
                    lblMessaggio.Text = errmess;
                    return;
                }

            }





            if (!metaRegistry.IsValid(registryRow, out errmess, out errfield)) {
                lblMessaggio.Text = errmess;
                return;
            }





            ClearDataSet.RemoveConstraints(ds);

            var postData = new Easy_PostData_NoBL();// PostData();
            postData.initClass(ds, DepConn);

            var pmc = postData.DO_POST_SERVICE();

            if (pmc.Count > 0) {
                string errore = "";
                //foreach (EasyProcedureMessage m in pmc) {
                //    errore += m.LongMess + " ";
                //}
                for (var i = 0; i < pmc.Count; i++) {
                    errore += pmc.GetMessage(i).LongMess + " ";
                }

                lblMessaggio.Text = errore; //"Errore del server dati";
                PulisciCampi();
                return;
            }

            try {
                Activation.SendEmail(Email, DepConn);
            } catch (Exception ex) {
                lblMessaggio.Text = "Invio dell'e-mail di attivazione fallito.";
                PulisciCampi();
                return;
            }

            lblMessaggio.Text = "Registrazione completata.";
            NascondiCampi();
            return;
        }
    }


    public class geoCity {
        public int idCity { get; set; }
        public string description { get; set; }
        public string province { get; set; }
    }
    public class geoNation {
        public int idNation { get; set; }
        public string description { get; set; }
    }



    [System.Web.Services.WebMethod]
    public static geoCity[] GetCities(string city, string currentSN) {
        string depcode_given = configManager.getCfg("codicedipartimento").ToString();

        string ErroreDepConn = string.Empty;
        var DepConn = AccessKit.GetDepartmentConn(depcode_given, out ErroreDepConn);
        if (!string.IsNullOrEmpty(ErroreDepConn)) {
            return new geoCity[] { };
        }
        var qhs = DepConn.GetQueryHelper();

        string filter = currentSN.ToString().ToUpper() == "S"
            ? qhs.AppAnd(qhs.Like("title", $"%{city}%"), qhs.IsNull("newcity"), qhs.IsNull("stop"))
            : qhs.Like("title", $"%{city}%");

        var t = DepConn.RUN_SELECT("geo_cityview", "*", "len(title) ",
            filter,
            "20", false);
        if (t == null) return new geoCity[] { };
        List<geoCity> result = new List<geoCity>();
        foreach (DataRow r in t.Rows) {
            result.Add(new geoCity() {
                idCity = Convert.ToInt32(r["idcity"]),
                description = r["title"].ToString(),
                province = r["provincecode"].ToString()
            });
        }
        DepConn.Destroy();
        return result.ToArray();
   
    }


    [System.Web.Services.WebMethod]
    public static geoNation[] GetNations(string nation, string currentSN) {
        string depcode_given = configManager.getCfg("codicedipartimento").ToString();
        string ErroreDepConn = string.Empty;
        var DepConn = AccessKit.GetDepartmentConn(depcode_given, out ErroreDepConn);
        if (!string.IsNullOrEmpty(ErroreDepConn)) {
            return new geoNation[] { };
        }

        var qhs = DepConn.GetQueryHelper();

        string filter = currentSN.ToString().ToUpper() == "S"
            ? qhs.AppAnd(qhs.Like("title", $"%{nation}%"), qhs.IsNull("newnation"), qhs.IsNull("stop"))
            : qhs.Like("title", $"%{nation}%");

        var t = DepConn.RUN_SELECT("geo_nation", "*", null, filter, "20", false);
        if (t == null) return new geoNation[] { };
        List<geoNation> result = new List<geoNation>();
        foreach (DataRow r in t.Rows) {
            result.Add(new geoNation() {
                idNation = Convert.ToInt32(r["idnation"]),
                description = r["title"].ToString()
            });
        }

        DepConn.Destroy();
        return result.ToArray();
    }

    public string privacy = @"
                            <p>
                                Informativa di cui all’art. 13 del Regolamento EU 2016/679 che regola Codice in materia di protezione dei dati personali Privacy
                            </p>
                            <br />

                            <p>
                                <b>Art. 1 - Titolare del trattamento</b><br />
                                Il titolare dei trattamenti dei dati raccolti ai sensi e per gli effetti dell’art. 13 del Regolamento EU 2016/679,
                                è <u>{0}</u> iscritta al Registro delle Imprese di {4} con Codice Fiscale e Partita IVA {3} con sede legale ed amministrativa
                                in {1} - {2} - {4} ({5}).
                            </p>
                            <br />

                            <p>
                                <b>Art. 2 - Natura facoltativa o obbligatoria del conferimento dei dati</b><br />
                                I dati dell’ utente conferiti al sito <u>{0}</u> possono essere necessari ai fini dell’utilizzo,
                                oppure rivestire carattere facoltativo. La natura obbligatoria o facoltativa del conferimento è specificata di volta in volta con la segnalazione del carattere (*) per individuare
                                l’obbligatorietà dell’informazione. La mancata comunicazione di dati obbligatori può rendere impossibile la prosecuzione e la conclusione della finalità perseguita dalla raccolta dei dati corrispondente.
                                Ad esempio la mancata indicazione dell’indirizzo di spedizione rende impossibile la conclusione dell’acquisto. A tal proposito si vuole evidenziare che l’eventuale comunicazione assente o non corretta di
                                una delle informazioni obbligatorie, può causare l’impossibilità per <u>{0}</u> di garantire la congruità del trattamento stesso e rende <u>{0}</u> non responsabile per conseguenze
                                scaturenti da tale comunicazione non corretta. Per garantire che i dati personali siano sempre esatti ed aggiornati, la preghiamo di segnalarci ogni modifica intervenuta via mail.
                                Tra i casi di conferimento facoltativi 	dei dati dell’utente citiamo quelli per scopi di marketing diretto, ma anche in questo caso sarà richiesto uno specifico consenso.
                            </p>
                            <br />

                            <p>
                                <b>Art. 3 - Finalità del trattamento</b><br />
                                I dati personali sono raccolti e trattati da <u>{0}</u> per finalità strettamente connesse all’uso del sito web, dei suoi servizi e all’acquisto di prodotti
                                tramite il sito web, ad esempio durante le fasi di:Procedura di acquisto dei prodotti su  <u>{0}</u>; Registrazione per la ricezione della Newsletter per posta elettronica;Fornitura dei servizi
                                di assistenza clienti. I dati personali saranno conservati nella forma che consenta la identificazione per il tempo strettamente necessario alla finalità per cui i dati sono stati raccolti e trattati e,
                                in ogni caso, entro i limiti di legge. I dati personali non saranno comunicati a terzi per scopi non consentiti dalla legge o senza espresso consenso e potranno essere comunicati a terzi solo quando ciò
                                sia necessario per dare seguito alla conclusione del contratto. Inoltre i dati potranno essere comunicati a forze di polizia o all’autorità giudiziaria, in conformità alla legge e previa richiesta formale
                                da parte di tali soggetti, ad esempio nell’ambito dei servizi antifrode. Può accadere che <u>{0}</u> si trovi a trattare dati personali di terzi soggetti comunicati direttamente dai propri utenti
                                a <u>{0}</u>, per esempio nel caso in cui l’utente abbia acquistato un prodotto da recapitare ad un amico ovvero quando il soggetto che corrisponde il prezzo per l’acquisto del prodotto sia diverso
                                dal soggetto cui il prodotto è destinato, ovvero ancora quando l’utente intenda segnalare ad un amico un servizio <u>{0}</u> o l’offerta in vendita di un particolare prodotto. In tutti questi
                                casi <u>{0}</u> farà pervenire al soggetto terzo l’informativa prescritta dall’art. 13 del Regolamento EU 2016/679 nel momento in cui registra nel proprio archivio i suoi dati, ma resta l’obbligo
                                dell’utente di ottenere il consenso della persona cui i dati si riferiscono prima di comunicarli a <u>{0}</u> e di informarlo circa questa Privacy Policy, perché sarà l’unico ed il solo responsabile
                                per la comunicazione di informazioni e di dati relativi a terzi soggetti, senza che questi abbiano espresso il loro consenso e per il loro uso non corretto o contrario alla legge. Il consenso di queste
                                persone non è necessario solo quando i dati di questo soggetto sono comunicati a <u>{0}</u> per la conclusione del contratto con <u>{0}</u> a suo esclusivo favore.
                            </p>
                            <br />

                            <p>
                                <b>Art. 4 - Modalità del trattamento</b><br />
                                Il trattamento dei dati può avvenire in varie forme: elettroniche, cartacee, telematiche, etc. Ogni trattamento avviene nel rispetto delle modalità
                                di cui agli artt. 11, 31 e ss. del Codice della Privacy e mediante l’adozione, nei modi previsti dal disciplinare tecnico in materia di misure minime di sicurezza contenuto nell’allegato B,
                                delle misure minime di sicurezza disciplinate dall’art. 35 del Codice della Privacy. Con l’accettazione, l’interessato presta espresso consenso al trattamento dei dati secondo le modalità suddette,
                                dunque in ogni forma e modo, ivi compresa la cessione dei dati a qualsiasi titolo a soggetti terzi. <u>{0}</u> acquisisce ogni più ampia facoltà e diritto di utilizzo dei dati medesimi,
                                compreso l’uso a fini commerciali, anche con riferimento alle banche dati nei quali i dati siano stati eventualmente inseriti e ogni e qualsiasi altro utilizzo.
                            </p>
                            <br />

                            <p>
                                <b>Art. 5 - Comunicazione</b><br />
                                I dati saranno trattati dal personale e/o dai collaboratori di <u>{0}</u>. I dati saranno comunicati a terzi soltanto previo consenso espresso,
                                salvo i casi in cui la comunicazione sia obbligatoria per legge o sia necessaria per finalità previste dalla legge per il perseguimento delle quali non sia richiesto il consenso dell’interessato
                                (ad esempio, nel caso di richiesta avanzata dalle forze di polizia o dalla magistratura o altri enti competenti oppure per eseguire obblighi derivanti dal contratto concluso).
                            </p>
                            <br />

                            <p>
                                <b>Art. 6 - Diritti dell’Interessato</b><br />
                                Scrivendoci via mail ogni momento l’interessato potrà esercitare i diritti riconosciuti dall’art. 13 del Regolamento EU 2016/679:l’aggiornamento,
                                la rettificazione oppure, quando vi ha interesse, l’integrazione dei dati;la cancellazione, la trasformazione in forma anonima o il blocco dei dati trattati in violazione di legge, compresi quelli
                                di cui non è necessaria la conservazione in relazione agli scopi per i quali i dati sono stati raccolti o successivamente trattati;l’attestazione che le operazioni di cui alle lettere a) e b) sono
                                state portate a conoscenza, anche per quanto riguarda il loro contenuto, di coloro ai quali i dati sono stati comunicati o diffusi, eccettuato il caso in cui tale adempimento si rivela impossibile
                                o comporta un impiego di mezzi manifestamente sproporzionato rispetto al diritto tutelato. L’interessato ha anche il diritto di opporsi in tutto o in parte al trattamento dei propri dati personali:
                                per motivi legittimi al trattamento dei dati personali che lo riguardano, ancorché pertinenti allo scopo della raccolta;al trattamento di dati personali che lo riguardano a fini di invio di materiale
                                pubblicitario o di vendita diretta o per il compimento di ricerche di mercato o di comunicazione commerciale. In qualsiasi momento l’utente può ottenere un elenco aggiornato dei responsabili del trattamento
                                scrivendoci via mail
                            </p>
                            <br />

                            <p>
                                <b>Art. 7. - Modifiche e aggiornamenti della Privacy Policy.</b><br />
                                Il titolare potrà modificare o semplicemente aggiornare, in tutto o in parte, la Privacy Policy di <u>{0}</u> anche
                                in considerazione della modifica delle norme di legge o di regolamento che regolano questa materia e proteggono i propri diritti. Le modifiche e gli aggiornamenti della Privacy Policy di <u>{0}</u>
                                saranno notificati agli utenti nella Home Page di <u>{0}</u> non appena adottati e saranno vincolanti non appena pubblicati sul sito web in questa stessa sezione. L’utente è pregato ad accedere con
                                regolarità a questa sezione per verificare la pubblicazione della più recente ed aggiornata Privacy Policy di <u>{0}</u>
                            </p>
                            <br />

                            <p>
                                <b>Art. 8 - Misure di sicurezza</b><br />
                                <u>{0}</u> adotta le misure di sicurezza adeguate al fine minimizzare i rischi di:distruzione perdita dei dati accesso non autorizzato trattamento non consentito
                                o non conforme alle finalità indicate nella nostra Privacy Policy. <u>{0}</u> peraltro, non può garantire che tali misure per la sicurezza del sito escludano qualsiasi rischio di accesso non consentito
                                di dispersione dei dati da parte di dispositivi di pertinenza dell’utente. A tal fine consigliamo l’utente di verificare l’esistenza sul proprio computer di software adeguati per la protezione della
                                trasmissione in rete di dati, e che il fornitore di servizi Internet abbia adottato misure idonee per la sicurezza della trasmissione di dati in rete.
                            </p>
                            <br />

                            <p>
                                <b>Art. 9 - Legge applicabile e rinvio alla normativa</b><br />
                                Il rapporto in materia di protezione dei dati personali tra <u>{0}</u> e l’utente è regolato dalla normativa italiana ed in particolare
                                dall’art. 13 del Regolamento EU 2016/679. L’utente può far riferimento al sito web del Garante per la protezione dei dati personali all’indirizzo http://www.garanteprivacy.it/, per conoscere i propri
                                diritti ed avere l’aggiornamento sulla normativa in materia di tutela delle persone rispetto al trattamento dei dati personali.
                            </p>";
}
