-- CREAZIONE VISTA csa_importriepview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importverepexpview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importverepexpview]
GO


CREATE       VIEW [csa_importverepexpview]
(
	idcsa_import,
	idver,
	ndetail,
	idepexp,
	quota,	
	lu,	lt,cu,ct,
	yepexp,nepexp,idrelated,paridepexp,nphase		
)
AS SELECT 
	RE.idcsa_import,
	RE.idver,
	RE.ndetail,
	RE.idepexp,
	RE.quota,	
	RE.lu,	RE.lt,RE.cu,RE.ct,
	E.yepexp,E.nepexp,E.idrelated,E.paridepexp,E.nphase
FROM csa_importver_epexp RE
	JOIN epexp E on RE.idepexp=E.idepexp
	

GO
--setuser 'amm'
--clear_table_info 'csa_importverepexpview'
--select * from csa_importverepexpview
 