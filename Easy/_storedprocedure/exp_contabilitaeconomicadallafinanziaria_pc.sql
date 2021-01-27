
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contabilitaeconomicadallafinanziaria_pc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contabilitaeconomicadallafinanziaria_pc]
GO


CREATE    PROCEDURE [exp_contabilitaeconomicadallafinanziaria_pc]
(
	@ayear smallint,
	@adate datetime,
	@idsorkind int,
	@showupb char(1)='N',
	@idupb varchar(36)='%',
	@showchildupb char(1)='N',
	@showmissioneprogrammi char(1)='S',
	@idsorkindmissioneprogrammi int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

)
AS BEGIN

-- exec exp_contabilitaeconomicadallafinanziaria_pc 2013, {ts '2013-12-31 00:00:00'}, 16, 'S','%','S','N', null,null,null,null,null,null
 

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'

DECLARE @oplevel tinyint
SELECT @oplevel = MAX(nlevel) --> Prendiamo il max perchè le prev. vengono messe sui nodi foglia, enon sui capitolo come avviene per il bilancio.
FROM sortinglevel
WHERE  (flag&2)<>0 and idsorkind = @idsorkind
	
	
declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear

DECLARE @minoplevelfin tinyint
SELECT  @minoplevelfin = min(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear and flag&2 <> 0

DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

DECLARE @incomefinphase tinyint
DECLARE @expensefinphase tinyint
DECLARE @maxincomephase tinyint
DECLARE @maxexpensephase tinyint

SELECT @incomefinphase = assessmentphasecode FROM config WHERE ayear = @ayear
IF @incomefinphase IS NULL
BEGIN
	SELECT @incomefinphase = incomefinphase FROM uniconfig
END
SELECT @maxincomephase = MAX(nphase) FROM incomephase

SELECT @expensefinphase = appropriationphasecode FROM config WHERE ayear = @ayear
IF @expensefinphase IS NULL
BEGIN
	SELECT @expensefinphase = expensefinphase FROM uniconfig
END
SELECT @maxexpensephase = MAX(nphase) FROM expensephase


CREATE TABLE #data
(
	idsor int,
	idupb varchar(36),
	idsormissioneprogrammi int,
	quota decimal(19,2),
	idacc varchar(38),
	ep_amount decimal(19,2)
)




-- Se deve mostrare anche i codice della class. Missioni Programmi, inserisce anche questi.
 CREATE TABLE #missioniprogrammi(
	idsor int NOT NULL,
	sortcode varchar(50),
	idupb varchar(36) NOT NULL,
	quota decimal(19,6) NULL,
	PRIMARY KEY (idsor,idupb)
)

if (@showmissioneprogrammi ='S')
Begin
	insert into #missioniprogrammi (
		idupb,
		idsor,
		sortcode,
		quota
	)
	select	
			isnull(@fixedidupb,US.idupb),
			US.idsor,
			sorting.sortcode,
			isnull(US.quota,1)
	from upbsorting US
	join sorting 
		on US.idsor = sorting.idsor
	join sortingkind K
		ON sorting.idsorkind = K.idsorkind
	JOIN upb U
		ON US.idupb = U.idupb
	where  K.idsorkind = @idsorkindmissioneprogrammi
			AND (US.idupb LIKE @idupb)	
			AND isnull(U.active,'N')='S'
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
End



-- Inserisce l'Utilizzato in EP

insert into #data (
	idsor,
	idacc,
	idupb,
	EP_amount
)
select A.idsor, 
	A.idacc,
	isnull(@fixedidupb,ED.idupb),
	abs(ISNULL(SUM(ED.amount),0))
from entry E
join entrydetail ED
	on E.yentry = ED.yentry
	and E.nentry = ED.nentry
join accountsorting A
	ON A.idacc = ED.idacc
join sorting S
	ON A.idsor = S.idsor
JOIN upb U
	ON ED.idupb = U.idupb
where E.yentry = @ayear
		and E.adate <= @adate
		and S.idsorkind = @idsorkind
		AND isnull(U.active,'N')='S'
		AND E.identrykind  not in (6,7) -- Esclude Epilogo, Apertura
		AND (ED.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
group by A.idsor, A.idacc, isnull(@fixedidupb,ED.idupb)

-- select * from #data

IF (@showupb ='S')
BEGIN
 SELECT 
	isnull(A.codeacc,'Nessun conto associato') as 'Cod.Coep',-->		Codice Conto
	A.title as 'Coep',
	K.description as 'Classificazione',
	S.sortcode as 'Cod.Conto',-->	'Codice Class.',
	S.description as 'Conto',
	upb.codeupb as 'Cod.UPB',
	upb.title as 'UPB',

	case when (@showmissioneprogrammi='S') then
		SUM(isnull(EP_amount,0) * isnull(#data.quota,1)) 
		else SUM(isnull(EP_amount,0)) 
		end AS 'Utilizzato in E/P',
	M.sortcode as 'Missione/Programmi'
FROM #data 
join sorting S
	on #data.idsor = S.idsor 
join sortingkind K
	on S.idsorkind = K.idsorkind
join upb
	on #data.idupb=upb.idupb
LEFT OUTER JOIN #missioniprogrammi M
		ON upb.idupb = M.idupb
LEFT OUTER JOIN account A
	ON A.idacc = #data.idacc
where  upb.idupb like @idupb
	   and S.idsorkind = @idsorkind
	   AND isnull(upb.active,'N')='S'
	   AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY 
	K.description,
	S.sortcode,	S.description,  upb.codeupb,upb.title,
	A.codeacc, A.title ,M.sortcode
 ORDER BY upb.codeupb asc, S.sortcode ASC 

END

IF (@showupb ='N')
BEGIN
SELECT 
	isnull(A.codeacc,'Nessun conto associato') as 'Cod.Coep', --> Codice Conto
	A.title as 'Coep',
	K.description as 'Classificazione',
	S.sortcode as 'Cod.Conto',--'Codice Class.',
	S.description as 'Conto',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(EP_amount,0) * isnull(#data.quota,1)) 
		else SUM(isnull(EP_amount,0)) 
		end AS 'Utilizzato in E/P',
	case when (@showmissioneprogrammi='S') then	M.sortcode 
	else null end
		as 'Missione/Programmi'
FROM #data 
join sorting S
	on #data.idsor = S.idsor 
join sortingkind K
	on S.idsorkind = K.idsorkind
join upb
	on #data.idupb=upb.idupb
LEFT OUTER JOIN account A
	ON A.idacc = #data.idacc
LEFT OUTER JOIN #missioniprogrammi M
		ON #data.idupb = M.idupb
where S.idsorkind = @idsorkind
GROUP BY 
	K.description,
	S.sortcode,	S.description,
	A.codeacc, A.title,M.sortcode
 ORDER BY S.sortcode ASC 

END	


drop table #missioniprogrammi
drop table #data


END

GO



