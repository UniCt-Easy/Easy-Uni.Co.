
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riclassificatosiope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riclassificatosiope]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure exp_riclassificatosiope(
	@ayear int,
	@kind char(1),		-- Expense / Income
	@userkind char(1),	-- D = dipartimento; A = amministrazione
	@viewfin char(1)	-- Indica se mostrare o meno la voce di bilancio.
) as 
begin


CREATE TABLE #error (msg varchar(1000))
INSERT INTO  #error (msg) EXEC Exp_check_siope @ayear, @kind, @userkind 

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT msg as 'Errori' FROM #error
	ORDER BY msg
	RETURN
END


DECLARE @iSIOPE INT
DECLARE @eSIOPE INT

IF (@userkind = 'A')
Begin
-- Amministrazione
	SELECT @iSIOPE = idsorkind from sortingkind where codesorkind = '10E_MACROSIOPE_AMMIN'
	SELECT @eSIOPE = idsorkind from sortingkind where codesorkind = '10S_MACROSIOPE_AMMIN'
end
Else
Begin
-- Dipartimento
	SELECT @iSIOPE = idsorkind from sortingkind where codesorkind = '10E_MACROSIOPE_DIP'
	SELECT @eSIOPE = idsorkind from sortingkind where codesorkind = '10S_MACROSIOPE_DIP'
End

CREATE TABLE #CLASSIFICATO(
	idfin int,
	nlevel	tinyint,
	idsor int,
	quota float,	
	previsioneLibera  decimal(19,2),
	previsioneVincolata  decimal(19,2),
	quotaLibera float,
	quotaVincolata float,
	previsioneCapitolo decimal(19,2),
	nlevelclass tinyint
)
-- Leggiamo il minimo livello operativo, di solito è il Capitolo.
DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM finlevel
WHERE ayear = @ayear and (flag&2)<>0

DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @supposed_jan01 decimal(19,2)

DECLARE @fin_kind tinyint
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

IF (@kind = 'I')
BEGIN
	SELECT
		@supposed_ff_jan01 =
			ISNULL(startfloatfund, 0) +
			ISNULL(proceedstilldate, 0) -
			ISNULL(paymentstilldate, 0) +
			ISNULL(proceedstoendofyear, 0) -
			ISNULL(paymentstoendofyear, 0),
		@supposed_aa_jan01 =
			ISNULL(startfloatfund, 0) +
			ISNULL(proceedstilldate, 0) -
			ISNULL(paymentstilldate, 0) +
			ISNULL(proceedstoendofyear, 0) -
			ISNULL(paymentstoendofyear, 0) +
			ISNULL(supposedpreviousrevenue, 0) +
			ISNULL(supposedcurrentrevenue , 0) -
			ISNULL(supposedpreviousexpenditure, 0) -
			ISNULL(supposedcurrentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1

	IF(@fin_kind = 2) 
	Begin 
		-- il bilancio è di Cassa
		SET @supposed_jan01 = @supposed_ff_jan01;
	End
	Else
	Begin	
		-- il bilancio è di Competenza
		SET @supposed_jan01 = @supposed_aa_jan01;
	End	
END


-- Nella tabella ci metto tutto ciò che è classificato dal titolo al capitolo, articolo. Tutto senza differenze.
-- Poi farò una seconda INSERT in cui ci metto tutti i capitoli che non hanno una classificazione propria ma assumono
-- implicitamente quella della categoria o titolo.
-- Per questi capitoli metteremo la propria previsione, la quota vincolata, la quota libera. Quest'ultime saranno copiate dalla categoria/titolo
-- di apprtenenza
-- Poi, sempre per questi capitoli, faremo un UPDATE per valorizzare rispettivamente:
-- PrevisioneLibera = previsione * quotaLibera
-- PrevisioneVincolata = previsione * quotaVincolata
-- In OUT alla sp, forniremo gli importi delle classificazioni, leggendo solo le righe dei capitoli.


IF (@kind='E')
Begin
	INSERT INTO #CLASSIFICATO(
		idfin,
		nlevel,
		previsioneLibera,		
		previsioneVincolata,
		idsor,
		quotaLibera,
		quotaVincolata
	)
	SELECT 
		F.idfin,
		F.nlevel,
		-- Previsione Libera
		ISNULL((SELECT sum(FY.prevision * FS2.quota) 
		FROM finyear FY	
		JOIN finsorting FS2
			ON FY.idfin = FS2.idfin
		JOIN sorting S2
			ON S2.idsor = FS2.idsor
		WHERE FY.ayear = @ayear
			AND FY.idfin = F.idfin
			AND S2.idsor = S.idsor
			AND substring(S2.sortcode, len(S2.sortcode)-1,1)='@'
			AND substring(S2.sortcode, len(S2.sortcode),1)='L'
			),0),
		-- Previsione Vincolata
		ISNULL((SELECT sum(FY.prevision * FS2.quota) 
		FROM finyear FY	
		JOIN finsorting FS2
			ON FY.idfin = FS2.idfin
		JOIN sorting S2
			ON S2.idsor = FS2.idsor
		WHERE FY.ayear = @ayear
			AND FY.idfin = F.idfin
			AND S2.idsor = S.idsor
			AND substring(S2.sortcode, len(S2.sortcode)-1,1)='@'
			AND substring(S2.sortcode, len(S2.sortcode),1)='V'
			),0),
		FS.idsor,
		-- Quota Libera
		ISNULL((SELECT FS2.quota
		FROM finsorting FS2
		JOIN sorting S2
			ON S2.idsor = FS2.idsor
		WHERE FS2.idfin = F.idfin
			AND S2.idsor = S.idsor
			AND substring(S2.sortcode, len(S2.sortcode)-1,1)='@'
			AND substring(S2.sortcode, len(S2.sortcode),1)='L'
			),0),
		-- Quota Vincolata
		ISNULL((SELECT FS2.quota
		FROM finsorting FS2
		JOIN sorting S2
			ON S2.idsor = FS2.idsor
		WHERE FS2.idfin = F.idfin
			AND S2.idsor = S.idsor
			AND substring(S2.sortcode, len(S2.sortcode)-1,1)='@'
			AND substring(S2.sortcode, len(S2.sortcode),1)='V'
			),0)
	FROM fin F 
	JOIN finsorting FS 
		ON FS.idfin = F.idfin
	JOIN sorting S
        ON S.idsor = FS.idsor 
	WHERE ((F.flag&1)<>0) -- solo la parte Spesa
		AND F.ayear = @ayear
        AND S.idsorkind = @eSIOPE
