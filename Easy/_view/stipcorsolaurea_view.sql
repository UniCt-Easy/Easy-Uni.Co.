-- CREAZIONE VISTA stockview
IF EXISTS(select * from sysobjects where id = object_id(N'[stip_corsolaureaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stip_corsolaureaview]
GO




--clear_table_info'stip_corsolaureaview'
--setuser 'amm'
--select * from stip_corsolaureaview
create  VIEW [stip_corsolaureaview]
(
	idstipcorsolaurea,
		codicecorsolaurea,descrizionecorsolaurea,
		codicedipartimento,dipartimento,
		codicesede,sede,
		codicepercorso,percorso,
		anno,
		idupb,descrizione,
		ct,lt,cu,lu,
		codiceupb,upb,
		codicecausale,causale)
AS
SELECT
	idstipcorsolaurea,codicecorsolaurea,descrizionecorsolaurea,codicedipartimento,dipartimento,codicesede,sede,codicepercorso,percorso,anno,
		stip_corsolaurea.idupb,descrizione,
		stip_corsolaurea.ct,stip_corsolaurea.lt,stip_corsolaurea.cu,stip_corsolaurea.lu,
		upb.codeupb,upb.title,
		stip_corsolaurea.codicecausale,stip_corsolaurea.causale
FROM stip_corsolaurea
left outer join upb on stip_corsolaurea.idupb=upb.idupb
GO

