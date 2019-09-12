if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_not_transmitted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_not_transmitted]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--[exp_proceeds_not_transmitted] 2009,'27-11-2009','T','T'

CREATE PROCEDURE [exp_proceeds_not_transmitted]
(
	@ayear int,	  			-- esercizio
	@printdate datetime,    -- filtro sulla data di stampa ufficiale
	@kind  char(1),         -- T: tutti, R:a regolarizzazione, N:non a regolarizzazione
	@annulled char(1)		-- T: tutti, S:annullate, N: non annullate
)
AS BEGIN
	CREATE TABLE #proceeds
	(
	phase varchar(50),
	idinc int,
	idreg int,
	registry varchar(100),
	ymov int,
	nmov int,
	doc varchar(35),
	docdate smalldatetime,
	description varchar(150),
	finance varchar(150),
	upb varchar(150),
	curramount decimal(19,2),
	ypro int,
	npro int,
	flagarrear char(1),
	adate smalldatetime,
	printdate smalldatetime,
	transmissiondate smalldatetime,
	annulmentdate	smalldatetime
	)


	INSERT INTO #proceeds
	(phase,idinc,idreg,registry,ymov,nmov,doc,docdate, 
	description,finance,upb,curramount,ypro,npro,
	flagarrear,adate,printdate,transmissiondate, annulmentdate)
	SELECT 
	IL.phase,IL.idinc, IL.idreg,IL.registry, IL.ymov, IL.nmov,
	IL.doc, IL.docdate, IL.description,IL.finance, IL.upb, IL.curramount,
	IL.ypro,IL.npro, IL.flagarrear,P.adate,P.printdate,PT.transmissiondate,P.annulmentdate
	FROM incomelastview IL
	JOIN proceeds P
		ON P.kpro = IL.kpro
	LEFT OUTER JOIN proceedstransmission PT
		ON PT.kproceedstransmission = P.kproceedstransmission
	WHERE IL.ypro = @ayear 
	AND P.printdate <= @printdate AND
	(
		(IL.nbill IS NULL AND @kind = 'N') OR
		(IL.nbill IS NOT NULL AND @kind = 'R') OR
		(@kind = 'T')
	)
	AND
	(
		((IL.curramount > 0) AND @annulled = 'N') OR
		((IL.curramount = 0) AND @annulled = 'S') OR
		(@annulled = 'T')
	)
	AND ISNULL(PT.transmissiondate,'2079-01-01')>@printdate
	ORDER BY IL.ymov, IL.nmov,IL.ypro,IL.npro

	SELECT 
		phase as 'Fase',
		ymov as 'Eserc. Mov.' ,
		nmov as 'Num. Mov',
		registry as 'Anagrafica',
		description as 'Descrizione',
		finance as 'Bilancio',
		upb as 'UPB',
		curramount as 'Importo Corrente',
		flagarrear as 'Compet.',
		ypro as 'Eserc. Reversale',
		npro as 'Num. Reversale',
		adate as 'Emissione',
		printdate as 'Stampa Uff.',
		transmissiondate as 'Trasmissione',
		annulmentdate	as 'Annullamento'
	FROM #proceeds
	ORDER BY ymov, nmov,ypro, npro

END