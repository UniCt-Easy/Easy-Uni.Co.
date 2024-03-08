
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fabbisognoresiduo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fabbisognoresiduo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'
/*
Fabbisogno Residuo = Fabbisogno assegnato + A - D

A: incassi  con Siope diverso dell'insieme allegato
C: incassi  con Siope compreso nell'insieme allegato
B :Incassi '2010101001' che NON concorrono al calcolo del fabbisogno
D: pagamenti (pagamenti che non rientrano ne in D ne in E)
E: pagamenti con Siope compreso nell'insieme allegato e senza COFOG
F: pagamenti con COFOG

*/
--exec exp_fabbisognoresiduo 2020,{ts '2020-12-31 00:00:00'},'%'
CREATE procedure exp_fabbisognoresiduo( 
	@ayear int,
	@adate datetime,
	@idupb varchar(36)='%',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	) as
begin
 
DECLARE @idsorkindE int
SELECT  @idsorkindE = idsorkind FROM sortingkind  WHERE codesorkind ='SIOPE_E_18' 

DECLARE @idsorkindS int
SELECT  @idsorkindS = idsorkind FROM sortingkind  WHERE codesorkind ='SIOPE_U_18' 

declare @maxexpensephase varchar(50)
set @maxexpensephase  = (select top 1 description from expensephase order by nphase desc)

declare @maxincomephase varchar(50)
set @maxincomephase  = (select top 1 description from incomephase order by nphase desc)


-- ======================================================================
--							TABELLA SIOPE ES
-- ======================================================================
create table #siopeES (
	idsor int, 
	e_s  char(1)
)


-- ======================================================================
--							INSERT SIOPE ES
-- ======================================================================
insert into #siopeES (idsor, e_s)
	select idsor, 'e' from sorting
	where idsorkind = @idsorkindE
	and sortcode in (
	'4020101003','4020101001','4020601001','4020101014','4020101004','4020101005','4020101006','4020101007','4020101008','4020101009','4020101010','4020101011','4020101012','4020101999','4020601999','4031001001','4031001003','4031001004','4031001005',
	'4031001006','4031001007','4031001008','4031001009','4031001010','4031001011','4031001012','4031001999','4020501001','4020503001','4020504001','4020505001','4020599999','4021001001','4031401001','4020507001','4031402001','4020102001','4020602001',
	'4031002001','4020102002','4031002002','4020102004','4031002004','4020102003','4031002003','4020102006','4031002006','4020102005','4031002005','4020102011','4031002011','4020102012','4031002012','4020102014','4031002014','4020103001','4020103002',
	'4020103999','4031003001','4031003002','4031003999','4020101013','4020102007','4031002007','4020102010','4031002010','4020102999','4020102008','4031002008','4020102009','4031002009','4020102017','4020102018','4020102019','4020102999','4031002015',
	'4031002016','4031002017','4031002018','4031002019','4031002999','4020301001','4020302001','4031201001','4031202001','4020303999','4031299001','4020201001','4031101001','4020401001','4031301001','4020102013','4031002013','4020101013','4031001013')

