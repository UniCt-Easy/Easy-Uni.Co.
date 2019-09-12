if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_scaricoperunitaorganizzativa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_scaricoperunitaorganizzativa]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE rpt_scaricoperunitaorganizzativa(
	@ayear	smallint ,
	@idstore int,
	@idsor1 int,-- configurare % come default, ossia se % vedi tutto
	@idsor2 int,
	@idsor3 int,
	@start datetime,
	@stop datetime
)

-- exec rpt_scaricoperunitaorganizzativa 2011, 1, null,null, null, '01/01/2011', '24/11/2011'

AS BEGIN

IF @idsor1 = 0 SET @idsor1 = NULL
IF @idsor2 = 0 SET @idsor2 = NULL
IF @idsor3 = 0 SET @idsor3 = NULL

DECLARE @idsortingkind1 varchar(20)
DECLARE @idsortingkind2 varchar(20)
DECLARE @idsortingkind3 varchar(20)
SELECT
	@idsortingkind1 = idsortingkind1,
	@idsortingkind2 = idsortingkind2,
	@idsortingkind3 = idsortingkind3
FROM config WHERE ayear = @ayear

DECLARE @sortingkind1 varchar(50)
SELECT @sortingkind1 = description FROM sortingkind WHERE idsorkind = @idsortingkind1

DECLARE @sortingkind2 varchar(50)
SELECT @sortingkind2 = description FROM sortingkind WHERE idsorkind = @idsortingkind2

DECLARE @sortingkind3 varchar(50)
SELECT @sortingkind3 = description FROM sortingkind WHERE idsorkind = @idsortingkind3

DECLARE @lencodesor int
SET @lencodesor = 50

SELECT
	D.ystoreunload,
	D.nstoreunload, 
	D.adate,--> data bolla
	D.description, -- decrizione dello scarico
	L.intcode, -- codice articolo
	L.description as list, --- descrizione  articolo
	U.description as unit,-- unita di carico/scarico
	isnull(sum(Det.number),0) as number,	-- q.tà Scaricata
	R.title as registry,-- fornitore per il Reso
	M.description as store,

	S1.nlevel as nlevel1, 
	K1.description as level1,
	S1.idsor as idsor1,
	S1.sortcode as sortcode1, 
	S1.description as description1, 
	
	S2.nlevel as nlevel2, 
	K2.description as level2,
	S2.idsor as idsor2,
	S2.sortcode as sortcode2, 
	S2.description as description2,

	S3.nlevel as nlevel3, 
	K3.description as level3,
	S3.idsor as idsor3,
	S3.sortcode as sortcode3, 
	S3.description as description3,
	
	round(S.amount/S.number,5) * isnull(sum(Det.number),0) as 'costototale' ,
	Det.idman,
	G.title
FROM storeunload D
JOIN storeunloaddetail Det
	ON D.idstoreunload = Det.idstoreunload
JOIN stock S
	ON Det.idstock = S.idstock
JOIN list L
	ON L.idlist = S.idlist
JOIN unit U
	ON U.idunit = L.idunit
JOIN store M
	ON M.idstore = D.idstore	
LEFT OUTER JOIN registry R
	ON R.idreg = D.idreg
LEFT OUTER JOIN sorting S1
	ON Det.idsor1 = S1.idsor AND S1.idsorkind = @idsortingkind1 
LEFT OUTER JOIN sortinglevel K1
	ON S1.nlevel = K1.nlevel AND K1.idsorkind = @idsortingkind1 
LEFT OUTER JOIN sorting S2
	ON Det.idsor2 = S2.idsor AND S2.idsorkind = @idsortingkind2 
LEFT OUTER JOIN sortinglevel K2
	ON S2.nlevel = K2.nlevel AND K2.idsorkind = @idsortingkind2 
LEFT OUTER JOIN sorting S3
	ON Det.idsor3 = S3.idsor AND S3.idsorkind = @idsortingkind3 
LEFT OUTER JOIN sortinglevel K3
	ON S3.nlevel = K3.nlevel AND K3.idsorkind = @idsortingkind3 
LEFT OUTER JOIN manager G
	ON G.idman = Det.idman
WHERE
	( D.idstore = @idstore OR @idstore IS NULL )
	AND D.ystoreunload = @ayear
	AND (@idsor1 IS NULL OR Det.idsor1 = @idsor1  )
	AND (@idsor2 IS NULL OR Det.idsor2 = @idsor2  )
	AND (@idsor3 IS NULL OR Det.idsor3 = @idsor3  )
	AND D.adate between @start AND @stop

GROUP BY 
	D.ystoreunload,
	D.nstoreunload, 
	D.adate,-- data bolla
	D.description, -- decrizione dello scarico
	L.intcode, -- codice articolo
	L.description, --- descrizione  articolo
	U.description,-- unita di carico/scarico
	R.title,-- fornitore per il Reso
	M.description ,
	K1.description, S1.nlevel, S1.idsor, S1.sortcode, S1.description ,
	K2.description, S2.nlevel, S2.idsor, S2.sortcode, S2.description ,
	K3.description, S3.nlevel, S3.idsor, S3.sortcode, S3.description,
	S.amount, S.number, Det.idman, G.title 
ORDER BY S1.sortcode, S2.sortcode, S3.sortcode,  L.intcode, D.adate

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

