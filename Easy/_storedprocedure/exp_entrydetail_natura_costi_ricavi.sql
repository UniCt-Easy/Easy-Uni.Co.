
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_entrydetail_natura_costi_ricavi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_entrydetail_natura_costi_ricavi]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--exec [exp_entrydetail_natura_costi_ricavi] 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-03-31 00:00:00'},2018,2018,'P', NULL, NULL, NULL, NULL, 'S', NULL, 'S', NULL, 'S', NULL, NULL, '%', 'N', 'N','S','N'
--setuser 'amm'
--setuser 'amministrazione'
CREATE    procedure [exp_entrydetail_natura_costi_ricavi]
	@ayear  int ,
	@start datetime,
	@stop datetime,
	@ayear_phase_1 int,
	@ayear_phase_2 int,
	@patpart char(1),  
	@codepatrimony varchar(50),
	@placcpart char(1), 
	@codeplaccount varchar(50),
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
	@dettagliata char(1)
AS
BEGIN
IF @patpart = 'E'
SET @patpart = null

IF @placcpart = 'E'
SET @placcpart = null

--exec exp_entrydetail_natura_costi_ricavi 2017, null, null, '%'
IF @codepatrimony is null
SET @codepatrimony = '%'

if @codeplaccount is null
SET @codeplaccount = '%'

set @idupb = isnull(@idupb,'%')


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
	
