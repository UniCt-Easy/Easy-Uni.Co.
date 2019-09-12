if exists (select * from dbo.sysobjects where id = object_id(N'[exp_expensegerarchico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_expensegerarchico]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


-- exp_expensegerarchico '2008', '2015', '2008', '2015', null, {ts '2008-01-01 00:00:00.000'}, {ts '2015-12-31 00:00:00.000'}, '%', null, null, null, '%', null, null, null, null, null

CREATE  PROCEDURE  exp_expensegerarchico(
	@ymin int,
	@ymax int,
	@ayearmin int,
	@ayearmax int,
	@registry varchar(100),
	@adatemin datetime,
	@adatemax datetime,
	@codefin varchar(50),
	@nphaseparent tinyint,
	@ymovparent  int,
	@nmovparent  int,
	@idupb varchar(36),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
) 
as begin
declare @idexp int
IF (@nphaseparent IS NULL OR @ymovparent IS NULL OR @nmovparent IS NULL)
	BEGIN
		SET @idexp = null	
	END
Else
	BEGIN
	   	SET @idexp = (select idexp 
				from expense 
				where ymov = @ymovparent 
				and nmov   = @nmovparent 
				and nphase = @nphaseparent) 
	END

declare @descrphase1 varchar(20)
declare @descrphase2 varchar(20)
declare @descrphase3 varchar(20)
declare @descrphase4 varchar(20)
declare @descrphase5 varchar(20)

select @descrphase1 = replace (description,'''','''''') from  expensephase where nphase = 1
select @descrphase2 = replace (description,'''','''''') from  expensephase where nphase = 2
select @descrphase3 = replace (description,'''','''''') from  expensephase where nphase = 3
select @descrphase4 = replace (description,'''','''''') from  expensephase where nphase = 4
select @descrphase5 = replace (description,'''','''''') from  expensephase where nphase = 5



declare @idsorkind01 int
declare @idsorkind02 int
declare @idsorkind03 int
declare @idsorkind04 int
declare @idsorkind05 int

declare @sortingkind01 varchar(50)
declare @sortingkind02 varchar(50)
declare @sortingkind03 varchar(50)
declare @sortingkind04 varchar(50)
declare @sortingkind05 varchar(50)

set @sortingkind01='no'
set @sortingkind02='no'
set @sortingkind03='no'
set @sortingkind04='no'
set @sortingkind05='no'

select @idsorkind01  = idsorkind01 from uniconfig
select @idsorkind02  = idsorkind02 from uniconfig
select @idsorkind03  = idsorkind03 from uniconfig
select @idsorkind04  = idsorkind04 from uniconfig
select @idsorkind05  = idsorkind05 from uniconfig

select @sortingkind01  =  replace (description,'''','''''')   from sortingkind where idsorkind = @idsorkind01
select @sortingkind02  =  replace (description,'''','''''')   from sortingkind where idsorkind = @idsorkind02
select @sortingkind03  =  replace (description,'''','''''')   from sortingkind where idsorkind = @idsorkind03
select @sortingkind04  =  replace (description,'''','''''')  from sortingkind where idsorkind = @idsorkind04
select @sortingkind05  =  replace (description,'''','''''')  from sortingkind where idsorkind = @idsorkind05
 

SELECT 
	S01.sortcode as 'S01_code',
	S02.sortcode as 'S02_code',
	S03.sortcode as 'S03_code',
	S04.sortcode as 'S04_code',
	S05.sortcode as 'S05_code',
	S01.description as 'S01',
	S02.description as 'S02',
	S03.description as 'S03',
	S04.description as 'S04',
	S05.description as 'S05',
	expense.idexp, 
	expenseyear.ayear, 
	expense.idreg, 
	expenseyear.idfin, 
	expenseyear.idupb
INTO #prova
	FROM expense
	join expenseyear 
		on expenseyear.idexp=expense.idexp 
	left outer join registry 
		on expense.idreg=registry.idreg 
	left outer join fin 
		on fin.idfin=expenseyear.idfin 
	left outer join upb 
		on upb.idupb = expenseyear.idupb
	JOIN expenselink 
		ON expenselink.idchild = expense.idexp  
		AND expenselink.idparent = ISNULL(@idexp,expense.idexp) 
	LEFT OUTER JOIN sorting S01
				ON upb.idsor01 = S01.idsor
	LEFT OUTER JOIN sorting S02
				ON upb.idsor02 = S02.idsor
	LEFT OUTER JOIN sorting S03
				ON upb.idsor03 = S03.idsor
	LEFT OUTER JOIN sorting S04
				ON upb.idsor04 = S04.idsor
	LEFT OUTER JOIN sorting S05
				ON upb.idsor05 = S05.idsor
	WHERE (@adatemin is null or adate >= @adatemin) and (@adatemax is null or adate <= @adatemax)
	and (@ymin is null or expense.ymov >= @ymin)
	and (@ymax is null or expense.ymov <= @ymax)
	and (@ayearmin is null or expenseyear.ayear >= @ayearmin)
	and (@ayearmax is null or expenseyear.ayear <= @ayearmax)
	and (@registry is null or registry.title like @registry)
	and (@codefin is null or codefin like @codefin)
	AND upb.idupb LIKE @idupb
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


declare @sqlcmd nvarchar(4000)

SET @sqlcmd = ' SELECT '


SET @sqlcmd= @sqlcmd + 
'	#prova.ayear as ANNO,
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(10),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 1
			where elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase1+''','
if (@descrphase2 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(10),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 2
			where  elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase2+''','
if (@descrphase3 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(10),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 3
			where  elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase3+''','
if (@descrphase4 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(10),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 4
			where  elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase4+''','

if (@descrphase5 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(10),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 5
			where  elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase5+''','

if (@idsorkind01 is not null)
SET @sqlcmd=@sqlcmd+
'   S01_code  + '' '' +' + '  S01' +  '	AS '''+@sortingkind01+''','

if (@idsorkind02 is not null)
SET @sqlcmd=@sqlcmd+
'   S02_code  + '' '' +' + '   S02' + '   AS '''+@sortingkind02+''','

if (@idsorkind03 is not null)
SET @sqlcmd=@sqlcmd+
'   S03_code  + '' '' +' + '   S03'  + '  AS '''+@sortingkind03+''','

if (@idsorkind04 is not null)
SET @sqlcmd= @sqlcmd+
'   S04_code  +  '' '' +' + '   S04' + '   AS '''+@sortingkind04+''','

if (@idsorkind05 is not null)
SET @sqlcmd=@sqlcmd+
'   S05_code  + '' '' +' + '   S05' + '	AS '''+@sortingkind05+''','



SET @sqlcmd=@sqlcmd+'
	(convert(varchar(4),payment.ypay) + ''/'' + convert(varchar(10),payment.npay)) as Mandato,
	expenselast.nbill as ''N. Bolletta'',
	codefin as ''Codice bilancio'',
	fin.title as ''Voce di bilancio'',
	codeupb as ''Codice UPB'',
	upb.title as ''UPB'',
	registry.title as ''Beneficiario'',
	expense.description as ''Descrizione'',
	expensetotal.curramount as ''Importo corrente'',
	case when expenselast.idexp is not null then null else expensetotal.available end as ''Disponibile'',
	service.description as Prestazione,
	expenselast.servicestart as Inizio,
	expenselast.servicestop as Fine,
	(select sum(employtax) from expensetax where expensetax.idexp=#prova.idexp) as ''Importo ritenute associate'',
	(select sum(amount) from expenseclawback where expenseclawback.idexp=#prova.idexp) as ''Importo recuperi associati'',
	expensetotal.curramount
		-(select isnull(sum(employtax),0) from expensetax where expensetax.idexp=#prova.idexp)
		-(select isnull(sum(amount),0) from expenseclawback where expenseclawback.idexp=#prova.idexp) as ''Netto'',
	expense.adate as ''Data contabile'',
	expense.doc as ''Doc.'',
	expense.docdate as ''Data Doc.'',
	expense.cu as ''Utente che ha creato il mov.''
FROM #prova
LEFT OUTER JOIN fin 
	on fin.idfin=#prova.idfin
LEFT OUTER JOIN upb 
	on upb.idupb=#prova.idupb
LEFT OUTER JOIN registry 
	on registry.idreg=#prova.idreg
LEFT OUTER JOIN expense 
	on expense.idexp=#prova.idexp
LEFT OUTER JOIN expenselast 
	on expenselast.idexp = #prova.idexp
LEFT OUTER JOIN payment 
	on payment.kpay = expenselast.kpay
LEFT OUTER JOIN service
	on service.idser = expenselast.idser  
LEFT OUTER JOIN expensetotal 
	ON expensetotal.idexp = #prova.idexp AND expensetotal.ayear = #prova.ayear 
order by 1,2,3,4,5

'


EXECUTE sp_executesql  @sqlcmd

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


