
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
-- CREAZIONE TABELLA istanzakind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzakind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[istanzakind] (
idistanzakind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkistanzakind PRIMARY KEY (idistanzakind
)
)
END
GO

-- VERIFICA STRUTTURA istanzakind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'idistanzakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD idistanzakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanzakind') and col.name = 'idistanzakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanzakind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanzakind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanzakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanzakind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanzakind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanzakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanzakind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanzakind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanzakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanzakind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [istanzakind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanzakind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanzakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanzakind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanzakind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanzakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanzakind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanzakind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanzakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanzakind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanzakind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanzakind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanzakind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanzakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanzakind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI istanzakind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'istanzakind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakind','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzakind','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI istanzakind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'istanzakind')
UPDATE customobject set isreal = 'S' where objectname = 'istanzakind'
ELSE
INSERT INTO customobject (objectname, isreal) values('istanzakind', 'S')
GO

-- GENERAZIONE DATI PER istanzakind --
IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '1')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Istanza di equipollenza del titolo' WHERE idistanzakind = '1'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Istanza di equipollenza del titolo')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '2')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Istanza di reintegro della carriera' WHERE idistanzakind = '2'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Istanza di reintegro della carriera')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '3')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Istanza di passaggio o cambio coorte' WHERE idistanzakind = '3'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Istanza di passaggio o cambio coorte')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '4')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Istanza di abbreviazione del titolo' WHERE idistanzakind = '4'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Istanza di abbreviazione del titolo')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '5')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Istanza di trasferimento in ingresso' WHERE idistanzakind = '5'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Istanza di trasferimento in ingresso')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '6')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'Istanza di rinuncia al conseguimento del titolo' WHERE idistanzakind = '6'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','6','Istanza di rinuncia al conseguimento del titolo')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '7')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'Istanza si sospensione della carriera' WHERE idistanzakind = '7'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','7','Istanza si sospensione della carriera')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '8')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '8',title = 'Istanza di trasferimento in uscita' WHERE idistanzakind = '8'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','8','Istanza di trasferimento in uscita')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '9')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '9',title = 'Richiesta di certificato' WHERE idistanzakind = '9'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('9','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','9','Richiesta di certificato')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '10')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '10',title = 'Richiesta di duplicato del libretto' WHERE idistanzakind = '10'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('10','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','10','Richiesta di duplicato del libretto')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '11')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '11',title = 'Richiesta di duplicato del diploma' WHERE idistanzakind = '11'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('11','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','11','Richiesta di duplicato del diploma')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '12')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '12',title = 'Istanza di conseguimento del titolo' WHERE idistanzakind = '12'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('12','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','12','Istanza di conseguimento del titolo')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '13')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2020-04-02 11:15:18.880'},cu = 'riccardotest',description = null,lt = {ts '2020-04-02 11:15:18.880'},lu = 'riccardotest',sortcode = '13',title = 'Istanza di preimmatricolazione' WHERE idistanzakind = '13'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('13','S',{ts '2020-04-02 11:15:18.880'},'riccardotest',null,{ts '2020-04-02 11:15:18.880'},'riccardotest','13','Istanza di preimmatricolazione')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '14')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2020-04-02 11:15:33.027'},cu = 'riccardotest',description = null,lt = {ts '2020-04-02 11:15:33.027'},lu = 'riccardotest',sortcode = '14',title = 'Istanza di immatricolazione' WHERE idistanzakind = '14'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('14','S',{ts '2020-04-02 11:15:33.027'},'riccardotest',null,{ts '2020-04-02 11:15:33.027'},'riccardotest','14','Istanza di immatricolazione')
GO

IF exists(SELECT * FROM [istanzakind] WHERE idistanzakind = '15')
UPDATE [istanzakind] SET active = 'S',ct = {ts '2020-04-02 11:15:58.030'},cu = 'riccardotest',description = null,lt = {ts '2020-04-02 11:15:58.030'},lu = 'riccardotest',sortcode = '15',title = 'Istanza di rinnovo dell''iscrizione' WHERE idistanzakind = '15'
ELSE
INSERT INTO [istanzakind] (idistanzakind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('15','S',{ts '2020-04-02 11:15:58.030'},'riccardotest',null,{ts '2020-04-02 11:15:58.030'},'riccardotest','15','Istanza di rinnovo dell''iscrizione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'istanzakind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle tipologie di istanza',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 10:54:19.960'},lu = 'assistenza',title = 'VOCABOLARIO delle tipologie di istanza' WHERE tablename = 'istanzakind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('istanzakind','VOCABOLARIO delle tipologie di istanza',null,'N',{ts '2018-07-20 10:54:19.960'},'assistenza','VOCABOLARIO delle tipologie di istanza')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','istanzakind','1',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','istanzakind','8',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','istanzakind','64',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','istanzakind','256',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanzakind' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanzakind' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanzakind','istanzakind','4',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','istanzakind','8',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','istanzakind','64',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','istanzakind','4',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'istanzakind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:54:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'istanzakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','istanzakind','50',null,null,null,'S',{ts '2018-07-20 10:54:24.460'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3309')
UPDATE [relation] SET childtable = 'istanzakind',description = 'istanza di cui descrive il tipo',lt = {ts '2018-07-20 11:00:28.927'},lu = 'assistenza',parenttable = 'istanza',title = null WHERE idrelation = '3309'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3309','istanzakind','istanza di cui descrive il tipo',{ts '2018-07-20 11:00:28.927'},'assistenza','istanza',null)
GO

-- FINE GENERAZIONE SCRIPT --

