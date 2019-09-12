
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_riepilogoiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_riepilogoiva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
CREATE  PROCEDURE  [exp_unified_riepilogoiva]
(
	@idivaregisterkind int,
	@idinvkind 		int,
	@year int,
	@startmonth int,
	@stopmonth int,
	@unified char(1)
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
	
	-- exp_unified_riepilogoiva 5,null,2011,1,12,'S'
	
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
	
	--	1) Consolidamento MULTI - DIP. sulla base del codice di consolidamento.
	--	2) Consolidamento MONO - DIP. sulla base del codice di consolidamento.
	DECLARE @TipoConsolidamentoRegistriIVA		char(1)
	SELECT  @TipoConsolidamentoRegistriIVA = isnull(paramvalue,'') FROM    generalreportparameter
	WHERE   idparam = 'TipoConsolidamentoRegistriIVA'

	IF (@unified <> 'S')
	BEGIN
	        EXEC exp_riepilogoiva @idivaregisterkind,@codeinvkind, @year, @startmonth, @stopmonth, @unified,@codeivaregisterkind 
	        RETURN
	END 

	IF ( @unified ='S' and @TipoConsolidamentoRegistriIVA = '2')
	BEGIN
	        EXEC exp_riepilogoiva @idivaregisterkindunified, @year,@codeinvkind, @startmonth, @stopmonth, @unified , @codeivaregisterkind
	        RETURN
	END 	
		
	CREATE TABLE #outtable
	(
		registername			varchar(50),
		departmentname			varchar(200),
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
		iduniqueregister int
	)
	
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
	where   (start is null or start <= @year ) AND ( stop is null or stop >= @year)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
			declare @dip_nomesp varchar(300)
		set @dip_nomesp = @iddbdepartment + '.exp_riepilogoiva'
	
		insert into #outtable 
			(
                registername			,
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
				va3type,
				flag_enable_split_payment,
				idsdi_acquisto,ipa_acq,
				idsdi_vendita, ipa_ven_cliente, 
				iduniqueregister
			)

			exec @dip_nomesp @idivaregisterkindunified, @codeinvkind, @year, @startmonth, @stopmonth, @unified, @codeivaregisterkind
			
		fetch next from @crsdepartment into @iddbdepartment
	END
	SELECT 
           	registername as 'Registro', 
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
			iduniqueregister as 'N.Registro Unico'		
	FROM #outtable
	
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

