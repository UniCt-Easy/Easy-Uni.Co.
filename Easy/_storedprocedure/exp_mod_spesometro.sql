
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_spesometro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_spesometro]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser'amministrazione'
--exec exp_mod_spesometro 2016, 'F',null,null

CREATE       PROCEDURE [exp_mod_spesometro](
	@ayear int,
	@kind char(1), --F: op.esposte in fattura, B:op.da blacklist e va indicato anche il trimestre di riferimento
	@trimestre int, -- Per B è possibile specificare o il trimestre o il mese
	@mese int
)
AS BEGIN
declare @meseinizio int
declare @mesefine int
IF (@kind = 'F')
Begin
	set @meseinizio = 1
	set @mesefine =12
End

IF(@kind='B' and @trimestre is not null)
Begin
	SELECT 
		@meseinizio= (@trimestre-1)*3+1,
		@mesefine = @trimestre*3
End

IF(@kind='B' and @mese is not null)
begin
	SELECT 
		@meseinizio= @mese ,
		@mesefine = @mese
End

-- Escludiamo il quadro SE, ossia quello relativo agli acquisti da San Marino.
-- Inseriamo le Fatture da considerare.
create table #fatture (ninv int, idinvkind int)
insert into #fatture(
	ninv, 
	idinvkind
)
select distinct I.ninv, I.idinvkind 
from invoiceview I
join invoicedetail ID
	ON I.yinv = ID.yinv
	AND I.ninv = ID.ninv
	AND I.idinvkind = ID.idinvkind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
JOIN registryaddress RA
	ON I.idreg = RA.idreg
JOIN address A
	ON RA.idaddresskind = A.idaddress
JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
where YEAR(I.adate) = @ayear
	and month(I.adate) between @meseinizio and @mesefine
	and isnull(ID.usedmodesospesometro,'F')='F' --> F : non escludere
	and isnull(I.flagintracom,'N')<>'S'
	AND isnull(RA.idnation,0) <> 48					--> Esclude San Marino
	and isnull(IRK.compensation,'N') ='N'	--> Esclude i registri Corrispettivi
	AND IRK.flagactivity <> 1				--> non prende i registri istituzionali
	AND IVTK.idivataxablekind <>5			--> esclude le aliquote Fuori Campo
	AND isnull(IK.enable_fe,'N')='N' --> dobbiamo escludere i tipo :  Utilizzabile nella Fattura Elettronica = S
	AND I.idsdi_acquisto IS NULL
	AND I.idsdi_vendita IS NULL


-- RECORD "C" - parte comune
CREATE TABLE #REC_C(
	idreg int,
	ProgressivoModulo int, -- Impostare ad 1 per il primo modulo di ogni quadro compilato, incrementando tale valore di una unità per ogni ulteriore modulo
-->> QUADRO FA - Operazioni documentate da fattura esposte in forma aggregata
	FA001004_num_op_attive_aggregate int,
	FA001005_num_op_passive_aggregate int,
	FA001006_noleggioleasing char(1),
	FA001007_op_imponibili_nonimponibili_esenti_ven int,
	FA001008_imposta_ven  int,
	FA001009_op_iva_nonesposta_ven int,
	FA001010_var_debito_ven  int,
	FA001011_var_debito_imposta_ven  int,
	FA001012_op_imponibili_nonimponibili_esenti_acqu int,
	FA001013_imposta_acqu  int,
	FA001014_op_iva_nonesposta_acqu  int,
	FA001015_var_credito_acqu  int,
	FA001016_var_credito_imposta_acqu  int,

-->>	QUADRO BL
--	 OPERAZIONI CON SOGGETTI AVENTI SEDE, RESIDENZA O DOMICILIO IN PAESI CON FISCALITÀ PRIVILEGIATA
--	 OPERAZIONI CON SOGGETTI NON RESIDENTI IN FORMA AGGREGATA
--	 ACQUISTI DI SERVIZI DA NON RESIDENTI IN FORMA AGGREGATA
-- BL002
	BL002001_CodIVA varchar(20), -- P.iva
	BL002002_Blacklist int,
	BL002003_NonResident int,
	BL002004_Acqu_NonResidenti int,
-- Operazioni ATTIVE
-- BL003 - Operazioni imponibili, non imponibili ed esenti. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" o "Operazioni con soggetti non residenti" 
	BL003001_importocomplessivo int,
	BL003002_imposta int,
-- BL004 - Operazioni non soggette ad IVA. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata"
	BL004001_cessionebeni int,
	BL004002_servizi int,
--BL005 - Note di variazione. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" (caselle BL002002) 
	BL005001_importocomplessivo int,
	BL005002_imposta int,
