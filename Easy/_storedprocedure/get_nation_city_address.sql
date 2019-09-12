if exists (select * from dbo.sysobjects where id = object_id(N'[get_nation_city_address]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [get_nation_city_address]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [get_nation_city_address]
(
	@idreg INT, -- cliente / fornitore fattura
	@dateindi smalldatetime,  -- data emissione della fattura
	@idnation int out,
	@idcity  int out
)
AS BEGIN
-- in prima istanza va preso il domicilio fiscale
DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_DOM'

-- in seconda istanza la residenza o sede amministrativa
DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

--mettere la data di  RIFERIMENTO
--DECLARE @dateindi smalldatetime
--SET @dateindi= convert( smalldatetime, '31-12-'+ convert(varchar(4),@ayear), 105)

CREATE TABLE #address
(
	idaddresskind 	int,
	start datetime,
	stop datetime,
	idreg		int,
	officename 	varchar(50),
	address		varchar(100),
	location	varchar(120),
	cap			varchar(20),
	province	varchar(2),
	idnation	int,
	nation		varchar(65),
	idcity int	 
)
INSERT INTO #address
(
	idaddresskind,
	start, 
	stop,
	idreg,
	officename,
	address,
	location,
	cap,
	province,
	idnation,
	nation,
	idcity						
)
SELECT
	idaddresskind,
	registryaddress.start,
	registryaddress.stop,
	idreg, 
	officename, 
	address,
	location = ISNULL(geo_city.title,'')+' ' +ISNULL(registryaddress.location,'') ,
	registryaddress.cap,
	geo_country.province,
	case 
		when flagforeign = 'N' then 1
		else geo_nation.idnation
	end,
	nation = 
	case 
		when flagforeign = 'N' then 'Italia'
		else geo_nation.title
	end,
	geo_city.idcity
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
		AND idreg = @idreg
delete #address
where #address.idaddresskind <> @nostand
	and exists
		(select * from #address r2 
		where #address.idreg=r2.idreg
		and r2.idaddresskind = @nostand)
delete #address
where #address.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #address r2 
		where #address.idreg=r2.idreg
		and r2.idaddresskind = @stand
		)
delete #address
where (
	select count(*) from #address r2 
	where #address.idreg=r2.idreg
	)>1

SET @idnation = (SELECT TOP 1 idnation FROM #address 
				        WHERE ISNULL(stop,{d '2079-06-06'}) > @dateindi order by start desc  )
SET @idcity = (SELECT TOP 1 idcity FROM #address 
				        WHERE ISNULL(stop,{d '2079-06-06'}) > @dateindi  order by start desc )
END
 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


