if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_csa_dipendentiassimilato_single]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_csa_dipendentiassimilato_single]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE exp_interscambio_csa_dipendentiassimilato_single
 (
	@datagenerazione datetime,
	@ayear int,
	@ateneo varchar(5),
	@tipoCompenso char(1),-- Assume valori T = Conto Terzi, C = CO.CO.CO. , B = Borse di studio
	@start datetime,
	@stop datetime
)

-- exec exp_interscambio_csa_dipendentiassimilato_single {ts '2014-12-31 01:02:03'} ,2014, '70136','C',{ts '2014-01-01 01:02:03'},{ts '2014-12-31 01:02:03'}
-- @tipoCompenso char(1),-- Assume valori T = Conto Terzi, C = CO.CO.CO. , B = Borse di studio, M = Missioni


AS 
/*
 CO.CO.CO = prestazioni parasubordinate associate agli imponibili:
 		8147 - Imp. Tesoro stipendio
		8186 - Imp.Ass.ac-si ded-lett.Cbis (collab.,revisori)	
 Borse di studio = prestazioni parasubordinate associate agli imponibili: 		 
		8268 - Imp.Ass.ac-si det-lett.C - Es.Irap (BORSE,..)
 Conto Terzi = prestazioni dipendenti associate agli imponibili:
		8177 - Imp.Ass.ac-no ded-lett.E (intram.,dpr382/80)
		8147 - Imp. Tesoro stipendio
 */
-- exec exp_interscambio_csa_dipendentiassimilato_single {ts '2010-12-31 01:02:03'} ,2010, '70012'
BEGIN

DECLARE @mask int -- Filtro Ritenute

IF (@tipoCompenso = 'C') SET  @mask = 1 --Parasubordinati/Cococo
IF (@tipoCompenso = 'T') SET  @mask = 2 --Compensi a dipendenti/ Conto Terzi
IF (@tipoCompenso = 'B') SET  @mask = 4 --Borse di Studio
IF (@tipoCompenso = 'M') SET  @mask = 8 --Missioni

-- ATTENZIONE: Questa sp è chiamata anche da 'exp_interscambio_csa_dipendentiassimilato_dati'. Quest'ultima mostra i dati che stiamo comunicando attraverso il file.

DECLARE @annoredditi int
SET @annoredditi = @ayear

CREATE TABLE #pagamenti(
		idexp int,
		idregistrylegalstatus int,
		voce8000 varchar(4),
		importo decimal(19,2),
		idreg int
		)

