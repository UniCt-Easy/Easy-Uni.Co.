
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_document_debit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_document_debit]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE PROCEDURE [exp_document_debit]
(
	@ayear int,
	@idreg  int = null,
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
AS 
BEGIN
-- setuser'amministrazione'
-- setuser'amm'
-- exec exp_document_debit 2019
 -- select * from entrydetail where idrelated='man§DGRF§2019§498§1'
/*
Ultima modifica 23/10/2014 Gianni
aumentata la dimensione dei campi di #document a 250 per risolvere un errore di troncamento

-- Essendo cambiata la logica di generazione delle scritture sui Compensi occasionali e cioè 
-- poichè le scritture EP adesso vengono generate solo se c'è la Data acquisizione documentazione definitiva, 
-- si chiede di escludere dall'esportazione tutti i compensi occasionali che non hanno scrittura,  
-- ma non hanno neanche la Data acquisizione documentazione definitiva valorizzata

 
-- Sempre per gli occasionali, se non esiste una scrittura e se la Data acquisizione documentazione 
-- definitiva ha esercizio diverso da quello in cui si lancia l'esportazione, deve essere visualizzata 
-- la Nota "Scrittura non generata perchè costo non di competenza dell'esercizio"
*/

declare @usapresentazionedocumenti char(1)
set @usapresentazionedocumenti='N'
if (select idacc_bankpaydoc from config where ayear=@ayear) is not null set @usapresentazionedocumenti='S'

print 'Contratto occasionale' 
CREATE TABLE #document
	(

		idreg int, 
		tipo varchar(250),
		tipodocumento varchar(250),
		y int,
		n int,
		ndetail int,
		description varchar(250),
		datadoc date,
		datascrittura date,
		importo decimal(19,2),
		residuo decimal(19,2),
		idacc varchar(38),
		idsor int,
		idrelated varchar(200)
	)


INSERT INTO #document
	(
		idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated
	)
SELECT 
	c.idreg,	'Contratto occasionale',null,c.ycon,c.ncon,null,c.description,
		c.datecompleted,e.adate,
		ed.amount,
		 (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc
					where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc and (A.flagaccountusage & 16)<>0),
		ed.idacc,c.idsor01,ed.idrelated		
from casualcontractview c
join entrydetail ed on ed.idrelated='cascon' + '§' + convert(varchar(4),c.ycon) + '§'  + convert(varchar(14),c.ncon)
join entry e on e.yentry=ed.yentry and e.nentry=ed.nentry
join account A on ed.idacc=A.idacc 
where e.yentry=@ayear and (@idreg is null or c.idreg=@idreg) and (A.flagaccountusage & 16)<>0 and ed.amount>0
	AND (@idsor01 IS NULL OR c.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR c.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR c.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR c.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR c.idsor05 = @idsor05)
	AND c.ayear=@ayear
ORDER BY c.ycon, c.ncon



print 'Compenso a dipendente' 
INSERT INTO #document
	(
			idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated
	)
SELECT 
		c.idreg, 'Compenso a dipendente',null,c.ycon,c.ncon,null,c.description,
		c.adate,e.adate,
		ed.amount,
		 (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc
					where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc and (A.flagaccountusage & 16)<>0),
		ed.idacc,c.idsor01,ed.idrelated
from wageadditionview c
join entrydetail ed on ed.idrelated='wageadd' + '§' + convert(varchar(4),c.ycon) + '§'  + convert(varchar(14),c.ncon)
join entry e on e.yentry=ed.yentry and e.nentry=ed.nentry
join account A on ed.idacc=A.idacc 
where e.yentry=@ayear and (@idreg is null or c.idreg=@idreg) and (A.flagaccountusage & 16)<>0 and ed.amount>0
	AND (@idsor01 IS NULL OR c.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR c.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR c.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR c.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR c.idsor05 = @idsor05)
ORDER BY c.ycon, c.ncon


print 'Missione'
-- Per le Missioni, essendo cambiata la logica di generazione delle scritture su
-- Missioni e cioè poichè le scritture EP adesso vengono generate solo se c'è la Data acquisizione documentazione definitiva, 
-- si chiede di escludere dall'esportazione tutte le Missioni che non hanno scrittura, ma non hanno neanche la Data acquisizione documentazione definitiva valorizzata
-- Anche per le Missioni, se non esiste una scrittura e se la Data acquisizione documentazione definitiva 
-- ha esercizio diverso da quello in cui si lancia l'esportazione, deve essere visualizzata la Nota 
-- "Scrittura non generata perchè costo non di competenza dell'esercizio"
INSERT INTO #document
	(idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated
	)
SELECT 
		c.idreg,'Missione',null, c.yitineration, c.nitineration, null,  c.description,
		c.datecompleted, e.adate,
		ed.amount,
		 (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc 
					where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc ),
		ed.idacc,c.idsor01,ed.idrelated
from itinerationview  c
join entrydetail ed on ed.idrelated='itineration' + '§' ++ convert(varchar(14),c.iditineration)
join entry e on e.yentry=ed.yentry and e.nentry=ed.nentry
join account A on ed.idacc=A.idacc 
where e.yentry=@ayear and (@idreg is null or c.idreg=@idreg) and (A.flagaccountusage & 16)<>0 and ed.amount>0
	AND (@idsor01 IS NULL OR c.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR c.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR c.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR c.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR c.idsor05 = @idsor05)
ORDER BY C.yitineration, C.nitineration




print 'Cedolino parasubordinati'
INSERT INTO #document
	(idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated
	)
SELECT 
		c.idreg,'Cedolino parasubordinati','Anno '+convert(varchar(4),C.fiscalyear), C.ycon, C.ncon, C.npayroll,null, 
		C.disbursementdate, e.adate,
		ed.amount,
		 (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc 
					where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc),
		ed.idacc,c.idsor01,ed.idrelated
from payrollview C
join entrydetail ed on ed.idrelated= 'payroll' + '§' + convert(varchar(10),C.idpayroll) 
join entry e on e.yentry=ed.yentry and e.nentry=ed.nentry
join account A on ed.idacc=A.idacc  
where e.yentry=@ayear and (@idreg is null or c.idreg=@idreg) and (A.flagaccountusage & 16)<>0 and ed.amount>0
	AND (@idsor01 IS NULL OR c.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR c.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR c.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR c.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR c.idsor05 = @idsor05)
ORDER BY C.ycon, C.ncon, C.fiscalyear, C.npayroll

print 'Dett. Fattura Acquisto'
INSERT INTO #document	(idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated	)
SELECT distinct
		 C.idreg, 'Dett. Fattura Acquisto', C.invoicekind ,C.yinv, C.ninv,C.rownum,C.detaildescription,
		 C.adate, e.adate,
		 (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc 
					where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc and ed2.amount>0),
		 (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc 
					where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc ),
		ed.idacc,c.idsor01,ed.idrelated
from invoicedetailview C
join entrydetail ed on ed.idrelated= 'inv' + '§' + convert(varchar(4),C.idinvkind) + '§'  + 
					convert(varchar(4),C.yinv) + '§'  + convert(varchar(14),C.ninv)+ '§'  + convert(varchar(14),C.rownum)
join entry e on e.yentry=ed.yentry and e.nentry=ed.nentry
join account A on ed.idacc=A.idacc 
where e.yentry=@ayear and (@idreg is null or c.idreg=@idreg) and (A.flagaccountusage & 16)<>0 and C.flagbuysell='A' and ed.amount>0
	AND (@idsor01 IS NULL OR c.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR c.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR c.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR c.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR c.idsor05 = @idsor05)
ORDER BY C.invoicekind ,C.yinv, C.ninv,C.rownum


print 'Dett. Fattura Vendita'
INSERT INTO #document	(idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated	)
SELECT  distinct
		 C.idreg, 'Dett. Fattura Vendita', C.invoicekind ,C.yinv, C.ninv,C.rownum,C.detaildescription,
		 C.adate, e.adate,
		  (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc 
					where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc  and ed2.amount<0),
		  (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc 
					where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc),
		ed.idacc,c.idsor01,ed.idrelated
from invoicedetailview C
join entrydetail ed on ed.idrelated= 'inv' + '§' + convert(varchar(4),C.idinvkind) + '§'  + 
					convert(varchar(4),C.yinv) + '§'  + convert(varchar(14),C.ninv)+ '§'  + convert(varchar(14),C.rownum)
join entry e on e.yentry=ed.yentry and e.nentry=ed.nentry
join account A on ed.idacc=A.idacc 
where e.yentry=@ayear and (@idreg is null or c.idreg=@idreg) and (A.flagaccountusage & 32)<>0 and C.flagbuysell='V' and ed.amount<0
	AND (@idsor01 IS NULL OR c.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR c.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR c.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR c.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR c.idsor05 = @idsor05)
ORDER BY C.invoicekind ,C.yinv, C.ninv,C.rownum



print 'Contratto Passivo'
INSERT INTO #document(	idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated)
SELECT  distinct
		M.idreg,'Contratto Passivo', MK.description, M.yman, M.nman, null,  M.description,
		M.adate,  null,	--isnull(c.start,M.adate)
		(select sum(ed2.amount) from entrydetail ed2 
			join entry e on e.yentry=ed2.yentry and e.nentry=ed2.nentry
					join account A on ed2.idacc=A.idacc 
					where (A.flagaccountusage & 16)<>0 and ed2.amount>0 and e.yentry=@ayear and
						(e.idrelated = 'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman))),								 
		 (select sum(ed2.amount) from entrydetail ed2 
				join entry e on e.yentry=ed2.yentry and e.nentry=ed2.nentry
					join account A on ed2.idacc=A.idacc 
					where (A.flagaccountusage & 16)<>0 and e.yentry=@ayear and
						( (e.idrelated = 'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman))
						 or
						  (ed2.idrelated like 'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman)+'§%' )
						)),
		null,m.idsor01,'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman)
from mandate M (nolock)
join mandatekind MK (nolock) on MK.idmankind=M.idmankind
where M.yman<=@ayear
AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
and exists (select * from entrydetail ed2 
			join entry e on e.yentry=ed2.yentry and e.nentry=ed2.nentry
					join account A on ed2.idacc=A.idacc 
					where (A.flagaccountusage & 16)<>0 and ed2.amount>0 and e.yentry=@ayear and
						(e.idrelated = 'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman)))	
ORDER BY  MK.description, M.yman, M.nman

-- Escludere i contratti attivi e passivi non collegabili a fattura per i quali non vi è la spunta su “Utilizzabile per la contabilizzazione”.
/*INSERT INTO #document(	idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated)
SELECT 
		ed.idreg,'Contratto Passivo', MK.description, M.yman, M.nman, null,  M.description,
		M.adate,  e.adate,	--isnull(c.start,M.adate)
		ed.amount,
		 (select sum(ed2.amount) from entrydetail ed2 
					join account A on ed2.idacc=A.idacc 
					where 
					((ed2.idrelated = 'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman))
						or (ed2.idrelated like 'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman)+'§%'))
								 and ed2.idacc=ed.idacc ),
		ed.idacc,m.idsor01,ed.idrelated
from mandate M 
join mandatekind MK (nolock) on MK.idmankind=M.idmankind
join entrydetail ed (nolock) on ((ed.idrelated = 'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman))
			or (ed.idrelated like 'man' + '§' + M.idmankind + '§'  + convert(varchar(4),M.yman) + '§'  + convert(varchar(14),M.nman)+'§%'))
join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry
join account A (nolock) on ed.idacc=A.idacc 
where e.yentry=@ayear and (@idreg is null or ed.idreg=@idreg) and (A.flagaccountusage & 16)<>0 and ed.amount>0
	AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
ORDER BY  MK.description, M.yman, M.nman*/


print 'Contratto Attivo'
INSERT INTO #document	(idreg,tipo,tipodocumento,y,n,ndetail,description,
				datadoc,datascrittura,importo,residuo, idacc,idsor,idrelated	)
SELECT  M.idreg, 'Contratto Attivo', MK.description, M.yestim, M.nestim, null, M.description,
		M.adate,null, --e.adate,  ---isnull(c.start,M.adate)
		-(select sum(ed2.amount) from entrydetail ed2 
			join entry e on e.yentry=ed2.yentry and e.nentry=ed2.nentry
					join account A on ed2.idacc=A.idacc 
					where (A.flagaccountusage & 32)<>0 and ed2.amount<0 and e.yentry=@ayear and
						 (e.idrelated = 'estim' + '§' + M.idestimkind + '§'  + convert(varchar(4),M.yestim) + '§'  + convert(varchar(14),M.nestim))						  
						 ),
		 - (select sum(ed2.amount) from entrydetail ed2 
				join entry e on e.yentry=ed2.yentry and e.nentry=ed2.nentry
					join account A on ed2.idacc=A.idacc
					where  (A.flagaccountusage & 32)<>0 and e.yentry=@ayear and
							( (e.idrelated = 'estim' + '§' + M.idestimkind + '§'  + convert(varchar(4),M.yestim) + '§'  + convert(varchar(14),M.nestim))
						  OR
						  (ed2.idrelated like 'estim' + '§' + M.idestimkind + '§'  + convert(varchar(4),M.yestim) + '§'  + convert(varchar(14),M.nestim)+'§%')
						) ),
		null,M.idsor01, 'estim' + '§' + M.idestimkind + '§'  + convert(varchar(4),M.yestim) + '§'  + convert(varchar(14),M.nestim)
from estimate M 
join estimatekind MK on M.idestimkind=MK.idestimkind
where  (@idreg is null or M.idreg=@idreg) 
and exists (select * from entrydetail ed2 
			join entry e on e.yentry=ed2.yentry and e.nentry=ed2.nentry
					join account A on ed2.idacc=A.idacc 
					where (A.flagaccountusage & 32)<>0 and ed2.amount<0 and e.yentry=@ayear and
						 (e.idrelated = 'estim' + '§' + M.idestimkind + '§'  + convert(varchar(4),M.yestim) + '§'  + convert(varchar(14),M.nestim))						  
						 )
	AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
ORDER BY MK.description, M.yestim, M.nestim
/*
		idreg int, 
		ndetail int,
		description varchar(250),
		datadoc date,
		datascrittura date,
		importo decimal(19,2),
		residuo decimal(19,2),
		idacc varchar(38),
		idsor int

*/


SELECT 
	tipo as 'Tipo',
	tipodocumento  as 'Tipo Documento',
	y as 'Eserc. Doc.',
	n as 'Num. Doc.',
	ndetail as 'N .Dettaglio',
	datadoc as 'Data documento',
	datascrittura as 'Data apertura debito/credito',
	importo as 'Importo iniziale',
	residuo as 'Importo residuo',
	R.title as 'Fornitore/Cliente',
	#document.description as 'descrizione',
	S.sortcode as 'Codice Attributo',
	S.description as 'Descrizione Attributo',
	A.codeacc as 'Codice conto',
	A.title as 'Conto',
	#document.idrelated as 'chiave scrittura' 
	
FROM #document
left outer join sorting S on S.idsor=#document.idsor
left outer join account A on A.idacc=#document.idacc
left outer join registry R on R.idreg=#document.idreg
where residuo <>0
END 

 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

