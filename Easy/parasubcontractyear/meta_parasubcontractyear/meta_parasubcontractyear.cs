
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_parasubcontractyear//meta_imputazionecontratto//
{
	/// <summary>
	/// Summary description for Meta_imputazionecontratto.
	/// </summary>
	public class Meta_parasubcontractyear : Meta_easydata
	{
		public Meta_parasubcontractyear(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "parasubcontractyear") 
		{		
			ListingTypes.Add("default");
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
            SetDefault(PrimaryTable, "flagbonusappliance", "N");
            SetDefault(PrimaryTable, "flagexcludefromcertificate", "N");
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (!base.IsValid (R, out errmess, out errfield)) return false;

//parasubcon§06000011
			DataRow Rparasubcontract = R.GetParentRow("parasubcontractparasubcontractyear");
            // 7862: il campo non viene copiato nell'AP
            //string filter_idrelated = "parasubcontract§" + Rparasubcontract["idcon"].ToString();
            //filter_idrelated = QHS.CmpEq("idrelated", filter_idrelated);

            //bool IsAdmin = (GetSys("manage_prestazioni") != null)
            //    ? GetSys("manage_prestazioni").ToString() == "S"
            //    : false;

            //DataTable Tserviceregistry = Conn.RUN_SELECT("serviceregistry","*",null,filter_idrelated,null,null,true);
            //if ((Tserviceregistry.Rows.Count>0)&&(R.RowState == DataRowState.Modified))
            //{
            //    if (
            //        R["idresidence",DataRowVersion.Current].ToString()!= R["idresidence",DataRowVersion.Original].ToString()
            //        )
            //    {
            //        if (IsAdmin)
            //        {
            //            errmess = "L'Anagrafe delle Prestazioni è stata già generata, adeguare anche i dati dell'Incarico.";
            //            MetaFactory.factory.getSingleton<IMessageShower>().Show(errmess, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }
            //        else
            //        {
            //            errmess = "Modifica non consentita perché l'Anagrafe delle Prestazioni è stata già generata";
            //            return false;
            //        }
            //    }
            //}

            
            string q = "SELECT * FROM servicetax JOIN tax "+
		               "ON servicetax.taxcode = tax.taxcode " +
                       "WHERE " + QHS.AppAnd(QHS.CmpEq("tax.taxkind", 3), QHS.CmpEq("servicetax.idser", Rparasubcontract["idser"]));
            DataTable prestazione = Conn.SQLRunner(q, -1, out errmess);
		    if ((prestazione.Rows.Count != 0)&&(R["idemenscontractkind"] is DBNull)) {
				errmess = "Scegliere un Tipo Rapporto";
				errfield = "idemenscontractkind";
				return false;
		    }

			DataRow rigaEmensTipoRapporto = R.GetParentRow("emenscontractkindparasubcontractyear");

            if (rigaEmensTipoRapporto != null) {

                if (rigaEmensTipoRapporto["flagactivityrequested"].Equals("S")
                    && (R["activitycode"] is DBNull)) {
                    errmess = "Per il 'Tipo Rapporto' scelto è necessario specificare l'Attività Previdenziale";
                    errfield = "activitycode";
                    return false;
                }

                if (!rigaEmensTipoRapporto["flagactivityrequested"].Equals("S")
                    && !(R["activitycode"] is DBNull)) {
                    errmess = "Per il 'Tipo Rapporto' scelto non va selezionata l'Attività Previdenziale";
                    errfield = "activitycode";
                    return false;
                }
            }
			DataRow rContratto = R.GetParentRow("parasubcontractparasubcontractyear");
            DataRow rService = rContratto.GetParentRow("serviceparasubcontract");

			string codeser = rService["servicecode770"].ToString().ToUpper();

            bool inps10 = (codeser == "05_COORDM")
                || (codeser == "05_ASSRICM")
                || (codeser == "05_TUTORM")
                || (codeser == "16_COORDM_DS")
                || (codeser == "16_COORDM_AS")
                || (codeser == "15_BRS_POSTM") //Borse post-doc mutuati (con solo rit. Inps) 
               || (codeser == "15_BRS_DOTTM"); //Borse dottorato di ricerca mutuati (solo Inps) 

            bool inps15 = codeser == "05_COORDP";

			if (inps10 && (R["idotherinsurance"] == DBNull.Value))
			{
				errmess = "Per i soggetti mutuati è necessario specificare l'altra forma assicurativa";
				errfield = "idotherinsurance";
				return false;
			}
			if (inps15 && (!R["idotherinsurance"].Equals("002")))
			{
				errmess = "Per i titolari di pensione diretta è necessario specificare 'Titolari di pensione diretta' come altra forma assicurativa";
				return false;
			}
			if (!inps15 &&(R["idotherinsurance"].Equals("002")))
			{
				errmess = "La prestazione scelta non è compatibile con l'altra forma assicurativa 'Titolari di pensione diretta'";
				errfield = "idser";
				return false;
			}

            if (CfgFn.GetNoNullInt32(rService["idser"]) != 0) {
                object foreign = Conn.DO_READ_VALUE("service", QHS.CmpEq("idser", rContratto["idser"]),"flagforeign");
                string flagforeign = "";
                if (foreign != null) {
                    flagforeign = foreign.ToString().ToUpper();
                }
				if ((flagforeign !="S")&&(CfgFn.GetNoNullInt32(R["idresidence"]) <= 0)){
				errmess = "Inserire il comune di residenza";
				errfield = "idresidence";
				return false;
                }
			}

		
			// Controllo su applicascaglioni - maggioreritenuta
			if (R["applybrackets"].ToString().ToUpper() == "N")
			{
				if (CfgFn.GetNoNullDecimal(R["highertax"]) <= 0)
				{
					errmess = "Impostare l'aliquota marginale";
					errfield = "highertax";
					return false;
				}
			}

			// Controlli sulle Addizionali IRPEF
			if ((CfgFn.GetNoNullDecimal(R["regionaltax"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["countrytax"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["citytax"]) > 0)
				)
			{
				// Il numero di rate non può essere nullo o pari a zero
				if (CfgFn.GetNoNullInt32(R["ratequantity"]) <= 0)
				{
					errmess = "Inserire il numero di rate di pagamento delle addizionali";
					errfield = "ratequantity";
					return false;
				}
				
				// Il mese di inizio non può essere nullo
				if (CfgFn.GetNoNullInt32(R["startmonth"]) <= 0)
				{
					errmess = "Inserire il mese da cui iniziare a pagare le rate delle addizionali";
					errfield = "startmonth";
					return false;
				}
				
				// Il mese di inizio deve cadere nel range di esistenza del contratto
				DateTime dataInizio = (DateTime) rContratto["start"];
				DateTime dataFine = (DateTime) rContratto["stop"];

				DateTime datamin = (dataInizio.Year == (int)R["ayear"]) ? dataInizio : new DateTime((int)R["ayear"],1,1);
				DateTime datamax = (dataFine.Year == (int)R["ayear"]) ? dataFine : new DateTime((int)R["ayear"],12,31);
				if ((CfgFn.GetNoNullInt32(R["startmonth"]) < datamin.Month) ||
					(CfgFn.GetNoNullInt32(R["startmonth"]) > datamax.Month))
			
				{
					errmess = "Il mese da cui si intende cominciare a pagare le rate delle addizionali non è congruo con l'esistenza del contratto";
					errfield = "startmonth";
					return false;
				}
				// Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno solare
				if (CfgFn.GetNoNullInt32(R["startmonth"]) + CfgFn.GetNoNullInt32(R["ratequantity"]) - 1 > datamax.Month)
				{
					errmess = "Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno fiscale";
					errfield = "ratequantity";
					return false;
				}
			}

            // Controlli sull'acconto dell'addizionale comunale
            if (CfgFn.GetNoNullDecimal(R["citytax_account"]) > 0){
                // Il numero di rate non può essere nullo o pari a zero
                if (CfgFn.GetNoNullInt32(R["ratequantity_account"]) <= 0) {
                    errmess = "Inserire il numero di rate di pagamento dell'acconto dell'addizionale comunale";
                    errfield = "ratequantity_account";
                    return false;
                }

                // Il mese di inizio non può essere nullo
                if (CfgFn.GetNoNullInt32(R["startmonth_account"]) <= 0) {
                    errmess = "Inserire il mese da cui iniziare a pagare le rate dell'acconto dell'addizionale comunale";
                    errfield = "startmonth_account";
                    return false;
                }

                // Il mese di inizio deve cadere nel range di esistenza del contratto
                DateTime dataInizio = (DateTime)rContratto["start"];
                DateTime dataFine = (DateTime)rContratto["stop"];

                DateTime datamin = (dataInizio.Year == (int)R["ayear"]) ? dataInizio : new DateTime((int)R["ayear"], 1, 1);
                DateTime datamax = (dataFine.Year == (int)R["ayear"]) ? dataFine : new DateTime((int)R["ayear"], 12, 31);
                if ((CfgFn.GetNoNullInt32(R["startmonth_account"]) < datamin.Month) ||
                    (CfgFn.GetNoNullInt32(R["startmonth_account"]) > datamax.Month)) {
                    errmess = "Il mese da cui si intende cominciare a pagare le rate dell'acconto dell'addizionale comunale non è congruo con l'esistenza del contratto";
                    errfield = "startmonth_account";
                    return false;
                }
                // Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno solare
                if (CfgFn.GetNoNullInt32(R["startmonth_account"]) + CfgFn.GetNoNullInt32(R["ratequantity_account"]) - 1 > datamax.Month) {
                    errmess = "Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno fiscale";
                    errfield = "ratequantity_account";
                    return false;
                }
            }
			return true;
		}
	}
}
