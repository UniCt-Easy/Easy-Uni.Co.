
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sort_auto_singleincome]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sort_auto_singleincome]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE          PROCEDURE [sort_auto_singleincome] 
(
	@ayear int,
	@idinc int,
	@idreg int,
	@idupb varchar(36),
	@start_nphase char(1),
	@stop_nphase char(1),
	@idfin int,
	@idman int,
	@incomeamount decimal (19,2),
	@parentidinc int =0
)
AS
CREATE TABLE #tmp (
	[idautosort] [int]  NULL,
	[idfin] [int] NULL,
	[idupb] [varchar](36) NULL,
	[idsorkindreg] [int] NULL,
	[idsorreg][int] NULL,
	[idman] [int]  NULL,
	[numerator] [int] NULL,
	[denominator] [int] NULL,
	[flagnodate][char](1) NULL,
	[defaultn1][varchar] (20)NULL,
	[defaultn2][varchar] (20)NULL,
	[defaultn3][varchar] (20)NULL,
	[defaultn4][varchar] (20)NULL,
	[defaultn5][varchar] (20)NULL,
	[defaultv1][varchar] (20)NULL,
	[defaultv2][varchar] (20)NULL,
	[defaultv3][varchar] (20)NULL,
	[defaultv4][varchar] (20)NULL,
	[defaultv5][varchar] (20)NULL,
	[idsorkind] [int] NOT NULL ,
	[idsor] [int] NULL,
	[idinc] [int] NULL ,
	[idsubclass] [smallint]  NULL ,
	[amount] [decimal](19, 2) NULL ,
	[description] [varchar] (150) NULL ,
	[noupdate] [smallint] NULL ,
	[nodelete] [smallint] NULL ,
	[txt] [text] NULL ,
	[rtf] [image] NULL ,
	[cu] [varchar] (50) NOT NULL ,
	[ct] [datetime] NOT NULL ,
	[lu] [varchar] (50) NOT NULL ,
	[lt] [datetime] NOT NULL ,
	[tobecontinued] [char] (1) NULL ,
	[start] [datetime] NULL ,
	[stop] [datetime] NULL ,
	[valuen1] [decimal](23, 6) NULL ,
	[valuen2] [decimal](23, 6) NULL ,
	[valuen3] [decimal](23, 6) NULL ,
	[valuen4] [decimal](23, 6) NULL ,
	[valuen5] [decimal](23, 6) NULL ,
	[values1] [varchar] (20) NULL ,
	[values2] [varchar] (20) NULL ,
	[values3] [varchar] (20) NULL ,
	[values4] [varchar] (20) NULL ,
	[values5] [varchar] (20) NULL ,
	[valuev1] [decimal](23, 6) NULL ,
	[valuev2] [decimal](23, 6) NULL ,
	[valuev3] [decimal](23, 6) NULL ,
	[valuev4] [decimal](23, 6) NULL ,
	[valuev5] [decimal](23, 6) NULL ,
	[paridsorkind] [int] NULL ,
	[paridsor] [int] NULL ,
	[paridsubclass] [smallint] NULL, 
	tempid int identity(1,1)
)
INSERT INTO #tmp 
(
	idautosort, idfin, idupb, idsorkindreg, idsorreg, idman,
	idsorkind, idsor, idsubclass,
	numerator, denominator, flagnodate,
	defaultn1, defaultn2, defaultn3, defaultn4, defaultn5,
	values1, values2, values3, values4, values5,
	defaultv1, defaultv2, defaultv3, defaultv4, defaultv5,
	cu, ct, lu, lt
) 
SELECT 
	A.idautosort,K.idparent,A.idupb,A.idsorkindreg,A.idsorreg,A.idman,
	A.idsorkind,A.idsor,1,
	A.numerator,A.denominator,A.flagnodate,
	A.defaultn1, A.defaultn2, A.defaultn3, A.defaultn4, A.defaultn5,
	A.defaults1, A.defaults2, A.defaults3, A.defaults4, A.defaults5,
	A.defaultv1, A.defaultv2, A.defaultv3, A.defaultv4, A.defaultv5,
	'A', GETDATE(), 'A', GETDATE()
FROM autoincomesorting A
JOIN sortingkind T
	ON A.idsorkind = T.idsorkind 
LEFT OUTER JOIN finlink K
	ON K.idparent = A.idfin
WHERE T.nphaseincome BETWEEN @start_nphase AND @stop_nphase
	AND ((A.idfin IS NULL)OR(@idfin = K.idchild)) 
	AND ((A.idupb IS NULL)OR (@idupb LIKE A.idupb + '%'))
	AND ((A.idman IS NULL) OR (@idman= A.idman))
	and  (T.start is null or T.start<=@ayear) and (T.stop is null or T.stop>=@ayear) -- >>>
	AND ((A.idsorkindreg IS NULL)
	OR EXISTS (
		SELECT *
		FROM registrysorting C
		JOIN sorting sc
			ON sc.idsor = C.idsor
		JOIN sortinglink 
			ON sortinglink.idchild = C.idsor
		WHERE C.idreg=@idreg
			AND sc.idsorkind=A.idsorkindreg
			AND ((A.idsorreg IS NULL) OR (sortinglink.idparent = A.idsorreg))
	)
	) AND (A.ayear = @ayear)
	