END
Else
Begin
	INSERT INTO #CLASSIFICATO(
		idfin,
		nlevel,
		previsioneLibera,		
		previsioneVincolata,
		idsor,
		quotaLibera,
		quotaVincolata
	)
	SELECT 
		F.idfin,
		F.nlevel,
		-- Previsione Libera
		ISNULL((SELECT sum(FY.prevision * FS2.quota) 
		FROM finyear FY	
		JOIN finsorting FS2
			ON FY.idfin = FS2.idfin
		JOIN sorting S2
			ON S2.idsor = FS2.idsor
		WHERE FY.ayear = @ayear
			AND FY.idfin = F.idfin
			AND S2.idsor = S.idsor
			AND substring(S2.sortcode, len(S2.sortcode)-1,1)='@'
			AND substring(S2.sortcode, len(S2.sortcode),1)='L'
			),0),
		-- Previsione Vincolata
		ISNULL((SELECT sum(FY.prevision * FS2.quota) 
		FROM finyear FY	
		JOIN finsorting FS2
			ON FY.idfin = FS2.idfin
		JOIN sorting S2
			ON S2.idsor = FS2.idsor
		WHERE FY.ayear = @ayear
			AND FY.idfin = F.idfin
			AND S2.idsor = S.idsor
			AND substring(S2.sortcode, len(S2.sortcode)-1,1)='@'
			AND substring(S2.sortcode, len(S2.sortcode),1)='V'
			),0),
		FS.idsor,
		-- Quota Libera
		ISNULL((SELECT FS2.quota
		FROM finsorting FS2
		JOIN sorting S2
			ON S2.idsor = FS2.idsor
		WHERE FS2.idfin = F.idfin
			AND S2.idsor = S.idsor
			AND substring(S2.sortcode, len(S2.sortcode)-1,1)='@'
			AND substring(S2.sortcode, len(S2.sortcode),1)='L'
			),0),
		-- Quota Vincolata
		ISNULL((SELECT FS2.quota
		FROM finsorting FS2
		JOIN sorting S2
			ON S2.idsor = FS2.idsor
		WHERE FS2.idfin = F.idfin
			AND S2.idsor = S.idsor
			AND substring(S2.sortcode, len(S2.sortcode)-1,1)='@'
			AND substring(S2.sortcode, len(S2.sortcode),1)='V'
			),0)
	FROM fin F 
	JOIN finsorting FS 
		ON FS.idfin = F.idfin
	JOIN sorting S
        ON S.idsor = FS.idsor 
	WHERE ((F.flag&1) = 0) -- solo la parte Entrata
		AND F.ayear = @ayear
		AND (F.flag & 16 =0)
        AND S.idsorkind = @iSIOPE
