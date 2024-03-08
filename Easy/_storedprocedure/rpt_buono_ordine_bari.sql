
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_bari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_bari]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'

CREATE      PROCEDURE [rpt_buono_ordine_bari]
	@ayear int,
	@printkind char(1),
	@mandatekind varchar(20),
	@startnman int,
	@stopnman int,
	@idman int,
	@official char(1),
	@labelinenglish char(1),
	@idsorkindstuttura int, --51
	@idsorkindfirma int, --52
	@idsorkindrichiedente int, --53
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
AS BEGIN
-- exec rpt_buono_ordine_bari 2014, 'I', 'GENERALE', 1, 10, NULL, 'N', 'N', {ts '2014-12-31 00:00:00'}, 'N', 51,52,53,null, null, null, null, null
IF (@ayear=0)
BEGIN
	SET @ayear='1900'
END
CREATE TABLE #mandate
(
	yman int  ,
	nman int  ,
	idmankind varchar(20),
	idreg int  ,
	idexpirationkind int  ,
	idcurrency int,
	exchangerate float  ,
	idman int,
	numintegration int  ,
	numannulled int ,
	cigcode varchar(10),
	cupcode varchar(15),
	sortcodestuttura varchar(50),
	sortstuttura varchar(200),
	sortcodefirma varchar(50),
	sortfirma varchar(200),
	sortcoderichiedente varchar(50),
	sortrichiedente varchar(200)
)

CREATE TABLE #printing
(
	nman int  
)
IF @printkind = 'A' 
	INSERT INTO #printing (nman) 
	SELECT nman from  mandate   join mandatekind  ON mandatekind.idmankind = mandate.idmankind  
	where (yman=@ayear) and (mandate.idmankind = @mandatekind) AND (officiallyprinted <>'S')
								and (	(@idman is not null  AND idman = @idman ) OR (@idman is null)	)
	AND (isnull(mandate.idsor01,mandatekind.idsor01) = @idsor01 OR @idsor01 IS NULL)
	AND (isnull(mandate.idsor02,mandatekind.idsor02) = @idsor02 OR @idsor02 IS NULL)
	AND (isnull(mandate.idsor03,mandatekind.idsor03) = @idsor03 OR @idsor03 IS NULL)
	AND (isnull(mandate.idsor04,mandatekind.idsor04) = @idsor04 OR @idsor04 IS NULL)
	AND (isnull(mandate.idsor05,mandatekind.idsor05) = @idsor05 OR @idsor05 IS NULL)
	
IF @printkind  <> 'A'
	INSERT INTO #printing (nman) 
	SELECT nman from  mandate join mandatekind  ON mandatekind.idmankind = mandate.idmankind  where (yman=@ayear) and (mandate.idmankind = @mandatekind) 
				AND (
			 		@startnman IS NOT NULL AND @stopnman IS NOT NULL 
					AND (nman BETWEEN @startnman AND @stopnman) 
					AND (idman = @idman  OR  @idman IS NULL)
				OR 
					@startnman IS NULL AND @stopnman IS NULL 
					AND @idman IS NOT NULL AND idman = @idman 
				    )
	AND (isnull(mandate.idsor01,mandatekind.idsor01) = @idsor01 OR @idsor01 IS NULL)
	AND (isnull(mandate.idsor02,mandatekind.idsor02) = @idsor02 OR @idsor02 IS NULL)
	AND (isnull(mandate.idsor03,mandatekind.idsor03) = @idsor03 OR @idsor03 IS NULL)
	AND (isnull(mandate.idsor04,mandatekind.idsor04) = @idsor04 OR @idsor04 IS NULL)
	AND (isnull(mandate.idsor05,mandatekind.idsor05) = @idsor05 OR @idsor05 IS NULL)

INSERT INTO #mandate
(
	yman,
	nman,
	idmankind,
	idreg,
	idexpirationkind,
	idcurrency,
	exchangerate,
	idman,
	numintegration,
	numannulled,
	cigcode
	)