---------------------------------------------------------------------------------------- CONTO TERZI ---------------------------------------------------------------------
if (@tipoCompenso ='T')
Begin
		-- 8177 - Imp.Ass.ac-no ded-lett.E (intram.,dpr382/80)
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				W.idregistrylegalstatus,
				'8177',
				MAX(ETO.taxablegross),
				W.idreg
		FROM wageaddition W
		JOIN wageadditionyear WY
			ON W.ycon = WY.ycon AND W.ncon = WY.ncon 
		JOIN expensewageaddition EW
			ON EW.ncon = W.ncon	AND EW.ycon = W.ycon 
		join expenselink ELK
			ON ELK.idparent = EW.idexp
		join expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		join payment P
			on P.kpay = EL.kpay
		JOIN service S
			ON S.idser = W.idser
		WHERE  P.ypay = @ayear
			AND T.taxkind = 2	-- > Serve l'imponibile Assistenziale = IRAP
			AND S.voce8000='8177'
			--AND V.servicekind = 'DIPENDENTE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND P.kpaymenttransmission IS NOT NULL
			AND P.adate between @start and @stop
			AND ETO.stop is null
			AND W.idregistrylegalstatus IS NOT NULL
		GROUP BY W.idreg, W.idregistrylegalstatus, EL.idexp

		-- 8147 - Imp. Tesoro stipendio
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				W.idregistrylegalstatus,
				'8147',
				MAX(ETO.taxablegross),
				W.idreg
		FROM wageaddition W
		JOIN wageadditionyear WY
			ON W.ycon = WY.ycon AND W.ncon = WY.ncon 
		JOIN expensewageaddition EW
			ON EW.ncon = W.ncon	AND EW.ycon = W.ycon 
		join expenselink ELK
			ON ELK.idparent = EW.idexp
		join expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		join payment P
			on P.kpay = EL.kpay
		JOIN service S
			ON S.idser = W.idser
		WHERE  P.ypay = @ayear
			AND V.voce = '8150' -- Rit. Tesoro c.d.
			AND S.voce8000='8147'
			--  AND V.servicekind = 'DIPENDENTE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND P.kpaymenttransmission IS NOT NULL
			AND P.adate between @start and @stop
			AND ETO.stop is null
			AND W.idregistrylegalstatus IS NOT NULL
		GROUP BY W.idreg, W.idregistrylegalstatus, EL.idexp
		
		-- Inserisce le ritenute c/Amm
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 	
				EL.idexp,
				W.idregistrylegalstatus,
				V.voce,
				SUM(ETO.admintax),
				W.idreg
		FROM wageaddition W
		JOIN wageadditionyear WY
			ON W.ycon = WY.ycon AND W.ncon = WY.ncon 
		JOIN expensewageaddition EW
			ON EW.ncon = W.ncon	AND EW.ycon = W.ycon 
		join expenselink ELK
			ON ELK.idparent = EW.idexp
		join expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN voce8000lookup V
			ON V.taxcode = ETO.taxcode
		join payment P
			on P.kpay = EL.kpay
		JOIN service S
			ON S.idser = W.idser
		WHERE P.ypay = @ayear
			-- AND V.servicekind = 'DIPENDENTE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 in('8177','8147')		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile CSA
			AND V.conto  = 'A' 
			AND isnull(ETO.admintax,0) >= 0
			AND P.kpaymenttransmission IS NOT NULL
			AND P.adate between @start and @stop
			AND W.idregistrylegalstatus IS NOT NULL
			AND ETO.stop is null
		GROUP BY EL.idexp, W.idregistrylegalstatus, V.voce,	W.idreg
		-- la Group By la faccio per la presenza di eventuali scaglioni 

		-- Inserisce le ritenute c/Dip
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 	
				EL.idexp,
				W.idregistrylegalstatus,
				V.voce,
				SUM(ETO.employtax),
				W.idreg
		FROM wageaddition W
		JOIN wageadditionyear WY
			ON W.ycon = WY.ycon AND W.ncon = WY.ncon 
		JOIN expensewageaddition EW
			ON EW.ncon = W.ncon	AND EW.ycon = W.ycon 
		join expenselink ELK
			ON ELK.idparent = EW.idexp
		join expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN voce8000lookup V
			ON V.taxcode = ETO.taxcode
		join payment P
			on P.kpay = EL.kpay
		JOIN service S
			ON S.idser = W.idser
		WHERE  P.ypay = @ayear
			-- AND V.servicekind = 'DIPENDENTE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND V.conto  = 'D' 
			AND S.voce8000 in('8177','8147')		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile CSA
			AND isnull(ETO.employtax,0) >= 0
			AND P.kpaymenttransmission IS NOT NULL
			AND P.adate between @start and @stop
			AND ETO.stop is null
			AND W.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, W.idregistrylegalstatus, V.voce,	W.idreg
		-- la Group By la faccio per la presenza di eventuali scaglioni 
End

---------------------------------------------------------------------------------------- CO.CO.CO.  ----------------------------------------------------------------------------------------------------

