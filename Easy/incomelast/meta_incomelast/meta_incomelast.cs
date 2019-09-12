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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using System.Collections;

namespace meta_incomelast {
    public class Meta_incomelast : Meta_easydata {
        public Meta_incomelast(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "incomelast") {
            Name = "Movimento di entrata - Dettaglio";
        }
        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if  (C.ColumnName == "kpro") return;
            base.InsertCopyColumn(C, Source, Dest);
        }
        override public bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield)) return false;

            //byte flag = Convert.ToByte(R["flag"]);
            //bool fulfilled = (flag & 1) == 1;
            //if (fulfilled) {
            //    string messaggio = "Attenzione!, impostando il flag 'Regolarizza disposizione di incasso già effettuata' " +
            //        " il movimento sarà nascosto nella stampa della distinta di trasmissione a meno che non venga impostato " +
            //        " il parametro MostraMovGiaTrasmessi a S, dal bottone Altri Parametri, in tal caso il movimento verrà visualizzato su sfondo grigio";
            //    DialogResult RES = MessageBox.Show(messaggio, "ATTENZIONE", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //    if (RES == DialogResult.Cancel) {
            //        errmess = "";
            //        errfield = "flag";
            //        return false;
            //    }
            //}

			return true;
		}

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "flag", 0);
        }
    }
}
