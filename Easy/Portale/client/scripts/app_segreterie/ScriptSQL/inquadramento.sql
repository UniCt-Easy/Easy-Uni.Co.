
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


-- CREAZIONE TABELLA inquadramento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inquadramento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inquadramento] (
idinquadramento int NOT NULL,
idcontrattokind int NOT NULL,
costolordoannuo decimal(9,2) NULL,
costolordoannuooneri decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
siglaimportazione varchar(1024) NULL,
start datetime NULL,
stop datetime NULL,
tempdef char(1) NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkinquadramento PRIMARY KEY (idinquadramento,
idcontrattokind
)
)
END
GO

-- VERIFICA STRUTTURA inquadramento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD idinquadramento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'idinquadramento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'costolordoannuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD costolordoannuo decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN costolordoannuo decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'costolordoannuooneri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD costolordoannuooneri decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN costolordoannuooneri decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'siglaimportazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD siglaimportazione varchar(1024) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN siglaimportazione varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD start datetime NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN start datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD stop datetime NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN stop datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD tempdef char(1) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN tempdef char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN title varchar(2048) NULL
GO

-- VERIFICA DI inquadramento IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inquadramento'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','int','assistenza','idcontrattokind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','int','assistenza','idinquadramento','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramento','decimal(9,2)','Generator','costolordoannuo','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramento','decimal(9,2)','Generator','costolordoannuooneri','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramento','varchar(1024)','Generator','siglaimportazione','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramento','datetime','assistenza','start','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramento','datetime','assistenza','stop','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramento','char(1)','assistenza','tempdef','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramento','varchar(2048)','assistenza','title','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI inquadramento IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inquadramento')
UPDATE customobject set isreal = 'S' where objectname = 'inquadramento'
ELSE
INSERT INTO customobject (objectname, isreal) values('inquadramento', 'S')
GO

