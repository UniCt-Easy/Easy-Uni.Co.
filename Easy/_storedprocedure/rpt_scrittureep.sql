SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_scrittureep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_scrittureep]
GO
 
CREATE    PROCEDURE [rpt_scrittureep]
	@ayear int,
	@nstart int,
	@nstop int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN

DECLARE @idsortingkind1 int
DECLARE @idsortingkind2 int
DECLARE @idsortingkind3 int
SELECT
	@idsortingkind1 = idsortingkind1,
	@idsortingkind2 = idsortingkind2,
	@idsortingkind3 = idsortingkind3
FROM config WHERE ayear = @ayear

DECLARE @sortingkind1 varchar(50)
SELECT  @sortingkind1 = description FROM sortingkind WHERE idsorkind = @idsortingkind1

DECLARE @sortingkind2 varchar(50)
SELECT  @sortingkind2 = description FROM sortingkind WHERE idsorkind = @idsortingkind2

DECLARE @sortingkind3 varchar(50)
SELECT  @sortingkind3 = description FROM sortingkind WHERE idsorkind = @idsortingkind3

SELECT
	entrydetail.yentry,
	entrydetail.nentry,
	entrydetail.ndetail,
	CASE
		WHEN ISNULL(entrydetail.amount,0) < 0 THEN -amount
		ELSE NULL
	END as give,
	CASE
		WHEN ISNULL(entrydetail.amount,0) >= 0 THEN amount
		ELSE NULL
	END as have,
	upb.codeupb,
	upb.title as 'upb',
	account.codeacc,
	account.title as 'account',
	registry.title as 'registry',
	entry.description,
	entry.adate,
	entry.doc,
	entry.docdate,
	accmotive.title as 'accmotive',
	accmotive.codemotive,
	S1.sortcode as 'sortcode1', 
	S1.description as 'description1',
	S2.sortcode as 'sortcode2', 
	S2.description as 'description2',
	S3.sortcode as 'sortcode3', 
	S3.description as 'description3',
	entry.locked
FROM entrydetail
INNER JOIN entry
	ON entrydetail.yentry = entry.yentry
	AND entrydetail.nentry = entry.nentry
LEFT OUTER JOIN registry
	ON entrydetail.idreg = registry.idreg
LEFT OUTER JOIN upb
	ON entrydetail.idupb = upb.idupb
LEFT OUTER JOIN account
	ON entrydetail.idacc = account.idacc
LEFT OUTER JOIN  accmotive
	ON entrydetail.idaccmotive = accmotive.idaccmotive
LEFT OUTER JOIN sorting S1
	on entrydetail.idsor1 = S1.idsor  and 
	S1.idsorkind = @idsortingkind1 
LEFT OUTER JOIN sorting S2
	on entrydetail.idsor2 = S2.idsor  and 
 	S2.idsorkind = @idsortingkind2 
LEFT OUTER JOIN sorting S3
 	on entrydetail.idsor3 = S3.idsor and 
 	S3.idsorkind = @idsortingkind3 
where entry.yentry = @ayear
	and entry.nentry between @nstart and @nstop
	AND (@idsor01 IS NULL OR  COALESCE (entry.idsor01, upb.idsor01)= @idsor01)
	AND (@idsor02 IS NULL OR  COALESCE (entry.idsor02, upb.idsor02)= @idsor02)
	AND (@idsor03 IS NULL OR  COALESCE (entry.idsor03, upb.idsor03)= @idsor03)
	AND (@idsor04 IS NULL OR  COALESCE (entry.idsor04, upb.idsor04)= @idsor04)
	AND (@idsor05 IS NULL OR  COALESCE (entry.idsor05, upb.idsor05)= @idsor05)	
Order by entrydetail.yentry, entrydetail.nentry, entrydetail.ndetail


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



