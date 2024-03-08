
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestocc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestocc]
GO

CREATE    PROCEDURE [rpt_compensoprestocc]
	@ayear 		int,
	@ycon	   	int,
	@ncontractbegin int,
    @ncontractend 	int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	
AS
BEGIN
CREATE TABLE #resid_address
(
	addresskind int,
	idreg int,
	registry varchar(100),
	officename varchar(50),
	address	varchar(100),	
	location varchar(120),
	cap varchar(20),
	province varchar(2),
	nation varchar(65),
	ycon int,
	ncon int		
)

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

INSERT INTO #resid_address
SELECT 
	idaddresskind,
	registryaddress.idreg, 
	registry.title,
	officename, 
	address,
	location = isnull(geo_city.title,'')+' '+isnull(registryaddress.location,''),
	cap = registryaddress.cap,
	province = geo_country.province,
	nation = 
	case 
		when flagforeign = 'N' then 'Italia'
		else
		geo_nation.title
	end,
	casualcontract.ycon,
	casualcontract.ncon
FROM registryaddress
JOIN casualcontract
	ON casualcontract.idreg = registryaddress.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
JOIN registry
	ON registry.idreg = casualcontract.idreg
WHERE 
	registryaddress.active <>'N' 
	AND	registryaddress.idaddresskind= @STAND
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
		AND cdi.active  <>'N' AND ((cdi.stop is null) OR (cdi.stop >= casualcontract.start)) and cdi.idreg = registryaddress.idreg)
	and casualcontract.ycon = @ycon
	and casualcontract.ncon BETWEEN @ncontractbegin AND @ncontractend
	AND (@idsor01 IS NULL OR casualcontract.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR casualcontract.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR casualcontract.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR casualcontract.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR casualcontract.idsor05 = @idsor05)
	
SELECT
	casualcontract.idreg as 'idreg',
	casualcontract.ycon as 'ycon',
	casualcontract.ncon as 'ncon',
	registry.title as 'registry',
	registry.birthdate,
	isnull(geo_city.title, registry.location) as 'birthlocation',
	isnull(geo_country.province, '') as 'birthprovince',
	isnull(geo_nation.title, 'Italia') as 'birthnation',		
	registry.cf,
	casualcontract.idser,
	service.description 	as 'service',
	inpsactivity.description  	as 'inpsactivity',
	otherinsurance.description 	as 'otherinsurance',
	emenscontractkind.description 	as 'emenscontractkind',
	casualcontract.ndays 		as 'ndays',
	casualcontract.feegross,
	casualcontract.start,
	casualcontract.stop,
	casualcontract.adate,
	casualcontract.ndays ,
	casualcontract.description as 'descrizione',
	#resid_address.address as 'residaddress',
	#resid_address.location as 'residlocation',
	#resid_address.cap,
	#resid_address.province as 'residprovince',
	#resid_address.nation as 'residnation'
FROM casualcontract
LEFT OUTER JOIN #resid_address
	ON #resid_address.idreg = casualcontract.idreg AND
	#resid_address.ycon = casualcontract.ycon AND
	#resid_address.ncon = casualcontract.ncon
JOIN registry
	ON registry.idreg = casualcontract.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN  geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN  geo_nation
	ON geo_nation.idnation = registry.idnation
JOIN service
	ON service.idser = casualcontract.idser
JOIN casualcontractyear 
	ON casualcontract.ycon = casualcontractyear.ycon
	AND casualcontract.ncon = casualcontractyear.ncon
	AND casualcontractyear.ayear= @ycon
LEFT OUTER JOIN otherinsurance 
	ON otherinsurance.idotherinsurance = casualcontractyear.idotherinsurance
	AND otherinsurance.ayear = casualcontractyear.ayear
LEFT OUTER JOIN inpsactivity 
	ON inpsactivity.activitycode = casualcontractyear.activitycode
	AND inpsactivity.ayear = casualcontractyear.ayear
LEFT OUTER JOIN emenscontractkind 
	ON emenscontractkind.idemenscontractkind = casualcontractyear.idemenscontractkind
	AND emenscontractkind.ayear = casualcontractyear.ayear
WHERE (casualcontract.ycon = @ycon AND  (casualcontract.ncon BETWEEN  @ncontractbegin AND @ncontractend))
	AND (@idsor01 IS NULL OR casualcontract.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR casualcontract.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR casualcontract.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR casualcontract.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR casualcontract.idsor05 = @idsor05)
ORDER BY casualcontract.ncon
 
 END 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