insert into #siopeES (idsor, e_s)
	select idsor, 's' from sorting
	where idsorkind = @idsorkindS
	and sortcode in (
	'1030207006','1030207007','2020201001','2020201002','2020109019','2020109999','2020109005','2020110009','2020109007','2020109016','2020201999','2020305001','2020306001','2020306999','2020101001','2020101003','2020401001','2020401003','2020103001',
	'2020103003','2020403001','2020107004','2020107999','2020407999','2020104001','2020105001','2020105002','2020105999','2020106001','2020404001','2020405001','2020405002','2020405999','2020406001','2020107001','2020407001','2020107002','2020107005',
	'2020407002','2020199001','2020103002','2020403002','2020104002','2020107004','2020107003','2020407003','2020407004','2020404002','2020302001','2020302002','2020111001','2020399001','2020103999','2020199002','2020199999','2020403999','2020499999','
	2020303001','2020304001','2020409999','2059999999')


-- ======================================================================
--						TABELLA PAGAMENTI_INCASSI
-- ======================================================================
create table #pagamentiincassi(
	idinc int,
	idexp int,
	incassiA_siopediverso decimal(19,2),		-- A: incassi  con Siope diverso dell'insieme allegato
	incassiB_siopenofabb decimal(19,2),			-- B : Incassi da trasferimenti correnti da Ministeri che NON concorrono al calcolo del fabbisogno
	incassiC_siopecompreso decimal(19,2),		-- C: incassi  con Siope compreso nell'insieme allegato
	pagamentiD decimal(19,2),					-- D: pagamenti (pagamenti che non rientrano ne in E ne in F)
	pagamentiE_siopecompreso decimal(19,2),		-- E: pagamenti con Siope compreso nell'insieme allegato e senza COFOG
	pagamentiF_Cofog decimal(19,2),				-- F: pagamenti con COFOG
	npay_npro int, 
	idupb varchar(36),
	idsor int,
	cofog varchar(20),
	cod_ue varchar(20),
	kind_ES varchar(50),						-- E entrata, S spesa
	kind_mov varchar(50),						-- I incassi, P pagamenti, T totali singole colonne 
	movdescription varchar(300),
	streamdate datetime,
	billdate datetime)


-- ======================================================================
-- A: incassi  con Siope diverso dell'insieme allegato
-- ======================================================================
insert into  #pagamentiincassi(
	idinc,
	idupb,
	incassiA_siopediverso,
	npay_npro, 
	idsor,
	cod_ue,
	kind_ES,
	kind_mov,			-- I incasso, VI var.incasso, P pagamento, PV var.pagamento
	movdescription,
	streamdate,
	billdate)
SELECT
	IL.idinc,
	IY.idupb,
	ES.amount,
	P.npro,
	ES.idsor,
	ES.values1,
	'E','I',
	@maxincomephase +' n.'+ convert(varchar(10),I.nmov) +'. '+I.description,
	PT.streamdate,
	CASE
		WHEN IL.nbill IS NOT NULL
			THEN (SELECT adate FROM bill where bill.billkind = 'C' AND bill.ybill = @ayear AND bill.nbill = IL.nbill)
		WHEN IL.nbill IS NULL
			THEN (SELECT top 1 adate FROM bill JOIN incomebill ON bill.billkind = 'C' AND bill.ybill =incomebill.ybill AND bill.nbill = incomebill.nbill where IL.idinc = incomebill.idinc AND bill.ybill = @ayear AND bill.nbill = incomebill.nbill)
	END
FROM income I
	join incomelast IL on I.idinc = IL.idinc
	join incomeyear IY on IL.idinc = IY.idinc
	JOIN upb U ON IY.idupb = U.idupb
	JOIN incomesorted ES ON ES.idinc = IY.idinc
	join sorting S on ES.idsor = S.idsor
	join proceeds P on IL.kpro = P.kpro
	left outer join proceedstransmission PT on PT.kproceedstransmission = P.kproceedstransmission
	left outer join #siopeES TS on TS.idsor = ES.idsor and TS.e_s='E'
WHERE IY.ayear = @ayear
	AND I.adate <= @adate
	AND (IY.idupb LIKE @idupb)
	AND S.idsorkind = @idsorkindE
	and TS.idsor is null
	and S.sortcode <>'2010101001' -- Viene considerato nella colonna successiva 'incassiB_siopenofabb'
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)


-- ======================================================================
-- B new: "Incassi da trasferimenti correnti da Ministeri che NON concorrono al calcolo del fabbisogno" 
-- ======================================================================
insert into  #pagamentiincassi(
	idinc,
	idupb,
	incassiB_siopenofabb,
	npay_npro, 
	idsor,
	cod_ue,
	kind_ES,kind_mov,
	movdescription,
	streamdate,
	billdate)
SELECT
	IL.idinc,
	IY.idupb,
	ES.amount,
	P.npro,
	ES.idsor,
	ES.values1,
	'E','I',
	@maxincomephase +' n.'+ convert(varchar(10),I.nmov) +'. '+I.description,
	PT.streamdate,
	CASE
		WHEN IL.nbill IS NOT NULL
			THEN (SELECT adate FROM bill where bill.billkind = 'C' AND bill.ybill = @ayear AND bill.nbill = IL.nbill)
		WHEN IL.nbill IS NULL
			THEN (SELECT top 1 adate FROM bill JOIN incomebill ON bill.billkind = 'C' AND bill.ybill =incomebill.ybill AND bill.nbill = incomebill.nbill where IL.idinc = incomebill.idinc AND bill.ybill = @ayear AND bill.nbill = incomebill.nbill)
	END
