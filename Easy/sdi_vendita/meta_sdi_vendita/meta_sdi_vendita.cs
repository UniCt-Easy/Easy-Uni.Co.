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

ï»¿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_sdi_vendita {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_sdi_vendita : Meta_easydata {
        public Meta_sdi_vendita(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sdi_vendita") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Fatture di vendita selezionate per la trasmissione";
                return GetFormByDllName("sdi_vendita_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "issigned", "N");
            SetDefault(PrimaryTable, "idsdi_status", 1);
            SetDefault(PrimaryTable, "flag_unseen", 0);
        }

        const string baseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static int StringToInt(string value) {
            int result = 0;
            int Base = baseChars.Length; //=62
            for (int i = 0; i < value.Length; i++) {
                result = result * Base;
                int cifra = baseChars.IndexOf(value[i]);
                if (cifra < 0) {
                    cifra = 200;
                }
                result += cifra;
            }
            return result;
        }

        public static string IntToString(int value) {

            string result = "";
            int Base = baseChars.Length; //=62

            do {
                result = baseChars[value % Base] + result;
                value = value / Base;
            }
            while (value > 0);

            return result;
        }

        private object CalcID(DataRow R, DataColumn C, DataAccess Conn) {
            object o = Conn.DO_READ_VALUE("sdi_vendita", null, "max(idsdi_vendita)");
            int num = CfgFn.GetNoNullInt32(o);

            if (num==0) {
                 o = Conn.DO_READ_VALUE("electronicinvoice", null, "max(nelectronicinvoice)");
                num = CfgFn.GetNoNullInt32(o);
            }
            num = num + 1;

            //object fnameMax = Conn.DO_READ_VALUE("sdi_vendita", null, "max(filename)");

            object CFTrasmittente = Conn.DO_READ_VALUE("license", null, "max(cf)");

            string progressivo = IntToString(num);
            string NomeFileXml = "IT" + CFTrasmittente + "_" + progressivo + ".xml";

           

            return NomeFileXml;

        }
        private object CalcIDVendita(DataRow R, DataColumn C, DataAccess Conn) {
            object o = Conn.DO_READ_VALUE("sdi_vendita", null, "max(idsdi_vendita)");
            int num = CfgFn.GetNoNullInt32(o);

            if (num==0) {
                 o = Conn.DO_READ_VALUE("electronicinvoice", null, "max(nelectronicinvoice)");
                num = CfgFn.GetNoNullInt32(o);
            }
            num = num + 1;
            
            return num;

        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idsdi_vendita"], null, null, 7);
            RowChange.MarkAsCustomAutoincrement(T.Columns["idsdi_vendita"], new RowChange.CustomCalcAutoID(CalcIDVendita));
            RowChange.MarkAsAutoincrement(T.Columns["filename"], null, null, 7);
            RowChange.MarkAsCustomAutoincrement(T.Columns["filename"], new RowChange.CustomCalcAutoID(CalcID));
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "sdi_venditaview", Exclude);
             return base.SelectOne(ListingType, filter, "sdi_vendita", Exclude);
        }


    }
}