End

-- Inserisco i capitoli, che non ho inserito prima perchè non classificati. 
-- Prenderò questi capitoli NON classificati, per cui è stata classificata direttamente la categoria, o titolo.
-- Queste categorie/titoli saranno presenti nella tab #Classificato.

INSERT INTO #CLASSIFICATO(
	idfin,
	nlevel,
	quotaLibera,		
	quotaVincolata,
	idsor,
	previsioneCapitolo,
	nlevelclass	-- Indica il lievello a cui è stata attribuita la class, se al titolo, alla categoria, al capitolo...
)
SELECT 
	F.idfin,	
	F.nlevel,
	C.quotaLibera,		
	C.quotaVincolata,
	C.idsor,
	SUM(FY.prevision),
	C.nlevel 
FROM #CLASSIFICATO C
JOIN finlink FLK 
	ON FLK.idparent = C.idfin 
JOIN finlink FLK2
	ON FLK2.idchild = FLK.idchild AND FLK2.nlevel = @minoplevel
JOIN Fin F
	ON F.idfin = FLK2.idchild
JOIN finyear FY
	ON FY.idfin = F.idfin	
WHERE F.nlevel = @minoplevel
		AND (F.flag & 16 =0)
		AND NOT EXISTS (select * from #CLASSIFICATO C2
					where C2.idfin = F.idfin)
GROUP BY F.idfin, F.nlevel, C.nlevel, C.quotaLibera, C.quotaVincolata, C.idsor

-- Valorizzo le previsioni Libere e Vincolate dei capitolo inseriti in precedenza, calcolate come quota parte della previsione principale.

UPDATE #CLASSIFICATO
	SET previsioneLibera = isnull(previsioneCapitolo,0) * quotaLibera,
		previsioneVincolata = isnull(previsioneCapitolo,0) * quotaVincolata
	WHERE isnull(previsioneCapitolo,0) >0

-- Cancello le righe delle Categorie e Titolo, lasciando solo i Capitoli.
DELETE FROM #CLASSIFICATO WHERE nlevel <> @minoplevel


-- Se ho classificato un titolo con una classificazione, per indicare che tutte le relative categorie avranno quella classificazione.
-- E poi per una di queste categorie ho inserito una classiicazione diversa da quella del titolo
-- In #Classificato avrò sia il titolo che la categoria
-- Nella INSERT precedente, avrò inserito tutti quei capitoli non classificati per cui, però, esiste un livello padre classificato.
-- Nella situazione descritta, in #classificato avrò due padri del capitolo, quindi lui inserirà due volte lo stesso capitolo:
-- una volta come figlio del titolo, una volta come figlio della categoria.
-- Con la seguente DELETE vogliamo cancellare quelle classificazioni che provengono dai titoli, laddove vi sia una classificazione che proviene
-- dalla categoria. Pertanto useremo "nlevelclass" che denota, appunto, il lievello a cui è stata attribuita la class, se al titolo, alla categoria, al capitolo...

DELETE FROM #CLASSIFICATO
WHERE nlevelclass <  ( select min(nlevelclass) from #CLASSIFICATO C2 
							where C2.idfin = #CLASSIFICATO.idfin 
								and C2.nlevelclass > #CLASSIFICATO.nlevelclass )

-- Inserisco nella tabella di #OUTPUT le righe, prendendo come codice di classificazione il livello precedente a quello attuale, 
-- depurando il codice da suffisso aggiunto da noi, cosicché 123@L e 123@V diventino una sola riga con codice 123. In particale in #CLASSIFICATO abbiamo: 
-- COD:123@L con PrevisioneLibera = 80		PrevisioneVincolata = 0
-- COD:123@V con PrevisioneLibera = 0		PrevisioneVincolata = 20
-- In #OUTPUT avremo:
-- COD:123	con PrevisioneLibera = 80		PrevisioneVincolata = 20

CREATE TABLE #OUTPUT(
	PrintingOrder varchar(50),
	Codice varchar(50),
	Descrizione varchar(200),
	PrevisioneLibera decimal(19,2),
	PrevisioneVincolata decimal(19,2),		
	Totale decimal(19,2),
	Bilancio varchar(50),
	idsor int
)

