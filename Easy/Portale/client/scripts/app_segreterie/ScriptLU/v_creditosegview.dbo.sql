
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


-- CREAZIONE VISTA creditosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[creditosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[creditosegview]
GO

CREATE VIEW [dbo].[creditosegview] AS 
SELECT CASE WHEN credito.autorizzato = 'S' THEN 'Si' WHEN credito.autorizzato = 'N' THEN 'No' END AS credito_autorizzato, credito.ct AS credito_ct, credito.cu AS credito_cu, credito.idcredito, credito.iddebito, credito.idpagamento, credito.idreg, credito.lt AS credito_lt, credito.lu AS credito_lu
FROM [dbo].credito WITH (NOLOCK) 
WHERE  credito.idcredito IS NOT NULL  AND credito.iddebito IS NOT NULL  AND credito.idpagamento IS NOT NULL  AND credito.idreg IS NOT NULL 
GO