SELECT 
	M.yman,
	M.nman,
	M.idmankind,
	M.idreg,
	M.idexpirationkind,
	M.idcurrency,
	M.exchangerate,
	M.idman,
	0,
	0,
	cigcode
FROM mandate M
WHERE M.yman = @ayear
	AND M.idmankind = @mandatekind
	AND M.nman in (SELECT nman FROM #printing)

-- Firma
update #mandate set	sortcodefirma = S1.sortcode, sortfirma = S1.description 
				from sorting S1
				join mandatesorting MS
					 on S1.idsor = MS.idsor AND S1.idsorkind = @idsorkindfirma
where MS.nman = #mandate.nman AND MS.yman = #mandate.yman AND MS.idmankind = #mandate.idmankind
		
-- Struttura
update #mandate set	sortcodestuttura = S1.sortcode, sortstuttura = S1.description 
				from sorting S1
				join mandatesorting MS
					 on S1.idsor = MS.idsor AND S1.idsorkind = @idsorkindstuttura
where MS.nman = #mandate.nman AND MS.yman = #mandate.yman AND MS.idmankind = #mandate.idmankind

-- Richiedente
update #mandate set	sortcoderichiedente = S1.sortcode, sortrichiedente = S1.description 
				from sorting S1
				join mandatesorting MS
					 on S1.idsor = MS.idsor AND S1.idsorkind = @idsorkindrichiedente
where MS.nman = #mandate.nman AND MS.yman = #mandate.yman AND MS.idmankind = #mandate.idmankind
				 
DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_ORD'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

DECLARE @dateindi smalldatetime
SET @dateindi= convert( smalldatetime, '31-12-'+ convert(varchar(4),@ayear), 105)
CREATE TABLE #address_mandate
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
INSERT INTO #address_mandate
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
	AND (idreg in (SELECT idreg from #mandate))

delete #address_mandate
where #address_mandate.idaddresskind <> @nostand
	and exists
		(select * from #address_mandate r2 
		where #address_mandate.idreg=r2.idreg
		and r2.idaddresskind = @nostand)
delete #address_mandate
where #address_mandate.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #address_mandate r2 
		where #address_mandate.idreg=r2.idreg
		and r2.idaddresskind = @stand
		)
delete #address_mandate
where (
	select count(*) from #address_mandate r2 
	where #address_mandate.idreg=r2.idreg
	)>1

/*
UPDATE  #mandate 
SET numannulled= (SELECT count(distinct idgroup) 
			FROM mandatedetail 
		       WHERE yman = #mandate.yman AND
			     nman = #mandate.nman AND 
			     idmankind = @mandatekind AND
			     mandatedetail.stop is not null and 
			     mandatedetail.stop <= @variationdate
			)
UPDATE  #mandate 
SET numintegration= (SELECT count(distinct idgroup) 
			FROM mandatedetail 
		       WHERE yman = #mandate.yman AND
			     nman = #mandate.nman AND 
			     idmankind = @mandatekind AND
			     mandatedetail.start is not null and 
			     mandatedetail.start <= @variationdate
			)
*/
CREATE TABLE #mandatedetail
(
	yman int,
	nman int,
	idmankind varchar(20),
	rownum int,
	detaildescription varchar(150),
	annotations varchar(400),
	npackage decimal(19,2),
	taxable decimal(19,5),
	taxrate float,
	tax decimal(19,2),
	discount float,
	start datetime,
	stop datetime,
	idgroup int,
	rowtaxable decimal(19,5),
	totalrow decimal(19,2),
	rowtaxable_fcurrency decimal(19,5),
	totalrow_fcurrency decimal(19,2),
	flagactivity smallint,
	idreg_detail int,
	cupcodedetail varchar(15),
	cupcode varchar(15),
	cigcodedetail varchar(10)
)
INSERT INTO #mandatedetail
(
	yman,
	nman,
	idmankind,
	rownum,
	detaildescription,
	annotations,
	npackage,
	taxable,
	taxrate,
	--tax,
	discount,
	start,
	stop ,
	idgroup ,
	rowtaxable,
	totalrow,
	---- ORDINI IN VALUTA ESTERA-----
	rowtaxable_fcurrency,
	totalrow_fcurrency,
	---------------------------------
	flagactivity,
	idreg_detail,
	cupcodedetail,
	cigcodedetail 
)
SELECT 
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idmankind,
	mandatedetail.rownum,
	detaildescription,
	mandatedetail.annotations,
	npackage,
	isnull(sum(taxable),0),
	CASE	
		WHEN ( mandate.flagintracom <> 'N')-- AND idcurrency NOT IN (select idcurrency from currency where codecurrency = 'ITL' OR codecurrency = 'EUR'))
		THEN  0
		ELSE taxrate
	END, 
	--sum(tax),
	discount,
	mandatedetail.start,
	mandatedetail.stop,
	idgroup,
sum(
	CONVERT(DECIMAL(19,2),
		ROUND(
		      mandatedetail.taxable*
		      mandatedetail.npackage*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0))),2
  		     )
	) 
),
-- Il campo totaleriga deve essere calcolato come la somma dell'imponibile scontato + l'iva 
CASE 
WHEN ( mandate.flagintracom<>'N')-- AND idcurrency NOT IN (select idcurrency from currency where codecurrency = 'ITL' OR codecurrency = 'EUR'))
THEN  
-- non considera iva
		SUM(
			CONVERT(DECIMAL(19,2),
				ROUND(
					  mandatedetail.taxable*
					  mandatedetail.npackage*
					  CONVERT(DECIMAL(19,6),mandate.exchangerate)*
					  (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0))),2
  					 )
			)
		) 
