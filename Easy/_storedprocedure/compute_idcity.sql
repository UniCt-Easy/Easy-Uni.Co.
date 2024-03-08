
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_idcity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_idcity]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE                                         procedure [compute_idcity] (
	@denominazione varchar(150)=null, 
	@sigla_provincia varchar(2)=null, 
	@nome_provincia varchar(50)=null, -- non viene usato
	@cap varchar(20)=null,  
	@data SMALLDATETIME=null, 
	@flagstorico CHAR(1)=null,  -- non viene usato
	@idcomune int output
) as 
begin
	SET @idcomune = NULL
	DECLARE @idprovincia INT
	DECLARE @count INT
	
	--se denominazione è null esco
	IF @denominazione IS NULL RETURN
	IF @data IS NULL SET @data=GETDATE()
	--ricerca secca per denominazione (questo evita errori tipo, Cerignola (BA) (in realtà la prov. è FG))
	SELECT @count=count(*) FROM geo_city WHERE title = @denominazione
		AND @data between ISNULL(start, {d '1900-01-01'}) AND ISNULL(stop, {d '2079-06-06'})
	--se è unico il record allora ho trovato il comune
	IF @count=1 BEGIN
		SELECT @idcomune=idcity FROM geo_city WHERE title = @denominazione 
			AND @data between ISNULL(start, {d '1900-01-01'}) AND ISNULL(stop, {d '2079-06-06'})
		RETURN
	END
	--ricerca secca per denominazione tra i comuni operativi (questo evita errori tipo, Cerignola (BA) (in realtà la prov. è FG))
	SELECT @count=count(*) FROM geo_cityusable WHERE title = @denominazione AND
		@data between ISNULL(start, {d '1900-01-01'}) AND ISNULL(stop, {d '2079-06-06'})
	--se è unico il record allora ho trovato il comune
	IF @count=1 BEGIN
		SELECT @idcomune=idcity FROM geo_cityusable WHERE title = @denominazione 
			AND @data between ISNULL(start, {d '1900-01-01'}) AND ISNULL(stop, {d '2079-06-06'})
		RETURN
	END
	--ricavo l'id della provincia data la sigla
	IF @sigla_provincia IS NOT NULL BEGIN
		SELECT @idprovincia=idcountry	FROM geo_country WHERE province = @sigla_provincia
		--se non esiste quella sigla cerco il comune solo per denominazione
		IF @idprovincia IS NOT NULL BEGIN
			--cerco il comune per localita e provincia
			SELECT @count=count(*) FROM geo_city WHERE title=@denominazione AND idcountry = @idprovincia 
				AND @data between ISNULL(start, {d '1900-01-01'}) AND ISNULL(stop, {d '2079-06-06'})
			--se è unico l'ho trovato
			IF @count=1 BEGIN
				SELECT @idcomune=idcity FROM geo_city WHERE title=@denominazione AND idcountry = @idprovincia 
					AND @data between ISNULL(start, {d '1900-01-01'}) AND ISNULL(stop, {d '2079-06-06'})
				RETURN
			END
			--cerco il comune tra quelli operativi per localita e provincia
			SELECT @count=count(*) FROM geo_cityusable WHERE title=@denominazione AND idcountry = @idprovincia 
				AND @data between ISNULL(start, {d '1900-01-01'}) AND ISNULL(stop, {d '2079-06-06'})
			--se è unico l'ho trovato
			IF @count=1 BEGIN
				SELECT @idcomune=idcity FROM geo_cityusable WHERE title=@denominazione AND idcountry = @idprovincia 
					AND @data between ISNULL(start, {d '1900-01-01'}) AND ISNULL(stop, {d '2079-06-06'})
				RETURN
			END
		END
	END
	if @cap is not null
		Begin
			select @idcomune = idcity from geo_cap where cap=@cap
		End
end




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

