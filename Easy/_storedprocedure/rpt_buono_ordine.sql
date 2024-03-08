
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

CREATE      PROCEDURE [rpt_buono_ordine]
	@ayear int,
	@printkind char(1),
	@mandatekind varchar(20),
	@startnman int,
	@stopnman int,
	@idman int,
	@official char(1),
	@includevariation char(1), 
	@variationdate smalldatetime,
	@labelinenglish char(1),
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int

AS BEGIN
 
-- setuser 'amministrazione'
-- exec rpt_buono_ordine 2021, 'X', 'SCMT_ContrPass', 1, 1, NULL, 'N', 'N', {ts '2021-12-31 00:00:00'}, 'N', NULL, NULL, NULL, NULL, NULL
IF (@ayear=0)
BEGIN
	SET @ayear='1900'
END

--modifiche task 10093
declare @flag int;
set @flag = (select flag from uniconfig);
--fine modifiche task 10093

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
	currtotalamount decimal(19,2),
	showiva decimal(19,6),
	idreg_rupanac int,
)

CREATE TABLE #printing
(
	idmankind varchar(20),
	nman int  
)
IF @printkind = 'A' 
	INSERT INTO #printing (idmankind,nman) 
	SELECT mandate.idmankind, mandate.nman from  mandate   join mandatekind  ON mandatekind.idmankind = mandate.idmankind  
	where (yman=@ayear) and (mandate.idmankind = @mandatekind) AND (officiallyprinted <>'S')
								and (	(@idman is not null  AND idman = @idman ) OR (@idman is null)	)
	AND (isnull(mandate.idsor01,mandatekind.idsor01) = @idsor01 OR @idsor01 IS NULL)
	AND (isnull(mandate.idsor02,mandatekind.idsor02) = @idsor02 OR @idsor02 IS NULL)
	AND (isnull(mandate.idsor03,mandatekind.idsor03) = @idsor03 OR @idsor03 IS NULL)
	AND (isnull(mandate.idsor04,mandatekind.idsor04) = @idsor04 OR @idsor04 IS NULL)
	AND (isnull(mandate.idsor05,mandatekind.idsor05) = @idsor05 OR @idsor05 IS NULL)
	
IF @printkind  <> 'A'
	INSERT INTO #printing (idmankind,nman) 
	SELECT mandate.idmankind, mandate.nman  from  mandate join mandatekind  ON mandatekind.idmankind = mandate.idmankind  where (yman=@ayear) and (mandate.idmankind = @mandatekind) 
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
	cigcode,
	showiva,
	idreg_rupanac
	)
SELECT 
	mandate.yman,
	mandate.nman,
	mandate.idmankind,
	mandate.idreg,
	mandate.idexpirationkind,
	mandate.idcurrency,
	mandate.exchangerate,
	mandate.idman,
	0,
	0,
	cigcode,
	case when isnull(mandate.flagintracom,'N')='N' then 1 else null end,
	mandate.idreg_rupanac
FROM mandate
JOIN #printing 
ON   #printing.idmankind = mandate.idmankind
AND  #printing.nman = mandate.nman
WHERE mandate.yman = @ayear


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
CREATE TABLE #mandatedetail_det
(
	yman int,
	nman int,
	idmankind varchar(20),
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
	cupcode varchar(30),
	cigcodedetail varchar(10),
	cupcode_byidgroup varchar(400),
	yepexp smallint,
	nepexp int,
	codemotive varchar(50),
	accmotive varchar(150),

	epexp_amount decimal(19,2),
	idexp_taxable int,/*vale 0 o null*/	--modifica task 10093
	idepexp int, --modifica task 10093
	epexp_byidgroup varchar(400),
	idexp_byidgroup int,
	ivadescription varchar(50) ,--task 10649
	rownum_main int

)


INSERT INTO #mandatedetail_det
(
	yman,
	nman,
	idmankind ,
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
	cupcode,
	cigcodedetail,
	yepexp, nepexp,
	codemotive,	accmotive, 
	epexp_amount,
	idexp_taxable, --modifica task 10093
	idepexp, --modifica task 10093

	ivadescription, --task 10649
	rownum_main
)
SELECT 
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idmankind,
	detaildescription,
	mandatedetail.annotations,
	npackage,
	isnull(sum(taxable),0),
	CASE	
		WHEN ( mandate.flagintracom <> 'N') --AND idcurrency NOT IN (select idcurrency from currency where codecurrency = 'ITL' OR codecurrency = 'EUR'))
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
WHEN ( mandate.flagintracom<>'N' ) -- AND idcurrency NOT IN (select idcurrency from currency where codecurrency = 'ITL' OR codecurrency = 'EUR'))
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
WHEN ( mandate.flagintracom<>'N' ) --AND idcurrency NOT IN (select idcurrency from currency where codecurrency = 'ITL' OR codecurrency = 'EUR'))
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
mandatedetail.cigcode,
epexp.yepexp, epexp.nepexp,
accmotive.codemotive, accmotive.title,