FROM income I
	join incomelast IL on I.idinc = IL.idinc
	join incomeyear IY on IL.idinc = IY.idinc
	JOIN upb U ON IY.idupb = U.idupb
	JOIN incomesorted ES ON ES.idinc = IY.idinc
	join sorting S on ES.idsor = S.idsor
	join proceeds P on IL.kpro = P.kpro
	left outer join proceedstransmission PT on PT.kproceedstransmission = P.kproceedstransmission
WHERE IY.ayear = @ayear
	AND I.adate <= @adate
	AND (IY.idupb LIKE @idupb)
	AND S.idsorkind = @idsorkindE
	and S.sortcode ='2010101001'
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)


-- ======================================================================
-- C: incassi  con Siope compreso nell'insieme allegato
-- ======================================================================
insert into  #pagamentiincassi(
	idinc,
	idupb,
	incassiC_siopecompreso,
	npay_npro, 
	idsor,
	cod_ue,
	kind_ES,kind_mov,
	movdescription,
	streamdate,
	billdate
	)
SELECT
	IL.idinc,
	IY.idupb,
	ES.amount,
	P.npro,
	ES.idsor,
	ES.values1,
	'E','I',
	@maxincomephase +' n.'+ convert(varchar(10),I.nmov) +'. '+I.description,
	PT.streamdate,
	CASE
		WHEN IL.nbill IS NOT NULL
			THEN (SELECT adate FROM bill where bill.billkind = 'C' AND bill.ybill = @ayear AND bill.nbill = IL.nbill)
		WHEN IL.nbill IS NULL
			THEN (SELECT top 1 adate FROM bill JOIN incomebill ON bill.billkind = 'C' AND bill.ybill =incomebill.ybill AND bill.nbill = incomebill.nbill where IL.idinc = incomebill.idinc AND bill.ybill = @ayear AND bill.nbill = incomebill.nbill)
	END
FROM income I
	join incomelast IL on I.idinc = IL.idinc
	join incomeyear IY on IL.idinc = IY.idinc
	JOIN upb U ON IY.idupb = U.idupb
	JOIN incomesorted ES ON ES.idinc = IY.idinc
	join sorting S on ES.idsor = S.idsor
	join proceeds P on IL.kpro = P.kpro
	left outer join proceedstransmission PT on PT.kproceedstransmission = P.kproceedstransmission
	join #siopeES TS on TS.idsor = ES.idsor and TS.e_s='E'
WHERE IY.ayear = @ayear
	AND I.adate <= @adate
	AND (IY.idupb LIKE @idupb)
	AND S.idsorkind = @idsorkindE
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)


-- ======================================================================
-- E: pagamenti con Siope compreso nell'insieme allegato e senza COFOG
-- ======================================================================
insert into  #pagamentiincassi(
	idexp,
	idupb,
	pagamentiE_siopecompreso,
	npay_npro, 
	idsor,
	cod_ue,
	cofog,
	kind_ES,kind_mov,
	movdescription,
	streamdate,
	billdate)
SELECT
	IL.idexp,
	IY.idupb,
	ES.amount,
	P.npay,
	ES.idsor,
	ES.values1,
	ES.values2,
	'S','P',
	@maxexpensephase +' n.'+ convert(varchar(10),I.nmov) +'. '+I.description,
	PT.streamdate,
	CASE
		WHEN IL.nbill IS NOT NULL
			THEN (SELECT adate FROM bill where bill.billkind = 'D' AND bill.ybill = @ayear AND bill.nbill = IL.nbill)
		WHEN IL.nbill IS NULL
			THEN (SELECT top 1 adate FROM bill JOIN expensebill ON bill.billkind = 'D' AND bill.ybill =expensebill.ybill AND bill.nbill = expensebill.nbill where IL.idexp = expensebill.idexp AND bill.ybill = @ayear AND bill.nbill = expensebill.nbill)
	END
