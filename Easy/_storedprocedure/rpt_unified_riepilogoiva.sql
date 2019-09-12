if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_riepilogoiva]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_riepilogoiva]
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
--setuser'amministrazione'

CREATE     PROCEDURE rpt_unified_riepilogoiva
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
--        rpt_unified_riepilogoiva 1,2011,1,12,'S','S','S'
	
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
	DECLARE @codeivaregisterkind varchar(20)
	DECLARE @idivaregisterkindunified int
	SELECT  @codeivaregisterkind		 = codeivaregisterkind,
		    @idivaregisterkindunified = idivaregisterkindunified  FROM ivaregisterkind WHERE idivaregisterkind = @idivaregisterkind

	--	1) Consolidamento MULTI - DIP. sulla base del codice di consolidamento.
	--	2) Consolidamento MONO - DIP. sulla base del codice di consolidamento.
	DECLARE @TipoConsolidamentoRegistriIVA		char(1)
	SELECT  @TipoConsolidamentoRegistriIVA = isnull(paramvalue,'') FROM    generalreportparameter
	WHERE   idparam = 'TipoConsolidamentoRegistriIVA'

	-- se la stampa non è consolidata 	
	
	IF (@unified <> 'S')
	BEGIN
	        EXEC rpt_riepilogoiva @idivaregisterkind, @year, @startmonth, @stopmonth, @official,@unified , @codeivaregisterkind, @split_payment,
	        @idsor01,@idsor02,@idsor03,@idsor04,@idsor05
	        RETURN
	END 

	IF ( @unified ='S' and @TipoConsolidamentoRegistriIVA = '2')
	BEGIN
	        EXEC rpt_riepilogoiva @idivaregisterkindunified, @year, @startmonth, @stopmonth, @official,@unified , @codeivaregisterkind, @split_payment,
	        @idsor01,@idsor02,@idsor03,@idsor04,@idsor05
	        RETURN
	END 	
	
	CREATE TABLE #outtable
	(
		departmentname			varchar(200),
		currmonth 			varchar(50),
		curryear 			int,
		registername 			varchar(50),
		idivakind 			varchar(20),   -- codice IVA
		ivakinddescr 			varchar(50),  
		rate 		        	decimal(19,6),
		unabatabilitypercentage 	decimal(19,6),
		taxabletotal_imm  		decimal(19,2), -- Imponibile (dei documenti immediati)
		ivaunabatable_imm 		decimal(19,2), -- IVA Indetraibile (dei documenti immediati)
		ivaabatable_imm			decimal(19,2), -- IVA Detraibile (dei documenti immediati)
        taxabletotal_dif                decimal(19,2), -- Imponibile (dei documenti differiti divenuti immediati)
        ivaunabatable_dif               decimal(19,2), -- IVA Indetrabile (dei documenti differiti divenuti immediati)
        ivaabatable_dif                 decimal(19,2), -- IVA Detraibile (dei documenti differiti divenuti immediati)
        taxabletotal_totdif             decimal(19,2), -- Imponibile (dei documenti differiti)
        ivaunabatable_totdif            decimal(19,2), -- IVA Indetraibile (dei documenti differiti)
        ivaabatable_totdif              decimal(19,2)  -- IVA Detraibile (dei documenti differiti)
	)

	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
	 where (start is null or start <= @year ) AND ( stop is null or stop >= @year)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
		set @dip_nomesp = @iddbdepartment + '.rpt_riepilogoiva'
		insert into #outtable 
			(
                        departmentname,
                        currmonth,
                        curryear,
                        registername,
                        idivakind,   
                        ivakinddescr,  
                        rate,
                        unabatabilitypercentage,
                        taxabletotal_imm,
                        ivaunabatable_imm,
                        ivaabatable_imm,
                        taxabletotal_dif,
                        ivaunabatable_dif,
                        ivaabatable_dif,
                        taxabletotal_totdif,
                        ivaunabatable_totdif,
                        ivaabatable_totdif 
			)

			exec @dip_nomesp @idivaregisterkindunified, @year, @startmonth, @stopmonth, @official,@unified, @codeivaregisterkind, @split_payment,
	        @idsor01,@idsor02,@idsor03,@idsor04,@idsor05
			
		fetch next from @crsdepartment into @iddbdepartment
	END
	SELECT 
                departmentname,
                currmonth,
                curryear,
                registername,
                idivakind,   
                ivakinddescr,  
                rate,
                unabatabilitypercentage,
                taxabletotal_imm,
                ivaunabatable_imm,
                ivaabatable_imm,
                taxabletotal_dif,
                ivaunabatable_dif,
                ivaabatable_dif,
                taxabletotal_totdif,
                ivaunabatable_totdif,
                ivaabatable_totdif 	 	
	FROM #outtable
	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO