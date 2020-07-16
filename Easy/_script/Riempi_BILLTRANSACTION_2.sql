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

﻿/*
Per ogni bill, con active = N, fa una insert in billtransaction, l'importo DA esitare, in termini di total - reduction - covered.
*/
DECLARE @ayear int
SET @ayear = 2014  -->>>>>>>> ESERCIZIO

create table #billtransactionTemp(
ybilltran	smallint,
nbilltranTEMP int identity(1,1),
nbill	int,
amount	decimal(19,2),
adate	datetime,
kind	char(1)
)

INSERT INTO #billtransactionTemp (ybilltran,nbill,amount,adate,kind)
SELECT ybill, nbill, isnull(total,0) - isnull(reduction,0) - 
		isnull(  (select sum(amount) from billtransaction BT where BT.ybilltran=billview.ybill and
								BT.nbill=billview.nbill and BT.kind=billview.billkind )
				 ,0), 				
		adate, billkind
FROM billview 
WHERE active = 'N' and ybill = @ayear
	and isnull(total,0) - isnull(reduction,0) - isnull(covered,0) >0


-- select * from #billtransactionTemp
DECLARE @nbilltran   int 
SET 	@nbilltran = ISNULL((SELECT MAX(nbilltran) FROM billtransaction WHERE ybilltran = @ayear),0) +1


INSERT INTO billtransaction (ybilltran,nbilltran,nbill,amount,adate,kind,ct,cu,lt,lu)
SELECT ybilltran,nbilltranTEMP+@nbilltran,nbill,amount,adate,kind, getdate(), 'script2_insert',getdate(),'script2_insert'
FROM #billtransactionTemp


drop table #billtransactionTemp


	