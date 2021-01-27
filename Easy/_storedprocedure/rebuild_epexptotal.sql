
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_epexptotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_epexptotal]
GO
--setuser 'amm'
--rebuild_epexptotal 2015
CREATE PROCEDURE rebuild_epexptotal (
	@ayear int =  NULL
)
AS BEGIN
	/*
	Nei calcoli ESCLUDO le scritture di tipo
	6	Epilogo
	10	Rilevazione Risultato Economico
	11	Epilogo conto economico
	12	Epilogo stato patrimoniale
	*/
	DECLARE @curryear int
	DELETE from epexptotal where (@ayear is null)  OR ayear=@ayear
	
	INSERT INTO epexptotal 
		(
			idepexp,ayear,	curramount,	curramount2,curramount3,	curramount4,curramount5,cost,debit,rateo
		)
		SELECT
			epexpyear.idepexp,	epexpyear.ayear,	epexpyear.amount,			epexpyear.amount2,
			epexpyear.amount3,	epexpyear.amount4,	epexpyear.amount5,0,0,0
		FROM epexpyear
		WHERE  (@ayear is null)  OR ayear=@ayear;

		with sumvar(idepexp,yvar,amount,amount2,amount3,amount4,amount5) as 
		(select idepexp,yvar,sum(amount),sum(amount2),sum(amount3),
					sum(amount4),sum(amount5) from epexpvar group by idepexp,yvar)
		update epexptotal set curramount = isnull(curramount,0) + isnull(sumvar.amount,0),
					 curramount2 = isnull(curramount2,0) + isnull(sumvar.amount2,0),
					  curramount3 = isnull(curramount3,0) + isnull(sumvar.amount3,0),
					   curramount4 = isnull(curramount4,0) + isnull(sumvar.amount4,0),
					    curramount5 = isnull(curramount5,0) + isnull(sumvar.amount5,0)
		from epexptotal
		join sumvar on epexptotal.idepexp=sumvar.idepexp 
					and epexptotal.ayear=sumvar.yvar
					and ((@ayear is null)  OR epexptotal.ayear=@ayear)
		 
	;
		with sumexptot(idepexp,ayear,amount,amount2,amount3,amount4,amount5) as
		(select E.paridepexp, ET.ayear, SUM(ET.curramount),SUM(ET.curramount2),SUM(ET.curramount3),
						SUM(ET.curramount4),SUM(ET.curramount5) from 
				epexptotal ET
				join epexp e on e.idepexp=ET.idepexp
				WHERE  (@ayear is null) OR ET.ayear=@ayear
				group by E.paridepexp, ET.ayear
		)
		UPDATE epexptotal
		SET available = ISNULL(ET.curramount, 0) - isnull(SE.amount,0),
			available2 = ISNULL(ET.curramount2, 0) - isnull(SE.amount2,0),
			available3 = ISNULL(ET.curramount3, 0) - isnull(SE.amount3,0),
			available4 = ISNULL(ET.curramount4, 0) - isnull(SE.amount4,0),
			available5 = ISNULL(ET.curramount5, 0) - isnull(SE.amount5,0)
		from epexptotal ET
		left outer join sumexptot SE on ET.idepexp=SE.idepexp and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;

	with sumcosttot(idepexp,ayear,amount) as
		(select ED.idepexp, ED.yentry, SUM(ED.amount) from 
			entrydetail ED JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 320 <>0) and ED.idepexp is not null and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepexp, ED.yentry
		)
		UPDATE epexptotal
		SET cost = -SE.amount
		from epexptotal ET
			join sumcosttot SE on ET.idepexp=SE.idepexp and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;


	with sumdebittot(idepexp,ayear,amount) as
		(select ED.idepexp, ED.yentry, SUM(ED.amount) from 
			entrydetail ED JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 16 <>0) and ED.idepexp is not null
				and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepexp, ED.yentry
		)
		UPDATE epexptotal
		SET debit = SE.amount
		from epexptotal ET
			join sumdebittot SE on ET.idepexp=SE.idepexp and ET.ayear=SE.ayear  
			where ((@ayear is null)  OR ET.ayear=@ayear)
;

	with sumcredittot(idepexp,ayear,amount) as
		(select ED.idepexp, ED.yentry, SUM(ED.amount) from 
			entrydetail ED JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 32 <>0) and ED.idepexp is not null
				and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepexp, ED.yentry
		)
		UPDATE epexptotal
		SET debit = isnull(ET.debit,0)-SE.amount
		from epexptotal ET
			join sumcredittot SE on ET.idepexp=SE.idepexp and ET.ayear=SE.ayear  
			where ((@ayear is null)  OR ET.ayear=@ayear)
;

	with sumrateotot(idepexp,ayear,amount) as
		(select ED.idepexp, ED.yentry, SUM(ED.amount) from 
			entrydetail ED JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 2 <>0) and ED.idepexp is not null
				and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepexp, ED.yentry
		)
		UPDATE epexptotal
		SET rateo = -SE.amount
		from epexptotal ET
			join sumrateotot SE on ET.idepexp=SE.idepexp and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;

	with fondoaccantonamentotot(idepexp,ayear,amount) as
		(select ED.idepexp, ED.yentry, SUM(ED.amount) from 
			entrydetail ED JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 4096 <>0) and ED.idepexp is not null
				and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepexp, ED.yentry
		)
		UPDATE epexptotal
		SET accantonamento = -SE.amount
		from epexptotal ET
			join fondoaccantonamentotot SE on ET.idepexp=SE.idepexp and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;



END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