IF (@tipoCompenso='C')
Begin
		-- considera solo le prestazioni di COLLABORAZIONE...
		-- Inserisce l'imponibile IRAP:
		-- 8186 Imp.Ass.ac-si ded-lett.Cbis (collab.,revisori) 

		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8186',
				MAX(ETO.taxablegross),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear---fiscalyear = @annoredditi
			AND T.taxkind = 2	-- > Serve l'imponibile Assistenziale = IRAP
			AND geoappliance IS NULL
			--AND V.servicekind = 'ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8186'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND C.idregistrylegalstatus IS NOT NULL
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND ETO.stop is null
		GROUP BY C.idreg, C.idregistrylegalstatus, EL.idexp

		-- 8011 Rit. IRPeF ac - ASSIMILATI
		-- Associata alle prestazioni:
		-- 8147	Imp. Tesoro stipendio
		-- 8186 Imp.Ass.ac-si ded-lett.Cbis (collab.,revisori)
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 	
				EL.idexp,
				C.idregistrylegalstatus,
				'8011',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = ETO.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear--fiscalyear = @annoredditi
			AND V.voce = '8011'
			--AND V.servicekind = 'ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 in('8186','8147')		
			AND isnull(ETO.employtax,0) >= 0
			AND T.taxkind = 1 
			AND T.geoappliance IS NULL
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg
		-- la Group By la faccio per la presenza di eventuali scaglioni 

		-- 8185 Rit. Add.Reg.IRPef - ASSIMILATI
		-- Associata alle prestazioni:
		-- 8147	Imp. Tesoro stipendio
		-- 8186 Imp.Ass.ac-si ded-lett.Cbis (collab.,revisori)
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8185',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear --fiscalyear = @annoredditi
			AND T.taxkind = 1 
			AND geoappliance = 'R' 
			AND ETO.stop is null
			AND isnull(ETO.employtax,0) >= 0
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND V.voce = '8185'
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 in('8186','8147')		
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

		-- 8221 Rit.Add.Com. 
		-- Associata alle prestazioni:
		-- 8147	Imp. Tesoro stipendio
		-- 8186 Imp.Ass.ac-si ded-lett.Cbis (collab.,revisori)		
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8221',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE T.taxkind = 1 
			AND payment.ypay = @ayear--
			AND isnull(ETO.employtax,0) >= 0
			AND geoappliance = 'C'
			AND V.voce = '8221'
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 in ('8186','8147')
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

		-- 8193 IRAP ac lav.ass.
		-- Associata alle prestazioni:
		-- 8147	Imp. Tesoro stipendio
		-- 8186 Imp.Ass.ac-si ded-lett.Cbis (collab.,revisori)
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8193',
				SUM(ETO.admintax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE T. taxkind = 2 
			AND isnull(ETO.admintax,0) >= 0
			AND geoappliance is null
			AND V.voce = '8193'
			AND payment.ypay = @ayear
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 in('8186','8147')
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

		-- 8218 = INPS-Imp. Gest. sep	rilevante sezione Inps
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8218',
				MAX(ETO.taxablegross),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE T. taxkind = 3	-- > imponibile previdenziale
			AND payment.ypay = @ayear--
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8186'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND ETO.stop is null
			AND V.conto ='D'
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg


		--- 8219 Rit. INPS G.S. c.d..Specificare l’aliquota per l’inclusione nella dichiarazione GLA (Emens)
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8219',
				SUM(ETO.employtax),
				--ISNULL(max(ETO.employrate),0)*100,
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE T.taxkind = 3	-- > Inps
			AND payment.ypay = @ayear--
			AND isnull(ETO.employtax,0) >= 0
			AND V.voce = '8219'-- > prende tutte Ritenute INPS c/dip. associate agli assimilati
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8186'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg


		-- 8220 Rit. INPS G.S. c.E..Specificare l’aliquota per l’inclusione nella dichiarazione GLA(Emens)

		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8220',
				SUM(ETO.admintax),
				--ISNULL(max(ETO.adminrate),0)*100,
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE T.taxkind = 3	-- > Inps
			AND payment.ypay = @ayear
			AND isnull(ETO.admintax,0) >= 0
			AND V.voce = '8220'-- > prende tutte Ritenute INPS c/amm. associate agli assimilati
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8186'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

		-- 8249 = Imponibile INAIL
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8249',
				MAX(ETO.taxablegross),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE T.taxkind = 4	-- > Serve l'imponibile INAIL. Calcolato come l'imponibile IRAP
			AND geoappliance IS NULL
			AND V.voce = '8251'
			AND payment.ypay = @ayear
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8186'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg


		--- 8250 Rit. INAIL c.d.
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8250',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE T. taxkind = 4 -- > INAIL
			AND payment.ypay = @ayear
			AND isnull(ETO.employtax,0) >= 0
			AND V.voce = '8250'-- > prende tutte Ritenute INAIL c.d. associate agli assimilati
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8186'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

		--- 8251 Rit. INAIL c.e.
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8251',
				SUM(ETO.admintax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE T. taxkind = 4 -- > INAIL
			AND payment.ypay = @ayear
			AND isnull(ETO.admintax,0) >= 0
			AND V.voce = '8251'-- > prende tutte Ritenute INAIL c.e. associate agli assimilati
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8186'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

-- 8147	Imp. Tesoro stipendio
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8147',
				MAX(ETO.taxablegross),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE V.voce = '8150' -- Rit. Tesoro c.d.
			AND payment.ypay = @ayear
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8147'		-- Imp. Tesoro stipendio
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg
-- 8150	Rit. Tesoro c.d.
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8150',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear
			AND isnull(ETO.employtax,0) >= 0
			AND V.voce = '8150'-- > prende tutte Ritenute Rit. Tesoro c.d. associate agli assimilati
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8147'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile Imp. Tesoro stipendio
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg
-- 8175 Rit. Fondo Credito
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8175',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear
			AND isnull(ETO.employtax,0) >= 0
			AND V.voce = '8175'-- > prende Rit. Fondo Credito associate agli assimilati
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8147'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile Imp. Tesoro stipendio
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

-- 8151	Rit. Tesoro c.E.
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8151',
				SUM(ETO.admintax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear
			AND isnull(ETO.admintax,0) >= 0
			AND V.voce = '8151'-- > prende tutte Ritenute Rit. Tesoro c.E. associate agli assimilati
			--AND V.servicekind='ASSIMILATO'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000='8147'		-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile Imp. Tesoro stipendio
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

End

If(@tipoCompenso='B')
Begin
---------------------------------------------------------------------------------------- BORSE di studio  ----------------------------------------------------------------------------------------------------
		-- 8268 = Imp.Ass.ac-si det-lett.C - Es.Irap (BORSE,..)
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8268',
				MAX(ETO.taxablegross),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear--fiscalyear = @annoredditi
			AND T.taxkind = 2	-- > Serve l'imponibile Assistenziale = IRAP
			AND S.voce8000 = '8268'-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND geoappliance IS NULL
			--AND V.servicekind = 'BORSE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND C.idregistrylegalstatus IS NOT NULL
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND ETO.stop is null
		GROUP BY C.idreg, C.idregistrylegalstatus, EL.idexp,S.voce8000	


		-- 8011 Rit. IRPeF ac - BORSE
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 	
				EL.idexp,
				C.idregistrylegalstatus,
				'8011',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear--fiscalyear = @annoredditi
			AND V.voce = '8011'
			--AND V.servicekind = 'BORSE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 = '8268'-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND isnull(ETO.employtax,0) >= 0
			AND taxkind = 1 
			AND geoappliance IS NULL
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg
		-- la Group By la faccio per la presenza di eventuali scaglioni 

		-- 8185 Rit. Add.Reg.IRPef - BORSE
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8185',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear--fiscalyear = @annoredditi
			AND  taxkind = 1 
			AND geoappliance = 'R' 
			AND ETO.stop is null
			AND isnull(ETO.employtax,0) >= 0
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND V.voce = '8185'
			--AND V.servicekind='BORSE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 = '8268'-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg

		-- 8221 Rit.Add.Com. 
		-- Calcolo della addizionale comunale all'IRPEF
		-- Si considera la somma delle ritenute nette fiscali comunali con codice pari a 05_ADDCOMU

		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8221',
				SUM(ETO.employtax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear
			AND T. taxkind = 1 
			AND isnull(ETO.employtax,0) >= 0
			AND geoappliance = 'C'
			AND V.voce = '8221'
			--AND V.servicekind='BORSE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 = '8268'-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg
					

		-- 8193 IRAP ac lav.ass.
		INSERT INTO #pagamenti(
				idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				idreg
				)
		SELECT 
				EL.idexp,
				C.idregistrylegalstatus,
				'8193',
				SUM(ETO.admintax),
				C.idreg
		FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @annoredditi
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN expensetaxofficial ETO
			ON ETO.idexp = EL.idexp
		JOIN tax T
			ON ETO.taxcode = T.taxcode
		JOIN voce8000lookup V
			ON V.taxcode = T.taxcode
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear
			AND T. taxkind = 2 
			AND isnull(ETO.admintax,0) >= 0
			AND geoappliance is null
			AND V.voce = '8193'
			--AND V.servicekind='BORSE'
			AND (( V.flagcsausability & @mask) <>0 )
			AND S.voce8000 = '8268'-- Prende solo le ritenute di quelle prestazioni mappate con l'imponibile assicutarivo CSA
			AND ETO.stop is null
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND C.idregistrylegalstatus IS NOT NULL
		GROUP BY EL.idexp, C.idregistrylegalstatus, V.voce,	C.idreg
End

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Corregge l'idregistrylegalstatus. Se facciamo l'importazione delle anagrafiche, e queste sono state già usate nei contratti, nelle tabelle dei contratti il campo
-- idregistrlegal status non sarà valorizzato, quindi dobbiamo cercare di leggerlo adesso.
UPDATE #pagamenti SET idregistrylegalstatus = 
									(select TOP 1 R1.idregistrylegalstatus -- ci sono anagrafiche con lo stesso ruolo ma aventi data decorrenza diversa
										from registrylegalstatus R1
										where R1.idreg = #pagamenti.idreg
											and R1.csa_compartment is not null
											and R1.csa_role is not null
											and 
											(select count(distinct R2.csa_role) FROM registrylegalstatus R2
												where R2.idreg = r1.idreg
												and R2.csa_compartment is not null
												and R2.csa_role is not null)= 1
										)
WHERE idregistrylegalstatus IS NULL

DECLARE @departmentname varchar(500)
SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')

DECLARE @iddb varchar(50)
SET @iddb = (select user)

-- In Out forniamo anche idexp perchè il file deve comunicare un record per pagamento
-- Ma l'idexp non basta, perchè è univoco nel dipetimento non nel DB, quindi vi concateniamo anche lo user per avere una chiave
-- univoca del mov. di spesa all'interno del DB consolidato
SELECT 
		P.idreg,
		@departmentname,
		@iddb+convert(varchar(10),P.idexp),
		P.idregistrylegalstatus,
		P.voce8000,
		P.importo,
		E.ymov,
		E.nmov,
		M.adate
FROM #pagamenti P
JOIN expense E	
	On P.idexp = E.idexp
JOIN expenselast EL
	ON El.idexp = E.idexp
JOIN payment M
	ON EL.kpay = M.kpay
where idregistrylegalstatus is not null --	<<
ORDER BY P.idreg, P.idexp, P.voce8000




END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


