-- CREAZIONE VISTA ivapaydetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[ivapaydetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ivapaydetailview]
GO







CREATE  VIEW [ivapaydetailview]
(
	yivapay,
	nivapay,
	start,
	stop,
	idivaregisterkind,
	codeivaregisterkind,
	description,
	registerclass,
	iva,
	ivadeferred,
	ivatotal,
	unabatable,
	unabatabledeferred,
	unabatabletotal,
	prorata,
	mixed,
	ivanet,
	ivanetdeferred,
	flagactivity,
	cu, 
	ct, 
	lu, 
	lt,
	idtreasurer,
	department
	)
	AS SELECT
	ivapaydetail.yivapay,
	ivapaydetail.nivapay,
	ivapay.start,
	ivapay.stop,
	ivapaydetail.idivaregisterkind,
	ivaregisterkind.codeivaregisterkind,
	ivaregisterkind.description,
	ivaregisterkind.registerclass,
	ivapaydetail.iva,
	ivapaydetail.ivadeferred,
	ISNULL(ivapaydetail.iva,0) + ISNULL(ivapaydetail.ivadeferred,0),
	ivapaydetail.unabatable,
	ivapaydetail.unabatabledeferred,
	ISNULL(ivapaydetail.unabatable,0) + ISNULL(ivapaydetail.unabatabledeferred,0),
	ivapaydetail.prorata,
	ivapaydetail.mixed,
	ivapaydetail.ivanet,
	ivapaydetail.ivanetdeferred,
	ivaregisterkind.flagactivity,
	ivapaydetail.cu, 
	ivapaydetail.ct, 
	ivapaydetail.lu,
	ivapaydetail.lt,
	ivaregisterkind.idtreasurer,
	isnull(treasurer.header,treasurer.description)
	FROM ivapaydetail (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
	ON ivaregisterkind.idivaregisterkind = ivapaydetail.idivaregisterkind
  JOIN ivapay (NOLOCK)
	ON ivapay.nivapay = ivapaydetail.nivapay
	AND ivapay.yivapay = ivapaydetail.yivapay
 left outer join treasurer (NOLOCK)
	ON treasurer.idtreasurer = ivaregisterkind.idtreasurer
	

GO

--clear_table_info 'ivapaydetailview'
--select * from ivapaydetailview