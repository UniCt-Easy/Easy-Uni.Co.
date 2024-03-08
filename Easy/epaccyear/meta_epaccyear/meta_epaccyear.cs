
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;

namespace meta_epaccyear
{
    /// <summary>
    /// Summary description for  meta_epaccyear.
    /// </summary>
    public class Meta_epaccyear : Meta_easydata {
        public Meta_epaccyear(DataAccess Conn,
            MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "epaccyear") {
        }
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T,"ayear", CfgFn.GetNoNullInt32( GetSys("esercizio")));
            if (T.Columns["amount"].DefaultValue == DBNull.Value) {
                SetDefault(T, "amount", 0);
            }
            if (T.Columns["amount2"].DefaultValue == DBNull.Value) {
                SetDefault(T, "amount2", 0);
            }
            if (T.Columns["amount3"].DefaultValue == DBNull.Value) {
                SetDefault(T, "amount3", 0);
            }
            if (T.Columns["amount4"].DefaultValue == DBNull.Value) {
                SetDefault(T, "amount4", 0);
            }
            if (T.Columns["amount5"].DefaultValue == DBNull.Value) {
                SetDefault(T, "amount5", 0);
            }
        }

        override public bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;

            if (R["idacc"] == DBNull.Value) {
                errmess = "Il conto è una informazione necessaria";
                errfield = "idacc";
                return false;
            }

            if (R["idupb"] == DBNull.Value) {
                errmess = "L'upb è una informazione necessaria";
                errfield = "idupb";
                return false;
            }

            if (R["amount"] == DBNull.Value) {
                errmess = "Non è stato immesso l'importo";
                errfield = "amount";
                return false;
            }
            if (CfgFn.GetNoNullDecimal(R["amount"]) < 0) {
                errmess = "L'importo non può essere negativo";
                errfield = "amount";
                return false;
            }
            int usage =CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", R["idacc"]), "flagaccountusage"));
            if ((usage & 128) == 0) {
                errmess = "E' necessario selezionare un conto di RICAVO";
                errfield = "idacc";
                return false;
            }

            return true;
        }

    }
}
