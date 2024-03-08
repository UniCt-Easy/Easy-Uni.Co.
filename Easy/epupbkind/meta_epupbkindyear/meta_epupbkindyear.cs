
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;


namespace meta_epupbkindyear {
    public class Meta_epupbkindyear : Meta_easydata {
        public Meta_epupbkindyear(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "epupbkindyear") {
			// listapermovbancario elenca in ordine di numero mandato filtrando solo l'esercizio corrente
    
		}

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
            SetDefault(PrimaryTable, "adjustmentkind", "L");
            //SetDefault(PrimaryTable, "adate", GetSys("datacontabile")); no         
        }

      
    }
}
