
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mastrino]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mastrino]
GO
--setuser 'amm'
--setuser 'amministrazione'
CREATE    PROCEDURE [rpt_mastrino]
	@ayear int,
	@start datetime,
	@stop datetime,
	@idsor1 int,
	@showchildsor1 char(1),
	@idsor2 int,
	@showchildsor2 char(1),
	@idsor3 int,
	@showchildsor3 char(1),
	--@nlevel varchar(1), task 6454
	@registry varchar(100),
	@filteraccount varchar(50),
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@includiepilogo char(1),
	@raggruppa char(1)
AS
BEGIN
-- exec rpt_mastrino 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-11-19 00:00:00'}, NULL, 'S', NULL, 'S', NULL, 'S', NULL, 'E020205090', '%', 'N', 'N', 'S', 'S'
CREATE TABLE #mastrino
(
	adate datetime,-- data operazione
	yentry int, --esercizio scrittura
	nentry int, --numero scrittura
	codemotive varchar(50),-- codice causale
	description varchar(150),-- descrizione opearazione
	sortingkind1 varchar(50),
	sortcode1 varchar(50),-- C.C
	description1 varchar(200),
	sortingkind2 varchar(50),
	sortcode2 varchar(50),-- C.C
	description2 varchar(200),
	sortingkind3 varchar(50),
	sortcode3 varchar(50),-- C.C
	description3 varchar(200),
	doc varchar(50),-- doc collegato
	docdate datetime,-- data documento
	registry varchar(100),
	idreg int,
	idacc varchar(38),-- 
	--amount decimal(19,2),-- importo
	give decimal(19,2),
	have decimal(19,2),
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150)
)

CREATE TABLE #mastrino_header
(
	adate datetime,-- data operazione
	yentry int, --esercizio scrittura
	nentry int, --numero scrittura
	codemotive varchar(50),-- codice causale
	description varchar(150),-- descrizione opearazione
	sortingkind1 varchar(50),
	sortcode1 varchar(50),-- C.C
	description1 varchar(200),
	sortingkind2 varchar(50),
	sortcode2 varchar(50),-- C.C
	description2 varchar(200),
	sortingkind3 varchar(50),
	sortcode3 varchar(50),-- C.C
	description3 varchar(200),
	doc varchar(50),-- doc collegato
	docdate datetime,-- data documento
	registry varchar(100),
	idreg int,
	idacc varchar(38),-- 
	--amount decimal(19,2),-- importo
	give decimal(19,2),
	have decimal(19,2),
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150)
)

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

CREATE TABLE #sortinglink1
	(
		idchild int 
	)
	
CREATE TABLE #sortinglink2
	(
		idchild int 
	)

CREATE TABLE #sortinglink3
	(
		idchild int 
	) 
-- Valuta se considerare i figli o meno dell'idsor
IF (@showchildsor1 = 'S')
BEGIN
	INSERT INTO #sortinglink1
	SELECT idchild from sortinglink 
	WHERE  idparent = @idsor1
END

IF (@showchildsor2 = 'S')
BEGIN
	INSERT INTO #sortinglink2	
	SELECT idchild from sortinglink 
	WHERE  idparent = @idsor2	
END

IF (@showchildsor3 = 'S')
BEGIN
	INSERT INTO #sortinglink3	
	SELECT idchild from sortinglink 
	WHERE  idparent = @idsor3	
END

-- Se ho scelto un livello sottostante del livello operativo utilizzo quello, 
-- altrimenti userò il I liv.operativo

/*DECLARE @levelusable varchar(20)
SELECT @levelusable = MIN(nlevel)
	FROM accountlevel
	WHERE flagusable = 'S'	AND ayear = @ayear

IF @levelusable < @nlevel
BEGIN
	SET @levelusable = @nlevel
END
*/
-- Calcola la lunghezza del filtro in base ad nlevel		
SET @filteraccount = RTRIM(@filteraccount) PRINT @filteraccount
IF  @filteraccount = ''
BEGIN
	SELECT @filteraccount = NULL
