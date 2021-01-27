
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_avcptrasmission {
    public class Meta_avcptrasmission : Meta_easydata {
        public Meta_avcptrasmission(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "avcptrasmission") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default": {
                    DefaultListType = "default";
                    Name = "Trasmissione AVCP";
                    return MetaData.GetFormByDllName("avcptrasmission_default");
                }
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "annoRiferimento", GetSys("esercizio"));
            SetDefault(PrimaryTable, "dataUltimoAggiornamentoDataset", DateTime.Now);
            SetDefault(PrimaryTable, "datapubblicazionedataset", DateTime.Now);
            object cf = Conn.DO_READ_VALUE("license", null, "cf");
            SetDefault(PrimaryTable, "codiceFiscaleProp", cf);
            object agency = Conn.DO_READ_VALUE("license", null, "agencyname");
            SetDefault(PrimaryTable, "denominazione", agency);
            SetDefault(PrimaryTable, "licenza", "IODL");
            SetDefault(PrimaryTable, "titolo", "Pubblicazione ai fini della legge 190");
            SetDefault(PrimaryTable, "abstract", "Pubblicazione ai fini della legge 190, rif. anno "+
                GetSys("esercizio").ToString());
            SetDefault(PrimaryTable, "entePubblicatore", agency);
        
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idavcptransmission"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
           
            return true;
        }

    }
}