-- GENERAZIONE DATI PER inquadramento --
IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '1')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2020-07-15 10:15:12.097'},cu = 'riccardotest{0001}',lt = {ts '2020-07-15 10:16:15.640'},lu = 'riccardotest{0001}',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'I progetto economico - classe 0' WHERE idcontrattokind = '1' AND idinquadramento = '1'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','1',null,null,{ts '2020-07-15 10:15:12.097'},'riccardotest{0001}',{ts '2020-07-15 10:16:15.640'},'riccardotest{0001}',null,null,null,null,'I progetto economico - classe 0')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '2')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2020-07-15 10:16:15.543'},cu = 'riccardotest{0001}',lt = {ts '2021-07-01 17:43:21.487'},lu = 'ferdinando.giannetti{SEGPRG}',siglaimportazione = null,start = {d '2019-01-01'},stop = null,tempdef = 'N',title = 'Vecchio regime' WHERE idcontrattokind = '1' AND idinquadramento = '2'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','2',null,null,{ts '2020-07-15 10:16:15.543'},'riccardotest{0001}',{ts '2021-07-01 17:43:21.487'},'ferdinando.giannetti{SEGPRG}',null,{d '2019-01-01'},null,'N','Vecchio regime')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '12' AND idinquadramento = '4')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-07-01 16:41:19.890'},cu = 'ferdinando.giannetti{SEGPRG}',lt = {ts '2021-07-01 16:41:19.890'},lu = 'ferdinando.giannetti{SEGPRG}',siglaimportazione = null,start = {d '2019-01-01'},stop = null,tempdef = 'N',title = 'Vecchio regime' WHERE idcontrattokind = '12' AND idinquadramento = '4'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('12','4',null,null,{ts '2021-07-01 16:41:19.890'},'ferdinando.giannetti{SEGPRG}',{ts '2021-07-01 16:41:19.890'},'ferdinando.giannetti{SEGPRG}',null,{d '2019-01-01'},null,'N','Vecchio regime')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '6')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:14:50.513'},cu = 'Ferdinando',lt = {ts '2021-11-10 13:07:56.563'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Prof.Associato DPR 232/11 art.2' WHERE idcontrattokind = '2' AND idinquadramento = '6'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','6',null,null,{ts '2021-10-20 15:14:50.513'},'Ferdinando',{ts '2021-11-10 13:07:56.563'},'ferdinando.giannetti{SEGADM}',null,null,null,'N','Prof.Associato DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '7')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.867'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.867'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'S',title = 'DPR 232/11 art.2' WHERE idcontrattokind = '2' AND idinquadramento = '7'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','7',null,null,{ts '2021-10-20 15:15:32.867'},'Ferdinando',{ts '2021-10-20 15:15:32.867'},'Ferdinando',null,null,null,'S','DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '8')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.867'},cu = 'Ferdinando',lt = {ts '2021-11-10 13:09:52.147'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Prof.Associato Legge 240/10' WHERE idcontrattokind = '2' AND idinquadramento = '8'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','8',null,null,{ts '2021-10-20 15:15:32.867'},'Ferdinando',{ts '2021-11-10 13:09:52.147'},'ferdinando.giannetti{SEGADM}',null,null,null,'N','Prof.Associato Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '9')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-11-10 13:15:41.417'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Prof.Ordinario DPR 232/11 art.2' WHERE idcontrattokind = '1' AND idinquadramento = '9'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','9',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-11-10 13:15:41.417'},'ferdinando.giannetti{SEGADM}',null,null,null,'N','Prof.Ordinario DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '10')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.870'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Legge 240/10' WHERE idcontrattokind = '1' AND idinquadramento = '10'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','10',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-10-20 15:15:32.870'},'Ferdinando',null,null,null,'N','Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '11')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.870'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'S',title = 'DPR 232/11 art.2' WHERE idcontrattokind = '1' AND idinquadramento = '11'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','11',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-10-20 15:15:32.870'},'Ferdinando',null,null,null,'S','DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '12')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.870'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'S',title = 'DPR 232/11 art.2' WHERE idcontrattokind = '7' AND idinquadramento = '12'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','12',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-10-20 15:15:32.870'},'Ferdinando',null,null,null,'S','DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '13')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.870'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'DPR 232/11 art.2' WHERE idcontrattokind = '7' AND idinquadramento = '13'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','13',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-10-20 15:15:32.870'},'Ferdinando',null,null,null,'N','DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '14')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:38:22.327'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:38:22.327'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'S',title = 'Legge 240/10' WHERE idcontrattokind = '2' AND idinquadramento = '14'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','14',null,null,{ts '2021-10-20 15:38:22.327'},'Ferdinando',{ts '2021-10-20 15:38:22.327'},'Ferdinando',null,null,null,'S','Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '15')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'B ' WHERE idcontrattokind = '20' AND idinquadramento = '15'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','15',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'B ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '16')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'C ' WHERE idcontrattokind = '19' AND idinquadramento = '16'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','16',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'C ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '17')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'D ' WHERE idcontrattokind = '18' AND idinquadramento = '17'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','17',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'D ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '14' AND idinquadramento = '18')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'Dir.' WHERE idcontrattokind = '14' AND idinquadramento = '18'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('14','18',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'Dir.')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '19')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'EP' WHERE idcontrattokind = '17' AND idinquadramento = '19'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','19',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'EP')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '26')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-10 12:54:31.827'},cu = 'ferdinando.giannetti{SEGADM}',lt = {ts '2021-11-10 12:58:10.070'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Inq. unico C' WHERE idcontrattokind = '19' AND idinquadramento = '26'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','26',null,null,{ts '2021-11-10 12:54:31.827'},'ferdinando.giannetti{SEGADM}',{ts '2021-11-10 12:58:10.070'},'ferdinando.giannetti{SEGADM}',null,null,null,'N','Inq. unico C')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '27')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-10 12:56:51.327'},cu = 'ferdinando.giannetti{SEGADM}',lt = {ts '2021-11-10 12:58:22.247'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'Inq. unico B' WHERE idcontrattokind = '20' AND idinquadramento = '27'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','27',null,null,{ts '2021-11-10 12:56:51.327'},'ferdinando.giannetti{SEGADM}',{ts '2021-11-10 12:58:22.247'},'ferdinando.giannetti{SEGADM}',null,null,null,null,'Inq. unico B')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '38')
UPDATE [inquadramento] SET costolordoannuo = '96186.12',costolordoannuooneri = '132978.03',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)TD:N contratto:Professori associati',start = null,stop = null,tempdef = 'N',title = 'nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)' WHERE idcontrattokind = '2' AND idinquadramento = '38'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','38','96186.12','132978.03',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)TD:N contratto:Professori associati',null,null,'N','nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '39')
UPDATE [inquadramento] SET costolordoannuo = '131674.55',costolordoannuooneri = '182067.81',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)TD:N contratto:Professori ordinari',start = null,stop = null,tempdef = 'N',title = 'nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)' WHERE idcontrattokind = '1' AND idinquadramento = '39'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','39','131674.55','182067.81',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)TD:N contratto:Professori ordinari',null,null,'N','nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '40')
UPDATE [inquadramento] SET costolordoannuo = '54410.91',costolordoannuooneri = '76776.41',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)TD:S contratto:Professori associati',start = null,stop = null,tempdef = 'S',title = 'nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)' WHERE idcontrattokind = '2' AND idinquadramento = '40'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','40','54410.91','76776.41',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)TD:S contratto:Professori associati',null,null,'S','nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '41')
UPDATE [inquadramento] SET costolordoannuo = '72311.41',costolordoannuooneri = '102229.37',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)TD:S contratto:Professori ordinari',start = null,stop = null,tempdef = 'S',title = 'nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)' WHERE idcontrattokind = '1' AND idinquadramento = '41'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','41','72311.41','102229.37',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)TD:S contratto:Professori ordinari',null,null,'S','nuovo-regime (art.3 comma 2 e 6 del d.p.r.15-12-2011 n.232)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '42')
UPDATE [inquadramento] SET costolordoannuo = '96186.11',costolordoannuooneri = '132978.02',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)TD:N contratto:Professori associati',start = null,stop = null,tempdef = 'N',title = 'Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)' WHERE idcontrattokind = '2' AND idinquadramento = '42'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','42','96186.11','132978.02',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)TD:N contratto:Professori associati',null,null,'N','Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '43')
UPDATE [inquadramento] SET costolordoannuo = '131674.56',costolordoannuooneri = '182067.82',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)TD:N contratto:Professori ordinari',start = null,stop = null,tempdef = 'N',title = 'Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)' WHERE idcontrattokind = '1' AND idinquadramento = '43'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','43','131674.56','182067.82',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)TD:N contratto:Professori ordinari',null,null,'N','Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '44')
UPDATE [inquadramento] SET costolordoannuo = '54410.91',costolordoannuooneri = '76776.41',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)TD:S contratto:Professori associati',start = null,stop = null,tempdef = 'S',title = 'Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)' WHERE idcontrattokind = '2' AND idinquadramento = '44'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','44','54410.91','76776.41',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)TD:S contratto:Professori associati',null,null,'S','Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '45')
UPDATE [inquadramento] SET costolordoannuo = '72311.41',costolordoannuooneri = '102229.38',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)TD:S contratto:Professori ordinari',start = null,stop = null,tempdef = 'S',title = 'Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)' WHERE idcontrattokind = '1' AND idinquadramento = '45'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','45','72311.41','102229.38',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)TD:S contratto:Professori ordinari',null,null,'S','Regime previgente (art. 2 e 4 del D.P.R. 15/12/2011 n.232)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '46')
UPDATE [inquadramento] SET costolordoannuo = '71261.35',costolordoannuooneri = '98502.4',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'RICERCATORE ( RUOLO AD ESAURIMENTO)TD:N contratto:Ricercatori Universitari',start = null,stop = null,tempdef = 'N',title = 'RICERCATORE ( RUOLO AD ESAURIMENTO)' WHERE idcontrattokind = '7' AND idinquadramento = '46'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','46','71261.35','98502.4',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','RICERCATORE ( RUOLO AD ESAURIMENTO)TD:N contratto:Ricercatori Universitari',null,null,'N','RICERCATORE ( RUOLO AD ESAURIMENTO)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '47')
UPDATE [inquadramento] SET costolordoannuo = '41896.91',costolordoannuooneri = '58981.58',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'RICERCATORE ( RUOLO AD ESAURIMENTO)TD:S contratto:Ricercatori Universitari',start = null,stop = null,tempdef = 'S',title = 'RICERCATORE ( RUOLO AD ESAURIMENTO)' WHERE idcontrattokind = '7' AND idinquadramento = '47'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','47','41896.91','58981.58',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','RICERCATORE ( RUOLO AD ESAURIMENTO)TD:S contratto:Ricercatori Universitari',null,null,'S','RICERCATORE ( RUOLO AD ESAURIMENTO)')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '48')
UPDATE [inquadramento] SET costolordoannuo = '36344.04',costolordoannuooneri = '50397.1',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera aTD:N contratto:Ricercatori Universitari',start = null,stop = null,tempdef = 'N',title = 'RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera a' WHERE idcontrattokind = '7' AND idinquadramento = '48'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','48','36344.04','50397.1',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera aTD:N contratto:Ricercatori Universitari',null,null,'N','RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera a')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '49')
UPDATE [inquadramento] SET costolordoannuo = '26366.9',costolordoannuooneri = '37291.21',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera aTD:S contratto:Ricercatori Universitari',start = null,stop = null,tempdef = 'S',title = 'RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera a' WHERE idcontrattokind = '7' AND idinquadramento = '49'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','49','26366.9','37291.21',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera aTD:S contratto:Ricercatori Universitari',null,null,'S','RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera a')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '50')
UPDATE [inquadramento] SET costolordoannuo = '43612.84',costolordoannuooneri = '61053.61',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera bTD:N contratto:Ricercatori Universitari',start = null,stop = null,tempdef = 'N',title = 'RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera b' WHERE idcontrattokind = '7' AND idinquadramento = '50'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','50','43612.84','61053.61',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera bTD:N contratto:Ricercatori Universitari',null,null,'N','RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera b')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '51')
UPDATE [inquadramento] SET costolordoannuo = '31640.27',costolordoannuooneri = '44293.22',ct = {ts '2021-12-09 17:33:40.650'},cu = 'import_stipendi',lt = {ts '2021-12-09 17:33:40.650'},lu = 'import_stipendi',siglaimportazione = 'RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera bTD:S contratto:Ricercatori Universitari',start = null,stop = null,tempdef = 'S',title = 'RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera b' WHERE idcontrattokind = '7' AND idinquadramento = '51'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','51','31640.27','44293.22',{ts '2021-12-09 17:33:40.650'},'import_stipendi',{ts '2021-12-09 17:33:40.650'},'import_stipendi','RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera bTD:S contratto:Ricercatori Universitari',null,null,'S','RICERCATORI A TEMPO DETERMINATO L. 240/2010 art. 24 comma 3 lettera b')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '52')
UPDATE [inquadramento] SET costolordoannuo = '20049',costolordoannuooneri = '27743.81',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'B1',start = null,stop = null,tempdef = null,title = 'B1' WHERE idcontrattokind = '20' AND idinquadramento = '52'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','52','20049','27743.81',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','B1',null,null,null,'B1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '53')
UPDATE [inquadramento] SET costolordoannuo = '21233.76',costolordoannuooneri = '29383.27',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'B2',start = null,stop = null,tempdef = null,title = 'B2' WHERE idcontrattokind = '20' AND idinquadramento = '53'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','53','21233.76','29383.27',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','B2',null,null,null,'B2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '54')
UPDATE [inquadramento] SET costolordoannuo = '22110.26',costolordoannuooneri = '30596.17',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'B3',start = null,stop = null,tempdef = null,title = 'B3' WHERE idcontrattokind = '20' AND idinquadramento = '54'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','54','22110.26','30596.17',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','B3',null,null,null,'B3')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '55')
UPDATE [inquadramento] SET costolordoannuo = '23030.9',costolordoannuooneri = '31870.16',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'B4',start = null,stop = null,tempdef = null,title = 'B4' WHERE idcontrattokind = '20' AND idinquadramento = '55'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','55','23030.9','31870.16',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','B4',null,null,null,'B4')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '56')
UPDATE [inquadramento] SET costolordoannuo = '23870.96',costolordoannuooneri = '33032.63',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'B5',start = null,stop = null,tempdef = null,title = 'B5' WHERE idcontrattokind = '20' AND idinquadramento = '56'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','56','23870.96','33032.63',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','B5',null,null,null,'B5')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '57')
UPDATE [inquadramento] SET costolordoannuo = '24736.74',costolordoannuooneri = '34230.7',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'B6',start = null,stop = null,tempdef = null,title = 'B6' WHERE idcontrattokind = '20' AND idinquadramento = '57'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','57','24736.74','34230.7',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','B6',null,null,null,'B6')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '58')
UPDATE [inquadramento] SET costolordoannuo = '25331.99',costolordoannuooneri = '35054.41',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'B7',start = null,stop = null,tempdef = null,title = 'B7' WHERE idcontrattokind = '20' AND idinquadramento = '58'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','58','25331.99','35054.41',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','B7',null,null,null,'B7')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '59')
UPDATE [inquadramento] SET costolordoannuo = '23143.49',costolordoannuooneri = '32025.97',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'C1',start = null,stop = null,tempdef = null,title = 'C1' WHERE idcontrattokind = '19' AND idinquadramento = '59'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','59','23143.49','32025.97',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','C1',null,null,null,'C1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '60')
UPDATE [inquadramento] SET costolordoannuo = '23563.98',costolordoannuooneri = '32607.84',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'C2',start = null,stop = null,tempdef = null,title = 'C2' WHERE idcontrattokind = '19' AND idinquadramento = '60'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','60','23563.98','32607.84',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','C2',null,null,null,'C2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '61')
UPDATE [inquadramento] SET costolordoannuo = '24243.42',costolordoannuooneri = '33548.04',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'C3',start = null,stop = null,tempdef = null,title = 'C3' WHERE idcontrattokind = '19' AND idinquadramento = '61'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','61','24243.42','33548.04',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','C3',null,null,null,'C3')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '62')
UPDATE [inquadramento] SET costolordoannuo = '25609.59',costolordoannuooneri = '35438.55',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'C4',start = null,stop = null,tempdef = null,title = 'C4' WHERE idcontrattokind = '19' AND idinquadramento = '62'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','62','25609.59','35438.55',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','C4',null,null,null,'C4')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '63')
UPDATE [inquadramento] SET costolordoannuo = '26370.72',costolordoannuooneri = '36491.8',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'C5',start = null,stop = null,tempdef = null,title = 'C5' WHERE idcontrattokind = '19' AND idinquadramento = '63'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','63','26370.72','36491.8',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','C5',null,null,null,'C5')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '64')
UPDATE [inquadramento] SET costolordoannuo = '27176.58',costolordoannuooneri = '37606.95',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'C6',start = null,stop = null,tempdef = null,title = 'C6' WHERE idcontrattokind = '19' AND idinquadramento = '64'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','64','27176.58','37606.95',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','C6',null,null,null,'C6')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '65')
UPDATE [inquadramento] SET costolordoannuo = '28001.18',costolordoannuooneri = '38748.03',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'C7',start = null,stop = null,tempdef = null,title = 'C7' WHERE idcontrattokind = '19' AND idinquadramento = '65'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','65','28001.18','38748.03',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','C7',null,null,null,'C7')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '66')
UPDATE [inquadramento] SET costolordoannuo = '28813.48',costolordoannuooneri = '39872.1',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'C8',start = null,stop = null,tempdef = null,title = 'C8' WHERE idcontrattokind = '19' AND idinquadramento = '66'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','66','28813.48','39872.1',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','C8',null,null,null,'C8')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '67')
UPDATE [inquadramento] SET costolordoannuo = '27333.41',costolordoannuooneri = '37823.98',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'D1',start = null,stop = null,tempdef = null,title = 'D1' WHERE idcontrattokind = '18' AND idinquadramento = '67'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','67','27333.41','37823.98',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','D1',null,null,null,'D1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '68')
UPDATE [inquadramento] SET costolordoannuo = '28323.53',costolordoannuooneri = '39194.11',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'D2',start = null,stop = null,tempdef = null,title = 'D2' WHERE idcontrattokind = '18' AND idinquadramento = '68'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','68','28323.53','39194.11',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','D2',null,null,null,'D2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '69')
UPDATE [inquadramento] SET costolordoannuo = '29411.64',costolordoannuooneri = '40699.83',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'D3',start = null,stop = null,tempdef = null,title = 'D3' WHERE idcontrattokind = '18' AND idinquadramento = '69'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','69','29411.64','40699.83',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','D3',null,null,null,'D3')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '70')
UPDATE [inquadramento] SET costolordoannuo = '30856.85',costolordoannuooneri = '42699.71',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'D4',start = null,stop = null,tempdef = null,title = 'D4' WHERE idcontrattokind = '18' AND idinquadramento = '70'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','70','30856.85','42699.71',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','D4',null,null,null,'D4')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '71')
UPDATE [inquadramento] SET costolordoannuo = '31897.36',costolordoannuooneri = '44139.56',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'D5',start = null,stop = null,tempdef = null,title = 'D5' WHERE idcontrattokind = '18' AND idinquadramento = '71'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','71','31897.36','44139.56',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','D5',null,null,null,'D5')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '72')
UPDATE [inquadramento] SET costolordoannuo = '33002.91',costolordoannuooneri = '45669.43',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'D6',start = null,stop = null,tempdef = null,title = 'D6' WHERE idcontrattokind = '18' AND idinquadramento = '72'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','72','33002.91','45669.43',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','D6',null,null,null,'D6')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '73')
UPDATE [inquadramento] SET costolordoannuo = '34154.77',costolordoannuooneri = '47263.36',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'D7',start = null,stop = null,tempdef = null,title = 'D7' WHERE idcontrattokind = '18' AND idinquadramento = '73'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','73','34154.77','47263.36',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','D7',null,null,null,'D7')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '18' AND idinquadramento = '74')
UPDATE [inquadramento] SET costolordoannuo = '35136.01',costolordoannuooneri = '48621.2',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'D8',start = null,stop = null,tempdef = null,title = 'D8' WHERE idcontrattokind = '18' AND idinquadramento = '74'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('18','74','35136.01','48621.2',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','D8',null,null,null,'D8')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '75')
UPDATE [inquadramento] SET costolordoannuo = '30890.33',costolordoannuooneri = '42746.04',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP1',start = null,stop = null,tempdef = null,title = 'EP1' WHERE idcontrattokind = '17' AND idinquadramento = '75'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','75','30890.33','42746.04',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','EP1',null,null,null,'EP1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '76')
UPDATE [inquadramento] SET costolordoannuo = '32747.55',costolordoannuooneri = '45316.06',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP2',start = null,stop = null,tempdef = null,title = 'EP2' WHERE idcontrattokind = '17' AND idinquadramento = '76'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','76','32747.55','45316.06',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','EP2',null,null,null,'EP2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '77')
UPDATE [inquadramento] SET costolordoannuo = '34508.9',costolordoannuooneri = '47753.41',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP3',start = null,stop = null,tempdef = null,title = 'EP3' WHERE idcontrattokind = '17' AND idinquadramento = '77'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','77','34508.9','47753.41',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','EP3',null,null,null,'EP3')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '78')
UPDATE [inquadramento] SET costolordoannuo = '38020.5',costolordoannuooneri = '52612.76',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP4',start = null,stop = null,tempdef = null,title = 'EP4' WHERE idcontrattokind = '17' AND idinquadramento = '78'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','78','38020.5','52612.76',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','EP4',null,null,null,'EP4')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '79')
UPDATE [inquadramento] SET costolordoannuo = '39606.28',costolordoannuooneri = '54807.17',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP5',start = null,stop = null,tempdef = null,title = 'EP5' WHERE idcontrattokind = '17' AND idinquadramento = '79'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','79','39606.28','54807.17',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','EP5',null,null,null,'EP5')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '80')
UPDATE [inquadramento] SET costolordoannuo = '41080.19',costolordoannuooneri = '56846.77',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP6',start = null,stop = null,tempdef = null,title = 'EP6' WHERE idcontrattokind = '17' AND idinquadramento = '80'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','80','41080.19','56846.77',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','EP6',null,null,null,'EP6')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '81')
UPDATE [inquadramento] SET costolordoannuo = '42616.97',costolordoannuooneri = '58973.36',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP7',start = null,stop = null,tempdef = null,title = 'EP7' WHERE idcontrattokind = '17' AND idinquadramento = '81'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','81','42616.97','58973.36',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','EP7',null,null,null,'EP7')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '17' AND idinquadramento = '82')
UPDATE [inquadramento] SET costolordoannuo = '43816.32',costolordoannuooneri = '60633.02',ct = {ts '2021-12-13 17:28:25.170'},cu = 'import_stipendi_PTA',lt = {ts '2021-12-13 17:28:25.170'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP8',start = null,stop = null,tempdef = null,title = 'EP8' WHERE idcontrattokind = '17' AND idinquadramento = '82'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('17','82','43816.32','60633.02',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA',{ts '2021-12-13 17:28:25.170'},'import_stipendi_PTA','EP8',null,null,null,'EP8')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'inquadramento')
UPDATE [tabledescr] SET description = 'Inquadramento',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-10 11:08:46.813'},lu = 'Generator',title = 'Inquadramento' WHERE tablename = 'inquadramento'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('inquadramento','Inquadramento','2','S',{ts '2021-11-10 11:08:46.813'},'Generator','Inquadramento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuo' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-05 10:03:11.320'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuo' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuo','inquadramento','5','9','2','','S',{ts '2021-11-05 10:03:11.320'},'Generator','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuooneri' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-05 10:03:11.320'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuooneri' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuooneri','inquadramento','5','9','2','','S',{ts '2021-11-05 10:03:11.320'},'Generator','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','inquadramento','8',null,null,null,'S',{ts '2020-07-14 16:13:13.993'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','inquadramento','64',null,null,null,'S',{ts '2020-07-14 16:13:13.993'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','inquadramento','4',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinquadramento' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinquadramento' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinquadramento','inquadramento','4',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','inquadramento','8',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','inquadramento','64',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'siglaimportazione' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-10 11:05:41.603'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'siglaimportazione' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('siglaimportazione','inquadramento','1024',null,null,'','S',{ts '2021-11-10 11:05:41.603'},'Generator','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:19:20.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','inquadramento','8',null,null,null,'S',{ts '2021-07-01 12:19:20.460'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:19:20.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','inquadramento','8',null,null,null,'S',{ts '2021-07-01 12:19:20.460'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempdef' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:19:20.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tempdef' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempdef','inquadramento','1',null,null,null,'S',{ts '2021-07-01 12:19:20.463'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','inquadramento','2048',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