IF ((@viewfin = 'S'))
Begin
 -- Ho decido di vedere anche il Capitolo a cui è stata attribuita la classificazione.
	INSERT INTO #OUTPUT(
		Bilancio,
		PrintingOrder,
		Codice,idsor,
		Descrizione,
		PrevisioneLibera,
		PrevisioneVincolata	,
		Totale 
	)
	SELECT  
		F.codefin,
		S_Parent.printingorder,
		S_Parent.sortcode,S_Parent.idsor,
		S_Parent.description,
		SUM(C.previsioneLibera),		
		SUM(C.previsioneVincolata),
		SUM(ISNULL(C.previsioneLibera,0) + ISNULL(C.previsioneVincolata,0)) 
	from #CLASSIFICATO C
	join sorting S			------> è la foglia 123@L
		on S.idsor = C.idsor
	JOIN sorting S_parent	------> è il nodo precedente 123
		ON S_Parent.idsor = S.paridsor
	JOIN fin F
		ON F.idfin = C.idfin
	GROUP BY F.codefin,S_Parent.sortcode,S_Parent.printingorder,S_Parent.idsor,	S_Parent.description
End
ELSE
Begin
-- Non voglio vedere il Capitolo
	INSERT INTO #OUTPUT(
		PrintingOrder,
		Codice, 
		idsor,
		Descrizione,
		PrevisioneLibera,
		PrevisioneVincolata	,
		Totale 
	)
	SELECT  
		S_Parent.printingorder,
		S_Parent.sortcode,
		S_Parent.idsor,
		S_Parent.description,
		SUM(C.previsioneLibera),		
		SUM(C.previsioneVincolata),
		SUM(ISNULL(C.previsioneLibera,0) + ISNULL(C.previsioneVincolata,0)) 
	from #CLASSIFICATO C
	join sorting S			------> è la foglia 123@L
		on S.idsor = C.idsor
	JOIN sorting S_parent	------> è il nodo precedente 123
		ON S_Parent.idsor = S.paridsor
	GROUP BY S_Parent.sortcode,	S_Parent.printingorder, S_Parent.idsor,	S_Parent.description
End

IF ((@kind = 'I') AND NOT EXISTS (SELECT * FROM #OUTPUT WHERE PrintingOrder = 'z.3'))
Begin
	INSERT INTO #OUTPUT(PrintingOrder, Codice, Descrizione, PrevisioneLibera, PrevisioneVincolata, Totale)
	VALUES ('z.3', 'z.3', 'Avanzo di amministrazione presunto/Fondo cassa presunto', @supposed_jan01, null, @supposed_jan01 )
End

-- Aggiungo tutti i codici di Classificazione che non sono stati usati, ossia quei codici che non sono stati attribuiti ad alcuna voce di bilancio.
-- Escludo il Titolo "Z". Escludo solo, perchè i figli (Partite di giro, etc...) mi serviranno dopo per calcolare i Totale Complessivo.

INSERT INTO #OUTPUT(
	PrintingOrder, 
	Codice, idsor,
	Descrizione, 
	PrevisioneLibera, PrevisioneVincolata, Totale
	)
SELECT  
	S.printingorder,
	S.sortcode, 
	S.idsor,
	S.description,
	NULL, NULL, NULL
FROM sorting S		
WHERE ( (S.idsorkind = @iSIOPE AND @kind = 'I')	OR	(S.idsorkind = @eSIOPE AND @kind = 'E')	)
	AND substring(S.sortcode, len(S.sortcode)-1,1)<>'@'
	AND NOT EXISTS (SELECT * FROM #OUTPUT O1 
					WHERE O1.Codice = S.sortcode)
	AND S.sortcode <> 'Z'
	

-- Inserisce la riga dei Totali Parziali: somma gli importi delle classificazioni, scartando le righe relative ai codici che iniziano per Z..:
-- z.1 : Partite di giro
-- z.2 : Trasferimenti Interni
-- z.3 : Avanzo di amministrazione presunto/Fondo cassa presunto
-- ...

INSERT INTO #OUTPUT(
	PrintingOrder,
	Codice,
	Descrizione,
	PrevisioneLibera,
	PrevisioneVincolata	,
	Totale
)
SELECT 
	'Z',
	NULL,
	CASE when ( @userkind ='A' )	
				Then 'TOTALE PARZIALE A.C.'
				Else 'TOTALE PARZIALE STRUTTURE DECENTRATE'
	End,
	SUM(PrevisioneLibera),
	SUM(PrevisioneVincolata),
	SUM(Totale)
