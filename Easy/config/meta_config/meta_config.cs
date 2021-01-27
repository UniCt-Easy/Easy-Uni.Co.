
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_config
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_config : Meta_easydata
    {
        public Meta_config(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "config")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")
            {
                Name = "Configurazione Annuale";
                DefaultListType = "default";
                Form F = GetFormByDllName("config_default");
                return F;
            }

            return null;
        }


        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
            //asset
            SetDefault(PrimaryTable, "asset_flagrestart", "S");
            SetDefault(PrimaryTable, "linktoinvoice", "N");
            SetDefault(PrimaryTable, "assetload_flag", 0);
            //invoice
            SetDefault(PrimaryTable, "deferredincomephase", "E");
            SetDefault(PrimaryTable, "deferredexpensephase", "T");
            //casualcontractsetup
            SetDefault(PrimaryTable, "casualcontract_flagrestart", "S");
            //parasubcontract
            //profservice
            SetDefault(PrimaryTable, "profservice_flagrestart", "S");
            //wageaddition
            SetDefault(PrimaryTable, "wageaddition_flagrestart", "S");
            //expense
            SetDefault(PrimaryTable, "payment_flag", 0);
            //income
            SetDefault(PrimaryTable, "proceeds_flag", 0);

            SetDefault(PrimaryTable, "flagiva_immediate_or_deferred", "I");
            int flag = CfgFn.GetNoNullInt32(PrimaryTable.Columns["flag_autodocnumbering"].DefaultValue);
            flag = flag | 0xF0; //All contract numbering=Auto
            PrimaryTable.Columns["flag_autodocnumbering"].DefaultValue = flag;


        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            base.IsValid(R, out errmess, out errfield);

            if (R["asset_flagnumbering"].ToString() == "" || R["asset_flagnumbering"].ToString() == "N")
            {
                errmess = "Specificare il tipo di numerazione per i buoni di carico/scarico";
                errfield = "asset_flagnumbering";
                return false;
            }

            string iban = R["iban_f24"].ToString();
            if (iban != "") {
                iban = CfgFn.normalizzaIBAN(iban.ToUpper());
                if (iban.Length != 27) {
                    errmess = "'"+iban+"' ha lunghezza "+iban.Length+"; si deve invece inserire un codice Iban di 27 caratteri così composto:\n"
                        + "\n- Codice Paese (2 caratteri - deve assumere il valore IT);"
                        + "\n- Codice di Controllo (2 caratteri - Obbligatorio e coerente con le specifiche IBAN);"
                        + "\n- CIN (1 carattere - deve essere una lettera maiuscola);"
                        + "\n- ABI (5 caratteri - deve assumere il valore 01000 (Banca d'Italia));"
                        + "\n- CAB (5 caratteri - deve assumere il valore 03245);"
                        + "\n- Numero di conto (12 caratteri - numero di conto definito in modo da individuare anche la tesoreria destinataria. Si veda la circolare n. 20 del 8/5/2007 della R.G.S.)";
                    errfield = "iban_f24";
                    return false;
                }
                if (iban.Substring(0, 2) != "IT") {
                    errmess = "Il codice Iban deve cominciare con 'IT'";
                    errfield = "iban_f24";
                    return false;
                }
                if (iban.Substring(5, 5) != "01000") {
                    errmess = "Il codice Iban inserito non corrisponde ad un conto di addebito presso la Banca d'Italia";
                    errfield = "iban_f24";
                    return false;
                }
                if (!CfgFn.verificaIban(iban)) {
                    errmess = "Il conto di addebito per il modello F24EP non è un codice Iban valido";
                    errfield = "iban_f24";
                    return false;
                }

            }
            
            return true;
        }

        public override void DescribeColumns(DataTable T, string listtype)
        {
            base.DescribeColumns(T, listtype);
            DescribeAColumn(T, "ayear", "");
        }
    }
}
