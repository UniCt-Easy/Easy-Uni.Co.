
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
-- CREAZIONE TABELLA graduatoriavar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[graduatoriavar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[graduatoriavar] (
idgraduatoriavar int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
title varchar(50) NULL,
 CONSTRAINT xpkgraduatoriavar PRIMARY KEY (idgraduatoriavar
)
)
END
GO

-- VERIFICA STRUTTURA graduatoriavar --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'idgraduatoriavar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD idgraduatoriavar int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriavar') and col.name = 'idgraduatoriavar' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriavar] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [graduatoriavar] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriavar') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriavar] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriavar] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriavar') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriavar] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriavar] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [graduatoriavar] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriavar') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriavar] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriavar] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriavar') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriavar] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriavar] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [graduatoriavar] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriavar' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriavar] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [graduatoriavar] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI graduatoriavar IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'graduatoriavar'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavar','int','ASSISTENZA','idgraduatoriavar','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriavar','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavar','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavar','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriavar','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavar','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavar','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriavar','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriavar','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI graduatoriavar IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'graduatoriavar')
UPDATE customobject set isreal = 'S' where objectname = 'graduatoriavar'
ELSE
INSERT INTO customobject (objectname, isreal) values('graduatoriavar', 'S')
GO

-- GENERAZIONE DATI PER graduatoriavar --
IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '1')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Età' WHERE idgraduatoriavar = '1'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Età')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '2')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Titoli di studio posseduti' WHERE idgraduatoriavar = '2'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Titoli di studio posseduti')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '3')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Voto pre-accademico' WHERE idgraduatoriavar = '3'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Voto pre-accademico')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '4')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Voto accademico' WHERE idgraduatoriavar = '4'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Voto accademico')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '5')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'ISE' WHERE idgraduatoriavar = '5'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','5','ISE')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '6')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'ISEE' WHERE idgraduatoriavar = '6'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','6','ISEE')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '7')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'ISP' WHERE idgraduatoriavar = '7'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','7','ISP')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '8')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '8',title = 'ISPE' WHERE idgraduatoriavar = '8'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','8','ISPE')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '9')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '9',title = 'Grado di Handicap' WHERE idgraduatoriavar = '9'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('9','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','9','Grado di Handicap')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '10')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '10',title = 'Ore di servizio prestato nella classe concorsuale' WHERE idgraduatoriavar = '10'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('10','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','10','Ore di servizio prestato nella classe concorsuale')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '11')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '11',title = 'Punteggio dato dall’esito di un test o esame' WHERE idgraduatoriavar = '11'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('11','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','11','Punteggio dato dall’esito di un test o esame')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '12')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '12',title = 'Anno di corso' WHERE idgraduatoriavar = '12'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('12','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','12','Anno di corso')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '13')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '13',title = 'Anno fuori corso' WHERE idgraduatoriavar = '13'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('13','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','13','Anno fuori corso')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '14')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '14',title = 'Numero anni di iscrizione al corso nell’istituto' WHERE idgraduatoriavar = '14'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('14','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','14','Numero anni di iscrizione al corso nell’istituto')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '15')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '15',title = 'Crediti ottenuti' WHERE idgraduatoriavar = '15'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('15','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','15','Crediti ottenuti')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '16')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '16',title = 'Crediti ottenuti nell’anno accademico precedente' WHERE idgraduatoriavar = '16'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('16','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','16','Crediti ottenuti nell’anno accademico precedente')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '17')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '17',title = 'Crediti mancanti alla conclusione' WHERE idgraduatoriavar = '17'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('17','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','17','Crediti mancanti alla conclusione')
GO

IF exists(SELECT * FROM [graduatoriavar] WHERE idgraduatoriavar = '18')
UPDATE [graduatoriavar] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '18',title = 'Media' WHERE idgraduatoriavar = '18'
ELSE
INSERT INTO [graduatoriavar] (idgraduatoriavar,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('18','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','18','Media')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'graduatoriavar')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile da loro delle variabili del calcolo della 2.4.36 Graduatoria',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 16:25:23.847'},lu = 'assistenza',title = 'Variabili del calcolo della graduatoria' WHERE tablename = 'graduatoriavar'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('graduatoriavar','VOCABOLARIO modificabile da loro delle variabili del calcolo della 2.4.36 Graduatoria',null,'N',{ts '2018-07-20 16:25:23.847'},'assistenza','Variabili del calcolo della graduatoria')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','graduatoriavar','1',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','graduatoriavar','8',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'cu' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','graduatoriavar','8',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','graduatoriavar','256',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoriavar' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoriavar' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoriavar','graduatoriavar','4',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','graduatoriavar','8',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','graduatoriavar','64',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','graduatoriavar','4',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'graduatoriavar')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:52:28.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','graduatoriavar','50',null,null,null,'S',{ts '2018-07-18 17:52:28.980'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3260')
UPDATE [relation] SET childtable = 'graduatoriavar',description = 'utilizzo della variabile nel calcolo della graduatoria',lt = {ts '2018-07-18 17:52:59.337'},lu = 'assistenza',parenttable = 'graduatoriadesc',title = null WHERE idrelation = '3260'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3260','graduatoriavar','utilizzo della variabile nel calcolo della graduatoria',{ts '2018-07-18 17:52:59.337'},'assistenza','graduatoriadesc',null)
GO

-- FINE GENERAZIONE SCRIPT --

