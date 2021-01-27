
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_riepilogoregistro_riep_ivakind]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_riepilogoregistro_riep_ivakind]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE     PROCEDURE [rpt_unified_riepilogoregistro_riep_ivakind]
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
--        rpt_unified_riepilogoregistro_riep_ivakind 5,2015,1,12,'S','N','S'
--        rpt_unified_riepilogoregistro_riep_ivakind 5,2015,1,12,'N','S','N'
--        rpt_unified_riepilogoregistro_riep_ivakind 5,2015,1,12,'N','N','N'
	
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
	CREATE TABLE #outtable
	(
		departmentname			varchar(200),
		currmonth 				varchar(50),
		curryear 				int,
		registername 			varchar(50),
		idivakind 				varchar(20),   -- codice IVA
		ivakinddescr 			varchar(50),  
		rate 		        	decimal(19,6),
		unabatabilitypercentage decimal(19,6),
		taxabletotal_imm  		decimal(19,2), -- Imponibile (dei documenti immediati)
		ivaunabatable_imm 		decimal(19,2), -- IVA Indetraibile (dei documenti immediati)
		ivaabatable_imm			decimal(19,2), -- IVA Detraibile (dei documenti immediati)
		taxabletotal_curr       decimal(19,2), -- Imponibile (dei documenti differiti divenuti immediati) es. corr
		ivaunabatable_curr		decimal(19,2), -- IVA Indetrabile (dei documenti differiti divenuti immediati) es. corr
		ivaabatable_curr		decimal(19,2),
		taxabletotal_prec		decimal(19,2), -- Imponibile (dei documenti differiti divenuti immediati) es. prec
		ivaunabatable_prec		decimal(19,2), -- IVA Indetrabile (dei documenti differiti divenuti immediati) es. prec
		ivaabatable_prec		decimal(19,2),
        taxabletotal_totdif     decimal(19,2), -- Imponibile (dei documenti differiti)
        ivaunabatable_totdif    decimal(19,2), -- IVA Indetraibile (dei documenti differiti)
        ivaabatable_totdif      decimal(19,2),  -- IVA Detraibile (dei documenti differiti)
		kind					varchar(2)
	)
	
	-- se la stampa non è consolidata 	
	DECLARE @codeivaregisterkind varchar(20)
	DECLARE @idivaregisterkindunified int
	SELECT  @codeivaregisterkind		 = codeivaregisterkind,
		    @idivaregisterkindunified = idivaregisterkindunified  FROM ivaregisterkind WHERE idivaregisterkind = @idivaregisterkind
		    
	--	1) Consolidamento MULTI - DIP. sulla base del codice di consolidamento.
	--	2) Consolidamento MONO - DIP. sulla base del codice di consolidamento.
	DECLARE @TipoConsolidamentoRegistriIVA		char(1)
	SELECT  @TipoConsolidamentoRegistriIVA = isnull(paramvalue,'') FROM    generalreportparameter
	WHERE   idparam = 'TipoConsolidamentoRegistriIVA'
	
	IF (@unified <> 'S')
	BEGIN
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
					ivaunabatable_imm , 
					ivaabatable_imm	, 
					taxabletotal_curr,      
					ivaunabatable_curr,		
					ivaabatable_curr,		
					taxabletotal_prec,		
					ivaunabatable_prec,		
					ivaabatable_prec,		
			        taxabletotal_totdif,     
					ivaunabatable_totdif,    
					ivaabatable_totdif,
					kind
			)
	        EXEC rpt_riepilogoregistro @idivaregisterkind, @year, @startmonth, @stopmonth, @official,@unified , @codeivaregisterkind, @split_payment,
	        @idsor01,@idsor02,@idsor03,@idsor04,@idsor05
	        
	END 
	Else
	Begin
			IF ( @unified ='S' and @TipoConsolidamentoRegistriIVA = '2')
			BEGIN
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
							ivaunabatable_imm , 
							ivaabatable_imm	, 
							taxabletotal_curr,      
							ivaunabatable_curr,		
							ivaabatable_curr,		
							taxabletotal_prec,		
							ivaunabatable_prec,		
							ivaabatable_prec,		
							taxabletotal_totdif,     
							ivaunabatable_totdif,    
							ivaabatable_totdif,
							kind
					)
					EXEC rpt_riepilogoregistro @idivaregisterkindunified, @year, @startmonth, @stopmonth, @official,@unified , @codeivaregisterkind, @split_payment,
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
					set @dip_nomesp = @iddbdepartment + '.rpt_riepilogoregistro'
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
								ivaunabatable_imm , 
								ivaabatable_imm	, 
								taxabletotal_curr,      
								ivaunabatable_curr,		
								ivaabatable_curr,		
								taxabletotal_prec,		
								ivaunabatable_prec,		
								ivaabatable_prec,		
								taxabletotal_totdif,     
								ivaunabatable_totdif,    
								ivaabatable_totdif,
								kind
						)
						exec @dip_nomesp @idivaregisterkindunified, @year, @startmonth, @stopmonth, @official,@unified, @codeivaregisterkind, @split_payment,
	        @idsor01,@idsor02,@idsor03,@idsor04,@idsor05
			
					fetch next from @crsdepartment into @iddbdepartment
			END--> while
			end --> else
	END -->Else
	UPDATE #OUTTABLE set rate = 0 WHERE isnull(rate,0) = 0
	SELECT 
			idivakind, ivakinddescr, rate,unabatabilitypercentage,
            --departmentname,
			--currmonth,
			--curryear,
			--registername,
			isnull(sum(taxabletotal_imm),0) as taxabletotal_imm, 
			isnull(sum(ivaunabatable_imm),0) as ivaunabatable_imm,
			isnull(sum(ivaabatable_imm),0) as ivaabatable_imm,  
			isnull(sum(taxabletotal_curr),0) as taxabletotal_curr,
			isnull(sum(ivaunabatable_curr),0) as ivaunabatable_curr,
			isnull(sum(ivaabatable_curr),0) as	ivaabatable_curr,
			isnull(sum(taxabletotal_prec),0) as	taxabletotal_prec,
			isnull(sum(ivaunabatable_prec),0) as ivaunabatable_prec,
			isnull(sum(ivaabatable_prec),0) as ivaabatable_prec,		
			isnull(sum(taxabletotal_totdif),0) as taxabletotal_totdif,
			isnull(sum(ivaunabatable_totdif),0) as  ivaunabatable_totdif,
			isnull(sum(ivaabatable_totdif),0) as ivaabatable_totdif,
			kind	
	FROM #outtable
	group by idivakind, ivakinddescr, rate,unabatabilitypercentage,kind
	
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
