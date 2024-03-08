
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fabbpagamentiperricerca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fabbpagamentiperricerca]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--setuser 'amministrazione'
-- 1030102001 
-- exp_fabbpagamentiperricerca '2020', '9', '%', null, null, null, null, null,'S'
CREATE procedure exp_fabbpagamentiperricerca( 
	@ayear int,
	@monthstop int,
	@idupb varchar(36)='%',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@showdetail char(1)='N'
	) as
begin
 
DECLARE @idsorkindS int
SELECT  @idsorkindS = idsorkind FROM sortingkind  WHERE codesorkind ='SIOPE_U_18' 

declare @firstmonth int
set @firstmonth = 1

declare	@monthstart int
set @monthstart = @monthstop
declare @maxexpensephase varchar(50)
set @maxexpensephase  = ( select top 1 description from expensephase order by nphase desc )
-- I pagamenti con questo SIOPE vanno esclusi perchè sono i codici di Investimenti e che in quanti tali non sono da considerarsi per Ricerca.
create table #siopeS (	idsor int)
insert into #siopeS (idsor )
select idsor from sorting where idsorkind = @idsorkindS
and sortcode in ('1030207006','1030207007','2020201001','2020201002','2020109019','2020109999','2020109005','2020110009','2020109007',
'2020109016','2020201999','2020305001','2020306001','2020306999','2020101001','2020101003','2020401001','2020401003','2020103001','2020103003','2020403001','2020107004','2020107999','2020407999','2020104001',
'2020105001','2020105002','2020105999','2020106001','2020404001','2020405001','2020405002','2020405999','2020406001','2020107001','2020407001','2020107002','2020107005','2020407002','2020199001','2020103002',
'2020403002','2020104002','2020107004','2020107003','2020407003','2020407004','2020404002','2020302001','2020302002','2020111001','2020399001','2020103999','2020199002','2020199999','2020403999','2020499999',
'2020303001','2020304001','2020409999','2059999999')

create table #pagamenti(
	importoCUMULATO decimal(19,2),	
	importoMENSILE decimal(19,2),	
	--idupb varchar(36),
	idsor int,
	cofog varchar(20),
	cod_ue varchar(20),
	nmov int,
	codeupb varchar(50),
	npay int,
	esitato decimal(19,2),
	dataesito datetime,
	datasospeso datetime  -- data apertura sospeso
)

create table #datiout(
	tempid int identity(1,1),
	importoCUMULATO_01_4 decimal(19,2),	
	importoMENSILE_01_4 decimal(19,2),	
	importoCUMULATO_04_8 decimal(19,2),	
	importoMENSILE_04_8 decimal(19,2),	
	importoCUMULATO_07_5 decimal(19,2),	
	importoMENSILE_07_5 decimal(19,2),	

	importoCUMULATO_UE1 decimal(19,2),	
	importoMENSILE_UE1 decimal(19,2),	
	importoCUMULATO_UE2 decimal(19,2),	
	importoMENSILE_UE2 decimal(19,2),	
	importoCUMULATO_UE3 decimal(19,2),	
	importoMENSILE_UE3 decimal(19,2),	
	importoCUMULATO_UE4 decimal(19,2),	
	importoMENSILE_UE4 decimal(19,2),	
	
	
	codiceprogrammasiope01_MENSILE  decimal(19,2),	 
	codiceprogrammasiope01_CUMULATO  decimal(19,2), 
	codiceprogrammasiope02_MENSILE  decimal(19,2), 
	codiceprogrammasiope02_CUMULATO  decimal(19,2),
	codicemissionesiope01_MENSILE  decimal(19,2), 
	codicemissionesiope01_CUMULATO  decimal(19,2),

	--idupb varchar(36),
	idsor int,
	cofog varchar(20),
	cod_ue varchar(20),

	nmov int,
	codeupb varchar(50),
	npay int,
	esitato decimal(19,2),
	dataesito datetime,
	datasospeso datetime  -- data apertura sospeso

)

