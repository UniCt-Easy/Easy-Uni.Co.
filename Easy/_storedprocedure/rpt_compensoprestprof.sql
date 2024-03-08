
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestprof]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestprof]
GO

CREATE    PROCEDURE [rpt_compensoprestprof]
	@ayear	   	int,
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
CREATE TABLE #addressresidence
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

INSERT INTO #addressresidence
SELECT 
	idaddresskind,
	registryaddress.idreg, 
	registry.title,
	officename, 
	address,
	isnull(geo_city.title,'')+' '+isnull(registryaddress.location,''),
	registryaddress.cap,
	geo_country.province,
	case 
		when flagforeign = 'N' then 'Italia'
		else
		geo_nation.title
	end,
	profservice.ycon,
	profservice.ncon
FROM registryaddress
JOIN profservice
	ON profservice.idreg = registryaddress.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
JOIN registry
	ON registry.idreg = profservice.idreg
WHERE 
registryaddress.active <>'N' AND
 registryaddress.idaddresskind= @STAND and
 profservice.ycon = @ycon AND 
 profservice.ncon BETWEEN @ncontractbegin AND @ncontractend
	AND (@idsor01 IS NULL OR profservice.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR profservice.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR profservice.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR profservice.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR profservice.idsor05 = @idsor05)
			
SELECT
	registry.idreg 		as 'idreg',
	profservice.ycon 	as 'ycon',
	profservice.ncon 	as 'ncon',
	registry.title 		as 'registry',
	registryclass.flaghuman as 'flaghuman',
	registry.birthdate,
	isnull(geo_city.title, registry.location) as 'birthplace',
	isnull(geo_country.province, '') as 'birthprovince',
	isnull(geo_nation.title, 'Italia') as 'birthnation',		
	registry.cf,
	registry.p_iva,
	profservice.idser,
	service.description as 'service',
	profservice.ndays,
	profservice.feegross,
	profservice.start,
	profservice.stop,
	profservice.adate,
	profservice.ndays,
	profservice.description,
	#addressresidence.address as 'residaddress',
	#addressresidence.location as 'residlocation',
	#addressresidence.cap as 'residcodpostale',
	#addressresidence.province as 'residprovince',
	#addressresidence.nation as 'residnation'
FROM  profservice
LEFT OUTER JOIN #addressresidence
ON #addressresidence.idreg = profservice.idreg AND
   #addressresidence.ycon = profservice.ycon AND
   #addressresidence.ncon = profservice.ncon
JOIN registry
	ON registry.idreg = profservice.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registry.idnation
JOIN service
	ON service.idser = profservice.idser
LEFT OUTER JOIN registryclass
	ON registryclass.idregistryclass = registry.idregistryclass
WHERE 
(profservice.ycon = @ycon AND  (profservice.ncon BETWEEN  @ncontractbegin AND @ncontractend))
	AND (@idsor01 IS NULL OR profservice.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR profservice.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR profservice.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR profservice.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR profservice.idsor05 = @idsor05)
ORDER BY profservice.ncon ASC
END 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
