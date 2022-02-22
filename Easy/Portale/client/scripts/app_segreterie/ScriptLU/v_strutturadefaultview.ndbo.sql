
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


-- CREAZIONE VISTA strutturadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[strutturadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [strutturadefaultview]
GO

CREATE VIEW [strutturadefaultview] AS 
SELECT  struttura.codice AS struttura_codice, struttura.codiceipa AS struttura_codiceipa, struttura.ct AS struttura_ct, struttura.cu AS struttura_cu, struttura.email AS struttura_email, struttura.fax AS struttura_fax,
 [dbo].aoo.title AS aoo_title, struttura.idaoo AS struttura_idaoo, struttura.idreg AS struttura_idreg,
 [dbo].sede.title AS sede_title, struttura.idsede AS struttura_idsede, struttura.idstruttura,
 [dbo].strutturakind.title AS strutturakind_title, struttura.idstrutturakind AS struttura_idstrutturakind,
 upb.title AS upb_title, struttura.idupb, struttura.lt AS struttura_lt, struttura.lu AS struttura_lu,
 strutturaparent.title AS strutturaparent_title, strutturakind_struttura.title AS strutturakind_struttura_title, strutturaparent.idstrutturakind AS strutturaparent_idstrutturakind, struttura.paridstruttura, struttura.pesoindicatori AS struttura_pesoindicatori, struttura.pesoobiettivi AS struttura_pesoobiettivi, struttura.pesoprogaltreuo AS struttura_pesoprogaltreuo, struttura.pesoproguo AS struttura_pesoproguo, struttura.telefono AS struttura_telefono, struttura.title, struttura.title_en AS struttura_title_en,
 isnull('Denominazione: ' + struttura.title + '; ','') + ' ' + isnull('Tipo: ' + [dbo].strutturakind.title + '; ','') as dropdown_title
FROM [dbo].struttura WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON struttura.idaoo = [dbo].aoo.idaoo
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON struttura.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN upb WITH (NOLOCK) ON struttura.idupb = upb.idupb
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON struttura.paridstruttura = strutturaparent.idstruttura
LEFT OUTER JOIN [dbo].strutturakind AS strutturakind_struttura WITH (NOLOCK) ON strutturaparent.idstrutturakind = strutturakind_struttura.idstrutturakind
WHERE  struttura.idstruttura IS NOT NULL 
GO