-- Importo mensile = Importo dei pagamenti con Cofog/UE, che hanno come data regolarizzazione sospeso (se il pagamento è a regolarizzazione) o come Data esitazione quelle comprese nel range del mese indicato in input
-- Importo cumulato = Importo dei pagamenti con Cofog/UE, che hanno come data regolarizzazione sospeso (se il pagamento è a regolarizzazione) o come Data esitazione quelle dall'01/01 fino al mese indicato in input

----> PAGAMENTI NON a regolarizzazione - MENSILI
insert into  #pagamenti(
	--idupb,
	importoMENSILE,
	idsor,
	cod_ue,
	cofog,
	nmov,
	codeupb,
	npay ,
	esitato,
	dataesito 
	)
SELECT
	--EY.idupb,
	ISNULL(SUM(ES.amount),0),
	ES.idsor,
	ES.values1,
	ES.values2,
	E.nmov, U.codeupb, P.npay,
	-- ESITATO PERFORMED
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=EL.idexp),0),
	(select top 1 transactiondate FROM banktransaction where  banktransaction.kpay = P.kpay 
	and month(transactiondate) between @monthstart and @monthstop order by transactiondate desc)
FROM expense E
	join expenselast EL on E.idexp = EL.idexp
	join expenseyear EY on EL.idexp = EY.idexp
	JOIN upb U						ON EY.idupb = U.idupb
	JOIN expensesorted ES				ON ES.idexp = EY.idexp
	join sorting S on ES.idsor = S.idsor
	join payment P on EL.kpay = P.kpay
	join historypaymentview HPV on HPV.idexp = EL.idexp
	left outer join #siopeS TS on TS.idsor = ES.idsor
WHERE EY.ayear = @ayear
		AND HPV.ymov = @ayear
		and month(HPV.competencydate) between @monthstart and @monthstop
		AND (EY.idupb LIKE @idupb)
		AND S.idsorkind = @idsorkindS
		and TS.idsor is null
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and (ES.values2 is not null or ES.values1 is not null)
		and ((EL.flag & 1)= 0 ) -- NON a regolarizzazione
		and (-- ESITATO PERFORMED
		ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=EL.idexp),0)) > 0
group by EL.idexp,	ES.idsor,	ES.values1,	ES.values2, E.nmov, U.codeupb, P.npay,P.kpay

----> PAGAMENTO A regolarizzazione - MENSILI
insert into  #pagamenti(
	--idupb,
	importoMENSILE,
	idsor,
	cod_ue,
	cofog,
	nmov,
	codeupb,
	npay ,
	esitato,
	dataesito,
	datasospeso   -- data apertura sospeso
	)
SELECT
	--EY.idupb,
	ISNULL(SUM(ES.amount),0),
	ES.idsor,
	ES.values1,
	ES.values2,
	E.nmov, U.codeupb, P.npay,
	-- ESITATO PERFORMED
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=EL.idexp),0),
	(select top 1 transactiondate FROM banktransaction where  banktransaction.kpay = P.kpay 
	and month(transactiondate) between @monthstart and @monthstop order by transactiondate desc),
	CASE
		WHEN EL.nbill IS NOT NULL THEN (select adate FROM bill where   bill.ybill = @ayear and EL.nbill = bill.nbill and bill.billkind = 'D' )
		ELSE  (SELECT top 1 B.adate FROM bill B 
									 JOIN expensebill EB ON B.billkind = 'D' AND B.ybill = EB.ybill AND B.nbill = EB.nbill 
									where EL.idexp = EB.idexp   
									and month(B.adate) between @monthstart and @monthstop
									order by B.adate asc)
	END
