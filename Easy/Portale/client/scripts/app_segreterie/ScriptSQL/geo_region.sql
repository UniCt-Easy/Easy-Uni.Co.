
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
-- CREAZIONE TABELLA geo_region --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_region]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_region] (
idregion int NOT NULL,
idnation int NULL,
lt datetime NULL,
lu varchar(64) NULL,
newregion int NULL,
oldregion int NULL,
start date NULL,
stop date NULL,
title varchar(50) NULL,
 CONSTRAINT xpkgeo_region PRIMARY KEY (idregion
)
)
END
GO

-- VERIFICA STRUTTURA geo_region --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'idregion' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD idregion int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('geo_region') and col.name = 'idregion' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [geo_region] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD idnation int NULL 
END
ELSE
	ALTER TABLE [geo_region] ALTER COLUMN idnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [geo_region] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [geo_region] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'newregion' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD newregion int NULL 
END
ELSE
	ALTER TABLE [geo_region] ALTER COLUMN newregion int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'oldregion' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD oldregion int NULL 
END
ELSE
	ALTER TABLE [geo_region] ALTER COLUMN oldregion int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD start date NULL 
END
ELSE
	ALTER TABLE [geo_region] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD stop date NULL 
END
ELSE
	ALTER TABLE [geo_region] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_region' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_region] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [geo_region] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI geo_region IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_region'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_region','int','ASSISTENZA','idregion','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_region','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_region','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_region','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_region','int','ASSISTENZA','newregion','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_region','int','ASSISTENZA','oldregion','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_region','date','ASSISTENZA','start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_region','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_region','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI geo_region IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_region')
UPDATE customobject set isreal = 'S' where objectname = 'geo_region'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_region', 'S')
GO

-- GENERAZIONE DATI PER geo_region --
IF exists(SELECT * FROM [geo_region] WHERE idregion = '1')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Piemonte' WHERE idregion = '1'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('1','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Piemonte')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '2')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Valle d''Aosta' WHERE idregion = '2'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('2','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Valle d''Aosta')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '3')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Lombardia' WHERE idregion = '3'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('3','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Lombardia')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '4')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Trentino Alto Adige' WHERE idregion = '4'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('4','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Trentino Alto Adige')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '5')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Veneto' WHERE idregion = '5'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('5','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Veneto')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '6')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Friuli Venezia Giulia' WHERE idregion = '6'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('6','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Friuli Venezia Giulia')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '7')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Liguria' WHERE idregion = '7'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('7','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Liguria')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '8')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Emilia Romagna' WHERE idregion = '8'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('8','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Emilia Romagna')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '9')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Toscana' WHERE idregion = '9'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('9','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Toscana')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '10')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Umbria' WHERE idregion = '10'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('10','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Umbria')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '11')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Marche' WHERE idregion = '11'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('11','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Marche')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '12')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Lazio' WHERE idregion = '12'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('12','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Lazio')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '13')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Abruzzo' WHERE idregion = '13'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('13','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Abruzzo')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '14')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Molise' WHERE idregion = '14'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('14','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Molise')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '15')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Campania' WHERE idregion = '15'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('15','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Campania')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '16')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Puglia' WHERE idregion = '16'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('16','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Puglia')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '17')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Basilicata' WHERE idregion = '17'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('17','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Basilicata')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '18')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Calabria' WHERE idregion = '18'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('18','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Calabria')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '19')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Sicilia' WHERE idregion = '19'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('19','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Sicilia')
GO

IF exists(SELECT * FROM [geo_region] WHERE idregion = '20')
UPDATE [geo_region] SET idnation = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newregion = null,oldregion = null,start = null,stop = null,title = 'Sardegna' WHERE idregion = '20'
ELSE
INSERT INTO [geo_region] (idregion,idnation,lt,lu,newregion,oldregion,start,stop,title) VALUES ('20','1',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Sardegna')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'geo_region')
UPDATE [tabledescr] SET description = 'Regioni',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:28.867'},lu = 'nino',title = 'Regioni' WHERE tablename = 'geo_region'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('geo_region','Regioni',null,'S',{ts '1900-01-01 03:00:28.867'},'nino','Regioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id nazione (tabella geo_nation)',kind = 'S',lt = {ts '1900-01-01 03:00:14.970'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','geo_region','4',null,null,'Id nazione (tabella geo_nation)','S',{ts '1900-01-01 03:00:14.970'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregion' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id regione (tabella geo_region)',kind = 'S',lt = {ts '1900-01-01 03:00:26.343'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregion' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregion','geo_region','4',null,null,'id regione (tabella geo_region)','S',{ts '1900-01-01 03:00:26.343'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.917'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','geo_region','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.917'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.947'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','geo_region','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.947'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newregion' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'regione successiva',kind = 'S',lt = {ts '2017-05-22 15:47:18.060'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'newregion' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newregion','geo_region','4',null,null,'regione successiva','S',{ts '2017-05-22 15:47:18.060'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oldregion' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'regione precedente',kind = 'S',lt = {ts '2018-03-23 16:35:06.460'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oldregion' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oldregion','geo_region','4',null,null,'regione precedente','S',{ts '2018-03-23 16:35:06.460'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data inizio',kind = 'S',lt = {ts '1900-01-01 02:59:54.123'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','geo_region','4',null,null,'data inizio','S',{ts '1900-01-01 02:59:54.123'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data fine',kind = 'S',lt = {ts '1900-01-01 02:59:54.630'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','geo_region','4',null,null,'data fine','S',{ts '1900-01-01 02:59:54.630'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'geo_region')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '1900-01-01 03:00:00.100'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'geo_region'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','geo_region','50',null,null,'Denominazione','S',{ts '1900-01-01 03:00:00.100'},'nino','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '890')
UPDATE [relation] SET childtable = 'geo_region',description = 'Id nazione (tabella geo_nation)',lt = {ts '2017-05-20 09:19:52.760'},lu = 'lu',parenttable = 'geo_nation',title = 'Regioni' WHERE idrelation = '890'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('890','geo_region','Id nazione (tabella geo_nation)',{ts '2017-05-20 09:19:52.760'},'lu','geo_nation','Regioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '890' AND parentcol = 'idnation')
UPDATE [relationcol] SET childcol = 'idnation',lt = {ts '2017-05-20 09:19:52.833'},lu = 'lu' WHERE idrelation = '890' AND parentcol = 'idnation'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('890','idnation','idnation',{ts '2017-05-20 09:19:52.833'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

