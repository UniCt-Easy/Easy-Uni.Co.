
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


--setuser 'amministrazione'
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

SELECT        webpaymentview.ywebpayment,
			  webpaymentview.nwebpayment, 
			  webpaymentview.forename, 
			  webpaymentview.surname,
			  webpaymentview.cf, 
			  webpaymentview.idwebpaymentstatus, 
              webpaymentview.webpaymentstatus,
			  webpaymentview.adate, 
			  webpaymentdetail.iddetail,
			  webpaymentdetail.number, 
			  webpaymentdetail.price, 
			  (webpaymentdetail.number * webpaymentdetail.price)+
			  case when webpaymentdetail.tax is null then 0 
					else webpaymentdetail.tax 
			  end as totale, 
			  case when webpaymentdetail.tax is null then 0 
				else webpaymentdetail.tax 
			  end as tax, 
			  case 
				when webpaymentdetail.annotations is null then '' 
				else webpaymentdetail.annotations 
			  end as annotations, 
			  list.description, 
              store.description AS Magazzino, 
			  registryaddress.address, 
			  registryaddress.cap, 
			  registryaddress.location, 
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
FROM            webpaymentview 
INNER JOIN
                webpaymentdetail ON webpaymentview.idwebpayment = webpaymentdetail.idwebpayment
INNER JOIN
                list ON webpaymentdetail.idlist = list.idlist 
INNER JOIN
                store ON webpaymentdetail.idstore = store.idstore
LEFT OUTER JOIN
                registryaddress ON webpaymentview.idreg = registryaddress.idreg
WHERE			webpaymentview.nwebpayment=@nwebpayment and webpaymentview.ywebpayment=@ywebpayment

END


