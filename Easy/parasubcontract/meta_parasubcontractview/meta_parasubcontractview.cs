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
using System.Diagnostics;

namespace meta_parasubcontractview {//meta_contrattoview//
	/// <summary>
	/// Summary description for Meta_contrattoview.
	/// </summary>
	public class Meta_parasubcontractview : Meta_easydata {
        string CONTRATTI_CON_PROBLEMI = "contratti con problemi";

		public Meta_parasubcontractview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "parasubcontractview") {
			ListingTypes.Add("default");
            ListingTypes.Add("contratti con problemi");
		}
        private string[] mykey = new string[] { "ayear", "idcon" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            if (ListingType == "default") return "idcon desc";
            return base.GetSorting(ListingType);
        }
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"", -1);
                int nPos = 1;
                DescribeAColumn(T, "ycon", "Esercizio", nPos++);
                DescribeAColumn(T, "ncon", "Num. Contratto", nPos++);
                DescribeAColumn(T, "idreg", ".Cod. Percipiente", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "matricula", "Matricola", nPos++);
                DescribeAColumn(T, "duty", "Mansione", nPos++);
                DescribeAColumn(T, "idpayrollkind", "Cod. Descr. Cedolino", nPos++);
                DescribeAColumn(T, "payroll", "Descr. Cedolino", nPos++);
                DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
                DescribeAColumn(T, "service", "Prestazione", nPos++);
                DescribeAColumn(T, "idresidence", "", nPos++);
                DescribeAColumn(T, "city", "Comune", nPos++);
                DescribeAColumn(T, "idcountry", "", nPos++);
                DescribeAColumn(T, "country", "Provincia", nPos++);
                DescribeAColumn(T, "employed", "In Forza", nPos++);
                DescribeAColumn(T, "payrollccinfo", "CC su Cedolino", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "monthlen", "Durata (Mesi)", nPos++);
                DescribeAColumn(T, "grossamount", "Importo Totale", nPos++);
                DescribeAColumn(T, "activitycode", "Codice Attività", nPos++);
                DescribeAColumn(T, "activity", "Attività Prev. INPS", nPos++);
                DescribeAColumn(T, "idotherinsurance", "Codice Forma Ass.", nPos++);
                DescribeAColumn(T, "otherinsurance", "Altra Forma Ass.", nPos++);
                DescribeAColumn(T, "idpat", "", nPos++);
                DescribeAColumn(T, "patcode", "Cod. Pos. Ass. Terr.", nPos++);
                DescribeAColumn(T, "pat", "Pos. Ass. Terr.", nPos++);
                DescribeAColumn(T, "notaxappliance", "Tipo No Tax Area", nPos++);
                DescribeAColumn(T, "highertax", "Maggiore Ritenuta", nPos++);
                DescribeAColumn(T, "idmatriculabook", "Cod. Tipo Libro", nPos++);
                DescribeAColumn(T, "matriculabook", "Tipo Libro Matricola", nPos++);
                DescribeAColumn(T, "regionaltax", "Importo Add. Regionale", nPos++);
                DescribeAColumn(T, "countrytax", "Importo Add. Provinciale", nPos++);
                DescribeAColumn(T, "citytax", "Importo Add. Comunale", nPos++);
                DescribeAColumn(T, "ratequantity", "Num. Rate", nPos++);
                DescribeAColumn(T, "startmonth", "Mese Inizio", nPos++);
                DescribeAColumn(T, "suspendedregionaltax", "Add. Reg. Sospese", nPos++);
                DescribeAColumn(T, "suspendedcountrytax", "Add. Prov. Sospese", nPos++);
                DescribeAColumn(T, "suspendedcitytax", "Add. Com. Sospese", nPos++);
                DescribeAColumn(T, "idemenscontractkind", "Codice Rapporto EMENS", nPos++);
                DescribeAColumn(T, "emenscontractkind", "Rapporto EMENS", nPos++);

                //task 10515
                DescribeAColumn(T, "codemotive", "Causale", nPos++);
                DescribeAColumn(T, "codemotivedebit", "Causale di debito", nPos++);
                DescribeAColumn(T, "codemotivedebit_crg", "Causale di debito aggiornata", nPos++);

                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
            }
		}


        public DataTable getContrattiConProblemi() {
            string query = @"--select * from tablename where oldtable='service'
--select * from colname where oldcol='rec770kind'
--più di un parasubcontract non conguagliato per lo stesso creditore
	select distinct ce1.idcon
	from payroll ce1 
	join parasubcontract co1 on ce1.flagbalance='S' and ce1.idcon=co1.idcon and ce1.disbursementdate is null and fiscalyear=" + GetSys("esercizio") + @"
	join payroll ce2 on ce2.flagbalance='S' and ce1.idpayroll<>ce2.idpayroll and ce2.disbursementdate is null and ce2.fiscalyear=ce1.fiscalyear
	join parasubcontract co2 on ce2.idcon=co2.idcon and co1.idreg=co2.idreg
union
--contratti con cud che puntano allo stesso altro parasubcontract
	select cud1.idcon
	from exhibitedcud cud1
	join parasubcontractyear on parasubcontractyear.idcon=cud1.idcon and ayear=" + QHS.quote(GetSys("esercizio")) + @"
	join exhibitedcud cud2
		on cud1.idlinkedcon=cud2.idlinkedcon and (cud1.idcon<>cud2.idcon or cud1.idexhibitedcud<>cud2.idexhibitedcud)
union
--contratti che non puntano ad un parasubcontract precedente
	select c1.idcon
	from parasubcontract c1
	join parasubcontractyear ic1 on c1.idcon=ic1.idcon and ic1.ayear=" + QHS.quote(GetSys("esercizio")) + @"
	join payroll on flagbalance='S' and disbursementdate is not null and fiscalyear=ic1.ayear and payroll.idcon<>c1.idcon
    JOIN service ON service.idser = c1.idser
	join parasubcontract c2 on c2.idcon=payroll.idcon and c2.idreg=c1.idreg
	where not exists (select * from exhibitedcud where exhibitedcud.idlinkedcon=payroll.idcon)
    AND ISNULL(service.certificatekind,'') = 'U'
	and (not exists (select * from payroll c2 where c2.idcon=c1.idcon and flagbalance='S' and disbursementdate is not null)
	or exists (select * from exhibitedcud cp where cp.idcon=c1.idcon))
union
--contratti conguagliati che hanno cud che non puntano a nulla
	select distinct exhibitedcud.idcon
	from exhibitedcud
	where idlinkedcon is null and exhibitedcud.fiscalyear=" + QHS.quote(GetSys("esercizio")) + @"
	and (cfotherdeputy is null or cfotherdeputy=
	(select cf from license))
union
--contratti dello stesso creditore tutti conguagliati e senza cud
select c1.idcon from parasubcontract c1
join parasubcontractyear i1 on c1.idcon=i1.idcon and ayear=" + QHS.quote(GetSys("esercizio")) + @"
where not exists (
	select * from parasubcontract c2 join payroll 
	on payroll.idcon=c2.idcon and payroll.fiscalyear=i1.ayear and c2.idreg=c1.idreg and payroll.flagbalance='S' 
	and (payroll.disbursementdate is null or exists (select * from exhibitedcud where exhibitedcud.idcon=c2.idcon))
) and (select count(*) from parasubcontract c3 join parasubcontractyear i3 on c3.idcon=i3.idcon and i3.ayear=i1.ayear and c3.idreg=c1.idreg)>1
union
--contratti di creditori che erano stati pagati col wizard
	select distinct idcon from parasubcontract
	join expense on parasubcontract.idreg=expense.idreg
	join service on expense.idser=service.idser and rec770kind='G'
	join expenseyear on expense.idexp=expenseyear.idexp and expenseyear.ayear=" + GetSys("esercizio") + @"
	join expensetax on expense.idexp=expensetax.idexp
	and not exists (select * from expensepayroll where expense.idexp like idexp+'%')";
            return Conn.SQLRunner(query);
        }

        override public string GetStaticFilter(string ListingType) {
            if (ListingType == CONTRATTI_CON_PROBLEMI) {
                DataTable t = getContrattiConProblemi();
                string filtro = QueryCreator.ColumnValues(t, null, "idcon", true);
                if (filtro == "") {
                    return "(idcon<>idcon)";
                }
                return "(idcon in (" + filtro + "))";
            }
            return base.GetStaticFilter(ListingType);
        }	
	}
}