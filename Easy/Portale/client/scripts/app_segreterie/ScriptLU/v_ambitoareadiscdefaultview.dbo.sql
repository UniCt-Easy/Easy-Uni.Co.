
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


-- CREAZIONE VISTA ambitoareadiscdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ambitoareadiscdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ambitoareadiscdefaultview]
GO

CREATE VIEW [dbo].[ambitoareadiscdefaultview] AS 
SELECT  ambitoareadisc.idambitoareadisc,
 [dbo].classescuola.sigla AS classescuola_sigla, [dbo].classescuola.title AS classescuola_title, ambitoareadisc.idclassescuola,
 [dbo].tipoattform.title AS tipoattform_title, [dbo].tipoattform.description AS tipoattform_description, ambitoareadisc.idtipoattform AS ambitoareadisc_idtipoattform, ambitoareadisc.indicecineca AS ambitoareadisc_indicecineca, ambitoareadisc.lt AS ambitoareadisc_lt, ambitoareadisc.lu AS ambitoareadisc_lu, ambitoareadisc.sortcode AS ambitoareadisc_sortcode, ambitoareadisc.title,
 isnull('Ambito: ' + ambitoareadisc.title + '; ','') as dropdown_title
FROM [dbo].ambitoareadisc WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].classescuola WITH (NOLOCK) ON ambitoareadisc.idclassescuola = [dbo].classescuola.idclassescuola
LEFT OUTER JOIN [dbo].tipoattform WITH (NOLOCK) ON ambitoareadisc.idtipoattform = [dbo].tipoattform.idtipoattform
WHERE  ambitoareadisc.idambitoareadisc IS NOT NULL 
GO


-- GENERAZIONE DATI PER ambitoareadiscdefaultview --
