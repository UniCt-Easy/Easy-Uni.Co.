if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_stima_pagopa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_stima_pagopa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--SELECT PARAMETER_NAME, ORDINAL_POSITION, DATA_TYPE  FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='esporta_stima_pagopa'
--esporta_stima_pagopa 2018

CREATE   PROCEDURE [esporta_stima_pagopa]
	 @ayear smallint
AS BEGIN
declare @tot table(tipo varchar(100),tot decimal(19,2),num decimal(19,2), minimo decimal(19,2),massimo decimal(19,2))
declare @fattcomm table(tipo varchar(100),tot decimal(19,2),num decimal(19,2), minimo decimal(19,2),massimo decimal(19,2))
declare @nofattcomm table(tipo varchar(100),tot decimal(19,2),num decimal(19,2), minimo decimal(19,2),massimo decimal(19,2))

insert into @tot(tipo,tot,num,minimo,massimo)
SELECT 'Tutti gli incassi',
	SUM(IT.curramount),count(*),MIN(IT.curramount),MAX(IT.curramount)
FROM incometotal IT
 join  income I on IT.idinc=I.idinc
 join  incomelast IL on I.idinc=IL.idinc
 join registry r on I.idreg=r.idreg

 where IT.ayear=@ayear
	and r.flagbankitaliaproceeds='N'
	and I.idpayment is null
	

insert into @fattcomm(tipo,tot,num,minimo,massimo)
SELECT 'Fatture attive',
	SUM(IT.curramount),count(*),MIN(IT.curramount),MAX(IT.curramount)
FROM incometotal IT
 join  income I on IT.idinc=I.idinc
 join incomeinvoice IINV on IINV.idinc=I.idinc
 join  incomelast IL on I.idinc=IL.idinc
 join registry r on I.idreg=r.idreg

 where IT.ayear=@ayear
	and r.flagbankitaliaproceeds='N'
	and I.idpayment is null	

END

insert into @fattcomm(tipo,tot,num,minimo,massimo)
SELECT 'Non fatture attive',
	SUM(IT.curramount),count(*),MIN(IT.curramount),MAX(IT.curramount)
FROM incometotal IT
 join  income I on IT.idinc=I.idinc 
 join  incomelast IL on I.idinc=IL.idinc
 join registry r on I.idreg=r.idreg
 where IT.ayear=@ayear
	and r.flagbankitaliaproceeds='N'
	and I.idpayment is null	
	and not exists (select * from incomeinvoice IV where IV.idinc=I.idinc)


select tipo,tot,num,minimo,massimo, convert(decimal(19,2),round(tot/num,2)) as medio from @tot
	union all
select tipo,tot,num,minimo,massimo,    convert(decimal(19,2),round(tot/num,2))as medio from @fattcomm
	union all
select tipo,tot,num,minimo,massimo,  convert(decimal(19,2),round(tot/num,2))as medio from @nofattcomm

--esporta_stima_pagopa 2015

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


