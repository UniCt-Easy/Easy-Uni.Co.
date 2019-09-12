-- CREAZIONE VISTA [finmotiveusable]
IF EXISTS(select * from sysobjects where id = object_id(N'[finmotiveusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finmotiveusable]
GO


CREATE  VIEW [finmotiveusable]
(
	idfinmotive,
	paridaccmotive,
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
	WHERE b1.paridfinmotive = finmotive.idfinmotive )=0




GO
  