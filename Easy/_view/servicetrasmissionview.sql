-- CREAZIONE VISTA servicetrasmissionview
IF EXISTS(select * from sysobjects where id = object_id(N'[servicetrasmissionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [servicetrasmissionview]
GO
CREATE   VIEW [servicetrasmissionview]
	AS
	SELECT
	servicetrasmission.idtrasmission,
	servicetrasmission.adate,
	servicetrasmission.idservicetrasmissionkind,
	servicetrasmissionkind.description as servicetrasmissionkind,
	servicetrasmission.idsor01,
	servicetrasmission.idsor02,
	servicetrasmission.idsor03,
	servicetrasmission.idsor04,
	servicetrasmission.idsor05
	from servicetrasmission
	left outer join servicetrasmissionkind
		on servicetrasmission.idservicetrasmissionkind = servicetrasmissionkind.idservicetrasmissionkind


GO




