
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
using funzioni_configurazione;//funzioni_configurazione

namespace meta_wageaddition//meta_contrattodip//
{
	/// <summary>
	/// Summary description for Meta_contrattodip.
	/// </summary>
	public class Meta_wageaddition : Meta_easydata
	{
		public Meta_wageaddition(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "wageaddition") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				Name = "Altri Compensi";
				DefaultListType = "default";
				return GetFormByDllName("wageaddition_default");
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
            string testoMessaggio = "Bisogna inserire i dati nel form di configurazione di Altri Compensi";
			DataTable configurazione = T.DataSet.Tables["config"];
			DataRow [] configrow = configurazione.Select("(ayear="+QueryCreator.quotedstrvalue(
							GetSys("esercizio"),false)+")");
			if (configrow.Length == 0)
			{
                MetaFactory.factory.getSingleton<IMessageShower>().Show(testoMessaggio, "Altri Compensi - Dati Mancanti", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return null;
			}

            int flag_autodocnumbering = CfgFn.GetNoNullInt32(configrow[0]["flag_autodocnumbering"]);
            string kind = ((flag_autodocnumbering & 0x80) == 0) ? "A" : "M";

			if (kind.ToUpper() == "A") {
                string reset = configrow[0]["wageaddition_flagrestart"].ToString();
				if (reset.ToUpper() == "S") {
					RowChange.SetSelector(T,"ycon");
				}
				RowChange.MarkAsAutoincrement(T.Columns["ncon"],null,null,0);
			}
			else
			{
				int nmax = CfgFn.GetNoNullInt32(
					Conn.DO_READ_VALUE("wageaddition", "(ycon="+
					QueryCreator.quotedstrvalue(GetSys("esercizio"),true)+")", "MAX(ncon)"))+1;
				SetDefault(T,"ncon", nmax);
			}
			return base.Get_New_Row(ParentRow, T);
		}

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) 
		{
			if ((C.ColumnName == "ycon") || (C.ColumnName == "ncon"))return;
			base.InsertCopyColumn (C, Source, Dest);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) 
		{
			if (ListingType == "default")
				return base.SelectOne(ListingType, filter, "wageadditionview", ToMerge);
			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (!base.IsValid (R, out errmess, out errfield)) return false;

	//wageadd§2006§1

            bool IsAdmin = (GetSys("manage_prestazioni") != null)
                            ? GetSys("manage_prestazioni").ToString() == "S"
                            : false;

			string filter_idrelated = "wageadd§" + R["ycon"].ToString() + "§" + R["ncon"].ToString();
			filter_idrelated = "(idrelated="+QueryCreator.quotedstrvalue(filter_idrelated,true)+")";

			DataTable Tserviceregistry = Conn.RUN_SELECT("serviceregistry","*",null,filter_idrelated,null,null,true);
			if ((Tserviceregistry.Rows.Count>0)&&(R.RowState == DataRowState.Modified)){
                bool error = false;
                string message = "";
                if (R["idreg", DataRowVersion.Current].ToString() != R["idreg", DataRowVersion.Original].ToString()) {
                    message = "Percipiente \n\r ";
                    error = true;
                }
                if (R["description", DataRowVersion.Current].ToString() != R["description", DataRowVersion.Original].ToString()) {
                    message = message + "Descrizione \n\r ";
                    error = true;
                }
                if (R["start", DataRowVersion.Current].ToString() != R["start", DataRowVersion.Original].ToString()) {
                    message = message + "Data Inizio \n\r ";
                    error = true;
                }
                if (R["stop", DataRowVersion.Current].ToString() != R["stop", DataRowVersion.Original].ToString()) {
                    message = message + "Data Fine \n\r ";
                    error = true;
                }
                if (CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["feegross", DataRowVersion.Current])) != CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["feegross", DataRowVersion.Original]))) {
                    message = message + "Lordo al beneficiario \n\r ";
                    error = true;
                }

				if (error){
                    if (IsAdmin){
                        errmess = "L'Anagrafe delle Prestazioni è stata già generata, e risultano modificati i seguenti dati: \n\r"
                            + message + "Adeguare anche i dati dell'Incarico.";

                        MetaFactory.factory.getSingleton<IMessageShower>().Show(errmess, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else{
                        errmess = "Risultano modificati i seguenti dati: \n\r"
                            + message + "La modifica non è consentita perché l'Anagrafe delle Prestazioni è stata già generata.\r\n" +
                            "Contattare il servizio assistenza o un utente con ruolo 'manage_prestazioni' ";
                        return false;
                    }
                }
			}
			//

			if (R["description"].ToString()=="")
			{
				errmess="Il campo descrizione è obbligatorio.";
				errfield="description";
				return false;
			}

			if (CfgFn.GetNoNullInt32(R["idreg"]) <= 0)
			{
				errmess = "Bisogna selezionare un percipiente";
                errfield = "registry.title";
				return false;			
			}

            if (CfgFn.GetNoNullInt32(R["idser"]) <= 0) {
                errmess = "Bisogna selezionare una prestazione";
                errfield = "idser";
                return false;
            }

			if (CfgFn.GetNoNullDecimal(R["feegross"]) <= 0)
			{
				errmess = "L'importo lordo del contratto deve essere maggiore di zero";
				errfield = "feegross";
				return false;
			}

			DateTime dataInizio = (DateTime)R["start"];
			DateTime dataFine = (DateTime)R["stop"];
			if (dataInizio > dataFine)
			{
				errmess = "La data di fine deve essere identica o successiva a quella di inizio";
				errfield = "stop";
				return false;
			}

            //Se il percipiente ha un indirizzo AP, nel form del compenso si deve scegliere o S o N
            String codeaddress = "07_SW_ANP";
            DateTime DataInizio = (DateTime)R["start"];
            object idaddresskind = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
            DataTable Address = DataAccess.RUN_SELECT(Conn, "registryaddress", "*", null,
                                QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("idreg", R["idreg"]),
                                QHS.CmpLe("start", DataInizio), QHS.NullOrGe("stop", DataInizio)), false);
            if (Address.Rows.Count > 0){
                if ((R["authneeded"].ToString() != "S") && (R["authneeded"].ToString() != "N")){
                    errfield = "authneeded";
                    errmess = "Il percipiente ha un indirizzo Anagrafe delle Prestazioni, pertanto va indicato se necessita o meno dell'autorizzazione.";
                    return false;
                }
            }

            if (R["authneeded"].ToString() == "S" && R["authdoc"].ToString() == ""){
                errmess = "Il campo 'Documento' è obbligatorio";
                errfield = "authdoc";
                return false;
            }

            if (R["authneeded"].ToString() == "S" && R["authdocdate"] == DBNull.Value){
                errmess = "Il campo 'data' è obbligatorio";
                errfield = "authdocdate";
                return false;
            }

            if (R["authneeded"].ToString() == "N" && R["noauthreason"].ToString() == ""){
                errmess = "Il campo 'Motivo' è obbligatorio";
                errfield = "authdoc";
                return false;
            }

			if ((R.RowState==DataRowState.Added) && (!RowChange.IsAutoIncrement(R.Table.Columns["ncon"])))
			{
				int NPRESENT = Conn.RUN_SELECT_COUNT("wageaddition","(ycon="+
					QueryCreator.quotedstrvalue(R["ycon"],true)+")AND"+
					"(ncon="+QueryCreator.quotedstrvalue(R["ncon"],true)+")",true);
				if (NPRESENT>0)
				{
					errmess="Esiste già un contratto con lo stesso numero.";
					errfield= "ncon";
					return false;
				}
			}
            //Se il DS contiene la tabella registry, controlla che l'idreg abbia il CF,se SI chiama il metodo.
            if (R.Table.DataSet.Tables.Contains("registry") && (R.Table.DataSet.Tables["registry"].Rows.Count > 0))
            {
                DataRow Registry = R.Table.DataSet.Tables["registry"].Rows[0];
                if (Registry["cf"] != DBNull.Value)
                {
                    string errori;
                    if (!CalcolaCodiceFiscale.CodiceFiscaleValido(this.Conn, Registry, out errori))
                    {
                        errmess = "Il Codice Fiscale non è valido!\n" + errori;
                        return false;
                    }
                }
            }
            else
            {
                //Se il DS non contiene la tabella registry,controlla che l'idreg abbia il CF se SI legge la riga dal DB
                // e chiama il metodo.
                object CF = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", R["idreg"]), "cf");
                if (CF != DBNull.Value)
                {
                    DataTable TRegistry = Conn.RUN_SELECT("registry", "*", null, QHS.CmpEq("idreg", R["idreg"]), null, null, true);
                    if (TRegistry.Rows.Count > 0)
                    {
                        DataRow Registry = TRegistry.Rows[0];
                        string errori;
                        if (!CalcolaCodiceFiscale.CodiceFiscaleValido(this.Conn, Registry, out errori))
                        {
                            errmess = "Il Codice Fiscale non è valido!\n" + errori;
                            return false;
                        }
                    }
                }
            }

            if ((R.Table.DataSet.Tables.Contains("service")) && 
                (R.Table.DataSet.Tables["service"].Rows.Count > 0))
            {
                DataRow[] ServiceFiltered = R.Table.DataSet.Tables["service"].Select(QHC.CmpEq("idser", R["idser"]));
                if (ServiceFiltered.Length != 0)
                {
                    DataRow Service = ServiceFiltered[0];
                    if ((Service["flagdistraint"].ToString() == "S") && (R["idreg_distrained"] == DBNull.Value))
                    {
                        errmess = "In base alla prestazione scelta deve essere specificato il Debitore Pignoratizio";
                        errfield = "idreg_distrained";
                        return false;
                    }
                }
                return true;
            }

			return true;
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable, "ycon", GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "completed", "N");
            SetDefault(PrimaryTable, "authneeded", "X");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"ycon","Esercizio Contratto");
				DescribeAColumn(T,"ncon","Numero Contratto");
			}
		}
	}
}