IF (@dettagliata = 'S')
BEGIN
	SELECT  
		account.codeacc as 'Codice Conto',
		account.title as 'Denominazione Conto',
		upb.codeupb as 'Codice UPB',
		upb.title as 'Denominazione UPB',
		CASE 
			WHEN account.idpatrimony IS NOT NULL THEN 'Stato Patrimoniale'
			WHEN account.idplaccount IS NOT NULL THEN 'Conto Economico'
			ELSE NULL
		END AS 'Schema ufficiale',
		CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.codepatrimony
			WHEN account.idplaccount IS NOT NULL THEN placcount.codeplaccount
			ELSE NULL
		END as 'Codice Voce Schema Ufficiale',
		CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.patpart
			WHEN account.idplaccount IS NOT NULL THEN placcount.placcpart
			ELSE NULL
		END as 'Parte Schema Ufficiale',
			CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.title
			WHEN account.idplaccount IS NOT NULL THEN placcount.title
			ELSE NULL
		END as 'Descrizione Voce Schema Ufficiale',
		CASE
			WHEN ISNULL(entrydetail.amount,0) < 0 THEN -entrydetail.amount
			ELSE 0
		END as 'Dare',
		CASE
			WHEN ISNULL(entrydetail.amount,0) >= 0 THEN entrydetail.amount
			ELSE 0
		END as 'Avere',
		ISNULL(entrydetail.amount,0) as 'Saldo',
		CASE 
			WHEN entrydetail.idepexp IS NOT NULL THEN 'Impegno di Budget'
			WHEN entrydetail.idepacc IS NOT NULL THEN 'Accertamento di Budget'
			ELSE NULL
		END AS 'Fase',
		epexpview.yepexp  as  'Anno di creazione  (Fase 2)',
		epexpview.nepexp  as 'Numero Movimento (Fase 2)',
		epexpview.codemotive  as 'Codice causale',
		--AccmEpexp.title  as 'Descrizione causale Impegno di budget',
		epexpview.codeacc  as 'Codice conto EP',
		epexpview.account  as 'Conto EP',
		--AccountEpexp.title  as 'Descrizione conto EP Impegno di budget',
		epexpview.totaldebit as 'Debiti Totali',
		null as 'Crediti Totali',
		CASE 
			WHEN entrydetail.idepexp IS NOT NULL THEN 'Pre-Impegno di Budget'
			WHEN entrydetail.idepacc IS NOT NULL THEN 'Pre-Accertamento di Budget'
			ELSE NULL
		END AS 'Fase 1',
		epexpview.parentyepexp  as 'Anno di creazione  (Fase 1)',
		epexpview.parentnepexp  as 'Numero (Fase 1)'
	FROM entrydetail
	INNER JOIN entry			ON entrydetail.yentry = entry.yentry	AND entrydetail.nentry = entry.nentry
	JOIN account				ON entrydetail.idacc = account.idacc
	JOIN epexpview		ON epexpview.idepexp = entrydetail.idepexp AND epexpview.yepexp = @ayear_phase_2  	AND epexpview.parentyepexp = @ayear_phase_1 AND epexpview.ayear = @ayear
	LEFT OUTER JOIN registry	ON entrydetail.idreg = registry.idreg
	LEFT OUTER JOIN upb			ON entrydetail.idupb = upb.idupb
	LEFT OUTER JOIN  entrykind ek		ON ek.identrykind = entry.identrykind
	LEFT OUTER JOIN patrimony		ON account.idpatrimony=patrimony.idpatrimony
	LEFT OUTER JOIN placcount		ON account.idplaccount = placcount.idplaccount
	WHERE entry.yentry = @ayear 
		AND (isnull(patrimony.codepatrimony,'') like @codepatrimony +'%'  OR @codepatrimony IS NULL) 
		AND (patrimony.patpart = @patpart or @patpart is null)
		AND (isnull(placcount.codeplaccount,'') like @codeplaccount +'%'  OR @codeplaccount IS NULL)
		AND (placcount.placcpart = @placcpart or @placcpart is null)
		AND (isnull(entrydetail.idupb,'') like @idupb	 OR @idupb = '%')	
		AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) 
		AND (entrydetail.idsor2 IN (SELECT idchild FROM #sortinglink2) OR @idsor2 IS NULL) 
		AND (entrydetail.idsor3 IN (SELECT idchild FROM #sortinglink3) OR @idsor3 IS NULL) 
		AND entry.yentry = @ayear				
		AND (entry.adate BETWEEN @start AND @stop)
		AND (isnull(registry.title,'') like @registry)
		AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilter) = @filteraccount)
		AND (@includiepilogo = 'S' or (entry.identrykind not in (6,11,12)))
	UNION ALL
		SELECT
		account.codeacc as 'Codice Conto',
		account.title as 'Denominazione Conto',
		upb.codeupb as 'Codice UPB',
		upb.title as 'Denominazione UPB',
		CASE 
			WHEN account.idpatrimony IS NOT NULL THEN 'Stato Patrimoniale'
			WHEN account.idplaccount IS NOT NULL THEN 'Conto Economico'
			ELSE NULL
		END AS 'Schema ufficiale',
		CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.codepatrimony
			WHEN account.idplaccount IS NOT NULL THEN placcount.codeplaccount
			ELSE NULL
		END as 'Codice Voce Schema Ufficiale',
		CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.patpart
			WHEN account.idplaccount IS NOT NULL THEN placcount.placcpart
			ELSE NULL
		END as 'Parte Schema Ufficiale',
			CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.title
			WHEN account.idplaccount IS NOT NULL THEN placcount.title
			ELSE NULL
		END as 'Descrizione Voce Schema Ufficiale',
		CASE
			WHEN ISNULL(entrydetail.amount,0) < 0 THEN -entrydetail.amount
			ELSE 0
		END as 'Dare',
		CASE
			WHEN ISNULL(entrydetail.amount,0) >= 0 THEN entrydetail.amount
			ELSE 0
		END as 'Avere',
		ISNULL(entrydetail.amount,0) as 'Saldo',
		CASE 
			WHEN entrydetail.idepexp IS NOT NULL THEN 'Impegno di Budget'
			WHEN entrydetail.idepacc IS NOT NULL THEN 'Accertamento di Budget'
			ELSE NULL
		END AS 'Fase',
		epaccview.yepacc  as  'Anno di creazione  (Fase 2)',
		epaccview.nepacc  as 'Numero Accertamento di budget',

		epaccview.codemotive  as 'Codice causale',
		--AccmEpacc.title  as 'Descrizione causale Accertamento di budget',
		epaccview.codeacc  as 'Codice conto EP',
		epaccview.account  as 'Conto EP',
		--AccountEpacc.title  as 'Descrizione conto EP Accertamento di budget', 
		null as 'Debiti Totali',
		epaccview.totalcredit as 'Crediti Totali',
		CASE 
			WHEN entrydetail.idepexp IS NOT NULL THEN 'Pre-Impegno di Budget'
			WHEN entrydetail.idepacc IS NOT NULL THEN 'Pre-Accertamento di Budget'
			ELSE NULL
		END AS 'Fase 1',
		epaccview.parentyepacc  as 'Anno di creazione  (Fase 1)',
		epaccview.parentnepacc  as 'Numero Movimento (Fase 1)'
	FROM entrydetail
	INNER JOIN entry			ON entrydetail.yentry = entry.yentry		AND entrydetail.nentry = entry.nentry
	LEFT OUTER JOIN registry	ON entrydetail.idreg = registry.idreg
	LEFT OUTER JOIN upb			ON entrydetail.idupb = upb.idupb
	JOIN account				ON entrydetail.idacc = account.idacc
	LEFT OUTER JOIN  entrykind ek		ON ek.identrykind = entry.identrykind
	LEFT OUTER JOIN patrimony			ON account.idpatrimony=patrimony.idpatrimony
	LEFT OUTER JOIN placcount			ON account.idplaccount = placcount.idplaccount
	left outer JOIN epaccview			ON epaccview.idepacc= entrydetail.idepacc AND epaccview.yepacc = @ayear_phase_2  	AND epaccview.parentyepacc = @ayear_phase_1 AND epaccview.ayear = @ayear
	WHERE entry.yentry = @ayear 
		AND (isnull(patrimony.codepatrimony,'') like @codepatrimony +'%'  OR @codepatrimony IS NULL) 
		AND (patrimony.patpart = @patpart or @patpart is null)
		AND (isnull(placcount.codeplaccount,'') like @codeplaccount +'%'  OR @codeplaccount IS NULL)
		AND (placcount.placcpart = @placcpart or @placcpart is null)
		AND (isnull(entrydetail.idupb,'') like @idupb	 OR @idupb = '%')	
		AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) 
		AND (entrydetail.idsor2 IN (SELECT idchild FROM #sortinglink2) OR @idsor2 IS NULL) 
		AND (entrydetail.idsor3 IN (SELECT idchild FROM #sortinglink3) OR @idsor3 IS NULL) 
		AND entry.yentry = @ayear				
		AND (entry.adate BETWEEN @start AND @stop)		
		AND (isnull(registry.title,'') like @registry)
		AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilter) = @filteraccount)
		---and (account.nlevel = @levelusable) 
		AND (@includiepilogo = 'S' or (entry.identrykind not in (6,11,12)))
		and entrydetail.idepexp is null
	END
ELSE
BEGIN
	SELECT
		account.codeacc as 'Codice Conto',
		account.title as 'Denominazione Conto',
		upb.codeupb as 'Codice UPB',
		upb.title as 'Denominazione UPB',
		CASE 
			WHEN account.idpatrimony IS NOT NULL THEN 'Stato Patrimoniale'
			WHEN account.idplaccount IS NOT NULL THEN 'Conto Economico'
			ELSE NULL
		END AS 'Schema ufficiale',
		CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.codepatrimony
			WHEN account.idplaccount IS NOT NULL THEN placcount.codeplaccount
			ELSE NULL
		END as 'Codice Voce Schema Ufficiale',
		CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.patpart
			WHEN account.idplaccount IS NOT NULL THEN placcount.placcpart
			ELSE NULL
		END as 'Parte Schema Ufficiale',
			CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.title
			WHEN account.idplaccount IS NOT NULL THEN placcount.title
			ELSE NULL
		END as 'Descrizione Voce Schema Ufficiale',
		SUM(
		CASE
			WHEN ISNULL(entrydetail.amount,0) < 0 THEN -entrydetail.amount
			ELSE 0
		END) as 'Dare',
		SUM(CASE
			WHEN ISNULL(entrydetail.amount,0) >= 0 THEN entrydetail.amount
			ELSE 0
		END) as 'Avere',
		SUM(ISNULL(entrydetail.amount,0)) as 'Saldo',
		CASE 
			WHEN entrydetail.idepexp IS NOT NULL THEN 'Impegno di Budget'
			WHEN entrydetail.idepacc IS NOT NULL THEN 'Accertamento di Budget'
			ELSE NULL
		END AS 'Fase',
		epexpview.codeacc  as 'Codice conto EP',
		epexpview.account  as 'Conto EP',
		epexpview.yepexp  as  'Anno di creazione  (Fase 2)',
		CASE 
			WHEN entrydetail.idepexp IS NOT NULL THEN 'Pre-Impegno di Budget'
			WHEN entrydetail.idepacc IS NOT NULL THEN 'Pre-Accertamento di Budget'
			ELSE NULL
		END AS 'Fase 1',
		epexpview.parentyepexp  as 'Anno di creazione  (Fase 1)'
		--AccountEpexp.title  as 'Descrizione conto EP Impegno di budget'
	FROM entrydetail
	INNER JOIN entry		ON entrydetail.yentry = entry.yentry		AND entrydetail.nentry = entry.nentry
	JOIN account				ON entrydetail.idacc = account.idacc
	JOIN epexpview		ON epexpview.idepexp = entrydetail.idepexp AND epexpview.yepexp = @ayear_phase_2  	AND epexpview.parentyepexp = @ayear_phase_1 AND epexpview.ayear = @ayear
	LEFT OUTER JOIN registry	ON entrydetail.idreg = registry.idreg
	LEFT OUTER JOIN upb			ON entrydetail.idupb = upb.idupb
	LEFT OUTER JOIN  entrykind ek		ON ek.identrykind = entry.identrykind
	LEFT OUTER JOIN patrimony			ON account.idpatrimony=patrimony.idpatrimony
	LEFT OUTER JOIN placcount			ON account.idplaccount = placcount.idplaccount
	WHERE entry.yentry = @ayear 
		AND (isnull(patrimony.codepatrimony,'') like @codepatrimony +'%'  OR @codepatrimony IS NULL) 
		AND (patrimony.patpart = @patpart or @patpart is null)
		AND (isnull(placcount.codeplaccount,'') like @codeplaccount +'%'  OR @codeplaccount IS NULL)
		AND (placcount.placcpart = @placcpart or @placcpart is null)
		AND (isnull(entrydetail.idupb,'') like @idupb	 OR @idupb = '%')	
		AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) 
		AND (entrydetail.idsor2 IN (SELECT idchild FROM #sortinglink2) OR @idsor2 IS NULL) 
		AND (entrydetail.idsor3 IN (SELECT idchild FROM #sortinglink3) OR @idsor3 IS NULL) 			
		AND (entry.adate BETWEEN @start AND @stop)
		
		AND (isnull(registry.title,'') like @registry)
		AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilter) = @filteraccount)
		---and (account.nlevel = @levelusable) 
		AND (@includiepilogo = 'S' or (entry.identrykind not in (6,11,12)))
		GROUP BY entrydetail.idepexp, entrydetail.idepacc,epexpview.yepexp, epexpview.parentyepexp,epexpview.codeacc, epexpview.account, 
		account.idpatrimony,  patrimony.patpart,
		account.idplaccount,  placcount.placcpart,
		--AccountEpexp.title,
		account.codeacc, account.title,upb.codeupb, upb.title,patrimony.codepatrimony,patrimony.title, placcount.codeplaccount,placcount.title  
	UNION ALL
		SELECT
		account.codeacc as 'Codice Conto',
		account.title as 'Denominazione Conto',
		upb.codeupb as 'Codice UPB',
		upb.title as 'Denominazione UPB',
		CASE 
			WHEN account.idpatrimony IS NOT NULL THEN 'Stato Patrimoniale'
			WHEN account.idplaccount IS NOT NULL THEN 'Conto Economico'
			ELSE NULL
		END AS 'Schema ufficiale',
		CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.codepatrimony
			WHEN account.idplaccount IS NOT NULL THEN placcount.codeplaccount
			ELSE NULL
		END as 'Codice Voce Schema Ufficiale',
		CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.patpart
			WHEN account.idplaccount IS NOT NULL THEN placcount.placcpart
			ELSE NULL
		END as 'Parte Schema Ufficiale',
			CASE
			WHEN account.idpatrimony IS NOT NULL THEN patrimony.title
			WHEN account.idplaccount IS NOT NULL THEN placcount.title
			ELSE NULL
		END as 'Descrizione Voce Schema Ufficiale',
		SUM(
		CASE
			WHEN ISNULL(entrydetail.amount,0) < 0 THEN -entrydetail.amount
			ELSE 0
		END) as 'Dare',
		SUM(CASE
			WHEN ISNULL(entrydetail.amount,0) >= 0 THEN entrydetail.amount
			ELSE 0
		END) as 'Avere',
		SUM(ISNULL(entrydetail.amount,0)) as 'Saldo',
		CASE 
			WHEN entrydetail.idepexp IS NOT NULL THEN 'Impegno di Budget'
			WHEN entrydetail.idepacc IS NOT NULL THEN 'Accertamento di Budget'
			ELSE NULL
		END AS 'Fase',
		epaccview.codeacc  as 'Codice conto EP',
		epaccview.account  as 'Conto EP',
		epaccview.yepacc  as  'Anno di creazione  (Fase 2) ',
		CASE 
			WHEN entrydetail.idepexp IS NOT NULL THEN 'Pre-Impegno di Budget'
			WHEN entrydetail.idepacc IS NOT NULL THEN 'Pre-Accertamento di Budget'
			ELSE NULL
		END AS 'Fase 1',
		epaccview.parentyepacc  as 'Anno di creazione  (Fase 1)'
		--AccountEpacc.title  as 'Descrizione conto EP Accertamento di budget'
	FROM entrydetail
	INNER JOIN entry		ON entrydetail.yentry = entry.yentry		AND entrydetail.nentry = entry.nentry
	JOIN account					ON entrydetail.idacc = account.idacc
	LEFT OUTER JOIN registry		ON entrydetail.idreg = registry.idreg
	LEFT OUTER JOIN upb				ON entrydetail.idupb = upb.idupb
	LEFT OUTER JOIN  entrykind ek	ON ek.identrykind = entry.identrykind
	LEFT OUTER JOIN patrimony		ON account.idpatrimony=patrimony.idpatrimony
	LEFT OUTER JOIN placcount		ON account.idplaccount = placcount.idplaccount
	LEFT OUTER JOIN epaccview		ON epaccview.idepacc= entrydetail.idepacc AND epaccview.yepacc = @ayear_phase_2  	AND epaccview.parentyepacc = @ayear_phase_1 AND epaccview.ayear = @ayear
	WHERE entry.yentry = @ayear 
		AND (isnull(patrimony.codepatrimony,'') like @codepatrimony +'%'  OR @codepatrimony IS NULL) 
		AND (patrimony.patpart = @patpart or @patpart is null)
		AND (isnull(placcount.codeplaccount,'') like @codeplaccount +'%'  OR @codeplaccount IS NULL)
		AND (placcount.placcpart = @placcpart or @placcpart is null)
		AND (isnull(entrydetail.idupb,'') like @idupb	 OR @idupb = '%')	
		AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) 
		AND (entrydetail.idsor2 IN (SELECT idchild FROM #sortinglink2) OR @idsor2 IS NULL) 
		AND (entrydetail.idsor3 IN (SELECT idchild FROM #sortinglink3) OR @idsor3 IS NULL) 
		AND entry.yentry = @ayear				
		AND (entry.adate BETWEEN @start AND @stop)		
		AND (isnull(registry.title,'') like @registry)
		AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilter) = @filteraccount)
		-----and (account.nlevel = @levelusable) 
		AND (@includiepilogo = 'S' or (entry.identrykind not in (6,11,12)))
		and entrydetail.idepexp is null
		GROUP BY entrydetail.idepexp, entrydetail.idepacc,epaccview.yepacc, epaccview.parentyepacc, epaccview.codeacc, epaccview.account, account.idpatrimony,  patrimony.patpart,
		account.idplaccount,  placcount.placcpart,
		--AccountEpacc.title,
		account.codeacc, account.title, upb.codeupb, upb.title,patrimony.codepatrimony,patrimony.title, placcount.codeplaccount,placcount.title 
	END
END

 



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

