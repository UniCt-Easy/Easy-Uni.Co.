
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using ep_functions;
using funzioni_configurazione;//funzioni_configurazione
using System.Collections.Generic;
using q = metadatalibrary.MetaExpression;
namespace meta_invoice//meta_documentoiva//
{
	/// <summary>
	/// Summary description for meta_documentoiva
	/// </summary>
	public class Meta_invoice : Meta_easydata {
		public Meta_invoice(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoice") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("bolladoganale");
			DefaultListType = "default";
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				Name="Fattura";
				DefaultListType="default";
				return MetaData.GetFormByDllName("invoice_default");//PinoRana
			}
			return null;
		}

        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "bolladoganale"){
                if (R["idinvkind_forwarder"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "invoiceview", ToMerge);

			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}

        public override string GetFilterForSearch(DataTable T) {
            //Esclude il filtro base su active, in fase di inserimento della Bolla Doganale nella fattura spedizioniere.
            if(T.TableName == "invoice_bolladoganale")
                return null;
            else
                return base.GetFilterForSearch(T);
        }

        public override void SetDefaults(DataTable PrimaryTable){
            object IsSdi_acquisto = GetUsr("sdi_acquisto");
            
			base.SetDefaults(PrimaryTable);

            QueryHelper QHS = Conn.GetQueryHelper();
            //SetDefault(PrimaryTable, "yinv", Conn.sys["esercizio"].ToString());
            //SetDefault(PrimaryTable, "adate", Conn.sys["datacontabile"].ToString());
            //SetDefault(PrimaryTable, "idcurrency", Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"),"idcurrency"));
            if (PrimaryTable.Columns["active"].DefaultValue == DBNull.Value){
                SetDefault(PrimaryTable, "active", "S");
            }
			SetDefault(PrimaryTable, "officiallyprinted", "N");
            SetDefault(PrimaryTable, "flag_ddt", "N");
            SetDefault(PrimaryTable, "toincludeinpaymentindicator", "S");
            SetDefault(PrimaryTable, "resendingpcc", "N");
            //SetDefault(PrimaryTable, "touniqueregister", "S"); task 16033
            SetDefault(PrimaryTable, "flag_enable_split_payment", "N");
            SetDefault(PrimaryTable, "flag_reverse_charge", "N");
            SetDefault(PrimaryTable, "rounding", "N");
            SetDefault(PrimaryTable, "ninv",99999987);
            
            if (PrimaryTable.Columns["flagintracom"].DefaultValue == DBNull.Value){
                SetDefault(PrimaryTable, "flagintracom", "N");
            }
            SetDefault(PrimaryTable, "flag", "2");
            if( PrimaryTable.Columns["autoinvoice"].DefaultValue ==DBNull.Value){
                SetDefault(PrimaryTable, "autoinvoice", "N");
            }
            if (PrimaryTable.Columns.Contains("idstampkind") && PrimaryTable.Columns["idstampkind"].DefaultValue == DBNull.Value) {
                SetDefault(PrimaryTable, "idstampkind", "no");
            }

            SetDefault(PrimaryTable, "adate", Conn.GetDataContabile());       
            object esercizio = Conn.GetEsercizio();
            object flagiva_immediate_or_deferred = Conn.DO_READ_VALUE("config",
                        QHS.CmpEq("ayear", esercizio), "flagiva_immediate_or_deferred");
            if (flagiva_immediate_or_deferred == null || flagiva_immediate_or_deferred == DBNull.Value) flagiva_immediate_or_deferred = "I";
            if (flagiva_immediate_or_deferred.ToString() == "D")
             SetDefault(PrimaryTable, "flagdeferred", "S");
            else
             SetDefault(PrimaryTable, "flagdeferred", "N");

            int flag = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("config",
                           QHS.CmpEq("ayear", esercizio), "flag"));
            if ((flag & 1) != 0) {//flaggato
                SetDefault(PrimaryTable, "flagbit", 64);// bit 6
            }
            else {
                SetDefault(PrimaryTable, "flagbit", 0);
            }

            SetDefault(PrimaryTable, "yinv", Conn.GetEsercizio());
            //Questi li esegue solo se il SetDefaults NON viene chiamato da sdi_acquisto
            if ((IsSdi_acquisto == null) || (IsSdi_acquisto.ToString() != "S")) {
                SetDefault(PrimaryTable, "idcurrency", Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"), "idcurrency"));
            }
		}

       
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if(ListingType == "bolladoganale"){
                foreach(DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int pos = 1;
                DescribeAColumn(T, "!invkind", "Tipo documento", "invoicekind_bolladoganale.description", pos++);
                DescribeAColumn(T, "yinv", "Esercizio", pos++);
                DescribeAColumn(T, "ninv", "Numero", pos++);
                DescribeAColumn(T, "doc", "Documento", pos++);
                DescribeAColumn(T, "docdate", "Data doc.", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                FilterRows(T);
            }
            if (ListingType == "elaboraincassi") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int pos = 1;
                DescribeAColumn(T, "idinvkind", ".idinvkind", pos++);
                DescribeAColumn(T, "yinv", "Esercizio", pos++);
                DescribeAColumn(T, "ninv", "Numero", pos++);
                DescribeAColumn(T, "!registry", "Cliente", pos++);
                DescribeAColumn(T, "doc", "Documento", pos++);
                DescribeAColumn(T, "docdate", "Data doc.", pos++);
                DescribeAColumn(T, "description", "nPos", pos++);
             
            }

        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			RowChange.SetSelector(T, "idinvkind");
			RowChange.SetSelector(T, "yinv");
			RowChange.MarkAsAutoincrement(T.Columns["ninv"], null, null, -1);
            if (!RowChange.IsCustomAutoIncrement(T.Columns["ninv"])) {
                RowChange.MarkAsCustomAutoincrement(T.Columns["ninv"],calcId);
            }
            RowChange.setMinimumTempValue(T.Columns["ninv"], 9999000);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;

		}
        private static object calcId(DataRow r, DataColumn c, DataAccess conn) {
            var qhs=conn.GetQueryHelper();
            var esercizio = r["yinv"];
            var invoiceFlagregister = conn.DO_READ_VALUE("config",
                        qhs.CmpEq("ayear", esercizio), "invoice_flagregister");
            if (invoiceFlagregister == null||invoiceFlagregister==DBNull.Value) invoiceFlagregister = "N";
            var n1=conn.DO_READ_VALUE("invoice",
                qhs.AppAnd(qhs.CmpEq("idinvkind", r["idinvkind"]), qhs.CmpEq("yinv", r["yinv"])),
                "MAX(ninv)");
            var ninv1 = CfgFn.GetNoNullInt32(n1) + 1;
            if (invoiceFlagregister.ToString().ToUpper() == "N") {
                return ninv1;
            }
            var sql = "SELECT TOP 1 IR.idivaregisterkind from ivaregisterkind IR " +
                        "join invoicekindregisterkind IK on IK.idivaregisterkind=IR.idivaregisterkind " +
                        " WHERE " +
                        qhs.AppAnd(qhs.CmpEq("IK.idinvkind", r["idinvkind"]), qhs.CmpNe("IR.registerclass", "P"))+
                        " ORDER BY IR.registerclass ASC ";
            var T = conn.SQLRunner(sql);
            if (T.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore nella configurazione del tipo documento");
                return 1;
            }
            var idivaregisterkind = T.Rows[0]["idivaregisterkind"];
            var n2 = CfgFn.GetNoNullInt32( conn.DO_READ_VALUE("ivaregister",
                    qhs.AppAnd(qhs.CmpEq("idivaregisterkind", idivaregisterkind),
                                qhs.CmpEq("yivaregister", esercizio)),
                                    "MAX(nivaregister)"))+1;
            T.Clear();
            return n2>=ninv1? n2:ninv1;
        }

        bool isSSN(object idinvkind) {
            string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            DataTable invreg = Conn.RUN_SELECT("invoicekindregisterkind", "*", null, filterreg, null, false);
            DataRow[] RegisterToLink = invreg.Select();
            foreach (DataRow IReg in RegisterToLink) {
                object idivaregisterkind = IReg["idivaregisterkind"];
                object code = Conn.DO_READ_VALUE("ivaregisterkind", QHS.CmpEq("idivaregisterkind", idivaregisterkind),
                    "codeivaregisterkind", null);
                if (code == null) return false;
                if (code.ToString().ToUpper() == "16TESSERASANITARIA") return true;
            }
            return false;
        }


		Dictionary<string,string>veroTipo= new Dictionary<string, string>();
		private string veroTipoFatturaAv(object idInvKind) {
            if (idInvKind == null) return "A";
			if (veroTipo.ContainsKey(idInvKind.ToString())) return veroTipo[idInvKind.ToString()];
			string filterreg = QHS.CmpEq("idinvkind", idInvKind);
			DataTable invRegKind = Conn.RUN_SELECT("invoicekindregisterkind", "*", null, filterreg, null, false);
			DataRow[] registerToLink = invRegKind.Select();
			bool acquisto = false;
			foreach (DataRow iReg in registerToLink) {
				object regClass = Conn.DO_READ_VALUE("ivaregisterkind",
					QHS.CmpEq("idivaregisterkind", iReg["idivaregisterkind"]),
					"registerclass");
				if (regClass==null || regClass.ToString().ToUpper() == "A")
					acquisto = true;
			}
			veroTipo[idInvKind.ToString()] = (acquisto ? "A" : "V");
			return veroTipo[idInvKind.ToString()];
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (R["adate"] == DBNull.Value) {
                errmess = "La data registrazione è obbligatoria";
                errfield = "adate";
                return false;
            }

            DateTime dd = (DateTime) R["adate"];
            if (dd.Year != CfgFn.GetNoNullInt32(R["yinv"])) {
                errmess = "La data registrazione non è coerente con l'anno fattura";
                errfield = "adate";
                return false;
            }
			if (CfgFn.GetNoNullInt32(R["ninv"])<=0) {
				errmess="E' necessario specificare il numero documento";
				errfield="ninv";
				return false;
			}

			if (CfgFn.GetNoNullInt32(R["idreg"])<=0) {
				errmess="Il campo 'Cliente/Fornitore' è obbligatorio";
				errfield="idreg";
				return false;
			}

			DataTable T=R.Table;
			string docautomatico="N";
            object idinvkind = R["idinvkind"];

            int flag;
            string enable_fe = "";
            if ((DS!=null)&&(DS.Tables.Contains("invoicekind"))) {
                DataTable InvKind= DS.Tables["invoicekind"];
                DataRow[] invk = InvKind.Select(QHC.CmpEq("idinvkind", idinvkind));
                flag = CfgFn.GetNoNullInt32(invk[0]["flag"]);
                enable_fe = invk[0]["enable_fe"].ToString().ToUpper();
            }
            else {
                flag = CfgFn.GetNoNullInt32(Conn.readValue("invoicekind", q.eq("idinvkind", idinvkind), "flag"));
                enable_fe = Conn.readValue("invoicekind", q.eq("idinvkind", idinvkind), "flag").ToString().ToUpper();
            }

			string myVeroTipoFattura = veroTipoFatturaAv(R["idinvkind"]);
			if ((myVeroTipoFattura != "A") && R["ipa_ven_cliente"] == DBNull.Value && R["email_ven_cliente"] == DBNull.Value && R["pec_ven_cliente"] == DBNull.Value 
			    && dd.Year>2018)  //vendita
			{
				errmess = "Per la fattura  di vendita è sempre necessario valorizzare il Codice Univoco, oppure l'Email o la PEC del Destinatario, anche in caso di soggetto privato";
				errfield = "ipa_ven_cliente";
				return false;
			}

			if (T.ExtendedProperties["docautomatico"]!=null) 
			docautomatico=T.ExtendedProperties["docautomatico"].ToString().ToUpper();
			if (docautomatico!="S" && R["doc"].ToString()=="") {
				errmess="Il campo 'Documento' è obbligatorio";
				errfield="doc";
				return false;
			}

            if (enable_fe == "N" && R["doc"].ToString().Length > 20) {
                errmess =
                    "Per le fatture non elettroniche è necessario limitare la lunghezza del campo documento a 20 caratteri.";
                errfield = "doc";
                return false;
            }

            if (R["docdate"] ==DBNull.Value) {
                errmess = "Il campo 'data documento' è obbligatorio";
                errfield = "docdate";
                return false;
                }

            if (R["idcurrency"] == DBNull.Value) {
                errmess = "Il campo 'Valuta' è obbligatorio";
                errfield = "idcurrency";
                return false;
            }
            if (R.RowState == DataRowState.Modified) {
                if (R["adate"].ToString() != R["adate", DataRowVersion.Original].ToString()) {
                    string idrel = EP_functions.GetIdForDocument(R);
                    if (Conn.RUN_SELECT_COUNT("entry", QHS.CmpEq("idrelated", idrel), false) > 0) {
                        errmess =
                            "La fattura ha già delle scritture collegate, occorre eliminarle prima di modificare " +
                            "la data di registrazione";
                        errfield = "adate";
                        return false;
                    }
                }
            }
        
            if (isSSN(R["idinvkind"])) {
                if (R["ssntipospesa"] == DBNull.Value) {
                    errmess = "Per il tipo fattura selezionata è necessario indicare il tipo spesa ai fini del progetto tessera sanitaria";
                    errfield = "ssntipospesa";
                    return false;
                }
            }
            // Le Bollette doganali non hanno Scadenza
            if (R.Table.Columns.Contains("flagbit")) {
                object flagObj = R["flagbit"];
                int flagInvoice = CfgFn.GetNoNullInt32(flagObj);
                bool isBolettaDoganale = (flagInvoice & 1) != 0; // Bit 0
                bool isFattSpedizioniere = (flagInvoice & 2) != 0; // Bit 1
                bool GeneraRecupero = (flagInvoice & 6) != 0; // Bit 6
                if (isBolettaDoganale && (R["idexpirationkind"] != DBNull.Value)) {
                    errmess = "Le Bollette doganali non hanno Scadenza";
                    errfield = "idexpirationkind";
                    return false;
                }
                
                if (isBolettaDoganale && (R["touniqueregister"].ToString().ToUpper() == "S")) {
                    errmess = "Le Bollette doganali non possono essere registrate nel registro unico";
                    errfield = "touniqueregister";
                    return false;
                }

                if (isBolettaDoganale && (R["active"].ToString().ToUpper() == "S")) {
                    errmess = "Le Bollette doganali non possono essere contabilizzate";
                    errfield = "active";
                    return false;
                }
                if (isBolettaDoganale && (R["autoinvoice"].ToString().ToUpper() == "S")) {
                    errmess = "Le Bollette doganali non possono essere autofatture";
                    errfield = "autoinvoice";
                    return false;
                }
                if (isBolettaDoganale && (R["toincludeinpaymentindicator"].ToString().ToUpper() == "S")) {
                    errmess = "Le Bollette doganali non vanno nell'indicatore di tempestività";
                    errfield = "toincludeinpaymentindicator";
                    return false;
                }
                if (isBolettaDoganale && isFattSpedizioniere) {
                    errmess = "Le Bollette doganali non sono fatt. spedizioniere";
                    errfield = "flagbit";
                    return false;
                }
                if (isBolettaDoganale && (R["flag_auto_split_payment"].ToString().ToUpper() == "N")) {
                    errmess = "Le Bollette doganali non possono essere modificate manualmente per lo split payment";
                    errfield = "flag_auto_split_payment";
                    return false;
                }
                if (isBolettaDoganale && (R["flag_enable_split_payment"].ToString().ToUpper() == "S")) {
                    errmess = "Le Bollette doganali non possono di tipo split payment";
                    errfield = "flag_enable_split_payment";
                    return false;
                }
                if(GeneraRecupero && (R["flag_enable_split_payment"].ToString().ToUpper() == "S") && (R["flagintracom"].ToString().ToUpper()!="N")) {
                    errmess = "Le Fatture INTRA o Extra-UE con generazione del recupero IVA estera non possono essere di tipo split payment";
                    errfield = "flag_enable_split_payment";
                    return false;
                }
            }

            //  1	Data contabile = data registrazione
            if ((CfgFn.GetNoNullInt32(R["idexpirationkind"]) == 1) && (R["adate"]==DBNull.Value)) {
                errmess = "Avendo scelto il tipo scadenza: Data contabile, è obbligatorio indicare la data registrazione";
                errfield = "adate";
                return false;
            }
            //  2	Data documento
            if ((CfgFn.GetNoNullInt32(R["idexpirationkind"]) == 2) && (R["docdate"] == DBNull.Value)) {
                errmess = "Avendo scelto il tipo scadenza: Data documento, è obbligatorio indicare la data documento";
                errfield = "docdate";
                return false;
            }
            //  3	Fine mese data documento
            if ((CfgFn.GetNoNullInt32(R["idexpirationkind"]) == 3) && (R["docdate"] == DBNull.Value)) {
                errmess = "Avendo scelto il tipo scadenza: Fine mese data documento, è obbligatorio indicare la data documento";
                errfield = "docdate";
                return false;
            }
            //  4	Fine mese data contabile
            if ((CfgFn.GetNoNullInt32(R["idexpirationkind"]) == 4) && (R["adate"] == DBNull.Value)) {
                errmess = "Avendo scelto il tipo scadenza: Fine mese data contabile, è obbligatorio indicare la data registrazione";
                errfield = "adate";
                return false;
            }
            //  5	Pagamento Immediato
            if ((CfgFn.GetNoNullInt32(R["idexpirationkind"]) == 5) && (R["adate"] == DBNull.Value)) {
                errmess = "Avendo scelto il tipo scadenza: Pagamento immediato, è obbligatorio indicare la data registrazione";
                errfield = "adate";
                return false;
            }
            //  6   Data ricezione
            if ((CfgFn.GetNoNullInt32(R["idexpirationkind"]) == 6) && (R["protocoldate"] == DBNull.Value)) {
                errmess = "Avendo scelto il tipo scadenza: Data ricezione, è obbligatorio indicare la data ricezione";
                errfield = "protocoldate";
                return false;
            }
            if ((DS!=null) && (DS.Tables.Contains("invoicedetail"))) {

            bool ExistsBeni = (DS.Tables["invoicedetail"].Select("intrastatoperationkind = 'B'").Length > 0);
            bool ExistsServizi = (DS.Tables["invoicedetail"].Select("intrastatoperationkind = 'S'").Length > 0);
            bool IntraInfoRequired = RegistryHasToDeclareIntrastat(R["idreg"]);

            if (R["flagintracom"].ToString().ToUpper() == "S" && IntraInfoRequired) {
                if (ExistsBeni){
                    if ((flag & 1) != 0){ 
                        //vendita
                        if (R["iso_destination"] == DBNull.Value){
                            errmess = "Il campo 'paese di destinazione' è obbligatorio";
                            errfield = "iso_destination";
                            return false;
                        }
                        if (R["idcountry_origin"] == DBNull.Value){
                            errmess = "Il campo 'provincia di origine' è obbligatorio";
                            errfield = "idcountry_origin";
                            return false;
                        }
                    }
                    else {  
                        //acquisto
                        if (R["iso_origin"] == DBNull.Value){
                            errmess = "Il campo 'paese di origine' è obbligatorio";
                            errfield = "iso_origin";
                            return false;
                        }
                        if (R["iso_provenance"] == DBNull.Value){
                            errmess = "Il campo 'paese di provenienza' è obbligatorio";
                            errfield = "iso_provenance";
                            return false;
                        }
                        if (R["idcountry_destination"] == DBNull.Value){
                            errmess = "Il campo 'provincia destinazione' è obbligatorio";
                            errfield = "idcountry_destination";
                            return false;
                        }
                    }
                    if (R["idintrastatkind"] == DBNull.Value){
                        errmess = "Il campo 'natura della transazione' è obbligatorio";
                        errfield = "idintrastatkind";
                        return false;
                    }
                }

                if (ExistsServizi){
                    if (R["docdate"] == DBNull.Value){
                        errmess = "Il campo 'data' è obbligatorio";
                        errfield = "docdate";
                        return false;
                    }

                    if (R["iso_payment"] == DBNull.Value){
                        errmess = "Il campo 'paese di pagamento' è obbligatorio";
                        errfield = "iso_payment";
                        return false;
                    }

                    if (R["idintrastatpaymethod"] == DBNull.Value){
                        errmess = "Il campo 'Modalità di pagamento' è obbligatorio";
                        errfield = "idintrastatpaymethod";
                        return false;
                    }
                }
            }

            }
			return true;
		}

        private bool RegistryHasToDeclareIntrastat(object idreg) {
            DataTable TRegistry = Conn.RUN_SELECT("registry", "idreg,p_iva,residence,idregistryclass", null, QHS.CmpEq("idreg", idreg), null, false);
            if (TRegistry.Rows.Count == 0) return false;
            DataRow Reg = TRegistry.Rows[0];
            object p_iva = Reg["p_iva"];
            object idresidence = Reg["residence"];

            object Ocoderesidence = Conn.DO_READ_VALUE("residence", QHS.CmpEq("idresidence", idresidence),
                                             "coderesidence");
            if (Ocoderesidence == null || Ocoderesidence == DBNull.Value) return false;
            string coderesidence = Ocoderesidence.ToString().ToUpper();
            // Qualora l'anagrafica sia configurata come:
            //- ente non commerciale;
            //- soggetto residente in altri paesi dell'UE;
            //- non abbia valorizzato la partita IVA;

            //non deve essere richiesta la compilazione dell'INTRASTAT sia:
            //nella fattura
            //nel dettaglio della fattura
            if ((coderesidence == "J") && (p_iva == DBNull.Value) && (CfgFn.GetNoNullInt32(Reg["idregistryclass"]) == 23)) {
                return false;
            }

            return true;

        }

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			DataTable T = C.Table;
			if ((C.ColumnName.ToLower()=="documento")&&(RowChange.IsAutoIncrement(C))){
				Dest["documento"]="-";
				return;
			}
            string [] dontcopy = new string[]{"yinv","flag_auto_split_payment","flag_enabled_split_payment","adate",
                    "flag_reverse_charge","idsdi_acquisto","idsdi_vendita","yelectronicinvoice","nelectronicinvoice",
                        "arrivalprotocolnum","resendingpcc","touniqueregister","idinvkind_real","yinv_real","ninv_real",
                        "doc","docdate","officiallyprinted","protocoldate",  
                        "idinvkind_forwarder","yinv_forwarder","ninv_forwarder","idtreasurer_acq_estere","idsdi_acquistoestere","idfedocumentkind"
            };
            foreach (string field in dontcopy) {
                if (C.ColumnName.ToLower()==field){
                    return;
                }
            }
           
            base.InsertCopyColumn(C, Source, Dest);
		}
	}
}
