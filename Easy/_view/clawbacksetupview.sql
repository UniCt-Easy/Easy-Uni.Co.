-- CREAZIONE VISTA clawbacksetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[clawbacksetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [clawbacksetupview]
GO


-- select * from clawbacksetupview
--setuser 'amministrazione'
CREATE VIEW clawbacksetupview 
(
	idclawback,	clawback,	clawbackref,
	ayear,
	clawbackfinance,	codefin,	finance,
	idaccmotive,	codemotive,	accmotive,
	idreg,	registry,
	idfin_s,	codefin_s,	finance_s,
	cu,	ct,	lu,	lt
)
  AS SELECT
	clawbacksetup.idclawback,	clawback.description,	clawback.clawbackref,
	clawbacksetup.ayear,
	clawbacksetup.clawbackfinance,	fin.codefin,	fin.title,
	clawbacksetup.idaccmotive,	accmotive.codemotive,	accmotive.title,  
	registry.idreg,	registry.title,
	clawbacksetup.idfin_s,	fin_s.codefin,	fin_s.title,
	clawbacksetup.cu,	clawbacksetup.ct,	clawbacksetup.lu,	clawbacksetup.lt
FROM clawbacksetup
JOIN clawback 					ON clawback.idclawback = clawbacksetup.idclawback
LEFT OUTER JOIN fin				ON fin.idfin = clawbacksetup.clawbackfinance
LEFT OUTER JOIN fin fin_s			ON fin_s.idfin = clawbacksetup.idfin_s
LEFT OUTER JOIN accmotive		ON accmotive.idaccmotive = clawbacksetup.idaccmotive
LEFT OUTER JOIN registry		ON registry.idreg = clawback.idreg






GO