epexptotal.curramount,
mandatedetail.idexp_taxable, --modifica task 10093
mandatedetail.idepexp, --modifica task 10093
ivakind.description, --task 10649
mandatedetail.rownum_main
FROM mandatedetail
JOIN mandate
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind
JOIN #printing 
	ON   #printing.idmankind = mandate.idmankind AND  #printing.nman = mandate.nman
LEFT OUTER JOIN expenseyear
		ON mandatedetail.idexp_taxable = expenseyear.idexp
		AND mandatedetail.yman = expenseyear.ayear
LEFT OUTER JOIN upb
		ON expenseyear.idupb = upb.idupb
LEFT OUTER JOIN epexp
		on epexp.idepexp = mandatedetail.idepexp
LEFT OUTER JOIN epexptotal 
		on epexp.idepexp= epexptotal.idepexp and epexptotal.ayear = @ayear
LEFT OUTER JOIN accmotive
	on accmotive.idaccmotive = mandatedetail.idaccmotive
LEFT OUTER JOIN ivakind --task 10649
	on mandatedetail.idivakind = ivakind.idivakind
WHERE mandate.yman = @ayear
GROUP BY mandatedetail.yman,mandatedetail.nman,mandatedetail.idmankind,flagintracom,idcurrency,detaildescription, mandatedetail.annotations,
	npackage,taxrate,discount, mandatedetail.start, mandatedetail.stop,idgroup,mandatedetail.flagactivity,mandatedetail.idreg,mandatedetail.cupcode, upb.cupcode, mandatedetail.cigcode,
	epexp.yepexp, epexp.nepexp,accmotive.codemotive, accmotive.title,
	epexptotal.curramount,
	mandatedetail.idexp_taxable, --modifica task 10093
	mandatedetail.idepexp --modifica task 10093
	,ivakind.description, --task 10649
	mandatedetail.rownum_main

--SELECT totalrow, * FROM #mandatedetail_det

UPDATE #mandate SET cigcode = NULL
			WHERE (select count(*) from #mandatedetail_det D
					where D.idmankind= #mandate.idmankind
					and D.yman = #mandate.yman
					and D.nman = #mandate.nman
					and D.cigcodedetail is not null
					and D.cigcodedetail <> #mandate.cigcode )>=1
					-- and D.cigcodedetail is not null)>=1
	
-- Concatena i vari codice CUP, affinchè la riga splittata, ritorni una nella stampa. Vedi task 5874. 
DECLARE @nman int
DECLARE @idgroup int 
declare @cupcode varchar(15)
DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT nman, idgroup, cupcode FROM #mandatedetail_det
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @nman,  @idgroup, @cupcode
 
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#mandatedetail_det set
	  cupcode_byidgroup = case when @cupcode is not null then isnull(cupcode_byidgroup,'') +'Cod. CUP:' +isnull(convert(varchar(15),@cupcode),'')+'. '
							--else isnull(cupcode_byidgroup,'')
							else cupcode_byidgroup
							end
	 WHERE nman = @nman and idgroup = @idgroup 

		FETCH NEXT FROM cursore 
		INTO @nman,  @idgroup, @cupcode
	END
CLOSE cursore

/*SELECT nman, idgroup, idepexp, yepexp, nepexp, epexp_amount FROM #mandatedetail_det
	where not exists (select * from #mandatedetail_det m where m.yman = @ayear and m.nman = #mandatedetail_det.nman and m.idgroup = #mandatedetail_det.idgroup and m.idepexp is null) 
	*/
	/*SELECT nman, idgroup, idepexp, yepexp, nepexp, epexp_amount FROM #mandatedetail_det
	where (select count(*) from #mandatedetail_det m where m.yman = @ayear and m.nman = #mandatedetail_det.nman and m.idgroup = #mandatedetail_det.idgroup and m.idepexp is null) = 0
	*/