FROM expense E
	join expenselast EL on E.idexp = EL.idexp
	join expenseyear EY on EL.idexp = EY.idexp
	JOIN upb U						ON EY.idupb = U.idupb
	JOIN expensesorted ES				ON ES.idexp = EY.idexp
	join sorting S on ES.idsor = S.idsor
	join payment P on EL.kpay = P.kpay
	left outer join paymenttransmission PT on PT.kpaymenttransmission = P.kpaymenttransmission
	left outer join #siopeS TS on TS.idsor = ES.idsor
WHERE EY.ayear = @ayear
		AND (EY.idupb LIKE @idupb)
		AND S.idsorkind = @idsorkindS
		and TS.idsor is null
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and (ES.values2 is not null or ES.values1 is not null)
		and (EL.flag & 1)<> 0 -- a regolarizzazione
		and (
			 ( EL.nbill IS NOT NULL and  ( select month(B.adate)
										FROM bill B
										where B.billkind = 'D' AND B.ybill = @ayear AND B.nbill = EL.nbill
										)
			  between @monthstart and @monthstop )
			 OR
			 ( EL.nbill IS NULL and (SELECT top 1 month(B.adate) FROM bill B 
											JOIN expensebill ON B.billkind = 'D' AND B.ybill = expensebill.ybill AND B.nbill = expensebill.nbill 
									where EL.idexp = expensebill.idexp AND B.ybill = @ayear --AND BT.nbill = EL.nbill
									order by B.adate asc)  between @monthstart and @monthstop )
			)
and
		(
		EL.nbill is not null
		and
			isnull((select B.toregularize from billview B where B.billkind='D' and B.ybill = @ayear and B.nbill = EL.nbill),0)=0
		OR
		(
		EL.nbill is null
			and isnull((select sum(B.toregularize) from billview B
				join expensebill on B.billkind='D' and B.ybill = expensebill.ybill and  B.nbill = expensebill.nbill
				where EL.idexp = expensebill.idexp and B.ybill = @ayear and B.nbill = expensebill.nbill),0)=0
		)
		)
		and (-- ESITATO PERFORMED
		ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=EL.idexp),0)) > 0
group by 	EL.nbill, EL.idexp,		ES.idsor,	ES.values1,	ES.values2, E.nmov, U.codeupb, P.npay,P.kpay

----> PAGAMENTI NON a regolarizzazione - CUMULATI
insert into  #pagamenti(
	--idupb,
	importoCUMULATO,
	idsor,
	cod_ue,
	cofog,
	nmov,
	codeupb,
	npay ,
	esitato,
	dataesito 
	)
SELECT
	--EY.idupb,
	sum(ES.amount),
	ES.idsor,
	ES.values1,
	ES.values2,
	E.nmov, U.codeupb, P.npay,
	-- ESITATO PERFORMED
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=EL.idexp),0),
	(select top 1 transactiondate FROM banktransaction where  banktransaction.kpay = P.kpay 
	and month(transactiondate) between @firstmonth and @monthstop  order by transactiondate desc)
FROM expense E
	join expenselast EL on E.idexp = EL.idexp
	join expenseyear EY on EL.idexp = EY.idexp
	JOIN upb U						ON EY.idupb = U.idupb
	JOIN expensesorted ES				ON ES.idexp = EY.idexp
	join sorting S on ES.idsor = S.idsor
	join payment P on EL.kpay = P.kpay
	join historypaymentview HPV on HPV.idexp = EL.idexp
	left outer join #siopeS TS on TS.idsor = ES.idsor
WHERE EY.ayear = @ayear
		AND HPV.ymov = @ayear
		and month(HPV.competencydate) between @firstmonth and @monthstop
		AND (EY.idupb LIKE @idupb)
		and TS.idsor is null
		AND S.idsorkind = @idsorkindS
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and (ES.values2 is not null or ES.values1 is not null)
		and ((EL.flag & 1)= 0 ) -- NON a regolarizzazione
		and (-- ESITATO PERFORMED
		ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=EL.idexp),0)) > 0