FROM #OUTPUT
WHERE PrintingOrder NOT LIKE 'Z%'

-- Inserisce la riga dei Totali Generali
INSERT INTO #OUTPUT(
	PrintingOrder,
	Codice,
	Descrizione,
	PrevisioneLibera,
	PrevisioneVincolata	,
	Totale
)
SELECT 
	'ZZ',
	NULL,
	CASE when (@userkind ='A') 
			Then 'TOTALE GENERALE A.C.'
			Else 'TOTALE GENERALE STRUTTURE DECENTRATE'
	End,
	SUM(PrevisioneLibera),
	SUM(PrevisioneVincolata),
	SUM(Totale)
FROM #OUTPUT
WHERE PrintingOrder LIKE 'Z%'

-- SELECT FINALE
IF (@kind='E')
Begin
-- Parte spesa
	IF (@viewfin='S') 
	-- Parte spesa con Bilancio
	Begin
		SELECT 	
			CASE	when (substring (Codice,1,1)='Z') Then NULL
					when ((substring (descrizione,1,3) = '>>>') AND @userkind='A')	Then NULL
					when ((substring (descrizione,1,3) = '>>>') AND @userkind='D' AND @kind = 'I' )	Then NULL
					Else Codice	
			End AS Codice,
			Descrizione,
			PrevisioneLibera as 'su Entrate Disponibili',
			PrevisioneVincolata	as 'su Entrate con vincolo di destinazione',
			Totale,
			Bilancio as 'Bilancio Spesa'
		FROM #OUTPUT
		ORDER BY PrintingOrder
	End
	Else
	Begin
	-- Parte spesa senza Bilancio
		SELECT 	
			CASE	when (substring (Codice,1,1)='Z')	Then NULL
					when ((substring (descrizione,1,3) = '>>>') AND @userkind='A')	Then NULL
					when ((substring (descrizione,1,3) = '>>>') AND @userkind='D' AND @kind = 'I' )	Then NULL
					Else Codice	
			End AS Codice,
			Descrizione,
			PrevisioneLibera as 'su Entrate Disponibili',
			PrevisioneVincolata	as 'su Entrate con vincolo di destinazione',
			Totale 
		FROM #OUTPUT
		ORDER BY PrintingOrder
	End
End
ELSE
Begin
-- Parte Entrata
	IF (@viewfin='S') 
	Begin
	-- Parte Entrata con Bilancio
		SELECT 	
			CASE	when (substring (Codice,1,1) = 'Z')	Then NULL
					when ((substring (descrizione,1,3) = '>>>') AND @userkind='A')	Then NULL
					when ((substring (descrizione,1,3) = '>>>') AND @userkind='D' AND @kind = 'I' )	Then NULL
					Else Codice	
			End AS Codice,
			Descrizione,
			PrevisioneLibera as 'Entrate Disponibili',
			PrevisioneVincolata	as 'Entrate con vincolo di destinazione',
			Totale,
			Bilancio as 'Bilancio Entrata'
		FROM #OUTPUT
		ORDER BY PrintingOrder
	End
	Else
	Begin
	-- Parte Entrata senza Bilancio
		SELECT 	
			CASE	when (substring (Codice,1,1) = 'Z')	Then NULL
					when ((substring (descrizione,1,3) = '>>>') AND @userkind='A')	Then NULL
					when ((substring (descrizione,1,3) = '>>>') AND @userkind='D' AND @kind = 'I' )	Then NULL
					Else Codice	
			End AS Codice,
			Descrizione,
			PrevisioneLibera as 'Entrate Disponibili',
			PrevisioneVincolata	as 'Entrate con vincolo di destinazione',
			Totale 
		FROM #OUTPUT
		ORDER BY PrintingOrder
	End
End


DROP TABLE #CLASSIFICATO
DROP TABLE #OUTPUT

end




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
