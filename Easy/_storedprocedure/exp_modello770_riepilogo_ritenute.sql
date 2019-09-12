if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_riepilogo_ritenute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_riepilogo_ritenute]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [exp_modello770_riepilogo_ritenute]
	@ayear int, 
	@kind char(1) -- D--> Dettagliata A--> Aggregata

---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------

AS
BEGIN

--setuser 'amministrazione' 
--[exp_modello770_riepilogo_ritenute] 2017, 'D'
DECLARE @annoredditi int
set @annoredditi = @ayear -1 

CREATE TABLE #spesa  (
	idexp int,nmov int,ymov int,npay int,
    idreg int, 
	datetaxpay datetime,
	desc_exp varchar(150),
	idser int,
	servicestart datetime,
	servicestop datetime,
	transmissiondate datetime
	)
INSERT INTO #spesa   
	(idexp, nmov, ymov,npay, 
    idreg, 
	datetaxpay,
	desc_exp,
	idser,servicestart,servicestop,
	transmissiondate
)

SELECT 
	EL.idexp,        --> idexp dei movimenti interessati
	expense.nmov,
	expense.ymov,P.npay,
	expense.idreg,
	null,
	expense.description,
	EL.idser,
	EL.servicestart,
	EL.servicestop,
	PT.transmissiondate
FROM  expense 
JOIN expenselast EL
        ON expense.idexp = EL.idexp
JOIN payment P
        ON P.kpay = EL.kpay 
JOIN paymenttransmission PT
		ON PT.kpaymenttransmission = P.kpaymenttransmission
JOIN expenseyear
	ON EL.idexp = expenseyear.idexp
WHERE PT.ypaymenttransmission = @annoredditi        
 AND expenseyear.ayear = @annoredditi   
   

CREATE TABLE #tax
(
	operazione varchar(30),
        idreg int,
-- le info relative al mov. di spesa e alla prestazione
-- andranno visualizzate in caso di NON consolidamento
	desc_exp varchar(150),
	idser int,
	servicestart datetime,
	servicestop datetime,
	nmov int,
	ymov int,
	npay int,

-- inforitenute
        taxcode int,
        taxablegross decimal(19,2),
        taxablenet decimal(19,2),
        employtax decimal(19,2),
        admintax decimal(19,2),
        abatements decimal(19,2),
        idexp int,
        stop datetime,datetaxpay datetime,
        rowkind char,
		ytaxpay int,
		ntaxpay int,
-- info relative al comune e regione fiscale
	idcity int,
	idfiscaltaxregion varchar(5),
	transmissiondate datetime
)

       -- 1) Prendere le righe che hanno Data Inizio Validità NULL
 --Applica nel periodo
 INSERT INTO #tax
(
		operazione,
		nmov,
		ymov,npay,
		taxablegross,
		taxablenet,
		employtax,
		admintax,
		abatements,
		idexp,
		taxcode,
		idreg,
		datetaxpay,
		stop,
		rowkind,
		ytaxpay,
		ntaxpay,
		idcity,
		idfiscaltaxregion,
		desc_exp,idser,servicestart,servicestop,
		transmissiondate  
) 
SELECT 
		null, --CASE  WHEN (E.start IS NULL AND E.stop IS NULL)  THEN 'Ritenuta'
		--	  WHEN (year(E.start) = @annoredditi)  THEN 'Correzione Rit.'
		--	  WHEN (year(E.stop ) = @annoredditi)  THEN 'Annullamento Rit.'
		--END,
		S.nmov,
		S.ymov,
        S.npay,
        isnull(E.taxablegross,0),
        isnull(E.taxablenet,0),
        isnull(E.employtax,0),
        isnull(E.admintax,0),
        isnull(E.abatements,0),
        E.idexp,
        E.taxcode,
        S.idreg,
		--info dell'anagafica
        null,
        null,
		1,
		E.ytaxpay,
		E.ntaxpay,
        E.idcity,
	E.idfiscaltaxregion,
	S.desc_exp,
	S.idser,S.servicestart,S.servicestop,
	S.transmissiondate 
FROM expensetax E
JOIN tax ON tax.taxcode = E.taxcode
JOIN #spesa S 
  ON S.idexp = E.idexp
JOIN registry R ON R.idreg =  S.idreg 
WHERE tax.taxkind IN (1,5)
AND   isnull(E.employtax,0) <> 0

-- 2) Prendere le righe che hanno Data Inizio Validità nell'esercizio  di input       
-- Correzioni fatte nel periodo

-- 3) Prendere le righe che hanno Data Fine Validità nell'esercizio di input;
-- Annullamenti fatti nel periodo

--AND ( E.start IS NULL AND E.stop IS NULL )  OR (year(E.start ) = @annoredditi) OR year(E.stop ) = @annoredditi 

