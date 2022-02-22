
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_registrydurc{
    /// <summary>
    /// MetaData for durc
    /// </summary>
    public class Meta_registrydurc : Meta_easydata  {
        public Meta_registrydurc(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "registrydurc"){
            Name = "DURC";
            EditTypes.Add("default");
            ListingTypes.Add("default");
            EditTypes.Add("anagraficadetail");
            ListingTypes.Add("anagraficadetail");
        }

        protected override Form GetForm(string FormName){
            if (FormName == "default"){
                DefaultListType = "default";
                Name = "DURC";
                return MetaData.GetFormByDllName("registrydurc_default");
            }
            if (FormName == "anagraficadetail"){
                Name = "DURC";
                DefaultListType = "anagraficadetail";
                return MetaData.GetFormByDllName("registrydurc_anagraficadetail");
            }
            return null;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default"){
                return base.SelectOne(ListingType, filter, "registrydurcview", ToMerge);
            }

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override void SetDefaults(DataTable T)  {
            base.SetDefaults(T);
            SetDefault(T, "adate", GetSys("datacontabile"));
            SetDefault(T, "iddurckind", 1);
            SetDefault(T, "flagirregular", "N");
        }

        public override void DescribeColumns(DataTable T, string ListingType)  {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")   {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "iddurckind", "Tipo Documento", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data scadenza", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data documento", nPos++);
                DescribeAColumn(T, "inpscode", "Codice INPS", nPos++);
                DescribeAColumn(T, "inailcode", "Codice INAIL", nPos++);
                DescribeAColumn(T, "buildingcode", "Codice Cassa Edile", nPos++);
                DescribeAColumn(T, "otherinsurancecode", "Codice Gestore Altra Forma Assic.", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                DescribeAColumn(T, "flagirregular", "Irregolare", nPos++);
            }

            if (ListingType == "anagraficadetail") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idregistrydurc", "#", nPos++);
                DescribeAColumn(T, "!durckind", "Tipo Documento", "durckind.description", nPos++);
                DescribeAColumn(T, "start", "Inizio validità", nPos++);
                DescribeAColumn(T, "stop", "Scadenza", nPos++);
                DescribeAColumn(T, "doc", "Documento",nPos++);
                DescribeAColumn(T, "docdate","Data documento",nPos++);
                DescribeAColumn(T, "inpscode","Codice INPS",nPos++);
                DescribeAColumn(T, "inailcode","Codice INAIL",nPos++);
                DescribeAColumn(T, "buildingcode", "Codice Cassa Edile", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                DescribeAColumn(T, "flagirregular", "Irregolare", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield){
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if ((R["start"] != DBNull.Value) && (R["stop"] != DBNull.Value)){
                DateTime start = (DateTime)R["start"];
                DateTime stop = (DateTime)R["stop"];
                if (start > stop)
                {
                    errmess = "Attenzione! Non può essere immessa una data inizio successiva alla data scadenza";
                    errfield = "start";
                    return false;
                }
            }
            if ((R["start"] != DBNull.Value) && (R["stop"] == DBNull.Value)) {
                errmess = "Attenzione! Specificare la data di Scadenza";
                return false;
            }

            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.SetSelector(T, "idreg");
            RowChange.MarkAsAutoincrement(T.Columns["idregistrydurc"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);

        }


    }



}
