
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


--[DBO]--
-- CREAZIONE TABELLA changeskind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[changeskind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[changeskind] (
idchangeskind int NOT NULL,
active char(1) NOT NULL,
description varchar(10) NULL,
idchanges int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(256) NOT NULL,
 CONSTRAINT xpkchangeskind PRIMARY KEY (idchangeskind
)
)
END
GO

-- VERIFICA STRUTTURA changeskind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'changeskind' and C.name = 'idchangeskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [changeskind] ADD idchangeskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('changeskind') and col.name = 'idchangeskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [changeskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'changeskind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [changeskind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('changeskind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [changeskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [changeskind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'changeskind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [changeskind] ADD description varchar(10) NULL 
END
ELSE
	ALTER TABLE [changeskind] ALTER COLUMN description varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'changeskind' and C.name = 'idchanges' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [changeskind] ADD idchanges int NULL 
END
ELSE
	ALTER TABLE [changeskind] ALTER COLUMN idchanges int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'changeskind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [changeskind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('changeskind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [changeskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [changeskind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'changeskind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [changeskind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('changeskind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [changeskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [changeskind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'changeskind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [changeskind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('changeskind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [changeskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [changeskind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'changeskind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [changeskind] ADD title varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('changeskind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [changeskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [changeskind] ALTER COLUMN title varchar(256) NOT NULL
GO

-- VERIFICA DI changeskind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'changeskind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskind','int','ASSISTENZA','idchangeskind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','changeskind','varchar(10)','ASSISTENZA','description','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','changeskind','int','ASSISTENZA','idchanges','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskind','varchar(256)','ASSISTENZA','title','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI changeskind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'changeskind')
UPDATE customobject set isreal = 'S' where objectname = 'changeskind'
ELSE
INSERT INTO customobject (objectname, isreal) values('changeskind', 'S')
GO

-- GENERAZIONE DATI PER changeskind --
IF exists(SELECT * FROM [changeskind] WHERE idchangeskind = '1')
UPDATE [changeskind] SET active = 'S',description = '',idchanges = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Previously selected educational component is not available at the Receiving Institution' WHERE idchangeskind = '1'
ELSE
INSERT INTO [changeskind] (idchangeskind,active,description,idchanges,lt,lu,sortcode,title) VALUES ('1','S','','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Previously selected educational component is not available at the Receiving Institution')
GO

IF exists(SELECT * FROM [changeskind] WHERE idchangeskind = '2')
UPDATE [changeskind] SET active = 'S',description = '',idchanges = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Component is in a different language than previously specified in the course catalogue' WHERE idchangeskind = '2'
ELSE
INSERT INTO [changeskind] (idchangeskind,active,description,idchanges,lt,lu,sortcode,title) VALUES ('2','S','','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Component is in a different language than previously specified in the course catalogue')
GO

IF exists(SELECT * FROM [changeskind] WHERE idchangeskind = '3')
UPDATE [changeskind] SET active = 'S',description = '',idchanges = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Timetable conflict' WHERE idchangeskind = '3'
ELSE
INSERT INTO [changeskind] (idchangeskind,active,description,idchanges,lt,lu,sortcode,title) VALUES ('3','S','','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Timetable conflict')
GO

IF exists(SELECT * FROM [changeskind] WHERE idchangeskind = '4')
UPDATE [changeskind] SET active = 'S',description = '',idchanges = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Other (please specify)' WHERE idchangeskind = '4'
ELSE
INSERT INTO [changeskind] (idchangeskind,active,description,idchanges,lt,lu,sortcode,title) VALUES ('4','S','','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Other (please specify)')
GO

IF exists(SELECT * FROM [changeskind] WHERE idchangeskind = '5')
UPDATE [changeskind] SET active = 'S',description = '',idchanges = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Substituting a deleted component' WHERE idchangeskind = '5'
ELSE
INSERT INTO [changeskind] (idchangeskind,active,description,idchanges,lt,lu,sortcode,title) VALUES ('5','S','','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Substituting a deleted component')
GO

IF exists(SELECT * FROM [changeskind] WHERE idchangeskind = '6')
UPDATE [changeskind] SET active = 'S',description = '',idchanges = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'Extending the mobility period' WHERE idchangeskind = '6'
ELSE
INSERT INTO [changeskind] (idchangeskind,active,description,idchanges,lt,lu,sortcode,title) VALUES ('6','S','','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','Extending the mobility period')
GO

IF exists(SELECT * FROM [changeskind] WHERE idchangeskind = '7')
UPDATE [changeskind] SET active = 'S',description = '',idchanges = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'Other (please specify)' WHERE idchangeskind = '7'
ELSE
INSERT INTO [changeskind] (idchangeskind,active,description,idchanges,lt,lu,sortcode,title) VALUES ('7','S','','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','7','Other (please specify)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'changeskind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO UE dei tipi di cambiamento nei 2.2.29 Learning Agreement for traineership (contratto di formazione)
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:13:05.537'},lu = 'assistenza',title = 'VOCABOLARIO UE dei tipi di cambiamento nei Learning Agreement for traineership (contratto di ' WHERE tablename = 'changeskind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('changeskind','VOCABOLARIO UE dei tipi di cambiamento nei 2.2.29 Learning Agreement for traineership (contratto di formazione)
',null,'N',{ts '2018-07-27 13:13:05.537'},'assistenza','VOCABOLARIO UE dei tipi di cambiamento nei Learning Agreement for traineership (contratto di ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'changeskind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:13:07.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'changeskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','changeskind','1',null,null,null,'S',{ts '2018-07-27 13:13:07.067'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'changeskind')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:13:07.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'changeskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','changeskind','10',null,null,null,'S',{ts '2018-07-27 13:13:07.067'},'assistenza','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idchanges' AND tablename = 'changeskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Changes',kind = 'S',lt = {ts '2020-07-02 11:31:04.810'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idchanges' AND tablename = 'changeskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idchanges','changeskind','4',null,null,'Changes','S',{ts '2020-07-02 11:31:04.810'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idchangeskind' AND tablename = 'changeskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:13:07.067'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idchangeskind' AND tablename = 'changeskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idchangeskind','changeskind','4',null,null,null,'S',{ts '2018-07-27 13:13:07.067'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'changeskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:13:07.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'changeskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','changeskind','8',null,null,null,'S',{ts '2018-07-27 13:13:07.067'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'changeskind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:13:07.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'changeskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','changeskind','64',null,null,null,'S',{ts '2018-07-27 13:13:07.067'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'changeskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:13:07.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'changeskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','changeskind','4',null,null,null,'S',{ts '2018-07-27 13:13:07.067'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'changeskind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:13:07.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'changeskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','changeskind','256',null,null,null,'S',{ts '2018-07-27 13:13:07.067'},'assistenza','N','varchar(256)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3377')
UPDATE [relation] SET childtable = 'changeskind',description = 'insegnamento all''estero di cui lo studente ougoing descrive il cambiamento nel suo learning agreement',lt = {ts '2018-07-27 13:15:39.957'},lu = 'assistenza',parenttable = 'convalidante',title = null WHERE idrelation = '3377'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3377','changeskind','insegnamento all''estero di cui lo studente ougoing descrive il cambiamento nel suo learning agreement',{ts '2018-07-27 13:15:39.957'},'assistenza','convalidante',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3378')
UPDATE [relation] SET childtable = 'changeskind',description = 'insegnamento nell''istituto di cui lo studente incoming descrive il cambiamento nel suo learning agreement',lt = {ts '2018-07-27 13:15:39.980'},lu = 'assistenza',parenttable = 'convalidato',title = null WHERE idrelation = '3378'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3378','changeskind','insegnamento nell''istituto di cui lo studente incoming descrive il cambiamento nel suo learning agreement',{ts '2018-07-27 13:15:39.980'},'assistenza','convalidato',null)
GO

-- FINE GENERAZIONE SCRIPT --

