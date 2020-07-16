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

using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_legalstatuscontract{//meta_selclasseview//
	/// <summary>
	/// Summary description for meta_selclasseview
	/// </summary>
	public class Meta_legalstatuscontract : Meta_easydata {
		public Meta_legalstatuscontract(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "legalstatuscontract") {
			ListingTypes.Add("default");
            ListingTypes.Add("anagrafica");
            Name = "Posizione Giuridica";
		}

	    private string[] mykey = new string[] {"idreg", "idregistrylegalstatus", "idposition" };
	    public override string[] primaryKey() {
	        return mykey;
	    }

	    public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idposition", ".#", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "codeposition", "Codice qualifica", nPos++);
                DescribeAColumn(T, "position", "Qualifica", nPos++);
                DescribeAColumn(T, "incomeclass", "Classe", nPos++);
                DescribeAColumn(T, "maxincomeclass", "Cl. stip. max", nPos++);
			}
            if (listtype == "anagrafica") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idposition", ".#", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "codeposition", "Codice qualifica", nPos++);
                DescribeAColumn(T, "position", "Qualifica", nPos++);
                DescribeAColumn(T, "incomeclass", "Classe", nPos++);
                DescribeAColumn(T, "maxincomeclass", "Cl. stip. max", nPos++);
                DescribeAColumn(T, "csa_compartment", "Comparto CSA", nPos++);
                DescribeAColumn(T, "csa_role", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "csa_class", "Inquadr.CSA", nPos++);
                DescribeAColumn(T, "csa_description", "Desr.CSA", nPos++);
                DescribeAColumn(T, "stop", "Termine", nPos++);
            }
		}
	}
}