FROM expense I
	join expenselast IL on I.idexp = IL.idexp
	join expenseyear IY on IL.idexp = IY.idexp
	JOIN upb U ON IY.idupb = U.idupb
	JOIN expensesorted ES ON ES.idexp = IY.idexp
	join sorting S on ES.idsor = S.idsor
	join payment P on IL.kpay = P.kpay
	left outer join paymenttransmission PT on PT.kpaymenttransmission = P.kpaymenttransmission
	join #siopeES TS on TS.idsor = ES.idsor and TS.e_s='S'
WHERE IY.ayear = @ayear
	AND I.adate <= @adate
	AND (IY.idupb LIKE @idupb)
	AND S.idsorkind = @idsorkindS
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	and ES.values2 is null


-- ======================================================================
-- F: pagamenti con COFOG
-- ======================================================================
insert into  #pagamentiincassi(
	idexp,
	idupb,
	pagamentiF_Cofog,
	npay_npro, 
	idsor,
	cod_ue,
	cofog,
	kind_ES,kind_mov,
	movdescription,
	streamdate,
	billdate)
SELECT
	IL.idexp,
	IY.idupb,
	ES.amount,
	P.npay,
	ES.idsor,
	ES.values1,
	ES.values2,
	'S','P',
	@maxexpensephase +' n.'+ convert(varchar(10),I.nmov) +'. '+I.description,
	PT.streamdate,
	CASE
		WHEN IL.nbill IS NOT NULL
			THEN (SELECT adate FROM bill where bill.billkind = 'D' AND bill.ybill = @ayear AND bill.nbill = IL.nbill)
		WHEN IL.nbill IS NULL
			THEN (SELECT top 1 adate FROM bill JOIN expensebill ON bill.billkind = 'D' AND bill.ybill =expensebill.ybill AND bill.nbill = expensebill.nbill where IL.idexp = expensebill.idexp AND bill.ybill = @ayear AND bill.nbill = expensebill.nbill)
	END
FROM expense I
	join expenselast IL on I.idexp = IL.idexp
	join expenseyear IY on IL.idexp = IY.idexp
	JOIN upb U ON IY.idupb = U.idupb
	JOIN expensesorted ES ON ES.idexp = IY.idexp
	join sorting S on ES.idsor = S.idsor
	join payment P on IL.kpay = P.kpay
	left outer join paymenttransmission PT on PT.kpaymenttransmission = P.kpaymenttransmission
WHERE IY.ayear = @ayear
	AND I.adate <= @adate
	AND (IY.idupb LIKE @idupb)
	AND S.idsorkind = @idsorkindS
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	and ES.values2 is NOT null   -- COFOG


-- ======================================================================
-- D: pagamenti (pagamenti che non rientrano ne in E ne in F) Prende tutto se non l'ha giÃ  preso prima
-- ======================================================================
insert into  #pagamentiincassi(
	idexp,
	idupb,
	pagamentiD,
	npay_npro, 
	idsor,
	cod_ue,
	cofog,
	kind_ES,kind_mov,
	movdescription,
	streamdate,
	billdate)
SELECT
	IL.idexp,
	IY.idupb,
	ES.amount,
	P.npay,
	ES.idsor,
	ES.values1,
	ES.values2,
	'S','P',
	@maxexpensephase +' n.'+ convert(varchar(10),I.nmov) +'. '+I.description,
	PT.streamdate,
	CASE
		WHEN  IL.nbill IS NOT NULL THEN (SELECT adate FROM bill where bill.billkind = 'D' AND bill.ybill = @ayear AND bill.nbill = IL.nbill)
		WHEN  IL.nbill IS NULL THEN (SELECT top 1 adate FROM bill 
								JOIN expensebill ON bill.billkind = 'D' AND bill.ybill =expensebill.ybill AND bill.nbill = expensebill.nbill 
								where IL.idexp = expensebill.idexp AND bill.ybill = @ayear AND bill.nbill = expensebill.nbill)
	END
