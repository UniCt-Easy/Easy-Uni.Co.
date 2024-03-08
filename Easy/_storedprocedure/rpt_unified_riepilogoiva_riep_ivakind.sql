
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_riepilogoiva_riep_ivakind]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_riepilogoiva_riep_ivakind]
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
--setuser'amm'inistrazione'
CREATE     PROCEDURE [rpt_unified_riepilogoiva_riep_ivakind]
(
	@idivaregisterkind int,
	@year int,
	@startmonth int,
	@stopmonth int,
	@official char(1),
	@unified char(1),
	@split_payment char(1),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
AS BEGIN
    --rpt_unified_riepilogoiva_riep_ivakind 1,2015,1,12,'N','S','T'
	-- GO
	-- rpt_unified_riepilogoiva_riep_ivakind 1,2011,1,12,'N','S'
    IF @startmonth IS NULL OR @startmonth < 1
	BEGIN
		SET @startmonth = 1
	END
	IF @startmonth > 12
	BEGIN
		SET @startmonth = 12
	END
	IF @stopmonth IS NULL OR @stopmonth < 1
	BEGIN
		SET @stopmonth = 1
	END
	IF @stopmonth > 12
	BEGIN
		SET @stopmonth = 12
	END
	-- CREAZIONE DELLA TABELLA TEMPORANEA cCON L'INFO SUL NOME DEL DIPARTIMENTO
	
	-- se la stampa non è consolidata 	
	
	CREATE TABLE #outtable
	(
		departmentname				varchar(200),
		currmonth 					varchar(50),
		curryear 					int,
		registername 				varchar(50),
		kind						char(1),		
		idivakind 					varchar(20),	-- codice IVA
		ivakinddescr 				varchar(50),  
		rate         				decimal(19,6),
		unabatabilitypercentage		decimal(19,6),
		taxabletotal_imm  			decimal(19,2),	-- Imponibile (dei documenti immediati)
		nottaxabletotal_imm  		decimal(19,2),	-- Non imponibile (dei documenti immediati)
		ivaunabatable_imm 			decimal(19,2),	-- IVA Indetraibile (dei documenti immediati)
		ivaabatable_imm				decimal(19,2),	-- IVA Detraibile (dei documenti immediati)
		taxabletotal_dif			decimal(19,2),	-- Imponibile (dei documenti differiti divenuti immediati)
		nottaxabletotal_dif			decimal(19,2),	-- Non imponibile (dei documenti differiti divenuti immediati)
		ivaunabatable_dif			decimal(19,2),	-- IVA Indetrabile (dei documenti differiti divenuti immediati)
		ivaabatable_dif				decimal(19,2),	-- IVA Detraibile (dei documenti differiti divenuti immediati)
		taxabletotal_totdif			decimal(19,2),	-- Imponibile (dei documenti differiti)
		nottaxabletotal_totdif		decimal(19,2),	-- Non imponibile (dei documenti differiti)
		ivaunabatable_totdif		decimal(19,2),	-- IVA Indetraibile (dei documenti differiti)
		ivaabatable_totdif			decimal(19,2),	-- IVA Detraibile (dei documenti differiti),
		flag_enable_split_payment	char(1)			-- split payment
	)

	DECLARE @codeivaregisterkind varchar(20)
	DECLARE @idivaregisterkindunified int
	SELECT  @codeivaregisterkind	  = codeivaregisterkind,
		    @idivaregisterkindunified = idivaregisterkindunified  FROM ivaregisterkind WHERE idivaregisterkind = @idivaregisterkind

	--	1) Consolidamento MULTI - DIP. sulla base del codice di consolidamento.
	--	2) Consolidamento MONO - DIP. sulla base del codice di consolidamento.
	DECLARE @TipoConsolidamentoRegistriIVA		char(1)
	SELECT  @TipoConsolidamentoRegistriIVA = isnull(paramvalue,'') FROM    generalreportparameter
	WHERE   idparam = 'TipoConsolidamentoRegistriIVA'
	
	IF (@unified <> 'S') 
	BEGIN
		INSERT INTO #outtable 
		(
            departmentname,
            currmonth,
            curryear,
            registername,
            kind,
            idivakind,   
            ivakinddescr,  
            rate,
            unabatabilitypercentage,
            taxabletotal_imm,
            nottaxabletotal_imm,
            ivaunabatable_imm,
            ivaabatable_imm,
            taxabletotal_dif,
            nottaxabletotal_dif,
            ivaunabatable_dif,
            ivaabatable_dif,
            taxabletotal_totdif,
            nottaxabletotal_totdif,
            ivaunabatable_totdif,
            ivaabatable_totdif,
            flag_enable_split_payment 
		)
	    EXEC rpt_riepilogoiva_split_payment @idivaregisterkind, @year, @startmonth, @stopmonth, @official,@unified , @codeivaregisterkind, @split_payment,
	    @idsor01,@idsor02,@idsor03,@idsor04,@idsor05
	END 
	ELSE
	BEGIN
		IF (@unified ='S' and @TipoConsolidamentoRegistriIVA = '2')
		BEGIN
			INSERT INTO #outtable 
			(
				departmentname,
				currmonth,
				curryear,
				registername,
				kind,
				idivakind,   
				ivakinddescr,  
				rate,
				unabatabilitypercentage,
				taxabletotal_imm,
				nottaxabletotal_imm,
				ivaunabatable_imm,
				ivaabatable_imm,
				taxabletotal_dif,
				nottaxabletotal_dif,
				ivaunabatable_dif,
				ivaabatable_dif,
				taxabletotal_totdif,
				nottaxabletotal_totdif,
				ivaunabatable_totdif,
				ivaabatable_totdif,
				flag_enable_split_payment 
			)
			EXEC rpt_riepilogoiva_split_payment @idivaregisterkindunified, @year, @startmonth, @stopmonth, @official,@unified , @codeivaregisterkind, @split_payment,
			@idsor01,@idsor02,@idsor03,@idsor04,@idsor05
		END 
		ELSE
		BEGIN		
			declare @iddbdepartment varchar(50)
			declare @crsdepartment cursor
			set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
									 where (start is null or start <= @year ) AND ( stop is null or stop >= @year)
			open 	@crsdepartment
			fetch next from @crsdepartment into @iddbdepartment
			while @@fetch_status=0 begin
				declare @dip_nomesp varchar(300)
				set @dip_nomesp = @iddbdepartment + '.rpt_riepilogoiva_split_payment'
				insert into #outtable 
				(
					departmentname,
					currmonth,
					curryear,
					registername,
					kind,
					idivakind,   
					ivakinddescr,  
					rate,
					unabatabilitypercentage,
					taxabletotal_imm,
					nottaxabletotal_imm,
					ivaunabatable_imm,
					ivaabatable_imm,
					taxabletotal_dif,
					nottaxabletotal_dif,
					ivaunabatable_dif,
					ivaabatable_dif,
					taxabletotal_totdif,
					nottaxabletotal_totdif,
					ivaunabatable_totdif,
					ivaabatable_totdif,
					flag_enable_split_payment 
				)
				exec @dip_nomesp @idivaregisterkindunified, @year, @startmonth, @stopmonth, @official,@unified, @codeivaregisterkind, @split_payment,
				@idsor01,@idsor02,@idsor03,@idsor04,@idsor05
					
				fetch next from @crsdepartment into @iddbdepartment
			end-- while
		END
	End
	
