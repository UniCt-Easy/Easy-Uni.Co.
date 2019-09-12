-- CREAZIONE VISTA wageadditionlinked
IF EXISTS(select * from sysobjects where id = object_id(N'[wageadditionlinked]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [wageadditionlinked]
GO


--setuser 'amministrazione'
--clear_table_info 'wageadditionlinked'
--select * from wageadditionlinked


CREATE VIEW [wageadditionlinked]
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
	adate,
	stop,
	start,
	description,
	ndays,

	idaccmotive,
	idsor1,
	idsor2,
	idsor3,
	idupb,
	completed,
	ct,
	cu,
	lt,
	lu,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	accountingyear.ayear,
	wageaddition.ycon,
	wageaddition.ncon,
	wageaddition.idreg,
	registry.title,
	wageaddition.idser,
	service.description,
	service.codeser,
	wageaddition.feegross,
	wageaddition.adate,
	wageaddition.stop,
	wageaddition.start,
	wageaddition.description,
	wageaddition.ndays,
	
	wageaddition.idaccmotive,
	wageaddition.idsor1,
	wageaddition.idsor2,
	wageaddition.idsor3,
	wageaddition.idupb,
	wageaddition.completed,
	wageaddition.ct,
	wageaddition.cu,
	wageaddition.lt,
	wageaddition.lu,
	wageaddition.idsor01,wageaddition.idsor02,wageaddition.idsor03,wageaddition.idsor04,wageaddition.idsor05
FROM wageaddition with (nolock)
JOIN service with (nolock)			ON wageaddition.idser = service.idser
JOIN registry with (nolock)			ON wageaddition.idreg = registry.idreg
CROSS JOIN accountingyear (nolock)
WHERE EXISTS (SELECT * FROM expensewageaddition JOIN expenseyear with (nolock) ON expenseyear.idexp = expensewageaddition.idexp WHERE expensewageaddition.ycon = wageaddition.ycon
											AND expensewageaddition.ncon = wageaddition.ncon AND accountingyear.ayear=expenseyear.ayear)



GO
