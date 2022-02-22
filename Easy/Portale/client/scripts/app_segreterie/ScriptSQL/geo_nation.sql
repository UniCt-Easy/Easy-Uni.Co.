
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


-- CREAZIONE TABELLA geo_nation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_nation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_nation] (
idnation int NOT NULL,
idcontinent int NULL,
lang varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
newnation int NULL,
oldnation int NULL,
start date NULL,
stop date NULL,
title varchar(65) NULL,
 CONSTRAINT xpkgeo_nation PRIMARY KEY (idnation
)
)
END
GO

-- VERIFICA STRUTTURA geo_nation --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD idnation int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('geo_nation') and col.name = 'idnation' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [geo_nation] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'idcontinent' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD idcontinent int NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN idcontinent int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'lang' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD lang varchar(64) NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN lang varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'newnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD newnation int NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN newnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'oldnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD oldnation int NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN oldnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD start date NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD stop date NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD title varchar(65) NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN title varchar(65) NULL
GO

-- VERIFICA DI geo_nation IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_nation'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_nation','int','ASSISTENZA','idnation','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','int','ASSISTENZA','idcontinent','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','varchar(64)','ASSISTENZA','lang','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','int','ASSISTENZA','newnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','int','ASSISTENZA','oldnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','date','ASSISTENZA','start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nation','varchar(65)','ASSISTENZA','title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI geo_nation IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_nation')
UPDATE customobject set isreal = 'S' where objectname = 'geo_nation'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_nation', 'S')
GO