ELSE
		SUM(
			CONVERT(DECIMAL(19,2),
				ROUND(
					  mandatedetail.taxable*
					  mandatedetail.npackage*
					  CONVERT(DECIMAL(19,6),mandate.exchangerate)*
					  (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0))),2
  					 )
			)+
			ROUND(mandatedetail.tax,2) 
		)
END,
----------------------------------------------------------------------------------------------------------
--------------------------------------- ORDINI IN VALUTA ESTERA ------------------------------------------
----------------------------------------------------------------------------------------------------------
SUM(
	CONVERT(DECIMAL(19,2),
		ROUND(
			  mandatedetail.taxable*
			  mandatedetail.npackage*
			  (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0))),2
			 )
	) 
),
-- Il campo totaleriga in valuta estera  deve essere calcolato come la somma dell'imponibile scontato + l'iva 
CASE 
WHEN ( mandate.flagintracom<>'N')-- AND idcurrency NOT IN (select idcurrency from currency where codecurrency = 'ITL' OR codecurrency = 'EUR'))
THEN  
-- non considera iva
		SUM(
			CONVERT(DECIMAL(19,2),
				ROUND(
					  mandatedetail.taxable*
					  mandatedetail.npackage*
					  (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0))),2
  					 )
			)
		) 
ELSE
		SUM(
			CONVERT(DECIMAL(19,2),
				ROUND(
					  mandatedetail.taxable*
					  mandatedetail.npackage*
					  (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0))),2
  					 )
			)+
			ROUND(mandatedetail.tax,2) 
		)
END,
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
mandatedetail.flagactivity,
mandatedetail.idreg,
ISNULL(mandatedetail.cupcode,upb.cupcode),
mandatedetail.cigcode
FROM mandatedetail
LEFT OUTER JOIN expenseyear
		ON mandatedetail.idexp_taxable = expenseyear.idexp
		AND mandatedetail.yman = expenseyear.ayear
LEFT OUTER JOIN upb
		ON expenseyear.idupb = upb.idupb
