if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_situazionepatrimoniale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_situazionepatrimoniale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_situazionepatrimoniale]
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@levelusable char(1),
	@idupb		varchar(36),
	@showchildupb	char(1),
	@suppressifblank char(1)
)
AS BEGIN
	--[rpt_situazionepatrimoniale]  2015, {ts '2015-01-20 00:00:00'}, {ts '2015-12-31 00:00:00'}, 3, null, 'S', 'S'
	CREATE TABLE #situazionepatrimoniale
	(
		idupb varchar(36),
		codeupb varchar(50),
		upb varchar(150),
		idacc1 varchar(38),
		code1 varchar(50),
		desc1 varchar(150),
		order1 varchar(50),
		idacc2 varchar(38),
		code2 varchar(50),
		desc2 varchar(150),
		order2 varchar(50),
		idacc3 varchar(38),
		code3 varchar(50),
		desc3 varchar(150),
		order3 varchar(50),
		idacc4 varchar(38),
		code4 varchar(50),
		desc4 varchar(150),
		order4 varchar(50),
		idacc5 varchar(38),
		code5 varchar(50),
		desc5 varchar(150),
		order5 varchar(50),
		idacc6 varchar(38),
		code6 varchar(50),
		desc6 varchar(150),
		order6 varchar(50),
		idacc varchar(38),
		code varchar(50),
		title varchar(150),
		printingorderacc varchar(50),
		dare decimal(19,2),
		avere decimal(19,2),
		section_ap char(1),
		placcount_sign char(1),
		patrimony_sign char(1),
		nriga int,
		nlevel char(1)
	)
	INSERT INTO #situazionepatrimoniale (idupb, codeupb, upb,idacc1, code1, desc1, order1, idacc2, code2, desc2, order2, idacc3, code3, desc3, order3, 
	idacc4, code4, desc4, order4, idacc5, code5, desc5, order5, idacc6, code6, desc6, order6,idacc, code, title, printingorderacc, nlevel, dare, avere, section_ap, placcount_sign, patrimony_sign)
	EXEC rpt_bilanciodiverifica @ayear, @start, @stop, @levelusable,@idupb, @showchildupb, @suppressifblank
	
	CREATE TABLE #rptfinale
	(
		
		idupb varchar(36),
		codeupb varchar(50),
		upb varchar(150),
		idacc_a varchar(38),
		idacc_p varchar(38),
		printingorder_a varchar(50),
		printingorder_p varchar(50),
		importo_a decimal(19,2),
		importo_p decimal(19,2),
		nriga int
	)
	UPDATE #situazionepatrimoniale 
	SET section_ap = 'P'
	WHERE (ISNULL(dare,0) - ISNULL(avere,0)) < 0
	AND section_ap = 'A'
	UPDATE #situazionepatrimoniale
	SET section_ap = 'A'
	WHERE (ISNULL(avere,0) - ISNULL(dare,0)) < 0
	AND section_ap = 'P'
	
	UPDATE #situazionepatrimoniale 
	SET section_ap = 'A'
	WHERE ISNULL(dare,0)=0 AND ISNULL(avere,0)= 0
	AND section_ap = 'P'
	AND patrimony_sign = 'N'
	UPDATE #situazionepatrimoniale
	SET section_ap = 'P'
	WHERE ISNULL(dare,0)=0 AND ISNULL(avere,0)= 0
	AND section_ap = 'A'
	AND patrimony_sign = 'N'
	UPDATE #situazionepatrimoniale
	SET nriga =
	1 +
	ISNULL(
		(SELECT COUNT(*) FROM #situazionepatrimoniale r2
		WHERE r2.printingorderacc < #situazionepatrimoniale.printingorderacc
		AND r2.section_ap = #situazionepatrimoniale.section_ap)
	,0)
	WHERE section_ap = 'A'
	
	UPDATE #situazionepatrimoniale
	SET nriga =
	1 +
	ISNULL(
		(SELECT COUNT(*) FROM #situazionepatrimoniale r2
		WHERE r2.printingorderacc < #situazionepatrimoniale.printingorderacc
		AND r2.section_ap = #situazionepatrimoniale.section_ap)
	,0)
	WHERE section_ap = 'P'
	
	DECLARE @nriga_a int
	DECLARE @nriga_p int
	SET @nriga_a = ISNULL((SELECT MAX(nriga) FROM #situazionepatrimoniale WHERE section_ap = 'A'),0)
	SET @nriga_p = ISNULL((SELECT MAX(nriga) FROM #situazionepatrimoniale WHERE section_ap = 'P'),0)
	
	IF (@nriga_a >= @nriga_p)
	BEGIN
		INSERT INTO #rptfinale (idupb, codeupb, upb,idacc_a, printingorder_a, importo_a, nriga)
		SELECT idupb, codeupb, upb,idacc, printingorderacc, (ISNULL(dare,0) - ISNULL(avere,0)), nriga
		FROM #situazionepatrimoniale
		WHERE section_ap = 'A'
		ORDER BY nriga
		UPDATE #rptfinale
		SET idacc_p = idacc,
		printingorder_p = printingorderacc,
		importo_p = (ISNULL(avere,0) - ISNULL(dare,0))
		FROM #situazionepatrimoniale
		WHERE #situazionepatrimoniale.section_ap = 'P'
		AND #rptfinale.nriga = #situazionepatrimoniale.nriga
	
	END
	ELSE
	BEGIN
		INSERT INTO #rptfinale (idupb, codeupb, upb,idacc_p, printingorder_p, importo_p, nriga)
		SELECT idupb, codeupb, upb,idacc, printingorderacc, (ISNULL(avere,0) - ISNULL(dare,0)), nriga
		FROM #situazionepatrimoniale
		WHERE section_ap = 'P'
		ORDER BY nriga
		UPDATE #rptfinale
		SET idacc_a = idacc,
		printingorder_a = printingorderacc,
		importo_a = (ISNULL(dare,0) - ISNULL(avere,0))
		FROM #situazionepatrimoniale
		WHERE #situazionepatrimoniale.section_ap = 'A'
		AND #rptfinale.nriga = #situazionepatrimoniale.nriga
	END
	
	SELECT
	rf.idupb,
	rf.codeupb,
	rf.upb,
	rf.nriga,
	rf.idacc_a, r1.code AS code_a, r1.title AS desc_a,
	r1.idacc1 AS idacc1_a, r1.code1 AS code1_a, r1.desc1 AS desc1_a, r1.order1 AS order1_a,
	r1.idacc2 AS idacc2_a, r1.code2 AS code2_a, r1.desc2 AS desc2_a, r1.order2 AS order2_a,
	r1.idacc3 AS idacc3_a, r1.code3 AS code3_a, r1.desc3 AS desc3_a, r1.order3 AS order3_a,
	r1.idacc4 AS idacc4_a, r1.code4 AS code4_a, r1.desc4 AS desc4_a, r1.order4 AS order4_a,
	r1.idacc5 AS idacc5_a, r1.code5 AS code5_a, r1.desc5 AS desc5_a, r1.order5 AS order5_a,
	r1.idacc6 AS idacc6_a, r1.code6 AS code6_a, r1.desc6 AS desc6_a, r1.order6 AS order6_a,
	r1.nlevel AS nlevel_a,
	isnull(rf.importo_a,0) as importo_a,
	rf.printingorder_a,
	rf.idacc_p, r2.code AS code_p, r2.title AS desc_p,
	r2.idacc1 AS idacc1_p, r2.code1 AS code1_p, r2.desc1 AS desc1_p, r2.order1 AS order1_p,
	r2.idacc2 AS idacc2_p, r2.code2 AS code2_p, r2.desc2 AS desc2_p, r2.order2 AS order2_p,
	r2.idacc3 AS idacc3_p, r2.code3 AS code3_p, r2.desc3 AS desc3_p, r2.order3 AS order3_p,
	r2.idacc4 AS idacc4_p, r2.code4 AS code4_p, r2.desc4 AS desc4_p, r2.order4 AS order4_p,
	r2.idacc5 AS idacc5_p, r2.code5 AS code5_p, r2.desc5 AS desc5_p, r2.order5 AS order5_p,
	r2.idacc6 AS idacc6_p, r2.code6 AS code6_p, r2.desc6 AS desc6_p, r2.order6 AS order6_p,
	r2.nlevel AS nlevel_p,
	isnull(rf.importo_p,0) as importo_p,
	rf.printingorder_p
	FROM #rptfinale rf
	LEFT OUTER JOIN #situazionepatrimoniale r1
	ON r1.idacc = rf.idacc_a
	AND r1.section_ap = 'A'
	LEFT OUTER JOIN #situazionepatrimoniale r2
	ON r2.idacc = rf.idacc_p
	AND r2.section_ap = 'P'
	ORDER BY rf.nriga
END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

