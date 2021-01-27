
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


 --setuser 'amministrazione'
 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_coerenzasiope_docmov]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_coerenzasiope_docmov]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
--	exec exp_coerenzasiope_docmov 2018
CREATE procedure [exp_coerenzasiope_docmov]
	@ayear smallint
AS BEGIN

DECLARE @nexpensephase tinyint
SELECT 	@nexpensephase = expensephase FROM config WHERE ayear = @ayear

declare @idsorkind_U int
select @idsorkind_U = idsorkind from sortingkind where codesorkind='SIOPE_U_18'
declare @idsorkind_E int
select @idsorkind_E = idsorkind from sortingkind where codesorkind='SIOPE_E_18'

CREATE TABLE #DATI(
	documento varchar(100),
	n int,		y int,		dockind varchar(150), 
	pettycash varchar(50),	yoperation int , noperation int,
	description varchar(150),
	idsor_siope int,
	nmov int,
	idsor int
	)
-- Conttratto Passivo - imponibile
INSERT INTO #DATI(documento, n, y, dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'Contratto Passivo',
	MD.nman, MD.yman, MK.description, MD.detaildescription, MD.idsor_siope,
	E.nmov,	S.idsor
from expensemandate EC
join expenselink ELK
	ON EC.idexp = ELK.idparent
join expenselast EL
	on ELK.idchild = EL.idexp	
join expensesorted ES
	on ES.idexp = EL.idexp 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join expense E
	on E.idexp = EL.idexp
JOIN mandatedetail MD 
	ON EC.idexp = MD.idexp_taxable
join mandatekind MK
	on MK.idmankind = MD.idmankind
where MD.idsor_siope is not null
	and E.ymov = @ayear
	and not exists (select dett.idmankind from mandatedetail dett	
				where  MD.idmankind  = dett.idmankind and MD.yman = dett.yman and MD.nman = dett.nman
				and isnull(dett.idsor_siope,0) = isnull(ES.idsor,0)) 

-- contratto Passivo - iva
INSERT INTO #DATI(documento, n, y, dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'Contratto Passivo',MD.nman, MD.yman, MK.description, MD.detaildescription, MD.idsor_siope,
	E.nmov,	S.idsor
from expensemandate EC
join expenselink ELK
	ON EC.idexp = ELK.idparent
join expenselast EL
	on ELK.idchild = EL.idexp	
join expensesorted ES
	on ES.idexp = EL.idexp 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join expense E
	on E.idexp = EL.idexp
JOIN mandatedetail MD 
	ON EC.idexp = MD.idexp_iva
join mandatekind MK
	on MK.idmankind = MD.idmankind
where MD.idsor_siope is not null
	and MD.idexp_iva <> MD.idexp_taxable
	and E.ymov = @ayear
	and not exists (select dett.idmankind from mandatedetail dett	
			where  MD.idmankind  = dett.idmankind and MD.yman = dett.yman and MD.nman = dett.nman
			and isnull(dett.idsor_siope,0) = isnull(ES.idsor,0)) 

-- Contratto Attivo - Imponibile
INSERT INTO #DATI(documento, n, y, dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'contratto Attivo',MD.nestim, MD.yestim, MK.description, MD.detaildescription, MD.idsor_siope,
	E.nmov,	S.idsor
from incomeestimate EC
join incomelink ELK
	ON EC.idinc = ELK.idparent
join incomelast EL
	on ELK.idchild = EL.idinc	
join incomesorted ES
	on ES.idinc = EL.idinc 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_E
join income E
	on E.idinc = EL.idinc
JOIN estimatedetail MD 
	ON EC.idinc = MD.idinc_taxable
join estimatekind MK
	on MK.idestimkind = MD.idestimkind
where MD.idsor_siope is not null
	and MD.idsor_siope <> ES.idsor
	and E.ymov = @ayear
 	and not exists (select dett.idestimkind from estimatedetail dett	
				where  MD.idestimkind  = dett.idestimkind and MD.yestim = dett.yestim and MD.nestim = dett.nestim
				and isnull(dett.idsor_siope,0) = isnull(ES.idsor,0)) 

-- Contratto Attivo - Iva
INSERT INTO #DATI(documento, n, y, dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'contratto Attivo',MD.nestim, MD.yestim, MK.description, MD.detaildescription, MD.idsor_siope,
	E.nmov,	S.idsor
from incomeestimate EC
join incomelink ELK
	ON EC.idinc = ELK.idparent
join incomelast EL
	on ELK.idchild = EL.idinc	
join incomesorted ES
	on ES.idinc = EL.idinc 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_E
join income E
	on E.idinc = EL.idinc
JOIN estimatedetail MD 
	ON EC.idinc = MD.idinc_iva
join estimatekind MK
	on MK.idestimkind = MD.idestimkind
where MD.idsor_siope is not null
	and MD.idinc_iva <> MD.idinc_taxable
	and MD.idsor_siope <> ES.idsor
	and E.ymov = @ayear
	and not exists (select dett.idestimkind from estimatedetail dett	
				where  MD.idestimkind  = dett.idestimkind and MD.yestim = dett.yestim and MD.nestim = dett.nestim
				and isnull(dett.idsor_siope,0) = isnull(ES.idsor,0)) 
-- Fatture acquisto - imponibile
INSERT INTO #DATI(documento, n, y, dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'FATTURA Acq.',MD.ninv, MD.yinv, MK.description, MD.detaildescription, MD.idsor_siope,
	E.nmov,	S.idsor
from expenseinvoice EC
join expenselink ELK
	ON EC.idexp = ELK.idparent
join expenselast EL
	on ELK.idchild = EL.idexp	
join expensesorted ES
	on ES.idexp = EL.idexp 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join expense E
	on E.idexp = EL.idexp
JOIN invoicedetail MD 
	ON EC.idexp = MD.idexp_taxable	
join invoicekind MK
	on MK.idinvkind = MD.idinvkind
where MD.idsor_siope is not null
	and MD.idsor_siope <> ES.idsor
	and E.ymov = @ayear
 	and not exists (select dett.idinvkind from invoicedetail dett	
				where  MD.idinvkind  = dett.idinvkind and MD.yinv = dett.yinv and MD.ninv = dett.ninv
				and isnull(dett.idsor_siope,0) = isnull(ES.idsor,0)) 

-- Fatture acquisto - iva
INSERT INTO #DATI(documento, n, y, dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'FATTURA Acq.',MD.ninv, MD.yinv, MK.description, MD.detaildescription, MD.idsor_siope,
	E.nmov,	S.idsor
from expenseinvoice EC
join expenselink ELK
	ON EC.idexp = ELK.idparent
join expenselast EL
	on ELK.idchild = EL.idexp	
join expensesorted ES
	on ES.idexp = EL.idexp 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join expense E
	on E.idexp = EL.idexp
JOIN invoicedetail MD 
	ON EC.idexp = MD.idexp_iva
join invoicekind MK
	on MK.idinvkind = MD.idinvkind
where MD.idsor_siope is not null
	and MD.idsor_siope <> ES.idsor
	and MD.idexp_iva <> MD.idexp_taxable
	and E.ymov = @ayear
 	and not exists (select dett.idinvkind from invoicedetail dett	
				where  MD.idinvkind  = dett.idinvkind and MD.yinv = dett.yinv and MD.ninv = dett.ninv
				and isnull(dett.idsor_siope,0) = isnull(ES.idsor,0)) 
-- Fatture di vendita - imponibile
INSERT INTO #DATI(documento, n, y, dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'FATTURA Ven.', MD.ninv, MD.yinv, MK.description, MD.detaildescription, MD.idsor_siope,
	E.nmov,	S.idsor
from incomeinvoice EC
join incomelink ELK
	ON EC.idinc = ELK.idparent
join incomelast EL
	on ELK.idchild = EL.idinc	
join incomesorted ES
	on ES.idinc = EL.idinc 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join income E
	on E.idinc = EL.idinc
JOIN invoicedetail MD 
	ON EC.idinc = MD.idinc_taxable
join invoicekind MK
	on MK.idinvkind = MD.idinvkind
where MD.idsor_siope is not null
	and MD.idsor_siope <> ES.idsor
	and E.ymov = @ayear
 	and not exists (select dett.idinvkind from invoicedetail dett	
				where  MD.idinvkind  = dett.idinvkind and MD.yinv = dett.yinv and MD.ninv = dett.ninv
				and isnull(dett.idsor_siope,0) = isnull(ES.idsor,0)) 
-- Fatture di vendita - iva	
INSERT INTO #DATI(documento, n, y, dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'FATTURA Ven.',MD.ninv, MD.yinv, MK.description, MD.detaildescription, MD.idsor_siope,
	E.nmov,	S.idsor
from incomeinvoice EC
join incomelink ELK
	ON EC.idinc = ELK.idparent
join incomelast EL
	on ELK.idchild = EL.idinc	
join incomesorted ES
	on ES.idinc = EL.idinc 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join income E
	on E.idinc = EL.idinc
JOIN invoicedetail MD 
	ON EC.idinc = MD.idinc_iva
join invoicekind MK
	on MK.idinvkind = MD.idinvkind
where MD.idsor_siope is not null
	and MD.idsor_siope <> ES.idsor
	and MD.idinc_iva <> MD.idinc_taxable
	and E.ymov = @ayear
 	and not exists (select dett.idinvkind from invoicedetail dett	
				where  MD.idinvkind  = dett.idinvkind and MD.yinv = dett.yinv and MD.ninv = dett.ninv
				and isnull(dett.idsor_siope,0) = isnull(ES.idsor,0)) 
-- Occasionali
INSERT INTO #DATI(documento, n, y,  description, idsor_siope,	nmov, idsor )
SELECT 
	'Occasionali',CC.ncon, CC.ycon, CC.description, CC.idsor_siope,
	E.nmov,	S.idsor
from expensecasualcontract EC
join expenselink ELK
	ON EC.idexp = ELK.idparent
join expenselast EL
	on ELK.idchild = EL.idexp	
join expensesorted ES
	on ES.idexp = EL.idexp 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join expense E
	on E.idexp = EL.idexp
JOIN casualcontract CC
	ON CC.ycon = EC.ycon and  CC.ncon = EC.ncon
	where CC.idsor_siope is not null
	and CC.idsor_siope <> ES.idsor
	and E.ymov = @ayear

--Missioni
INSERT INTO #DATI(documento, n, y,  description, idsor_siope,	nmov, idsor )
SELECT 
	'Missioni', CC.nitineration, CC.yitineration, CC.description, CC.idsor_siope,
	E.nmov,	S.idsor
from expenseitineration EC
join expenselink ELK
	ON EC.idexp = ELK.idparent
join expenselast EL
	on ELK.idchild = EL.idexp	
join expensesorted ES
	on ES.idexp = EL.idexp 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join expense E
	on E.idexp = EL.idexp
JOIN itineration CC
	ON CC.iditineration = EC.iditineration
	where CC.idsor_siope is not null
	and CC.idsor_siope <> ES.idsor
	and E.ymov = @ayear

 -- Parasubordinati
INSERT INTO #DATI(documento, n, y,  description, idsor_siope,	nmov, idsor )
SELECT 
	'Parasubordinati',P.ncon, P.ycon, P.duty, P.idsor_siope,
	E.nmov,	S.idsor
from expensepayroll EC
join expenselink ELK
	ON EC.idexp = ELK.idparent
join expenselast EL
	on ELK.idchild = EL.idexp	
join expensesorted ES
	on ES.idexp = EL.idexp 
join sorting S	
	on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
join expense E
	on E.idexp = EL.idexp
JOIN payroll CC
	ON CC.idpayroll = EC.idpayroll
join parasubcontract P
	on CC.idcon = P.idcon
where P.idsor_siope is not null
	and P.idsor_siope <> ES.idsor
	and E.ymov = @ayear
	
INSERT INTO #DATI(documento, n, y,  description, idsor_siope,	
	pettycash, yoperation, noperation, idsor )
SELECT 
	'Occasionali-PS',CC.ncon, CC.ycon, CC.description, CC.idsor_siope,
	PP.description, PO.yoperation, PO.noperation, PS.idsor
	FROM pettycashoperation PO
	JOIN pettycash PP
		ON PP.idpettycash = PO.idpettycash
	JOIN pettycashoperationcasualcontract
		ON  PO.idpettycash = pettycashoperationcasualcontract.idpettycash
		AND PO.yoperation  = pettycashoperationcasualcontract.yoperation
		AND PO.noperation  = pettycashoperationcasualcontract.noperation
	join pettycashoperationsorted PS
		on PS.idpettycash = PO.idpettycash and PS.noperation = PO.noperation and PS.yoperation = PO.yoperation
	JOIN casualcontract CC
		ON  CC.ycon  = pettycashoperationcasualcontract.ycon
		AND CC.ncon  = pettycashoperationcasualcontract.ncon
 	WHERE CC.idsor_siope <>PS.idsor
	and PO.yoperation = @ayear

INSERT INTO #DATI(documento, n, y,  description, idsor_siope,	
	pettycash, yoperation, noperation, idsor )
SELECT 
	'Missione-PS',CC.nitineration, CC.yitineration, CC.description, CC.idsor_siope,
	PP.description, PO.yoperation, PO.noperation, PS.idsor
	FROM pettycashoperation PO
	JOIN pettycash PP
		ON PP.idpettycash = PO.idpettycash
	JOIN pettycashoperationitineration
		ON  PO.idpettycash = pettycashoperationitineration.idpettycash
		AND PO.yoperation  = pettycashoperationitineration.yoperation
		AND PO.noperation  = pettycashoperationitineration.noperation
	join pettycashoperationsorted PS
		on PS.idpettycash = PO.idpettycash and PS.noperation = PO.noperation and PS.yoperation = PO.yoperation
	JOIN itineration CC
			ON CC.iditineration  = pettycashoperationitineration.iditineration
 	WHERE CC.idsor_siope <>PS.idsor
	and PO.yoperation = @ayear

INSERT INTO #DATI(documento, n, y,  description, idsor_siope,	
	pettycash, yoperation, noperation, idsor )
SELECT 
	'Fattura-PS',CC.ninv, CC.yinv, CC.description, null,
	PP.description, PO.yoperation, PO.noperation, PS.idsor
	FROM pettycashoperation PO
	JOIN pettycash PP
		ON PP.idpettycash = PO.idpettycash
	JOIN pettycashoperationinvoice
		ON  PO.idpettycash = pettycashoperationinvoice.idpettycash
		AND PO.yoperation  = pettycashoperationinvoice.yoperation
		AND PO.noperation  = pettycashoperationinvoice.noperation
	join pettycashoperationsorted PS
		on PS.idpettycash = PO.idpettycash and PS.noperation = PO.noperation and PS.yoperation = PO.yoperation
	JOIN invoice CC
			ON CC.idinvkind  = pettycashoperationinvoice.idinvkind and CC.yinv = pettycashoperationinvoice.yinv and CC.ninv = pettycashoperationinvoice.ninv
 	WHERE not exists (select count(dett.idinvkind) from invoicedetail dett	
				where  CC.idinvkind  = dett.idinvkind and CC.yinv = dett.yinv and CC.ninv = dett.ninv
				and isnull(dett.idsor_siope,0) = isnull(PS.idsor,0)) 
	and PO.yoperation = @ayear

	--Operazioni di Fondo Economale / Pagamento Reintegro
INSERT INTO #DATI(documento, n, y,dockind, description, idsor_siope,	nmov, idsor )
SELECT 
	'Op. Fondo Economale', PO.noperation, PO.yoperation, PP.description, PO.description, PO.idsor_siope,
	PR.noperation,	null
FROM pettycashoperation PO
JOIN pettycash PP
	ON PP.idpettycash = PO.idpettycash
JOIN pettycashoperation PR --- reintegro
	ON PR.idpettycash = PO.idpettycash AND PR.yoperation = PO.yrestore AND PR.noperation = PO.nrestore
WHERE   PO.idsor_siope is not null  AND  PO.yoperation = @ayear
AND EXISTS(SELECT * FROM pettycashexpense PE 
						JOIN expenselast EL
							on EL.idexp = PE.idexp	
						JOIN expense E
							on E.idexp = EL.idexp
							and E.ymov = @ayear
							WHERE PE.idpettycash = PR.idpettycash AND PE.yoperation = PR.yoperation AND PE.noperation = PR.noperation)
AND NOT EXISTS(SELECT * FROM pettycashexpense PE 
						JOIN expenselast EL
							on EL.idexp = PE.idexp	
						JOIN expensesorted ES
							on ES.idexp = EL.idexp 
						JOIN sorting S	
							on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
						JOIN expense E
							on E.idexp = EL.idexp
							and PO.idsor_siope = ES.idsor and E.ymov = @ayear
							WHERE PE.idpettycash = PR.idpettycash AND PE.yoperation = PR.yoperation AND PE.noperation = PR.noperation)

-- allora visto che si vuole per forza vedere il siope incoerente del pagamento del reintegro prendo il primo
-- in questo caso lo visualizzo

 --sp_help pettycashoperation
UPDATE #DATI set idsor = (  SELECT TOP 1 S.idsor FROM  pettycashexpense PE 
						JOIN pettycashoperation  PO 
							 ON PO.nrestore = PE.noperation
							 AND PO.Yrestore = PE.yoperation
							 AND PO.idpettycash = PE.idpettycash
						JOIN expenselast EL
							on EL.idexp = PE.idexp	
						JOIN expensesorted ES
							on ES.idexp = EL.idexp 
						JOIN sorting S	
							on ES.idsor = S.idsor and S.idsorkind = @idsorkind_U
						JOIN expense E
							on E.idexp = EL.idexp
							JOIN pettycash ON PE.idpettycash = pettycash.idpettycash
							WHERE E.ymov = 2018  AND PO.noperation = #dati.n AND   PO.yoperation = #dati.y AND pettycash.description = #dati.dockind
						      )
WHERE documento = 'Op. Fondo Economale'


select  
	D.documento as 'Documento/Compenso',
	D.dockind as Tipo, 
	D.y as 'Eserc. Doc',
	D.n  as 'Num. Doc',
	D.description as 'Descrizione',
	D.nmov as 'Num.Pagamento/Incasso',
	D.pettycash as 'Fondo P.S.',
	D.yoperation as 'Eserc.Op.',
	D.noperation as 'Num.Op.',
	SDOC.sortcode as'Class.Documento',
	SMOV.sortcode as'Class.Movimento/Op.P.S.'
 from #dati D
 left outer join sorting SDOC
	on D.idsor_siope = SDOC.idsor 
 left outer join sorting SMOV
	on D.idsor = SMOV.idsor 
order by D.documento, D.dockind, D.y, D.n 
drop table #dati

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
