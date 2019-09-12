
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_carrello]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_carrello]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

CREATE  PROCEDURE [rpt_carrello]
(
	@nwebpayment int,
	@ywebpayment smallint
)
AS BEGIN

SELECT        webpaymentview.ywebpayment, webpaymentview.nwebpayment, webpaymentview.forename, webpaymentview.surname, webpaymentview.cf, webpaymentview.idwebpaymentstatus, 
                         webpaymentview.webpaymentstatus, webpaymentview.adate, webpaymentdetail.number, webpaymentdetail.price, (webpaymentdetail.number * webpaymentdetail.price)+case when webpaymentdetail.tax is null then 0 else webpaymentdetail.tax end as totale , case when webpaymentdetail.tax is null then 0 else webpaymentdetail.tax end as tax, case when webpaymentdetail.annotations is null then '' else webpaymentdetail.annotations end as annotations, list.description, 
                          store.description AS Magazzino, registryaddress.address, registryaddress.cap, registryaddress.location, 
						  (SELECT sum(webpaymentdetail.number)
											FROM webpaymentview INNER JOIN
												 webpaymentdetail ON webpaymentview.idwebpayment = webpaymentdetail.idwebpayment
											WHERE webpaymentview.nwebpayment = @nwebpayment and webpaymentview.ywebpayment=@ywebpayment
											GROUP BY webpaymentview.ywebpayment, webpaymentview.nwebpayment) as qttot,
						  (SELECT sum((webpaymentdetail.price * webpaymentdetail.number)+case when webpaymentdetail.tax is null then 0 else webpaymentdetail.tax end)
											FROM webpaymentview INNER JOIN
												 webpaymentdetail ON webpaymentview.idwebpayment = webpaymentdetail.idwebpayment
											WHERE webpaymentview.nwebpayment = @nwebpayment and webpaymentview.ywebpayment=@ywebpayment
											GROUP BY webpaymentview.ywebpayment, webpaymentview.nwebpayment) as prezzotot
FROM            webpaymentview INNER JOIN
                         webpaymentdetail ON webpaymentview.idwebpayment = webpaymentdetail.idwebpayment INNER JOIN
                         list ON webpaymentdetail.idlist = list.idlist INNER JOIN
                         store ON webpaymentdetail.idstore = store.idstore LEFT OUTER JOIN
                         registryaddress ON webpaymentview.idreg = registryaddress.idreg
WHERE        webpaymentview.nwebpayment=@nwebpayment and webpaymentview.ywebpayment=@ywebpayment

END


