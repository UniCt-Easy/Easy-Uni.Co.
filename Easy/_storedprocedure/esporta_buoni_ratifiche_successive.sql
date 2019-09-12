if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_buoni_ratifiche_successive]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_buoni_ratifiche_successive]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE  [esporta_buoni_ratifiche_successive]
	@start smalldatetime,
	@stop  smalldatetime
AS BEGIN
-- exec esporta_buoni_ratifiche_successive {ts '2016-01-01 00:00:00'},{ts '2016-12-31 00:00:00'}
 
	SELECT
		assetloadview.codeassetloadkind as 'Cod. Tipo Buono Carico',
		assetloadview.assetloadkind 'Tipo Buono Carico',
		assetloadview.yassetload 'Eserc.Buono',
		assetloadview.nassetload 'Num.Buono',
		assetloadview.adate as 'Data Contabile',
		assetloadview.ratificationdate as 'Data Ratifica',
		assetloadview.totalassetacquire as 'Totale carichi',
		assetloadview.assetamortizationamount as 'Totale rivalutazioni',
		assetloadview.totalassetload as 'Totale Buono'		
	FROM assetloadview 

	WHERE	( YEAR(assetloadview.ratificationdate) > assetloadview.yassetload )
		AND assetloadview.adate between @start and @stop		
	UNION 
	SELECT
		assetunloadview.codeassetunloadkind as 'Cod. Tipo Buono Scarico',
		assetunloadview.assetunloadkind 'Tipo Buono Scarico',
		assetunloadview.yassetunload 'Eserc.Buono',
		assetunloadview.nassetunload 'Num.Buono',
		assetunloadview.adate as 'Data Contabile',
		assetunloadview.ratificationdate as 'Data Ratifica'	,
		assetunloadview.assetcurrentvalue as 'Valore Corrente Cespiti Scaricati',
		assetunloadview.assetamortizationamount as 'Totale svalutazioni',
		assetunloadview.totalassetunload as 'Totale Buono'	
	FROM assetunloadview 
	WHERE	( YEAR(assetunloadview.ratificationdate) > assetunloadview.yassetunload )
		AND assetunloadview.adate between @start and @stop		
	 --ORDER BY ISNULL(assetloadview.codeassetloadkind, assetunloadview.codeassetunloadkind) ,
	 --ISNULL(assetloadview.yassetload,assetunloadview.yassetunload)  desc,
	 --ISNULL(assetloadview.nassetload,assetunloadview.nassetunload) 
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 