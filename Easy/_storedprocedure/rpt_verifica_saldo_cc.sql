
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_verifica_saldo_cc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_verifica_saldo_cc]
GO
 
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
setuser 'amministrazione'
rpt_verifica_saldo_cc 2021, {d '2021-06-30'}, null, 'N', 'N'
rpt_verifica_saldo_cc 2016, null,null, null 8218190.82
*/
 
CREATE 	PROCEDURE rpt_verifica_saldo_cc
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
			SUM(et.curramount) from
			incometotal et 
			JOIN income e on et.idinc=e.idinc and et.ayear=@ayear
			JOIN incomelast el on el.idinc = e.idinc 
			JOIN proceeds p on el.kpro = p.kpro
			JOIN proceedstransmission pt
				ON pt.kproceedstransmission = p.kproceedstransmission
			WHERE 	p.ypro = @ayear 
				AND (pt.transmissiondate <= @date or @date is null)
				AND PT.yproceedstransmission=@ayear
				AND (p.idtreasurer = @idtreasurer  or @idtreasurer is null)		
		
		DECLARE @pay_communicated decimal(19,2)
		-- Mandati Trasmessi
		SELECT 	@pay_communicated =
			SUM(et.curramount) from
			expensetotal et 
			JOIN expense e on et.idexp=e.idexp  and et.ayear=@ayear
			JOIN expenselast el on el.idexp = e.idexp 
			JOIN payment p on el.kpay=p.kpay	
			JOIN paymenttransmission pt
				ON pt.kpaymenttransmission = p.kpaymenttransmission
			WHERE 	p.ypay = @ayear 
				AND (pt.transmissiondate <= @date or @date is null)
				AND PT.ypaymenttransmission=@ayear
				AND (p.idtreasurer = @idtreasurer	  or @idtreasurer is null)	
	
		DECLARE @proc_not_performed decimal(19,2)
		-- Reversali di anno corrente NON ESITATE alla data  
		SELECT 	@proc_not_performed = 
			SUM(et.curramount) from
			incometotal et 
			JOIN income e on et.idinc=e.idinc and et.ayear=@ayear
			JOIN incomelast el on el.idinc = e.idinc 
			JOIN proceeds p on el.kpro = p.kpro
			JOIN proceedstransmission pt
				ON pt.kproceedstransmission = p.kproceedstransmission
			WHERE (pt.transmissiondate <= @date or @date is null)
				AND p.ypro=@ayear
				AND PT.yproceedstransmission=@ayear
				AND (p.idtreasurer = @idtreasurer  or @idtreasurer is null)		
				AND
                ISNULL((SELECT SUM(amount)from banktransaction PD where PD.kpro=P.kpro and 
				( (year(PD.transactiondate) = @ayear AND (PD.transactiondate <= @date)) 
				 OR  (year(PD.transactiondate) = (@ayear + 1) AND (@documentiesitati='S'))
				 OR  (@date is null)) ),0) =0
		
		
		DECLARE @pay_not_performed decimal(19,2)
		-- Mandati di anno corrente  NON ESITATI alla data  
		SELECT 	@pay_not_performed = 
			SUM(et.curramount) from
			expensetotal et 
			JOIN expense e on et.idexp=e.idexp and et.ayear=@ayear
			JOIN expenselast el on el.idexp = e.idexp 
			JOIN payment p on el.kpay=p.kpay	
			JOIN paymenttransmission pt
			ON pt.kpaymenttransmission = p.kpaymenttransmission
			WHERE (pt.transmissiondate <= @date or @date is null)
			AND p.ypay=@ayear
			AND PT.ypaymenttransmission=@ayear
			AND (p.idtreasurer = @idtreasurer  or @idtreasurer is null)		
		    AND
                ISNULL((SELECT SUM(amount)from banktransaction PD where PD.kpay=P.kpay and 
				((year(PD.transactiondate) = @ayear AND (PD.transactiondate <= @date)) 
			 OR  (year(PD.transactiondate) = (@ayear + 1) AND (@documentiesitati='S'))
			 OR  (@date is null))),0) =0

		DECLARE @proc_partially_performed decimal(19,2)
		SET 	@proc_partially_performed = 
		ISNULL(@proc_communicated,0) - ISNULL(@proc_not_performed,0) -
		ISNULL(
			(SELECT
			SUM(bt.amount)
			FROM banktransaction bt
			JOIN proceeds p
				ON p.kpro = bt.kpro
			JOIN proceedstransmission pt
				ON pt.kproceedstransmission = p.kproceedstransmission
			WHERE ((year(bt.transactiondate) = @ayear AND (bt.transactiondate <= @date))
					OR (year(bt.transactiondate) = (@ayear + 1) AND (@documentiesitati='S'))
					OR (bt.transactiondate is null or @date is null)
				   )
				AND (p.idtreasurer = @idtreasurer  or @idtreasurer is null)		
				AND p.ypro = @ayear)
			,0)
		
		
		DECLARE @pay_partially_performed decimal(19,2)
		SET 	@pay_partially_performed =
		ISNULL(@pay_communicated,0) - ISNULL(@pay_not_performed,0) -
		ISNULL(
			(SELECT
			SUM(bt.amount)
			FROM banktransaction bt
			JOIN payment p
				ON p.kpay = bt.kpay
			JOIN paymenttransmission pt
				ON pt.kpaymenttransmission = p.kpaymenttransmission
			WHERE  
					((year(bt.transactiondate) = @ayear AND (bt.transactiondate <= @date))
					OR (year(bt.transactiondate) = (@ayear + 1) AND (@documentiesitati='S'))
					OR (bt.transactiondate is null or @date is null)
				   )

				AND (p.idtreasurer = @idtreasurer  or @idtreasurer is null)		
				AND p.ypay = @ayear)
			,0)
		
		DECLARE @active_pendings decimal(19,2)
		DECLARE @passive_pendings decimal(19,2)