UPDATE #tmp SET idinc = @idinc 
UPDATE #tmp SET numerator = 1, denominator = 1 WHERE numerator IS NULL AND denominator IS NULL
UPDATE #tmp SET denominator = numerator WHERE (denominator IS NULL) OR (denominator=0)
UPDATE #tmp SET amount = @incomeamount * numerator / denominator
UPDATE #tmp SET valuen1 = @incomeamount WHERE defaultN1 = '@'
UPDATE #tmp SET valuen2 = @incomeamount WHERE defaultN2 = '@'
UPDATE #tmp SET valuen3 = @incomeamount WHERE defaultN3 = '@'
UPDATE #tmp SET valuen4 = @incomeamount WHERE defaultN4 = '@'
UPDATE #tmp SET valuen5 = @incomeamount WHERE defaultN5 = '@'
UPDATE #tmp SET valuev1 = @incomeamount WHERE defaultV1 = '@'
UPDATE #tmp SET valuev2 = @incomeamount WHERE defaultV2 = '@'
UPDATE #tmp SET valuev3 = @incomeamount WHERE defaultV3 = '@'
UPDATE #tmp SET valuev4 = @incomeamount WHERE defaultV4 = '@'
UPDATE #tmp SET valuev5 = @incomeamount WHERE defaultV5 = '@'
DELETE FROM #tmp
WHERE (
	SELECT COUNT(*) FROM #tmp T2
	LEFT OUTER JOIN finlink K
		ON K.idchild = T2.idfin
	LEFT OUTER JOIN sortinglink SLK
		ON SLK.idchild = T2.idsorreg
	WHERE (#tmp.idsorkind=T2.idsorkind) AND
		--l'insieme individuato da T2 deve essere diverso da quello di #tmp
		( (#tmp.idfin IS NULL and T2.idfin is not null) or (#tmp.idfin is not null and T2.idfin IS NULL) or (#tmp.idfin<>T2.idfin) or
		  (#tmp.idman IS NULL and T2.idman is not null) or (#tmp.idman is not null and T2.idman IS NULL) or (#tmp.idman<>T2.idman) or
		  (#tmp.idupb IS NULL and T2.idupb is not null) or (#tmp.idupb is not null and T2.idupb IS NULL) or (#tmp.idupb<>T2.idupb) or
		  (#tmp.idsorkindreg IS NULL and T2.idsorkindreg is not null) or (#tmp.idsorkindreg is not null and T2.idsorkindreg IS NULL) or (#tmp.idsorkindreg<>T2.idsorkindreg) or
		  (#tmp.idsorreg IS NULL and T2.idsorreg is not null) or (#tmp.idsorreg is not null and T2.idsorreg IS NULL) or (#tmp.idsorreg<>T2.idsorreg) 
		) AND
		--l'insieme individuato da T2  deve essere più specifico di quello di #tmp
		((#tmp.idfin IS NULL) or (K.idparent = #tmp.idfin )) AND 
		((#tmp.idupb IS NULL)or(T2.idupb LIKE #tmp.idupb+'%') ) AND
		((#tmp.idman IS NULL)or(T2.idman = #tmp.idman) ) AND
		(   ((#tmp.idsorkindreg IS NULL)or
		      ( 
			 (T2.idsorkindreg = #tmp.idsorkindreg)
			AND (SLK.idparent = #tmp.idsorreg)
		      )
		   )	
		)
)>0
DELETE FROM #tmp WHERE ISNULL(idsor,0) = 0



if ( @start_nphase > 1 AND ISNULL(@parentidinc,0)<>0) 
BEGIN

create table #classprec(
idsorkind int,
idsor int,
paridsorkind int ,
paridsor int ,
paridsubclass int,
incamount decimal(19,2),
sortamount decimal(19,2),
amount decimal(19,2)
)

insert into #classprec
select SK.idsorkind,
	S2.idsor,
	S.idsorkind,
	S.idsor,
	ES.idsubclass,
	ET.curramount,
	ES.amount,
	ES.amount* (@incomeamount/ET.curramount)
	from 
		incomesorted ES 
		join incomelink EL on EL.idchild=@parentidinc 
		and EL.idparent=ES.idinc and ES.ayear=@ayear
		join incometotal ET on ES.idinc=ET.idinc and ET.ayear=@ayear
		join sorting S  on ES.idsor=S.idsor		
		join sortingkind SK on SK.idparentkind= S.idsorkind	
		join sorting S2 on S2.idsorkind=SK.idsorkind and
				S2.sortcode=S.sortcode AND ISNULL(S2.movkind,'')=ISNULL(S.movkind,'')
		where (SK.start is null or SK.start<=@ayear) and (SK.stop is null or SK.stop>=@ayear)
			and (isnull(SK.active,'S')='S')
			and SK.nphaseincome >=convert(int,@start_nphase) 
			and SK.nphaseincome <=convert(int,@stop_nphase)

--cancella le classificazioni multiple se associati a pagamenti parziali 
--delete from #classprec where
--		 incamount>@incomeamount and
--	(select count(*) from #classprec C2 where C2.idsorkind=#classprec.idsorkind) >1
	

if (select count(*) from #classprec)>0
insert into #tmp(idsorkind,idsor,amount,paridsorkind,paridsor,paridsubclass,ct,cu,lt,lu) 
select idsorkind,idsor,amount, paridsorkind,paridsor,
	paridsubclass , getdate(),'autosort',getdate(),'autosort'  
from #classprec

drop table #classprec


END

update #tmp set idsubclass= (select count(*) from #tmp t2 where t2.idsorkind=#tmp.idsorkind and 
					t2.idsor=#tmp.idsor and  t2.tempid<=#tmp.tempid)
		



SELECT
	idsorkind,idsor,idinc,tempid as idsubclass,amount,
	description,noupdate,nodelete,txt,rtf,cu,ct,lu,lt,
	flagnodate,tobecontinued,start,stop,
	valuen1, valuen2, valuen3, valuen4, valuen5,
	values1, values2, values3, values4, values5,
	valuev1, valuev2, valuev3, valuev4, valuev5,
	paridsorkind,paridsor,paridsubclass, ayear=@ayear
FROM #tmp

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

