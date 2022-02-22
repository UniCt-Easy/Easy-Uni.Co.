
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
-- CREAZIONE TABELLA geo_country --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_country]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_country] (
idcountry int NOT NULL,
idregion int NULL,
lt datetime NULL,
lu varchar(64) NULL,
newcountry int NULL,
oldcountry int NULL,
province char(2) NULL,
start date NULL,
stop date NULL,
title varchar(50) NULL,
 CONSTRAINT xpkgeo_country PRIMARY KEY (idcountry
)
)
END
GO

-- VERIFICA STRUTTURA geo_country --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'idcountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD idcountry int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('geo_country') and col.name = 'idcountry' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [geo_country] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'idregion' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD idregion int NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN idregion int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'newcountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD newcountry int NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN newcountry int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'oldcountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD oldcountry int NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN oldcountry int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'province' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD province char(2) NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN province char(2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD start date NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD stop date NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_country' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_country] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [geo_country] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI geo_country IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_country'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_country','int','ASSISTENZA','idcountry','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','int','ASSISTENZA','idregion','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','int','ASSISTENZA','newcountry','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','int','ASSISTENZA','oldcountry','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','char(2)','ASSISTENZA','province','2','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','date','ASSISTENZA','start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_country','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI geo_country IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_country')
UPDATE customobject set isreal = 'S' where objectname = 'geo_country'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_country', 'S')
GO

