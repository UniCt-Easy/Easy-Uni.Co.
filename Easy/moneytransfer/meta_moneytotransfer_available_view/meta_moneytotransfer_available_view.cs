
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
using System.Collections.Generic;
using System.Text;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;


namespace meta_moneytotransfer_available_view
{
    public class Meta_moneytotransfer_available_view : Meta_easydata
    {
        public Meta_moneytotransfer_available_view(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "moneytotransfer_available_view")
        {
            ListingTypes.Add("lista");
            DefaultListType = "lista";
        }
        private string[] mykey = new string[] { "y", "n", "kind","idfin","idupb" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T);
            if (ListingType == "lista")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "y", "Esercizio", nPos++);
                DescribeAColumn(T, "n", "Numero", nPos++);
                DescribeAColumn(T, "adate", "Data Contabile", nPos++);

                DescribeAColumn(T, "underwritingincome", "Finanziamento Origine", nPos++);
                DescribeAColumn(T, "codefinincome", "Bilancio Origine", nPos++);
                DescribeAColumn(T, "codeupbincome", "UPB Origine", nPos++);

                DescribeAColumn(T, "underwriting", "Finanziamento Dest", nPos++);
                DescribeAColumn(T, "codefin", "Bilancio Dest", nPos++);
                DescribeAColumn(T, "codeupb", "UPB Dest", nPos++);

                DescribeAColumn(T, "treasurerincome", "Cassiere Origine", nPos++);
                DescribeAColumn(T, "treasurer", "Cassiere Destinazione", nPos++);
                
                DescribeAColumn(T, "moneytotransfer", "Importo Disponibile", nPos++);
                DescribeAColumn(T, "moneytransfered", "Importo Trasferito", nPos++);
                              
            }
        }
    }
}

