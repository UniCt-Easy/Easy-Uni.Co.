
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
-- CREAZIONE TABELLA sasd --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sasd] (
idsasd int NOT NULL,
codice varchar(50) NOT NULL,
codice_old varchar(4) NULL,
idareadidattica int NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(255) NOT NULL,
 CONSTRAINT xpksasd PRIMARY KEY (idsasd
)
)
END
GO

-- VERIFICA STRUTTURA sasd --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasd' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasd] ADD idsasd int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasd') and col.name = 'idsasd' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasd] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasd' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasd] ADD codice varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasd') and col.name = 'codice' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasd] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasd] ALTER COLUMN codice varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasd' and C.name = 'codice_old' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasd] ADD codice_old varchar(4) NULL 
END
ELSE
	ALTER TABLE [sasd] ALTER COLUMN codice_old varchar(4) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasd' and C.name = 'idareadidattica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasd] ADD idareadidattica int NULL 
END
ELSE
	ALTER TABLE [sasd] ALTER COLUMN idareadidattica int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasd' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasd] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [sasd] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasd' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasd] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [sasd] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasd' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasd] ADD title varchar(255) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasd') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasd] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasd] ALTER COLUMN title varchar(255) NOT NULL
GO

-- VERIFICA DI sasd IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sasd'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasd','int','ASSISTENZA','idsasd','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasd','varchar(50)','ASSISTENZA','codice','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasd','varchar(4)','ASSISTENZA','codice_old','4','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasd','int','ASSISTENZA','idareadidattica','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasd','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasd','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasd','varchar(255)','ASSISTENZA','title','255','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sasd IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sasd')
UPDATE customobject set isreal = 'S' where objectname = 'sasd'
ELSE
INSERT INTO customobject (objectname, isreal) values('sasd', 'S')
GO

