
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


-- CREAZIONE VISTA debitosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[debitosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[debitosegview]
GO

CREATE VIEW [dbo].[debitosegview] AS 
SELECT  debito.codicebollettino AS debito_codicebollettino, debito.codicemav AS debito_codicemav, debito.ct AS debito_ct, debito.cu AS debito_cu, debito.iddebito,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, debito.idiscrizione,
 [dbo].istanza.aa AS istanza_aa, [dbo].istanza.extension AS istanza_extension, debito.idistanza,
 [dbo].nullaosta.data AS nullaosta_data, debito.idnullaosta, debito.idreg,
 [dbo].tassaconf.title AS tassaconf_title, debito.idtassaconf, debito.IUV AS debito_IUV, debito.lt AS debito_lt, debito.lu AS debito_lu, debito.scadenza AS debito_scadenza, debito.title,
 isnull('Denominazione: ' + debito.title + '; ','') as dropdown_title
FROM [dbo].debito WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON debito.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].istanza WITH (NOLOCK) ON debito.idistanza = [dbo].istanza.idistanza
LEFT OUTER JOIN [dbo].nullaosta WITH (NOLOCK) ON debito.idnullaosta = [dbo].nullaosta.idnullaosta
LEFT OUTER JOIN [dbo].tassaconf WITH (NOLOCK) ON debito.idtassaconf = [dbo].tassaconf.idtassaconf
WHERE  debito.iddebito IS NOT NULL  AND debito.idreg IS NOT NULL 
GO

