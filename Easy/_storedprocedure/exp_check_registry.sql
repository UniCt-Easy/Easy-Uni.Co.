
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_registry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_registry]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE exp_check_registry (		
	@ayear int
) AS
BEGIN
/* Versione 1.0.1 del 13/11/2007 ultima modifica: GIUSEPPE */

-- fetch sulla tabella registry per avere i campi @surname @forename @birthday @idgeo @gender

-- E' la tabella contenete l'output finale
CREATE TABLE  #result
(
	idreg int,
	err_msg varchar(150),
	computed_cf varchar(20),
	inserted_cf varchar(20),
	surname varchar(100),
	forename varchar(100),
	gender char,
	b_date datetime,
	b_city varchar(70),
	b_nation varchar(70),
	r_city varchar(70)
)

DECLARE @birthcity varchar(50)
DECLARE @birthnation varchar(50)
DECLARE @birthyear char(2)
DECLARE @month char(1)
DECLARE @day varchar(2)
DECLARE @geocity char(4)
DECLARE @cf_built varchar(16)
DECLARE @c_birthday varchar(20)
DECLARE @surname varchar(100)
DECLARE @forename varchar(100)
DECLARE @birthday smalldatetime
DECLARE @vocali	varchar(60)
DECLARE @numvocali int
DECLARE @consonanti varchar(60)
DECLARE @numconsonanti int
DECLARE @indpos	int
DECLARE @maxindpos int
DECLARE @lettera char(1)
DECLARE @kind char(1)
DECLARE @idgeo int
DECLARE @idnation int
DECLARE @gender char(1)
DECLARE @codfisc char(16)		
DECLARE @error int 
DECLARE @idreg int

DECLARE @cf char(16)
SELECT @cf=''

DECLARE @dec31 datetime
DECLARE @jan12 datetime
IF (@ayear IS NOT NULL)
BEGIN
	SET @dec31 = CONVERT(datetime, '31-12-'+str(@ayear,4), 105)
	SET @jan12 = CONVERT(datetime, '12-01-'+str(@ayear+1,4), 105)
END
DECLARE @cf_cursor cursor
if (@ayear is null)
begin
	set @cf_cursor = CURSOR FOR
		SELECT registry.idreg, forename, surname, cf, gender, birthdate, idcity, idnation
		FROM registry
		JOIN registryclass
			ON registryclass.idregistryclass = registry.idregistryclass
		WHERE registryclass.flaghuman ='S' 
	FOR READ ONLY
end 
else 
begin
	set @cf_cursor = CURSOR FOR
		select registry.idreg, forename, surname, cf, gender, birthdate, idcity, idnation
		from registry
		JOIN registryclass
			ON registryclass.idregistryclass = registry.idregistryclass
		where registryclass.flaghuman = 'S' 
			and idreg in (
				select idreg from expenseview where registry.idreg = expenseview.idreg
				and (expenseview.ayear=@ayear or expenseview.ayear=@ayear+1 and expenseview.adate <= @jan12)
				and expenseview.idser is not null
				and expenseview.nphase=(
					select max(nphase) from expensephase
				)
		
			)
	FOR READ ONLY
