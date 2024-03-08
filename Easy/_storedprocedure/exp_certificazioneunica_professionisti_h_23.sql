
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_professionisti_h_23]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_professionisti_h_23]
GO
 --setuser'amm'
 -- setuser 'amministrazione'
--exec exp_certificazioneunica_professionisti_h_23  PRSRCC87R11H224K 
CREATE PROCEDURE [exp_certificazioneunica_professionisti_h_23]
(
	@cf varchar(20)
 )
 -- estraggo l'elenco dei percipienti, autonomi, 
 -- che hanno eseguito prestazioni mappate con il Record H
 
 
AS BEGIN
	declare @annodichiarazione int
	set @annodichiarazione = 2023

	declare @annoredditi int
	set @annoredditi = 2022


	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #expense2022
	(
		idexp int,
		idreg int,
		title varchar(150),
		cf varchar(50),
		p_iva varchar(50),
		ycon int, 
		ncon int ,
		ymov int, 
		nmov int, 
		curramount decimal(19,2),
		codeser varchar(50),
		ivakind varchar(50),
		sortcode varchar(50),
		sorting varchar(100),
		taxref varchar(50), 
		tax varchar(100), 
		taxablenet decimal(19,2),
		employtax decimal(19,2)--,
		--spese_nonimp decimal(19,2), -- bolli NON imponibili  
		--spese_imp decimal(19,2)  -- bolli imponibili fiscalmente
	)

	CREATE TABLE #percipienti_record_H_2022
	(
		idreg int,
		title varchar(150),
		cf varchar(50),
		p_iva varchar(50),
		ycon int, 
		ncon int ,
		ymov int, 
		nmov int, 
		curramount decimal(19,2),
		codeser varchar(50),
		ivakind varchar(50),
		sortcode varchar(50),
		sorting varchar(100),
		taxref varchar(50), 
		tax varchar(100), 
		taxablenet decimal(19,2),
		employtax decimal(19,2)--,
		--spese_nonimp decimal(19,2), -- bolli NON imponibili  
		--spese_imp decimal(19,2)  -- bolli imponibili fiscalmente
	)

	----------------------------------------------------------
    --- Estrazione dati relativi ai percipienti autonomi ----
    ----------------------------------------------------------
    
	INSERT INTO #expense2022 --#percipienti_record_H_2022
		(
			idexp,
			idreg,
			title,
			cf,
			p_iva,
			codeser,
			ivakind,
			sortcode,
			sorting,
			taxref, 
			tax, 
			taxablenet,
			employtax, 
			ycon, 
			ncon,
			ymov, 
			nmov, 
			curramount--,
			--spese_nonimp,
			--spese_imp
		)
	SELECT DISTINCT
			expense.idexp,
			expense.idreg,
			registry.title,
			registry.cf,
			registry.p_iva,
			service.codeser,
			IK.description,
			S.sortcode,
			S.description,
			PT.taxref, 
			PT.description, 
			PT.taxablenet,
			PT.employtax, 
			P.ycon,
			P.ncon,
			expense.ymov,
			expense.nmov,
			expenselastview.curramount --,
		--	ps.amount,
		--	psf.amount
	FROM expense
	JOIN expenselastview on expense.idexp = expenselastview.idexp
	JOIN payment 
		on payment.kpay = expenselastview.kpay
	JOIN paymenttransmission
		on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
	JOIN service on service.idser=expenselastview.idser
	JOIN registry ON expense.idreg = registry.idreg
	JOIN expenselink EL on EL.idchild=expenselastview.idexp	
	JOIN expenseprofservice EP ON EL.idparent=EP.idexp	
	JOIN profservice P ON P.ycon=EP.ycon and P.ncon=EP.ncon
	--left outer join profservicerefund ps on P.ycon = ps.ycon and P.ncon = ps.ncon
	--left outer join profservicerefund psf on P.ycon = ps.ycon and P.ncon = ps.ncon
	--left outer join profrefund pr on pr.idlinkedrefund = ps.idlinkedrefund and pr.flagfiscaldeduction = 'S'	-- considero spese non imponibili
	--left outer join profrefund prf on prf.idlinkedrefund = psf.idlinkedrefund and prf.flagfiscaldeduction = 'N'	-- considero spese   imponibili fiscalmente da sommare all'imponibile fiscale netto
	left outer join   profservicetaxview PT 
	ON PT.ycon=P.ycon and PT.ncon=P.ncon and PT.taxkind = 1									
	JOIN ivakind IK ON P.idivakind = IK.idivakind
	JOIN ivakindsorting IKS ON IKS.idivakind = IK.idivakind
	JOIN sorting S ON S.idsor = IKS.idsor AND S.sortcode in ('013','014')
	JOIN sortingkind SK ON SK.idsorkind = S.idsorkind AND SK.codesorkind = '016_CLASSIVAKIND'
	WHERE 	registry.idregistryclass <> '10' and registry.idregistryclass <> '24'
		AND year(paymenttransmission.transmissiondate)=@annoredditi
		AND service.rec770kind = 'H'
		AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselastview.idexp)
		+ ISNULL(
			(SELECT SUM(amount) FROM expensevar
			WHERE expensevar.idexp = expense.idexp
			-- AND expensevar.yvar <= @annoredditi  superfluo poiché expense di ultima fase
			AND ISNULL(autokind,0) <> 4)
		,0)) > 0
		AND (select count(*) from expensetaxofficial 
		      where expensetaxofficial.idexp=expense.idexp
		      AND   expensetaxofficial.stop IS NULL) > 0
		AND service.module = 'PROFESSIONALE'
	--------------------------------------------------------------------------------
	----- da rimuovere non appena sarà corretto l'errore dal software sogei --------
	--------------------------------------------------------------------------------
		AND (registry.cf IS NOT NULL) 
		AND (registry.cf = @cf OR @cf IS NULL)
		AND (ISNULL(P.flagexcludefromcertificate,'N') = 'N')

		UNION ALL 

			SELECT DISTINCT
			expense.idexp,
			expense.idreg,
			registry.title,
			registry.cf,
			registry.p_iva,
			service.codeser,
			null,
			null,
			null,
			PT.taxref, 
			PT.description, 
			PT.taxablenet,
			PT.employtax, 
			P.ycon,
			P.ncon,
			expense.ymov,
			expense.nmov,
			expenselastview.curramount--,
			--ps.amount,
			--psf.amount
	FROM expense
	JOIN expenselastview on expense.idexp = expenselastview.idexp
	JOIN payment 
		on payment.kpay = expenselastview.kpay
	JOIN paymenttransmission
		on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
	JOIN service on service.idser=expenselastview.idser
	JOIN registry ON expense.idreg = registry.idreg
	JOIN expenselink EL on EL.idchild=expenselastview.idexp	
	JOIN expenseprofservice EP ON EL.idparent=EP.idexp	
	JOIN profservice P ON P.ycon=EP.ycon and P.ncon=EP.ncon	
	--left outer join profservicerefund ps on P.ycon = ps.ycon and P.ncon = ps.ncon
	--left outer join profservicerefund psf on P.ycon = ps.ycon and P.ncon = ps.ncon
	--left outer join profrefund pr on pr.idlinkedrefund = ps.idlinkedrefund and pr.flagfiscaldeduction = 'S'	-- considero spese non imponibili
	--left outer join profrefund prf on prf.idlinkedrefund = psf.idlinkedrefund and prf.flagfiscaldeduction = 'N'	-- considero spese   imponibili fiscalmente da sommare all'imponibile fiscale netto
	LEFT OUTER JOIN   profservicetaxview PT 
	ON PT.ycon=P.ycon and PT.ncon=P.ncon and PT.taxkind = 1			
	WHERE 	registry.idregistryclass <> '10' and registry.idregistryclass <> '24'
		AND year(paymenttransmission.transmissiondate)=@annoredditi
		AND service.rec770kind = 'H'
		AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselastview.idexp)
		+ ISNULL(
			(SELECT SUM(amount) FROM expensevar
			WHERE expensevar.idexp = expense.idexp
			-- AND expensevar.yvar <= @annoredditi  superfluo poiché expense di ultima fase
			AND ISNULL(autokind,0) <> 4)
		,0)) > 0
		AND (select count(*) from expensetaxofficial 
		      where expensetaxofficial.idexp=expense.idexp
		      AND   expensetaxofficial.stop IS NULL) > 0
		AND service.module = 'PROFESSIONALE'
		--- non hanno aliquote mappate
		AND (SELECT count(*) FROM ivakind IK
				JOIN ivakindsorting IKS ON IKS.idivakind = IK.idivakind
				JOIN sorting S ON S.idsor = IKS.idsor AND S.sortcode in ('013','014')
				JOIN sortingkind SK ON SK.idsorkind = S.idsorkind 
				AND SK.codesorkind = '016_CLASSIVAKIND'
		     WHERE  P.idivakind = IK.idivakind) = 0
	--------------------------------------------------------------------------------
	----- da rimuovere non appena sarà corretto l'errore dal software sogei --------
	--------------------------------------------------------------------------------
		AND (registry.cf IS NOT NULL) 
		AND (registry.cf = @cf OR @cf IS NULL)
		AND (ISNULL(P.flagexcludefromcertificate,'N') = 'N')
		ORDER BY registry.title

