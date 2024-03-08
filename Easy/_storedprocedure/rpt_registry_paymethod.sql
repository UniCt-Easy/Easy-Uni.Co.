
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


/* Versione 1.0.0 del 10/09/2007 ultima modifica: PIERO */


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registry_paymethod]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registry_paymethod]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE     PROCEDURE [rpt_registry_paymethod]
(
		@idreg int
)
AS BEGIN



SELECT 
	
	registry.idreg, 

-- mod pagamento 
        registrypaymethod.idregistrypaymethod,
	registrypaymethod.regmodcode, 
	paymethod.description as paymethod, 
	registrypaymethod.cin, 
	registrypaymethod.idbank as idbank, 
	bank.description as bank, 
	registrypaymethod.idcab as idcab, 
	cab.description as cab, 
	registrypaymethod.cc, 
	registrypaymethod.iban, 
	registrypaymethod.paymentdescr, 
	REPLACE(expirationkind.shorttitle,'%',isnull(registrypaymethod.paymentexpiring,'')) as expiration,
	registrypaymethod.flagstandard as standard, 
	deputy.title,
	currency.description as currency
FROM registry
-- modalita di pagamento
LEFT OUTER JOIN registrypaymethod
	ON registry.idreg = registrypaymethod.idreg AND isnull(registrypaymethod.active,'N')='S'
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
LEFT OUTER JOIN expirationkind 
	ON expirationkind.idexpirationkind = registrypaymethod.idexpirationkind


WHERE (registry.idreg = @idreg OR @idreg is null)
	
		


END







GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

