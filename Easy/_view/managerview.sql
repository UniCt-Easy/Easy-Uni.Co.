-- CREAZIONE VISTA managerview
IF EXISTS(select * from sysobjects where id = object_id(N'[managerview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [managerview]
GO


--clear_table_info managerview

CREATE VIEW managerview 
(
	idman,
	title,
	iddivision,
	codedivision,
	division,
	email,
	phonenumber,
	userweb,
	passwordweb,
	active,
	financeactive,
	wantswarn,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	manager.idman,
	manager.title,
	manager.iddivision,
	division.codedivision,
	division.description,
	manager.email,
	manager.phonenumber,
	manager.userweb,
	manager.passwordweb,
	manager.active,
	manager.financeactive,
	manager.wantswarn,
	manager.idsor01,
	manager.idsor02,
	manager.idsor03,
	manager.idsor04,
	manager.idsor05,
	manager.cu, 
	manager.ct, 
	manager.lu,
	manager.lt 
FROM manager
LEFT OUTER JOIN division
	ON manager.iddivision = division.iddivision

GO

