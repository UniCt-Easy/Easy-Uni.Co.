if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[exp_fg_riclassificatosupagatoconprev]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fg_riclassificatosupagatoconprev]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure exp_fg_riclassificatosupagatoconprev(
	@idsorkindmaster int,--class origine
    	@idsorkindchild int,-- class destinazione
	@ayear smallint,
	@date datetime,
	@kind char(1)-- Expense / Income
) as 
begin

-- EXEC  prova_claa 	14,29,	2009,{ts '2009-12-31 00:00:00'},'E'
-- Bilancio SIRGS - SIOPE Spesa
-- EXEC  prova_claa 	14,6,	2009,{ts '2009-12-31 00:00:00'},'I'


CREATE TABLE #CLASSIFICATO(
	tipoclass varchar(50),
	codiceclass varchar(50), 
	classificazione varchar(200),
	bilancio varchar(50),
	perc_prev_prevista  decimal(19,4),
	pagatosullacoppia  decimal(19,2),
	previsionesulcapitolo  decimal(19,2),
	perc_pagata  decimal(19,4)
)

CREATE TABLE #OUT(
	tipoclass varchar(50),
	codiceclass varchar(50), 
	classificazione varchar(200),
	bilancio varchar(50),
	perc_prev_prevista  decimal(19,4),
	pagatosullacoppia  decimal(19,2),
	previsionesulcapitolo  decimal(19,2),
	perc_pagata  decimal(19,4)
)

IF (@kind='E')
Begin
	INSERT INTO #CLASSIFICATO(
		tipoclass,
		codiceclass, 
		classificazione,
		bilancio,
		perc_prev_prevista,
		previsionesulcapitolo,		
		pagatosullacoppia
	)
	SELECT 
		sortingkind.description,
		sortmaster.sortcode, 
		sortmaster.description, 
		F.codefin,
		--perc_prev_prevista
		FS.quota,

		-- Previsione alla data sul capitolo
		ISNULL((SELECT sum(FY.prevision ) 
		FROM finyear FY	
		WHERE FY.ayear = @ayear
			AND FY.idfin = F.idfin),0)
		+
		ISNULL((SELECT sum(FVD.amount)
		FROM finvar FV
		JOIN finvardetail FVD
			ON FV.yvar = FVD.yvar
			AND FV.nvar = FVD.nvar
		WHERE FVD.idfin = F.idfin
			AND FV.adate <= @date
			AND FV.yvar = @ayear 
			AND FV.idfinvarstatus = 5),0),

		-- Somma del pagato sulla coppia
		ISNULL((SELECT sum(BKS.amount) 
		FROM banktransactionsorting BKS
		JOIN banktransaction BKT
                on BKT.yban = BKS.yban 
                and BKT.nban = BKS.nban
		JOIN expenseyear EY
			on BKT.idexp = EY.idexp
		JOIN finsorting FS
			on EY.idfin = FS.idfin
		JOIN sorting S
			on S.idsor = FS.idsor
		WHERE EY.ayear = @ayear
			AND EY.idfin = F.idfin
			AND BKS.idsor = SORTCHILD.idsor		-- SIOPE
			AND S.idsorkind = SORTMASTER.idsorkind	-- SIRGS
			AND S.idsor = SORTMASTER.idsor),0)
	FROM finsorting FS 
	JOIN sortingtranslation 
		ON sortingtranslation.idsortingmaster = FS.idsor 
	JOIN fin F
		ON FS.idfin = F.idfin
	JOIN sorting SORTMASTER
                on SORTMASTER.idsor = sortingtranslation.idsortingmaster -- SIRGS
	JOIN sortingkind 
                on sortingkind.idsorkind = SORTMASTER.idsorkind
	JOIN sorting SORTCHILD
                on SORTCHILD.idsor = sortingtranslation.idsortingchild -- S I O P E
	WHERE ((F.flag&1)<>0) -- solo la parte spesa
		AND F.ayear = @ayear
        AND SORTMASTER.idsorkind = @idsorkindmaster
        AND SORTCHILD.idsorkind = @idsorkindchild
	ORDER BY sortingkind.description, sortmaster.sortcode