END

DECLARE @lenfilter int
SET @lenfilter = DATALENGTH(RTRIM(ISNULL(@filteraccount,''))) PRINT @lenfilter

--DECLARE @newnlevel int
--SET @newnlevel = (CONVERT(int, @nlevel)*4) + 2 PRINT @newnlevel
	
-- Aggiorna @idupb
IF (@showchildupb = 'S')
BEGIN
	SET @idupb=@idupb+'%' 
END

-- Aggiorna il filtro sul creditore 
IF @registry IS NULL OR @registry = ''
BEGIN
	SET @registry = '%'
END

DECLARE @lenlab int
DECLARE @lenlabdetail int
DECLARE @leneserc int
SET @lenlab = 5  -- Indica la posizione del campo idinvkind all'interno di idrelated nel caso di fattura : INV§1
SET @lenlabdetail = 15  -- Indica la posizione del campo idinvkind all'interno di idrelated nel caso di DETTAGLIO CONTRATTO PASSIVO : MANDATEDETAIL§1

SET @leneserc = 4 -- Viene applicato come len(esercizio) + 1 per calcolare la posizione del numero dell afattura all'interno del campo idrelated
	
INSERT INTO #mastrino_header
(
	adate,
	yentry,
	nentry,
	codemotive,
	description,
	sortcode1,description1,
	sortcode2,description2,
	sortcode3,description3,
	doc,
	docdate ,
	registry,
	idreg,
	idacc,
	--amount ,
	give,
	have,
	upb ,
	codeupb,
	idupb
)
SELECT 
	DATEADD(day, -1, @start),
	null,
	null,
	null,
	'Saldo iniziale',
	null, null,
	null, null,
	null, null,
	null,
	null,
	null,null,
	account.idacc,--SUBSTRING(account.idacc, 1, @newnlevel),  	
	SUM(CASE	WHEN ISNULL(amount,0) < 0 THEN amount	ELSE 0    END),	
	SUM(CASE	WHEN ISNULL(amount,0) >= 0 THEN amount	ELSE 0    END),	
	--amount ,
	case when @showupb='S' then upb.title else null end,	
	case when @showupb='S' then upb.codeupb else null end,	
	case when @showupb='S' then upb.idupb else null end	