--rimuovo i pagamenti dei contratti occasionali da non trasmettere
--cioè con flagexcludefromcertificate = S
delete from #expense2022 where idexp in( 
SELECT #expense2022.idexp FROM #expense2022
join expenselink el on el.idchild = #expense2022.idexp 
join expensecasualcontract ec on el.idparent = ec.idexp
join casualcontract c on c.ycon = ec.ycon and c.ncon = ec.ncon
where (ISNULL(c.flagexcludefromcertificate,'N') = 'S')) 

--rimuovo i pagamenti dei contratti professionali da non trasmettere
--cioè con flagexcludefromcertificate = S
delete from #expense2022 where idexp in( 
SELECT #expense2022.idexp FROM #expense2022
join expenselink el on el.idchild = #expense2022.idexp 
join expenseprofservice ep on el.idparent = ep.idexp
join profservice p on p.ycon = ep.ycon and p.ncon = ep.ncon
where (ISNULL(p.flagexcludefromcertificate,'N') = 'S'))

--rimuovo i pagamenti dei contratti dipendenti da non trasmettere
--cioè con flagexcludefromcertificate = S
delete from #expense2022 where idexp in( 
SELECT #expense2022.idexp FROM #expense2022
join expenselink el on el.idchild = #expense2022.idexp 
join expensewageaddition ew on el.idparent = ew.idexp
join wageaddition w on w.ycon = ew.ycon and w.ncon = ew.ncon
where (ISNULL(w.flagexcludefromcertificate,'N') = 'S'))


