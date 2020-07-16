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

﻿if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_epexparrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_epexparrearscopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--setuser 'amm'
--closeyear_epexparrearscopy 2017
CREATE    PROCEDURE [closeyear_epexparrearscopy]
(
	@ayear int
)
AS BEGIN
	
DECLARE @idepexp int
DECLARE @idacc  varchar(38)
DECLARE @idupb varchar(36)
DECLARE @nphase tinyint
DECLARE @nlevel tinyint
DECLARE @curramount decimal(19,2)
DECLARE @amount2 decimal(19,2)
DECLARE @amount3 decimal(19,2)
DECLARE @amount4 decimal(19,2)
DECLARE @amount5 decimal(19,2)
--DECLARE @available decimal(19,2)
DECLARE @payed decimal(19,2)
DECLARE @newidacc varchar(38)
DECLARE @nextayear int

SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
	
--fase 1 dove c'è residuo
INSERT INTO epexpyear	(idepexp, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepexp,@nextayear, AL.newidacc, EY.idupb,
			isnull((SELECT SUM(	case when isnull(E3.flagvariation,'N')='N' then ED.amount else -ED.amount end ) /*Se l'impegno è una Nota di var.,il conto di costo viene movimentato in Avere*/
				FROM entrydetail ED
					join account A2		on ED.idacc = A2.idacc
					join epexpyear EY3		on EY3.idepexp = ED.idepexp and EY3.ayear = ED.yentry
					JOIN epexp E3			ON E3.idepexp = ED.idepexp
				WHERE E3.paridepexp = EY.idepexp	AND ED.yentry = @ayear 	and (( A2.flagaccountusage & 320)<> 0) ),0) /* payed */
				+ ET.curramount+ isnull(ET.curramount2,0),
				ET.curramount3,ET.curramount4,ET.curramount5,null,
					'EpExparrearscopy', GETDATE(), 'EpExparrearscopy', GETDATE() 	
from epexpyear EY 
 join epexptotal ET on ET.idepexp=EY.idepexp and ET.ayear=EY.ayear
 join epexp E on EY.idepexp=E.idepexp
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epexpyear EY2 on EY2.idepexp=EY.idepexp and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepexp is null and E.nphase=1
  and
 (isnull((SELECT SUM(case when isnull(E3.flagvariation,'N')='N' then ED.amount else -ED.amount end ) 
				FROM entrydetail ED
					join account A2		on ED.idacc = A2.idacc
					join epexpyear EY3		on EY3.idepexp = ED.idepexp and EY3.ayear = ED.yentry
					JOIN epexp E3			ON E3.idepexp = ED.idepexp
				WHERE E3.paridepexp = EY.idepexp	AND ED.yentry = @ayear 	and (( A2.flagaccountusage & 320)<> 0) ),0) /* payed */
				+ ET.curramount+ isnull(ET.curramount2,0) <>0 or  
						isnull(ET.curramount3,0) <>0 or  isnull(ET.curramount4,0)<>0 or  isnull(ET.curramount5,0) <>0
 )
 
print 'fase 1 ' 	
--fase 2 dove c'è residuo
INSERT INTO epexpyear	(idepexp, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepexp,@nextayear, AL.newidacc, EY.idupb,
			isnull(( SELECT SUM(case when isnull(E2.flagvariation,'N')='N' then ED.amount else -ED.amount end )	 /*Se l'impegno è una Nota di var.,il conto di costo viene movimentato in Avere*/
					FROM entrydetail ED
					join account A2		on ED.idacc = A2.idacc
					JOIN epexp E2			ON E2.idepexp = ED.idepexp
					WHERE ED.yentry = @ayear AND ED.idepexp = EY.idepexp	and (( A2.flagaccountusage & 320)<> 0) ),0) /* payed */
				+ ET.curramount+ isnull(ET.curramount2,0),ET.curramount3,ET.curramount4,ET.curramount5,null,
					'EpExparrearscopy', GETDATE(), 'EpExparrearscopy', GETDATE() 	
from epexpyear EY 
 join epexptotal ET on ET.idepexp=EY.idepexp and ET.ayear=EY.ayear
 join epexp E on EY.idepexp=E.idepexp
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epexpyear EY2 on EY2.idepexp=EY.idepexp and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepexp is null and E.nphase=2
  and
	(isnull(( SELECT SUM(case when isnull(E2.flagvariation,'N')='N' then ED.amount else -ED.amount end )	 /*Se l'impegno è una Nota di var.,il conto di costo viene movimentato in Avere*/
					FROM entrydetail ED
					join account A2		on ED.idacc = A2.idacc
					JOIN epexp E2			ON E2.idepexp = ED.idepexp
					WHERE ED.yentry = @ayear	AND ED.idepexp = EY.idepexp	and (( A2.flagaccountusage & 320)<> 0) ),0) /* payed */
				+ ET.curramount+ isnull(ET.curramount2,0) <>0 or  
						isnull(ET.curramount3,0) <>0 or  isnull(ET.curramount4,0)<>0 or  isnull(ET.curramount5,0) <>0
	)

print 'fase 2'
--fase 1 ove ci sono saldi vari non a zero
INSERT INTO epexpyear	(idepexp, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepexp,@nextayear, AL.newidacc, EY.idupb, 0,0,0,0,null,  'EpExparrearscopy', GETDATE(), 'EpExparrearscopy', GETDATE() 	
from epexpyear EY 
 join epexptotal ET on ET.idepexp=EY.idepexp and ET.ayear=EY.ayear
 join epexp E on EY.idepexp=E.idepexp
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epexpyear EY2 on EY2.idepexp=EY.idepexp and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepexp is null and E.nphase=1
  and  exists (select sum(ED.amount),ED.idacc from entrydetail ED
					join account A on ED.idacc= A.idacc
					join epexp EE on EE.idepexp=ED.idepexp
					where (A.flagaccountusage & (16+32+1+2+4096))<>0
							and EE.paridepexp=E.idepexp
							and ED.yentry=  @ayear
					group by ED.idacc
					having sum(ED.amount)<>0 )

print 'fase 1 bis'
--fase 2 ove ci sono saldi vari non a zero
INSERT INTO epexpyear	(idepexp, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepexp,@nextayear, AL.newidacc, EY.idupb, 0,0,0,0,null,  'EpExparrearscopy', GETDATE(), 'EpExparrearscopy', GETDATE() 	
from epexpyear EY 
 join epexptotal ET on ET.idepexp=EY.idepexp and ET.ayear=EY.ayear
 join epexp E on EY.idepexp=E.idepexp
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epexpyear EY2 on EY2.idepexp=EY.idepexp and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepexp is null and E.nphase=2
  and  exists (select sum(ED.amount),ED.idacc from entrydetail ED
					join account A on ED.idacc= A.idacc
					where (A.flagaccountusage & (16+32+1+2+4096))<>0 --ratei attivi,passivi,debiti,crediti,f.accantonamento
							and ED.idepexp=E.idepexp
							and ED.yentry=  @ayear
					group by ED.idacc
					having sum(ED.amount)<>0 )
print 'fase 2 bis'

--fase 1 ove ci sono le fasi due per motivi indecifrabili
INSERT INTO epexpyear	(idepexp, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepexp,@nextayear, AL.newidacc, EY.idupb, 0,0,0,0,null,  'EpExparrearscopy', GETDATE(), 'EpExparrearscopy', GETDATE() 	
from epexpyear EY 
 join epexptotal ET on ET.idepexp=EY.idepexp and ET.ayear=EY.ayear
 join epexp E on EY.idepexp=E.idepexp
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epexpyear EY2 on EY2.idepexp=EY.idepexp and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepexp is null and E.nphase=2
	and exists (select * from  epexp E3 
					join epexpyear EY3 on E3.idepexp = EY3.idepexp 
					where  E3.paridepexp=E.idepexp
							and EY3.ayear=  @ayear+1 	 ) 

print 'fase 1 tris'
exec rebuild_epexptotal @nextayear

exec rebuild_upbepexptotal @nextayear
 
--CREATE TABLE #info (msg varchar(800))
--INSERT INTO #info
--VALUES('Gli impegni di budget, per la quota non pagata, sono stati trasferiti all''esercizio ' + @nextayearstr)
	
	
--SELECT * FROM #info
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
	