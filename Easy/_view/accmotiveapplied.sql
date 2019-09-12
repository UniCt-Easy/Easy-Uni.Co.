-- CREAZIONE VISTA accmotiveapplied
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotiveapplied]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accmotiveapplied]
GO






CREATE  VIEW [dbo].[accmotiveapplied]
(
	idaccmotive,
	paridaccmotive,
	codemotive,
	motive,
	cu,
	ct,
	lu,
	lt,
	active,
	idepoperation,
	epoperation,
	in_use,
	flagamm,
	flagdep,
	expensekind
)
AS SELECT
accmotive.idaccmotive,
accmotive.paridaccmotive,
accmotive.codemotive,
accmotive.title,
accmotive.cu,
accmotive.ct,
accmotive.lu,
accmotive.lt,
accmotive.active,
epoperation.idepoperation,
epoperation.title,
CASE
WHEN (SELECT COUNT(*) FROM accmotiveepoperation acc1 WHERE acc1.idaccmotive LIKE accmotive.idaccmotive + '%'
	AND acc1.idepoperation = epoperation.idepoperation)>0 THEN 'S'
ELSE 'N'
END
,
accmotive.flagamm,
accmotive.flagdep,
accmotive.expensekind
FROM accmotive
CROSS JOIN epoperation
--WHERE 
--EXISTS
	--(SELECT * FROM accmotiveepoperation acc1 WHERE acc1.idaccmotive LIKE accmotive.idaccmotive + '%'
	--AND acc1.idepoperation = epoperation.idepoperation)
UNION 
SELECT
accmotive.idaccmotive,
accmotive.paridaccmotive,
accmotive.codemotive,
accmotive.title,
accmotive.cu,
accmotive.ct,
accmotive.lu,
accmotive.lt,
accmotive.active,
null,
null,
'S',
accmotive.flagamm,
accmotive.flagdep,
accmotive.expensekind
FROM accmotive



GO
