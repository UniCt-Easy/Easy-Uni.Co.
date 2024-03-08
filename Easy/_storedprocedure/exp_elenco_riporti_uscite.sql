
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_elenco_riporti_uscite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_elenco_riporti_uscite]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exp_elenco_riporti_uscite 2015,'101010'
-- setuser 'amministrazione'
-- sp_exp_elenco_riporti_uscite 2008,'302020'
CREATE      PROCEDURE [exp_elenco_riporti_uscite]
(
	@esercizio 					smallint,
	@codicebilancio				varchar(10),
	@centrospesa		varchar(50) = '%'
)
AS
BEGIN

if @codicebilancio != '%' set @codicebilancio=@codicebilancio+'%'
if (@codicebilancio is null) set @codicebilancio  ='%'
 
IF @centrospesa IS NULL OR @centrospesa= '' 	set @centrospesa = '%'



---- determino la fase pagamento
DECLARE @nphase_max tinyint--char(1)  o
SELECT  @nphase_max = max(nphase) FROM expensephase  





	CREATE TABLE #exp_excel
		(
			nphase			tinyint,		
			fase    				varchar(50)			NULL,
			esercmovimento				smallint			NULL,
			nummovimento				int			NULL,
			anno					smallint			NULL,
			idspesa					varchar(100)			NULL,
			idexp					int				NULL,
			codicebilancio_old		varchar(50)			NULL,
			codicecentrospesa_old	varchar(50)			NULL,
			codicebilancio				varchar(50)			NULL,
			codicecentrospesa			varchar(50)			NULL,
			denominazioneCS				varchar(200)		NULL,
			responsabile				varchar(100)			NULL,
			documento				varchar(50)			NULL,
			datadocumento				smalldatetime		NULL,
			descrizione				varchar(150)		NULL,
			importooriginale				float				NULL,
			importo0101				float				NULL,
			disponibile				float				NULL,
			flagcompetenza				char(1) NULL,
			idupb					varchar(36)
		)
	set nocount on
------------------------------

SELECT  expense.idexp, 
	expenseyear.ayear, 
	expense.idreg, 
	expenseyear.idfin, 
	expenseyear.idupb,
	expenseyear_old.idfin as idfin_old,
	expenseyear_old.idupb as idupb_old
INTO #prova
	FROM expense
	join expenseyear	expenseyear_old	on expenseyear_old.idexp=expense.idexp  and expenseyear_old.ayear  = @esercizio  
	join expenseyear					on expenseyear.idexp=expense.idexp  and expenseyear.ayear  = @esercizio+1  
	left outer join registry			on expense.idreg=registry.idreg 
	join fin fin_old					on fin_old.idfin=expenseyear_old.idfin  
	join fin						on fin.idfin=expenseyear.idfin  
	join upb					on upb.idupb=expenseyear.idupb  
	JOIN expenselink			ON expenselink.idchild = expense.idexp  
												AND expenselink.idparent = expense.idexp
WHERE fin_old.codefin LIKE @codicebilancio 
	  AND upb.idupb LIKE @centrospesa and 	  expense.nphase< 5
--

