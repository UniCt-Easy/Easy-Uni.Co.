if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_situazionemagazzino]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_situazionemagazzino]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE       PROCEDURE rpt_situazionemagazzino(
	@idstore int,
	@idlist int,
	@stop datetime
)

AS BEGIN

-- Report che indichi la valorizzazione complessiva del magazzino per ogni articolo
-- exec rpt_situazionemagazzino NULL, null,  {ts '2011-06-20 00:00:00'}

create table #stock
(
	idstore int, 
	idstock int,
	idlist int,
	number decimal(19,2),
	totunload decimal(19,2)
)

INSERT INTO #stock
(
	idstore,
	idstock,
	idlist,
	number
)
SELECT 
S.idstore,
S.idstock,
S.idlist,
S.number
FROM stock S
WHERE (S.idstore = @idstore OR @idstore IS NULL)
	AND (S.idlist = @idlist OR @idlist IS NULL)
	AND S.number >0
	AND S.adate <= @stop

UPDATE #stock
SET totunload =  
(SELECT ISNULL(SUM(UD.number),0)
FROM storeunloaddetail UD
JOIN storeunload U
	ON U.idstoreunload = UD.idstoreunload 
WHERE UD.idstock = #stock.idstock
AND U.adate <= @stop
)

--select * from #stock ORDER BY totunload desc
--select * from #storeunloaddetail

SELECT
	S.idstore,
	M.description as 'store',
	L.idlist,
	L.intcode,
	L.description as 'list',
	unit.description as 'unit', -- unita di carico/scarico
	SUM(ISNULL(S.number,0) - ISNULL(S.totunload,0)) as 'giacenza'
FROM list L
JOIN unit 
	ON unit.idunit = L.idunit
JOIN #stock S
	ON L.idlist = S.idlist
JOIN store M
	ON S.idstore =  M.idstore
WHERE ( S.idstore = @idstore OR @idstore IS NULL )
	AND ( L.idlist = @idlist OR @idlist IS NULL )
	AND S.number >0
GROUP BY S.idstore, M.description, L.idlist, L.intcode, L.description, unit.description

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





