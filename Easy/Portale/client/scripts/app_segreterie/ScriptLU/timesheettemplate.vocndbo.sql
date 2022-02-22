
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


-- VERIFICA DI timesheettemplate IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'timesheettemplate'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','timesheettemplate','varchar(60)','assistenza','idtimesheettemplate','60','S','varchar','System.String','','','''assistenza''','','S')
GO

-- VERIFICA DI timesheettemplate IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'timesheettemplate')
UPDATE customobject set isreal = 'S' where objectname = 'timesheettemplate'
ELSE
INSERT INTO customobject (objectname, isreal) values('timesheettemplate', 'S')
GO