-- GENERAZIONE DATI PER geo_nation --
IF exists(SELECT * FROM [geo_nation] WHERE idnation = '1')
UPDATE [geo_nation] SET idcontinent = '1',lang = '',lt = {ts '2019-03-14 16:17:42.360'},lu = 'ASSISTENZA',newnation = null,oldnation = null,start = null,stop = null,title = 'ITALIA' WHERE idnation = '1'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('1','1','',{ts '2019-03-14 16:17:42.360'},'ASSISTENZA',null,null,null,null,'ITALIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '2')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ALBANIA' WHERE idnation = '2'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('2','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ALBANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '3')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ANDORRA' WHERE idnation = '3'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('3','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ANDORRA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '4')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '78',oldnation = '66',start = {d '1991-09-23'},stop = {d '1994-01-01'},title = 'ARMENIA' WHERE idnation = '4'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('4','1',null,{d '2003-11-20'},'''IMPORT''','78','66',{d '1991-09-23'},{d '1994-01-01'},'ARMENIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '5')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'AUSTRIA' WHERE idnation = '5'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('5','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'AUSTRIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '6')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '79',oldnation = '62',start = {d '1991-08-30'},stop = {d '1994-01-01'},title = 'AZERBAIGIAN' WHERE idnation = '6'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('6','1',null,{d '2003-11-20'},'''IMPORT''','79','62',{d '1991-08-30'},{d '1994-01-01'},'AZERBAIGIAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '7')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'BELGIO' WHERE idnation = '7'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('7','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'BELGIO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '8')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '60',start = {d '1991-08-25'},stop = null,title = 'BIELORUSSIA=RUSSIA BIANCA' WHERE idnation = '8'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('8','1',null,{d '2003-11-20'},'''IMPORT''',null,'60',{d '1991-08-25'},null,'BIELORUSSIA=RUSSIA BIANCA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '9')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '29',start = {d '1992-03-03'},stop = null,title = 'BOSNIA ED ERZEGOVINA' WHERE idnation = '9'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('9','1',null,{d '2003-11-20'},'''IMPORT''',null,'29',{d '1992-03-03'},null,'BOSNIA ED ERZEGOVINA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '10')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'BULGARIA' WHERE idnation = '10'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('10','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'BULGARIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '11')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '12',start = {d '1993-01-01'},stop = null,title = 'CECA REPUBBLICA' WHERE idnation = '11'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('11','1',null,{d '2003-11-20'},'''IMPORT''',null,'12',{d '1993-01-01'},null,'CECA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '12')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '50',oldnation = null,start = null,stop = {d '1993-01-01'},title = 'CECOSLOVACCHIA' WHERE idnation = '12'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('12','1',null,{d '2003-11-20'},'''IMPORT''','50',null,null,{d '1993-01-01'},'CECOSLOVACCHIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '13')
UPDATE [geo_nation] SET idcontinent = '1',lang = 'Latino',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CITTA'' DEL VATICANO' WHERE idnation = '13'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('13','1','Latino',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CITTA'' DEL VATICANO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '14')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '28',start = {d '1991-10-08'},stop = null,title = 'CROAZIA' WHERE idnation = '14'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('14','1',null,{d '2003-11-20'},'''IMPORT''',null,'28',{d '1991-10-08'},null,'CROAZIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '15')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DANIMARCA' WHERE idnation = '15'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('15','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DANIMARCA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '16')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '64',start = {d '1991-09-06'},stop = null,title = 'ESTONIA' WHERE idnation = '16'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('16','1',null,{d '2003-11-20'},'''IMPORT''',null,'64',{d '1991-09-06'},null,'ESTONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '17')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'FINLANDIA' WHERE idnation = '17'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('17','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'FINLANDIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '18')
UPDATE [geo_nation] SET idcontinent = '1',lang = 'Francese',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'FRANCIA' WHERE idnation = '18'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('18','1','Francese',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'FRANCIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '19')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '94',oldnation = '65',start = {d '1991-09-09'},stop = {d '1994-01-01'},title = 'GEORGIA' WHERE idnation = '19'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('19','1',null,{d '2003-11-20'},'''IMPORT''','94','65',{d '1991-09-09'},{d '1994-01-01'},'GEORGIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '20')
UPDATE [geo_nation] SET idcontinent = '1',lang = 'Tedesco',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1990-10-03'},stop = null,title = 'GERMANIA' WHERE idnation = '20'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('20','1','Tedesco',{d '2003-11-20'},'''IMPORT''',null,null,{d '1990-10-03'},null,'GERMANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '21')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '20',oldnation = null,start = null,stop = {d '1990-10-03'},title = 'GERMANIA REPUBBLICA DEMOCRATICA' WHERE idnation = '21'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('21','1',null,{d '2003-11-20'},'''IMPORT''','20',null,null,{d '1990-10-03'},'GERMANIA REPUBBLICA DEMOCRATICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '22')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '20',oldnation = null,start = null,stop = {d '1990-10-03'},title = 'GERMANIA REPUBBLICA FEDERALE' WHERE idnation = '22'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('22','1',null,{d '2003-11-20'},'''IMPORT''','20',null,null,{d '1990-10-03'},'GERMANIA REPUBBLICA FEDERALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '23')
UPDATE [geo_nation] SET idcontinent = '1',lang = 'Inglese',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'REGNO UNITO DI GRAN BRETAGNA E IRLANDA DEL NORD' WHERE idnation = '23'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('23','1','Inglese',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'REGNO UNITO DI GRAN BRETAGNA E IRLANDA DEL NORD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '24')
UPDATE [geo_nation] SET idcontinent = '1',lang = 'Greco',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GRECIA' WHERE idnation = '24'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('24','1','Greco',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GRECIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '25')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'IRLANDA=EIRE' WHERE idnation = '25'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('25','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'IRLANDA=EIRE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '26')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ISLANDA' WHERE idnation = '26'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('26','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ISLANDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '27')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '28',oldnation = null,start = null,stop = {d '1991-09-15'},title = 'IUGOSLAVIA' WHERE idnation = '27'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('27','1',null,{d '2003-11-20'},'''IMPORT''','28',null,null,{d '1991-09-15'},'IUGOSLAVIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '28')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '29',oldnation = '27',start = {d '1991-09-15'},stop = {d '1991-10-08'},title = 'IUGOSLAVIA' WHERE idnation = '28'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('28','1',null,{d '2003-11-20'},'''IMPORT''','29','27',{d '1991-09-15'},{d '1991-10-08'},'IUGOSLAVIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '29')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '30',oldnation = '28',start = {d '1991-10-08'},stop = {d '1992-03-03'},title = 'IUGOSLAVIA' WHERE idnation = '29'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('29','1',null,{d '2003-11-20'},'''IMPORT''','30','28',{d '1991-10-08'},{d '1992-03-03'},'IUGOSLAVIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '30')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '49',oldnation = '29',start = {d '1992-03-03'},stop = {d '2003-02-04'},title = 'IUGOSLAVIA' WHERE idnation = '30'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('30','1',null,{d '2003-11-20'},'''IMPORT''','49','29',{d '1992-03-03'},{d '2003-02-04'},'IUGOSLAVIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '31')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '102',oldnation = '68',start = {d '1991-12-16'},stop = {d '1994-01-01'},title = 'KAZAKISTAN' WHERE idnation = '31'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('31','1',null,{d '2003-11-20'},'''IMPORT''','102','68',{d '1991-12-16'},{d '1994-01-01'},'KAZAKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '32')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '103',oldnation = '63',start = {d '1991-08-31'},stop = {d '1994-01-01'},title = 'KIRGHIZISTAN' WHERE idnation = '32'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('32','1',null,{d '2003-11-20'},'''IMPORT''','103','63',{d '1991-08-31'},{d '1994-01-01'},'KIRGHIZISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '33')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '64',start = {d '1991-09-06'},stop = null,title = 'LETTONIA' WHERE idnation = '33'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('33','1',null,{d '2003-11-20'},'''IMPORT''',null,'64',{d '1991-09-06'},null,'LETTONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '34')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'LIECHTENSTEIN' WHERE idnation = '34'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('34','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'LIECHTENSTEIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '35')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {ts '2020-01-23 13:36:53.887'},lu = 'riccardotest',newnation = null,oldnation = '64',start = {d '1991-09-06'},stop = null,title = 'LITUANIA' WHERE idnation = '35'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('35','1',null,{ts '2020-01-23 13:36:53.887'},'riccardotest',null,'64',{d '1991-09-06'},null,'LITUANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '36')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'LUSSEMBURGO' WHERE idnation = '36'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('36','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'LUSSEMBURGO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '37')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '27',start = {d '1991-09-15'},stop = null,title = 'MACEDONIA' WHERE idnation = '37'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('37','1',null,{d '2003-11-20'},'''IMPORT''',null,'27',{d '1991-09-15'},null,'MACEDONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '38')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MALTA' WHERE idnation = '38'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('38','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MALTA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '39')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '61',start = {d '1991-08-27'},stop = null,title = 'MOLDAVIA' WHERE idnation = '39'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('39','1',null,{d '2003-11-20'},'''IMPORT''',null,'61',{d '1991-08-27'},null,'MOLDAVIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '40')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MONACO' WHERE idnation = '40'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('40','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MONACO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '41')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NORVEGIA' WHERE idnation = '41'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('41','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NORVEGIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '42')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'OLANDA (PAESI BASSI)' WHERE idnation = '42'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('42','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'OLANDA (PAESI BASSI)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '43')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '45',oldnation = null,start = null,stop = {d '1989-12-31'},title = 'POLONIA' WHERE idnation = '43'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('43','1',null,{d '2003-11-20'},'''IMPORT''','45',null,null,{d '1989-12-31'},'POLONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '44')
UPDATE [geo_nation] SET idcontinent = '1',lang = 'Portoghese',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PORTOGALLO' WHERE idnation = '44'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('44','1','Portoghese',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'PORTOGALLO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '45')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '43',start = {d '1989-12-31'},stop = null,title = 'REPUBBLICA DI POLONIA' WHERE idnation = '45'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('45','1',null,{d '2003-11-20'},'''IMPORT''',null,'43',{d '1989-12-31'},null,'REPUBBLICA DI POLONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '46')
UPDATE [geo_nation] SET idcontinent = '1',lang = 'Rumeno',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ROMANIA' WHERE idnation = '46'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('46','1','Rumeno',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ROMANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '47')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '69',start = {d '1992-03-31'},stop = null,title = 'RUSSIA=FEDERAZIONE RUSSA' WHERE idnation = '47'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('47','1',null,{d '2003-11-20'},'''IMPORT''',null,'69',{d '1992-03-31'},null,'RUSSIA=FEDERAZIONE RUSSA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '48')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SAN MARINO' WHERE idnation = '48'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('48','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SAN MARINO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '49')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '30',start = {d '2003-02-04'},stop = {d '2006-06-02'},title = 'SERBIA E MONTENEGRO' WHERE idnation = '49'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('49','1',null,{d '2003-11-20'},'''IMPORT''',null,'30',{d '2003-02-04'},{d '2006-06-02'},'SERBIA E MONTENEGRO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '50')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '12',start = {d '1993-01-01'},stop = null,title = 'SLOVACCHIA' WHERE idnation = '50'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('50','1',null,{d '2003-11-20'},'''IMPORT''',null,'12',{d '1993-01-01'},null,'SLOVACCHIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '51')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '28',start = {d '1991-10-08'},stop = null,title = 'SLOVENIA' WHERE idnation = '51'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('51','1',null,{d '2003-11-20'},'''IMPORT''',null,'28',{d '1991-10-08'},null,'SLOVENIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '52')
UPDATE [geo_nation] SET idcontinent = '1',lang = 'Spagnolo',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SPAGNA' WHERE idnation = '52'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('52','1','Spagnolo',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SPAGNA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '53')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SVEZIA' WHERE idnation = '53'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('53','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SVEZIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '54')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SVIZZERA' WHERE idnation = '54'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('54','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SVIZZERA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '55')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '120',oldnation = '65',start = {d '1991-09-09'},stop = {d '1994-01-01'},title = 'TAGIKISTAN' WHERE idnation = '55'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('55','1',null,{d '2003-11-20'},'''IMPORT''','120','65',{d '1991-09-09'},{d '1994-01-01'},'TAGIKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '56')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '123',oldnation = '67',start = {d '1991-10-29'},stop = {d '1994-01-01'},title = 'TURKEMENISTAN' WHERE idnation = '56'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('56','1',null,{d '2003-11-20'},'''IMPORT''','123','67',{d '1991-10-29'},{d '1994-01-01'},'TURKEMENISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '57')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '59',start = {d '1991-08-24'},stop = null,title = 'UCRAINA' WHERE idnation = '57'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('57','1',null,{d '2003-11-20'},'''IMPORT''',null,'59',{d '1991-08-24'},null,'UCRAINA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '58')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'UNGHERIA' WHERE idnation = '58'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('58','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'UNGHERIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '59')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '60',oldnation = null,start = null,stop = {d '1991-08-24'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '59'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('59','1',null,{d '2003-11-20'},'''IMPORT''','60',null,null,{d '1991-08-24'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '60')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '61',oldnation = '59',start = {d '1991-08-24'},stop = {d '1991-08-25'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '60'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('60','1',null,{d '2003-11-20'},'''IMPORT''','61','59',{d '1991-08-24'},{d '1991-08-25'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '61')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '62',oldnation = '60',start = {d '1991-08-25'},stop = {d '1991-08-27'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '61'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('61','1',null,{d '2003-11-20'},'''IMPORT''','62','60',{d '1991-08-25'},{d '1991-08-27'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '62')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '63',oldnation = '61',start = {d '1991-08-27'},stop = {d '1991-08-30'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '62'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('62','1',null,{d '2003-11-20'},'''IMPORT''','63','61',{d '1991-08-27'},{d '1991-08-30'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '63')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '64',oldnation = '62',start = {d '1991-08-30'},stop = {d '1991-08-31'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '63'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('63','1',null,{d '2003-11-20'},'''IMPORT''','64','62',{d '1991-08-30'},{d '1991-08-31'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '64')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '65',oldnation = '63',start = {d '1991-08-31'},stop = {d '1991-09-06'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '64'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('64','1',null,{d '2003-11-20'},'''IMPORT''','65','63',{d '1991-08-31'},{d '1991-09-06'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '65')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '66',oldnation = '64',start = {d '1991-09-06'},stop = {d '1991-09-09'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '65'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('65','1',null,{d '2003-11-20'},'''IMPORT''','66','64',{d '1991-09-06'},{d '1991-09-09'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '66')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '67',oldnation = '65',start = {d '1991-09-09'},stop = {d '1991-09-23'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '66'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('66','1',null,{d '2003-11-20'},'''IMPORT''','67','65',{d '1991-09-09'},{d '1991-09-23'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '67')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '68',oldnation = '66',start = {d '1991-09-23'},stop = {d '1991-10-29'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '67'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('67','1',null,{d '2003-11-20'},'''IMPORT''','68','66',{d '1991-09-23'},{d '1991-10-29'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '68')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '69',oldnation = '67',start = {d '1991-10-29'},stop = {d '1991-12-16'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '68'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('68','1',null,{d '2003-11-20'},'''IMPORT''','69','67',{d '1991-10-29'},{d '1991-12-16'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '69')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '47',oldnation = '68',start = {d '1991-12-16'},stop = {d '1992-03-31'},title = 'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE' WHERE idnation = '69'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('69','1',null,{d '2003-11-20'},'''IMPORT''','47','68',{d '1991-12-16'},{d '1992-03-31'},'UNIONE REPUBBLICHE SOCIALISTE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '70')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '124',oldnation = '63',start = {d '1991-08-31'},stop = {d '1994-01-01'},title = 'UZBEKISTAN' WHERE idnation = '70'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('70','1',null,{d '2003-11-20'},'''IMPORT''','124','63',{d '1991-08-31'},{d '1994-01-01'},'UZBEKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '71')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'FAER OER (ISOLE)' WHERE idnation = '71'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('71','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'FAER OER (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '72')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GIBILTERRA' WHERE idnation = '72'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('72','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GIBILTERRA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '73')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MAN (ISOLA)' WHERE idnation = '73'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('73','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MAN (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '74')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NORMANNE (ISOLE)=ISOLE DEL CANALE' WHERE idnation = '74'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('74','1',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NORMANNE (ISOLE)=ISOLE DEL CANALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '75')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'AFGHANISTAN' WHERE idnation = '75'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('75','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'AFGHANISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '76')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '129',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'ARABIA MERIDIONALE FEDERAZIONE' WHERE idnation = '76'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('76','2',null,{d '2003-11-20'},'''IMPORT''','129',null,null,{d '1975-12-31'},'ARABIA MERIDIONALE FEDERAZIONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '77')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ARABIA SAUDITA' WHERE idnation = '77'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('77','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ARABIA SAUDITA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '78')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '4',start = {d '1994-01-01'},stop = null,title = 'ARMENIA' WHERE idnation = '78'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('78','2',null,{d '2003-11-20'},'''IMPORT''',null,'4',{d '1994-01-01'},null,'ARMENIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '79')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '6',start = {d '1994-01-01'},stop = null,title = 'AZERBAIGIAN' WHERE idnation = '79'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('79','2',null,{d '2003-11-20'},'''IMPORT''',null,'6',{d '1994-01-01'},null,'AZERBAIGIAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '80')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '133',start = {d '1975-12-31'},stop = null,title = 'BAHREIN' WHERE idnation = '80'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('80','2',null,{d '2003-11-20'},'''IMPORT''',null,'133',{d '1975-12-31'},null,'BAHREIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '81')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1975-12-31'},stop = null,title = 'BANGLADESH' WHERE idnation = '81'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('81','2',null,{d '2003-11-20'},'''IMPORT''',null,null,{d '1975-12-31'},null,'BANGLADESH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '82')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1975-12-31'},stop = null,title = 'BHUTAN' WHERE idnation = '82'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('82','2',null,{d '2003-11-20'},'''IMPORT''',null,null,{d '1975-12-31'},null,'BHUTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '83')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = {d '1989-06-18'},title = 'BIRMANIA' WHERE idnation = '83'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('83','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,{d '1989-06-18'},'BIRMANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '84')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '134',start = {d '1984-12-31'},stop = null,title = 'BRUNEI' WHERE idnation = '84'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('84','2',null,{d '2003-11-20'},'''IMPORT''',null,'134',{d '1984-12-31'},null,'BRUNEI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '85')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CAMBOGIA' WHERE idnation = '85'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('85','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CAMBOGIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '86')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '119',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'CEYLON' WHERE idnation = '86'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('86','2',null,{d '2003-11-20'},'''IMPORT''','119',null,null,{d '1975-12-31'},'CEYLON')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '87')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '136',start = null,stop = null,title = 'CINA REPUBBLICA POPOLARE' WHERE idnation = '87'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('87','2',null,{d '2003-11-20'},'''IMPORT''',null,'136',null,null,'CINA REPUBBLICA POPOLARE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '88')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CIPRO' WHERE idnation = '88'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('88','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CIPRO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '89')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'COREA DEL NORD' WHERE idnation = '89'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('89','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'COREA DEL NORD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '90')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'COREA DEL SUD' WHERE idnation = '90'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('90','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'COREA DEL SUD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '91')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '135',start = {d '1975-12-31'},stop = null,title = 'EMIRATI ARABI UNITI' WHERE idnation = '91'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('91','2',null,{d '2003-11-20'},'''IMPORT''',null,'135',{d '1975-12-31'},null,'EMIRATI ARABI UNITI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '92')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'FILIPPINE' WHERE idnation = '92'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('92','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'FILIPPINE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '93')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '115',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'FORMOSA=TAIWAN' WHERE idnation = '93'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('93','2',null,{d '2003-11-20'},'''IMPORT''','115',null,null,{d '1975-12-31'},'FORMOSA=TAIWAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '94')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '19',start = {d '1994-01-01'},stop = null,title = 'GEORGIA' WHERE idnation = '94'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('94','2',null,{d '2003-11-20'},'''IMPORT''',null,'19',{d '1994-01-01'},null,'GEORGIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '95')
UPDATE [geo_nation] SET idcontinent = '2',lang = 'Giapponese',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GIAPPONE' WHERE idnation = '95'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('95','2','Giapponese',{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GIAPPONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '96')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GIORDANIA' WHERE idnation = '96'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('96','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GIORDANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '97')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '116',start = null,stop = null,title = 'INDIA' WHERE idnation = '97'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('97','2',null,{d '2003-11-20'},'''IMPORT''',null,'116',null,null,'INDIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '98')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '139',start = null,stop = null,title = 'INDONESIA' WHERE idnation = '98'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('98','2',null,{d '2003-11-20'},'''IMPORT''',null,'139',null,null,'INDONESIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '99')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'IRAN' WHERE idnation = '99'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('99','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'IRAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '100')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'IRAQ' WHERE idnation = '100'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('100','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'IRAQ')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '101')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ISRAELE' WHERE idnation = '101'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('101','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ISRAELE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '102')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '31',start = {d '1994-01-01'},stop = null,title = 'KAZAKISTAN' WHERE idnation = '102'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('102','2',null,{d '2003-11-20'},'''IMPORT''',null,'31',{d '1994-01-01'},null,'KAZAKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '103')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '32',start = {d '1994-01-01'},stop = null,title = 'KIRGHIZISTAN' WHERE idnation = '103'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('103','2',null,{d '2003-11-20'},'''IMPORT''',null,'32',{d '1994-01-01'},null,'KIRGHIZISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '104')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'KUWAIT' WHERE idnation = '104'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('104','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'KUWAIT')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '105')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'LAOS' WHERE idnation = '105'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('105','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'LAOS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '106')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'LIBANO' WHERE idnation = '106'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('106','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'LIBANO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '107')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '108',oldnation = null,start = null,stop = {d '1966-10-01'},title = 'MALAYSIA' WHERE idnation = '107'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('107','2',null,{d '2003-11-20'},'''IMPORT''','108',null,null,{d '1966-10-01'},'MALAYSIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '108')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '107',start = {d '1966-10-01'},stop = null,title = 'MALAYSIA' WHERE idnation = '108'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('108','2',null,{d '2003-11-20'},'''IMPORT''',null,'107',{d '1966-10-01'},null,'MALAYSIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '109')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MALDIVE' WHERE idnation = '109'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('109','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MALDIVE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '110')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MONGOLIA' WHERE idnation = '110'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('110','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MONGOLIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '111')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NEPAL' WHERE idnation = '111'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('111','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NEPAL')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '112')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'OMAN' WHERE idnation = '112'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('112','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'OMAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '113')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PAKISTAN' WHERE idnation = '113'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('113','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'PAKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '114')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '137',start = {d '1975-12-31'},stop = null,title = 'QATAR' WHERE idnation = '114'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('114','2',null,{d '2003-11-20'},'''IMPORT''',null,'137',{d '1975-12-31'},null,'QATAR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '115')
UPDATE [geo_nation] SET idcontinent = '2',lang = 'Cinese',lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '93',start = {d '1975-12-31'},stop = null,title = 'REPUBBLICA DELLA CINA NAZIONALE=TAIWAN' WHERE idnation = '115'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('115','2','Cinese',{d '2003-11-20'},'''IMPORT''',null,'93',{d '1975-12-31'},null,'REPUBBLICA DELLA CINA NAZIONALE=TAIWAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '116')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '97',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'SIKKIM' WHERE idnation = '116'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('116','2',null,{d '2003-11-20'},'''IMPORT''','97',null,null,{d '1975-12-31'},'SIKKIM')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '117')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '107',start = {d '1966-10-01'},stop = null,title = 'SINGAPORE' WHERE idnation = '117'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('117','2',null,{d '2003-11-20'},'''IMPORT''',null,'107',{d '1966-10-01'},null,'SINGAPORE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '118')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SIRIA' WHERE idnation = '118'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('118','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SIRIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '119')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '86',start = {d '1975-12-31'},stop = null,title = 'SRI LANKA' WHERE idnation = '119'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('119','2',null,{d '2003-11-20'},'''IMPORT''',null,'86',{d '1975-12-31'},null,'SRI LANKA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '120')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '55',start = {d '1994-01-01'},stop = null,title = 'TAGIKISTAN' WHERE idnation = '120'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('120','2',null,{d '2003-11-20'},'''IMPORT''',null,'55',{d '1994-01-01'},null,'TAGIKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '121')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'THAILANDIA' WHERE idnation = '121'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('121','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'THAILANDIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '122')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TURCHIA' WHERE idnation = '122'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('122','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'TURCHIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '123')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '56',start = {d '1994-01-01'},stop = null,title = 'TURKEMENISTAN' WHERE idnation = '123'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('123','2',null,{d '2003-11-20'},'''IMPORT''',null,'56',{d '1994-01-01'},null,'TURKEMENISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '124')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '70',start = {d '1994-01-01'},stop = null,title = 'UZBEKISTAN' WHERE idnation = '124'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('124','2',null,{d '2003-11-20'},'''IMPORT''',null,'70',{d '1994-01-01'},null,'UZBEKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '125')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1977-12-31'},stop = null,title = 'VIETNAM' WHERE idnation = '125'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('125','2',null,{d '2003-11-20'},'''IMPORT''',null,null,{d '1977-12-31'},null,'VIETNAM')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '126')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '125',oldnation = null,start = null,stop = {d '1977-12-31'},title = 'VIETNAM DEL NORD' WHERE idnation = '126'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('126','2',null,{d '2003-11-20'},'''IMPORT''','125',null,null,{d '1977-12-31'},'VIETNAM DEL NORD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '127')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '125',oldnation = null,start = null,stop = {d '1977-12-31'},title = 'VIETNAM DEL SUD' WHERE idnation = '127'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('127','2',null,{d '2003-11-20'},'''IMPORT''','125',null,null,{d '1977-12-31'},'VIETNAM DEL SUD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '128')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '129',start = null,stop = null,title = 'YEMEN' WHERE idnation = '128'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('128','2',null,{d '2003-11-20'},'''IMPORT''',null,'129',null,null,'YEMEN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '129')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '128',oldnation = null,start = {d '1975-12-31'},stop = {d '1990-05-22'},title = 'YEMEN REPUBBLICA DEMOCRATICA POPOLARE' WHERE idnation = '129'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('129','2',null,{d '2003-11-20'},'''IMPORT''','128',null,{d '1975-12-31'},{d '1990-05-22'},'YEMEN REPUBBLICA DEMOCRATICA POPOLARE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '130')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'COCOS (ISOLE)' WHERE idnation = '130'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('130','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'COCOS (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '131')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GAZA (TERRITORIO DI)' WHERE idnation = '131'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('131','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GAZA (TERRITORIO DI)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '132')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '129',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'ARABIA MERIDIONALE PROTETTORATO' WHERE idnation = '132'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('132','2',null,{d '2003-11-20'},'''IMPORT''','129',null,null,{d '1975-12-31'},'ARABIA MERIDIONALE PROTETTORATO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '133')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '80',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'BAHREIN' WHERE idnation = '133'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('133','2',null,{d '2003-11-20'},'''IMPORT''','80',null,null,{d '1975-12-31'},'BAHREIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '134')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '84',oldnation = null,start = null,stop = {d '1984-12-31'},title = 'BRUNEI' WHERE idnation = '134'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('134','2',null,{d '2003-11-20'},'''IMPORT''','84',null,null,{d '1984-12-31'},'BRUNEI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '135')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '91',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'COSTA DEI PIRATI=TRUCIAL STATES' WHERE idnation = '135'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('135','2',null,{d '2003-11-20'},'''IMPORT''','91',null,null,{d '1975-12-31'},'COSTA DEI PIRATI=TRUCIAL STATES')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '136')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '87',oldnation = null,start = null,stop = {d '1997-07-01'},title = 'HONG KONG' WHERE idnation = '136'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('136','2',null,{d '2003-11-20'},'''IMPORT''','87',null,null,{d '1997-07-01'},'HONG KONG')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '137')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '114',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'QATAR' WHERE idnation = '137'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('137','2',null,{d '2003-11-20'},'''IMPORT''','114',null,null,{d '1975-12-31'},'QATAR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '138')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MACAO' WHERE idnation = '138'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('138','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MACAO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '139')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '98',oldnation = null,start = null,stop = {d '1978-12-31'},title = 'TIMOR (ISOLA)' WHERE idnation = '139'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('139','2',null,{d '2003-11-20'},'''IMPORT''','98',null,null,{d '1978-12-31'},'TIMOR (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '140')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '95',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'RYUKYU (ISOLE)' WHERE idnation = '140'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('140','2',null,{d '2003-11-20'},'''IMPORT''','95',null,null,{d '1975-12-31'},'RYUKYU (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '141')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ALGERIA' WHERE idnation = '141'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('141','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ALGERIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '142')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '229',start = {d '1977-12-31'},stop = null,title = 'ANGOLA' WHERE idnation = '142'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('142','3',null,{d '2003-11-20'},'''IMPORT''',null,'229',{d '1977-12-31'},null,'ANGOLA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '143')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '162',start = {d '1975-12-31'},stop = null,title = 'BENIN' WHERE idnation = '143'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('143','3',null,{d '2003-11-20'},'''IMPORT''',null,'162',{d '1975-12-31'},null,'BENIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '144')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '198',oldnation = '195',start = {d '1978-12-31'},stop = {d '1994-01-01'},title = 'BOPHUTHATSWANA' WHERE idnation = '144'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('144','3',null,{d '2003-11-20'},'''IMPORT''','198','195',{d '1978-12-31'},{d '1994-01-01'},'BOPHUTHATSWANA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '145')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '222',start = {d '1966-10-01'},stop = null,title = 'BOTSWANA' WHERE idnation = '145'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('145','3',null,{d '2003-11-20'},'''IMPORT''',null,'222',{d '1966-10-01'},null,'BOTSWANA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '146')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '208',start = {d '1984-12-31'},stop = null,title = 'BURKINA' WHERE idnation = '146'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('146','3',null,{d '2003-11-20'},'''IMPORT''',null,'208',{d '1984-12-31'},null,'BURKINA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '147')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'BURUNDI' WHERE idnation = '147'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('147','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'BURUNDI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '148')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CAMERUN' WHERE idnation = '148'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('148','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CAMERUN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '149')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '230',start = {d '1975-12-31'},stop = null,title = 'CAPO VERDE' WHERE idnation = '149'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('149','3',null,{d '2003-11-20'},'''IMPORT''',null,'230',{d '1975-12-31'},null,'CAPO VERDE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '150')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '152',start = {d '1980-12-31'},stop = null,title = 'CENTRAFRICANA REPUBBLICA' WHERE idnation = '150'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('150','3',null,{d '2003-11-20'},'''IMPORT''',null,'152',{d '1980-12-31'},null,'CENTRAFRICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '151')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '152',oldnation = null,start = null,stop = {d '1977-12-31'},title = 'CENTROAFRICANA REPUBBLICA' WHERE idnation = '151'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('151','3',null,{d '2003-11-20'},'''IMPORT''','152',null,null,{d '1977-12-31'},'CENTROAFRICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '152')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '150',oldnation = '151',start = {d '1977-12-31'},stop = {d '1980-12-31'},title = 'CENTROAFRICANO IMPERO' WHERE idnation = '152'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('152','3',null,{d '2003-11-20'},'''IMPORT''','150','151',{d '1977-12-31'},{d '1980-12-31'},'CENTROAFRICANO IMPERO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '153')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CIAD' WHERE idnation = '153'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('153','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CIAD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '154')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '198',oldnation = '197',start = {d '1984-12-31'},stop = {d '1994-01-01'},title = 'CISKEI' WHERE idnation = '154'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('154','3',null,{d '2003-11-20'},'''IMPORT''','198','197',{d '1984-12-31'},{d '1994-01-01'},'CISKEI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '155')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '218',oldnation = '156',start = {d '1977-12-31'},stop = null,title = 'COMORE' WHERE idnation = '155'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('155','3',null,{d '2003-11-20'},'''IMPORT''','218','156',{d '1977-12-31'},null,'COMORE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '156')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '155',oldnation = '216',start = {d '1975-12-31'},stop = {d '1977-12-31'},title = 'COMORE (ISOLE)' WHERE idnation = '156'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('156','3',null,{d '2003-11-20'},'''IMPORT''','155','216',{d '1975-12-31'},{d '1977-12-31'},'COMORE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '157')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '160',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'CONGO BRAZZAVILLE' WHERE idnation = '157'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('157','3',null,{d '2003-11-20'},'''IMPORT''','160',null,null,{d '1975-12-31'},'CONGO BRAZZAVILLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '158')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '209',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'CONGO LEOPOLDVILLE' WHERE idnation = '158'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('158','3',null,{d '2003-11-20'},'''IMPORT''','209',null,null,{d '1975-12-31'},'CONGO LEOPOLDVILLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '159')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '209',start = {d '1997-05-17'},stop = null,title = 'CONGO REPUBBLICA DEMOCRATICA' WHERE idnation = '159'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('159','3',null,{d '2003-11-20'},'''IMPORT''',null,'209',{d '1997-05-17'},null,'CONGO REPUBBLICA DEMOCRATICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '160')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '157',start = {d '1975-12-31'},stop = null,title = 'CONGO REPUBBLICA POPOLARE' WHERE idnation = '160'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('160','3',null,{d '2003-11-20'},'''IMPORT''',null,'157',{d '1975-12-31'},null,'CONGO REPUBBLICA POPOLARE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '161')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'COSTA D''AVORIO' WHERE idnation = '161'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('161','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'COSTA D''AVORIO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '162')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '143',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'DAHOMEY=BENIN' WHERE idnation = '162'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('162','3',null,{d '2003-11-20'},'''IMPORT''','143',null,null,{d '1975-12-31'},'DAHOMEY=BENIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '163')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'EGITTO' WHERE idnation = '163'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('163','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'EGITTO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '164')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '165',start = {d '1993-05-24'},stop = null,title = 'ERITREA' WHERE idnation = '164'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('164','3',null,{d '2003-11-20'},'''IMPORT''',null,'165',{d '1993-05-24'},null,'ERITREA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '165')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '166',oldnation = null,start = null,stop = {d '1993-05-24'},title = 'ETIOPIA' WHERE idnation = '165'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('165','3',null,{d '2003-11-20'},'''IMPORT''','166',null,null,{d '1993-05-24'},'ETIOPIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '166')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '165',start = {d '1993-05-24'},stop = null,title = 'ETIOPIA' WHERE idnation = '166'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('166','3',null,{d '2003-11-20'},'''IMPORT''',null,'165',{d '1993-05-24'},null,'ETIOPIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '167')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GABON' WHERE idnation = '167'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('167','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GABON')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '168')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GAMBIA' WHERE idnation = '168'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('168','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GAMBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '169')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GHANA' WHERE idnation = '169'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('169','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GHANA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '170')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '220',start = {d '1977-12-31'},stop = null,title = 'GIBUTI' WHERE idnation = '170'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('170','3',null,{d '2003-11-20'},'''IMPORT''',null,'220',{d '1977-12-31'},null,'GIBUTI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '171')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GUINEA' WHERE idnation = '171'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('171','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GUINEA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '172')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '231',start = {d '1975-12-31'},stop = null,title = 'GUINEA BISSAU' WHERE idnation = '172'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('172','3',null,{d '2003-11-20'},'''IMPORT''',null,'231',{d '1975-12-31'},null,'GUINEA BISSAU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '173')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '213',start = {d '1975-12-31'},stop = null,title = 'GUINEA EQUATORIALE' WHERE idnation = '173'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('173','3',null,{d '2003-11-20'},'''IMPORT''',null,'213',{d '1975-12-31'},null,'GUINEA EQUATORIALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '174')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'KENYA' WHERE idnation = '174'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('174','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'KENYA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '175')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '221',start = {d '1966-10-01'},stop = null,title = 'LESOTHO' WHERE idnation = '175'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('175','3',null,{d '2003-11-20'},'''IMPORT''',null,'221',{d '1966-10-01'},null,'LESOTHO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '176')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'LIBERIA' WHERE idnation = '176'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('176','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'LIBERIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '177')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'LIBIA' WHERE idnation = '177'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('177','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'LIBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '178')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MADAGASCAR' WHERE idnation = '178'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('178','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MADAGASCAR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '179')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MALAWI' WHERE idnation = '179'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('179','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MALAWI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '180')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MALI' WHERE idnation = '180'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('180','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MALI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '181')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MAROCCO' WHERE idnation = '181'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('181','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MAROCCO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '182')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MAURITANIA' WHERE idnation = '182'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('182','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MAURITANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '183')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '223',start = {d '1975-12-31'},stop = null,title = 'MAURIZIO' WHERE idnation = '183'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('183','3',null,{d '2003-11-20'},'''IMPORT''',null,'223',{d '1975-12-31'},null,'MAURIZIO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '184')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '232',start = {d '1975-12-31'},stop = null,title = 'MOZAMBICO' WHERE idnation = '184'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('184','3',null,{d '2003-11-20'},'''IMPORT''',null,'232',{d '1975-12-31'},null,'MOZAMBICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '185')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '236',start = {d '1978-12-31'},stop = null,title = 'NAMIBIA' WHERE idnation = '185'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('185','3',null,{d '2003-11-20'},'''IMPORT''',null,'236',{d '1978-12-31'},null,'NAMIBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '186')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NIGER' WHERE idnation = '186'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('186','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NIGER')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '187')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NIGERIA' WHERE idnation = '187'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('187','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NIGERIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '188')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '212',oldnation = null,start = null,stop = {d '1980-12-31'},title = 'RHODESIA' WHERE idnation = '188'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('188','3',null,{d '2003-11-20'},'''IMPORT''','212',null,null,{d '1980-12-31'},'RHODESIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '189')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'RUANDA' WHERE idnation = '189'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('189','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'RUANDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '190')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '233',start = {d '1975-12-31'},stop = null,title = 'SAO TOME'' E PRINCIPE' WHERE idnation = '190'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('190','3',null,{d '2003-11-20'},'''IMPORT''',null,'233',{d '1975-12-31'},null,'SAO TOME'' E PRINCIPE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '191')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '218',oldnation = '225',start = {d '1977-12-31'},stop = null,title = 'SEICELLE' WHERE idnation = '191'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('191','3',null,{d '2003-11-20'},'''IMPORT''','218','225',{d '1977-12-31'},null,'SEICELLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '192')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SENEGAL' WHERE idnation = '192'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('192','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SENEGAL')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '193')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SIERRA LEONE' WHERE idnation = '193'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('193','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SIERRA LEONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '194')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SOMALIA' WHERE idnation = '194'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('194','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SOMALIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '195')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '196',oldnation = null,start = null,stop = {d '1978-12-31'},title = 'SUDAFRICANA REPUBBLICA' WHERE idnation = '195'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('195','3',null,{d '2003-11-20'},'''IMPORT''','196',null,null,{d '1978-12-31'},'SUDAFRICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '196')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '197',oldnation = '195',start = {d '1978-12-31'},stop = {d '1980-12-31'},title = 'SUDAFRICANA REPUBBLICA' WHERE idnation = '196'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('196','3',null,{d '2003-11-20'},'''IMPORT''','197','195',{d '1978-12-31'},{d '1980-12-31'},'SUDAFRICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '197')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '198',oldnation = '196',start = {d '1980-12-31'},stop = {d '1984-12-31'},title = 'SUDAFRICANA REPUBBLICA' WHERE idnation = '197'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('197','3',null,{d '2003-11-20'},'''IMPORT''','198','196',{d '1980-12-31'},{d '1984-12-31'},'SUDAFRICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '198')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1984-12-31'},stop = null,title = 'SUDAFRICANA REPUBBLICA' WHERE idnation = '198'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('198','3',null,{d '2003-11-20'},'''IMPORT''',null,null,{d '1984-12-31'},null,'SUDAFRICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '199')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SUDAN' WHERE idnation = '199'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('199','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SUDAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '200')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '226',start = {d '1975-12-31'},stop = null,title = 'SWAZILAND' WHERE idnation = '200'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('200','3',null,{d '2003-11-20'},'''IMPORT''',null,'226',{d '1975-12-31'},null,'SWAZILAND')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '201')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '202',oldnation = null,start = null,stop = {d '1966-10-01'},title = 'TANGANICA' WHERE idnation = '201'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('201','3',null,{d '2003-11-20'},'''IMPORT''','202',null,null,{d '1966-10-01'},'TANGANICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '202')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1966-10-01'},stop = null,title = 'TANZANIA' WHERE idnation = '202'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('202','3',null,{d '2003-11-20'},'''IMPORT''',null,null,{d '1966-10-01'},null,'TANZANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '203')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TOGO' WHERE idnation = '203'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('203','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'TOGO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '204')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '198',oldnation = '195',start = {d '1978-12-31'},stop = {d '1994-01-01'},title = 'TRANSKEI' WHERE idnation = '204'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('204','3',null,{d '2003-11-20'},'''IMPORT''','198','195',{d '1978-12-31'},{d '1994-01-01'},'TRANSKEI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '205')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TUNISIA' WHERE idnation = '205'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('205','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'TUNISIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '206')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'UGANDA' WHERE idnation = '206'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('206','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'UGANDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '207')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '198',oldnation = '196',start = {d '1980-12-31'},stop = {d '1994-01-01'},title = 'VENDA' WHERE idnation = '207'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('207','3',null,{d '2003-11-20'},'''IMPORT''','198','196',{d '1980-12-31'},{d '1994-01-01'},'VENDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '208')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '146',oldnation = null,start = null,stop = {d '1984-12-31'},title = 'VOLTA=ALTOVOLTA' WHERE idnation = '208'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('208','3',null,{d '2003-11-20'},'''IMPORT''','146',null,null,{d '1984-12-31'},'VOLTA=ALTOVOLTA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '209')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '159',oldnation = '158',start = {d '1975-12-31'},stop = {d '1997-05-17'},title = 'ZAIRE' WHERE idnation = '209'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('209','3',null,{d '2003-11-20'},'''IMPORT''','159','158',{d '1975-12-31'},{d '1997-05-17'},'ZAIRE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '210')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ZAMBIA' WHERE idnation = '210'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('210','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ZAMBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '211')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '202',oldnation = null,start = null,stop = {d '1966-10-01'},title = 'ZANZIBAR' WHERE idnation = '211'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('211','3',null,{d '2003-11-20'},'''IMPORT''','202',null,null,{d '1966-10-01'},'ZANZIBAR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '212')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '188',start = {d '1980-12-31'},stop = null,title = 'ZIMBABWE' WHERE idnation = '212'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('212','3',null,{d '2003-11-20'},'''IMPORT''',null,'188',{d '1980-12-31'},null,'ZIMBABWE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '213')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '173',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'GUINEA SPAGNOLA' WHERE idnation = '213'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('213','3',null,{d '2003-11-20'},'''IMPORT''','173',null,null,{d '1975-12-31'},'GUINEA SPAGNOLA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '214')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '227',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'IFNI' WHERE idnation = '214'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('214','3',null,{d '2003-11-20'},'''IMPORT''','227',null,null,{d '1975-12-31'},'IFNI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '215')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '234',oldnation = null,start = null,stop = {d '1977-12-31'},title = 'SAHARA SPAGNOLO' WHERE idnation = '215'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('215','3',null,{d '2003-11-20'},'''IMPORT''','234',null,null,{d '1977-12-31'},'SAHARA SPAGNOLO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '216')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '156',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'COMORE (ISOLE)' WHERE idnation = '216'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('216','3',null,{d '2003-11-20'},'''IMPORT''','156',null,null,{d '1975-12-31'},'COMORE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '217')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'LA REUNION (ISOLA)' WHERE idnation = '217'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('217','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'LA REUNION (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '218')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1977-12-31'},stop = null,title = 'MAYOTTE (ISOLA)' WHERE idnation = '218'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('218','3',null,{d '2003-11-20'},'''IMPORT''',null,null,{d '1977-12-31'},null,'MAYOTTE (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '219')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '220',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'SOMALIA FRANCESE' WHERE idnation = '219'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('219','3',null,{d '2003-11-20'},'''IMPORT''','220',null,null,{d '1975-12-31'},'SOMALIA FRANCESE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '220')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '170',oldnation = '219',start = {d '1975-12-31'},stop = {d '1977-12-31'},title = 'TERRITORIO FRANCESE DEGLI AFAR E DEGLI ISSA' WHERE idnation = '220'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('220','3',null,{d '2003-11-20'},'''IMPORT''','170','219',{d '1975-12-31'},{d '1977-12-31'},'TERRITORIO FRANCESE DEGLI AFAR E DEGLI ISSA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '221')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '175',oldnation = null,start = null,stop = {d '1966-10-01'},title = 'BASUTOLAND-SUD AFRICA BRITANNICO' WHERE idnation = '221'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('221','3',null,{d '2003-11-20'},'''IMPORT''','175',null,null,{d '1966-10-01'},'BASUTOLAND-SUD AFRICA BRITANNICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '222')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '145',oldnation = null,start = null,stop = {d '1966-10-01'},title = 'BECIUANIA-SUD AFRICA BRITANNICO' WHERE idnation = '222'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('222','3',null,{d '2003-11-20'},'''IMPORT''','145',null,null,{d '1966-10-01'},'BECIUANIA-SUD AFRICA BRITANNICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '223')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '183',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'MAURIZIO (ISOLE)' WHERE idnation = '223'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('223','3',null,{d '2003-11-20'},'''IMPORT''','183',null,null,{d '1975-12-31'},'MAURIZIO (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '224')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SANT''ELENA (ISOLA)' WHERE idnation = '224'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('224','3',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SANT''ELENA (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '225')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '191',oldnation = null,start = null,stop = {d '1977-12-31'},title = 'SEICELLE (ISOLE)' WHERE idnation = '225'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('225','3',null,{d '2003-11-20'},'''IMPORT''','191',null,null,{d '1977-12-31'},'SEICELLE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '226')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '200',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'SWAZILAND-SUDAFRICA BRITANNICO' WHERE idnation = '226'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('226','3',null,{d '2003-11-20'},'''IMPORT''','200',null,null,{d '1975-12-31'},'SWAZILAND-SUDAFRICA BRITANNICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '227')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '181',oldnation = '214',start = {d '1975-12-31'},stop = {d '1984-12-31'},title = 'IFNI' WHERE idnation = '227'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('227','3',null,{d '2003-11-20'},'''IMPORT''','181','214',{d '1975-12-31'},{d '1984-12-31'},'IFNI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '228')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '181',oldnation = '215',start = {d '1977-12-31'},stop = {d '1984-12-31'},title = 'SAHARA SETTENTRIONALE' WHERE idnation = '228'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('228','3',null,{d '2003-11-20'},'''IMPORT''','181','215',{d '1977-12-31'},{d '1984-12-31'},'SAHARA SETTENTRIONALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '229')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '142',oldnation = null,start = null,stop = {d '1977-12-31'},title = 'ANGOLA' WHERE idnation = '229'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('229','3',null,{d '2003-11-20'},'''IMPORT''','142',null,null,{d '1977-12-31'},'ANGOLA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '230')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '149',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'CAPO VERDE (ISOLE)' WHERE idnation = '230'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('230','3',null,{d '2003-11-20'},'''IMPORT''','149',null,null,{d '1975-12-31'},'CAPO VERDE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '231')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '172',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'GUINEA PORTOGHESE' WHERE idnation = '231'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('231','3',null,{d '2003-11-20'},'''IMPORT''','172',null,null,{d '1975-12-31'},'GUINEA PORTOGHESE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '232')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '184',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'MOZAMBICO' WHERE idnation = '232'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('232','3',null,{d '2003-11-20'},'''IMPORT''','184',null,null,{d '1975-12-31'},'MOZAMBICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '233')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '190',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'SAO TOME'' E PRINCIPE (ISOLE)' WHERE idnation = '233'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('233','3',null,{d '2003-11-20'},'''IMPORT''','190',null,null,{d '1975-12-31'},'SAO TOME'' E PRINCIPE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '234')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '181',oldnation = '215',start = {d '1977-12-31'},stop = {d '1984-12-31'},title = 'SAHARA MERIDIONALE' WHERE idnation = '234'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('234','3',null,{d '2003-11-20'},'''IMPORT''','181','215',{d '1977-12-31'},{d '1984-12-31'},'SAHARA MERIDIONALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '235')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '236',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'AFRICA DEL SUD-OVEST' WHERE idnation = '235'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('235','3',null,{d '2003-11-20'},'''IMPORT''','236',null,null,{d '1975-12-31'},'AFRICA DEL SUD-OVEST')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '236')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '185',oldnation = '235',start = {d '1975-12-31'},stop = {d '1978-12-31'},title = 'NAMIBIA=AFRICA DEL SUD OVEST' WHERE idnation = '236'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('236','3',null,{d '2003-11-20'},'''IMPORT''','185','235',{d '1975-12-31'},{d '1978-12-31'},'NAMIBIA=AFRICA DEL SUD OVEST')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '237')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CANADA' WHERE idnation = '237'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('237','4',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CANADA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '238')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'STATI UNITI D''AMERICA' WHERE idnation = '238'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('238','4',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'STATI UNITI D''AMERICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '239')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GROENLANDIA' WHERE idnation = '239'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('239','4',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GROENLANDIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '240')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SAINT PIERRE ET MIQUELON (ISOLE)' WHERE idnation = '240'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('240','4',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SAINT PIERRE ET MIQUELON (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '241')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'BERMUDA (ISOLE)' WHERE idnation = '241'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('241','4',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'BERMUDA (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '242')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '268',start = {d '1984-12-31'},stop = null,title = 'ANTIGUA E BARBUDA' WHERE idnation = '242'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('242','5',null,{d '2003-11-20'},'''IMPORT''',null,'268',{d '1984-12-31'},null,'ANTIGUA E BARBUDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '243')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '269',start = {d '1975-12-31'},stop = null,title = 'BAHAMA' WHERE idnation = '243'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('243','5',null,{d '2003-11-20'},'''IMPORT''',null,'269',{d '1975-12-31'},null,'BAHAMA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '244')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '265',start = {d '1975-12-31'},stop = null,title = 'BARBADOS' WHERE idnation = '244'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('244','5',null,{d '2003-11-20'},'''IMPORT''',null,'265',{d '1975-12-31'},null,'BARBADOS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '245')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '270',start = {d '1984-12-31'},stop = null,title = 'BELIZE' WHERE idnation = '245'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('245','5',null,{d '2003-11-20'},'''IMPORT''',null,'270',{d '1984-12-31'},null,'BELIZE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '246')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'COSTA RICA' WHERE idnation = '246'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('246','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'COSTA RICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '247')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CUBA' WHERE idnation = '247'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('247','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CUBA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '248')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '267',start = {d '1980-12-31'},stop = null,title = 'DOMINICA' WHERE idnation = '248'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('248','5',null,{d '2003-11-20'},'''IMPORT''',null,'267',{d '1980-12-31'},null,'DOMINICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '249')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DOMINICANA REPUBBLICA' WHERE idnation = '249'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('249','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DOMINICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '250')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'EL SALVADOR' WHERE idnation = '250'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('250','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'EL SALVADOR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '251')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GIAMAICA' WHERE idnation = '251'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('251','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GIAMAICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '252')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '266',start = {d '1977-12-31'},stop = null,title = 'GRENADA' WHERE idnation = '252'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('252','5',null,{d '2003-11-20'},'''IMPORT''',null,'266',{d '1977-12-31'},null,'GRENADA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '253')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GUATEMALA' WHERE idnation = '253'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('253','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GUATEMALA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '254')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'HAITI' WHERE idnation = '254'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('254','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'HAITI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '255')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'HONDURAS' WHERE idnation = '255'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('255','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'HONDURAS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '256')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MESSICO' WHERE idnation = '256'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('256','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MESSICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '257')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NICARAGUA' WHERE idnation = '257'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('257','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NICARAGUA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '258')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PANAMA''' WHERE idnation = '258'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('258','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'PANAMA''')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '259')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '268',start = {d '1984-12-31'},stop = null,title = 'SAINT KITTS E NEVIS=SAINT CHRISTOPHER E NEVIS' WHERE idnation = '259'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('259','5',null,{d '2003-11-20'},'''IMPORT''',null,'268',{d '1984-12-31'},null,'SAINT KITTS E NEVIS=SAINT CHRISTOPHER E NEVIS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '260')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '267',start = {d '1980-12-31'},stop = null,title = 'SAINT LUCIA' WHERE idnation = '260'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('260','5',null,{d '2003-11-20'},'''IMPORT''',null,'267',{d '1980-12-31'},null,'SAINT LUCIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '261')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '267',start = {d '1980-12-31'},stop = null,title = 'SAINT VINCENT E GRENADINE' WHERE idnation = '261'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('261','5',null,{d '2003-11-20'},'''IMPORT''',null,'267',{d '1980-12-31'},null,'SAINT VINCENT E GRENADINE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '262')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GUADALUPA' WHERE idnation = '262'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('262','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GUADALUPA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '263')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MARTINICA' WHERE idnation = '263'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('263','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MARTINICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '264')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '267',start = {d '1980-12-31'},stop = null,title = 'ANGUILLA (ISOLA)' WHERE idnation = '264'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('264','5',null,{d '2003-11-20'},'''IMPORT''',null,'267',{d '1980-12-31'},null,'ANGUILLA (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '265')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '266',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'ANTILLE BRITANNICHE' WHERE idnation = '265'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('265','5',null,{d '2003-11-20'},'''IMPORT''','266',null,null,{d '1975-12-31'},'ANTILLE BRITANNICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '266')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '267',oldnation = '265',start = {d '1975-12-31'},stop = {d '1977-12-31'},title = 'ANTILLE BRITANNICHE' WHERE idnation = '266'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('266','5',null,{d '2003-11-20'},'''IMPORT''','267','265',{d '1975-12-31'},{d '1977-12-31'},'ANTILLE BRITANNICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '267')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '268',oldnation = '266',start = {d '1977-12-31'},stop = {d '1980-12-31'},title = 'ANTILLE BRITANNICHE' WHERE idnation = '267'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('267','5',null,{d '2003-11-20'},'''IMPORT''','268','266',{d '1977-12-31'},{d '1980-12-31'},'ANTILLE BRITANNICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '268')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '242',oldnation = '267',start = {d '1980-12-31'},stop = {d '1984-12-31'},title = 'ANTILLE BRITANNICHE' WHERE idnation = '268'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('268','5',null,{d '2003-11-20'},'''IMPORT''','242','267',{d '1980-12-31'},{d '1984-12-31'},'ANTILLE BRITANNICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '269')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '243',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'BAHAMA (ISOLE)' WHERE idnation = '269'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('269','5',null,{d '2003-11-20'},'''IMPORT''','243',null,null,{d '1975-12-31'},'BAHAMA (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '270')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '245',oldnation = '272',start = {d '1975-12-31'},stop = {d '1984-12-31'},title = 'BELIZE' WHERE idnation = '270'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('270','5',null,{d '2003-11-20'},'''IMPORT''','245','272',{d '1975-12-31'},{d '1984-12-31'},'BELIZE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '271')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '267',start = {d '1980-12-31'},stop = null,title = 'CAYMAN (ISOLE)' WHERE idnation = '271'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('271','5',null,{d '2003-11-20'},'''IMPORT''',null,'267',{d '1980-12-31'},null,'CAYMAN (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '272')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '270',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'HONDURAS BRITANNICO' WHERE idnation = '272'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('272','5',null,{d '2003-11-20'},'''IMPORT''','270',null,null,{d '1975-12-31'},'HONDURAS BRITANNICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '273')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '267',start = {d '1980-12-31'},stop = null,title = 'MONTSERRAT' WHERE idnation = '273'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('273','5',null,{d '2003-11-20'},'''IMPORT''',null,'267',{d '1980-12-31'},null,'MONTSERRAT')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '274')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TURKS E CAICOS (ISOLE)' WHERE idnation = '274'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('274','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'TURKS E CAICOS (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '275')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1978-12-31'},stop = null,title = 'VERGINI BRITANNICHE (ISOLE)' WHERE idnation = '275'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('275','5',null,{d '2003-11-20'},'''IMPORT''',null,null,{d '1978-12-31'},null,'VERGINI BRITANNICHE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '276')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ANTILLE OLANDESI' WHERE idnation = '276'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('276','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ANTILLE OLANDESI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '277')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '278',start = {d '1980-12-31'},stop = null,title = 'PANAMA ZONA DEL CANALE' WHERE idnation = '277'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('277','5',null,{d '2003-11-20'},'''IMPORT''',null,'278',{d '1980-12-31'},null,'PANAMA ZONA DEL CANALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '278')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '277',oldnation = null,start = null,stop = {d '1980-12-31'},title = 'PANAMA ZONA DEL CANALE' WHERE idnation = '278'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('278','5',null,{d '2003-11-20'},'''IMPORT''','277',null,null,{d '1980-12-31'},'PANAMA ZONA DEL CANALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '279')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PUERTO RICO' WHERE idnation = '279'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('279','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'PUERTO RICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '280')
UPDATE [geo_nation] SET idcontinent = '5',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'VERGINI AMERICANE (ISOLE)' WHERE idnation = '280'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('280','5',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'VERGINI AMERICANE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '281')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ARGENTINA' WHERE idnation = '281'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('281','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ARGENTINA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '282')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'BOLIVIA' WHERE idnation = '282'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('282','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'BOLIVIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '283')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'BRASILE' WHERE idnation = '283'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('283','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'BRASILE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '284')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CILE' WHERE idnation = '284'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('284','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CILE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '285')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'COLOMBIA' WHERE idnation = '285'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('285','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'COLOMBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '286')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ECUADOR' WHERE idnation = '286'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('286','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'ECUADOR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '287')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '295',start = {d '1975-12-31'},stop = null,title = 'GUYANA' WHERE idnation = '287'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('287','6',null,{d '2003-11-20'},'''IMPORT''',null,'295',{d '1975-12-31'},null,'GUYANA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '288')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PARAGUAY' WHERE idnation = '288'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('288','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'PARAGUAY')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '289')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PERU''' WHERE idnation = '289'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('289','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'PERU''')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '290')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '297',start = {d '1975-12-31'},stop = null,title = 'SURINAME' WHERE idnation = '290'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('290','6',null,{d '2003-11-20'},'''IMPORT''',null,'297',{d '1975-12-31'},null,'SURINAME')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '291')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TRINIDAD E TOBAGO' WHERE idnation = '291'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('291','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'TRINIDAD E TOBAGO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '292')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'URUGUAY' WHERE idnation = '292'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('292','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'URUGUAY')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '293')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'VENEZUELA' WHERE idnation = '293'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('293','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'VENEZUELA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '294')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GUAYANA=GUIANA FRANCESE' WHERE idnation = '294'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('294','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GUAYANA=GUIANA FRANCESE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '295')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '287',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'GUYANA BRITANNICA' WHERE idnation = '295'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('295','6',null,{d '2003-11-20'},'''IMPORT''','287',null,null,{d '1975-12-31'},'GUYANA BRITANNICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '296')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MALVINE=FALKLAND (ISOLE)' WHERE idnation = '296'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('296','6',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MALVINE=FALKLAND (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '297')
UPDATE [geo_nation] SET idcontinent = '6',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '290',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'GUAYANA OLANDESE' WHERE idnation = '297'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('297','6',null,{d '2003-11-20'},'''IMPORT''','290',null,null,{d '1975-12-31'},'GUAYANA OLANDESE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '298')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'AUSTRALIA' WHERE idnation = '298'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('298','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'AUSTRALIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '299')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '321',start = {d '1975-12-31'},stop = null,title = 'FIGI=VITI' WHERE idnation = '299'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('299','7',null,{d '2003-11-20'},'''IMPORT''',null,'321',{d '1975-12-31'},null,'FIGI=VITI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '300')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '322',start = {d '1980-12-31'},stop = null,title = 'KIRIBATI' WHERE idnation = '300'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('300','7',null,{d '2003-11-20'},'''IMPORT''',null,'322',{d '1980-12-31'},null,'KIRIBATI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '301')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '338',start = {d '1990-12-22'},stop = null,title = 'MARSHALL' WHERE idnation = '301'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('301','7',null,{d '2003-11-20'},'''IMPORT''',null,'338',{d '1990-12-22'},null,'MARSHALL')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '302')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '334',start = {d '1990-12-22'},stop = null,title = 'MICRONESIA STATI FEDERATI' WHERE idnation = '302'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('302','7',null,{d '2003-11-20'},'''IMPORT''',null,'334',{d '1990-12-22'},null,'MICRONESIA STATI FEDERATI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '303')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '314',start = {d '1975-12-31'},stop = null,title = 'NAURU' WHERE idnation = '303'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('303','7',null,{d '2003-11-20'},'''IMPORT''',null,'314',{d '1975-12-31'},null,'NAURU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '304')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NUOVA ZELANDA' WHERE idnation = '304'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('304','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NUOVA ZELANDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '305')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '340',start = {d '1997-01-01'},stop = null,title = 'PALAU' WHERE idnation = '305'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('305','7',null,{d '2003-11-20'},'''IMPORT''',null,'340',{d '1997-01-01'},null,'PALAU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '306')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = {d '1975-12-31'},stop = null,title = 'PAPUA NUOVA GUINEA' WHERE idnation = '306'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('306','7',null,{d '2003-11-20'},'''IMPORT''',null,null,{d '1975-12-31'},null,'PAPUA NUOVA GUINEA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '307')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '324',start = {d '1978-12-31'},stop = null,title = 'SALOMONE' WHERE idnation = '307'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('307','7',null,{d '2003-11-20'},'''IMPORT''',null,'324',{d '1978-12-31'},null,'SALOMONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '308')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SAMOA' WHERE idnation = '308'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('308','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SAMOA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '309')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '325',start = {d '1975-12-31'},stop = null,title = 'TONGA=ISOLE DEGLI AMICI' WHERE idnation = '309'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('309','7',null,{d '2003-11-20'},'''IMPORT''',null,'325',{d '1975-12-31'},null,'TONGA=ISOLE DEGLI AMICI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '310')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '322',start = {d '1980-12-31'},stop = null,title = 'TUVALU' WHERE idnation = '310'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('310','7',null,{d '2003-11-20'},'''IMPORT''',null,'322',{d '1980-12-31'},null,'TUVALU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '311')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '326',start = {d '1980-12-31'},stop = null,title = 'VANUATU' WHERE idnation = '311'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('311','7',null,{d '2003-11-20'},'''IMPORT''',null,'326',{d '1980-12-31'},null,'VANUATU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '312')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CHRISTMAS (ISOLA)' WHERE idnation = '312'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('312','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'CHRISTMAS (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '313')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MACQUARIE (ISOLE)' WHERE idnation = '313'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('313','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MACQUARIE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '314')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '303',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'NAURU (ISOLE)' WHERE idnation = '314'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('314','7',null,{d '2003-11-20'},'''IMPORT''','303',null,null,{d '1975-12-31'},'NAURU (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '315')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NORFOLK (ISOLE E ISOLE DEL MAR DEI CORALLI)' WHERE idnation = '315'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('315','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NORFOLK (ISOLE E ISOLE DEL MAR DEI CORALLI)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '316')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '306',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'NUOVA GUINEA' WHERE idnation = '316'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('316','7',null,{d '2003-11-20'},'''IMPORT''','306',null,null,{d '1975-12-31'},'NUOVA GUINEA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '317')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '306',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'PAPUASIA' WHERE idnation = '317'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('317','7',null,{d '2003-11-20'},'''IMPORT''','306',null,null,{d '1975-12-31'},'PAPUASIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '318')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NUOVA CALEDONIA (ISOLE E DIPENDENZE)' WHERE idnation = '318'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('318','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NUOVA CALEDONIA (ISOLE E DIPENDENZE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '319')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'POLINESIA FRANCESE (ISOLE)' WHERE idnation = '319'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('319','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'POLINESIA FRANCESE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '320')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'WALLIS E FUTUNA (ISOLE)' WHERE idnation = '320'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('320','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'WALLIS E FUTUNA (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '321')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '299',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'FIGI=VITI (ISOLE)' WHERE idnation = '321'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('321','7',null,{d '2003-11-20'},'''IMPORT''','299',null,null,{d '1975-12-31'},'FIGI=VITI (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '322')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '300',oldnation = null,start = null,stop = {d '1980-12-31'},title = 'GILBERT E ELLICE (ISOLE)' WHERE idnation = '322'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('322','7',null,{d '2003-11-20'},'''IMPORT''','300',null,null,{d '1980-12-31'},'GILBERT E ELLICE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '323')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PITCAIRN (E DIPENDENZE)' WHERE idnation = '323'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('323','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'PITCAIRN (E DIPENDENZE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '324')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '307',oldnation = null,start = null,stop = {d '1978-12-31'},title = 'SALOMONE (ISOLE)' WHERE idnation = '324'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('324','7',null,{d '2003-11-20'},'''IMPORT''','307',null,null,{d '1978-12-31'},'SALOMONE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '325')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '309',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'TONGA=DEGLI AMICI (ISOLE)' WHERE idnation = '325'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('325','7',null,{d '2003-11-20'},'''IMPORT''','309',null,null,{d '1975-12-31'},'TONGA=DEGLI AMICI (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '326')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '311',oldnation = null,start = null,stop = {d '1980-12-31'},title = 'NUOVE EBRIDI (ISOLE CONDOMINIO FRANCO-INGLESE)' WHERE idnation = '326'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('326','7',null,{d '2003-11-20'},'''IMPORT''','311',null,null,{d '1980-12-31'},'NUOVE EBRIDI (ISOLE CONDOMINIO FRANCO-INGLESE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '327')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'COOK (ISOLE)' WHERE idnation = '327'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('327','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'COOK (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '328')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'NIUE=SAVAGE (ISOLE)' WHERE idnation = '328'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('328','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'NIUE=SAVAGE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '329')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TOKELAU=ISOLE DELL''UNIONE' WHERE idnation = '329'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('329','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'TOKELAU=ISOLE DELL''UNIONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '330')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '331',start = {d '1984-12-31'},stop = null,title = 'ISOLE CILENE (PASQUA E SALA Y GOMEZ)' WHERE idnation = '330'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('330','7',null,{d '2003-11-20'},'''IMPORT''',null,'331',{d '1984-12-31'},null,'ISOLE CILENE (PASQUA E SALA Y GOMEZ)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '331')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '330',oldnation = null,start = null,stop = {d '1984-12-31'},title = 'PASQUA (ISOLA)' WHERE idnation = '331'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('331','7',null,{d '2003-11-20'},'''IMPORT''','330',null,null,{d '1984-12-31'},'PASQUA (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '332')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'IRIAN OCCIDENTALE' WHERE idnation = '332'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('332','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'IRIAN OCCIDENTALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '333')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '334',oldnation = null,start = null,stop = {d '1984-12-31'},title = 'CAROLINE (ISOLE)' WHERE idnation = '333'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('333','7',null,{d '2003-11-20'},'''IMPORT''','334',null,null,{d '1984-12-31'},'CAROLINE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '334')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '302',oldnation = '333',start = {d '1984-12-31'},stop = {d '1990-12-22'},title = 'CAROLINE (ISOLE)=STATI FEDERATI DI MICRONESIA' WHERE idnation = '334'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('334','7',null,{d '2003-11-20'},'''IMPORT''','302','333',{d '1984-12-31'},{d '1990-12-22'},'CAROLINE (ISOLE)=STATI FEDERATI DI MICRONESIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '335')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GUAM (ISOLA)' WHERE idnation = '335'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('335','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'GUAM (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '336')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '95',oldnation = null,start = null,stop = {d '1975-12-31'},title = 'MARCUS (ISOLE)' WHERE idnation = '336'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('336','7',null,{d '2003-11-20'},'''IMPORT''','95',null,null,{d '1975-12-31'},'MARCUS (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '337')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MARIANNE (ISOLE)' WHERE idnation = '337'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('337','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MARIANNE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '338')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '301',oldnation = null,start = null,stop = {d '1990-12-22'},title = 'MARSHALL (ISOLE)' WHERE idnation = '338'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('338','7',null,{d '2003-11-20'},'''IMPORT''','301',null,null,{d '1990-12-22'},'MARSHALL (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '339')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MIDWAY (ISOLE)' WHERE idnation = '339'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('339','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'MIDWAY (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '340')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '305',oldnation = '333',start = {d '1984-12-31'},stop = {d '1997-01-01'},title = 'PALAU REPUBBLICA' WHERE idnation = '340'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('340','7',null,{d '2003-11-20'},'''IMPORT''','305','333',{d '1984-12-31'},{d '1997-01-01'},'PALAU REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '341')
UPDATE [geo_nation] SET idcontinent = '7',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SAMOA AMERICANE (ISOLE)' WHERE idnation = '341'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('341','7',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'SAMOA AMERICANE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '342')
UPDATE [geo_nation] SET idcontinent = '8',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE CANADESI' WHERE idnation = '342'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('342','8',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE CANADESI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '343')
UPDATE [geo_nation] SET idcontinent = '8',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE NORVEGESI ARTICHE' WHERE idnation = '343'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('343','8',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE NORVEGESI ARTICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '344')
UPDATE [geo_nation] SET idcontinent = '8',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = '345',start = {d '1992-03-31'},stop = null,title = 'DIPENDENZE RUSSE' WHERE idnation = '344'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('344','8',null,{d '2003-11-20'},'''IMPORT''',null,'345',{d '1992-03-31'},null,'DIPENDENZE RUSSE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '345')
UPDATE [geo_nation] SET idcontinent = '8',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '344',oldnation = null,start = null,stop = {d '1992-03-31'},title = 'DIPENDENZE SOVIETICHE' WHERE idnation = '345'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('345','8',null,{d '2003-11-20'},'''IMPORT''','344',null,null,{d '1992-03-31'},'DIPENDENZE SOVIETICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '346')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE AUSTRALIANE' WHERE idnation = '346'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('346','9',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE AUSTRALIANE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '347')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE BRITANNICHE' WHERE idnation = '347'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('347','9',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE BRITANNICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '348')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE FRANCESI' WHERE idnation = '348'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('348','9',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE FRANCESI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '349')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE NEOZELANDESI' WHERE idnation = '349'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('349','9',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE NEOZELANDESI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '350')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE NORVEGESI ANTARTICHE' WHERE idnation = '350'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('350','9',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE NORVEGESI ANTARTICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '351')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE STATUNITENSI' WHERE idnation = '351'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('351','9',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE STATUNITENSI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '352')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE SUDAFRICANE' WHERE idnation = '352'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('352','9',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'DIPENDENZE SUDAFRICANE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '353')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'Palestina' WHERE idnation = '353'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('353','2',null,{d '2003-11-20'},'''IMPORT''',null,null,null,null,'Palestina')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '354')
UPDATE [geo_nation] SET idcontinent = '0',lang = null,lt = {d '2003-11-20'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'APOLIDE' WHERE idnation = '354'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('354','0',null,{d '2003-11-20'},'Software and more',null,null,null,null,'APOLIDE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '355')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newnation = '83',oldnation = null,start = null,stop = null,title = 'BURMA' WHERE idnation = '355'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('355','2',null,{d '2003-11-20'},'''IMPORT''','83',null,null,null,'BURMA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '356')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {ts '2004-06-08 12:57:12.640'},lu = '''IMPORT''',newnation = null,oldnation = '83',start = {d '1989-06-18'},stop = null,title = 'MYANMAR' WHERE idnation = '356'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('356','2',null,{ts '2004-06-08 12:57:12.640'},'''IMPORT''',null,'83',{d '1989-06-18'},null,'MYANMAR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '357')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CANARIE ISOLE' WHERE idnation = '357'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('357',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'CANARIE ISOLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '358')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CAMPIONE D''ITALIA' WHERE idnation = '358'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('358','1',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'CAMPIONE D''ITALIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '359')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SAHARA OCCIDENTALE' WHERE idnation = '359'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('359','3',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'SAHARA OCCIDENTALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '360')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'WAKE ISOLE' WHERE idnation = '360'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('360',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'WAKE ISOLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '361')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TERRITORIO ANTARTICO BRITANNICO' WHERE idnation = '361'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('361','9',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'TERRITORIO ANTARTICO BRITANNICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '362')
UPDATE [geo_nation] SET idcontinent = '9',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TERRITORIO ANTARTICO FRANCESE' WHERE idnation = '362'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('362','9',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'TERRITORIO ANTARTICO FRANCESE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '363')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GUERNSEY C.I' WHERE idnation = '363'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('363',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'GUERNSEY C.I')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '364')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'JERSEY C.I.' WHERE idnation = '364'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('364','1',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'JERSEY C.I.')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '365')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ARUBA' WHERE idnation = '365'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('365','4',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'ARUBA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '366')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PORTORICO' WHERE idnation = '366'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('366','4',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'PORTORICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '367')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SAINT MARTIN SETTENTRIONALE' WHERE idnation = '367'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('367',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'SAINT MARTIN SETTENTRIONALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '368')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CLIPPERTON' WHERE idnation = '368'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('368',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'CLIPPERTON')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '369')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ASCENSION' WHERE idnation = '369'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('369',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'ASCENSION')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '370')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'GOUGH' WHERE idnation = '370'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('370',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'GOUGH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '371')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TRISTAN DA CUNHA' WHERE idnation = '371'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('371',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'TRISTAN DA CUNHA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '372')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CHAFARINAS' WHERE idnation = '372'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('372',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'CHAFARINAS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '373')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MELILLA' WHERE idnation = '373'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('373',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'MELILLA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '374')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PENON DE ALHUCEMAS' WHERE idnation = '374'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('374',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'PENON DE ALHUCEMAS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '375')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PENON DE VELEZ DE LA GOMERA' WHERE idnation = '375'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('375',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'PENON DE VELEZ DE LA GOMERA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '376')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'AZZORRE ISOLE' WHERE idnation = '376'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('376',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'AZZORRE ISOLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '377')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'MADEIRA' WHERE idnation = '377'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('377',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'MADEIRA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '378')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ABU DHABI' WHERE idnation = '378'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('378',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'ABU DHABI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '379')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'AJMAN' WHERE idnation = '379'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('379',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'AJMAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '380')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'DUBAI' WHERE idnation = '380'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('380',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'DUBAI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '381')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'FUIJAYRAH' WHERE idnation = '381'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('381',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'FUIJAYRAH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '382')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'RAS AL KHAIMAH' WHERE idnation = '382'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('382',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'RAS AL KHAIMAH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '383')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SHARJAH' WHERE idnation = '383'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('383',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'SHARJAH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '384')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'UMM AL QAIWAIN' WHERE idnation = '384'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('384',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'UMM AL QAIWAIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '385')
UPDATE [geo_nation] SET idcontinent = '2',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'TERRITORIO BRIT. OCEANO INDIANO' WHERE idnation = '385'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('385','2',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'TERRITORIO BRIT. OCEANO INDIANO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '386')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CEUTA' WHERE idnation = '386'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('386',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'CEUTA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '387')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SAINT-PIERRE E MIQUELON' WHERE idnation = '387'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('387','4',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'SAINT-PIERRE E MIQUELON')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '388')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ISOLE AMERICANE DEL PACIFICO' WHERE idnation = '388'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('388',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'ISOLE AMERICANE DEL PACIFICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '389')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'CHAGOS ISOLE' WHERE idnation = '389'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('389',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'CHAGOS ISOLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '390')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'BOUVET ISLAND' WHERE idnation = '390'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('390',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'BOUVET ISLAND')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '391')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SOUTH GEORGIA AND SOUTH SANDWICH' WHERE idnation = '391'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('391',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'SOUTH GEORGIA AND SOUTH SANDWICH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '392')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'HEARD AND MCDONALD ISLAND' WHERE idnation = '392'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('392',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'HEARD AND MCDONALD ISLAND')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '393')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SVALBARD AND JAN MAYEN ISLANDS' WHERE idnation = '393'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('393','1',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'SVALBARD AND JAN MAYEN ISLANDS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '394')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'ALDERNEY C.I' WHERE idnation = '394'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('394',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'ALDERNEY C.I')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '395')
UPDATE [geo_nation] SET idcontinent = '4',lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'BARBUDA' WHERE idnation = '395'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('395','4',null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'BARBUDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '396')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'HERM C.I.' WHERE idnation = '396'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('396',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'HERM C.I.')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '397')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'SARK C.I.' WHERE idnation = '397'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('397',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'SARK C.I.')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '398')
UPDATE [geo_nation] SET idcontinent = null,lang = null,lt = {ts '2004-06-08 14:27:55.060'},lu = '''IMPORT''',newnation = null,oldnation = null,start = null,stop = null,title = 'PAESI NON CLASSIFICATI' WHERE idnation = '398'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('398',null,null,{ts '2004-06-08 14:27:55.060'},'''IMPORT''',null,null,null,null,'PAESI NON CLASSIFICATI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '399')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2007-10-10'},lu = '''UPDATE''',newnation = null,oldnation = '49',start = {d '2006-06-03'},stop = null,title = 'SERBIA' WHERE idnation = '399'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('399','1',null,{d '2007-10-10'},'''UPDATE''',null,'49',{d '2006-06-03'},null,'SERBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '400')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {d '2007-10-10'},lu = '''UPDATE''',newnation = null,oldnation = '49',start = {d '2007-06-03'},stop = null,title = 'MONTENEGRO' WHERE idnation = '400'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('400','1',null,{d '2007-10-10'},'''UPDATE''',null,'49',{d '2007-06-03'},null,'MONTENEGRO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '401')
UPDATE [geo_nation] SET idcontinent = '1',lang = null,lt = {ts '2016-07-06 16:34:24.400'},lu = 'NINO',newnation = null,oldnation = null,start = {d '2008-02-21'},stop = null,title = 'KOSSOVO' WHERE idnation = '401'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('401','1',null,{ts '2016-07-06 16:34:24.400'},'NINO',null,null,{d '2008-02-21'},null,'KOSSOVO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '402')
UPDATE [geo_nation] SET idcontinent = '3',lang = null,lt = {ts '2018-11-27 10:26:08.560'},lu = 'sw',newnation = null,oldnation = null,start = null,stop = null,title = 'SUDAN DEL SUD' WHERE idnation = '402'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lang,lt,lu,newnation,oldnation,start,stop,title) VALUES ('402','3',null,{ts '2018-11-27 10:26:08.560'},'sw',null,null,null,null,'SUDAN DEL SUD')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'geo_nation')
UPDATE [tabledescr] SET description = 'Nazioni',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:28.863'},lu = 'nino',title = 'Nazioni' WHERE tablename = 'geo_nation'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('geo_nation','Nazioni',null,'S',{ts '1900-01-01 03:00:28.863'},'nino','Nazioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontinent' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id continente',kind = 'S',lt = {ts '2016-10-07 17:19:49.497'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontinent' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontinent','geo_nation','4',null,null,'id continente','S',{ts '2016-10-07 17:19:49.497'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id nazione (tabella geo_nation)',kind = 'S',lt = {ts '1900-01-01 03:00:14.957'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','geo_nation','4',null,null,'Id nazione (tabella geo_nation)','S',{ts '1900-01-01 03:00:14.957'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.907'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','geo_nation','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.907'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','geo_nation','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.937'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newnation' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazione in cui questa è confluita',kind = 'S',lt = {ts '2020-10-16 10:31:37.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'newnation' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newnation','geo_nation','4',null,null,'Nazione in cui questa è confluita','S',{ts '2020-10-16 10:31:37.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oldnation' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazione da cui questa è confluita',kind = 'S',lt = {ts '2020-10-16 10:31:37.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oldnation' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oldnation','geo_nation','4',null,null,'Nazione da cui questa è confluita','S',{ts '2020-10-16 10:31:37.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data inizio',kind = 'S',lt = {ts '1900-01-01 02:59:54.110'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','geo_nation','4',null,null,'data inizio','S',{ts '1900-01-01 02:59:54.110'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data fine',kind = 'S',lt = {ts '1900-01-01 02:59:54.617'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','geo_nation','4',null,null,'data fine','S',{ts '1900-01-01 02:59:54.617'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '65',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '1900-01-01 03:00:00.090'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(65)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','geo_nation','65',null,null,'Denominazione','S',{ts '1900-01-01 03:00:00.090'},'nino','N','varchar(65)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '1352')
UPDATE [relation] SET childtable = 'geo_nation',description = 'id continente',lt = {ts '2017-05-20 09:20:01.013'},lu = 'lu',parenttable = 'parasubcontract',title = 'Nazioni' WHERE idrelation = '1352'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1352','geo_nation','id continente',{ts '2017-05-20 09:20:01.013'},'lu','parasubcontract','Nazioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '1352' AND parentcol = 'idcon')
UPDATE [relationcol] SET childcol = 'idcontinent',lt = {ts '2017-05-20 09:20:01.157'},lu = 'lu' WHERE idrelation = '1352' AND parentcol = 'idcon'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('1352','idcon','idcontinent',{ts '2017-05-20 09:20:01.157'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

