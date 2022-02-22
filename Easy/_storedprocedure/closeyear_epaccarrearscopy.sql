
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_epaccarrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_epaccarrearscopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--setuser 'amm'
--closeyear_epaccarrearscopy 2017
CREATE    PROCEDURE [closeyear_epaccarrearscopy]
(
	@ayear int
)
AS BEGIN
	
DECLARE @idepacc int
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
INSERT INTO epaccyear	(idepacc, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepacc,@nextayear, AL.newidacc, EY.idupb,
											/* mettiamo il - perchè i conti di ricavo vengono movimentati in avere +, e qui dobbiamo sottrarre l'incasso. 
											Se però l'accertamento è una Nota di var.,il conto di ricavo viene movimentato in Dare*/
			isnull((SELECT SUM(case when isnull(E3.flagvariation,'N')='N' then -ED.amount else ED.amount end )
				FROM entrydetail ED
					join account A2		on ED.idacc = A2.idacc
					join epaccyear EY3		on EY3.idepacc = ED.idepacc and EY3.ayear = ED.yentry
					JOIN epacc E3			ON E3.idepacc = ED.idepacc
				WHERE E3.paridepacc = EY.idepacc	AND ED.yentry = @ayear 	and (( A2.flagaccountusage & 128  )<> 0) ),0) --> incassato
				+ ET.curramount+ isnull(ET.curramount2,0),ET.curramount3,ET.curramount4,ET.curramount5,null,
					'epaccarrearscopy', GETDATE(), 'epaccarrearscopy', GETDATE() 	
from epaccyear EY 
 join epacctotal ET on ET.idepacc=EY.idepacc and ET.ayear=EY.ayear
 join epacc E on EY.idepacc=E.idepacc
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epaccyear EY2 on EY2.idepacc=EY.idepacc and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepacc is null and E.nphase=1
  and
 (isnull((SELECT  SUM(case when isnull(E3.flagvariation,'N')='N' then -ED.amount else ED.amount end )
				FROM entrydetail ED
					join account A2		on ED.idacc = A2.idacc
					join epaccyear EY3		on EY3.idepacc = ED.idepacc and EY3.ayear = ED.yentry
					JOIN epacc E3			ON E3.idepacc = ED.idepacc
				WHERE E3.paridepacc = EY.idepacc	AND ED.yentry = @ayear 	and (( A2.flagaccountusage & 128  )<> 0) ),0) --> incassato
				+ ET.curramount+ isnull(ET.curramount2,0) <>0 or  
						isnull(ET.curramount3,0) <>0 or  isnull(ET.curramount4,0)<>0 or  isnull(ET.curramount5,0) <>0
 )
print 'fase 1 ' 	
--fase 2 dove c'è residuo
INSERT INTO epaccyear	(idepacc, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepacc,@nextayear, AL.newidacc, EY.idupb,
											/* mettiamo il - perchè i conti di ricavo vengono movimentati in avere +, e qui dobbiamo sottrarre l'incasso. 
											Se però l'accertamento è una Nota di var.,il conto di ricavo viene movimentato in Dare*/
			isnull(( SELECT  SUM(case when isnull(E2.flagvariation,'N')='N' then -ED.amount else ED.amount end )  
					FROM entrydetail ED
					join account A2	on ED.idacc = A2.idacc
					JOIN epacc E2			ON E2.idepacc = ED.idepacc
					WHERE ED.yentry = @ayear	AND ED.idepacc = EY.idepacc	and (( A2.flagaccountusage & 128  )<> 0) ),0) --> incassato
				+ ET.curramount+ isnull(ET.curramount2,0),ET.curramount3,ET.curramount4,ET.curramount5,null,
					'epaccarrearscopy', GETDATE(), 'epaccarrearscopy', GETDATE() 	
from epaccyear EY 
 join epacctotal ET on ET.idepacc=EY.idepacc and ET.ayear=EY.ayear
 join epacc E on EY.idepacc=E.idepacc
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epaccyear EY2 on EY2.idepacc=EY.idepacc and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepacc is null and E.nphase=2
  and
	(isnull(( SELECT  SUM(case when isnull(E2.flagvariation,'N')='N' then -ED.amount else ED.amount end )  
					FROM entrydetail ED
					join account A2		on ED.idacc = A2.idacc
					JOIN epacc E2			ON E2.idepacc = ED.idepacc
					WHERE ED.yentry = @ayear	AND ED.idepacc = EY.idepacc	and (( A2.flagaccountusage & 128  )<> 0) ),0) --> incassato
					+ ET.curramount+ isnull(ET.curramount2,0) <>0 or  
						isnull(ET.curramount3,0) <>0 or  isnull(ET.curramount4,0)<>0 or  isnull(ET.curramount5,0) <>0
	)

print 'fase 2'
--fase 1 ove ci sono saldi vari non a zero
INSERT INTO epaccyear	(idepacc, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepacc,@nextayear, AL.newidacc, EY.idupb, 0,0,0,0,null,  'epaccarrearscopy', GETDATE(), 'epaccarrearscopy', GETDATE() 	
from epaccyear EY 
 join epacctotal ET on ET.idepacc=EY.idepacc and ET.ayear=EY.ayear
 join epacc E on EY.idepacc=E.idepacc
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epaccyear EY2 on EY2.idepacc=EY.idepacc and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepacc is null and E.nphase=1
  and  exists (select sum(ED.amount),ED.idacc from entrydetail ED
					join account A on ED.idacc= A.idacc
					join epacc EE on EE.idepacc=ED.idepacc
					where (A.flagaccountusage & (16+32+1+2))<>0
							and EE.paridepacc=E.idepacc
							and ED.yentry=  @ayear
					group by ED.idacc
					having sum(ED.amount)<>0 )

print 'fase 1 bis'
--fase 2 ove ci sono saldi vari non a zero
INSERT INTO epaccyear	(idepacc, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepacc,@nextayear, AL.newidacc, EY.idupb, 0,0,0,0,null,  'epaccarrearscopy', GETDATE(), 'epaccarrearscopy', GETDATE() 	
from epaccyear EY 
 join epacctotal ET on ET.idepacc=EY.idepacc and ET.ayear=EY.ayear
 join epacc E on EY.idepacc=E.idepacc
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epaccyear EY2 on EY2.idepacc=EY.idepacc and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepacc is null and E.nphase=2
  and  exists (select sum(ED.amount),ED.idacc from entrydetail ED
					join account A on ED.idacc= A.idacc
					where (A.flagaccountusage & (16+32+1+2))<>0 --ratei attivi,passivi,debiti,crediti,f.accantonamento
							and ED.idepacc=E.idepacc
							and ED.yentry=  @ayear
					group by ED.idacc
					having sum(ED.amount)<>0 )
print 'fase 2 bis'

--fase 1 ove ci sono le fasi due per motivi indecifrabili
INSERT INTO epaccyear	(idepacc, ayear, idacc, idupb, amount, amount2, amount3, amount4,amount5,  cu, ct, lu, lt)
SELECT EY.idepacc,@nextayear, AL.newidacc, EY.idupb, 0,0,0,0,null,  'epaccarrearscopy', GETDATE(), 'epaccarrearscopy', GETDATE() 	
from epaccyear EY 
 join epacctotal ET on ET.idepacc=EY.idepacc and ET.ayear=EY.ayear
 join epacc E on EY.idepacc=E.idepacc
 join accountlookup AL on AL.oldidacc = EY.idacc
 left outer join epaccyear EY2 on EY2.idepacc=EY.idepacc and EY2.ayear=@nextayear
 where EY.ayear=@ayear and EY2.idepacc is null and E.nphase=2
	and exists (select * from  epacc E3 
					join epaccyear EY3 on E3.idepacc = EY3.idepacc 
					where  E3.paridepacc=E.idepacc
							and EY3.ayear=  @ayear+1 	 ) 

print 'fase 1 tris'
exec rebuild_epacctotal @nextayear

exec rebuild_upbepacctotal @nextayear
 
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
 
