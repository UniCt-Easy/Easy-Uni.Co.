
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
lt datetime NULL,
lu varchar(64) NULL,
newnation int NULL,
oldnation int NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
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
	ALTER TABLE [geo_nation] ADD start smalldatetime NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN start smalldatetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD stop smalldatetime NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN stop smalldatetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD title varchar(65) NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN title varchar(65) NULL
GO


-- GENERAZIONE DATI PER geo_nation --
IF exists(SELECT * FROM [geo_nation] WHERE idnation = '1')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ITALIA' WHERE idnation = '1'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('1','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ITALIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '2')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ALBANIA' WHERE idnation = '2'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('2','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ALBANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '3')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ANDORRA' WHERE idnation = '3'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('3','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ANDORRA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '5')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'AUSTRIA' WHERE idnation = '5'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('5','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'AUSTRIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '7')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'BELGIO' WHERE idnation = '7'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('7','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'BELGIO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '8')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '60',start = {ts '1991-08-25 00:00:00.000'},stop = null,title = 'BIELORUSSIA=RUSSIA BIANCA' WHERE idnation = '8'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('8','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'60',{ts '1991-08-25 00:00:00.000'},null,'BIELORUSSIA=RUSSIA BIANCA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '9')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '29',start = {ts '1992-03-03 00:00:00.000'},stop = null,title = 'BOSNIA ED ERZEGOVINA' WHERE idnation = '9'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('9','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'29',{ts '1992-03-03 00:00:00.000'},null,'BOSNIA ED ERZEGOVINA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '10')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'BULGARIA' WHERE idnation = '10'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('10','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'BULGARIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '11')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '12',start = {ts '1993-01-01 00:00:00.000'},stop = null,title = 'CECA REPUBBLICA' WHERE idnation = '11'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('11','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'12',{ts '1993-01-01 00:00:00.000'},null,'CECA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '13')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CITTA'' DEL VATICANO' WHERE idnation = '13'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('13','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CITTA'' DEL VATICANO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '14')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '28',start = {ts '1991-10-08 00:00:00.000'},stop = null,title = 'CROAZIA' WHERE idnation = '14'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('14','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'28',{ts '1991-10-08 00:00:00.000'},null,'CROAZIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '15')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DANIMARCA' WHERE idnation = '15'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('15','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DANIMARCA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '16')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '64',start = {ts '1991-09-06 00:00:00.000'},stop = null,title = 'ESTONIA' WHERE idnation = '16'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('16','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'64',{ts '1991-09-06 00:00:00.000'},null,'ESTONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '17')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'FINLANDIA' WHERE idnation = '17'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('17','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'FINLANDIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '18')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'FRANCIA' WHERE idnation = '18'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('18','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'FRANCIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '20')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1990-10-03 00:00:00.000'},stop = null,title = 'GERMANIA' WHERE idnation = '20'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('20','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1990-10-03 00:00:00.000'},null,'GERMANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '23')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'REGNO UNITO DI GRAN BRETAGNA E IRLANDA DEL NORD' WHERE idnation = '23'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('23','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'REGNO UNITO DI GRAN BRETAGNA E IRLANDA DEL NORD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '24')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GRECIA' WHERE idnation = '24'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('24','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GRECIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '25')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'IRLANDA=EIRE' WHERE idnation = '25'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('25','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'IRLANDA=EIRE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '26')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ISLANDA' WHERE idnation = '26'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('26','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ISLANDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '33')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '64',start = {ts '1991-09-06 00:00:00.000'},stop = null,title = 'LETTONIA' WHERE idnation = '33'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('33','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'64',{ts '1991-09-06 00:00:00.000'},null,'LETTONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '34')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'LIECHTENSTEIN' WHERE idnation = '34'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('34','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'LIECHTENSTEIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '35')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '64',start = {ts '1991-09-06 00:00:00.000'},stop = null,title = 'LITUANIA' WHERE idnation = '35'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('35','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'64',{ts '1991-09-06 00:00:00.000'},null,'LITUANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '36')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'LUSSEMBURGO' WHERE idnation = '36'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('36','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'LUSSEMBURGO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '37')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '27',start = {ts '1991-09-15 00:00:00.000'},stop = null,title = 'MACEDONIA' WHERE idnation = '37'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('37','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'27',{ts '1991-09-15 00:00:00.000'},null,'MACEDONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '38')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MALTA' WHERE idnation = '38'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('38','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MALTA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '39')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '61',start = {ts '1991-08-27 00:00:00.000'},stop = null,title = 'MOLDAVIA' WHERE idnation = '39'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('39','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'61',{ts '1991-08-27 00:00:00.000'},null,'MOLDAVIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '40')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MONACO' WHERE idnation = '40'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('40','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MONACO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '41')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NORVEGIA' WHERE idnation = '41'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('41','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NORVEGIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '42')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'OLANDA (PAESI BASSI)' WHERE idnation = '42'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('42','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'OLANDA (PAESI BASSI)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '44')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PORTOGALLO' WHERE idnation = '44'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('44','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'PORTOGALLO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '45')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '43',start = {ts '1989-12-31 00:00:00.000'},stop = null,title = 'REPUBBLICA DI POLONIA' WHERE idnation = '45'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('45','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'43',{ts '1989-12-31 00:00:00.000'},null,'REPUBBLICA DI POLONIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '46')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ROMANIA' WHERE idnation = '46'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('46','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ROMANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '47')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '69',start = {ts '1992-03-31 00:00:00.000'},stop = null,title = 'RUSSIA=FEDERAZIONE RUSSA' WHERE idnation = '47'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('47','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'69',{ts '1992-03-31 00:00:00.000'},null,'RUSSIA=FEDERAZIONE RUSSA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '48')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SAN MARINO' WHERE idnation = '48'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('48','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SAN MARINO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '50')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '12',start = {ts '1993-01-01 00:00:00.000'},stop = null,title = 'SLOVACCHIA' WHERE idnation = '50'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('50','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'12',{ts '1993-01-01 00:00:00.000'},null,'SLOVACCHIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '51')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '28',start = {ts '1991-10-08 00:00:00.000'},stop = null,title = 'SLOVENIA' WHERE idnation = '51'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('51','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'28',{ts '1991-10-08 00:00:00.000'},null,'SLOVENIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '52')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SPAGNA' WHERE idnation = '52'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('52','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SPAGNA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '53')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SVEZIA' WHERE idnation = '53'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('53','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SVEZIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '54')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SVIZZERA' WHERE idnation = '54'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('54','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SVIZZERA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '57')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '59',start = {ts '1991-08-24 00:00:00.000'},stop = null,title = 'UCRAINA' WHERE idnation = '57'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('57','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'59',{ts '1991-08-24 00:00:00.000'},null,'UCRAINA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '58')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'UNGHERIA' WHERE idnation = '58'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('58','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'UNGHERIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '71')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'FAER OER (ISOLE)' WHERE idnation = '71'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('71','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'FAER OER (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '72')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GIBILTERRA' WHERE idnation = '72'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('72','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GIBILTERRA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '73')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MAN (ISOLA)' WHERE idnation = '73'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('73','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MAN (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '74')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NORMANNE (ISOLE)=ISOLE DEL CANALE' WHERE idnation = '74'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('74','1',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NORMANNE (ISOLE)=ISOLE DEL CANALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '75')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'AFGHANISTAN' WHERE idnation = '75'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('75','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'AFGHANISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '77')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ARABIA SAUDITA' WHERE idnation = '77'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('77','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ARABIA SAUDITA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '78')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '4',start = {ts '1994-01-01 00:00:00.000'},stop = null,title = 'ARMENIA' WHERE idnation = '78'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('78','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'4',{ts '1994-01-01 00:00:00.000'},null,'ARMENIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '79')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '6',start = {ts '1994-01-01 00:00:00.000'},stop = null,title = 'AZERBAIGIAN' WHERE idnation = '79'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('79','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'6',{ts '1994-01-01 00:00:00.000'},null,'AZERBAIGIAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '80')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '133',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'BAHREIN' WHERE idnation = '80'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('80','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'133',{ts '1975-12-31 00:00:00.000'},null,'BAHREIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '81')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'BANGLADESH' WHERE idnation = '81'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('81','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1975-12-31 00:00:00.000'},null,'BANGLADESH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '82')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'BHUTAN' WHERE idnation = '82'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('82','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1975-12-31 00:00:00.000'},null,'BHUTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '84')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '134',start = {ts '1984-12-31 00:00:00.000'},stop = null,title = 'BRUNEI' WHERE idnation = '84'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('84','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'134',{ts '1984-12-31 00:00:00.000'},null,'BRUNEI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '85')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CAMBOGIA' WHERE idnation = '85'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('85','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CAMBOGIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '87')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '136',start = null,stop = null,title = 'CINA REPUBBLICA POPOLARE' WHERE idnation = '87'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('87','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'136',null,null,'CINA REPUBBLICA POPOLARE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '88')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CIPRO' WHERE idnation = '88'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('88','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CIPRO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '89')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'COREA DEL NORD' WHERE idnation = '89'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('89','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'COREA DEL NORD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '90')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'COREA DEL SUD' WHERE idnation = '90'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('90','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'COREA DEL SUD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '91')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '135',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'EMIRATI ARABI UNITI' WHERE idnation = '91'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('91','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'135',{ts '1975-12-31 00:00:00.000'},null,'EMIRATI ARABI UNITI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '92')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'FILIPPINE' WHERE idnation = '92'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('92','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'FILIPPINE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '94')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '19',start = {ts '1994-01-01 00:00:00.000'},stop = null,title = 'GEORGIA' WHERE idnation = '94'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('94','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'19',{ts '1994-01-01 00:00:00.000'},null,'GEORGIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '95')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GIAPPONE' WHERE idnation = '95'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('95','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GIAPPONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '96')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GIORDANIA' WHERE idnation = '96'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('96','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GIORDANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '97')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '116',start = null,stop = null,title = 'INDIA' WHERE idnation = '97'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('97','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'116',null,null,'INDIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '98')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '139',start = null,stop = null,title = 'INDONESIA' WHERE idnation = '98'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('98','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'139',null,null,'INDONESIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '99')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'IRAN' WHERE idnation = '99'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('99','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'IRAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '100')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'IRAQ' WHERE idnation = '100'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('100','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'IRAQ')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '101')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ISRAELE' WHERE idnation = '101'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('101','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ISRAELE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '102')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '31',start = {ts '1994-01-01 00:00:00.000'},stop = null,title = 'KAZAKISTAN' WHERE idnation = '102'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('102','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'31',{ts '1994-01-01 00:00:00.000'},null,'KAZAKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '103')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '32',start = {ts '1994-01-01 00:00:00.000'},stop = null,title = 'KIRGHIZISTAN' WHERE idnation = '103'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('103','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'32',{ts '1994-01-01 00:00:00.000'},null,'KIRGHIZISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '104')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'KUWAIT' WHERE idnation = '104'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('104','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'KUWAIT')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '105')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'LAOS' WHERE idnation = '105'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('105','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'LAOS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '106')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'LIBANO' WHERE idnation = '106'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('106','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'LIBANO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '108')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '107',start = {ts '1966-10-01 00:00:00.000'},stop = null,title = 'MALAYSIA' WHERE idnation = '108'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('108','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'107',{ts '1966-10-01 00:00:00.000'},null,'MALAYSIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '109')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MALDIVE' WHERE idnation = '109'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('109','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MALDIVE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '110')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MONGOLIA' WHERE idnation = '110'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('110','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MONGOLIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '111')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NEPAL' WHERE idnation = '111'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('111','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NEPAL')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '112')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'OMAN' WHERE idnation = '112'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('112','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'OMAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '113')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PAKISTAN' WHERE idnation = '113'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('113','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'PAKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '114')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '137',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'QATAR' WHERE idnation = '114'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('114','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'137',{ts '1975-12-31 00:00:00.000'},null,'QATAR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '115')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '93',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'REPUBBLICA DELLA CINA NAZIONALE=TAIWAN' WHERE idnation = '115'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('115','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'93',{ts '1975-12-31 00:00:00.000'},null,'REPUBBLICA DELLA CINA NAZIONALE=TAIWAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '117')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '107',start = {ts '1966-10-01 00:00:00.000'},stop = null,title = 'SINGAPORE' WHERE idnation = '117'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('117','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'107',{ts '1966-10-01 00:00:00.000'},null,'SINGAPORE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '118')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SIRIA' WHERE idnation = '118'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('118','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SIRIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '119')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '86',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'SRI LANKA' WHERE idnation = '119'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('119','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'86',{ts '1975-12-31 00:00:00.000'},null,'SRI LANKA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '120')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '55',start = {ts '1994-01-01 00:00:00.000'},stop = null,title = 'TAGIKISTAN' WHERE idnation = '120'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('120','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'55',{ts '1994-01-01 00:00:00.000'},null,'TAGIKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '121')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'THAILANDIA' WHERE idnation = '121'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('121','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'THAILANDIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '122')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TURCHIA' WHERE idnation = '122'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('122','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'TURCHIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '123')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '56',start = {ts '1994-01-01 00:00:00.000'},stop = null,title = 'TURKEMENISTAN' WHERE idnation = '123'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('123','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'56',{ts '1994-01-01 00:00:00.000'},null,'TURKEMENISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '124')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '70',start = {ts '1994-01-01 00:00:00.000'},stop = null,title = 'UZBEKISTAN' WHERE idnation = '124'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('124','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'70',{ts '1994-01-01 00:00:00.000'},null,'UZBEKISTAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '125')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1977-12-31 00:00:00.000'},stop = null,title = 'VIETNAM' WHERE idnation = '125'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('125','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1977-12-31 00:00:00.000'},null,'VIETNAM')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '128')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '129',start = null,stop = null,title = 'YEMEN' WHERE idnation = '128'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('128','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'129',null,null,'YEMEN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '130')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'COCOS (ISOLE)' WHERE idnation = '130'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('130','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'COCOS (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '131')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GAZA (TERRITORIO DI)' WHERE idnation = '131'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('131','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GAZA (TERRITORIO DI)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '138')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MACAO' WHERE idnation = '138'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('138','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MACAO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '141')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ALGERIA' WHERE idnation = '141'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('141','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ALGERIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '142')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '229',start = {ts '1977-12-31 00:00:00.000'},stop = null,title = 'ANGOLA' WHERE idnation = '142'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('142','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'229',{ts '1977-12-31 00:00:00.000'},null,'ANGOLA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '143')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '162',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'BENIN' WHERE idnation = '143'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('143','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'162',{ts '1975-12-31 00:00:00.000'},null,'BENIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '145')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '222',start = {ts '1966-10-01 00:00:00.000'},stop = null,title = 'BOTSWANA' WHERE idnation = '145'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('145','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'222',{ts '1966-10-01 00:00:00.000'},null,'BOTSWANA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '146')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '208',start = {ts '1984-12-31 00:00:00.000'},stop = null,title = 'BURKINA' WHERE idnation = '146'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('146','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'208',{ts '1984-12-31 00:00:00.000'},null,'BURKINA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '147')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'BURUNDI' WHERE idnation = '147'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('147','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'BURUNDI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '148')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CAMERUN' WHERE idnation = '148'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('148','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CAMERUN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '149')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '230',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'CAPO VERDE' WHERE idnation = '149'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('149','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'230',{ts '1975-12-31 00:00:00.000'},null,'CAPO VERDE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '150')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '152',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'CENTRAFRICANA REPUBBLICA' WHERE idnation = '150'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('150','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'152',{ts '1980-12-31 00:00:00.000'},null,'CENTRAFRICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '153')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CIAD' WHERE idnation = '153'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('153','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CIAD')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '155')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = '218',oldnation = '156',start = {ts '1977-12-31 00:00:00.000'},stop = null,title = 'COMORE' WHERE idnation = '155'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('155','3',{ts '2003-11-20 00:00:00.000'},'Software and more','218','156',{ts '1977-12-31 00:00:00.000'},null,'COMORE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '159')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '209',start = {ts '1997-05-17 00:00:00.000'},stop = null,title = 'CONGO REPUBBLICA DEMOCRATICA' WHERE idnation = '159'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('159','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'209',{ts '1997-05-17 00:00:00.000'},null,'CONGO REPUBBLICA DEMOCRATICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '160')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '157',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'CONGO REPUBBLICA POPOLARE' WHERE idnation = '160'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('160','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'157',{ts '1975-12-31 00:00:00.000'},null,'CONGO REPUBBLICA POPOLARE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '161')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'COSTA D''AVORIO' WHERE idnation = '161'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('161','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'COSTA D''AVORIO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '163')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'EGITTO' WHERE idnation = '163'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('163','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'EGITTO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '164')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '165',start = {ts '1993-05-24 00:00:00.000'},stop = null,title = 'ERITREA' WHERE idnation = '164'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('164','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'165',{ts '1993-05-24 00:00:00.000'},null,'ERITREA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '166')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '165',start = {ts '1993-05-24 00:00:00.000'},stop = null,title = 'ETIOPIA' WHERE idnation = '166'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('166','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'165',{ts '1993-05-24 00:00:00.000'},null,'ETIOPIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '167')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GABON' WHERE idnation = '167'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('167','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GABON')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '168')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GAMBIA' WHERE idnation = '168'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('168','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GAMBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '169')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GHANA' WHERE idnation = '169'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('169','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GHANA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '170')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '220',start = {ts '1977-12-31 00:00:00.000'},stop = null,title = 'GIBUTI' WHERE idnation = '170'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('170','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'220',{ts '1977-12-31 00:00:00.000'},null,'GIBUTI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '171')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GUINEA' WHERE idnation = '171'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('171','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GUINEA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '172')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '231',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'GUINEA BISSAU' WHERE idnation = '172'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('172','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'231',{ts '1975-12-31 00:00:00.000'},null,'GUINEA BISSAU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '173')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '213',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'GUINEA EQUATORIALE' WHERE idnation = '173'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('173','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'213',{ts '1975-12-31 00:00:00.000'},null,'GUINEA EQUATORIALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '174')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'KENYA' WHERE idnation = '174'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('174','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'KENYA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '175')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '221',start = {ts '1966-10-01 00:00:00.000'},stop = null,title = 'LESOTHO' WHERE idnation = '175'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('175','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'221',{ts '1966-10-01 00:00:00.000'},null,'LESOTHO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '176')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'LIBERIA' WHERE idnation = '176'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('176','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'LIBERIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '177')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'LIBIA' WHERE idnation = '177'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('177','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'LIBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '178')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MADAGASCAR' WHERE idnation = '178'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('178','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MADAGASCAR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '179')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MALAWI' WHERE idnation = '179'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('179','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MALAWI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '180')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MALI' WHERE idnation = '180'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('180','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MALI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '181')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MAROCCO' WHERE idnation = '181'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('181','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MAROCCO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '182')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MAURITANIA' WHERE idnation = '182'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('182','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MAURITANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '183')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '223',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'MAURIZIO' WHERE idnation = '183'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('183','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'223',{ts '1975-12-31 00:00:00.000'},null,'MAURIZIO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '184')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '232',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'MOZAMBICO' WHERE idnation = '184'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('184','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'232',{ts '1975-12-31 00:00:00.000'},null,'MOZAMBICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '185')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '236',start = {ts '1978-12-31 00:00:00.000'},stop = null,title = 'NAMIBIA' WHERE idnation = '185'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('185','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'236',{ts '1978-12-31 00:00:00.000'},null,'NAMIBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '186')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NIGER' WHERE idnation = '186'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('186','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NIGER')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '187')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NIGERIA' WHERE idnation = '187'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('187','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NIGERIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '189')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'RUANDA' WHERE idnation = '189'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('189','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'RUANDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '190')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '233',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'SAO TOME'' E PRINCIPE' WHERE idnation = '190'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('190','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'233',{ts '1975-12-31 00:00:00.000'},null,'SAO TOME'' E PRINCIPE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '191')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = '218',oldnation = '225',start = {ts '1977-12-31 00:00:00.000'},stop = null,title = 'SEICELLE' WHERE idnation = '191'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('191','3',{ts '2003-11-20 00:00:00.000'},'Software and more','218','225',{ts '1977-12-31 00:00:00.000'},null,'SEICELLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '192')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SENEGAL' WHERE idnation = '192'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('192','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SENEGAL')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '193')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SIERRA LEONE' WHERE idnation = '193'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('193','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SIERRA LEONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '194')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SOMALIA' WHERE idnation = '194'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('194','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SOMALIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '198')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1984-12-31 00:00:00.000'},stop = null,title = 'SUDAFRICANA REPUBBLICA' WHERE idnation = '198'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('198','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1984-12-31 00:00:00.000'},null,'SUDAFRICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '199')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SUDAN' WHERE idnation = '199'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('199','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SUDAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '200')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '226',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'SWAZILAND' WHERE idnation = '200'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('200','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'226',{ts '1975-12-31 00:00:00.000'},null,'SWAZILAND')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '202')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1966-10-01 00:00:00.000'},stop = null,title = 'TANZANIA' WHERE idnation = '202'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('202','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1966-10-01 00:00:00.000'},null,'TANZANIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '203')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TOGO' WHERE idnation = '203'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('203','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'TOGO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '205')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TUNISIA' WHERE idnation = '205'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('205','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'TUNISIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '206')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'UGANDA' WHERE idnation = '206'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('206','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'UGANDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '210')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ZAMBIA' WHERE idnation = '210'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('210','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ZAMBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '212')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '188',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'ZIMBABWE' WHERE idnation = '212'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('212','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'188',{ts '1980-12-31 00:00:00.000'},null,'ZIMBABWE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '217')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'LA REUNION (ISOLA)' WHERE idnation = '217'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('217','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'LA REUNION (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '218')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1977-12-31 00:00:00.000'},stop = null,title = 'MAYOTTE (ISOLA)' WHERE idnation = '218'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('218','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1977-12-31 00:00:00.000'},null,'MAYOTTE (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '224')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SANT''ELENA (ISOLA)' WHERE idnation = '224'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('224','3',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SANT''ELENA (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '237')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CANADA' WHERE idnation = '237'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('237','4',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CANADA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '238')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'STATI UNITI D''AMERICA' WHERE idnation = '238'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('238','4',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'STATI UNITI D''AMERICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '239')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GROENLANDIA' WHERE idnation = '239'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('239','4',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GROENLANDIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '240')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SAINT PIERRE ET MIQUELON (ISOLE)' WHERE idnation = '240'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('240','4',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SAINT PIERRE ET MIQUELON (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '241')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'BERMUDA (ISOLE)' WHERE idnation = '241'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('241','4',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'BERMUDA (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '242')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '268',start = {ts '1984-12-31 00:00:00.000'},stop = null,title = 'ANTIGUA E BARBUDA' WHERE idnation = '242'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('242','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'268',{ts '1984-12-31 00:00:00.000'},null,'ANTIGUA E BARBUDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '243')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '269',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'BAHAMA' WHERE idnation = '243'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('243','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'269',{ts '1975-12-31 00:00:00.000'},null,'BAHAMA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '244')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '265',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'BARBADOS' WHERE idnation = '244'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('244','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'265',{ts '1975-12-31 00:00:00.000'},null,'BARBADOS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '245')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '270',start = {ts '1984-12-31 00:00:00.000'},stop = null,title = 'BELIZE' WHERE idnation = '245'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('245','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'270',{ts '1984-12-31 00:00:00.000'},null,'BELIZE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '246')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'COSTA RICA' WHERE idnation = '246'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('246','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'COSTA RICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '247')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CUBA' WHERE idnation = '247'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('247','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CUBA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '248')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '267',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'DOMINICA' WHERE idnation = '248'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('248','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'267',{ts '1980-12-31 00:00:00.000'},null,'DOMINICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '249')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DOMINICANA REPUBBLICA' WHERE idnation = '249'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('249','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DOMINICANA REPUBBLICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '250')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'EL SALVADOR' WHERE idnation = '250'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('250','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'EL SALVADOR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '251')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GIAMAICA' WHERE idnation = '251'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('251','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GIAMAICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '252')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '266',start = {ts '1977-12-31 00:00:00.000'},stop = null,title = 'GRENADA' WHERE idnation = '252'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('252','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'266',{ts '1977-12-31 00:00:00.000'},null,'GRENADA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '253')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GUATEMALA' WHERE idnation = '253'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('253','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GUATEMALA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '254')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'HAITI' WHERE idnation = '254'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('254','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'HAITI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '255')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'HONDURAS' WHERE idnation = '255'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('255','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'HONDURAS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '256')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MESSICO' WHERE idnation = '256'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('256','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MESSICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '257')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NICARAGUA' WHERE idnation = '257'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('257','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NICARAGUA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '258')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PANAMA''' WHERE idnation = '258'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('258','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'PANAMA''')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '259')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '268',start = {ts '1984-12-31 00:00:00.000'},stop = null,title = 'SAINT KITTS E NEVIS=SAINT CHRISTOPHER E NEVIS' WHERE idnation = '259'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('259','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'268',{ts '1984-12-31 00:00:00.000'},null,'SAINT KITTS E NEVIS=SAINT CHRISTOPHER E NEVIS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '260')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '267',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'SAINT LUCIA' WHERE idnation = '260'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('260','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'267',{ts '1980-12-31 00:00:00.000'},null,'SAINT LUCIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '261')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '267',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'SAINT VINCENT E GRENADINE' WHERE idnation = '261'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('261','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'267',{ts '1980-12-31 00:00:00.000'},null,'SAINT VINCENT E GRENADINE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '262')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GUADALUPA' WHERE idnation = '262'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('262','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GUADALUPA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '263')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MARTINICA' WHERE idnation = '263'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('263','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MARTINICA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '264')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '267',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'ANGUILLA (ISOLA)' WHERE idnation = '264'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('264','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'267',{ts '1980-12-31 00:00:00.000'},null,'ANGUILLA (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '271')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '267',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'CAYMAN (ISOLE)' WHERE idnation = '271'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('271','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'267',{ts '1980-12-31 00:00:00.000'},null,'CAYMAN (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '273')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '267',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'MONTSERRAT' WHERE idnation = '273'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('273','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'267',{ts '1980-12-31 00:00:00.000'},null,'MONTSERRAT')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '274')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TURKS E CAICOS (ISOLE)' WHERE idnation = '274'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('274','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'TURKS E CAICOS (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '275')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1978-12-31 00:00:00.000'},stop = null,title = 'VERGINI BRITANNICHE (ISOLE)' WHERE idnation = '275'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('275','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1978-12-31 00:00:00.000'},null,'VERGINI BRITANNICHE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '276')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ANTILLE OLANDESI' WHERE idnation = '276'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('276','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ANTILLE OLANDESI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '277')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '278',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'PANAMA ZONA DEL CANALE' WHERE idnation = '277'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('277','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'278',{ts '1980-12-31 00:00:00.000'},null,'PANAMA ZONA DEL CANALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '279')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PUERTO RICO' WHERE idnation = '279'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('279','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'PUERTO RICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '280')
UPDATE [geo_nation] SET idcontinent = '5',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'VERGINI AMERICANE (ISOLE)' WHERE idnation = '280'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('280','5',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'VERGINI AMERICANE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '281')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ARGENTINA' WHERE idnation = '281'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('281','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ARGENTINA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '282')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'BOLIVIA' WHERE idnation = '282'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('282','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'BOLIVIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '283')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'BRASILE' WHERE idnation = '283'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('283','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'BRASILE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '284')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CILE' WHERE idnation = '284'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('284','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CILE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '285')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'COLOMBIA' WHERE idnation = '285'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('285','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'COLOMBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '286')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ECUADOR' WHERE idnation = '286'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('286','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'ECUADOR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '287')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '295',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'GUYANA' WHERE idnation = '287'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('287','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'295',{ts '1975-12-31 00:00:00.000'},null,'GUYANA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '288')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PARAGUAY' WHERE idnation = '288'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('288','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'PARAGUAY')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '289')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PERU''' WHERE idnation = '289'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('289','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'PERU''')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '290')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '297',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'SURINAME' WHERE idnation = '290'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('290','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'297',{ts '1975-12-31 00:00:00.000'},null,'SURINAME')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '291')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TRINIDAD E TOBAGO' WHERE idnation = '291'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('291','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'TRINIDAD E TOBAGO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '292')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'URUGUAY' WHERE idnation = '292'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('292','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'URUGUAY')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '293')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'VENEZUELA' WHERE idnation = '293'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('293','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'VENEZUELA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '294')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GUAYANA=GUIANA FRANCESE' WHERE idnation = '294'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('294','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GUAYANA=GUIANA FRANCESE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '296')
UPDATE [geo_nation] SET idcontinent = '6',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MALVINE=FALKLAND (ISOLE)' WHERE idnation = '296'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('296','6',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MALVINE=FALKLAND (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '298')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'AUSTRALIA' WHERE idnation = '298'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('298','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'AUSTRALIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '299')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '321',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'FIGI=VITI' WHERE idnation = '299'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('299','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'321',{ts '1975-12-31 00:00:00.000'},null,'FIGI=VITI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '300')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '322',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'KIRIBATI' WHERE idnation = '300'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('300','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'322',{ts '1980-12-31 00:00:00.000'},null,'KIRIBATI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '301')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '338',start = {ts '1990-12-22 00:00:00.000'},stop = null,title = 'MARSHALL' WHERE idnation = '301'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('301','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'338',{ts '1990-12-22 00:00:00.000'},null,'MARSHALL')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '302')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '334',start = {ts '1990-12-22 00:00:00.000'},stop = null,title = 'MICRONESIA STATI FEDERATI' WHERE idnation = '302'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('302','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'334',{ts '1990-12-22 00:00:00.000'},null,'MICRONESIA STATI FEDERATI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '303')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '314',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'NAURU' WHERE idnation = '303'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('303','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'314',{ts '1975-12-31 00:00:00.000'},null,'NAURU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '304')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NUOVA ZELANDA' WHERE idnation = '304'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('304','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NUOVA ZELANDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '305')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '340',start = {ts '1997-01-01 00:00:00.000'},stop = null,title = 'PALAU' WHERE idnation = '305'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('305','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'340',{ts '1997-01-01 00:00:00.000'},null,'PALAU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '306')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'PAPUA NUOVA GUINEA' WHERE idnation = '306'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('306','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,{ts '1975-12-31 00:00:00.000'},null,'PAPUA NUOVA GUINEA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '307')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '324',start = {ts '1978-12-31 00:00:00.000'},stop = null,title = 'SALOMONE' WHERE idnation = '307'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('307','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'324',{ts '1978-12-31 00:00:00.000'},null,'SALOMONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '308')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SAMOA' WHERE idnation = '308'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('308','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SAMOA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '309')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '325',start = {ts '1975-12-31 00:00:00.000'},stop = null,title = 'TONGA=ISOLE DEGLI AMICI' WHERE idnation = '309'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('309','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'325',{ts '1975-12-31 00:00:00.000'},null,'TONGA=ISOLE DEGLI AMICI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '310')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '322',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'TUVALU' WHERE idnation = '310'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('310','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'322',{ts '1980-12-31 00:00:00.000'},null,'TUVALU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '311')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '326',start = {ts '1980-12-31 00:00:00.000'},stop = null,title = 'VANUATU' WHERE idnation = '311'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('311','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'326',{ts '1980-12-31 00:00:00.000'},null,'VANUATU')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '312')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CHRISTMAS (ISOLA)' WHERE idnation = '312'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('312','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'CHRISTMAS (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '313')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MACQUARIE (ISOLE)' WHERE idnation = '313'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('313','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MACQUARIE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '315')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NORFOLK (ISOLE E ISOLE DEL MAR DEI CORALLI)' WHERE idnation = '315'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('315','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NORFOLK (ISOLE E ISOLE DEL MAR DEI CORALLI)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '318')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NUOVA CALEDONIA (ISOLE E DIPENDENZE)' WHERE idnation = '318'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('318','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NUOVA CALEDONIA (ISOLE E DIPENDENZE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '319')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'POLINESIA FRANCESE (ISOLE)' WHERE idnation = '319'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('319','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'POLINESIA FRANCESE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '320')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'WALLIS E FUTUNA (ISOLE)' WHERE idnation = '320'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('320','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'WALLIS E FUTUNA (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '323')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PITCAIRN (E DIPENDENZE)' WHERE idnation = '323'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('323','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'PITCAIRN (E DIPENDENZE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '327')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'COOK (ISOLE)' WHERE idnation = '327'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('327','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'COOK (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '328')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'NIUE=SAVAGE (ISOLE)' WHERE idnation = '328'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('328','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'NIUE=SAVAGE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '329')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TOKELAU=ISOLE DELL''UNIONE' WHERE idnation = '329'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('329','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'TOKELAU=ISOLE DELL''UNIONE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '330')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '331',start = {ts '1984-12-31 00:00:00.000'},stop = null,title = 'ISOLE CILENE (PASQUA E SALA Y GOMEZ)' WHERE idnation = '330'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('330','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'331',{ts '1984-12-31 00:00:00.000'},null,'ISOLE CILENE (PASQUA E SALA Y GOMEZ)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '332')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'IRIAN OCCIDENTALE' WHERE idnation = '332'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('332','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'IRIAN OCCIDENTALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '335')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GUAM (ISOLA)' WHERE idnation = '335'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('335','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'GUAM (ISOLA)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '337')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MARIANNE (ISOLE)' WHERE idnation = '337'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('337','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MARIANNE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '339')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MIDWAY (ISOLE)' WHERE idnation = '339'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('339','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'MIDWAY (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '341')
UPDATE [geo_nation] SET idcontinent = '7',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SAMOA AMERICANE (ISOLE)' WHERE idnation = '341'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('341','7',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'SAMOA AMERICANE (ISOLE)')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '342')
UPDATE [geo_nation] SET idcontinent = '8',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE CANADESI' WHERE idnation = '342'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('342','8',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE CANADESI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '343')
UPDATE [geo_nation] SET idcontinent = '8',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE NORVEGESI ARTICHE' WHERE idnation = '343'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('343','8',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE NORVEGESI ARTICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '344')
UPDATE [geo_nation] SET idcontinent = '8',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = '345',start = {ts '1992-03-31 00:00:00.000'},stop = null,title = 'DIPENDENZE RUSSE' WHERE idnation = '344'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('344','8',{ts '2003-11-20 00:00:00.000'},'Software and more',null,'345',{ts '1992-03-31 00:00:00.000'},null,'DIPENDENZE RUSSE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '346')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE AUSTRALIANE' WHERE idnation = '346'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('346','9',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE AUSTRALIANE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '347')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE BRITANNICHE' WHERE idnation = '347'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('347','9',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE BRITANNICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '348')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE FRANCESI' WHERE idnation = '348'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('348','9',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE FRANCESI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '349')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE NEOZELANDESI' WHERE idnation = '349'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('349','9',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE NEOZELANDESI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '350')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE NORVEGESI ANTARTICHE' WHERE idnation = '350'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('350','9',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE NORVEGESI ANTARTICHE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '351')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE STATUNITENSI' WHERE idnation = '351'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('351','9',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE STATUNITENSI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '352')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DIPENDENZE SUDAFRICANE' WHERE idnation = '352'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('352','9',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'DIPENDENZE SUDAFRICANE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '353')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'Palestina' WHERE idnation = '353'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('353','2',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'Palestina')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '354')
UPDATE [geo_nation] SET idcontinent = '0',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'APOLIDE' WHERE idnation = '354'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('354','0',{ts '2003-11-20 00:00:00.000'},'Software and more',null,null,null,null,'APOLIDE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '355')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2003-11-20 00:00:00.000'},lu = 'Software and more',newnation = '83',oldnation = null,start = null,stop = null,title = 'BURMA' WHERE idnation = '355'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('355','2',{ts '2003-11-20 00:00:00.000'},'Software and more','83',null,null,null,'BURMA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '356')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2004-06-08 12:57:12.640'},lu = 'Software and more',newnation = null,oldnation = '83',start = {ts '1989-06-18 00:00:00.000'},stop = null,title = 'MYANMAR' WHERE idnation = '356'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('356','2',{ts '2004-06-08 12:57:12.640'},'Software and more',null,'83',{ts '1989-06-18 00:00:00.000'},null,'MYANMAR')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '357')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CANARIE ISOLE' WHERE idnation = '357'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('357',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'CANARIE ISOLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '358')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CAMPIONE D''ITALIA' WHERE idnation = '358'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('358','1',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'CAMPIONE D''ITALIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '359')
UPDATE [geo_nation] SET idcontinent = '3',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SAHARA OCCIDENTALE' WHERE idnation = '359'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('359','3',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'SAHARA OCCIDENTALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '360')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'WAKE ISOLE' WHERE idnation = '360'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('360',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'WAKE ISOLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '361')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TERRITORIO ANTARTICO BRITANNICO' WHERE idnation = '361'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('361','9',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'TERRITORIO ANTARTICO BRITANNICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '362')
UPDATE [geo_nation] SET idcontinent = '9',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TERRITORIO ANTARTICO FRANCESE' WHERE idnation = '362'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('362','9',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'TERRITORIO ANTARTICO FRANCESE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '363')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GUERNSEY C.I' WHERE idnation = '363'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('363',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'GUERNSEY C.I')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '364')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'JERSEY C.I.' WHERE idnation = '364'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('364','1',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'JERSEY C.I.')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '365')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ARUBA' WHERE idnation = '365'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('365','4',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'ARUBA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '366')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PORTORICO' WHERE idnation = '366'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('366','4',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'PORTORICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '367')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SAINT MARTIN SETTENTRIONALE' WHERE idnation = '367'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('367',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'SAINT MARTIN SETTENTRIONALE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '368')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CLIPPERTON' WHERE idnation = '368'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('368',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'CLIPPERTON')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '369')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ASCENSION' WHERE idnation = '369'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('369',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'ASCENSION')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '370')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'GOUGH' WHERE idnation = '370'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('370',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'GOUGH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '371')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TRISTAN DA CUNHA' WHERE idnation = '371'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('371',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'TRISTAN DA CUNHA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '372')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CHAFARINAS' WHERE idnation = '372'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('372',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'CHAFARINAS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '373')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MELILLA' WHERE idnation = '373'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('373',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'MELILLA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '374')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PENON DE ALHUCEMAS' WHERE idnation = '374'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('374',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'PENON DE ALHUCEMAS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '375')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PENON DE VELEZ DE LA GOMERA' WHERE idnation = '375'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('375',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'PENON DE VELEZ DE LA GOMERA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '376')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'AZZORRE ISOLE' WHERE idnation = '376'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('376',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'AZZORRE ISOLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '377')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'MADEIRA' WHERE idnation = '377'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('377',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'MADEIRA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '378')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ABU DHABI' WHERE idnation = '378'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('378',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'ABU DHABI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '379')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'AJMAN' WHERE idnation = '379'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('379',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'AJMAN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '380')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'DUBAI' WHERE idnation = '380'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('380',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'DUBAI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '381')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'FUIJAYRAH' WHERE idnation = '381'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('381',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'FUIJAYRAH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '382')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'RAS AL KHAIMAH' WHERE idnation = '382'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('382',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'RAS AL KHAIMAH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '383')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SHARJAH' WHERE idnation = '383'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('383',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'SHARJAH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '384')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'UMM AL QAIWAIN' WHERE idnation = '384'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('384',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'UMM AL QAIWAIN')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '385')
UPDATE [geo_nation] SET idcontinent = '2',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'TERRITORIO BRIT. OCEANO INDIANO' WHERE idnation = '385'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('385','2',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'TERRITORIO BRIT. OCEANO INDIANO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '386')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CEUTA' WHERE idnation = '386'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('386',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'CEUTA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '387')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SAINT-PIERRE E MIQUELON' WHERE idnation = '387'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('387','4',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'SAINT-PIERRE E MIQUELON')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '388')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ISOLE AMERICANE DEL PACIFICO' WHERE idnation = '388'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('388',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'ISOLE AMERICANE DEL PACIFICO')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '389')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'CHAGOS ISOLE' WHERE idnation = '389'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('389',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'CHAGOS ISOLE')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '390')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'BOUVET ISLAND' WHERE idnation = '390'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('390',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'BOUVET ISLAND')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '391')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SOUTH GEORGIA AND SOUTH SANDWICH' WHERE idnation = '391'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('391',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'SOUTH GEORGIA AND SOUTH SANDWICH')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '392')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'HEARD AND MCDONALD ISLAND' WHERE idnation = '392'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('392',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'HEARD AND MCDONALD ISLAND')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '393')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SVALBARD AND JAN MAYEN ISLANDS' WHERE idnation = '393'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('393','1',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'SVALBARD AND JAN MAYEN ISLANDS')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '394')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'ALDERNEY C.I' WHERE idnation = '394'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('394',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'ALDERNEY C.I')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '395')
UPDATE [geo_nation] SET idcontinent = '4',lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'BARBUDA' WHERE idnation = '395'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('395','4',{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'BARBUDA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '396')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'HERM C.I.' WHERE idnation = '396'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('396',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'HERM C.I.')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '397')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'SARK C.I.' WHERE idnation = '397'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('397',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'SARK C.I.')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '398')
UPDATE [geo_nation] SET idcontinent = null,lt = {ts '2004-06-08 14:27:55.060'},lu = 'Software and more',newnation = null,oldnation = null,start = null,stop = null,title = 'PAESI NON CLASSIFICATI' WHERE idnation = '398'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('398',null,{ts '2004-06-08 14:27:55.060'},'Software and more',null,null,null,null,'PAESI NON CLASSIFICATI')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '399')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2007-10-10 00:00:00.000'},lu = '''UPDATE''',newnation = null,oldnation = '49',start = {ts '2006-06-03 00:00:00.000'},stop = null,title = 'SERBIA' WHERE idnation = '399'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('399','1',{ts '2007-10-10 00:00:00.000'},'''UPDATE''',null,'49',{ts '2006-06-03 00:00:00.000'},null,'SERBIA')
GO

IF exists(SELECT * FROM [geo_nation] WHERE idnation = '400')
UPDATE [geo_nation] SET idcontinent = '1',lt = {ts '2007-10-10 00:00:00.000'},lu = '''UPDATE''',newnation = null,oldnation = '49',start = {ts '2007-06-03 00:00:00.000'},stop = null,title = 'MONTENEGRO' WHERE idnation = '400'
ELSE
INSERT INTO [geo_nation] (idnation,idcontinent,lt,lu,newnation,oldnation,start,stop,title) VALUES ('400','1',{ts '2007-10-10 00:00:00.000'},'''UPDATE''',null,'49',{ts '2007-06-03 00:00:00.000'},null,'MONTENEGRO')
GO

-- FINE GENERAZIONE SCRIPT --