group by 		EL.idexp,		ES.idsor,	ES.values1,	ES.values2, E.nmov, U.codeupb, P.npay,P.kpay

----> PAGAMENTO A regolarizzazione - CUMULATI
insert into  #pagamenti(
	--idupb,
	importoCUMULATO,
	idsor,
	cod_ue,
	cofog,
	nmov,
	codeupb,
	npay ,
	esitato,
	dataesito,
	datasospeso   -- data apertura sospeso
	)
SELECT
	--EY.idupb,
	sum(ES.amount),
	ES.idsor,
	ES.values1,
	ES.values2,
	E.nmov, U.codeupb, P.npay,
	-- ESITATO PERFORMED
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=EL.idexp),0),
	(select top 1 transactiondate FROM banktransaction where  banktransaction.kpay = P.kpay 
	and month(transactiondate) between @firstmonth and @monthstop order by transactiondate desc),
	CASE
		WHEN EL.nbill IS NOT NULL THEN (select adate FROM bill where   bill.ybill = @ayear and EL.nbill = bill.nbill and bill.billkind = 'D' )
		ELSE  (SELECT top 1 B.adate FROM bill B 
									 JOIN expensebill EB ON B.billkind = 'D' AND B.ybill = EB.ybill AND B.nbill = EB.nbill 
									where EL.idexp = EB.idexp   
									and month(B.adate) between   @firstmonth and @monthstop 
									order by B.adate asc)
	END
FROM expense E
	join expenselast EL on E.idexp = EL.idexp
	join expenseyear EY on EL.idexp = EY.idexp
	JOIN upb U						ON EY.idupb = U.idupb
	JOIN expensesorted ES				ON ES.idexp = EY.idexp
	join sorting S on ES.idsor = S.idsor
	join payment P on EL.kpay = P.kpay
	left outer join paymenttransmission PT on PT.kpaymenttransmission = P.kpaymenttransmission
	left outer join #siopeS TS on TS.idsor = ES.idsor
WHERE EY.ayear = @ayear
		AND (EY.idupb LIKE @idupb)
		and TS.idsor is null
		AND S.idsorkind = @idsorkindS
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and (ES.values2 is not null or ES.values1 is not null)
		and (EL.flag & 1)<> 0 -- a regolarizzazione
		and (
			( EL.nbill IS NOT NULL and   ( select month(B.adate)
										FROM bill B
										where B.billkind = 'D' AND B.ybill = @ayear AND B.nbill = EL.nbill
										)
							between @firstmonth and @monthstop )
			OR
			( EL.nbill IS NULL and (SELECT top 1 month(B.adate) FROM bill B 
											JOIN expensebill ON B.billkind = 'D' AND B.ybill = expensebill.ybill AND B.nbill = expensebill.nbill 
									where EL.idexp = expensebill.idexp AND B.ybill = @ayear --AND BT.nbill = EL.nbill
									order by B.adate asc)  between @firstmonth and @monthstop )
		)
	and
		(
		EL.nbill is not null
		and
			isnull((select B.toregularize from billview B where B.billkind='D' and B.ybill = @ayear and B.nbill = EL.nbill),0)=0
		OR
		(
		EL.nbill is null
			and isnull((select sum(B.toregularize) from billview B
				join expensebill on B.billkind='D' and B.ybill = expensebill.ybill and  B.nbill = expensebill.nbill
				where EL.idexp = expensebill.idexp and B.ybill = @ayear and B.nbill = expensebill.nbill),0)=0
		)
		)
		and (-- ESITATO PERFORMED
		ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=EL.idexp),0)) > 0
								
group by EL.nbill, 	EL.idexp,			ES.idsor,	ES.values1,	ES.values2	, E.nmov, U.codeupb, P.npay,P.kpay


