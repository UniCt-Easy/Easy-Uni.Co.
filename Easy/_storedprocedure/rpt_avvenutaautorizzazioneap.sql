
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


 
 SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_avvenutaautorizzazioneap]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_avvenutaautorizzazioneap]
GO

CREATE     PROCEDURE [rpt_avvenutaautorizzazioneap]
	@yservreg int,
	@nservregstart int,
	@nservregstop int,
	@target char(1), -- I : stampa da indirizzare all'incaricato, E:stampa da indirizzare all'ente conferente
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS						      
BEGIN						

--	exec rpt_avvenutaautorizzazioneap 2013,1,1000,I
CREATE TABLE #INCARICATI (idreg int)
insert into #INCARICATI
select idreg 	
FROM serviceregistry
WHERE yservreg = @yservreg 
	and nservreg between @nservregstart and @nservregstop
	and employkind = 'D'
	AND (@idsor01 IS NULL OR idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR idsor05 = @idsor05)

CREATE TABLE #CONFERENTI (idreg int)
insert into #CONFERENTI
select idconferring
FROM serviceregistry
WHERE yservreg = @yservreg 
	and nservreg between @nservregstart and @nservregstop
	and employkind = 'D'
	AND (@idsor01 IS NULL OR idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR idsor05 = @idsor05) 

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_DOM'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

DECLARE @dateindi smalldatetime
SET @dateindi= convert( smalldatetime, '31-12-'+ convert(varchar(4),@yservreg), 105)

-- Calcola indirizzo	 INCARICATO

CREATE TABLE #ADDRESS_INCARICATO
(
	idaddresskind 	int,
	idreg		int,
	officename 	varchar(50),
	address		varchar(100),
	location	varchar(120),
	cap		varchar(20),
	province	varchar(2),
	nation		varchar(65)	 
)

 
	INSERT INTO #ADDRESS_INCARICATO
	(
		idaddresskind,
		idreg,
		officename,
		address,
		location,
		cap,
		province,
		nation						
	)
	SELECT
		idaddresskind,
		idreg, 
		officename, 
		address,
		location = ISNULL(geo_city.title,'')+' ' +ISNULL(registryaddress.location,'') ,
		registryaddress.cap,
		geo_country.province,
		nation = 
		case 
			when flagforeign = 'N' then 'Italia'
			else geo_nation.title
		end
	FROM registryaddress
	left outer join geo_city
		ON geo_city.idcity = registryaddress.idcity
	left outer join geo_country
		ON geo_city.idcountry = geo_country.idcountry
	left outer join geo_nation
		ON geo_nation.idnation = registryaddress.idnation
	WHERE 
		(
		registryaddress.active <>'N' 
		AND registryaddress.start = 
			(SELECT MAX(cdi.start) 
			FROM registryaddress cdi 
			WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateindi
			and cdi.idreg = registryaddress.idreg))
		AND (idreg in (SELECT idreg from #INCARICATI))
	delete #ADDRESS_INCARICATO
	where #ADDRESS_INCARICATO.idaddresskind <> @nostand
		and exists
			(select * from #ADDRESS_INCARICATO r2 
			where #ADDRESS_INCARICATO.idreg=r2.idreg
			and r2.idaddresskind = @nostand)
	delete #ADDRESS_INCARICATO
	where #ADDRESS_INCARICATO.idaddresskind not in (@nostand, @stand)
		and exists (
			select * from #ADDRESS_INCARICATO r2 
			where #ADDRESS_INCARICATO.idreg=r2.idreg
			and r2.idaddresskind = @stand
			)
	delete #ADDRESS_INCARICATO
	where (
		select count(*) from #ADDRESS_INCARICATO r2 
		where #ADDRESS_INCARICATO.idreg=r2.idreg
		)>1
 
-- Calcol indirizzo CONFERENTE

CREATE TABLE #ADDRESS_CONFERENTE
(
	idaddresskind 	int,
	idreg		int,
	officename 	varchar(50),
	address		varchar(100),
	location	varchar(120),
	cap		varchar(20),
	province	varchar(2),
	nation		varchar(65)	 
)
 
	INSERT INTO #ADDRESS_CONFERENTE
	(
		idaddresskind,
		idreg,
		officename,
		address,
		location,
		cap,
		province,
		nation						
	)
	SELECT
		idaddresskind,
		idreg, 
		officename, 
		address,
		location = ISNULL(geo_city.title,'')+' ' +ISNULL(registryaddress.location,'') ,
		registryaddress.cap,
		geo_country.province,
		nation = 
		case 
			when flagforeign = 'N' then 'Italia'
			else geo_nation.title
		end
	FROM registryaddress
	left outer join geo_city
		ON geo_city.idcity = registryaddress.idcity
	left outer join geo_country
		ON geo_city.idcountry = geo_country.idcountry
	left outer join geo_nation
		ON geo_nation.idnation = registryaddress.idnation
	WHERE 
		(
		registryaddress.active <>'N' 
		AND registryaddress.start = 
			(SELECT MAX(cdi.start) 
			FROM registryaddress cdi 
			WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateindi
			and cdi.idreg = registryaddress.idreg))
		AND (idreg in (SELECT idreg from #CONFERENTI))

	delete #ADDRESS_CONFERENTE
	where #ADDRESS_CONFERENTE.idaddresskind <> @nostand
		and exists
			(select * from #ADDRESS_CONFERENTE r2 
			where #ADDRESS_CONFERENTE.idreg=r2.idreg
			and r2.idaddresskind = @nostand)

	delete #ADDRESS_CONFERENTE
	where #ADDRESS_CONFERENTE.idaddresskind not in (@nostand, @stand)
		and exists (
			select * from #ADDRESS_CONFERENTE r2 
			where #ADDRESS_CONFERENTE.idreg=r2.idreg
			and r2.idaddresskind = @stand
			)

	delete #ADDRESS_CONFERENTE
	where (
		select count(*) from #ADDRESS_CONFERENTE r2 
		where #ADDRESS_CONFERENTE.idreg=r2.idreg
		)>1
 

SELECT 
	S.idreg,
	S.nservreg,
	#ADDRESS_INCARICATO.address as address_reg,
	#ADDRESS_INCARICATO.location as location_reg,
	#ADDRESS_INCARICATO.cap as cap_reg,
	#ADDRESS_INCARICATO.province as province_reg,

	#ADDRESS_CONFERENTE.address as address_conf,
	#ADDRESS_CONFERENTE.location as location_conf,
	#ADDRESS_CONFERENTE.cap as cap_conf,
	#ADDRESS_CONFERENTE.province as province_conf,
	S.title,
	S.surname,
	S.forename, 
	S.cf,
	apactivitykind.description as apactivitykind, 
	S.start, 
	S.stop, 
	S.expectedamount,
	S.conferring_surname,
	S.conferring_forename,
	S.pa_title,
	S.authorizationdate
	FROM serviceregistry S
	JOIN apactivitykind
		ON S.idapactivitykind = apactivitykind.idapactivitykind and S.yservreg = apactivitykind.ayear
	LEFT OUTER JOIN #ADDRESS_INCARICATO
		ON S.idreg = #ADDRESS_INCARICATO.idreg
	LEFT OUTER JOIN #ADDRESS_CONFERENTE
		ON S.idconferring = #ADDRESS_CONFERENTE.idreg
	WHERE S.yservreg = @yservreg 
		and S.nservreg between @nservregstart and @nservregstop
		and S.employkind = 'D'
	Order by S.idreg


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