FROM expense I
	join expenselast IL on I.idexp = IL.idexp
	join expenseyear IY on IL.idexp = IY.idexp
	JOIN upb U						ON IY.idupb = U.idupb
	JOIN expensesorted ES				ON ES.idexp = IY.idexp
	join sorting S on ES.idsor = S.idsor
	join payment P on IL.kpay = P.kpay
	left outer join paymenttransmission PT on PT.kpaymenttransmission = P.kpaymenttransmission
WHERE IY.ayear = @ayear
		AND I.adate <= @adate
		AND (IY.idupb LIKE @idupb)
		AND S.idsorkind = @idsorkindS
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and (select count(*) from #pagamentiincassi P_I where  IL.idexp = P_I.idexp and ES.idsor = P_I.idsor AND P_I.kind_mov='P') = 0 


-- ======================================================================
-- TABELLA DI OUT
-- ======================================================================
create table #datiout(
	tempid int identity(1,1),
	kind_ES varchar(50),			-- E entrata, S spesa
	npay_npro int, 
	idinc int,
	idexp int,
	incassiA_siopediverso decimal(19,2),	
	incassiB_siopenofabb decimal(19,2),
	incassiC_siopecompreso decimal(19,2),	
	pagamentiD decimal(19,2),	
	pagamentiE_siopecompreso decimal(19,2),	
	pagamentiF_Cofog decimal(19,2),	
	fabb_residuo decimal(19,2),
	fabb_residuoT decimal(19,2),
	idupb varchar(36),
	idsor int,
	cofog varchar(20),
	cod_ue varchar(20),
	kind_mov varchar(50),			-- I incassi, P pagamenti, T totali singole colonne 
	movdescription varchar(300),
	codeupb varchar(50),
	idepupbkind int,
	epupbkind varchar(50),			-- title
	paridupb varchar(50),
	idsors varchar(50),
	sortcode varchar(50),
	streamdate datetime,
	billdate datetime
)


-- ======================================================================
-- Fabbisogno Assegnato
-- ======================================================================
insert into #datiout(
	kind_ES,
	fabb_residuo 
	)
select  
	'F',
	assignedrequirement
from config
where ayear = @ayear


-- ======================================================================
-- Inserimento PagamentiIncassi
-- ======================================================================
insert into #datiout(
	kind_ES,
	npay_npro, 
	sortcode,
	codeupb,
	idepupbkind,
	epupbkind,
	paridupb,
	idsors,
	cofog,
	cod_ue,
	movdescription,
	incassiA_siopediverso,	
	incassiB_siopenofabb,
	incassiC_siopecompreso,	
	pagamentiD,	
	pagamentiE_siopecompreso,	
	pagamentiF_Cofog, 
	streamdate,
	billdate)
select  
	P.kind_ES,
	npay_npro , 
	S.sortcode,
	U.codeupb , 
	U.idepupbkind,
	UPK.title, 
	PAR.codeupb,
	IDSOR.sortcode,
	P.cofog ,
	P.cod_ue ,
	P.movdescription,
	sum(P.incassiA_siopediverso),
	sum(P.incassiB_siopenofabb),
	sum(P.incassiC_siopecompreso),
	sum(P.pagamentiD),
	sum(P.pagamentiE_siopecompreso),
	sum(P.pagamentiF_Cofog),
	P.streamdate,
	P.billdate  
from #pagamentiincassi P
	join sorting S on P.idsor = S.idsor
	join upb U on P.idupb = U.idupb
	left outer join upb PAR on U.paridupb = PAR.idupb
	left join sorting IDSOR on U.idsor01 = IDSOR.idsor
	left outer join epupbkind UPK on UPK.idepupbkind = U.idepupbkind
group by kind_ES, npay_npro, S.sortcode, U.codeupb, P.cofog, P.cod_ue, P.movdescription, U.idepupbkind, UPK.title, PAR.codeupb, IDSOR.sortcode, P.streamdate, P.billdate 
order by kind_ES, npay_npro, S.sortcode, P.cofog, P.cod_ue, U.codeupb, P.movdescription, P.streamdate, P.billdate 


-- ======================================================================
-- Update Fabbisogno
-- ======================================================================
update #datiout set fabb_residuo =  isnull(incassiA_siopediverso,0) - isnull(pagamentiD,0) where kind_ES in ('E','S')


