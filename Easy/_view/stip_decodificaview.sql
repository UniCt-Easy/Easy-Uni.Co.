 -- CREAZIONE VISTA stip_decodificaview
IF EXISTS(select * from sysobjects where id = object_id(N'[stip_decodificaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stip_decodificaview]
GO

--setuser'amm'
CREATE  VIEW [stip_decodificaview]
(
	idstipdecodifica,
	idstiptassa,
	codicetassa,
	tassa,
	idstipvoce,
	codicevoce,
	voce,
	idstipcorsolaurea,
	codicecorsolaurea,
	corsolaurea,
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
	ct,
	cu,
	lt,
	lu
)
AS  SELECT
	stip_decodifica.idstipdecodifica,
	stip_decodifica.idstiptassa,
	stip_tassa.codicetassa,
	stip_tassa.descrizione,
	stip_decodifica.idstipvoce,
	stip_voce.codicevoce,
	stip_voce.descrizione,
	stip_corsolaurea.idstipcorsolaurea,
	stip_corsolaurea.codicecorsolaurea,
	stip_corsolaurea.descrizione,
	stip_decodifica.idaccmotiverevenue,
	accmotiverevenue.codemotive,
	accmotiverevenue.title,
	stip_decodifica.idaccmotivecredit,
	accmotivecredit.codemotive,
	accmotivecredit.title,
	stip_decodifica.idfinmotive,
	finmotive.codemotive,
	finmotive.title,
	stip_decodifica.idaccmotiveundotax,
	accmotiveundotax.codemotive,
	accmotiveundotax.title,
	stip_decodifica.idaccmotiveundotaxpost,
	accmotiveundotaxpost.codemotive,
	accmotiveundotaxpost.title,
	stip_decodifica.ct,
	stip_decodifica.cu,
	stip_decodifica.lt,
	stip_decodifica.lu
FROM stip_decodifica
	JOIN stip_tassa ON stip_tassa.idstiptassa = stip_decodifica.idstiptassa 
	JOIN stip_voce  ON stip_voce.idstipvoce  = stip_decodifica.idstipvoce
	LEFT OUTER JOIN stip_corsolaurea  ON stip_corsolaurea.idstipcorsolaurea  = stip_decodifica.idstipcorsolaurea
	LEFT OUTER JOIN finmotive ON finmotive.idfinmotive  = stip_decodifica.idfinmotive 
	LEFT OUTER JOIN accmotive accmotiverevenue ON accmotiverevenue.idaccmotive  = stip_decodifica.idaccmotiverevenue
	LEFT OUTER JOIN accmotive accmotivecredit ON accmotivecredit.idaccmotive  = stip_decodifica.idaccmotivecredit
	LEFT OUTER JOIN accmotive accmotiveundotax ON accmotiveundotax.idaccmotive  = stip_decodifica.idaccmotiveundotax
	LEFT OUTER JOIN accmotive accmotiveundotaxpost ON accmotiveundotaxpost.idaccmotive  = stip_decodifica.idaccmotiveundotaxpost


GO


