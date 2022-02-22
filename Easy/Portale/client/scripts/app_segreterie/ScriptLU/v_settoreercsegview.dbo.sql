
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


-- CREAZIONE VISTA settoreercsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[settoreercsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[settoreercsegview]
GO



CREATE VIEW [dbo].[settoreercsegview] AS SELECT CASE WHEN settoreerc.active = 'S' THEN 'Si' WHEN settoreerc.active = 'N' THEN 'No' END AS settoreerc_active, settoreerc.ct AS settoreerc_ct, settoreerc.cu AS settoreerc_cu, settoreerc.description AS settoreerc_description, settoreerc.idsettoreerc, settoreerc.lt AS settoreerc_lt, settoreerc.lu AS settoreerc_lu, settoreerc.sortcode AS settoreerc_sortcode, settoreerc.title, isnull('Titolo: ' + settoreerc.title + '; ','') as dropdown_title FROM [dbo].settoreerc WITH (NOLOCK)  WHERE  settoreerc.idsettoreerc IS NOT NULL 

GO

