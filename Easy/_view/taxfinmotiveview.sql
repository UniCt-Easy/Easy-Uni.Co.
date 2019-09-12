-- CREAZIONE VISTA taxfinmotiveview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxfinmotiveview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxfinmotiveview]
GO


CREATE  VIEW [taxfinmotiveview](
	taxcode,
	taxref,
	tax,
	idser,
	service,
	codeser,
	idmotincomeintra, codemotiveincomeintra,finmotive_incomeintra,
	idmotincomeemploy, codemotiveincomeemploy, finmotive_incomeemploy,
	idmotadmintax, codemotiveadmintax, finmotive_admintax,
	idmotexpenseemploy, codemotiveexpenseemploy, finmotive_expenseemploy,
	idmotexpensecontra, codemotiveexpensecontra, finmotive_expensecontra,
	lt,ct,lu,cu
)
AS SELECT
	taxfinmotive.taxcode,	tax.taxref,	tax.description,
	taxfinmotive.idser,	service.description,	service.codeser,
	taxfinmotive.idmotincomeintra,		finmotive_incomeintra.codemotive,	finmotive_incomeintra.title, 
	taxfinmotive.idmotincomeemploy,		finmotive_incomeemploy.codemotive,	finmotive_incomeemploy.title,
	taxfinmotive.idmotadmintax,			finmotive_admintax.codemotive,		finmotive_admintax.title,
	taxfinmotive.idmotexpenseemploy,	finmotive_expenseemploy.codemotive, finmotive_expenseemploy.title,
	taxfinmotive.idmotexpensecontra,	finmotive_expensecontra.codemotive, finmotive_expensecontra.title,
	taxfinmotive.lt,
	taxfinmotive.ct,
	taxfinmotive.lu,
	taxfinmotive.cu
FROM taxfinmotive
join tax
	on taxfinmotive.taxcode= tax.taxcode
join service
	on taxfinmotive.idser = service.idser
left outer join finmotive as finmotive_incomeintra
	on taxfinmotive.idmotincomeintra = finmotive_incomeintra.idfinmotive
left outer join finmotive as finmotive_incomeemploy
	on taxfinmotive.idmotincomeemploy = finmotive_incomeemploy.idfinmotive
left outer join finmotive as finmotive_admintax
	on taxfinmotive.idmotadmintax = finmotive_admintax.idfinmotive
left outer join finmotive as finmotive_expenseemploy
	on taxfinmotive.idmotexpenseemploy = finmotive_expenseemploy.idfinmotive
left outer join finmotive as finmotive_expensecontra
	on taxfinmotive.idmotexpensecontra = finmotive_expensecontra.idfinmotive


GO