-- ======================================================================
-- Inserisce i totali
-- ======================================================================
insert into  #datiout(
	kind_ES,
	incassiA_siopediverso,
	incassiB_siopenofabb,
	incassiC_siopecompreso,
	pagamentiD,
	pagamentiE_siopecompreso,
	pagamentiF_Cofog ,
	kind_mov)
select
	'TOTALI',
	sum(P.incassiA_siopediverso) ,
	sum(P.incassiB_siopenofabb),
	sum(P.incassiC_siopecompreso) ,
	sum(P.pagamentiD) ,
	sum(P.pagamentiE_siopecompreso),
	sum(P.pagamentiF_Cofog),
	'T'
from 	#pagamentiincassi P



-- ======================================================================
-- Tabella Ordinata dove inserire i valori del fabbisogno residuo sommati progressivamente
-- ======================================================================
create table #datisum(
	tempid int identity(1,1),
	kind_ES varchar(50),
	npay_npro int, 
	sortcode varchar(50),
	codeupb varchar(50),
	epupbkind varchar(50),
	paridupb varchar(50),
	idsors varchar(50),
	cofog varchar(20),
	cod_ue varchar(20),
	streamdate datetime,
	billdate datetime,
	movdescription varchar(300),
	incassiA_siopediverso decimal(19,2),
	incassiB_siopenofabb decimal(19,2),
	incassiC_siopecompreso decimal(19,2),
	pagamentiD decimal(19,2),
	pagamentiE_siopecompreso decimal(19,2),
	pagamentiF_Cofog decimal(19,2),
	fabb_residuo decimal(19,2)
)


-- ======================================================================
-- Variabili d'appoggio per la fetch
-- ======================================================================
declare @kind_ES varchar(50)
declare @npay_npro int
declare @sortcode varchar(50)
declare @codeupb varchar(50)
declare @epupbkind varchar(50)
declare @paridupb varchar(50)
declare @idsors varchar(50)
declare @cofog varchar(20)
declare @cod_ue varchar(20)
declare @streamdate datetime
declare @billdate datetime
declare @movdescription varchar(300)
declare @incassiA_siopediverso decimal(19,2)
declare @incassiB_siopenofabb decimal(19,2)
declare @incassiC_siopecompreso decimal(19,2)
declare @pagamentiD decimal(19,2)
declare @pagamentiE_siopecompreso decimal(19,2)
declare @pagamentiF_Cofog decimal(19,2)
declare @fabb_residuo decimal(19,2)

-- Progressivo del residuo
declare @residuo as decimal(19,2)
set @residuo = 0

-- Cursore sulla tabella temp per inserire il fabbisogno calcolando la somma progressiva
DECLARE fabb_residuo_cursor CURSOR FOR
select  
	kind_ES,
	npay_npro, 
	P.sortcode,
	P.codeupb, 
	P.epupbkind, 
	P.paridupb,
	P.idsors,
	P.cofog,
	P.cod_ue,
	P.streamdate ,
	P.billdate ,
	P.movdescription,
	P.incassiA_siopediverso,		-- A: incassi  con Siope diverso dell'insieme allegato
	P.incassiB_siopenofabb,			-- B: Incassi da trasferimenti correnti da Ministeri che NON concorrono al calcolo del fabbisogno
	P.incassiC_siopecompreso,		-- C: incassi  con Siope compreso nell'insieme allegato
	P.pagamentiD,					-- D: pagamenti (pagamenti che non rientrano ne in E ne in F)
	P.pagamentiE_siopecompreso,		-- E: pagamenti con Siope compreso nell'insieme allegato e senza COFOG
	P.pagamentiF_Cofog,				-- F: pagamenti con COFOG
	fabb_residuo
from #datiout P
order by 1,2,12

 
-- Apro e leggo
OPEN fabb_residuo_cursor  
FETCH NEXT FROM fabb_residuo_cursor
INTO @kind_ES, @npay_npro, @sortcode, @codeupb, @epupbkind, @paridupb, @idsors, @cofog, @cod_ue, @streamdate, @billdate, @movdescription, @incassiA_siopediverso, @incassiB_siopenofabb, @incassiC_siopecompreso, @pagamentiD, @pagamentiE_siopecompreso, @pagamentiF_Cofog, @fabb_residuo