--SELECT * from #prova JOIN fin ON fin.idfin = #prova.idfin
INSERT INTO #exp_excel
SELECT 	expensephase.nphase, expensephase.description,expense.ymov,expense.nmov, 
	CAST ((select E1.ymov  FROM  expense E1					 
		JOIN expenselink elk1
			ON elk1.idparent = E1.idexp AND elk1.nlevel = 1
			where elk1.idchild = #prova.idexp
		) AS varchar(4)),

	''''+(select (SUBSTRING(convert(varchar(4),E1.ymov),3,2) + '/' +REPLICATE('0',5-DATALENGTH(convert(varchar(6),E1.nmov)))+convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 1
			where elk1.idchild = #prova.idexp
	) + 
	ISNULL('-' +
	(select (SUBSTRING(convert(varchar(4),E1.ymov),3,2) + '/' + REPLICATE('0',5-DATALENGTH(convert(varchar(6),E1.nmov)))+convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 2
			where  elk1.idchild = #prova.idexp
	),'') +
	ISNULL( '-' +
	(select (SUBSTRING(convert(varchar(4),E1.ymov),3,2) + '/' + REPLICATE('0',5-DATALENGTH(convert(varchar(6),E1.nmov)))+convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 3
			where  elk1.idchild = #prova.idexp
	),'') +
	ISNULL( '-' +
	(select (SUBSTRING(convert(varchar(4),E1.ymov),3,2) + '/' + REPLICATE('0',5-DATALENGTH(convert(varchar(6),E1.nmov)))+convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 4
			where  elk1.idchild = #prova.idexp
	),'') +
	ISNULL( '-' +
	(select (convert(varchar(4),E1.ymov) + '/' + REPLICATE('0',5-DATALENGTH(convert(varchar(6),E1.nmov)))+convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 5
			where  elk1.idchild = #prova.idexp
	),''), 
	expense.idexp, 
--	+ (convert(varchar(4),payment.ypay) + '/' + convert(varchar(6),payment.npay)) ,
	fin_old.codefin as 'Bilancio_old',
	upb_old.codeupb as 'Upb_old',
	fin.codefin ,
	upb.codeupb ,
	upb.title,
	null, null,null,
	expense.description as 'Descrizione',
	expenseyear_starting.amount,
	expensetotal.curramount as 'Importo corrente',
	expensetotal.available,
	CASE
		WHEN (select E1.ymov  FROM  expense E1					 
		JOIN expenselink elk1
			ON elk1.idparent = E1.idexp AND elk1.nlevel = 1
			where elk1.idchild = #prova.idexp
		)=@esercizio THEN 'C'
		ELSE 'R'
	END AS 'flagcompetenza',
	#PROVA.idupb

FROM #prova
LEFT OUTER JOIN fin					on fin.idfin=#prova.idfin
LEFT OUTER JOIN upb					on upb.idupb=#prova.idupb
LEFT OUTER JOIN fin fin_old					on fin_old.idfin=#prova.idfin_old
LEFT OUTER JOIN upb upb_old					on upb_old.idupb=#prova.idupb_old
--LEFT OUTER JOIN registry 	on registry.idreg=#prova.idreg
LEFT OUTER JOIN expense				on expense.idexp=#prova.idexp
LEFT OUTER JOIN expenselast			on expenselast.idexp = #prova.idexp
LEFT OUTER JOIN payment				on payment.kpay = expenselast.kpay
LEFT OUTER JOIN service				on service.idser = expenselast.idser  
LEFT OUTER JOIN expensetotal		ON expensetotal.idexp = #prova.idexp AND expensetotal.ayear = #prova.ayear 
LEFT OUTER JOIN expensetotal expensetotal_firstyear
  									ON expensetotal_firstyear.idexp = expense.idexp 	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
									ON expenseyear_starting.idexp = expensetotal_firstyear.idexp  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
JOIN expensephase					ON expensephase.nphase = expense.nphase
WHERE expensetotal.ayear  = @esercizio+1  AND expense.nphase < 5  AND fin_old.codefin LIKE @codicebilancio
AND upb.idupb LIKE @centrospesa 
---------------------------------------------------

DELETE #exp_excel
WHERE anno > @esercizio
UPDATE #exp_excel
SET disponibile = (SELECT ISNULL(MIN(IM.available),0.0)
		   FROM expensetotal IM
		   WHERE IM.idexp = #exp_excel.idexp
		   AND IM.ayear > @esercizio)


	set nocount off
	SELECT 
	idspesa as 'ID spesa',
	Fase, 
	Esercmovimento as 'Eserc. mov',
	Nummovimento as 'Num. mov', 
	Documento as 'Doc.', 
	Descrizione, 
	importooriginale as 'Importo originale',
	importo0101 as 'Importo Corrente', 
	Disponibile as 'Disponibile Attuale', 
	null as 'Da pagare',
	null as 'Riporti',
	null as 'Economie',
	flagcompetenza AS 'FlagComp',
	codicebilancio AS 'Codice Bilancio',
	codicecentrospesa AS 'Codice Centro Spesa',
	denominazioneCS AS 'Denominazione Centro di Spesa',
	idupb as 'ID Centro Spesa'
	FROM #exp_excel
	where nphase < @nphase_max -- Fase pagamento
	order by idspesa
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 