FROM entry
JOIN entrydetail			ON entry.yentry  = entrydetail.yentry 	AND entry.nentry = entrydetail.nentry 
JOIN account				ON account.idacc = entrydetail.idacc		
LEFT OUTER JOIN accmotive	on entrydetail.idaccmotive = accmotive.idaccmotive
LEFT OUTER JOIN upb			ON entrydetail.idupb = upb.idupb
LEFT OUTER JOIN registry	on entrydetail.idreg = registry.idreg 
--LEFT OUTER JOIN sorting S1	on entrydetail.idsor1 = S1.idsor  and 	S1.idsorkind = @idsortingkind1 
--LEFT OUTER JOIN sorting S2	on entrydetail.idsor2 = S2.idsor  and  	S2.idsorkind = @idsortingkind2 
--LEFT OUTER JOIN sorting S3 	on entrydetail.idsor3 = S3.idsor and  	S3.idsorkind = @idsortingkind3 
WHERE (isnull(entrydetail.idupb,'') like @idupb	 OR @idupb = '%')	
	--AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) 
	--AND (entrydetail.idsor2 IN (SELECT idchild FROM #sortinglink2) OR @idsor2 IS NULL) 
	--AND (entrydetail.idsor3 IN (SELECT idchild FROM #sortinglink3) OR @idsor3 IS NULL) 
	and entry.yentry = @ayear				
	and (entry.adate < @start )
	and (isnull(registry.title,'') like @registry)
	and (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilter) = @filteraccount)
	---and (account.nlevel = @levelusable) 
	AND (@includiepilogo = 'S' or (entry.identrykind not in (6,11,12)))
group by 	
	--S1.sortcode, S1.description,
	--S2.sortcode, S2.description,
	--S3.sortcode, S3.description,
	account.idacc,
		case when @showupb='S' then upb.title else null end,	
	case when @showupb='S' then upb.codeupb else null end,	
	case when @showupb='S' then upb.idupb else null end	

--select * from #mastrino_header

-- Nel riempimento del mastrino vengono scartate le scritture di EPILOGO (identrykind = '6')

DECLARE @Consideracoordinateanalitiche char(1)
SELECT @Consideracoordinateanalitiche = isnull(paramvalue,'N') 
FROM reportadditionalparam WHERE paramname = 'Consideracoordinateanalitiche' and reportname='mastrinocompatto'
--sp_help reportadditionalparam

if(@Consideracoordinateanalitiche= 'S')
Begin
		INSERT INTO #mastrino
		(
			adate,
			yentry,
			nentry,
			codemotive,
			description,
			sortcode1,description1,
			sortcode2,description2,
			sortcode3,description3,
			doc,
			docdate ,
			registry,
			idreg,
			idacc,
			--amount ,
			give,
			have,
			upb ,
			codeupb,
			idupb
		)
		SELECT 
			entry.adate,
			entry.yentry,
			entry.nentry,
			codemotive,
			entry.description ,
			S1.sortcode, S1.description,
			S2.sortcode, S2.description,
			S3.sortcode, S3.description,
			CASE 
			WHEN SUBSTRING(entry.idrelated,1,3) = 'INV' THEN
				(SELECT 'Fatt. ' + ink.codeinvkind + ' ' 
						+ SUBSTRING(entry.idrelated, (@lenlab + 
									PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,len(entry.idrelated) - @lenlab))),@leneserc
						  ) 
						+ '/' 
						+ SUBSTRING(entry.idrelated,(@lenlab + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab) ) + (@leneserc + 1)
													),
									len(entry.idrelated)-(@lenlab + 
														  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab  )) 
									+ @leneserc )
						  )  --Creazione della stringa Doc nel caso in cui si stia stampando una fattura
				 FROM invoice inv
					JOIN invoicekind ink
						ON inv.idinvkind = ink.idinvkind
				 WHERE ink.idinvkind= CONVERT(int,
										SUBSTRING(entry.idrelated,@lenlab,
												  PATINDEX('%§%',SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
													-1)
									  )
				 AND inv.yinv = CONVERT(int,
										SUBSTRING(entry.idrelated, (@lenlab + 
												  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
										),@leneserc)
								)
				AND inv.ninv = CONVERT(int,				
									   SUBSTRING(entry.idrelated,(@lenlab + 
												 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
												 + (@leneserc + 1) ),
												 len(entry.idrelated)-(@lenlab + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
													  + @leneserc  ) 
												 ) 
										)					
								)
			WHEN SUBSTRING(entry.idrelated,1,3)= 'MAN' AND SUBSTRING(entry.idrelated,1,13) <> 'MANDATEDETAIL' THEN
	
		
				(SELECT 'Ord. ' + man.idmankind + ' ' 
						+ SUBSTRING(entry.idrelated, (@lenlab + 
									PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))),@leneserc
						  ) 
						+ '/' 
						+ SUBSTRING(entry.idrelated,(@lenlab + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab) ) + (@leneserc + 1)
													),
									len(entry.idrelated)-(@lenlab + 
														  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab  )) 
									+ @leneserc )
						  )  --Creazione della stringa Doc nel caso in cui si stia stampando un Contratto Passivo
				 FROM mandate man

				 WHERE man.idmankind=	SUBSTRING(entry.idrelated,@lenlab,
												  PATINDEX('%§%',SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
													-1)
				 AND man.yman = CONVERT(int,
										SUBSTRING(entry.idrelated, (@lenlab + 
												  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
										),@leneserc)
								)
				 AND man.nman = CONVERT(int,				
									   SUBSTRING(entry.idrelated,(@lenlab + 
												 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
												 + (@leneserc + 1) ),
												 len(entry.idrelated)-(@lenlab + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
													  + @leneserc  ) 
												 ) 
										)					
								)
				WHEN SUBSTRING(entry.idrelated,1,3)= 'MAN' AND SUBSTRING(entry.idrelated,1,13) =  'MANDATEDETAIL' THEN
	
		
				(SELECT 'Dett. Ord. ' + man.idmankind + ' ' 
						+ SUBSTRING(entry.idrelated, (@lenlabdetail + 
									PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))),@leneserc
						  ) 
						+ '/' 
						+ SUBSTRING(entry.idrelated,(@lenlabdetail + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail) ) + (@leneserc + 1)
													),
									len(entry.idrelated)-(@lenlabdetail + 
														  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail  )) 
									+ @leneserc )
						  )  --Creazione della stringa Doc nel caso in cui si stia stampando un Contratto Passivo
				 FROM mandate man

				 WHERE man.idmankind=	SUBSTRING(entry.idrelated,@lenlabdetail,
												  PATINDEX('%§%',SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))
													-1)
				 AND man.yman = CONVERT(int,
										SUBSTRING(entry.idrelated, (@lenlabdetail + 
												  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))
										),@leneserc)
								)
				 AND man.nman = CONVERT(int,				
									   SUBSTRING(entry.idrelated,(@lenlabdetail + 
												 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))
												 + (@leneserc + 1) ),
												 len(entry.idrelated)-(@lenlabdetail + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))
													  + @leneserc  ) 
												 ) 
										)					
								)
			ELSE		
				entry.doc
			END,
			entry.docdate ,
			registry.title,	registry.idreg,
			account.idacc,--SUBSTRING(account.idacc, 1, @newnlevel),  	
			CASE	WHEN ISNULL(amount,0) < 0 THEN amount	ELSE 0    END,	
			CASE	WHEN ISNULL(amount,0) >= 0 THEN amount	ELSE 0    END,	
			--amount ,
			case when @showupb='S' then upb.title else null end,	
			case when @showupb='S' then upb.codeupb else null end,	
			case when @showupb='S' then upb.idupb else null end	
		FROM entry
		JOIN entrydetail			ON entry.yentry  = entrydetail.yentry 	AND entry.nentry = entrydetail.nentry 
		JOIN account				ON account.idacc = entrydetail.idacc		
		LEFT OUTER JOIN accmotive	on entrydetail.idaccmotive = accmotive.idaccmotive
		LEFT OUTER JOIN upb			ON entrydetail.idupb = upb.idupb
		LEFT OUTER JOIN registry	on entrydetail.idreg = registry.idreg 
		LEFT OUTER JOIN sorting S1	on entrydetail.idsor1 = S1.idsor  and 	S1.idsorkind = @idsortingkind1 
		LEFT OUTER JOIN sorting S2	on entrydetail.idsor2 = S2.idsor  and  	S2.idsorkind = @idsortingkind2 
		LEFT OUTER JOIN sorting S3 	on entrydetail.idsor3 = S3.idsor and  	S3.idsorkind = @idsortingkind3 
		WHERE (isnull(entrydetail.idupb,'') like @idupb	 OR @idupb = '%')	
			AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) 
			AND (entrydetail.idsor2 IN (SELECT idchild FROM #sortinglink2) OR @idsor2 IS NULL) 
			AND (entrydetail.idsor3 IN (SELECT idchild FROM #sortinglink3) OR @idsor3 IS NULL) 
			and entry.yentry = @ayear				
			and (entry.adate BETWEEN @start AND @stop)
			and (isnull(registry.title,'') like @registry)
			and (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilter) = @filteraccount)
			---and (account.nlevel = @levelusable) 
			AND (@includiepilogo = 'S' or (entry.identrykind not in (6,11,12)))
end	
-- SENZA driver
if(@Consideracoordinateanalitiche= 'N')
Begin
		INSERT INTO #mastrino
		(
			adate,
			yentry,
			nentry,
			codemotive,
			description,
			doc,
			docdate ,
			registry,
			idreg,
			idacc,
			--amount ,
			give,
			have,
			upb ,
			codeupb,
			idupb
		)
		SELECT 
			entry.adate,
			entry.yentry,
			entry.nentry,
			codemotive,
			entry.description ,
			CASE 
			WHEN SUBSTRING(entry.idrelated,1,3) = 'INV' THEN
				(SELECT 'Fatt. ' + ink.codeinvkind + ' ' 
						+ SUBSTRING(entry.idrelated, (@lenlab + 
									PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,len(entry.idrelated) - @lenlab))),@leneserc
						  ) 
						+ '/' 
						+ SUBSTRING(entry.idrelated,(@lenlab + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab) ) + (@leneserc + 1)
													),
									len(entry.idrelated)-(@lenlab + 
														  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab  )) 
									+ @leneserc )
						  )  --Creazione della stringa Doc nel caso in cui si stia stampando una fattura
				 FROM invoice inv
					JOIN invoicekind ink
						ON inv.idinvkind = ink.idinvkind
				 WHERE ink.idinvkind= CONVERT(int,
										SUBSTRING(entry.idrelated,@lenlab,
												  PATINDEX('%§%',SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
													-1)
									  )
				 AND inv.yinv = CONVERT(int,
										SUBSTRING(entry.idrelated, (@lenlab + 
												  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
										),@leneserc)
								)
				AND inv.ninv = CONVERT(int,				
									   SUBSTRING(entry.idrelated,(@lenlab + 
												 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
												 + (@leneserc + 1) ),
												 len(entry.idrelated)-(@lenlab + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
													  + @leneserc  ) 
												 ) 
										)					
								)
			WHEN SUBSTRING(entry.idrelated,1,3)= 'MAN' AND SUBSTRING(entry.idrelated,1,13) <> 'MANDATEDETAIL' THEN
	
		
				(SELECT 'Ord. ' + man.idmankind + ' ' 
						+ SUBSTRING(entry.idrelated, (@lenlab + 
									PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))),@leneserc
						  ) 
						+ '/' 
						+ SUBSTRING(entry.idrelated,(@lenlab + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab) ) + (@leneserc + 1)
													),
									len(entry.idrelated)-(@lenlab + 
														  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab  )) 
									+ @leneserc )
						  )  --Creazione della stringa Doc nel caso in cui si stia stampando un Contratto Passivo
				 FROM mandate man

				 WHERE man.idmankind=	SUBSTRING(entry.idrelated,@lenlab,
												  PATINDEX('%§%',SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
													-1)
				 AND man.yman = CONVERT(int,
										SUBSTRING(entry.idrelated, (@lenlab + 
												  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
										),@leneserc)
								)
				 AND man.nman = CONVERT(int,				
									   SUBSTRING(entry.idrelated,(@lenlab + 
												 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
												 + (@leneserc + 1) ),
												 len(entry.idrelated)-(@lenlab + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlab,LEN(entry.idrelated) - @lenlab))
													  + @leneserc  ) 
												 ) 
										)					
								)
				WHEN SUBSTRING(entry.idrelated,1,3)= 'MAN' AND SUBSTRING(entry.idrelated,1,13) =  'MANDATEDETAIL' THEN
	
		
				(SELECT 'Dett. Ord. ' + man.idmankind + ' ' 
						+ SUBSTRING(entry.idrelated, (@lenlabdetail + 
									PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))),@leneserc
						  ) 
						+ '/' 
						+ SUBSTRING(entry.idrelated,(@lenlabdetail + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail) ) + (@leneserc + 1)
													),
									len(entry.idrelated)-(@lenlabdetail + 
														  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail  )) 
									+ @leneserc )
						  )  --Creazione della stringa Doc nel caso in cui si stia stampando un Contratto Passivo
				 FROM mandate man

				 WHERE man.idmankind=	SUBSTRING(entry.idrelated,@lenlabdetail,
												  PATINDEX('%§%',SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))
													-1)
				 AND man.yman = CONVERT(int,
										SUBSTRING(entry.idrelated, (@lenlabdetail + 
												  PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))
										),@leneserc)
								)
				 AND man.nman = CONVERT(int,				
									   SUBSTRING(entry.idrelated,(@lenlabdetail + 
												 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))
												 + (@leneserc + 1) ),
												 len(entry.idrelated)-(@lenlabdetail + 
													 PATINDEX('%§%', SUBSTRING(entry.idrelated,@lenlabdetail,LEN(entry.idrelated) - @lenlabdetail))
													  + @leneserc  ) 
												 ) 
										)					
								)
			ELSE		
				entry.doc
			END,
			entry.docdate ,
			registry.title,	registry.idreg,
			account.idacc,--SUBSTRING(account.idacc, 1, @newnlevel),  	
			CASE	WHEN ISNULL(amount,0) < 0 THEN amount	ELSE 0    END,	
			CASE	WHEN ISNULL(amount,0) >= 0 THEN amount	ELSE 0    END,	
			--amount ,
			case when @showupb='S' then upb.title else null end,	
			case when @showupb='S' then upb.codeupb else null end,	
			case when @showupb='S' then upb.idupb else null end	
		FROM entry
		JOIN entrydetail			ON entry.yentry  = entrydetail.yentry 	AND entry.nentry = entrydetail.nentry 
		JOIN account				ON account.idacc = entrydetail.idacc		
		LEFT OUTER JOIN accmotive	on entrydetail.idaccmotive = accmotive.idaccmotive
		LEFT OUTER JOIN upb			ON entrydetail.idupb = upb.idupb
		LEFT OUTER JOIN registry	on entrydetail.idreg = registry.idreg 
		WHERE (isnull(entrydetail.idupb,'') like @idupb	 OR @idupb = '%')	
			and entry.yentry = @ayear				
			and (entry.adate BETWEEN @start AND @stop)
			and (isnull(registry.title,'') like @registry)
			and (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilter) = @filteraccount)
			---and (account.nlevel = @levelusable) 
			AND (@includiepilogo = 'S' or (entry.identrykind not in (6,11,12)))