-- Per ogni riga
WHILE @@FETCH_STATUS = 0  
BEGIN
	-- Sommo il residuo
	SET @residuo = isnull(@fabb_residuo, 0) + @residuo
	
	-- Insert della riga con il nuovo residuo calcolato
	insert into #datisum
		(kind_ES, npay_npro, sortcode, codeupb, epupbkind, paridupb, idsors, cofog, cod_ue, streamdate, billdate, movdescription, incassiA_siopediverso, incassiB_siopenofabb, incassiC_siopecompreso, pagamentiD, pagamentiE_siopecompreso, pagamentiF_Cofog, fabb_residuo)
	values
		(@kind_ES, @npay_npro, @sortcode, @codeupb, @epupbkind, @paridupb, @idsors, @cofog, @cod_ue, @streamdate, @billdate, @movdescription, @incassiA_siopediverso, @incassiB_siopenofabb, @incassiC_siopecompreso, @pagamentiD, @pagamentiE_siopecompreso, @pagamentiF_Cofog, @residuo)

	-- Next
    FETCH NEXT FROM fabb_residuo_cursor
	INTO @kind_ES, @npay_npro, @sortcode, @codeupb, @epupbkind, @paridupb, @idsors, @cofog, @cod_ue, @streamdate, @billdate, @movdescription, @incassiA_siopediverso, @incassiB_siopenofabb, @incassiC_siopecompreso, @pagamentiD, @pagamentiE_siopecompreso, @pagamentiF_Cofog, @fabb_residuo
END


-- Elimino Cursore
CLOSE fabb_residuo_cursor  
DEALLOCATE fabb_residuo_cursor 


UPDATE #datisum set kind_ES = 'Fabbisogno Assegnato', fabb_residuo = NULL where kind_ES = 'F'

-- ======================================================================
-- Select finale
-- ======================================================================
select
	kind_ES						as 'ENTRATA/SPESA',
	npay_npro					as 'Numero Documento (Mandato/Reversale)', 
	sortcode					as 'SIOPE',
	codeupb						as 'UPB', 
	epupbkind					as 'Tipo UPB', 
	paridupb					as 'UPB Padre',
	idsors						as 'Attributo Sicurezza 01',
	cofog						as 'Codice COFOG ',
	cod_ue						as 'Codice UE',
	streamdate					as 'Data creazione flusso della distinta di trasmissione',
	billdate					as 'Data contabile della partita pendente a regolarizzazione',
	movdescription				as 'Descrizione fase di cassa',
	incassiA_siopediverso		as 'a) Incassi che concorrono al calcolo del fabbisogno',																-- A: incassi  con Siope diverso dell'insieme allegato
	incassiB_siopenofabb		as 'b) Incassi da trasferimenti correnti da Ministeri che NON concorrono al calcolo del fabbisogno',					-- B: incassi da trasferimenti correnti da Ministeri che NON concorrono al calcolo del fabbisogno
	incassiC_siopecompreso		as 'c) Incassi per ricerca e investimenti che NON concorrono al calcolo del fabbisogno(Codici Siope All. 2 DM 35875)',	-- C: incassi  con Siope compreso nell'insieme allegato
	pagamentiD					as 'd)Pagamenti che non rientrano nelle due colonne successive',														-- D: pagamenti (pagamenti che non rientrano ne in E ne in F)
	pagamentiE_siopecompreso	as 'e)Pagamenti che hanno un codice Siope tra quelli dell allegato 1 ma non hanno il codice Cofog ',					-- E: pagamenti con Siope compreso nell'insieme allegato e senza COFOG
	pagamentiF_Cofog			as 'f)Pagamenti che hanno un codice Cofog',																				-- F: pagamenti con COFOG
	fabb_residuo				as 'Fabbisogno Residuo = (Fabbisogno assegnato + a) -d))'
 from #datisum
 order by tempid


drop table #siopeES
drop table #pagamentiincassi
drop table #datiout
drop table #datisum

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

