
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


-- VERIFICA DI annoaccademico IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'annoaccademico'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','annoaccademico','nvarchar(9)','ASSISTENZA','aa','9','S','nvarchar','System.String','','','''ASSISTENZA''','','S')
GO

-- VERIFICA DI annoaccademico IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'annoaccademico')
UPDATE customobject set isreal = 'S' where objectname = 'annoaccademico'
ELSE
INSERT INTO customobject (objectname, isreal) values('annoaccademico', 'S')
GO
