-- CREAZIONE VISTA finmotiveunusable
IF EXISTS(select * from sysobjects where id = object_id(N'[finmotiveunusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finmotiveunusable]
GO


CREATE  VIEW [finmotiveunusable]
(
	idfinmotive,
	paridfinmotive,
	codemotive,
	title,
	active,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	finmotive.idfinmotive,
	finmotive.paridfinmotive,
	finmotive.codemotive,
	finmotive.title,
	finmotive.active,
	finmotive.cu,
	finmotive.ct,
	finmotive.lu,
	finmotive.lt
	FROM finmotive (NOLOCK)
	WHERE (SELECT count(*) FROM finmotive b1
	WHERE b1.paridfinmotive = finmotive.idfinmotive )>0






GO

 