end
OPEN @cf_cursor
FETCH NEXT FROM @cf_cursor INTO @idreg, @forename, @surname, @codfisc, @gender, @birthday, @idgeo, @idnation
WHILE (@@FETCH_STATUS = 0)
BEGIN
	select @error = 0
	declare @messaggio varchar(150)
	set @messaggio = null
	if (@codfisc is null) set @messaggio = isnull(@messaggio+', il codice fiscale', 'MANCA il codice fiscale')
	if (@surname is null) set @messaggio = isnull(@messaggio+', il surname', 'MANCA il surname')
	if (@forename is null) set @messaggio = isnull(@messaggio+', il forename', 'MANCA il forename')
	if (@gender is null) set @messaggio = isnull(@messaggio+', il gender', 'MANCA il gender')
	if (@birthday is null) set @messaggio = isnull(@messaggio+', la data di nascita', 'MANCA la data di nascita')
	set @birthcity = null
	set @birthnation = null
	if (@idnation is not null or @idgeo is null and substring(@codfisc,12,1)='Z')
	begin
		select @birthnation = geo_nation.title
		from geo_nation
		where geo_nation.idnation=@idnation
		SELECT @geocity = value  
		FROM geo_nation_agency WHERE idnation=@idnation and idcode=1 and idagency=1 and version=1
		if (@idnation is null) 
			SET @messaggio = isnull(@messaggio+' e la nazione di nascita', 'MANCA la nazione di nascita')
	end 
	else 
	begin
		select @birthcity = geo_city.title
		from geo_city
		where geo_city.idcity=@idgeo
		SELECT @geocity = value  
		FROM geo_city_agency WHERE idcity=@idgeo and idcode=1 and idagency=1 and version=1
		if (@idgeo is null) 
			SET @messaggio = isnull(@messaggio+' ed il comune di nascita', 'MANCA il comune di nascita')
	end
	IF (@messaggio is not null)
	BEGIN
		insert into #result VALUES ( 
				@idreg , 
				@messaggio, 
				null, 
				@codfisc, 
				@surname, 
				@forename, 
				@gender, 
				@birthday, 
				@birthcity, 
				@birthnation, 
				null)

		select @error = 1 
	END
	
IF @error <> 1 
BEGIN
--data in formato dd/mm/yyyy
	SELECT @c_birthday =  CONVERT(varchar(20),@birthday,105)
--anno di nascita
	SELECT @birthyear = SUBSTRING(@c_birthday,9,2)
--mese di nascita
	SELECT @month = cfvalue FROM monthname
	WHERE code = CONVERT(int,SUBSTRING(@c_birthday,4,2))
--giorno di nascita dipendente dal gender
	IF @gender IN ('m','M')
		SELECT @day = SUBSTRING(@c_birthday,1,2)
	ELSE
		SELECT @day = SUBSTRING(@c_birthday,1,2)+40
	IF LEN(@day)<2 SET @day = '0' + @day
--surname
	SELECT @numvocali = 0 	
	SELECT @numconsonanti = 0 
	SELECT @vocali = ''
	SELECT @consonanti=''
	SELECT @indpos = 0
	SELECT @maxindpos = LEN(@surname)
	WHILE (@indpos < @maxindpos)
	  BEGIN
		SELECT @kind=''         
		SELECT @indpos = @indpos + 1
		SELECT @lettera = SUBSTRING(@surname,@indpos,1)
		SELECT @kind = kind FROM buildcf WHERE letter = @lettera
		IF ISNULL(@kind,'') = 'C'
		 BEGIN
			SELECT @numconsonanti = @numconsonanti +1
			SELECT @consonanti = @consonanti + @lettera
		 END
		IF ISNULL(@kind,'') = 'V'
		 BEGIN
			SELECT @numvocali = @numvocali +1
			SELECT @vocali = @vocali + @lettera
		 END
	  END --fine while 
	  IF @numconsonanti > 2 SELECT @cf_built = SUBSTRING(@consonanti,1,3)
	  ELSE IF ((@numconsonanti = 2) AND (@numvocali > 0)) SELECT @cf_built =  SUBSTRING(@consonanti,1,2) + SUBSTRING(@vocali,1,1)
	  ELSE IF ((@numconsonanti = 1) AND (@numvocali > 1)) SELECT @cf_built =  SUBSTRING(@consonanti,1,1) + SUBSTRING(@vocali,1,2)
	  ELSE IF ((@numconsonanti = 1) AND (@numvocali = 1)) SELECT @cf_built =  SUBSTRING(@consonanti,1,1) + SUBSTRING(@vocali,1,1) + 'X'
	  ELSE IF ((@numconsonanti = 0) AND (@numvocali > 2)) SELECT @cf_built =  SUBSTRING(@vocali,1,3)
	  ELSE IF ((@numconsonanti = 0) AND (@numvocali = 2)) SELECT @cf_built =  SUBSTRING(@vocali,1,2) + 'X'
	  ELSE IF ((@numconsonanti = 0) AND (@numvocali = 1)) SELECT @cf_built =  SUBSTRING(@vocali,1,1) + 'XX'
	  ELSE SELECT @cf_built =  'XXX'