-- Concatena i vari Impegni di budget, affinchè la riga splittata, ritorni una nella stampa ( epexp_byidgroup )


DECLARE @idepexp int
declare @epexp_amount decimal(19,2)
declare @yepexp smallint
declare @nepexp int
DECLARE cursoreidepexp CURSOR FORWARD_ONLY for 
	SELECT nman, idgroup, idepexp, yepexp, nepexp, epexp_amount FROM #mandatedetail_det
	where (select count(*) from #mandatedetail_det m where m.yman = @ayear and m.nman = #mandatedetail_det.nman and m.idgroup = #mandatedetail_det.idgroup and m.idepexp is null) = 0
		OPEN cursoreidepexp
	FETCH NEXT FROM cursoreidepexp 
	INTO @nman, @idgroup, @idepexp, @yepexp, @nepexp, @epexp_amount
 
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#mandatedetail_det set
	  epexp_byidgroup = case when @idepexp is not null 
									then isnull(epexp_byidgroup,'')	+'Eserc.:' +isnull(convert(varchar(15),@yepexp),'')
																		+' N.:' +isnull(convert(varchar(15),@nepexp),'')+
																		+' Importo.:' + isnull(convert(varchar(15),@epexp_amount),'')+'; '
							else epexp_byidgroup
							end
	 WHERE nman = @nman and idgroup = @idgroup 

		FETCH NEXT FROM cursoreidepexp 
		INTO @nman,  @idgroup, @idepexp, @yepexp, @nepexp, @epexp_amount
	END
CLOSE cursoreidepexp
-- Pone idexp_byidgroup, simbolicamente a 1, se c'è l'impegno, non può mettere il vero impegno perchè se i dettagli avessero impegni diversi, a parità di idgroup, si vedrebbe lo split nella stampa.
DECLARE @idexp int
DECLARE cursoreidexp CURSOR FORWARD_ONLY for 
	SELECT nman, idgroup, idepexp FROM #mandatedetail_det
	where (select count(*) from #mandatedetail_det m where m.yman = @ayear and m.nman = #mandatedetail_det.nman and m.idgroup = #mandatedetail_det.idgroup and m.idexp_taxable is null) = 0
		OPEN cursoreidexp
	FETCH NEXT FROM cursoreidexp 
	INTO @nman, @idgroup, @idexp
 
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#mandatedetail_det set
								idexp_byidgroup = 1
	 WHERE nman = @nman and idgroup = @idgroup 

		FETCH NEXT FROM cursoreidexp 
		INTO @nman,  @idgroup, @idexp
	END
CLOSE cursoreidexp

--select idexp_taxable,idexp_byidgroup,epexp_byidgroup,* from #mandatedetail_det 

--select idexp_taxable,idexp_byidgroup,* from #mandatedetail_det 
--			WHERE  (select count(*) from #mandatedetail_det m
--				where m.yman = @ayear and m.nman = #mandatedetail_det.nman and m.idgroup = #mandatedetail_det.idgroup and m.idexp_taxable is null) > 0


-- Pone a null il campo idexp_byidgroup ove vi siano fratelli non contabilizzati nel finanziario
UPDATE #mandatedetail_det SET idexp_byidgroup = NULL
			WHERE  (select count(*) from #mandatedetail_det m
				where m.yman = @ayear and m.nman = #mandatedetail_det.nman and m.idgroup = #mandatedetail_det.idgroup and m.idexp_taxable is null) > 0


CREATE TABLE #mandatedetail
(
	yman int,
	nman int,
	idmankind varchar(20),
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
	cupcode varchar(15),
	cigcodedetail varchar(10),
	cupcode_byidgroup varchar(400),
	codemotive varchar(50),	accmotive varchar(150),

	idexp_byidgroup int, 
	epexp_byidgroup varchar(400),
	ivadescription varchar(50), --task 10649
	rownum_main int

)
insert into #mandatedetail(
	yman,
	nman,
	idmankind,
	detaildescription,
	annotations,
	npackage,
	taxable,
	taxrate,
	tax,
	discount,
	start,
	stop,
	idgroup,
	rowtaxable,
	totalrow,
	rowtaxable_fcurrency,
	totalrow_fcurrency,
	flagactivity,
	idreg_detail,
	cigcodedetail,
	cupcode_byidgroup,
	codemotive,	accmotive, 

	idexp_byidgroup,
	epexp_byidgroup,
	ivadescription, --task 10649
	rownum_main

)
select 	yman, 
	nman,
	idmankind,
	detaildescription,
	annotations,
	npackage,
	sum(taxable),
	taxrate,
	tax,
	discount,
	start,
	stop,
	idgroup,
	sum(rowtaxable),
	sum(totalrow),
	sum(rowtaxable_fcurrency),
	sum(totalrow_fcurrency),
	flagactivity,
	idreg_detail,
	cigcodedetail,
	cupcode_byidgroup,
	codemotive,	accmotive ,

	#mandatedetail_det.idexp_byidgroup, 
	epexp_byidgroup,
	#mandatedetail_det.ivadescription, --task 10649
	#mandatedetail_det.rownum_main
from #mandatedetail_det
group by yman,	nman,	idmankind,	detaildescription,	annotations,	
	npackage,		taxrate,	tax,	discount,
	start,	stop,	idgroup,
	flagactivity,	idreg_detail,	cigcodedetail,cupcode_byidgroup,
	codemotive,	accmotive,
	epexp_byidgroup,
	#mandatedetail_det.idexp_byidgroup,
	ivadescription, --task 10649 
	rownum_main
declare @introduzioneconsipkind varchar(600)
select @introduzioneconsipkind = isnull(description,'') from consipkind where idconsipkind = 10--> Il 10 indica la frase introduttiva!


UPDATE #mandate 
SET currtotalamount = ( select sum (#mandatedetail.totalrow) from #mandatedetail
									WHERE #mandate.yman = #mandatedetail.yman
										AND #mandate.nman = #mandatedetail.nman
										AND #mandate.idmankind = #mandatedetail.idmankind
										AND (#mandatedetail.stop is null OR #mandatedetail.stop > @variationdate )
										AND (#mandatedetail.start is null OR #mandatedetail.start <= @variationdate )
										)
where ( select count(*) from #mandatedetail
			WHERE #mandate.yman = #mandatedetail.yman
				AND #mandate.nman = #mandatedetail.nman
				AND #mandate.idmankind = #mandatedetail.idmankind
				AND #mandatedetail.start is not  null   
				AND #mandatedetail.start <= @variationdate)>=1 -- se ci sono integrazioni
				or
	( select count(*) from #mandatedetail
			WHERE #mandate.yman = #mandatedetail.yman
				AND #mandate.nman = #mandatedetail.nman
				AND #mandate.idmankind = #mandatedetail.idmankind
				AND #mandatedetail.stop is not  null      
				AND #mandatedetail.stop <= @variationdate)>=1 -- oppure ci sono annullamenti
				
SELECT 
	#mandate.yman,
	#mandate.nman,
	mandatekind.idmankind,
	mandatekind.description AS mandatekind,
	mandate.description,
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
	CONVERT(datetime, mandate.adate)  as adate, 
	#mandate.idreg ,
	#mandate.idreg_rupanac,
	registry.title ,
	CASE 
		WHEN ISNULL(mandatekind.multireg,'N') = 'S' THEN registry_detail.title
		ELSE NULL
	END as registry_detail_title,
	registry_rupanac.title as registry_rupanac_title,
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
	#mandate.exchangerate ,
	CASE 

		WHEN (@flag&8 <> 0 AND @flag&4 <> 0 AND #mandatedetail.epexp_byidgroup IS NULL AND #mandatedetail.idexp_byidgroup IS NULL) THEN 'Dett. privo di Impegno di Budget e Finanziario' --modifiche task 10093
		WHEN (@flag&4 <> 0 AND #mandatedetail.idexp_byidgroup IS NULL) THEN 'Dettaglio privo di Impegno Finanziario' --modifiche task 10093
		WHEN (@flag&8 <> 0 AND #mandatedetail.epexp_byidgroup IS NULL) THEN 'Dettaglio privo di Impegno di Budget' --modifiche task 10093
		
		 WHEN (#mandatedetail.cupcode_byidgroup IS NOT NULL ) and (#mandatedetail.cigcodedetail IS NOT NULL)
			THEN ISNULL(#mandatedetail.detaildescription,'') + ' ' + ISNULL(#mandatedetail.annotations,'') + char(13)+' ' + #mandatedetail.cupcode_byidgroup+ char(13)+'Cod. CIG: ' + #mandatedetail.cigcodedetail

		 WHEN (#mandatedetail.cupcode_byidgroup IS NOT NULL ) and (#mandatedetail.cigcodedetail IS NULL)
			THEN ISNULL(#mandatedetail.detaildescription,'') + ' ' + ISNULL(#mandatedetail.annotations,'') + char(13)+' ' + #mandatedetail.cupcode_byidgroup

		 WHEN (#mandatedetail.cupcode_byidgroup IS NULL ) and (#mandatedetail.cigcodedetail IS NOT NULL)
			THEN ISNULL(#mandatedetail.detaildescription,'') + ' ' + ISNULL(#mandatedetail.annotations,'') + char(13)+'Cod. CIG: ' + #mandatedetail.cigcodedetail

		 ELSE ISNULL(#mandatedetail.detaildescription,'') + ' ' + ISNULL(#mandatedetail.annotations,'')
	END AS uniondescr,
	
	--modifiche task 10093
	CASE
	WHEN (@flag&4 <> 0 AND #mandatedetail.idexp_byidgroup IS NULL) then NULL 
	WHEN (@flag&8 <> 0 AND #mandatedetail.epexp_byidgroup IS NULL) then NULL
	ELSE ISNULL(#mandatedetail.npackage, 0)
	END as number,

	CASE
	WHEN (@flag&4 <> 0 AND #mandatedetail.idexp_byidgroup IS NULL) then NULL 
	WHEN (@flag&8 <> 0 AND #mandatedetail.epexp_byidgroup IS NULL) then NULL
	ELSE ISNULL(#mandatedetail.taxable, 0)
	END as taxable,

	CASE
	WHEN (@flag&4 <> 0 AND #mandatedetail.idexp_byidgroup IS NULL) then NULL 
	WHEN (@flag&8 <> 0 AND #mandatedetail.epexp_byidgroup IS NULL) then NULL
	ELSE ISNULL(#mandatedetail.taxrate, 0)
	END as taxrate,
	--fine modifiche task 10093
	 
	ISNULL(#mandatedetail.discount, 0)as discount ,
	CASE 
			WHEN ((currency.codecurrency IS NULL) OR (currency.codecurrency = 'ITL') OR (currency.codecurrency = 'EUR')) THEN 'N' 
			ELSE 'S'
		END 
	as is_english,
	#mandatedetail.start,
	#mandatedetail.stop,
	
	--modifiche task 10093
	CASE
	WHEN (@flag&4 <> 0 AND #mandatedetail.idexp_byidgroup IS NULL) then NULL 
	WHEN (@flag&8 <> 0 AND #mandatedetail.epexp_byidgroup IS NULL) then NULL
	ELSE isnull(#mandatedetail.rowtaxable,0) 
	END as rowtaxable,
	--fine modifiche task 10093
	
	mandate.txt as notes,
-- Il campo totaleriga deve essere calcolato come la somma dell'imponibile scontato + l'iva 
	
	--modifiche task 10093
	CASE
		WHEN (@flag&4 <> 0 AND #mandatedetail.idexp_byidgroup IS NULL) then NULL 
		WHEN (@flag&8 <> 0 AND #mandatedetail.epexp_byidgroup IS NULL) then NULL
	ELSE isnull(#mandatedetail.totalrow,0)
	END as totalrow,
	--fine modifiche task 10093

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
	isnull(#mandate.cigcode,'') AS cigcode,
	CASE 
			WHEN ((residence.coderesidence = 'I') OR (residence.coderesidence = 'U')) THEN 'N' 
			ELSE 'S'
		END 
	as is_vat,
	mandate.idconsipkind,
	@introduzioneconsipkind as introduzioneconsipkind,
	consipkind.description as 'consipkind' ,
	ISNULL(consipkind.flagpurchaseperformed,'S')  as 'flagpurchaseperformed' ,
	mandate.flagintracom,
	mandatekind.riferimento_amministrazione,
	mandatekind.ipa_fe,
	isnull(#mandate.currtotalamount,0) as currtotalamount,
	#mandatedetail.codemotive, #mandatedetail.accmotive
	,#mandatedetail.ivadescription, --task 10649
	 #mandatedetail.epexp_byidgroup
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
LEFT OUTER JOIN registry as registry_rupanac
	ON #mandate.idreg_rupanac = registry_rupanac.idreg
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
where ( #mandatedetail.rownum_main is null and #mandatedetail.stop is null)
ORDER BY  #mandate.idmankind, #mandate.nman, #mandatedetail.idgroup
	
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