-- GENERAZIONE DATI PER sasd --
IF exists(SELECT * FROM [sasd] WHERE idsasd = '1')
UPDATE [sasd] SET codice = 'CODI/02',codice_old = 'F090',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Chitarra' WHERE idsasd = '1'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('1','CODI/02','F090',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Chitarra')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '2')
UPDATE [sasd] SET codice = 'CODI/03',codice_old = 'F560',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Mandolino' WHERE idsasd = '2'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('2','CODI/03','F560',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Mandolino')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '3')
UPDATE [sasd] SET codice = 'CODI/04',codice_old = 'F130',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Contrabbasso' WHERE idsasd = '3'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('3','CODI/04','F130',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Contrabbasso')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '4')
UPDATE [sasd] SET codice = 'CODI/05',codice_old = 'F370',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Viola' WHERE idsasd = '4'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('4','CODI/05','F370',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Viola')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '5')
UPDATE [sasd] SET codice = 'CODI/06',codice_old = 'F390',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Violino' WHERE idsasd = '5'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('5','CODI/06','F390',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Violino')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '6')
UPDATE [sasd] SET codice = 'CODI/07',codice_old = 'F410',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Violoncello' WHERE idsasd = '6'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('6','CODI/07','F410',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Violoncello')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '7')
UPDATE [sasd] SET codice = 'CODI/08',codice_old = 'F460',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Basso tuba' WHERE idsasd = '7'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('7','CODI/08','F460',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Basso tuba')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '8')
UPDATE [sasd] SET codice = 'CODI/09',codice_old = 'F100',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Clarinetto' WHERE idsasd = '8'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('8','CODI/09','F100',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Clarinetto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '9')
UPDATE [sasd] SET codice = 'CODI/10',codice_old = 'F140',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'COrno' WHERE idsasd = '9'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('9','CODI/10','F140',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','COrno')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '10')
UPDATE [sasd] SET codice = 'CODI/11',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Eufonio' WHERE idsasd = '10'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('10','CODI/11',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Eufonio')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '11')
UPDATE [sasd] SET codice = 'CODI/12',codice_old = 'F180',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Fagotto' WHERE idsasd = '11'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('11','CODI/12','F180',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Fagotto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '12')
UPDATE [sasd] SET codice = 'CODI/13',codice_old = 'F190',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Flauto' WHERE idsasd = '12'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('12','CODI/13','F190',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Flauto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '13')
UPDATE [sasd] SET codice = 'CODI/14',codice_old = 'F280',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Oboe' WHERE idsasd = '13'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('13','CODI/14','F280',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Oboe')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '14')
UPDATE [sasd] SET codice = 'CODI/15',codice_old = 'F440',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Saxofono' WHERE idsasd = '14'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('14','CODI/15','F440',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Saxofono')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '15')
UPDATE [sasd] SET codice = 'CODI/16',codice_old = 'F360',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tromba' WHERE idsasd = '15'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('15','CODI/16','F360',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tromba')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '16')
UPDATE [sasd] SET codice = 'CODI/17',codice_old = 'F360',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Trombone' WHERE idsasd = '16'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('16','CODI/17','F360',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Trombone')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '17')
UPDATE [sasd] SET codice = 'CODI/18',codice_old = 'F520',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Fisarmonica' WHERE idsasd = '17'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('17','CODI/18','F520',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Fisarmonica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '18')
UPDATE [sasd] SET codice = 'CODI/19',codice_old = 'F290',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Organo' WHERE idsasd = '18'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('18','CODI/19','F290',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Organo')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '19')
UPDATE [sasd] SET codice = 'CODI/20',codice_old = 'F300',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pratica organistica e canto gregoriano' WHERE idsasd = '19'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('19','CODI/20','F300',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pratica organistica e canto gregoriano')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '20')
UPDATE [sasd] SET codice = 'CODI/21',codice_old = 'F310',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pianoforte' WHERE idsasd = '20'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('20','CODI/21','F310',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pianoforte')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '21')
UPDATE [sasd] SET codice = 'CODI/22',codice_old = 'F450',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Strumenti a percussione' WHERE idsasd = '21'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('21','CODI/22','F450',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Strumenti a percussione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '22')
UPDATE [sasd] SET codice = 'CODI/23',codice_old = 'F080',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Canto' WHERE idsasd = '22'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('22','CODI/23','F080',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Canto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '23')
UPDATE [sasd] SET codice = 'CODI/24',codice_old = 'F580',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musica vocale da camera' WHERE idsasd = '23'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('23','CODI/24','F580',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musica vocale da camera')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '24')
UPDATE [sasd] SET codice = 'CODI/25',codice_old = 'F010',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Accompagnamento pianistico' WHERE idsasd = '24'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('24','CODI/25','F010',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Accompagnamento pianistico')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '25')
UPDATE [sasd] SET codice = 'COMJ/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Basso elettrico' WHERE idsasd = '25'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('25','COMJ/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Basso elettrico')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '26')
UPDATE [sasd] SET codice = 'COMJ/02',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Chitarra jazz' WHERE idsasd = '26'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('26','COMJ/02','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Chitarra jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '27')
UPDATE [sasd] SET codice = 'COMJ/03',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Contrabbasso jazz' WHERE idsasd = '27'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('27','COMJ/03','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Contrabbasso jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '28')
UPDATE [sasd] SET codice = 'COMJ/04',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Violino jazz ' WHERE idsasd = '28'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('28','COMJ/04','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Violino jazz ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '29')
UPDATE [sasd] SET codice = 'COMJ/05',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Clarinetto jazz' WHERE idsasd = '29'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('29','COMJ/05','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Clarinetto jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '30')
UPDATE [sasd] SET codice = 'COMJ/06',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Saxofono jazz' WHERE idsasd = '30'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('30','COMJ/06','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Saxofono jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '31')
UPDATE [sasd] SET codice = 'COMJ/07',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tromba jazz' WHERE idsasd = '31'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('31','COMJ/07','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tromba jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '32')
UPDATE [sasd] SET codice = 'COMJ/08',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Trombone jazz' WHERE idsasd = '32'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('32','COMJ/08','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Trombone jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '33')
UPDATE [sasd] SET codice = 'COMJ/09',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pianoforte jazz' WHERE idsasd = '33'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('33','COMJ/09','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pianoforte jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '34')
UPDATE [sasd] SET codice = 'COMJ/10',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tastiere elettroniche' WHERE idsasd = '34'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('34','COMJ/10',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tastiere elettroniche')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '35')
UPDATE [sasd] SET codice = 'COMJ/11',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Batteria e percussioni jazz' WHERE idsasd = '35'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('35','COMJ/11','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Batteria e percussioni jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '36')
UPDATE [sasd] SET codice = 'COMJ/12',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Canto jazz' WHERE idsasd = '36'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('36','COMJ/12','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Canto jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '37')
UPDATE [sasd] SET codice = 'COMJ/13',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musiche tradizionali' WHERE idsasd = '37'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('37','COMJ/13',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musiche tradizionali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '38')
UPDATE [sasd] SET codice = 'COMA/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Arpa rinascimentale e barocca' WHERE idsasd = '38'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('38','COMA/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Arpa rinascimentale e barocca')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '39')
UPDATE [sasd] SET codice = 'COMA/02',codice_old = 'F550',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Liuto' WHERE idsasd = '39'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('39','COMA/02','F550',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Liuto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '40')
UPDATE [sasd] SET codice = 'COMA/03',codice_old = 'F600',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Viola da gamba' WHERE idsasd = '40'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('40','COMA/03','F600',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Viola da gamba')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '41')
UPDATE [sasd] SET codice = 'COMA/04',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Violino barocco' WHERE idsasd = '41'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('41','COMA/04',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Violino barocco')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '42')
UPDATE [sasd] SET codice = 'COMA/05',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Violoncello barocco' WHERE idsasd = '42'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('42','COMA/05',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Violoncello barocco')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '43')
UPDATE [sasd] SET codice = 'COMA/06',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Clarinetto storico' WHERE idsasd = '43'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('43','COMA/06',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Clarinetto storico')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '44')
UPDATE [sasd] SET codice = 'COMA/07',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Cornetto' WHERE idsasd = '44'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('44','COMA/07',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Cornetto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '45')
UPDATE [sasd] SET codice = 'COMA/08',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Corno naturale' WHERE idsasd = '45'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('45','COMA/08',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Corno naturale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '46')
UPDATE [sasd] SET codice = 'COMA/09',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Fagotto barocco e classico' WHERE idsasd = '46'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('46','COMA/09',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Fagotto barocco e classico')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '47')
UPDATE [sasd] SET codice = 'COMA/10',codice_old = 'F530',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Flauto dolce' WHERE idsasd = '47'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('47','COMA/10','F530',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Flauto dolce')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '48')
UPDATE [sasd] SET codice = 'COMA/11',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Oboe barocco e classico' WHERE idsasd = '48'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('48','COMA/11',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Oboe barocco e classico')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '49')
UPDATE [sasd] SET codice = 'COMA/12',codice_old = 'F530',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Flauto traversiere' WHERE idsasd = '49'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('49','COMA/12','F530',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Flauto traversiere')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '50')
UPDATE [sasd] SET codice = 'COMA/13',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tromba rinascimentale barocca' WHERE idsasd = '50'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('50','COMA/13',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tromba rinascimentale barocca')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '51')
UPDATE [sasd] SET codice = 'COMA/14',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Trombone rinascimentale e barocco' WHERE idsasd = '51'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('51','COMA/14',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Trombone rinascimentale e barocco')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '52')
UPDATE [sasd] SET codice = 'COMA/15',codice_old = 'F110',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Clavicembalo e tastiere storiche' WHERE idsasd = '52'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('52','COMA/15','F110',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Clavicembalo e tastiere storiche')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '53')
UPDATE [sasd] SET codice = 'COMA/16',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Canto rinascimentale barocco' WHERE idsasd = '53'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('53','COMA/16',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Canto rinascimentale barocco')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '54')
UPDATE [sasd] SET codice = 'COME/01',codice_old = 'F570',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Esecuzione e interpretazione della musica elettroacustica' WHERE idsasd = '54'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('54','COME/01','F570',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Esecuzione e interpretazione della musica elettroacustica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '55')
UPDATE [sasd] SET codice = 'COME/02',codice_old = 'F570',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Composizione musicale elettroacustica' WHERE idsasd = '55'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('55','COME/02','F570',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Composizione musicale elettroacustica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '56')
UPDATE [sasd] SET codice = 'COME/03',codice_old = 'F570',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Acustica musicale' WHERE idsasd = '56'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('56','COME/03','F570',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Acustica musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '57')
UPDATE [sasd] SET codice = 'COME/04',codice_old = 'F570',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Elettroacustica' WHERE idsasd = '57'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('57','COME/04','F570',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Elettroacustica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '58')
UPDATE [sasd] SET codice = 'COME/05',codice_old = 'F570',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Informatica musicale' WHERE idsasd = '58'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('58','COME/05','F570',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Informatica musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '59')
UPDATE [sasd] SET codice = 'COME/06',codice_old = 'F570',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Multimedialità' WHERE idsasd = '59'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('59','COME/06','F570',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Multimedialità')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '60')
UPDATE [sasd] SET codice = 'COMS/01',codice_old = 'F420',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musica sacra' WHERE idsasd = '60'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('60','COMS/01','F420',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musica sacra')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '61')
UPDATE [sasd] SET codice = 'COMI/01',codice_old = 'F160',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Esercitazioni corali' WHERE idsasd = '61'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('61','COMI/01','F160',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Esercitazioni corali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '62')
UPDATE [sasd] SET codice = 'COMI/02',codice_old = 'F170',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Esercitazione orchestrali' WHERE idsasd = '62'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('62','COMI/02','F170',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Esercitazione orchestrali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '63')
UPDATE [sasd] SET codice = 'COMI/03',codice_old = 'F240',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musica da camera' WHERE idsasd = '63'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('63','COMI/03','F240',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musica da camera')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '64')
UPDATE [sasd] SET codice = 'COMI/04',codice_old = 'F260',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musica d''insieme per strumenti a fiato' WHERE idsasd = '64'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('64','COMI/04','F260',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musica d''insieme per strumenti a fiato')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '65')
UPDATE [sasd] SET codice = 'COMI/05',codice_old = 'F250',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musica d''insieme per strumenti ad arco' WHERE idsasd = '65'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('65','COMI/05','F250',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musica d''insieme per strumenti ad arco')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '66')
UPDATE [sasd] SET codice = 'COMI/06',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musica d''insieme jazz' WHERE idsasd = '66'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('66','COMI/06','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musica d''insieme jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '67')
UPDATE [sasd] SET codice = 'COMI/07',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musica d''insieme per strumenti antichi' WHERE idsasd = '67'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('67','COMI/07',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musica d''insieme per strumenti antichi')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '68')
UPDATE [sasd] SET codice = 'COMI/08',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecnica di improvvisazione musicale' WHERE idsasd = '68'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('68','COMI/08',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecnica di improvvisazione musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '69')
UPDATE [sasd] SET codice = 'CORS/01',codice_old = 'F060',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria e tecnica dell''interpretazione scenica' WHERE idsasd = '69'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('69','CORS/01','F060',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria e tecnica dell''interpretazione scenica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '70')
UPDATE [sasd] SET codice = 'COID/01',codice_old = 'F230',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Direzione di coro e composizione corale ' WHERE idsasd = '70'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('70','COID/01','F230',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Direzione di coro e composizione corale ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '71')
UPDATE [sasd] SET codice = 'COID/02',codice_old = 'F150',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Direzione d''orchestra' WHERE idsasd = '71'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('71','COID/02','F150',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Direzione d''orchestra')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '72')
UPDATE [sasd] SET codice = 'COID/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Direzione d''orchestra di fiati' WHERE idsasd = '72'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('72','COID/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Direzione d''orchestra di fiati')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '73')
UPDATE [sasd] SET codice = 'CODC/01',codice_old = 'F030',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Composizione' WHERE idsasd = '73'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('73','CODC/01','F030',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Composizione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '74')
UPDATE [sasd] SET codice = 'CODC/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Composizione per la musica applicata alle immagini' WHERE idsasd = '74'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('74','CODC/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Composizione per la musica applicata alle immagini')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '75')
UPDATE [sasd] SET codice = 'CODC/03',codice_old = 'F120',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Composizione polifonica vocale' WHERE idsasd = '75'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('75','CODC/03','F120',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Composizione polifonica vocale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '76')
UPDATE [sasd] SET codice = 'CODC/04',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Composizione jazz' WHERE idsasd = '76'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('76','CODC/04','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Composizione jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '77')
UPDATE [sasd] SET codice = 'CODC/05',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Orchestrazione e concertazione jazz' WHERE idsasd = '77'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('77','CODC/05','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Orchestrazione e concertazione jazz')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '78')
UPDATE [sasd] SET codice = 'CODC/06',codice_old = 'F340',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Strumentazione e composizione per orchestra di fiati' WHERE idsasd = '78'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('78','CODC/06','F340',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Strumentazione e composizione per orchestra di fiati')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '79')
UPDATE [sasd] SET codice = 'CODM/01',codice_old = 'F070',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Bibliografia e Biblioteconomia musicale' WHERE idsasd = '79'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('79','CODM/01','F070',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Bibliografia e Biblioteconomia musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '80')
UPDATE [sasd] SET codice = 'CODM/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Etnomusicologia' WHERE idsasd = '80'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('80','CODM/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Etnomusicologia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '81')
UPDATE [sasd] SET codice = 'CODM/03',codice_old = 'F330',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musicologia sistematica' WHERE idsasd = '81'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('81','CODM/03','F330',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musicologia sistematica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '82')
UPDATE [sasd] SET codice = 'CODM/04',codice_old = 'F330',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia della musica' WHERE idsasd = '82'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('82','CODM/04','F330',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '83')
UPDATE [sasd] SET codice = 'CODM/05',codice_old = 'F570',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia della musica elettroacustica' WHERE idsasd = '83'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('83','CODM/05','F570',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia della musica elettroacustica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '84')
UPDATE [sasd] SET codice = 'CODM/06',codice_old = 'F540',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia del jazz, delle musiche improvvisate e audiotattili' WHERE idsasd = '84'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('84','CODM/06','F540',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia del jazz, delle musiche improvvisate e audiotattili')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '85')
UPDATE [sasd] SET codice = 'CODM/07',codice_old = 'F210',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Poesia per musica e drammaturgia musicale' WHERE idsasd = '85'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('85','CODM/07','F210',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Poesia per musica e drammaturgia musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '86')
UPDATE [sasd] SET codice = 'COTP/01',codice_old = 'F020',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria dell''armonia e analisi' WHERE idsasd = '86'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('86','COTP/01','F020',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria dell''armonia e analisi')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '87')
UPDATE [sasd] SET codice = 'COTP/02',codice_old = 'F220',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Lettura della partitura' WHERE idsasd = '87'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('87','COTP/02','F220',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Lettura della partitura')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '88')
UPDATE [sasd] SET codice = 'COTP/03',codice_old = 'F320',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pratica e lettura pianistica' WHERE idsasd = '88'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('88','COTP/03','F320',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pratica e lettura pianistica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '89')
UPDATE [sasd] SET codice = 'COTP/04',codice_old = 'F590',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Prepolifonia' WHERE idsasd = '89'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('89','COTP/04','F590',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Prepolifonia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '90')
UPDATE [sasd] SET codice = 'COTP/05',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria e prassi del basso continuo' WHERE idsasd = '90'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('90','COTP/05',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria e prassi del basso continuo')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '91')
UPDATE [sasd] SET codice = 'COTP/06',codice_old = 'F350',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria, ritmica e percezione musicale' WHERE idsasd = '91'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('91','COTP/06','F350',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria, ritmica e percezione musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '92')
UPDATE [sasd] SET codice = 'CODD/01',codice_old = 'F490',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Direzione di coro e repertorio corale per Didattica della musica' WHERE idsasd = '92'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('92','CODD/01','F490',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Direzione di coro e repertorio corale per Didattica della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '93')
UPDATE [sasd] SET codice = 'CODD/02',codice_old = 'F480',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Elementi di composizione per Didattica della musica' WHERE idsasd = '93'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('93','CODD/02','F480',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Elementi di composizione per Didattica della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '94')
UPDATE [sasd] SET codice = 'CODD/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Musica d''insieme per Didattica della musica' WHERE idsasd = '94'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('94','CODD/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Musica d''insieme per Didattica della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '95')
UPDATE [sasd] SET codice = 'CODD/04',codice_old = 'F470',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pedagogia musicale per Didattica della musica' WHERE idsasd = '95'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('95','CODD/04','F470',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pedagogia musicale per Didattica della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '96')
UPDATE [sasd] SET codice = 'CODD/05',codice_old = 'F510',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pratica della lettura vocale e pianistica per Didattica della musica' WHERE idsasd = '96'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('96','CODD/05','F510',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pratica della lettura vocale e pianistica per Didattica della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '97')
UPDATE [sasd] SET codice = 'CODD/06',codice_old = 'F500',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia della musica per Didattica della musica' WHERE idsasd = '97'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('97','CODD/06','F500',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia della musica per Didattica della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '98')
UPDATE [sasd] SET codice = 'CODD/07',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche di consapevolezza e di espressione corporea' WHERE idsasd = '98'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('98','CODD/07',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche di consapevolezza e di espressione corporea')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '99')
UPDATE [sasd] SET codice = 'CODL/01',codice_old = 'F200',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Lingua e letteratura italiana' WHERE idsasd = '99'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('99','CODL/01','F200',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Lingua e letteratura italiana')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '100')
UPDATE [sasd] SET codice = 'CODL/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Lingua straniera comunitaria' WHERE idsasd = '100'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('100','CODL/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Lingua straniera comunitaria')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '101')
UPDATE [sasd] SET codice = 'COCM/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Organizzazione, diritto e legislazione dello spettacolo musicale' WHERE idsasd = '101'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('101','COCM/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Organizzazione, diritto e legislazione dello spettacolo musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '102')
UPDATE [sasd] SET codice = 'COCM/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche della comunicazione' WHERE idsasd = '102'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('102','COCM/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche della comunicazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '103')
UPDATE [sasd] SET codice = 'ABAV1',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Anatomia artistica' WHERE idsasd = '103'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('103','ABAV1',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Anatomia artistica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '104')
UPDATE [sasd] SET codice = 'ABAV2',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche dell''Incisione - Grafica d''Arte' WHERE idsasd = '104'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('104','ABAV2',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche dell''Incisione - Grafica d''Arte')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '105')
UPDATE [sasd] SET codice = 'ABAV3',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Disegno' WHERE idsasd = '105'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('105','ABAV3',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Disegno')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '106')
UPDATE [sasd] SET codice = 'ABAV4',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche grafiche speciali' WHERE idsasd = '106'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('106','ABAV4',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche grafiche speciali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '107')
UPDATE [sasd] SET codice = 'ABAV5',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pittura' WHERE idsasd = '107'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('107','ABAV5',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pittura')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '108')
UPDATE [sasd] SET codice = 'ABAV6',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche per la pittura' WHERE idsasd = '108'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('108','ABAV6',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche per la pittura')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '109')
UPDATE [sasd] SET codice = 'ABAV7',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Scultura' WHERE idsasd = '109'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('109','ABAV7',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Scultura')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '110')
UPDATE [sasd] SET codice = 'ABAV8',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche per la scultura' WHERE idsasd = '110'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('110','ABAV8',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche per la scultura')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '111')
UPDATE [sasd] SET codice = 'ABAV9',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche del marmo e pietre dure' WHERE idsasd = '111'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('111','ABAV9',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche del marmo e pietre dure')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '112')
UPDATE [sasd] SET codice = 'ABAV10',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche di fonderia' WHERE idsasd = '112'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('112','ABAV10',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche di fonderia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '113')
UPDATE [sasd] SET codice = 'ABAV11',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Decorazione' WHERE idsasd = '113'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('113','ABAV11',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Decorazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '114')
UPDATE [sasd] SET codice = 'ABAV12',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche per la decorazione' WHERE idsasd = '114'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('114','ABAV12',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche per la decorazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '115')
UPDATE [sasd] SET codice = 'ABAV13',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Plastica ornamentale' WHERE idsasd = '115'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('115','ABAV13',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Plastica ornamentale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '116')
UPDATE [sasd] SET codice = 'ABPR14',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Elementi di architettura e urbanistica' WHERE idsasd = '116'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('116','ABPR14',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Elementi di architettura e urbanistica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '117')
UPDATE [sasd] SET codice = 'ABPR15',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Metodologia della progettazione ' WHERE idsasd = '117'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('117','ABPR15',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Metodologia della progettazione ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '118')
UPDATE [sasd] SET codice = 'ABPR16',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Disegno per la progettazione' WHERE idsasd = '118'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('118','ABPR16',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Disegno per la progettazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '119')
UPDATE [sasd] SET codice = 'ABPR17',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Design ' WHERE idsasd = '119'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('119','ABPR17',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Design ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '120')
UPDATE [sasd] SET codice = 'ABPR18',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Land design ' WHERE idsasd = '120'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('120','ABPR18',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Land design ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '121')
UPDATE [sasd] SET codice = 'ABPR19',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Graphic design' WHERE idsasd = '121'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('121','ABPR19',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Graphic design')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '122')
UPDATE [sasd] SET codice = 'ABPR20',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Arte del fumetto' WHERE idsasd = '122'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('122','ABPR20',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Arte del fumetto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '123')
UPDATE [sasd] SET codice = 'ABPR21',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Modellistica ' WHERE idsasd = '123'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('123','ABPR21',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Modellistica ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '124')
UPDATE [sasd] SET codice = 'ABPR22',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Scenografia' WHERE idsasd = '124'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('124','ABPR22',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Scenografia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '125')
UPDATE [sasd] SET codice = 'ABPR23',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Scenotecnica ' WHERE idsasd = '125'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('125','ABPR23',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Scenotecnica ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '126')
UPDATE [sasd] SET codice = 'ABPR24',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Restauro per la pittura' WHERE idsasd = '126'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('126','ABPR24',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Restauro per la pittura')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '127')
UPDATE [sasd] SET codice = 'ABPR25',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Restauro per la scultura' WHERE idsasd = '127'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('127','ABPR25',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Restauro per la scultura')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '128')
UPDATE [sasd] SET codice = 'ABPR26',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Restauro per la decorazione' WHERE idsasd = '128'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('128','ABPR26',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Restauro per la decorazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '129')
UPDATE [sasd] SET codice = 'ABPR27',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Restauro dei materiali cartacei ' WHERE idsasd = '129'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('129','ABPR27',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Restauro dei materiali cartacei ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '130')
UPDATE [sasd] SET codice = 'ABPR28',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Restauro dei supporti audiovisivi' WHERE idsasd = '130'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('130','ABPR28',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Restauro dei supporti audiovisivi')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '131')
UPDATE [sasd] SET codice = 'ABPR29',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Chimica e fisica per il restauro' WHERE idsasd = '131'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('131','ABPR29',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Chimica e fisica per il restauro')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '132')
UPDATE [sasd] SET codice = 'ABPR30',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecnologia dei materiali' WHERE idsasd = '132'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('132','ABPR30',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecnologia dei materiali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '133')
UPDATE [sasd] SET codice = 'ABPR31',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Fotografia' WHERE idsasd = '133'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('133','ABPR31',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Fotografia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '134')
UPDATE [sasd] SET codice = 'ABPR32',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Costume per lo spettacolo ' WHERE idsasd = '134'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('134','ABPR32',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Costume per lo spettacolo ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '135')
UPDATE [sasd] SET codice = 'ABPR33',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche applicate per la produzione teatrale' WHERE idsasd = '135'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('135','ABPR33',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche applicate per la produzione teatrale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '136')
UPDATE [sasd] SET codice = 'ABPR34',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Fashion design' WHERE idsasd = '136'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('136','ABPR34',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Fashion design')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '137')
UPDATE [sasd] SET codice = 'ABPR35',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Regia' WHERE idsasd = '137'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('137','ABPR35',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Regia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '138')
UPDATE [sasd] SET codice = 'ABPR36',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche performative per le arti visive' WHERE idsasd = '138'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('138','ABPR36',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche performative per le arti visive')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '139')
UPDATE [sasd] SET codice = 'ABPR72',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche della pittura per il restauro' WHERE idsasd = '139'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('139','ABPR72',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche della pittura per il restauro')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '140')
UPDATE [sasd] SET codice = 'ABPR73',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche della scultura per il restauro' WHERE idsasd = '140'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('140','ABPR73',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche della scultura per il restauro')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '141')
UPDATE [sasd] SET codice = 'ABPR74',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche di formatura e di fonderia per il restauro' WHERE idsasd = '141'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('141','ABPR74',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche di formatura e di fonderia per il restauro')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '142')
UPDATE [sasd] SET codice = 'ABPR75',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche della decorazione per il restauro' WHERE idsasd = '142'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('142','ABPR75',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche della decorazione per il restauro')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '143')
UPDATE [sasd] SET codice = 'ABPR76',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche e tecnologie grafiche per il restauro' WHERE idsasd = '143'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('143','ABPR76',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche e tecnologie grafiche per il restauro')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '144')
UPDATE [sasd] SET codice = 'ABTEC37',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Metodologia progettuale della comunicazione visiva' WHERE idsasd = '144'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('144','ABTEC37',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Metodologia progettuale della comunicazione visiva')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '145')
UPDATE [sasd] SET codice = 'ABTEC38',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Applicazioni digitali per le arti visive' WHERE idsasd = '145'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('145','ABTEC38',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Applicazioni digitali per le arti visive')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '146')
UPDATE [sasd] SET codice = 'ABTEC39',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecnologie per l’informatica' WHERE idsasd = '146'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('146','ABTEC39',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecnologie per l’informatica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '147')
UPDATE [sasd] SET codice = 'ABTEC40',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Progettazione multimediale' WHERE idsasd = '147'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('147','ABTEC40',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Progettazione multimediale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '148')
UPDATE [sasd] SET codice = 'ABTEC41',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche della modellazione digitale' WHERE idsasd = '148'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('148','ABTEC41',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche della modellazione digitale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '149')
UPDATE [sasd] SET codice = 'ABTEC42',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Sistemi interattivi' WHERE idsasd = '149'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('149','ABTEC42',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Sistemi interattivi')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '150')
UPDATE [sasd] SET codice = 'ABTEC43',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Linguaggi e tecniche dell’audiovisivo' WHERE idsasd = '150'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('150','ABTEC43',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Linguaggi e tecniche dell’audiovisivo')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '151')
UPDATE [sasd] SET codice = 'ABTEC44',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Sound design' WHERE idsasd = '151'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('151','ABTEC44',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Sound design')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '152')
UPDATE [sasd] SET codice = 'ABST45',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teorie delle arti multimediali' WHERE idsasd = '152'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('152','ABST45',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teorie delle arti multimediali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '153')
UPDATE [sasd] SET codice = 'ABST46',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Estetica' WHERE idsasd = '153'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('153','ABST46',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Estetica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '154')
UPDATE [sasd] SET codice = 'ABST47',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Stile, Storia dell’arte e del costume ' WHERE idsasd = '154'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('154','ABST47',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Stile, Storia dell’arte e del costume ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '155')
UPDATE [sasd] SET codice = 'ABST48',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia delle arti applicate' WHERE idsasd = '155'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('155','ABST48',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia delle arti applicate')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '156')
UPDATE [sasd] SET codice = 'ABST49',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria e storia del restauro' WHERE idsasd = '156'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('156','ABST49',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria e storia del restauro')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '157')
UPDATE [sasd] SET codice = 'ABST50',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia dell’architettura' WHERE idsasd = '157'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('157','ABST50',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia dell’architettura')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '158')
UPDATE [sasd] SET codice = 'ABST51',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Fenomenologia delle arti contemporanee' WHERE idsasd = '158'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('158','ABST51',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Fenomenologia delle arti contemporanee')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '159')
UPDATE [sasd] SET codice = 'ABST52',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia e metodologia della critica d’arte' WHERE idsasd = '159'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('159','ABST52',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia e metodologia della critica d’arte')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '160')
UPDATE [sasd] SET codice = 'ABST53',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia dello spettacolo' WHERE idsasd = '160'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('160','ABST53',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia dello spettacolo')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '161')
UPDATE [sasd] SET codice = 'ABST54',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia della musica' WHERE idsasd = '161'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('161','ABST54',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '162')
UPDATE [sasd] SET codice = 'ABST55',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Antropologia culturale' WHERE idsasd = '162'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('162','ABST55',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Antropologia culturale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '163')
UPDATE [sasd] SET codice = 'ABST56',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Discipline sociologiche' WHERE idsasd = '163'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('163','ABST56',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Discipline sociologiche')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '164')
UPDATE [sasd] SET codice = 'ABST57',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Fenomenologie del sacro ' WHERE idsasd = '164'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('164','ABST57',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Fenomenologie del sacro ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '165')
UPDATE [sasd] SET codice = 'ABST58',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria della percezione e psicologia della forma ' WHERE idsasd = '165'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('165','ABST58',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria della percezione e psicologia della forma ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '166')
UPDATE [sasd] SET codice = 'ABST59',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pedagogia e didattica dell''arte' WHERE idsasd = '166'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('166','ABST59',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pedagogia e didattica dell''arte')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '167')
UPDATE [sasd] SET codice = 'ABST60',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Metodi e tecniche dell''arte-terapia' WHERE idsasd = '167'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('167','ABST60',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Metodi e tecniche dell''arte-terapia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '168')
UPDATE [sasd] SET codice = 'ABVPA61',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Beni culturali e ambientali' WHERE idsasd = '168'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('168','ABVPA61',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Beni culturali e ambientali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '169')
UPDATE [sasd] SET codice = 'ABVPA62',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teorie e pratiche della valorizzazione dei beni culturali' WHERE idsasd = '169'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('169','ABVPA62',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teorie e pratiche della valorizzazione dei beni culturali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '170')
UPDATE [sasd] SET codice = 'ABVPA63',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Museologia' WHERE idsasd = '170'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('170','ABVPA63',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Museologia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '171')
UPDATE [sasd] SET codice = 'ABVPA64',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Museografia e progettazione di sistemi espositivi' WHERE idsasd = '171'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('171','ABVPA64',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Museografia e progettazione di sistemi espositivi')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '172')
UPDATE [sasd] SET codice = 'ABPC65',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria e metodo dei mass media ' WHERE idsasd = '172'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('172','ABPC65',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria e metodo dei mass media ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '173')
UPDATE [sasd] SET codice = 'ABPC66',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia dei nuovi media' WHERE idsasd = '173'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('173','ABPC66',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia dei nuovi media')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '174')
UPDATE [sasd] SET codice = 'ABPC67',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Metodologie e tecniche della comunicazione' WHERE idsasd = '174'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('174','ABPC67',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Metodologie e tecniche della comunicazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '175')
UPDATE [sasd] SET codice = 'ABPC68',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Analisi dei processi comunicativi ' WHERE idsasd = '175'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('175','ABPC68',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Analisi dei processi comunicativi ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '176')
UPDATE [sasd] SET codice = 'ABLE69',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Marketing e management' WHERE idsasd = '176'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('176','ABLE69',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Marketing e management')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '177')
UPDATE [sasd] SET codice = 'ABLE70',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Legislazione ed economia delle arti e dello spettacolo ' WHERE idsasd = '177'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('177','ABLE70',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Legislazione ed economia delle arti e dello spettacolo ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '178')
UPDATE [sasd] SET codice = 'ABLIN71',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Lingue' WHERE idsasd = '178'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('178','ABLIN71',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Lingue')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '179')
UPDATE [sasd] SET codice = 'ADTI/01',codice_old = 'N250',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecnica della danza classica' WHERE idsasd = '179'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('179','ADTI/01','N250',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecnica della danza classica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '180')
UPDATE [sasd] SET codice = 'ADTI/02',codice_old = 'N350',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Repertorio della danza classica' WHERE idsasd = '180'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('180','ADTI/02','N350',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Repertorio della danza classica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '181')
UPDATE [sasd] SET codice = 'ADTI/03',codice_old = 'N260',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecnica della danza moderna e contemporanea ' WHERE idsasd = '181'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('181','ADTI/03','N260',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecnica della danza moderna e contemporanea ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '182')
UPDATE [sasd] SET codice = 'ADTI/04',codice_old = 'N360',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Repertorio della danza moderna e contemporanea' WHERE idsasd = '182'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('182','ADTI/04','N360',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Repertorio della danza moderna e contemporanea')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '183')
UPDATE [sasd] SET codice = 'ADES/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Educativo della danza' WHERE idsasd = '183'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('183','ADES/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Educativo della danza')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '184')
UPDATE [sasd] SET codice = 'ADES/02',codice_old = 'N100',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Fisiotecnica della danza' WHERE idsasd = '184'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('184','ADES/02','N100',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Fisiotecnica della danza')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '185')
UPDATE [sasd] SET codice = 'ADES/03',codice_old = 'N020',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Anatomia e fisiologia del movimento' WHERE idsasd = '185'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('185','ADES/03','N020',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Anatomia e fisiologia del movimento')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '186')
UPDATE [sasd] SET codice = 'ADES/04',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Psicologico coreutico ' WHERE idsasd = '186'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('186','ADES/04',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Psicologico coreutico ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '187')
UPDATE [sasd] SET codice = 'ADTC/01',codice_old = 'N060',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Composizione della danza ' WHERE idsasd = '187'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('187','ADTC/01','N060',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Composizione della danza ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '188')
UPDATE [sasd] SET codice = 'ADTC/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Progettazione, allestimento e regia' WHERE idsasd = '188'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('188','ADTC/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Progettazione, allestimento e regia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '189')
UPDATE [sasd] SET codice = 'ADTC/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Arte coreutica e nuove tecnologie' WHERE idsasd = '189'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('189','ADTC/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Arte coreutica e nuove tecnologie')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '190')
UPDATE [sasd] SET codice = 'ADTS/01',codice_old = 'N170',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria, solfeggio e pratica musicale' WHERE idsasd = '190'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('190','ADTS/01','N170',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria, solfeggio e pratica musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '191')
UPDATE [sasd] SET codice = 'ADTS/02',codice_old = 'N270',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Teoria della danza' WHERE idsasd = '191'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('191','ADTS/02','N270',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Teoria della danza')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '192')
UPDATE [sasd] SET codice = 'ADTS/03',codice_old = 'N230',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = ' Storia della musica' WHERE idsasd = '192'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('192','ADTS/03','N230',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA',' Storia della musica')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '193')
UPDATE [sasd] SET codice = 'ADTS/04',codice_old = 'N210',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = ' Storia della danza' WHERE idsasd = '193'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('193','ADTS/04','N210',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA',' Storia della danza')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '194')
UPDATE [sasd] SET codice = 'ADTS/05',codice_old = 'N200',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = ' Storia dell’arte' WHERE idsasd = '194'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('194','ADTS/05','N200',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA',' Storia dell’arte')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '195')
UPDATE [sasd] SET codice = 'ADTS/06',codice_old = 'N180',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = ' Spazio scenico' WHERE idsasd = '195'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('195','ADTS/06','N180',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA',' Spazio scenico')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '196')
UPDATE [sasd] SET codice = 'ADTM/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Pratica musicale in ambito coreutico' WHERE idsasd = '196'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('196','ADTM/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Pratica musicale in ambito coreutico')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '197')
UPDATE [sasd] SET codice = 'ADTM/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Informatica musicale' WHERE idsasd = '197'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('197','ADTM/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Informatica musicale')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '198')
UPDATE [sasd] SET codice = 'ADEA/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Antropologia della danza' WHERE idsasd = '198'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('198','ADEA/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Antropologia della danza')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '199')
UPDATE [sasd] SET codice = 'ADEA/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Etnomusicologia' WHERE idsasd = '199'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('199','ADEA/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Etnomusicologia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '200')
UPDATE [sasd] SET codice = 'ADEA/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Repertori etnocoreutici' WHERE idsasd = '200'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('200','ADEA/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Repertori etnocoreutici')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '201')
UPDATE [sasd] SET codice = 'ADEA/04',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Sociologia della danza' WHERE idsasd = '201'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('201','ADEA/04',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Sociologia della danza')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '202')
UPDATE [sasd] SET codice = 'ADPP/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Psicologia e pedagogia' WHERE idsasd = '202'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('202','ADPP/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Psicologia e pedagogia')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '203')
UPDATE [sasd] SET codice = 'ADGE/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Legislazione e amministrazione' WHERE idsasd = '203'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('203','ADGE/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Legislazione e amministrazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '204')
UPDATE [sasd] SET codice = 'ADDC/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Lingue straniere' WHERE idsasd = '204'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('204','ADDC/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Lingue straniere')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '205')
UPDATE [sasd] SET codice = 'ADRFV 009',codice_old = 'N 16',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'ARTI MARZIALI' WHERE idsasd = '205'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('205','ADRFV 009','N 16',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','ARTI MARZIALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '206')
UPDATE [sasd] SET codice = 'ADRFV 013',codice_old = 'N 07',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'DANZA' WHERE idsasd = '206'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('206','ADRFV 013','N 07',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','DANZA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '207')
UPDATE [sasd] SET codice = 'ADRM 017',codice_old = 'N 05',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'CANTO' WHERE idsasd = '207'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('207','ADRM 017','N 05',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','CANTO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '208')
UPDATE [sasd] SET codice = 'ADRM 018 ',codice_old = 'N 01',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'ACCOMPAGNAMENTO E COLLABORAZIONE AL PIANOFORTE PER IL CANTO E LA DANZA' WHERE idsasd = '208'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('208','ADRM 018 ','N 01',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','ACCOMPAGNAMENTO E COLLABORAZIONE AL PIANOFORTE PER IL CANTO E LA DANZA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '209')
UPDATE [sasd] SET codice = 'ADRPRS 026',codice_old = 'N280',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'TRUCCO' WHERE idsasd = '209'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('209','ADRPRS 026','N280',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','TRUCCO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '210')
UPDATE [sasd] SET codice = 'ADRSMC 041',codice_old = 'N 03',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'STORIA E CRITICA DELLE ARTI VISIVE E DELL'' ARCHITETTURA' WHERE idsasd = '210'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('210','ADRSMC 041','N 03',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','STORIA E CRITICA DELLE ARTI VISIVE E DELL'' ARCHITETTURA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '211')
UPDATE [sasd] SET codice = 'ADREOS 034',codice_old = 'N 12',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'COMUNICAZIONE E PROMOZIONE' WHERE idsasd = '211'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('211','ADREOS 034','N 12',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','COMUNICAZIONE E PROMOZIONE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '212')
UPDATE [sasd] SET codice = 'ADRFV 011',codice_old = 'N 08',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'EDUCAZIONE ALLA VOCE' WHERE idsasd = '212'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('212','ADRFV 011','N 08',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','EDUCAZIONE ALLA VOCE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '213')
UPDATE [sasd] SET codice = 'ADRPL 014',codice_old = 'N 09',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'ESERCITAZIONE DI TECNICHE DI LETTURA' WHERE idsasd = '213'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('213','ADRPL 014','N 09',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','ESERCITAZIONE DI TECNICHE DI LETTURA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '214')
UPDATE [sasd] SET codice = 'ADRDS 029',codice_old = 'N 18',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'DRAMMATURGIA E ANALISI TESTUALE' WHERE idsasd = '214'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('214','ADRDS 029','N 18',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','DRAMMATURGIA E ANALISI TESTUALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '215')
UPDATE [sasd] SET codice = 'ADRSMC 040',codice_old = 'N 22',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'MUSICOLOGIA' WHERE idsasd = '215'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('215','ADRSMC 040','N 22',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','MUSICOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '216')
UPDATE [sasd] SET codice = 'ADRSMC 038',codice_old = 'N 24',idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'TEATROLOGIA' WHERE idsasd = '216'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('216','ADRSMC 038','N 24',null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','TEATROLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '217')
UPDATE [sasd] SET codice = 'ISDE/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Design del prodotto' WHERE idsasd = '217'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('217','ISDE/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Design del prodotto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '218')
UPDATE [sasd] SET codice = 'ISDE/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Design degli ambienti ' WHERE idsasd = '218'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('218','ISDE/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Design degli ambienti ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '219')
UPDATE [sasd] SET codice = 'ISDE/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Design dei sistemi ' WHERE idsasd = '219'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('219','ISDE/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Design dei sistemi ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '220')
UPDATE [sasd] SET codice = 'ISDE/04',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Ingegnerizzazione del prodotto' WHERE idsasd = '220'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('220','ISDE/04',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Ingegnerizzazione del prodotto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '221')
UPDATE [sasd] SET codice = 'ISDE/05',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Design della moda ' WHERE idsasd = '221'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('221','ISDE/05',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Design della moda ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '222')
UPDATE [sasd] SET codice = 'ISDC/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Scienze della comunicazione' WHERE idsasd = '222'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('222','ISDC/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Scienze della comunicazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '223')
UPDATE [sasd] SET codice = 'ISDC/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche e linguaggi della comunicazione ' WHERE idsasd = '223'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('223','ISDC/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche e linguaggi della comunicazione ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '224')
UPDATE [sasd] SET codice = 'ISDC/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Progettazione grafica dell’immagine ' WHERE idsasd = '224'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('224','ISDC/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Progettazione grafica dell’immagine ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '225')
UPDATE [sasd] SET codice = 'ISDC/04',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Progettazione multimediale ' WHERE idsasd = '225'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('225','ISDC/04',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Progettazione multimediale ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '226')
UPDATE [sasd] SET codice = 'ISDC/05',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Design della comunicazione ' WHERE idsasd = '226'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('226','ISDC/05',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Design della comunicazione ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '227')
UPDATE [sasd] SET codice = 'ISDC/06',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche di produzione grafica ' WHERE idsasd = '227'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('227','ISDC/06',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche di produzione grafica ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '228')
UPDATE [sasd] SET codice = 'ISDC/07',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche informatiche multimediali ' WHERE idsasd = '228'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('228','ISDC/07',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche informatiche multimediali ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '229')
UPDATE [sasd] SET codice = 'ISDC/08',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Comunicazione del progetto di moda ' WHERE idsasd = '229'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('229','ISDC/08',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Comunicazione del progetto di moda ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '230')
UPDATE [sasd] SET codice = 'ISME/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Metodologia della progettazione' WHERE idsasd = '230'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('230','ISME/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Metodologia della progettazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '231')
UPDATE [sasd] SET codice = 'ISME/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Basic design' WHERE idsasd = '231'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('231','ISME/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Basic design')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '232')
UPDATE [sasd] SET codice = 'ISME/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Scienze e linguaggi della percezione ' WHERE idsasd = '232'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('232','ISME/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Scienze e linguaggi della percezione ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '233')
UPDATE [sasd] SET codice = 'ISDR/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Analisi e rappresentazione della forma e del progetto' WHERE idsasd = '233'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('233','ISDR/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Analisi e rappresentazione della forma e del progetto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '234')
UPDATE [sasd] SET codice = 'ISDR/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Metodi e strumenti per la rappresentazione' WHERE idsasd = '234'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('234','ISDR/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Metodi e strumenti per la rappresentazione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '235')
UPDATE [sasd] SET codice = 'ISDR/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche di rappresentazione e comunicazione del progetto  ' WHERE idsasd = '235'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('235','ISDR/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche di rappresentazione e comunicazione del progetto  ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '236')
UPDATE [sasd] SET codice = 'ISDR/04',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecniche di rappresentazione del corpo' WHERE idsasd = '236'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('236','ISDR/04',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecniche di rappresentazione del corpo')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '237')
UPDATE [sasd] SET codice = 'ISSC/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia e cultura del design' WHERE idsasd = '237'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('237','ISSC/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia e cultura del design')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '238')
UPDATE [sasd] SET codice = 'ISSC/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia e cultura della comunicazione ' WHERE idsasd = '238'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('238','ISSC/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia e cultura della comunicazione ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '239')
UPDATE [sasd] SET codice = 'ISSC/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Storia del costume e della moda ' WHERE idsasd = '239'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('239','ISSC/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Storia del costume e della moda ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '240')
UPDATE [sasd] SET codice = 'ISST/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Scienze matematiche e fisiche ' WHERE idsasd = '240'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('240','ISST/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Scienze matematiche e fisiche ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '241')
UPDATE [sasd] SET codice = 'ISST/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Scienza e tecnologia dei materiali' WHERE idsasd = '241'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('241','ISST/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Scienza e tecnologia dei materiali')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '242')
UPDATE [sasd] SET codice = 'ISST/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecnologie della produzione' WHERE idsasd = '242'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('242','ISST/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecnologie della produzione')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '243')
UPDATE [sasd] SET codice = 'ISST/04',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Tecnologie del prodotto moda' WHERE idsasd = '243'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('243','ISST/04',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Tecnologie del prodotto moda')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '244')
UPDATE [sasd] SET codice = 'ISSU/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Sociologia e antropologia del design ' WHERE idsasd = '244'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('244','ISSU/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Sociologia e antropologia del design ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '245')
UPDATE [sasd] SET codice = 'ISSU/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Sociologia e antropologia della comunicazione ' WHERE idsasd = '245'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('245','ISSU/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Sociologia e antropologia della comunicazione ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '246')
UPDATE [sasd] SET codice = 'ISSU/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Psicologia per il design e la comunicazione ' WHERE idsasd = '246'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('246','ISSU/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Psicologia per il design e la comunicazione ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '247')
UPDATE [sasd] SET codice = 'ISSU/04',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Ergonomia ' WHERE idsasd = '247'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('247','ISSU/04',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Ergonomia ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '248')
UPDATE [sasd] SET codice = 'ISSU/05',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Sociologia antropologia e psicologia della moda' WHERE idsasd = '248'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('248','ISSU/05',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Sociologia antropologia e psicologia della moda')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '249')
UPDATE [sasd] SET codice = 'ISSE/01',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Economia e gestione delle imprese ' WHERE idsasd = '249'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('249','ISSE/01',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Economia e gestione delle imprese ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '250')
UPDATE [sasd] SET codice = 'ISSE/02',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Gestione dell’attività professionale ' WHERE idsasd = '250'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('250','ISSE/02',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Gestione dell’attività professionale ')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '251')
UPDATE [sasd] SET codice = 'ISSE/03',codice_old = null,idareadidattica = null,lt = {ts '2019-02-28 18:01:48.117'},lu = 'ASSISTENZA',title = 'Economia e marketing della moda' WHERE idsasd = '251'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('251','ISSE/03',null,null,{ts '2019-02-28 18:01:48.117'},'ASSISTENZA','Economia e marketing della moda')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '622')
UPDATE [sasd] SET codice = 'CODI/01',codice_old = 'F050',idareadidattica = null,lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',title = 'Arpa' WHERE idsasd = '622'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('622','CODI/01','F050',null,{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Arpa')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '623')
UPDATE [sasd] SET codice = '999999999999996',codice_old = '0',idareadidattica = null,lt = {ts '2019-11-08 09:33:14.867'},lu = 'ASSISTENZA',title = 'Settore ante D.M 26 febbraio 1999 - Rideterminazione settori scientifico-disciplinari' WHERE idsasd = '623'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('623','999999999999996','0',null,{ts '2019-11-08 09:33:14.867'},'ASSISTENZA','Settore ante D.M 26 febbraio 1999 - Rideterminazione settori scientifico-disciplinari')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '624')
UPDATE [sasd] SET codice = '999999999999997',codice_old = null,idareadidattica = null,lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'Conoscenze linguistiche' WHERE idsasd = '624'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('624','999999999999997',null,null,{d '2019-02-28'},'ASSISTENZA','Conoscenze linguistiche')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '625')
UPDATE [sasd] SET codice = '999999999999998',codice_old = null,idareadidattica = null,lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'Non previsto' WHERE idsasd = '625'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('625','999999999999998',null,null,{d '2019-02-28'},'ASSISTENZA','Non previsto')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '626')
UPDATE [sasd] SET codice = '999999999999999',codice_old = null,idareadidattica = null,lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'Non disponibile' WHERE idsasd = '626'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('626','999999999999999',null,null,{d '2019-02-28'},'ASSISTENZA','Non disponibile')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '627')
UPDATE [sasd] SET codice = 'AGR/01',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ECONOMIA ED ESTIMO RURALE' WHERE idsasd = '627'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('627','AGR/01',null,'11',{d '2019-02-28'},'ASSISTENZA','ECONOMIA ED ESTIMO RURALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '628')
UPDATE [sasd] SET codice = 'AGR/02',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'AGRONOMIA E COLTIVAZIONI ERBACEE' WHERE idsasd = '628'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('628','AGR/02',null,'11',{d '2019-02-28'},'ASSISTENZA','AGRONOMIA E COLTIVAZIONI ERBACEE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '629')
UPDATE [sasd] SET codice = 'AGR/03',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARBORICOLTURA GENERALE E COLTIVAZIONI ARBOREE' WHERE idsasd = '629'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('629','AGR/03',null,'11',{d '2019-02-28'},'ASSISTENZA','ARBORICOLTURA GENERALE E COLTIVAZIONI ARBOREE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '630')
UPDATE [sasd] SET codice = 'AGR/04',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ORTICOLTURA E FLORICOLTURA' WHERE idsasd = '630'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('630','AGR/04',null,'11',{d '2019-02-28'},'ASSISTENZA','ORTICOLTURA E FLORICOLTURA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '631')
UPDATE [sasd] SET codice = 'AGR/05',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ASSESTAMENTO FORESTALE E SELVICOLTURA' WHERE idsasd = '631'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('631','AGR/05',null,'11',{d '2019-02-28'},'ASSISTENZA','ASSESTAMENTO FORESTALE E SELVICOLTURA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '632')
UPDATE [sasd] SET codice = 'AGR/06',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TECNOLOGIA DEL LEGNO E UTILIZZAZIONI FORESTALI' WHERE idsasd = '632'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('632','AGR/06',null,'11',{d '2019-02-28'},'ASSISTENZA','TECNOLOGIA DEL LEGNO E UTILIZZAZIONI FORESTALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '633')
UPDATE [sasd] SET codice = 'AGR/07',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GENETICA AGRARIA' WHERE idsasd = '633'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('633','AGR/07',null,'11',{d '2019-02-28'},'ASSISTENZA','GENETICA AGRARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '634')
UPDATE [sasd] SET codice = 'AGR/08',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'IDRAULICA AGRARIA E SISTEMAZIONI IDRAULICO-FORESTALI' WHERE idsasd = '634'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('634','AGR/08',null,'11',{d '2019-02-28'},'ASSISTENZA','IDRAULICA AGRARIA E SISTEMAZIONI IDRAULICO-FORESTALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '635')
UPDATE [sasd] SET codice = 'AGR/09',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MECCANICA AGRARIA' WHERE idsasd = '635'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('635','AGR/09',null,'11',{d '2019-02-28'},'ASSISTENZA','MECCANICA AGRARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '636')
UPDATE [sasd] SET codice = 'AGR/10',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'COSTRUZIONI RURALI E TERRITORIO AGROFORESTALE' WHERE idsasd = '636'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('636','AGR/10',null,'11',{d '2019-02-28'},'ASSISTENZA','COSTRUZIONI RURALI E TERRITORIO AGROFORESTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '637')
UPDATE [sasd] SET codice = 'AGR/11',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ENTOMOLOGIA GENERALE E APPLICATA' WHERE idsasd = '637'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('637','AGR/11',null,'11',{d '2019-02-28'},'ASSISTENZA','ENTOMOLOGIA GENERALE E APPLICATA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '638')
UPDATE [sasd] SET codice = 'AGR/12',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PATOLOGIA VEGETALE' WHERE idsasd = '638'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('638','AGR/12',null,'11',{d '2019-02-28'},'ASSISTENZA','PATOLOGIA VEGETALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '639')
UPDATE [sasd] SET codice = 'AGR/13',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA AGRARIA' WHERE idsasd = '639'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('639','AGR/13',null,'11',{d '2019-02-28'},'ASSISTENZA','CHIMICA AGRARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '640')
UPDATE [sasd] SET codice = 'AGR/14',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PEDOLOGIA' WHERE idsasd = '640'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('640','AGR/14',null,'11',{d '2019-02-28'},'ASSISTENZA','PEDOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '641')
UPDATE [sasd] SET codice = 'AGR/15',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZE E TECNOLOGIE ALIMENTARI' WHERE idsasd = '641'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('641','AGR/15',null,'11',{d '2019-02-28'},'ASSISTENZA','SCIENZE E TECNOLOGIE ALIMENTARI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '642')
UPDATE [sasd] SET codice = 'AGR/16',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MICROBIOLOGIA AGRARIA' WHERE idsasd = '642'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('642','AGR/16',null,'11',{d '2019-02-28'},'ASSISTENZA','MICROBIOLOGIA AGRARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '643')
UPDATE [sasd] SET codice = 'AGR/17',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ZOOTECNICA GENERALE E MIGLIORAMENTO GENETICO' WHERE idsasd = '643'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('643','AGR/17',null,'11',{d '2019-02-28'},'ASSISTENZA','ZOOTECNICA GENERALE E MIGLIORAMENTO GENETICO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '644')
UPDATE [sasd] SET codice = 'AGR/18',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'NUTRIZIONE E ALIMENTAZIONE ANIMALE' WHERE idsasd = '644'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('644','AGR/18',null,'11',{d '2019-02-28'},'ASSISTENZA','NUTRIZIONE E ALIMENTAZIONE ANIMALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '645')
UPDATE [sasd] SET codice = 'AGR/19',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ZOOTECNICA SPECIALE' WHERE idsasd = '645'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('645','AGR/19',null,'11',{d '2019-02-28'},'ASSISTENZA','ZOOTECNICA SPECIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '646')
UPDATE [sasd] SET codice = 'AGR/20',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ZOOCOLTURE' WHERE idsasd = '646'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('646','AGR/20',null,'11',{d '2019-02-28'},'ASSISTENZA','ZOOCOLTURE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '647')
UPDATE [sasd] SET codice = 'BIO/01',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BOTANICA GENERALE' WHERE idsasd = '647'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('647','BIO/01',null,'9',{d '2019-02-28'},'ASSISTENZA','BOTANICA GENERALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '648')
UPDATE [sasd] SET codice = 'BIO/02',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BOTANICA SISTEMATICA' WHERE idsasd = '648'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('648','BIO/02',null,'9',{d '2019-02-28'},'ASSISTENZA','BOTANICA SISTEMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '649')
UPDATE [sasd] SET codice = 'BIO/03',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BOTANICA AMBIENTALE E APPLICATA' WHERE idsasd = '649'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('649','BIO/03',null,'9',{d '2019-02-28'},'ASSISTENZA','BOTANICA AMBIENTALE E APPLICATA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '650')
UPDATE [sasd] SET codice = 'BIO/04',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISIOLOGIA VEGETALE' WHERE idsasd = '650'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('650','BIO/04',null,'9',{d '2019-02-28'},'ASSISTENZA','FISIOLOGIA VEGETALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '651')
UPDATE [sasd] SET codice = 'BIO/05',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ZOOLOGIA' WHERE idsasd = '651'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('651','BIO/05',null,'9',{d '2019-02-28'},'ASSISTENZA','ZOOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '652')
UPDATE [sasd] SET codice = 'BIO/06',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANATOMIA COMPARATA E CITOLOGIA' WHERE idsasd = '652'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('652','BIO/06',null,'9',{d '2019-02-28'},'ASSISTENZA','ANATOMIA COMPARATA E CITOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '653')
UPDATE [sasd] SET codice = 'BIO/07',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ECOLOGIA' WHERE idsasd = '653'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('653','BIO/07',null,'9',{d '2019-02-28'},'ASSISTENZA','ECOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '654')
UPDATE [sasd] SET codice = 'BIO/08',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANTROPOLOGIA' WHERE idsasd = '654'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('654','BIO/08',null,'9',{d '2019-02-28'},'ASSISTENZA','ANTROPOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '655')
UPDATE [sasd] SET codice = 'BIO/09',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISIOLOGIA' WHERE idsasd = '655'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('655','BIO/09',null,'9',{d '2019-02-28'},'ASSISTENZA','FISIOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '656')
UPDATE [sasd] SET codice = 'BIO/10',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BIOCHIMICA' WHERE idsasd = '656'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('656','BIO/10',null,'9',{d '2019-02-28'},'ASSISTENZA','BIOCHIMICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '657')
UPDATE [sasd] SET codice = 'BIO/11',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BIOLOGIA MOLECOLARE' WHERE idsasd = '657'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('657','BIO/11',null,'9',{d '2019-02-28'},'ASSISTENZA','BIOLOGIA MOLECOLARE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '658')
UPDATE [sasd] SET codice = 'BIO/12',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BIOCHIMICA CLINICA E BIOLOGIA MOLECOLARE CLINICA' WHERE idsasd = '658'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('658','BIO/12',null,'9',{d '2019-02-28'},'ASSISTENZA','BIOCHIMICA CLINICA E BIOLOGIA MOLECOLARE CLINICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '659')
UPDATE [sasd] SET codice = 'BIO/13',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BIOLOGIA APPLICATA' WHERE idsasd = '659'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('659','BIO/13',null,'9',{d '2019-02-28'},'ASSISTENZA','BIOLOGIA APPLICATA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '660')
UPDATE [sasd] SET codice = 'BIO/14',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FARMACOLOGIA' WHERE idsasd = '660'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('660','BIO/14',null,'9',{d '2019-02-28'},'ASSISTENZA','FARMACOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '661')
UPDATE [sasd] SET codice = 'BIO/15',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BIOLOGIA FARMACEUTICA' WHERE idsasd = '661'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('661','BIO/15',null,'9',{d '2019-02-28'},'ASSISTENZA','BIOLOGIA FARMACEUTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '662')
UPDATE [sasd] SET codice = 'BIO/16',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANATOMIA UMANA' WHERE idsasd = '662'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('662','BIO/16',null,'9',{d '2019-02-28'},'ASSISTENZA','ANATOMIA UMANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '663')
UPDATE [sasd] SET codice = 'BIO/17',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ISTOLOGIA' WHERE idsasd = '663'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('663','BIO/17',null,'9',{d '2019-02-28'},'ASSISTENZA','ISTOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '664')
UPDATE [sasd] SET codice = 'BIO/18',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GENETICA' WHERE idsasd = '664'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('664','BIO/18',null,'9',{d '2019-02-28'},'ASSISTENZA','GENETICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '665')
UPDATE [sasd] SET codice = 'BIO/19',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MICROBIOLOGIA GENERALE' WHERE idsasd = '665'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('665','BIO/19',null,'9',{d '2019-02-28'},'ASSISTENZA','MICROBIOLOGIA GENERALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '666')
UPDATE [sasd] SET codice = 'BIO/20',codice_old = null,idareadidattica = '9',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SOPPRESSO con DM 26.6.00 - ATTIVITA MOTORIE' WHERE idsasd = '666'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('666','BIO/20',null,'9',{d '2019-02-28'},'ASSISTENZA','SOPPRESSO con DM 26.6.00 - ATTIVITA MOTORIE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '667')
UPDATE [sasd] SET codice = 'CHIM/01',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA ANALITICA' WHERE idsasd = '667'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('667','CHIM/01',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA ANALITICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '668')
UPDATE [sasd] SET codice = 'CHIM/02',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA FISICA' WHERE idsasd = '668'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('668','CHIM/02',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA FISICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '669')
UPDATE [sasd] SET codice = 'CHIM/03',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA GENERALE E INORGANICA' WHERE idsasd = '669'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('669','CHIM/03',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA GENERALE E INORGANICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '670')
UPDATE [sasd] SET codice = 'CHIM/04',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA INDUSTRIALE' WHERE idsasd = '670'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('670','CHIM/04',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA INDUSTRIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '671')
UPDATE [sasd] SET codice = 'CHIM/05',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZA E TECNOLOGIA DEI MATERIALI POLIMERICI' WHERE idsasd = '671'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('671','CHIM/05',null,'7',{d '2019-02-28'},'ASSISTENZA','SCIENZA E TECNOLOGIA DEI MATERIALI POLIMERICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '672')
UPDATE [sasd] SET codice = 'CHIM/06',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA ORGANICA' WHERE idsasd = '672'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('672','CHIM/06',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA ORGANICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '673')
UPDATE [sasd] SET codice = 'CHIM/07',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FONDAMENTI CHIMICI DELLE TECNOLOGIE' WHERE idsasd = '673'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('673','CHIM/07',null,'7',{d '2019-02-28'},'ASSISTENZA','FONDAMENTI CHIMICI DELLE TECNOLOGIE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '674')
UPDATE [sasd] SET codice = 'CHIM/08',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA FARMACEUTICA' WHERE idsasd = '674'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('674','CHIM/08',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA FARMACEUTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '675')
UPDATE [sasd] SET codice = 'CHIM/09',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FARMACEUTICO TECNOLOGICO APPLICATIVO' WHERE idsasd = '675'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('675','CHIM/09',null,'7',{d '2019-02-28'},'ASSISTENZA','FARMACEUTICO TECNOLOGICO APPLICATIVO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '676')
UPDATE [sasd] SET codice = 'CHIM/10',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA DEGLI ALIMENTI' WHERE idsasd = '676'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('676','CHIM/10',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA DEGLI ALIMENTI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '677')
UPDATE [sasd] SET codice = 'CHIM/11',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA E BIOTECNOLOGIA DELLE FERMENTAZIONI' WHERE idsasd = '677'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('677','CHIM/11',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA E BIOTECNOLOGIA DELLE FERMENTAZIONI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '678')
UPDATE [sasd] SET codice = 'CHIM/12',codice_old = null,idareadidattica = '7',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA DELL''AMBIENTE E DEI BENI CULTURALI' WHERE idsasd = '678'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('678','CHIM/12',null,'7',{d '2019-02-28'},'ASSISTENZA','CHIMICA DELL''AMBIENTE E DEI BENI CULTURALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '679')
UPDATE [sasd] SET codice = 'FIS/01',codice_old = null,idareadidattica = '6',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA SPERIMENTALE' WHERE idsasd = '679'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('679','FIS/01',null,'6',{d '2019-02-28'},'ASSISTENZA','FISICA SPERIMENTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '680')
UPDATE [sasd] SET codice = 'FIS/02',codice_old = null,idareadidattica = '6',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA TEORICA, MODELLI E METODI MATEMATICI' WHERE idsasd = '680'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('680','FIS/02',null,'6',{d '2019-02-28'},'ASSISTENZA','FISICA TEORICA, MODELLI E METODI MATEMATICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '681')
UPDATE [sasd] SET codice = 'FIS/03',codice_old = null,idareadidattica = '6',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA DELLA MATERIA' WHERE idsasd = '681'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('681','FIS/03',null,'6',{d '2019-02-28'},'ASSISTENZA','FISICA DELLA MATERIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '682')
UPDATE [sasd] SET codice = 'FIS/04',codice_old = null,idareadidattica = '6',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA NUCLEARE E SUBNUCLEARE' WHERE idsasd = '682'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('682','FIS/04',null,'6',{d '2019-02-28'},'ASSISTENZA','FISICA NUCLEARE E SUBNUCLEARE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '683')
UPDATE [sasd] SET codice = 'FIS/05',codice_old = null,idareadidattica = '6',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ASTRONOMIA E ASTROFISICA' WHERE idsasd = '683'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('683','FIS/05',null,'6',{d '2019-02-28'},'ASSISTENZA','ASTRONOMIA E ASTROFISICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '684')
UPDATE [sasd] SET codice = 'FIS/06',codice_old = null,idareadidattica = '6',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA PER IL SISTEMA TERRA E PER IL MEZZO CIRCUMTERRESTRE' WHERE idsasd = '684'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('684','FIS/06',null,'6',{d '2019-02-28'},'ASSISTENZA','FISICA PER IL SISTEMA TERRA E PER IL MEZZO CIRCUMTERRESTRE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '685')
UPDATE [sasd] SET codice = 'FIS/07',codice_old = null,idareadidattica = '6',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA APPLICATA (A BENI CULTURALI, AMBIENTALI, BIOLOGIA E MEDICINA)' WHERE idsasd = '685'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('685','FIS/07',null,'6',{d '2019-02-28'},'ASSISTENZA','FISICA APPLICATA (A BENI CULTURALI, AMBIENTALI, BIOLOGIA E MEDICINA)')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '686')
UPDATE [sasd] SET codice = 'FIS/08',codice_old = null,idareadidattica = '6',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIDATTICA E STORIA DELLA FISICA' WHERE idsasd = '686'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('686','FIS/08',null,'6',{d '2019-02-28'},'ASSISTENZA','DIDATTICA E STORIA DELLA FISICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '687')
UPDATE [sasd] SET codice = 'GEO/01',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PALEONTOLOGIA E PALEOECOLOGIA' WHERE idsasd = '687'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('687','GEO/01',null,'8',{d '2019-02-28'},'ASSISTENZA','PALEONTOLOGIA E PALEOECOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '688')
UPDATE [sasd] SET codice = 'GEO/02',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOLOGIA STRATIGRAFICA E SEDIMENTOLOGICA' WHERE idsasd = '688'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('688','GEO/02',null,'8',{d '2019-02-28'},'ASSISTENZA','GEOLOGIA STRATIGRAFICA E SEDIMENTOLOGICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '689')
UPDATE [sasd] SET codice = 'GEO/03',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOLOGIA STRUTTURALE' WHERE idsasd = '689'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('689','GEO/03',null,'8',{d '2019-02-28'},'ASSISTENZA','GEOLOGIA STRUTTURALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '690')
UPDATE [sasd] SET codice = 'GEO/04',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOGRAFIA FISICA E GEOMORFOLOGIA' WHERE idsasd = '690'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('690','GEO/04',null,'8',{d '2019-02-28'},'ASSISTENZA','GEOGRAFIA FISICA E GEOMORFOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '691')
UPDATE [sasd] SET codice = 'GEO/05',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOLOGIA APPLICATA' WHERE idsasd = '691'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('691','GEO/05',null,'8',{d '2019-02-28'},'ASSISTENZA','GEOLOGIA APPLICATA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '692')
UPDATE [sasd] SET codice = 'GEO/06',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MINERALOGIA' WHERE idsasd = '692'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('692','GEO/06',null,'8',{d '2019-02-28'},'ASSISTENZA','MINERALOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '693')
UPDATE [sasd] SET codice = 'GEO/07',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PETROLOGIA E PETROGRAFIA' WHERE idsasd = '693'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('693','GEO/07',null,'8',{d '2019-02-28'},'ASSISTENZA','PETROLOGIA E PETROGRAFIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '694')
UPDATE [sasd] SET codice = 'GEO/08',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOCHIMICA E VULCANOLOGIA' WHERE idsasd = '694'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('694','GEO/08',null,'8',{d '2019-02-28'},'ASSISTENZA','GEOCHIMICA E VULCANOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '695')
UPDATE [sasd] SET codice = 'GEO/09',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEORISORSE MINERARIE E APPLICAZIONI MINERALOGICO-PETROGRAFICHE PER L''AMBIENTE ED I BENI CULTURALI' WHERE idsasd = '695'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('695','GEO/09',null,'8',{d '2019-02-28'},'ASSISTENZA','GEORISORSE MINERARIE E APPLICAZIONI MINERALOGICO-PETROGRAFICHE PER L''AMBIENTE ED I BENI CULTURALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '696')
UPDATE [sasd] SET codice = 'GEO/10',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOFISICA DELLA TERRA SOLIDA' WHERE idsasd = '696'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('696','GEO/10',null,'8',{d '2019-02-28'},'ASSISTENZA','GEOFISICA DELLA TERRA SOLIDA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '697')
UPDATE [sasd] SET codice = 'GEO/11',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOFISICA APPLICATA' WHERE idsasd = '697'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('697','GEO/11',null,'8',{d '2019-02-28'},'ASSISTENZA','GEOFISICA APPLICATA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '698')
UPDATE [sasd] SET codice = 'GEO/12',codice_old = null,idareadidattica = '8',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'OCEANOGRAFIA E FISICA DELL''ATMOSFERA' WHERE idsasd = '698'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('698','GEO/12',null,'8',{d '2019-02-28'},'ASSISTENZA','OCEANOGRAFIA E FISICA DELL''ATMOSFERA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '699')
UPDATE [sasd] SET codice = 'ICAR/01',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'IDRAULICA' WHERE idsasd = '699'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('699','ICAR/01',null,'12',{d '2019-02-28'},'ASSISTENZA','IDRAULICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '700')
UPDATE [sasd] SET codice = 'ICAR/02',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'COSTRUZIONI IDRAULICHE E MARITTIME E IDROLOGIA' WHERE idsasd = '700'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('700','ICAR/02',null,'12',{d '2019-02-28'},'ASSISTENZA','COSTRUZIONI IDRAULICHE E MARITTIME E IDROLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '701')
UPDATE [sasd] SET codice = 'ICAR/03',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'INGEGNERIA SANITARIA - AMBIENTALE' WHERE idsasd = '701'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('701','ICAR/03',null,'12',{d '2019-02-28'},'ASSISTENZA','INGEGNERIA SANITARIA - AMBIENTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '702')
UPDATE [sasd] SET codice = 'ICAR/04',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STRADE, FERROVIE E AEROPORTI' WHERE idsasd = '702'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('702','ICAR/04',null,'12',{d '2019-02-28'},'ASSISTENZA','STRADE, FERROVIE E AEROPORTI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '703')
UPDATE [sasd] SET codice = 'ICAR/05',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TRASPORTI' WHERE idsasd = '703'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('703','ICAR/05',null,'12',{d '2019-02-28'},'ASSISTENZA','TRASPORTI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '704')
UPDATE [sasd] SET codice = 'ICAR/06',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TOPOGRAFIA E CARTOGRAFIA' WHERE idsasd = '704'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('704','ICAR/06',null,'12',{d '2019-02-28'},'ASSISTENZA','TOPOGRAFIA E CARTOGRAFIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '705')
UPDATE [sasd] SET codice = 'ICAR/07',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOTECNICA' WHERE idsasd = '705'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('705','ICAR/07',null,'12',{d '2019-02-28'},'ASSISTENZA','GEOTECNICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '706')
UPDATE [sasd] SET codice = 'ICAR/08',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZA DELLE COSTRUZIONI' WHERE idsasd = '706'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('706','ICAR/08',null,'12',{d '2019-02-28'},'ASSISTENZA','SCIENZA DELLE COSTRUZIONI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '707')
UPDATE [sasd] SET codice = 'ICAR/09',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TECNICA DELLE COSTRUZIONI' WHERE idsasd = '707'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('707','ICAR/09',null,'12',{d '2019-02-28'},'ASSISTENZA','TECNICA DELLE COSTRUZIONI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '708')
UPDATE [sasd] SET codice = 'ICAR/10',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHITETTURA TECNICA' WHERE idsasd = '708'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('708','ICAR/10',null,'12',{d '2019-02-28'},'ASSISTENZA','ARCHITETTURA TECNICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '709')
UPDATE [sasd] SET codice = 'ICAR/11',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PRODUZIONE EDILIZIA' WHERE idsasd = '709'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('709','ICAR/11',null,'12',{d '2019-02-28'},'ASSISTENZA','PRODUZIONE EDILIZIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '710')
UPDATE [sasd] SET codice = 'ICAR/12',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TECNOLOGIA DELL''ARCHITETTURA' WHERE idsasd = '710'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('710','ICAR/12',null,'12',{d '2019-02-28'},'ASSISTENZA','TECNOLOGIA DELL''ARCHITETTURA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '711')
UPDATE [sasd] SET codice = 'ICAR/13',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DISEGNO INDUSTRIALE' WHERE idsasd = '711'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('711','ICAR/13',null,'12',{d '2019-02-28'},'ASSISTENZA','DISEGNO INDUSTRIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '712')
UPDATE [sasd] SET codice = 'ICAR/14',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'COMPOSIZIONE ARCHITETTONICA E URBANA' WHERE idsasd = '712'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('712','ICAR/14',null,'12',{d '2019-02-28'},'ASSISTENZA','COMPOSIZIONE ARCHITETTONICA E URBANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '713')
UPDATE [sasd] SET codice = 'ICAR/15',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHITETTURA DEL PAESAGGIO' WHERE idsasd = '713'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('713','ICAR/15',null,'12',{d '2019-02-28'},'ASSISTENZA','ARCHITETTURA DEL PAESAGGIO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '714')
UPDATE [sasd] SET codice = 'ICAR/16',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHITETTURA DEGLI INTERNI E ALLESTIMENTO' WHERE idsasd = '714'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('714','ICAR/16',null,'12',{d '2019-02-28'},'ASSISTENZA','ARCHITETTURA DEGLI INTERNI E ALLESTIMENTO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '715')
UPDATE [sasd] SET codice = 'ICAR/17',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DISEGNO' WHERE idsasd = '715'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('715','ICAR/17',null,'12',{d '2019-02-28'},'ASSISTENZA','DISEGNO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '716')
UPDATE [sasd] SET codice = 'ICAR/18',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELL''ARCHITETTURA' WHERE idsasd = '716'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('716','ICAR/18',null,'12',{d '2019-02-28'},'ASSISTENZA','STORIA DELL''ARCHITETTURA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '717')
UPDATE [sasd] SET codice = 'ICAR/19',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'RESTAURO' WHERE idsasd = '717'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('717','ICAR/19',null,'12',{d '2019-02-28'},'ASSISTENZA','RESTAURO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '718')
UPDATE [sasd] SET codice = 'ICAR/20',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TECNICA E PIANIFICAZIONE URBANISTICA' WHERE idsasd = '718'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('718','ICAR/20',null,'12',{d '2019-02-28'},'ASSISTENZA','TECNICA E PIANIFICAZIONE URBANISTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '719')
UPDATE [sasd] SET codice = 'ICAR/21',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'URBANISTICA' WHERE idsasd = '719'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('719','ICAR/21',null,'12',{d '2019-02-28'},'ASSISTENZA','URBANISTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '720')
UPDATE [sasd] SET codice = 'ICAR/22',codice_old = null,idareadidattica = '12',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ESTIMO' WHERE idsasd = '720'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('720','ICAR/22',null,'12',{d '2019-02-28'},'ASSISTENZA','ESTIMO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '721')
UPDATE [sasd] SET codice = 'INF/01',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'INFORMATICA' WHERE idsasd = '721'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('721','INF/01',null,'5',{d '2019-02-28'},'ASSISTENZA','INFORMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '722')
UPDATE [sasd] SET codice = 'ING-IND/01',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHITETTURA NAVALE' WHERE idsasd = '722'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('722','ING-IND/01',null,'13',{d '2019-02-28'},'ASSISTENZA','ARCHITETTURA NAVALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '723')
UPDATE [sasd] SET codice = 'ING-IND/02',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'COSTRUZIONI E IMPIANTI NAVALI E MARINI' WHERE idsasd = '723'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('723','ING-IND/02',null,'13',{d '2019-02-28'},'ASSISTENZA','COSTRUZIONI E IMPIANTI NAVALI E MARINI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '724')
UPDATE [sasd] SET codice = 'ING-IND/03',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MECCANICA DEL VOLO' WHERE idsasd = '724'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('724','ING-IND/03',null,'13',{d '2019-02-28'},'ASSISTENZA','MECCANICA DEL VOLO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '725')
UPDATE [sasd] SET codice = 'ING-IND/04',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'COSTRUZIONI E STRUTTURE AEROSPAZIALI' WHERE idsasd = '725'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('725','ING-IND/04',null,'13',{d '2019-02-28'},'ASSISTENZA','COSTRUZIONI E STRUTTURE AEROSPAZIALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '726')
UPDATE [sasd] SET codice = 'ING-IND/05',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'IMPIANTI E SISTEMI AEROSPAZIALI' WHERE idsasd = '726'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('726','ING-IND/05',null,'13',{d '2019-02-28'},'ASSISTENZA','IMPIANTI E SISTEMI AEROSPAZIALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '727')
UPDATE [sasd] SET codice = 'ING-IND/06',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FLUIDODINAMICA' WHERE idsasd = '727'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('727','ING-IND/06',null,'13',{d '2019-02-28'},'ASSISTENZA','FLUIDODINAMICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '728')
UPDATE [sasd] SET codice = 'ING-IND/07',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PROPULSIONE AEROSPAZIALE' WHERE idsasd = '728'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('728','ING-IND/07',null,'13',{d '2019-02-28'},'ASSISTENZA','PROPULSIONE AEROSPAZIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '729')
UPDATE [sasd] SET codice = 'ING-IND/08',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MACCHINE A FLUIDO' WHERE idsasd = '729'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('729','ING-IND/08',null,'13',{d '2019-02-28'},'ASSISTENZA','MACCHINE A FLUIDO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '730')
UPDATE [sasd] SET codice = 'ING-IND/09',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SISTEMI PER L''ENERGIA E L''AMBIENTE' WHERE idsasd = '730'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('730','ING-IND/09',null,'13',{d '2019-02-28'},'ASSISTENZA','SISTEMI PER L''ENERGIA E L''AMBIENTE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '731')
UPDATE [sasd] SET codice = 'ING-IND/10',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA TECNICA INDUSTRIALE' WHERE idsasd = '731'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('731','ING-IND/10',null,'13',{d '2019-02-28'},'ASSISTENZA','FISICA TECNICA INDUSTRIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '732')
UPDATE [sasd] SET codice = 'ING-IND/11',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA TECNICA AMBIENTALE' WHERE idsasd = '732'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('732','ING-IND/11',null,'13',{d '2019-02-28'},'ASSISTENZA','FISICA TECNICA AMBIENTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '733')
UPDATE [sasd] SET codice = 'ING-IND/12',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MISURE MECCANICHE E TERMICHE' WHERE idsasd = '733'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('733','ING-IND/12',null,'13',{d '2019-02-28'},'ASSISTENZA','MISURE MECCANICHE E TERMICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '734')
UPDATE [sasd] SET codice = 'ING-IND/13',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MECCANICA APPLICATA ALLE MACCHINE' WHERE idsasd = '734'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('734','ING-IND/13',null,'13',{d '2019-02-28'},'ASSISTENZA','MECCANICA APPLICATA ALLE MACCHINE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '735')
UPDATE [sasd] SET codice = 'ING-IND/14',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PROGETTAZIONE MECCANICA E COSTRUZIONE DI MACCHINE' WHERE idsasd = '735'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('735','ING-IND/14',null,'13',{d '2019-02-28'},'ASSISTENZA','PROGETTAZIONE MECCANICA E COSTRUZIONE DI MACCHINE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '736')
UPDATE [sasd] SET codice = 'ING-IND/15',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DISEGNO E METODI DELL''INGEGNERIA INDUSTRIALE' WHERE idsasd = '736'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('736','ING-IND/15',null,'13',{d '2019-02-28'},'ASSISTENZA','DISEGNO E METODI DELL''INGEGNERIA INDUSTRIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '737')
UPDATE [sasd] SET codice = 'ING-IND/16',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TECNOLOGIE E SISTEMI DI LAVORAZIONE' WHERE idsasd = '737'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('737','ING-IND/16',null,'13',{d '2019-02-28'},'ASSISTENZA','TECNOLOGIE E SISTEMI DI LAVORAZIONE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '738')
UPDATE [sasd] SET codice = 'ING-IND/17',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'IMPIANTI INDUSTRIALI MECCANICI' WHERE idsasd = '738'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('738','ING-IND/17',null,'13',{d '2019-02-28'},'ASSISTENZA','IMPIANTI INDUSTRIALI MECCANICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '739')
UPDATE [sasd] SET codice = 'ING-IND/18',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA DEI REATTORI NUCLEARI' WHERE idsasd = '739'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('739','ING-IND/18',null,'13',{d '2019-02-28'},'ASSISTENZA','FISICA DEI REATTORI NUCLEARI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '740')
UPDATE [sasd] SET codice = 'ING-IND/19',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'IMPIANTI NUCLEARI' WHERE idsasd = '740'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('740','ING-IND/19',null,'13',{d '2019-02-28'},'ASSISTENZA','IMPIANTI NUCLEARI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '741')
UPDATE [sasd] SET codice = 'ING-IND/20',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MISURE E STRUMENTAZIONE NUCLEARI' WHERE idsasd = '741'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('741','ING-IND/20',null,'13',{d '2019-02-28'},'ASSISTENZA','MISURE E STRUMENTAZIONE NUCLEARI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '742')
UPDATE [sasd] SET codice = 'ING-IND/21',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'METALLURGIA' WHERE idsasd = '742'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('742','ING-IND/21',null,'13',{d '2019-02-28'},'ASSISTENZA','METALLURGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '743')
UPDATE [sasd] SET codice = 'ING-IND/22',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZA E TECNOLOGIA DEI MATERIALI' WHERE idsasd = '743'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('743','ING-IND/22',null,'13',{d '2019-02-28'},'ASSISTENZA','SCIENZA E TECNOLOGIA DEI MATERIALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '744')
UPDATE [sasd] SET codice = 'ING-IND/23',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA FISICA APPLICATA' WHERE idsasd = '744'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('744','ING-IND/23',null,'13',{d '2019-02-28'},'ASSISTENZA','CHIMICA FISICA APPLICATA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '745')
UPDATE [sasd] SET codice = 'ING-IND/24',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PRINCIPI DI INGEGNERIA CHIMICA' WHERE idsasd = '745'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('745','ING-IND/24',null,'13',{d '2019-02-28'},'ASSISTENZA','PRINCIPI DI INGEGNERIA CHIMICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '746')
UPDATE [sasd] SET codice = 'ING-IND/25',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'IMPIANTI CHIMICI' WHERE idsasd = '746'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('746','ING-IND/25',null,'13',{d '2019-02-28'},'ASSISTENZA','IMPIANTI CHIMICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '747')
UPDATE [sasd] SET codice = 'ING-IND/26',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TEORIA DELLO SVILUPPO DEI PROCESSI CHIMICI' WHERE idsasd = '747'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('747','ING-IND/26',null,'13',{d '2019-02-28'},'ASSISTENZA','TEORIA DELLO SVILUPPO DEI PROCESSI CHIMICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '748')
UPDATE [sasd] SET codice = 'ING-IND/27',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIMICA INDUSTRIALE E TECNOLOGICA' WHERE idsasd = '748'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('748','ING-IND/27',null,'13',{d '2019-02-28'},'ASSISTENZA','CHIMICA INDUSTRIALE E TECNOLOGICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '749')
UPDATE [sasd] SET codice = 'ING-IND/28',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'INGEGNERIA E SICUREZZA DEGLI SCAVI' WHERE idsasd = '749'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('749','ING-IND/28',null,'13',{d '2019-02-28'},'ASSISTENZA','INGEGNERIA E SICUREZZA DEGLI SCAVI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '750')
UPDATE [sasd] SET codice = 'ING-IND/29',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'INGEGNERIA DELLE MATERIE PRIME' WHERE idsasd = '750'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('750','ING-IND/29',null,'13',{d '2019-02-28'},'ASSISTENZA','INGEGNERIA DELLE MATERIE PRIME')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '751')
UPDATE [sasd] SET codice = 'ING-IND/30',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'IDROCARBURI E FLUIDI DEL SOTTOSUOLO' WHERE idsasd = '751'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('751','ING-IND/30',null,'13',{d '2019-02-28'},'ASSISTENZA','IDROCARBURI E FLUIDI DEL SOTTOSUOLO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '752')
UPDATE [sasd] SET codice = 'ING-IND/31',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ELETTROTECNICA' WHERE idsasd = '752'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('752','ING-IND/31',null,'13',{d '2019-02-28'},'ASSISTENZA','ELETTROTECNICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '753')
UPDATE [sasd] SET codice = 'ING-IND/32',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CONVERTITORI, MACCHINE E AZIONAMENTI ELETTRICI' WHERE idsasd = '753'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('753','ING-IND/32',null,'13',{d '2019-02-28'},'ASSISTENZA','CONVERTITORI, MACCHINE E AZIONAMENTI ELETTRICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '754')
UPDATE [sasd] SET codice = 'ING-IND/33',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SISTEMI ELETTRICI PER L''ENERGIA' WHERE idsasd = '754'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('754','ING-IND/33',null,'13',{d '2019-02-28'},'ASSISTENZA','SISTEMI ELETTRICI PER L''ENERGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '755')
UPDATE [sasd] SET codice = 'ING-IND/34',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BIOINGEGNERIA INDUSTRIALE' WHERE idsasd = '755'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('755','ING-IND/34',null,'13',{d '2019-02-28'},'ASSISTENZA','BIOINGEGNERIA INDUSTRIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '756')
UPDATE [sasd] SET codice = 'ING-IND/35',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'INGEGNERIA ECONOMICO-GESTIONALE' WHERE idsasd = '756'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('756','ING-IND/35',null,'13',{d '2019-02-28'},'ASSISTENZA','INGEGNERIA ECONOMICO-GESTIONALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '757')
UPDATE [sasd] SET codice = 'ING-INF/01',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ELETTRONICA' WHERE idsasd = '757'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('757','ING-INF/01',null,'13',{d '2019-02-28'},'ASSISTENZA','ELETTRONICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '758')
UPDATE [sasd] SET codice = 'ING-INF/02',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CAMPI ELETTROMAGNETICI' WHERE idsasd = '758'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('758','ING-INF/02',null,'13',{d '2019-02-28'},'ASSISTENZA','CAMPI ELETTROMAGNETICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '759')
UPDATE [sasd] SET codice = 'ING-INF/03',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TELECOMUNICAZIONI' WHERE idsasd = '759'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('759','ING-INF/03',null,'13',{d '2019-02-28'},'ASSISTENZA','TELECOMUNICAZIONI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '760')
UPDATE [sasd] SET codice = 'ING-INF/04',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'AUTOMATICA' WHERE idsasd = '760'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('760','ING-INF/04',null,'13',{d '2019-02-28'},'ASSISTENZA','AUTOMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '761')
UPDATE [sasd] SET codice = 'ING-INF/05',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SISTEMI DI ELABORAZIONE DELLE INFORMAZIONI' WHERE idsasd = '761'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('761','ING-INF/05',null,'13',{d '2019-02-28'},'ASSISTENZA','SISTEMI DI ELABORAZIONE DELLE INFORMAZIONI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '762')
UPDATE [sasd] SET codice = 'ING-INF/06',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'BIOINGEGNERIA ELETTRONICA E INFORMATICA' WHERE idsasd = '762'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('762','ING-INF/06',null,'13',{d '2019-02-28'},'ASSISTENZA','BIOINGEGNERIA ELETTRONICA E INFORMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '763')
UPDATE [sasd] SET codice = 'ING-INF/07',codice_old = null,idareadidattica = '13',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MISURE ELETTRICHE ED ELETTRONICHE' WHERE idsasd = '763'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('763','ING-INF/07',null,'13',{d '2019-02-28'},'ASSISTENZA','MISURE ELETTRICHE ED ELETTRONICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '764')
UPDATE [sasd] SET codice = 'IUS/01',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO PRIVATO' WHERE idsasd = '764'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('764','IUS/01',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO PRIVATO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '765')
UPDATE [sasd] SET codice = 'IUS/02',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO PRIVATO COMPARATO' WHERE idsasd = '765'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('765','IUS/02',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO PRIVATO COMPARATO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '766')
UPDATE [sasd] SET codice = 'IUS/03',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO AGRARIO' WHERE idsasd = '766'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('766','IUS/03',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO AGRARIO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '767')
UPDATE [sasd] SET codice = 'IUS/04',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO COMMERCIALE' WHERE idsasd = '767'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('767','IUS/04',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO COMMERCIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '768')
UPDATE [sasd] SET codice = 'IUS/05',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO DELL''ECONOMIA' WHERE idsasd = '768'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('768','IUS/05',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO DELL''ECONOMIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '769')
UPDATE [sasd] SET codice = 'IUS/06',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO DELLA NAVIGAZIONE' WHERE idsasd = '769'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('769','IUS/06',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO DELLA NAVIGAZIONE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '770')
UPDATE [sasd] SET codice = 'IUS/07',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO DEL LAVORO' WHERE idsasd = '770'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('770','IUS/07',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO DEL LAVORO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '771')
UPDATE [sasd] SET codice = 'IUS/08',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO COSTITUZIONALE' WHERE idsasd = '771'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('771','IUS/08',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO COSTITUZIONALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '772')
UPDATE [sasd] SET codice = 'IUS/09',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ISTITUZIONI DI DIRITTO PUBBLICO' WHERE idsasd = '772'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('772','IUS/09',null,'16',{d '2019-02-28'},'ASSISTENZA','ISTITUZIONI DI DIRITTO PUBBLICO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '773')
UPDATE [sasd] SET codice = 'IUS/10',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO AMMINISTRATIVO' WHERE idsasd = '773'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('773','IUS/10',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO AMMINISTRATIVO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '774')
UPDATE [sasd] SET codice = 'IUS/11',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO CANONICO E DIRITTO ECCLESIASTICO' WHERE idsasd = '774'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('774','IUS/11',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO CANONICO E DIRITTO ECCLESIASTICO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '775')
UPDATE [sasd] SET codice = 'IUS/12',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO TRIBUTARIO' WHERE idsasd = '775'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('775','IUS/12',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO TRIBUTARIO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '776')
UPDATE [sasd] SET codice = 'IUS/13',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO INTERNAZIONALE' WHERE idsasd = '776'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('776','IUS/13',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO INTERNAZIONALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '777')
UPDATE [sasd] SET codice = 'IUS/14',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO DELL''UNIONE EUROPEA' WHERE idsasd = '777'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('777','IUS/14',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO DELL''UNIONE EUROPEA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '778')
UPDATE [sasd] SET codice = 'IUS/15',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO PROCESSUALE CIVILE' WHERE idsasd = '778'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('778','IUS/15',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO PROCESSUALE CIVILE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '779')
UPDATE [sasd] SET codice = 'IUS/16',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO PROCESSUALE PENALE' WHERE idsasd = '779'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('779','IUS/16',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO PROCESSUALE PENALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '780')
UPDATE [sasd] SET codice = 'IUS/17',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO PENALE' WHERE idsasd = '780'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('780','IUS/17',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO PENALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '781')
UPDATE [sasd] SET codice = 'IUS/18',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO ROMANO E DIRITTI DELL''ANTICHITA' WHERE idsasd = '781'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('781','IUS/18',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO ROMANO E DIRITTI DELL''ANTICHITA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '782')
UPDATE [sasd] SET codice = 'IUS/19',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DEL DIRITTO MEDIEVALE E MODERNO' WHERE idsasd = '782'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('782','IUS/19',null,'16',{d '2019-02-28'},'ASSISTENZA','STORIA DEL DIRITTO MEDIEVALE E MODERNO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '783')
UPDATE [sasd] SET codice = 'IUS/20',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOSOFIA DEL DIRITTO' WHERE idsasd = '783'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('783','IUS/20',null,'16',{d '2019-02-28'},'ASSISTENZA','FILOSOFIA DEL DIRITTO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '784')
UPDATE [sasd] SET codice = 'IUS/21',codice_old = null,idareadidattica = '16',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIRITTO PUBBLICO COMPARATO' WHERE idsasd = '784'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('784','IUS/21',null,'16',{d '2019-02-28'},'ASSISTENZA','DIRITTO PUBBLICO COMPARATO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '785')
UPDATE [sasd] SET codice = 'L-ANT/01',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PREISTORIA E PROTOSTORIA' WHERE idsasd = '785'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('785','L-ANT/01',null,'14',{d '2019-02-28'},'ASSISTENZA','PREISTORIA E PROTOSTORIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '786')
UPDATE [sasd] SET codice = 'L-ANT/02',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA GRECA' WHERE idsasd = '786'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('786','L-ANT/02',null,'14',{d '2019-02-28'},'ASSISTENZA','STORIA GRECA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '787')
UPDATE [sasd] SET codice = 'L-ANT/03',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA ROMANA' WHERE idsasd = '787'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('787','L-ANT/03',null,'14',{d '2019-02-28'},'ASSISTENZA','STORIA ROMANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '788')
UPDATE [sasd] SET codice = 'L-ANT/04',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'NUMISMATICA' WHERE idsasd = '788'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('788','L-ANT/04',null,'14',{d '2019-02-28'},'ASSISTENZA','NUMISMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '789')
UPDATE [sasd] SET codice = 'L-ANT/05',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PAPIROLOGIA' WHERE idsasd = '789'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('789','L-ANT/05',null,'14',{d '2019-02-28'},'ASSISTENZA','PAPIROLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '790')
UPDATE [sasd] SET codice = 'L-ANT/06',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ETRUSCOLOGIA E ANTICHITA ITALICHE' WHERE idsasd = '790'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('790','L-ANT/06',null,'14',{d '2019-02-28'},'ASSISTENZA','ETRUSCOLOGIA E ANTICHITA ITALICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '791')
UPDATE [sasd] SET codice = 'L-ANT/07',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHEOLOGIA CLASSICA' WHERE idsasd = '791'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('791','L-ANT/07',null,'14',{d '2019-02-28'},'ASSISTENZA','ARCHEOLOGIA CLASSICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '792')
UPDATE [sasd] SET codice = 'L-ANT/08',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHEOLOGIA CRISTIANA E MEDIEVALE' WHERE idsasd = '792'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('792','L-ANT/08',null,'14',{d '2019-02-28'},'ASSISTENZA','ARCHEOLOGIA CRISTIANA E MEDIEVALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '793')
UPDATE [sasd] SET codice = 'L-ANT/09',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'TOPOGRAFIA ANTICA' WHERE idsasd = '793'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('793','L-ANT/09',null,'14',{d '2019-02-28'},'ASSISTENZA','TOPOGRAFIA ANTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '794')
UPDATE [sasd] SET codice = 'L-ANT/10',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'METODOLOGIE DELLA RICERCA ARCHEOLOGICA' WHERE idsasd = '794'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('794','L-ANT/10',null,'14',{d '2019-02-28'},'ASSISTENZA','METODOLOGIE DELLA RICERCA ARCHEOLOGICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '795')
UPDATE [sasd] SET codice = 'L-ART/01',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELL''ARTE MEDIEVALE' WHERE idsasd = '795'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('795','L-ART/01',null,'14',{d '2019-02-28'},'ASSISTENZA','STORIA DELL''ARTE MEDIEVALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '796')
UPDATE [sasd] SET codice = 'L-ART/02',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELL''ARTE MODERNA' WHERE idsasd = '796'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('796','L-ART/02',null,'14',{d '2019-02-28'},'ASSISTENZA','STORIA DELL''ARTE MODERNA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '797')
UPDATE [sasd] SET codice = 'L-ART/03',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELL''ARTE CONTEMPORANEA' WHERE idsasd = '797'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('797','L-ART/03',null,'14',{d '2019-02-28'},'ASSISTENZA','STORIA DELL''ARTE CONTEMPORANEA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '798')
UPDATE [sasd] SET codice = 'L-ART/04',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MUSEOLOGIA E CRITICA ARTISTICA E DEL RESTAURO' WHERE idsasd = '798'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('798','L-ART/04',null,'14',{d '2019-02-28'},'ASSISTENZA','MUSEOLOGIA E CRITICA ARTISTICA E DEL RESTAURO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '799')
UPDATE [sasd] SET codice = 'L-ART/05',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DISCIPLINE DELLO SPETTACOLO' WHERE idsasd = '799'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('799','L-ART/05',null,'14',{d '2019-02-28'},'ASSISTENZA','DISCIPLINE DELLO SPETTACOLO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '800')
UPDATE [sasd] SET codice = 'L-ART/06',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CINEMA, FOTOGRAFIA E TELEVISIONE' WHERE idsasd = '800'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('800','L-ART/06',null,'14',{d '2019-02-28'},'ASSISTENZA','CINEMA, FOTOGRAFIA E TELEVISIONE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '801')
UPDATE [sasd] SET codice = 'L-ART/07',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MUSICOLOGIA E STORIA DELLA MUSICA' WHERE idsasd = '801'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('801','L-ART/07',null,'14',{d '2019-02-28'},'ASSISTENZA','MUSICOLOGIA E STORIA DELLA MUSICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '802')
UPDATE [sasd] SET codice = 'L-ART/08',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ETNOMUSICOLOGIA' WHERE idsasd = '802'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('802','L-ART/08',null,'14',{d '2019-02-28'},'ASSISTENZA','ETNOMUSICOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '803')
UPDATE [sasd] SET codice = 'L-FIL-LET/01',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CIVILTA EGEE' WHERE idsasd = '803'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('803','L-FIL-LET/01',null,'14',{d '2019-02-28'},'ASSISTENZA','CIVILTA EGEE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '804')
UPDATE [sasd] SET codice = 'L-FIL-LET/02',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURA GRECA' WHERE idsasd = '804'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('804','L-FIL-LET/02',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURA GRECA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '805')
UPDATE [sasd] SET codice = 'L-FIL-LET/03',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOLOGIA ITALICA, ILLIRICA, CELTICA' WHERE idsasd = '805'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('805','L-FIL-LET/03',null,'14',{d '2019-02-28'},'ASSISTENZA','FILOLOGIA ITALICA, ILLIRICA, CELTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '806')
UPDATE [sasd] SET codice = 'L-FIL-LET/04',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURA LATINA' WHERE idsasd = '806'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('806','L-FIL-LET/04',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURA LATINA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '807')
UPDATE [sasd] SET codice = 'L-FIL-LET/05',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOLOGIA CLASSICA' WHERE idsasd = '807'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('807','L-FIL-LET/05',null,'14',{d '2019-02-28'},'ASSISTENZA','FILOLOGIA CLASSICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '808')
UPDATE [sasd] SET codice = 'L-FIL-LET/06',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURA CRISTIANA ANTICA' WHERE idsasd = '808'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('808','L-FIL-LET/06',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURA CRISTIANA ANTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '809')
UPDATE [sasd] SET codice = 'L-FIL-LET/07',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CIVILTA BIZANTINA' WHERE idsasd = '809'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('809','L-FIL-LET/07',null,'14',{d '2019-02-28'},'ASSISTENZA','CIVILTA BIZANTINA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '810')
UPDATE [sasd] SET codice = 'L-FIL-LET/08',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURA LATINA MEDIEVALE E UMANISTICA' WHERE idsasd = '810'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('810','L-FIL-LET/08',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURA LATINA MEDIEVALE E UMANISTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '811')
UPDATE [sasd] SET codice = 'L-FIL-LET/09',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOLOGIA E LINGUISTICA ROMANZA' WHERE idsasd = '811'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('811','L-FIL-LET/09',null,'14',{d '2019-02-28'},'ASSISTENZA','FILOLOGIA E LINGUISTICA ROMANZA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '812')
UPDATE [sasd] SET codice = 'L-FIL-LET/10',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURA ITALIANA' WHERE idsasd = '812'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('812','L-FIL-LET/10',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURA ITALIANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '813')
UPDATE [sasd] SET codice = 'L-FIL-LET/11',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURA ITALIANA CONTEMPORANEA' WHERE idsasd = '813'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('813','L-FIL-LET/11',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURA ITALIANA CONTEMPORANEA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '814')
UPDATE [sasd] SET codice = 'L-FIL-LET/12',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUISTICA ITALIANA' WHERE idsasd = '814'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('814','L-FIL-LET/12',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUISTICA ITALIANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '815')
UPDATE [sasd] SET codice = 'L-FIL-LET/13',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOLOGIA DELLA LETTERATURA ITALIANA' WHERE idsasd = '815'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('815','L-FIL-LET/13',null,'14',{d '2019-02-28'},'ASSISTENZA','FILOLOGIA DELLA LETTERATURA ITALIANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '816')
UPDATE [sasd] SET codice = 'L-FIL-LET/14',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CRITICA LETTERARIA E LETTERATURE COMPARATE' WHERE idsasd = '816'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('816','L-FIL-LET/14',null,'14',{d '2019-02-28'},'ASSISTENZA','CRITICA LETTERARIA E LETTERATURE COMPARATE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '817')
UPDATE [sasd] SET codice = 'L-FIL-LET/15',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOLOGIA GERMANICA' WHERE idsasd = '817'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('817','L-FIL-LET/15',null,'14',{d '2019-02-28'},'ASSISTENZA','FILOLOGIA GERMANICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '818')
UPDATE [sasd] SET codice = 'L-LIN/01',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GLOTTOLOGIA E LINGUISTICA' WHERE idsasd = '818'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('818','L-LIN/01',null,'14',{d '2019-02-28'},'ASSISTENZA','GLOTTOLOGIA E LINGUISTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '819')
UPDATE [sasd] SET codice = 'L-LIN/02',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIDATTICA DELLE LINGUE MODERNE' WHERE idsasd = '819'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('819','L-LIN/02',null,'14',{d '2019-02-28'},'ASSISTENZA','DIDATTICA DELLE LINGUE MODERNE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '820')
UPDATE [sasd] SET codice = 'L-LIN/03',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURA FRANCESE' WHERE idsasd = '820'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('820','L-LIN/03',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURA FRANCESE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '821')
UPDATE [sasd] SET codice = 'L-LIN/04',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E TRADUZIONE - LINGUA FRANCESE' WHERE idsasd = '821'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('821','L-LIN/04',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E TRADUZIONE - LINGUA FRANCESE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '822')
UPDATE [sasd] SET codice = 'L-LIN/05',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURA SPAGNOLA' WHERE idsasd = '822'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('822','L-LIN/05',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURA SPAGNOLA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '823')
UPDATE [sasd] SET codice = 'L-LIN/06',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURE ISPANO-AMERICANE' WHERE idsasd = '823'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('823','L-LIN/06',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURE ISPANO-AMERICANE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '824')
UPDATE [sasd] SET codice = 'L-LIN/07',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E TRADUZIONE - LINGUA SPAGNOLA' WHERE idsasd = '824'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('824','L-LIN/07',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E TRADUZIONE - LINGUA SPAGNOLA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '825')
UPDATE [sasd] SET codice = 'L-LIN/08',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURE PORTOGHESE E BRASILIANA' WHERE idsasd = '825'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('825','L-LIN/08',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURE PORTOGHESE E BRASILIANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '826')
UPDATE [sasd] SET codice = 'L-LIN/09',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E TRADUZIONE - LINGUE PORTOGHESE E BRASILIANA' WHERE idsasd = '826'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('826','L-LIN/09',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E TRADUZIONE - LINGUE PORTOGHESE E BRASILIANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '827')
UPDATE [sasd] SET codice = 'L-LIN/10',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURA INGLESE' WHERE idsasd = '827'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('827','L-LIN/10',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURA INGLESE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '828')
UPDATE [sasd] SET codice = 'L-LIN/11',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUE E LETTERATURE ANGLO-AMERICANE' WHERE idsasd = '828'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('828','L-LIN/11',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUE E LETTERATURE ANGLO-AMERICANE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '829')
UPDATE [sasd] SET codice = 'L-LIN/12',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E TRADUZIONE - LINGUA INGLESE' WHERE idsasd = '829'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('829','L-LIN/12',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E TRADUZIONE - LINGUA INGLESE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '830')
UPDATE [sasd] SET codice = 'L-LIN/13',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LETTERATURA TEDESCA' WHERE idsasd = '830'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('830','L-LIN/13',null,'14',{d '2019-02-28'},'ASSISTENZA','LETTERATURA TEDESCA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '831')
UPDATE [sasd] SET codice = 'L-LIN/14',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E TRADUZIONE - LINGUA TEDESCA' WHERE idsasd = '831'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('831','L-LIN/14',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E TRADUZIONE - LINGUA TEDESCA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '832')
UPDATE [sasd] SET codice = 'L-LIN/15',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUE E LETTERATURE NORDICHE' WHERE idsasd = '832'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('832','L-LIN/15',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUE E LETTERATURE NORDICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '833')
UPDATE [sasd] SET codice = 'L-LIN/16',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURA NEDERLANDESE' WHERE idsasd = '833'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('833','L-LIN/16',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURA NEDERLANDESE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '834')
UPDATE [sasd] SET codice = 'L-LIN/17',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURA ROMENA' WHERE idsasd = '834'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('834','L-LIN/17',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURA ROMENA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '835')
UPDATE [sasd] SET codice = 'L-LIN/18',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURA ALBANESE' WHERE idsasd = '835'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('835','L-LIN/18',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURA ALBANESE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '836')
UPDATE [sasd] SET codice = 'L-LIN/19',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOLOGIA UGRO-FINNICA' WHERE idsasd = '836'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('836','L-LIN/19',null,'14',{d '2019-02-28'},'ASSISTENZA','FILOLOGIA UGRO-FINNICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '837')
UPDATE [sasd] SET codice = 'L-LIN/20',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURA NEOGRECA' WHERE idsasd = '837'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('837','L-LIN/20',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURA NEOGRECA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '838')
UPDATE [sasd] SET codice = 'L-LIN/21',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SLAVISTICA' WHERE idsasd = '838'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('838','L-LIN/21',null,'14',{d '2019-02-28'},'ASSISTENZA','SLAVISTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '839')
UPDATE [sasd] SET codice = 'L-OR/01',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DEL VICINO ORIENTE ANTICO' WHERE idsasd = '839'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('839','L-OR/01',null,'14',{d '2019-02-28'},'ASSISTENZA','STORIA DEL VICINO ORIENTE ANTICO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '840')
UPDATE [sasd] SET codice = 'L-OR/02',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'EGITTOLOGIA E CIVILTA COPTA' WHERE idsasd = '840'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('840','L-OR/02',null,'14',{d '2019-02-28'},'ASSISTENZA','EGITTOLOGIA E CIVILTA COPTA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '841')
UPDATE [sasd] SET codice = 'L-OR/03',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ASSIRIOLOGIA' WHERE idsasd = '841'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('841','L-OR/03',null,'14',{d '2019-02-28'},'ASSISTENZA','ASSIRIOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '842')
UPDATE [sasd] SET codice = 'L-OR/04',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANATOLISTICA' WHERE idsasd = '842'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('842','L-OR/04',null,'14',{d '2019-02-28'},'ASSISTENZA','ANATOLISTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '843')
UPDATE [sasd] SET codice = 'L-OR/05',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHEOLOGIA E STORIA DELL''ARTE DEL VICINO ORIENTE ANTICO' WHERE idsasd = '843'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('843','L-OR/05',null,'14',{d '2019-02-28'},'ASSISTENZA','ARCHEOLOGIA E STORIA DELL''ARTE DEL VICINO ORIENTE ANTICO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '844')
UPDATE [sasd] SET codice = 'L-OR/06',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHEOLOGIA FENICIO-PUNICA' WHERE idsasd = '844'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('844','L-OR/06',null,'14',{d '2019-02-28'},'ASSISTENZA','ARCHEOLOGIA FENICIO-PUNICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '845')
UPDATE [sasd] SET codice = 'L-OR/07',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SEMITISTICA-LINGUE E LETTERATURE DELL''ETIOPIA' WHERE idsasd = '845'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('845','L-OR/07',null,'14',{d '2019-02-28'},'ASSISTENZA','SEMITISTICA-LINGUE E LETTERATURE DELL''ETIOPIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '846')
UPDATE [sasd] SET codice = 'L-OR/08',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'EBRAICO' WHERE idsasd = '846'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('846','L-OR/08',null,'14',{d '2019-02-28'},'ASSISTENZA','EBRAICO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '847')
UPDATE [sasd] SET codice = 'L-OR/09',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUE E LETTERATURE DELL''AFRICA' WHERE idsasd = '847'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('847','L-OR/09',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUE E LETTERATURE DELL''AFRICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '848')
UPDATE [sasd] SET codice = 'L-OR/10',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DEI PAESI ISLAMICI' WHERE idsasd = '848'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('848','L-OR/10',null,'14',{d '2019-02-28'},'ASSISTENZA','STORIA DEI PAESI ISLAMICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '849')
UPDATE [sasd] SET codice = 'L-OR/11',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHEOLOGIA E STORIA DELLL''ARTE MUSULMANA' WHERE idsasd = '849'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('849','L-OR/11',null,'14',{d '2019-02-28'},'ASSISTENZA','ARCHEOLOGIA E STORIA DELLL''ARTE MUSULMANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '850')
UPDATE [sasd] SET codice = 'L-OR/12',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURA ARABA' WHERE idsasd = '850'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('850','L-OR/12',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURA ARABA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '851')
UPDATE [sasd] SET codice = 'L-OR/13',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARMENISTICA, CAUCASOLOGIA, MONGOLISTICA E TURCOLOGIA' WHERE idsasd = '851'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('851','L-OR/13',null,'14',{d '2019-02-28'},'ASSISTENZA','ARMENISTICA, CAUCASOLOGIA, MONGOLISTICA E TURCOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '852')
UPDATE [sasd] SET codice = 'L-OR/14',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOLOGIA, RELIGIONI E STORIA DELL''IRAN' WHERE idsasd = '852'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('852','L-OR/14',null,'14',{d '2019-02-28'},'ASSISTENZA','FILOLOGIA, RELIGIONI E STORIA DELL''IRAN')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '853')
UPDATE [sasd] SET codice = 'L-OR/15',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUA E LETTERATURA PERSIANA' WHERE idsasd = '853'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('853','L-OR/15',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUA E LETTERATURA PERSIANA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '854')
UPDATE [sasd] SET codice = 'L-OR/16',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHEOLOGIA E STORIA DELLL''ARTE DELL''INDIA E DELL''ASIA CENTRALE' WHERE idsasd = '854'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('854','L-OR/16',null,'14',{d '2019-02-28'},'ASSISTENZA','ARCHEOLOGIA E STORIA DELLL''ARTE DELL''INDIA E DELL''ASIA CENTRALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '855')
UPDATE [sasd] SET codice = 'L-OR/17',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOSOFIE, RELIGIONI E STORIA DELL''INDIA E DELL''ASIA CENTRALE' WHERE idsasd = '855'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('855','L-OR/17',null,'14',{d '2019-02-28'},'ASSISTENZA','FILOSOFIE, RELIGIONI E STORIA DELL''INDIA E DELL''ASIA CENTRALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '856')
UPDATE [sasd] SET codice = 'L-OR/18',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'INDOLOGIA E TIBETOLOGIA' WHERE idsasd = '856'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('856','L-OR/18',null,'14',{d '2019-02-28'},'ASSISTENZA','INDOLOGIA E TIBETOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '857')
UPDATE [sasd] SET codice = 'L-OR/19',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUE E LETTERATURE MODERNE DEL SUBCONTINENTE INDIANO' WHERE idsasd = '857'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('857','L-OR/19',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUE E LETTERATURE MODERNE DEL SUBCONTINENTE INDIANO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '858')
UPDATE [sasd] SET codice = 'L-OR/20',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHEOLOGIA, STORIA DELLL''ARTE E FILOSOFIE DELL''ASIA ORIENTALE' WHERE idsasd = '858'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('858','L-OR/20',null,'14',{d '2019-02-28'},'ASSISTENZA','ARCHEOLOGIA, STORIA DELLL''ARTE E FILOSOFIE DELL''ASIA ORIENTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '859')
UPDATE [sasd] SET codice = 'L-OR/21',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUE E LETTERATURE DELLA CINA E DELL''ASIA SUD-ORIENTALE' WHERE idsasd = '859'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('859','L-OR/21',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUE E LETTERATURE DELLA CINA E DELL''ASIA SUD-ORIENTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '860')
UPDATE [sasd] SET codice = 'L-OR/22',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LINGUE E LETTERATURE DEL GIAPPONE E DELLA COREA' WHERE idsasd = '860'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('860','L-OR/22',null,'14',{d '2019-02-28'},'ASSISTENZA','LINGUE E LETTERATURE DEL GIAPPONE E DELLA COREA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '861')
UPDATE [sasd] SET codice = 'L-OR/23',codice_old = null,idareadidattica = '14',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELL''ASIA ORIENTALE E SUD-ORIENTALE' WHERE idsasd = '861'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('861','L-OR/23',null,'14',{d '2019-02-28'},'ASSISTENZA','STORIA DELL''ASIA ORIENTALE E SUD-ORIENTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '862')
UPDATE [sasd] SET codice = 'M-DEA/01',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DISCIPLINE DEMOETNOANTROPOLOGICHE' WHERE idsasd = '862'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('862','M-DEA/01',null,'15',{d '2019-02-28'},'ASSISTENZA','DISCIPLINE DEMOETNOANTROPOLOGICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '863')
UPDATE [sasd] SET codice = 'M-EDF/01',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'METODI E DIDATTICHE DELLE ATTIVITA MOTORIE' WHERE idsasd = '863'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('863','M-EDF/01',null,'15',{d '2019-02-28'},'ASSISTENZA','METODI E DIDATTICHE DELLE ATTIVITA MOTORIE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '864')
UPDATE [sasd] SET codice = 'M-EDF/02',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'METODI E DIDATTICHE DELLE ATTIVITA SPORTIVE' WHERE idsasd = '864'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('864','M-EDF/02',null,'15',{d '2019-02-28'},'ASSISTENZA','METODI E DIDATTICHE DELLE ATTIVITA SPORTIVE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '865')
UPDATE [sasd] SET codice = 'M-FIL/01',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOSOFIA TEORETICA' WHERE idsasd = '865'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('865','M-FIL/01',null,'15',{d '2019-02-28'},'ASSISTENZA','FILOSOFIA TEORETICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '866')
UPDATE [sasd] SET codice = 'M-FIL/02',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LOGICA E FILOSOFIA DELLA SCIENZA' WHERE idsasd = '866'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('866','M-FIL/02',null,'15',{d '2019-02-28'},'ASSISTENZA','LOGICA E FILOSOFIA DELLA SCIENZA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '867')
UPDATE [sasd] SET codice = 'M-FIL/03',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOSOFIA MORALE' WHERE idsasd = '867'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('867','M-FIL/03',null,'15',{d '2019-02-28'},'ASSISTENZA','FILOSOFIA MORALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '868')
UPDATE [sasd] SET codice = 'M-FIL/04',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ESTETICA' WHERE idsasd = '868'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('868','M-FIL/04',null,'15',{d '2019-02-28'},'ASSISTENZA','ESTETICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '869')
UPDATE [sasd] SET codice = 'M-FIL/05',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOSOFIA E TEORIA DEI LINGUAGGI' WHERE idsasd = '869'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('869','M-FIL/05',null,'15',{d '2019-02-28'},'ASSISTENZA','FILOSOFIA E TEORIA DEI LINGUAGGI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '870')
UPDATE [sasd] SET codice = 'M-FIL/06',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLA FILOSOFIA' WHERE idsasd = '870'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('870','M-FIL/06',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA DELLA FILOSOFIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '871')
UPDATE [sasd] SET codice = 'M-FIL/07',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLA FILOSOFIA ANTICA' WHERE idsasd = '871'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('871','M-FIL/07',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA DELLA FILOSOFIA ANTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '872')
UPDATE [sasd] SET codice = 'M-FIL/08',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLA FILOSOFIA MEDIEVALE' WHERE idsasd = '872'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('872','M-FIL/08',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA DELLA FILOSOFIA MEDIEVALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '873')
UPDATE [sasd] SET codice = 'M-GGR/01',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOGRAFIA' WHERE idsasd = '873'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('873','M-GGR/01',null,'15',{d '2019-02-28'},'ASSISTENZA','GEOGRAFIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '874')
UPDATE [sasd] SET codice = 'M-GGR/02',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOGRAFIA ECONOMICO-POLITICA' WHERE idsasd = '874'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('874','M-GGR/02',null,'15',{d '2019-02-28'},'ASSISTENZA','GEOGRAFIA ECONOMICO-POLITICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '875')
UPDATE [sasd] SET codice = 'M-PED/01',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PEDAGOGIA GENERALE E SOCIALE' WHERE idsasd = '875'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('875','M-PED/01',null,'15',{d '2019-02-28'},'ASSISTENZA','PEDAGOGIA GENERALE E SOCIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '876')
UPDATE [sasd] SET codice = 'M-PED/02',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLA PEDAGOGIA' WHERE idsasd = '876'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('876','M-PED/02',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA DELLA PEDAGOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '877')
UPDATE [sasd] SET codice = 'M-PED/03',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIDATTICA E PEDAGOGIA SPECIALE' WHERE idsasd = '877'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('877','M-PED/03',null,'15',{d '2019-02-28'},'ASSISTENZA','DIDATTICA E PEDAGOGIA SPECIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '878')
UPDATE [sasd] SET codice = 'M-PED/04',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PEDAGOGIA SPERIMENTALE' WHERE idsasd = '878'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('878','M-PED/04',null,'15',{d '2019-02-28'},'ASSISTENZA','PEDAGOGIA SPERIMENTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '879')
UPDATE [sasd] SET codice = 'M-PSI/01',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICOLOGIA GENERALE' WHERE idsasd = '879'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('879','M-PSI/01',null,'15',{d '2019-02-28'},'ASSISTENZA','PSICOLOGIA GENERALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '880')
UPDATE [sasd] SET codice = 'M-PSI/02',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICOBIOLOGIA E PSICOLOGIA FISIOLOGICA' WHERE idsasd = '880'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('880','M-PSI/02',null,'15',{d '2019-02-28'},'ASSISTENZA','PSICOBIOLOGIA E PSICOLOGIA FISIOLOGICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '881')
UPDATE [sasd] SET codice = 'M-PSI/03',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICOMETRIA' WHERE idsasd = '881'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('881','M-PSI/03',null,'15',{d '2019-02-28'},'ASSISTENZA','PSICOMETRIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '882')
UPDATE [sasd] SET codice = 'M-PSI/04',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICOLOGIA DELLO SVILUPPO E PSICOLOGIA DELL''EDUCAZIONE' WHERE idsasd = '882'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('882','M-PSI/04',null,'15',{d '2019-02-28'},'ASSISTENZA','PSICOLOGIA DELLO SVILUPPO E PSICOLOGIA DELL''EDUCAZIONE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '883')
UPDATE [sasd] SET codice = 'M-PSI/05',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICOLOGIA SOCIALE' WHERE idsasd = '883'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('883','M-PSI/05',null,'15',{d '2019-02-28'},'ASSISTENZA','PSICOLOGIA SOCIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '884')
UPDATE [sasd] SET codice = 'M-PSI/06',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICOLOGIA DEL LAVORO E DELLE ORGANIZZAZIONI' WHERE idsasd = '884'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('884','M-PSI/06',null,'15',{d '2019-02-28'},'ASSISTENZA','PSICOLOGIA DEL LAVORO E DELLE ORGANIZZAZIONI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '885')
UPDATE [sasd] SET codice = 'M-PSI/07',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICOLOGIA DINAMICA' WHERE idsasd = '885'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('885','M-PSI/07',null,'15',{d '2019-02-28'},'ASSISTENZA','PSICOLOGIA DINAMICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '886')
UPDATE [sasd] SET codice = 'M-PSI/08',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICOLOGIA CLINICA' WHERE idsasd = '886'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('886','M-PSI/08',null,'15',{d '2019-02-28'},'ASSISTENZA','PSICOLOGIA CLINICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '887')
UPDATE [sasd] SET codice = 'M-STO/01',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA MEDIEVALE' WHERE idsasd = '887'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('887','M-STO/01',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA MEDIEVALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '888')
UPDATE [sasd] SET codice = 'M-STO/02',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA MODERNA' WHERE idsasd = '888'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('888','M-STO/02',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA MODERNA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '889')
UPDATE [sasd] SET codice = 'M-STO/03',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELL''EUROPA ORIENTALE' WHERE idsasd = '889'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('889','M-STO/03',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA DELL''EUROPA ORIENTALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '890')
UPDATE [sasd] SET codice = 'M-STO/04',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA CONTEMPORANEA' WHERE idsasd = '890'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('890','M-STO/04',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA CONTEMPORANEA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '891')
UPDATE [sasd] SET codice = 'M-STO/05',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLA SCIENZA E DELLE TECNICHE' WHERE idsasd = '891'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('891','M-STO/05',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA DELLA SCIENZA E DELLE TECNICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '892')
UPDATE [sasd] SET codice = 'M-STO/06',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLE RELIGIONI' WHERE idsasd = '892'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('892','M-STO/06',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA DELLE RELIGIONI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '893')
UPDATE [sasd] SET codice = 'M-STO/07',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DEL CRISTIANESIMO E DELLE CHIESE' WHERE idsasd = '893'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('893','M-STO/07',null,'15',{d '2019-02-28'},'ASSISTENZA','STORIA DEL CRISTIANESIMO E DELLE CHIESE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '894')
UPDATE [sasd] SET codice = 'M-STO/08',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ARCHIVISTICA, BIBLIOGRAFIA E BIBLIOTECONOMIA' WHERE idsasd = '894'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('894','M-STO/08',null,'15',{d '2019-02-28'},'ASSISTENZA','ARCHIVISTICA, BIBLIOGRAFIA E BIBLIOTECONOMIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '895')
UPDATE [sasd] SET codice = 'M-STO/09',codice_old = null,idareadidattica = '15',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PALEOGRAFIA' WHERE idsasd = '895'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('895','M-STO/09',null,'15',{d '2019-02-28'},'ASSISTENZA','PALEOGRAFIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '896')
UPDATE [sasd] SET codice = 'MAT/01',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'LOGICA MATEMATICA' WHERE idsasd = '896'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('896','MAT/01',null,'5',{d '2019-02-28'},'ASSISTENZA','LOGICA MATEMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '897')
UPDATE [sasd] SET codice = 'MAT/02',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ALGEBRA' WHERE idsasd = '897'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('897','MAT/02',null,'5',{d '2019-02-28'},'ASSISTENZA','ALGEBRA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '898')
UPDATE [sasd] SET codice = 'MAT/03',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GEOMETRIA' WHERE idsasd = '898'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('898','MAT/03',null,'5',{d '2019-02-28'},'ASSISTENZA','GEOMETRIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '899')
UPDATE [sasd] SET codice = 'MAT/04',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MATEMATICHE COMPLEMENTARI' WHERE idsasd = '899'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('899','MAT/04',null,'5',{d '2019-02-28'},'ASSISTENZA','MATEMATICHE COMPLEMENTARI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '900')
UPDATE [sasd] SET codice = 'MAT/05',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANALISI MATEMATICA' WHERE idsasd = '900'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('900','MAT/05',null,'5',{d '2019-02-28'},'ASSISTENZA','ANALISI MATEMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '901')
UPDATE [sasd] SET codice = 'MAT/06',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PROBABILITA E STATISTICA MATEMATICA' WHERE idsasd = '901'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('901','MAT/06',null,'5',{d '2019-02-28'},'ASSISTENZA','PROBABILITA E STATISTICA MATEMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '902')
UPDATE [sasd] SET codice = 'MAT/07',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISICA MATEMATICA' WHERE idsasd = '902'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('902','MAT/07',null,'5',{d '2019-02-28'},'ASSISTENZA','FISICA MATEMATICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '903')
UPDATE [sasd] SET codice = 'MAT/08',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANALISI NUMERICA' WHERE idsasd = '903'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('903','MAT/08',null,'5',{d '2019-02-28'},'ASSISTENZA','ANALISI NUMERICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '904')
UPDATE [sasd] SET codice = 'MAT/09',codice_old = null,idareadidattica = '5',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'RICERCA OPERATIVA' WHERE idsasd = '904'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('904','MAT/09',null,'5',{d '2019-02-28'},'ASSISTENZA','RICERCA OPERATIVA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '905')
UPDATE [sasd] SET codice = 'MED/01',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STATISTICA MEDICA' WHERE idsasd = '905'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('905','MED/01',null,'10',{d '2019-02-28'},'ASSISTENZA','STATISTICA MEDICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '906')
UPDATE [sasd] SET codice = 'MED/02',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLA MEDICINA' WHERE idsasd = '906'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('906','MED/02',null,'10',{d '2019-02-28'},'ASSISTENZA','STORIA DELLA MEDICINA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '907')
UPDATE [sasd] SET codice = 'MED/03',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GENETICA MEDICA' WHERE idsasd = '907'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('907','MED/03',null,'10',{d '2019-02-28'},'ASSISTENZA','GENETICA MEDICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '908')
UPDATE [sasd] SET codice = 'MED/04',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PATOLOGIA GENERALE' WHERE idsasd = '908'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('908','MED/04',null,'10',{d '2019-02-28'},'ASSISTENZA','PATOLOGIA GENERALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '909')
UPDATE [sasd] SET codice = 'MED/05',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PATOLOGIA CLINICA' WHERE idsasd = '909'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('909','MED/05',null,'10',{d '2019-02-28'},'ASSISTENZA','PATOLOGIA CLINICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '910')
UPDATE [sasd] SET codice = 'MED/06',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ONCOLOGIA MEDICA' WHERE idsasd = '910'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('910','MED/06',null,'10',{d '2019-02-28'},'ASSISTENZA','ONCOLOGIA MEDICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '911')
UPDATE [sasd] SET codice = 'MED/07',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MICROBIOLOGIA E MICROBIOLOGIA CLINICA' WHERE idsasd = '911'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('911','MED/07',null,'10',{d '2019-02-28'},'ASSISTENZA','MICROBIOLOGIA E MICROBIOLOGIA CLINICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '912')
UPDATE [sasd] SET codice = 'MED/08',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANATOMIA PATOLOGICA' WHERE idsasd = '912'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('912','MED/08',null,'10',{d '2019-02-28'},'ASSISTENZA','ANATOMIA PATOLOGICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '913')
UPDATE [sasd] SET codice = 'MED/09',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MEDICINA INTERNA' WHERE idsasd = '913'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('913','MED/09',null,'10',{d '2019-02-28'},'ASSISTENZA','MEDICINA INTERNA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '914')
UPDATE [sasd] SET codice = 'MED/10',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE DELL''APPARATO RESPIRATORIO' WHERE idsasd = '914'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('914','MED/10',null,'10',{d '2019-02-28'},'ASSISTENZA','MALATTIE DELL''APPARATO RESPIRATORIO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '915')
UPDATE [sasd] SET codice = 'MED/11',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE DELL''APPARATO CARDIOVASCOLARE' WHERE idsasd = '915'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('915','MED/11',null,'10',{d '2019-02-28'},'ASSISTENZA','MALATTIE DELL''APPARATO CARDIOVASCOLARE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '916')
UPDATE [sasd] SET codice = 'MED/12',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GASTROENTEROLOGIA' WHERE idsasd = '916'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('916','MED/12',null,'10',{d '2019-02-28'},'ASSISTENZA','GASTROENTEROLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '917')
UPDATE [sasd] SET codice = 'MED/13',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ENDOCRINOLOGIA' WHERE idsasd = '917'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('917','MED/13',null,'10',{d '2019-02-28'},'ASSISTENZA','ENDOCRINOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '918')
UPDATE [sasd] SET codice = 'MED/14',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'NEFROLOGIA' WHERE idsasd = '918'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('918','MED/14',null,'10',{d '2019-02-28'},'ASSISTENZA','NEFROLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '919')
UPDATE [sasd] SET codice = 'MED/15',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE DEL SANGUE' WHERE idsasd = '919'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('919','MED/15',null,'10',{d '2019-02-28'},'ASSISTENZA','MALATTIE DEL SANGUE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '920')
UPDATE [sasd] SET codice = 'MED/16',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'REUMATOLOGIA' WHERE idsasd = '920'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('920','MED/16',null,'10',{d '2019-02-28'},'ASSISTENZA','REUMATOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '921')
UPDATE [sasd] SET codice = 'MED/17',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE INFETTIVE' WHERE idsasd = '921'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('921','MED/17',null,'10',{d '2019-02-28'},'ASSISTENZA','MALATTIE INFETTIVE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '922')
UPDATE [sasd] SET codice = 'MED/18',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIRURGIA GENERALE' WHERE idsasd = '922'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('922','MED/18',null,'10',{d '2019-02-28'},'ASSISTENZA','CHIRURGIA GENERALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '923')
UPDATE [sasd] SET codice = 'MED/19',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIRURGIA PLASTICA' WHERE idsasd = '923'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('923','MED/19',null,'10',{d '2019-02-28'},'ASSISTENZA','CHIRURGIA PLASTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '924')
UPDATE [sasd] SET codice = 'MED/20',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIRURGIA PEDIATRICA E INFANTILE' WHERE idsasd = '924'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('924','MED/20',null,'10',{d '2019-02-28'},'ASSISTENZA','CHIRURGIA PEDIATRICA E INFANTILE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '925')
UPDATE [sasd] SET codice = 'MED/21',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIRURGIA TORACICA' WHERE idsasd = '925'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('925','MED/21',null,'10',{d '2019-02-28'},'ASSISTENZA','CHIRURGIA TORACICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '926')
UPDATE [sasd] SET codice = 'MED/22',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIRURGIA VASCOLARE' WHERE idsasd = '926'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('926','MED/22',null,'10',{d '2019-02-28'},'ASSISTENZA','CHIRURGIA VASCOLARE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '927')
UPDATE [sasd] SET codice = 'MED/23',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIRURGIA CARDIACA' WHERE idsasd = '927'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('927','MED/23',null,'10',{d '2019-02-28'},'ASSISTENZA','CHIRURGIA CARDIACA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '928')
UPDATE [sasd] SET codice = 'MED/24',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'UROLOGIA' WHERE idsasd = '928'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('928','MED/24',null,'10',{d '2019-02-28'},'ASSISTENZA','UROLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '929')
UPDATE [sasd] SET codice = 'MED/25',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PSICHIATRIA' WHERE idsasd = '929'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('929','MED/25',null,'10',{d '2019-02-28'},'ASSISTENZA','PSICHIATRIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '930')
UPDATE [sasd] SET codice = 'MED/26',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'NEUROLOGIA' WHERE idsasd = '930'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('930','MED/26',null,'10',{d '2019-02-28'},'ASSISTENZA','NEUROLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '931')
UPDATE [sasd] SET codice = 'MED/27',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'NEUROCHIRURGIA' WHERE idsasd = '931'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('931','MED/27',null,'10',{d '2019-02-28'},'ASSISTENZA','NEUROCHIRURGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '932')
UPDATE [sasd] SET codice = 'MED/28',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE ODONTOSTOMATOLOGICHE' WHERE idsasd = '932'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('932','MED/28',null,'10',{d '2019-02-28'},'ASSISTENZA','MALATTIE ODONTOSTOMATOLOGICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '933')
UPDATE [sasd] SET codice = 'MED/29',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CHIRURGIA MAXILLOFACCIALE' WHERE idsasd = '933'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('933','MED/29',null,'10',{d '2019-02-28'},'ASSISTENZA','CHIRURGIA MAXILLOFACCIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '934')
UPDATE [sasd] SET codice = 'MED/30',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE APPARATO VISIVO' WHERE idsasd = '934'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('934','MED/30',null,'10',{d '2019-02-28'},'ASSISTENZA','MALATTIE APPARATO VISIVO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '935')
UPDATE [sasd] SET codice = 'MED/31',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'OTORINOLARINGOIATRIA' WHERE idsasd = '935'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('935','MED/31',null,'10',{d '2019-02-28'},'ASSISTENZA','OTORINOLARINGOIATRIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '936')
UPDATE [sasd] SET codice = 'MED/32',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'AUDIOLOGIA' WHERE idsasd = '936'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('936','MED/32',null,'10',{d '2019-02-28'},'ASSISTENZA','AUDIOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '937')
UPDATE [sasd] SET codice = 'MED/33',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE APPARATO LOCOMOTORE' WHERE idsasd = '937'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('937','MED/33',null,'10',{d '2019-02-28'},'ASSISTENZA','MALATTIE APPARATO LOCOMOTORE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '938')
UPDATE [sasd] SET codice = 'MED/34',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MEDICINA FISICA E RIABILITATIVA' WHERE idsasd = '938'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('938','MED/34',null,'10',{d '2019-02-28'},'ASSISTENZA','MEDICINA FISICA E RIABILITATIVA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '939')
UPDATE [sasd] SET codice = 'MED/35',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE CUTANEE E VENEREE' WHERE idsasd = '939'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('939','MED/35',null,'10',{d '2019-02-28'},'ASSISTENZA','MALATTIE CUTANEE E VENEREE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '940')
UPDATE [sasd] SET codice = 'MED/36',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DIAGNOSTICA PER IMMAGINI E RADIOTERAPIA' WHERE idsasd = '940'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('940','MED/36',null,'10',{d '2019-02-28'},'ASSISTENZA','DIAGNOSTICA PER IMMAGINI E RADIOTERAPIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '941')
UPDATE [sasd] SET codice = 'MED/37',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'NEURORADIOLOGIA' WHERE idsasd = '941'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('941','MED/37',null,'10',{d '2019-02-28'},'ASSISTENZA','NEURORADIOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '942')
UPDATE [sasd] SET codice = 'MED/38',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PEDIATRIA GENERALE E SPECIALISTICA' WHERE idsasd = '942'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('942','MED/38',null,'10',{d '2019-02-28'},'ASSISTENZA','PEDIATRIA GENERALE E SPECIALISTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '943')
UPDATE [sasd] SET codice = 'MED/39',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'NEUROPSICHIATRIA INFANTILE' WHERE idsasd = '943'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('943','MED/39',null,'10',{d '2019-02-28'},'ASSISTENZA','NEUROPSICHIATRIA INFANTILE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '944')
UPDATE [sasd] SET codice = 'MED/40',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'GINECOLOGIA E OSTETRICIA' WHERE idsasd = '944'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('944','MED/40',null,'10',{d '2019-02-28'},'ASSISTENZA','GINECOLOGIA E OSTETRICIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '945')
UPDATE [sasd] SET codice = 'MED/41',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANESTESIOLOGIA' WHERE idsasd = '945'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('945','MED/41',null,'10',{d '2019-02-28'},'ASSISTENZA','ANESTESIOLOGIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '946')
UPDATE [sasd] SET codice = 'MED/42',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'IGIENE GENERALE E APPLICATA' WHERE idsasd = '946'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('946','MED/42',null,'10',{d '2019-02-28'},'ASSISTENZA','IGIENE GENERALE E APPLICATA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '947')
UPDATE [sasd] SET codice = 'MED/43',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MEDICINA LEGALE' WHERE idsasd = '947'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('947','MED/43',null,'10',{d '2019-02-28'},'ASSISTENZA','MEDICINA LEGALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '948')
UPDATE [sasd] SET codice = 'MED/44',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MEDICINA DEL LAVORO' WHERE idsasd = '948'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('948','MED/44',null,'10',{d '2019-02-28'},'ASSISTENZA','MEDICINA DEL LAVORO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '949')
UPDATE [sasd] SET codice = 'MED/45',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZE INFERMIERISTICHE GENERALI, CLINICHE E PEDIATRICHE' WHERE idsasd = '949'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('949','MED/45',null,'10',{d '2019-02-28'},'ASSISTENZA','SCIENZE INFERMIERISTICHE GENERALI, CLINICHE E PEDIATRICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '950')
UPDATE [sasd] SET codice = 'MED/46',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZE TECNICHE DI MEDICINA E DI LABORATORIO' WHERE idsasd = '950'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('950','MED/46',null,'10',{d '2019-02-28'},'ASSISTENZA','SCIENZE TECNICHE DI MEDICINA E DI LABORATORIO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '951')
UPDATE [sasd] SET codice = 'MED/47',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZE INFERMIERISTICHE OSTETRICO-GINECOLOGICHE' WHERE idsasd = '951'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('951','MED/47',null,'10',{d '2019-02-28'},'ASSISTENZA','SCIENZE INFERMIERISTICHE OSTETRICO-GINECOLOGICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '952')
UPDATE [sasd] SET codice = 'MED/48',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZE INFERMIERISTICHE E TECNICHE NEURO-PSICHIATRICHE E RIABILITATIVE' WHERE idsasd = '952'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('952','MED/48',null,'10',{d '2019-02-28'},'ASSISTENZA','SCIENZE INFERMIERISTICHE E TECNICHE NEURO-PSICHIATRICHE E RIABILITATIVE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '953')
UPDATE [sasd] SET codice = 'MED/49',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZE TECNICHE DIETETICHE APPLICATE' WHERE idsasd = '953'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('953','MED/49',null,'10',{d '2019-02-28'},'ASSISTENZA','SCIENZE TECNICHE DIETETICHE APPLICATE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '954')
UPDATE [sasd] SET codice = 'MED/50',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZE TECNICHE MEDICHE E APPLICATE' WHERE idsasd = '954'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('954','MED/50',null,'10',{d '2019-02-28'},'ASSISTENZA','SCIENZE TECNICHE MEDICHE E APPLICATE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '955')
UPDATE [sasd] SET codice = 'MED/51',codice_old = null,idareadidattica = '10',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SOPPRESSO con DM 26.6.00 - ATTIVITA MOTORIE' WHERE idsasd = '955'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('955','MED/51',null,'10',{d '2019-02-28'},'ASSISTENZA','SOPPRESSO con DM 26.6.00 - ATTIVITA MOTORIE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '956')
UPDATE [sasd] SET codice = 'SECS-P/01',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ECONOMIA POLITICA' WHERE idsasd = '956'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('956','SECS-P/01',null,'17',{d '2019-02-28'},'ASSISTENZA','ECONOMIA POLITICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '957')
UPDATE [sasd] SET codice = 'SECS-P/02',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'POLITICA ECONOMICA' WHERE idsasd = '957'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('957','SECS-P/02',null,'17',{d '2019-02-28'},'ASSISTENZA','POLITICA ECONOMICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '958')
UPDATE [sasd] SET codice = 'SECS-P/03',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZA DELLE FINANZE' WHERE idsasd = '958'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('958','SECS-P/03',null,'17',{d '2019-02-28'},'ASSISTENZA','SCIENZA DELLE FINANZE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '959')
UPDATE [sasd] SET codice = 'SECS-P/04',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DEL PENSIERO ECONOMICO' WHERE idsasd = '959'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('959','SECS-P/04',null,'17',{d '2019-02-28'},'ASSISTENZA','STORIA DEL PENSIERO ECONOMICO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '960')
UPDATE [sasd] SET codice = 'SECS-P/05',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ECONOMETRIA' WHERE idsasd = '960'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('960','SECS-P/05',null,'17',{d '2019-02-28'},'ASSISTENZA','ECONOMETRIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '961')
UPDATE [sasd] SET codice = 'SECS-P/06',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ECONOMIA APPLICATA' WHERE idsasd = '961'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('961','SECS-P/06',null,'17',{d '2019-02-28'},'ASSISTENZA','ECONOMIA APPLICATA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '962')
UPDATE [sasd] SET codice = 'SECS-P/07',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ECONOMIA AZIENDALE' WHERE idsasd = '962'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('962','SECS-P/07',null,'17',{d '2019-02-28'},'ASSISTENZA','ECONOMIA AZIENDALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '963')
UPDATE [sasd] SET codice = 'SECS-P/08',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ECONOMIA E GESTIONE DELLE IMPRESE' WHERE idsasd = '963'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('963','SECS-P/08',null,'17',{d '2019-02-28'},'ASSISTENZA','ECONOMIA E GESTIONE DELLE IMPRESE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '964')
UPDATE [sasd] SET codice = 'SECS-P/09',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FINANZA AZIENDALE' WHERE idsasd = '964'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('964','SECS-P/09',null,'17',{d '2019-02-28'},'ASSISTENZA','FINANZA AZIENDALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '965')
UPDATE [sasd] SET codice = 'SECS-P/10',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ORGANIZZAZIONE AZIENDALE' WHERE idsasd = '965'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('965','SECS-P/10',null,'17',{d '2019-02-28'},'ASSISTENZA','ORGANIZZAZIONE AZIENDALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '966')
UPDATE [sasd] SET codice = 'SECS-P/11',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ECONOMIA DEGLI INTERMEDIARI FINANZIARI' WHERE idsasd = '966'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('966','SECS-P/11',null,'17',{d '2019-02-28'},'ASSISTENZA','ECONOMIA DEGLI INTERMEDIARI FINANZIARI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '967')
UPDATE [sasd] SET codice = 'SECS-P/12',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA ECONOMICA' WHERE idsasd = '967'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('967','SECS-P/12',null,'17',{d '2019-02-28'},'ASSISTENZA','STORIA ECONOMICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '968')
UPDATE [sasd] SET codice = 'SECS-P/13',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZE MERCEOLOGICHE' WHERE idsasd = '968'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('968','SECS-P/13',null,'17',{d '2019-02-28'},'ASSISTENZA','SCIENZE MERCEOLOGICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '969')
UPDATE [sasd] SET codice = 'SECS-S/01',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STATISTICA' WHERE idsasd = '969'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('969','SECS-S/01',null,'17',{d '2019-02-28'},'ASSISTENZA','STATISTICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '970')
UPDATE [sasd] SET codice = 'SECS-S/02',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STATISTICA PER LA RICERCA SPERIMENTALE E TECNOLOGICA' WHERE idsasd = '970'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('970','SECS-S/02',null,'17',{d '2019-02-28'},'ASSISTENZA','STATISTICA PER LA RICERCA SPERIMENTALE E TECNOLOGICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '971')
UPDATE [sasd] SET codice = 'SECS-S/03',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STATISTICA ECONOMICA' WHERE idsasd = '971'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('971','SECS-S/03',null,'17',{d '2019-02-28'},'ASSISTENZA','STATISTICA ECONOMICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '972')
UPDATE [sasd] SET codice = 'SECS-S/04',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'DEMOGRAFIA' WHERE idsasd = '972'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('972','SECS-S/04',null,'17',{d '2019-02-28'},'ASSISTENZA','DEMOGRAFIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '973')
UPDATE [sasd] SET codice = 'SECS-S/05',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STATISTICA SOCIALE' WHERE idsasd = '973'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('973','SECS-S/05',null,'17',{d '2019-02-28'},'ASSISTENZA','STATISTICA SOCIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '974')
UPDATE [sasd] SET codice = 'SECS-S/06',codice_old = null,idareadidattica = '17',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'METODI MATEMATICI DELL''ECONOMIA E DELLE SCIENZE ATTUARIALI E FINANZIARIE' WHERE idsasd = '974'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('974','SECS-S/06',null,'17',{d '2019-02-28'},'ASSISTENZA','METODI MATEMATICI DELL''ECONOMIA E DELLE SCIENZE ATTUARIALI E FINANZIARIE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '975')
UPDATE [sasd] SET codice = 'SPS/01',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FILOSOFIA POLITICA' WHERE idsasd = '975'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('975','SPS/01',null,'18',{d '2019-02-28'},'ASSISTENZA','FILOSOFIA POLITICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '976')
UPDATE [sasd] SET codice = 'SPS/02',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLE DOTTRINE POLITICHE' WHERE idsasd = '976'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('976','SPS/02',null,'18',{d '2019-02-28'},'ASSISTENZA','STORIA DELLE DOTTRINE POLITICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '977')
UPDATE [sasd] SET codice = 'SPS/03',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLE ISTITUZIONI POLITICHE' WHERE idsasd = '977'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('977','SPS/03',null,'18',{d '2019-02-28'},'ASSISTENZA','STORIA DELLE ISTITUZIONI POLITICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '978')
UPDATE [sasd] SET codice = 'SPS/04',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SCIENZA POLITICA' WHERE idsasd = '978'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('978','SPS/04',null,'18',{d '2019-02-28'},'ASSISTENZA','SCIENZA POLITICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '979')
UPDATE [sasd] SET codice = 'SPS/05',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA E ISTITUZIONI DELLE AMERICHE' WHERE idsasd = '979'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('979','SPS/05',null,'18',{d '2019-02-28'},'ASSISTENZA','STORIA E ISTITUZIONI DELLE AMERICHE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '980')
UPDATE [sasd] SET codice = 'SPS/06',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA DELLE RELAZIONI INTERNAZIONALI' WHERE idsasd = '980'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('980','SPS/06',null,'18',{d '2019-02-28'},'ASSISTENZA','STORIA DELLE RELAZIONI INTERNAZIONALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '981')
UPDATE [sasd] SET codice = 'SPS/07',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SOCIOLOGIA GENERALE' WHERE idsasd = '981'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('981','SPS/07',null,'18',{d '2019-02-28'},'ASSISTENZA','SOCIOLOGIA GENERALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '982')
UPDATE [sasd] SET codice = 'SPS/08',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SOCIOLOGIA DEI PROCESSI CULTURALI E COMUNICATIVI' WHERE idsasd = '982'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('982','SPS/08',null,'18',{d '2019-02-28'},'ASSISTENZA','SOCIOLOGIA DEI PROCESSI CULTURALI E COMUNICATIVI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '983')
UPDATE [sasd] SET codice = 'SPS/09',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SOCIOLOGIA DEI PROCESSI ECONOMICI E DEL LAVORO' WHERE idsasd = '983'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('983','SPS/09',null,'18',{d '2019-02-28'},'ASSISTENZA','SOCIOLOGIA DEI PROCESSI ECONOMICI E DEL LAVORO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '984')
UPDATE [sasd] SET codice = 'SPS/10',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SOCIOLOGIA DELL''AMBIENTE E DEL TERRITORIO' WHERE idsasd = '984'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('984','SPS/10',null,'18',{d '2019-02-28'},'ASSISTENZA','SOCIOLOGIA DELL''AMBIENTE E DEL TERRITORIO')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '985')
UPDATE [sasd] SET codice = 'SPS/11',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SOCIOLOGIA DEI FENOMENI POLITICI' WHERE idsasd = '985'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('985','SPS/11',null,'18',{d '2019-02-28'},'ASSISTENZA','SOCIOLOGIA DEI FENOMENI POLITICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '986')
UPDATE [sasd] SET codice = 'SPS/12',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'SOCIOLOGIA GIURIDICA, DELLA DEVIANZA E MUTAMENTO SOCIALE' WHERE idsasd = '986'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('986','SPS/12',null,'18',{d '2019-02-28'},'ASSISTENZA','SOCIOLOGIA GIURIDICA, DELLA DEVIANZA E MUTAMENTO SOCIALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '987')
UPDATE [sasd] SET codice = 'SPS/13',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA E ISTITUZIONI DELL''AFRICA' WHERE idsasd = '987'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('987','SPS/13',null,'18',{d '2019-02-28'},'ASSISTENZA','STORIA E ISTITUZIONI DELL''AFRICA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '988')
UPDATE [sasd] SET codice = 'SPS/14',codice_old = null,idareadidattica = '18',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'STORIA E ISTITUZIONI DELL''ASIA' WHERE idsasd = '988'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('988','SPS/14',null,'18',{d '2019-02-28'},'ASSISTENZA','STORIA E ISTITUZIONI DELL''ASIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '989')
UPDATE [sasd] SET codice = 'VET/01',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ANATOMIA DEGLI ANIMALI DOMESTICI' WHERE idsasd = '989'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('989','VET/01',null,'11',{d '2019-02-28'},'ASSISTENZA','ANATOMIA DEGLI ANIMALI DOMESTICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '990')
UPDATE [sasd] SET codice = 'VET/02',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FISIOLOGIA VETERINARIA' WHERE idsasd = '990'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('990','VET/02',null,'11',{d '2019-02-28'},'ASSISTENZA','FISIOLOGIA VETERINARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '991')
UPDATE [sasd] SET codice = 'VET/03',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PATOLOGIA GENERALE E ANATOMIA PATOLOGICA VETERINARIA' WHERE idsasd = '991'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('991','VET/03',null,'11',{d '2019-02-28'},'ASSISTENZA','PATOLOGIA GENERALE E ANATOMIA PATOLOGICA VETERINARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '992')
UPDATE [sasd] SET codice = 'VET/04',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'ISPEZIONE DEGLI ALIMENTI DI ORIGINE ANIMALE' WHERE idsasd = '992'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('992','VET/04',null,'11',{d '2019-02-28'},'ASSISTENZA','ISPEZIONE DEGLI ALIMENTI DI ORIGINE ANIMALE')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '993')
UPDATE [sasd] SET codice = 'VET/05',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'MALATTIE INFETTIVE DEGLI ANIMALI DOMESTICI' WHERE idsasd = '993'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('993','VET/05',null,'11',{d '2019-02-28'},'ASSISTENZA','MALATTIE INFETTIVE DEGLI ANIMALI DOMESTICI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '994')
UPDATE [sasd] SET codice = 'VET/06',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'PARASSITOLOGIA E MALATTIE PARASSITARIE DEGLI ANIMALI' WHERE idsasd = '994'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('994','VET/06',null,'11',{d '2019-02-28'},'ASSISTENZA','PARASSITOLOGIA E MALATTIE PARASSITARIE DEGLI ANIMALI')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '995')
UPDATE [sasd] SET codice = 'VET/07',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'FARMACOLOGIA E TOSSICOLOGIA VETERINARIA' WHERE idsasd = '995'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('995','VET/07',null,'11',{d '2019-02-28'},'ASSISTENZA','FARMACOLOGIA E TOSSICOLOGIA VETERINARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '996')
UPDATE [sasd] SET codice = 'VET/08',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CLINICA MEDICA VETERINARIA' WHERE idsasd = '996'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('996','VET/08',null,'11',{d '2019-02-28'},'ASSISTENZA','CLINICA MEDICA VETERINARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '997')
UPDATE [sasd] SET codice = 'VET/09',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CLINICA CHIRURGICA VETERINARIA' WHERE idsasd = '997'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('997','VET/09',null,'11',{d '2019-02-28'},'ASSISTENZA','CLINICA CHIRURGICA VETERINARIA')
GO

