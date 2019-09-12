-- CREAZIONE VISTA webpaymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[webpaymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [webpaymentview]
GO



-- clear_table_info'webpaymentview'
-- select * from webpaymentview
-- sp_help webpaymentview

CREATE  VIEW [webpaymentview] as
(
	select P.idwebpayment as idwebpayment,
		   P.ywebpayment as ywebpayment,
		   P.nwebpayment as nwebpayment,
		   R.idreg,
		   R.forename as forename,
		   R.surname  as surname,
		   R.cf as cf,
		   P.idcustomuser as idcustomuser,
		   P.idwebpaymentstatus,
		   PS.description as webpaymentstatus,
		   P.adate 
	from webpayment P
	join registry R
		on P.idreg = R.idreg
	join webpaymentstatus PS
		on P.idwebpaymentstatus = PS.idwebpaymentstatus

)


GO
