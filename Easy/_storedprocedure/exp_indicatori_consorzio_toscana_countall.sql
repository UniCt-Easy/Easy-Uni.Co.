
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_indicatori_consorzio_toscana_countall]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_indicatori_consorzio_toscana_countall]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
--exec exp_indicatori_consorzio_toscana_countall 2023, {d '2023-01-01'}, {d '2023-07-16'}  
 
CREATE PROCEDURE [exp_indicatori_consorzio_toscana_countall]
(
	@ayear			int,
	@start			date ,
	@stop			date  
)
AS
BEGIN
 

/*
come da colloquio odierno con il Dot. Perna sono a richiedere le modalità per l’estrapolazione dei seguenti dati attraverso l’uso del software in uso:

su base annuale
n° risconti
n° documenti propedeutici prodotti
n° bozze predisposte
n° beni inventario
 

su base mensile:
n° impegni e accertamenti
n° liquidazioni e pagamenti
n° riscossioni/n° canali di riscossione
n° variazioni di BUDGET (accountvar)
*/
CREATE TABLE #data_risconti (
	counters  int,
)

CREATE TABLE #data_doc_propedeutici (
	counters  int,
)

/*
contratto occasionale 
parcella
altricompensi
missione
cedolino parasubordinati
fattura 
contratto passivo
contratto attivo
fondo economale
elaborazione stipendiale ?
distinta trasmissione pagamento?
distinta trasmissione incasso ?
*/

INSERT INTO #data_doc_propedeutici
SELECT
(SELECT COUNT(*) FROM casualcontract where ycon = @ayear and adate between @start and @stop)
+
(SELECT COUNT(*) FROM profservice where ycon = @ayear and adate between @start and @stop)
+
(SELECT COUNT(*) FROM wageaddition where ycon = @ayear and adate between @start and @stop)
+
(SELECT COUNT(*) FROM itineration where yitineration = @ayear and adate between @start and @stop)
+
(SELECT COUNT(*) FROM payroll  where fiscalyear = @ayear and ct between @start and @stop)
+
(SELECT COUNT(*) FROM invoice  where yinv = @ayear and adate between @start and @stop)
+
(SELECT COUNT(*) FROM estimate    where yestim= @ayear and adate between @start and @stop)
+
(SELECT COUNT(*) FROM mandate   where yman= @ayear and adate between @start and @stop)
+
(SELECT COUNT(*) FROM pettycashoperation where yoperation= @ayear and adate between @start and @stop
and   (flag & 8) <> 0 --- 'S'
)
 
 
CREATE TABLE #data_bozze_predisposte (
	counters  int,
)

-- beni inventario
CREATE TABLE #data_asset(
	counters int,
)
INSERT INTO #data_asset
SELECT COUNT(*)  FROM asset JOIN assetacquire  ON asset.nassetacquire = assetacquire.nassetacquire
WHERE YEAR(adate) = @ayear AND   adate between @start and @stop and asset.idpiece = 1

 
---impegni di budget
CREATE TABLE #data_epexp(
	counters int,
)
INSERT INTO #data_epexp
SELECT COUNT(*) FROM epexp WHERE yepexp = @ayear and adate between @start and @stop and nphase = 2

---accertamenti di budget
CREATE TABLE #data_epacc(
	counters int,
)
INSERT INTO #data_epacc
SELECT COUNT(*) FROM epacc  WHERE yepacc = @ayear and adate between @start and @stop and nphase = 2

--- pagamenti
CREATE TABLE #data_expenselast(
	counters int,
)
 INSERT INTO #data_expenselast
 SELECT COUNT(*) FROM expenselast join expense ON expenselast.idexp = expense.idexp WHERE ymov = @ayear and adate between @start and @stop

--- riscossioni
CREATE TABLE #data_incomelast(
	counters int,
)
 INSERT INTO #data_incomelast
 SELECT COUNT(*) FROM incomelast join income ON incomelast.idinc = income.idinc  WHERE ymov = @ayear and adate between @start and @stop

-- variazioni budget
CREATE TABLE #data_accountvar(
	counters int,
)
 --INSERT INTO #data_accountvar
 --SELECT COUNT(accountvar.nvar) FROM accountvardetail 
 --join accountvar on accountvardetail.yvar = accountvar.yvar  and 
 --accountvardetail.nvar  = accountvar.nvar   
 --WHERE accountvardetail.yvar = @ayear and accountvar.adate between @start and @stop
 
  INSERT INTO #data_accountvar
 SELECT COUNT(accountvar.nvar) FROM accountvar 
  
 WHERE accountvar.yvar = @ayear and accountvar.adate between @start and @stop

 CREATE TABLE #result (Descrizione varchar(50), num int)
 INSERT INTO #result (Descrizione, num)
 SELECT ' - RILEVAZIONE DAL ' + convert(varchar, @start, 1) + ' AL ' + convert(varchar,@stop, 1) , null
 UNION
 SELECT '1 - Risconti' AS 'Descrizione', counters as 'n°' FROM  #data_risconti
 UNION 
 SELECT '2 - Doc. Propedeutici' AS 'Descrizione', counters as 'n°' FROM  #data_doc_propedeutici
 UNION 
 SELECT '3 - Bozze Predisposte' AS 'Descrizione',  counters as 'n°' FROM #data_bozze_predisposte
 UNION 
 SELECT '4 - Cespiti inventariati' AS 'Descrizione',  counters as 'n°' FROM  #data_asset
 UNION 
 SELECT '5 - Impegni di Budget' AS 'Descrizione',  counters as 'n°' FROM   #data_epexp
 UNION 
 SELECT '6 - Accertamenti di Budget' AS 'Descrizione',  counters as 'n°' FROM   #data_epacc
 UNION 
 SELECT '7 - Pagamenti' AS 'Descrizione',  counters as 'n°' FROM  #data_expenselast
 UNION 
 SELECT '8 - Riscossioni' AS 'Descrizione',  counters as 'n°' FROM  #data_incomelast
 UNION 
 SELECT '9 - Variazioni di Budget' AS 'Descrizione',  counters as 'n°' FROM  #data_accountvar
 ORDER BY 1

 SELECT  descrizione as 'Descrizione', num as 'n° rilevazioni' FROM  #result
END
