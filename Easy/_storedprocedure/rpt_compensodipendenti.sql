
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensodipendenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensodipendenti]
GO


CREATE   PROCEDURE [rpt_compensodipendenti]
	@ayear int,
	@ycon int,
	@ncontractbegin int,
    @ncontractend int  ,
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
	address varchar(100),
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
	ISNULL(geo_city.title,'')+' '+ISNULL(registryaddress.location,''),
	registryaddress.cap,
	geo_country.province,
	case 
		when flagforeign = 'N' then 'Italia'
		else
		geo_nation.title
	end,
	wageaddition.ycon,
	wageaddition.ncon
FROM registryaddress
JOIN wageaddition
	ON wageaddition.idreg = registryaddress.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
JOIN registry
	ON registry.idreg = wageaddition.idreg
WHERE 
	registryaddress.active <>'N' AND
	registryaddress.idaddresskind= @STAND
	and wageaddition.ycon = @ycon
	and wageaddition.ncon BETWEEN @ncontractbegin AND @ncontractend
	AND (@idsor01 IS NULL OR wageaddition.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR wageaddition.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR wageaddition.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR wageaddition.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR wageaddition.idsor05 = @idsor05)

		
SELECT
	registry.idreg as 'idreg',
	wageaddition.ycon as 'ycon',
	wageaddition.ncon as 'ncon',
	registry.title as 'registry',
	registry.birthdate,
	ISNULL(geo_city.title, registry.location) as 'birthlocation',
	ISNULL(geo_country.province, '') as 'birthprovince',
	ISNULL(geo_nation.title, 'Italia') as 'birthnation',
	registry.cf,
	wageaddition.idser,
	service.codeser,
	service.description as 'service',
	positionworkcontract.description as 'position',
	contractlength.description as 'duration',
	workingtime.description as 'time',
	wageaddition.ndays,
	wageaddition.feegross,
	wageaddition.start,
	wageaddition.stop,
	wageaddition.adate,
	wageaddition.description,
	#resid_address.address AS 'residaddress',
	#resid_address.location AS 'residlocation',
	#resid_address.cap AS 'residcodpostale',
	#resid_address.province AS 'residprovince',
	#resid_address.nation AS 'residnation'
	FROM  wageaddition			
	JOIN registry
		ON registry.idreg = wageaddition.idreg
	LEFT OUTER JOIN geo_city
		ON geo_city.idcity = registry.idcity
	LEFT OUTER JOIN geo_country
		ON geo_city.idcountry = geo_country.idcountry
	LEFT OUTER JOIN geo_nation
		ON geo_nation.idnation = registry.idnation
	JOIN service
		ON service.idser = wageaddition.idser
	JOIN wageadditionyear 
		ON wageaddition.ycon = wageadditionyear.ycon
		AND wageaddition.ncon = wageadditionyear.ncon
		AND wageadditionyear.ayear = @ayear
	LEFT OUTER JOIN positionworkcontract
		ON positionworkcontract.idposition = wageadditionyear.idposition
		AND positionworkcontract.ayear = wageadditionyear.ayear
	LEFT OUTER JOIN contractlength 
		ON contractlength.idcontractlength = wageadditionyear.idcontractlength
		AND contractlength.ayear = wageadditionyear.ayear
	LEFT OUTER JOIN workingtime 
		ON workingtime.idworkingtime = wageadditionyear.idworkingtime
		AND workingtime.ayear = wageadditionyear.ayear
	LEFT OUTER JOIN #resid_address
		ON #resid_address.idreg = wageaddition.idreg AND
		   #resid_address.ycon = wageaddition.ycon AND
		   #resid_address.ncon = wageaddition.ncon
	WHERE 
	(wageaddition.ycon = @ycon AND  wageaddition.ncon BETWEEN  @ncontractbegin AND @ncontractend)
	AND (@idsor01 IS NULL OR wageaddition.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR wageaddition.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR wageaddition.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR wageaddition.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR wageaddition.idsor05 = @idsor05)
	ORDER BY wageaddition.ncon ASC
END 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
