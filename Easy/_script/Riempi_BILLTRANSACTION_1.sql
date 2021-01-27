
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


DECLARE @ayear int
SET @ayear = 2014  -->>>>>>>> ESERCIZIO

create table #billtransactionTemp(
ybilltran	smallint,
nbilltranTEMP int identity(1,1),
nbill	int,
amount	decimal(19,2),
adate	datetime,
kind	char(1),
idbankimport int
)

-- SPESA
INSERT INTO #billtransactionTemp (ybilltran,nbill,amount,adate,kind,idbankimport)
SELECT BT.yban, E.nbill, BT.amount, BT.transactiondate, 'D',BT.idbankimport
FROM banktransaction BT
JOIN expenselast E
	ON BT.idexp = E.idexp
WHERE BT.yban = @ayear and BT.kind='D' and E.nbill is not null and BT.transactiondate is not null

-- ENTRATA
INSERT INTO #billtransactionTemp (ybilltran,nbill,amount,adate,kind,idbankimport)
SELECT BT.yban, I.nbill, BT.amount, BT.transactiondate, 'C', BT.idbankimport
FROM banktransaction BT
JOIN incomelast I
	ON BT.idinc = I.idinc
WHERE BT.yban = @ayear  and BT.kind='C' and I.nbill is not null and BT.transactiondate is not null

--select * from #billtransactionTemp

INSERT INTO billtransaction (ybilltran,nbilltran,nbill,amount,adate,kind,idbankimport,ct,cu,lt,lu)
SELECT ybilltran,nbilltranTEMP,nbill,amount,adate,kind,idbankimport, getdate(), 'script1_insert',getdate(),'script1_insert'
FROM #billtransactionTemp


drop table #billtransactionTemp

-- update banktransaction set kind = 'C' where kpro is not null and isnull(kind,'q')<>'C'
-- update banktransaction set kind = 'D' where kpay is not null  and isnull(kind,'q')<>'D'