End	


DECLARE @mostraanagrafica char(1)
SELECT 	@mostraanagrafica = paramvalue	FROM reportadditionalparam
WHERE   reportname = 'mastrino' AND
	paramname  = 'MostraAnagrafica'

IF 	(isnull(@mostraanagrafica,'S') = 'N') 
	UPDATE  #mastrino set idreg = null,registry = null
 

IF 	(isnull(@showupb,'S') = 'N') 
	UPDATE  #mastrino set 	codeupb = null,		idupb = null,		upb = null  

DECLARE @mostracoordinateanalitiche char(1)
SELECT 	@mostracoordinateanalitiche = paramvalue	FROM reportadditionalparam
WHERE   reportname = 'mastrino' AND
	paramname  = 'MostraCoordinateAnalitiche'

IF 	(isnull(@mostracoordinateanalitiche,'S') = 'N') 
	UPDATE  #mastrino set codemotive = null


if(@raggruppa = 'S')
Begin
	
	SELECT
		adate 	,
		yentry,
		nentry,
		codemotive ,
		description 	,
		@sortingkind1	as 'cc1',
		sortcode1,
		description1,
		@sortingkind2	as 'cc2',
		sortcode2,	
		description2,
		@sortingkind3	as 'cc3',	
		sortcode3 	,
		description3,
		doc,
		docdate,
		registry,
		idreg,
		account.codeacc as 'codeaccount',
		#mastrino_header.idacc,
		account.title 	as 'title'	,
		account.printingorder as 'printingorder',	
		isnull(sum(give),0) as give,
		isnull(sum(have),0) as have,
		codeupb,
		idupb,
		upb   	
	FROM #mastrino_header 
	JOIN account ON #mastrino_header.idacc = account.idacc
	GROUP BY adate,		yentry,		nentry,		codemotive ,	description 	,				sortcode1,		description1,
				sortcode2,			description2,					sortcode3 	,		description3,
		doc,		docdate,		registry,		idreg,		account.codeacc,		#mastrino_header.idacc,		account.title,
		account.printingorder,			codeupb,		idupb,		upb   
	
	union all
	SELECT
		adate 	,
		yentry,
		nentry,
		codemotive ,
		description 	,
		@sortingkind1	as 'cc1',
		sortcode1,
		description1,
		@sortingkind2	as 'cc2',
		sortcode2,	
		description2,
		@sortingkind3	as 'cc3',	
		sortcode3 	,
		description3,
		doc,
		docdate,
		registry,
		idreg,
		account.codeacc as 'codeaccount',
		#mastrino.idacc,
		account.title 	as 'title'	,
		account.printingorder as 'printingorder',	
		isnull(sum(give),0) as give,
		isnull(sum(have),0) as have,
		codeupb,
		idupb,
		upb   	
	FROM #mastrino 
	JOIN account 
	ON #mastrino.idacc = account.idacc
	GROUP BY adate,		yentry,		nentry,		codemotive ,	description 	,				sortcode1,		description1,
				sortcode2,			description2,					sortcode3 	,		description3,
		doc,		docdate,		registry,		idreg,		account.codeacc,		#mastrino.idacc,		account.title,
		account.printingorder,			codeupb,		idupb,		upb   
	ORDER BY idupb,		upb , adate,account.printingorder
