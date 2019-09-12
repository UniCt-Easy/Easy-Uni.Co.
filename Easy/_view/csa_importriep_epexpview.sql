-- CREAZIONE VISTA csa_importriepview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importriepepexpview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importriepepexpview]
GO


CREATE       VIEW [csa_importriepepexpview]
(
	idcsa_import,
	idriep,
	ndetail,
	idepexp,
	quota,	
	lu,	lt,cu,ct,
	yepexp,nepexp,idrelated,paridepexp,nphase
)
AS SELECT 
	RE.idcsa_import,
	RE.idriep,
	RE.ndetail,
	RE.idepexp,
	RE.quota,	
	RE.lu,	RE.lt,RE.cu,RE.ct,
	E.yepexp,E.nepexp,E.idrelated,E.paridepexp,E.nphase
FROM csa_importriep_epexp RE
	JOIN epexp E on RE.idepexp=E.idepexp
	

GO
--setuser 'amm'
--clear_table_info 'csa_importriepepexpview'
--select * from csa_importriepepexpview
 