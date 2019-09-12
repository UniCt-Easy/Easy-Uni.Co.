--clear_table_info'stip_gompview'

-- CREAZIONE VISTA stip_gompview
IF EXISTS(select * from sysobjects where id = object_id(N'[stip_gompview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stip_gompview]
GO

CREATE VIEW [stip_gompview]
(
	idstip_gomp,
	codicecausale,
	annoregolamento,
	fuoricorso,

	idaccmotiverevenue,
	codemotiverevenue,
	accmotiverevenue,
	idaccmotivecredit,
	codemotivecredit,
	accmotivecredit,
	idfinmotive,
	codefinmotive,
	finmotive,
	idaccmotiveundotax,
	codemotiveundotax,
	accmotiveundotax,
	idaccmotiveundotaxpost,
	codemotiveundotaxpost,
	accmotiveundotaxpost,
	tipologiacorso,
	descrizione,
	ct,
	cu,
	lt,
	lu
)
AS  SELECT
	stip_gomp.idstip_gomp,
	stip_gomp.codicecausale,
	stip_gomp.annoregolamento,
	stip_gomp.fuoricorso,

	stip_gomp.idaccmotiverevenue,
	accmotiverevenue.codemotive,
	accmotiverevenue.title,
	stip_gomp.idaccmotivecredit,
	accmotivecredit.codemotive,
	accmotivecredit.title,
	stip_gomp.idfinmotive,
	finmotive.codemotive,
	finmotive.title,
	stip_gomp.idaccmotiveundotax,
	accmotiveundotax.codemotive,
	accmotiveundotax.title,
	stip_gomp.idaccmotiveundotaxpost,
	accmotiveundotaxpost.codemotive,
	accmotiveundotaxpost.title,
	stip_gomp.tipologiacorso,
	stip_gomp.descrizione,
	stip_gomp.ct,
	stip_gomp.cu,
	stip_gomp.lt,
	stip_gomp.lu
FROM stip_gomp
	LEFT OUTER JOIN finmotive ON finmotive.idfinmotive  = stip_gomp.idfinmotive 
	LEFT OUTER JOIN accmotive accmotiverevenue ON accmotiverevenue.idaccmotive  = stip_gomp.idaccmotiverevenue
	LEFT OUTER JOIN accmotive accmotivecredit ON accmotivecredit.idaccmotive  = stip_gomp.idaccmotivecredit
	LEFT OUTER JOIN accmotive accmotiveundotax ON accmotiveundotax.idaccmotive  = stip_gomp.idaccmotiveundotax
	LEFT OUTER JOIN accmotive accmotiveundotaxpost ON accmotiveundotaxpost.idaccmotive  = stip_gomp.idaccmotiveundotaxpost



GO
