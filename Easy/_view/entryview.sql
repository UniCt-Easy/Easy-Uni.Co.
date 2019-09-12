-- CREAZIONE VISTA entryview
IF EXISTS(select * from sysobjects where id = object_id(N'[entryview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW entryview
GO

--select * from entrykind
--select * from entry
--select * from entryview


CREATE    VIEW entryview
(
	yentry,
	nentry,
	adate,
	identrykind,
	entrykind,
	description,
	doc,
	docdate,
	locked,
	credit , 
	debit,
	idrelated,
	official,
	lt,lu,ct,cu,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
e.yentry,
e.nentry,
e.adate,
e.identrykind,
	ek.description,
	e.description,
	e.doc,
	e.docdate,
	e.locked,
	-isnull( (SELECT SUM(amount) FROM entrydetail ed where  ed.yentry=e.yentry and ed.nentry=e.nentry and amount<0) ,0),
	isnull( (SELECT SUM(amount) FROM entrydetail ed where ed.yentry=e.yentry and ed.nentry=e.nentry and amount>0) , 0),
	e.idrelated,
	e.official,
	e.lt,e.lu,e.ct,e.cu,
	e.idsor01,
	e.idsor02,
	e.idsor03,
	e.idsor04,
	e.idsor05
FROM  entry e
LEFT OUTER JOIN entrykind  ek with (nolock)  
	on e.identrykind=ek.identrykind
GO

 

