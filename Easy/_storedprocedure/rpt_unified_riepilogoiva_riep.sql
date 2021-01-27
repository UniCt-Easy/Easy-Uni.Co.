
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_riepilogoiva_riep]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_riepilogoiva_riep]
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
--setuser'amministrazione'
CREATE     PROCEDURE rpt_unified_riepilogoiva_riep
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
    -- rpt_unified_riepilogoiva_riep 1,2011,1,12,'N','S'
	-- rpt_unified_riepilogoiva_riep 1,2011,1,12,'N','N'
	
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
	
	--	1) Consolidamento MULTI - DIP. sulla base del codice di consolidamento.
	--	2) Consolidamento MONO - DIP. sulla base del codice di consolidamento.
	DECLARE @TipoConsolidamentoRegistriIVA		char(1)
	SELECT  @TipoConsolidamentoRegistriIVA = isnull(paramvalue,'') FROM    generalreportparameter
	WHERE   idparam = 'TipoConsolidamentoRegistriIVA'
	
	IF ((@unified <> 'S') OR ( @unified ='S' and @TipoConsolidamentoRegistriIVA = '2'))
	BEGIN
            SELECT
	        user AS departmentname,
        	0 AS taxabletotal_imm, 
        	0 AS taxabletotal_imm_esente, 
        	0 AS ivaunabatable_imm,
        	0 AS ivaabatable_imm, 
        	0 AS taxabletotal_dif,
        	0 AS taxabletotal_dif_esente,
        	0 AS ivaunabatable_dif,
        	0 AS ivaabatable_dif, 
        	0 AS taxabletotal_totdif, 
        	0 AS taxabletotal_totdif_esente, 
        	0 AS ivaunabatable_totdif,
        	0 AS ivaabatable_totdif 

	        RETURN
	END 

	-- CREAZIONE DELLA TABELLA TEMPORANEA CON L'INFO SUL NOME DEL DIPARTIMENTO
	CREATE TABLE #outtable
	(
		departmentname			varchar(200),
		currmonth 			varchar(50),
		curryear 			int,
		registername 			varchar(50),
		idivakind 			varchar(20),   -- codice IVA
		ivakinddescr 			varchar(50),  
		rate         			decimal(19,6),
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

	DECLARE @codeivaregisterkind varchar(20)
	DECLARE @idivaregisterkindunified int
	SELECT  @codeivaregisterkind		 = codeivaregisterkind,
		    @idivaregisterkindunified = idivaregisterkindunified  FROM ivaregisterkind WHERE idivaregisterkind = @idivaregisterkind


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
UPDATE #OUTTABLE set rate = 0 WHERE isnull(rate,0) = 0

	/*SELECT 
                departmentname,
        	SUM(taxabletotal_imm) AS taxabletotal_imm, -- Imponibile (dei documenti immediati)        >>>>>>
        	SUM(ivaunabatable_imm) AS ivaunabatable_imm, -- IVA Indetraibile (dei documenti immediati)
        	SUM(ivaabatable_imm) AS ivaabatable_imm, -- IVA Detraibile (dei documenti immediati)
        	SUM(taxabletotal_dif) AS taxabletotal_dif, -- Imponibile (dei documenti differiti divenuti immediati)        <<<<<<<
        	SUM(ivaunabatable_dif) AS ivaunabatable_dif, -- IVA Indetrabile (dei documenti differiti divenuti immediati)
        	SUM(ivaabatable_dif) AS ivaabatable_dif, -- IVA Detraibile (dei documenti differiti divenuti immediati)
        	SUM(taxabletotal_totdif) AS taxabletotal_totdif, -- Imponibile (dei documenti differiti)        <<<<<<<<<
        	SUM(ivaunabatable_totdif) AS ivaunabatable_totdif, -- IVA Indetraibile (dei documenti differiti)
        	SUM(ivaabatable_totdif) AS ivaabatable_totdif -- IVA Detraibile (dei documenti differiti)
	FROM #outtable
        GROUP BY departmentname*/
	SELECT 
                departmentname,
                (select SUM(taxabletotal_imm) 
                        from #outtable O2 
                        where O2.departmentname  =#outtable.departmentname and isnull(rate,0)<>0 )
                 AS taxabletotal_imm, -- Imponibile (dei documenti immediati)        NON ESENTE
        	(select SUM(taxabletotal_imm) 
                        from #outtable O2
                        where O2.departmentname  =#outtable.departmentname and isnull(rate,0)=0 )
                 AS taxabletotal_imm_esente, -- Imponibile (dei documenti immediati)        ESENTE
        	SUM(ivaunabatable_imm) AS ivaunabatable_imm, -- IVA Indetraibile (dei documenti immediati)
        	SUM(ivaabatable_imm) AS ivaabatable_imm, -- IVA Detraibile (dei documenti immediati)
                (select SUM(taxabletotal_dif)  
                        from #outtable O2
                        where O2.departmentname  =#outtable.departmentname and isnull(rate,0)<>0 )
                AS taxabletotal_dif, -- Imponibile (dei documenti differiti divenuti immediati)        NON ESENTE
               (select SUM(taxabletotal_dif)  
                        from #outtable O2
                        where O2.departmentname  =#outtable.departmentname and isnull(rate,0)=0 )
                AS taxabletotal_dif_esente, -- Imponibile (dei documenti differiti divenuti immediati)     ESENTE
        	SUM(ivaunabatable_dif) AS ivaunabatable_dif, -- IVA Indetrabile (dei documenti differiti divenuti immediati)
        	SUM(ivaabatable_dif) AS ivaabatable_dif, -- IVA Detraibile (dei documenti differiti divenuti immediati)
               (select SUM(taxabletotal_totdif)  
                        from #outtable O2
                        where O2.departmentname  =#outtable.departmentname and isnull(rate,0)<>0 )
                AS taxabletotal_totdif, -- Imponibile (dei documenti differiti)       NON ESENTE 
               (select SUM(taxabletotal_totdif)  
                        from #outtable O2
                        where O2.departmentname  =#outtable.departmentname and isnull(rate,0)= 0 )
        	AS taxabletotal_totdif_esente, -- Imponibile (dei documenti differiti)       ESENTE
        	SUM(ivaunabatable_totdif) AS ivaunabatable_totdif, -- IVA Indetraibile (dei documenti differiti)
        	SUM(ivaabatable_totdif) AS ivaabatable_totdif -- IVA Detraibile (dei documenti differiti)
	FROM #outtable
        GROUP BY departmentname

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- exec rpt_unified_riepilogoiva_riep 1,2007,1,12,'N','S'