INSERT INTO #tax
(
		--operazione,
		nmov,
		ymov,npay,
		taxablegross,
		taxablenet,
		employtax,
		admintax,
		abatements,
		idexp,
		taxcode,
		idreg,
		datetaxpay,
		stop,
		rowkind,
		ytaxpay,
		ntaxpay,
		idcity,
		idfiscaltaxregion,
		desc_exp,idser,servicestart,servicestop,
		transmissiondate  
) 
SELECT 
		--CASE  WHEN (E.start IS NULL AND E.stop IS NULL)  THEN 'Ritenuta'
		--	  WHEN (year(E.start) = @annoredditi)  THEN 'Correzione Rit.'
		--	  WHEN (year(E.stop ) = @annoredditi)  THEN 'Annullamento Rit.'
		--END,
		S.nmov,
		S.ymov,
        S.npay,
        null,
        null,
        isnull(E.employamount,0),
        isnull(E.adminamount,0),
        null,
        E.idexp,
        E.taxcode,
        S.idreg,
		--info dell'anagafica
        null,
        null,
       	2,
		E.ytaxpay,
		E.ntaxpay,
        E.idcity,
	E.idfiscaltaxregion,
	S.desc_exp,
	S.idser,S.servicestart,S.servicestop,
	S.transmissiondate 
FROM expensetaxcorrige E
JOIN tax ON tax.taxcode = E.taxcode
JOIN #spesa S 
  ON S.idexp = E.idexp
JOIN registry R ON R.idreg =  S.idreg 
WHERE tax.taxkind IN (1,5)
AND         isnull(E.employamount,0) <> 0

-- 2) Prendere le righe che hanno Data Inizio Validità nell'esercizio  di input       
-- Correzioni fatte nel periodo

-- 3) Prendere le righe che hanno Data Fine Validità nell'esercizio di input;
-- Annullamenti fatti nel periodo

AND   (year(E.adate ) = @annoredditi)  
 
--select * from #tax
 
CREATE TABLE #output
(
        idreg int,
-- info del movimento di spea
		nmov int,
		ymov int,
		npay int,
		desc_exp varchar(150),
-- info delle prestazioni 
		idser int,
		servicestart datetime,
		servicestop datetime,
		taxcode int,
		taxablegross decimal(19,2),
		taxablenet decimal(19,2),
		employtax decimal(19,2),
		admintax decimal(19,2),
		abatements decimal(19,2),
		idexp int,
		stop datetime,datetaxpay datetime,
		rowkind char,
		ytaxpay int,
		ntaxpay int,
-- info relative al comune e regione fiscale
		idcity int,
		idfiscaltaxregion varchar(5),
	monthtransmission  int,
	yeartransmission  int 
)

 
-- Se ho deciso di consolidare, non verranno visualizzate le info del mov. di spesa
-- e della prestazione, quindi li azzero per accelerare le operazioni di raggruppamento successive.
 

--select * from #tax
INSERT INTO #output
(
	idreg,idexp,
	nmov,
	ymov,npay,desc_exp,
	idser,servicestart,servicestop,
	taxcode,
	taxablegross,
	taxablenet,
	employtax,
	admintax,
	abatements,
	rowkind,
	ytaxpay,
	ntaxpay,
	idcity,
	idfiscaltaxregion ,
	monthtransmission,
	yeartransmission   
)
SELECT
	idreg,idexp,
	nmov,
	ymov,npay,desc_exp,
	idser,servicestart,servicestop,
	taxcode,
	SUM(taxablegross),
	SUM(taxablenet),
	SUM(employtax),
	SUM(admintax),
	SUM(abatements),
	rowkind, -- vale: 1, 2, 3.
	ytaxpay,
	ntaxpay,
	idcity,
	idfiscaltaxregion ,
	month(transmissiondate),  
	year(transmissiondate)  
FROM #tax
GROUP BY idreg,idexp,nmov,ymov,npay, taxcode,rowkind,
        idcity,idfiscaltaxregion,
	desc_exp,idser,servicestart,servicestop, 	month(transmissiondate),  
	year(transmissiondate),ytaxpay,ntaxpay
ORDER BY idreg,rowkind,taxcode
 
--- tipo ritenuta,
--- periodo di riferimento (mese e anno),
--- importo a debito,  
--- importo a credito,	
--- mese liquidazione,
--- anno liquidazione,
--- codice tributo,
--- codice Regione (per addizionale regionale)
--select * from #output

IF (@kind = 'D')  --- dettagliata
 SELECT
					CASE         
	                        WHEN rowkind  = 1 then  tax.description +' (applicata) '
							WHEN rowkind  = 2 then  tax.description +' (correzione) '
	                        ELSE tax.description
	                END as 'Tipo Ritenuta', 
					convert(char(2),monthtransmission) as 'Mese rif.',
					convert(char(4),yeartransmission) as 'Anno rif.',
					tax.fiscaltaxcode as 'Codice Tributo',
					#output.idfiscaltaxregion as 'Cod. Regione Fiscale',-- (capire che codice vuole)
					#output.ytaxpay as 'Eserc. liquidazione ritenuta',
					#output.ntaxpay as 'Num. liquidazione ritenuta',
					F24.nmonth as 'F24EP',
	                F.title as 'Regione Fiscale',
	                R.title as Percipiente,
	        		ISNULL(R.cf, R.foreigncf) as 'CF/CF Estero',
	                R.p_iva as 'P.iva',
					service.description as 'Tipo prest.',
					service.module as 'Modulo',
					(
					select 
					CASE WHEN  ISNULL(im.flagexcludefromcertificate,'N') = 'N' THEN NULL
						 ELSE 'S'
					END
					FROM parasubcontract  co
					JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @ayear --(anno della dichiarazione)
					JOIN payroll ce ON ce.idcon = co.idcon
					JOIN expensepayroll ece ON ece.idpayroll = ce.idpayroll
					JOIN expenselink el ON el.idparent = ece.idexp
					AND  el.idchild = #output.idexp
					) as 'Escluso da Cert. Unica (Parasub.)',
					#output.ymov as 'Esercizio Pagamento',
					#output.nmov as 'Numero Pagamento',
					#output.desc_exp as 'Descrizione',
	                CASE WHEN ISNULL(#output.employtax,0) > 0 THEN #output.employtax ELSE NULL
					END as 'Importo a debito',
					CASE WHEN ISNULL(#output.employtax,0) < 0 THEN #output.employtax ELSE NULL
					END as 'Importo a credito'--,
	       --         CASE WHEN ISNULL(#output.admintax,0) > 0 THEN #output.admintax ELSE NULL END as 'Rit.Amm. (a debito)'  ,  
				    --CASE WHEN ISNULL(#output.admintax,0) < 0 THEN #output.admintax ELSE NULL END as 'Rit.Amm. (a credito)'     
	        FROM #output
	        JOIN tax
	                ON tax.taxcode = #output.taxcode
			LEFT OUTER JOIN taxpay TP
	        	ON TP.ytaxpay = #output.ytaxpay
				AND TP.ntaxpay = #output.ntaxpay
			LEFT OUTER JOIN f24ep F24
	        	ON F24.idf24ep = TP.idf24ep
	        LEFT OUTER JOIN registry R
	                ON #output.idreg = R.idreg
	        LEFT OUTER JOIN geo_city GC
	        	ON GC.idcity = R.idcity
	        LEFT OUTER JOIN geo_country GP
	        	ON GP.idcountry = GC.idcountry
	        LEFT OUTER JOIN geo_nation GN
	        	ON GN.idnation = R.idnation
	        LEFT OUTER JOIN geo_city GC_rit
	        	ON GC_rit.idcity = #output.idcity
	        LEFT OUTER JOIN fiscaltaxregion F
	        	ON F.idfiscaltaxregion = #output.idfiscaltaxregion
			JOIN service ON service.idser = #output.idser
	        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),tax.description, #output.monthtransmission, #output.yeartransmission

ELSE  --- AGGREGATA
 SELECT
					CASE         
	                        WHEN rowkind  = 1 then  tax.description +' (applicata) '
							WHEN rowkind  = 2 then  tax.description +' (correzione) '
	                        ELSE tax.description
	                END as 'Tipo Ritenuta', 
					tax.fiscaltaxcode as 'Codice Tributo',
					convert(char(2),monthtransmission) as 'Mese rif.',
					convert(char(4),yeartransmission) as 'Anno rif.',
					#output.idfiscaltaxregion as 'Cod. Regione Fiscale',-- (capire che codice vuole)
	                F.title as 'Regione Fiscale',
	                CASE WHEN ISNULL(SUM(#output.employtax),0) > 0 THEN ISNULL(SUM(#output.employtax),0) ELSE NULL
					END as 'Importo a debito',
					CASE WHEN ISNULL(SUM(#output.employtax),0) < 0 THEN ISNULL(SUM(#output.employtax),0)ELSE NULL
					END as 'Importo a credito'--,
	       --         CASE WHEN ISNULL(SUM(#output.admintax),0) > 0 THEN ISNULL(SUM(#output.admintax),0) ELSE NULL END as 'Rit.Amm. (a debito)'  ,  
				    --CASE WHEN ISNULL(SUM(#output.admintax),0) < 0 THEN ISNULL(SUM(#output.admintax),0) ELSE NULL END as 'Rit.Amm. (a credito)'     
	        FROM #output
	        JOIN tax
	                ON tax.taxcode = #output.taxcode
	        LEFT OUTER JOIN registry R
	                ON #output.idreg = R.idreg
	        LEFT OUTER JOIN geo_city GC
	        	ON GC.idcity = R.idcity
	        LEFT OUTER JOIN geo_country GP
	        	ON GP.idcountry = GC.idcountry
	        LEFT OUTER JOIN geo_nation GN
	        	ON GN.idnation = R.idnation
	        LEFT OUTER JOIN geo_city GC_rit
	        	ON GC_rit.idcity = #output.idcity
	        LEFT OUTER JOIN fiscaltaxregion F
	        	ON F.idfiscaltaxregion = #output.idfiscaltaxregion
			GROUP BY #output.rowkind,tax.description,tax.fiscaltaxcode,#output.idfiscaltaxregion, F.title,#output.monthtransmission, #output.yeartransmission
	        ORDER BY tax.description,  #output.monthtransmission, #output.yeartransmission

END

 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