IF exists(SELECT * FROM [sasd] WHERE idsasd = '998')
UPDATE [sasd] SET codice = 'VET/10',codice_old = null,idareadidattica = '11',lt = {d '2019-02-28'},lu = 'ASSISTENZA',title = 'CLINICA OSTETRICA E GINECOLOGIA VETERINARIA' WHERE idsasd = '998'
ELSE
INSERT INTO [sasd] (idsasd,codice,codice_old,idareadidattica,lt,lu,title) VALUES ('998','VET/10',null,'11',{d '2019-02-28'},'ASSISTENZA','CLINICA OSTETRICA E GINECOLOGIA VETERINARIA')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sasd')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR dei settori artistico-scientifico disciplinari',idapplication = null,isdbo = 'N',lt = {ts '2019-02-06 11:57:15.200'},lu = 'assistenza',title = 'Settori artistico-scientifico disciplinari' WHERE tablename = 'sasd'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sasd','VOCABOLARIO MIUR dei settori artistico-scientifico disciplinari',null,'N',{ts '2019-02-06 11:57:15.200'},'assistenza','Settori artistico-scientifico disciplinari')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:32:31.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','sasd','50',null,null,null,'S',{ts '2018-07-17 17:32:31.480'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice_old' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice legge precedente',kind = 'S',lt = {ts '2019-01-25 17:43:28.590'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(4)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice_old' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice_old','sasd','4',null,null,'Codice legge precedente','S',{ts '2019-01-25 17:43:28.590'},'assistenza','N','varchar(4)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idareadidattica' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Area o ambito disciplinare',kind = 'S',lt = {ts '2018-12-10 16:56:54.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idareadidattica' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idareadidattica','sasd','4',null,null,'Area o ambito disciplinare','S',{ts '2018-12-10 16:56:54.257'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-21 18:44:47.123'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','sasd','4',null,null,'Codice Istituto','S',{ts '2018-11-21 18:44:47.123'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-10 16:38:35.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','sasd','8',null,null,null,'S',{ts '2018-12-10 16:38:35.547'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-10 16:38:35.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','sasd','64',null,null,null,'S',{ts '2018-12-10 16:38:35.547'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = 'Settore Artistico Scientifico Disciplinare',kind = 'S',lt = {ts '2018-12-10 16:56:54.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','sasd','255',null,null,'Settore Artistico Scientifico Disciplinare','S',{ts '2018-12-10 16:56:54.257'},'assistenza','N','varchar(255)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

