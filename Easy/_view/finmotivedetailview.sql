-- CREAZIONE VISTA finmotivedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[finmotivedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finmotivedetailview]
GO
 
CREATE VIEW [finmotivedetailview]
(
	idfinmotive,
	idfin,
	cu,
	ct,
	lu,
	lt,
	finpart,
	codefin,
	finance,
	ayear 
)
	AS SELECT
	finmotivedetail.idfinmotive,
	finmotivedetail.idfin,
	finmotivedetail.cu,
	finmotivedetail.ct,
	finmotivedetail.lu,
	finmotivedetail.lt,
	 CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.codefin,
	fin.title,
	fin.ayear
	FROM finmotivedetail (NOLOCK)
		JOIN fin  on fin.idfin= finmotivedetail.idfin
	





GO
 
 