
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_riepilogoiva_dett]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_riepilogoiva_dett]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE  PROCEDURE  [exp_unified_riepilogoiva_dett]
(
	@idivaregisterkind int,
	@idinvkind 		int,
	@year int,
	@startmonth int,
	@stopmonth int,
	@groupiva char(1),
	@groupinvkind char(1),
	@flagactivity smallint,
	@unified char(1),
	@av char(1)
)
AS BEGIN	
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
	
	-- exp_unified_riepilogoiva_dett null,null,2015,1,12,'N','N',2,'N','V'
	
 
	-- se la stampa non è consolidata 	
	DECLARE @codeinvkind  varchar(20)
	SET @codeinvkind = (SELECT codeinvkind FROM invoicekind WHERE idinvkind = @idinvkind)

	DECLARE @codeivaregisterkind varchar(20)
	DECLARE @idivaregisterkindunified int
	if ( @idivaregisterkind is null)--> Vuol, dire che non ho specificato il registro e voglio vederli tutti.
	Begin
		SET  @codeivaregisterkind	  = null
		SET  @idivaregisterkindunified = null
	End
	Else
	Begin
		SELECT  @codeivaregisterkind	  = codeivaregisterkind,
				@idivaregisterkindunified = idivaregisterkindunified  FROM ivaregisterkind WHERE idivaregisterkind = @idivaregisterkind
	End
	print @idivaregisterkindunified

	--	1) Consolidamento MULTI - DIP. sulla base del codice di consolidamento.
	--	2) Consolidamento MONO - DIP. sulla base del codice di consolidamento.
	DECLARE @TipoConsolidamentoRegistriIVA		char(1)
	SELECT  @TipoConsolidamentoRegistriIVA = isnull(paramvalue,'') FROM    generalreportparameter
	WHERE   idparam = 'TipoConsolidamentoRegistriIVA'


	IF (@unified <> 'S')
	BEGIN
	        EXEC exp_riepilogoiva_dett @idivaregisterkind,@codeinvkind, @year, @startmonth, @stopmonth,@groupiva, @groupinvkind, @flagactivity, @unified, @codeivaregisterkind, @av 
	        RETURN
	END 

	IF ( @unified ='S' and @TipoConsolidamentoRegistriIVA = '2')
	BEGIN
			EXEC exp_riepilogoiva_dett @idivaregisterkindunified,@codeinvkind, @year, @startmonth, @stopmonth,@groupiva, @groupinvkind, @flagactivity, @unified, @codeivaregisterkind,@av 
	        RETURN	        
	END 	
	
	CREATE TABLE #outtable
	(
		registername			varchar(50),
		idivaregisterkindunified int,
		departmentname			varchar(500),
		attributo1				varchar(200),
		label					varchar(50),
		invoicekind				varchar(50),
		yinv					int,
		ninv					int,
		rownum					int,
		adate					datetime,
		codemotive  varchar(50),	motive  varchar(150),
		codeacc varchar(50),		account varchar(150),
		codemotivedett  varchar(50),motivedett  varchar(150),
		codeaccdett varchar(50),	accountdett varchar(150),
		flagmixed				char(1),
		flagdeferred			char(1),
		flagactivity			varchar(20),
		taxabletotal			decimal(19,2),
		ivagross				decimal(19,2),
		ivaunabatable			decimal(19,2), 
		ivaabatable				decimal(19,2),   
		ivakind					varchar(50),
		doc						varchar(35),
		docdate					smalldatetime,	
		registry				varchar(100),
		description				varchar(150),
		intracom				varchar(20),
		reverse_charge			char(1),
		intrastatoperationkind	varchar(20),	
		service					varchar(400),		
		paymethod				varchar(50),		
		idintrastatsupplymethod varchar(50),	
		nation_payment			varchar(100),	
		intrastatkind			varchar(200),
		measure					varchar(10),
		intrastacode			varchar(8),	
		descintrastacode		varchar(1000),
		nation_destination		varchar(100),
		nation_origin			varchar(100),
		nation_proven			varchar(100),
		country_destin			varchar(100),
		country_origin			varchar(100),
		intra12operationkind	varchar(20),
		move12					char(1),
		exception12				char(1),
		va3type					varchar(50),
		flag_enable_split_payment char(1),
		idsdi_acquisto int,		ipa_acq varchar(6),
		idsdi_vendita int,		ipa_ven_cliente varchar(6),
		iduniqueregister int,
		idupb varchar(36),
		codeupb varchar(50),
		upb varchar(150),
		idupb_iva varchar(36),
		codeupb_iva varchar(50),
		upb_iva varchar(150)
		
		-- Modifiche task 10269
		,paymenttransmissiondate smalldatetime,
		proceedstransmissiondate smalldatetime,
		taxable decimal(19,5),
		tax decimal (19,2)
		-- Fine modifiche task 10269

		-- Inizio Modifiche task 10659
        ,cf	varchar(16)                        
		,p_iva varchar(15)
		,foreigncf varchar(40)	
		-- Fine   modifiche task 10659			
		
	)

	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
							 where (start is null or start <= @year ) AND ( stop is null or stop >= @year)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
		set @dip_nomesp = @iddbdepartment + '.exp_riepilogoiva_dett'
		
	IF (@flagactivity != 4 AND @groupiva = 'N' and @groupinvkind = 'N') 
		BEGIN
		insert into #outtable 
			(
                registername			,
				idivaregisterkindunified,
				--departmentname			,
				attributo1				,
				label					,
				invoicekind				,
				yinv					,
				ninv					,
				rownum					,
				adate					,
				codemotive,motive,codeacc,account,
				codemotivedett,motivedett,codeaccdett,accountdett,
				flagmixed				,
				flagdeferred			,
				taxabletotal			,
				ivagross				,
				ivaunabatable			, 
				ivaabatable				,   
				ivakind					,
				doc						,
				docdate					,	
				registry				,
				description				,
				flagactivity			,
				intracom				,
				reverse_charge			,
				intrastatoperationkind  ,	
				service					,		
				paymethod				,		
				idintrastatsupplymethod ,	
				nation_payment			,	
				intrastatkind			,
				measure					,
				intrastacode			,	
				descintrastacode		,
				nation_destination		,
				nation_origin		    ,
				nation_proven			,
				country_destin			,
				country_origin			,
				intra12operationkind	,
				move12					,
				exception12				,
				va3type	,
				flag_enable_split_payment,
				idsdi_acquisto,ipa_acq,
				idsdi_vendita, ipa_ven_cliente, 
				iduniqueregister,
				idupb,
				codeupb,
				upb,
				idupb_iva,
				codeupb_iva,
				upb_iva
				--Modifiche task 10269
				,paymenttransmissiondate,
				proceedstransmissiondate,
				taxable,
				tax 
				--Fine modifiche task 10269

				, cf, p_iva, foreigncf   -- Modifiche task 10659
					
			)

			exec @dip_nomesp @idivaregisterkindunified, @codeinvkind, @year, @startmonth, @stopmonth, @groupiva, @groupinvkind, @flagactivity, @unified, @codeivaregisterkind,@av 
			fetch next from @crsdepartment into @iddbdepartment
			END
			ELSE
			BEGIN
			insert into #outtable 
			(
                registername			,
				idivaregisterkindunified ,
				departmentname			,
				label					,
				invoicekind				,
				yinv					,
				ninv					,
				rownum					,
				adate					,
				flagmixed				,
				flagdeferred			,
				taxabletotal			,
				ivagross				,
				ivaunabatable			, 
				ivaabatable				,   
				ivakind					,
				doc						,
				docdate					,	
				registry				,
				description				,
				flagactivity			,
				idupb					,
				codeupb					,
				upb						,
				idupb_iva				,
				codeupb_iva				,
				upb_iva
			)

			exec @dip_nomesp @idivaregisterkindunified, @codeinvkind, @year, @startmonth, @stopmonth, @groupiva, @groupinvkind, @flagactivity, @unified, @codeivaregisterkind ,@av
			fetch next from @crsdepartment into @iddbdepartment
			END
	
