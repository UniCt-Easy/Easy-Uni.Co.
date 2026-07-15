/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_verifica_saldo_cc_story]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_verifica_saldo_cc_story]
GO
 
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
setuser 'amministrazione'

rpt_verifica_saldo_cc_story 2025, {d '2025-06-04'}, 7, 'N', 'N'
rpt_verifica_saldo_cc_story 2016, null,null, null 8218190.82
*/
 
CREATE 	PROCEDURE rpt_verifica_saldo_cc_story
	@ayear 	int,
	@date 	datetime,
	@idtreasurer INT,
	@historicizebillop char(1),
	@documentiesitati char(1)
AS
	BEGIN
		DECLARE @date_3112_previous_year datetime
		
		DECLARE @yprev int
		SET 	@yprev = @ayear - 1
			 
		SET 	@date_3112_previous_year =CONVERT(datetime, '12/31/' + CONVERT(char(4), @yprev),101) 
		DECLARE @date_ending_to_consider datetime -- ai fini dell'esitazione

		IF (@documentiesitati = 'S') SET  @date_ending_to_consider = CONVERT(datetime, '12/31/' + CONVERT(char(4), @ayear),101) ELSE SET  @date_ending_to_consider =@date_3112_previous_year
	
 

	-- Leggere la Documentazione del task n.4077
	DECLARE @ff_jan01 decimal(19,2)
	if(@idtreasurer is null)
	Begin
		SELECT 	@ff_jan01 = 
			ISNULL(startfloatfund, 0.0) 
		FROM 	surplus
		WHERE 	ayear = @ayear 
	End
	Else
	Begin
		SELECT 	@ff_jan01 = 
			ISNULL(amount,0)
		FROM treasurerstart
		WHERE 	ayear = @ayear and idtreasurer = @idtreasurer
	End	

		DECLARE @display_previous_year  char(1)
		IF EXISTS(SELECT * FROM accountingyear WHERE ayear = @ayear - 1)
			BEGIN
				SELECT 	@display_previous_year = 'S'
				SET 	@date_3112_previous_year =CONVERT(datetime, '12/31/' + CONVERT(char(4), @yprev),101) 
				
				DECLARE @previous_proc_communicated 	decimal(19,2)
				-- Reversali Trasmesse nell'anno precedente
				SELECT 	@previous_proc_communicated =
						SUM(et.curramount) from
						incometotal et 
						JOIN income e on et.idinc = e.idinc and et.ayear = (@ayear - 1)
						JOIN incomelast el on el.idinc = e.idinc 
						JOIN proceeds p on el.kpro = p.kpro
						JOIN proceedstransmission pt
							ON pt.kproceedstransmission = p.kproceedstransmission
						WHERE p.ypro = (@ayear  - 1)
							AND pt.transmissiondate <= @date_3112_previous_year
							AND PT.yproceedstransmission = (@ayear - 1)
							AND ( p.idtreasurer = @idtreasurer or @idtreasurer is null)		

				DECLARE @previous_pay_communicated 	decimal(19,2)
				-- Mandati Trasmessi nell'anno precedente
				SELECT 	@previous_pay_communicated =
						SUM(et.curramount) from
						expensetotal et 
						JOIN expense e on et.idexp=e.idexp  and et.ayear = (@ayear - 1)
						JOIN expenselast el on el.idexp = e.idexp 
						JOIN payment p on el.kpay=p.kpay
						JOIN paymenttransmission pt
							ON pt.kpaymenttransmission = p.kpaymenttransmission
						WHERE p.ypay = (@ayear - 1) 
							AND pt.transmissiondate <= @date_3112_previous_year
							AND PT.ypaymenttransmission = (@ayear - 1)
							AND (p.idtreasurer = @idtreasurer	 or @idtreasurer is null)			

				DECLARE @previous_proc_not_performed decimal(19,2)
				-- Reversali di anno precedente non  esitate entro il 31/12/anno prec 
				SELECT 	@previous_proc_not_performed = 
						SUM(et.curramount)
						FROM incometotal et 
						JOIN income e
							ON et.idinc=e.idinc and et.ayear=@ayear-1
						JOIN incomelast el on el.idinc = e.idinc 
						JOIN proceeds p on el.kpro = p.kpro
						JOIN proceedstransmission pt
							ON pt.kproceedstransmission = p.kproceedstransmission
						WHERE pt.transmissiondate <= @date_3112_previous_year
							AND p.ypro = @ayear-1
							AND pt.yproceedstransmission=@ayear-1
							AND (p.idtreasurer = @idtreasurer  or @idtreasurer is null)		
							AND
							ISNULL((SELECT SUM(amount)from banktransaction PD
							where PD.kpro=P.kpro and 
							PD.transactiondate <= @date_ending_to_consider),0) =0
		
				
				DECLARE @previous_pay_not_performed decimal(19,2)
				-- Mandati di anno precedente non  esitati entro il 31/12/anno prec 
				SELECT 	@previous_pay_not_performed = 
						SUM(et.curramount)
						FROM expensetotal et 
						JOIN expense e
							ON et.idexp=e.idexp and et.ayear=@ayear-1
						JOIN expenselast el on el.idexp = e.idexp 
						JOIN payment p on el.kpay=p.kpay
						JOIN paymenttransmission pt
							ON pt.kpaymenttransmission = p.kpaymenttransmission
						WHERE pt.transmissiondate <= @date_3112_previous_year
							AND p.ypay = @ayear-1
							AND pt.ypaymenttransmission=@ayear-1
							AND (p.idtreasurer = @idtreasurer or @idtreasurer is null)				
							AND
							ISNULL((SELECT SUM(amount)from banktransaction PD
							where PD.kpay=P.kpay and
							PD.transactiondate <= @date_ending_to_consider),0) =0
							
				DECLARE @previous_proc_partially_performed 	decimal(19,2)
				-- Reversali di anni precedenti trasmesse e parzialmente esitate (importo rimasto da esitare)
				SET 	@previous_proc_partially_performed = 
				ISNULL(@previous_proc_communicated,0) - ISNULL(@previous_proc_not_performed,0) -
				ISNULL(
					(SELECT
					SUM(bt.amount)
					FROM banktransaction bt
					JOIN proceeds p
						ON p.kpro = bt.kpro
					JOIN proceedstransmission pt
						ON pt.kproceedstransmission = p.kproceedstransmission
					WHERE bt.transactiondate <= @date_ending_to_consider
						AND pt.transmissiondate <= @date_3112_previous_year
						AND (p.idtreasurer = @idtreasurer	 or @idtreasurer is null)			
						AND p.ypro = (@ayear - 1))
					,0)
				
				DECLARE @previous_pay_partially_performed 	decimal(19,2)
				-- Mandati di anni precedenti trasmessi e parzialmente esitati (importo rimasto da esitare)
				SET 	@previous_pay_partially_performed =
				ISNULL(@previous_pay_communicated,0) - ISNULL(@previous_pay_not_performed,0) -
				ISNULL(
					(SELECT
					SUM(bt.amount)
					FROM banktransaction bt
					JOIN payment p
						ON p.kpay = bt.kpay
					JOIN paymenttransmission pt
						ON pt.kpaymenttransmission = p.kpaymenttransmission
					WHERE bt.transactiondate <= @date_ending_to_consider
						AND pt.transmissiondate <= @date_3112_previous_year
						AND (p.idtreasurer = @idtreasurer or @idtreasurer is null)				
						AND p.ypay = (@ayear - 1))
				,0)
				
				DECLARE @treasurer_start 	decimal(19,2)
				SELECT 	@treasurer_start =
					ISNULL(@ff_jan01, 0.0) -
					ISNULL(@previous_proc_not_performed, 0.0) -
					ISNULL(@previous_proc_partially_performed, 0.0) +
					ISNULL(@previous_pay_not_performed, 0.0) +
					ISNULL(@previous_pay_partially_performed, 0.0)
				
				DECLARE @previous_proc_performed decimal(19,2)
				--esiti di reversali di anno precedente
				SELECT 	@previous_proc_performed =
					ISNULL(SUM(pd.amount),0) 
					FROM banktransaction pd 
					JOIN proceeds p
						ON p.kpro=pd.kpro 
					JOIN proceedstransmission pt
						ON pt.kproceedstransmission = p.kproceedstransmission
					WHERE 	p.ypro=@ayear-1
						AND PD.transactiondate > @date_ending_to_consider
						AND ((PD.transactiondate <= @date AND pt.transmissiondate <= @date)  or @date is null)
						AND (p.idtreasurer = @idtreasurer	 or @idtreasurer is null)			

				DECLARE @previous_pay_performed decimal(19,2)
				--esiti di mandati di anno precedente
				SELECT 	@previous_pay_performed = 
					ISNULL(SUM(pd.amount),0)
					FROM banktransaction pd 
					JOIN payment p
						ON p.kpay=pd.kpay
					JOIN paymenttransmission pt
						ON pt.kpaymenttransmission = p.kpaymenttransmission
					WHERE 	p.ypay=@ayear-1
						AND PD.transactiondate > @date_ending_to_consider
						AND ((PD.transactiondate <= @date AND pt.transmissiondate <= @date)  or @date is null)
						AND (p.idtreasurer = @idtreasurer	or @idtreasurer is null)			
			END
		ELSE
			BEGIN
				SELECT @display_previous_year = 'N'
				SET @treasurer_start = ISNULL(
					(SELECT	amount
					FROM treasurerstart	
					WHERE ayear = @ayear
					AND (idtreasurer = @idtreasurer  or @idtreasurer is null)	),0)
			END
		DECLARE @proc_communicated decimal(19,2)
		-- Reversali Trasmesse
		SELECT 	@proc_communicated =
			SUM(ey.amount) from
			incomeyear ey 
			JOIN income e on ey.idinc = e.idinc and ey.ayear = @ayear
			JOIN incomelast el on el.idinc = e.idinc 
			JOIN proceeds p on el.kpro = p.kpro
			JOIN proceedstransmission pt
				ON pt.kproceedstransmission = p.kproceedstransmission
			WHERE 	p.ypro = @ayear 
				AND (pt.transmissiondate <= @date or @date is null)
				AND PT.yproceedstransmission=@ayear
				AND (p.idtreasurer = @idtreasurer  or @idtreasurer is null)		
		
		DECLARE @proc_communicated_VAR decimal(19,2)
		-- Reversali Trasmesse (variazioni)
		SELECT 	@proc_communicated_VAR = 
			SUM(iv.amount) from
			incomevar iv 
			JOIN income e on iv.idinc = e.idinc and iv.yvar = @ayear
			JOIN incomelast el on el.idinc = e.idinc 
			JOIN proceeds p on el.kpro = p.kpro
			JOIN proceedstransmission pt
				ON pt.kproceedstransmission = p.kproceedstransmission
			WHERE 	p.ypro = @ayear 
				and iv.adate <= @date
				AND (pt.transmissiondate <= @date or @date is null)
				AND PT.yproceedstransmission=@ayear
				AND (p.idtreasurer = @idtreasurer  or @idtreasurer is null)		

		SET @proc_communicated = @proc_communicated + isnull(@proc_communicated_VAR,0)

		DECLARE @pay_communicated decimal(19,2)
		-- Mandati Trasmessi
		SELECT 	@pay_communicated =
			SUM(ey.amount) from
			expenseyear ey 
			JOIN expense e on ey.idexp = e.idexp  and ey.ayear = @ayear
			JOIN expenselast el on el.idexp = e.idexp 
			JOIN payment p on el.kpay=p.kpay	
			JOIN paymenttransmission pt
				ON pt.kpaymenttransmission = p.kpaymenttransmission
			WHERE 	p.ypay = @ayear 
				AND (pt.transmissiondate <= @date or @date is null)
				AND PT.ypaymenttransmission=@ayear
				AND (p.idtreasurer = @idtreasurer	  or @idtreasurer is null)	

		DECLARE @pay_communicated_VAR decimal(19,2)
		-- Mandati Trasmessi (variaizoni)
		SELECT 	@pay_communicated_VAR =
			SUM(ev.amount) from
			expensevar ev 
			JOIN expense e on ev.idexp = e.idexp and ev.yvar = @ayear
			JOIN expenselast el on el.idexp = e.idexp 
			JOIN payment p on el.kpay=p.kpay	
			JOIN paymenttransmission pt
				ON pt.kpaymenttransmission = p.kpaymenttransmission
			WHERE 	p.ypay = @ayear 
				and ev.adate <= @date
				AND (pt.transmissiondate <= @date or @date is null)
				AND PT.ypaymenttransmission=@ayear
				AND (p.idtreasurer = @idtreasurer	  or @idtreasurer is null)	
				
		SET @pay_communicated = @pay_communicated + isnull(@pay_communicated_VAR,0)


		DECLARE @proc_not_performed decimal(19,2)
		-- Reversali di anno corrente NON ESITATE alla data  
		SET 	@proc_not_performed =
		(select isnull(sum(totale), 0)
		from
			(SELECT
				SUM(iy.amount) 
				+ isnull((select sum(iv2.amount) from incomevar iv2 
						JOIN incomelast il2
							ON il2.idinc = iv2.idinc
						join income i2 on il2.idinc = i2.idinc
						where iv2.idinc = il2.idinc 
								and il2.kpro = il.kpro
								and i2.nmov = i.nmov
								and iv2.yvar = @ayear and iv2.adate <=@date),0)
				- 
				ISNULL(
					(SELECT SUM(amount)
					FROM banktransaction b
					WHERE b.kpro = il.kpro
						AND b.transactiondate <= @date)
				,0) as totale
			FROM incomeyear iy 
			JOIN income i 
				ON iy.idinc=i.idinc
			JOIN incomelast il 
				ON il.idinc = i.idinc
			JOIN proceeds p 
				ON p.kpro = il.kpro
			JOIN proceedstransmission pt
				ON pt.kproceedstransmission = p.kproceedstransmission
			WHERE p.ypro = @ayear
			AND (p.idtreasurer = @idtreasurer OR @idtreasurer IS NULL)
				AND pt.transmissiondate <= @date
				AND ISNULL((SELECT SUM(amount)from banktransaction PD where PD.kpro=P.kpro and 
					( (year(PD.transactiondate) = @ayear AND (PD.transactiondate <= @date)) 
					 OR  (year(PD.transactiondate) = (@ayear + 1) AND (@documentiesitati='S'))
					 OR  (@date is null)) ),0) = 0
			group by P.ypro, P.npro, p.adate, il.kpro, i.nmov
			HAVING ISNULL(SUM(iy.amount),0)
					+ isnull((select sum(iv2.amount) from incomevar iv2 
							JOIN incomelast il2
								ON il2.idinc = iv2.idinc
							where iv2.idinc = il2.idinc 
									and il2.kpro = il.kpro
									and iv2.yvar = @ayear and iv2.adate <=@date),0)
			>0 
			) as subquery
		)
 

		DECLARE @pay_not_performed decimal(19,2)
		-- Mandati di anno corrente  NON ESITATI alla data  
		SET 	@pay_not_performed = 
		(select isnull(sum(totale), 0)
		from
			(SELECT
				(SUM(EY.amount) 
				+ isnull((select sum(iv2.amount) from expensevar iv2 
								JOIN expenselast el2
									ON el2.idexp = iv2.idexp
								join expense e2 ON EL2.idexp = E2.idexp
								where iv2.idexp = el2.idexp 
										and el2.kpay = el.kpay
										and e2.nmov = E.nmov
										and iv2.yvar = @ayear and iv2.adate <=@date),0)
				-
				ISNULL(
					(SELECT SUM(amount)
					FROM banktransaction B
					WHERE B.kpay = EL.kpay
					AND B.transactiondate <= @date)
				,0)) as totale
			FROM expenseyear Ey 
			JOIN expense E 
				ON Ey.idexp = E.idexp  	AND Ey.ayear = @ayear
			JOIN expenselast EL 
				ON EL.idexp = E.idexp  
			JOIN payment P 
				ON P.kpay = EL.kpay
			JOIN paymenttransmission pt
				ON PT.kpaymenttransmission = P.kpaymenttransmission
			WHERE P.ypay = @ayear
				AND (p.idtreasurer = @idtreasurer OR @idtreasurer IS NULL)
				AND PT.transmissiondate <= @date
				AND ISNULL((SELECT SUM(amount)from banktransaction PD where PD.kpay=P.kpay and 
					((year(PD.transactiondate) = @ayear AND (PD.transactiondate <= @date)) 
					OR  (year(PD.transactiondate) = (@ayear + 1) AND (@documentiesitati='S'))
					OR  (@date is null))),0) = 0
			GROUP BY P.ypay,P.npay,P.adate,EL.kpay, E.nmov
			having 	(SUM(EY.amount) 
				+ isnull((select sum(iv2.amount) from expensevar iv2 
								JOIN expenselast el2
									ON el2.idexp = iv2.idexp
								where iv2.idexp = el2.idexp 
										and el2.kpay = el.kpay
										and iv2.yvar = @ayear and iv2.adate <=@date),0)
										)>0
			) as subquery
		)
		DECLARE @proc_partially_performed decimal(19,2)
		SET 	@proc_partially_performed = 
		(select isnull(sum(totale), 0)
		from
			(SELECT 
				(SUM(iy.amount) 
				+ isnull((select sum(iv2.amount) from incomevar iv2 
							JOIN incomelast il2
								ON il2.idinc = iv2.idinc
							where iv2.idinc = il2.idinc 
									and il2.kpro = il.kpro
									and iv2.yvar = @ayear and iv2.adate <=@date),0)
				-
				ISNULL(
					(SELECT SUM(pd.amount)
					FROM banktransaction pd
					WHERE pd.kpro = il.kpro
					AND pd.transactiondate <= @date)
				,0)) as totale
			FROM incomeyear iy 
			JOIN income i
				ON iy.idinc = i.idinc
			JOIN incomelast il
				ON il.idinc = i.idinc
			JOIN proceeds p
				ON p.kpro = il.kpro
			JOIN proceedstransmission pt
				ON pt.kproceedstransmission = p.kproceedstransmission
			WHERE pt.transmissiondate <= @date
				AND p.ypro = @ayear
				AND (p.idtreasurer = @idtreasurer OR @idtreasurer IS NULL)
				AND exists (SELECT * from banktransaction bt where bt.kpro=P.kpro and 
						((year(bt.transactiondate) = @ayear AND (bt.transactiondate <= @date))
					OR (year(bt.transactiondate) = (@ayear + 1) AND (@documentiesitati='S'))
					OR (bt.transactiondate is null or @date is null)
				   ))
			GROUP BY P.ypro,P.npro,p.adate,il.kpro 
			HAVING ISNULL(SUM(iy.amount),0) 
				+ isnull((select sum(iv2.amount) from incomevar iv2 
						JOIN incomelast il2
							ON il2.idinc = iv2.idinc
						where iv2.idinc = il2.idinc 
								and il2.kpro = il.kpro
								and iv2.yvar = @ayear and iv2.adate <=@date),0)
				> 0
				AND 
				ISNULL(SUM(iy.amount),0) 
				+ isnull((select sum(iv2.amount) from incomevar iv2 
						JOIN incomelast il2
							ON il2.idinc = iv2.idinc
						where iv2.idinc = il2.idinc 
								and il2.kpro = il.kpro
								and iv2.yvar = @ayear and iv2.adate <=@date),0)
				- 	ISNULL(
				(SELECT SUM(pd.amount)
				FROM banktransaction pd
				WHERE pd.kpro = il.kpro
				AND pd.transactiondate <= @date)
			,0) > 0
			AND ISNULL(
				(SELECT SUM(pd.amount)
				FROM banktransaction pd
				WHERE pd.kpro = il.kpro
				AND pd.transactiondate <= @date)
			,0) > 0
			) as subquery
		)
		
		DECLARE @pay_partially_performed decimal(19,2)
		SET 	@pay_partially_performed =
		(select isnull(sum(totale), 0)
		from
			(SELECT
				(SUM(Ey.amount) 
				+ isnull((select sum(iv2.amount) from expensevar iv2 
								JOIN expenselast el2
									ON el2.idexp = iv2.idexp
								where iv2.idexp = el2.idexp 
										and el2.kpay = el.kpay
										and iv2.yvar = @ayear and iv2.adate <=@date),0)
				-
				ISNULL(
					(SELECT SUM(pd.amount)
					FROM banktransaction pd
					WHERE pd.kpay = el.kpay
					AND pd.transactiondate <= @date)
				,0)) as totale
			FROM expenseyear ey 
				JOIN expense e
					ON ey.idexp=e.idexp
				JOIN expenselast el
					ON el.idexp=e.idexp
				JOIN payment p
					ON  p.kpay = el.kpay
				JOIN paymenttransmission pt
					ON pt.kpaymenttransmission = p.kpaymenttransmission
				WHERE pt.transmissiondate <= @date
					and ey.ayear = @ayear
					AND p.ypay = @ayear
					AND (p.idtreasurer = @idtreasurer OR @idtreasurer IS NULL)
					AND exists (SELECT * from banktransaction bt where bt.kpay=P.kpay and 
						((year(bt.transactiondate) = @ayear AND (bt.transactiondate <= @date))
						OR (year(bt.transactiondate) = (@ayear + 1) AND (@documentiesitati='S'))
						OR (bt.transactiondate is null or @date is null)
					    ))
				GROUP BY P.ypay,P.npay,P.adate,el.kpay 
				HAVING ISNULL(SUM(EY.amount),0)
					+ isnull((select sum(iv2.amount) from expensevar iv2 
								JOIN expenselast el2
									ON el2.idexp = iv2.idexp
								where iv2.idexp = el2.idexp 
										and el2.kpay = el.kpay
										and iv2.yvar = @ayear and iv2.adate <=@date),0)
					>0
					AND 
					ISNULL(
					SUM(EY.amount),0) 
					+ isnull((select sum(iv2.amount) from expensevar iv2 
								JOIN expenselast el2
									ON el2.idexp = iv2.idexp
								where iv2.idexp = el2.idexp 
										and el2.kpay = el.kpay
										and iv2.yvar = @ayear and iv2.adate <=@date),0)
				- 	ISNULL(
					(SELECT SUM(pd.amount)
					FROM banktransaction pd
					WHERE pd.kpay = el.kpay
					AND pd.transactiondate <= @date)
				,0) > 0
				AND
				ISNULL(
					(SELECT SUM(pd.amount)
					FROM banktransaction pd
					WHERE pd.kpay = el.kpay
					AND pd.transactiondate <= @date)
				,0) > 0
			) as subquery
		)
		
		DECLARE @active_pendings decimal(19,2)
		DECLARE @passive_pendings decimal(19,2)


