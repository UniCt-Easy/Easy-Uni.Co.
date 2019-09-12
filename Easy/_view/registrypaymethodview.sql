-- CREAZIONE VISTA registrypaymethodview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrypaymethodview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrypaymethodview]
GO

CREATE  VIEW [DBO].[registrypaymethodview]
(
	idreg, 
	idregistrypaymethod,
	regmodcode, 
	registry, 
	idpaymethod, 
	paymethod, 
	allowdeputy,
	iban,
	cin, 
	idbank, 
	banktitle, 
	idcab, 
	cabtitle, 
	cc, 
	biccode,
	idchargehandling,
	paymentdescr, 
	paymentexpiring, 
	idexpirationkind, 
	flagstandard, 
	active, 
	iddeputy,
	deputy,
	idcurrency,
	codecurrency,
	currency,
        extracode,
        flag,
        refexternaldoc,
        notes,
	cu, ct, lu, lt
)
AS SELECT 
	registrypaymethod.idreg, 
	registrypaymethod.idregistrypaymethod,
	registrypaymethod.regmodcode, 
	registry.title, 
	registrypaymethod.idpaymethod, 
	paymethod.description, 
	paymethod.allowdeputy,
	registrypaymethod.iban,
	registrypaymethod.cin, 
	registrypaymethod.idbank, 
	bank.description, 
	registrypaymethod.idcab, 
	cab.description, 
	registrypaymethod.cc, 
	registrypaymethod.biccode,
	registrypaymethod.idchargehandling,
	registrypaymethod.paymentdescr, 
	registrypaymethod.paymentexpiring, 
	registrypaymethod.idexpirationkind, 
	registrypaymethod.flagstandard, 
	registrypaymethod.active, 
	registrypaymethod.iddeputy,
	deputy.title,
	registrypaymethod.idcurrency,
	currency.codecurrency,
	currency.description,
    registrypaymethod.extracode,
    registrypaymethod.flag,
    registrypaymethod.refexternaldoc,
    registrypaymethod.notes,
	registrypaymethod.cu, registrypaymethod.ct, registrypaymethod.lu, registrypaymethod.lt
FROM registrypaymethod
JOIN registry
	ON registrypaymethod.idreg = registry.idreg 
LEFT OUTER JOIN registry deputy
	ON deputy.idreg = registrypaymethod.iddeputy
LEFT OUTER JOIN paymethod
	ON paymethod.idpaymethod = registrypaymethod.idpaymethod 
LEFT OUTER JOIN bank
	ON bank.idbank = registrypaymethod.idbank 
LEFT OUTER JOIN cab
	ON cab.idbank = registrypaymethod.idbank 
	AND cab.idcab = registrypaymethod.idcab 
LEFT OUTER JOIN currency
	ON currency.idcurrency = registrypaymethod.idcurrency




GO

