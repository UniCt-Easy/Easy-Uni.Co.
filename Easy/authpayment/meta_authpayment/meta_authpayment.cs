
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
using System.Collections.Generic;
using System.Text;
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;

namespace meta_authpayment {
    public class Meta_authpayment : Meta_easydata {
        public Meta_authpayment(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "authpayment") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            DefaultListType = "default";
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Autorizzazione al pagamento Agente di Riscossione";
                return GetFormByDllName("authpayment_default");
            }
            return null;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetMySelector(T.Columns["nauthpayment"], "yauthpayment", 0);
            RowChange.MarkAsAutoincrement(T.Columns["nauthpayment"], null, null, 0);
            RowChange.MarkAsAutoincrement(T.Columns["idauthpayment"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "yauthpayment", GetSys("esercizio"));
            SetDefault(PrimaryTable, "idauthstatus", 1);
        }

      
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            switch (ListingType) {
                case "default":
                return base.SelectOne(ListingType, filter, "authpaymentview", Exclude);
            }
            return base.SelectOne(ListingType, filter, searchtable, Exclude);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            int idauthstatus =CfgFn.GetNoNullInt32(R["idauthstatus"]);
            if (idauthstatus == 0) {
                errmess = "Inserire lo stato dell'autorizzazione";
                errfield = "idauthstatus";
                return false;
            }

            if (idauthstatus == 1) {
                if (R["sent_date"] != DBNull.Value) {
                    errmess = "Nello stato attuale non bisogna valorizzare la data di invio";
                    errfield = "sent_date";
                    return false;
                }

                if (R["authorize_date"] != DBNull.Value) {
                    errmess = "Nello stato attuale non bisogna valorizzare la data di tacita autorizzazione";
                    errfield = "authorize_date";
                    return false;
                }
            }
            else {
                if ((R["sent_date"] == DBNull.Value) && (idauthstatus < 5))
                {
                    errmess = "Inserire la data di invio";
                    errfield = "sent_date";
                    return false;
                }

                if ((R["authorize_date"] == DBNull.Value) && (idauthstatus < 5)) {
                    errmess = "Inserire la data di tacita autorizzazione";
                    errfield = "authorize_date";
                    return false;
                }
            }

            if (CfgFn.GetNoNullInt32(R["idreg"]) == 0) {
                errmess = "Inserire il percipiente";
                errfield = "idreg";
                return false;
            }

            if ((idauthstatus >= 3) && (CfgFn.GetNoNullDecimal(R["attach_amount"]) == 0)
            && (idauthstatus < 5))
            {
                errmess = "Inserire l'importo da pignorare";
                errfield = "attach_amount";
                return false;
            }

            if (CfgFn.GetNoNullDecimal(R["attach_amount"]) < 0)  
            {
                errmess = "L'importo da pignorare non può essere negativo";
                errfield = "attach_amount";
                return false;
            }

            return true;
        }
    }
}