END
			
	IF (@flagactivity != 4 AND @groupiva = 'N' and @groupinvkind = 'N') 
	BEGIN
		SELECT 
           		registername as 'Registro', 
				idivaregisterkindunified as '#Cod. consolidamento',
				--departmentname as 'Dipartimento', 
				attributo1 as 'Attributo1',
				label as 'Esigibilità/Detraibilità', 
				invoicekind as 'Tipo Fattura', 
				yinv as 'Eserc. Fattura', 
				ninv as 'Num. Fattura', 
				rownum as '# Dett', 
				adate as 'Data Registr.',
				codemotive as 'Cod.Causale credito/debito', motive as 'Causale credito/debito',	codeacc as 'Cod.Conto credito/debito', account as 'Conto credito/debito',
				codemotivedett as 'Cod.Causale costo/ricavo', motivedett as 'Causale costo/ricavo',codeaccdett as 'Cod.Conto costo/ricavo', accountdett as 'Conto costo/ricavo',
				cf as 'Codice Fiscale', p_iva as 'Partita IVA', foreigncf as 'CF Estero/Passaporto',   -- Modifiche task 10659
				flagmixed as 'Promiscua',
				flagdeferred as 'IVA Differita', 
				taxabletotal as 'Impon. Tot.', 
				ivagross as 'IVA Tot.',
				ivaunabatable as 'IVA Indetr.',
				ivaabatable as 'IVA Detr.',
				ivakind as 'Tipo IVA',
				doc as 'Doc. colleg.',
				docdate as 'Data Doc.', 
				registry as 'Fornitore/Cliente', 
				description  as 'Descrizione',
				flagactivity as 'Attività',
				intracom	 as 'Operazione UE',
				reverse_charge as 'Reverse Charge',
				intrastatoperationkind  as 'Tipo oper. Intrastat',	
				service		as 'Servizio',		
				paymethod	as 'Modalità pagamento/incasso'	,		
				idintrastatsupplymethod as 'Modalità erogazione',	
				nation_payment	as 'Paese pagam.',	
				intrastatkind	as 'Nat. Transazione',
				measure	 as 'Un. misura suppl.',
				intrastacode as 'Cod. Nomencl. combinata',	
				descintrastacode as 'Nomencl. combinata',
				nation_destination	 as 'Paese. destin.',
				nation_origin	as 'Paese. orig.' ,
				nation_proven	as 'Paese. proven.',
				country_destin	as 'Prov. destin.',
				country_origin	as  'Prov. orig.'		,
				intra12operationkind as 'INTRA12 - Tipo oper.',
				move12	as 'INTRA12 - Fornitore non resid. UE'				,
				exception12	as 'INTRA12 - art.7-Ter DPR. n.633/72'			,
				va3type		 as 'Ripartizione totale acquisti - Quadro VF',
				flag_enable_split_payment as 'Split Payment',
				idsdi_acquisto as 'N.File(SdI Acquisto)' ,	ipa_acq as 'IPA acqisto',
				idsdi_vendita  as 'N.File(SdI Vendita)', ipa_ven_cliente as 'IPA cliente', 
				iduniqueregister as 'N.Registro Unico'	,
				idupb as '# UPB',
				codeupb as 'Cod. UPB',
				upb as 'UPB',
				idupb_iva  as '# UPB Iva', 
				codeupb_iva as 'Cod UPB Iva', 
				upb_iva  as 'UPB Iva'
				--Modifiche task 10269
				,paymenttransmissiondate as 'Data di trasmissione della distinta pagamenti',
				proceedstransmissiondate as 'Data di trasmissione della distinta incassi',
				taxable as 'Imponibile Pagato/Incassato',
				tax as 'IvaLiquidata'
				--Fine modifiche task 10269
						
		FROM #outtable
	END
	ELSE
	BEGIN
		SELECT 
           		registername as 'Registro', 
				idivaregisterkindunified as '#Cod. consolidamento',
				departmentname as 'Dipartimento', 
				label as 'Esigibilità/Detraibilità', 
				invoicekind as 'Tipo Fattura', 
				yinv as 'Eserc. Fattura', 
				ninv as 'Num. Fattura', 
				rownum as '# Dett', 
				adate as 'Data Registr.',
				flagmixed as 'Promiscua',
				flagdeferred as 'IVA Differita', 
				taxabletotal as 'Impon. Tot.', 
				ivagross as 'IVA Tot.',
				ivaunabatable as 'IVA Indetr.',
				ivaabatable as 'IVA Detr.',
				ivakind as 'Tipo IVA',
				doc as 'Doc. colleg.',
				docdate as 'Data Doc.', 
				registry as 'Fornitore/Cliente', 
				description  as 'Descrizione',
				flagactivity as 'Attività',
				idupb as '# UPB',
				codeupb as 'Cod. UPB',
				upb as 'UPB',
				idupb_iva  as '# UPB Iva', 
				codeupb_iva as 'Cod UPB Iva', 
				upb_iva  as 'UPB Iva'
		FROM #outtable
	END
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
