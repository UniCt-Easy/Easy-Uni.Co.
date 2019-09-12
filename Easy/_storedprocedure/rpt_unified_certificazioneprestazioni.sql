if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_certificazioneprestazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_certificazioneprestazioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [rpt_unified_certificazioneprestazioni]
(
	@ayear smallint, 
	@idreg int, 
	@start datetime,
	@stop datetime,
	@idser int,
	@unified char(1),   -- consolidamento dei dati
	@showallser char(1) -- mostra le prestazioni non associate a certificazioni specifiche non CUD
	/*
	------------------------------------------------
	--------- ELENCO CERTIFICAZIONI SPECIFICHE------
	------------------------------------------------
	A	Certificazione Retribuzioni Aggiuntive	
	C	Certificazione stranieri in Convenzione	
	F	Certificazione Ritenuta d'Acconto	
	I	Certificazione INPS a gestione separata	
	P	Certificazione Premi di Studio e altri Premi	
	S	Modello Assegnisti	
	T	Certificazione a Titolo d'imposta	
	U	Modello CUD	
	------------------------------------------------
	------------------------------------------------
	------------------------------------------------
	*/
)
AS BEGIN

IF (@unified <> 'S')
BEGIN
        EXEC rpt_certificazioneprestazioni @ayear, @idreg, @start, @stop, @idser, @showallser
        RETURN
END 
CREATE TABLE #unified (
        departmentname  varchar(150),
	idexp int,
	idreg int ,
	registry varchar(100),
	b_city varchar(120),
   	birthdate smalldatetime,
	b_province varchar(2),
	b_nation varchar(65),
	cf varchar(16),
        taxcode int,
	taxdescription varchar(50),
	expensedescription varchar(150),	
	service varchar(50),
	idser int,
	npay int,
	taxablenet decimal(19,2),
	grossamount decimal(19,2), --Importo Lordo del Pagamento
	employtax decimal(19,2),
	admintax decimal(19,2),
	taxablegross decimal(19,2), -- Imponibile Lordo
	sent_office varchar(50),
	sent_address varchar(100),
	sent_idaddresskind varchar(20),
	sent_location varchar(120),
	sent_cap varchar(20),
	sent_province varchar(2),
	sent_nation varchar(65)
)

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
								 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.rpt_certificazioneprestazioni'
PRINT @iddbdepartment
		INSERT INTO #unified (
                        departmentname,
                	idexp,
                	idreg,
                	registry,
                	b_city,
                   	birthdate,
                	b_province,
                	b_nation,
                	cf,
                        taxcode,
                	taxdescription,
                	expensedescription,	
                	service,
                	idser,
                	npay,
                	taxablenet,
                	grossamount,--Importo Lordo del Pagamento
                	employtax,
                	admintax,
                	taxablegross, -- Imponibile Lordo
                	sent_office,
                	sent_address,
                	sent_idaddresskind, 
                	sent_location,
                	sent_cap,
                	sent_province,
                	sent_nation
		)
		EXEC @dip_nomesp @ayear, @idreg, @start, @stop, @idser, @showallser
	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
END

SELECT 
        departmentname,
	idexp,
	idreg,
	registry,
	b_city,
   	birthdate,
	b_province,
	b_nation,
	cf,
        taxcode,
	taxdescription,
	expensedescription,	
	service,
	idser,
	npay,
	taxablenet,
	grossamount,--Importo Lordo del Pagamento
	employtax,
	admintax,
	taxablegross, -- Imponibile Lordo
	sent_office,
	sent_address,
	sent_idaddresskind, 
	sent_location,
	sent_cap,
	sent_province,
	sent_nation
FROM #unified
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

