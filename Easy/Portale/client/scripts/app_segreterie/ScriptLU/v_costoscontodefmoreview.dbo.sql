
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


-- CREAZIONE VISTA costoscontodefmoreview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[costoscontodefmoreview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[costoscontodefmoreview]
GO

CREATE VIEW [dbo].[costoscontodefmoreview] AS 
SELECT  costoscontodef.ct AS costoscontodef_ct, costoscontodef.cu AS costoscontodef_cu, costoscontodef.idcostoscontodef,
 [dbo].costoscontodefkind.title AS costoscontodefkind_title, costoscontodef.idcostoscontodefkind AS costoscontodef_idcostoscontodefkind, costoscontodef.lt AS costoscontodef_lt, costoscontodef.lu AS costoscontodef_lu,
 costoscontodefparent.title AS costoscontodefparent_title, costoscontodef.paridcostoscontodef, costoscontodef.title,
 isnull('Titolo: ' + costoscontodef.title + '; ','') as dropdown_title
FROM [dbo].costoscontodef WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].costoscontodefkind WITH (NOLOCK) ON costoscontodef.idcostoscontodefkind = [dbo].costoscontodefkind.idcostoscontodefkind
LEFT OUTER JOIN [dbo].costoscontodef AS costoscontodefparent WITH (NOLOCK) ON costoscontodef.paridcostoscontodef = costoscontodefparent.idcostoscontodef
WHERE  costoscontodef.idcostoscontodef IS NOT NULL 
GO

