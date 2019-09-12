-- CREAZIONE VISTA sisest_causaleview
IF EXISTS(select * from sysobjects where id = object_id(N'[sisest_causaleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sisest_causaleview]
GO


CREATE   VIEW [sisest_causaleview](
	idcausale,
	codicecausale,
	descrizione,
	note,

	idaccmotive,
	codemotive,
	accmotive,

	idfinmotive,
	codefinmotive,
	finmotive,

	idaccmotive_credit ,
	codeaccmotive_credit,
	accmotive_credit, 
	
	idaccmotive_bollo,
	codeaccmotive_bollo,
	accmotive_bollo,
	
	idfinmotive_bollo,
	codefinmotive_bollo,
	finmotive_bollo,

	idaccmotive_bollo_credit,
	codeaccmotive_bollo_credit,
	accmotive_bollo_credit,

	idaccmotive_regionale,
	codeaccmotive_regionale,
	accmotive_regionale,

	idfinmotive_regionale,
	codefinmotive_regionale,
	finmotive_regionale,

	idaccmotive_regionale_credit,
	codeaccmotive_regionale_credit,
	accmotive_regionale_credit,
	tiporiga,
	active,
	ayear,
	tipocompetenza,
	lt,	lu,	ct,	cu
)
AS
SELECT
	sisest_causale.idcausale,
	sisest_causale.codicecausale,
	sisest_causale.descrizione,
	sisest_causale.note,
	sisest_causale.idaccmotive,
	accmotive.codemotive,
	accmotive.title,

	sisest_causale.idfinmotive,
	finmotive.codemotive,
	finmotive.title,

	sisest_causale.idaccmotive_credit ,
	accmotive_credit.codemotive,
	accmotive_credit.title, 

	sisest_causale.idaccmotive_bollo,
	accmotive_bollo.codemotive,
	accmotive_bollo.title,
	
	sisest_causale.idfinmotive_bollo,
	finmotive_bollo.codemotive,
	finmotive_bollo.title,

	sisest_causale.idaccmotive_bollo_credit,
	accmotive_bollo_credit.codemotive,
	accmotive_bollo_credit.title,
	sisest_causale.idaccmotive_regionale,
	accmotive_regionale.codemotive,
	accmotive_regionale.title,
	sisest_causale.idfinmotive_regionale,
	finmotive_regionale.codemotive,
	finmotive_regionale.title,
	sisest_causale.idaccmotive_regionale_credit,
	accmotive_regionale_credit.codemotive,
	accmotive_regionale_credit.title,

	sisest_causale.tiporiga,
	sisest_causale.active,
	sisest_causale.ayear,
	sisest_causale.tipocompetenza,
	sisest_causale.lt,
	sisest_causale.lu,
	sisest_causale.ct,
	sisest_causale.cu
FROM sisest_causale
LEFT OUTER JOIN accmotive 
	ON sisest_causale.idaccmotive = accmotive.idaccmotive
LEFT OUTER JOIN finmotive 
	ON sisest_causale.idfinmotive = finmotive.idfinmotive
LEFT OUTER JOIN accmotive as  accmotive_credit
	ON sisest_causale.idaccmotive_credit = accmotive_credit.idaccmotive
LEFT OUTER JOIN accmotive as accmotive_bollo
	ON sisest_causale.idaccmotive_bollo = accmotive_bollo.idaccmotive
LEFT OUTER JOIN finmotive AS finmotive_bollo
	ON sisest_causale.idfinmotive_bollo = finmotive_bollo.idfinmotive
LEFT OUTER JOIN accmotive as accmotive_bollo_credit
	ON sisest_causale.idaccmotive_bollo_credit = accmotive_bollo_credit.idaccmotive
LEFT OUTER JOIN accmotive as  accmotive_regionale
	ON sisest_causale.idaccmotive_regionale = accmotive_regionale.idaccmotive
LEFT OUTER JOIN finmotive AS finmotive_regionale
	ON sisest_causale.idfinmotive_regionale = finmotive_regionale.idfinmotive
LEFT OUTER JOIN accmotive as  accmotive_regionale_credit
	ON sisest_causale.idaccmotive_regionale_credit = accmotive_regionale_credit.idaccmotive


GO
