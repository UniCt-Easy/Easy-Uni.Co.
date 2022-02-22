
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


-- CREAZIONE VISTA accordoscambiomidettsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomidettsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accordoscambiomidettsegview]
GO

CREATE VIEW [dbo].[accordoscambiomidettsegview] AS 
SELECT  accordoscambiomidett.ct AS accordoscambiomidett_ct, accordoscambiomidett.cu AS accordoscambiomidett_cu, accordoscambiomidett.idaccordoscambiomi, accordoscambiomidett.idaccordoscambiomidett,
 [dbo].isced2013.detailedfield AS isced2013_detailedfield, accordoscambiomidett.idisced2013,
 registry_registry_istitutiesteriistitutiesteri.title AS registryistitutiesteri_title, accordoscambiomidett.idreg_istitutiesteri,
 [dbo].torkind.title AS torkind_title, [dbo].torkind.description AS torkind_description, accordoscambiomidett.idtorkind AS accordoscambiomidett_idtorkind, accordoscambiomidett.lt AS accordoscambiomidett_lt, accordoscambiomidett.lu AS accordoscambiomidett_lu, accordoscambiomidett.numdocincoming AS accordoscambiomidett_numdocincoming, accordoscambiomidett.numdocoutgoing AS accordoscambiomidett_numdocoutgoing, accordoscambiomidett.numpersincoming AS accordoscambiomidett_numpersincoming, accordoscambiomidett.numpersoutgoing AS accordoscambiomidett_numpersoutgoing, accordoscambiomidett.numstulearincoming AS accordoscambiomidett_numstulearincoming, accordoscambiomidett.numstulearoutgoing AS accordoscambiomidett_numstulearoutgoing, accordoscambiomidett.numstutraincoming AS accordoscambiomidett_numstutraincoming, accordoscambiomidett.numstutraoutgoing AS accordoscambiomidett_numstutraoutgoing, accordoscambiomidett.stipula AS accordoscambiomidett_stipula, accordoscambiomidett.stop AS accordoscambiomidett_stop
FROM [dbo].accordoscambiomidett WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].isced2013 WITH (NOLOCK) ON accordoscambiomidett.idisced2013 = [dbo].isced2013.idisced2013
LEFT OUTER JOIN [dbo].registry_istitutiesteri AS registry_istitutiesteriistitutiesteri WITH (NOLOCK) ON accordoscambiomidett.idreg_istitutiesteri = registry_istitutiesteriistitutiesteri.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiesteriistitutiesteri WITH (NOLOCK) ON registry_istitutiesteriistitutiesteri.idreg = registry_registry_istitutiesteriistitutiesteri.idreg
LEFT OUTER JOIN [dbo].torkind WITH (NOLOCK) ON accordoscambiomidett.idtorkind = [dbo].torkind.idtorkind
WHERE  accordoscambiomidett.idaccordoscambiomi IS NOT NULL  AND accordoscambiomidett.idaccordoscambiomidett IS NOT NULL  AND accordoscambiomidett.idreg_istitutiesteri IS NOT NULL 
GO

