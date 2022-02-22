
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
-- CREAZIONE TABELLA sostenimentoesito --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sostenimentoesito]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sostenimentoesito] (
idsostenimentoesito int NOT NULL,
active char(1) NOT NULL,
description varchar(256) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpksostenimentoesito PRIMARY KEY (idsostenimentoesito
)
)
END
GO

-- VERIFICA STRUTTURA sostenimentoesito --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimentoesito' and C.name = 'idsostenimentoesito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimentoesito] ADD idsostenimentoesito int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimentoesito') and col.name = 'idsostenimentoesito' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimentoesito] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimentoesito' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimentoesito] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimentoesito') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimentoesito] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimentoesito] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimentoesito' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimentoesito] ADD description varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimentoesito') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimentoesito] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimentoesito] ALTER COLUMN description varchar(256) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimentoesito' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimentoesito] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [sostenimentoesito] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimentoesito' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimentoesito] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [sostenimentoesito] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimentoesito' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimentoesito] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimentoesito') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimentoesito] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimentoesito] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimentoesito' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimentoesito] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimentoesito') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimentoesito] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimentoesito] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI sostenimentoesito IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sostenimentoesito'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesito','int','ASSISTENZA','idsostenimentoesito','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesito','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesito','varchar(256)','ASSISTENZA','description','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoesito','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoesito','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesito','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesito','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sostenimentoesito IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sostenimentoesito')
UPDATE customobject set isreal = 'S' where objectname = 'sostenimentoesito'
ELSE
INSERT INTO customobject (objectname, isreal) values('sostenimentoesito', 'S')
GO

-- GENERAZIONE DATI PER sostenimentoesito --
IF exists(SELECT * FROM [sostenimentoesito] WHERE idsostenimentoesito = '1')
UPDATE [sostenimentoesito] SET active = 'S',description = 'Esito negativo',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Bocciato' WHERE idsostenimentoesito = '1'
ELSE
INSERT INTO [sostenimentoesito] (idsostenimentoesito,active,description,lt,lu,sortcode,title) VALUES ('1','S','Esito negativo',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Bocciato')
GO

IF exists(SELECT * FROM [sostenimentoesito] WHERE idsostenimentoesito = '2')
UPDATE [sostenimentoesito] SET active = 'S',description = 'Lo studente ha partecipato ma rinuncia alla valutazione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = 'Ritirato' WHERE idsostenimentoesito = '2'
ELSE
INSERT INTO [sostenimentoesito] (idsostenimentoesito,active,description,lt,lu,sortcode,title) VALUES ('2','S','Lo studente ha partecipato ma rinuncia alla valutazione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Ritirato')
GO

IF exists(SELECT * FROM [sostenimentoesito] WHERE idsostenimentoesito = '3')
UPDATE [sostenimentoesito] SET active = 'S',description = 'Lo studente non ha partecipato',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '4',title = 'Assente' WHERE idsostenimentoesito = '3'
ELSE
INSERT INTO [sostenimentoesito] (idsostenimentoesito,active,description,lt,lu,sortcode,title) VALUES ('3','S','Lo studente non ha partecipato',{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','Assente')
GO

IF exists(SELECT * FROM [sostenimentoesito] WHERE idsostenimentoesito = '4')
UPDATE [sostenimentoesito] SET active = 'S',description = 'In sospeso a causa di motivi amministrativi o contabili',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '5',title = 'Sospeso' WHERE idsostenimentoesito = '4'
ELSE
INSERT INTO [sostenimentoesito] (idsostenimentoesito,active,description,lt,lu,sortcode,title) VALUES ('4','S','In sospeso a causa di motivi amministrativi o contabili',{ts '2019-02-28 18:02:19.867'},'Ferdinando','5','Sospeso')
GO

IF exists(SELECT * FROM [sostenimentoesito] WHERE idsostenimentoesito = '5')
UPDATE [sostenimentoesito] SET active = 'S',description = 'Il voto è rifiutato dallo studente',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '6',title = 'Rifiutato' WHERE idsostenimentoesito = '5'
ELSE
INSERT INTO [sostenimentoesito] (idsostenimentoesito,active,description,lt,lu,sortcode,title) VALUES ('5','S','Il voto è rifiutato dallo studente',{ts '2019-02-28 18:02:19.867'},'Ferdinando','6','Rifiutato')
GO

IF exists(SELECT * FROM [sostenimentoesito] WHERE idsostenimentoesito = '6')
UPDATE [sostenimentoesito] SET active = 'S',description = 'In caso che lo studente desideri ripetere l''esame',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '7',title = 'Annullato' WHERE idsostenimentoesito = '6'
ELSE
INSERT INTO [sostenimentoesito] (idsostenimentoesito,active,description,lt,lu,sortcode,title) VALUES ('6','S','In caso che lo studente desideri ripetere l''esame',{ts '2019-02-28 18:02:19.867'},'Ferdinando','7','Annullato')
GO

IF exists(SELECT * FROM [sostenimentoesito] WHERE idsostenimentoesito = '7')
UPDATE [sostenimentoesito] SET active = 'S',description = 'Esito positivo',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'Promosso' WHERE idsostenimentoesito = '7'
ELSE
INSERT INTO [sostenimentoesito] (idsostenimentoesito,active,description,lt,lu,sortcode,title) VALUES ('7','S','Esito positivo',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Promosso')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sostenimentoesito')
UPDATE [tabledescr] SET description = 'VOCABOLARIO esiti possibili',idapplication = null,isdbo = 'N',lt = {ts '2018-07-17 12:53:31.700'},lu = 'assistenza',title = 'VOCABOLARIO esiti possibili' WHERE tablename = 'sostenimentoesito'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sostenimentoesito','VOCABOLARIO esiti possibili',null,'N',{ts '2018-07-17 12:53:31.700'},'assistenza','VOCABOLARIO esiti possibili')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'sostenimentoesito')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-02-03 18:16:12.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','sostenimentoesito','1',null,null,null,'S',{ts '2020-02-03 18:16:12.767'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'sostenimentoesito')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-02-03 18:16:12.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','sostenimentoesito','256',null,null,null,'S',{ts '2020-02-03 18:16:12.767'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsostenimentoesito' AND tablename = 'sostenimentoesito')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-02-03 18:16:12.770'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsostenimentoesito' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsostenimentoesito','sostenimentoesito','4',null,null,null,'S',{ts '2020-02-03 18:16:12.770'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'sostenimentoesito')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-02-03 18:16:12.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','sostenimentoesito','8',null,null,null,'S',{ts '2020-02-03 18:16:12.770'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'sostenimentoesito')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-02-03 18:16:12.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','sostenimentoesito','64',null,null,null,'S',{ts '2020-02-03 18:16:12.770'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'sostenimentoesito')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-02-03 18:16:12.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','sostenimentoesito','4',null,null,null,'S',{ts '2020-02-03 18:16:12.770'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'sostenimentoesito')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Esito',kind = 'S',lt = {ts '2020-02-04 16:50:35.943'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','sostenimentoesito','50',null,null,'Esito','S',{ts '2020-02-04 16:50:35.943'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3195')
UPDATE [relation] SET childtable = 'sostenimentoesito',description = '? il sostenimento di chui esprime l''esito',lt = {ts '2018-07-17 12:54:46.777'},lu = 'assistenza',parenttable = 'sostenimento',title = null WHERE idrelation = '3195'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3195','sostenimentoesito','? il sostenimento di chui esprime l''esito',{ts '2018-07-17 12:54:46.777'},'assistenza','sostenimento',null)
GO

-- FINE GENERAZIONE SCRIPT --

