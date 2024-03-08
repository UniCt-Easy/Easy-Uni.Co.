
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogo_ritenute_applicate_occasionali]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogo_ritenute_applicate_occasionali]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE    PROCEDURE [exp_riepilogo_ritenute_applicate_occasionali]
	@ayear                 int, 
	@idreg int, 
	@tax                   int, 
	@start              datetime,
	@stop                datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
  BEGIN
-- exec exp_riepilogo_ritenute_applicate_occasionali 2010, null,null,{ts '2010-01-01 00:00:00'} , {ts '2010-12-31 00:00:00'}
DECLARE @departmentname varchar(150)

SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')


DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_DOM'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand


CREATE TABLE #casualcontract
(
	monthtaxpay int,
	taxablegross decimal(19,2),
	taxablenet decimal(19,2),
	employtax decimal(19,2),
	admintax decimal(19,2),
	abatements decimal(19,2),
	idexp int,
	taxcode int,
	idser int,
	idreg int,
	ycon int,
	ncon int,
	cc_start datetime,
	cc_stop datetime,
	idaddresskind int,
	start datetime,
	idcity int,
	idfiscaltaxregion varchar(5)
)

INSERT INTO #casualcontract
(
	monthtaxpay,
	taxablegross,
	taxablenet,
	employtax,
	admintax,
	abatements,
	idexp,
	taxcode,
	idser,
	idreg,
	ycon,
	ncon,
	cc_start,
	cc_stop,
	idaddresskind,
	start,
	idcity,
	idfiscaltaxregion
)

SELECT 	month(E.datetaxpay) as monthtaxpay,
	max(isnull(CCT.taxablegross,0)) as 'taxablegross',
	sum(isnull(CCT.taxablenet,0))   as 'taxablenet',
	sum(isnull(CCT.employtax,0))    as 'employtax',
	sum(isnull(CCT.admintax,0))     as 'admintax',
	sum(isnull(E.abatements,0))   as 'abatements',
	E.idexp,
	ISNULL(T.maintaxcode,T.taxcode) as taxcode,
	EL.idser,
        expense.idreg,
	CC.ycon ,
	CC.ncon ,
	CC.start as cc_start, 
	CC.stop as cc_stop,
	idaddresskind = @NOSTAND,
	start = (select max(registryaddress.start) from registryaddress 
		where registryaddress.idreg = expense.idreg
		and registryaddress.idaddresskind = @NOSTAND
		and year(registryaddress.start) <= @ayear
		AND registryaddress.active = 'S'),
	E.idcity,
	E.idfiscaltaxregion
FROM expensetaxview as E
JOIN expense 
	ON expense.idexp = E.idexp
JOIN expenselast EL
	ON E.idexp = EL.idexp
JOIN tax T
	ON T.taxcode = E.taxcode
join expenselink elk
	on elk.idchild = el.idexp	
JOIN expensecasualcontract EC
	ON EC.idexp = ELK.idparent
JOIN casualcontract CC
	ON CC.ycon = EC.ycon and  CC.ncon = EC.ncon
JOIN casualcontracttax CCT
	ON CCT.ycon  = CC.ycon 
	AND CCT.ncon  = CC.ncon  
	AND CCT.taxcode = T.taxcode
WHERE expense.ymov = @ayear  
	AND E.datetaxpay BETWEEN @start AND @stop 
	AND (@tax is null OR ISNULL(T.maintaxcode,T.taxcode) = @tax )
	AND (cc.idreg=@idreg OR @idreg is null)
	AND (@idsor01 IS NULL OR CC.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR CC.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR CC.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR CC.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR CC.idsor05 = @idsor05)
GROUP BY expense.idreg, E.idexp, ISNULL(T.maintaxcode,T.taxcode), E.datetaxpay, EL.idser,CC.ycon,CC.ncon, 
	CC.start,CC.stop, E.idcity, E.idfiscaltaxregion

INSERT INTO #casualcontract
(
	monthtaxpay,
	taxablegross,
	taxablenet,
	employtax,
	admintax,
	abatements,
	idexp,
	taxcode,
	idser,
	idreg,
	ycon,
	ncon,
	cc_start,
	cc_stop,
	idaddresskind,
	start,
	idcity,
	idfiscaltaxregion
)
SELECT 	month(E.adate) as monthtaxpay,
	0,
	0,
	sum(isnull(E.employamount,0)),
	sum(isnull(E.adminamount,0)),
	0,
	E.idexp,
	ISNULL(T.maintaxcode,T.taxcode) as taxcode,
	EL.idser,
        expense.idreg,
	CC.ycon ,
	CC.ncon ,
	CC.start,
	CC.stop,
	idaddresskind = @NOSTAND,
	start = (select max(registryaddress.start) from registryaddress 
		where registryaddress.idreg = expense.idreg
		and registryaddress.idaddresskind = @NOSTAND
		and year(registryaddress.start) <= @ayear
		AND registryaddress.active = 'S'),
	E.idcity,
	E.idfiscaltaxregion
FROM expensetaxcorrigeview as E
JOIN expense 
	ON expense.idexp = E.idexp
JOIN expenselast EL
	ON E.idexp = EL.idexp
