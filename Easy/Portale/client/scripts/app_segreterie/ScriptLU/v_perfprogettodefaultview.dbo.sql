
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


-- CREAZIONE VISTA perfprogettodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettodefaultview]
GO

CREATE VIEW [dbo].[perfprogettodefaultview] AS 
SELECT  perfprogetto.idperfprogetto,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, perfprogetto.idstruttura, perfprogetto.title, perfprogetto.description AS perfprogetto_description, perfprogetto.datainizioprevista AS perfprogetto_datainizioprevista, perfprogetto.datafineprevista AS perfprogetto_datafineprevista, perfprogetto.datainizioeffettiva AS perfprogetto_datainizioeffettiva, perfprogetto.datafineeffettiva AS perfprogetto_datafineeffettiva, perfprogetto.risultato AS perfprogetto_risultato,
 [dbo].perfprogettostatus.title AS perfprogettostatus_title, perfprogetto.idperfprogettostatus AS perfprogetto_idperfprogettostatus, perfprogetto.note AS perfprogetto_note,
 [dbo].didprogsuddannokind.title AS didprogsuddannokind_title, perfprogetto.iddidprogsuddannokind AS perfprogetto_iddidprogsuddannokind, perfprogetto.benefici AS perfprogetto_benefici, perfprogetto.ct AS perfprogetto_ct, perfprogetto.cu AS perfprogetto_cu, perfprogetto.lt AS perfprogetto_lt, perfprogetto.lu AS perfprogetto_lu,
 isnull('Titolo: ' + perfprogetto.title + '; ','') as dropdown_title
FROM [dbo].perfprogetto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON perfprogetto.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN [dbo].perfprogettostatus WITH (NOLOCK) ON perfprogetto.idperfprogettostatus = [dbo].perfprogettostatus.idperfprogettostatus
LEFT OUTER JOIN [dbo].didprogsuddannokind WITH (NOLOCK) ON perfprogetto.iddidprogsuddannokind = [dbo].didprogsuddannokind.iddidprogsuddannokind
WHERE  perfprogetto.idperfprogetto IS NOT NULL 
GO