-- Operazioni PASSIVE
--BL006 - Operazioni imponibili, non imponibili ed esenti. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" o "Operazioni con soggetti non residenti" 
	BL006001_importocomplessivo int,
	BL006002_imposta int,
-- BL007 - Operazioni non soggette ad IVA. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" 
	BL007001_importocomplessivo int,
-- BL008 - Note di variazione. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" 
	BL008001_importocomplessivo int,
	BL008002_imposta int
)

INSERT INTO #REC_C(
	FA001004_num_op_attive_aggregate, -- Per il momento contiamo solo le fatture, escludendo le note di variazione.
	idreg,
	FA001006_noleggioleasing
	)
	select 
	count(*),
	I.idreg,
	CASE 
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
JOIN registry R
	ON I.idreg = R.idreg
where	YEAR(I.adate) = 2016
	AND ((IK.flag&4)=0)		-- variation = N
	AND ((IK.flag&1)<>0) -- V
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
group by I.idreg

INSERT INTO #REC_C(
	FA001005_num_op_passive_aggregate, -- Per il momento contiamo solo le fatture, escludendo le note di variazione.
	idreg,
	FA001006_noleggioleasing
	)
select 
	count(*),
	I.idreg,
	CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
JOIN registry R					ON I.idreg = R.idreg
where	YEAR(I.adate) = @ayear
	AND ((IK.flag&4)=0)		-- variation = N
	AND ((IK.flag&1)= 0) -- A
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

-- OPERAZIONI ATTIVE  ( Vendite )
INSERT INTO #REC_C(
	idreg,
	FA001007_op_imponibili_nonimponibili_esenti_ven,
	FA001006_noleggioleasing
)
SELECT 
	I.idreg,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK				ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK		ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
JOIN registry R					ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND IVTK.idivataxablekind in (1,2,3) --Imponibile, Non Imponibile, Esente 
	AND ((IK.flag&4)=0)		-- variation = N
	AND ((IK.flag&1)<>0) -- V
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg
 




INSERT INTO #REC_C(
	idreg,
	FA001008_imposta_ven,
	FA001006_noleggioleasing
)
SELECT 
	I.idreg,
	 ISNULL(ROUND(SUM(ID.iva_euro),0),0),
	 CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID	ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
JOIN ivakind IVK			ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
JOIN registry R				ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)=0)		--> flagvariation = N
	AND ((IK.flag&1)<>0) --> V
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	FA001009_op_iva_nonesposta_ven ,
	FA001006_noleggioleasing	
)
SELECT 
	I.idreg,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID			ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
JOIN ivakind IVK					ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK			ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK					ON IK.idinvkind = I.idinvkind
JOIN registry R						ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)=0)		--> flagvariation = N
	AND ((IK.flag&1)<>0) --> V
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND IVK.rate = 0
	--AND IVTK.idivataxablekind in (4) -- Non esposta in fattura
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	FA001004_num_op_attive_aggregate, 
	FA001010_var_debito_ven,
	FA001011_var_debito_imposta_ven,
	FA001006_noleggioleasing
)
SELECT 
	I.idreg,
	COUNT(*),
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	ISNULL(ROUND(SUM(ID.iva_euro),0),0),
	CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID			ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK					ON  IVK.idivakind = ID.idivakind	
 JOIN ivataxablekind IVTK			ON IVTK.idivataxablekind = IVK.idivataxablekind
 JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
JOIN registry R						ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)<>0)		--> flagvariation = S
	AND ((IK.flag&1) <>0) --> V
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
group by I.idreg
				
-- OPERAZIONI PASSIVE - Acquisti
INSERT INTO #REC_C(
	idreg,
	FA001012_op_imponibili_nonimponibili_esenti_acqu,
	FA001006_noleggioleasing
)
SELECT 
	I.idreg,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK				ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK		ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
JOIN registry R					ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND IVTK.idivataxablekind in (1,2,3) --Imponibile, Non Imponibile, Esente 
	AND ((IK.flag&4)=0)		-- variation = N
	AND ((IK.flag&1)=0) -- A
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	FA001013_imposta_acqu,
	FA001006_noleggioleasing
)
SELECT 
	I.idreg,
	 ISNULL(ROUND(SUM(ID.iva_euro),0),0),
	 CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID			ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK					ON  IVK.idivakind = ID.idivakind	
 JOIN ivataxablekind IVTK			ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK					ON IK.idinvkind = I.idinvkind
