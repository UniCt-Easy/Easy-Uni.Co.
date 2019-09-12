-- CREAZIONE VISTA flowchartuserview
IF EXISTS(select * from sysobjects where id = object_id(N'[flowchartuserview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [flowchartuserview]
GO


CREATE VIEW [flowchartuserview]
as 

SELECT 
	flowchart.ayear,
	flowchart.title as flowchart,
	flowchart.nlevel,
	flowchartuser.idflowchart,
	flowchartuser.ndetail,
	flowchartuser.idcustomuser,
	customuser.username,
	flowchartuser.start,
	flowchartuser.stop,
	flowchartuser.flagdefault,
	flowchartuser.idsor01,
	S1.sortcode as sortcode01,
	flowchartuser.idsor02,
	S2.sortcode as sortcode02,
	flowchartuser.idsor03,
	S3.sortcode as sortcode03,
	flowchartuser.idsor04,
	S4.sortcode as sortcode04,
	flowchartuser.idsor05,
	S5.sortcode as sortcode05,
	flowchartuser.title,
	flowchartuser.all_sorkind01,
	flowchartuser.all_sorkind02,
	flowchartuser.all_sorkind03,
	flowchartuser.all_sorkind04,
	flowchartuser.all_sorkind05,
	flowchartuser.sorkind01_withchilds,
	flowchartuser.sorkind02_withchilds,
	flowchartuser.sorkind03_withchilds,
	flowchartuser.sorkind04_withchilds,
	flowchartuser.sorkind05_withchilds
from flowchartuser 
join flowchart 
	on flowchartuser.idflowchart = flowchart.idflowchart
join customuser
	on customuser.idcustomuser = flowchartuser.idcustomuser	
left outer join sorting S1
	on flowchartuser.idsor01 = S1.idsor  
left outer join sorting S2
	on flowchartuser.idsor02 = S2.idsor 
left outer join sorting S3
	on flowchartuser.idsor03 = S3.idsor 
left outer join sorting S4
	on flowchartuser.idsor04 = S4.idsor 
left outer join sorting S5
	on flowchartuser.idsor05 = S5.idsor 

GO

