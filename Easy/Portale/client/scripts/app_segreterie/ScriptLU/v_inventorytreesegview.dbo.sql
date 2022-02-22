
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


-- CREAZIONE VISTA inventorytreesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytreesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inventorytreesegview]
GO



CREATE VIEW [dbo].[inventorytreesegview] AS SELECT  inventorytree.codeinv, inventorytree.ct AS inventorytree_ct, inventorytree.cu AS inventorytree_cu, inventorytree.description AS inventorytree_description, inventorytree.idaccmotivediscount AS inventorytree_idaccmotivediscount, [dbo].accmotive.codemotive AS accmotive_codemotive, [dbo].accmotive.title AS accmotive_title, inventorytree.idaccmotiveload, inventorytree.idaccmotivetransfer AS inventorytree_idaccmotivetransfer, inventorytree.idaccmotiveunload AS inventorytree_idaccmotiveunload, inventorytree.idinv, inventorytree.lookupcode AS inventorytree_lookupcode, inventorytree.lt AS inventorytree_lt, inventorytree.lu AS inventorytree_lu, inventorytree.nlevel AS inventorytree_nlevel, inventorytreeparent.codeinv AS inventorytreeparent_codeinv, inventorytreeparent.description AS inventorytreeparent_description, inventorytree.paridinv, inventorytree.rtf AS inventorytree_rtf, inventorytree.txt AS inventorytree_txt, isnull('Codice: ' + inventorytree.codeinv + '; ','') + ' ' + isnull('Denominazione: ' + inventorytree.description + '; ','') as dropdown_title FROM [dbo].inventorytree WITH (NOLOCK)  LEFT OUTER JOIN [dbo].accmotive WITH (NOLOCK) ON inventorytree.idaccmotiveload = [dbo].accmotive.idaccmotive LEFT OUTER JOIN [dbo].inventorytree AS inventorytreeparent WITH (NOLOCK) ON inventorytree.paridinv = inventorytreeparent.idinv WHERE  inventorytree.idinv IS NOT NULL 

GO