JOIN registry R						ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)=0)		--> flagvariation = N
	AND ((IK.flag&1)=0) --> A
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	FA001014_op_iva_nonesposta_acqu ,
	FA001006_noleggioleasing
)
SELECT 
	I.idreg,
	 ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK				ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK		ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
JOIN registry R					ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)=0)		--> flagvariation = N
	AND ((IK.flag&1)=0) --> A
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND IVK.rate = 0
	--AND IVTK.idivataxablekind in (4) -- Non esposta in fattura
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	FA001005_num_op_passive_aggregate,
	FA001015_var_credito_acqu,
	FA001016_var_credito_imposta_acqu,
	FA001006_noleggioleasing
)
SELECT 
	I.idreg,
	COUNT(*),
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	ISNULL(ROUND(SUM(ID.iva_euro),0),0),
	CASE
		WHEN count(distinct isnull(ID.leasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(ID.leasing,'N')))/count(*)) end as leasing
FROM invoice I
JOIN invoicedetailview ID	ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK			ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
JOIN registry R				ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)<>0)		--> flagvariation = S
	AND ((IK.flag&1)=0) --> A
	and I.idblacklist is null
	-- RESIDENTI 
	AND R.residence = 1 -- Residente in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
	and IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
group by I.idreg


INSERT INTO #REC_C (
	idreg,
	BL002002_Blacklist,
	BL003001_importocomplessivo
)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0)+
	ISNULL(ROUND(SUM(ID.iva_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK				ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK		ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) <>0) --> V
	AND IVTK.idivataxablekind in (1,2,3) --Imponibile, Non Imponibile, Esente 
	and I.idblacklist is NOT null
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C (
	idreg,
	BL002003_NonResident,
	BL003001_importocomplessivo,
	BL003002_imposta
)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	ISNULL(ROUND(SUM(ID.iva_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
JOIN registry R
	ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) <>0) --> V
	AND IVTK.idivataxablekind in (1,2,3) --Imponibile, Non Imponibile, Esente 
	and I.idblacklist is null
	-- NON RESIDENTI 
	AND R.residence <> 1 -- NON RESIDENTI in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg, isnull(ID.leasing,'N')

INSERT INTO #REC_C (
	idreg,
	BL002002_Blacklist,
	BL004001_cessionebeni
)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) <> 0) --> V
	AND IVTK.idivataxablekind <> 5
	and I.idblacklist is NOT null
	and ID.flag_invoicedetail = 0 -- beni
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C (
	idreg,
	BL002002_Blacklist,
	BL004002_servizi
)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID	ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK 	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK		ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) <> 0) --> V
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
	and I.idblacklist is NOT null
	and ID.flag_invoicedetail = 1 -- servizi
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	BL005001_importocomplessivo,
	BL005002_imposta
)
SELECT 
	I.idreg,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	ISNULL(ROUND(SUM(ID.iva_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK					ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)<>0)		--> flagvariation = S
	AND ((IK.flag&1) <>0) --> V
	and I.idblacklist is NOT null
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C (
	idreg,
	BL002002_Blacklist,
	BL006001_importocomplessivo,
	BL006002_imposta
)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	 ISNULL(ROUND(SUM(ID.iva_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK				ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK		ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) = 0) --> A
	AND IVTK.idivataxablekind in (1,2,3) --Imponibile, Non Imponibile, Esente 
	and I.idblacklist is NOT null
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C (
	idreg,
	BL002003_NonResident,
	BL006001_importocomplessivo,
	BL006002_imposta
)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	 ISNULL(ROUND(SUM(ID.iva_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID		ON I.idinvkind = ID.idinvkind	AND I.yinv = ID.yinv	AND I.ninv = ID.ninv
 JOIN ivakind IVK				ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK		ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
JOIN registry R					ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	-- NON RESIDENTI 
	AND R.residence <> 1 -- NON RESIDENTI in Italia
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) = 0) --> A
	AND IVTK.idivataxablekind in (1,2,3) --Imponibile, Non Imponibile, Esente 
	and I.idblacklist is null
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg


INSERT INTO #REC_C(
	idreg,
	BL002002_Blacklist,
	BL007001_importocomplessivo
	)
SELECT
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
 JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) = 0) --> A
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
	and I.idblacklist is NOT null
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	BL002003_NonResident,
	BL007001_importocomplessivo
	)
SELECT
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
JOIN registry R
	ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) = 0) --> A
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
	and I.idblacklist is  null
	-- NON RESIDENTI 
	AND R.residence <> 1 -- NON RESIDENTI in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg		

INSERT INTO #REC_C(
	idreg,
	BL002004_Acqu_NonResidenti,
	BL007001_importocomplessivo
	)
SELECT
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
 JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
