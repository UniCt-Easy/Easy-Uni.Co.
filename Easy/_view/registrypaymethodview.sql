
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
	cu, ct, lu, lt,
	ccdedicato_stop
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
	registrypaymethod.cu, registrypaymethod.ct, registrypaymethod.lu, registrypaymethod.lt,
	registrypaymethod.ccdedicato_stop
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

