/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Data;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using metadatalibrary;
using System.Text;
using funzioni_configurazione;
using System.Globalization;


namespace exporthelper {
    public class exp_riepilogo_ritenute_applicate_inail :IExportHelper {
        public DataTable Execute(DataAccess DA, Hashtable H) {
            CQueryHelper QHC;
            QueryHelper QHS;
            QHC = new CQueryHelper();
            QHS = DA.GetQueryHelper();

            Hashtable H1 = new Hashtable();
            DataSet MyOut = null;
            object[] ReportParams = new object[10] { H["ayear"],H["idreg"],H["tax"],H["show_month"],H["idsor01"],H["idsor02"],H["idsor03"],H["idsor04"],H["idsor05"],H["perpresavisione"] };
            int timeout = 300;
            MyOut = DA.CallSP("exp_riepilogo_ritenute_applicate_inail", ReportParams, false, timeout);
            if ((MyOut == null) || (MyOut.Tables.Count == 0) || (MyOut.Tables[0].Rows.Count == 0)) {
                return null;
            }
            else {
                DataTable OutTable = MyOut.Tables[0];
                DataColumn CC = OutTable.Columns["AliquotaApplicata"];
                CC.ExtendedProperties["ExcelFormat"] = "0.00000";
                MyOut.Tables.Remove(MyOut.Tables[0]);
                return OutTable;
            }
        }
        
        



    }
}
