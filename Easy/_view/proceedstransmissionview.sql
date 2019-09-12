-- CREAZIONE VISTA proceedstransmissionview
IF EXISTS(select * from sysobjects where id = object_id(N'[proceedstransmissionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceedstransmissionview]
GO

CREATE  VIEW proceedstransmissionview 
	(
	kproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	idman,
	manager,
	idtreasurer,
	codetreasurer,
	treasurer,
	transmissiondate,
	total,
	transmissionkind,
	streamdate,
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
	proceedstransmission.kproceedstransmission,
	proceedstransmission.yproceedstransmission,
 	proceedstransmission.nproceedstransmission,
	proceedstransmission.idman,
	manager.title,
	proceedstransmission.idtreasurer,
	treasurer.codetreasurer,
	treasurer.description,
 	proceedstransmission.transmissiondate,
	ISNULL((SELECT SUM(ISNULL(total,0)) FROM proceedsview d 
	WHERE d.kproceedstransmission = proceedstransmission.kproceedstransmission),0),
	proceedstransmission.transmissionkind,
	proceedstransmission.streamdate,
	proceedstransmission.flagtransmissionenabled,
	treasurer.idsor01,
	treasurer.idsor02,
	treasurer.idsor03,
	treasurer.idsor04,
	treasurer.idsor05,
	proceedstransmission.cu,
	proceedstransmission.ct,
	proceedstransmission.lu,
	proceedstransmission.lt
	FROM proceedstransmission 
	LEFT OUTER JOIN manager 
	ON manager.idman = proceedstransmission.idman
	LEFT OUTER JOIN treasurer 
	ON treasurer.idtreasurer = proceedstransmission.idtreasurer

 

GO