INSERT INTO #datiout(	 idsor,	nmov,codeupb,npay ,dataesito, importoCUMULATO_01_4,		importoMENSILE_01_4)
select 		idsor, nmov,codeupb,npay ,dataesito, sum(importoCUMULATO),	sum(importoMENSILE)	
from #pagamenti
where cofog = '01.4'
and dataesito is not null
group by  		idsor,nmov,codeupb,npay ,dataesito

	
	

INSERT INTO #datiout(	 idsor,	nmov,codeupb,npay ,dataesito,datasospeso, importoCUMULATO_04_8,		importoMENSILE_04_8)
select 		idsor, nmov,codeupb,npay ,dataesito,datasospeso, sum(importoCUMULATO),	sum(importoMENSILE)
from #pagamenti
where cofog = '04.8'
and dataesito is not null
group by  		idsor,nmov,codeupb,npay ,dataesito,datasospeso

INSERT INTO #datiout(	 idsor,	nmov,codeupb,npay ,dataesito, datasospeso,importoCUMULATO_07_5,		importoMENSILE_07_5)
select 		idsor, nmov,codeupb,npay ,dataesito,datasospeso, sum(importoCUMULATO),	sum(importoMENSILE)	
from #pagamenti
where cofog = '07.5'
and dataesito is not null
group by  		idsor,nmov,codeupb,npay ,dataesito,datasospeso

INSERT INTO #datiout(	 idsor,	nmov,codeupb,npay ,dataesito,datasospeso, importoCUMULATO_UE1,		importoMENSILE_UE1)
select 		idsor, nmov,codeupb,npay ,dataesito,datasospeso, sum(importoCUMULATO),	sum(importoMENSILE)
from #pagamenti
where cod_ue = '01'
and dataesito is not null
group by  		idsor,nmov,codeupb,npay ,dataesito, datasospeso

INSERT INTO #datiout(	 idsor,nmov,codeupb,npay ,dataesito, datasospeso,	importoCUMULATO_UE2,		importoMENSILE_UE2)
select 		idsor, nmov,codeupb,npay ,dataesito, datasospeso,sum(importoCUMULATO),	sum(importoMENSILE)
from #pagamenti
where cod_ue = '02'
and dataesito is not null
group by  		idsor,nmov,codeupb,npay ,dataesito, datasospeso

INSERT INTO #datiout(	 idsor,	nmov,codeupb,npay ,dataesito, datasospeso,importoCUMULATO_UE3,		importoMENSILE_UE3)
select 		idsor, nmov,codeupb,npay ,dataesito,datasospeso,sum(importoCUMULATO),	sum(importoMENSILE)
from #pagamenti
where cod_ue = '03'
and dataesito is not null
group by  		idsor,nmov,codeupb,npay ,dataesito, datasospeso 

INSERT INTO #datiout(	 idsor,nmov,codeupb,npay ,dataesito, datasospeso,	importoCUMULATO_UE4,		importoMENSILE_UE4)
select 		idsor, nmov,codeupb,npay ,dataesito,datasospeso,sum(importoCUMULATO),	sum(importoMENSILE)
from #pagamenti
where cod_ue = '04'
and dataesito is not null
group by  		idsor,nmov,codeupb,npay ,dataesito,datasospeso



-- CODICE PROGRAMMA SIOPE
-- 01 - Ricerca scientifica e tecnologica di base		02 - Ricerca scientifica e tecnologica applicata	

INSERT INTO #datiout(idsor, nmov,codeupb,npay ,codiceprogrammasiope01_MENSILE, codiceprogrammasiope01_CUMULATO, dataesito, datasospeso  )
select idsor, nmov,codeupb,npay ,sum(importoMENSILE_01_4), sum(importoCUMULATO_01_4), dataesito, datasospeso 
from #datiout 
group by idsor, dataesito, datasospeso, nmov,codeupb,npay 