UPDATE #OUTTABLE set rate = 0 WHERE isnull(rate,0) = 0
--SELECT * from #outtable
SELECT 
	idivakind,ivakinddescr,rate,flag_enable_split_payment,kind,

    -- Imponibile (dei documenti immediati)        >>>>>>
    -- Imponibile (dei documenti differiti divenuti immediati)  <<<<<<<
    -- Imponibile (dei documenti differiti)        <<<<<<<<<
	SUM(taxabletotal_imm) + SUM(taxabletotal_dif)  /*+ SUM(taxabletotal_totdif)*/  AS taxabletotal, 

    -- Imponibile (dei documenti immediati)        >>>>>>
    -- Imponibile (dei documenti differiti divenuti immediati)  <<<<<<<
    -- Imponibile (dei documenti differiti)        <<<<<<<<<
	SUM(nottaxabletotal_imm) + SUM(nottaxabletotal_dif)  /*+ SUM(taxabletotal_totdif)*/  AS nottaxabletotal, 

	-- IVA Indetraibile (dei documenti immediati)
	-- IVA Indetraibile (dei documenti differiti divenuti immediati)
	-- IVA Indetraibile (dei documenti differiti)
	SUM(ivaunabatable_imm) + SUM(ivaunabatable_dif) /* + SUM(ivaunabatable_totdif)*/ AS ivaunabatable, 
	
	-- IVA Detraibile (dei documenti immediati)
	-- IVA Detraibile (dei documenti differiti divenuti immediati)
	-- IVA Detraibile (dei documenti differiti)
	-- IVA a esigilibità immediata + IVA a esigibilità differita e basta, non va aggiunta l'iva divenuta esigibile, 
	-- perchè è l'iva a esigibilità differita divenuta esigibile
	SUM(ivaabatable_imm) +SUM(ivaabatable_dif) /*+ SUM(ivaabatable_totdif)*/ AS ivaabatable,

	-- Somma di Iva Detraibile + Iva indetraibile 
	-- (dei documenti immediati)
	-- (dei documenti differiti divenuti immediati)
	-- (dei documenti differiti)
	SUM(ivaunabatable_imm) + SUM(ivaunabatable_dif) /*+ SUM(ivaunabatable_totdif)*/ +
	SUM(ivaabatable_imm)   + SUM(ivaabatable_dif) /*+ SUM(ivaabatable_totdif)*/  AS ivatotal
FROM #outtable
GROUP BY idivakind,ivakinddescr,rate,flag_enable_split_payment,kind

END
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