--forename
	SELECT @numvocali = 0
	SELECT @numconsonanti = 0
	SELECT @vocali = ''
	SELECT @consonanti=''
	SELECT @indpos = 0
	SELECT @maxindpos = LEN(@forename)
	WHILE (@indpos < @maxindpos)
	  BEGIN
		SELECT @kind=''         
		SELECT @indpos = @indpos + 1
		SELECT @lettera = SUBSTRING(@forename,@indpos,1)
		SELECT @kind = kind FROM buildcf WHERE letter = @lettera
		IF ISNULL(@kind,'') = 'C'
		 BEGIN
			SELECT @numconsonanti = @numconsonanti +1
			SELECT @consonanti = @consonanti + @lettera
		 END
		IF ISNULL(@kind,'') = 'V'
		 BEGIN
			SELECT @numvocali = @numvocali +1
			SELECT @vocali = @vocali + @lettera
		 END
	  END --fine while 
	  IF @numconsonanti > 3 SELECT @cf_built = @cf_built + SUBSTRING(@consonanti,1,1) + SUBSTRING(@consonanti,3,1) + SUBSTRING(@consonanti,4,1)
	  ELSE IF (@numconsonanti = 3) SELECT @cf_built = @cf_built + SUBSTRING(@consonanti,1,3)
	  ELSE IF ((@numconsonanti = 2) AND (@numvocali > 0)) SELECT @cf_built = @cf_built +  SUBSTRING(@consonanti,1,2) + SUBSTRING(@vocali,1,1)
	  ELSE IF ((@numconsonanti = 1) AND (@numvocali > 1)) SELECT @cf_built = @cf_built + SUBSTRING(@consonanti,1,1) + SUBSTRING(@vocali,1,2)
	  ELSE IF ((@numconsonanti = 1) AND (@numvocali = 1)) SELECT @cf_built = @cf_built +  SUBSTRING(@consonanti,1,1) + SUBSTRING(@vocali,1,1) + 'X'
	  ELSE IF ((@numconsonanti = 0) AND (@numvocali > 2)) SELECT @cf_built = @cf_built + SUBSTRING(@vocali,1,3)
	  ELSE IF ((@numconsonanti = 0) AND (@numvocali = 2)) SELECT @cf_built = @cf_built +  SUBSTRING(@vocali,1,2) + 'X'
	  ELSE IF ((@numconsonanti = 0) AND (@numvocali = 1)) SELECT @cf_built = @cf_built +  SUBSTRING(@vocali,1,1) + 'XX'
	  ELSE SELECT @cf_built =  @cf_built + 'XXX'
--i primi 15 caratteri di cf
	  SELECT @cf_built = @cf_built + @birthyear + @month + @day + @geocity