insert into #percipienti_record_H_2022
select #expense2022.idreg,
		#expense2022.title,
		#expense2022.cf,
		#expense2022.p_iva,
		#expense2022.ycon,  
		#expense2022.ncon,
		#expense2022.ymov, 
		#expense2022.nmov, 
		#expense2022.curramount,
		#expense2022.codeser,
		#expense2022.ivakind,
		#expense2022.sortcode,
		#expense2022.sorting,
		#expense2022.taxref, 
		#expense2022.tax, 
		#expense2022.taxablenet,
		#expense2022.employtax--,
		--#expense2022.spese_nonimp,
		--#expense2022.spese_imp
from #expense2022

	SELECT 	
		idreg,
		title as 'Percipiente',
		cf,
		p_iva,
		codeser as 'Cod prestazione',
		ivakind as 'Tipo iva',
		sortcode as 'Cod. Class',
		sorting as 'Tipo Class',
		taxref as 'Cod. Ritenuta', 
		tax as 'Ritenuta', 
		taxablenet  /*+ isnull(spese_imp, 0)*/ as 'Imponibile netto',
		employtax as 'Importo c/percipiente', 
		ycon as 'Eserc. contratto',  
		ncon as 'Num.contratto',
		ymov as 'Eserc. pagamento', 
		nmov as 'Num. pagamento', 
		curramount as 'Importo corrente'--,
	--	spese_nonimp as 'Spese non Imponibili',
		--spese_nonimp as 'Spese Imponibili'
	FROM	#percipienti_record_H_2022
 

END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 exec exp_certificazioneunica_professionisti_h_23  null
