
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_elenco_riporti_entrate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_elenco_riporti_entrate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 -- setuser 'amministrazione'
-- exp_elenco_riporti_entrate 2015,'102010'
-- exp_elenco_riporti_uscite 2015,'1'
CREATE      PROCEDURE [exp_elenco_riporti_entrate]
(
	@esercizio 					smallint,
	@codicebilancio				varchar(10)
)
AS
--------------------------------------------------------------------------
------------------ personalizzazione solo per BARI -----------------------
--------------------------------------------------------------------------
BEGIN
 

if @codicebilancio != '%' set @codicebilancio=@codicebilancio+'%'
if (@codicebilancio is null) set @codicebilancio  ='%'


	CREATE TABLE #exp_excel
		(
			fase    				varchar(50)			NULL,
			esercmovimento			smallint			NULL,
			nummovimento			smallint			NULL,
			anno					smallint			NULL,
			idspesa					varchar(100)		NULL,
			idinc					int					NULL,
			codicebilancio_old		varchar(50)			NULL,
			codicecentrospesa_old	varchar(50)			NULL,
			codicebilancio			varchar(50)			NULL,
			codicecentrospesa		varchar(50)			NULL,
			responsabile			varchar(100)		NULL,
			documento				varchar(50)			NULL,
			datadocumento			smalldatetime		NULL,
			descrizione				varchar(150)		NULL,
			importooriginale		float				NULL,
			importo0101				float				NULL,
			disponibile				float				NULL,
			versante				varchar(150) NULL,
			flagcompetenza			char(1) NULL,
			idupb					varchar(36)
		)
	set nocount on
------------------------------
print @codicebilancio
SELECT  income.idinc, 
	incomeyear.ayear, 
	income.idreg, 
	incomeyear.idupb, 
	incomeyear.idfin, 
	incomeyear_old.idfin as idfin_old,
	incomeyear_old.idupb as idupb_old
INTO #prova
	FROM income
	join incomeyear	incomeyear_old	on incomeyear_old.idinc=income.idinc  and incomeyear_old.ayear  = @esercizio  
	join incomeyear					on incomeyear.idinc=income.idinc  and incomeyear.ayear  = @esercizio+1  
	left outer join registry		on income.idreg=registry.idreg 
	join fin fin_old					on fin_old.idfin=incomeyear_old.idfin  
	join fin						on fin.idfin=incomeyear.idfin  
	--JOIN incomelink					ON incomelink.idchild = income.idinc  
	--										AND incomelink.idparent = income.idinc
WHERE income.nphase < 3 AND fin_old.codefin LIKE @codicebilancio 

----
--SELECT * from #prova JOIN fin ON fin.idfin = #prova.idfin
--JOIN fin fin_old ON fin_old.idfin = #prova.idfin_old
-- JOIN incomeview ON incomeview.idinc = #prova.idinc

INSERT INTO #exp_excel
SELECT 	incomephase.description,income.ymov,income.nmov, 
	CAST ((select E1.ymov  FROM  income E1					 
		JOIN incomelink elk1
			ON elk1.idparent = E1.idinc AND elk1.nlevel = 1
			where elk1.idchild = #prova.idinc
		) AS varchar(4)),
	-- inizio idspesa
	''''+(select (SUBSTRING(convert(varchar(4),E1.ymov),3,2) + '/' + convert(varchar(6),E1.nmov))
		FROM  income E1					 
			JOIN incomelink elk1
				ON elk1.idparent = E1.idinc AND elk1.nlevel = 1
			where elk1.idchild = #prova.idinc
	) + 
	ISNULL('-' +
	(select (SUBSTRING(convert(varchar(4),E1.ymov),3,2) + '/' + convert(varchar(6),E1.nmov))
		FROM  income E1					 
			JOIN incomelink elk1
				ON elk1.idparent = E1.idinc AND elk1.nlevel = 2
			where  elk1.idchild = #prova.idinc
	),'') +
	ISNULL( '-' +
	(select (SUBSTRING(convert(varchar(4),E1.ymov),3,2) + '/' + convert(varchar(6),E1.nmov))
		FROM  income E1					 
			JOIN incomelink elk1
				ON elk1.idparent = E1.idinc AND elk1.nlevel = 3
			where  elk1.idchild = #prova.idinc
	),'') , 
	income.idinc, 
	fin_old.codefin as 'Bilancio_old',
	upb_old.codeupb as 'Upb_old',
	fin.codefin ,
	upb.codeupb ,
	null, null,null,
	income.description as 'Descrizione',
	incomeyear_starting.amount,
	incometotal.curramount as 'Importo corrente',
	incometotal.available,
	registry.title,
	CASE
		WHEN (select E1.ymov  FROM  income E1					 
		JOIN incomelink elk1
			ON elk1.idparent = E1.idinc AND elk1.nlevel = 1
			where elk1.idchild = #prova.idinc
		)=@esercizio THEN 'C'
		ELSE 'R'
	END AS 'flagcompetenza',
	#PROVA.idupb

FROM #prova
LEFT OUTER JOIN fin					on fin.idfin=#prova.idfin
LEFT OUTER JOIN upb					on upb.idupb=#prova.idupb
LEFT OUTER JOIN fin fin_old					on fin_old.idfin=#prova.idfin_old
LEFT OUTER JOIN upb upb_old					on upb_old.idupb=#prova.idupb_old

--LEFT OUTER JOIN registry	on registry.idreg=#prova.idreg
LEFT OUTER JOIN income				on income.idinc=#prova.idinc
LEFT OUTER JOIN incomelast			on incomelast.idinc = #prova.idinc
LEFT OUTER JOIN incometotal			ON incometotal.idinc = #prova.idinc AND incometotal.ayear = #prova.ayear 
LEFT OUTER JOIN incometotal incometotal_firstyear
								  	ON incometotal_firstyear.idinc = income.idinc
  										AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting
									ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  										AND incomeyear_starting.ayear = incometotal_firstyear.ayear
LEFT OUTER JOIN registry			ON registry.idreg = #prova.idreg
JOIN incomephase					ON incomephase.nphase = income.nphase

WHERE incometotal.ayear  = @esercizio+1  AND income.nphase < 3 AND fin_old.codefin LIKE @codicebilancio

---------------------------------------------------

DELETE #exp_excel
WHERE anno > @esercizio
UPDATE #exp_excel
SET disponibile = (SELECT ISNULL(MIN(IM.available),0.0)
		   FROM incometotal IM
		   WHERE IM.idinc = #exp_excel.idinc
		   AND IM.ayear > @esercizio)


	set nocount off
	SELECT 
	idspesa as 'ID Spesa',
	Fase, 
	Esercmovimento as 'Eserc. mov',
	Nummovimento as 'Num. mov', 
	Documento as 'Doc.', 
	Descrizione, 
	importooriginale as 'Importo originale',
	importo0101 as 'Importo Corrente', 
	Disponibile as 'Disponibile Attuale', 
	null as 'Da Incassare',
	null as 'Riporti',
	null as 'Economie',
	flagcompetenza AS 'FlagComp',
	versante AS 'Versante',
	codicebilancio_old AS 'Codice Bilancio',
	codicecentrospesa_old as 'Centro di Spesa',
	idupb as 'ID Centro di Spesa'
	FROM #exp_excel
	order by anno,idspesa
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




 
