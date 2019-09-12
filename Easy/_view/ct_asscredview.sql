-- CREAZIONE VISTA ct_asscredview
IF EXISTS(select * from sysobjects where id = object_id(N'[ct_asscredview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ct_asscredview]
GO

CREATE                                VIEW ct_asscredview
	(
	idct_asscred,
	idfin_income,
	yfinincome,
	finincomecode,
	finincometitle,
	idsor, sortcode, sorting,
	cu,
	ct,
	lu,
	lt
 	)
	AS SELECT
	ct_asscred.idct_asscred,
	ct_asscred.idfin_income,
	bilancioentrata.ayear,
	bilancioentrata.codefin,
	bilancioentrata.title,
	sorting.idsor, sorting.sortcode, sorting.description,
	ct_asscred.cu,
	ct_asscred.ct,
	ct_asscred.lu,
	ct_asscred.lt
	FROM ct_asscred (NOLOCK)
	JOIN fin bilancioentrata (NOLOCK)
		ON bilancioentrata.idfin = ct_asscred.idfin_income
	join sorting 
		on sorting.idsor = ct_asscred.idsor



GO

-- clear_table_info'ct_asscredview'