-- IMPORTO DA REGOLARIZZARE:
-- se active = N, allora è zero, perchè nella vecchia gestione Active = Da regolarizzare, quindi se N, la bolletta era stata tutta regolarizzata.
-- se active = S, lo calcoliamo come : total - reduction  , leggendo da billview.Ove 
-- total è l'importo della bolletta, reduction sono gli storni, e covered è l'importo regolarizzato.
-- Per chi usa il nuovo form "Importazione esiti e sospesi", si possono storicizzare le operazioni di apertura e storni di bolletta, leggendole da bankimportbill

		DECLARE @partite_pendenti_attive decimal(19,2)
		IF (ISNULL(@historicizebillop,'N') = 'N')
		BEGIN
			SELECT  @partite_pendenti_attive =  SUM(isnull(total,0) - isnull(reduction,0))
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
		END 
		ELSE
		BEGIN
			SELECT  @partite_pendenti_attive =  sum(amount)
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
		END

		DECLARE @esitato_partite_pendenti_attive decimal(19,2)
		SELECT @esitato_partite_pendenti_attive = sum(amount)
		FROM billtransaction
		join bill on bill.ybill=billtransaction.ybilltran and bill.nbill=billtransaction.nbill and bill.billkind=billtransaction.kind
		where ((year(billtransaction.adate) = @ayear AND (billtransaction.adate <= @date))
				OR    (year(billtransaction.adate) = (@ayear + 1) AND (@documentiesitati='S'))
				OR    (billtransaction.adate is null or @date is null)
				)
		and billtransaction.ybilltran = @ayear
		and billtransaction.kind = 'C'
		and bill.active='S'
		AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
		
		SET @partite_pendenti_attive = isnull(@partite_pendenti_attive,0) - isnull(@esitato_partite_pendenti_attive,0)

		DECLARE @partite_pendenti_passive decimal(19,2)
		IF (ISNULL(@historicizebillop,'N') = 'N')
		BEGIN
		SELECT  @partite_pendenti_passive =  SUM(isnull(total,0) - isnull(reduction,0))
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
		END
		ELSE
		BEGIN
			SELECT  @partite_pendenti_passive =  sum(amount)
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
		END

		DECLARE @esitato_partite_pendenti_passive decimal(19,2)
		SELECT @esitato_partite_pendenti_passive = sum(amount)
		FROM billtransaction
		join bill on bill.ybill=billtransaction.ybilltran and bill.nbill=billtransaction.nbill and bill.billkind=billtransaction.kind
		where ((year(billtransaction.adate) = @ayear AND billtransaction.adate <= @date)
				OR    (year(billtransaction.adate) = (@ayear + 1) AND (@documentiesitati='S'))
				OR    (billtransaction.adate is null or @date is null)
				)
		and billtransaction.ybilltran = @ayear
		and billtransaction.kind = 'D'
		AND bill.active = 'S'
		AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)

		SET @partite_pendenti_passive = isnull(@partite_pendenti_passive,0) - isnull(@esitato_partite_pendenti_passive,0)

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