-- GENERAZIONE DATI PER geo_country --
IF exists(SELECT * FROM [geo_country] WHERE idcountry = '1')
UPDATE [geo_country] SET idregion = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'TO',start = null,stop = null,title = 'Torino' WHERE idcountry = '1'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('1','1',{d '2003-11-20'},'''IMPORT''',null,null,'TO',null,null,'Torino')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '2')
UPDATE [geo_country] SET idregion = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'VC',start = null,stop = null,title = 'Vercelli' WHERE idcountry = '2'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('2','1',{d '2003-11-20'},'''IMPORT''',null,null,'VC',null,null,'Vercelli')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '3')
UPDATE [geo_country] SET idregion = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'NO',start = null,stop = null,title = 'Novara' WHERE idcountry = '3'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('3','1',{d '2003-11-20'},'''IMPORT''',null,null,'NO',null,null,'Novara')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '4')
UPDATE [geo_country] SET idregion = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CN',start = null,stop = null,title = 'Cuneo' WHERE idcountry = '4'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('4','1',{d '2003-11-20'},'''IMPORT''',null,null,'CN',null,null,'Cuneo')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '5')
UPDATE [geo_country] SET idregion = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AT',start = null,stop = null,title = 'Asti' WHERE idcountry = '5'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('5','1',{d '2003-11-20'},'''IMPORT''',null,null,'AT',null,null,'Asti')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '6')
UPDATE [geo_country] SET idregion = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AL',start = null,stop = null,title = 'Alessandria' WHERE idcountry = '6'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('6','1',{d '2003-11-20'},'''IMPORT''',null,null,'AL',null,null,'Alessandria')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '7')
UPDATE [geo_country] SET idregion = '2',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AO',start = null,stop = null,title = 'Aosta' WHERE idcountry = '7'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('7','2',{d '2003-11-20'},'''IMPORT''',null,null,'AO',null,null,'Aosta')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '8')
UPDATE [geo_country] SET idregion = '7',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'IM',start = null,stop = null,title = 'Imperia' WHERE idcountry = '8'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('8','7',{d '2003-11-20'},'''IMPORT''',null,null,'IM',null,null,'Imperia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '9')
UPDATE [geo_country] SET idregion = '7',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'SV',start = null,stop = null,title = 'Savona' WHERE idcountry = '9'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('9','7',{d '2003-11-20'},'''IMPORT''',null,null,'SV',null,null,'Savona')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '10')
UPDATE [geo_country] SET idregion = '7',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'GE',start = null,stop = null,title = 'Genova' WHERE idcountry = '10'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('10','7',{d '2003-11-20'},'''IMPORT''',null,null,'GE',null,null,'Genova')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '11')
UPDATE [geo_country] SET idregion = '7',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'SP',start = null,stop = null,title = 'La Spezia' WHERE idcountry = '11'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('11','7',{d '2003-11-20'},'''IMPORT''',null,null,'SP',null,null,'La Spezia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '12')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'VA',start = null,stop = null,title = 'Varese' WHERE idcountry = '12'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('12','3',{d '2003-11-20'},'''IMPORT''',null,null,'VA',null,null,'Varese')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '13')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CO',start = null,stop = null,title = 'Como' WHERE idcountry = '13'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('13','3',{d '2003-11-20'},'''IMPORT''',null,null,'CO',null,null,'Como')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '14')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'SO',start = null,stop = null,title = 'Sondrio' WHERE idcountry = '14'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('14','3',{d '2003-11-20'},'''IMPORT''',null,null,'SO',null,null,'Sondrio')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '15')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'MI',start = null,stop = null,title = 'Milano' WHERE idcountry = '15'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('15','3',{d '2003-11-20'},'''IMPORT''',null,null,'MI',null,null,'Milano')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '16')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BG',start = null,stop = null,title = 'Bergamo' WHERE idcountry = '16'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('16','3',{d '2003-11-20'},'''IMPORT''',null,null,'BG',null,null,'Bergamo')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '17')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BS',start = null,stop = null,title = 'Brescia' WHERE idcountry = '17'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('17','3',{d '2003-11-20'},'''IMPORT''',null,null,'BS',null,null,'Brescia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '18')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PV',start = null,stop = null,title = 'Pavia' WHERE idcountry = '18'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('18','3',{d '2003-11-20'},'''IMPORT''',null,null,'PV',null,null,'Pavia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '19')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CR',start = null,stop = null,title = 'Cremona' WHERE idcountry = '19'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('19','3',{d '2003-11-20'},'''IMPORT''',null,null,'CR',null,null,'Cremona')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '20')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'MN',start = null,stop = null,title = 'Mantova' WHERE idcountry = '20'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('20','3',{d '2003-11-20'},'''IMPORT''',null,null,'MN',null,null,'Mantova')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '21')
UPDATE [geo_country] SET idregion = '4',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BZ',start = null,stop = null,title = 'Bolzano - Bozen' WHERE idcountry = '21'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('21','4',{d '2003-11-20'},'''IMPORT''',null,null,'BZ',null,null,'Bolzano - Bozen')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '22')
UPDATE [geo_country] SET idregion = '4',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'TN',start = null,stop = null,title = 'Trento' WHERE idcountry = '22'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('22','4',{d '2003-11-20'},'''IMPORT''',null,null,'TN',null,null,'Trento')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '23')
UPDATE [geo_country] SET idregion = '5',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'VR',start = null,stop = null,title = 'Verona' WHERE idcountry = '23'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('23','5',{d '2003-11-20'},'''IMPORT''',null,null,'VR',null,null,'Verona')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '24')
UPDATE [geo_country] SET idregion = '5',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'VI',start = null,stop = null,title = 'Vicenza' WHERE idcountry = '24'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('24','5',{d '2003-11-20'},'''IMPORT''',null,null,'VI',null,null,'Vicenza')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '25')
UPDATE [geo_country] SET idregion = '5',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BL',start = null,stop = null,title = 'Belluno' WHERE idcountry = '25'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('25','5',{d '2003-11-20'},'''IMPORT''',null,null,'BL',null,null,'Belluno')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '26')
UPDATE [geo_country] SET idregion = '5',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'TV',start = null,stop = null,title = 'Treviso' WHERE idcountry = '26'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('26','5',{d '2003-11-20'},'''IMPORT''',null,null,'TV',null,null,'Treviso')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '27')
UPDATE [geo_country] SET idregion = '5',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'VE',start = null,stop = null,title = 'Venezia' WHERE idcountry = '27'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('27','5',{d '2003-11-20'},'''IMPORT''',null,null,'VE',null,null,'Venezia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '28')
UPDATE [geo_country] SET idregion = '5',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PD',start = null,stop = null,title = 'Padova' WHERE idcountry = '28'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('28','5',{d '2003-11-20'},'''IMPORT''',null,null,'PD',null,null,'Padova')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '29')
UPDATE [geo_country] SET idregion = '5',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'RO',start = null,stop = null,title = 'Rovigo' WHERE idcountry = '29'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('29','5',{d '2003-11-20'},'''IMPORT''',null,null,'RO',null,null,'Rovigo')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '30')
UPDATE [geo_country] SET idregion = '6',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'UD',start = null,stop = null,title = 'Udine' WHERE idcountry = '30'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('30','6',{d '2003-11-20'},'''IMPORT''',null,null,'UD',null,null,'Udine')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '31')
UPDATE [geo_country] SET idregion = '6',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'GO',start = null,stop = null,title = 'Gorizia' WHERE idcountry = '31'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('31','6',{d '2003-11-20'},'''IMPORT''',null,null,'GO',null,null,'Gorizia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '32')
UPDATE [geo_country] SET idregion = '6',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'TS',start = null,stop = null,title = 'Trieste' WHERE idcountry = '32'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('32','6',{d '2003-11-20'},'''IMPORT''',null,null,'TS',null,null,'Trieste')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '33')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PC',start = null,stop = null,title = 'Piacenza' WHERE idcountry = '33'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('33','8',{d '2003-11-20'},'''IMPORT''',null,null,'PC',null,null,'Piacenza')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '34')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PR',start = null,stop = null,title = 'Parma' WHERE idcountry = '34'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('34','8',{d '2003-11-20'},'''IMPORT''',null,null,'PR',null,null,'Parma')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '35')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'RE',start = null,stop = null,title = 'Reggio nell''Emilia' WHERE idcountry = '35'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('35','8',{d '2003-11-20'},'''IMPORT''',null,null,'RE',null,null,'Reggio nell''Emilia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '36')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'MO',start = null,stop = null,title = 'Modena' WHERE idcountry = '36'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('36','8',{d '2003-11-20'},'''IMPORT''',null,null,'MO',null,null,'Modena')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '37')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BO',start = null,stop = null,title = 'Bologna' WHERE idcountry = '37'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('37','8',{d '2003-11-20'},'''IMPORT''',null,null,'BO',null,null,'Bologna')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '38')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'FE',start = null,stop = null,title = 'Ferrara' WHERE idcountry = '38'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('38','8',{d '2003-11-20'},'''IMPORT''',null,null,'FE',null,null,'Ferrara')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '39')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'RA',start = null,stop = null,title = 'Ravenna' WHERE idcountry = '39'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('39','8',{d '2003-11-20'},'''IMPORT''',null,null,'RA',null,null,'Ravenna')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '40')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = '104',province = 'FC',start = {d '1992-04-16'},stop = null,title = 'Forlì-Cesena' WHERE idcountry = '40'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('40','8',{d '2003-11-20'},'''IMPORT''',null,'104','FC',{d '1992-04-16'},null,'Forlì-Cesena')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '41')
UPDATE [geo_country] SET idregion = '11',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PU',start = null,stop = null,title = 'Pesaro e Urbino' WHERE idcountry = '41'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('41','11',{d '2003-11-20'},'''IMPORT''',null,null,'PU',null,null,'Pesaro e Urbino')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '42')
UPDATE [geo_country] SET idregion = '11',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AN',start = null,stop = null,title = 'Ancona' WHERE idcountry = '42'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('42','11',{d '2003-11-20'},'''IMPORT''',null,null,'AN',null,null,'Ancona')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '43')
UPDATE [geo_country] SET idregion = '11',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'MC',start = null,stop = null,title = 'Macerata' WHERE idcountry = '43'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('43','11',{d '2003-11-20'},'''IMPORT''',null,null,'MC',null,null,'Macerata')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '44')
UPDATE [geo_country] SET idregion = '11',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AP',start = null,stop = null,title = 'Ascoli Piceno' WHERE idcountry = '44'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('44','11',{d '2003-11-20'},'''IMPORT''',null,null,'AP',null,null,'Ascoli Piceno')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '45')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'MS',start = null,stop = null,title = 'Massa-Carrara' WHERE idcountry = '45'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('45','9',{d '2003-11-20'},'''IMPORT''',null,null,'MS',null,null,'Massa-Carrara')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '46')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'LU',start = null,stop = null,title = 'Lucca' WHERE idcountry = '46'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('46','9',{d '2003-11-20'},'''IMPORT''',null,null,'LU',null,null,'Lucca')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '47')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PT',start = null,stop = null,title = 'Pistoia' WHERE idcountry = '47'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('47','9',{d '2003-11-20'},'''IMPORT''',null,null,'PT',null,null,'Pistoia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '48')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'FI',start = null,stop = null,title = 'Firenze' WHERE idcountry = '48'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('48','9',{d '2003-11-20'},'''IMPORT''',null,null,'FI',null,null,'Firenze')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '49')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'LI',start = null,stop = null,title = 'Livorno' WHERE idcountry = '49'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('49','9',{d '2003-11-20'},'''IMPORT''',null,null,'LI',null,null,'Livorno')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '50')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PI',start = null,stop = null,title = 'Pisa' WHERE idcountry = '50'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('50','9',{d '2003-11-20'},'''IMPORT''',null,null,'PI',null,null,'Pisa')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '51')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AR',start = null,stop = null,title = 'Arezzo' WHERE idcountry = '51'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('51','9',{d '2003-11-20'},'''IMPORT''',null,null,'AR',null,null,'Arezzo')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '52')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'SI',start = null,stop = null,title = 'Siena' WHERE idcountry = '52'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('52','9',{d '2003-11-20'},'''IMPORT''',null,null,'SI',null,null,'Siena')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '53')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'GR',start = null,stop = null,title = 'Grosseto' WHERE idcountry = '53'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('53','9',{d '2003-11-20'},'''IMPORT''',null,null,'GR',null,null,'Grosseto')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '54')
UPDATE [geo_country] SET idregion = '10',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PG',start = null,stop = null,title = 'Perugia' WHERE idcountry = '54'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('54','10',{d '2003-11-20'},'''IMPORT''',null,null,'PG',null,null,'Perugia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '55')
UPDATE [geo_country] SET idregion = '10',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'TR',start = null,stop = null,title = 'Terni' WHERE idcountry = '55'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('55','10',{d '2003-11-20'},'''IMPORT''',null,null,'TR',null,null,'Terni')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '56')
UPDATE [geo_country] SET idregion = '12',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'VT',start = null,stop = null,title = 'Viterbo' WHERE idcountry = '56'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('56','12',{d '2003-11-20'},'''IMPORT''',null,null,'VT',null,null,'Viterbo')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '57')
UPDATE [geo_country] SET idregion = '12',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'RI',start = null,stop = null,title = 'Rieti' WHERE idcountry = '57'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('57','12',{d '2003-11-20'},'''IMPORT''',null,null,'RI',null,null,'Rieti')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '58')
UPDATE [geo_country] SET idregion = '12',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'RM',start = null,stop = null,title = 'Roma' WHERE idcountry = '58'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('58','12',{d '2003-11-20'},'''IMPORT''',null,null,'RM',null,null,'Roma')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '59')
UPDATE [geo_country] SET idregion = '12',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'LT',start = null,stop = null,title = 'Latina' WHERE idcountry = '59'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('59','12',{d '2003-11-20'},'''IMPORT''',null,null,'LT',null,null,'Latina')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '60')
UPDATE [geo_country] SET idregion = '12',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'FR',start = null,stop = null,title = 'Frosinone' WHERE idcountry = '60'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('60','12',{d '2003-11-20'},'''IMPORT''',null,null,'FR',null,null,'Frosinone')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '61')
UPDATE [geo_country] SET idregion = '15',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CE',start = null,stop = null,title = 'Caserta' WHERE idcountry = '61'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('61','15',{d '2003-11-20'},'''IMPORT''',null,null,'CE',null,null,'Caserta')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '62')
UPDATE [geo_country] SET idregion = '15',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BN',start = null,stop = null,title = 'Benevento' WHERE idcountry = '62'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('62','15',{d '2003-11-20'},'''IMPORT''',null,null,'BN',null,null,'Benevento')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '63')
UPDATE [geo_country] SET idregion = '15',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'NA',start = null,stop = null,title = 'Napoli' WHERE idcountry = '63'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('63','15',{d '2003-11-20'},'''IMPORT''',null,null,'NA',null,null,'Napoli')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '64')
UPDATE [geo_country] SET idregion = '15',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AV',start = null,stop = null,title = 'Avellino' WHERE idcountry = '64'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('64','15',{d '2003-11-20'},'''IMPORT''',null,null,'AV',null,null,'Avellino')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '65')
UPDATE [geo_country] SET idregion = '15',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'SA',start = null,stop = null,title = 'Salerno' WHERE idcountry = '65'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('65','15',{d '2003-11-20'},'''IMPORT''',null,null,'SA',null,null,'Salerno')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '66')
UPDATE [geo_country] SET idregion = '13',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AQ',start = null,stop = null,title = 'L''Aquila' WHERE idcountry = '66'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('66','13',{d '2003-11-20'},'''IMPORT''',null,null,'AQ',null,null,'L''Aquila')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '67')
UPDATE [geo_country] SET idregion = '13',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'TE',start = null,stop = null,title = 'Teramo' WHERE idcountry = '67'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('67','13',{d '2003-11-20'},'''IMPORT''',null,null,'TE',null,null,'Teramo')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '68')
UPDATE [geo_country] SET idregion = '13',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PE',start = null,stop = null,title = 'Pescara' WHERE idcountry = '68'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('68','13',{d '2003-11-20'},'''IMPORT''',null,null,'PE',null,null,'Pescara')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '69')
UPDATE [geo_country] SET idregion = '13',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CH',start = null,stop = null,title = 'Chieti' WHERE idcountry = '69'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('69','13',{d '2003-11-20'},'''IMPORT''',null,null,'CH',null,null,'Chieti')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '70')
UPDATE [geo_country] SET idregion = '14',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CB',start = null,stop = null,title = 'Campobasso' WHERE idcountry = '70'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('70','14',{d '2003-11-20'},'''IMPORT''',null,null,'CB',null,null,'Campobasso')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '71')
UPDATE [geo_country] SET idregion = '16',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'FG',start = null,stop = null,title = 'Foggia' WHERE idcountry = '71'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('71','16',{d '2003-11-20'},'''IMPORT''',null,null,'FG',null,null,'Foggia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '72')
UPDATE [geo_country] SET idregion = '16',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BA',start = null,stop = null,title = 'Bari' WHERE idcountry = '72'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('72','16',{d '2003-11-20'},'''IMPORT''',null,null,'BA',null,null,'Bari')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '73')
UPDATE [geo_country] SET idregion = '16',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'TA',start = null,stop = null,title = 'Taranto' WHERE idcountry = '73'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('73','16',{d '2003-11-20'},'''IMPORT''',null,null,'TA',null,null,'Taranto')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '74')
UPDATE [geo_country] SET idregion = '16',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BR',start = null,stop = null,title = 'Brindisi' WHERE idcountry = '74'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('74','16',{d '2003-11-20'},'''IMPORT''',null,null,'BR',null,null,'Brindisi')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '75')
UPDATE [geo_country] SET idregion = '16',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'LE',start = null,stop = null,title = 'Lecce' WHERE idcountry = '75'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('75','16',{d '2003-11-20'},'''IMPORT''',null,null,'LE',null,null,'Lecce')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '76')
UPDATE [geo_country] SET idregion = '17',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PZ',start = null,stop = null,title = 'Potenza' WHERE idcountry = '76'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('76','17',{d '2003-11-20'},'''IMPORT''',null,null,'PZ',null,null,'Potenza')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '77')
UPDATE [geo_country] SET idregion = '17',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'MT',start = null,stop = null,title = 'Matera' WHERE idcountry = '77'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('77','17',{d '2003-11-20'},'''IMPORT''',null,null,'MT',null,null,'Matera')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '78')
UPDATE [geo_country] SET idregion = '18',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CS',start = null,stop = null,title = 'Cosenza' WHERE idcountry = '78'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('78','18',{d '2003-11-20'},'''IMPORT''',null,null,'CS',null,null,'Cosenza')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '79')
UPDATE [geo_country] SET idregion = '18',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CZ',start = null,stop = null,title = 'Catanzaro' WHERE idcountry = '79'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('79','18',{d '2003-11-20'},'''IMPORT''',null,null,'CZ',null,null,'Catanzaro')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '80')
UPDATE [geo_country] SET idregion = '18',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'RC',start = null,stop = null,title = 'Reggio di Calabria' WHERE idcountry = '80'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('80','18',{d '2003-11-20'},'''IMPORT''',null,null,'RC',null,null,'Reggio di Calabria')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '81')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'TP',start = null,stop = null,title = 'Trapani' WHERE idcountry = '81'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('81','19',{d '2003-11-20'},'''IMPORT''',null,null,'TP',null,null,'Trapani')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '82')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PA',start = null,stop = null,title = 'Palermo' WHERE idcountry = '82'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('82','19',{d '2003-11-20'},'''IMPORT''',null,null,'PA',null,null,'Palermo')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '83')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'ME',start = null,stop = null,title = 'Messina' WHERE idcountry = '83'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('83','19',{d '2003-11-20'},'''IMPORT''',null,null,'ME',null,null,'Messina')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '84')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'AG',start = null,stop = null,title = 'Agrigento' WHERE idcountry = '84'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('84','19',{d '2003-11-20'},'''IMPORT''',null,null,'AG',null,null,'Agrigento')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '85')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CL',start = null,stop = null,title = 'Caltanissetta' WHERE idcountry = '85'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('85','19',{d '2003-11-20'},'''IMPORT''',null,null,'CL',null,null,'Caltanissetta')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '86')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'EN',start = null,stop = null,title = 'Enna' WHERE idcountry = '86'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('86','19',{d '2003-11-20'},'''IMPORT''',null,null,'EN',null,null,'Enna')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '87')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CT',start = null,stop = null,title = 'Catania' WHERE idcountry = '87'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('87','19',{d '2003-11-20'},'''IMPORT''',null,null,'CT',null,null,'Catania')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '88')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'RG',start = null,stop = null,title = 'Ragusa' WHERE idcountry = '88'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('88','19',{d '2003-11-20'},'''IMPORT''',null,null,'RG',null,null,'Ragusa')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '89')
UPDATE [geo_country] SET idregion = '19',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'SR',start = null,stop = null,title = 'Siracusa' WHERE idcountry = '89'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('89','19',{d '2003-11-20'},'''IMPORT''',null,null,'SR',null,null,'Siracusa')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '90')
UPDATE [geo_country] SET idregion = '20',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'SS',start = null,stop = null,title = 'Sassari' WHERE idcountry = '90'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('90','20',{d '2003-11-20'},'''IMPORT''',null,null,'SS',null,null,'Sassari')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '91')
UPDATE [geo_country] SET idregion = '20',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'NU',start = null,stop = null,title = 'Nuoro' WHERE idcountry = '91'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('91','20',{d '2003-11-20'},'''IMPORT''',null,null,'NU',null,null,'Nuoro')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '92')
UPDATE [geo_country] SET idregion = '20',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'CA',start = null,stop = null,title = 'Cagliari' WHERE idcountry = '92'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('92','20',{d '2003-11-20'},'''IMPORT''',null,null,'CA',null,null,'Cagliari')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '93')
UPDATE [geo_country] SET idregion = '6',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PN',start = {d '1968-04-06'},stop = null,title = 'Pordenone' WHERE idcountry = '93'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('93','6',{d '2003-11-20'},'''IMPORT''',null,null,'PN',{d '1968-04-06'},null,'Pordenone')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '94')
UPDATE [geo_country] SET idregion = '14',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'IS',start = {d '1970-03-03'},stop = null,title = 'Isernia' WHERE idcountry = '94'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('94','14',{d '2003-11-20'},'''IMPORT''',null,null,'IS',{d '1970-03-03'},null,'Isernia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '95')
UPDATE [geo_country] SET idregion = '20',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'OR',start = {d '1974-08-20'},stop = null,title = 'Oristano' WHERE idcountry = '95'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('95','20',{d '2003-11-20'},'''IMPORT''',null,null,'OR',{d '1974-08-20'},null,'Oristano')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '96')
UPDATE [geo_country] SET idregion = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'BI',start = {d '1992-04-16'},stop = null,title = 'Biella' WHERE idcountry = '96'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('96','1',{d '2003-11-20'},'''IMPORT''',null,null,'BI',{d '1992-04-16'},null,'Biella')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '97')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'LC',start = {d '1992-04-16'},stop = null,title = 'Lecco' WHERE idcountry = '97'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('97','3',{d '2003-11-20'},'''IMPORT''',null,null,'LC',{d '1992-04-16'},null,'Lecco')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '98')
UPDATE [geo_country] SET idregion = '3',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'LO',start = {d '1992-04-16'},stop = null,title = 'Lodi' WHERE idcountry = '98'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('98','3',{d '2003-11-20'},'''IMPORT''',null,null,'LO',{d '1992-04-16'},null,'Lodi')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '99')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'RN',start = {d '1992-04-16'},stop = null,title = 'Rimini' WHERE idcountry = '99'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('99','8',{d '2003-11-20'},'''IMPORT''',null,null,'RN',{d '1992-04-16'},null,'Rimini')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '100')
UPDATE [geo_country] SET idregion = '9',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PO',start = {d '1992-04-16'},stop = null,title = 'Prato' WHERE idcountry = '100'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('100','9',{d '2003-11-20'},'''IMPORT''',null,null,'PO',{d '1992-04-16'},null,'Prato')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '101')
UPDATE [geo_country] SET idregion = '18',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'KR',start = {d '1992-04-16'},stop = null,title = 'Crotone' WHERE idcountry = '101'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('101','18',{d '2003-11-20'},'''IMPORT''',null,null,'KR',{d '1992-04-16'},null,'Crotone')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '102')
UPDATE [geo_country] SET idregion = '18',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'VV',start = {d '1992-04-16'},stop = null,title = 'Vibo Valentia' WHERE idcountry = '102'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('102','18',{d '2003-11-20'},'''IMPORT''',null,null,'VV',{d '1992-04-16'},null,'Vibo Valentia')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '103')
UPDATE [geo_country] SET idregion = '1',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'VB',start = {d '1992-05-23'},stop = null,title = 'Verbano-Cusio-Ossola' WHERE idcountry = '103'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('103','1',{d '2003-11-20'},'''IMPORT''',null,null,'VB',{d '1992-05-23'},null,'Verbano-Cusio-Ossola')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '104')
UPDATE [geo_country] SET idregion = '8',lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = '40',oldcountry = null,province = 'FO',start = null,stop = {d '1992-04-15'},title = 'Forlì' WHERE idcountry = '104'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('104','8',{d '2003-11-20'},'''IMPORT''','40',null,'FO',null,{d '1992-04-15'},'Forlì')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '105')
UPDATE [geo_country] SET idregion = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'ZA',start = null,stop = null,title = 'Zara' WHERE idcountry = '105'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('105',null,{d '2003-11-20'},'''IMPORT''',null,null,'ZA',null,null,'Zara')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '106')
UPDATE [geo_country] SET idregion = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'PL',start = null,stop = null,title = 'Pola' WHERE idcountry = '106'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('106',null,{d '2003-11-20'},'''IMPORT''',null,null,'PL',null,null,'Pola')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '107')
UPDATE [geo_country] SET idregion = null,lt = {d '2003-11-20'},lu = '''IMPORT''',newcountry = null,oldcountry = null,province = 'FM',start = null,stop = null,title = 'Fiume' WHERE idcountry = '107'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('107',null,{d '2003-11-20'},'''IMPORT''',null,null,'FM',null,null,'Fiume')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '108')
UPDATE [geo_country] SET idregion = '20',lt = {ts '2005-06-22 12:43:36.447'},lu = 'pino',newcountry = null,oldcountry = null,province = 'CI',start = {d '2005-01-01'},stop = null,title = 'Carbonia-Iglesias' WHERE idcountry = '108'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('108','20',{ts '2005-06-22 12:43:36.447'},'pino',null,null,'CI',{d '2005-01-01'},null,'Carbonia-Iglesias')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '109')
UPDATE [geo_country] SET idregion = '20',lt = {ts '2005-06-22 12:43:36.447'},lu = 'pino',newcountry = null,oldcountry = null,province = 'VS',start = {d '2005-01-01'},stop = null,title = 'Medio Campidano' WHERE idcountry = '109'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('109','20',{ts '2005-06-22 12:43:36.447'},'pino',null,null,'VS',{d '2005-01-01'},null,'Medio Campidano')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '110')
UPDATE [geo_country] SET idregion = '20',lt = {ts '2005-06-22 12:43:36.447'},lu = 'pino',newcountry = null,oldcountry = null,province = 'OG',start = {d '2005-01-01'},stop = null,title = 'Ogliastra' WHERE idcountry = '110'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('110','20',{ts '2005-06-22 12:43:36.447'},'pino',null,null,'OG',{d '2005-01-01'},null,'Ogliastra')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '111')
UPDATE [geo_country] SET idregion = '20',lt = {ts '2005-06-22 12:43:36.447'},lu = 'pino',newcountry = null,oldcountry = null,province = 'OT',start = {d '2005-01-01'},stop = null,title = 'Olbia-Tempio' WHERE idcountry = '111'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('111','20',{ts '2005-06-22 12:43:36.447'},'pino',null,null,'OT',{d '2005-01-01'},null,'Olbia-Tempio')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '112')
UPDATE [geo_country] SET idregion = '16',lt = {ts '2006-05-18 13:13:57.763'},lu = 'pino',newcountry = null,oldcountry = null,province = 'BT',start = {d '2006-01-01'},stop = null,title = 'Barletta-Andria-Trani' WHERE idcountry = '112'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('112','16',{ts '2006-05-18 13:13:57.763'},'pino',null,null,'BT',{d '2006-01-01'},null,'Barletta-Andria-Trani')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '113')
UPDATE [geo_country] SET idregion = '3',lt = {ts '2011-02-18 13:58:29.200'},lu = 'assistenza',newcountry = null,oldcountry = null,province = 'MB',start = null,stop = null,title = 'Monza e Brianza' WHERE idcountry = '113'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('113','3',{ts '2011-02-18 13:58:29.200'},'assistenza',null,null,'MB',null,null,'Monza e Brianza')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '115')
UPDATE [geo_country] SET idregion = '3',lt = {ts '2011-02-21 15:38:55.517'},lu = 'assistenza',newcountry = null,oldcountry = null,province = 'MB',start = null,stop = null,title = 'Monza e Brianza' WHERE idcountry = '115'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('115','3',{ts '2011-02-21 15:38:55.517'},'assistenza',null,null,'MB',null,null,'Monza e Brianza')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '116')
UPDATE [geo_country] SET idregion = '11',lt = {ts '2011-02-21 15:38:55.520'},lu = 'assistenza',newcountry = null,oldcountry = null,province = 'FM',start = null,stop = null,title = 'Fermo' WHERE idcountry = '116'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('116','11',{ts '2011-02-21 15:38:55.520'},'assistenza',null,null,'FM',null,null,'Fermo')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '117')
UPDATE [geo_country] SET idregion = null,lt = {ts '2019-03-05 09:59:06.833'},lu = 'nino_lu',newcountry = null,oldcountry = null,province = 'SM',start = null,stop = null,title = 'San Marino' WHERE idcountry = '117'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('117',null,{ts '2019-03-05 09:59:06.833'},'nino_lu',null,null,'SM',null,null,'San Marino')
GO

IF exists(SELECT * FROM [geo_country] WHERE idcountry = '118')
UPDATE [geo_country] SET idregion = '20',lt = {ts '2020-03-16 10:17:42.977'},lu = 'geo_2020',newcountry = null,oldcountry = null,province = 'SU',start = {d '2016-02-02'},stop = null,title = 'Provincia del Sud Sardegna' WHERE idcountry = '118'
ELSE
INSERT INTO [geo_country] (idcountry,idregion,lt,lu,newcountry,oldcountry,province,start,stop,title) VALUES ('118','20',{ts '2020-03-16 10:17:42.977'},'geo_2020',null,null,'SU',{d '2016-02-02'},null,'Provincia del Sud Sardegna')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'geo_country')
UPDATE [tabledescr] SET description = 'Province',idapplication = null,isdbo = 'S',lt = {ts '2016-04-21 18:33:03.430'},lu = 'nino',title = 'Province' WHERE tablename = 'geo_country'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('geo_country','Province',null,'S',{ts '2016-04-21 18:33:03.430'},'nino','Province')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcountry' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id paese (tabella geo_country)',kind = 'S',lt = {ts '1900-01-01 03:00:25.947'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcountry' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcountry','geo_country','4',null,null,'id paese (tabella geo_country)','S',{ts '1900-01-01 03:00:25.947'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregion' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id regione (tabella geo_region)',kind = 'S',lt = {ts '1900-01-01 03:00:26.337'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregion' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregion','geo_country','4',null,null,'id regione (tabella geo_region)','S',{ts '1900-01-01 03:00:26.337'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.900'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','geo_country','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.900'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.930'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','geo_country','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.930'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newcountry' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id nuova provincia in cui questa è confluita',kind = 'S',lt = {ts '2020-10-16 11:12:12.787'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'newcountry' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newcountry','geo_country','4',null,null,'id nuova provincia in cui questa è confluita','S',{ts '2020-10-16 11:12:12.787'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oldcountry' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id provincia da cui questa è confluita',kind = 'S',lt = {ts '2020-10-16 11:12:12.787'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oldcountry' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oldcountry','geo_country','4',null,null,'id provincia da cui questa è confluita','S',{ts '2020-10-16 11:12:12.787'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'province' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'sigla provincia',kind = 'S',lt = {ts '2016-10-07 17:18:59.617'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(2)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'province' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('province','geo_country','2',null,null,'sigla provincia','S',{ts '2016-10-07 17:18:59.617'},'nino','N','char(2)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data inizio',kind = 'S',lt = {ts '1900-01-01 02:59:54.100'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','geo_country','4',null,null,'data inizio','S',{ts '1900-01-01 02:59:54.100'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data fine',kind = 'S',lt = {ts '1900-01-01 02:59:54.607'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','geo_country','4',null,null,'data fine','S',{ts '1900-01-01 02:59:54.607'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'geo_country')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '1900-01-01 03:00:00.083'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'geo_country'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','geo_country','50',null,null,'Denominazione','S',{ts '1900-01-01 03:00:00.083'},'nino','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '896')
UPDATE [relation] SET childtable = 'geo_country',description = 'id regione (tabella geo_region)',lt = {ts '2017-05-20 09:19:52.853'},lu = 'lu',parenttable = 'geo_region',title = 'Province' WHERE idrelation = '896'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('896','geo_country','id regione (tabella geo_region)',{ts '2017-05-20 09:19:52.853'},'lu','geo_region','Province')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '896' AND parentcol = 'idregion')
UPDATE [relationcol] SET childcol = 'idregion',lt = {ts '2017-05-20 09:19:52.920'},lu = 'lu' WHERE idrelation = '896' AND parentcol = 'idregion'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('896','idregion','idregion',{ts '2017-05-20 09:19:52.920'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