INSERT INTO #datiout(idsor, nmov,codeupb,npay ,codiceprogrammasiope02_MENSILE, codiceprogrammasiope02_CUMULATO, dataesito, datasospeso )
select idsor,nmov,codeupb,npay , sum(isnull(importoMENSILE_04_8,0) + isnull(importoMENSILE_07_5,0)),  
sum(isnull(importoCUMULATO_04_8,0) + isnull(importoCUMULATO_07_5,0)), dataesito, datasospeso 
from #datiout  
group by idsor, dataesito, datasospeso, nmov,codeupb,npay 
	
-- CODICE MISSIONE SIOPE	
-- 01 - Ricerca ed innovazione	

INSERT INTO #datiout(idsor,nmov,codeupb,npay , codicemissionesiope01_MENSILE, codicemissionesiope01_CUMULATO, dataesito, datasospeso )
select idsor, nmov,codeupb,npay ,sum(isnull(codiceprogrammasiope01_MENSILE,0) + isnull(codiceprogrammasiope02_MENSILE,0)) , 
			sum(isnull(codiceprogrammasiope01_CUMULATO,0) + isnull(codiceprogrammasiope02_CUMULATO,0)), dataesito, datasospeso 
from #datiout  
group by idsor, nmov,codeupb,npay ,dataesito, datasospeso 

if (@showdetail = 'S' )
Begin
 

select 
	nmov as 'Num.Pagamento',
	codeupb as 'UPB',
	npay as 'Num.Mmandato',
	dataesito as 'Data Esito',
	datasospeso as 'Data Apertura Sospeso',
	S.sortcode				as 'Codice CGU (Siope)',

	isnull(sum(codicemissionesiope01_MENSILE),0)  as 'CODICE MISSIONE SIOPE 01-Ricerca ed innovazione(mensile)',	  
	isnull(sum(codicemissionesiope01_CUMULATO),0) as 'CODICE MISSIONE SIOPE 01-Ricerca ed innovazione(cumulato)',	 

	isnull(sum(codiceprogrammasiope01_MENSILE),0) as  'CODICE PROGRAMMA SIOPE 01-Ricerca scientifica e tecnologica di base (mensile)', 
	isnull(sum(codiceprogrammasiope01_CUMULATO),0) as  'CODICE PROGRAMMA SIOPE 01-Ricerca scientifica e tecnologica di base (cumulato)', 
	isnull(sum(codiceprogrammasiope02_MENSILE),0)  as  'CODICE PROGRAMMA SIOPE 02 - Ricerca scientifica e tecnologica applicata(mensile)', 
	isnull(sum(codiceprogrammasiope02_CUMULATO),0) as  'CODICE PROGRAMMA SIOPE 02 - Ricerca scientifica e tecnologica applicata(cumulato)',  


	isnull(sum(importoMENSILE_01_4),0)		as 'COFOG 01.4 - Ricerca di base(mensile)',	
	isnull(sum(importoCUMULATO_01_4),0)	as 'COFOG 01.4 - Ricerca di base(cumulati)',		
	
	isnull(sum(importoMENSILE_04_8),0)		as 'COFOG 04.8-R&S per gli affari economici(mensile)',		
	isnull(sum(importoCUMULATO_04_8),0)	as 'COFOG 04.8-R&S per gli affari economici(cumulati)',			

	isnull(sum(importoMENSILE_07_5),0)		as 'COFOG 07.5-R&S per la sanità(mensile)',			
	isnull(sum(importoCUMULATO_07_5),0)	as 'COFOG 07.5-R&S per la sanità(cumulati)',				

	isnull(sum(importoMENSILE_UE1),0) as 'UE 01-Progetto ricerca Stato(mensile)',		
	isnull(sum(importoCUMULATO_UE1),0)		as 'UE 01-Progetto ricerca Stato(cumulati)',			

	isnull(sum(importoMENSILE_UE2),0)		as 'UE 02-Progetto ricerca privati(mensile)',			
	isnull(sum(importoCUMULATO_UE2),0)		as 'UE 02-progetto ricerca privati(cumulati)',		
			
	isnull(sum(importoMENSILE_UE3),0)		as 'UE 03-Progetto ricerca UE(mensile)',			
	isnull(sum(importoCUMULATO_UE3),0)		as 'UE 03-Progetto ricerca UE(cumulati)',		
				
	isnull(sum(importoMENSILE_UE4),0)		as 'UE 04-Progetto ricerca extra UE(mensile)',				
	isnull(sum(importoCUMULATO_UE4),0)		as 'UE 04-Progetto ricerca extra UE(cumulati)'	
	
