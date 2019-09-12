-- CREAZIONE VISTA ct_asscreddetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[ct_asscreddetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ct_asscreddetailview]
GO

CREATE                                VIEW ct_asscreddetailview
	(
	idct_asscred,
	idfin_income,
	yfinincome,
	finincomecode,
	finincometitle,
	idfin_expense,
	yfinexpense,
	finexpensecode,
	finexpensetitle,
	idsor, sortcode, sorting,
	quota,
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
	ct_asscreddetail.idfin_expense,
	bilanciospesa.ayear,
	bilanciospesa.codefin,
	bilanciospesa.title,
	ct_asscred.idsor, sorting.sortcode,sorting.description,
	ct_asscreddetail.quota,
	ct_asscreddetail.cu,
	ct_asscreddetail.ct,
	ct_asscreddetail.lu,
	ct_asscreddetail.lt
	FROM ct_asscred (NOLOCK)
	join sorting
		on ct_asscred.idsor =sorting.idsor
	JOIN fin bilancioentrata (NOLOCK)
		ON bilancioentrata.idfin = ct_asscred.idfin_income
	join ct_asscreddetail (NOLOCK)
		on ct_asscred.idct_asscred = ct_asscreddetail.idct_asscred
	JOIN fin bilanciospesa (NOLOCK)
		ON bilanciospesa.idfin = ct_asscreddetail.idfin_expense
		

GO