JOIN tax T
	ON T.taxcode = E.taxcode
join expenselink elk
	on elk.idchild = el.idexp	
JOIN expensecasualcontract EC
	ON EC.idexp = ELK.idparent
JOIN casualcontract CC
	ON CC.ycon = EC.ycon and  CC.ncon = EC.ncon
JOIN casualcontracttax CCT
	ON CCT.ycon  = CC.ycon 
	AND CCT.ncon  = CC.ncon  
	AND CCT.taxcode = T.taxcode
WHERE expense.ymov = @ayear  
	AND E.adate BETWEEN @start AND @stop 
	AND (@tax is null OR ISNULL(T.maintaxcode,T.taxcode) = @tax )
	AND (cc.idreg=@idreg OR @idreg is null)
	AND (@idsor01 IS NULL OR CC.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR CC.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR CC.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR CC.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR CC.idsor05 = @idsor05)	
GROUP BY expense.idreg, E.idexp, ISNULL(T.maintaxcode,T.taxcode), E.adate, EL.idser,CC.ycon,CC.ncon, 
	CC.start,CC.stop, E.idcity, E.idfiscaltaxregion

update #casualcontract set
	idaddresskind = @STAND,
	start = (select max(registryaddress.start)
from registryaddress 
where registryaddress.idreg = #casualcontract.idreg
	and registryaddress.idaddresskind = @STAND
	and year(registryaddress.start) <= @ayear
	AND registryaddress.active = 'S')
where start is null

update #casualcontract set
	start = (select max(registryaddress.start)
from registryaddress 
where registryaddress.idreg = #casualcontract.idreg
	and year(registryaddress.start) <= @ayear
	AND registryaddress.active = 'S')
where start is null

update #casualcontract set
	idaddresskind = registryaddress.idaddresskind
from registryaddress 
where registryaddress.idreg = #casualcontract.idreg
	and registryaddress.start = #casualcontract.start
	AND registryaddress.active = 'S'
	and #casualcontract.idaddresskind is null

SELECT
	monthtaxpay as 'Mese', 
	@departmentname 'Dipartimento',
	registry.cf 'Codice Fiscale',
	registry.title as 'Percipiente',
	service.description as 'Prestazione',
	#casualcontract.cc_start as 'Inizio Prestazione',
	#casualcontract.cc_stop as 'Fine Prestazione',
	tax.description as 'Ritenuta',
	SUM(#casualcontract.taxablegross) as 'Imponibile Lordo' ,
	SUM(#casualcontract.taxablenet) as 'Imponibile Netto' ,
	SUM(#casualcontract.employtax) as  'Rit/Dipendente',
	SUM(#casualcontract.admintax) as 'Rit/Amministrazione',
	SUM(#casualcontract.abatements) as 'Detrazioni applicate',
	geo_city.title as 'Comune',
	geo_region.title as 'Regione',
	gf.title as 'Comune Fiscale',
	fiscaltaxregion.title as 'Regione Fiscale',
	otherinsurance.description as 'Altra forma Ass.',
	emenscontractkind.description as 'Tipo Rapporto'
FROM #casualcontract
join registry 
	on #casualcontract.idreg = registry.idreg 
JOIN casualcontractyear 
	ON #casualcontract.ycon = casualcontractyear.ycon
	AND #casualcontract.ncon = casualcontractyear.ncon
	AND casualcontractyear.ayear= @ayear
left outer join tax 
	on #casualcontract.taxcode = tax.taxcode
left outer join service 
	on #casualcontract.idser = service.idser
left outer join registryaddress 
	on registryaddress.idaddresskind=#casualcontract.idaddresskind
	and registryaddress.idreg=#casualcontract.idreg
	and registryaddress.start=#casualcontract.start
left outer join geo_city 
	on geo_city.idcity=registryaddress.idcity
left outer join geo_country 
	on geo_country.idcountry=geo_city.idcountry
left outer join geo_region
	on geo_region.idregion=geo_country.idregion
left outer join geo_city gf
	on geo_city.idcity=#casualcontract.idcity
left outer join fiscaltaxregion 
	on fiscaltaxregion.idregion=#casualcontract.idfiscaltaxregion
LEFT OUTER JOIN otherinsurance 
	ON otherinsurance.idotherinsurance = casualcontractyear.idotherinsurance
	AND otherinsurance.ayear = casualcontractyear.ayear
LEFT OUTER JOIN inpsactivity 
	ON inpsactivity.activitycode = casualcontractyear.activitycode
	AND inpsactivity.ayear = casualcontractyear.ayear
LEFT OUTER JOIN emenscontractkind 
	ON emenscontractkind.idemenscontractkind = casualcontractyear.idemenscontractkind
	AND emenscontractkind.ayear = casualcontractyear.ayear
WHERE (registry.idreg=@idreg OR @idreg=0)
GROUP BY cf, registry.title, tax.description, monthtaxpay, service.description, geo_city.title, geo_region.title,
	gf.title, fiscaltaxregion.title,
	#casualcontract.cc_start,#casualcontract.cc_stop,otherinsurance.description,emenscontractkind.description
ORDER BY tax.description, registry.title


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