from #datiout D
	join sorting S on S.idsor = D.idsor and S.idsorkind = @idsorkindS
group by S.sortcode,nmov, codeupb,npay,	dataesito,datasospeso
End
else
begin

select 
	S.sortcode				as 'Codice CGU (Siope)',
	isnull(sum(codicemissionesiope01_MENSILE),0)  as 'CODICE MISSIONE SIOPE 01-Ricerca ed innovazione(mensile)',	  
	isnull(sum(codicemissionesiope01_CUMULATO),0) as 'CODICE MISSIONE SIOPE 01-Ricerca ed innovazione(cumulato)',	 

	isnull(sum(codiceprogrammasiope01_MENSILE),0) as  'CODICE PROGRAMMA SIOPE 01-Ricerca scientifica e tecnologica di base (mensile)', 
	isnull(sum(codiceprogrammasiope01_CUMULATO),0) as  'CODICE PROGRAMMA SIOPE 01-Ricerca scientifica e tecnologica di base (cumulato)', 
	isnull(sum(codiceprogrammasiope02_MENSILE),0)  as  'CODICE PROGRAMMA SIOPE 02 - Ricerca scientifica e tecnologica applicata(mensile)', 
	isnull(sum(codiceprogrammasiope02_CUMULATO),0) as  'CODICE PROGRAMMA SIOPE 02 - Ricerca scientifica e tecnologica applicata(cumulato)',  

	isnull(sum(importoMENSILE_01_4),0)		as 'COFOG 01.4 - Ricerca di base(mensile)',	
	isnull(sum(importoCUMULATO_01_4),0)	as 'COFOG 01.4 - Ricerca di base(cumulati)',		
	
	isnull(sum(importoMENSILE_04_8),0)		as 'COFOG 04.8-R&S per gli affari economici(mensile)',		
	isnull(sum(importoCUMULATO_04_8),0)	as 'COFOG 04.8-R&S per gli affari economici(cumulati)',			

	isnull(sum(importoMENSILE_07_5),0)		as 'COFOG 07.5-R&S per la sanità(mensile)',			
	isnull(sum(importoCUMULATO_07_5),0)	as 'COFOG 07.5-R&S per la sanità(cumulati)',				

	isnull(sum(importoMENSILE_UE1),0) as 'UE 01-Progetto ricerca Stato(mensile)',		
	isnull(sum(importoCUMULATO_UE1),0)		as 'UE 01-Progetto ricerca Stato(cumulati)',			

	isnull(sum(importoMENSILE_UE2),0)		as 'UE 02-Progetto ricerca privati(mensile)',			
	isnull(sum(importoCUMULATO_UE2),0)		as 'UE 02-progetto ricerca privati(cumulati)',		
			
	isnull(sum(importoMENSILE_UE3),0)		as 'UE 03-Progetto ricerca UE(mensile)',			
	isnull(sum(importoCUMULATO_UE3),0)		as 'UE 03-Progetto ricerca UE(cumulati)',		
				
	isnull(sum(importoMENSILE_UE4),0)		as 'UE 04-Progetto ricerca extra UE(mensile)',				
	isnull(sum(importoCUMULATO_UE4),0)		as 'UE 04-Progetto ricerca extra UE(cumulati)'	
	
from #datiout D
	join sorting S on S.idsor = D.idsor and S.idsorkind = @idsorkindS

group by S.sortcode
end
end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


