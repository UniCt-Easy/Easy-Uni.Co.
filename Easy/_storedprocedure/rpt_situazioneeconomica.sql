
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_situazioneeconomica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_situazioneeconomica]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [rpt_situazioneeconomica]
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
--	[rpt_situazioneeconomica] 2015, {ts '2015-01-20 00:00:00'}, {ts '2015-12-31 00:00:00'}, 3, null, 'S', 'S'
	CREATE TABLE #situazioneeconomica
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
		section_cr char(1),
		placcount_sign char(1),
		patrimony_sign char(1),
		nriga int,
		nlevel char(1)
	)
	INSERT INTO #situazioneeconomica (idupb, codeupb, upb,idacc1, code1, desc1, order1, idacc2, code2, desc2, order2, idacc3, code3, desc3, order3, 
	idacc4, code4, desc4, order4, idacc5, code5, desc5, order5, idacc6, code6, desc6, order6,idacc, code, title, printingorderacc, nlevel, dare, avere, section_cr,placcount_sign,patrimony_sign)
	EXEC rpt_bilanciodiverifica @ayear, @start, @stop, @levelusable,@idupb, @showchildupb, @suppressifblank
	UPDATE #situazioneeconomica SET dare = -avere, avere = NULL, section_cr = 'R' WHERE section_cr = 'C' AND dare < 0
	UPDATE #situazioneeconomica SET avere = -dare, dare = NULL, section_cr = 'C' WHERE section_cr = 'R' AND avere < 0
	
	CREATE TABLE #rptfinale
	(
		idupb varchar(36),
		codeupb varchar(50),
		upb varchar(150),
		idacc_c varchar(38),
		idacc_r varchar(38),
		printingorder_c varchar(50),
		printingorder_r varchar(50),
		importo_c decimal(19,2),
		importo_r decimal(19,2),
		nriga int
	)
	UPDATE #situazioneeconomica 
	SET section_cr = 'R'
	WHERE (ISNULL(dare,0) - ISNULL(avere,0)) < 0
	AND section_cr = 'C'
	UPDATE #situazioneeconomica
	SET section_cr = 'C'
	WHERE (ISNULL(avere,0) - ISNULL(dare,0)) < 0
	AND section_cr = 'R' 
	
	UPDATE #situazioneeconomica 
	SET section_cr = 'R'
	WHERE ISNULL(dare,0)=0 AND ISNULL(avere,0)= 0
	AND section_cr = 'C'
	AND placcount_sign = 'N'
	
	
	UPDATE #situazioneeconomica 
	SET section_cr = 'C'
	WHERE ISNULL(dare,0)=0 AND ISNULL(avere,0)= 0
	AND section_cr = 'R'
	AND placcount_sign = 'N'
	UPDATE #situazioneeconomica
	SET nriga =
	1 +
	ISNULL(
		(SELECT COUNT(*) FROM #situazioneeconomica r2
		WHERE r2.printingorderacc < #situazioneeconomica.printingorderacc
		AND r2.section_cr = 'C')
	,0)
	WHERE section_cr = 'C'
	
	UPDATE #situazioneeconomica
	SET nriga =
	1 +
	ISNULL(
		(SELECT COUNT(*) FROM #situazioneeconomica r2
		WHERE r2.printingorderacc < #situazioneeconomica.printingorderacc
		AND r2.section_cr = 'R')
	,0)
	WHERE section_cr = 'R'
	DECLARE @nriga_c int
	DECLARE @nriga_r int
	SET @nriga_c = ISNULL((SELECT MAX(nriga) FROM #situazioneeconomica WHERE section_cr = 'C'),0)
	SET @nriga_r = ISNULL((SELECT MAX(nriga) FROM #situazioneeconomica WHERE section_cr = 'R'),0)
	IF (@nriga_c >= @nriga_r)
	BEGIN
		INSERT INTO #rptfinale (idupb, codeupb, upb,idacc_c, printingorder_c, importo_c, nriga)
		SELECT idupb, codeupb, upb,idacc, printingorderacc, (ISNULL(dare,0) - ISNULL(avere,0)), nriga
		FROM #situazioneeconomica
		WHERE section_cr = 'C'
		ORDER BY nriga
		UPDATE #rptfinale
		SET idacc_r = idacc,
		printingorder_r = printingorderacc,
		importo_r = (ISNULL(avere,0) - ISNULL(dare,0))
		FROM #situazioneeconomica
		WHERE #situazioneeconomica.section_cr = 'R'
		AND #rptfinale.nriga = #situazioneeconomica.nriga
	END
	ELSE
	BEGIN
		INSERT INTO #rptfinale (idupb, codeupb, upb,idacc_r, printingorder_r, importo_r, nriga)
		SELECT idupb, codeupb, upb,idacc, printingorderacc, (ISNULL(avere,0) - ISNULL(dare,0)), nriga
		FROM #situazioneeconomica
		WHERE section_cr = 'R'
		ORDER BY nriga
		UPDATE #rptfinale
		SET idacc_c = idacc,
		printingorder_c = printingorderacc,
		importo_c = (ISNULL(dare,0) - ISNULL(avere,0))
		FROM #situazioneeconomica
		WHERE #situazioneeconomica.section_cr = 'C'
		AND #rptfinale.nriga = #situazioneeconomica.nriga
	END
	SELECT
	rf.idupb,
	rf.codeupb,
	rf.upb,
	rf.nriga,
	rf.idacc_c, r1.code AS code_c, r1.title AS desc_c,
	r1.idacc1 AS idacc1_c, r1.code1 AS code1_c, r1.desc1 AS desc1_c, r1.order1 AS order1_c,
	r1.idacc2 AS idacc2_c, r1.code2 AS code2_c, r1.desc2 AS desc2_c, r1.order2 AS order2_c,
	r1.idacc3 AS idacc3_c, r1.code3 AS code3_c, r1.desc3 AS desc3_c, r1.order3 AS order3_c,
	r1.idacc4 AS idacc4_c, r1.code4 AS code4_c, r1.desc4 AS desc4_c, r1.order4 AS order4_c,
	r1.idacc5 AS idacc5_c, r1.code5 AS code5_c, r1.desc5 AS desc5_c, r1.order5 AS order5_c,
	r1.idacc6 AS idacc6_c, r1.code6 AS code6_c, r1.desc6 AS desc6_c, r1.order6 AS order6_c,
	r1.nlevel AS nlevel_c,
	isnull(rf.importo_c,0) as importo_c,
	rf.printingorder_c,
	rf.idacc_r, r2.code AS code_r, r2.title AS desc_r,
	r2.idacc1 AS idacc1_r, r2.code1 AS code1_r, r2.desc1 AS desc1_r, r2.order1 AS order1_r,
	r2.idacc2 AS idacc2_r, r2.code2 AS code2_r, r2.desc2 AS desc2_r, r2.order2 AS order2_r,
	r2.idacc3 AS idacc3_r, r2.code3 AS code3_r, r2.desc3 AS desc3_r, r2.order3 AS order3_r,
	r2.idacc4 AS idacc4_r, r2.code4 AS code4_r, r2.desc4 AS desc4_r, r2.order4 AS order4_r,
	r2.idacc5 AS idacc5_r, r2.code5 AS code5_r, r2.desc5 AS desc5_r, r2.order5 AS order5_r,
	r2.idacc6 AS idacc6_r, r2.code6 AS code6_r, r2.desc6 AS desc6_r, r2.order6 AS order6_r,
	r2.nlevel AS nlevel_r,
	isnull(rf.importo_r,0) as importo_r,
	rf.printingorder_r
	FROM #rptfinale rf
	LEFT OUTER JOIN #situazioneeconomica r1
	ON r1.idacc = rf.idacc_c
	AND r1.section_cr = 'C'
	LEFT OUTER JOIN #situazioneeconomica r2
	ON r2.idacc = rf.idacc_r
	AND r2.section_cr = 'R'
	ORDER BY rf.nriga
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
