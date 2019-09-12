if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bolladiscarico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bolladiscarico]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE rpt_bolladiscarico(
	@ystoreunload	smallint ,
	@nstoreunload_start	int,
	@nstoreunload_stop	int,
	@idstore int,
	@idman int
)
AS BEGIN
--	exec rpt_bolladiscarico 2011,null,null,null, null

DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM  stocklocationlevel
WHERE (flag&2)<>0


SELECT
	D.ystoreunload,
	D.nstoreunload, 
	D.adate,-- data bolla
	D.description, -- decrizione dello scarico
	L.intcode, -- codice articolo
	L.description as list, --- descrizione  articolo
	U.description as unit,-- unita di carico/scarico
	isnull(sum(Det.number),0) as number,	-- q.tà Scaricata
	R.title as registry,-- fornitore per il Reso
	SL1.stocklocationcode AS stocklocationcode1,
	SL1.description as stocklocation1,
	SL2.stocklocationcode AS stocklocationcode2,
	SL2.description as stocklocation2,
	SL3.stocklocationcode AS stocklocationcode3,
	SL3.description as stocklocation3,
	SL4.stocklocationcode AS stocklocationcode4,
	SL4.description as stocklocation4,
	M.description as store,
	Det.idman,
	G.title as manager,
	SG.description as sortingdescription,
	convert(varchar(255),D.txt) as note
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
LEFT OUTER JOIN manager G
	ON G.idman = Det.idman
LEFT OUTER JOIN stocklocation SL4							
	ON SL4.idstocklocation = S.idstocklocation AND SL4.nlevel = @minoplevel
LEFT OUTER JOIN stocklocation SL3
	ON SL3.idstocklocation = SL4.paridstocklocation 
LEFT OUTER JOIN stocklocation SL2
	ON SL2.idstocklocation = SL3.paridstocklocation 
LEFT OUTER JOIN stocklocation SL1
	ON SL1.idstocklocation = SL2.paridstocklocation 
LEFT OUTER JOIN sorting SG
	ON SG.idsor = Det.idsor1
LEFT OUTER JOIN sortingkind SK
	ON SG.idsorkind = SK.idsorkind
	AND SK.codesorkind = 'Centrodicosto'
WHERE (@nstoreunload_start is null  or @nstoreunload_start <= D.nstoreunload )
		AND (@nstoreunload_stop is null or @nstoreunload_stop >= D.nstoreunload)
	AND ( D.idstore = @idstore OR @idstore IS NULL )
	AND D.ystoreunload = @ystoreunload
	AND ( Det.idman = @idman OR @idman IS NULL )
GROUP BY 
	D.ystoreunload,
	D.nstoreunload, 
	D.adate,-- data bolla
	D.description, -- decrizione dello scarico
	L.intcode, -- codice articolo
	L.description, --- descrizione  articolo
	U.description,-- unita di carico/scarico
	R.title,-- fornitore per il Reso
	M.description,
	Det.idman, G.title, 
	SL1.stocklocationcode, SL1.description,
	SL2.stocklocationcode, SL2.description,
	SL3.stocklocationcode, SL3.description,
	SL4.stocklocationcode, SL4.description,
	SG.description,
	convert(varchar(255),D.txt)
order by D.ystoreunload, D.nstoreunload, G.title


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


