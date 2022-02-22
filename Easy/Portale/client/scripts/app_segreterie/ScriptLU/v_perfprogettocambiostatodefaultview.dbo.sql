
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


-- CREAZIONE VISTA perfprogettocambiostatodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettocambiostatodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettocambiostatodefaultview]
GO

CREATE VIEW [dbo].[perfprogettocambiostatodefaultview] AS 
SELECT 
 [dbo].perfprogettostatus.title AS perfprogettostatus_title, perfprogettocambiostato.idperfprogettostatus AS perfprogettocambiostato_idperfprogettostatus,
 perfprogettostatusto.title AS perfprogettostatusto_title, perfprogettocambiostato.idperfprogettostatus_to AS perfprogettocambiostato_idperfprogettostatus_to, perfprogettocambiostato.ct AS perfprogettocambiostato_ct, perfprogettocambiostato.cu AS perfprogettocambiostato_cu, perfprogettocambiostato.lt AS perfprogettocambiostato_lt, perfprogettocambiostato.lu AS perfprogettocambiostato_lu, perfprogettocambiostato.idperfprogettocambiostato,
 [dbo].perfruolo.idperfruolo AS perfruolo_idperfruolo, perfprogettocambiostato.idperfruolo, perfprogettocambiostato.idperfruolo_mail AS perfprogettocambiostato_idperfruolo_mail
FROM [dbo].perfprogettocambiostato WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfprogettostatus WITH (NOLOCK) ON perfprogettocambiostato.idperfprogettostatus = [dbo].perfprogettostatus.idperfprogettostatus
LEFT OUTER JOIN [dbo].perfprogettostatus AS perfprogettostatusto WITH (NOLOCK) ON perfprogettocambiostato.idperfprogettostatus_to = perfprogettostatusto.idperfprogettostatus
LEFT OUTER JOIN [dbo].perfruolo WITH (NOLOCK) ON perfprogettocambiostato.idperfruolo = [dbo].perfruolo.idperfruolo
WHERE  perfprogettocambiostato.idperfprogettocambiostato IS NOT NULL 
GO

