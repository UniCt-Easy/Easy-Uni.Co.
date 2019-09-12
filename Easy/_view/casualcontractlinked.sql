-- CREAZIONE VISTA casualcontractlinked
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontractlinked]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontractlinked]
GO
--setuser 'amministrazione'
--clear_table_info 'casualcontractlinked'
--select * from casualcontractlinked 

CREATE   VIEW [casualcontractlinked]
(
	ayear,
	ycon,
	ncon,
	idreg,
	registry,
	idser,
	service,
	codeser,
	feegross,
	ct,
	cu,
	adate,
	stop,
	start,
	ndays,
	taxableotheragency,
	lt,
	lu,
	
	description,
	higherrate,
	flaghigherrate,
	idupb,
	idaccmotive,
	idsor1,
	idsor2,
	idsor3,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS
SELECT
	accountingyear.ayear,
	casualcontract.ycon,
	casualcontract.ncon,
	casualcontract.idreg,
	registry.title,
	casualcontract.idser,
	service.description,
	service.codeser, 
	casualcontract.feegross,
	casualcontract.ct,
	casualcontract.cu,
	casualcontract.adate,
	casualcontract.stop,
	casualcontract.start,
	casualcontract.ndays,
	casualcontractyear.taxableotheragency,
	casualcontract.lt,
	casualcontract.lu,

	casualcontract.description,
	casualcontractyear.higherrate,
	casualcontractyear.flaghigherrate,
	casualcontract.idupb,
	casualcontract.idaccmotive,
	casualcontract.idsor1,
	casualcontract.idsor2,
	casualcontract.idsor3,
	casualcontract.idsor01,
	casualcontract.idsor02,
	casualcontract.idsor03,
	casualcontract.idsor04,
	casualcontract.idsor05

FROM casualcontract (nolock)
JOIN service (nolock)
	ON casualcontract.idser = service.idser
JOIN casualcontractyear (nolock)
	ON casualcontract.ycon = casualcontractyear.ycon
	AND casualcontract.ncon = casualcontractyear.ncon
	AND casualcontract.ycon = casualcontractyear.ayear
JOIN registry (nolock)
	ON casualcontract.idreg = registry.idreg
CROSS JOIN accountingyear (nolock)
WHERE EXISTS (SELECT * FROM expensecasualcontract AS MM
		JOIN expenseyear II
		  ON  II.idexp=MM.idexp
		 AND  MM.ycon=casualcontract.ycon
		 AND  MM.ncon=casualcontract.ncon
	       WHERE II.ayear = accountingyear.ayear)

GO