End

if(@raggruppa<>'S')
Begin
	SELECT
		adate 	,
		yentry,
		nentry,
		codemotive ,
		description 	,
		@sortingkind1	as 'cc1',
		sortcode1,
		description1,
		@sortingkind2	as 'cc2',
		sortcode2,	
		description2,
		@sortingkind3	as 'cc3',	
		sortcode3 	,
		description3,
		doc,
		docdate,
		registry,
		idreg,
		account.codeacc as 'codeaccount',
		#mastrino_header.idacc,
		account.title 	as 'title'	,
		account.printingorder as 'printingorder',	
		isnull(give,0) as give,
		isnull(have,0) as have,
		codeupb,
		idupb,
		upb   	
	FROM #mastrino_header 
	JOIN account 
	ON #mastrino_header.idacc = account.idacc
	
	union all
	SELECT
		adate 	,
		yentry,
		nentry,
		codemotive ,
		description 	,
		@sortingkind1	as 'cc1',
		sortcode1,
		description1,
		@sortingkind2	as 'cc2',
		sortcode2,	
		description2,
		@sortingkind3	as 'cc3',	
		sortcode3 	,
		description3,
		doc,
		docdate,
		registry,
		idreg,
		account.codeacc as 'codeaccount',
		#mastrino.idacc,
		account.title 	as 'title'	,
		account.printingorder as 'printingorder',	
		isnull(give,0) as give,
		isnull(have,0) as have,
		codeupb,
		idupb,
		upb   	
	FROM #mastrino 
	JOIN account 
	ON #mastrino.idacc = account.idacc
	ORDER BY adate,account.printingorder
End

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- exec rpt_mastrino 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-11-19 00:00:00'}, NULL, 'S', NULL, 'S', NULL, 'S', NULL, 'E020205090', '%', 'N', 'N', 'S', 'S'
