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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_casualcontractview//meta_contrattooccview//
{
	/// <summary>
	/// Summary description for Meta_contrattooccview.
	/// </summary>
	public class Meta_casualcontractview : Meta_easydata
	{
		public Meta_casualcontractview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "casualcontractview") 
		{
			ListingTypes.Add("default");
			ListingTypes.Add("epdebit");
		}

       
        public override string GetStaticFilter(string ListingType) {
			string filteresercizio = "(ayear='"+GetSys("esercizio")+"')";
			return filteresercizio;
		}

        private string[] mykey = new string[] { "ycon", "ncon", "ayear" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"",-1);
				int pos=1;
				DescribeAColumn(T,"ycon","Eserc. Contratto",pos++);
				DescribeAColumn(T,"ncon","Num. Contratto",pos++);
				DescribeAColumn(T,"registry","Percipiente",pos++);
				DescribeAColumn(T,"description","descrizione",pos++);
				DescribeAColumn(T,"codeser","Cod. Prestazione",pos++);
				DescribeAColumn(T,"service","Prestazione",pos++);
				DescribeAColumn(T,"start","Data Inizio",pos++);
				DescribeAColumn(T,"stop","Data Fine",pos++);
				DescribeAColumn(T,"adate","Data Contabile",pos++);
				DescribeAColumn(T,"ndays","Durata (Giorni)",pos++);
				DescribeAColumn(T,"feegross","Importo Totale",pos++);
                DescribeAColumn(T, "total", "Costo totale", pos++);
				DescribeAColumn(T,"completed","Contabilizzabile",pos++);
				DescribeAColumn(T,"activitycode","Codice Attivit‡",pos++);
				DescribeAColumn(T,"activity","Attivit‡ Prev. INPS",pos++);
				DescribeAColumn(T,"idotherinsurance","Codice Forma Ass.",pos++);
				DescribeAColumn(T,"otherinsurance","Altra Forma Ass.",pos++);
				DescribeAColumn(T,"idemenscontractkind","Codice Rapporto EMENS",pos++);
				DescribeAColumn(T,"emenscontractkind", "Rapporto EMENS",pos++);
                DescribeAColumn(T, "iduniqueregister", "Prog.Registro Unico", pos++);
                DescribeAColumn(T, "expiration", "Scadenza", pos++);
                DescribeAColumn(T, "expensekinddescription", "Natura spesa", pos++);
                DescribeAColumn(T, "codemotive", "Cod.Causale di costo", pos++);
                DescribeAColumn(T, "accmotive", "Causale di costo", pos++);
                DescribeAColumn(T, "codemotivedebit", "Cod.Causale di debito", pos++);
                DescribeAColumn(T, "accmotivedebit", "Causale di debito", pos++);
                DescribeAColumn(T, "codemotivedebit_crg", "Cod.Causale di debito aggiornata", pos++);
                DescribeAColumn(T, "accmotive_crg", "Causale di debito aggiornata", pos++);
                DescribeAColumn(T, "idaccmotivedebit_datacrg", "Data Correz. Causale di debito", pos++);
 
            }
		}
	}
}
