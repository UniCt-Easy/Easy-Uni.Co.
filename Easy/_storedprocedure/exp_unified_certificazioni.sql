if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_certificazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure  [exp_unified_certificazioni]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE     PROCEDURE [exp_unified_certificazioni]

	@ayear smallint, 
	@idreg int, 
	@start datetime,
	@stop datetime,
	@iddbdepartment varchar(50)

AS
BEGIN

IF (@idreg is NULL)  SET @idreg = 0

DECLARE @dip_nomesp varchar(300)

CREATE TABLE #output
( 
	dbdepartment varchar(150),
	iddbdepartment varchar(50),
	idanagrafica int,
	Anagrafica varchar(150),
	Nome varchar(150), 
	Cognome varchar(150), 
	Sesso Char(1),
	CittaNascita varchar(150),
	DataNascita datetime,
	ProvinciaNascita varchar(2),
	NazioneNascita varchar(150),
	CodiceFiscale varchar(16),
	PIva varchar(12),
	DescrizionePagamento varchar(150),	
	Mandato int,
--	ImportoLordoPagamento decimal(19,2),
	ImponibileFiscale decimal(19,2),
	RitAcconto decimal(19,2),
	ImponibileINPS decimal(19,2),
	INPSDip decimal(19,2),
	INPSAmm decimal(19,2),
	Indirizzo varchar(150),
	CittaoNazione varchar(150),
	CAP varchar(5),
	Provincia varchar(2),
	TipoPrestazione varchar(150),
	TipoPrestazioneEasy varchar(150)
)

IF @iddbdepartment IS NOT NULL 
BEGIN

	SET @dip_nomesp = @iddbdepartment + '.exp_certificazioni'
	INSERT INTO #output (
				dbdepartment,
				iddbdepartment,
				idanagrafica,
				Anagrafica,
				Nome, 
				Cognome , 
				Sesso ,
				CittaNascita ,
				DataNascita ,
				ProvinciaNascita ,
				NazioneNascita ,
				CodiceFiscale ,
				PIva ,
				DescrizionePagamento ,	
				Mandato ,
				ImponibileFiscale ,
				RitAcconto ,
				ImponibileINPS ,
				INPSDip ,
				INPSAmm ,
				Indirizzo ,
				CittaoNazione ,
				CAP ,
				Provincia ,
				TipoPrestazione ,
				TipoPrestazioneEasy 
    		)
		EXEC @dip_nomesp @ayear, @idreg, @start, @stop , @iddbdepartment
END

ELSE

BEGIN

	DECLARE @crsdepartment cursor

	SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
	OPEN @crsdepartment

	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
	WHILE @@fetch_status=0 begin
		SET @dip_nomesp = @iddbdepartment + '.exp_certificazioni'
	
			INSERT INTO #output (
				dbdepartment,
				iddbdepartment,
				idanagrafica,
				Anagrafica,
				Nome, 
				Cognome , 
				Sesso ,
				CittaNascita ,
				DataNascita ,
				ProvinciaNascita ,
				NazioneNascita ,
				CodiceFiscale ,
				PIva ,
				DescrizionePagamento ,	
				Mandato ,
				ImponibileFiscale ,
				RitAcconto ,
				ImponibileINPS ,
				INPSDip ,
				INPSAmm ,
				Indirizzo ,
				CittaoNazione ,
				CAP ,
				Provincia ,
				TipoPrestazione ,
				TipoPrestazioneEasy 
    			)
			EXEC @dip_nomesp @ayear, @idreg, @start, @stop , @iddbdepartment
		FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
	END

END

SELECT  dbdepartment,
		iddbdepartment,
		idanagrafica,
		Anagrafica,
		Nome, 
		Cognome , 
		Sesso ,
		CittaNascita ,
		DataNascita ,
		ProvinciaNascita ,
		NazioneNascita ,
		CodiceFiscale ,
		PIva ,
		DescrizionePagamento ,	
		Mandato ,
		ImponibileFiscale ,
		RitAcconto ,
		ImponibileINPS ,
		INPSDip ,
		INPSAmm ,
		Indirizzo ,
		CittaoNazione ,
		CAP ,
		Provincia ,
		TipoPrestazione ,
		TipoPrestazioneEasy 
FROM #output
ORDER BY dbdepartment, anagrafica, mandato

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