-- IMPORTO DA REGOLARIZZARE:
-- se active = N, allora è zero, perchè nella vecchia gestione Active = Da regolarizzare, quindi se N, la bolletta era stata tutta regolarizzata.
-- se active = S, lo calcoliamo come : total - reduction  , leggendo da billview.Ove 
-- total è l'importo della bolletta, reduction sono gli storni, e covered è l'importo regolarizzato.
-- Per chi usa il nuovo form "Importazione esiti e sospesi", si possono storicizzare le operazioni di apertura e storni di bolletta, leggendole da bankimportbill

		create table #billtemp
		(
			nbill int,
			amount decimal(19,2)
		)

		DECLARE @partite_pendenti_attive decimal(19,2)
		IF (ISNULL(@historicizebillop,'N') = 'N')
		BEGIN
			insert into #billtemp
			(
				nbill, 
				amount
			)
			SELECT   nbill,  isnull(total,0) - isnull(reduction,0)
			FROM billview 
			WHERE ybill = @ayear 
				AND billkind='C' 
				AND active = 'S'
				AND 
				(
					 (year(billview.adate) = @ayear AND (billview.adate <= @date)) 
				 OR  (year(billview.adate) = (@ayear + 1) AND (@documentiesitati='S'))
				 OR  (@date is null)
				)
				AND (idtreasurer = @idtreasurer  or @idtreasurer is null)

			select @partite_pendenti_attive = sum(amount)
			from #billtemp
		END 
		ELSE
		BEGIN
			insert into #billtemp
			(
				nbill, 
				amount
			)
			SELECT  bill.nbill, amount
			FROM    bankimportbill
			join bill on bill.ybill=bankimportbill.ybill and 
				 bill.nbill=bankimportbill.nbill and 
				 bill.billkind=bankimportbill.billkind
			where ((year(bankimportbill.adate) = @ayear AND (bankimportbill.adate <= @date))
					OR (year(bankimportbill.adate) = (@ayear + 1) AND (@documentiesitati='S'))
					OR (bankimportbill.adate is null or @date is null)
				   )
			and bankimportbill.ybill = @ayear
			and bankimportbill.billkind = 'C'
			and bill.active='S'
			AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)

			select @partite_pendenti_attive = sum(amount)
			from #billtemp
		END

		DECLARE @esitato_partite_pendenti_attive decimal(19,2)
		SELECT @esitato_partite_pendenti_attive = sum(amount)
		FROM billtransaction
		join bill on bill.ybill=billtransaction.ybilltran and bill.nbill=billtransaction.nbill and bill.billkind=billtransaction.kind
		where ((year(billtransaction.adate) = @ayear AND (billtransaction.adate <= @date))
				OR    (year(billtransaction.adate) = (@ayear + 1) AND (@documentiesitati='S') and month(@date) = 12 and day(@date) = 31)
				OR    (billtransaction.adate is null or @date is null)
				)
		and billtransaction.ybilltran = @ayear
		and billtransaction.kind = 'C'
		and bill.active='S'
		AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
		AND bill.nbill in (select nbill from #billtemp)
		
		SET @partite_pendenti_attive = isnull(@partite_pendenti_attive,0) - isnull(@esitato_partite_pendenti_attive,0)

		delete from #billtemp

		DECLARE @partite_pendenti_passive decimal(19,2)
		IF (ISNULL(@historicizebillop,'N') = 'N')
		BEGIN
			insert into #billtemp
			(
				nbill, 
				amount
			)
			SELECT  nbill, isnull(total,0) - isnull(reduction,0)
			FROM billview 
			WHERE ybill = @ayear 
				AND billkind='D' 
				AND active = 'S'
				AND
				(
						 (year(billview.adate) = @ayear AND (billview.adate <= @date)) 
					 OR  (year(billview.adate) = (@ayear+ 1) AND (@documentiesitati='S'))
					 OR  (@date is null)
				)
				AND (idtreasurer = @idtreasurer  or @idtreasurer is null)

			SELECT  @partite_pendenti_passive = sum(amount)
			from #billtemp
		END
		ELSE
		BEGIN
			insert into #billtemp
			(
				nbill, 
				amount
			)
			SELECT  bill.nbill, amount
			FROM    bankimportbill
			join bill on bill.ybill=bankimportbill.ybill and 
				 bill.nbill=bankimportbill.nbill and 
				 bill.billkind=bankimportbill.billkind
			where ((year(bankimportbill.adate) = @ayear AND bankimportbill.adate <= @date)
					OR (year(bankimportbill.adate) = (@ayear + 1) AND (@documentiesitati='S'))
					OR (bankimportbill.adate is null or @date is null)
				   )
			and bankimportbill.ybill = @ayear
			and bankimportbill.billkind = 'D'
			and bill.active='S'
			AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)

			SELECT  @partite_pendenti_passive = sum(amount)
			from #billtemp
		END

		DECLARE @esitato_partite_pendenti_passive decimal(19,2)
		SELECT @esitato_partite_pendenti_passive = sum(amount)
		FROM billtransaction
		join bill on bill.ybill=billtransaction.ybilltran and bill.nbill=billtransaction.nbill and bill.billkind=billtransaction.kind
		where ((year(billtransaction.adate) = @ayear AND billtransaction.adate <= @date)
				OR    (year(billtransaction.adate) = (@ayear + 1) AND (@documentiesitati='S') and month(@date) = 12 and day(@date) = 31)
				OR    (billtransaction.adate is null or @date is null)
				)
		and billtransaction.ybilltran = @ayear
		and billtransaction.kind = 'D'
		AND bill.active = 'S'
		AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
		AND bill.nbill in (select nbill from #billtemp)

		SET @partite_pendenti_passive = isnull(@partite_pendenti_passive,0) - isnull(@esitato_partite_pendenti_passive,0)

		drop table #billtemp

		-- Calcolo Girofondi
		DECLARE @moneytransfer_pagati decimal(19,2)
		SELECT @moneytransfer_pagati = isnull((SELECT sum(amount) FROM moneytransfer 
						WHERE (idtreasurersource = @idtreasurer or @idtreasurer is null)
							and (adate <= @date or @date is null)
							and ytransfer = @ayear) ,0)

		DECLARE @moneytransfer_incassati decimal(19,2)
		SELECT @moneytransfer_incassati = isnull((SELECT sum(amount) FROM moneytransfer 
						WHERE (idtreasurerdest = @idtreasurer  or @idtreasurer is null)	
							and (adate <= @date or @date is null)
							and ytransfer = @ayear)  ,0)

		DECLARE @treasurer_header varchar(150)
		SELECT @treasurer_header = header
		FROM treasurer
		where idtreasurer = @idtreasurer
	
		SELECT
		 	@ff_jan01 					 'floatfundinitial',
			@previous_proc_not_performed 			 'previousprocnotperformed',
			@previous_proc_partially_performed 		 'revprecparzesitate',
			@previous_pay_not_performed 			 'previouspaynotperformed',
			@previous_pay_partially_performed 		 'previouspaypartialperformed',
			@treasurer_start 				 'initialbalance',
			@proc_communicated 				 'proctransmitted',
			@proc_not_performed 				 'procnotperformed',
			@proc_partially_performed 			 'procpartiallyperformed',
			@pay_communicated 				 'paytransmitted',
			@pay_not_performed 				 'paynotperformed',
			@pay_partially_performed 		 'paypartiallyperformed',
			ISNULL(@active_pendings,0) 		 'activependings',
			ISNULL(@passive_pendings,0) 				 'passivependings',
			ISNULL(@previous_proc_performed, 0.0) 		 'previousprocperformed',
			ISNULL(@previous_pay_performed, 0.0) 		 'previouspayperformed',
			@display_previous_year 				 'previousyeardisp',
			@partite_pendenti_attive 			 'pendenti_attive',
			@partite_pendenti_passive 			 'pendenti_passive',
			@treasurer_header as treasurer,
			@moneytransfer_pagati as 'moneytransfer_pagati',
			@moneytransfer_incassati as 'moneytransfer_incassati'
	END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



