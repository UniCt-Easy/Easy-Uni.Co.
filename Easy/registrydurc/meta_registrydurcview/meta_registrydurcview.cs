/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_registrydurcview
{
    /// <summary>
    /// Summary description for meta_cdindirizzoview
    /// </summary>
    public class Meta_registrydurcview : Meta_easydata
    {
        public Meta_registrydurcview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "registrydurcview")
        {
            ListingTypes.Add("default");
            Name = "Indirizzo";
        }

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")   {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "durckinddescr", "Tipo Documento", nPos++);
                DescribeAColumn(T, "start", "Inizio validit‡", nPos++);
                DescribeAColumn(T, "stop", "Scadenza", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data documento", nPos++);
                DescribeAColumn(T, "inpscode", "Codice INPS", nPos++);
                DescribeAColumn(T, "inailcode", "Codice INAIL", nPos++);
                DescribeAColumn(T, "buildingcode", "Codice Cassa Edile", nPos++);
                DescribeAColumn(T, "otherinsurancecode", "Codice Gestore Altra Forma Assic.", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
            }
        }
    }
}