End
Else
Begin
	INSERT INTO #CLASSIFICATO(
		tipoclass,
		codiceclass, 
		classificazione,
		bilancio,
		perc_prev_prevista,
		previsionesulcapitolo,		
		pagatosullacoppia
	)
	SELECT 
		sortingkind.description,
		sortmaster.sortcode, 
		sortmaster.description, 
		F.codefin,
		--perc_prev_prevista
		FS.quota,

		-- Previsione alla data sul capitolo
		ISNULL((SELECT sum(FY.prevision ) 
		FROM finyear FY	
		WHERE FY.ayear = @ayear
			AND FY.idfin = F.idfin),0)
		+
		ISNULL((SELECT sum(FVD.amount)
		FROM finvar FV
		JOIN finvardetail FVD
			ON FV.yvar = FVD.yvar
			AND FV.nvar = FVD.nvar
		WHERE FVD.idfin = F.idfin
			AND FV.adate <= @date
			AND FV.yvar = @ayear 
			AND FV.idfinvarstatus = 5),0),

		-- Somma del pagato sulla coppia
		ISNULL((SELECT sum(BKS.amount) 
		FROM banktransactionsorting BKS
		JOIN banktransaction BKT
                on BKT.yban = BKS.yban 
                and BKT.nban = BKS.nban
		JOIN incomeyear EY
			on BKT.idinc = EY.idinc
		JOIN finsorting FS
			on EY.idfin = FS.idfin
		JOIN sorting S
			on S.idsor = FS.idsor
		WHERE EY.ayear = @ayear
			AND EY.idfin = F.idfin
			AND BKS.idsor = SORTCHILD.idsor		-- SIOPE
			AND S.idsorkind = SORTMASTER.idsorkind	-- SIRGS
			AND S.idsor = SORTMASTER.idsor),0)
	FROM finsorting FS 
	JOIN sortingtranslation 
		ON sortingtranslation.idsortingmaster = FS.idsor 
	JOIN fin F
		ON FS.idfin = F.idfin
	JOIN sorting SORTMASTER
                on SORTMASTER.idsor = sortingtranslation.idsortingmaster -- SIRGS
	JOIN sortingkind 
                on sortingkind.idsorkind = SORTMASTER.idsorkind
	JOIN sorting SORTCHILD
                on SORTCHILD.idsor = sortingtranslation.idsortingchild -- S I O P E
	WHERE ((F.flag&1)=0) -- solo la parte entrata
		AND F.ayear = @ayear
        AND SORTMASTER.idsorkind = @idsorkindmaster
        AND SORTCHILD.idsorkind = @idsorkindchild
	ORDER BY sortingkind.description, sortmaster.sortcode

End

INSERT INTO #OUT(
	tipoclass,
	codiceclass, 
	classificazione,
	bilancio,
	perc_prev_prevista,
	previsionesulcapitolo,		
	pagatosullacoppia
)
SELECT
	tipoclass,
	codiceclass, 
	classificazione,
	bilancio,
	perc_prev_prevista,
	previsionesulcapitolo,		
	SUM(pagatosullacoppia)
FROM #CLASSIFICATO
GROUP BY tipoclass,	codiceclass, classificazione, bilancio, perc_prev_prevista,	previsionesulcapitolo		

UPDATE #OUT SET perc_pagata = pagatosullacoppia / previsionesulcapitolo where previsionesulcapitolo<>0

-- qualora ci fosse un pagamento senza una previsione mostreremo: 100% pagamenti, 0% previsione 
UPDATE #OUT SET perc_pagata = 1, 
			perc_prev_prevista = 0 
WHERE previsionesulcapitolo = 0
 
-- IMPORTANTE --
-- Devo fornire in OUT nella #tab SOLO QUELLE RIGHE PER CUI CI SONO CAPITOLI AVENTI RIGHE CON 'SIRGS' SFORATO

-- Cancella le righe per cui la % pagata è UGUALE alla % prevista, ossia ho pagato tutto ciò che prevedevo di pagare
DELETE FROM #OUT WHERE perc_prev_prevista = perc_pagata

-- Cancella quelle righe per cui la voce di bilancio non ha previsione sforata. Se esiste per la stessa voce di bilancio
-- anche una sola riga con previsione sforata, non deve visualizzare solo quella riga, ma tutte le righe di quella voce di bilancio
-- per avere una visione generale della situazione e quindi agevolare la correzione.
DELETE FROM #OUT 
WHERE bilancio not in  (SELECT c1.bilancio FROM #OUT c1
					WHERE c1.bilancio = #OUT.bilancio 
					AND c1.perc_pagata > c1.perc_prev_prevista)	


