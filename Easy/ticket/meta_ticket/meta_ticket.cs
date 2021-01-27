
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;

namespace meta_ticket {

    public class Meta_ticket : Meta_easydata {
        public Meta_ticket(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "ticket") {
            Name = "Ticket";
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            switch (FormName) {
            case "default": {
                Name = "Ticket";
                return MetaData.GetFormByDllName("ticket_default");
            }
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")  {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
                int npos = 1;
                DescribeAColumn(T, "idticket", "#",npos++);
                DescribeAColumn(T, "apertura", "Apertura", npos++);
                DescribeAColumn(T, "stato", "Stato", npos++);
                DescribeAColumn(T, "chiusura", "Chiusura", npos++);
            }

            //			DescribeAColumn(T,"sortcode","Codice");
            //			DescribeAColumn(T,"description","Descrizione");
        }
    }
}
