/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_moneytransfer
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_moneytransfer : Meta_easydata
    {
        public Meta_moneytransfer(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "moneytransfer")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Girofondo";
        }
        protected override Form GetForm(string FormName){
            if (FormName == "default"){
                DefaultListType = "default";
                return GetFormByDllName("moneytransfer_default");
            }
            return null;
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude){
            return base.SelectOne(ListingType, filter, "moneytransferview", Exclude);
        }


        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ytransfer", GetSys("esercizio").ToString());
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "transferkind","N");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.SetSelector(T, "ytransfer");
            RowChange.MarkAsAutoincrement(T.Columns["ntransfer"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield){
            if (CfgFn.GetNoNullInt32(R["idtreasurersource"])== 0){
                errfield = "idtreasurersource";
                errmess = "E' necessario scegliere il Cassiere Origine";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idtreasurerdest"]) == 0){
                errfield = "idtreasurerdest";
                errmess = "E' necessario scegliere il Cassiere di destinazione";
                return false;
            }

            if (CfgFn.GetNoNullDecimal(R["amount"]) == 0){
                errfield = "amount";
                errmess = "L'importo non può essere zero.";
                return false;
            }

            if (!(R["adate"] is DateTime)) {
                errfield = "adate";
                errmess = "Inserire la data contabile.";
                return false;
            }

            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
        }

    }
}