--carattere finale
	  DECLARE @i	int
	  DECLARE @tot_codfisc	int
	  DECLARE @sum_disp	int
	  DECLARE @sum_pari	int
	  DECLARE @lf	char(1)
	  SELECT @i = 0
	  SELECT @tot_codfisc =0
	  SELECT @sum_disp =0
	  SELECT @sum_pari =0
	  WHILE @i < 8
	  BEGIN
		SELECT @sum_disp = @sum_disp + oddposition
		FROM buildcf
		WHERE letter= SUBSTRING(@cf_built,2 * @i + 1,1)
		
		IF @i > 0
			SELECT @sum_pari = @sum_pari + evenposition
			FROM buildcf
			WHERE letter= SUBSTRING(@cf_built,2 * @i,1)
		SELECT @i = @i + 1
	  END
	SELECT @tot_codfisc = @sum_disp + @sum_pari
  	SELECT @lf = letter FROM buildcf WHERE evenposition = (@tot_codfisc % 26) AND kind <> 'N'
  	SELECT @cf = @cf_built + @lf
	set @cf = upper(@cf)
	set @codfisc = upper(@codfisc)
	IF @cf <> @codfisc
	BEGIN
		set @messaggio = null
		if datalength(@codfisc)<>16 set @messaggio = 'La lunghezza del codice fiscale è '+datalength(@codfisc)+' e non 16' 
		else begin
			if substring(@cf,1,15)=substring(@codfisc,1,15) and substring(@cf,16,1)<>substring(@codfisc,16,1) 
				set @messaggio = 'L''ultimo carattere del codice fiscale è "'+substring(@cf,16,1)+'" e non "'+substring(@codfisc,16,1)+'"'
			else begin
				if substring(@codfisc,16,1)!=(
					select p16.letter from buildcf p16 where p16.kind <>'N' and p16.evenposition=(
						(select sum(cf.evenposition) from evenposition_cf join buildcf cf
							on cf.letter=substring(@codfisc, evenposition_cf.position, 1)
						) + (select sum(cf.oddposition) from oddposition_cf join buildcf cf
							on cf.letter=substring(@codfisc, oddposition_cf.position, 1)
						)
					)
				%26) set @messaggio = 'ERRORI nel codice fiscale inserito'
				else begin
					if substring(@cf,1,3)<>substring(@codfisc,1,3) set @messaggio = isnull(@messaggio+', surname', 'ERRORI nel surname')
					if substring(@cf,4,3)<>substring(@codfisc,4,3) set @messaggio = isnull(@messaggio+', forename', 'ERRORI nel forename')
					if abs(ascii(substring(@cf,11,2))-ascii(substring(@codfisc,11,2))) = 4 set @messaggio = isnull(@messaggio+', gender', 'ERRORI nel gender')
					if substring(@cf,7,5)<>substring(@codfisc,7,5) set @messaggio = isnull(@messaggio+', data di nascita', 'ERRORI nella data di nascita')
					if substring(@cf,12,4)<>substring(@codfisc,12,4) set @messaggio = isnull(@messaggio+' e comune di nascita', 'ERRORI nel comune di nascita')
				end
			end
		end
		INSERT INTO #result VALUES (
					@idreg, 
					@messaggio, 
					@cf, 
					@codfisc, 
					@surname, 
					@forename, 
					@gender, 
					@birthday, 
					@birthcity, 
					@birthnation, 
					null)
	END 
	else 
	begin
	if (select newcity from geo_city where idcity=@idgeo) is not null or exists (select * from geo_city where oldcity=@idgeo)
	begin
		insert into #result 
		values(
			@idreg, 
			'Aggiornare il comune di nascita: '+@birthcity, 
			@cf, 
			@codfisc, 
			@surname, 
			@forename, 
			@gender,
			@birthday, 
			@birthcity, 
			@birthnation, 
			null)
	end
	declare @datainizio smalldatetime
	declare @idcomuneresidenza int
	declare @comuneresidenza varchar(70)
	DECLARE @idstand int
	SELECT @idstand = idaddress FROM address WHERE codeaddress = '07_SW_DEF'

	select @datainizio=start, @idcomuneresidenza=idcity
	from registryaddress where idreg=@idreg and idaddresskind=@idstand and
		((@ayear is null) or (@dec31 between start and stop) or (stop is null and @dec31>=start))
	select @comuneresidenza=title from geo_city where idcity=@idcomuneresidenza
	IF (@datainizio is null)
	BEGIN
		insert into #result 
		values(
			@idreg, 
			'Assente la residenza predefinita', 
			@cf, 
			@codfisc, 
			@surname, 
			@forename, 
			@gender, 
			@birthday, 
			@birthcity, 
			@birthnation, 
			@comuneresidenza
		)
	END
	if (select newcity from geo_city where idcity=@idcomuneresidenza) is not null or exists (select * from geo_city where oldcity=@idcomuneresidenza)
	begin
		insert into #result 
		values(
			@idreg, 
			'Aggiornare il comune di residenza: '+@comuneresidenza, 
			@cf, 
			@codfisc, 
			@surname, 
			@forename, 
			@gender, 
			@birthday, 
			@birthcity, 
			@birthnation, 
			@comuneresidenza
		)
	end
end

END
	FETCH NEXT FROM @cf_cursor INTO @idreg, @forename, @surname, @codfisc, @gender, @birthday , @idgeo, @idnation
	END 
	DEALLOCATE @cf_cursor
	SELECT * FROM #result ORDER BY err_msg
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

