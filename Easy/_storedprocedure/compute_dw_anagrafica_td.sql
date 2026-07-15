/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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



/*--------------------------------------------------------------------------------------------------------------------------

			Questa stored procedure legge dal DB utente e scrive nella tabella  "anagrafica_td" del db  >> DataWareHouse_ENTE <<				 

---------------------------------------------------------------------------------------------------------------------------*/

--setuser'amministrazione'
-- exec compute_dw_anagrafica_td

if exists (select * from dbo.sysobjects where id = object_id(N'compute_dw_anagrafica_td') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure compute_dw_anagrafica_td
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create   PROCEDURE compute_dw_anagrafica_td
AS

Begin 
		DELETE DataWareHouse_ENTE.dbo.anagrafica_td;

		DECLARE @codenostand varchar(20)
		SET @codenostand = '07_SW_ORD'

		DECLARE @codestand varchar(20)
		SET @codestand = '07_SW_DEF'

		DECLARE @STAND int
		SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

		DECLARE @NOSTAND int
		SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

		DECLARE @dateindi smalldatetime
		SET @dateindi= convert( smalldatetime, '31-12-'+ convert(varchar(4),year( GETDATE())), 105)

CREATE TABLE #address_anagrafica
(
	idaddresskind 	int,
	idreg		int,
	officename 	varchar(50),
	address		varchar(100),
	city	varchar(120),
	cap		varchar(20),
	province	varchar(2),
	nation		varchar(65)	 
)
INSERT INTO #address_anagrafica
(
	idaddresskind,
	idreg,
	officename,
	address,
	city,
	cap,
	province,
	nation						
)
SELECT
	idaddresskind,
	idreg, 
	officename, 
	address,
	city = ISNULL(geo_city.title,''),
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
	AND (idreg in (SELECT idreg from DataWareHouse_ENTE.dbo.entrydetailfact ))



delete #address_anagrafica
where #address_anagrafica.idaddresskind <> @nostand
	and exists
		(select * from #address_anagrafica r2 
		where #address_anagrafica.idreg=r2.idreg
		and r2.idaddresskind = @nostand)
delete #address_anagrafica
where #address_anagrafica.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #address_anagrafica r2 
		where #address_anagrafica.idreg=r2.idreg
		and r2.idaddresskind = @stand
		)
delete #address_anagrafica
where (
	select count(*) from #address_anagrafica r2 
	where #address_anagrafica.idreg=r2.idreg
	)>1


-- Se sono presenti nella tabella dei fatti e manca l'indirizzo, prendiamo la Città dalla data di nascita
CREATE TABLE #registry_birth
(	idreg int,
	city varchar(120),
	province varchar(2),
	nation_title varchar(65),
)

INSERT INTO #registry_birth
(
	idreg,
	city,
	province,
	nation_title
)
SELECT
	registry.idreg,
	ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location,''),
	ISNULL(geo_country.province, ''),
	ISNULL(geo_nation.title, 'ITALIA')
FROM registry

LEFT OUTER JOIN geo_city
	ON registry.idcity = geo_city.idcity  
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registry.idnation = geo_nation.idnation  
WHERE   idreg not in (SELECT idreg from #address_anagrafica ) 
	 and idreg in (SELECT idreg from DataWareHouse_ENTE.dbo.entrydetailfact ) 

;WITH registryreferenceFiltered AS (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY idregistryreference ORDER BY idregistryreference desc) AS rn
    FROM registryreference
    WHERE flagdefault = 'S'
)

insert into DataWareHouse_ENTE.dbo.anagrafica_td
(
	idreg,--idreg ,
	registrytitle,-- registry ,
	p_iva,
	cf,
	indirizzo,--address,
	city,
	cap,
	provincia,--province,
	nazione,--nation,
	phone,
	fax,
	mobilenumber,
	email,
	officename
)	
SELECT 
	#address_anagrafica.idreg ,
	registry.title ,
	registry.p_iva,
	registry.cf,
	#address_anagrafica.address,
	#address_anagrafica.city,
	#address_anagrafica.cap,
	#address_anagrafica.province,
	#address_anagrafica.nation,
	RF.phonenumber as phone,
	RF.faxnumber as fax,
	RF.mobilenumber as mobilenumber,
	RF.email,
	#address_anagrafica.officename
FROM #address_anagrafica 
JOIN registry
	ON #address_anagrafica.idreg = registry.idreg
LEFT OUTER JOIN registryreferenceFiltered RF
	ON RF.idreg = #address_anagrafica.idreg and RF.rn=1
	
LEFT OUTER JOIN residence 
	ON registry.residence = residence.idresidence


;WITH registryreferenceFiltered AS (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY idregistryreference ORDER BY idregistryreference desc) AS rn
    FROM registryreference
    WHERE flagdefault = 'S'
)	
insert into DataWareHouse_ENTE.dbo.anagrafica_td
(
	idreg,--idreg ,
	registrytitle,-- registry ,
	p_iva,
	cf,
	indirizzo,--address,
	city,
	cap,
	provincia,--province,
	nazione,--nation,
	phone,
	fax,
	mobilenumber,
	email,
	officename
)	
SELECT 
	#registry_birth.idreg ,
	registry.title ,
	registry.p_iva,
	registry.cf,
	null,
	#registry_birth.city,
	null,
	#registry_birth.province,
	#registry_birth.nation_title,
	RF.phonenumber as phone,
	RF.faxnumber as fax,
	RF.mobilenumber as mobilenumber,
	RF.email,
	null
FROM #registry_birth 
JOIN registry
	ON #registry_birth.idreg = registry.idreg
LEFT OUTER JOIN registryreferenceFiltered RF
	ON RF.idreg = #registry_birth.idreg and RF.rn=1
LEFT OUTER JOIN residence 
	ON registry.residence = residence.idresidence



	
drop table #address_anagrafica

drop table #registry_birth
End

go

-- select * from DataWareHouse_ENTE.dbo.anagrafica_td

