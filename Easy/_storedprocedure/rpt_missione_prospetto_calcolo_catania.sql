
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_prospetto_calcolo_catania]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_prospetto_calcolo_catania]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 


-- setuser 'amministrazione' 
-- SETUSER'AMM'
-- rpt_missione_prospetto_calcolo_catania 2019,2019, 1, 30
CREATE  PROCEDURE  [rpt_missione_prospetto_calcolo_catania]
	@ayear smallint, 
	@yitineration smallint, 
	@numberbegin int,
	@numberend int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN

CREATE TABLE #rls
(
	idreg int,
	idposition int,
	incomeclass int,
	yitineration smallint,
	nitineration int,
	foreigngroupnumber smallint,
	iditineration int,
	start datetime
)

INSERT INTO #rls (idreg, idposition, incomeclass, yitineration, nitineration,iditineration, start)
SELECT RLS.idreg, RLS.idposition, isnull(RLS.incomeclass,0), I.yitineration, I.nitineration,  I.iditineration,I.start
FROM registrylegalstatus RLS
JOIN itineration I
	ON I.idreg = RLS.idreg
	AND I.idregistrylegalstatus = RLS.idregistrylegalstatus
WHERE I.yitineration = @yitineration
	AND I.nitineration BETWEEN @numberbegin AND @numberend
	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	AND I.iditineration_ref is null
	