JOIN mandate
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind
WHERE   mandatedetail.yman = @ayear
	AND mandatedetail.idmankind= @mandatekind
	AND mandatedetail.nman in (SELECT nman FROM #printing)
GROUP BY mandatedetail.yman,mandatedetail.nman,mandatedetail.idmankind,mandatedetail.rownum,
	flagintracom,idcurrency,detaildescription,mandatedetail.annotations,
	npackage,taxrate,discount, mandatedetail.start, mandatedetail.stop,idgroup,mandatedetail.flagactivity,mandatedetail.idreg,mandatedetail.cupcode, upb.cupcode, mandatedetail.cigcode

UPDATE #mandate SET cigcode = NULL
			WHERE (select count(*) from #mandatedetail D
					where D.idmankind= #mandate.idmankind
					and D.yman = #mandate.yman
					and D.nman = #mandate.nman
					and D.cigcodedetail is not null
					and D.cigcodedetail <> #mandate.cigcode )>=1
					
-- Valorizza cupcode idealmente come cup del mandate, se i dettagli hanno tutti lo stesso cup
UPDATE #mandate SET cupcode = (select top 1 D.cupcodedetail from #mandatedetail D
					where D.idmankind= #mandate.idmankind
					and D.yman = #mandate.yman
					and D.nman = #mandate.nman
					and D.cupcodedetail is not null )
			WHERE not exists (select count(*) from #mandatedetail D
					join #mandatedetail D2
						on D.idmankind= D2.idmankind and D.yman = D2.yman and D.nman = D2.nman
					where D.idmankind= #mandate.idmankind
					and D.yman = #mandate.yman
					and D.nman = #mandate.nman
					and D.cupcode <> D2.cupcode)
					or
					(select count(*) from #mandatedetail D
					where D.idmankind= #mandate.idmankind
					and D.yman = #mandate.yman
					and D.nman = #mandate.nman
					and D.cigcodedetail is not null )=1

-- Poi nella select finale prende cigcode oppure cigcodedetail, idem per il cup. Prende o il principale o il dettaglio

declare @introduzioneconsipkind varchar(600)
select @introduzioneconsipkind = isnull(description,'') from consipkind where idconsipkind = 10--> Il 10 indica la frase introduttiva!

SELECT 
	#mandate.yman,
	#mandate.nman,
	mandatekind.description AS mandatekind,
	#mandatedetail.rownum,
	mandate.description ,
	mandatekind.office,
	mandatekind.phonenumber AS phonenumber_office,
	mandatekind.faxnumber AS faxnumber_office,
	mandatekind.email AS email_office,
	mandatekind.title_l,   -- sezione firme
	mandatekind.name_l,
	mandatekind.title_c,
	mandatekind.name_c,
	mandatekind.title_r,
	mandatekind.name_r,
	mandatekind.notes1, -- annotazioni
	mandatekind.notes2,
	mandatekind.notes3,
	mandatekind.header,
	mandatekind.address as dep_address,
	mandate.adate,
	#mandate.idreg ,
	registry.title ,
	registry_detail.title as registry_detail_title,
	#address_mandate.officename,
	#address_mandate.address,
	#address_mandate.location,
	#address_mandate.cap,
	#address_mandate.province,
	#address_mandate.nation,
	registryreference.phonenumber as phone,
	registryreference.faxnumber as fax,
	registryreference.mobilenumber as mobilenumber,
	registryreference.email,
	registry.p_iva,
	registry.cf,
	REPLACE(expirationkind.shorttitle,'%',isnull(mandate.paymentexpiring,'')) as expiration,
	mandate.registryreference ,
	mandate.deliveryexpiration ,
	mandate.deliveryaddress ,
	manager.title as manager,
	currency.codecurrency as idcurrency ,
	#mandate.exchangerate,
	#mandate.cigcode,
	case when #mandate.cigcode is null then #mandatedetail.cigcodedetail
		else null
	end as 'cigcodedetail',
	#mandate.cupcode,
	case when #mandate.cupcode is null then #mandatedetail.cupcodedetail
		else null
	end as 'cupcodedetail',
	ISNULL(#mandatedetail.detaildescription,'') + ' ' + ISNULL(#mandatedetail.annotations,'') AS uniondescr,
	ISNULL(#mandatedetail.npackage, 0) as number ,
	ISNULL(#mandatedetail.taxable, 0) as taxable ,
	ISNULL(#mandatedetail.taxrate, 0) as taxrate,
	ISNULL(#mandatedetail.discount, 0)as discount ,
	CASE 
			WHEN ((currency.codecurrency IS NULL) OR (currency.codecurrency = 'ITL') OR (currency.codecurrency = 'EUR')) THEN 'N' 
			ELSE 'S'
		END 
	as is_english,
	#mandatedetail.start,
	#mandatedetail.stop,

	isnull(#mandatedetail.rowtaxable,0) as rowtaxable,
	mandate.txt as notes,
	isnull(#mandatedetail.totalrow,0) as totalrow,
	isnull(#mandatedetail.rowtaxable_fcurrency,0) as rowtaxable_fcurrency,
	isnull(#mandatedetail.totalrow_fcurrency,0) as totalrow_fcurrency,
	#mandate.numannulled,
	#mandate.numintegration,
	case
	when #mandatedetail.flagactivity ='1' then 'i'
	when #mandatedetail.flagactivity ='2' then 'c'
	when #mandatedetail.flagactivity ='3' then 'p'
	when #mandatedetail.flagactivity ='4' then 'n'
	end AS flagactivity,
	#mandatedetail.idreg_detail,
	@labelinenglish as labelinenglish,
	CASE 
			WHEN ((residence.coderesidence = 'I') OR (residence.coderesidence = 'U')) THEN 'N' 
			ELSE 'S'
		END 
	as is_vat,
	mandate.idconsipkind,
	@introduzioneconsipkind as introduzioneconsipkind,
	consipkind.description as 'consipkind' ,
	mandate.flagintracom,
	#mandate.sortcodestuttura,
	#mandate.sortstuttura,
	#mandate.sortcodefirma,
	#mandate.sortfirma,
	#mandate.sortcoderichiedente,
	#mandate.sortrichiedente,
	mandate.subappropriation,
	mandate.finsubappropriation,
	mandate.adatesubappropriation,
	mandatekind.riferimento_amministrazione
FROM #mandate
JOIN mandate
	ON mandate.yman = #mandate.yman
	AND mandate.nman = #mandate.nman
	and mandate.idmankind = #mandate.idmankind
JOIN mandatekind  
	ON #mandate.idmankind = mandatekind.idmankind 
JOIN #mandatedetail
	ON #mandate.yman = #mandatedetail.yman
	AND #mandate.nman = #mandatedetail.nman
	AND #mandate.idmankind = #mandatedetail.idmankind
LEFT OUTER JOIN registry
	ON #mandate.idreg = registry.idreg
LEFT OUTER JOIN registry as registry_detail
	ON #mandatedetail.idreg_detail = registry_detail.idreg
LEFT OUTER JOIN manager
	ON manager.idman = #mandate.idman
LEFT OUTER JOIN registryreference
	ON registryreference.idreg = #mandate.idreg
	AND registryreference.flagdefault = 'S'
LEFT OUTER JOIN residence 
	ON registry.residence = residence.idresidence
LEFT OUTER JOIN expirationkind 
	ON expirationkind.idexpirationkind = #mandate.idexpirationkind
LEFT OUTER JOIN #address_mandate
	ON #mandate.idreg = #address_mandate.idreg
LEFT OUTER JOIN currency
	ON currency.idcurrency = #mandate.idcurrency
LEFT OUTER JOIN consipkind
	ON consipkind.idconsipkind = mandate.idconsipkind
WHERE #mandatedetail.start is null 
ORDER BY #mandate.nman, #mandatedetail.idgroup
	
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--exec rpt_buono_ordine_bari 2014, 'I', 'CICCIO-CP', 3, 4, NULL, 'N',  'N', 51,52,53,null, null, null, null, null
