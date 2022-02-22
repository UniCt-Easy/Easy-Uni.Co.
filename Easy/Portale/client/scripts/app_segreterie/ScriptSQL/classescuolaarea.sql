
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


-- CREAZIONE TABELLA classescuolaarea --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuolaarea]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[classescuolaarea] (
idclassescuolaarea int NOT NULL,
title nvarchar(50) NULL,
 CONSTRAINT xpkclassescuolaarea PRIMARY KEY (idclassescuolaarea
)
)
END
GO

-- VERIFICA STRUTTURA classescuolaarea --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolaarea' and C.name = 'idclassescuolaarea' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolaarea] ADD idclassescuolaarea int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolaarea') and col.name = 'idclassescuolaarea' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolaarea] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolaarea' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolaarea] ADD title nvarchar(50) NULL 
END
ELSE
	ALTER TABLE [classescuolaarea] ALTER COLUMN title nvarchar(50) NULL
GO

-- VERIFICA DI classescuolaarea IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'classescuolaarea'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolaarea','int','ASSISTENZA','idclassescuolaarea','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolaarea','nvarchar(50)','ASSISTENZA','title','50','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI classescuolaarea IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'classescuolaarea')
UPDATE customobject set isreal = 'S' where objectname = 'classescuolaarea'
ELSE
INSERT INTO customobject (objectname, isreal) values('classescuolaarea', 'S')
GO

-- GENERAZIONE DATI PER classescuolaarea --
IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '1')
UPDATE [classescuolaarea] SET title = 'Area Sanitaria' WHERE idclassescuolaarea = '1'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('1','Area Sanitaria')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '2')
UPDATE [classescuolaarea] SET title = 'Area Scientifica' WHERE idclassescuolaarea = '2'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('2','Area Scientifica')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '3')
UPDATE [classescuolaarea] SET title = 'Area Sociale' WHERE idclassescuolaarea = '3'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('3','Area Sociale')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '4')
UPDATE [classescuolaarea] SET title = 'Area Umanistica' WHERE idclassescuolaarea = '4'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('4','Area Umanistica')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '5')
UPDATE [classescuolaarea] SET title = 'Area Beni Culturali' WHERE idclassescuolaarea = '5'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('5','Area Beni Culturali')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '6')
UPDATE [classescuolaarea] SET title = 'Area Sanitaria' WHERE idclassescuolaarea = '6'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('6','Area Sanitaria')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '7')
UPDATE [classescuolaarea] SET title = 'Area Psicologica' WHERE idclassescuolaarea = '7'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('7','Area Psicologica')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '8')
UPDATE [classescuolaarea] SET title = 'Area Veterinaria' WHERE idclassescuolaarea = '8'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('8','Area Veterinaria')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '9')
UPDATE [classescuolaarea] SET title = 'Area Reach' WHERE idclassescuolaarea = '9'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('9','Area Reach')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'classescuolaarea')
UPDATE [tabledescr] SET description = 'Area della scuola / classe di laurea',idapplication = null,isdbo = 'N',lt = {ts '2020-05-18 12:14:02.177'},lu = 'assistenza',title = 'Area della scuola / classe di laurea' WHERE tablename = 'classescuolaarea'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('classescuolaarea','Area della scuola / classe di laurea',null,'N',{ts '2020-05-18 12:14:02.177'},'assistenza','Area della scuola / classe di laurea')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuolaarea' AND tablename = 'classescuolaarea')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-18 12:14:04.473'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassescuolaarea' AND tablename = 'classescuolaarea'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuolaarea','classescuolaarea','4',null,null,null,'S',{ts '2020-05-18 12:14:04.473'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'classescuolaarea')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-18 12:14:04.473'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'classescuolaarea'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','classescuolaarea','50',null,null,null,'S',{ts '2020-05-18 12:14:04.473'},'assistenza','N','nvarchar(50)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