JOIN registry R
	ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4) = 0)		--> flagvariation = N
	AND ((IK.flag&1) = 0) --> A
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
	and I.idblacklist is null
	-- NON RESIDENTI 
	AND R.residence <> 1 -- NON RESIDENTI in Italia
	and ID.flag_invoicedetail = 1 -- servizi
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	BL002002_Blacklist,
	BL008001_importocomplessivo,
	BL008002_imposta
	)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	ISNULL(ROUND(SUM(ID.iva_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
 JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)<>0)		--> flagvariation = S
	AND ((IK.flag&1) = 0) --> A
	and I.idblacklist is NOT null
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	BL002003_NonResident,
	BL008001_importocomplessivo,
	BL008002_imposta
	)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	ISNULL(ROUND(SUM(ID.iva_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
 JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
JOIN registry R
	ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)<>0)		--> flagvariation = S
	AND ((IK.flag&1) = 0) --> A
	and I.idblacklist is  null
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
	-- NON RESIDENTI 
	AND R.residence <> 1 -- NON RESIDENTI in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg

INSERT INTO #REC_C(
	idreg,
	BL002004_Acqu_NonResidenti,
	BL008001_importocomplessivo,
	BL008002_imposta
	)
SELECT 
	I.idreg,
	1,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	ISNULL(ROUND(SUM(ID.iva_euro),0),0)
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
JOIN registry R
	ON I.idreg = R.idreg
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)<>0)		--> flagvariation = S
	AND ((IK.flag&1) = 0) --> A
	and I.idblacklist is null
	and ID.flag_invoicedetail = 1 -- servizi
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
	-- NON RESIDENTI 
	AND R.residence <> 1 -- NON RESIDENTI in Italia
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
group by I.idreg


SELECT 
	#REC_C.idreg,
	sum(FA001004_num_op_attive_aggregate) as FA001004_num_op_attive_aggregate,
	sum(FA001005_num_op_passive_aggregate) as FA001005_num_op_passive_aggregate,
	CASE 
	WHEN count(distinct isnull(FA001006_noleggioleasing,'N'))>1 then 'N' else char(SUM(ASCII(isnull(FA001006_noleggioleasing,'N')))/count(*)) end as leasing,
	sum(FA001007_op_imponibili_nonimponibili_esenti_ven) as FA001007_op_imponibili_nonimponibili_esenti_ven,
	sum(FA001008_imposta_ven) as FA001008_imposta_ven,
	sum(FA001009_op_iva_nonesposta_ven)  as FA001009_op_iva_nonesposta_ven,
	sum(FA001010_var_debito_ven) as FA001010_var_debito_ven,
	sum(FA001011_var_debito_imposta_ven) as FA001011_var_debito_imposta_ven,
	sum(FA001012_op_imponibili_nonimponibili_esenti_acqu) as FA001012_op_imponibili_nonimponibili_esenti_acqu,
	sum(FA001013_imposta_acqu) as FA001013_imposta_acqu,
	sum(FA001014_op_iva_nonesposta_acqu) as FA001014_op_iva_nonesposta_acqu,
	sum(FA001015_var_credito_acqu) as FA001015_var_credito_acqu,
	sum(FA001016_var_credito_imposta_acqu) as FA001016_var_credito_imposta_acqu,
	sum(BL002002_Blacklist) as BL002002_Blacklist,							--> CB
	sum(BL002003_NonResident) as BL002003_NonResident,						--> CB
	sum(BL002004_Acqu_NonResidenti) as BL002004_Acqu_NonResidenti,			--> CB
	sum(BL003001_importocomplessivo) as BL003001_importocomplessivo,
	sum(BL003002_imposta) as BL003002_imposta,
	sum(BL004001_cessionebeni) as BL004001_cessionebeni,
	sum(BL004002_servizi) as BL004002_servizi,
	sum(BL005001_importocomplessivo) as BL005001_importocomplessivo,
	sum(BL005002_imposta) as BL005002_imposta,
	sum(BL006001_importocomplessivo) as BL006001_importocomplessivo,
	sum(BL006002_imposta) as BL006002_imposta,
	sum(BL007001_importocomplessivo) as BL007001_importocomplessivo,
	sum(BL008001_importocomplessivo) as BL008001_importocomplessivo,
	sum(BL008002_imposta) as BL008002_imposta
FROM #REC_C
JOIN registry R
	ON #REC_C.idreg = R.idreg
WHERE  
	( @kind='F'	
	)
	OR
	(@kind='B'	AND (R.forename is not null OR R.title is not null))
GROUP BY 	#REC_C.idreg

DROP TABLE #fatture
DROP TABLE #REC_C
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