-- Inserisce le class. SIRGS utilizzate ma senza previsioni, ossia non associate ad alcuna vose di bilancio
IF (@kind='E')
Begin
	INSERT INTO #OUT(
		tipoclass,
		codiceclass, 
		classificazione,
		bilancio,
		perc_prev_prevista,
		previsionesulcapitolo,		
		pagatosullacoppia
	)
	SELECT 
		sortingkind.description,
		SIRGS.sortcode, 
		SIRGS.description, 
		NULL,
		--perc_prev_prevista
		0,
		-- Previsione alla data sul capitolo
		0,
		-- Somma del pagato sulla coppia
		SUM(BKS.amount) 
	FROM banktransactionsorting BKS
		JOIN banktransaction BKT
			ON BKT.yban = BKS.yban 
            AND BKT.nban = BKS.nban
		JOIN expenseyear EY
			ON BKT.idexp = EY.idexp
		JOIN sorting SIOPE
			ON SIOPE.idsor = BKS.idsor
		JOIN sortingtranslation 
			ON SIOPE.idsor = sortingtranslation.idsortingchild	-- SIOPE
		JOIN sorting SIRGS
            ON SIRGS.idsor = sortingtranslation.idsortingmaster -- SIRGS
		JOIN sortingkind 
				on sortingkind.idsorkind = SIRGS.idsorkind
	WHERE EY.ayear = @ayear
		AND SIRGS.idsorkind = @idsorkindmaster
        AND SIOPE.idsorkind = @idsorkindchild
		AND NOT EXISTS (SELECT * FROM finsorting FS WHERE  FS.idfin = EY.idfin and FS.idsor = SIRGS.idsor)
	GROUP BY sortingkind.description, SIRGS.sortcode,SIRGS.description
End
Else
Begin 
	INSERT INTO #OUT(
		tipoclass,
		codiceclass, 
		classificazione,
		bilancio,
		perc_prev_prevista,
		previsionesulcapitolo,		
		pagatosullacoppia
	)
	SELECT 
		sortingkind.description,
		SIRGS.sortcode, 
		SIRGS.description, 
		NULL,
		--perc_prev_prevista
		0,
		-- Previsione alla data sul capitolo
		0,
		-- Somma del pagato sulla coppia
		SUM(BKS.amount) 
	FROM banktransactionsorting BKS
		JOIN banktransaction BKT
			ON BKT.yban = BKS.yban 
            AND BKT.nban = BKS.nban
		JOIN incomeyear EY
			ON BKT.idinc = EY.idinc
		JOIN sorting SIOPE
			ON SIOPE.idsor = BKS.idsor
		JOIN sortingtranslation 
			ON SIOPE.idsor = sortingtranslation.idsortingchild	-- SIOPE
		JOIN sorting SIRGS
            ON SIRGS.idsor = sortingtranslation.idsortingmaster -- SIRGS
		JOIN sortingkind 
				on sortingkind.idsorkind = SIRGS.idsorkind
	WHERE EY.ayear = @ayear
		AND SIRGS.idsorkind = @idsorkindmaster
        AND SIOPE.idsorkind = @idsorkindchild
		AND NOT EXISTS (SELECT * FROM finsorting FS WHERE  FS.idfin = EY.idfin and FS.idsor = SIRGS.idsor)
	GROUP BY sortingkind.description, SIRGS.sortcode,SIRGS.description

End

IF (@kind='E')
Begin
-- Parte spesa
	SELECT 
		tipoclass as 'Tipo Class',
		codiceclass as 'Codice Class', 
		classificazione as 'Classificazione',
		bilancio 'Bilancio',
		perc_prev_prevista *100 as '% Prevista',
		perc_pagata *100 as '% Pagata',
		(perc_prev_prevista * previsionesulcapitolo) as 'Importo Previsto',
		pagatosullacoppia as 'Importo Pagato'
	FROM #OUT
	ORDER BY bilancio, codiceclass,classificazione
End
Else
Begin
-- Parte entrata
	SELECT 
		tipoclass as 'Tipo Class',
		codiceclass as 'Codice Class', 
		classificazione as 'Classificazione',
		bilancio 'Bilancio',
		perc_prev_prevista *100 as '% Prevista',
		perc_pagata *100 as '% Incassata',
		(perc_prev_prevista * previsionesulcapitolo) as 'Importo Previsto',
		pagatosullacoppia as 'Importo Incassato'
	FROM #OUT
	ORDER BY bilancio, codiceclass,classificazione
End
		
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO






