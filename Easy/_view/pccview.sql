-- CREAZIONE VISTA pccview
IF EXISTS(select * from sysobjects where id = object_id(N'[pccview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pccview]
GO

CREATE   VIEW [pccview]
	(
	opkind,
	idpcc,
	idinvkind,
	invoicekind,
	yinv,
	ninv,
	ycon,
	ncon,
	idmankind ,
	mandatekind,
	yman,
	nman
)
as 
select 
	'Invio',
	pccsend.idpcc,
	invoicekind.idinvkind,
	invoicekind.description,
	yinv,
	ninv,
	ycon,
	ncon,
	mandatekind.idmankind ,
	mandatekind.description,
	yman,
	nman
from pccsend
left outer join invoicekind
	on pccsend.idinvkind = invoicekind.idinvkind
left outer join mandatekind
	on pccsend.idmankind = mandatekind.idmankind 
union
select 
	'Comunicazione Contabilizzazione',
	pccexpense.idpcc,
	invoicekind.idinvkind,
	invoicekind.description,
	yinv,
	ninv,
	ycon,
	ncon,
	mandatekind.idmankind ,
	mandatekind.description,
	yman,
	nman
from pccexpense
left outer join invoicekind
	on pccexpense.idinvkind = invoicekind.idinvkind
left outer join mandatekind
	on pccexpense.idmankind = mandatekind.idmankind 
union
select 
	'Comunicazione Scadenza',
	pccexpiring.idpcc,
	invoicekind.idinvkind,
	invoicekind.description,
	yinv,
	ninv,
	ycon,
	ncon,
	mandatekind.idmankind ,
	mandatekind.description,
	yman,
	nman
from pccexpiring
left outer join invoicekind
	on pccexpiring.idinvkind = invoicekind.idinvkind
left outer join mandatekind
	on pccexpiring.idmankind = mandatekind.idmankind 
union
select 
	'Comunicazione Pagamento',
	pccpayment.idpcc,
	invoicekind.idinvkind,
	invoicekind.description,
	yinv,
	ninv,
	ycon,
	ncon,
	mandatekind.idmankind ,
	mandatekind.description,
	yman,
	nman
from pccpayment
left outer join invoicekind
	on pccpayment.idinvkind = invoicekind.idinvkind
left outer join mandatekind
	on pccpayment.idmankind = mandatekind.idmankind 

go