UPDATE #rls
SET foreigngroupnumber =
(SELECT DET.foreigngroupnumber
FROM foreigngroupruledetail DET
JOIN foreigngrouprule F		ON F.idforeigngrouprule = DET.idforeigngrouprule
WHERE DET.idposition = #rls.idposition
	AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
	AND F.start =
		(SELECT MAX(F2.start)
		FROM foreigngrouprule F2
		JOIN foreigngroupruledetail DET2			ON F.idforeigngrouprule = DET.idforeigngrouprule
		WHERE DET2.idposition = #rls.idposition
			AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
			AND start <= #rls.start)
)




DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_AVV'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SET @NOSTAND = isnull((select idaddress FROM address WHERE codeaddress = @codenostand),0)

CREATE TABLE #address
(
	addresskind int, idreg int, officename varchar(50), address varchar(100),
	location varchar(120), cap varchar(20), province varchar(2), nation varchar(65)	
)	


INSERT INTO #address
SELECT
	idaddresskind,
	I.idreg, 
	officename, 
	address,
	ISNULL(geo_city.title,'')+' ' +ISNULL(registryaddress.location,''),
	registryaddress.cap,
	geo_country.province,
	case when flagforeign = 'N' then 'Italia' else geo_nation.title end
FROM registryaddress
JOIN itineration I
	ON I.idreg = registryaddress.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE 
	(
	    registryaddress.active <>'N' 
	AND registryaddress.start = 
	(SELECT MAX(cdi.start) 
	FROM registryaddress cdi 
	WHERE cdi.idaddresskind = registryaddress.idaddresskind
	AND cdi.active <>'N' 
	and cdi.stop is null --AND ((cdi.stop is null) OR (cdi.stop >= @dateindi)) 
	and cdi.idreg = registryaddress.idreg))
	and I.yitineration = @yitineration
	AND I.nitineration BETWEEN @numberbegin AND @numberend
	

delete #address
	where #address.addresskind <> @nostand
	and exists (
		select * from #address r2 
		where #address.idreg=r2.idreg
		and r2.addresskind = @nostand
	)
delete #address
	where #address.addresskind not in (@nostand, @stand)
	and exists (
		select * from #address r2 
		where #address.idreg=r2.idreg
		and r2.addresskind = @stand
	)
delete #address
	where (
		select count(*) from #address r2 
		where #address.idreg=r2.idreg
	)>1


SELECT 
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	registry.title  registry,
	registry.extmatricula  matricula,
	registry.birthdate,		 
	registry.gender,		
	ra.location as city,				 
	ra.address,				 
	ra.cap,					 
	registry.CF,			 
	s1.description ufficio,			-- Descrizione del primo attributo di sicurezza
	ISNULL(itineration.advancepercentage,0)		advancepercentage,		--  percentuale di anticipo richiesta
	ISNULL(itineration.supposedamount,0)		supposedamount,			--  importo presunto
	ISNULL(itineration.supposedfood,0)			supposedfood,			--  pasti presunti
	ISNULL(itineration.supposedliving,0)		supposedliving,			--  alloggio presunti
	ISNULL(itineration.supposedtravel,0)		supposedtravel,			--  viaggio presunti
	--  mezzo straordinario della missione Aereo, Nave o Nessuno
	CASE 		when (( itineration.flagmove & 1) = 0)  then 'N'  ELSE 'S' END as 'Nessuno',
	CASE 		when (( itineration.flagmove & 2) = 0)  then 'N'  ELSE 'S' END as 'Aereo',
	CASE 		when (( itineration.flagmove & 4) = 0)  then 'N'  ELSE 'S' END as 'Nave', 

	ISNULL(itineration.flagoutside,'N')			flagoutside,			--  missione su fondi esterni all'Ateneo
	ISNULL(itineration.flagownfunds,'N')		flagownfunds,			--  missioni su fondi propri 
	ISNULL(fc.description,'ITALIA')				nazione,				--  paese estero
	rp.iban,															--  modalità di pagamento per l'IBAN
	ISNULL(itineration.nfood,0)					nfood,					--  numero pasti
	itineration.advanceapplied,											--  anticipo erogato
	isnull (m.title, 'Non indicato')			 responsabile,			--  responsabile
	isnull(u.title  + ' - UPB: ' + u.codeupb, 'Non indicato') upb,			--  UPB  
	itineration.vehicle_info,			-- Targa
	itineration.vehicle_motive,			-- Motivo
	service.description as service,
	itineration.authorizationdate,
	itineration.starttime,
	itineration.stoptime,
	itineration.adate,
	position.description as position,
	#rls.incomeclass AS currentclass,
	#rls.foreigngroupnumber,
	itineration.applierannotations,
	itineration.location,
	CASE DATEDIFF(day, itineration.start,itineration.stop)
		WHEN 0 THEN 1
		ELSE DATEDIFF(day, itineration.start,itineration.stop)
	END ndays,
	itinerationstatus.iditinerationstatus,
	itinerationstatus.description as itinerationstatus,
	case 
		when itineration.iditinerationstatus = 6 /*Approvata*/ then itineration.adate
		else (select max(lt) from itinerationauthagency where itinerationauthagency.iditineration = itineration.iditineration) 
	end as 'printdate'
FROM itineration
JOIN registry			ON registry.idreg = itineration.idreg
--join registryaddressview ra	ON ra.idreg = registry.idreg and ra.codeaddress = '07_SW_DEF' and ra.active = 'S' and ra.stop is null
LEFT OUTER JOIN #address ra
	ON ra.idreg = itineration.idreg
JOIN #rls		ON itineration.yitineration = #rls.yitineration	AND itineration.nitineration = #rls.nitineration
JOIN position	ON position.idposition = #rls.idposition
JOIN service	ON service.idser = itineration.idser
JOIN itinerationstatus ON itineration.iditinerationstatus = itinerationstatus.iditinerationstatus
LEFT OUTER JOIN sorting s1			on s1.idsor = itineration.idsor01
left outer join foreigncountry fc	on itineration.idforeigncountry = fc.idforeigncountry
left outer join manager m			on itineration.idman = m.idman
left outer join upb u				on itineration.idupb = u.idupb
left outer join registrypaymethod rp	ON rp.idreg = registry.idreg and itineration.idregistrypaymethod = rp.idregistrypaymethod
WHERE itineration.yitineration = @yitineration   
	AND itineration.nitineration BETWEEN @numberbegin AND @numberend
	AND (@idsor01 IS NULL OR itineration.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR itineration.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR itineration.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR itineration.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR itineration.idsor05 = @idsor05)
	AND itineration.iditineration_ref is null
ORDER BY itineration.nitineration ASC
END



GO
 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
