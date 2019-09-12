 -- CREAZIONE VISTA paymenttransmissionview
IF EXISTS(select * from sysobjects where id = object_id(N'[paymenttransmissionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [paymenttransmissionview]
GO
 


CREATE  VIEW paymenttransmissionview 
	(
	kpaymenttransmission,
	ypaymenttransmission,
  	npaymenttransmission,
	idman,
	manager,
	idtreasurer,
	codetreasurer,
	treasurer,
  	transmissiondate,
	total,
	flagmailsent,
	transmissionkind,
	streamdate,
	bankdate,
	flagtransmissionenabled,
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
	paymenttransmission.kpaymenttransmission,
	paymenttransmission.ypaymenttransmission,
  	paymenttransmission.npaymenttransmission,
	paymenttransmission.idman,
	manager.title,
	paymenttransmission.idtreasurer,
	treasurer.codetreasurer,
	treasurer.description,
 	paymenttransmission.transmissiondate,
	ISNULL((SELECT SUM(ISNULL(total,0)) FROM paymentview d 
	WHERE d.kpaymenttransmission = paymenttransmission.kpaymenttransmission ),0),
	paymenttransmission.flagmailsent,
	paymenttransmission.transmissionkind,
	paymenttransmission.streamdate,
	paymenttransmission.bankdate,
	paymenttransmission.flagtransmissionenabled,
	treasurer.idsor01,
	treasurer.idsor02,
	treasurer.idsor03,
	treasurer.idsor04,
	treasurer.idsor05,
 	paymenttransmission.cu,
  	paymenttransmission.ct,
  	paymenttransmission.lu,
  	paymenttransmission.lt
	FROM paymenttransmission
	LEFT OUTER JOIN manager
	ON manager.idman = paymenttransmission.idman
	LEFT OUTER JOIN treasurer 
	ON treasurer.idtreasurer = paymenttransmission.idtreasurer






GO
 

