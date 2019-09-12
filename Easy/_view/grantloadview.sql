-- CREAZIONE VISTA assetview
IF EXISTS(select * from sysobjects where id = object_id(N'[grantloadview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [grantloadview]
GO
 


--setuser 'amm'
--select * from grantloadview
--clear_table_info 'grantloadview'
CREATE     VIEW [grantloadview]
(
	idgrantload,
	description,
	kind,
	kind_ext,
	yload,
	adate,
	lt,lu,ct,cu
)
AS SELECT
	idgrantload,
	description,
	kind,
	case when kind='D' then 'Apertura Risconto' else 'Consumo Risconto' end ,
	yload,
	adate,
	lt,lu,ct,cu
FROM grantload (NOLOCK) 



GO


 