
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
-- CREAZIONE TABELLA ccnl --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ccnl]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ccnl] (
idccnl int NOT NULL,
active char(1) NOT NULL,
area nvarchar(50) NOT NULL,
contraenti nvarchar(1050) NOT NULL,
ct datetime NOT NULL,
cu nvarchar(64) NOT NULL,
decorrenza date NULL,
lt datetime NOT NULL,
lu nvarchar(64) NOT NULL,
scadec date NULL,
scadenza date NULL,
sortcode int NOT NULL,
stipula date NOT NULL,
title nvarchar(150) NOT NULL,
 CONSTRAINT xpkccnl PRIMARY KEY (idccnl
)
)
END
GO

-- VERIFICA STRUTTURA ccnl --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'idccnl' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD idccnl int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'idccnl' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'area' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD area nvarchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'area' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN area nvarchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'contraenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD contraenti nvarchar(1050) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'contraenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN contraenti nvarchar(1050) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD cu nvarchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN cu nvarchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'decorrenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD decorrenza date NULL 
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN decorrenza date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD lu nvarchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN lu nvarchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'scadec' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD scadec date NULL 
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN scadec date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'scadenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD scadenza date NULL 
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN scadenza date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'stipula' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD stipula date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'stipula' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN stipula date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ccnl' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ccnl] ADD title nvarchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('ccnl') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [ccnl] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [ccnl] ALTER COLUMN title nvarchar(150) NOT NULL
GO

-- VERIFICA DI ccnl IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'ccnl'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','int','ASSISTENZA','idccnl','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','nvarchar(50)','ASSISTENZA','area','50','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','nvarchar(1050)','ASSISTENZA','contraenti','1050','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','nvarchar(64)','ASSISTENZA','cu','64','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ccnl','date','ASSISTENZA','decorrenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','nvarchar(64)','ASSISTENZA','lu','64','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ccnl','date','ASSISTENZA','scadec','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ccnl','date','ASSISTENZA','scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','date','ASSISTENZA','stipula','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnl','nvarchar(150)','ASSISTENZA','title','150','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI ccnl IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'ccnl')
UPDATE customobject set isreal = 'S' where objectname = 'ccnl'
ELSE
INSERT INTO customobject (objectname, isreal) values('ccnl', 'S')
GO

-- GENERAZIONE DATI PER ccnl --
IF exists(SELECT * FROM [ccnl] WHERE idccnl = '1')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FORITALY, AIC, FAGRI, ASSOTECFAGRI,IMPRENDITORI&IMPRESE, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '1',stipula = {d '2016-07-21'},title = 'AGRICOLTURA E ATTIVITA'' AFFINI (FOR.ITALY)' WHERE idccnl = '1'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('1','S','AGRICOLTURA (52) ','FORITALY, AIC, FAGRI, ASSOTECFAGRI,IMPRENDITORI&IMPRESE, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'1',{d '2016-07-21'},'AGRICOLTURA E ATTIVITA'' AFFINI (FOR.ITALY)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '2')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'UAI, CONFAE, CONFENAL, CONFENAL FEDAGRI, FSE COBAS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-12-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '2',stipula = {d '2016-12-22'},title = 'AGRICOLTURA E FLOROVIVAISMO' WHERE idccnl = '2'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('2','S','AGRICOLTURA (52) ','UAI, CONFAE, CONFENAL, CONFENAL FEDAGRI, FSE COBAS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'2',{d '2016-12-22'},'AGRICOLTURA E FLOROVIVAISMO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '3')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'UNCI, ASCATUNCI, UNSIC, FNACONFSAL, SNAF, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2011-12-31'},sortcode = '3',stipula = {d '2007-12-20'},title = 'AGRICOLTURA ED ATTIVITA'' AFFINI: Cooperative' WHERE idccnl = '3'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('3','S','AGRICOLTURA (52) ','UNCI, ASCATUNCI, UNSIC, FNACONFSAL, SNAF, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2011-12-31'},'3',{d '2007-12-20'},'AGRICOLTURA ED ATTIVITA'' AFFINI: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '4')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '4',stipula = {d '2014-07-15'},title = 'AGRICOLTURA PESCA E AGROALIMENTARE: Cooperative' WHERE idccnl = '4'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('4','S','AGRICOLTURA (52) ','SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'4',{d '2014-07-15'},'AGRICOLTURA PESCA E AGROALIMENTARE: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '5')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFINNOVA, FEDERSICUREZZA ITALIA, FIADEL SP CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-31'},sortcode = '5',stipula = {d '2017-04-01'},title = 'AGRICOLTURA, FLOROVIVAISMO, FIORICOLTURA, FORESTALE E MANUTENZIONE GIARDINI' WHERE idccnl = '5'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('5','S','AGRICOLTURA (52) ','CONFINNOVA, FEDERSICUREZZA ITALIA, FIADEL SP CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-31'},'5',{d '2017-04-01'},'AGRICOLTURA, FLOROVIVAISMO, FIORICOLTURA, FORESTALE E MANUTENZIONE GIARDINI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '6')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'AIC, ASNALI, CONFEUR, UNSIC, UNSICOOP, CONFSAL, FNACONFSAL, SNAF FNA CONFSAL, EUROSIL, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-02-28'},sortcode = '6',stipula = {d '2014-03-05'},title = 'AGRICOLTURA, FLOROVIVAISMO, FLORICOLTURA, FORESTALE E MANUTENZIONE GIARDINI' WHERE idccnl = '6'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('6','S','AGRICOLTURA (52) ','AIC, ASNALI, CONFEUR, UNSIC, UNSICOOP, CONFSAL, FNACONFSAL, SNAF FNA CONFSAL, EUROSIL, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-02-28'},'6',{d '2014-03-05'},'AGRICOLTURA, FLOROVIVAISMO, FLORICOLTURA, FORESTALE E MANUTENZIONE GIARDINI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '7')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FAGRI, UNSIC, ASNALI, FNACONFSAL, SNAFFNACONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-02-28'},sortcode = '7',stipula = {d '2011-03-02'},title = 'AGRICOLTURA,INDUSTRIA AGRICOLA, FORESTALE: cooperative' WHERE idccnl = '7'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('7','S','AGRICOLTURA (52) ','FAGRI, UNSIC, ASNALI, FNACONFSAL, SNAFFNACONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-02-28'},'7',{d '2011-03-02'},'AGRICOLTURA,INDUSTRIA AGRICOLA, FORESTALE: cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '8')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'UNIMA, FAI CISL, FLAI CGIL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '8',stipula = {d '2012-06-21'},title = 'AGRICOLTURA: Aziende in conto terzi' WHERE idccnl = '8'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('8','S','AGRICOLTURA (52) ','UNIMA, FAI CISL, FLAI CGIL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'8',{d '2012-06-21'},'AGRICOLTURA: Aziende in conto terzi')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '9')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'AGRITALAGCI,LEGACOOPAGROALIMENTARE, FEDAGRICONFCOOPERATIVE, FAI CISL, FLAI CGIL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '9',stipula = {d '2016-08-03'},title = 'AGRICOLTURA: Cooperative e Consorzi Agricoli' WHERE idccnl = '9'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('9','S','AGRICOLTURA (52) ','AGRITALAGCI,LEGACOOPAGROALIMENTARE, FEDAGRICONFCOOPERATIVE, FAI CISL, FLAI CGIL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'9',{d '2016-08-03'},'AGRICOLTURA: Cooperative e Consorzi Agricoli')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '10')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-08-04'},sortcode = '10',stipula = {d '2016-08-05'},title = 'AGRICOLTURA: Cooperative e Consorzi Agricoli (ESAARCO)' WHERE idccnl = '10'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('10','S','AGRICOLTURA (52) ','ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-08-04'},'10',{d '2016-08-05'},'AGRICOLTURA: Cooperative e Consorzi Agricoli (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '11')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFAGRICOLTURA, DIR AGRI CONFEDERDIA, CIDA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2020-12-31'},sortcode = '11',stipula = {d '2017-10-19'},title = 'AGRICOLTURA: Dirigenti' WHERE idccnl = '11'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('11','S','AGRICOLTURA (52) ','CONFAGRICOLTURA, DIR AGRI CONFEDERDIA, CIDA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2020-12-31'},'11',{d '2017-10-19'},'AGRICOLTURA: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '12')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFAGRICOLTURA, FEDERAZIONENAZIONALEPROPRIETARICONDUTTORIINECONOMIA, FEDERAZIONENAZIONALEAFFITTUARICONDUTTORIINECONOMIA, FEDERAZIONENAZIONALEDELL''IMPRESAFAMILIARECOLTIVATRICE, UNAITALIA, COLDIRETTI, CIA, FEDERDIA, AGRI-QUADRI, CONFEDERDIA, FLAI CGIL, FAI CISL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '12',stipula = {d '2017-02-23'},title = 'AGRICOLTURA: Impiegati' WHERE idccnl = '12'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('12','S','AGRICOLTURA (52) ','CONFAGRICOLTURA, FEDERAZIONENAZIONALEPROPRIETARICONDUTTORIINECONOMIA, FEDERAZIONENAZIONALEAFFITTUARICONDUTTORIINECONOMIA, FEDERAZIONENAZIONALEDELL''IMPRESAFAMILIARECOLTIVATRICE, UNAITALIA, COLDIRETTI, CIA, FEDERDIA, AGRI-QUADRI, CONFEDERDIA, FLAI CGIL, FAI CISL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'12',{d '2017-02-23'},'AGRICOLTURA: Impiegati')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '13')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-02-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-02-14'},sortcode = '13',stipula = {d '2016-02-11'},title = 'AGRICOLTURA: Impiegati (CONFIMPRENDITORI-USIL)' WHERE idccnl = '13'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('13','S','AGRICOLTURA (52) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-02-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-02-14'},'13',{d '2016-02-11'},'AGRICOLTURA: Impiegati (CONFIMPRENDITORI-USIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '14')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-08-04'},sortcode = '14',stipula = {d '2016-08-05'},title = 'AGRICOLTURA: Impiegati (ESAARCO)' WHERE idccnl = '14'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('14','S','AGRICOLTURA (52) ','ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-08-04'},'14',{d '2016-08-05'},'AGRICOLTURA: Impiegati (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '15')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CEPAAAGROALIMENTARESETTOREAGRICOLO, CEPAA, UGLAGRICOLI E FORESTALI, UGL AGROALIMENTARE, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-04-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-02-28'},scadenza = {d '2017-04-22'},sortcode = '15',stipula = {d '2014-04-23'},title = 'AGRICOLTURA: Imprese Cooperative (CEPA-A - UGL)' WHERE idccnl = '15'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('15','S','AGRICOLTURA (52) ','CEPAAAGROALIMENTARESETTOREAGRICOLO, CEPAA, UGLAGRICOLI E FORESTALI, UGL AGROALIMENTARE, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-04-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-02-28'},{d '2017-04-22'},'15',{d '2014-04-23'},'AGRICOLTURA: Imprese Cooperative (CEPA-A - UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '16')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFIMEA, FEDERTERZIARIO, CFC, UGLAGRICOLIEFORESTALI, UGL AGROALIMENTARE, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-31'},sortcode = '16',stipula = {d '2013-07-02'},title = 'AGRICOLTURA: ImpreseCooperative (CONFIMEA-FEDERTERZIARIO-UGL)' WHERE idccnl = '16'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('16','S','AGRICOLTURA (52) ','CONFIMEA, FEDERTERZIARIO, CFC, UGLAGRICOLIEFORESTALI, UGL AGROALIMENTARE, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-31'},'16',{d '2013-07-02'},'AGRICOLTURA: ImpreseCooperative (CONFIMEA-FEDERTERZIARIO-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '17')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'UNICOOP, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-02-28'},sortcode = '17',stipula = {d '2013-03-06'},title = 'AGRICOLTURA: ImpreseCooperative (UNICOOP-UGL)' WHERE idccnl = '17'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('17','S','AGRICOLTURA (52) ','UNICOOP, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-02-28'},'17',{d '2013-03-06'},'AGRICOLTURA: ImpreseCooperative (UNICOOP-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '18')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFIMPRESEAGRICOLTURA, CONFIMPRESEITALIA, FESICACONFSAL, CONFSAL FISALS, CONFSALPESCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-10-31'},sortcode = '18',stipula = {d '2014-10-24'},title = 'AGRICOLTURA: Operaiagricoli,florovivaistie dell''acquacoltura' WHERE idccnl = '18'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('18','S','AGRICOLTURA (52) ','CONFIMPRESEAGRICOLTURA, CONFIMPRESEITALIA, FESICACONFSAL, CONFSAL FISALS, CONFSALPESCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-10-31'},'18',{d '2014-10-24'},'AGRICOLTURA: Operaiagricoli,florovivaistie dell''acquacoltura')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '19')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFAGRICOLTURA, COLDIRETTI, CIA, SindacatoNazionaleAgricoli e Forestali UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '19',stipula = {d '2016-06-16'},title = 'AGRICOLTURA: Operai e Florovivaisti' WHERE idccnl = '19'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('19','S','AGRICOLTURA (52) ','CONFAGRICOLTURA, COLDIRETTI, CIA, SindacatoNazionaleAgricoli e Forestali UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'19',{d '2016-06-16'},'AGRICOLTURA: Operai e Florovivaisti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '20')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFAGRICOLTURA, FEDERAZIONENAZIONALEDEIPROPRIETARICONDUTTORIINECONOMIA, FEDERAZIONENAZIONALEAFFITTUARICONDUTTORIINECONOMIA, FEDERAZIONENAZIONALEDELL''IMPRESAFAMILIARECOLTIVATRICE, ASSOCIAZIONEITALIANACOSTRUTTORIDELVERDE, COLDIRETTI, CIA, FLAI CGIL, FAI CISL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '20',stipula = {d '2014-10-22'},title = 'AGRICOLTURA: Operai e Florovivaisti' WHERE idccnl = '20'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('20','S','AGRICOLTURA (52) ','CONFAGRICOLTURA, FEDERAZIONENAZIONALEDEIPROPRIETARICONDUTTORIINECONOMIA, FEDERAZIONENAZIONALEAFFITTUARICONDUTTORIINECONOMIA, FEDERAZIONENAZIONALEDELL''IMPRESAFAMILIARECOLTIVATRICE, ASSOCIAZIONEITALIANACOSTRUTTORIDELVERDE, COLDIRETTI, CIA, FLAI CGIL, FAI CISL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'20',{d '2014-10-22'},'AGRICOLTURA: Operai e Florovivaisti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '21')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'COMPIEAGRICOLTURACONFEDERAZIONEPICCOLEEMEDIEIMPRESEEUROPEECOMPARTOAGRICOLTURA, UCIUNIONECOLTIVATORIITALIANI, ULEUNIONELAVORATORIEUROPEIAGRICOLTURA ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-12-16'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-16'},sortcode = '21',stipula = {d '2011-12-16'},title = 'AGRICOLTURA: Operai e Florovivaisti' WHERE idccnl = '21'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('21','S','AGRICOLTURA (52) ','COMPIEAGRICOLTURACONFEDERAZIONEPICCOLEEMEDIEIMPRESEEUROPEECOMPARTOAGRICOLTURA, UCIUNIONECOLTIVATORIITALIANI, ULEUNIONELAVORATORIEUROPEIAGRICOLTURA ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-16'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-16'},'21',{d '2011-12-16'},'AGRICOLTURA: Operai e Florovivaisti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '22')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FAGRI, ASNALI, FNA CONFSAL, SNAF FNA CONSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2012-09-30'},scadenza = {d '2014-09-30'},sortcode = '22',stipula = {d '2010-09-29'},title = 'AGRICOLTURA: Operai e Florovivaisti' WHERE idccnl = '22'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('22','S','AGRICOLTURA (52) ','FAGRI, ASNALI, FNA CONFSAL, SNAF FNA CONSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-09-30'},{d '2014-09-30'},'22',{d '2010-09-29'},'AGRICOLTURA: Operai e Florovivaisti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '23')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-02-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-02-14'},sortcode = '23',stipula = {d '2016-02-11'},title = 'AGRICOLTURA: Operaie Florovivaisti (CONFIMPRENDITORI-USIL)' WHERE idccnl = '23'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('23','S','AGRICOLTURA (52) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-02-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-02-14'},'23',{d '2016-02-11'},'AGRICOLTURA: Operaie Florovivaisti (CONFIMPRENDITORI-USIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '24')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-08-04'},sortcode = '24',stipula = {d '2016-08-05'},title = 'AGRICOLTURA: Operai e Florovivaisti (ESAARCO)' WHERE idccnl = '24'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('24','S','AGRICOLTURA (52) ','ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-08-04'},'24',{d '2016-08-05'},'AGRICOLTURA: Operai e Florovivaisti (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '25')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FEDERAZIENDE, FEDERDIPENDENTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-02-28'},sortcode = '25',stipula = {d '2017-03-01'},title = 'AGRICOLTURA: OperaieFlorovivaisti (FEDERAZIENDE-FEDERDIPENDENTI)' WHERE idccnl = '25'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('25','S','AGRICOLTURA (52) ','FEDERAZIENDE, FEDERDIPENDENTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-02-28'},'25',{d '2017-03-01'},'AGRICOLTURA: OperaieFlorovivaisti (FEDERAZIENDE-FEDERDIPENDENTI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '26')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FEDERDAT, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-05-31'},sortcode = '26',stipula = {d '2016-05-17'},title = 'AGRICOLTURA: OperaieFlorovivaisti (FEDERDAT-CONSIL)' WHERE idccnl = '26'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('26','S','AGRICOLTURA (52) ','FEDERDAT, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-05-31'},'26',{d '2016-05-17'},'AGRICOLTURA: OperaieFlorovivaisti (FEDERDAT-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '27')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FEDERIMPRESEITALIA, ALPAI, SALPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-12-31'},sortcode = '27',stipula = {d '2016-09-30'},title = 'AGRICOLTURA: OperaieFlorovivaisti (FEDERIMPRESEITALIA-ALPAI-SALPS)' WHERE idccnl = '27'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('27','S','AGRICOLTURA (52) ','FEDERIMPRESEITALIA, ALPAI, SALPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-12-31'},'27',{d '2016-09-30'},'AGRICOLTURA: OperaieFlorovivaisti (FEDERIMPRESEITALIA-ALPAI-SALPS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '28')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'MIDA, SNIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '28',stipula = {d '2015-11-06'},title = 'AGRICOLTURA: Operai e Florovivaisti (MIDA-SNIAL)' WHERE idccnl = '28'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('28','S','AGRICOLTURA (52) ','MIDA, SNIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'28',{d '2015-11-06'},'AGRICOLTURA: Operai e Florovivaisti (MIDA-SNIAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '29')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ADLI, ASSIDAL, FAMARCONFAMAR, FIRAS_SPPCIU, FLSCONFAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-02-28'},sortcode = '29',stipula = {d '2017-03-01'},title = 'AGRICOLTURA: PMI e Cooperative (ADLI-FAMAR)' WHERE idccnl = '29'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('29','S','AGRICOLTURA (52) ','ADLI, ASSIDAL, FAMARCONFAMAR, FIRAS_SPPCIU, FLSCONFAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-02-28'},'29',{d '2017-03-01'},'AGRICOLTURA: PMI e Cooperative (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '30')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FEDIMPRESE, CIU, FAMAR, CONFAMAR, SNAPEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-01-31'},sortcode = '30',stipula = {d '2016-01-31'},title = 'AGRICOLTURA: PMIeCooperative (FEDIMPRESE-CIU-FAMAR-SNAPEL)' WHERE idccnl = '30'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('30','S','AGRICOLTURA (52) ','FEDIMPRESE, CIU, FAMAR, CONFAMAR, SNAPEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-01-31'},'30',{d '2016-01-31'},'AGRICOLTURA: PMIeCooperative (FEDIMPRESE-CIU-FAMAR-SNAPEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '31')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FEDIMPRESE, FAMAR, SNAPEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '31',stipula = {d '2015-06-01'},title = 'AGRICOLTURA: PMIeCooperative (FEDIMPRESE-FAMAR-SNAPEL)' WHERE idccnl = '31'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('31','S','AGRICOLTURA (52) ','FEDIMPRESE, FAMAR, SNAPEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'31',{d '2015-06-01'},'AGRICOLTURA: PMIeCooperative (FEDIMPRESE-FAMAR-SNAPEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '32')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'NORD INDUSTRIALE, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '32',stipula = {d '2015-02-26'},title = 'AGRICOLTURA: PMI e Cooperative (NORDINDUSTRIALE-FAMAR)' WHERE idccnl = '32'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('32','S','AGRICOLTURA (52) ','NORD INDUSTRIALE, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'32',{d '2015-02-26'},'AGRICOLTURA: PMI e Cooperative (NORDINDUSTRIALE-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '33')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'FIDAP IMPRESE, FISAL ITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2021-12-31'},sortcode = '33',stipula = {d '2017-12-12'},title = 'AGRICOLTURA: SettoreAgricoloeFlorovivaisti (FIDAP IMPRESE - FISAL ITALIA)' WHERE idccnl = '33'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('33','S','AGRICOLTURA (52) ','FIDAP IMPRESE, FISAL ITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2021-12-31'},'33',{d '2017-12-12'},'AGRICOLTURA: SettoreAgricoloeFlorovivaisti (FIDAP IMPRESE - FISAL ITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '34')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'SAL, ANCORS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-05-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-05-04'},sortcode = '34',stipula = {d '2014-04-15'},title = 'AZIENDE AGRICOLE ORTO-FLORO-FRUTTICOLE' WHERE idccnl = '34'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('34','S','AGRICOLTURA (52) ','SAL, ANCORS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-05-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-05-04'},'34',{d '2014-04-15'},'AZIENDE AGRICOLE ORTO-FLORO-FRUTTICOLE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '35')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ESAARCO, CEPA, CEPA Agricoltura, UIPA, CLI, FLAAF, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-05-30'},sortcode = '35',stipula = {d '2017-05-31'},title = 'AZIENDE AGRICOLE, AGRITURISTICHE E FLOROVIVAISTE (ESAARCO)' WHERE idccnl = '35'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('35','S','AGRICOLTURA (52) ','ESAARCO, CEPA, CEPA Agricoltura, UIPA, CLI, FLAAF, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-05-30'},'35',{d '2017-05-31'},'AZIENDE AGRICOLE, AGRITURISTICHE E FLOROVIVAISTE (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '36')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'UCI, ERSAF, AIC, CEUQ ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-02-01'},sortcode = '36',stipula = {d '2018-02-14'},title = 'AZIENDE AGRICOLE AGRITURISTICHE, FATTORIE DIDATTICHE-SOCIALI E FLOROVIVAISTE anche in forma cooperativa' WHERE idccnl = '36'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('36','S','AGRICOLTURA (52) ','UCI, ERSAF, AIC, CEUQ ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-02-01'},'36',{d '2018-02-14'},'AZIENDE AGRICOLE AGRITURISTICHE, FATTORIE DIDATTICHE-SOCIALI E FLOROVIVAISTE anche in forma cooperativa')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '37')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'LEGA IMPRESA, UIPA, FILAP, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-10-31'},sortcode = '37',stipula = {d '2017-11-25'},title = 'AZIENDE E COOPERATIVE AGRICOLE, AGRITURISTICHE E FLOROVIVAISTE' WHERE idccnl = '37'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('37','S','AGRICOLTURA (52) ','LEGA IMPRESA, UIPA, FILAP, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-10-31'},'37',{d '2017-11-25'},'AZIENDE E COOPERATIVE AGRICOLE, AGRITURISTICHE E FLOROVIVAISTE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '38')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFAGRICOLTURA, COLDIRETTI, CIA, FAI CISL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '38',stipula = {d '2006-04-26'},title = 'AZIENDE MANUTENZIONE DEL VERDE' WHERE idccnl = '38'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('38','S','AGRICOLTURA (52) ','CONFAGRICOLTURA, COLDIRETTI, CIA, FAI CISL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'38',{d '2006-04-26'},'AZIENDE MANUTENZIONE DEL VERDE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '39')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-08-04'},sortcode = '39',stipula = {d '2016-08-05'},title = 'CONSORZI AGRARI (ESAARCO)' WHERE idccnl = '39'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('39','S','AGRICOLTURA (52) ','ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-08-04'},'39',{d '2016-08-05'},'CONSORZI AGRARI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '40')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ASSOCIAZIONENAZIONALEDEICONSORZIAGRARI, ASSOCIAZIONENAZIONALEDEIDIRIGENTIDEICONSORZIAGRARIFNDACIDA, FEDERAZIONENAZIONALEDIRIGENTIAZIENDE INDUSTRIALI FEDERMANAGER CIDA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '40',stipula = {d '2009-12-04'},title = 'CONSORZI AGRARI: Dirigenti' WHERE idccnl = '40'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('40','S','AGRICOLTURA (52) ','ASSOCIAZIONENAZIONALEDEICONSORZIAGRARI, ASSOCIAZIONENAZIONALEDEIDIRIGENTIDEICONSORZIAGRARIFNDACIDA, FEDERAZIONENAZIONALEDIRIGENTIAZIENDE INDUSTRIALI FEDERMANAGER CIDA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'40',{d '2009-12-04'},'CONSORZI AGRARI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '41')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ASSOCAP, FLAI CGIL, FAI CISL, UILTUCS UIL, SINALCAP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2012-05-31'},scadenza = {d '2012-05-31'},sortcode = '41',stipula = {d '2009-12-22'},title = 'CONSORZI AGRARI: Operai e Impiegati' WHERE idccnl = '41'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('41','S','AGRICOLTURA (52) ','ASSOCAP, FLAI CGIL, FAI CISL, UILTUCS UIL, SINALCAP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-05-31'},{d '2012-05-31'},'41',{d '2009-12-22'},'CONSORZI AGRARI: Operai e Impiegati')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '42')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-08-04'},sortcode = '42',stipula = {d '2016-08-05'},title = 'CONSORZI di Bonifica e di Miglioramento Fondiario (ESAARCO)' WHERE idccnl = '42'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('42','S','AGRICOLTURA (52) ','ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-08-04'},'42',{d '2016-08-05'},'CONSORZI di Bonifica e di Miglioramento Fondiario (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '43')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'SNEBI, SINDICOB',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2011-12-31'},sortcode = '43',stipula = {d '2011-02-03'},title = 'CONSORZI di Bonifica: Dirigenti' WHERE idccnl = '43'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('43','S','AGRICOLTURA (52) ','SNEBI, SINDICOB',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2011-12-31'},'43',{d '2011-02-03'},'CONSORZI di Bonifica: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '44')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'SNEBI, FLAI CGIL, FAI CISL, FILBI UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2011-12-31'},sortcode = '44',stipula = {d '2010-03-25'},title = 'CONSORZI di Bonifica: Operai e Impiegati' WHERE idccnl = '44'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('44','S','AGRICOLTURA (52) ','SNEBI, FLAI CGIL, FAI CISL, FILBI UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2011-12-31'},'44',{d '2010-03-25'},'CONSORZI di Bonifica: Operai e Impiegati')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '45')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'CONFEURO, EUROTER, EUROCOLTIVATORI, SOGGETTOGIURIDICO, E-ACADEMY',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-12-31'},sortcode = '45',stipula = {d '2017-06-07'},title = 'LAVORATORI AGRICOLI' WHERE idccnl = '45'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('45','S','AGRICOLTURA (52) ','CONFEURO, EUROTER, EUROCOLTIVATORI, SOGGETTOGIURIDICO, E-ACADEMY',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-12-31'},'45',{d '2017-06-07'},'LAVORATORI AGRICOLI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '46')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'NORD INDUSTRIALE, CONFIMI, FASPI, FAL, CONFAEL, SNALP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '46',stipula = {d '2016-07-21'},title = 'PRIMOSETTORE: AGRICOLTURA,ZOOTECNIA, FORESTAZIONE' WHERE idccnl = '46'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('46','S','AGRICOLTURA (52) ','NORD INDUSTRIALE, CONFIMI, FASPI, FAL, CONFAEL, SNALP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'46',{d '2016-07-21'},'PRIMOSETTORE: AGRICOLTURA,ZOOTECNIA, FORESTAZIONE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '47')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'UNCEM, ISA AGRICOLI IDRAULICI FORESTALI ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '47',stipula = {d '2011-07-07'},title = 'SISTEMAZIONI IDRAULICO FORESTALI' WHERE idccnl = '47'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('47','S','AGRICOLTURA (52) ','UNCEM, ISA AGRICOLI IDRAULICI FORESTALI ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'47',{d '2011-07-07'},'SISTEMAZIONI IDRAULICO FORESTALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '48')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'UNCEM, UGL AGRICOLI E FORESTALI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '48',stipula = {d '2011-02-02'},title = 'SISTEMAZIONI IDRAULICO FORESTALI' WHERE idccnl = '48'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('48','S','AGRICOLTURA (52) ','UNCEM, UGL AGRICOLI E FORESTALI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'48',{d '2011-02-02'},'SISTEMAZIONI IDRAULICO FORESTALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '49')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'UNCEM, FEDERAZIONEITALIANACOMUNITA''FORESTALI, FEDERFORESTE,LEGACOOPAGROALIMENTARE, FEDAGRICONFCOOPERATIVE, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGRITALAGCI, FLAICGIL, FAICISL, UILAUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '49',stipula = {d '2010-12-07'},title = 'SISTEMAZIONI IDRAULICO FORESTALI' WHERE idccnl = '49'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('49','S','AGRICOLTURA (52) ','UNCEM, FEDERAZIONEITALIANACOMUNITA''FORESTALI, FEDERFORESTE,LEGACOOPAGROALIMENTARE, FEDAGRICONFCOOPERATIVE, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGRITALAGCI, FLAICGIL, FAICISL, UILAUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'49',{d '2010-12-07'},'SISTEMAZIONI IDRAULICO FORESTALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '50')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-08-04'},sortcode = '50',stipula = {d '2016-08-05'},title = 'SISTEMAZIONI IDRAULICO FORESTALI (ESAARCO)' WHERE idccnl = '50'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('50','S','AGRICOLTURA (52) ','ESAARCO, ESAARCOArtigianato, ESAARCOAutotrasporti, ESAARCOServizieTerziario, ESAARCOVigilanzaeSicurezza, FEAZAgricoleESAARCO, FECDESAARCO, FEIAESAARCO, ESAARCOCommercio, CEPAA, CEPAAChimica, CEPAAScuola, CEPAASanit?, CEPAAAgricoltura, CEPAACommercio, CEPAATurismo, CEPAACostruttoriEdilieAffini, CEPAAPesca, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, ADI, CIU, SICEL,ONAPS, UGLFNLE, FISNALCTAUGL, CGELFNLA, CGELFNLM, CGELFNLP, FLAAFCGEL, FENALSCGEL, FNAOPS CGEL, FENALC CGEL, FLT CGEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-08-04'},'50',{d '2016-08-05'},'SISTEMAZIONI IDRAULICO FORESTALI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '51')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'ASSOCIAZIONEITALIANAALLEVATORI, FLAICGIL, FAICISL, UILAUIL, CONFEDERDIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '51',stipula = {d '2007-10-04'},title = 'ZOOTECNIA : Operai e Impiegati' WHERE idccnl = '51'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('51','S','AGRICOLTURA (52) ','ASSOCIAZIONEITALIANAALLEVATORI, FLAICGIL, FAICISL, UILAUIL, CONFEDERDIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'51',{d '2007-10-04'},'ZOOTECNIA : Operai e Impiegati')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '52')
UPDATE [ccnl] SET active = 'S',area = 'AGRICOLTURA (52) ',contraenti = 'AIA, AIDEZ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '52',stipula = {d '2008-10-24'},title = 'ZOOTECNIA: Dirigenti' WHERE idccnl = '52'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('52','S','AGRICOLTURA (52) ','AIA, AIDEZ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'52',{d '2008-10-24'},'ZOOTECNIA: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '53')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '53',stipula = {d '2014-06-18'},title = 'ABRASIVI: PMI, Cooperative, Artigiane' WHERE idccnl = '53'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('53','S','CHIMICI (33) ','FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'53',{d '2014-06-18'},'ABRASIVI: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '54')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UGL CHIMICI, CEPA A',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-22'},sortcode = '54',stipula = {d '2013-05-23'},title = 'ABRASIVI: PMI, Cooperative, Artigiane' WHERE idccnl = '54'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('54','S','CHIMICI (33) ','UGL CHIMICI, CEPA A',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-22'},'54',{d '2013-05-23'},'ABRASIVI: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '55')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '55',stipula = {d '2014-06-18'},title = 'CERAMICA: PMI, Cooperative, Artigiane' WHERE idccnl = '55'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('55','S','CHIMICI (33) ','FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'55',{d '2014-06-18'},'CERAMICA: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '56')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UGL CHIMICI, CEPA A',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-22'},sortcode = '56',stipula = {d '2013-05-23'},title = 'CERAMICA: PMI, Cooperative, Artigiane' WHERE idccnl = '56'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('56','S','CHIMICI (33) ','UGL CHIMICI, CEPA A',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-22'},'56',{d '2013-05-23'},'CERAMICA: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '57')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'LEGA IMPRESA, FILAP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-11-09'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '57',stipula = {d '2015-11-09'},title = 'CHIMICA - CERAMICA (LEGA IMPRESA)' WHERE idccnl = '57'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('57','S','CHIMICI (33) ','LEGA IMPRESA, FILAP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-11-09'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'57',{d '2015-11-09'},'CHIMICA - CERAMICA (LEGA IMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '58')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '58',stipula = {d '2016-04-07'},title = 'CHIMICA (ADLI-FAMAR)' WHERE idccnl = '58'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('58','S','CHIMICI (33) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'58',{d '2016-04-07'},'CHIMICA (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '59')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'NORD INDUSTRIALE, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '59',stipula = {d '2015-02-26'},title = 'CHIMICA (NORD INDUSTRIALE-FAMAR)' WHERE idccnl = '59'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('59','S','CHIMICI (33) ','NORD INDUSTRIALE, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'59',{d '2015-02-26'},'CHIMICA (NORD INDUSTRIALE-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '60')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UNIONCHIMICACONFAPI, FILCTEMCGIL, FEMCACISL, UILTECUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '60',stipula = {d '2016-07-26'},title = 'CHIMICA E AFFINI (Piccola e Media Impresa)' WHERE idccnl = '60'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('60','S','CHIMICI (33) ','UNIONCHIMICACONFAPI, FILCTEMCGIL, FEMCACISL, UILTECUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'60',{d '2016-07-26'},'CHIMICA E AFFINI (Piccola e Media Impresa)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '61')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '61',stipula = {d '2014-06-18'},title = 'CHIMICA ED AFFINI: PMI, Cooperative, Artigiane' WHERE idccnl = '61'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('61','S','CHIMICI (33) ','FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'61',{d '2014-06-18'},'CHIMICA ED AFFINI: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '62')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UGL CHIMICI, CEPA A',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-22'},sortcode = '62',stipula = {d '2013-05-23'},title = 'CHIMICA ED AFFINI: PMI, Cooperative, Artigiane' WHERE idccnl = '62'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('62','S','CHIMICI (33) ','UGL CHIMICI, CEPA A',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-22'},'62',{d '2013-05-23'},'CHIMICA ED AFFINI: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '63')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDARCOM, CIFA, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2005-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-01'},scadenza = {d '2009-11-30'},sortcode = '63',stipula = {d '2005-11-30'},title = 'CHIMICA,VETRO,GOMMA E PLASTICA: PMI, Cooperative, Artigiane' WHERE idccnl = '63'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('63','S','CHIMICI (33) ','FEDARCOM, CIFA, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-01'},{d '2009-11-30'},'63',{d '2005-11-30'},'CHIMICA,VETRO,GOMMA E PLASTICA: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '64')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERCHIMICA, FARMINDUSTRIA, UGLCHIMICI, FAILCCONFAIL, FIALC CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '64',stipula = {d '2015-10-15'},title = 'CHIMICO FARMACEUTICA e AFFINI: Industrie' WHERE idccnl = '64'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('64','S','CHIMICI (33) ','FEDERCHIMICA, FARMINDUSTRIA, UGLCHIMICI, FAILCCONFAIL, FIALC CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'64',{d '2015-10-15'},'CHIMICO FARMACEUTICA e AFFINI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '65')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERCHIMICA, FARMINDUSTRIA, FILCTEMCGIL, FEMCACISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '65',stipula = {d '2015-10-15'},title = 'CHIMICO FARMACEUTICA e AFFINI: Industrie' WHERE idccnl = '65'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('65','S','CHIMICI (33) ','FEDERCHIMICA, FARMINDUSTRIA, FILCTEMCGIL, FEMCACISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'65',{d '2015-10-15'},'CHIMICO FARMACEUTICA e AFFINI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '66')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'ANICTA, FEMCACISL, FILCTEMCGIL, UILTECUIL,(adesionediUGL CHIMICI dal 17/4/2013)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '66',stipula = {d '2013-04-04'},title = 'CHIMICO FARMACEUTICA e AFFINI: Industrie' WHERE idccnl = '66'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('66','S','CHIMICI (33) ','ANICTA, FEMCACISL, FILCTEMCGIL, UILTECUIL,(adesionediUGL CHIMICI dal 17/4/2013)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'66',{d '2013-04-04'},'CHIMICO FARMACEUTICA e AFFINI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '67')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '67',stipula = {d '2014-06-18'},title = 'CONCIA E ACCORPATI: PMI, Cooperative, Artigiane' WHERE idccnl = '67'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('67','S','CHIMICI (33) ','FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'67',{d '2014-06-18'},'CONCIA E ACCORPATI: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '68')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UGL CHIMICI, CEPA A',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-22'},sortcode = '68',stipula = {d '2013-05-23'},title = 'CONCIA ED ACCORPATI: PMI, Cooperative, Artigiane' WHERE idccnl = '68'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('68','S','CHIMICI (33) ','UGL CHIMICI, CEPA A',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-22'},'68',{d '2013-05-23'},'CONCIA ED ACCORPATI: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '69')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UNIC, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-10-31'},sortcode = '69',stipula = {d '2013-07-25'},title = 'CONCIA: Industrie' WHERE idccnl = '69'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('69','S','CHIMICI (33) ','UNIC, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-10-31'},'69',{d '2013-07-25'},'CONCIA: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '70')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UNIC, FILCTEM CGIL, FEMCA CISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-10-31'},sortcode = '70',stipula = {d '2013-07-18'},title = 'CONCIA: Industrie' WHERE idccnl = '70'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('70','S','CHIMICI (33) ','UNIC, FILCTEM CGIL, FEMCA CISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-10-31'},'70',{d '2013-07-18'},'CONCIA: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '71')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'CONFINDUSTRIAENERGIA, FILCTEMCGIL, FEMCACISL, UILTECUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '71',stipula = {d '2017-01-25'},title = 'ENERGIA E PETROLIO' WHERE idccnl = '71'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('71','S','CHIMICI (33) ','CONFINDUSTRIAENERGIA, FILCTEMCGIL, FEMCACISL, UILTECUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'71',{d '2017-01-25'},'ENERGIA E PETROLIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '72')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'CONFINDUSTRIA ENERGIA, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '72',stipula = {d '2017-01-25'},title = 'ENERGIA E PETROLIO' WHERE idccnl = '72'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('72','S','CHIMICI (33) ','CONFINDUSTRIA ENERGIA, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'72',{d '2017-01-25'},'ENERGIA E PETROLIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '73')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERAZIONEGOMMA E PLASTICA, ASSOCIAZIONEITALIANARICOSTRUTTORIPNEUMATICI, CONFINDUSTRIA, FILCTEMCGIL, FEMCA CISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-08'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '73',stipula = {d '2014-01-08'},title = 'GOMMA E PLASTICA: Industrie' WHERE idccnl = '73'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('73','S','CHIMICI (33) ','FEDERAZIONEGOMMA E PLASTICA, ASSOCIAZIONEITALIANARICOSTRUTTORIPNEUMATICI, CONFINDUSTRIA, FILCTEMCGIL, FEMCA CISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-08'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'73',{d '2014-01-08'},'GOMMA E PLASTICA: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '74')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERAZIONEGOMMA E PLASTICA, ASSOCIAZIONEITALIANARICOSTRUTTORI PNEUMATICI, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-08'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '74',stipula = {d '2014-01-08'},title = 'GOMMA E PLASTICA: Industrie' WHERE idccnl = '74'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('74','S','CHIMICI (33) ','FEDERAZIONEGOMMA E PLASTICA, ASSOCIAZIONEITALIANARICOSTRUTTORI PNEUMATICI, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-08'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'74',{d '2014-01-08'},'GOMMA E PLASTICA: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '75')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UNIONCHIMICACONFAPI, FILCEMCGIL, FEMCACISL, UILCEMUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2011-12-31'},sortcode = '75',stipula = {d '2008-03-05'},title = 'GOMMA E PLASTICA: P.M.I.' WHERE idccnl = '75'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('75','S','CHIMICI (33) ','UNIONCHIMICACONFAPI, FILCEMCGIL, FEMCACISL, UILCEMUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2011-12-31'},'75',{d '2008-03-05'},'GOMMA E PLASTICA: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '76')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '76',stipula = {d '2014-06-18'},title = 'GOMMA E PLASTICA: PMI, Cooperative, Artigiane' WHERE idccnl = '76'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('76','S','CHIMICI (33) ','FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'76',{d '2014-06-18'},'GOMMA E PLASTICA: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '77')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'ASSOMINERARIA, FILCTEM CGIL, FEMCA CISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '77',stipula = {d '2017-02-15'},title = 'MINERO-METALLURGICHE: Industrie' WHERE idccnl = '77'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('77','S','CHIMICI (33) ','ASSOMINERARIA, FILCTEM CGIL, FEMCA CISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'77',{d '2017-02-15'},'MINERO-METALLURGICHE: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '78')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'ASSOMINERARIA, UGL CHIMICI ENERGIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-03-31'},sortcode = '78',stipula = {d '2013-11-20'},title = 'MINERO-METALLURGICHE: Industrie' WHERE idccnl = '78'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('78','S','CHIMICI (33) ','ASSOMINERARIA, UGL CHIMICI ENERGIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-03-31'},'78',{d '2013-11-20'},'MINERO-METALLURGICHE: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '79')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'CONFINDUSTRIACERAMICA, FILCTEMCGIL, FEMCACISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '79',stipula = {d '2016-11-16'},title = 'PIASTRELLE E REFRATTARI: Industrie' WHERE idccnl = '79'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('79','S','CHIMICI (33) ','CONFINDUSTRIACERAMICA, FILCTEMCGIL, FEMCACISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'79',{d '2016-11-16'},'PIASTRELLE E REFRATTARI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '80')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'CONFINDUSTRIACERAMICA, UGLCHIMICI, FIALCCISAL, FAILCCONFAIL, FESICA CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '80',stipula = {d '2014-08-28'},title = 'PIASTRELLE E REFRATTARI: Industrie' WHERE idccnl = '80'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('80','S','CHIMICI (33) ','CONFINDUSTRIACERAMICA, UGLCHIMICI, FIALCCISAL, FAILCCONFAIL, FESICA CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'80',{d '2014-08-28'},'PIASTRELLE E REFRATTARI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '81')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UGL CHIMICI, CEPA A',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-22'},sortcode = '81',stipula = {d '2013-05-23'},title = 'PLASTICA E GOMMA: PMI, Cooperative, Artigiane' WHERE idccnl = '81'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('81','S','CHIMICI (33) ','UGL CHIMICI, CEPA A',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-22'},'81',{d '2013-05-23'},'PLASTICA E GOMMA: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '82')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'ASSOVETRO, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '82',stipula = {d '2016-07-27'},title = 'VETRO: Industrie' WHERE idccnl = '82'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('82','S','CHIMICI (33) ','ASSOVETRO, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'82',{d '2016-07-27'},'VETRO: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '83')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'ASSOVETRO, FILCTEM CGIL, FEMCA CISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '83',stipula = {d '2016-07-27'},title = 'VETRO: Industrie' WHERE idccnl = '83'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('83','S','CHIMICI (33) ','ASSOVETRO, FILCTEM CGIL, FEMCA CISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'83',{d '2016-07-27'},'VETRO: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '84')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '84',stipula = {d '2014-06-18'},title = 'VETRO: PMI, Cooperative, Artigiane' WHERE idccnl = '84'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('84','S','CHIMICI (33) ','FEDERTERZIARIO, CONFIMEA, CFC, UGL CHIMICI ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'84',{d '2014-06-18'},'VETRO: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '85')
UPDATE [ccnl] SET active = 'S',area = 'CHIMICI (33) ',contraenti = 'UGL CHIMICI, CEPA A',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-22'},sortcode = '85',stipula = {d '2013-05-23'},title = 'VETRO: PMI, Cooperative, Artigiane' WHERE idccnl = '85'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('85','S','CHIMICI (33) ','UGL CHIMICI, CEPA A',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-22'},'85',{d '2013-05-23'},'VETRO: PMI, Cooperative, Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '86')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ESAARCO, CEPAA, CEPAAFedercoop, SAI, ALIM, FER, CONFIMPRESA, UNIPMI, PMIITALIAINTERNATIONAL, CIU, SICEL, CGEL FNLM, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '86',stipula = {d '2014-11-01'},title = 'AUTODEMOLIZIONE, SMALTIMENTO, RECUPERO, TRASPORTO, RICICLAGGIO E TRASFORMAZIONe (ESAARCO)' WHERE idccnl = '86'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('86','S','MECCANICI (31) ','ESAARCO, CEPAA, CEPAAFedercoop, SAI, ALIM, FER, CONFIMPRESA, UNIPMI, PMIITALIAINTERNATIONAL, CIU, SICEL, CGEL FNLM, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'86',{d '2014-11-01'},'AUTODEMOLIZIONE, SMALTIMENTO, RECUPERO, TRASPORTO, RICICLAGGIO E TRASFORMAZIONe (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '87')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'CONFARTIGIANATOAutoriparazione, CONFARTIGIANATOMetalmeccanicadiProduzione, CONFARTIGIANATOImpianti, CONFARTIGIANATOOrafi, CONFARTIGIANATOFe.Na.ODI, CNAProduzione, CNAInstallazionediImpianti, CNAServiziallacomunit?/Autoriparatori, CNAArtisticoetradizionale, CNABenesseree Sanit?, CASARTIGIANI, CLAAI, FIOM CGIL, FIM CISL, UILM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '87',stipula = {d '2011-06-16'},title = 'MECCANICA, ORAFI ARGENTIERI, ODONTOTECNICI: artigiani' WHERE idccnl = '87'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('87','S','MECCANICI (31) ','CONFARTIGIANATOAutoriparazione, CONFARTIGIANATOMetalmeccanicadiProduzione, CONFARTIGIANATOImpianti, CONFARTIGIANATOOrafi, CONFARTIGIANATOFe.Na.ODI, CNAProduzione, CNAInstallazionediImpianti, CNAServiziallacomunit?/Autoriparatori, CNAArtisticoetradizionale, CNABenesseree Sanit?, CASARTIGIANI, CLAAI, FIOM CGIL, FIM CISL, UILM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'87',{d '2011-06-16'},'MECCANICA, ORAFI ARGENTIERI, ODONTOTECNICI: artigiani')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '88')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'FAPI, CESAC, FESICA CONFSAL, CONFSAL FISALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '88',stipula = {d '2017-08-01'},title = 'METALMECCANICA: Artigiane (FAPI-CESAC-CONFSAL)' WHERE idccnl = '88'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('88','S','MECCANICI (31) ','FAPI, CESAC, FESICA CONFSAL, CONFSAL FISALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'88',{d '2017-08-01'},'METALMECCANICA: Artigiane (FAPI-CESAC-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '89')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-18'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '89',stipula = {d '2017-05-18'},title = 'METALMECCANICA: Artigiane (FAPI-CESAC-FILDICIU)' WHERE idccnl = '89'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('89','S','MECCANICI (31) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-18'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'89',{d '2017-05-18'},'METALMECCANICA: Artigiane (FAPI-CESAC-FILDICIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '90')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'CONFLAVORO PMI, CILS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-04-30'},scadenza = {d '2017-04-30'},sortcode = '90',stipula = {d '2012-04-30'},title = 'METALMECCANICA: artigiani (CONFLAVORO)' WHERE idccnl = '90'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('90','S','MECCANICI (31) ','CONFLAVORO PMI, CILS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-04-30'},{d '2017-04-30'},'90',{d '2012-04-30'},'METALMECCANICA: artigiani (CONFLAVORO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '91')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ESAARCO, CEPAA, ESAARCOArtigianato, SAI, FER, ASSOPONTEGGI, CILA, CIU, SICEL, CGELFNLA, CGELFNLM,ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-25'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-24'},sortcode = '91',stipula = {d '2016-11-25'},title = 'METALMECCANICA: artigiani (ESAARCO)' WHERE idccnl = '91'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('91','S','MECCANICI (31) ','ESAARCO, CEPAA, ESAARCOArtigianato, SAI, FER, ASSOPONTEGGI, CILA, CIU, SICEL, CGELFNLA, CGELFNLM,ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-25'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-24'},'91',{d '2016-11-25'},'METALMECCANICA: artigiani (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '92')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'FEDERNETWORK, SINDACATO POPOLO DELLA RETE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '92',stipula = {d '2014-07-02'},title = 'METALMECCANICA: artigiani (FEDERNETWORK)' WHERE idccnl = '92'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('92','S','MECCANICI (31) ','FEDERNETWORK, SINDACATO POPOLO DELLA RETE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'92',{d '2014-07-02'},'METALMECCANICA: artigiani (FEDERNETWORK)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '93')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'MIDA, SNIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '93',stipula = {d '2015-12-21'},title = 'METALMECCANICA: artigiani (MIDA-SNIAL)' WHERE idccnl = '93'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('93','S','MECCANICI (31) ','MIDA, SNIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'93',{d '2015-12-21'},'METALMECCANICA: artigiani (MIDA-SNIAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '94')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, FESICA, FISALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-10-31'},sortcode = '94',stipula = {d '2014-10-24'},title = 'METALMECCANICA: Aziende del comparto (CONFIMPRESEITALIA)' WHERE idccnl = '94'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('94','S','MECCANICI (31) ','CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, FESICA, FISALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-10-31'},'94',{d '2014-10-24'},'METALMECCANICA: Aziende del comparto (CONFIMPRESEITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '95')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'CPMI ITALIA, FESICA, FISALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '95',stipula = {d '2014-07-01'},title = 'METALMECCANICA: Aziende del comparto (CPMIITALIA)' WHERE idccnl = '95'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('95','S','MECCANICI (31) ','CPMI ITALIA, FESICA, FISALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'95',{d '2014-07-01'},'METALMECCANICA: Aziende del comparto (CPMIITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '96')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ANPIT, CISALMETALMECCANICI, CISAL,(adesionediUNSICeUNSICOOP dal 4/2/2014), (adesione di CIDEC dal 5/7/2017)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-31'},sortcode = '96',stipula = {d '2013-04-29'},title = 'METALMECCANICA: Aziende e Cooperative' WHERE idccnl = '96'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('96','S','MECCANICI (31) ','ANPIT, CISALMETALMECCANICI, CISAL,(adesionediUNSICeUNSICOOP dal 4/2/2014), (adesione di CIDEC dal 5/7/2017)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-31'},'96',{d '2013-04-29'},'METALMECCANICA: Aziende e Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '97')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'AGCIProduzioneeLavoro, ANCPLLEGACOOP, FederlavoroeServizi CONFCOOPERATIVE, FIM CISL, FIOM CGIL, UILM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '97',stipula = {d '2013-05-13'},title = 'METALMECCANICA: Cooperative' WHERE idccnl = '97'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('97','S','MECCANICI (31) ','AGCIProduzioneeLavoro, ANCPLLEGACOOP, FederlavoroeServizi CONFCOOPERATIVE, FIM CISL, FIOM CGIL, UILM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'97',{d '2013-05-13'},'METALMECCANICA: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '98')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ESAARCO, CEPAA, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CIU, SI CEL, CGEL FNLM, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-25'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-24'},sortcode = '98',stipula = {d '2016-11-25'},title = 'METALMECCANICA: Cooperative (ESAARCO)' WHERE idccnl = '98'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('98','S','MECCANICI (31) ','ESAARCO, CEPAA, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CIU, SI CEL, CGEL FNLM, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-25'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-24'},'98',{d '2016-11-25'},'METALMECCANICA: Cooperative (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '99')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'FCAN.V., CNHINDUSTRIALN.V., FIMCISL, UILMUIL, FISMIC, UGL METALMECCANICI, ASSOCIAZIONI QUADRI E CAPI FIAT',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '99',stipula = {d '2015-07-07'},title = 'METALMECCANICA: FIAT' WHERE idccnl = '99'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('99','S','MECCANICI (31) ','FCAN.V., CNHINDUSTRIALN.V., FIMCISL, UILMUIL, FISMIC, UGL METALMECCANICI, ASSOCIAZIONI QUADRI E CAPI FIAT',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'99',{d '2015-07-07'},'METALMECCANICA: FIAT')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '100')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ANAP, ALIM, SELP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-30'},sortcode = '100',stipula = {d '2016-01-11'},title = 'METALMECCANICA: Impresedelcomparto (ANAP-ALIM-SELP)' WHERE idccnl = '100'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('100','S','MECCANICI (31) ','ANAP, ALIM, SELP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-30'},'100',{d '2016-01-11'},'METALMECCANICA: Impresedelcomparto (ANAP-ALIM-SELP)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '101')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ACIS, UNIONLIBERI, FEDERLIBERI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-13'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '101',stipula = {d '2016-04-13'},title = 'METALMECCANICA: Imprese, PMIeCooperazione (ACIS-UNIONLIBERI-FAMAR)' WHERE idccnl = '101'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('101','S','MECCANICI (31) ','ACIS, UNIONLIBERI, FEDERLIBERI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-13'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'101',{d '2016-04-13'},'METALMECCANICA: Imprese, PMIeCooperazione (ACIS-UNIONLIBERI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '102')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-29'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-28'},sortcode = '102',stipula = {d '2016-03-22'},title = 'METALMECCANICA: Imprese, PMIeCooperazione (ADLI-FAMAR)' WHERE idccnl = '102'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('102','S','MECCANICI (31) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-29'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-28'},'102',{d '2016-03-22'},'METALMECCANICA: Imprese, PMIeCooperazione (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '103')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'FEDIMPRESE, FAMAR, SNAPEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '103',stipula = {d '2015-02-27'},title = 'METALMECCANICA: Imprese, PMIeCooperazione (FEDIMPRESE-FAMAR-SNAPEL)' WHERE idccnl = '103'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('103','S','MECCANICI (31) ','FEDIMPRESE, FAMAR, SNAPEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'103',{d '2015-02-27'},'METALMECCANICA: Imprese, PMIeCooperazione (FEDIMPRESE-FAMAR-SNAPEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '104')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'NORD INDUSTRIALE, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '104',stipula = {d '2015-02-26'},title = 'METALMECCANICA: Imprese, PMIeCooperazione (NORD INDUSTRIALE-FAMAR)' WHERE idccnl = '104'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('104','S','MECCANICI (31) ','NORD INDUSTRIALE, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'104',{d '2015-02-26'},'METALMECCANICA: Imprese, PMIeCooperazione (NORD INDUSTRIALE-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '105')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'FEDERMECCANICACONFINDUSTRIA, ASSISTALCONFINDUSTRIA, CONFINDUSTRIA, FIMCISL, CISL, UILMUIL, UIL, FISMICCONFSAL, CONFSAL, UGLMETALMECCANICI, UGL, USAS ASGB METALL, SAVT',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '105',stipula = {d '2012-12-05'},title = 'METALMECCANICA: Industrie' WHERE idccnl = '105'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('105','S','MECCANICI (31) ','FEDERMECCANICACONFINDUSTRIA, ASSISTALCONFINDUSTRIA, CONFINDUSTRIA, FIMCISL, CISL, UILMUIL, UIL, FISMICCONFSAL, CONFSAL, UGLMETALMECCANICI, UGL, USAS ASGB METALL, SAVT',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'105',{d '2012-12-05'},'METALMECCANICA: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '106')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ESAARCO, CEPA A, CEPA A Industria, SAI, FER, ASSO PONTEGGI, CIU, SI CEL, CGEL FNLM, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-25'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-24'},sortcode = '106',stipula = {d '2016-11-25'},title = 'METALMECCANICA: Industrie (ESAARCO)' WHERE idccnl = '106'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('106','S','MECCANICI (31) ','ESAARCO, CEPA A, CEPA A Industria, SAI, FER, ASSO PONTEGGI, CIU, SI CEL, CGEL FNLM, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-25'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-24'},'106',{d '2016-11-25'},'METALMECCANICA: Industrie (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '107')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'UNIONMECCANICACONFAPI, CONFAPI, FIMCISL, FIOMCGIL, UILM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2020-10-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = null,sortcode = '107',stipula = {d '2017-10-02'},title = 'METALMECCANICA: P.M.I.' WHERE idccnl = '107'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('107','S','MECCANICI (31) ','UNIONMECCANICACONFAPI, CONFAPI, FIMCISL, FIOMCGIL, UILM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-10-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,'107',{d '2017-10-02'},'METALMECCANICA: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '108')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'AEP, ADIMA,.FISMICCONFSAL, FILCOMFISMIC, SALAFISMIC, FISMICCOLF(adesionediFEDERDAT, ASSOTERZIARIO, PMIITALIA INTERNATIONAL dal 13/4/2015)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-28'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '108',stipula = {d '2014-07-28'},title = 'METALMECCANICA: P.M.I. - AEP-ADIMA' WHERE idccnl = '108'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('108','S','MECCANICI (31) ','AEP, ADIMA,.FISMICCONFSAL, FILCOMFISMIC, SALAFISMIC, FISMICCOLF(adesionediFEDERDAT, ASSOTERZIARIO, PMIITALIA INTERNATIONAL dal 13/4/2015)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-28'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'108',{d '2014-07-28'},'METALMECCANICA: P.M.I. - AEP-ADIMA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '109')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ALEAITALIA, ADEITALIA, ALEAITALIAMETALMECCANICA, ADEITALIA METALMECCANICA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-09-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-08-31'},sortcode = '109',stipula = {d '2009-09-02'},title = 'METALMECCANICA: P.M.I. - Alea-Ade' WHERE idccnl = '109'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('109','S','MECCANICI (31) ','ALEAITALIA, ADEITALIA, ALEAITALIAMETALMECCANICA, ADEITALIA METALMECCANICA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-09-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-08-31'},'109',{d '2009-09-02'},'METALMECCANICA: P.M.I. - Alea-Ade')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '110')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'CONFIMI IMPRESA MECCANICA, FIM CISL, UILM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-05-31'},sortcode = '110',stipula = {d '2016-07-22'},title = 'METALMECCANICA: P.M.I. - CONFIMI' WHERE idccnl = '110'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('110','S','MECCANICI (31) ','CONFIMI IMPRESA MECCANICA, FIM CISL, UILM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-05-31'},'110',{d '2016-07-22'},'METALMECCANICA: P.M.I. - CONFIMI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '111')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'FEDERIMPRESEITALIA, ALPAI, SALPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-14'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-01-14'},sortcode = '111',stipula = {d '2015-01-14'},title = 'METALMECCANICA: P.M.I. - FEDERIMPRESEITALIA' WHERE idccnl = '111'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('111','S','MECCANICI (31) ','FEDERIMPRESEITALIA, ALPAI, SALPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-14'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-01-14'},'111',{d '2015-01-14'},'METALMECCANICA: P.M.I. - FEDERIMPRESEITALIA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '112')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'SISTEMA IMPRESA, FISMIC CONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '112',stipula = {d '2016-06-14'},title = 'METALMECCANICA: P.M.I.(SISTEMAIMPRESA-CONFSAL)' WHERE idccnl = '112'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('112','S','MECCANICI (31) ','SISTEMA IMPRESA, FISMIC CONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'112',{d '2016-06-14'},'METALMECCANICA: P.M.I.(SISTEMAIMPRESA-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '113')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleImpreseMetalmeccaniche, UNIMPRESAFederazione NazionaleInstallatoriImpianti, CONFINTESA, CONFINTESAFederazione NazionaleLavoratori Materie Prime',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '113',stipula = {d '2017-05-04'},title = 'METALMECCANICA: P.M.I.(UNIMPRESA-CONFINTESA)' WHERE idccnl = '113'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('113','S','MECCANICI (31) ','UNIMPRESA, UNIMPRESAFederazione NazionaleImpreseMetalmeccaniche, UNIMPRESAFederazione NazionaleInstallatoriImpianti, CONFINTESA, CONFINTESAFederazione NazionaleLavoratori Materie Prime',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'113',{d '2017-05-04'},'METALMECCANICA: P.M.I.(UNIMPRESA-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '114')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'ESAARCO, CEPA A, CEPA A Industria, SAI, FER, ASSO PONTEGGI, CIU, SI CEL, CGEL FNLM, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-25'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-24'},sortcode = '114',stipula = {d '2016-11-25'},title = 'METALMECCANICA: PMI (ESAARCO)' WHERE idccnl = '114'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('114','S','MECCANICI (31) ','ESAARCO, CEPA A, CEPA A Industria, SAI, FER, ASSO PONTEGGI, CIU, SI CEL, CGEL FNLM, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-25'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-24'},'114',{d '2016-11-25'},'METALMECCANICA: PMI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '115')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '115',stipula = {d '2017-03-15'},title = 'METALMECCANICO: Industria e Artigianato' WHERE idccnl = '115'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('115','S','MECCANICI (31) ','CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'115',{d '2017-03-15'},'METALMECCANICO: Industria e Artigianato')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '116')
UPDATE [ccnl] SET active = 'S',area = 'MECCANICI (31) ',contraenti = 'CONFINDUSTRIAFEDERORAFI, ASSOCIAZIONEARGENTIERI, FIM CISL, UILM UIL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-10-31'},sortcode = '116',stipula = {d '2010-09-23'},title = 'ORAFI, ARGENTIERI: Industrie' WHERE idccnl = '116'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('116','S','MECCANICI (31) ','CONFINDUSTRIAFEDERORAFI, ASSOCIAZIONEARGENTIERI, FIM CISL, UILM UIL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-10-31'},'116',{d '2010-09-23'},'ORAFI, ARGENTIERI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '117')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'UNFI, ISA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '117',stipula = {d '2014-07-28'},title = 'Az. artigiane di Lavanderia, Tintorie ed affini (UNFI-ISA)' WHERE idccnl = '117'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('117','S','TESSILI (30) ','UNFI, ISA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'117',{d '2014-07-28'},'Az. artigiane di Lavanderia, Tintorie ed affini (UNFI-ISA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '118')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'CAPIMED, FENAPI, USAE, USPPI, CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '118',stipula = {d '2008-04-08'},title = 'Az.ArtigianediLavanderie, Tintorie,affini (CAPIMED-FENAPI-USAE-USPPI-CEL)' WHERE idccnl = '118'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('118','S','TESSILI (30) ','CAPIMED, FENAPI, USAE, USPPI, CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'118',{d '2008-04-08'},'Az.ArtigianediLavanderie, Tintorie,affini (CAPIMED-FENAPI-USAE-USPPI-CEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '119')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'CEPA, CONFIMPRESEITALIA, USAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-03-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-03-01'},sortcode = '119',stipula = {d '2011-01-28'},title = 'Az.ArtigianediLavanderie, Tintorie,affini (CEPA-CONFIMPRESEITALIA-USAE)' WHERE idccnl = '119'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('119','S','TESSILI (30) ','CEPA, CONFIMPRESEITALIA, USAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-03-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-03-01'},'119',{d '2011-01-28'},'Az.ArtigianediLavanderie, Tintorie,affini (CEPA-CONFIMPRESEITALIA-USAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '120')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'CONFIMPRESA, CNL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-06-30'},sortcode = '120',stipula = {d '2016-06-30'},title = 'Az.ArtigianediLavanderie, Tintorie,affini (CONFIMPRESA-CNL)' WHERE idccnl = '120'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('120','S','TESSILI (30) ','CONFIMPRESA, CNL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-06-30'},'120',{d '2016-06-30'},'Az.ArtigianediLavanderie, Tintorie,affini (CONFIMPRESA-CNL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '121')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'CONFIMPRESA, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-04-30'},sortcode = '121',stipula = {d '2014-04-30'},title = 'Az.ArtigianediLavanderie, Tintorie,affini (CONFIMPRESA-CONSIL)' WHERE idccnl = '121'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('121','S','TESSILI (30) ','CONFIMPRESA, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-04-30'},'121',{d '2014-04-30'},'Az.ArtigianediLavanderie, Tintorie,affini (CONFIMPRESA-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '122')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '122',stipula = {d '2011-12-22'},title = 'Az.ArtigianediLavanderie, Tintorie,affini (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '122'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('122','S','TESSILI (30) ','CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'122',{d '2011-12-22'},'Az.ArtigianediLavanderie, Tintorie,affini (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '123')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'ASSOCALZATURIFICI, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-03-31'},sortcode = '123',stipula = {d '2013-11-29'},title = 'CALZATURE: Industrie' WHERE idccnl = '123'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('123','S','TESSILI (30) ','ASSOCALZATURIFICI, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-03-31'},'123',{d '2013-11-29'},'CALZATURE: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '124')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'Uniontessile Confapi, Filtea CGIL, Femca CISL, Uilta UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-12-31'},scadenza = {d '2007-12-31'},sortcode = '124',stipula = {d '2004-06-24'},title = 'CALZATURE: P.M.I.' WHERE idccnl = '124'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('124','S','TESSILI (30) ','Uniontessile Confapi, Filtea CGIL, Femca CISL, Uilta UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-31'},{d '2007-12-31'},'124',{d '2004-06-24'},'CALZATURE: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '125')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'FEDARCOM, CIFA, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2005-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-11-30'},scadenza = {d '2009-11-30'},sortcode = '125',stipula = {d '2005-11-30'},title = 'CONTO TERZISTI, A FACON: PMI, Cooperative' WHERE idccnl = '125'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('125','S','TESSILI (30) ','FEDARCOM, CIFA, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-11-30'},{d '2009-11-30'},'125',{d '2005-11-30'},'CONTO TERZISTI, A FACON: PMI, Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '126')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'FEDIMPRESE, FAMAR, SNAPEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '126',stipula = {d '2015-02-27'},title = 'FACON: Artigianato, PMI, Cooperazione' WHERE idccnl = '126'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('126','S','TESSILI (30) ','FEDIMPRESE, FAMAR, SNAPEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'126',{d '2015-02-27'},'FACON: Artigianato, PMI, Cooperazione')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '127')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-21'},sortcode = '127',stipula = {d '2016-03-22'},title = 'FACON: Artigianato, PMI, Cooperazione (ADLI-FAMAR)' WHERE idccnl = '127'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('127','S','TESSILI (30) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-21'},'127',{d '2016-03-22'},'FACON: Artigianato, PMI, Cooperazione (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '128')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'ASSOGIOCATTOLI, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '128',stipula = {d '2017-02-20'},title = 'GIOCATTOLI, MODELLISMO ... : Industrie' WHERE idccnl = '128'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('128','S','TESSILI (30) ','ASSOGIOCATTOLI, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'128',{d '2017-02-20'},'GIOCATTOLI, MODELLISMO ... : Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '129')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'Uniontessile CONFAPI, Filtea CGIL, Femca CISL, Uilta UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-12-31'},scadenza = {d '2007-12-31'},sortcode = '129',stipula = {d '2004-06-24'},title = 'GIOCATTOLI, MODELLISMO ... : P.M.I.' WHERE idccnl = '129'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('129','S','TESSILI (30) ','Uniontessile CONFAPI, Filtea CGIL, Femca CISL, Uilta UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-31'},{d '2007-12-31'},'129',{d '2004-06-24'},'GIOCATTOLI, MODELLISMO ... : P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '130')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'ASSOSISTEMA, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '130',stipula = {d '2017-05-11'},title = 'LAVANDERIE, TINTORIE ... : Industrie' WHERE idccnl = '130'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('130','S','TESSILI (30) ','ASSOSISTEMA, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'130',{d '2017-05-11'},'LAVANDERIE, TINTORIE ... : Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '131')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'ASSOSISTEMA, UGL CHIMICI TESSILI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-06-30'},sortcode = '131',stipula = {d '2013-06-19'},title = 'LAVANDERIE, TINTORIE ... : Industrie' WHERE idccnl = '131'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('131','S','TESSILI (30) ','ASSOSISTEMA, UGL CHIMICI TESSILI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-06-30'},'131',{d '2013-06-19'},'LAVANDERIE, TINTORIE ... : Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '132')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'LEGA IMPRESA, FILAP, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-02-28'},sortcode = '132',stipula = {d '2016-04-21'},title = 'LAVORAZIONICONTOTERZIAFACON: aziendeecooperative' WHERE idccnl = '132'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('132','S','TESSILI (30) ','LEGA IMPRESA, FILAP, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-02-28'},'132',{d '2016-04-21'},'LAVORAZIONICONTOTERZIAFACON: aziendeecooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '133')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '133',stipula = {d '2016-07-29'},title = 'MODA-Pelletteria, Calzaturiero, TessileeAbbigliamento (CONFLAVORO PMI - CONFSAL)' WHERE idccnl = '133'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('133','S','TESSILI (30) ','CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'133',{d '2016-07-29'},'MODA-Pelletteria, Calzaturiero, TessileeAbbigliamento (CONFLAVORO PMI - CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '134')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'ANFAO, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '134',stipula = {d '2016-07-19'},title = 'OCCHIALI: Industrie' WHERE idccnl = '134'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('134','S','TESSILI (30) ','ANFAO, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'134',{d '2016-07-19'},'OCCHIALI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '135')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'Uniontessile Confapi, Filtea CGIL, Femca CISL, Uilta UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-12-31'},scadenza = {d '2007-12-31'},sortcode = '135',stipula = {d '2004-06-24'},title = 'OCCHIALI: P.M.I.' WHERE idccnl = '135'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('135','S','TESSILI (30) ','Uniontessile Confapi, Filtea CGIL, Femca CISL, Uilta UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-31'},{d '2007-12-31'},'135',{d '2004-06-24'},'OCCHIALI: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '136')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'AIMPESCONFINDUSTRIA, FEMCACISL, FILCTEMCGIL, UILTECUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '136',stipula = {d '2016-12-23'},title = 'OMBRELLI OMBRELLONI ...: Industrie' WHERE idccnl = '136'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('136','S','TESSILI (30) ','AIMPESCONFINDUSTRIA, FEMCACISL, FILCTEMCGIL, UILTECUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'136',{d '2016-12-23'},'OMBRELLI OMBRELLONI ...: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '137')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'AIMPESCONFINDUSTRIA, FEMCACISL, FILCTEMCGIL, UILTECUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '137',stipula = {d '2016-12-23'},title = 'PELLI E SUCCEDANEI: Industrie' WHERE idccnl = '137'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('137','S','TESSILI (30) ','AIMPESCONFINDUSTRIA, FEMCACISL, FILCTEMCGIL, UILTECUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'137',{d '2016-12-23'},'PELLI E SUCCEDANEI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '138')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'Uniontessile CONFAPI, Filtea CGIL, Femca CISL, Uilta UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-12-31'},scadenza = {d '2007-12-31'},sortcode = '138',stipula = {d '2004-06-24'},title = 'PELLI E SUCCEDANEI: P.M.I.' WHERE idccnl = '138'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('138','S','TESSILI (30) ','Uniontessile CONFAPI, Filtea CGIL, Femca CISL, Uilta UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-31'},{d '2007-12-31'},'138',{d '2004-06-24'},'PELLI E SUCCEDANEI: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '139')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'ASSOSCRITTURA, ASSOSPAZZOLE, FEMCACISL, FILCTEMCGIL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '139',stipula = {d '2016-11-22'},title = 'PENNE SPAZZOLE ... : Industrie' WHERE idccnl = '139'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('139','S','TESSILI (30) ','ASSOSCRITTURA, ASSOSPAZZOLE, FEMCACISL, FILCTEMCGIL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'139',{d '2016-11-22'},'PENNE SPAZZOLE ... : Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '140')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'Uniontessile Confapi, Filtea CGIL, Femca CISL, Uilta UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-12-31'},scadenza = {d '2007-12-31'},sortcode = '140',stipula = {d '2004-06-24'},title = 'PENNE SPAZZOLE ... : P.M.I.' WHERE idccnl = '140'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('140','S','TESSILI (30) ','Uniontessile Confapi, Filtea CGIL, Femca CISL, Uilta UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-31'},{d '2007-12-31'},'140',{d '2004-06-24'},'PENNE SPAZZOLE ... : P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '141')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'FEDERPESCACONFINDUSTRIA, FEMCACISL, FILCTEMCGIL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-06-30'},sortcode = '141',stipula = {d '2017-07-27'},title = 'RETIFICI DA PESCA' WHERE idccnl = '141'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('141','S','TESSILI (30) ','FEDERPESCACONFINDUSTRIA, FEMCACISL, FILCTEMCGIL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-06-30'},'141',{d '2017-07-27'},'RETIFICI DA PESCA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '142')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'ESAARCO, CEPAA, ESAARCOServizieTerziario, CEPAAFedercoop, SAI, CIU, SI CEL, ONAPS, FISNALCTA UGL, CLI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-10-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-10-05'},sortcode = '142',stipula = {d '2017-10-05'},title = 'TESSILIABBIGLIAMENTOMODA: Industrie (ESAARCO)' WHERE idccnl = '142'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('142','S','TESSILI (30) ','ESAARCO, CEPAA, ESAARCOServizieTerziario, CEPAAFedercoop, SAI, CIU, SI CEL, ONAPS, FISNALCTA UGL, CLI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-10-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-10-05'},'142',{d '2017-10-05'},'TESSILIABBIGLIAMENTOMODA: Industrie (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '143')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'CNAFEDERMODA, CONFARTIGIANATOFederazionenazionaledellaMODA, CASARTIGIANI, CLAAI, FILCTEMCGIL, FEMCACISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-25'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-03-31'},sortcode = '143',stipula = {d '2014-07-25'},title = 'TESSILI ABBIGLIAMENTO: Artigiane' WHERE idccnl = '143'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('143','S','TESSILI (30) ','CNAFEDERMODA, CONFARTIGIANATOFederazionenazionaledellaMODA, CASARTIGIANI, CLAAI, FILCTEMCGIL, FEMCACISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-25'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-03-31'},'143',{d '2014-07-25'},'TESSILI ABBIGLIAMENTO: Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '144')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'SMI, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '144',stipula = {d '2017-02-21'},title = 'TESSILI ABBIGLIAMENTO: Industrie' WHERE idccnl = '144'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('144','S','TESSILI (30) ','SMI, FEMCA CISL, FILCTEM CGIL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'144',{d '2017-02-21'},'TESSILI ABBIGLIAMENTO: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '145')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'AMPI, FEAPI, FEAGRI, FIALTE, UFFICIOLEGALEVERTENZECONFLIAA, CONFLIAA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-09-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-09-14'},sortcode = '145',stipula = {d '2012-09-15'},title = 'TESSILIABBIGLIAMENTO:Lavorazionicontoterziafacon' WHERE idccnl = '145'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('145','S','TESSILI (30) ','AMPI, FEAPI, FEAGRI, FIALTE, UFFICIOLEGALEVERTENZECONFLIAA, CONFLIAA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-09-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-09-14'},'145',{d '2012-09-15'},'TESSILIABBIGLIAMENTO:Lavorazionicontoterziafacon')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '146')
UPDATE [ccnl] SET active = 'S',area = 'TESSILI (30) ',contraenti = 'UNIONTESSILECONFAPI, FILCTEMCGIL, FEMCACISL, UILTECUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '146',stipula = {d '2016-10-12'},title = 'TESSILI ABBIGLIAMENTO: P.M.I.' WHERE idccnl = '146'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('146','S','TESSILI (30) ','UNIONTESSILECONFAPI, FILCTEMCGIL, FEMCACISL, UILTECUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'146',{d '2016-10-12'},'TESSILI ABBIGLIAMENTO: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '147')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FORITALY, AIC, FAGRI, ASSOTECFAGRI,IMPRENDITORI&IMPRESE, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '147',stipula = {d '2016-07-21'},title = 'AGROALIMENTARE E ATTIVITA'' AFFINI (FOR.ITALY)' WHERE idccnl = '147'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('147','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FORITALY, AIC, FAGRI, ASSOTECFAGRI,IMPRENDITORI&IMPRESE, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'147',{d '2016-07-21'},'AGROALIMENTARE E ATTIVITA'' AFFINI (FOR.ITALY)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '148')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-05-31'},sortcode = '148',stipula = {d '2017-06-01'},title = 'AGROALIMENTARE, AGRICOLTURAEPESCA (FAPI- CESAC - FILDI CIU)' WHERE idccnl = '148'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('148','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-05-31'},'148',{d '2017-06-01'},'AGROALIMENTARE, AGRICOLTURAEPESCA (FAPI- CESAC - FILDI CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '149')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FEAGRI, FEAPI, CONFIMEDAMPI, FLAUCONFLIAA,MOVIMENTOSICILIANO LAVORATORI, CELDA CONFLIAA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-31'},sortcode = '149',stipula = {d '2013-06-01'},title = 'ALIMENTAREEAGROALIMENTARE: cooperative,aziende artigiane e PMI' WHERE idccnl = '149'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('149','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FEAGRI, FEAPI, CONFIMEDAMPI, FLAUCONFLIAA,MOVIMENTOSICILIANO LAVORATORI, CELDA CONFLIAA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-31'},'149',{d '2013-06-01'},'ALIMENTAREEAGROALIMENTARE: cooperative,aziende artigiane e PMI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '150')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'LEGA IMPRESA, FILAP, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '150',stipula = {d '2017-05-29'},title = 'ALIMENTARE, AGROALIMENTARE ED AFFINI' WHERE idccnl = '150'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('150','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','LEGA IMPRESA, FILAP, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'150',{d '2017-05-29'},'ALIMENTARE, AGROALIMENTARE ED AFFINI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '151')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CESAC, FAPI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-07-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-07-14'},sortcode = '151',stipula = {d '2010-07-15'},title = 'ALIMENTARISTI PANIFICAZIONE AFFINI Artigiani' WHERE idccnl = '151'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('151','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CESAC, FAPI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-07-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-07-14'},'151',{d '2010-07-15'},'ALIMENTARISTI PANIFICAZIONE AFFINI Artigiani')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '152')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CNAAlimentare, CONFARTIGIANATOAlimentazione, CASARTIGIANI, CLAAI, FLAI CGIL, FAI CISL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '152',stipula = {d '2017-02-23'},title = 'ALIMENTARISTI: Artigiane' WHERE idccnl = '152'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('152','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CNAAlimentare, CONFARTIGIANATOAlimentazione, CASARTIGIANI, CLAAI, FLAI CGIL, FAI CISL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'152',{d '2017-02-23'},'ALIMENTARISTI: Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '153')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CICAS, CEI, CONFIMPRESA, SIA, ISA, SILSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2005-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-04-30'},scadenza = {d '2009-04-30'},sortcode = '153',stipula = {d '2010-06-14'},title = 'ALIMENTARISTI: Artigiane (CICASCEICONFIMPRESA)' WHERE idccnl = '153'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('153','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CICAS, CEI, CONFIMPRESA, SIA, ISA, SILSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-04-30'},{d '2009-04-30'},'153',{d '2010-06-14'},'ALIMENTARISTI: Artigiane (CICASCEICONFIMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '154')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'AGRITALAGCI,LEGACOOPAGROALIMENTARE, FEDAGRICONFCOOPERATIVE, FAI CISL, FLAI CGIL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-11-30'},sortcode = '154',stipula = {d '2016-03-23'},title = 'ALIMENTARISTI: Cooperative' WHERE idccnl = '154'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('154','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','AGRITALAGCI,LEGACOOPAGROALIMENTARE, FEDAGRICONFCOOPERATIVE, FAI CISL, FLAI CGIL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-11-30'},'154',{d '2016-03-23'},'ALIMENTARISTI: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '155')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'UNIMPRESA, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-31'},sortcode = '155',stipula = {d '2017-04-12'},title = 'ALIMENTARISTI: Cooperative (UNIMPRESA-CONFINTESA)' WHERE idccnl = '155'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('155','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','UNIMPRESA, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-31'},'155',{d '2017-04-12'},'ALIMENTARISTI: Cooperative (UNIMPRESA-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '156')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FEDERALIMENTARE, AIDEPI, AIIPA, ANCIT, ANICAV, ASSALZOO, ASSICA, ASSITOL, ASSOBIBE, ASSOBIRRA, ASSOCARNI, ASSOLATTE, FEDERVINI,ITALMOPA,MINERACQUA, UNIONZUCCHERO, FAI CISL, FLAI CGIL, UILA UIL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-11-30'},sortcode = '156',stipula = {d '2016-02-05'},title = 'ALIMENTARISTI: Industrie' WHERE idccnl = '156'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('156','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FEDERALIMENTARE, AIDEPI, AIIPA, ANCIT, ANICAV, ASSALZOO, ASSICA, ASSITOL, ASSOBIBE, ASSOBIRRA, ASSOCARNI, ASSOLATTE, FEDERVINI,ITALMOPA,MINERACQUA, UNIONZUCCHERO, FAI CISL, FLAI CGIL, UILA UIL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-11-30'},'156',{d '2016-02-05'},'ALIMENTARISTI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '157')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CICAS, CEI, CONFIMPRESA, SIA, ISA, SILSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-06-14'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '157',stipula = {d '2010-06-14'},title = 'ALIMENTARISTI: Industrie (CICASCEICONFIMPRESA)' WHERE idccnl = '157'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('157','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CICAS, CEI, CONFIMPRESA, SIA, ISA, SILSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-06-14'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'157',{d '2010-06-14'},'ALIMENTARISTI: Industrie (CICASCEICONFIMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '158')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'UNIMPRESA, UNIMPRESA Agricoltura, CIDEC, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '158',stipula = {d '2017-06-21'},title = 'ALIMENTARISTI:Micro, PMI (UNIMPRESA-CIDEC-CONFINTESA)' WHERE idccnl = '158'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('158','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','UNIMPRESA, UNIMPRESA Agricoltura, CIDEC, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'158',{d '2017-06-21'},'ALIMENTARISTI:Micro, PMI (UNIMPRESA-CIDEC-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '159')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'UNIONALIMENTARI CONFAPI, FAI CISL, FLAI CGIL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '159',stipula = {d '2016-09-16'},title = 'ALIMENTARISTI: P.M.I.' WHERE idccnl = '159'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('159','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','UNIONALIMENTARI CONFAPI, FAI CISL, FLAI CGIL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'159',{d '2016-09-16'},'ALIMENTARISTI: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '160')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CIFA, FedarcomCIFA, CONFSAL, FesicaCONFSAL, FisalsCONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-11-30'},sortcode = '160',stipula = {d '2016-12-19'},title = 'ALIMENTARISTI: PMI (CIFA-CONFSAL)' WHERE idccnl = '160'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('160','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CIFA, FedarcomCIFA, CONFSAL, FesicaCONFSAL, FisalsCONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-11-30'},'160',{d '2016-12-19'},'ALIMENTARISTI: PMI (CIFA-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '161')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'ACAI, CONAPI, UGL AGROALIMENTARE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-01-01'},sortcode = '161',stipula = {d '2012-12-21'},title = 'ALIMENTAZIONEePANIFICAZIONE: AziendeArtigiane' WHERE idccnl = '161'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('161','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','ACAI, CONAPI, UGL AGROALIMENTARE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-01-01'},'161',{d '2012-12-21'},'ALIMENTAZIONEePANIFICAZIONE: AziendeArtigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '162')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CAPIMED, FENAPI, USAE, USPPI, CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '162',stipula = {d '2008-04-08'},title = 'Aziende Artigiane Alimentari (CAPIMED-FENAPI-USAE-USPPI-CEL)' WHERE idccnl = '162'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('162','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CAPIMED, FENAPI, USAE, USPPI, CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'162',{d '2008-04-08'},'Aziende Artigiane Alimentari (CAPIMED-FENAPI-USAE-USPPI-CEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '163')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CEPA, CONFIMPRESEITALIA, USAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-03-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-03-01'},sortcode = '163',stipula = {d '2011-01-28'},title = 'AziendeArtigianeAlimentari (CEPA-CONFIMPRESEITALIA-USAE)' WHERE idccnl = '163'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('163','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CEPA, CONFIMPRESEITALIA, USAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-03-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-03-01'},'163',{d '2011-01-28'},'AziendeArtigianeAlimentari (CEPA-CONFIMPRESEITALIA-USAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '164')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU, CSE FNILA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '164',stipula = {d '2011-12-22'},title = 'Aziende Artigiane Alimentari (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '164'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('164','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU, CSE FNILA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'164',{d '2011-12-22'},'Aziende Artigiane Alimentari (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '165')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CEPA A, CEPA A AGRICOLTURA, CIU, FLAAF',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-10-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-10-29'},sortcode = '165',stipula = {d '2012-10-30'},title = 'AziendedeisettoriAGROALIMENTARE-AGRICOLO-AGRITURISTICO E FLOROVIVAISTICO (CEPA A-CIU)' WHERE idccnl = '165'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('165','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CEPA A, CEPA A AGRICOLTURA, CIU, FLAAF',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-10-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-10-29'},'165',{d '2012-10-30'},'AziendedeisettoriAGROALIMENTARE-AGRICOLO-AGRITURISTICO E FLOROVIVAISTICO (CEPA A-CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '166')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'UNSIC, FEDERDAT, CONFIAL, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '166',stipula = {d '2016-07-21'},title = 'INDUSTRIAALIMENTARE (UNSIC-FEDERDAT-CONFIAL-CONSIL)' WHERE idccnl = '166'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('166','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','UNSIC, FEDERDAT, CONFIAL, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'166',{d '2016-07-21'},'INDUSTRIAALIMENTARE (UNSIC-FEDERDAT-CONFIAL-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '167')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'ASSIPAN CONFCOMMERCIO, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '167',stipula = {d '2013-06-19'},title = 'PANIFICAZIONE (Assipan-Ugl)' WHERE idccnl = '167'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('167','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','ASSIPAN CONFCOMMERCIO, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'167',{d '2013-06-19'},'PANIFICAZIONE (Assipan-Ugl)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '168')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FEDARCOM, CIFA, FIADEL SP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-05-31'},sortcode = '168',stipula = {d '2011-06-01'},title = 'PANIFICAZIONE E ALIMENTARI' WHERE idccnl = '168'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('168','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FEDARCOM, CIFA, FIADEL SP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-05-31'},'168',{d '2011-06-01'},'PANIFICAZIONE E ALIMENTARI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '169')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FEDERAZIONEITALIANAPANIFICATORIPANIFICATORIPASTICCIERIEDAFFINI, ASSOPANIFICATORIFIESACONFESERCENTI, FLAI CGIL, FAI CISL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '169',stipula = {d '2013-02-13'},title = 'PANIFICAZIONE: Aziende artigianali ed industriali' WHERE idccnl = '169'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('169','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FEDERAZIONEITALIANAPANIFICATORIPANIFICATORIPASTICCIERIEDAFFINI, ASSOPANIFICATORIFIESACONFESERCENTI, FLAI CGIL, FAI CISL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'169',{d '2013-02-13'},'PANIFICAZIONE: Aziende artigianali ed industriali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '170')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FEDERAZIONEITALIANAPANIFICATORIPASTICCIERIEDAFFINI, ASSOPANIFICATORI FIESA CONFESERCENTI, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2011-12-31'},sortcode = '170',stipula = {d '2009-12-05'},title = 'PANIFICAZIONE: Aziende artigianali ed industriali' WHERE idccnl = '170'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('170','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FEDERAZIONEITALIANAPANIFICATORIPASTICCIERIEDAFFINI, ASSOPANIFICATORI FIESA CONFESERCENTI, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2011-12-31'},'170',{d '2009-12-05'},'PANIFICAZIONE: Aziende artigianali ed industriali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '171')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FORITALY, AIC, FAGRI, ASSOTECFAGRI,IMPRENDITORI&IMPRESE, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '171',stipula = {d '2016-07-21'},title = 'PESCA E ATTIVITA'' AFFINI (FOR.ITALY)' WHERE idccnl = '171'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('171','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FORITALY, AIC, FAGRI, ASSOTECFAGRI,IMPRENDITORI&IMPRESE, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'171',{d '2016-07-21'},'PESCA E ATTIVITA'' AFFINI (FOR.ITALY)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '172')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'ANAPI PESCA, CONFSAL PESCA, CONFSAL FISALS, CONFSAL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '172',stipula = {d '2015-11-05'},title = 'Pescamarittimaeimprenditoriaittica-ANAPIPescaConfsal Pesca' WHERE idccnl = '172'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('172','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','ANAPI PESCA, CONFSAL PESCA, CONFSAL FISALS, CONFSAL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'172',{d '2015-11-05'},'Pescamarittimaeimprenditoriaittica-ANAPIPescaConfsal Pesca')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '173')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'AGCIAGRITAL, FEDERCOOPESCACONFCOOPERATIVE,LEGACOOP AGROALIMENTARE, FAI CISL, FLAI CGIL, UILAPESCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-12-31'},scadenza = {d '2017-01-01'},sortcode = '173',stipula = {d '2017-02-20'},title = 'PESCA MARITTIMA: Cooperative' WHERE idccnl = '173'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('173','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','AGCIAGRITAL, FEDERCOOPESCACONFCOOPERATIVE,LEGACOOP AGROALIMENTARE, FAI CISL, FLAI CGIL, UILAPESCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-12-31'},{d '2017-01-01'},'173',{d '2017-02-20'},'PESCA MARITTIMA: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '174')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CEPAAPESCACOOPERATIVE, CEPAA, UGLAGROALIMENTARE, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-05-06'},scadenza = {d '2014-05-07'},sortcode = '174',stipula = {d '2014-05-07'},title = 'PESCA MARITTIMA: Cooperative (CEPA-A - UGL)' WHERE idccnl = '174'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('174','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CEPAAPESCACOOPERATIVE, CEPAA, UGLAGROALIMENTARE, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-06'},{d '2014-05-07'},'174',{d '2014-05-07'},'PESCA MARITTIMA: Cooperative (CEPA-A - UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '175')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CONFIMEA, FEDERTERZIARIO, CFC, UGLAGROALIMENTARE, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-07-01'},scadenza = {d '2013-07-02'},sortcode = '175',stipula = {d '2013-07-02'},title = 'PESCA MARITTIMA: Cooperative (CONFIMEA-FEDERTERZIARIO-UGL)' WHERE idccnl = '175'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('175','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CONFIMEA, FEDERTERZIARIO, CFC, UGLAGROALIMENTARE, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{d '2013-07-02'},'175',{d '2013-07-02'},'PESCA MARITTIMA: Cooperative (CONFIMEA-FEDERTERZIARIO-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '176')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'ESAARCO, CEPAA, CEPAAPesca, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CIU, SICEL, CGELFNLP,ONAPS, FISNALCTAUGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-11-24'},scadenza = {d '2016-11-25'},sortcode = '176',stipula = {d '2016-11-25'},title = 'PESCA MARITTIMA: Cooperative (ESAARCO)' WHERE idccnl = '176'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('176','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','ESAARCO, CEPAA, CEPAAPesca, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CIU, SICEL, CGELFNLP,ONAPS, FISNALCTAUGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-11-24'},{d '2016-11-25'},'176',{d '2016-11-25'},'PESCA MARITTIMA: Cooperative (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '177')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'UNICOOP, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-03-25'},scadenza = {d '2013-03-26'},sortcode = '177',stipula = {d '2013-03-26'},title = 'PESCA MARITTIMA: Cooperative (UNICOOP-UGL)' WHERE idccnl = '177'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('177','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','UNICOOP, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-25'},{d '2013-03-26'},'177',{d '2013-03-26'},'PESCA MARITTIMA: Cooperative (UNICOOP-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '178')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'FEDERPESCA, FAI CISL, FLAI CGIL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2014-01-01'},sortcode = '178',stipula = {d '2014-12-16'},title = 'PESCA MARITTIMA: Industrie' WHERE idccnl = '178'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('178','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','FEDERPESCA, FAI CISL, FLAI CGIL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2014-01-01'},'178',{d '2014-12-16'},'PESCA MARITTIMA: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '179')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'ACGIAGRITAL, FEDERCOOPESCACONFCOOPERATIVE,LEGACOOPAgroalimentareDipartimentoPesca, FAICISL, FLAICGIL, UILAPESCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '179',stipula = {d '2017-07-26'},title = 'PESCA: Cooperative' WHERE idccnl = '179'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('179','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','ACGIAGRITAL, FEDERCOOPESCACONFCOOPERATIVE,LEGACOOPAgroalimentareDipartimentoPesca, FAICISL, FLAICGIL, UILAPESCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'179',{d '2017-07-26'},'PESCA: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '180')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'ESAARCO, CEPAA, CEPAAPesca, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CIU, SICEL, CGELFNLP,ONAPS, FISNALCTAUGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-11-24'},scadenza = {d '2016-11-25'},sortcode = '180',stipula = {d '2016-11-25'},title = 'PESCA: Cooperative (ESAARCO)' WHERE idccnl = '180'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('180','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','ESAARCO, CEPAA, CEPAAPesca, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CIU, SICEL, CGELFNLP,ONAPS, FISNALCTAUGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-11-24'},{d '2016-11-25'},'180',{d '2016-11-25'},'PESCA: Cooperative (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '181')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'UNCI, UNCI PESCA, CISAL, CISAL FNASLA, CISAL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-11-30'},scadenza = {d '2015-12-01'},sortcode = '181',stipula = {d '2015-11-25'},title = 'PESCA: Cooperative (UNCI-CISAL)' WHERE idccnl = '181'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('181','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','UNCI, UNCI PESCA, CISAL, CISAL FNASLA, CISAL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-11-30'},{d '2015-12-01'},'181',{d '2015-11-25'},'PESCA: Cooperative (UNCI-CISAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '182')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'CONFEDERAZIONE COINAR, CONFSAL SIA, FEDERASSOITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-12-31'},scadenza = {d '2020-12-31'},sortcode = '182',stipula = {d '2016-09-29'},title = 'Settore ALIMENTARE e PANIFICAZIONE: ImpreseArtigiane' WHERE idccnl = '182'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('182','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','CONFEDERAZIONE COINAR, CONFSAL SIA, FEDERASSOITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-12-31'},{d '2020-12-31'},'182',{d '2016-09-29'},'Settore ALIMENTARE e PANIFICAZIONE: ImpreseArtigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '183')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'AIIPA, FAI CISL, FLAI CGIL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2012-09-30'},scadenza = {d '2009-12-01'},sortcode = '183',stipula = {d '2009-12-09'},title = 'SOTTOPRODOTTI DELLA MACELLAZIONE' WHERE idccnl = '183'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('183','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','AIIPA, FAI CISL, FLAI CGIL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-09-30'},{d '2009-12-01'},'183',{d '2009-12-09'},'SOTTOPRODOTTI DELLA MACELLAZIONE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '184')
UPDATE [ccnl] SET active = 'S',area = 'ALIMENTARISTI - AGROINDUSTRIALE (38) ',contraenti = 'APTI, FLAI CGIL, FAI CISL, UILA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-12-31'},scadenza = {d '2011-01-01'},sortcode = '184',stipula = {d '2011-07-25'},title = 'TABACCO: (Lavorazione del)' WHERE idccnl = '184'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('184','S','ALIMENTARISTI - AGROINDUSTRIALE (38) ','APTI, FLAI CGIL, FAI CISL, UILA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-12-31'},{d '2011-01-01'},'184',{d '2011-07-25'},'TABACCO: (Lavorazione del)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '185')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CNAProduzione, CNACostruzioni, CONFARTIGIANATOLegnoaArredo, CONFARTIGIANATOMarmisti, CASARTIGIANI, CLAAI, FENEAL UIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2016-01-01'},sortcode = '185',stipula = {d '2018-03-13'},title = 'Area LEGNO LAPIDEI: Artigiane' WHERE idccnl = '185'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('185','S','EDILIZIA (71) ','CNAProduzione, CNACostruzioni, CONFARTIGIANATOLegnoaArredo, CONFARTIGIANATOMarmisti, CASARTIGIANI, CLAAI, FENEAL UIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2016-01-01'},'185',{d '2018-03-13'},'Area LEGNO LAPIDEI: Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '186')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CAPIMED, FENAPI, USAE, USPPI, CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '186',stipula = {d '2008-04-08'},title = 'Aziende Artigiane del Legno ed Affini (CAPIMED-FENAPI-USAE-USPPI-CEL)' WHERE idccnl = '186'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('186','S','EDILIZIA (71) ','CAPIMED, FENAPI, USAE, USPPI, CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'186',{d '2008-04-08'},'Aziende Artigiane del Legno ed Affini (CAPIMED-FENAPI-USAE-USPPI-CEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '187')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CEPA, CONFIMPRESEITALIA, USAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-03-01'},scadenza = {d '2011-03-02'},sortcode = '187',stipula = {d '2011-01-28'},title = 'Aziende Artigiane del Legno ed Affini (CEPA-CONFIMPRESEITALIA-USAE)' WHERE idccnl = '187'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('187','S','EDILIZIA (71) ','CEPA, CONFIMPRESEITALIA, USAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-03-01'},{d '2011-03-02'},'187',{d '2011-01-28'},'Aziende Artigiane del Legno ed Affini (CEPA-CONFIMPRESEITALIA-USAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '188')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSEFNILASU, CSE FNILEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2012-01-01'},sortcode = '188',stipula = {d '2011-12-22'},title = 'Aziende Artigiane del Legno ed Affini (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '188'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('188','S','EDILIZIA (71) ','CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSEFNILASU, CSE FNILEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2012-01-01'},'188',{d '2011-12-22'},'Aziende Artigiane del Legno ed Affini (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '189')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDERMACO, FENEAL UIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2015-11-24'},sortcode = '189',stipula = {d '2015-11-24'},title = 'CEMENTO, CALCE, GESSO: Industrie' WHERE idccnl = '189'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('189','S','EDILIZIA (71) ','FEDERMACO, FENEAL UIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2015-11-24'},'189',{d '2015-11-24'},'CEMENTO, CALCE, GESSO: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '190')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDERMACO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-03-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '190',stipula = {d '2013-03-22'},title = 'CEMENTO, CALCE, GESSO: Industrie' WHERE idccnl = '190'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('190','S','EDILIZIA (71) ','FEDERMACO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-03-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'190',{d '2013-03-22'},'CEMENTO, CALCE, GESSO: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '191')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFAPI ANIEM, FENEAL UIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-24'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '191',stipula = {d '2017-01-24'},title = 'CEMENTO, CALCE, GESSO: P.M.I.' WHERE idccnl = '191'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('191','S','EDILIZIA (71) ','CONFAPI ANIEM, FENEAL UIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-24'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'191',{d '2017-01-24'},'CEMENTO, CALCE, GESSO: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '192')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CEPAA, CEPAACOSTRUTTORIEDILIEAFFINI, CILA,LUCI, SICEL, FNLE, CONF LAVORATORI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-03-26'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-03-25'},sortcode = '192',stipula = {d '2013-03-26'},title = 'CEMENTO, CALCE, GESSO: P.M.I. - CEPA-A' WHERE idccnl = '192'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('192','S','EDILIZIA (71) ','CEPAA, CEPAACOSTRUTTORIEDILIEAFFINI, CILA,LUCI, SICEL, FNLE, CONF LAVORATORI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-03-26'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-03-25'},'192',{d '2013-03-26'},'CEMENTO, CALCE, GESSO: P.M.I. - CEPA-A')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '193')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANIEMCONFIMIIMPRESA, ANIERCONFIMIIMPRESA, FENEALUIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-18'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '193',stipula = {d '2016-04-18'},title = 'CEMENTO, CALCE,GESSO: P.M.I.-CONFIMIIMPRESA' WHERE idccnl = '193'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('193','S','EDILIZIA (71) ','ANIEMCONFIMIIMPRESA, ANIERCONFIMIIMPRESA, FENEALUIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-18'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'193',{d '2016-04-18'},'CEMENTO, CALCE,GESSO: P.M.I.-CONFIMIIMPRESA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '194')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEEDILIZIA, ACSASSOCIAZIONECOOPERATIVEDISERVIZI, CSECONFEDERAZIONEINDIPENDENTESINDACATIEUROPEI, CSEFNILAPMI, CSEFNLEL, CSECOOP, CSEFNILASU, CSEFNLEI, CSE DIR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-12-31'},scadenza = {d '2015-12-31'},sortcode = '194',stipula = {d '2011-12-22'},title = 'CEMENTO, CALCE, GESSO: P.M.I. - CSE' WHERE idccnl = '194'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('194','S','EDILIZIA (71) ','CONFIMPRESEITALIA, CONFIMPRESEEDILIZIA, ACSASSOCIAZIONECOOPERATIVEDISERVIZI, CSECONFEDERAZIONEINDIPENDENTESINDACATIEUROPEI, CSEFNILAPMI, CSEFNLEL, CSECOOP, CSEFNILASU, CSEFNLEI, CSE DIR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-12-31'},{d '2015-12-31'},'194',{d '2011-12-22'},'CEMENTO, CALCE, GESSO: P.M.I. - CSE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '195')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'USAEFNLE, FNPSL, CONFIMPRESEITALIA, CONFEUROPA, CILA, PMIAGRIGENTO, CONFIMIT, ENEAS, ASSOCOSTRUTTORI, ASPIN',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-03-27'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2012-03-26'},scadenza = {d '2014-03-27'},sortcode = '195',stipula = {d '2010-03-27'},title = 'CEMENTO, CALCE, GESSO: P.M.I. - USAE' WHERE idccnl = '195'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('195','S','EDILIZIA (71) ','USAEFNLE, FNPSL, CONFIMPRESEITALIA, CONFEUROPA, CILA, PMIAGRIGENTO, CONFIMIT, ENEAS, ASSOCOSTRUTTORI, ASPIN',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-03-27'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-03-26'},{d '2014-03-27'},'195',{d '2010-03-27'},'CEMENTO, CALCE, GESSO: P.M.I. - USAE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '196')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ESAARCO CIU, UGL FNLE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-02-07'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-02-06'},sortcode = '196',stipula = {d '2014-02-06'},title = 'EDILI, COSTRUZIONI, RESTAUROEAFFINI: artigianato e cooperative' WHERE idccnl = '196'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('196','S','EDILIZIA (71) ','ESAARCO CIU, UGL FNLE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-02-07'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-02-06'},'196',{d '2014-02-06'},'EDILI, COSTRUZIONI, RESTAUROEAFFINI: artigianato e cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '197')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANAEPACONFARTIGIANATOEDILIZIA, CNACOSTRUZIONI, FIAECASARTIGIANI,DIPARTIMENTOEDILECLAAI, FENEALUIL, FILCACISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-03-31'},sortcode = '197',stipula = {d '2014-01-24'},title = 'EDILI: Artigiane' WHERE idccnl = '197'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('197','S','EDILIZIA (71) ','ANAEPACONFARTIGIANATOEDILIZIA, CNACOSTRUZIONI, FIAECASARTIGIANI,DIPARTIMENTOEDILECLAAI, FENEALUIL, FILCACISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-03-31'},'197',{d '2014-01-24'},'EDILI: Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '198')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRESA, CNL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-30'},sortcode = '198',stipula = {d '2015-11-27'},title = 'EDILI: aziende artigiane e PMI - CONFIMPRESA-CNL' WHERE idccnl = '198'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('198','S','EDILIZIA (71) ','CONFIMPRESA, CNL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-30'},'198',{d '2015-11-27'},'EDILI: aziende artigiane e PMI - CONFIMPRESA-CNL')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '199')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRESA, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-04-30'},sortcode = '199',stipula = {d '2014-04-30'},title = 'EDILI: aziende artigiane e PMI-CONFIMPRESA-CONSIL' WHERE idccnl = '199'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('199','S','EDILIZIA (71) ','CONFIMPRESA, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-04-30'},'199',{d '2014-04-30'},'EDILI: aziende artigiane e PMI-CONFIMPRESA-CONSIL')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '200')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'AEP, ADIMA, FISMICCONFSAL, FILCOMFISMIC, SALAFISMIC, FISMICCOLF(adesionediFEDERDAT, ASSOTERZIARIO, PMIITALIA INTERNATIONAL dal 13/4/2015)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-01-31'},sortcode = '200',stipula = {d '2015-02-01'},title = 'EDILI: aziende del settore ed affini (FISMICCONFSAL-ADIMA-AEP)' WHERE idccnl = '200'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('200','S','EDILIZIA (71) ','AEP, ADIMA, FISMICCONFSAL, FILCOMFISMIC, SALAFISMIC, FISMICCOLF(adesionediFEDERDAT, ASSOTERZIARIO, PMIITALIA INTERNATIONAL dal 13/4/2015)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-01-31'},'200',{d '2015-02-01'},'EDILI: aziende del settore ed affini (FISMICCONFSAL-ADIMA-AEP)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '201')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FIDAP IMPRESE, FISAL ITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-12-31'},sortcode = '201',stipula = {d '2017-12-27'},title = 'EDILI: aziende dell''Industriae dell''Artigianato (FIDAPIMPRESE - FISAL ITALIA)' WHERE idccnl = '201'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('201','S','EDILIZIA (71) ','FIDAP IMPRESE, FISAL ITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-12-31'},'201',{d '2017-12-27'},'EDILI: aziende dell''Industriae dell''Artigianato (FIDAPIMPRESE - FISAL ITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '202')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANCE, ACI-PL(ANCPLLEGACOOP, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCIPRODUZIONEELAVORO), FENEALUIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '202',stipula = {d '2014-07-01'},title = 'EDILI: Cooperative di Produzione e Lavoro' WHERE idccnl = '202'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('202','S','EDILIZIA (71) ','ANCE, ACI-PL(ANCPLLEGACOOP, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCIPRODUZIONEELAVORO), FENEALUIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'202',{d '2014-07-01'},'EDILI: Cooperative di Produzione e Lavoro')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '203')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ESAARCO, CEPAA, CEPAACostruttoriedilieaffini, CEPAAFedercoop, SAI, ALIM, FER, CONFIMPRESA, ASSOPONTEGGI, UNI PMI, PMI ITALIA INTERNATIONAL, CIU, SI CEL, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '203',stipula = {d '2014-11-01'},title = 'EDILI: CooperativediProduzioneeLavoro (ESAARCO)' WHERE idccnl = '203'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('203','S','EDILIZIA (71) ','ESAARCO, CEPAA, CEPAACostruttoriedilieaffini, CEPAAFedercoop, SAI, ALIM, FER, CONFIMPRESA, ASSOPONTEGGI, UNI PMI, PMI ITALIA INTERNATIONAL, CIU, SI CEL, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'203',{d '2014-11-01'},'EDILI: CooperativediProduzioneeLavoro (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '204')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFSAAP, UPLA, FENAPI, FASPI, UAI, ALPPI, FENALPI, FIRASSPP, FIRAS Edilizia, IMMEXA, CONFELP, ALI CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-10-17'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-10-17'},sortcode = '204',stipula = {d '2016-10-13'},title = 'EDILI: Dipendenti delle PMI del settore Edile e affini' WHERE idccnl = '204'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('204','S','EDILIZIA (71) ','CONFSAAP, UPLA, FENAPI, FASPI, UAI, ALPPI, FENALPI, FIRASSPP, FIRAS Edilizia, IMMEXA, CONFELP, ALI CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-17'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-10-17'},'204',{d '2016-10-13'},'EDILI: Dipendenti delle PMI del settore Edile e affini')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '205')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFINNOVA, FEDERSICUREZZA ITALIA, SINAST, FIADEL CISAL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-11-30'},sortcode = '205',stipula = {d '2016-12-02'},title = 'EDILI: DipendentiimpreseartigianeePMIindustrialieaffini' WHERE idccnl = '205'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('205','S','EDILIZIA (71) ','CONFINNOVA, FEDERSICUREZZA ITALIA, SINAST, FIADEL CISAL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-11-30'},'205',{d '2016-12-02'},'EDILI: DipendentiimpreseartigianeePMIindustrialieaffini')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '206')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-18'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '206',stipula = {d '2017-05-18'},title = 'EDILI: Imprese artigiane (FAPI-CESAC-FILDI CIU)' WHERE idccnl = '206'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('206','S','EDILIZIA (71) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-18'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'206',{d '2017-05-18'},'EDILI: Imprese artigiane (FAPI-CESAC-FILDI CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '207')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'UNIMPRESA, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-31'},sortcode = '207',stipula = {d '2017-04-12'},title = 'EDILI: ImpreseartigianeePMI (UNIMPRESA-CONFINTESA)' WHERE idccnl = '207'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('207','S','EDILIZIA (71) ','UNIMPRESA, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-31'},'207',{d '2017-04-12'},'EDILI: ImpreseartigianeePMI (UNIMPRESA-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '208')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ESAARCO, ESAARCOArtigianato, CEPAA, CEPAACostruttoriedilieaffini, SAI, FER, ASSOPONTEGGI, CILA, CIU, SICEL,ONAPS, UGL FNLE, CGEL FNLA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-08-04'},sortcode = '208',stipula = {d '2016-08-05'},title = 'EDILI: imprese artigiane edili e affini (ESAARCO)' WHERE idccnl = '208'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('208','S','EDILIZIA (71) ','ESAARCO, ESAARCOArtigianato, CEPAA, CEPAACostruttoriedilieaffini, SAI, FER, ASSOPONTEGGI, CILA, CIU, SICEL,ONAPS, UGL FNLE, CGEL FNLA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-08-04'},'208',{d '2016-08-05'},'EDILI: imprese artigiane edili e affini (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '209')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDARCOM, CIFA, FIADEL SP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-06-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-06-14'},sortcode = '209',stipula = {d '2010-06-15'},title = 'EDILI: impreseartigiane,coop., PMI-FEDARCOM-CIFA-FIADEL' WHERE idccnl = '209'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('209','S','EDILIZIA (71) ','FEDARCOM, CIFA, FIADEL SP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-06-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-06-14'},'209',{d '2010-06-15'},'EDILI: impreseartigiane,coop., PMI-FEDARCOM-CIFA-FIADEL')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '210')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ADLI, ASSIDAL, FIRAS_SPPCIU, FAMARCONFAMAR, FLSCONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-01-31'},sortcode = '210',stipula = {d '2017-02-01'},title = 'EDILI: Imprese del settore edile e attivit? affini' WHERE idccnl = '210'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('210','S','EDILIZIA (71) ','ADLI, ASSIDAL, FIRAS_SPPCIU, FAMARCONFAMAR, FLSCONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-01-31'},'210',{d '2017-02-01'},'EDILI: Imprese del settore edile e attivit? affini')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '211')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FOR ITALY, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-01-31'},sortcode = '211',stipula = {d '2018-01-25'},title = 'EDILI: Impresedelsettoreedileeattivit?affini (FORITALY - FAMAR)' WHERE idccnl = '211'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('211','S','EDILIZIA (71) ','FOR ITALY, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-01-31'},'211',{d '2018-01-25'},'EDILI: Impresedelsettoreedileeattivit?affini (FORITALY - FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '212')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFAR, CONFSAL SIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-12-31'},scadenza = {d '2017-12-31'},sortcode = '212',stipula = {d '2013-03-22'},title = 'EDILI: impreseecoop.artigiane, PMI-CONFAR-CONFSAL SIA' WHERE idccnl = '212'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('212','S','EDILIZIA (71) ','CONFAR, CONFSAL SIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-12-31'},{d '2017-12-31'},'212',{d '2013-03-22'},'EDILI: impreseecoop.artigiane, PMI-CONFAR-CONFSAL SIA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '213')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFLAVOROPMI, CILSCONFEDERAZIONEITALIANALAVORATORI SICURI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-12-31'},scadenza = {d '2016-12-31'},sortcode = '213',stipula = {d '2011-12-28'},title = 'EDILI: impreseecoop.artigiane, PMI-CONFLAVOROPMI-CILS' WHERE idccnl = '213'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('213','S','EDILIZIA (71) ','CONFLAVOROPMI, CILSCONFEDERAZIONEITALIANALAVORATORI SICURI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-12-31'},{d '2016-12-31'},'213',{d '2011-12-28'},'EDILI: impreseecoop.artigiane, PMI-CONFLAVOROPMI-CILS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '214')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANPE, ALPAI, AIFES',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-09-30'},sortcode = '214',stipula = {d '2017-09-26'},title = 'EDILI: imprese edili e affini (ANPE-ALPAI-AIFES)' WHERE idccnl = '214'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('214','S','EDILIZIA (71) ','ANPE, ALPAI, AIFES',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-09-30'},'214',{d '2017-09-26'},'EDILI: imprese edili e affini (ANPE-ALPAI-AIFES)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '215')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-07-06'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-07-05'},sortcode = '215',stipula = {d '2015-07-02'},title = 'EDILI: impreseedilieaffini (CONFIMPRENDITORI-USIL)' WHERE idccnl = '215'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('215','S','EDILIZIA (71) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-07-06'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-07-05'},'215',{d '2015-07-02'},'EDILI: impreseedilieaffini (CONFIMPRENDITORI-USIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '216')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ESAARCO, CEPAA, CEPAACostruttoriedilieaffini, SAI, FER, ASSOPONTEGGI, CIU, SICEL,ONAPS, FNLEUGL, FISNALCTAUGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-10-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-10-04'},sortcode = '216',stipula = {d '2016-10-05'},title = 'EDILI: imprese edili e affini (ESAARCO)' WHERE idccnl = '216'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('216','S','EDILIZIA (71) ','ESAARCO, CEPAA, CEPAACostruttoriedilieaffini, SAI, FER, ASSOPONTEGGI, CIU, SICEL,ONAPS, FNLEUGL, FISNALCTAUGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-10-04'},'216',{d '2016-10-05'},'EDILI: imprese edili e affini (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '217')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDERIMPRESEITALIA, ALPAI, SALPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-14'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-01-14'},sortcode = '217',stipula = {d '2015-01-14'},title = 'EDILI: Imprese edili e affini (FEDERIMPRESEITALIA)' WHERE idccnl = '217'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('217','S','EDILIZIA (71) ','FEDERIMPRESEITALIA, ALPAI, SALPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-14'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-01-14'},'217',{d '2015-01-14'},'EDILI: Imprese edili e affini (FEDERIMPRESEITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '218')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'LEGA IMPRESA, FILAP, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '218',stipula = {d '2017-05-29'},title = 'EDILI: imprese edili e affini (LEGA IMPRESA)' WHERE idccnl = '218'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('218','S','EDILIZIA (71) ','LEGA IMPRESA, FILAP, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'218',{d '2017-05-29'},'EDILI: imprese edili e affini (LEGA IMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '219')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ASP, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-03-12'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-03-11'},sortcode = '219',stipula = {d '2018-02-26'},title = 'EDILI: imprese edili ed affini (ASP-CONSIL)' WHERE idccnl = '219'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('219','S','EDILIZIA (71) ','ASP, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-03-12'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-03-11'},'219',{d '2018-02-26'},'EDILI: imprese edili ed affini (ASP-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '220')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDERDAT, UNSIC, UNSICOOP, CONFIAL, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-10-31'},sortcode = '220',stipula = {d '2016-10-06'},title = 'EDILI: impreseediliedaffini (FEDERDAT-UNSIC-UNSICOOP-CONFIAL-CONSIL)' WHERE idccnl = '220'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('220','S','EDILIZIA (71) ','FEDERDAT, UNSIC, UNSICOOP, CONFIAL, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-10-31'},'220',{d '2016-10-06'},'EDILI: impreseediliedaffini (FEDERDAT-UNSIC-UNSICOOP-CONFIAL-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '221')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMEA, AECP, AGROIMPRESA, ASSIMPRESA, CICAS, CONFUNAI, CONFAPPI, UNICA, FISMIC, ISA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-04-30'},sortcode = '221',stipula = {d '2010-05-12'},title = 'EDILI: Imprese, coop. artigiane, PMI - CONFIMEA' WHERE idccnl = '221'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('221','S','EDILIZIA (71) ','CONFIMEA, AECP, AGROIMPRESA, ASSIMPRESA, CICAS, CONFUNAI, CONFAPPI, UNICA, FISMIC, ISA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-04-30'},'221',{d '2010-05-12'},'EDILI: Imprese, coop. artigiane, PMI - CONFIMEA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '222')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANCE, ACI-PL(ANCPLLEGACOOP, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCIPRODUZIONEELAVORO), FENEALUIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '222',stipula = {d '2014-07-01'},title = 'EDILI: Industrie' WHERE idccnl = '222'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('222','S','EDILIZIA (71) ','ANCE, ACI-PL(ANCPLLEGACOOP, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCIPRODUZIONEELAVORO), FENEALUIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'222',{d '2014-07-01'},'EDILI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '223')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CNAI, UNAPI, FISMIC CONFSAL, FILCOM FISMIC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-04-30'},sortcode = '223',stipula = {d '2012-04-23'},title = 'EDILI: Industrie - CNAI-UNAPI' WHERE idccnl = '223'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('223','S','EDILIZIA (71) ','CNAI, UNAPI, FISMIC CONFSAL, FILCOM FISMIC',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-04-30'},'223',{d '2012-04-23'},'EDILI: Industrie - CNAI-UNAPI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '224')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDAPI CONAPI, CONFINTESA Edilizia ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-04'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-03'},sortcode = '224',stipula = {d '2016-03-04'},title = 'EDILI: Micro, PMI, Artigiane (CONAPI-CONFINTESA)' WHERE idccnl = '224'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('224','S','EDILIZIA (71) ','FEDAPI CONAPI, CONFINTESA Edilizia ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-04'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-03'},'224',{d '2016-03-04'},'EDILI: Micro, PMI, Artigiane (CONAPI-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '225')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSEFNILASU, CSE FNILEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2012-01-01'},sortcode = '225',stipula = {d '2011-12-22'},title = 'EDILI: micro, PMI,artigiane,cooperative-CONFIMPRESEITALIA-ACS-CSE' WHERE idccnl = '225'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('225','S','EDILIZIA (71) ','CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSEFNILASU, CSE FNILEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2012-01-01'},'225',{d '2011-12-22'},'EDILI: micro, PMI,artigiane,cooperative-CONFIMPRESEITALIA-ACS-CSE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '226')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFAPI ANIEM, FENEAL UIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '226',stipula = {d '2014-11-12'},title = 'EDILI: P.M.I.' WHERE idccnl = '226'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('226','S','EDILIZIA (71) ','CONFAPI ANIEM, FENEAL UIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'226',{d '2014-11-12'},'EDILI: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '227')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANIEMCONFIMIIMPRESA, ANIERCONFIMIIMPRESA, FENEALUIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2013-11-01'},sortcode = '227',stipula = {d '2013-10-28'},title = 'EDILI: P.M.I. - CONFIMI IMPRESA' WHERE idccnl = '227'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('227','S','EDILIZIA (71) ','ANIEMCONFIMIIMPRESA, ANIERCONFIMIIMPRESA, FENEALUIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2013-11-01'},'227',{d '2013-10-28'},'EDILI: P.M.I. - CONFIMI IMPRESA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '228')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ALEAITALIA, ADEITALIA, ALEAITALIAEDILIZIA, ADEITALIAEDILIZIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-08-31'},scadenza = {d '2009-09-02'},sortcode = '228',stipula = {d '2009-09-02'},title = 'EDILI: P.M.I. Artigianato e cooperative' WHERE idccnl = '228'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('228','S','EDILIZIA (71) ','ALEAITALIA, ADEITALIA, ALEAITALIAEDILIZIA, ADEITALIAEDILIZIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-08-31'},{d '2009-09-02'},'228',{d '2009-09-02'},'EDILI: P.M.I. Artigianato e cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '229')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, FEDERTERZIARIOSUD, UGLCOSTRUZIONI, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2014-12-01'},sortcode = '229',stipula = {d '2014-12-17'},title = 'EDILI: P.M.I. Artigiane - UGL' WHERE idccnl = '229'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('229','S','EDILIZIA (71) ','FEDERTERZIARIO, CONFIMEA, CFC, FEDERTERZIARIOSUD, UGLCOSTRUZIONI, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2014-12-01'},'229',{d '2014-12-17'},'EDILI: P.M.I. Artigiane - UGL')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '230')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CEPA A, UGL COSTRUZIONI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-10-15'},scadenza = {d '2013-10-15'},sortcode = '230',stipula = {d '2013-10-15'},title = 'EDILI: P.M.I. Artigiane (CEPA-A - UGL)' WHERE idccnl = '230'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('230','S','EDILIZIA (71) ','CEPA A, UGL COSTRUZIONI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-15'},{d '2013-10-15'},'230',{d '2013-10-15'},'EDILI: P.M.I. Artigiane (CEPA-A - UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '231')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CIU, FNLEUGL, UGLFISNALCTA, CONFEDERAZIONEGENERALEEUROPEA DEI LAVORATORI, CEPA A, ESAARCO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-08-15'},scadenza = {d '2015-08-16'},sortcode = '231',stipula = {d '2015-08-05'},title = 'EDILI: P.M.I. Artigiane Cooperative' WHERE idccnl = '231'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('231','S','EDILIZIA (71) ','CIU, FNLEUGL, UGLFISNALCTA, CONFEDERAZIONEGENERALEEUROPEA DEI LAVORATORI, CEPA A, ESAARCO',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-08-15'},{d '2015-08-16'},'231',{d '2015-08-05'},'EDILI: P.M.I. Artigiane Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '232')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CNAI, UNAPI, FISMIC CONFSAL, FILCOM FISMIC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-04-30'},scadenza = {d '2012-05-01'},sortcode = '232',stipula = {d '2012-04-23'},title = 'EDILI: P.M.I. Artigiane Cooperative - CNAI' WHERE idccnl = '232'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('232','S','EDILIZIA (71) ','CNAI, UNAPI, FISMIC CONFSAL, FILCOM FISMIC',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-04-30'},{d '2012-05-01'},'232',{d '2012-04-23'},'EDILI: P.M.I. Artigiane Cooperative - CNAI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '233')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ITALIAIMPRESA, ASSIMPRESA, ASSIMPRESAITALIA, SITALED, CONFLAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-03-14'},scadenza = {d '2012-03-15'},sortcode = '233',stipula = {d '2012-03-23'},title = 'EDILI: Piccole e Medie Imprese - ITALIA IMPRESA' WHERE idccnl = '233'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('233','S','EDILIZIA (71) ','ITALIAIMPRESA, ASSIMPRESA, ASSIMPRESAITALIA, SITALED, CONFLAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-14'},{d '2012-03-15'},'233',{d '2012-03-23'},'EDILI: Piccole e Medie Imprese - ITALIA IMPRESA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '234')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2012-01-01'},sortcode = '234',stipula = {d '2012-05-19'},title = 'EDILI: PMIartigianeindustrialieaffini-CONFIMPRENDITORI' WHERE idccnl = '234'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('234','S','EDILIZIA (71) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2012-01-01'},'234',{d '2012-05-19'},'EDILI: PMIartigianeindustrialieaffini-CONFIMPRENDITORI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '235')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FENAEDCONFIMPRESEITALIA, CONFIMPRESEITALIA, UGLCOSTRUZIONI, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2014-01-01'},sortcode = '235',stipula = {d '2013-11-15'},title = 'EDILI: PMI e affini - CONFIMPRESE ITALIA-UGL)' WHERE idccnl = '235'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('235','S','EDILIZIA (71) ','FENAEDCONFIMPRESEITALIA, CONFIMPRESEITALIA, UGLCOSTRUZIONI, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2014-01-01'},'235',{d '2013-11-15'},'EDILI: PMI e affini - CONFIMPRESE ITALIA-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '236')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ESAARCO, CEPAA, CEPAACostruttoriedilieaffini, SAI, ALIM, FER, CONFIMPRESA, ASSOPONTEGGI, UNIPMI, PMIITALIAINTERNATIONAL, CIU, SI CEL, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2014-11-01'},sortcode = '236',stipula = {d '2014-11-01'},title = 'EDILI: PMI e affini (ESAARCO)' WHERE idccnl = '236'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('236','S','EDILIZIA (71) ','ESAARCO, CEPAA, CEPAACostruttoriedilieaffini, SAI, ALIM, FER, CONFIMPRESA, ASSOPONTEGGI, UNIPMI, PMIITALIAINTERNATIONAL, CIU, SI CEL, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2014-11-01'},'236',{d '2014-11-01'},'EDILI: PMI e affini (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '237')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CCOPITALIANE, CONFSAAP, AECP, UPLA, CEPAA, CEPAAINDUSTRIAECOSTRUZIONI, CEPAATERZIARIO,IMPRESAITALIA, ALDEPI, ALPPI, FENALPI, CONFLAVORATORI, FNLEUGL, CONFAIL, FASPI CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-05-31'},scadenza = {d '2014-06-01'},sortcode = '237',stipula = {d '2014-05-28'},title = 'EDILI: PMI e Cooperative' WHERE idccnl = '237'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('237','S','EDILIZIA (71) ','CCOPITALIANE, CONFSAAP, AECP, UPLA, CEPAA, CEPAAINDUSTRIAECOSTRUZIONI, CEPAATERZIARIO,IMPRESAITALIA, ALDEPI, ALPPI, FENALPI, CONFLAVORATORI, FNLEUGL, CONFAIL, FASPI CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-31'},{d '2014-06-01'},'237',{d '2014-05-28'},'EDILI: PMI e Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '238')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANAP, ALIM, SELP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2015-07-02'},sortcode = '238',stipula = {d '2015-07-02'},title = 'EDILI: PMI ed affini (ANAP)' WHERE idccnl = '238'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('238','S','EDILIZIA (71) ','ANAP, ALIM, SELP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2015-07-02'},'238',{d '2015-07-02'},'EDILI: PMI ed affini (ANAP)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '239')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'LEGA IMPRESA, FILAP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2015-11-09'},sortcode = '239',stipula = {d '2015-11-09'},title = 'EDILI: PMI ed affini (LEGA IMPRESA)' WHERE idccnl = '239'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('239','S','EDILIZIA (71) ','LEGA IMPRESA, FILAP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2015-11-09'},'239',{d '2015-11-09'},'EDILI: PMI ed affini (LEGA IMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '240')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'SAL, ANCORS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-11-25'},scadenza = {d '2012-11-26'},sortcode = '240',stipula = {d '2012-10-22'},title = 'EDILI: PMI industriali artigiane - SAL-ANCORS' WHERE idccnl = '240'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('240','S','EDILIZIA (71) ','SAL, ANCORS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-11-25'},{d '2012-11-26'},'240',{d '2012-10-22'},'EDILI: PMI industriali artigiane - SAL-ANCORS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '241')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'SULSINDACATOUNITARIODEILAVORATORI,MCRIMPASSMICRO PICCOLE MEDIE IMPRESE ED ARTIGIANE ASSOCIATE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2010-04-01'},sortcode = '241',stipula = {d '2010-03-31'},title = 'EDILIZIA: CCNL settore costruzioni ' WHERE idccnl = '241'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('241','S','EDILIZIA (71) ','SULSINDACATOUNITARIODEILAVORATORI,MCRIMPASSMICRO PICCOLE MEDIE IMPRESE ED ARTIGIANE ASSOCIATE',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2010-04-01'},'241',{d '2010-03-31'},'EDILIZIA: CCNL settore costruzioni ')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '242')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CEPAA, CEPAACOSTRUTTORIEDILIEAFFINI, CILA,LUCI, SICEL, FNLE, CONF LAVORATORI ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-03-25'},scadenza = {d '2013-03-26'},sortcode = '242',stipula = {d '2013-03-26'},title = 'LAPIDEI (Escavazione, Trivellazione e Lavorazione): imprese artigiane' WHERE idccnl = '242'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('242','S','EDILIZIA (71) ','CEPAA, CEPAACOSTRUTTORIEDILIEAFFINI, CILA,LUCI, SICEL, FNLE, CONF LAVORATORI ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-25'},{d '2013-03-26'},'242',{d '2013-03-26'},'LAPIDEI (Escavazione, Trivellazione e Lavorazione): imprese artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '243')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEEDILIZIA, ACS, CSE, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSEFNILASU, CSEFNILEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-12-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-29'},sortcode = '243',stipula = {d '2011-12-22'},title = 'LAPIDEI (Estr.eLavoraz.): imprese artigiane (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '243'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('243','S','EDILIZIA (71) ','CONFIMPRESEITALIA, CONFIMPRESEEDILIZIA, ACS, CSE, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSEFNILASU, CSEFNILEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-29'},'243',{d '2011-12-22'},'LAPIDEI (Estr.eLavoraz.): imprese artigiane (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '244')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'USAEFNEL, FNPSL, CONFIMPRESEITALIA, CONFEUROPA, CILA, PMIAGRIGENTO, CONFIMIT, ENEAS, ASSOCOSTRUTTORI, ASPIN',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-03-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-03-29'},sortcode = '244',stipula = {d '2010-03-27'},title = 'LAPIDEI (Estr. e Lavoraz.): imprese artigiane (USAE)' WHERE idccnl = '244'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('244','S','EDILIZIA (71) ','USAEFNEL, FNPSL, CONFIMPRESEITALIA, CONFEUROPA, CILA, PMIAGRIGENTO, CONFIMIT, ENEAS, ASSOCOSTRUTTORI, ASPIN',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-03-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-03-29'},'244',{d '2010-03-27'},'LAPIDEI (Estr. e Lavoraz.): imprese artigiane (USAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '245')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFINDUSTRIAMARMOMACCHINE, ANEPLA, FENEALUIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-03-31'},sortcode = '245',stipula = {d '2013-05-03'},title = 'LAPIDEI (Estr. e Lavoraz.): Industrie' WHERE idccnl = '245'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('245','S','EDILIZIA (71) ','CONFINDUSTRIAMARMOMACCHINE, ANEPLA, FENEALUIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-03-31'},'245',{d '2013-05-03'},'LAPIDEI (Estr. e Lavoraz.): Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '246')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFAPI ANIEM, FENEAL UIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-03-31'},sortcode = '246',stipula = {d '2014-03-05'},title = 'LAPIDEI (Estr. e Lavoraz.): PMI' WHERE idccnl = '246'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('246','S','EDILIZIA (71) ','CONFAPI ANIEM, FENEAL UIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-03-31'},'246',{d '2014-03-05'},'LAPIDEI (Estr. e Lavoraz.): PMI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '247')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANIEMCONFIMIIMPRESA, ANIERCONFIMIIMPRESA, FENEALUIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-04-30'},sortcode = '247',stipula = {d '2017-09-14'},title = 'LAPIDEI (Estr. e Lavoraz.): PMI - CONFIMI IMPRESA' WHERE idccnl = '247'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('247','S','EDILIZIA (71) ','ANIEMCONFIMIIMPRESA, ANIERCONFIMIIMPRESA, FENEALUIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-04-30'},'247',{d '2017-09-14'},'LAPIDEI (Estr. e Lavoraz.): PMI - CONFIMI IMPRESA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '248')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEEDILIZIA, ACS, CSE, CSEFNILAPMI, CSEFNLEL, CSECOOP, CSEFNILASU, CSEFNLEI, CSE DIR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-03-31'},sortcode = '248',stipula = {d '2011-12-22'},title = 'Laterizi e manuf. In cemento: artigiane, PMI,cooperative (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '248'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('248','S','EDILIZIA (71) ','CONFIMPRESEITALIA, CONFIMPRESEEDILIZIA, ACS, CSE, CSEFNILAPMI, CSEFNLEL, CSECOOP, CSEFNILASU, CSEFNLEI, CSE DIR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-03-31'},'248',{d '2011-12-22'},'Laterizi e manuf. In cemento: artigiane, PMI,cooperative (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '249')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANDIL, ASSOBETON, FENEAL UIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '249',stipula = {d '2016-03-31'},title = 'LATERIZI E MANUF. IN CEMENTO: Industrie' WHERE idccnl = '249'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('249','S','EDILIZIA (71) ','ANDIL, ASSOBETON, FENEAL UIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'249',{d '2016-03-31'},'LATERIZI E MANUF. IN CEMENTO: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '250')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CONFAPI ANIEM, FENEAL UIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-06-30'},sortcode = '250',stipula = {d '2017-06-23'},title = 'LATERIZI E MANUF. IN CEMENTO: P.M.I.' WHERE idccnl = '250'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('250','S','EDILIZIA (71) ','CONFAPI ANIEM, FENEAL UIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-06-30'},'250',{d '2017-06-23'},'LATERIZI E MANUF. IN CEMENTO: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '251')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'ANIEMCONFIMIIMPRESA, ANIERCONFIMIIMPRESA, FENEALUIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '251',stipula = {d '2016-06-13'},title = 'LATERIZI E MANUF. INCEMENTO: P.M.I.-CONFIMIIMPRESA' WHERE idccnl = '251'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('251','S','EDILIZIA (71) ','ANIEMCONFIMIIMPRESA, ANIERCONFIMIIMPRESA, FENEALUIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'251',{d '2016-06-13'},'LATERIZI E MANUF. INCEMENTO: P.M.I.-CONFIMIIMPRESA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '252')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'CEPAA, CEPAACOSTRUTTORIEDILIEAFFINI, CILA,LUCI, SICEL, FNLE, CONF LAVORATORI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-03-26'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-03-25'},sortcode = '252',stipula = {d '2013-03-26'},title = 'Laterizi, manufatti in cotto, in cemento e affini' WHERE idccnl = '252'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('252','S','EDILIZIA (71) ','CEPAA, CEPAACOSTRUTTORIEDILIEAFFINI, CILA,LUCI, SICEL, FNLE, CONF LAVORATORI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-03-26'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-03-25'},'252',{d '2013-03-26'},'Laterizi, manufatti in cotto, in cemento e affini')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '253')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDERLEGNOARREDO, FENEAL UIL, FILCA CISL, FILLEA CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '253',stipula = {d '2016-12-13'},title = 'LEGNO, ARREDAMENTO: Industrie' WHERE idccnl = '253'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('253','S','EDILIZIA (71) ','FEDERLEGNOARREDO, FENEAL UIL, FILCA CISL, FILLEA CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'253',{d '2016-12-13'},'LEGNO, ARREDAMENTO: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '254')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'FEDERLEGNO ARREDO, UGL COSTRUZIONI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-03-31'},sortcode = '254',stipula = {d '2013-09-16'},title = 'LEGNO, ARREDAMENTO: Industrie' WHERE idccnl = '254'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('254','S','EDILIZIA (71) ','FEDERLEGNO ARREDO, UGL COSTRUZIONI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-03-31'},'254',{d '2013-09-16'},'LEGNO, ARREDAMENTO: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '255')
UPDATE [ccnl] SET active = 'S',area = 'EDILIZIA (71) ',contraenti = 'UNITAL CONFAPI, FILLEA CGIL, FILCA CISL, FENEAL UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-31'},sortcode = '255',stipula = {d '2013-10-25'},title = 'LEGNO, ARREDAMENTO: P.M.I.' WHERE idccnl = '255'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('255','S','EDILIZIA (71) ','UNITAL CONFAPI, FILLEA CGIL, FILCA CISL, FENEAL UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-31'},'255',{d '2013-10-25'},'LEGNO, ARREDAMENTO: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '256')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'CNACOMUNICAZIONEETERZIARIOAVANZATO, CONFARTIGIANATOCOMUNICAZIONE, CASARTIGIANI, CLAAI, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '256',stipula = {d '2018-02-27'},title = 'AREA COMUNICAZIONE - Imprese Artigiane' WHERE idccnl = '256'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('256','S','POLIGRAFICI E SPETTACOLO (44) ','CNACOMUNICAZIONEETERZIARIOAVANZATO, CONFARTIGIANATOCOMUNICAZIONE, CASARTIGIANI, CLAAI, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'256',{d '2018-02-27'},'AREA COMUNICAZIONE - Imprese Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '257')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANIAF, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2003-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-06-30'},scadenza = {d '2007-06-30'},sortcode = '257',stipula = {d '2004-06-07'},title = 'AZIENDE AEROFOTOGRAMMETRICHE' WHERE idccnl = '257'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('257','S','POLIGRAFICI E SPETTACOLO (44) ','ANIAF, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2003-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-06-30'},{d '2007-06-30'},'257',{d '2004-06-07'},'AZIENDE AEROFOTOGRAMMETRICHE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '258')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ASSOCARTA, ASSOGRAFICI, SLCCGIL, FISTELCISL, UILCOMUIL, UGL CARTA E STAMPA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '258',stipula = {d '2016-11-30'},title = 'CARTARIE E CARTOTECNICHE: Industrie' WHERE idccnl = '258'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('258','S','POLIGRAFICI E SPETTACOLO (44) ','ASSOCARTA, ASSOGRAFICI, SLCCGIL, FISTELCISL, UILCOMUIL, UGL CARTA E STAMPA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'258',{d '2016-11-30'},'CARTARIE E CARTOTECNICHE: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '259')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANICA, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '259',stipula = {d '2011-12-21'},title = 'CINEMA AUDIOVISIVI: Industrie' WHERE idccnl = '259'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('259','S','POLIGRAFICI E SPETTACOLO (44) ','ANICA, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'259',{d '2011-12-21'},'CINEMA AUDIOVISIVI: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '260')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANICA, AID 2014, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '260',stipula = {d '2017-02-27'},title = 'CINEMA: Doppiaggio' WHERE idccnl = '260'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('260','S','POLIGRAFICI E SPETTACOLO (44) ','ANICA, AID 2014, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'260',{d '2017-02-27'},'CINEMA: Doppiaggio')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '261')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANICA, APT, APP, SLCCGIL, FISTELCISL, UILCOMUIL,(adesionedi UGL COMUNICAZIONI dal 26/7/2011)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-12-31'},scadenza = {d '2013-12-31'},sortcode = '261',stipula = {d '2009-11-03'},title = 'CINEMA: Generici Produzione A.V.' WHERE idccnl = '261'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('261','S','POLIGRAFICI E SPETTACOLO (44) ','ANICA, APT, APP, SLCCGIL, FISTELCISL, UILCOMUIL,(adesionedi UGL COMUNICAZIONI dal 26/7/2011)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-31'},{d '2013-12-31'},'261',{d '2009-11-03'},'CINEMA: Generici Produzione A.V.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '262')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANICA, APT, APC, API, SLC CGIL, FISTEL CISL, UILSIC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2000-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2002-03-31'},scadenza = {d '2004-03-31'},sortcode = '262',stipula = {d '1999-12-07'},title = 'CINEMA: Tecnici e Maestranze' WHERE idccnl = '262'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('262','S','POLIGRAFICI E SPETTACOLO (44) ','ANICA, APT, APC, API, SLC CGIL, FISTEL CISL, UILSIC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2000-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2002-03-31'},{d '2004-03-31'},'262',{d '1999-12-07'},'CINEMA: Tecnici e Maestranze')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '263')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'PMI ITALIA INTERNATIONAL, FILCOM FISMIC CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-06-30'},scadenza = {d '2015-07-01'},sortcode = '263',stipula = {d '2015-06-05'},title = 'COMUNICATORI D''IMPRESA (PMI ItaliaInternational-Filcom-Fismic Confsal)' WHERE idccnl = '263'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('263','S','POLIGRAFICI E SPETTACOLO (44) ','PMI ITALIA INTERNATIONAL, FILCOM FISMIC CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-06-30'},{d '2015-07-01'},'263',{d '2015-06-05'},'COMUNICATORI D''IMPRESA (PMI ItaliaInternational-Filcom-Fismic Confsal)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '264')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ESAARCO, CEPAA, ESAARCOServizieTerziario, SAI, ALIM, CONFIMPRESA, UNIPMI, PMIITALIAINTERNATIONAL, CIU, SICEL, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2014-11-01'},sortcode = '264',stipula = {d '2014-11-01'},title = 'COMUNICATORI D''IMPRESA: P.M.I. (ESAARCO)' WHERE idccnl = '264'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('264','S','POLIGRAFICI E SPETTACOLO (44) ','ESAARCO, CEPAA, ESAARCOServizieTerziario, SAI, ALIM, CONFIMPRESA, UNIPMI, PMIITALIAINTERNATIONAL, CIU, SICEL, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2014-11-01'},'264',{d '2014-11-01'},'COMUNICATORI D''IMPRESA: P.M.I. (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '265')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ASSOLOMBARDA, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-12-31'},scadenza = {d '2011-01-01'},sortcode = '265',stipula = {d '2011-10-05'},title = 'COMUNICAZIONE D''IMPRESA' WHERE idccnl = '265'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('265','S','POLIGRAFICI E SPETTACOLO (44) ','ASSOLOMBARDA, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-12-31'},{d '2011-01-01'},'265',{d '2011-10-05'},'COMUNICAZIONE D''IMPRESA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '266')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'UNIGECCONFAPI, UNIMATICACONFAPI, CONFAPI, SLCCGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-06-30'},scadenza = {d '2012-07-01'},sortcode = '266',stipula = {d '2013-07-29'},title = 'COMUNICAZIONE,INFORMATICAESERVIZIINNOVATIVI: P.M.I.' WHERE idccnl = '266'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('266','S','POLIGRAFICI E SPETTACOLO (44) ','UNIGECCONFAPI, UNIMATICACONFAPI, CONFAPI, SLCCGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-06-30'},{d '2012-07-01'},'266',{d '2013-07-29'},'COMUNICAZIONE,INFORMATICAESERVIZIINNOVATIVI: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '267')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'AFI, FIMI, PMI, UNIVIDEO, ASSOLOMBARDA, SLCCGIL, FISTELCISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2014-01-01'},sortcode = '267',stipula = {d '2014-10-27'},title = 'DISCOGRAFICI - VIDEOFONOGRAFICI' WHERE idccnl = '267'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('267','S','POLIGRAFICI E SPETTACOLO (44) ','AFI, FIMI, PMI, UNIVIDEO, ASSOLOMBARDA, SLCCGIL, FISTELCISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2014-01-01'},'267',{d '2014-10-27'},'DISCOGRAFICI - VIDEOFONOGRAFICI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '268')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ASSOGRAFICI, AIE, ANES, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2014-10-16'},sortcode = '268',stipula = {d '2014-10-16'},title = 'EDITORIA E GRAFICA: Industrie' WHERE idccnl = '268'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('268','S','POLIGRAFICI E SPETTACOLO (44) ','ASSOGRAFICI, AIE, ANES, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2014-10-16'},'268',{d '2014-10-16'},'EDITORIA E GRAFICA: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '269')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ASSOGRAFICI, ASSOCIAZIONEITALIANAEDITORI, ASSOCIAZIONENAZIONALEEDITORIAPERIODICASPECIALIZZATA, UGL CARTA E STAMPA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-03-31'},scadenza = {d '2011-07-01'},sortcode = '269',stipula = {d '2011-05-30'},title = 'EDITORIA E GRAFICA: Industrie' WHERE idccnl = '269'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('269','S','POLIGRAFICI E SPETTACOLO (44) ','ASSOGRAFICI, ASSOCIAZIONEITALIANAEDITORI, ASSOCIAZIONENAZIONALEEDITORIAPERIODICASPECIALIZZATA, UGL CARTA E STAMPA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-03-31'},{d '2011-07-01'},'269',{d '2011-05-30'},'EDITORIA E GRAFICA: Industrie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '270')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANFOLS, FIALS CISAL, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2006-12-31'},scadenza = {d '2004-01-01'},sortcode = '270',stipula = {d '2007-02-12'},title = 'ENTI LIRICI' WHERE idccnl = '270'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('270','S','POLIGRAFICI E SPETTACOLO (44) ','ANFOLS, FIALS CISAL, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-12-31'},{d '2004-01-01'},'270',{d '2007-02-12'},'ENTI LIRICI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '271')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANEC, ANEM, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-12-31'},scadenza = {d '2012-01-01'},sortcode = '271',stipula = {d '2011-11-25'},title = 'ESERCIZI CINEMATOGRAFICI E CINEMA-TEATRALI' WHERE idccnl = '271'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('271','S','POLIGRAFICI E SPETTACOLO (44) ','ANEC, ANEM, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-12-31'},{d '2012-01-01'},'271',{d '2011-11-25'},'ESERCIZI CINEMATOGRAFICI E CINEMA-TEATRALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '272')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ASSOCIAZIONEFOTOLABORATORIITALIANICONTOTERZICONFINDUSTRIA, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-06-30'},scadenza = {d '2013-07-01'},sortcode = '272',stipula = {d '2013-06-17'},title = 'FOTO LABORATORI CONTO TERZI' WHERE idccnl = '272'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('272','S','POLIGRAFICI E SPETTACOLO (44) ','ASSOCIAZIONEFOTOLABORATORIITALIANICONTOTERZICONFINDUSTRIA, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-30'},{d '2013-07-01'},'272',{d '2013-06-17'},'FOTO LABORATORI CONTO TERZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '273')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'FIEG, SINAGISLCCGIL, CISLGiornalai, UILTUCSGiornalai, SNAGCONFCOMMERCIO, FENAGICONFESERCENTI, USIAGIUGL, USPI, ANADIS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2006-01-01'},sortcode = '273',stipula = {d '2005-04-18'},title = 'GIORNALI (Edicole Rivendite Giornali)' WHERE idccnl = '273'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('273','S','POLIGRAFICI E SPETTACOLO (44) ','FIEG, SINAGISLCCGIL, CISLGiornalai, UILTUCSGiornalai, SNAGCONFCOMMERCIO, FENAGICONFESERCENTI, USIAGIUGL, USPI, ANADIS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2006-01-01'},'273',{d '2005-04-18'},'GIORNALI (Edicole Rivendite Giornali)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '274')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'FIEG, FEDERMANAGER, SINDACATONAZIONALEDIRIGENTIGIORNALI QUOTIDIANI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2005-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2006-12-31'},scadenza = {d '2008-12-31'},sortcode = '274',stipula = {d '2005-03-31'},title = 'GIORNALI E QUOTIDIANI: Direttori e Dirigenti' WHERE idccnl = '274'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('274','S','POLIGRAFICI E SPETTACOLO (44) ','FIEG, FEDERMANAGER, SINDACATONAZIONALEDIRIGENTIGIORNALI QUOTIDIANI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-12-31'},{d '2008-12-31'},'274',{d '2005-03-31'},'GIORNALI E QUOTIDIANI: Direttori e Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '275')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'FIEG, ASSOCIAZIONESTAMPATORIITALIANAGIORNALI, SLCCGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2010-06-30'},scadenza = {d '2011-12-31'},sortcode = '275',stipula = {d '2008-04-04'},title = 'GIORNALI E QUOTIDIANI: Operai e Impiegati' WHERE idccnl = '275'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('275','S','POLIGRAFICI E SPETTACOLO (44) ','FIEG, ASSOCIAZIONESTAMPATORIITALIANAGIORNALI, SLCCGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-06-30'},{d '2011-12-31'},'275',{d '2008-04-04'},'GIORNALI E QUOTIDIANI: Operai e Impiegati')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '276')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'FIEG, FNSI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-03-31'},scadenza = {d '2013-04-01'},sortcode = '276',stipula = {d '2014-06-24'},title = 'GIORNALISTI' WHERE idccnl = '276'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('276','S','POLIGRAFICI E SPETTACOLO (44) ','FIEG, FNSI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-31'},{d '2013-04-01'},'276',{d '2014-06-24'},'GIORNALISTI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '277')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'AERANTICORALLO, AERANTI, ASSOCIAZIONECORALLO, FEDERAZIONE NAZIONALE STAMPA ITALIANA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-12-31'},scadenza = {d '2013-12-31'},sortcode = '277',stipula = {d '2010-01-27'},title = 'GIORNALISTI: Radio televisione - imprese locali' WHERE idccnl = '277'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('277','S','POLIGRAFICI E SPETTACOLO (44) ','AERANTICORALLO, AERANTI, ASSOCIAZIONECORALLO, FEDERAZIONE NAZIONALE STAMPA ITALIANA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-31'},{d '2013-12-31'},'277',{d '2010-01-27'},'GIORNALISTI: Radio televisione - imprese locali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '278')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'RAI, UNIONE INDUSTRIALI ROMA, USIGRAI, FNSI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-03-31'},sortcode = '278',stipula = {d '2009-06-23'},title = 'GIORNALISTI: RAI (estensione CCNL)' WHERE idccnl = '278'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('278','S','POLIGRAFICI E SPETTACOLO (44) ','RAI, UNIONE INDUSTRIALI ROMA, USIGRAI, FNSI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-03-31'},'278',{d '2009-06-23'},'GIORNALISTI: RAI (estensione CCNL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '279')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'CONFINDUSTRIARADIOTELEVISIONI, RNA, ANICA, SLCCGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-12-31'},scadenza = {d '2014-04-14'},sortcode = '279',stipula = {d '2014-04-17'},title = 'Imprese Radiotelevisive Private' WHERE idccnl = '279'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('279','S','POLIGRAFICI E SPETTACOLO (44) ','CONFINDUSTRIARADIOTELEVISIONI, RNA, ANICA, SLCCGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-12-31'},{d '2014-04-14'},'279',{d '2014-04-17'},'Imprese Radiotelevisive Private')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '280')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'FEDERDAT, ASSODIGITALI, FISMIC CONFSAL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-10-14'},scadenza = {d '2015-10-15'},sortcode = '280',stipula = {d '2015-10-15'},title = 'INFORMATICA E SERVIZI INNOVATIVI: PMI' WHERE idccnl = '280'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('280','S','POLIGRAFICI E SPETTACOLO (44) ','FEDERDAT, ASSODIGITALI, FISMIC CONFSAL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-10-14'},{d '2015-10-15'},'280',{d '2015-10-15'},'INFORMATICA E SERVIZI INNOVATIVI: PMI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '281')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'FEDERIPPODROMI,TRENNOsrl, SLCCGIL, FISASCATCISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-12-31'},sortcode = '281',stipula = {d '2007-10-16'},title = 'IPPICA: Addetti al totalizzatore, ingressi e ss.vv.' WHERE idccnl = '281'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('281','S','POLIGRAFICI E SPETTACOLO (44) ','FEDERIPPODROMI,TRENNOsrl, SLCCGIL, FISASCATCISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-12-31'},'281',{d '2007-10-16'},'IPPICA: Addetti al totalizzatore, ingressi e ss.vv.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '282')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'FEDERIPPODROMI, UNI, SLC CGIL, FISASCAT CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-11-07'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-06-30'},scadenza = {d '2010-06-30'},sortcode = '282',stipula = {d '2006-11-07'},title = 'IPPICA: Dipendenti Societa'' Corse dei Cavalli' WHERE idccnl = '282'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('282','S','POLIGRAFICI E SPETTACOLO (44) ','FEDERIPPODROMI, UNI, SLC CGIL, FISASCAT CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-11-07'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-06-30'},{d '2010-06-30'},'282',{d '2006-11-07'},'IPPICA: Dipendenti Societa'' Corse dei Cavalli')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '283')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'UNAG, ASSOGALOPPO, SLCCGIL, FISASCATCISL, UILCOMUIL, FAAG CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-02-28'},sortcode = '283',stipula = {d '2007-05-21'},title = 'IPPICA: Scuderie Cavalli da Corsa al Galoppo' WHERE idccnl = '283'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('283','S','POLIGRAFICI E SPETTACOLO (44) ','UNAG, ASSOGALOPPO, SLCCGIL, FISASCATCISL, UILCOMUIL, FAAG CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-02-28'},'283',{d '2007-05-21'},'IPPICA: Scuderie Cavalli da Corsa al Galoppo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '284')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANAGT, UNAGT, SLC CGIL, FISASCAT CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '284',stipula = {d '2008-05-15'},title = 'IPPICA: Scuderie Cavalli da Corsa al Trotto' WHERE idccnl = '284'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('284','S','POLIGRAFICI E SPETTACOLO (44) ','ANAGT, UNAGT, SLC CGIL, FISASCAT CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'284',{d '2008-05-15'},'IPPICA: Scuderie Cavalli da Corsa al Trotto')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '285')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'AGCICULTURALIA, FEDERCULTURACONFCOOPERATIVE,LEGACOOPSETTORECULTURA, SLCCGIL, FISTELCISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '285',stipula = {d '2014-11-06'},title = 'PRODUZIONECULTURALEESPETTACOLO: Cooperative e Imprese Sociali' WHERE idccnl = '285'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('285','S','POLIGRAFICI E SPETTACOLO (44) ','AGCICULTURALIA, FEDERCULTURACONFCOOPERATIVE,LEGACOOPSETTORECULTURA, SLCCGIL, FISTELCISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'285',{d '2014-11-06'},'PRODUZIONECULTURALEESPETTACOLO: Cooperative e Imprese Sociali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '286')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'SIPRA, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-12-31'},sortcode = '286',stipula = {d '2009-12-01'},title = 'PUBBLICITA (SIPRA PUBLICITAS)' WHERE idccnl = '286'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('286','S','POLIGRAFICI E SPETTACOLO (44) ','SIPRA, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-12-31'},'286',{d '2009-12-01'},'PUBBLICITA (SIPRA PUBLICITAS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '287')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'AERANTICORALLO, AERANTI, CORALLO, CISAL, FENASALCCISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2011-12-31'},sortcode = '287',stipula = {d '2009-02-26'},title = 'RADIO TELEVISIONE: Aziende private' WHERE idccnl = '287'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('287','S','POLIGRAFICI E SPETTACOLO (44) ','AERANTICORALLO, AERANTI, CORALLO, CISAL, FENASALCCISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2011-12-31'},'287',{d '2009-02-26'},'RADIO TELEVISIONE: Aziende private')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '288')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'RAI, UNINDUSTRIACONFINDUSTRIA, SLCCGIL, FISTELCISL, UILCOMUIL, UGLTELECOMUNICAZIONI, SNATER,LIBERSINDCONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '288',stipula = {d '2013-02-07'},title = 'RAI' WHERE idccnl = '288'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('288','S','POLIGRAFICI E SPETTACOLO (44) ','RAI, UNINDUSTRIACONFINDUSTRIA, SLCCGIL, FISTELCISL, UILCOMUIL, UGLTELECOMUNICAZIONI, SNATER,LIBERSINDCONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'288',{d '2013-02-07'},'RAI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '289')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'RAIRADIOTELEVISIONEITALIANASPA, SLCCGIL, FISTELCISL, UILCOM UIL, SNATER',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2009-12-31'},sortcode = '289',stipula = {d '2009-12-03'},title = 'RAI: Artisti (Prof. D''Orchestra, Artisti del coro...)' WHERE idccnl = '289'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('289','S','POLIGRAFICI E SPETTACOLO (44) ','RAIRADIOTELEVISIONEITALIANASPA, SLCCGIL, FISTELCISL, UILCOM UIL, SNATER',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2009-12-31'},'289',{d '2009-12-03'},'RAI: Artisti (Prof. D''Orchestra, Artisti del coro...)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '290')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'SIAE, SLCCGIL, FISTELCISL, UILPAUIL, FEDERAZIONECONFSAL CADA, UGL COMUNICAZIONI, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '290',stipula = {d '2012-07-26'},title = 'SIAE (SOCIETA'' ITALIANA AUTORI ED EDITORI)' WHERE idccnl = '290'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('290','S','POLIGRAFICI E SPETTACOLO (44) ','SIAE, SLCCGIL, FISTELCISL, UILPAUIL, FEDERAZIONECONFSAL CADA, UGL COMUNICAZIONI, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'290',{d '2012-07-26'},'SIAE (SOCIETA'' ITALIANA AUTORI ED EDITORI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '291')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'SIAE, CIDA SNAD SIAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-28'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '291',stipula = {d '2014-01-27'},title = 'SIAE (SOCIETA''ITALIANAAUTORIEDEDITORI): Dirigenti' WHERE idccnl = '291'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('291','S','POLIGRAFICI E SPETTACOLO (44) ','SIAE, CIDA SNAD SIAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-28'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'291',{d '2014-01-27'},'SIAE (SOCIETA''ITALIANAAUTORIEDEDITORI): Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '292')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'FIPE SILB, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '292',stipula = {d '2011-12-15'},title = 'SPETTACOLOEserciziPubblici: Artistiatempodeterminato' WHERE idccnl = '292'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('292','S','POLIGRAFICI E SPETTACOLO (44) ','FIPE SILB, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'292',{d '2011-12-15'},'SPETTACOLOEserciziPubblici: Artistiatempodeterminato')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '293')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'UNCI, UNSIC, LIBERSIND CONFSAL, CONFSAL FISALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2005-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-09-30'},scadenza = {d '2009-09-30'},sortcode = '293',stipula = {d '2005-09-30'},title = 'SPETTACOLO: Cooperativesettoreartistico,informativo e sportivo' WHERE idccnl = '293'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('293','S','POLIGRAFICI E SPETTACOLO (44) ','UNCI, UNSIC, LIBERSIND CONFSAL, CONFSAL FISALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-09-30'},{d '2009-09-30'},'293',{d '2005-09-30'},'SPETTACOLO: Cooperativesettoreartistico,informativo e sportivo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '294')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'UNIONENAZIONALECOMMERCIALISTIEDESPERTICONTABILI, CONFIMPRESEITALIA, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-03-31'},sortcode = '294',stipula = {d '2015-04-27'},title = 'SPETTACOLO: Impresesettoreartistico,informativoesportivo' WHERE idccnl = '294'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('294','S','POLIGRAFICI E SPETTACOLO (44) ','UNIONENAZIONALECOMMERCIALISTIEDESPERTICONTABILI, CONFIMPRESEITALIA, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-03-31'},'294',{d '2015-04-27'},'SPETTACOLO: Impresesettoreartistico,informativoesportivo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '295')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'COS, SOS, Alai Cisl, Clacs Cisl',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2007-12-31'},sortcode = '295',stipula = {d '2003-11-28'},title = 'SPETTACOLO: Lavoratori Intermittenti' WHERE idccnl = '295'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('295','S','POLIGRAFICI E SPETTACOLO (44) ','COS, SOS, Alai Cisl, Clacs Cisl',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2007-12-31'},'295',{d '2003-11-28'},'SPETTACOLO: Lavoratori Intermittenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '296')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'PLATEA, ETI, SLC CGIL, FISTEL CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2011-12-31'},sortcode = '296',stipula = {d '2009-01-13'},title = 'TEATRI STABILI/ETI: Personale non Artistico' WHERE idccnl = '296'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('296','S','POLIGRAFICI E SPETTACOLO (44) ','PLATEA, ETI, SLC CGIL, FISTEL CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2011-12-31'},'296',{d '2009-01-13'},'TEATRI STABILI/ETI: Personale non Artistico')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '297')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'PLATEA, ANTPI, ANCRIT, ANTAC, SLCCGIL, SAISLCCGIL, FISTELCISL, FAIFISTELCISL, UILCOMUIL, CoordinamentoattoriUILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-12-31'},sortcode = '297',stipula = {d '2008-11-20'},title = 'TEATRI: Personale Artistico' WHERE idccnl = '297'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('297','S','POLIGRAFICI E SPETTACOLO (44) ','PLATEA, ANTPI, ANCRIT, ANTAC, SLCCGIL, SAISLCCGIL, FISTELCISL, FAIFISTELCISL, UILCOMUIL, CoordinamentoattoriUILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-12-31'},'297',{d '2008-11-20'},'TEATRI: Personale Artistico')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '298')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ESAARCO, CEPAA, ESAARCOServizieTerziario, CEPAAFedercoop, SAI, CIU, SI CEL, ONAPS, CLI, Fisnalcta UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-10-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-10-05'},sortcode = '298',stipula = {d '2017-10-05'},title = 'TEATRI: Personale Artistico e Tecnico (ESAARCO)' WHERE idccnl = '298'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('298','S','POLIGRAFICI E SPETTACOLO (44) ','ESAARCO, CEPAA, ESAARCOServizieTerziario, CEPAAFedercoop, SAI, CIU, SI CEL, ONAPS, CLI, Fisnalcta UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-10-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-10-05'},'298',{d '2017-10-05'},'TEATRI: Personale Artistico e Tecnico (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '299')
UPDATE [ccnl] SET active = 'S',area = 'POLIGRAFICI E SPETTACOLO (44) ',contraenti = 'ANET, AGIS, SLC CGIL, FISTEL CISL, UILCOM UIL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-12-31'},scadenza = {d '2007-12-31'},sortcode = '299',stipula = {d '2005-10-17'},title = 'TEATRI: Personale non Artistico' WHERE idccnl = '299'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('299','S','POLIGRAFICI E SPETTACOLO (44) ','ANET, AGIS, SLC CGIL, FISTEL CISL, UILCOM UIL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-31'},{d '2007-12-31'},'299',{d '2005-10-17'},'TEATRI: Personale non Artistico')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '300')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-18'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '300',stipula = {d '2017-05-18'},title = 'Acconciatura,Estetica, Tricologia non curativa, Tatuaggi, Piercing e Centri Benessere (FAPI-CESAC-FILDI CIU)' WHERE idccnl = '300'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('300','S','COMMERCIO (214) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-18'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'300',{d '2017-05-18'},'Acconciatura,Estetica, Tricologia non curativa, Tatuaggi, Piercing e Centri Benessere (FAPI-CESAC-FILDI CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '301')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '301',stipula = {d '2017-06-06'},title = 'Acconciatura,Estetica, Tricologia non curativa, Tatuaggio, Piercing e Centri Benessere' WHERE idccnl = '301'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('301','S','COMMERCIO (214) ','CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'301',{d '2017-06-06'},'Acconciatura,Estetica, Tricologia non curativa, Tatuaggio, Piercing e Centri Benessere')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '302')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANAP, ALIM, SELP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-30'},sortcode = '302',stipula = {d '2016-01-11'},title = 'Acconciatura, estetica,... (ANAP-ALIM-SELP)' WHERE idccnl = '302'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('302','S','COMMERCIO (214) ','ANAP, ALIM, SELP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-30'},'302',{d '2016-01-11'},'Acconciatura, estetica,... (ANAP-ALIM-SELP)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '303')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ESAARCO, CEPAA, ESAARCOArtigianato, CEPAAFedercoop, SAI, ALIM, FER, CONFIMPRESA, UNIPMI, PMIITALIAINTERNATIONAL, CILA, CIU, SI CEL, CGEL FNLA, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '303',stipula = {d '2014-11-01'},title = 'Acconciatura, estetica,... (ESAARCO)' WHERE idccnl = '303'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('303','S','COMMERCIO (214) ','ESAARCO, CEPAA, ESAARCOArtigianato, CEPAAFedercoop, SAI, ALIM, FER, CONFIMPRESA, UNIPMI, PMIITALIAINTERNATIONAL, CILA, CIU, SI CEL, CGEL FNLA, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'303',{d '2014-11-01'},'Acconciatura, estetica,... (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '304')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFAPI, FIARC, FILCAMSCGIL, FISASCATCISL, FNAARC, UILTUCS UIL, UGL, USARCI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2002-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2005-03-31'},sortcode = '304',stipula = {d '2002-03-20'},title = 'AGENTI DI COMMERCIO (PMI)' WHERE idccnl = '304'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('304','S','COMMERCIO (214) ','CONFAPI, FIARC, FILCAMSCGIL, FISASCATCISL, FNAARC, UILTUCS UIL, UGL, USARCI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2002-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2005-03-31'},'304',{d '2002-03-20'},'AGENTI DI COMMERCIO (PMI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '305')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFCOMMERCIO, CONFCOOPERATIVE, CONFESERCENTI, FNAARC, FILCAMSCGIL, FISASCATCISL, UILTUCSUIL, FIARCCONFESERCENTI, UGL TERZIARIO, USARCI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-02-29'},sortcode = '305',stipula = {d '2009-02-16'},title = 'AGENTI DI COMMERCIO (Sett. Commercio)' WHERE idccnl = '305'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('305','S','COMMERCIO (214) ','CONFCOMMERCIO, CONFCOOPERATIVE, CONFESERCENTI, FNAARC, FILCAMSCGIL, FISASCATCISL, UILTUCSUIL, FIARCCONFESERCENTI, UGL TERZIARIO, USARCI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-02-29'},'305',{d '2009-02-16'},'AGENTI DI COMMERCIO (Sett. Commercio)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '306')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CNA, CONFARTIGIANATOIMPRESE, CASARTIGIANI, CLAAI, USARCI, FNAARC, FIARC, FILCAMSCGIL, FISASCATCISL, UILTUCS UIL, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '306',stipula = {d '2014-12-10'},title = 'AGENTI DI COMMERCIO: Artigiane' WHERE idccnl = '306'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('306','S','COMMERCIO (214) ','CNA, CONFARTIGIANATOIMPRESE, CASARTIGIANI, CLAAI, USARCI, FNAARC, FIARC, FILCAMSCGIL, FISASCATCISL, UILTUCS UIL, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'306',{d '2014-12-10'},'AGENTI DI COMMERCIO: Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '307')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFINDUSTRIA, CONFCOOPERATIVE, FNAARC, FIARC, USARCI, FILCAMS CGIL, FISASCAT CISL: UILTUCS UIL, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '307',stipula = {d '2014-07-30'},title = 'AGENTI DI COMMERCIO: Aziende Industriali' WHERE idccnl = '307'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('307','S','COMMERCIO (214) ','CONFINDUSTRIA, CONFCOOPERATIVE, FNAARC, FIARC, USARCI, FILCAMS CGIL, FISASCAT CISL: UILTUCS UIL, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'307',{d '2014-07-30'},'AGENTI DI COMMERCIO: Aziende Industriali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '308')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSOCAP, ANSACAP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '308',stipula = {d '2009-04-03'},title = 'AGENTI E RAPPRESENTANTI DI CONSORZI AGRARI' WHERE idccnl = '308'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('308','S','COMMERCIO (214) ','ASSOCAP, ANSACAP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'308',{d '2009-04-03'},'AGENTI E RAPPRESENTANTI DI CONSORZI AGRARI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '309')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FIAIP, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '309',stipula = {d '2011-07-27'},title = 'AGENTI IMMOBILIARI PROFESSIONALI E MANDATARI' WHERE idccnl = '309'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('309','S','COMMERCIO (214) ','FIAIP, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'309',{d '2011-07-27'},'AGENTI IMMOBILIARI PROFESSIONALI E MANDATARI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '310')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANPIT, CONFAZIENDA, FEDIMPRESE, UNICA, CISAL, FEDERAGENTI CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-04-30'},sortcode = '310',stipula = {d '2013-04-22'},title = 'AGENZIA E RAPPRESENTANZA COMMERCIALE (Commercio-Servizi-Terziario-Turismo-Industria-Artigianato)' WHERE idccnl = '310'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('310','S','COMMERCIO (214) ','ANPIT, CONFAZIENDA, FEDIMPRESE, UNICA, CISAL, FEDERAGENTI CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-04-30'},'310',{d '2013-04-22'},'AGENZIA E RAPPRESENTANZA COMMERCIALE (Commercio-Servizi-Terziario-Turismo-Industria-Artigianato)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '311')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNCI, CISAL, FEDERAGENTI CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-07-31'},sortcode = '311',stipula = {d '2015-07-27'},title = 'AGENZIA E RAPPRESENTANZA COMMERCIALE: Cooperative (Commercio-Servizi-Terziario-Turismo-Artigianato)' WHERE idccnl = '311'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('311','S','COMMERCIO (214) ','UNCI, CISAL, FEDERAGENTI CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-07-31'},'311',{d '2015-07-27'},'AGENZIA E RAPPRESENTANZA COMMERCIALE: Cooperative (Commercio-Servizi-Terziario-Turismo-Artigianato)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '312')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CIDEC, UGIFAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '312',stipula = {d '2013-07-10'},title = 'AGENZIA E RAPPRESENTANZA SETTORE ARTIGIANO (Cidec-Ugifai)' WHERE idccnl = '312'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('312','S','COMMERCIO (214) ','CIDEC, UGIFAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'312',{d '2013-07-10'},'AGENZIA E RAPPRESENTANZA SETTORE ARTIGIANO (Cidec-Ugifai)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '313')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FAPI, UGIFAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-10-18'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-09-30'},sortcode = '313',stipula = {d '2013-10-18'},title = 'AGENZIA E RAPPRESENTANZA SETTORE ARTIGIANO (Fapi-Ugifai)' WHERE idccnl = '313'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('313','S','COMMERCIO (214) ','FAPI, UGIFAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-10-18'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-09-30'},'313',{d '2013-10-18'},'AGENZIA E RAPPRESENTANZA SETTORE ARTIGIANO (Fapi-Ugifai)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '314')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CESAC, FISARC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-09-30'},sortcode = '314',stipula = {d '2009-09-09'},title = 'AGENZIA E RAPPRESENTANZA SETTORE COMMERCIO (Cesac-Fisarc)' WHERE idccnl = '314'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('314','S','COMMERCIO (214) ','CESAC, FISARC',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-09-30'},'314',{d '2009-09-09'},'AGENZIA E RAPPRESENTANZA SETTORE COMMERCIO (Cesac-Fisarc)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '315')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CIDEC, UGIFAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-31'},sortcode = '315',stipula = {d '2013-06-21'},title = 'AGENZIA E RAPPRESENTANZA SETTORE COMMERCIO (Cidec-Ugifai)' WHERE idccnl = '315'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('315','S','COMMERCIO (214) ','CIDEC, UGIFAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-31'},'315',{d '2013-06-21'},'AGENZIA E RAPPRESENTANZA SETTORE COMMERCIO (Cidec-Ugifai)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '316')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FAPI, UGIFAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-10-25'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-09-30'},sortcode = '316',stipula = {d '2013-10-25'},title = 'AGENZIA E RAPPRESENTANZA SETTORE COMMERCIO (Fapi-Ugifai)' WHERE idccnl = '316'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('316','S','COMMERCIO (214) ','FAPI, UGIFAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-10-25'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-09-30'},'316',{d '2013-10-25'},'AGENZIA E RAPPRESENTANZA SETTORE COMMERCIO (Fapi-Ugifai)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '317')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CIDEC, UGIFAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-08-30'},sortcode = '317',stipula = {d '2013-09-18'},title = 'AGENZIA E RAPPRESENTANZA SETTORE INDUSTRIALE (Cidec-Ugifai)' WHERE idccnl = '317'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('317','S','COMMERCIO (214) ','CIDEC, UGIFAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-08-30'},'317',{d '2013-09-18'},'AGENZIA E RAPPRESENTANZA SETTORE INDUSTRIALE (Cidec-Ugifai)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '318')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FAPI, UGIFAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-10-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-09-30'},sortcode = '318',stipula = {d '2013-10-30'},title = 'AGENZIA E RAPPRESENTANZA SETTORE INDUSTRIALE (Fapi-Ugifai)' WHERE idccnl = '318'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('318','S','COMMERCIO (214) ','FAPI, UGIFAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-10-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-09-30'},'318',{d '2013-10-30'},'AGENZIA E RAPPRESENTANZA SETTORE INDUSTRIALE (Fapi-Ugifai)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '319')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FILCOM FISMIC, FISMIC CONFSAL, AIAV, UNI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-04'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-03'},sortcode = '319',stipula = {d '2016-04-14'},title = 'AGENZIE DI VIAGGI E OPERATORI TURISTICI' WHERE idccnl = '319'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('319','S','COMMERCIO (214) ','FILCOM FISMIC, FISMIC CONFSAL, AIAV, UNI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-04'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-03'},'319',{d '2016-04-14'},'AGENZIE DI VIAGGI E OPERATORI TURISTICI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '320')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'AISS, FEDERTERZIARIO, CONFIMEA, CFCRETED''IMPRESA, UGLSICUREZZA CIVILE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-05-31'},sortcode = '320',stipula = {d '2017-05-31'},title = 'AGENZIE SICUREZZA SUSSIDIARIA E ISTITUTI INVESTIGATIVI (SECURITY)' WHERE idccnl = '320'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('320','S','COMMERCIO (214) ','AISS, FEDERTERZIARIO, CONFIMEA, CFCRETED''IMPRESA, UGLSICUREZZA CIVILE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-05-31'},'320',{d '2017-05-31'},'AGENZIE SICUREZZA SUSSIDIARIA E ISTITUTI INVESTIGATIVI (SECURITY)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '321')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CEPA, SI CEL, CEPA SERVIZI, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-08-08'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-08-07'},sortcode = '321',stipula = {d '2013-12-03'},title = 'AGENZIE SICUREZZA SUSSIDIARIA NON ARMATA' WHERE idccnl = '321'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('321','S','COMMERCIO (214) ','CEPA, SI CEL, CEPA SERVIZI, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-08-08'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-08-07'},'321',{d '2013-12-03'},'AGENZIE SICUREZZA SUSSIDIARIA NON ARMATA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '322')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERALBERGHI, CONFCOMMERCIO, MANAGERITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '322',stipula = {d '2016-12-21'},title = 'ALBERGHI: Dirigenti' WHERE idccnl = '322'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('322','S','COMMERCIO (214) ','FEDERALBERGHI, CONFCOMMERCIO, MANAGERITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'322',{d '2016-12-21'},'ALBERGHI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '323')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'AICA CONFINDUSTRIA, MANAGERITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '323',stipula = {d '2017-03-15'},title = 'ALBERGHI: Dirigenti Catene Alberghiere' WHERE idccnl = '323'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('323','S','COMMERCIO (214) ','AICA CONFINDUSTRIA, MANAGERITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'323',{d '2017-03-15'},'ALBERGHI: Dirigenti Catene Alberghiere')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '324')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANACI, UNAI, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2001-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2005-12-31'},sortcode = '324',stipula = {d '2001-04-19'},title = 'AMMINISTRATORI DI CONDOMINIO' WHERE idccnl = '324'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('324','S','COMMERCIO (214) ','ANACI, UNAI, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2001-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2005-12-31'},'324',{d '2001-04-19'},'AMMINISTRATORI DI CONDOMINIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '325')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNSIC, UNSICOOP, FEDERDAT, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '325',stipula = {d '2017-07-13'},title = 'Assistenza Domiciliare non Medica' WHERE idccnl = '325'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('325','S','COMMERCIO (214) ','UNSIC, UNSICOOP, FEDERDAT, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'325',{d '2017-07-13'},'Assistenza Domiciliare non Medica')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '326')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'Feder-IacCtCONFIMPRESEITALIA, ASSOPMICONFIMPRESEITALIA, CONFIMPRESEITALIA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-06-09'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-09'},sortcode = '326',stipula = {d '2017-06-23'},title = 'ATTIVITA'' COLLATERALI AL COMMERCIO, DISTRIBUZIONE E SERVIZI' WHERE idccnl = '326'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('326','S','COMMERCIO (214) ','Feder-IacCtCONFIMPRESEITALIA, ASSOPMICONFIMPRESEITALIA, CONFIMPRESEITALIA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-06-09'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-09'},'326',{d '2017-06-23'},'ATTIVITA'' COLLATERALI AL COMMERCIO, DISTRIBUZIONE E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '327')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CAPIMED, FENAPI, USAE, USPPI, CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '327',stipula = {d '2008-04-08'},title = 'Aziende Artigiane di Parrucchieri,BarbieriedEstetica (CAPIMED-FENAPI-USAE-USPPI-CEL)' WHERE idccnl = '327'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('327','S','COMMERCIO (214) ','CAPIMED, FENAPI, USAE, USPPI, CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'327',{d '2008-04-08'},'Aziende Artigiane di Parrucchieri,BarbieriedEstetica (CAPIMED-FENAPI-USAE-USPPI-CEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '328')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CEPA, CONFIMPRESEITALIA, USAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-03-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-03-01'},sortcode = '328',stipula = {d '2011-01-28'},title = 'Aziende Artigiane di Parrucchieri, Barbieri ed Estetica (CEPA-CONFIMPRESEITALIA-USAE)' WHERE idccnl = '328'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('328','S','COMMERCIO (214) ','CEPA, CONFIMPRESEITALIA, USAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-03-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-03-01'},'328',{d '2011-01-28'},'Aziende Artigiane di Parrucchieri, Barbieri ed Estetica (CEPA-CONFIMPRESEITALIA-USAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '329')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '329',stipula = {d '2011-12-22'},title = 'Aziende Artigiane di Parrucchieri, Barbieri ed Estetica (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '329'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('329','S','COMMERCIO (214) ','CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'329',{d '2011-12-22'},'Aziende Artigiane di Parrucchieri, Barbieri ed Estetica (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '330')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDARCOM, CIFA, FIADEL SP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-06-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-06-21'},sortcode = '330',stipula = {d '2010-06-22'},title = 'Aziende Artigiane di Parrucchieri, Barbieri ed Estetisti' WHERE idccnl = '330'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('330','S','COMMERCIO (214) ','FEDARCOM, CIFA, FIADEL SP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-06-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-06-21'},'330',{d '2010-06-22'},'Aziende Artigiane di Parrucchieri, Barbieri ed Estetisti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '331')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CAPIMED, FENAPI, USAE, USPPI, CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '331',stipula = {d '2008-04-08'},title = 'AziendeArtigianeOdontotecniche (CAPIMED-FENAPI-USAE-USPPI-CEL)' WHERE idccnl = '331'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('331','S','COMMERCIO (214) ','CAPIMED, FENAPI, USAE, USPPI, CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'331',{d '2008-04-08'},'AziendeArtigianeOdontotecniche (CAPIMED-FENAPI-USAE-USPPI-CEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '332')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CEPA, CONFIMPRESEITALIA, USAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-03-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-03-01'},sortcode = '332',stipula = {d '2011-01-28'},title = 'Aziende Artigiane Odontotecniche (CEPA-CONFIMPRESEITALIA-USAE)' WHERE idccnl = '332'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('332','S','COMMERCIO (214) ','CEPA, CONFIMPRESEITALIA, USAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-03-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-03-01'},'332',{d '2011-01-28'},'Aziende Artigiane Odontotecniche (CEPA-CONFIMPRESEITALIA-USAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '333')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '333',stipula = {d '2011-12-22'},title = 'Aziende Artigiane Odontotecniche (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '333'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('333','S','COMMERCIO (214) ','CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'333',{d '2011-12-22'},'Aziende Artigiane Odontotecniche (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '334')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ACAI, CONAPI, AEM ITALIA, UGL TERZIARIO ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-11-30'},sortcode = '334',stipula = {d '2012-11-29'},title = 'Aziende Artigiane settore Commercio Servizi Terziario: Emotional Manager - Coach - Counselor' WHERE idccnl = '334'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('334','S','COMMERCIO (214) ','ACAI, CONAPI, AEM ITALIA, UGL TERZIARIO ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-11-30'},'334',{d '2012-11-29'},'Aziende Artigiane settore Commercio Servizi Terziario: Emotional Manager - Coach - Counselor')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '335')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleCommercioTurismoeServizi, ASSIMEA, CONFAMMINISTRATORI, UNIMMOBILIARE, ACAP, PROGETTOANGELICA, CONFINTESATUCS, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-09-30'},scadenza = {d '2017-10-01'},sortcode = '335',stipula = {d '2017-10-04'},title = 'AZIENDE E STUDI DI AMMINISTRAZIONE CONDOMINIALE E/O DI SERVIZI INTEGRATI ALLA PROPRIETA'' IMMOBILIARE' WHERE idccnl = '335'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('335','S','COMMERCIO (214) ','UNIMPRESA, UNIMPRESAFederazione NazionaleCommercioTurismoeServizi, ASSIMEA, CONFAMMINISTRATORI, UNIMMOBILIARE, ACAP, PROGETTOANGELICA, CONFINTESATUCS, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-09-30'},{d '2017-10-01'},'335',{d '2017-10-04'},'AZIENDE E STUDI DI AMMINISTRAZIONE CONDOMINIALE E/O DI SERVIZI INTEGRATI ALLA PROPRIETA'' IMMOBILIARE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '336')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'COMPIE, AEM, ULE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-12-12'},scadenza = {d '2011-12-13'},sortcode = '336',stipula = {d '2011-12-13'},title = 'Aziende e Studi Professionali: EmotionalManager-Coach - Conselor' WHERE idccnl = '336'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('336','S','COMMERCIO (214) ','COMPIE, AEM, ULE',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-12-12'},{d '2011-12-13'},'336',{d '2011-12-13'},'Aziende e Studi Professionali: EmotionalManager-Coach - Conselor')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '337')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CESAC, FAPI, COSNIL, COSNIL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-05-31'},scadenza = {d '2010-06-01'},sortcode = '337',stipula = {d '2010-05-23'},title = 'AZIENDE IN AREE PUBBLICHE (EX AMBULANTI)' WHERE idccnl = '337'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('337','S','COMMERCIO (214) ','CESAC, FAPI, COSNIL, COSNIL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-31'},{d '2010-06-01'},'337',{d '2010-05-23'},'AZIENDE IN AREE PUBBLICHE (EX AMBULANTI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '338')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVASGSL, UNIONFORMATORI, ASSOSPAMANAGER, ASSOBEAUTYMANAGER, SITLAV, SIASO CONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-12-31'},scadenza = {d '2015-01-01'},sortcode = '338',stipula = {d '2014-12-02'},title = 'BEAUTY & WELLNESS' WHERE idccnl = '338'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('338','S','COMMERCIO (214) ','ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVASGSL, UNIONFORMATORI, ASSOSPAMANAGER, ASSOBEAUTYMANAGER, SITLAV, SIASO CONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-12-31'},{d '2015-01-01'},'338',{d '2014-12-02'},'BEAUTY & WELLNESS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '339')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIPE, CONFSAL SIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-03-31'},scadenza = {d '2019-07-30'},sortcode = '339',stipula = {d '2015-04-02'},title = 'Bellezza e Servizio alla Persona' WHERE idccnl = '339'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('339','S','COMMERCIO (214) ','CONFIPE, CONFSAL SIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-03-31'},{d '2019-07-30'},'339',{d '2015-04-02'},'Bellezza e Servizio alla Persona')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '340')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, CONFIPE, CONFIPEFIPA, CONFIPEFIE, CONFIPEFIC, CONFIPEFIBI, FESICACONFSAL, CONFSALFISALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-05-31'},scadenza = {d '2016-06-01'},sortcode = '340',stipula = {d '2016-06-27'},title = 'Bellezza e Servizio alla Persona: imprese' WHERE idccnl = '340'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('340','S','COMMERCIO (214) ','CONFIMPRESEITALIA, CONFIPE, CONFIPEFIPA, CONFIPEFIE, CONFIPEFIC, CONFIPEFIBI, FESICACONFSAL, CONFSALFISALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-05-31'},{d '2016-06-01'},'340',{d '2016-06-27'},'Bellezza e Servizio alla Persona: imprese')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '341')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSOCED, LAIT, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-06-30'},scadenza = {d '2015-07-01'},sortcode = '341',stipula = {d '2015-07-09'},title = 'CENTRI DI ELABORAZIONE DATI' WHERE idccnl = '341'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('341','S','COMMERCIO (214) ','ASSOCED, LAIT, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-06-30'},{d '2015-07-01'},'341',{d '2015-07-09'},'CENTRI DI ELABORAZIONE DATI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '342')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMEA, AECP, ASSIMPRESA, CICAS, CONFIMPRESA, FEDERTERZIARIO SUD, FISMIC, ISA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-07-31'},scadenza = {d '2012-07-31'},sortcode = '342',stipula = {d '2008-11-26'},title = 'CENTRI DI ELABORAZIONE DATI' WHERE idccnl = '342'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('342','S','COMMERCIO (214) ','CONFIMEA, AECP, ASSIMPRESA, CICAS, CONFIMPRESA, FEDERTERZIARIO SUD, FISMIC, ISA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-07-31'},{d '2012-07-31'},'342',{d '2008-11-26'},'CENTRI DI ELABORAZIONE DATI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '343')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'SISTEMACOMMERCIOEIMPRESA, UNIONCED, UNIMPRESA, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-04-30'},scadenza = {d '2011-04-30'},sortcode = '343',stipula = {d '2007-05-01'},title = 'CENTRI DI ELABORAZIONE DATI' WHERE idccnl = '343'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('343','S','COMMERCIO (214) ','SISTEMACOMMERCIOEIMPRESA, UNIONCED, UNIMPRESA, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-04-30'},{d '2011-04-30'},'343',{d '2007-05-01'},'CENTRI DI ELABORAZIONE DATI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '344')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSOCED, CONFTERZIARIO, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2003-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-04-30'},scadenza = {d '2007-04-30'},sortcode = '344',stipula = {d '2003-04-18'},title = 'CENTRI DI ELABORAZIONE DATI: Dirigenti e Quadri di direzione' WHERE idccnl = '344'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('344','S','COMMERCIO (214) ','ASSOCED, CONFTERZIARIO, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2003-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-04-30'},{d '2007-04-30'},'344',{d '2003-04-18'},'CENTRI DI ELABORAZIONE DATI: Dirigenti e Quadri di direzione')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '345')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNIMPRESA, UNIMPRESAProfessioni, CONFINTESA, CONFINTESA TUCS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-05-30'},scadenza = {d '2017-06-01'},sortcode = '345',stipula = {d '2017-05-17'},title = 'CENTRI SERVIZI' WHERE idccnl = '345'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('345','S','COMMERCIO (214) ','UNIMPRESA, UNIMPRESAProfessioni, CONFINTESA, CONFINTESA TUCS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-05-30'},{d '2017-06-01'},'345',{d '2017-05-17'},'CENTRI SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '346')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERPROPRIETA'', UPPI, CONFAPPI, FEDERCASACONFSAL, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '346',stipula = {d '2013-05-08'},title = 'COLF e BADANTI' WHERE idccnl = '346'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('346','S','COMMERCIO (214) ','FEDERPROPRIETA'', UPPI, CONFAPPI, FEDERCASACONFSAL, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'346',{d '2013-05-08'},'COLF e BADANTI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '347')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMEA, FEDERTERZIARIO, SINALP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-10-30'},scadenza = {d '2012-10-30'},sortcode = '347',stipula = {d '2012-10-30'},title = 'COLF e BADANTI (CONFIMEA)' WHERE idccnl = '347'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('347','S','COMMERCIO (214) ','CONFIMEA, FEDERTERZIARIO, SINALP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-10-30'},{d '2012-10-30'},'347',{d '2012-10-30'},'COLF e BADANTI (CONFIMEA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '348')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'LEGA IMPRESA, UIDD, FILAP, FILAP Terzo Settore, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2021-02-28'},scadenza = {d '2017-12-01'},sortcode = '348',stipula = {d '2017-11-25'},title = 'COLF E BADANTI (LEGA IMPRESA-UIDD-FILAP-CIU)' WHERE idccnl = '348'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('348','S','COMMERCIO (214) ','LEGA IMPRESA, UIDD, FILAP, FILAP Terzo Settore, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2021-02-28'},{d '2017-12-01'},'348',{d '2017-11-25'},'COLF E BADANTI (LEGA IMPRESA-UIDD-FILAP-CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '349')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASDATCOLF, SILPA, SIDU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2021-10-31'},scadenza = {d '2017-10-31'},sortcode = '349',stipula = {d '2017-10-02'},title = 'COLLABORATORI FAMILIARI' WHERE idccnl = '349'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('349','S','COMMERCIO (214) ','ASDATCOLF, SILPA, SIDU',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2021-10-31'},{d '2017-10-31'},'349',{d '2017-10-02'},'COLLABORATORI FAMILIARI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '350')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSOCALL CONFCOMMERCIO, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2021-12-31'},scadenza = {d '2017-01-01'},sortcode = '350',stipula = {d '2018-03-01'},title = 'COLLABORATORI TELEFONICI DEI CALL CENTER' WHERE idccnl = '350'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('350','S','COMMERCIO (214) ','ASSOCALL CONFCOMMERCIO, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2021-12-31'},{d '2017-01-01'},'350',{d '2018-03-01'},'COLLABORATORI TELEFONICI DEI CALL CENTER')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '351')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CICAS, CEI, CONFIMPRESA, SIA, ISA, SILSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-07-31'},scadenza = {d '2010-08-01'},sortcode = '351',stipula = {d '2010-07-19'},title = 'COMMERCIO (CICASCEICONFIMPRESASIAISASILSE)' WHERE idccnl = '351'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('351','S','COMMERCIO (214) ','CICAS, CEI, CONFIMPRESA, SIA, ISA, SILSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-31'},{d '2010-08-01'},'351',{d '2010-07-19'},'COMMERCIO (CICASCEICONFIMPRESASIAISASILSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '352')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANPIT, UNICA, CONFIMPRENDITORI, CIDEC, CISALTERZIARIO, CISAL,(sottoscrittoil20/4/2017daPMIITALIA),(sottoscrittoil5/6/2017 da UAI) ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2017-01-01'},sortcode = '352',stipula = {d '2016-12-28'},title = 'COMMERCIO (CISAL)' WHERE idccnl = '352'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('352','S','COMMERCIO (214) ','ANPIT, UNICA, CONFIMPRENDITORI, CIDEC, CISALTERZIARIO, CISAL,(sottoscrittoil20/4/2017daPMIITALIA),(sottoscrittoil5/6/2017 da UAI) ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2017-01-01'},'352',{d '2016-12-28'},'COMMERCIO (CISAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '353')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-30'},sortcode = '353',stipula = {d '2017-04-05'},title = 'COMMERCIO (FAPI-CESAC-FILDI CIU)' WHERE idccnl = '353'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('353','S','COMMERCIO (214) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-30'},'353',{d '2017-04-05'},'COMMERCIO (FAPI-CESAC-FILDI CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '354')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CNAI, UCICT, FISMIC CONFSAL, FILCOM FISMIC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-02-28'},sortcode = '354',stipula = {d '2014-03-04'},title = 'COMMERCIO (fino a 14 dipendenti)' WHERE idccnl = '354'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('354','S','COMMERCIO (214) ','CNAI, UCICT, FISMIC CONFSAL, FILCOM FISMIC',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-02-28'},'354',{d '2014-03-04'},'COMMERCIO (fino a 14 dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '355')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNSIC, ASNALI, SNALV, FNA CONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-05-31'},sortcode = '355',stipula = {d '2011-05-31'},title = 'COMMERCIO CONSUMO ALIMENTARE SERVIZI E DISTRIBUZIONE (imprese)' WHERE idccnl = '355'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('355','S','COMMERCIO (214) ','UNSIC, ASNALI, SNALV, FNA CONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-05-31'},'355',{d '2011-05-31'},'COMMERCIO CONSUMO ALIMENTARE SERVIZI E DISTRIBUZIONE (imprese)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '356')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FORITALY,IMPRENDITORI&IMPRESE, SISTEMAINDUSTRIADELL''AREAVASTA, SISTEMAINDUSTRIALAZIO, SISTEMAINDUSTRIACAMPANIA, APICALABRIA, SICILIAIMPRESA, UGLTERZIARIO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-02-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-06-30'},sortcode = '356',stipula = {d '2016-02-22'},title = 'COMMERCIO E AFFINI: micro, piccole e medie imprese (FOR.ITALY)' WHERE idccnl = '356'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('356','S','COMMERCIO (214) ','FORITALY,IMPRENDITORI&IMPRESE, SISTEMAINDUSTRIADELL''AREAVASTA, SISTEMAINDUSTRIALAZIO, SISTEMAINDUSTRIACAMPANIA, APICALABRIA, SICILIAIMPRESA, UGLTERZIARIO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-02-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-06-30'},'356',{d '2016-02-22'},'COMMERCIO E AFFINI: micro, piccole e medie imprese (FOR.ITALY)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '357')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFESERCENTI, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '357',stipula = {d '2016-10-13'},title = 'COMMERCIO E SERVIZI' WHERE idccnl = '357'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('357','S','COMMERCIO (214) ','CONFESERCENTI, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'357',{d '2016-10-13'},'COMMERCIO E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '358')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFCOMMERCIO, FILCAMS CGIL, FISASCAT CISL, UILTUCS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '358',stipula = {d '2015-03-30'},title = 'COMMERCIO E SERVIZI' WHERE idccnl = '358'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('358','S','COMMERCIO (214) ','CONFCOMMERCIO, FILCAMS CGIL, FISASCAT CISL, UILTUCS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'358',{d '2015-03-30'},'COMMERCIO E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '359')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFESERCENTI, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '359',stipula = {d '2011-03-15'},title = 'COMMERCIO E SERVIZI' WHERE idccnl = '359'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('359','S','COMMERCIO (214) ','CONFESERCENTI, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'359',{d '2011-03-15'},'COMMERCIO E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '360')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFCOMMERCIO, UGL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '360',stipula = {d '2011-02-26'},title = 'COMMERCIO E SERVIZI' WHERE idccnl = '360'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('360','S','COMMERCIO (214) ','CONFCOMMERCIO, UGL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'360',{d '2011-02-26'},'COMMERCIO E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '361')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-02-28'},sortcode = '361',stipula = {d '2016-03-01'},title = 'COMMERCIO E SERVIZI (ADLI-FAMAR)' WHERE idccnl = '361'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('361','S','COMMERCIO (214) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-02-28'},'361',{d '2016-03-01'},'COMMERCIO E SERVIZI (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '362')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFTERZIARIO, ALAR, CIU, CONFLAVORATORI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2006-08-31'},scadenza = {d '2008-08-31'},sortcode = '362',stipula = {d '2004-07-24'},title = 'COMMERCIO E SERVIZI (CONFTERZIARIO)' WHERE idccnl = '362'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('362','S','COMMERCIO (214) ','CONFTERZIARIO, ALAR, CIU, CONFLAVORATORI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-08-31'},{d '2008-08-31'},'362',{d '2004-07-24'},'COMMERCIO E SERVIZI (CONFTERZIARIO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '363')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDIMPRESE, SNAPEL, CIU, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-01-31'},sortcode = '363',stipula = {d '2016-01-31'},title = 'COMMERCIO E SERVIZI (FEDIMPRESE-SNAPEL-CIU-FAMAR)' WHERE idccnl = '363'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('363','S','COMMERCIO (214) ','FEDIMPRESE, SNAPEL, CIU, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-01-31'},'363',{d '2016-01-31'},'COMMERCIO E SERVIZI (FEDIMPRESE-SNAPEL-CIU-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '364')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'NORD INDUSTRIALE, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '364',stipula = {d '2015-02-26'},title = 'COMMERCIO E SERVIZI (NORDINDUSTRIALE-FAMAR)' WHERE idccnl = '364'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('364','S','COMMERCIO (214) ','NORD INDUSTRIALE, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'364',{d '2015-02-26'},'COMMERCIO E SERVIZI (NORDINDUSTRIALE-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '365')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFCOMMERCIO Imprese per l''Italia, MANAGERITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '365',stipula = {d '2016-07-21'},title = 'COMMERCIO E SERVIZI: Dirigenti' WHERE idccnl = '365'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('365','S','COMMERCIO (214) ','CONFCOMMERCIO Imprese per l''Italia, MANAGERITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'365',{d '2016-07-21'},'COMMERCIO E SERVIZI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '366')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSPIM, SIDA, Sindacato SLI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '366',stipula = {d '2016-11-29'},title = 'COMMERCIO E TERZIARIO (ASSPIM-SIDA-SindacatoSLI)' WHERE idccnl = '366'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('366','S','COMMERCIO (214) ','ASSPIM, SIDA, Sindacato SLI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'366',{d '2016-11-29'},'COMMERCIO E TERZIARIO (ASSPIM-SIDA-SindacatoSLI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '367')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UAI, CONFAE, CONFENAL, CONFENAL FEDITES, FSE COBAS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-12-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '367',stipula = {d '2016-12-22'},title = 'COMMERCIO E TERZIARIO (UAI-CONFAE-CONFENAL FEDITES-FSE COBAS)' WHERE idccnl = '367'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('367','S','COMMERCIO (214) ','UAI, CONFAE, CONFENAL, CONFENAL FEDITES, FSE COBAS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'367',{d '2016-12-22'},'COMMERCIO E TERZIARIO (UAI-CONFAE-CONFENAL FEDITES-FSE COBAS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '368')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDARCOM, CIFA, FIADEL SP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-06-18'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-06-17'},sortcode = '368',stipula = {d '2010-06-18'},title = 'COMMERCIO SERVIZI E TRASPORTI' WHERE idccnl = '368'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('368','S','COMMERCIO (214) ','FEDARCOM, CIFA, FIADEL SP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-06-18'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-06-17'},'368',{d '2010-06-18'},'COMMERCIO SERVIZI E TRASPORTI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '369')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDIMPRESE, SNAPEL, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-10-31'},sortcode = '369',stipula = {d '2014-12-10'},title = 'COMMERCIO TURISMO E SERVIZI (FEDIMPRESE-SNAPEL)' WHERE idccnl = '369'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('369','S','COMMERCIO (214) ','FEDIMPRESE, SNAPEL, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-10-31'},'369',{d '2014-12-10'},'COMMERCIO TURISMO E SERVIZI (FEDIMPRESE-SNAPEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '370')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESA, CNL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-30'},sortcode = '370',stipula = {d '2015-11-27'},title = 'COMMERCIO, DISTRIBUZIONE E SERVIZI (CONFIMPRESA-CNL)' WHERE idccnl = '370'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('370','S','COMMERCIO (214) ','CONFIMPRESA, CNL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-30'},'370',{d '2015-11-27'},'COMMERCIO, DISTRIBUZIONE E SERVIZI (CONFIMPRESA-CNL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '371')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESA, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-04-30'},sortcode = '371',stipula = {d '2014-04-30'},title = 'COMMERCIO, DISTRIBUZIONE E SERVIZI (CONFIMPRESA-CONSIL)' WHERE idccnl = '371'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('371','S','COMMERCIO (214) ','CONFIMPRESA, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-04-30'},'371',{d '2014-04-30'},'COMMERCIO, DISTRIBUZIONE E SERVIZI (CONFIMPRESA-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '372')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNFI, ISA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '372',stipula = {d '2014-07-29'},title = 'COMMERCIO, DISTRIBUZIONE E SERVIZI (UNFI-ISA)' WHERE idccnl = '372'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('372','S','COMMERCIO (214) ','UNFI, ISA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'372',{d '2014-07-29'},'COMMERCIO, DISTRIBUZIONE E SERVIZI (UNFI-ISA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '373')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERDAT, ASSOTERZIARIO, ASSOALIMENTA, ASSOPREVENZIONE AEP, CONSIL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-06-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-06-14'},sortcode = '373',stipula = {d '2015-06-11'},title = 'COMMERCIO,GRANDE DISTRIBUZIONE E RETAIL MARKETING' WHERE idccnl = '373'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('373','S','COMMERCIO (214) ','FEDERDAT, ASSOTERZIARIO, ASSOALIMENTA, ASSOPREVENZIONE AEP, CONSIL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-06-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-06-14'},'373',{d '2015-06-11'},'COMMERCIO,GRANDE DISTRIBUZIONE E RETAIL MARKETING')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '374')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CEPA A, SI CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-03-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-03-31'},sortcode = '374',stipula = {d '2014-03-31'},title = 'COMMERCIO, SERVIZI E TERZIARIO (CEPA-A-SI-CEL)' WHERE idccnl = '374'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('374','S','COMMERCIO (214) ','CEPA A, SI CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-03-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-03-31'},'374',{d '2014-03-31'},'COMMERCIO, SERVIZI E TERZIARIO (CEPA-A-SI-CEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '375')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESA, UNI, ASP, ASSOISPETTORI, FISMICCONFSAL, FILCOM FISMIC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '375',stipula = {d '2017-07-01'},title = 'COMMERCIO, TERZIARIO E SERVIZI' WHERE idccnl = '375'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('375','S','COMMERCIO (214) ','CONFIMPRESA, UNI, ASP, ASSOISPETTORI, FISMICCONFSAL, FILCOM FISMIC',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'375',{d '2017-07-01'},'COMMERCIO, TERZIARIO E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '376')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNSIC, UNSICOOP, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '376',stipula = {d '2016-01-13'},title = 'COMMERCIO, TERZIARIO E SERVIZI (UNSIC-UNSICOOP-UGL TERZIARIO)' WHERE idccnl = '376'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('376','S','COMMERCIO (214) ','UNSIC, UNSICOOP, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'376',{d '2016-01-13'},'COMMERCIO, TERZIARIO E SERVIZI (UNSIC-UNSICOOP-UGL TERZIARIO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '377')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CEPI UCI, ANIAC, SINALP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-10-07'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-09-30'},sortcode = '377',stipula = {d '2014-10-07'},title = 'COMMERCIO, TERZIARIO E SERVIZI: PMI' WHERE idccnl = '377'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('377','S','COMMERCIO (214) ','CEPI UCI, ANIAC, SINALP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-10-07'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-09-30'},'377',{d '2014-10-07'},'COMMERCIO, TERZIARIO E SERVIZI: PMI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '378')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CEPI UCI, CONFAEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-05-27'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-06-30'},sortcode = '378',stipula = {d '2015-05-27'},title = 'COMMERCIO, TURISMO E TERZIARIO' WHERE idccnl = '378'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('378','S','COMMERCIO (214) ','CEPI UCI, CONFAEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-05-27'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-06-30'},'378',{d '2015-05-27'},'COMMERCIO, TURISMO E TERZIARIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '379')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANCCCOOP, CONFCOOPERATIVE, AGCI, FILCAMSCGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '379',stipula = {d '2011-12-22'},title = 'COMMERCIO: Cooperative di Consumo' WHERE idccnl = '379'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('379','S','COMMERCIO (214) ','ANCCCOOP, CONFCOOPERATIVE, AGCI, FILCAMSCGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'379',{d '2011-12-22'},'COMMERCIO: Cooperative di Consumo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '380')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERAZIENDE, FEDERDIPENDENTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '380',stipula = {d '2013-01-01'},title = 'DIPENDENTI DEL TERZIARIO' WHERE idccnl = '380'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('380','S','COMMERCIO (214) ','FEDERAZIENDE, FEDERDIPENDENTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'380',{d '2013-01-01'},'DIPENDENTI DEL TERZIARIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '381')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, FENACTCONFIMPRESEITALIA, ASSEOPE, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-11-30'},sortcode = '381',stipula = {d '2017-03-28'},title = 'DIPENDENTI DEL TERZIARIO: COMMERCIO, DISTRIBUZIONE E SERVIZI' WHERE idccnl = '381'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('381','S','COMMERCIO (214) ','CONFIMPRESEITALIA, FENACTCONFIMPRESEITALIA, ASSEOPE, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-11-30'},'381',{d '2017-03-28'},'DIPENDENTI DEL TERZIARIO: COMMERCIO, DISTRIBUZIONE E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '382')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FIDAP IMPRESE, FISAL ITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2021-12-31'},sortcode = '382',stipula = {d '2017-11-07'},title = 'DIPENDENTI DEL TERZIARIO: COMMERCIO, DISTRIBUZIONE E SERVIZI (FIDAPIMPRESE-FISAL ITALIA)' WHERE idccnl = '382'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('382','S','COMMERCIO (214) ','FIDAP IMPRESE, FISAL ITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2021-12-31'},'382',{d '2017-11-07'},'DIPENDENTI DEL TERZIARIO: COMMERCIO, DISTRIBUZIONE E SERVIZI (FIDAPIMPRESE-FISAL ITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '383')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'SISTEMAIMPRESA, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '383',stipula = {d '2017-04-20'},title = 'DIPENDENTI DEL TERZIARIO: COMMERCIO, DISTRIBUZIONE E SERVIZI (SCI-CONFSAL)' WHERE idccnl = '383'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('383','S','COMMERCIO (214) ','SISTEMAIMPRESA, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'383',{d '2017-04-20'},'DIPENDENTI DEL TERZIARIO: COMMERCIO, DISTRIBUZIONE E SERVIZI (SCI-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '384')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNSIC, UNSICOOP, ASNALI, FNACONFSAL, SNALVCONFSAL, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-05-31'},sortcode = '384',stipula = {d '2016-05-26'},title = 'DISTRIBUZIONE DI CARBURANTE E COMBUSTIBILE PER USO DOMESTICO, AGRICOLO E INDUSTRIALE' WHERE idccnl = '384'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('384','S','COMMERCIO (214) ','UNSIC, UNSICOOP, ASNALI, FNACONFSAL, SNALVCONFSAL, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-05-31'},'384',{d '2016-05-26'},'DISTRIBUZIONE DI CARBURANTE E COMBUSTIBILE PER USO DOMESTICO, AGRICOLO E INDUSTRIALE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '385')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'Sindacato SLI, SIDA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-02-28'},sortcode = '385',stipula = {d '2017-02-01'},title = 'Domestici - Colf e Badanti - conviventi e non conviventi' WHERE idccnl = '385'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('385','S','COMMERCIO (214) ','Sindacato SLI, SIDA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-02-28'},'385',{d '2017-02-01'},'Domestici - Colf e Badanti - conviventi e non conviventi')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '386')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CAPIMED, FENAILP, CUB, FENALCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '386',stipula = {d '2011-11-09'},title = 'Domestici Colf e Badanti' WHERE idccnl = '386'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('386','S','COMMERCIO (214) ','CAPIMED, FENAILP, CUB, FENALCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'386',{d '2011-11-09'},'Domestici Colf e Badanti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '387')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFAR, CONFIPE, CONFSAL SIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '387',stipula = {d '2013-07-30'},title = 'Estetica, Acconciatori e Parrucchieri, in genere' WHERE idccnl = '387'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('387','S','COMMERCIO (214) ','CONFAR, CONFIPE, CONFSAL SIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'387',{d '2013-07-30'},'Estetica, Acconciatori e Parrucchieri, in genere')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '388')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSOFARM, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-07-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '388',stipula = {d '2013-07-22'},title = 'FARMACIE MUNICIPALIZZATE' WHERE idccnl = '388'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('388','S','COMMERCIO (214) ','ASSOFARM, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'388',{d '2013-07-22'},'FARMACIE MUNICIPALIZZATE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '389')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERFARMA, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-01-31'},sortcode = '389',stipula = {d '2011-11-14'},title = 'FARMACIE PRIVATE' WHERE idccnl = '389'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('389','S','COMMERCIO (214) ','FEDERFARMA, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-01-31'},'389',{d '2011-11-14'},'FARMACIE PRIVATE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '390')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-29'},sortcode = '390',stipula = {d '2016-11-30'},title = 'FARMACIE PRIVATE (ESAARCO)' WHERE idccnl = '390'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('390','S','COMMERCIO (214) ','ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-29'},'390',{d '2016-11-30'},'FARMACIE PRIVATE (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '391')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANCEF, FLAI CGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '391',stipula = {d '2013-04-11'},title = 'FIORI (IMPORT-EXPORT)' WHERE idccnl = '391'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('391','S','COMMERCIO (214) ','ANCEF, FLAI CGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'391',{d '2013-04-11'},'FIORI (IMPORT-EXPORT)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '392')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CNAI, UNAPI, MCM CNAI, FISMIC CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-06-30'},sortcode = '392',stipula = {d '2011-07-15'},title = 'GESTIONE E SERVIZI IN APPALTO (Aeroporti) ' WHERE idccnl = '392'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('392','S','COMMERCIO (214) ','CNAI, UNAPI, MCM CNAI, FISMIC CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-06-30'},'392',{d '2011-07-15'},'GESTIONE E SERVIZI IN APPALTO (Aeroporti) ')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '393')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNIMPRESA, Sindacato SLI, SIDA ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-03-31'},sortcode = '393',stipula = {d '2015-02-27'},title = 'GUARDIANIA E PORTIERATO' WHERE idccnl = '393'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('393','S','COMMERCIO (214) ','UNIMPRESA, Sindacato SLI, SIDA ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-03-31'},'393',{d '2015-02-27'},'GUARDIANIA E PORTIERATO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '394')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFEDERAZIONEITALIANADELLOSPORTCONFCOMMERCIO, SLC CGIL, FISASCAT FIST CISL, UILCOM UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2015-12-22'},sortcode = '394',stipula = {d '2015-12-22'},title = 'IMPIANTI SPORTIVI (DIPENDENTI)' WHERE idccnl = '394'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('394','S','COMMERCIO (214) ','CONFEDERAZIONEITALIANADELLOSPORTCONFCOMMERCIO, SLC CGIL, FISASCAT FIST CISL, UILCOM UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2015-12-22'},'394',{d '2015-12-22'},'IMPIANTI SPORTIVI (DIPENDENTI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '395')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERTURISMOCONFINDUSTRIA, CONFINDUSTRIAAICA, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-01-31'},sortcode = '395',stipula = {d '2016-11-14'},title = 'INDUSTRIA TURISTICA' WHERE idccnl = '395'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('395','S','COMMERCIO (214) ','FEDERTURISMOCONFINDUSTRIA, CONFINDUSTRIAAICA, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-01-31'},'395',{d '2016-11-14'},'INDUSTRIA TURISTICA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '396')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ERSAF, CEUQ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-06-30'},scadenza = {d '2017-07-01'},sortcode = '396',stipula = {d '2017-05-01'},title = 'INTERSETTORIALE: Commercio, Terziario, DistribuzioneServizi, PubbliciEsercizieTurismo (ERSAF - CEUQ)' WHERE idccnl = '396'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('396','S','COMMERCIO (214) ','ERSAF, CEUQ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-06-30'},{d '2017-07-01'},'396',{d '2017-05-01'},'INTERSETTORIALE: Commercio, Terziario, DistribuzioneServizi, PubbliciEsercizieTurismo (ERSAF - CEUQ)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '397')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CIFA, FedarcomCIFA, UniterziarioCIFA, UnipmiCIFA, CONFSAL, Fna CONFSAL, Snalv CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-06-30'},scadenza = {d '2016-07-01'},sortcode = '397',stipula = {d '2016-12-19'},title = 'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, Pubblici Esercizi e Turismo' WHERE idccnl = '397'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('397','S','COMMERCIO (214) ','CIFA, FedarcomCIFA, UniterziarioCIFA, UnipmiCIFA, CONFSAL, Fna CONFSAL, Snalv CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-06-30'},{d '2016-07-01'},'397',{d '2016-12-19'},'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, Pubblici Esercizi e Turismo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '398')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2016-01-11'},sortcode = '398',stipula = {d '2017-06-06'},title = 'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (CONFLAVORO PMI - CONFSAL)' WHERE idccnl = '398'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('398','S','COMMERCIO (214) ','CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2016-01-11'},'398',{d '2017-06-06'},'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (CONFLAVORO PMI - CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '399')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFLAVORO PMI, CONFIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-03-31'},scadenza = {d '2014-04-01'},sortcode = '399',stipula = {d '2014-03-26'},title = 'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (CONFLAVORO PMI-CONFIL)' WHERE idccnl = '399'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('399','S','COMMERCIO (214) ','CONFLAVORO PMI, CONFIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-03-31'},{d '2014-04-01'},'399',{d '2014-03-26'},'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (CONFLAVORO PMI-CONFIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '400')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FISAPI, FENAILP, FISALP CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-06-18'},scadenza = {d '2017-06-19'},sortcode = '400',stipula = {d '2017-06-15'},title = 'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (FISAPI - FENAILP - FISALP CONFSAL)' WHERE idccnl = '400'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('400','S','COMMERCIO (214) ','FISAPI, FENAILP, FISALP CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-06-18'},{d '2017-06-19'},'400',{d '2017-06-15'},'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (FISAPI - FENAILP - FISALP CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '401')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'LEGA IMPRESA, FILAP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-07-31'},scadenza = {d '2015-11-09'},sortcode = '401',stipula = {d '2015-11-09'},title = 'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (LEGA IMPRESA)' WHERE idccnl = '401'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('401','S','COMMERCIO (214) ','LEGA IMPRESA, FILAP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-07-31'},{d '2015-11-09'},'401',{d '2015-11-09'},'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (LEGA IMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '402')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'SELP, ANAP, ALIM',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-07-23'},scadenza = {d '2015-07-24'},sortcode = '402',stipula = {d '2015-07-24'},title = 'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (SELP-ANAP-ALIM)' WHERE idccnl = '402'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('402','S','COMMERCIO (214) ','SELP, ANAP, ALIM',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-07-23'},{d '2015-07-24'},'402',{d '2015-07-24'},'INTERSETTORIALE: Commercio, Terziario, Distribuzione, Servizi, PubbliciEsercizieTurismo (SELP-ANAP-ALIM)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '403')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UAI, UNAPRI, ASSIDAL, ANIF, CONFSALFASPI, FEDARMEC, CONFSAAP, SIAT, FIRAS SPP, UIPS, ALPPI, IMMEXA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-07-26'},scadenza = {d '2016-07-27'},sortcode = '403',stipula = {d '2016-07-27'},title = 'INTERSETTORIALE: Servizialleimprese, Terziario, Commercio e Distribuzione, Pubblici Esercizi e Turismo' WHERE idccnl = '403'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('403','S','COMMERCIO (214) ','UAI, UNAPRI, ASSIDAL, ANIF, CONFSALFASPI, FEDARMEC, CONFSAAP, SIAT, FIRAS SPP, UIPS, ALPPI, IMMEXA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-07-26'},{d '2016-07-27'},'403',{d '2016-07-27'},'INTERSETTORIALE: Servizialleimprese, Terziario, Commercio e Distribuzione, Pubblici Esercizi e Turismo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '404')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleIstitutiVigilanzaPrivata, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-04-30'},scadenza = {d '2017-05-01'},sortcode = '404',stipula = {d '2017-05-03'},title = 'ISTITUTI E IMPRESE DI VIGILANZA PRIVATA E SERVIZI FIDUCIARI (UNIMPRESA - CONFINTESA)' WHERE idccnl = '404'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('404','S','COMMERCIO (214) ','UNIMPRESA, UNIMPRESAFederazione NazionaleIstitutiVigilanzaPrivata, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-04-30'},{d '2017-05-01'},'404',{d '2017-05-03'},'ISTITUTI E IMPRESE DI VIGILANZA PRIVATA E SERVIZI FIDUCIARI (UNIMPRESA - CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '405')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERDAT, UNSIC, UNSICOOP, CIU, CONFIAL, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-03-14'},scadenza = {d '2017-03-15'},sortcode = '405',stipula = {d '2017-03-08'},title = 'ISTITUTI ED IMPRESE DI VIGILANZA PRIVATA E SERVIZI FIDUCIARI' WHERE idccnl = '405'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('405','S','COMMERCIO (214) ','FEDERDAT, UNSIC, UNSICOOP, CIU, CONFIAL, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-03-14'},{d '2017-03-15'},'405',{d '2017-03-08'},'ISTITUTI ED IMPRESE DI VIGILANZA PRIVATA E SERVIZI FIDUCIARI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '406')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERPOL, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-12-31'},scadenza = {d '2018-01-01'},sortcode = '406',stipula = {d '2017-12-15'},title = 'ISTITUTI INVESTIGATIVI PRIVATI E AGENZIE SICUREZZA SUSSIDIARIA' WHERE idccnl = '406'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('406','S','COMMERCIO (214) ','FEDERPOL, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-12-31'},{d '2018-01-01'},'406',{d '2017-12-15'},'ISTITUTI INVESTIGATIVI PRIVATI E AGENZIE SICUREZZA SUSSIDIARIA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '407')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-10-04'},scadenza = {d '2017-10-05'},sortcode = '407',stipula = {d '2017-10-05'},title = 'Lavoratori Domestici (FAPI-CESAC-FILDI CIU)' WHERE idccnl = '407'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('407','S','COMMERCIO (214) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-10-04'},{d '2017-10-05'},'407',{d '2017-10-05'},'Lavoratori Domestici (FAPI-CESAC-FILDI CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '408')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'EUROCOLF, CONFEURO, E-ACADEMY,MIGRANTI,OVER50, APS-ACADEMY',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2021-12-31'},scadenza = {d '2017-10-01'},sortcode = '408',stipula = {d '2017-06-09'},title = 'LAVORATORI FAMILIARI, COLF E BADANTI' WHERE idccnl = '408'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('408','S','COMMERCIO (214) ','EUROCOLF, CONFEURO, E-ACADEMY,MIGRANTI,OVER50, APS-ACADEMY',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2021-12-31'},{d '2017-10-01'},'408',{d '2017-06-09'},'LAVORATORI FAMILIARI, COLF E BADANTI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '409')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FIDALDO,DOMINA, FILCAMSCGIL, FISASCATCISL, UILTUCSUIL, FEDERCOLF, (adesione di UGL TERZIARIO dal 4/4/2014) ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2013-07-01'},sortcode = '409',stipula = {d '2013-07-16'},title = 'LAVORO DOMESTICO' WHERE idccnl = '409'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('409','S','COMMERCIO (214) ','FIDALDO,DOMINA, FILCAMSCGIL, FISASCATCISL, UILTUCSUIL, FEDERCOLF, (adesione di UGL TERZIARIO dal 4/4/2014) ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2013-07-01'},'409',{d '2013-07-16'},'LAVORO DOMESTICO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '410')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, CONFPENSIONATI, USAEFNEL, COSNILColf e Badanti, COSNIL, SILSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-07-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-07-15'},sortcode = '410',stipula = {d '2008-07-15'},title = 'Lavoro Domestico - Colf e Badanti' WHERE idccnl = '410'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('410','S','COMMERCIO (214) ','CONFIMPRESEITALIA, CONFPENSIONATI, USAEFNEL, COSNILColf e Badanti, COSNIL, SILSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-07-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-07-15'},'410',{d '2008-07-15'},'Lavoro Domestico - Colf e Badanti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '411')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANAP, SELP, LIBERO SINDACATO COLF E BADANTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '411',stipula = {d '2016-12-14'},title = 'LAVORO DOMESTICO (ANAP-SELP-LIBEROSINDACATO COLF E BADANTI)' WHERE idccnl = '411'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('411','S','COMMERCIO (214) ','ANAP, SELP, LIBERO SINDACATO COLF E BADANTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'411',{d '2016-12-14'},'LAVORO DOMESTICO (ANAP-SELP-LIBEROSINDACATO COLF E BADANTI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '412')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, UNICOLFESAARCO, CIU, SICEL, FNAOPSCLI, ASSOCOLFCLI,ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-05-30'},sortcode = '412',stipula = {d '2017-05-31'},title = 'LAVORO DOMESTICO (ESAARCO)' WHERE idccnl = '412'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('412','S','COMMERCIO (214) ','ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, UNICOLFESAARCO, CIU, SICEL, FNAOPSCLI, ASSOCOLFCLI,ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-05-30'},'412',{d '2017-05-31'},'LAVORO DOMESTICO (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '413')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FIDAP IMPRESE, FISAL ITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2021-12-31'},sortcode = '413',stipula = {d '2017-11-23'},title = 'LAVORO DOMESTICO (FIDAPIMPRESE-FISALITALIA)' WHERE idccnl = '413'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('413','S','COMMERCIO (214) ','FIDAP IMPRESE, FISAL ITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2021-12-31'},'413',{d '2017-11-23'},'LAVORO DOMESTICO (FIDAPIMPRESE-FISALITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '414')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'COMPIE, ULE, SILSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-12-19'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-18'},sortcode = '414',stipula = {d '2011-12-15'},title = 'Lavoro Domestico Badanti e Colf del Terziario' WHERE idccnl = '414'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('414','S','COMMERCIO (214) ','COMPIE, ULE, SILSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-19'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-18'},'414',{d '2011-12-15'},'Lavoro Domestico Badanti e Colf del Terziario')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '415')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANPIT, CIDEC, CONFIMPRENDITORI, UNICA, CISALTerziario, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-11-30'},sortcode = '415',stipula = {d '2017-11-08'},title = 'MARKETING' WHERE idccnl = '415'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('415','S','COMMERCIO (214) ','ANPIT, CIDEC, CONFIMPRENDITORI, UNICA, CISALTerziario, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-11-30'},'415',{d '2017-11-08'},'MARKETING')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '416')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FRUITIMPRESE, FLAI CGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '416',stipula = {d '2017-07-27'},title = 'ORTOFRUTTA E AGRUMI (Import - Export )' WHERE idccnl = '416'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('416','S','COMMERCIO (214) ','FRUITIMPRESE, FLAI CGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'416',{d '2017-07-27'},'ORTOFRUTTA E AGRUMI (Import - Export )')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '417')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVASGSL, UNIONFORMATORI, ASSOBEAUTYMANAGER, SITLAV, SIASO CONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '417',stipula = {d '2014-12-22'},title = 'PARAFARMACIE E FARMACIE DI SERVIZI' WHERE idccnl = '417'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('417','S','COMMERCIO (214) ','ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVASGSL, UNIONFORMATORI, ASSOBEAUTYMANAGER, SITLAV, SIASO CONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'417',{d '2014-12-22'},'PARAFARMACIE E FARMACIE DI SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '418')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CNAUnionebenessereesanit?, CONFARTIGIANATOBenessereAcconciatori, CONFARTIGIANATOBenessereEstetica, CASARTIGIANI, CLAAIFedernasUnamem, FILCAMSCGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '418',stipula = {d '2014-09-08'},title = 'PARRUCCHIERI: Artigiane' WHERE idccnl = '418'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('418','S','COMMERCIO (214) ','CNAUnionebenessereesanit?, CONFARTIGIANATOBenessereAcconciatori, CONFARTIGIANATOBenessereEstetica, CASARTIGIANI, CLAAIFedernasUnamem, FILCAMSCGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'418',{d '2014-09-08'},'PARRUCCHIERI: Artigiane')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '419')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FISA, CONFSAL, CONFSAL Vigili del Fuoco',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-08-31'},sortcode = '419',stipula = {d '2015-09-14'},title = 'Produzione,Installazione,ManutenzioneMezziedImpianti Antincendio' WHERE idccnl = '419'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('419','S','COMMERCIO (214) ','FISA, CONFSAL, CONFSAL Vigili del Fuoco',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-08-31'},'419',{d '2015-09-14'},'Produzione,Installazione,ManutenzioneMezziedImpianti Antincendio')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '420')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSO PMI, ANFOS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-10-24'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-10-23'},sortcode = '420',stipula = {d '2013-10-14'},title = 'PROFESSIONISTI NON ORGANIZZATI IN ORDINI O COLLEGI' WHERE idccnl = '420'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('420','S','COMMERCIO (214) ','ASSO PMI, ANFOS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-10-24'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-10-23'},'420',{d '2013-10-14'},'PROFESSIONISTI NON ORGANIZZATI IN ORDINI O COLLEGI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '421')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFEDILIZIA, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '421',stipula = {d '2012-11-12'},title = 'PROPRIETARI FABBRICATI (Dipendenti)' WHERE idccnl = '421'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('421','S','COMMERCIO (214) ','CONFEDILIZIA, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'421',{d '2012-11-12'},'PROPRIETARI FABBRICATI (Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '422')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFEDILIZIA, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '422',stipula = {d '2012-11-12'},title = 'PROPRIETARI FABBRICATI (Dipendenti)' WHERE idccnl = '422'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('422','S','COMMERCIO (214) ','CONFEDILIZIA, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'422',{d '2012-11-12'},'PROPRIETARI FABBRICATI (Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '423')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERPROPRIETA'', UPPI, CONFAPPI, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-06-30'},sortcode = '423',stipula = {d '2013-03-14'},title = 'PROPRIETARI FABBRICATI (Dipendenti): Piccoliproprietari' WHERE idccnl = '423'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('423','S','COMMERCIO (214) ','FEDERPROPRIETA'', UPPI, CONFAPPI, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-06-30'},'423',{d '2013-03-14'},'PROPRIETARI FABBRICATI (Dipendenti): Piccoliproprietari')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '424')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-09'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-03-08'},sortcode = '424',stipula = {d '2015-03-05'},title = 'PUBBLICIESERCIZI, OPERATORITURISTICI, STRUTTURE RICETTIVE,...' WHERE idccnl = '424'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('424','S','COMMERCIO (214) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-09'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-03-08'},'424',{d '2015-03-05'},'PUBBLICIESERCIZI, OPERATORITURISTICI, STRUTTURE RICETTIVE,...')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '425')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FIPE, ANGEM,LEGACOOPPRODUZIONEESERVIZI, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCI, FILCAMSCGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-12-31'},sortcode = '425',stipula = {d '2018-02-08'},title = 'PUBBLICI ESERCIZI, RISTORAZIONE COLLETTIVA E  COMMERCIALE E TURISMO' WHERE idccnl = '425'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('425','S','COMMERCIO (214) ','FIPE, ANGEM,LEGACOOPPRODUZIONEESERVIZI, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCI, FILCAMSCGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-12-31'},'425',{d '2018-02-08'},'PUBBLICI ESERCIZI, RISTORAZIONE COLLETTIVA E  COMMERCIALE E TURISMO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '426')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNSIC, FEDERSECURITY, CONFAEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-02-28'},sortcode = '426',stipula = {d '2012-03-07'},title = 'SECURITY' WHERE idccnl = '426'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('426','S','COMMERCIO (214) ','UNSIC, FEDERSECURITY, CONFAEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-02-28'},'426',{d '2012-03-07'},'SECURITY')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '427')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRENDITORI, CIU ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-10-12'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-10-11'},sortcode = '427',stipula = {d '2016-10-11'},title = 'SERVIZI AL MARKETING OPERATIVO (CONFIMPRENDITORI-CIU)' WHERE idccnl = '427'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('427','S','COMMERCIO (214) ','CONFIMPRENDITORI, CIU ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-12'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-10-11'},'427',{d '2016-10-11'},'SERVIZI AL MARKETING OPERATIVO (CONFIMPRENDITORI-CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '428')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-28'},sortcode = '428',stipula = {d '2017-07-26'},title = 'Servizi alle Famiglie (CONFLAVORO PMI - CONFSAL)' WHERE idccnl = '428'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('428','S','COMMERCIO (214) ','CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-28'},'428',{d '2017-07-26'},'Servizi alle Famiglie (CONFLAVORO PMI - CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '429')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FORITALY, SISTEMAINDUSTRIADELL''AREAVASTA, SISTEMAINDUSTRIALAZIO, SISTEMAINDUSTRIACAMPANIA, APICALABRIA, SICILIAIMPRESA, AIC, FAGRI, ASPERA, ASSOTEC,IMPRENDITORI&IMPRESE, UGL TERZIARIO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-06-30'},scadenza = {d '2016-02-22'},sortcode = '429',stipula = {d '2016-02-22'},title = 'SERVIZIEAFFINI: cooperative e micro, piccole e medie imprese (FOR.ITALY)' WHERE idccnl = '429'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('429','S','COMMERCIO (214) ','FORITALY, SISTEMAINDUSTRIADELL''AREAVASTA, SISTEMAINDUSTRIALAZIO, SISTEMAINDUSTRIACAMPANIA, APICALABRIA, SICILIAIMPRESA, AIC, FAGRI, ASPERA, ASSOTEC,IMPRENDITORI&IMPRESE, UGL TERZIARIO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-06-30'},{d '2016-02-22'},'429',{d '2016-02-22'},'SERVIZIEAFFINI: cooperative e micro, piccole e medie imprese (FOR.ITALY)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '430')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-03-08'},scadenza = {d '2015-03-09'},sortcode = '430',stipula = {d '2015-03-05'},title = 'Settore COMMERCIALE e dei SERVIZI, TERZIARIO e TURISMO' WHERE idccnl = '430'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('430','S','COMMERCIO (214) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-03-08'},{d '2015-03-09'},'430',{d '2015-03-05'},'Settore COMMERCIALE e dei SERVIZI, TERZIARIO e TURISMO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '431')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONAPI, FMPI CONAPI, CONFINTESA, CONFINTESA TUCS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-12-31'},scadenza = {d '2018-01-01'},sortcode = '431',stipula = {d '2017-12-14'},title = 'Settore DOMESTICO (CONAPI - CONFINTESA)' WHERE idccnl = '431'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('431','S','COMMERCIO (214) ','CONAPI, FMPI CONAPI, CONFINTESA, CONFINTESA TUCS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-12-31'},{d '2018-01-01'},'431',{d '2017-12-14'},'Settore DOMESTICO (CONAPI - CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '432')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-02-28'},scadenza = {d '2016-03-01'},sortcode = '432',stipula = {d '2016-03-01'},title = 'SICUREZZA (ADLI-FAMAR)' WHERE idccnl = '432'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('432','S','COMMERCIO (214) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-02-28'},{d '2016-03-01'},'432',{d '2016-03-01'},'SICUREZZA (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '433')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNSIC, UNSICOOP, SIVIPPS, CESALP, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-02-28'},scadenza = {d '2015-03-01'},sortcode = '433',stipula = {d '2015-02-18'},title = 'SICUREZZA, CUSTODIA E VIGILANZA PRIVATA' WHERE idccnl = '433'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('433','S','COMMERCIO (214) ','UNSIC, UNSICOOP, SIVIPPS, CESALP, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-02-28'},{d '2015-03-01'},'433',{d '2015-02-18'},'SICUREZZA, CUSTODIA E VIGILANZA PRIVATA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '434')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANAP, ALIM, SELP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2015-12-18'},sortcode = '434',stipula = {d '2015-12-18'},title = 'SICUREZZA, CUSTODIA E VIGILANZA PRIVATA (ANAP-ALIM-SELP)' WHERE idccnl = '434'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('434','S','COMMERCIO (214) ','ANAP, ALIM, SELP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2015-12-18'},'434',{d '2015-12-18'},'SICUREZZA, CUSTODIA E VIGILANZA PRIVATA (ANAP-ALIM-SELP)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '435')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'LEGA IMPRESA, FILAP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2015-11-09'},sortcode = '435',stipula = {d '2015-11-09'},title = 'SICUREZZA, STEWART, PORTIERATO E CONTROLLO (LEGA IMPRESA)' WHERE idccnl = '435'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('435','S','COMMERCIO (214) ','LEGA IMPRESA, FILAP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2015-11-09'},'435',{d '2015-11-09'},'SICUREZZA, STEWART, PORTIERATO E CONTROLLO (LEGA IMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '436')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANISA, CONFSAL, CONFSAL VIGILI DEL FUOCO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2012-07-31'},scadenza = {d '2009-08-01'},sortcode = '436',stipula = {d '2009-11-03'},title = 'SORVEGLIANZA ANTINCENDIO' WHERE idccnl = '436'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('436','S','COMMERCIO (214) ','ANISA, CONFSAL, CONFSAL VIGILI DEL FUOCO',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-07-31'},{d '2009-08-01'},'436',{d '2009-11-03'},'SORVEGLIANZA ANTINCENDIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '437')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANAI, CSE, CSE FULSCAM',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-04-30'},scadenza = {d '2014-05-01'},sortcode = '437',stipula = {d '2014-04-17'},title = 'STUDI LEGALI: Dipendenti e Collaboratori' WHERE idccnl = '437'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('437','S','COMMERCIO (214) ','ANAI, CSE, CSE FULSCAM',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-30'},{d '2014-05-01'},'437',{d '2014-04-17'},'STUDI LEGALI: Dipendenti e Collaboratori')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '438')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-11-20'},scadenza = {d '2016-11-21'},sortcode = '438',stipula = {d '2016-11-21'},title = 'Studi Odontoiatri (ESAARCO)' WHERE idccnl = '438'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('438','S','COMMERCIO (214) ','ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-11-20'},{d '2016-11-21'},'438',{d '2016-11-21'},'Studi Odontoiatri (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '439')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CIFA, AIO, FIALS CONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-02-29'},scadenza = {d '2017-03-01'},sortcode = '439',stipula = {d '2017-03-30'},title = 'Studi Odontoiatrici e Medico Dentistici' WHERE idccnl = '439'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('439','S','COMMERCIO (214) ','CIFA, AIO, FIALS CONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-02-29'},{d '2017-03-01'},'439',{d '2017-03-30'},'Studi Odontoiatrici e Medico Dentistici')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '440')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFPROFESSIONI, FILCAMSCGIL, FISASCATCISL, UILTUCSUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-03-31'},scadenza = {d '2015-04-01'},sortcode = '440',stipula = {d '2015-04-17'},title = 'STUDI Professionali' WHERE idccnl = '440'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('440','S','COMMERCIO (214) ','CONFPROFESSIONI, FILCAMSCGIL, FISASCATCISL, UILTUCSUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-03-31'},{d '2015-04-01'},'440',{d '2015-04-17'},'STUDI Professionali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '441')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, ASSOCIAZIONEEspertiAmbientali.it, ASSIPRO, AIVAsgsl, SIASOCONFSAL, CONFSAL, UNIONFORMATORI, ASSOSPAMANAGER, ASSOBEAUTYMANAGER, SITLAV',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-03-31'},scadenza = {d '2015-04-01'},sortcode = '441',stipula = {d '2015-03-30'},title = 'Studi Professionali' WHERE idccnl = '441'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('441','S','COMMERCIO (214) ','ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, ASSOCIAZIONEEspertiAmbientali.it, ASSIPRO, AIVAsgsl, SIASOCONFSAL, CONFSAL, UNIONFORMATORI, ASSOSPAMANAGER, ASSOBEAUTYMANAGER, SITLAV',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-03-31'},{d '2015-04-01'},'441',{d '2015-03-30'},'Studi Professionali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '442')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMEA, AECP, ASSIMPRESA, CICAS, CONFUNAI, CONFEURO, FEDERTERZIARIO SUD, FISMIC, ISA, SIASO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-04-30'},scadenza = {d '2013-04-30'},sortcode = '442',stipula = {d '2009-04-22'},title = 'Studi Professionali' WHERE idccnl = '442'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('442','S','COMMERCIO (214) ','CONFIMEA, AECP, ASSIMPRESA, CICAS, CONFUNAI, CONFEURO, FEDERTERZIARIO SUD, FISMIC, ISA, SIASO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-04-30'},{d '2013-04-30'},'442',{d '2009-04-22'},'Studi Professionali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '443')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-07-05'},scadenza = {d '2015-07-06'},sortcode = '443',stipula = {d '2015-07-02'},title = 'Studi Professionali (CONFIMPRENDITORI-USIL)' WHERE idccnl = '443'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('443','S','COMMERCIO (214) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-07-05'},{d '2015-07-06'},'443',{d '2015-07-02'},'Studi Professionali (CONFIMPRENDITORI-USIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '444')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-05-18'},sortcode = '444',stipula = {d '2017-05-18'},title = 'Studi Professionali (CONFLAVORO PMI - CONFSAL)' WHERE idccnl = '444'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('444','S','COMMERCIO (214) ','CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-05-18'},'444',{d '2017-05-18'},'Studi Professionali (CONFLAVORO PMI - CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '445')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ESAARCO, CEPAA, ESAARCOServizieTerziario, CEPAAFedercoop, SAI, FER, CIU, SICEL, FNAOPSCGEL,ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-11-20'},scadenza = {d '2016-11-21'},sortcode = '445',stipula = {d '2016-11-21'},title = 'Studi Professionali (ESAARCO)' WHERE idccnl = '445'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('445','S','COMMERCIO (214) ','ESAARCO, CEPAA, ESAARCOServizieTerziario, CEPAAFedercoop, SAI, FER, CIU, SICEL, FNAOPSCGEL,ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-11-20'},{d '2016-11-21'},'445',{d '2016-11-21'},'Studi Professionali (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '446')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERDAT, CIU, CONSIL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-11-30'},scadenza = {d '2016-12-01'},sortcode = '446',stipula = {d '2016-11-30'},title = 'Studi Professionali (FEDERDAT-CIU-CONSIL)' WHERE idccnl = '446'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('446','S','COMMERCIO (214) ','FEDERDAT, CIU, CONSIL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-11-30'},{d '2016-12-01'},'446',{d '2016-11-30'},'Studi Professionali (FEDERDAT-CIU-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '447')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERIMPRESEITALIA, ALPAI, SALPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-09-30'},sortcode = '447',stipula = {d '2016-09-30'},title = 'Studi Professionali (FEDERIMPRESEITALIA-ALPAI-SALPS)' WHERE idccnl = '447'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('447','S','COMMERCIO (214) ','FEDERIMPRESEITALIA, ALPAI, SALPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-09-30'},'447',{d '2016-09-30'},'Studi Professionali (FEDERIMPRESEITALIA-ALPAI-SALPS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '448')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FISAPI, CEPI, ASSIMEA, FENAILP, FISALP CONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-11-30'},sortcode = '448',stipula = {d '2017-01-26'},title = 'Studi Professionali (Fisapi-Fisalp Confsal)' WHERE idccnl = '448'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('448','S','COMMERCIO (214) ','FISAPI, CEPI, ASSIMEA, FENAILP, FISALP CONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-11-30'},'448',{d '2017-01-26'},'Studi Professionali (Fisapi-Fisalp Confsal)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '449')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'LAIT, CONFTERZIARIO, CIU, CONFLAVORATORI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2006-08-31'},scadenza = {d '2008-08-31'},sortcode = '449',stipula = {d '2004-07-23'},title = 'STUDI Professionali Contabili' WHERE idccnl = '449'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('449','S','COMMERCIO (214) ','LAIT, CONFTERZIARIO, CIU, CONFLAVORATORI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-08-31'},{d '2008-08-31'},'449',{d '2004-07-23'},'STUDI Professionali Contabili')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '450')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANACI, SACI, CISAL TERZIARIO, CISAL, ENBIF',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-02-28'},sortcode = '450',stipula = {d '2016-01-28'},title = 'STUDI PROFESSIONALI O SOCIETA'' AMMINISTRATORI CONDOMINIO' WHERE idccnl = '450'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('450','S','COMMERCIO (214) ','ANACI, SACI, CISAL TERZIARIO, CISAL, ENBIF',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-02-28'},'450',{d '2016-01-28'},'STUDI PROFESSIONALI O SOCIETA'' AMMINISTRATORI CONDOMINIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '451')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFDENT, ALP, UGL, AIPAO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2002-05-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2004-05-15'},scadenza = {d '2006-05-15'},sortcode = '451',stipula = {d '2002-05-15'},title = 'STUDI Professionali Odontoiatrici (Dipendenti)' WHERE idccnl = '451'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('451','S','COMMERCIO (214) ','CONFDENT, ALP, UGL, AIPAO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2002-05-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-05-15'},{d '2006-05-15'},'451',{d '2002-05-15'},'STUDI Professionali Odontoiatrici (Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '452')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANCOT, ANAP, ALIM, FENAPI, SELP, ALI CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-06-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-06-21'},sortcode = '452',stipula = {d '2016-06-22'},title = 'StudiProfessionali, CentriElaborazioneDati, Consulenti Tributari e Tributaristi' WHERE idccnl = '452'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('452','S','COMMERCIO (214) ','ANCOT, ANAP, ALIM, FENAPI, SELP, ALI CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-06-21'},'452',{d '2016-06-22'},'StudiProfessionali, CentriElaborazioneDati, Consulenti Tributari e Tributaristi')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '453')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'INRL,LAPET, ANPIT, CIDEC, CISALTerziario, CISAL,(sottoscrittoda UAI il 5/6/2017)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '453',stipula = {d '2016-11-14'},title = 'Studi Revisori Legali e Tributaristi' WHERE idccnl = '453'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('453','S','COMMERCIO (214) ','INRL,LAPET, ANPIT, CIDEC, CISALTerziario, CISAL,(sottoscrittoda UAI il 5/6/2017)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'453',{d '2016-11-14'},'Studi Revisori Legali e Tributaristi')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '454')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FOR ITALY, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-20'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '454',stipula = {d '2017-04-20'},title = 'TERZIARIO (FOR.ITALY-FAMAR)' WHERE idccnl = '454'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('454','S','COMMERCIO (214) ','FOR ITALY, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-20'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'454',{d '2017-04-20'},'TERZIARIO (FOR.ITALY-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '455')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ESAARCO, CEPAA, ESAARCOServizieTerziario, CEPAAFedercoop, SAI, FER, CIU, SI CEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-20'},sortcode = '455',stipula = {d '2016-11-21'},title = 'TERZIARIO DI MERCATO: DISTRIBUZIONE E SERVIZI (ESAARCO)' WHERE idccnl = '455'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('455','S','COMMERCIO (214) ','ESAARCO, CEPAA, ESAARCOServizieTerziario, CEPAAFedercoop, SAI, FER, CIU, SI CEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-20'},'455',{d '2016-11-21'},'TERZIARIO DI MERCATO: DISTRIBUZIONE E SERVIZI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '456')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDARCOM, CIFA, FIADEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-07-08'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-07-07'},sortcode = '456',stipula = {d '2009-07-08'},title = 'TERZIARIO E SERVIZI: Aziende e Cooperative' WHERE idccnl = '456'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('456','S','COMMERCIO (214) ','FEDARCOM, CIFA, FIADEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-07-08'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-07-07'},'456',{d '2009-07-08'},'TERZIARIO E SERVIZI: Aziende e Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '457')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '457',stipula = {d '2014-07-15'},title = 'TERZIARIO E TURISMO: Cooperative' WHERE idccnl = '457'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('457','S','COMMERCIO (214) ','SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'457',{d '2014-07-15'},'TERZIARIO E TURISMO: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '458')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESETERZIARIO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSEFNILASU, CSE FNILT, CSE COOP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '458',stipula = {d '2011-11-28'},title = 'TERZIARIO, COMMERCIO E SERVIZI-CONFIMPRESEITALIA-ACS-CSE' WHERE idccnl = '458'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('458','S','COMMERCIO (214) ','CONFIMPRESEITALIA, CONFIMPRESETERZIARIO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSEFNILASU, CSE FNILT, CSE COOP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'458',{d '2011-11-28'},'TERZIARIO, COMMERCIO E SERVIZI-CONFIMPRESEITALIA-ACS-CSE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '459')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CEPA A, UGL TERZIARIO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-05-31'},sortcode = '459',stipula = {d '2014-05-28'},title = 'TERZIARIO, COMMERCIO E SERVIZI: micro, piccolee medie imprese del settore (CEPA A-UGL)' WHERE idccnl = '459'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('459','S','COMMERCIO (214) ','CEPA A, UGL TERZIARIO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-05-31'},'459',{d '2014-05-28'},'TERZIARIO, COMMERCIO E SERVIZI: micro, piccolee medie imprese del settore (CEPA A-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '460')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMEA, FEDERTERZIARIO, CFC, UGL TERZIARIO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '460',stipula = {d '2017-03-08'},title = 'TERZIARIO, COMMERCIO E SERVIZI: micro, piccolee medie imprese del settore (CONFIMEA-UGL)' WHERE idccnl = '460'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('460','S','COMMERCIO (214) ','CONFIMEA, FEDERTERZIARIO, CFC, UGL TERZIARIO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'460',{d '2017-03-08'},'TERZIARIO, COMMERCIO E SERVIZI: micro, piccolee medie imprese del settore (CONFIMEA-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '461')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMEA, FEDERMOBILITA'', FEDERTERZIARIO, CFC, UGLTERZIARIO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '461',stipula = {d '2017-03-08'},title = 'TERZIARIO, COMMERCIO E SERVIZI: micro, piccolee medie imprese del settore (CONFIMEA-UGL)' WHERE idccnl = '461'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('461','S','COMMERCIO (214) ','CONFIMEA, FEDERMOBILITA'', FEDERTERZIARIO, CFC, UGLTERZIARIO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'461',{d '2017-03-08'},'TERZIARIO, COMMERCIO E SERVIZI: micro, piccolee medie imprese del settore (CONFIMEA-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '462')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESETERZIARIO, ASSEOPE, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '462',stipula = {d '2013-06-26'},title = 'TERZIARIO, COMMERCIO E SERVIZI: micro, piccole e medie imprese del settore (CONFIMPRESE-ASSEOPE-UGL TERZIARIO)' WHERE idccnl = '462'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('462','S','COMMERCIO (214) ','CONFIMPRESEITALIA, CONFIMPRESETERZIARIO, ASSEOPE, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'462',{d '2013-06-26'},'TERZIARIO, COMMERCIO E SERVIZI: micro, piccole e medie imprese del settore (CONFIMPRESE-ASSEOPE-UGL TERZIARIO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '463')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVAsgsl, FITRAITALIA, UNAIT, CICAS, ASSOAPI, CEPIUCI, CONFITIP, CONFUNISCO, FEDERIMPRESEITALIA, FENAILP, CONFLAI, FENALCA,ISASindacato, SIASOCONFSAL, SITLAV, UNIONFORMATORI ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-10-31'},sortcode = '463',stipula = {d '2015-10-15'},title = 'TERZIARIO, COMMERCIO, DISTRIBUZIONE E SERVIZI - ITALIA IMPRESA' WHERE idccnl = '463'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('463','S','COMMERCIO (214) ','ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVAsgsl, FITRAITALIA, UNAIT, CICAS, ASSOAPI, CEPIUCI, CONFITIP, CONFUNISCO, FEDERIMPRESEITALIA, FENAILP, CONFLAI, FENALCA,ISASindacato, SIASOCONFSAL, SITLAV, UNIONFORMATORI ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-10-31'},'463',{d '2015-10-15'},'TERZIARIO, COMMERCIO, DISTRIBUZIONE E SERVIZI - ITALIA IMPRESA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '464')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFINNOVA, FEDERSICUREZZA ITALIA, SINAST',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '464',stipula = {d '2016-12-13'},title = 'TERZIARIO, COMMERCIO, DISTRIBUZIONE E SERVIZI (CONFINNOVA-FEDERSICUREZZAITALIA-SINAST)' WHERE idccnl = '464'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('464','S','COMMERCIO (214) ','CONFINNOVA, FEDERSICUREZZA ITALIA, SINAST',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'464',{d '2016-12-13'},'TERZIARIO, COMMERCIO, DISTRIBUZIONE E SERVIZI (CONFINNOVA-FEDERSICUREZZAITALIA-SINAST)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '465')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleCommercioTurismo e Servizi, CONFINTESA TUCS, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-02-28'},sortcode = '465',stipula = {d '2017-03-22'},title = 'TERZIARIO, COMMERCIO, DISTRIBUZIONE E SERVIZI (UNIMPRESA - CONFINTESA)' WHERE idccnl = '465'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('465','S','COMMERCIO (214) ','UNIMPRESA, UNIMPRESAFederazione NazionaleCommercioTurismo e Servizi, CONFINTESA TUCS, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-02-28'},'465',{d '2017-03-22'},'TERZIARIO, COMMERCIO, DISTRIBUZIONE E SERVIZI (UNIMPRESA - CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '466')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FMPICONAPI, CONAPI, CONFINTESATurismo, CommercioeServizi, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-04'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-03'},sortcode = '466',stipula = {d '2016-03-04'},title = 'TERZIARIO, COMMERCIO, TURISMO E SERVIZI (finoa 50 dipendenti) - (CONAPI-CONFINTESA)' WHERE idccnl = '466'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('466','S','COMMERCIO (214) ','FMPICONAPI, CONAPI, CONFINTESATurismo, CommercioeServizi, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-04'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-03'},'466',{d '2016-03-04'},'TERZIARIO, COMMERCIO, TURISMO E SERVIZI (finoa 50 dipendenti) - (CONAPI-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '467')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDARCOM, CIFA, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-04-30'},sortcode = '467',stipula = {d '2009-04-16'},title = 'TERZIARIO, DISTRIBUZIONE E SERVIZI-CONFSALFEDARCOM CIFA ' WHERE idccnl = '467'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('467','S','COMMERCIO (214) ','FEDARCOM, CIFA, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-04-30'},'467',{d '2009-04-16'},'TERZIARIO, DISTRIBUZIONE E SERVIZI-CONFSALFEDARCOM CIFA ')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '468')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERIMPRESEITALIA, ALPAI, SALPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-14'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-01-14'},sortcode = '468',stipula = {d '2015-01-14'},title = 'TERZIARIO, DISTRIBUZIONE E SERVIZI (FEDERIMPRESEITALIA-ALPAI-SALPS)' WHERE idccnl = '468'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('468','S','COMMERCIO (214) ','FEDERIMPRESEITALIA, ALPAI, SALPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-14'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-01-14'},'468',{d '2015-01-14'},'TERZIARIO, DISTRIBUZIONE E SERVIZI (FEDERIMPRESEITALIA-ALPAI-SALPS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '469')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERIMPRESEITALIA, CONF COINAR, CONFSAL SIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-05-28'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-05-27'},sortcode = '469',stipula = {d '2014-05-28'},title = 'TERZIARIO, DISTRIBUZIONE E SERVIZI (FEDERIMPRESEITALIA-CONFCOINAR-CONFSALSIA)' WHERE idccnl = '469'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('469','S','COMMERCIO (214) ','FEDERIMPRESEITALIA, CONF COINAR, CONFSAL SIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-05-28'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-05-27'},'469',{d '2014-05-28'},'TERZIARIO, DISTRIBUZIONE E SERVIZI (FEDERIMPRESEITALIA-CONFCOINAR-CONFSALSIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '470')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFAR, SIA CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = null,sortcode = '470',stipula = {d '2013-03-15'},title = 'TERZIARIO: COMMERCIO, DISTRIBUZIONE E SERVIZI' WHERE idccnl = '470'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('470','S','COMMERCIO (214) ','CONFAR, SIA CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,'470',{d '2013-03-15'},'TERZIARIO: COMMERCIO, DISTRIBUZIONE E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '471')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CNAI, UCICT, FISMIC CONFSAL, FILCOM FISMIC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-06-30'},sortcode = '471',stipula = {d '2012-06-27'},title = 'TERZIARO E SERVIZI - CNAI-UCICT' WHERE idccnl = '471'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('471','S','COMMERCIO (214) ','CNAI, UCICT, FISMIC CONFSAL, FILCOM FISMIC',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-06-30'},'471',{d '2012-06-27'},'TERZIARO E SERVIZI - CNAI-UCICT')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '472')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ACIS, UNIONLIBERI, FEDERLIBERI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-13'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '472',stipula = {d '2016-04-13'},title = 'TURISMO (ACIS-UNIONLIBERI-FAMAR)' WHERE idccnl = '472'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('472','S','COMMERCIO (214) ','ACIS, UNIONLIBERI, FEDERLIBERI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-13'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'472',{d '2016-04-13'},'TURISMO (ACIS-UNIONLIBERI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '473')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-02-28'},sortcode = '473',stipula = {d '2016-03-01'},title = 'TURISMO (ADLI-FAMAR)' WHERE idccnl = '473'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('473','S','COMMERCIO (214) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-02-28'},'473',{d '2016-03-01'},'TURISMO (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '474')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'AIP, CONFLAVORATORI, FENASALC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-12-09'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-01'},sortcode = '474',stipula = {d '2013-12-09'},title = 'TURISMO (AIP-CONFLAVORATORI-FENASALC)' WHERE idccnl = '474'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('474','S','COMMERCIO (214) ','AIP, CONFLAVORATORI, FENASALC',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-12-09'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-01'},'474',{d '2013-12-09'},'TURISMO (AIP-CONFLAVORATORI-FENASALC)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '475')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERALBERGHI, FAITA, CONFCOMMERCIOIMPRESEPERL''ITALIA, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-08-31'},sortcode = '475',stipula = {d '2014-01-18'},title = 'TURISMO (AZIENDE CONFCOMMERCIO)' WHERE idccnl = '475'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('475','S','COMMERCIO (214) ','FEDERALBERGHI, FAITA, CONFCOMMERCIOIMPRESEPERL''ITALIA, FILCAMS CGIL, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-08-31'},'475',{d '2014-01-18'},'TURISMO (AZIENDE CONFCOMMERCIO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '476')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERALBERGHI, FIPE, FIAVET, FAITA, CONFCOMMERCIOIMPRESE PER L''ITALIA, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-04-30'},sortcode = '476',stipula = {d '2010-05-28'},title = 'TURISMO (AZIENDE CONFCOMMERCIO)' WHERE idccnl = '476'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('476','S','COMMERCIO (214) ','FEDERALBERGHI, FIPE, FIAVET, FAITA, CONFCOMMERCIOIMPRESE PER L''ITALIA, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-04-30'},'476',{d '2010-05-28'},'TURISMO (AZIENDE CONFCOMMERCIO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '477')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSOTURISMO, ASSHOTEL, ASSOCAMPING, ASSOVIAGGI, FIBA, FIEPET, CONFESERCENTI, FILCAMSCGIL, FISASCATCISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-04-30'},sortcode = '477',stipula = {d '2010-03-04'},title = 'TURISMO (AZIENDE CONFESERCENTI)' WHERE idccnl = '477'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('477','S','COMMERCIO (214) ','ASSOTURISMO, ASSHOTEL, ASSOCAMPING, ASSOVIAGGI, FIBA, FIEPET, CONFESERCENTI, FILCAMSCGIL, FISASCATCISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-04-30'},'477',{d '2010-03-04'},'TURISMO (AZIENDE CONFESERCENTI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '478')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFTERZIARIO, ALAR, CIU, CONFLAVORATORI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2006-07-31'},scadenza = {d '2008-07-31'},sortcode = '478',stipula = {d '2004-07-24'},title = 'TURISMO (AZIENDE CONFTERZIARIO)' WHERE idccnl = '478'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('478','S','COMMERCIO (214) ','CONFTERZIARIO, ALAR, CIU, CONFLAVORATORI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-07-31'},{d '2008-07-31'},'478',{d '2004-07-24'},'TURISMO (AZIENDE CONFTERZIARIO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '479')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FMPICONAPI, CONAPI, CONFINTESA, CONFINTESATurismo, Commercio e Servizi',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-06-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-05-30'},sortcode = '479',stipula = {d '2017-06-01'},title = 'TURISMO (CONAPI-CONFINTESA)' WHERE idccnl = '479'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('479','S','COMMERCIO (214) ','FMPICONAPI, CONAPI, CONFINTESA, CONFINTESATurismo, Commercio e Servizi',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-06-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-05-30'},'479',{d '2017-06-01'},'TURISMO (CONAPI-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '480')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ESAARCO, CEPAA, CEPAATurismo, CEPAAFedercoop, SAI, FER, CIU, SI CEL, ONAPS, FLT CGEL, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-20'},sortcode = '480',stipula = {d '2016-11-21'},title = 'TURISMO (ESAARCO)' WHERE idccnl = '480'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('480','S','COMMERCIO (214) ','ESAARCO, CEPAA, CEPAATurismo, CEPAAFedercoop, SAI, FER, CIU, SI CEL, ONAPS, FLT CGEL, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-20'},'480',{d '2016-11-21'},'TURISMO (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '481')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, UGL TERZIARIO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '481',stipula = {d '2017-10-10'},title = 'TURISMO (FEDERTERZIARIO-CONFIMEA-CFC-UGL)' WHERE idccnl = '481'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('481','S','COMMERCIO (214) ','FEDERTERZIARIO, CONFIMEA, CFC, UGL TERZIARIO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'481',{d '2017-10-10'},'TURISMO (FEDERTERZIARIO-CONFIMEA-CFC-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '482')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDIMPRESE, SNAPEL, CIU, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-01-30'},sortcode = '482',stipula = {d '2016-01-31'},title = 'TURISMO (FEDIMPRESE-SNAPEL-CIU-FAMAR)' WHERE idccnl = '482'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('482','S','COMMERCIO (214) ','FEDIMPRESE, SNAPEL, CIU, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-01-30'},'482',{d '2016-01-31'},'TURISMO (FEDIMPRESE-SNAPEL-CIU-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '483')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CNAI, UCICT, FISMIC CONFSAL, FILCOM FISMIC ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-02-28'},sortcode = '483',stipula = {d '2014-03-04'},title = 'TURISMO (fino a 14 dipendenti)' WHERE idccnl = '483'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('483','S','COMMERCIO (214) ','CNAI, UCICT, FISMIC CONFSAL, FILCOM FISMIC ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-02-28'},'483',{d '2014-03-04'},'TURISMO (fino a 14 dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '484')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FORITALY,IMPRENDITORI&IMPRESE, SISTEMAINDUSTRIADELL''AREAVASTA, SISTEMAINDUSTRIALAZIO, SISTEMAINDUSTRIACAMPANIA, APICALABRIA, SICILIAIMPRESA, UGLTERZIARIO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-02-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-06-30'},sortcode = '484',stipula = {d '2016-02-22'},title = 'TURISMO E AFFINI: micro, piccole e medieimprese (FOR.ITALY)' WHERE idccnl = '484'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('484','S','COMMERCIO (214) ','FORITALY,IMPRENDITORI&IMPRESE, SISTEMAINDUSTRIADELL''AREAVASTA, SISTEMAINDUSTRIALAZIO, SISTEMAINDUSTRIACAMPANIA, APICALABRIA, SICILIAIMPRESA, UGLTERZIARIO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-02-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-06-30'},'484',{d '2016-02-22'},'TURISMO E AFFINI: micro, piccole e medieimprese (FOR.ITALY)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '485')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'SISTEMAIMPRESA, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-10-31'},sortcode = '485',stipula = {d '2017-10-26'},title = 'TURISMO E PUBBLICI ESERCIZI' WHERE idccnl = '485'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('485','S','COMMERCIO (214) ','SISTEMAIMPRESA, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-10-31'},'485',{d '2017-10-26'},'TURISMO E PUBBLICI ESERCIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '486')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CNAI, UCICT, FISMIC CONFSAL, FILCOM FISMIC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-04-30'},sortcode = '486',stipula = {d '2015-04-21'},title = 'TURISMO e PUBBLICIESERCIZI (aziendeconpiu''di14 dip.)' WHERE idccnl = '486'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('486','S','COMMERCIO (214) ','CNAI, UCICT, FISMIC CONFSAL, FILCOM FISMIC',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-04-30'},'486',{d '2015-04-21'},'TURISMO e PUBBLICIESERCIZI (aziendeconpiu''di14 dip.)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '487')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UAI, CONFAE, UNIAP, CONFENAL, FSE COBAS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '487',stipula = {d '2016-04-07'},title = 'TURISMO E PUBBLICI ESERCIZI (EBIPIC)' WHERE idccnl = '487'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('487','S','COMMERCIO (214) ','UAI, CONFAE, UNIAP, CONFENAL, FSE COBAS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'487',{d '2016-04-07'},'TURISMO E PUBBLICI ESERCIZI (EBIPIC)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '488')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-30'},sortcode = '488',stipula = {d '2017-04-05'},title = 'TURISMO E PUBBLICI ESERCIZI (FAPI-CESAC-FILDICIU)' WHERE idccnl = '488'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('488','S','COMMERCIO (214) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-30'},'488',{d '2017-04-05'},'TURISMO E PUBBLICI ESERCIZI (FAPI-CESAC-FILDICIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '489')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERDAT, ASSOTERZIARIO, ASSOALIMENTA, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-09-30'},sortcode = '489',stipula = {d '2015-09-16'},title = 'TURISMO E PUBBLICI ESERCIZI (FEDERDAT-CONSIL)' WHERE idccnl = '489'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('489','S','COMMERCIO (214) ','FEDERDAT, ASSOTERZIARIO, ASSOALIMENTA, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-09-30'},'489',{d '2015-09-16'},'TURISMO E PUBBLICI ESERCIZI (FEDERDAT-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '490')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FIDAP IMPRESE, FISAL ITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2021-12-31'},sortcode = '490',stipula = {d '2017-11-10'},title = 'TURISMO E PUBBLICI ESERCIZI (FIDAPIMPRESE-FISAL ITALIA)' WHERE idccnl = '490'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('490','S','COMMERCIO (214) ','FIDAP IMPRESE, FISAL ITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2021-12-31'},'490',{d '2017-11-10'},'TURISMO E PUBBLICI ESERCIZI (FIDAPIMPRESE-FISAL ITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '491')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'NORD INDUSTRIALE, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '491',stipula = {d '2015-02-26'},title = 'TURISMO E PUBBLICI ESERCIZI (NORDINDUSTRIALE-FAMAR)' WHERE idccnl = '491'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('491','S','COMMERCIO (214) ','NORD INDUSTRIALE, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'491',{d '2015-02-26'},'TURISMO E PUBBLICI ESERCIZI (NORDINDUSTRIALE-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '492')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNSIC, UNSICOOP, ANAP, CONFIMPRESEITALIA, SELP, SNALVCONFSAL, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-01-31'},sortcode = '492',stipula = {d '2016-01-27'},title = 'TURISMO E PUBBLICI ESERCIZI: imprese,anchecooperative, operanti nel settore' WHERE idccnl = '492'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('492','S','COMMERCIO (214) ','UNSIC, UNSICOOP, ANAP, CONFIMPRESEITALIA, SELP, SNALVCONFSAL, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-01-31'},'492',{d '2016-01-27'},'TURISMO E PUBBLICI ESERCIZI: imprese,anchecooperative, operanti nel settore')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '493')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CAPIMED, FENAILP, CUB, FENALCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '493',stipula = {d '2011-11-09'},title = 'TURISMO E SERVIZI TURISTICI' WHERE idccnl = '493'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('493','S','COMMERCIO (214) ','CAPIMED, FENAILP, CUB, FENALCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'493',{d '2011-11-09'},'TURISMO E SERVIZI TURISTICI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '494')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANPIT, AIAV, CIDEC, UNICA, CONFIMPRENDITORI, PMIITALIA, UAI TCS, CISAL TERZIARIO, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '494',stipula = {d '2017-05-23'},title = 'TURISMO, AGENZIE DI VIAGGIO E PUBBLICI ESERCIZI' WHERE idccnl = '494'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('494','S','COMMERCIO (214) ','ANPIT, AIAV, CIDEC, UNICA, CONFIMPRENDITORI, PMIITALIA, UAI TCS, CISAL TERZIARIO, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'494',{d '2017-05-23'},'TURISMO, AGENZIE DI VIAGGIO E PUBBLICI ESERCIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '495')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'PMI ITALIA, SELP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '495',stipula = {d '2017-12-01'},title = 'TURISMO, PUBBLICI ESERCIZI, AGENZIE DI VIAGGI, SALE BINGO' WHERE idccnl = '495'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('495','S','COMMERCIO (214) ','PMI ITALIA, SELP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'495',{d '2017-12-01'},'TURISMO, PUBBLICI ESERCIZI, AGENZIE DI VIAGGI, SALE BINGO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '496')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNSIC, UNSICOOP, ASNALI, FNACONFSAL, SNALVCONFSAL, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-05-31'},sortcode = '496',stipula = {d '2016-05-12'},title = 'TURISMO: ATTIVITA'' AUSILIARIE E COMPLEMENTARI AI PRINCIPALI SETTORI MERCEOLOGICI (cooperative)' WHERE idccnl = '496'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('496','S','COMMERCIO (214) ','UNSIC, UNSICOOP, ASNALI, FNACONFSAL, SNALVCONFSAL, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-05-31'},'496',{d '2016-05-12'},'TURISMO: ATTIVITA'' AUSILIARIE E COMPLEMENTARI AI PRINCIPALI SETTORI MERCEOLOGICI (cooperative)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '497')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMEA, FEDERTERZIARIO, CONFITER,IMPRESAITALIA, CFC, UGL Terziario, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '497',stipula = {d '2017-04-27'},title = 'TURISMO: Attivit? Stagionale' WHERE idccnl = '497'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('497','S','COMMERCIO (214) ','CONFIMEA, FEDERTERZIARIO, CONFITER,IMPRESAITALIA, CFC, UGL Terziario, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'497',{d '2017-04-27'},'TURISMO: Attivit? Stagionale')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '498')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'IMPRESAITALIA, CEPAA, CEPAATURISMO, ESAARCO,LUCI, CONFSAL, CONFLAVORATORI, SI CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-04-30'},sortcode = '498',stipula = {d '2013-05-08'},title = 'TURISMO: Cooperative e Consorzi (Attivit? Stagionale)' WHERE idccnl = '498'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('498','S','COMMERCIO (214) ','IMPRESAITALIA, CEPAA, CEPAATURISMO, ESAARCO,LUCI, CONFSAL, CONFLAVORATORI, SI CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-04-30'},'498',{d '2013-05-08'},'TURISMO: Cooperative e Consorzi (Attivit? Stagionale)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '499')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDARCOM, CIFA, FIADEL SP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-06-25'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-06-24'},sortcode = '499',stipula = {d '2010-06-25'},title = 'TURISMO: lavoratori dipendenti aziende del settore' WHERE idccnl = '499'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('499','S','COMMERCIO (214) ','FEDARCOM, CIFA, FIADEL SP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-06-25'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-06-24'},'499',{d '2010-06-25'},'TURISMO: lavoratori dipendenti aziende del settore')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '500')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CEPAA, CEPAATURISMO, ESAARCO, CIU, FISNALCTAUGL,ONAPS, SI CEL, FLT',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-10-29'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-10-28'},sortcode = '500',stipula = {d '2015-10-29'},title = 'TURISMO: micro piccole medie imprese del settore-CEPA A - CIU' WHERE idccnl = '500'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('500','S','COMMERCIO (214) ','CEPAA, CEPAATURISMO, ESAARCO, CIU, FISNALCTAUGL,ONAPS, SI CEL, FLT',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-10-29'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-10-28'},'500',{d '2015-10-29'},'TURISMO: micro piccole medie imprese del settore-CEPA A - CIU')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '501')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ITALIA TURISMO CIDEC, CIDEC, USAE ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-09-30'},sortcode = '501',stipula = {d '2010-09-22'},title = 'TURISMO: micro piccole medie imprese del settore-CIDEC-USAE' WHERE idccnl = '501'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('501','S','COMMERCIO (214) ','ITALIA TURISMO CIDEC, CIDEC, USAE ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-09-30'},'501',{d '2010-09-22'},'TURISMO: micro piccole medie imprese del settore-CIDEC-USAE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '502')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESETURISMO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSEFNILASU, CSE COOP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-05-31'},sortcode = '502',stipula = {d '2011-06-28'},title = 'TURISMO: micro piccole medie imprese del settore-CONFIMPRESEITALIA-ACS-CSE' WHERE idccnl = '502'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('502','S','COMMERCIO (214) ','CONFIMPRESEITALIA, CONFIMPRESETURISMO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSEFNILASU, CSE COOP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-05-31'},'502',{d '2011-06-28'},'TURISMO: micro piccole medie imprese del settore-CONFIMPRESEITALIA-ACS-CSE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '503')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'CONFIMPRESEITALIA, FESICA CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-11-30'},sortcode = '503',stipula = {d '2017-11-16'},title = 'TURISMO: micro piccole medie imprese del settore-CONFIMPRESEITALIA-CONFSAL' WHERE idccnl = '503'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('503','S','COMMERCIO (214) ','CONFIMPRESEITALIA, FESICA CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-11-30'},'503',{d '2017-11-16'},'TURISMO: micro piccole medie imprese del settore-CONFIMPRESEITALIA-CONFSAL')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '504')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'UNIMPRESA, UNIMPRESACommercioeTurismo, CONFINTESA, CONFINTESA Turismo Commercio e Servizi',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-07-31'},sortcode = '504',stipula = {d '2017-07-26'},title = 'TURISTICOALBERGHIERO (UNIMPRESA-CONFINTESA)' WHERE idccnl = '504'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('504','S','COMMERCIO (214) ','UNIMPRESA, UNIMPRESACommercioeTurismo, CONFINTESA, CONFINTESA Turismo Commercio e Servizi',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-07-31'},'504',{d '2017-07-26'},'TURISTICOALBERGHIERO (UNIMPRESA-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '505')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'FEDERIMPRESEITALIA, ALPAI, SALPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '505',stipula = {d '2016-09-30'},title = 'TURISTICOEALBERGHIERO (FEDERIMPRESEITALIA-ALPAI-SALPS)' WHERE idccnl = '505'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('505','S','COMMERCIO (214) ','FEDERIMPRESEITALIA, ALPAI, SALPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'505',{d '2016-09-30'},'TURISTICOEALBERGHIERO (FEDERIMPRESEITALIA-ALPAI-SALPS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '506')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSIV,LEGACOOPSERVIZI, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCISERVIZI, FILCAMSCGIL, FISASCATCISL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '506',stipula = {d '2013-04-08'},title = 'VIGILANZA' WHERE idccnl = '506'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('506','S','COMMERCIO (214) ','ASSIV,LEGACOOPSERVIZI, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCISERVIZI, FILCAMSCGIL, FISASCATCISL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'506',{d '2013-04-08'},'VIGILANZA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '507')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ASSIV,LEGACOOPSERVIZI, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCI SERVIZI, UGL SICUREZZA CIVILE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '507',stipula = {d '2013-04-08'},title = 'VIGILANZA' WHERE idccnl = '507'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('507','S','COMMERCIO (214) ','ASSIV,LEGACOOPSERVIZI, FEDERLAVOROESERVIZICONFCOOPERATIVE, AGCI SERVIZI, UGL SICUREZZA CIVILE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'507',{d '2013-04-08'},'VIGILANZA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '508')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'G7 International srl, UGL Sicurezza Civile',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-12-31'},sortcode = '508',stipula = {d '2018-03-16'},title = 'VIGILANZA ARMATA A BORDO DI NAVI MERCANTILI BATTENTI BANDIERA ITALIANA' WHERE idccnl = '508'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('508','S','COMMERCIO (214) ','G7 International srl, UGL Sicurezza Civile',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-12-31'},'508',{d '2018-03-16'},'VIGILANZA ARMATA A BORDO DI NAVI MERCANTILI BATTENTI BANDIERA ITALIANA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '509')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'NORD INDUSTRIALE, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '509',stipula = {d '2015-02-26'},title = 'VIGILANZA NON ARMATA E SICUREZZA' WHERE idccnl = '509'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('509','S','COMMERCIO (214) ','NORD INDUSTRIALE, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'509',{d '2015-02-26'},'VIGILANZA NON ARMATA E SICUREZZA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '510')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANSL, SINAL, CIDAT',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '510',stipula = {d '2016-12-19'},title = 'VIGILANZA PRIVATA E SERVIZI DI PORTIERATO' WHERE idccnl = '510'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('510','S','COMMERCIO (214) ','ANSL, SINAL, CIDAT',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'510',{d '2016-12-19'},'VIGILANZA PRIVATA E SERVIZI DI PORTIERATO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '511')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANIVP, ASSVIGILANZA, UNIV, FILCAMS CGIL, FISASCAT CISL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '511',stipula = {d '2014-02-28'},title = 'VIGILANZA PRIVATA E SERVIZI FIDUCIARI (ANIVP-ASSVIGILANZA-UNIV)' WHERE idccnl = '511'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('511','S','COMMERCIO (214) ','ANIVP, ASSVIGILANZA, UNIV, FILCAMS CGIL, FISASCAT CISL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'511',{d '2014-02-28'},'VIGILANZA PRIVATA E SERVIZI FIDUCIARI (ANIVP-ASSVIGILANZA-UNIV)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '512')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ESAARCO, CEPAA, ESAARCOVigilanzaeSicurezza, CEPAAFedercoop, SAI, FER, CIU, SI CEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-20'},sortcode = '512',stipula = {d '2016-11-21'},title = 'VIGILANZA PRIVATA E SERVIZI FIDUCIARI (ESAARCO)' WHERE idccnl = '512'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('512','S','COMMERCIO (214) ','ESAARCO, CEPAA, ESAARCOVigilanzaeSicurezza, CEPAAFedercoop, SAI, FER, CIU, SI CEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-20'},'512',{d '2016-11-21'},'VIGILANZA PRIVATA E SERVIZI FIDUCIARI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '513')
UPDATE [ccnl] SET active = 'S',area = 'COMMERCIO (214) ',contraenti = 'ANPIT, CIDEC, CONFAZIENDA, UNICA, UNIQUALITY, CISALSINALV, CISALTERZIARIO, CISAL,(sottoscrittoil20/4/2017daPMIITALIA), (sottoscritto da UAI il 5/6/2017)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-10-31'},sortcode = '513',stipula = {d '2015-10-15'},title = 'VIGILANZA PRIVATA, INVESTIGAZIONI E SERVIZI FIDUCIARI' WHERE idccnl = '513'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('513','S','COMMERCIO (214) ','ANPIT, CIDEC, CONFAZIENDA, UNICA, UNIQUALITY, CISALSINALV, CISALTERZIARIO, CISAL,(sottoscrittoil20/4/2017daPMIITALIA), (sottoscritto da UAI il 5/6/2017)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-10-31'},'513',{d '2015-10-15'},'VIGILANZA PRIVATA, INVESTIGAZIONI E SERVIZI FIDUCIARI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '514')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ENAVSPA, FILTCGIL, FITCISL, UILT, UGLTRASPORTI, USAEAV, ASSIVOLOQUADRI, ANPCATATMPP,LICTAATMPP, CILAAVATM PP, COBAS LAVORO PRIVATO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '514',stipula = {d '2012-03-23'},title = 'AEREI: Assistenza al Volo (Dipendenti AA.VV)' WHERE idccnl = '514'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('514','S','TRASPORTI (65) ','ENAVSPA, FILTCGIL, FITCISL, UILT, UGLTRASPORTI, USAEAV, ASSIVOLOQUADRI, ANPCATATMPP,LICTAATMPP, CILAAVATM PP, COBAS LAVORO PRIVATO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'514',{d '2012-03-23'},'AEREI: Assistenza al Volo (Dipendenti AA.VV)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '515')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ENAV SpA, ASDE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-12-31'},scadenza = {d '2007-12-31'},sortcode = '515',stipula = {d '2004-11-20'},title = 'AEREI: Assistenza al Volo (Dirigenti AA.VV)' WHERE idccnl = '515'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('515','S','TRASPORTI (65) ','ENAV SpA, ASDE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-31'},{d '2007-12-31'},'515',{d '2004-11-20'},'AEREI: Assistenza al Volo (Dirigenti AA.VV)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '516')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FAIRO, FILT CGIL, FIT CISL, UILTRASPORTI, UGL TRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '516',stipula = {d '2011-07-14'},title = 'AEREI: Compagnie Aeree Straniere (FAIRO)' WHERE idccnl = '516'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('516','S','TRASPORTI (65) ','FAIRO, FILT CGIL, FIT CISL, UILTRASPORTI, UGL TRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'516',{d '2011-07-14'},'AEREI: Compagnie Aeree Straniere (FAIRO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '517')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSAEROPORTI, FILTCGIL, FITCISL, UILTRASPORTI, UGLTrasporto Aereo',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '517',stipula = {d '2014-10-01'},title = 'AEREI: Trasporto Aereo' WHERE idccnl = '517'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('517','S','TRASPORTI (65) ','ASSAEROPORTI, FILTCGIL, FITCISL, UILTRASPORTI, UGLTrasporto Aereo',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'517',{d '2014-10-01'},'AEREI: Trasporto Aereo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '518')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSAEREO, FILTCGIL, FITCISL, UILTRASPORTI, UGLTRASPORTO AEREO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '518',stipula = {d '2014-07-17'},title = 'AEREI: Trasporto Aereo' WHERE idccnl = '518'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('518','S','TRASPORTI (65) ','ASSAEREO, FILTCGIL, FITCISL, UILTRASPORTI, UGLTRASPORTO AEREO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'518',{d '2014-07-17'},'AEREI: Trasporto Aereo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '519')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSOCONTROL, FILTCGIL, FITCISL, UILTRASPORTI, UGLTrasporti',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '519',stipula = {d '2014-05-27'},title = 'AEREI: Trasporto Aereo' WHERE idccnl = '519'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('519','S','TRASPORTI (65) ','ASSOCONTROL, FILTCGIL, FITCISL, UILTRASPORTI, UGLTrasporti',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'519',{d '2014-05-27'},'AEREI: Trasporto Aereo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '520')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSAEREO, ASSAEROPORTI, ASSOHANDLERS, ASSOCONTROL, ASSOCATERING, FILTCGIL, FITCISL, UILTRASPORTI, UGLTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = null,sortcode = '520',stipula = {d '2013-08-02'},title = 'AEREI: Trasporto Aereo' WHERE idccnl = '520'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('520','S','TRASPORTI (65) ','ASSAEREO, ASSAEROPORTI, ASSOHANDLERS, ASSOCONTROL, ASSOCATERING, FILTCGIL, FITCISL, UILTRASPORTI, UGLTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,'520',{d '2013-08-02'},'AEREI: Trasporto Aereo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '521')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDERAGENTI, FILT CGIL, FIT CISL, UILTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2008-03-31'},sortcode = '521',stipula = {d '2004-04-22'},title = 'AGENZIE MARITTIME E AEREE E MEDIATORI MARITTIMI' WHERE idccnl = '521'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('521','S','TRASPORTI (65) ','FEDERAGENTI, FILT CGIL, FIT CISL, UILTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2008-03-31'},'521',{d '2004-04-22'},'AGENZIE MARITTIME E AEREE E MEDIATORI MARITTIMI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '522')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDERAGENTI, MANAGERITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '522',stipula = {d '2017-02-13'},title = 'AGENZIE MARITTIME E AEREE E MEDIATORI MARITTIMI: Dirigenti' WHERE idccnl = '522'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('522','S','TRASPORTI (65) ','FEDERAGENTI, MANAGERITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'522',{d '2017-02-13'},'AGENZIE MARITTIME E AEREE E MEDIATORI MARITTIMI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '523')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASNAF & AS, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '523',stipula = {d '2011-11-30'},title = 'ATTIVITA'' FUNEBRI E CIMITERIALI' WHERE idccnl = '523'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('523','S','TRASPORTI (65) ','ASNAF & AS, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'523',{d '2011-11-30'},'ATTIVITA'' FUNEBRI E CIMITERIALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '524')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSTRA, ANAV, FILTCGIL, FITCISL, UILTRASPORTIUIL, FAISACISAL, UGL FNA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '524',stipula = {d '2015-11-28'},title = 'AUTOFERROTRANVIERI' WHERE idccnl = '524'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('524','S','TRASPORTI (65) ','ASSTRA, ANAV, FILTCGIL, FITCISL, UILTRASPORTIUIL, FAISACISAL, UGL FNA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'524',{d '2015-11-28'},'AUTOFERROTRANVIERI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '525')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSTRA, FEDERMANAGER',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-04-27'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '525',stipula = {d '2010-04-27'},title = 'AUTOFERROTRANVIERI: Dirigenti' WHERE idccnl = '525'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('525','S','TRASPORTI (65) ','ASSTRA, FEDERMANAGER',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-04-27'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'525',{d '2010-04-27'},'AUTOFERROTRANVIERI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '526')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNCI, FAST CONFSAL, FAST NOLEGGIO CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '526',stipula = {d '2007-03-14'},title = 'AUTONOLEGGIO' WHERE idccnl = '526'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('526','S','TRASPORTI (65) ','UNCI, FAST CONFSAL, FAST NOLEGGIO CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'526',{d '2007-03-14'},'AUTONOLEGGIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '527')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ANIASA, FILT CGIL, FIT CISL, UILTRASPORTI UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '527',stipula = {d '2016-07-26'},title = 'AUTORIMESSE' WHERE idccnl = '527'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('527','S','TRASPORTI (65) ','ANIASA, FILT CGIL, FIT CISL, UILTRASPORTI UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'527',{d '2016-07-26'},'AUTORIMESSE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '528')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNASCA, CONFCOMMERCIO, FILTCGIL, FITCISL, UILTRASPORTI UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '528',stipula = {d '2016-12-13'},title = 'AUTOSCUOLE E SCUOLE DI NAUTICA' WHERE idccnl = '528'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('528','S','TRASPORTI (65) ','UNASCA, CONFCOMMERCIO, FILTCGIL, FITCISL, UILTRASPORTI UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'528',{d '2016-12-13'},'AUTOSCUOLE E SCUOLE DI NAUTICA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '529')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ESAARCO, CEPAA, ESAARCOAutotrasporti, SAI, FER, CIU, SICEL, FENALS CGEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-29'},sortcode = '529',stipula = {d '2016-11-30'},title = 'AUTOSCUOLE E STUDI DI CONSULENZA AUTOMOBILISTICA (ESAARCO)' WHERE idccnl = '529'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('529','S','TRASPORTI (65) ','ESAARCO, CEPAA, ESAARCOAutotrasporti, SAI, FER, CIU, SICEL, FENALS CGEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-29'},'529',{d '2016-11-30'},'AUTOSCUOLE E STUDI DI CONSULENZA AUTOMOBILISTICA (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '530')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDERRETI, FISEACAP, FILTCGIL, FITCISL, UILTRASPORTI, SLA CISAL, UGL TRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '530',stipula = {d '2013-08-01'},title = 'AUTOSTRADE E TRAFORI (Societa'' e Consorzi Concessionari)' WHERE idccnl = '530'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('530','S','TRASPORTI (65) ','FEDERRETI, FISEACAP, FILTCGIL, FITCISL, UILTRASPORTI, SLA CISAL, UGL TRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'530',{d '2013-08-01'},'AUTOSTRADE E TRAFORI (Societa'' e Consorzi Concessionari)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '531')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'LEGA IMPRESA, FILAP, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-06-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-06-20'},sortcode = '531',stipula = {d '2016-06-22'},title = 'AUTOTRASPORTI MERCI, LOGISTICA, SPEDIZIONIE AFFINI (LEGA IMPRESA-FILAP-CIU)' WHERE idccnl = '531'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('531','S','TRASPORTI (65) ','LEGA IMPRESA, FILAP, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-06-20'},'531',{d '2016-06-22'},'AUTOTRASPORTI MERCI, LOGISTICA, SPEDIZIONIE AFFINI (LEGA IMPRESA-FILAP-CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '532')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'CONFETRA, MANAGERITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '532',stipula = {d '2016-11-10'},title = 'AUTOTRASPORTI: Dirigenti' WHERE idccnl = '532'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('532','S','TRASPORTI (65) ','CONFETRA, MANAGERITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'532',{d '2016-11-10'},'AUTOTRASPORTI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '533')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ACIS, FAMAR, CONFAMAR,(sottoscrizionedellaUNIONLIBERIindata 13/4/2016)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '533',stipula = {d '2016-03-23'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (ACIS-FAMAR)' WHERE idccnl = '533'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('533','S','TRASPORTI (65) ','ACIS, FAMAR, CONFAMAR,(sottoscrizionedellaUNIONLIBERIindata 13/4/2016)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'533',{d '2016-03-23'},'AUTOTRASPORTO E SPEDIZIONE MERCI (ACIS-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '534')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-31'},sortcode = '534',stipula = {d '2016-04-07'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (ADLI-FAMAR)' WHERE idccnl = '534'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('534','S','TRASPORTI (65) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-31'},'534',{d '2016-04-07'},'AUTOTRASPORTO E SPEDIZIONE MERCI (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '535')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'TRANSFIGOROUTE ITALIA ASSOTIR, FAST CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '535',stipula = {d '2014-01-23'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (ASSOTIR-FAST CONFSAL)' WHERE idccnl = '535'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('535','S','TRASPORTI (65) ','TRANSFIGOROUTE ITALIA ASSOTIR, FAST CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'535',{d '2014-01-23'},'AUTOTRASPORTO E SPEDIZIONE MERCI (ASSOTIR-FAST CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '536')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDERIMPRENDITORI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '536',stipula = {d '2016-03-23'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (CISAL)' WHERE idccnl = '536'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('536','S','TRASPORTI (65) ','FEDERIMPRENDITORI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'536',{d '2016-03-23'},'AUTOTRASPORTO E SPEDIZIONE MERCI (CISAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '537')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESETRASPORTI, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU, CSE FNILEL, CSE FNILT ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '537',stipula = {d '2011-12-22'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '537'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('537','S','TRASPORTI (65) ','CONFIMPRESEITALIA, CONFIMPRESETRASPORTI, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU, CSE FNILEL, CSE FNILT ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'537',{d '2011-12-22'},'AUTOTRASPORTO E SPEDIZIONE MERCI (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '538')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'CONFIMPRESEITALIA, FASTAUTOTRASPORTO E SPEDIZIONE MERCI, FASTCAMIONISTIEAUTISTIDIPENDENTI, FASTCONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '538',stipula = {d '2011-11-28'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (CONFIMPRESEITALIA-CONFSAL)' WHERE idccnl = '538'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('538','S','TRASPORTI (65) ','CONFIMPRESEITALIA, FASTAUTOTRASPORTO E SPEDIZIONE MERCI, FASTCAMIONISTIEAUTISTIDIPENDENTI, FASTCONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'538',{d '2011-11-28'},'AUTOTRASPORTO E SPEDIZIONE MERCI (CONFIMPRESEITALIA-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '539')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDIMPRESE, FAMAR NAZIONALE, SNAPEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '539',stipula = {d '2014-12-10'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (FEDIMPRESE-FAMAR NAZIONALE-SNAPEL)' WHERE idccnl = '539'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('539','S','TRASPORTI (65) ','FEDIMPRESE, FAMAR NAZIONALE, SNAPEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'539',{d '2014-12-10'},'AUTOTRASPORTO E SPEDIZIONE MERCI (FEDIMPRESE-FAMAR NAZIONALE-SNAPEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '540')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNCI, FAST, FAST CAMIONISTI AUTISTI DIPENDENTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-03-31'},sortcode = '540',stipula = {d '2014-04-01'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (UNCI-CONFSAL)' WHERE idccnl = '540'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('540','S','TRASPORTI (65) ','UNCI, FAST, FAST CAMIONISTI AUTISTI DIPENDENTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-03-31'},'540',{d '2014-04-01'},'AUTOTRASPORTO E SPEDIZIONE MERCI (UNCI-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '541')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNSIC, FASTAUTOTRASPORTO E SPEDIZIONE MERCI, FASTCAMIONISTI E AUTISTI DIPENDENTI, FAST CONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '541',stipula = {d '2011-11-28'},title = 'AUTOTRASPORTO E SPEDIZIONE MERCI (UNSIC-CONFSAL)' WHERE idccnl = '541'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('541','S','TRASPORTI (65) ','UNSIC, FASTAUTOTRASPORTO E SPEDIZIONE MERCI, FASTCAMIONISTI E AUTISTI DIPENDENTI, FAST CONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'541',{d '2011-11-28'},'AUTOTRASPORTO E SPEDIZIONE MERCI (UNSIC-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '542')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'MIDA, SNIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '542',stipula = {d '2015-12-23'},title = 'AUTOTRASPORTO MERCI E LOGISTICA (MIDA-SNIAL)' WHERE idccnl = '542'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('542','S','TRASPORTI (65) ','MIDA, SNIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'542',{d '2015-12-23'},'AUTOTRASPORTO MERCI E LOGISTICA (MIDA-SNIAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '543')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSOTRASPORTI, UGL VIABILITA'' E LOGISTICA, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-27'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-01-26'},sortcode = '543',stipula = {d '2014-01-27'},title = 'AUTOTRASPORTO MERCI, LOGISTICA E SPEDIZIONI (ASSOTRASPORTI-UGL)' WHERE idccnl = '543'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('543','S','TRASPORTI (65) ','ASSOTRASPORTI, UGL VIABILITA'' E LOGISTICA, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-27'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-01-26'},'543',{d '2014-01-27'},'AUTOTRASPORTO MERCI, LOGISTICA E SPEDIZIONI (ASSOTRASPORTI-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '544')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-07-06'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-07-05'},sortcode = '544',stipula = {d '2015-07-02'},title = 'AUTOTRASPORTO MERCI, LOGISTICA, SPEDIZIONIE AFFINI' WHERE idccnl = '544'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('544','S','TRASPORTI (65) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-07-06'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-07-05'},'544',{d '2015-07-02'},'AUTOTRASPORTO MERCI, LOGISTICA, SPEDIZIONIE AFFINI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '545')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNSIC, UNSICOOP, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-31'},sortcode = '545',stipula = {d '2017-04-21'},title = 'AUTOTRASPORTO, SPEDIZIONEEMOVIMENTAZIONE MERCI, LOGISTICA ED AFFINI' WHERE idccnl = '545'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('545','S','TRASPORTI (65) ','UNSIC, UNSICOOP, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-31'},'545',{d '2017-04-21'},'AUTOTRASPORTO, SPEDIZIONEEMOVIMENTAZIONE MERCI, LOGISTICA ED AFFINI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '546')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'COOPITALIANE,IMPRESAITALIA, CONFSAAP, AECP, UPLA,TRASPORTOUNITOFIAP, CEPAA, CEPAATERZIARIO, FASPICONFSAL, PMIA, ALDEPI, ALPPI, FENALPI, CONFLAVORATORICONFSAL, CONFAIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-05-31'},sortcode = '546',stipula = {d '2014-05-28'},title = 'AUTOTRASPORTO, SPEDIZIONE MERCI E LOGISTICA: cooperative, micro e piccole aziende' WHERE idccnl = '546'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('546','S','TRASPORTI (65) ','COOPITALIANE,IMPRESAITALIA, CONFSAAP, AECP, UPLA,TRASPORTOUNITOFIAP, CEPAA, CEPAATERZIARIO, FASPICONFSAL, PMIA, ALDEPI, ALPPI, FENALPI, CONFLAVORATORICONFSAL, CONFAIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-05-31'},'546',{d '2014-05-28'},'AUTOTRASPORTO, SPEDIZIONE MERCI E LOGISTICA: cooperative, micro e piccole aziende')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '547')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'LT CONAPI, CONFINTESA Viabilit? e Logistica',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-04'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-03'},sortcode = '547',stipula = {d '2016-03-04'},title = 'AUTOTRASPORTO, SPEDIZIONE MERCI, LOGISTICA E FACCHINAGGIO (CONAPI-CONFINTESA)' WHERE idccnl = '547'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('547','S','TRASPORTI (65) ','LT CONAPI, CONFINTESA Viabilit? e Logistica',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-04'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-03'},'547',{d '2016-03-04'},'AUTOTRASPORTO, SPEDIZIONE MERCI, LOGISTICA E FACCHINAGGIO (CONAPI-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '548')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNICOOP, UGL Viabilit? e Logistica, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-11'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-07-10'},sortcode = '548',stipula = {d '2017-07-11'},title = 'AUTOTRASPORTO, SPEDIZIONE MERCI, LOGISTICA E FACCHINAGGIO (UNICOOP-UGL)' WHERE idccnl = '548'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('548','S','TRASPORTI (65) ','UNICOOP, UGL Viabilit? e Logistica, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-11'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-07-10'},'548',{d '2017-07-11'},'AUTOTRASPORTO, SPEDIZIONE MERCI, LOGISTICA E FACCHINAGGIO (UNICOOP-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '549')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleTrasporti, CONFINTESA, CONFINTESA Viabilit? e Logistica',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-31'},sortcode = '549',stipula = {d '2017-04-19'},title = 'AUTOTRASPORTO, SPEDIZIONE MERCI, LOGISTICA E FACCHINAGGIO (UNIMPRESA-CONFINTESA)' WHERE idccnl = '549'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('549','S','TRASPORTI (65) ','UNIMPRESA, UNIMPRESAFederazione NazionaleTrasporti, CONFINTESA, CONFINTESA Viabilit? e Logistica',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-31'},'549',{d '2017-04-19'},'AUTOTRASPORTO, SPEDIZIONE MERCI, LOGISTICA E FACCHINAGGIO (UNIMPRESA-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '550')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNSIC, UNSICOOP, PMIA, UGL Viabilit? e Logistica',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-30'},sortcode = '550',stipula = {d '2015-11-23'},title = 'AUTOTRASPORTO, SPEDIZIONE MERCI, LOGISTICA ED AFFINI (UNSIC-UNSICOOP-PMIA-UGL)' WHERE idccnl = '550'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('550','S','TRASPORTI (65) ','UNSIC, UNSICOOP, PMIA, UGL Viabilit? e Logistica',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-30'},'550',{d '2015-11-23'},'AUTOTRASPORTO, SPEDIZIONE MERCI, LOGISTICA ED AFFINI (UNSIC-UNSICOOP-PMIA-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '551')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FISE, ANIM, FILT CGIL, FIT CISL, UILTRASPORTI UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2005-08-31'},sortcode = '551',stipula = {d '2004-02-03'},title = 'CARICO E SCARICO (per Ministero Difesa)' WHERE idccnl = '551'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('551','S','TRASPORTI (65) ','FISE, ANIM, FILT CGIL, FIT CISL, UILTRASPORTI UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2005-08-31'},'551',{d '2004-02-03'},'CARICO E SCARICO (per Ministero Difesa)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '552')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'CONSORZIOCOPAM, CISALTERZIARIO, CISAL,(AdesionediCONFARTIGIANATO IMPRESE ROMA dal 10/2/2016)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-09-30'},sortcode = '552',stipula = {d '2014-09-09'},title = 'CONSORZIO COPAM' WHERE idccnl = '552'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('552','S','TRASPORTI (65) ','CONSORZIOCOPAM, CISALTERZIARIO, CISAL,(AdesionediCONFARTIGIANATO IMPRESE ROMA dal 10/2/2016)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-09-30'},'552',{d '2014-09-09'},'CONSORZIO COPAM')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '553')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-07-31'},sortcode = '553',stipula = {d '2017-06-06'},title = 'DISTRIBUZIONE MERCI, LOGISTICAESERVIZIPRIVATI' WHERE idccnl = '553'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('553','S','TRASPORTI (65) ','CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-07-31'},'553',{d '2017-06-06'},'DISTRIBUZIONE MERCI, LOGISTICAESERVIZIPRIVATI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '554')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FISE, AISE, ANPAC, UP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2004-12-31'},scadenza = {d '2001-01-01'},sortcode = '554',stipula = {d '2001-07-19'},title = 'ELICOTTERI:Trasporto non di linea, manutenzione e riparaz.' WHERE idccnl = '554'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('554','S','TRASPORTI (65) ','FISE, AISE, ANPAC, UP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-12-31'},{d '2001-01-01'},'554',{d '2001-07-19'},'ELICOTTERI:Trasporto non di linea, manutenzione e riparaz.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '555')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'AGENS, FEDERTRASPORTO, ANCP, FILTCGIL, FITCISL, UILTRASPORTI, UGL TRASPORTI, FAST FERROVIE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-12-31'},scadenza = {d '2012-01-01'},sortcode = '555',stipula = {d '2012-07-20'},title = 'FERROVIE: Attivita'' ferroviarie' WHERE idccnl = '555'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('555','S','TRASPORTI (65) ','AGENS, FEDERTRASPORTO, ANCP, FILTCGIL, FITCISL, UILTRASPORTI, UGL TRASPORTI, FAST FERROVIE',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-12-31'},{d '2012-01-01'},'555',{d '2012-07-20'},'FERROVIE: Attivita'' ferroviarie')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '556')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ANEF, FILT CGIL, FIT CISL, UILTRASPORTI UIL, SAVT',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-04-30'},scadenza = {d '2016-05-01'},sortcode = '556',stipula = {d '2016-05-12'},title = 'FUNIVIE TERRESTRI ED AEREE' WHERE idccnl = '556'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('556','S','TRASPORTI (65) ','ANEF, FILT CGIL, FIT CISL, UILTRASPORTI UIL, SAVT',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-04-30'},{d '2016-05-01'},'556',{d '2016-05-12'},'FUNIVIE TERRESTRI ED AEREE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '557')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDERDAT, CIU, CONFIAL, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-03-19'},scadenza = {d '2017-03-20'},sortcode = '557',stipula = {d '2017-03-15'},title = 'LOGISTICA, TRASPORTI MERCI E SPEDIZIONI (FEDERDAT)' WHERE idccnl = '557'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('557','S','TRASPORTI (65) ','FEDERDAT, CIU, CONFIAL, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-03-19'},{d '2017-03-20'},'557',{d '2017-03-15'},'LOGISTICA, TRASPORTI MERCI E SPEDIZIONI (FEDERDAT)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '558')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'AITE, AITI, ASSOESPRESSI, ASSOLOGISTICA, FEDESPEDI, FEDIT, FISI,TRASPORTOUNITOFIAP, CONFETRA, ANITA, FAI, ASSOTIR, FEDERTRASLOCHI, FEDERLOGISTICA, FIAP, UNITAI, CONFTRASPORTO, CNAFITA, CONFARTIGIANATOTRASPORTI, SNACASARTIGIANI, CLAAI, FILTCGIL, FITCISL, UILTRASPORTIUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '558',stipula = {d '2017-12-03'},title = 'LOGISTICA, TRASPORTO MERCI E SPEDIZIONE' WHERE idccnl = '558'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('558','S','TRASPORTI (65) ','AITE, AITI, ASSOESPRESSI, ASSOLOGISTICA, FEDESPEDI, FEDIT, FISI,TRASPORTOUNITOFIAP, CONFETRA, ANITA, FAI, ASSOTIR, FEDERTRASLOCHI, FEDERLOGISTICA, FIAP, UNITAI, CONFTRASPORTO, CNAFITA, CONFARTIGIANATOTRASPORTI, SNACASARTIGIANI, CLAAI, FILTCGIL, FITCISL, UILTRASPORTIUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'558',{d '2017-12-03'},'LOGISTICA, TRASPORTO MERCI E SPEDIZIONE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '559')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSOLOGISTICA, MANAGERITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2015-01-01'},sortcode = '559',stipula = {d '2016-12-23'},title = 'MAGAZZINI GENERALI: Dirigenti' WHERE idccnl = '559'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('559','S','TRASPORTI (65) ','ASSOLOGISTICA, MANAGERITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2015-01-01'},'559',{d '2016-12-23'},'MAGAZZINI GENERALI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '560')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'CONFITARMA, MEDIBORDO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-12-31'},scadenza = {d '2016-01-01'},sortcode = '560',stipula = {d '2016-01-27'},title = 'MARITTIMI: Medici di Bordo' WHERE idccnl = '560'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('560','S','TRASPORTI (65) ','CONFITARMA, MEDIBORDO',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-12-31'},{d '2016-01-01'},'560',{d '2016-01-27'},'MARITTIMI: Medici di Bordo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '561')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ANGOPI,LEGACOOPServizi, FILTCGIL, FITCISL, UILTRASPORTIUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-06-30'},scadenza = {d '2013-07-01'},sortcode = '561',stipula = {d '2013-06-20'},title = 'MARITTIMI: Ormeggiatori e Barcaioli (cooperative)' WHERE idccnl = '561'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('561','S','TRASPORTI (65) ','ANGOPI,LEGACOOPServizi, FILTCGIL, FITCISL, UILTRASPORTIUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-30'},{d '2013-07-01'},'561',{d '2013-06-20'},'MARITTIMI: Ormeggiatori e Barcaioli (cooperative)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '562')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDARLINEA, FILT CGIL, FIT CISL, UILTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-12-31'},scadenza = {d '2015-07-01'},sortcode = '562',stipula = {d '2015-07-01'},title = 'MARITTIMI: settore del Cabotaggio Marittimo' WHERE idccnl = '562'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('562','S','TRASPORTI (65) ','FEDARLINEA, FILT CGIL, FIT CISL, UILTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-12-31'},{d '2015-07-01'},'562',{d '2015-07-01'},'MARITTIMI: settore del Cabotaggio Marittimo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '563')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'CONFITARMA, ASSORIMORCHIATORI, FEDERIMORCHIATORI, FEDARLINEA, FILTCGIL, FITCISL, UILTRASPORTI, USCLAC, UNCDIM',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-12-31'},scadenza = {d '2015-07-01'},sortcode = '563',stipula = {d '2015-07-01'},title = 'MARITTIMI: settore Marittimo' WHERE idccnl = '563'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('563','S','TRASPORTI (65) ','CONFITARMA, ASSORIMORCHIATORI, FEDERIMORCHIATORI, FEDARLINEA, FILTCGIL, FITCISL, UILTRASPORTI, USCLAC, UNCDIM',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-12-31'},{d '2015-07-01'},'563',{d '2015-07-01'},'MARITTIMI: settore Marittimo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '564')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'AIAD, ANPICO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-12-31'},scadenza = {d '2008-01-01'},sortcode = '564',stipula = {d '2007-11-29'},title = 'PILOTI Collaudatori Dip.da Az.di Costruzioni Aerospaziali' WHERE idccnl = '564'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('564','S','TRASPORTI (65) ','AIAD, ANPICO',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-31'},{d '2008-01-01'},'564',{d '2007-11-29'},'PILOTI Collaudatori Dip.da Az.di Costruzioni Aerospaziali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '565')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FENIOF, CONFCOMMERCIO, FILT CGIL, FIT CISL, UILTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-12-31'},scadenza = {d '2017-01-01'},sortcode = '565',stipula = {d '2017-05-05'},title = 'POMPE FUNEBRI: Agenzie Private' WHERE idccnl = '565'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('565','S','TRASPORTI (65) ','FENIOF, CONFCOMMERCIO, FILT CGIL, FIT CISL, UILTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-12-31'},{d '2017-01-01'},'565',{d '2017-05-05'},'POMPE FUNEBRI: Agenzie Private')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '566')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDERUTILITY, CGILFunzionePubblica, FITCISL, UILTRASPORTIUIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2005-01-01'},sortcode = '566',stipula = {d '2007-11-14'},title = 'POMPE FUNEBRI: Agenzie Pubbliche' WHERE idccnl = '566'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('566','S','TRASPORTI (65) ','FEDERUTILITY, CGILFunzionePubblica, FITCISL, UILTRASPORTIUIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2005-01-01'},'566',{d '2007-11-14'},'POMPE FUNEBRI: Agenzie Pubbliche')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '567')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ASSITERMINAL, ASSOLOGISTICA, ASSOPORTI, FISEUNIPORT, FILT CGIL, FIT CISL, UILTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-12-31'},scadenza = {d '2013-01-01'},sortcode = '567',stipula = {d '2014-01-14'},title = 'PORTUALI: Lavoratori dei Porti' WHERE idccnl = '567'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('567','S','TRASPORTI (65) ','ASSITERMINAL, ASSOLOGISTICA, ASSOPORTI, FISEUNIPORT, FILT CGIL, FIT CISL, UILTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-31'},{d '2013-01-01'},'567',{d '2014-01-14'},'PORTUALI: Lavoratori dei Porti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '568')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ALEAITALIA, ADEITALIA, ALEAITALIATRASPORTI, ADEITALIATRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-08-31'},scadenza = {d '2009-09-02'},sortcode = '568',stipula = {d '2009-09-02'},title = 'PORTUALI:Lavoratori dei Porti Cooperative settore trasporti' WHERE idccnl = '568'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('568','S','TRASPORTI (65) ','ALEAITALIA, ADEITALIA, ALEAITALIATRASPORTI, ADEITALIATRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-08-31'},{d '2009-09-02'},'568',{d '2009-09-02'},'PORTUALI:Lavoratori dei Porti Cooperative settore trasporti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '569')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'UNCI, URI, FAST, FAST CONFSAL, URI TAXI, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-05-31'},scadenza = {d '2013-06-01'},sortcode = '569',stipula = {d '2013-11-20'},title = 'RADIOTAXI' WHERE idccnl = '569'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('569','S','TRASPORTI (65) ','UNCI, URI, FAST, FAST CONFSAL, URI TAXI, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-05-31'},{d '2013-06-01'},'569',{d '2013-11-20'},'RADIOTAXI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '570')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ENTEREGISTRONAVALEITALIANO, RINASPA, RINASERVICESSPA, RINACHECKSRL, RINAVALUESRL, SOARINASPA, FILTCGIL, FIT CISL, UIL TRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2015-01-01'},sortcode = '570',stipula = {d '2014-11-04'},title = 'RINA (Ente Registro Italiano Navale)' WHERE idccnl = '570'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('570','S','TRASPORTI (65) ','ENTEREGISTRONAVALEITALIANO, RINASPA, RINASERVICESSPA, RINACHECKSRL, RINAVALUESRL, SOARINASPA, FILTCGIL, FIT CISL, UIL TRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2015-01-01'},'570',{d '2014-11-04'},'RINA (Ente Registro Italiano Navale)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '571')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FederazioneServiziSoccorsoStradaleCONFIMEA, ANCSA, CONFIMEA, FEDERTERZIARIO, CFC, UGL Terziario, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-04-30'},scadenza = {d '2017-05-01'},sortcode = '571',stipula = {d '2017-05-04'},title = 'SOCCORSO STRADALE E ATTIVITA'' DISERVIZI CONNESSI (Micro, Piccole e Medie Imprese)' WHERE idccnl = '571'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('571','S','TRASPORTI (65) ','FederazioneServiziSoccorsoStradaleCONFIMEA, ANCSA, CONFIMEA, FEDERTERZIARIO, CFC, UGL Terziario, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-04-30'},{d '2017-05-01'},'571',{d '2017-05-04'},'SOCCORSO STRADALE E ATTIVITA'' DISERVIZI CONNESSI (Micro, Piccole e Medie Imprese)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '572')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ESAARCO, CEPAA, ESAARCOAutotrasporti, SAI, FER, CIU, SICEL, FENALS CGEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-29'},sortcode = '572',stipula = {d '2016-11-30'},title = 'SPEDIZIONE, AUTOTRASPORTO MERCI E LOGISTICA (ESAARCO)' WHERE idccnl = '572'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('572','S','TRASPORTI (65) ','ESAARCO, CEPAA, ESAARCOAutotrasporti, SAI, FER, CIU, SICEL, FENALS CGEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-29'},'572',{d '2016-11-30'},'SPEDIZIONE, AUTOTRASPORTO MERCI E LOGISTICA (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '573')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FEDERLAVOROESERVIZICONFCOOPERATIVE,LEGACOOPSERVIZI, AGCISERVIZI, UNICATAXIFILTCGIL, FITCISL, UILTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-02-28'},sortcode = '573',stipula = {d '2016-11-29'},title = 'TAXI' WHERE idccnl = '573'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('573','S','TRASPORTI (65) ','FEDERLAVOROESERVIZICONFCOOPERATIVE,LEGACOOPSERVIZI, AGCISERVIZI, UNICATAXIFILTCGIL, FITCISL, UILTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-02-28'},'573',{d '2016-11-29'},'TAXI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '574')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVASGSL, FITRAITALIA, UNIONFORMATORI, ASSOBEAUTYMANAGER, SITLAV',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '574',stipula = {d '2014-12-22'},title = 'TRASPORTO E LOGISTICA' WHERE idccnl = '574'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('574','S','TRASPORTI (65) ','ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVASGSL, FITRAITALIA, UNIONFORMATORI, ASSOBEAUTYMANAGER, SITLAV',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'574',{d '2014-12-22'},'TRASPORTO E LOGISTICA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '575')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '575',stipula = {d '2014-07-15'},title = 'TRASPORTO SPEDIZIONI E LOGISTICA: Cooperative' WHERE idccnl = '575'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('575','S','TRASPORTI (65) ','SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'575',{d '2014-07-15'},'TRASPORTO SPEDIZIONI E LOGISTICA: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '576')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ESAARCO, CEPAA, ESAARCOAutotrasporti, SAI, ALIM, CONFIMPRESA, UNIPMI, PMIITALIAINTERNATIONAL, CIU, SICEL, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '576',stipula = {d '2014-11-01'},title = 'TRASPORTO VIAGGIATORI, TRASPORTO INNOVATIVO E CENTRALI RADIO TAXI (ESAARCO)' WHERE idccnl = '576'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('576','S','TRASPORTI (65) ','ESAARCO, CEPAA, ESAARCOAutotrasporti, SAI, ALIM, CONFIMPRESA, UNIPMI, PMIITALIAINTERNATIONAL, CIU, SICEL, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'576',{d '2014-11-01'},'TRASPORTO VIAGGIATORI, TRASPORTO INNOVATIVO E CENTRALI RADIO TAXI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '577')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'FOR ITALY, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-12-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '577',stipula = {d '2016-12-30'},title = 'TRASPORTO, SPEDIZIONI, LOGISTICA E ATTIVITA'' AFFINI (FOR ITALY - FAMAR)' WHERE idccnl = '577'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('577','S','TRASPORTI (65) ','FOR ITALY, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'577',{d '2016-12-30'},'TRASPORTO, SPEDIZIONI, LOGISTICA E ATTIVITA'' AFFINI (FOR ITALY - FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '578')
UPDATE [ccnl] SET active = 'S',area = 'TRASPORTI (65) ',contraenti = 'ANGAF, FILT CGIL, FIT CISL, UILTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2011-12-31'},sortcode = '578',stipula = {d '2009-07-28'},title = 'VIGILANZA ANTINCENDIO (Societa''/Cooperative)' WHERE idccnl = '578'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('578','S','TRASPORTI (65) ','ANGAF, FILT CGIL, FIT CISL, UILTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2011-12-31'},'578',{d '2009-07-28'},'VIGILANZA ANTINCENDIO (Societa''/Cooperative)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '579')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'UFI, MANAGERITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2005-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2008-12-31'},sortcode = '579',stipula = {d '2004-10-21'},title = 'AGENTI IN ATTIVITA'' FINANZIARIE' WHERE idccnl = '579'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('579','S','CREDITO E ASSICURAZIONI (31) ','UFI, MANAGERITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2008-12-31'},'579',{d '2004-10-21'},'AGENTI IN ATTIVITA'' FINANZIARIE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '580')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'FENAFI, UFIC, CONFIMPRESEITALIA, CIDEC, CEPIUCI, FENAILP, ASSIMEC, ASSOPROFESSIONAL, SIMEDIA UGL, ASSOCRED',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-02-28'},sortcode = '580',stipula = {d '2011-02-17'},title = 'AGENTI IN SERVIZI FINANZIARI' WHERE idccnl = '580'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('580','S','CREDITO E ASSICURAZIONI (31) ','FENAFI, UFIC, CONFIMPRESEITALIA, CIDEC, CEPIUCI, FENAILP, ASSIMEC, ASSOPROFESSIONAL, SIMEDIA UGL, ASSOCRED',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-02-28'},'580',{d '2011-02-17'},'AGENTI IN SERVIZI FINANZIARI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '581')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ANIA, SNA, UNAPASS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2003-12-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2006-12-31'},sortcode = '581',stipula = {d '2003-12-23'},title = 'ASSICURAZIONI: Agenti iscritti all''Albo' WHERE idccnl = '581'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('581','S','CREDITO E ASSICURAZIONI (31) ','ANIA, SNA, UNAPASS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2003-12-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2006-12-31'},'581',{d '2003-12-23'},'ASSICURAZIONI: Agenti iscritti all''Albo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '582')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ANAPACONFCOMMERCIO, FIRSTCISL, FISACCGIL, UILCAUIL, FNA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '582',stipula = {d '2017-12-18'},title = 'ASSICURAZIONI: Agenzie in gestione libera (ANAPA)' WHERE idccnl = '582'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('582','S','CREDITO E ASSICURAZIONI (31) ','ANAPACONFCOMMERCIO, FIRSTCISL, FISACCGIL, UILCAUIL, FNA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'582',{d '2017-12-18'},'ASSICURAZIONI: Agenzie in gestione libera (ANAPA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '583')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'CSA, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '1999-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2000-12-31'},scadenza = {d '2002-12-31'},sortcode = '583',stipula = {d '2000-02-11'},title = 'ASSICURAZIONI: Agenzie in gestione libera (CSA)' WHERE idccnl = '583'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('583','S','CREDITO E ASSICURAZIONI (31) ','CSA, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '1999-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2000-12-31'},{d '2002-12-31'},'583',{d '2000-02-11'},'ASSICURAZIONI: Agenzie in gestione libera (CSA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '584')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'SNA, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2023-04-01'},sortcode = '584',stipula = {d '2018-02-05'},title = 'ASSICURAZIONI: Agenzie ingestione libera (SNA-CPMI-CONFSAL)' WHERE idccnl = '584'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('584','S','CREDITO E ASSICURAZIONI (31) ','SNA, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2023-04-01'},'584',{d '2018-02-05'},'ASSICURAZIONI: Agenzie ingestione libera (SNA-CPMI-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '585')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ANAGINA, FIBA CISL, FISAC CGIL, FNA, UILCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-16'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '585',stipula = {d '2014-07-16'},title = 'ASSICURAZIONI: Agenzie INAVITA-ASSITALIA (Dipendenti)' WHERE idccnl = '585'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('585','S','CREDITO E ASSICURAZIONI (31) ','ANAGINA, FIBA CISL, FISAC CGIL, FNA, UILCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-16'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'585',{d '2014-07-16'},'ASSICURAZIONI: Agenzie INAVITA-ASSITALIA (Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '586')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ASSOCIAZIONEAGENZIESOCIETARIEUNIPOL,LEGACOOP, FIBA CISL, FISAC CGIL, UILCA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '586',stipula = {d '2012-12-07'},title = 'ASSICURAZIONI: Agenzie Societarie UNIPOL-LEGACOOP' WHERE idccnl = '586'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('586','S','CREDITO E ASSICURAZIONI (31) ','ASSOCIAZIONEAGENZIESOCIETARIEUNIPOL,LEGACOOP, FIBA CISL, FISAC CGIL, UILCA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'586',{d '2012-12-07'},'ASSICURAZIONI: Agenzie Societarie UNIPOL-LEGACOOP')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '587')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'AISA, FISAC CGIL, FIBA CISL, UILCA UIL, FNA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-09-30'},sortcode = '587',stipula = {d '2012-12-03'},title = 'ASSICURAZIONI: Dipendenti (AISA-AISSA)' WHERE idccnl = '587'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('587','S','CREDITO E ASSICURAZIONI (31) ','AISA, FISAC CGIL, FIBA CISL, UILCA UIL, FNA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-09-30'},'587',{d '2012-12-03'},'ASSICURAZIONI: Dipendenti (AISA-AISSA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '588')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ANIA, FIRST CISL, FISAC CGIL, FNA, SNFIA, UILCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-02-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '588',stipula = {d '2017-02-22'},title = 'ASSICURAZIONI: Dipendenti (ANIA)' WHERE idccnl = '588'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('588','S','CREDITO E ASSICURAZIONI (31) ','ANIA, FIRST CISL, FISAC CGIL, FNA, SNFIA, UILCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-02-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'588',{d '2017-02-22'},'ASSICURAZIONI: Dipendenti (ANIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '589')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ANIA, FIDIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-06-30'},sortcode = '589',stipula = {d '2013-06-07'},title = 'ASSICURAZIONI: Dirigenti' WHERE idccnl = '589'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('589','S','CREDITO E ASSICURAZIONI (31) ','ANIA, FIDIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-06-30'},'589',{d '2013-06-07'},'ASSICURAZIONI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '590')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ABI, FABI, FIRSTCISL, FISACCGIL, SINFUB, UGLCREDITO, UILCA UIL, UNISIN',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-07-13'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '590',stipula = {d '2015-07-13'},title = 'BANCARI: ABI (Dirigenti)' WHERE idccnl = '590'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('590','S','CREDITO E ASSICURAZIONI (31) ','ABI, FABI, FIRSTCISL, FISACCGIL, SINFUB, UGLCREDITO, UILCA UIL, UNISIN',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-07-13'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'590',{d '2015-07-13'},'BANCARI: ABI (Dirigenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '591')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ABI,DIRCREDITOFD, FABI, FIBACISL, FISACCGIL, SINFUB, UGLCREDITO, UILCA UIL, UNISIN FALCRI SILCEA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '591',stipula = {d '2015-03-31'},title = 'BANCARI: ABI (Quadri direttivi e aree professionali)' WHERE idccnl = '591'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('591','S','CREDITO E ASSICURAZIONI (31) ','ABI,DIRCREDITOFD, FABI, FIBACISL, FISACCGIL, SINFUB, UGLCREDITO, UILCA UIL, UNISIN FALCRI SILCEA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'591',{d '2015-03-31'},'BANCARI: ABI (Quadri direttivi e aree professionali)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '592')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'BANCA D''ITALIA, UILCA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '592',stipula = {d '2010-07-13'},title = 'BANCARI: Banca D''Italia - carriera Direttiva' WHERE idccnl = '592'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('592','S','CREDITO E ASSICURAZIONI (31) ','BANCA D''ITALIA, UILCA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'592',{d '2010-07-13'},'BANCARI: Banca D''Italia - carriera Direttiva')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '593')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'BANCA D''ITALIA, SIBC CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '593',stipula = {d '2010-07-13'},title = 'BANCARI: Banca D''Italia - carriera Direttiva' WHERE idccnl = '593'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('593','S','CREDITO E ASSICURAZIONI (31) ','BANCA D''ITALIA, SIBC CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'593',{d '2010-07-13'},'BANCARI: Banca D''Italia - carriera Direttiva')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '594')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'BANCA D''ITALIA, FALBI, FIBA CISL, FABI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '594',stipula = {d '2010-07-13'},title = 'BANCARI: Banca D''Italia - carriera Direttiva' WHERE idccnl = '594'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('594','S','CREDITO E ASSICURAZIONI (31) ','BANCA D''ITALIA, FALBI, FIBA CISL, FABI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'594',{d '2010-07-13'},'BANCARI: Banca D''Italia - carriera Direttiva')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '595')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'BANCA D''ITALIA, SINDIRETTIVO CIDA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '595',stipula = {d '2010-07-13'},title = 'BANCARI: Banca D''Italia - carriera Direttiva' WHERE idccnl = '595'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('595','S','CREDITO E ASSICURAZIONI (31) ','BANCA D''ITALIA, SINDIRETTIVO CIDA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'595',{d '2010-07-13'},'BANCARI: Banca D''Italia - carriera Direttiva')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '596')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'BANCA D''ITALIA, UILCA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '596',stipula = {d '2010-07-13'},title = 'BANCARI: Banca D''Italia - carriera Operativa' WHERE idccnl = '596'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('596','S','CREDITO E ASSICURAZIONI (31) ','BANCA D''ITALIA, UILCA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'596',{d '2010-07-13'},'BANCARI: Banca D''Italia - carriera Operativa')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '597')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'BANCA D''ITALIA, SIBC CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '597',stipula = {d '2010-07-13'},title = 'BANCARI: Banca D''Italia - carriera Operativa' WHERE idccnl = '597'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('597','S','CREDITO E ASSICURAZIONI (31) ','BANCA D''ITALIA, SIBC CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'597',{d '2010-07-13'},'BANCARI: Banca D''Italia - carriera Operativa')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '598')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'BANCA D''ITALIA, FALBI, FABI, FIBA CISL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '598',stipula = {d '2010-07-13'},title = 'BANCARI: Banca D''Italia - carriera Operativa' WHERE idccnl = '598'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('598','S','CREDITO E ASSICURAZIONI (31) ','BANCA D''ITALIA, FALBI, FABI, FIBA CISL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'598',{d '2010-07-13'},'BANCARI: Banca D''Italia - carriera Operativa')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '599')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'AGCI, AGCI SETTORE CREDITO E FINANZA, SINADI, SILCCO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '599',stipula = {d '2012-10-31'},title = 'BANCARI: CasseRurali-CreditoCooperativo (Cooperative)' WHERE idccnl = '599'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('599','S','CREDITO E ASSICURAZIONI (31) ','AGCI, AGCI SETTORE CREDITO E FINANZA, SINADI, SILCCO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'599',{d '2012-10-31'},'BANCARI: CasseRurali-CreditoCooperativo (Cooperative)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '600')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'AGCI, AGCI SETTORE CREDITO E FINANZA, SINADI, SILCCO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '600',stipula = {d '2012-10-31'},title = 'BANCARI: CasseRurali-CreditoCooperativo: Dirigenti (Cooperative)' WHERE idccnl = '600'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('600','S','CREDITO E ASSICURAZIONI (31) ','AGCI, AGCI SETTORE CREDITO E FINANZA, SINADI, SILCCO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'600',{d '2012-10-31'},'BANCARI: CasseRurali-CreditoCooperativo: Dirigenti (Cooperative)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '601')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'FEDERCASSE,DIRCREDITO, FABI, FIBACISL, FISACCGIL, SINCRA UGL CREDITO, UILCA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-12-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '601',stipula = {d '2012-12-21'},title = 'BANCARI: CasseRuralieArtigiane-CreditoCooperativo' WHERE idccnl = '601'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('601','S','CREDITO E ASSICURAZIONI (31) ','FEDERCASSE,DIRCREDITO, FABI, FIBACISL, FISACCGIL, SINCRA UGL CREDITO, UILCA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-12-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'601',{d '2012-12-21'},'BANCARI: CasseRuralieArtigiane-CreditoCooperativo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '602')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'FEDERCASSE,DIRCREDITOFD, FABI, FIBACISL, FISACCGIL, SINCRA UGL CREDITO, UILCA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-12-31'},sortcode = '602',stipula = {d '2008-07-24'},title = 'BANCARI: CasseRuralieArtigiane-CreditoCooperativo - Dirigenti' WHERE idccnl = '602'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('602','S','CREDITO E ASSICURAZIONI (31) ','FEDERCASSE,DIRCREDITOFD, FABI, FIBACISL, FISACCGIL, SINCRA UGL CREDITO, UILCA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-12-31'},'602',{d '2008-07-24'},'BANCARI: CasseRuralieArtigiane-CreditoCooperativo - Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '603')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'COMPIECONFEDERAZIONEPICCOLEEMEDIEIMPRESEEUROPEE, ASSOCIAZIONEBICBROKERITALIANI, ULEUNIONELAVORATORI EUROPEI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-12-14'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-14'},sortcode = '603',stipula = {d '2011-12-14'},title = 'Broker Assicurativi e Brokercoach' WHERE idccnl = '603'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('603','S','CREDITO E ASSICURAZIONI (31) ','COMPIECONFEDERAZIONEPICCOLEEMEDIEIMPRESEEUROPEE, ASSOCIAZIONEBICBROKERITALIANI, ULEUNIONELAVORATORI EUROPEI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-14'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-14'},'603',{d '2011-12-14'},'Broker Assicurativi e Brokercoach')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '604')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'EQUITALIASPA, RISCOSSIONESICILIASPA,DIRCREDITOFD, FABI, FALCRI, FIBACISL, FISACCGIL, SILCEA, SNALEC, UGL, UILCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-04-09'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-12-31'},sortcode = '604',stipula = {d '2008-04-09'},title = 'Concessionari Servizi Tributi' WHERE idccnl = '604'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('604','S','CREDITO E ASSICURAZIONI (31) ','EQUITALIASPA, RISCOSSIONESICILIASPA,DIRCREDITOFD, FABI, FALCRI, FIBACISL, FISACCGIL, SILCEA, SNALEC, UGL, UILCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-04-09'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-12-31'},'604',{d '2008-04-09'},'Concessionari Servizi Tributi')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '605')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'EQUITALIASPA, RISCOSSIONESICILIASPA,DIRCREDITOFD, FABI, FIBA CISL, FISAC CGIL, UGL, UILCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-12-31'},sortcode = '605',stipula = {d '2008-12-19'},title = 'Concessionari Servizi Tributi: Dirigenti' WHERE idccnl = '605'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('605','S','CREDITO E ASSICURAZIONI (31) ','EQUITALIASPA, RISCOSSIONESICILIASPA,DIRCREDITOFD, FABI, FIBA CISL, FISAC CGIL, UGL, UILCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-12-31'},'605',{d '2008-12-19'},'Concessionari Servizi Tributi: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '606')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ULIAS, FESICA CONFSAL, CONFSAL FISALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-06-30'},sortcode = '606',stipula = {d '2016-07-06'},title = 'Intermediari Assicurativi' WHERE idccnl = '606'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('606','S','CREDITO E ASSICURAZIONI (31) ','ULIAS, FESICA CONFSAL, CONFSAL FISALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-06-30'},'606',{d '2016-07-06'},'Intermediari Assicurativi')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '607')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'FENAFI, UFIC, CONFIMPRESEITALIA, CIDEC, CEPIUCI, FENAILP, ASSIMEC, ASSOPROFESSIONAL, SIMEDIA UGL, ASSOCRED',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-02-28'},sortcode = '607',stipula = {d '2011-02-17'},title = 'MEDIATORI DEI CREDITI' WHERE idccnl = '607'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('607','S','CREDITO E ASSICURAZIONI (31) ','FENAFI, UFIC, CONFIMPRESEITALIA, CIDEC, CEPIUCI, FENAILP, ASSIMEC, ASSOPROFESSIONAL, SIMEDIA UGL, ASSOCRED',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-02-28'},'607',{d '2011-02-17'},'MEDIATORI DEI CREDITI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '608')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'ASCI, FIBA CISL, FISAC CGIL, UILCA UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2005-12-31'},scadenza = {d '2007-12-31'},sortcode = '608',stipula = {d '2005-02-14'},title = 'SOCIETA'' D''INTERMEDIAZIONE MOBILIARE' WHERE idccnl = '608'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('608','S','CREDITO E ASSICURAZIONI (31) ','ASCI, FIBA CISL, FISAC CGIL, UILCA UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-12-31'},{d '2007-12-31'},'608',{d '2005-02-14'},'SOCIETA'' D''INTERMEDIAZIONE MOBILIARE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '609')
UPDATE [ccnl] SET active = 'S',area = 'CREDITO E ASSICURAZIONI (31) ',contraenti = 'FENAFI, ASSIMEC, FEDERPROMMUILTUCS, UILTUCSUIL, FIDICC SINADI ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-10'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-06-28'},sortcode = '609',stipula = {d '2017-04-10'},title = 'SOCIETA'' FINANZIARIE E SERVIZI: Dipendenti' WHERE idccnl = '609'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('609','S','CREDITO E ASSICURAZIONI (31) ','FENAFI, ASSIMEC, FEDERPROMMUILTUCS, UILTUCSUIL, FIDICC SINADI ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-10'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-06-28'},'609',{d '2017-04-10'},'SOCIETA'' FINANZIARIE E SERVIZI: Dipendenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '610')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FEDERTERME, FISASCAT CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '610',stipula = {d '2018-01-24'},title = 'AZIENDE TERMALI' WHERE idccnl = '610'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('610','S','AZIENDE DI SERVIZI (45) ','FEDERTERME, FISASCAT CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'610',{d '2018-01-24'},'AZIENDE TERMALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '611')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CONISERVIZISPA, FPCGIL, CISLFP, USB, UGLFNOS, FIALPCISAL, UIL PA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '611',stipula = {d '2016-12-14'},title = 'CONI SERVIZI SpA' WHERE idccnl = '611'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('611','S','AZIENDE DI SERVIZI (45) ','CONISERVIZISPA, FPCGIL, CISLFP, USB, UGLFNOS, FIALPCISAL, UIL PA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'611',{d '2016-12-14'},'CONI SERVIZI SpA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '612')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CONI SERVIZI SPA, FP CGIL, UIL PA, CISL FP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '612',stipula = {d '2011-02-25'},title = 'CONI SERVIZI SpA: Dirigenti' WHERE idccnl = '612'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('612','S','AZIENDE DI SERVIZI (45) ','CONI SERVIZI SPA, FP CGIL, UIL PA, CISL FP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'612',{d '2011-02-25'},'CONI SERVIZI SpA: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '613')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ASSOELETTRICA, UTILITALIA, ENELSPA,GSESPA, SOGINSPA,TERNASPA, ENERGIACONCORRENTE, FILCTEMCGIL, FLAEICISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '613',stipula = {d '2017-01-25'},title = 'ELETTRICI' WHERE idccnl = '613'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('613','S','AZIENDE DI SERVIZI (45) ','ASSOELETTRICA, UTILITALIA, ENELSPA,GSESPA, SOGINSPA,TERNASPA, ENERGIACONCORRENTE, FILCTEMCGIL, FLAEICISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'613',{d '2017-01-25'},'ELETTRICI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '614')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ASSOELETTRICA, FEDERUTILITY, ENELSPA,GSE, SOGIN,TERNA, UGL FEDERAZIONE CHIMICI SINDACATO ENERGIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '614',stipula = {d '2013-02-19'},title = 'ELETTRICI' WHERE idccnl = '614'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('614','S','AZIENDE DI SERVIZI (45) ','ASSOELETTRICA, FEDERUTILITY, ENELSPA,GSE, SOGIN,TERNA, UGL FEDERAZIONE CHIMICI SINDACATO ENERGIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'614',{d '2013-02-19'},'ELETTRICI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '615')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ENERGIA CONCORRENTE, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '615',stipula = {d '2013-05-30'},title = 'ENERGIA CONCORRENTE' WHERE idccnl = '615'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('615','S','AZIENDE DI SERVIZI (45) ','ENERGIA CONCORRENTE, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'615',{d '2013-05-30'},'ENERGIA CONCORRENTE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '616')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FEDERIMPRENDITORI, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '616',stipula = {d '2015-12-17'},title = 'FACILITY MANAGEMENT' WHERE idccnl = '616'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('616','S','AZIENDE DI SERVIZI (45) ','FEDERIMPRENDITORI, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'616',{d '2015-12-17'},'FACILITY MANAGEMENT')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '617')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ACIS, UNIONLIBERI, FEDERLIBERI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-13'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '617',stipula = {d '2016-04-13'},title = 'FACILITY MANAGEMENT (ACIS-UNIONLIBERI-FAMAR)' WHERE idccnl = '617'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('617','S','AZIENDE DI SERVIZI (45) ','ACIS, UNIONLIBERI, FEDERLIBERI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-13'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'617',{d '2016-04-13'},'FACILITY MANAGEMENT (ACIS-UNIONLIBERI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '618')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-21'},sortcode = '618',stipula = {d '2016-03-22'},title = 'FACILITY MANAGEMENT (ADLI-FAMAR)' WHERE idccnl = '618'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('618','S','AZIENDE DI SERVIZI (45) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-21'},'618',{d '2016-03-22'},'FACILITY MANAGEMENT (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '619')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FEDIMPRESE, FAMAR NAZIONALE, SNAPEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '619',stipula = {d '2014-12-10'},title = 'FACILITY MANAGEMENT (FEDIMPRESE-FAMARNAZIONALE-SNAPEL)' WHERE idccnl = '619'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('619','S','AZIENDE DI SERVIZI (45) ','FEDIMPRESE, FAMAR NAZIONALE, SNAPEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'619',{d '2014-12-10'},'FACILITY MANAGEMENT (FEDIMPRESE-FAMARNAZIONALE-SNAPEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '620')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FEDIMPRESE, SNAPEL, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-09-01'},sortcode = '620',stipula = {d '2016-09-01'},title = 'FACILITY MANAGEMENT (FEDIMPRESE-SNAPEL-CIU)' WHERE idccnl = '620'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('620','S','AZIENDE DI SERVIZI (45) ','FEDIMPRESE, SNAPEL, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-09-01'},'620',{d '2016-09-01'},'FACILITY MANAGEMENT (FEDIMPRESE-SNAPEL-CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '621')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'UNICOOP, UGL TERZIARIO, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-07-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-07-14'},sortcode = '621',stipula = {d '2015-07-13'},title = 'FACILITY MANAGEMENT: Cooperative (UNICOOP-UGL)' WHERE idccnl = '621'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('621','S','AZIENDE DI SERVIZI (45) ','UNICOOP, UGL TERZIARIO, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-07-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-07-14'},'621',{d '2015-07-13'},'FACILITY MANAGEMENT: Cooperative (UNICOOP-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '622')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ANFIDA, ANIGAS, ASSOGAS, CONFINDUSTRIAENERGIA, FEDERESTRATTIVA, FEDERUTILITY, FILCTEMCGIL, FEMCACISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '622',stipula = {d '2014-01-14'},title = 'GAS e ACQUA' WHERE idccnl = '622'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('622','S','AZIENDE DI SERVIZI (45) ','ANFIDA, ANIGAS, ASSOGAS, CONFINDUSTRIAENERGIA, FEDERESTRATTIVA, FEDERUTILITY, FILCTEMCGIL, FEMCACISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'622',{d '2014-01-14'},'GAS e ACQUA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '623')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ANFIDA, ANIGAS, CONFINDUSTRIAENERGIA, ASSOGAS, FEDERESTRATTIVA, FEDERUTILITY, CISAL FEDERENERGIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '623',stipula = {d '2011-02-17'},title = 'GAS e ACQUA' WHERE idccnl = '623'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('623','S','AZIENDE DI SERVIZI (45) ','ANFIDA, ANIGAS, CONFINDUSTRIAENERGIA, ASSOGAS, FEDERESTRATTIVA, FEDERUTILITY, CISAL FEDERENERGIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'623',{d '2011-02-17'},'GAS e ACQUA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '624')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ANFIDA, ASSOGAS, ANIGAS, CONFINDUSTRIAENERGIA, FEDERESTRATTIVA, FEDERUTILITY, UGL CHIMICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '624',stipula = {d '2011-02-10'},title = 'GAS e ACQUA' WHERE idccnl = '624'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('624','S','AZIENDE DI SERVIZI (45) ','ANFIDA, ASSOGAS, ANIGAS, CONFINDUSTRIAENERGIA, FEDERESTRATTIVA, FEDERUTILITY, UGL CHIMICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'624',{d '2011-02-10'},'GAS e ACQUA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '625')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'COOPITALIANE, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '625',stipula = {d '2018-01-03'},title = 'MULTISERVIZI PULIZIA E LOGISTICA: Cooperative' WHERE idccnl = '625'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('625','S','AZIENDE DI SERVIZI (45) ','COOPITALIANE, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'625',{d '2018-01-03'},'MULTISERVIZI PULIZIA E LOGISTICA: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '626')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CONFARTIGIANATOImpresediPulizia, CNAServiziallacomunit?, CASARTIGIANI, CLAAI, FILCAMSCGIL, FISASCATCISL, UILTRASPORTI UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '626',stipula = {d '2014-09-18'},title = 'PULIZIA Disinfezione Disinfestazione (PMI Cooperative Artigiane)' WHERE idccnl = '626'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('626','S','AZIENDE DI SERVIZI (45) ','CONFARTIGIANATOImpresediPulizia, CNAServiziallacomunit?, CASARTIGIANI, CLAAI, FILCAMSCGIL, FISASCATCISL, UILTRASPORTI UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'626',{d '2014-09-18'},'PULIZIA Disinfezione Disinfestazione (PMI Cooperative Artigiane)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '627')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleCommercioeservizi, UNIMPRESAProfessioni, CONFINTESA, CONFINTESATUCS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-05-31'},sortcode = '627',stipula = {d '2017-05-17'},title = 'PULIZIA,GLOBALSERVICE, FACILITYMANAGEMENT' WHERE idccnl = '627'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('627','S','AZIENDE DI SERVIZI (45) ','UNIMPRESA, UNIMPRESAFederazione NazionaleCommercioeservizi, UNIMPRESAProfessioni, CONFINTESA, CONFINTESATUCS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-05-31'},'627',{d '2017-05-17'},'PULIZIA,GLOBALSERVICE, FACILITYMANAGEMENT')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '628')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CAPIMED, FENAPI, USAE, USPPI, CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-12-31'},scadenza = {d '2010-12-31'},sortcode = '628',stipula = {d '2008-04-08'},title = 'PULIZIA: Aziende artigiane di pulimento e multiservizi (CAPIMED-FENAPI-USAE-USPPI-CEL)' WHERE idccnl = '628'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('628','S','AZIENDE DI SERVIZI (45) ','CAPIMED, FENAPI, USAE, USPPI, CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-12-31'},{d '2010-12-31'},'628',{d '2008-04-08'},'PULIZIA: Aziende artigiane di pulimento e multiservizi (CAPIMED-FENAPI-USAE-USPPI-CEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '629')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CEPA, CONFIMPRESEITALIA, USAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-03-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-03-01'},sortcode = '629',stipula = {d '2011-01-28'},title = 'PULIZIA: Aziende artigiane di pulimento e multiservizi (CEPA-CONFIMPRESEITALIA-USAE)' WHERE idccnl = '629'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('629','S','AZIENDE DI SERVIZI (45) ','CEPA, CONFIMPRESEITALIA, USAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-03-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-03-01'},'629',{d '2011-01-28'},'PULIZIA: Aziende artigiane di pulimento e multiservizi (CEPA-CONFIMPRESEITALIA-USAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '630')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU, CSE FNILEL, CSE FNILT, CSE FNILA, CSE FNILM',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '630',stipula = {d '2011-12-22'},title = 'PULIZIA: Aziende artigiane di pulimento e multiservizi (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '630'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('630','S','AZIENDE DI SERVIZI (45) ','CONFIMPRESEITALIA, CONFIMPRESEARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSE FNILASU, CSE FNILEL, CSE FNILT, CSE FNILA, CSE FNILM',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'630',{d '2011-12-22'},'PULIZIA: Aziende artigiane di pulimento e multiservizi (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '631')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CONAPI, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-04'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-03'},sortcode = '631',stipula = {d '2016-03-04'},title = 'PULIZIA: Aziende di pulimento e multiservizi (CONAPI-CONFINTESA)' WHERE idccnl = '631'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('631','S','AZIENDE DI SERVIZI (45) ','CONAPI, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-04'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-03'},'631',{d '2016-03-04'},'PULIZIA: Aziende di pulimento e multiservizi (CONAPI-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '632')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CONFIMPRESA, CNL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-30'},sortcode = '632',stipula = {d '2015-11-30'},title = 'PULIZIA: Cooperative (CONFIMPRESA-CNL)' WHERE idccnl = '632'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('632','S','AZIENDE DI SERVIZI (45) ','CONFIMPRESA, CNL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-30'},'632',{d '2015-11-30'},'PULIZIA: Cooperative (CONFIMPRESA-CNL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '633')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEITALIAARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSEFNILASU, CSEFNILEL, CSEFNILT, CSEFNILA, CSEFNILM',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '633',stipula = {d '2011-12-22'},title = 'PULIZIA: Cooperative (CONFIMPRESEITALIA-ACS-CSE)' WHERE idccnl = '633'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('633','S','AZIENDE DI SERVIZI (45) ','CONFIMPRESEITALIA, CONFIMPRESEITALIAARTIGIANATO, ACS, CSE, CSEFULSCAM, CSEFNILAPMI, CSEFNLEI, CSEDIR, CSECOOP, CSEFNILASU, CSEFNILEL, CSEFNILT, CSEFNILA, CSEFNILM',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'633',{d '2011-12-22'},'PULIZIA: Cooperative (CONFIMPRESEITALIA-ACS-CSE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '634')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-14'},sortcode = '634',stipula = {d '2016-03-15'},title = 'PULIZIA: Cooperative (SISTEMACOOP-SCI-CONFSAL)' WHERE idccnl = '634'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('634','S','AZIENDE DI SERVIZI (45) ','SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-14'},'634',{d '2016-03-15'},'PULIZIA: Cooperative (SISTEMACOOP-SCI-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '635')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'COOPITALIANE,IMPRESAITALIA, CONFSAAP, AECP, UPLA, CEPAA, CEPAATERZIARIO, CEPAAAIMA, ALDEPI, ALPPI, FENALPI, CONFLAVORATORICONFSAL, CONFAIL, FASPICONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-05-31'},sortcode = '635',stipula = {d '2014-05-28'},title = 'PULIZIA: dipendenti PMI, soci e dipendenti Cooperative' WHERE idccnl = '635'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('635','S','AZIENDE DI SERVIZI (45) ','COOPITALIANE,IMPRESAITALIA, CONFSAAP, AECP, UPLA, CEPAA, CEPAATERZIARIO, CEPAAAIMA, ALDEPI, ALPPI, FENALPI, CONFLAVORATORICONFSAL, CONFAIL, FASPICONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-05-31'},'635',{d '2014-05-28'},'PULIZIA: dipendenti PMI, soci e dipendenti Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '636')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-11'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '636',stipula = {d '2017-06-06'},title = 'PULIZIA: IgieneAmbientale (CONFLAVOROPMI-CONFSAL)' WHERE idccnl = '636'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('636','S','AZIENDE DI SERVIZI (45) ','CONFLAVOROPMI, FESICACONFSAL, CONFSALFISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-11'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'636',{d '2017-06-06'},'PULIZIA: IgieneAmbientale (CONFLAVOROPMI-CONFSAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '637')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'UTILITALIA, FP CGIL, FIT CISL, UILTRASPORTI UIL, FIADEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-06-30'},sortcode = '637',stipula = {d '2016-07-10'},title = 'PULIZIA: Igiene Urbana MUNICIPALIZZATE' WHERE idccnl = '637'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('637','S','AZIENDE DI SERVIZI (45) ','UTILITALIA, FP CGIL, FIT CISL, UILTRASPORTI UIL, FIADEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-06-30'},'637',{d '2016-07-10'},'PULIZIA: Igiene Urbana MUNICIPALIZZATE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '638')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FEDERAMBIENTE, FEDERAZIONEITALIANAUGLIGIENEAMBIENTALE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '638',stipula = {d '2011-06-30'},title = 'PULIZIA: Igiene Urbana MUNICIPALIZZATE' WHERE idccnl = '638'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('638','S','AZIENDE DI SERVIZI (45) ','FEDERAMBIENTE, FEDERAZIONEITALIANAUGLIGIENEAMBIENTALE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'638',{d '2011-06-30'},'PULIZIA: Igiene Urbana MUNICIPALIZZATE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '639')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FISEASSOAMBIENTE, FISE, FPCGIL, FITCISL, UILTRASPORTI, FIADEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-06-30'},sortcode = '639',stipula = {d '2016-12-06'},title = 'PULIZIA: Igiene Urbana PRIVATE' WHERE idccnl = '639'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('639','S','AZIENDE DI SERVIZI (45) ','FISEASSOAMBIENTE, FISE, FPCGIL, FITCISL, UILTRASPORTI, FIADEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-06-30'},'639',{d '2016-12-06'},'PULIZIA: Igiene Urbana PRIVATE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '640')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FISECONFINDUSTRIA,LEGACOOPSERVIZI, FEDERLAVOROCONFCOOPERATIVE, PSLAGCI, UNIONSERVIZICONFAPI, FILCAMS CGIL, FISASCAT CISL, UILTRASPORTI UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-04-30'},sortcode = '640',stipula = {d '2011-05-31'},title = 'PULIZIA: Imprese' WHERE idccnl = '640'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('640','S','AZIENDE DI SERVIZI (45) ','FISECONFINDUSTRIA,LEGACOOPSERVIZI, FEDERLAVOROCONFCOOPERATIVE, PSLAGCI, UNIONSERVIZICONFAPI, FILCAMS CGIL, FISASCAT CISL, UILTRASPORTI UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-04-30'},'640',{d '2011-05-31'},'PULIZIA: Imprese')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '641')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FISE CONFINDUSTRIA, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2011-12-31'},sortcode = '641',stipula = {d '2007-12-21'},title = 'PULIZIA: Imprese' WHERE idccnl = '641'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('641','S','AZIENDE DI SERVIZI (45) ','FISE CONFINDUSTRIA, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2011-12-31'},'641',{d '2007-12-21'},'PULIZIA: Imprese')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '642')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FNIP CONFCOMMERCIO, UGL IGIENE AMBIENTALE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-04-30'},sortcode = '642',stipula = {d '2011-07-26'},title = 'PULIZIA: Imprese (Confcommercio)' WHERE idccnl = '642'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('642','S','AZIENDE DI SERVIZI (45) ','FNIP CONFCOMMERCIO, UGL IGIENE AMBIENTALE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-04-30'},'642',{d '2011-07-26'},'PULIZIA: Imprese (Confcommercio)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '643')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FNIPCONFCOMMERCIO, FILCAMSCGIL, FISASCATCISL, UILTRASPORTI UIL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-04-30'},sortcode = '643',stipula = {d '2011-07-21'},title = 'PULIZIA: Imprese (Confcommercio)' WHERE idccnl = '643'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('643','S','AZIENDE DI SERVIZI (45) ','FNIPCONFCOMMERCIO, FILCAMSCGIL, FISASCATCISL, UILTRASPORTI UIL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-04-30'},'643',{d '2011-07-21'},'PULIZIA: Imprese (Confcommercio)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '644')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ESAARCO, CEPAA, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CIU, SICEL,ONAPS, FENALCCGEL, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-21'},sortcode = '644',stipula = {d '2016-11-22'},title = 'PULIZIA: Imprese (ESAARCO)' WHERE idccnl = '644'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('644','S','AZIENDE DI SERVIZI (45) ','ESAARCO, CEPAA, CEPAAIndustria, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CIU, SICEL,ONAPS, FENALCCGEL, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-21'},'644',{d '2016-11-22'},'PULIZIA: Imprese (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '645')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'UNSIC, UNSICOOP, FEDERDAT, CONFIAL, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '645',stipula = {d '2017-12-19'},title = 'PULIZIA: Imprese (UNSIC-UNSICOOP-FEDERDAT-CONFIAL-CONSIL)' WHERE idccnl = '645'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('645','S','AZIENDE DI SERVIZI (45) ','UNSIC, UNSICOOP, FEDERDAT, CONFIAL, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'645',{d '2017-12-19'},'PULIZIA: Imprese (UNSIC-UNSICOOP-FEDERDAT-CONFIAL-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '646')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ESAARCO, CEPAA, ESAARCO Artigianato, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, CIU, SICEL, CGELFNLA,ONAPS, FENALC CGEL, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-21'},sortcode = '646',stipula = {d '2016-11-22'},title = 'PULIZIA: Imprese Artigiane (ESAARCO)' WHERE idccnl = '646'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('646','S','AZIENDE DI SERVIZI (45) ','ESAARCO, CEPAA, ESAARCO Artigianato, CEPAAFedercoop, SAI, FER, ASSOPONTEGGI, CILA, CIU, SICEL, CGELFNLA,ONAPS, FENALC CGEL, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-21'},'646',{d '2016-11-22'},'PULIZIA: Imprese Artigiane (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '647')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CNAI, UNAPI, FISMIC CONFSAL, FILCOM FISMIC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-07-31'},sortcode = '647',stipula = {d '2012-07-05'},title = 'PULIZIA: Imprese Artigiane e/o Piccole Imprese Industriali (CNAI-FISMIC)' WHERE idccnl = '647'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('647','S','AZIENDE DI SERVIZI (45) ','CNAI, UNAPI, FISMIC CONFSAL, FILCOM FISMIC',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-07-31'},'647',{d '2012-07-05'},'PULIZIA: Imprese Artigiane e/o Piccole Imprese Industriali (CNAI-FISMIC)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '648')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'CESID, USIPE, SEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '648',stipula = {d '2014-01-16'},title = 'PULIZIA: Imprese e Cooperative (CESID-USIPE-SEL)' WHERE idccnl = '648'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('648','S','AZIENDE DI SERVIZI (45) ','CESID, USIPE, SEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'648',{d '2014-01-16'},'PULIZIA: Imprese e Cooperative (CESID-USIPE-SEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '649')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ACIS, UNIONLIBERI, FEDERLIBERI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-13'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '649',stipula = {d '2016-04-13'},title = 'PULIZIA: Imprese, PMI, Artigiane, Cooperative (ACIS-UNIONLIBERI-FAMAR)' WHERE idccnl = '649'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('649','S','AZIENDE DI SERVIZI (45) ','ACIS, UNIONLIBERI, FEDERLIBERI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-13'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'649',{d '2016-04-13'},'PULIZIA: Imprese, PMI, Artigiane, Cooperative (ACIS-UNIONLIBERI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '650')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ADLI, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-03-21'},sortcode = '650',stipula = {d '2016-03-22'},title = 'PULIZIA: Imprese, PMI, Artigiane, Cooperative (ADLI-FAMAR)' WHERE idccnl = '650'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('650','S','AZIENDE DI SERVIZI (45) ','ADLI, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-03-21'},'650',{d '2016-03-22'},'PULIZIA: Imprese, PMI, Artigiane, Cooperative (ADLI-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '651')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FEDIMPRESE, FAMAR, SNAPEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '651',stipula = {d '2015-02-27'},title = 'PULIZIA: Imprese, PMI, Artigiane, Cooperative (FEDIMPRESE-FAMAR-SNAPEL)' WHERE idccnl = '651'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('651','S','AZIENDE DI SERVIZI (45) ','FEDIMPRESE, FAMAR, SNAPEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'651',{d '2015-02-27'},'PULIZIA: Imprese, PMI, Artigiane, Cooperative (FEDIMPRESE-FAMAR-SNAPEL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '652')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'NORD INDUSTRIALE, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '652',stipula = {d '2015-02-26'},title = 'PULIZIA: Imprese, PMI, Artigiane, Cooperative (NORDINDUSTRIALE-FAMAR)' WHERE idccnl = '652'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('652','S','AZIENDE DI SERVIZI (45) ','NORD INDUSTRIALE, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'652',{d '2015-02-26'},'PULIZIA: Imprese, PMI, Artigiane, Cooperative (NORDINDUSTRIALE-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '653')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'FEDERSICUREZZA ITALIA, CONFINNOVA, FIADEL SP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-04-30'},sortcode = '653',stipula = {d '2017-05-30'},title = 'PULIZIE (FEDERSICUREZZAITALIA-CONFINNOVA-FIADEL SP)' WHERE idccnl = '653'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('653','S','AZIENDE DI SERVIZI (45) ','FEDERSICUREZZA ITALIA, CONFINNOVA, FIADEL SP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-04-30'},'653',{d '2017-05-30'},'PULIZIE (FEDERSICUREZZAITALIA-CONFINNOVA-FIADEL SP)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '654')
UPDATE [ccnl] SET active = 'S',area = 'AZIENDE DI SERVIZI (45) ',contraenti = 'ASSTEL, SLCCGIL, FISTELCISL, UILCOMUIL, UGLTELECOMUNICAZIONI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '654',stipula = {d '2013-02-01'},title = 'TELECOMUNICAZIONI' WHERE idccnl = '654'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('654','S','AZIENDE DI SERVIZI (45) ','ASSTEL, SLCCGIL, FISTELCISL, UILCOMUIL, UGLTELECOMUNICAZIONI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'654',{d '2013-02-01'},'TELECOMUNICAZIONI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '655')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CGILFP, CISLFPS, UILPA, FPCIDA, CONFSALUNSA,DIRSTAT, FED.ASSOMEDSIVEMP, CGIL, CISL, UIL, CIDA, CONFEDIRSTAT, CONFSAL, COSMED',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '655',stipula = {d '2010-02-12'},title = 'AREA I: Dirigenti (Ministeri-Aziende)' WHERE idccnl = '655'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('655','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CGILFP, CISLFPS, UILPA, FPCIDA, CONFSALUNSA,DIRSTAT, FED.ASSOMEDSIVEMP, CGIL, CISL, UIL, CIDA, CONFEDIRSTAT, CONFSAL, COSMED',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'655',{d '2010-02-12'},'AREA I: Dirigenti (Ministeri-Aziende)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '656')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CGILFP, CISLFPS, UILFPL, FPCIDA,DIRERDIREL, CSAREGIONIEAUTONOMIELOCALI, CGIL, CISL, UIL, CONFEDIR, CIDA, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-02'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '656',stipula = {d '2010-02-22'},title = 'AREA II: Dirigenti (Regioni)' WHERE idccnl = '656'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('656','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CGILFP, CISLFPS, UILFPL, FPCIDA,DIRERDIREL, CSAREGIONIEAUTONOMIELOCALI, CGIL, CISL, UIL, CONFEDIR, CIDA, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-02'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'656',{d '2010-02-22'},'AREA II: Dirigenti (Regioni)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '657')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CGILFP, CISLFPSCOSIADI, UILFPL, FPCIDA, SNABISDS, SINAFO, AUPI, CONFEDIRSANITA'', CGIL, CISL, UIL, CIDA, CONFEDIR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '657',stipula = {d '2008-10-17'},title = 'AREA III: Dirigenti (SANITA'' Area non Medica)' WHERE idccnl = '657'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('657','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CGILFP, CISLFPSCOSIADI, UILFPL, FPCIDA, SNABISDS, SINAFO, AUPI, CONFEDIRSANITA'', CGIL, CISL, UIL, CIDA, CONFEDIR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'657',{d '2008-10-17'},'AREA III: Dirigenti (SANITA'' Area non Medica)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '658')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CGILFPMEDICI, FEDCISLMEDICICOSIME, FMUILFPL, CIVEMP, FESMED, UMSPED, CIMOASMD, ANAAOASSOMED, CGIL, CISL, UIL, CONFEDIR, COSMED',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '658',stipula = {d '2008-10-17'},title = 'AREA IV: Dirigenti (SANITA'' Area Medica)' WHERE idccnl = '658'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('658','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CGILFPMEDICI, FEDCISLMEDICICOSIME, FMUILFPL, CIVEMP, FESMED, UMSPED, CIMOASMD, ANAAOASSOMED, CGIL, CISL, UIL, CONFEDIR, COSMED',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'658',{d '2008-10-17'},'AREA IV: Dirigenti (SANITA'' Area Medica)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '659')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CGIL, CISL, CONFSAL, CIDA, FLCCGIL, CISLSCUOLA, CONFSAL SNALS, ANP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '659',stipula = {d '2010-07-15'},title = 'AREA V: Dirigenti (Scuola)' WHERE idccnl = '659'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('659','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CGIL, CISL, CONFSAL, CIDA, FLCCGIL, CISLSCUOLA, CONFSAL SNALS, ANP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'659',{d '2010-07-15'},'AREA V: Dirigenti (Scuola)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '660')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CISL, CISLFPS, CISAL, CSACISALFIALP, ANMIINAIL, CIDA, FPCIDA, RDBCUB, FEMEPA, CGIL, CGILFP, UIL, UILPA, CONFSAL, CONFSAL UNSA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '660',stipula = {d '2010-07-21'},title = 'AREAVI: Dirigenti (Ag.Fiscali-Enti Pubblici non economici)' WHERE idccnl = '660'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('660','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CISL, CISLFPS, CISAL, CSACISALFIALP, ANMIINAIL, CIDA, FPCIDA, RDBCUB, FEMEPA, CGIL, CGILFP, UIL, UILPA, CONFSAL, CONFSAL UNSA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'660',{d '2010-07-21'},'AREAVI: Dirigenti (Ag.Fiscali-Enti Pubblici non economici)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '661')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CGIL, CISL, UIL, CIDA, FLCCGIL, CISLUNIVERSITA'', CISLFIR, UIL PA, SRDAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '661',stipula = {d '2010-07-28'},title = 'AREA VII: Dirigenti (Ricerca-Universit?)' WHERE idccnl = '661'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('661','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CGIL, CISL, UIL, CIDA, FLCCGIL, CISLUNIVERSITA'', CISLFIR, UIL PA, SRDAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'661',{d '2010-07-28'},'AREA VII: Dirigenti (Ricerca-Universit?)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '662')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, FPCIDA, CIDA, SNAPRECOM, CONFINTESA, CISLFPS, CISL, UIL PA, UIL, FP CGIL, CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '662',stipula = {d '2010-08-04'},title = 'AREA VIII: Dirigenti (Presidenza Consiglio Ministri)' WHERE idccnl = '662'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('662','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, FPCIDA, CIDA, SNAPRECOM, CONFINTESA, CISLFPS, CISL, UIL PA, UIL, FP CGIL, CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'662',{d '2010-08-04'},'AREA VIII: Dirigenti (Presidenza Consiglio Ministri)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '663')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'SIULP, SAP, SIAP, SILPCGIL, CONSAPITALIASICURA,LISIPO, SODIPO, UGL, COISPUPFPS, UILPS, SAPPE,OSAPP, CISLFPS, UILPA, SINAPPE, CGILFP, SIAPPE, USPP(UGLFNPPCLPPLISIAPP), CNPP, SAPAF, UGL, CORPOFOREST.STATO, CISLFPSCORPOFOREST.STATO, UILPACORPOFOREST.STATO, SAPECOFS CISAL, CGIL FP CORPO FOREST. STATO, DIRFOR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '663',stipula = {d '2007-09-11'},title = 'CARABINIERI - GUARDIA DI FINANZA' WHERE idccnl = '663'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('663','S','AMMINISTRAZIONE PUBBLICA (20) ','SIULP, SAP, SIAP, SILPCGIL, CONSAPITALIASICURA,LISIPO, SODIPO, UGL, COISPUPFPS, UILPS, SAPPE,OSAPP, CISLFPS, UILPA, SINAPPE, CGILFP, SIAPPE, USPP(UGLFNPPCLPPLISIAPP), CNPP, SAPAF, UGL, CORPOFOREST.STATO, CISLFPSCORPOFOREST.STATO, UILPACORPOFOREST.STATO, SAPECOFS CISAL, CGIL FP CORPO FOREST. STATO, DIRFOR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'663',{d '2007-09-11'},'CARABINIERI - GUARDIA DI FINANZA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '664')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CISLFPS, CISL, UILPA, UIL,DIRSTAT, CONFEDIRSTAT, CIDA UNADIS, CIDA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '664',stipula = {d '2010-03-03'},title = 'CNEL: Dirigenti' WHERE idccnl = '664'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('664','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CISLFPS, CISL, UILPA, UIL,DIRSTAT, CONFEDIRSTAT, CIDA UNADIS, CIDA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'664',{d '2010-03-03'},'CNEL: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '665')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, CISLFP, CISL, FPCGIL, CGIL, UILPA, UIL, FED.CONFSALUNSA, CONFSAL, FED. NAZ.LE INTESA FP, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '665',stipula = {d '2018-02-12'},title = 'Comparto FUNZIONI CENTRALI' WHERE idccnl = '665'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('665','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, CISLFP, CISL, FPCGIL, CGIL, UILPA, UIL, FED.CONFSALUNSA, CONFSAL, FED. NAZ.LE INTESA FP, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'665',{d '2018-02-12'},'Comparto FUNZIONI CENTRALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '666')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, FPCGIL, CGIL, CISLFP, CISL, UILFPL, UIL, CSARegionieAutonomie Locali, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '666',stipula = {d '2018-02-21'},title = 'Comparto FUNZIONI LOCALI' WHERE idccnl = '666'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('666','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, FPCGIL, CGIL, CISLFP, CISL, UILFPL, UIL, CSARegionieAutonomie Locali, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'666',{d '2018-02-21'},'Comparto FUNZIONI LOCALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '667')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, FLCCGIL, CGIL, CISLSCUOLA, CISL, FED.UILSCUOLARUA, UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '667',stipula = {d '2018-02-08'},title = 'Comparto ISTRUZIONE E RICERCA' WHERE idccnl = '667'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('667','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, FLCCGIL, CGIL, CISLSCUOLA, CISL, FED.UILSCUOLARUA, UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'667',{d '2018-02-08'},'Comparto ISTRUZIONE E RICERCA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '668')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, FP CGIL, CGIL, CISL FP, CISL, UIL FPL, UIL, FSI, USAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '668',stipula = {d '2018-02-23'},title = 'Comparto SANITA''' WHERE idccnl = '668'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('668','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, FP CGIL, CGIL, CISL FP, CISL, UIL FPL, UIL, FSI, USAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'668',{d '2018-02-23'},'Comparto SANITA''')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '669')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, FPCIDA, CIDA, FITCISL, CISL, UILTRASPORTI, UIL, FPCGIL, CGIL, USPPI APAC, USPPI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '669',stipula = {d '2010-08-04'},title = 'ENAC (Ente Nazionale Aviazione Civile): Dirigenti' WHERE idccnl = '669'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('669','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, FPCIDA, CIDA, FITCISL, CISL, UILTRASPORTI, UIL, FPCGIL, CGIL, USPPI APAC, USPPI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'669',{d '2010-08-04'},'ENAC (Ente Nazionale Aviazione Civile): Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '670')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'DELEGAZIONEDIPARTEPUBBLICA, STATOMAGGIOREDELLADIFESA, COCER Esercito, COCER Marina, COCER Aeronautica',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '670',stipula = {d '2007-09-11'},title = 'FORZE ARMATE (Esercito - Marina - Aeronautica)' WHERE idccnl = '670'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('670','S','AMMINISTRAZIONE PUBBLICA (20) ','DELEGAZIONEDIPARTEPUBBLICA, STATOMAGGIOREDELLADIFESA, COCER Esercito, COCER Marina, COCER Aeronautica',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'670',{d '2007-09-11'},'FORZE ARMATE (Esercito - Marina - Aeronautica)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '671')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'SIULP, SAP, SIAP, SILPCGIL, CONSAPITALIASICURA,LISIPO, SODIPO, UGL, COISPUPFPS, UILPS, SAPPE,OSAPP, CISLFPS, UILPA, SINAPPE, CGILFP, SIAPPE, USPP(UGLFNPPCLPPLISIAPP), CNPP, SAPAF, UGL, CORPOFOREST.STATO, CISLFPSCORPOFOREST.STATO, UILPACORPOFOREST.STATO, SAPECOFS CISAL, CGIL FP CORPO FOREST. STATO, DIRFOR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '671',stipula = {d '2007-09-11'},title = 'POLIZIA - PENITENZIARI - FORESTALI' WHERE idccnl = '671'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('671','S','AMMINISTRAZIONE PUBBLICA (20) ','SIULP, SAP, SIAP, SILPCGIL, CONSAPITALIASICURA,LISIPO, SODIPO, UGL, COISPUPFPS, UILPS, SAPPE,OSAPP, CISLFPS, UILPA, SINAPPE, CGILFP, SIAPPE, USPP(UGLFNPPCLPPLISIAPP), CNPP, SAPAF, UGL, CORPOFOREST.STATO, CISLFPSCORPOFOREST.STATO, UILPACORPOFOREST.STATO, SAPECOFS CISAL, CGIL FP CORPO FOREST. STATO, DIRFOR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'671',{d '2007-09-11'},'POLIZIA - PENITENZIARI - FORESTALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '672')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'ARAN, SNAPRECOM, CISL FPS, FLP, CISL, UGL, CSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '672',stipula = {d '2009-07-31'},title = 'PRESIDENZA DEL CONSIGLIO DEI MINISTRI' WHERE idccnl = '672'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('672','S','AMMINISTRAZIONE PUBBLICA (20) ','ARAN, SNAPRECOM, CISL FPS, FLP, CISL, UGL, CSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'672',{d '2009-07-31'},'PRESIDENZA DEL CONSIGLIO DEI MINISTRI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '673')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'F VVF CISL, FP CGIL VVF, UIL PA VVF, RDB PI CUB, CONSAL VVF ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '673',stipula = {d '2008-05-07'},title = 'VIGILI DEL FUOCO' WHERE idccnl = '673'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('673','S','AMMINISTRAZIONE PUBBLICA (20) ','F VVF CISL, FP CGIL VVF, UIL PA VVF, RDB PI CUB, CONSAL VVF ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'673',{d '2008-05-07'},'VIGILI DEL FUOCO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '674')
UPDATE [ccnl] SET active = 'S',area = 'AMMINISTRAZIONE PUBBLICA (20) ',contraenti = 'FVVFCISL, APVVF, SINDIRVVF, FPCGILVVF, UILPAVVF, USPPI DIRIGENTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '674',stipula = {d '2008-05-07'},title = 'VIGILI DEL FUOCO: direttivi e dirigenti' WHERE idccnl = '674'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('674','S','AMMINISTRAZIONE PUBBLICA (20) ','FVVFCISL, APVVF, SINDIRVVF, FPCGILVVF, UILPAVVF, USPPI DIRIGENTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'674',{d '2008-05-07'},'VIGILI DEL FUOCO: direttivi e dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '675')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AGENZIADELDEMANIO, CGILFP, CISLFPS, UILPA, CONFSALSALFI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2004-10-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2006-09-30'},scadenza = {d '2008-09-30'},sortcode = '675',stipula = {d '2004-08-02'},title = 'AGENZIA DEL DEMANIO' WHERE idccnl = '675'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('675','S','ENTI E ISTITUZIONI PRIVATE (108) ','AGENZIADELDEMANIO, CGILFP, CISLFPS, UILPA, CONFSALSALFI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-10-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-09-30'},{d '2008-09-30'},'675',{d '2004-08-02'},'AGENZIA DEL DEMANIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '676')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ANASSPA, FILTCGIL, FITCISL, UILPAANAS, SNALACISAL, SADA FAST CONFSAL, UGL, DIRSTAT',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2006-01-01'},sortcode = '676',stipula = {d '2007-07-26'},title = 'ANAS (Ente Nazionale per le Strade)' WHERE idccnl = '676'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('676','S','ENTI E ISTITUZIONI PRIVATE (108) ','ANASSPA, FILTCGIL, FITCISL, UILPAANAS, SNALACISAL, SADA FAST CONFSAL, UGL, DIRSTAT',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2006-01-01'},'676',{d '2007-07-26'},'ANAS (Ente Nazionale per le Strade)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '677')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ANAS SPA, FNDAI FEDERMANAGER',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-12-31'},scadenza = {d '2009-01-01'},sortcode = '677',stipula = {d '2010-02-03'},title = 'ANAS: Dirigenti (Ente Nazionale per le Strade)' WHERE idccnl = '677'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('677','S','ENTI E ISTITUZIONI PRIVATE (108) ','ANAS SPA, FNDAI FEDERMANAGER',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-31'},{d '2009-01-01'},'677',{d '2010-02-03'},'ANAS: Dirigenti (Ente Nazionale per le Strade)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '678')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ANCI, CGIL FPS, UIL FPL, UIL PA, CISL FPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2011-12-31'},sortcode = '678',stipula = {d '2008-07-01'},title = 'ANCI' WHERE idccnl = '678'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('678','S','ENTI E ISTITUZIONI PRIVATE (108) ','ANCI, CGIL FPS, UIL FPL, UIL PA, CISL FPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2011-12-31'},'678',{d '2008-07-01'},'ANCI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '679')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNCI, SNALS CONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2010-06-30'},scadenza = {d '2012-06-30'},sortcode = '679',stipula = {d '2008-06-25'},title = 'Asili Nido o Ludoteche: Cooperative' WHERE idccnl = '679'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('679','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNCI, SNALS CONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-06-30'},{d '2012-06-30'},'679',{d '2008-06-25'},'Asili Nido o Ludoteche: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '680')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'NORD INDUSTRIALE, FAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2015-03-01'},sortcode = '680',stipula = {d '2015-02-26'},title = 'ASSISTENZA (NORD INDUSTRIALE-FAMAR)' WHERE idccnl = '680'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('680','S','ENTI E ISTITUZIONI PRIVATE (108) ','NORD INDUSTRIALE, FAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2015-03-01'},'680',{d '2015-02-26'},'ASSISTENZA (NORD INDUSTRIALE-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '681')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'CEPAA, CEPASANITA'', ESAARCO, CIU, FNAOPS, FISNALCTAUGL, ONAPS, SI CEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-10-06'},scadenza = {d '2015-10-07'},sortcode = '681',stipula = {d '2015-10-07'},title = 'AZIENDE SANITARIE PRIVATE, ALTRE STRUTTURE RESIDENZIALI, ASSISTENZIALI, SOCIO-ASSISTENZIALI, COOP.SOCIO-SANITARIE-CEPA-CIU-FNAOPS' WHERE idccnl = '681'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('681','S','ENTI E ISTITUZIONI PRIVATE (108) ','CEPAA, CEPASANITA'', ESAARCO, CIU, FNAOPS, FISNALCTAUGL, ONAPS, SI CEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-10-06'},{d '2015-10-07'},'681',{d '2015-10-07'},'AZIENDE SANITARIE PRIVATE, ALTRE STRUTTURE RESIDENZIALI, ASSISTENZIALI, SOCIO-ASSISTENZIALI, COOP.SOCIO-SANITARIE-CEPA-CIU-FNAOPS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '682')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ANPIT, CIDEC, CONFIMPRENDITORI, PMIITALIA, UAITCS, UNICA, CISAL Terziario, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-12-31'},scadenza = {d '2018-01-01'},sortcode = '682',stipula = {d '2017-11-21'},title = 'CASE DI CURA E SERVIZI ASSISTENZIALI E SOCIOSANITARI' WHERE idccnl = '682'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('682','S','ENTI E ISTITUZIONI PRIVATE (108) ','ANPIT, CIDEC, CONFIMPRENDITORI, PMIITALIA, UAITCS, UNICA, CISAL Terziario, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-12-31'},{d '2018-01-01'},'682',{d '2017-11-21'},'CASE DI CURA E SERVIZI ASSISTENZIALI E SOCIOSANITARI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '683')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-11-29'},scadenza = {d '2016-11-30'},sortcode = '683',stipula = {d '2016-11-30'},title = 'CASE DI CURA PRIVATE E CENTRI DI RIABILITAZIONE (ESAARCO)' WHERE idccnl = '683'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('683','S','ENTI E ISTITUZIONI PRIVATE (108) ','ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-11-29'},{d '2016-11-30'},'683',{d '2016-11-30'},'CASE DI CURA PRIVATE E CENTRI DI RIABILITAZIONE (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '684')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-11-29'},scadenza = {d '2016-11-30'},sortcode = '684',stipula = {d '2016-11-30'},title = 'CASE DI CURA PRIVATEECENTRIDIRIABILITAZIONE: Medici (ESAARCO)' WHERE idccnl = '684'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('684','S','ENTI E ISTITUZIONI PRIVATE (108) ','ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-11-29'},{d '2016-11-30'},'684',{d '2016-11-30'},'CASE DI CURA PRIVATEECENTRIDIRIABILITAZIONE: Medici (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '685')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-07-05'},scadenza = {d '2015-07-06'},sortcode = '685',stipula = {d '2015-07-02'},title = 'CASE DI CURA PRIVATE E CENTRI DI RIABILITAZIONE: personale non medico (CONFIMPRENDITORI-USIL)' WHERE idccnl = '685'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('685','S','ENTI E ISTITUZIONI PRIVATE (108) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-07-05'},{d '2015-07-06'},'685',{d '2015-07-02'},'CASE DI CURA PRIVATE E CENTRI DI RIABILITAZIONE: personale non medico (CONFIMPRENDITORI-USIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '686')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'Approvato dal Comitato Direttivo CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-03-31'},scadenza = {d '2004-04-01'},sortcode = '686',stipula = {d '2004-04-19'},title = 'CGIL (Lavoratori Dipendenti)' WHERE idccnl = '686'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('686','S','ENTI E ISTITUZIONI PRIVATE (108) ','Approvato dal Comitato Direttivo CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-03-31'},{d '2004-04-01'},'686',{d '2004-04-19'},'CGIL (Lavoratori Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '687')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'Delibera del Comitato Esecutivo Confederale',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-03-31'},scadenza = {d '2004-04-01'},sortcode = '687',stipula = {d '2004-06-22'},title = 'CISL (Dirigenti)' WHERE idccnl = '687'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('687','S','ENTI E ISTITUZIONI PRIVATE (108) ','Delibera del Comitato Esecutivo Confederale',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-03-31'},{d '2004-04-01'},'687',{d '2004-06-22'},'CISL (Dirigenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '688')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'Delibera del Comitato Esecutivo Confederale',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-03-31'},scadenza = {d '2004-04-01'},sortcode = '688',stipula = {d '2004-06-22'},title = 'CISL (Lavoratori Dipendenti)' WHERE idccnl = '688'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('688','S','ENTI E ISTITUZIONI PRIVATE (108) ','Delibera del Comitato Esecutivo Confederale',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-03-31'},{d '2004-04-01'},'688',{d '2004-06-22'},'CISL (Lavoratori Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '689')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ARIS, FP CGIL, CISL FP, UIL FPL, UGL SANITA''',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-01-01'},sortcode = '689',stipula = {d '2015-12-30'},title = 'Collaboratori di Enti di Ricerca privati, IRCCS E Strutture Sanitarie private (ARIS)' WHERE idccnl = '689'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('689','S','ENTI E ISTITUZIONI PRIVATE (108) ','ARIS, FP CGIL, CISL FP, UIL FPL, UGL SANITA''',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-01-01'},'689',{d '2015-12-30'},'Collaboratori di Enti di Ricerca privati, IRCCS E Strutture Sanitarie private (ARIS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '690')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'LUISS, UNIVERSITA'' COMMERCIALE LUIGI BOCCONI, UNIVERSITA'' CATTOLICA DEL SACRO CUORE, UNIVERSITA'' CAMPUS BIOMEDICO, UNIVERSITA''CARLO CATTANEO LIUC, UNIVERSITA'' VITA SALUTE SAN RAFFAELE, FONDAZIONE CENTRO SAN RAFFAELE, UNIVERSITA'' DEGLI STUDIDI SCIENZE GASTRONOMICHE, LIBERA UNIVERSITA'' DEGLI STUDI KORE DI ENNA, UNINT UNIVERSITA'' DEGLISTUDI INTERNAZIONALI DI ROMA, LIBERA UNIVERSITA'' DI LINGUE E COMUNICAZIONE UILM, LIBERA UNIVERSITA'' MARIA SS ASSUNTA, UNIVERSITA'' DEGLI STUDI SUOR ORSOLA BENINCASA, FLCCGIL, CISL UNIVERSITA'', UIL RUA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-10'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-09'},sortcode = '690',stipula = {d '2015-12-10'},title = 'Collaboratori UNIVERSITA'' NON STATALI' WHERE idccnl = '690'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('690','S','ENTI E ISTITUZIONI PRIVATE (108) ','LUISS, UNIVERSITA'' COMMERCIALE LUIGI BOCCONI, UNIVERSITA'' CATTOLICA DEL SACRO CUORE, UNIVERSITA'' CAMPUS BIOMEDICO, UNIVERSITA''CARLO CATTANEO LIUC, UNIVERSITA'' VITA SALUTE SAN RAFFAELE, FONDAZIONE CENTRO SAN RAFFAELE, UNIVERSITA'' DEGLI STUDIDI SCIENZE GASTRONOMICHE, LIBERA UNIVERSITA'' DEGLI STUDI KORE DI ENNA, UNINT UNIVERSITA'' DEGLISTUDI INTERNAZIONALI DI ROMA, LIBERA UNIVERSITA'' DI LINGUE E COMUNICAZIONE UILM, LIBERA UNIVERSITA'' MARIA SS ASSUNTA, UNIVERSITA'' DEGLI STUDI SUOR ORSOLA BENINCASA, FLCCGIL, CISL UNIVERSITA'', UIL RUA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-10'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-09'},'690',{d '2015-12-10'},'Collaboratori UNIVERSITA'' NON STATALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '691')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FENASPA, ASPAT, ANPRIC, CONFIMPRESEITALIA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-06-30'},sortcode = '691',stipula = {d '2013-05-30'},title = 'COMPARTO PRIVATO SANITARIO E SOCIOSANITARIO' WHERE idccnl = '691'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('691','S','ENTI E ISTITUZIONI PRIVATE (108) ','FENASPA, ASPAT, ANPRIC, CONFIMPRESEITALIA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-06-30'},'691',{d '2013-05-30'},'COMPARTO PRIVATO SANITARIO E SOCIOSANITARIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '692')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FICEI, FP CGIL, FPS CISL, UIL FPL, FINDICI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '692',stipula = {d '2016-11-29'},title = 'CONSORZI ED ENTI DI INDUSTRIALIZZAZIONE' WHERE idccnl = '692'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('692','S','ENTI E ISTITUZIONI PRIVATE (108) ','FICEI, FP CGIL, FPS CISL, UIL FPL, FINDICI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'692',{d '2016-11-29'},'CONSORZI ED ENTI DI INDUSTRIALIZZAZIONE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '693')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FICEI, FEDERMANAGER, DIRSIND',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '693',stipula = {d '2012-04-03'},title = 'CONSORZI ED ENTI DI INDUSTRIALIZZAZIONE: Dirigenti' WHERE idccnl = '693'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('693','S','ENTI E ISTITUZIONI PRIVATE (108) ','FICEI, FEDERMANAGER, DIRSIND',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'693',{d '2012-04-03'},'CONSORZI ED ENTI DI INDUSTRIALIZZAZIONE: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '694')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNICOOP, UGL Sanit? Nazionale, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '694',stipula = {d '2016-12-22'},title = 'COOPERATIVE SETTORE SOCIO-SANITARIO, UMANITARIO, ASSISTENZIALE-EDUCATIVO E DI INSERIMENTO LAVORATIVO (UNICOOP-UGL)' WHERE idccnl = '694'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('694','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNICOOP, UGL Sanit? Nazionale, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'694',{d '2016-12-22'},'COOPERATIVE SETTORE SOCIO-SANITARIO, UMANITARIO, ASSISTENZIALE-EDUCATIVO E DI INSERIMENTO LAVORATIVO (UNICOOP-UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '695')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNFI, ISA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '695',stipula = {d '2014-07-28'},title = 'Cooperative sociali' WHERE idccnl = '695'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('695','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNFI, ISA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'695',{d '2014-07-28'},'Cooperative sociali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '696')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'LEGA IMPRESA, FILAP, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-03-21'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-02-28'},sortcode = '696',stipula = {d '2016-03-21'},title = 'COOPERATIVE SOCIO-SANITARIE, AZIENDE SANITARIE PRIVATE, STRUTTURE RESIDENZIALI, ASSISTENZIALI E SOCIO-ASSISTENZIALI' WHERE idccnl = '696'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('696','S','ENTI E ISTITUZIONI PRIVATE (108) ','LEGA IMPRESA, FILAP, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-03-21'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-02-28'},'696',{d '2016-03-21'},'COOPERATIVE SOCIO-SANITARIE, AZIENDE SANITARIE PRIVATE, STRUTTURE RESIDENZIALI, ASSISTENZIALI E SOCIO-ASSISTENZIALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '697')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ARIS, ANMIRS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2007-12-31'},sortcode = '697',stipula = {d '2008-12-29'},title = 'Dirigenti Medici di Ospedali Classificati e IRCCS (ARIS)' WHERE idccnl = '697'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('697','S','ENTI E ISTITUZIONI PRIVATE (108) ','ARIS, ANMIRS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2007-12-31'},'697',{d '2008-12-29'},'Dirigenti Medici di Ospedali Classificati e IRCCS (ARIS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '698')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'POSTEITALIANESPA, SLCCGIL, SLPCISL, UILPOSTE, FAILPCISAL, CONFSAL COMUNICAZIONI, UGL COMUNICAZIONI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '698',stipula = {d '2011-04-14'},title = 'ENTE POSTE ITALIANE (Poste Italiane spa)' WHERE idccnl = '698'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('698','S','ENTI E ISTITUZIONI PRIVATE (108) ','POSTEITALIANESPA, SLCCGIL, SLPCISL, UILPOSTE, FAILPCISAL, CONFSAL COMUNICAZIONI, UGL COMUNICAZIONI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'698',{d '2011-04-14'},'ENTE POSTE ITALIANE (Poste Italiane spa)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '699')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'POSTE ITALIANE SPA, ASSIDIPOST FNDAI, FNDAI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '1999-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2002-12-31'},sortcode = '699',stipula = {d '1999-03-09'},title = 'ENTE POSTE ITALIANE: Dirigenti (Poste Italiane spa)' WHERE idccnl = '699'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('699','S','ENTI E ISTITUZIONI PRIVATE (108) ','POSTE ITALIANE SPA, ASSIDIPOST FNDAI, FNDAI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '1999-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2002-12-31'},'699',{d '1999-03-09'},'ENTE POSTE ITALIANE: Dirigenti (Poste Italiane spa)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '700')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'CEI, CICAS, CONFIMPRESA, ANFOP, ISA, SIA CONFSAL, SILSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-10-31'},sortcode = '700',stipula = {d '2010-11-12'},title = 'ENTI FORMAZIONE PROFESSIONALE' WHERE idccnl = '700'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('700','S','ENTI E ISTITUZIONI PRIVATE (108) ','CEI, CICAS, CONFIMPRESA, ANFOP, ISA, SIA CONFSAL, SILSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-10-31'},'700',{d '2010-11-12'},'ENTI FORMAZIONE PROFESSIONALE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '701')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FIDEF, CEFIR, CISAL SCUOLA, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-08-30'},sortcode = '701',stipula = {d '2012-09-06'},title = 'ENTI ISTRUZIONE-FORMAZIONE E CULTURA VARIA' WHERE idccnl = '701'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('701','S','ENTI E ISTITUZIONI PRIVATE (108) ','FIDEF, CEFIR, CISAL SCUOLA, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-08-30'},'701',{d '2012-09-06'},'ENTI ISTRUZIONE-FORMAZIONE E CULTURA VARIA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '702')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FIDEF, FIINSEI, CONFIMPRESEITALIA, CONFALSCUOLA, FLPSCUOLA, CSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-08-30'},sortcode = '702',stipula = {d '2015-08-03'},title = 'ENTI ISTRUZIONE-FORMAZIONE E CULTURA VARIA (FIDEF-FIINSEI)' WHERE idccnl = '702'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('702','S','ENTI E ISTITUZIONI PRIVATE (108) ','FIDEF, FIINSEI, CONFIMPRESEITALIA, CONFALSCUOLA, FLPSCUOLA, CSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-08-30'},'702',{d '2015-08-03'},'ENTI ISTRUZIONE-FORMAZIONE E CULTURA VARIA (FIDEF-FIINSEI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '703')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ADEPP, CGILFP, CISLFP, UILPA, FIALPCISAL, UGLTERZIARIO, CONFSAL PARASTATO, DIRP CONFEDIR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '703',stipula = {d '2010-12-23'},title = 'ENTI PREVIDENZIALI PRIVATIZZATI' WHERE idccnl = '703'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('703','S','ENTI E ISTITUZIONI PRIVATE (108) ','ADEPP, CGILFP, CISLFP, UILPA, FIALPCISAL, UGLTERZIARIO, CONFSAL PARASTATO, DIRP CONFEDIR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'703',{d '2010-12-23'},'ENTI PREVIDENZIALI PRIVATIZZATI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '704')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ADEPP, CGILFP, CISLFP, UILPA, FIALPCISAL, UGLTERZIARIO, CIDA ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '704',stipula = {d '2010-12-29'},title = 'ENTI PREVIDENZIALI PRIVATIZZATI: Dirigenti' WHERE idccnl = '704'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('704','S','ENTI E ISTITUZIONI PRIVATE (108) ','ADEPP, CGILFP, CISLFP, UILPA, FIALPCISAL, UGLTERZIARIO, CIDA ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'704',{d '2010-12-29'},'ENTI PREVIDENZIALI PRIVATIZZATI: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '705')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AFI, CGIL, CISL, UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2009-12-31'},scadenza = {d '2011-12-31'},sortcode = '705',stipula = {d '2007-07-06'},title = 'FABBRICERIE' WHERE idccnl = '705'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('705','S','ENTI E ISTITUZIONI PRIVATE (108) ','AFI, CGIL, CISL, UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-31'},{d '2011-12-31'},'705',{d '2007-07-06'},'FABBRICERIE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '706')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FEDERCASA, FP CGIL, FPS CISL, UIL FPL, FESICA CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2009-12-31'},sortcode = '706',stipula = {d '2008-07-17'},title = 'FEDERCASA' WHERE idccnl = '706'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('706','S','ENTI E ISTITUZIONI PRIVATE (108) ','FEDERCASA, FP CGIL, FPS CISL, UIL FPL, FESICA CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2009-12-31'},'706',{d '2008-07-17'},'FEDERCASA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '707')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FEDERCULTURE, FP CGIL, CISL FP, UIL FPL, UIL PA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '707',stipula = {d '2016-05-12'},title = 'FEDERCULTURE: Dipendenti' WHERE idccnl = '707'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('707','S','ENTI E ISTITUZIONI PRIVATE (108) ','FEDERCULTURE, FP CGIL, CISL FP, UIL FPL, UIL PA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'707',{d '2016-05-12'},'FEDERCULTURE: Dipendenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '708')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FEDERCULTURE, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '708',stipula = {d '2016-05-12'},title = 'FEDERCULTURE: Dipendenti' WHERE idccnl = '708'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('708','S','ENTI E ISTITUZIONI PRIVATE (108) ','FEDERCULTURE, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'708',{d '2016-05-12'},'FEDERCULTURE: Dipendenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '709')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FENAPIGROUP, FENAPIASSISTANCE, FENAPI, CIU, SILPA, SINALP, SELP, ALI CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-12-31'},sortcode = '709',stipula = {d '2016-12-29'},title = 'FENAPI GROUP (Dipendenti)' WHERE idccnl = '709'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('709','S','ENTI E ISTITUZIONI PRIVATE (108) ','FENAPIGROUP, FENAPIASSISTANCE, FENAPI, CIU, SILPA, SINALP, SELP, ALI CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-12-31'},'709',{d '2016-12-29'},'FENAPI GROUP (Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '710')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FONDAZIONEENASARCO, CGILFP, CISLFPS, UILPA, UGL, FIALP CISAL, DIRP CONFEDIR, USB',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '710',stipula = {d '2011-01-24'},title = 'FONDAZIONE ENASARCO' WHERE idccnl = '710'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('710','S','ENTI E ISTITUZIONI PRIVATE (108) ','FONDAZIONEENASARCO, CGILFP, CISLFPS, UILPA, UGL, FIALP CISAL, DIRP CONFEDIR, USB',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'710',{d '2011-01-24'},'FONDAZIONE ENASARCO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '711')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FONDAZIONEENASARCO, CGILFP, CISLFPS, UILPA, UGL, FIALP CISAL, DIRP CONFEDIR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '711',stipula = {d '2011-01-24'},title = 'FONDAZIONE ENASARCO: Dirigenti' WHERE idccnl = '711'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('711','S','ENTI E ISTITUZIONI PRIVATE (108) ','FONDAZIONEENASARCO, CGILFP, CISLFPS, UILPA, UGL, FIALP CISAL, DIRP CONFEDIR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'711',{d '2011-01-24'},'FONDAZIONE ENASARCO: Dirigenti')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '712')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNFI, ANFOP, ISA, FEDERFORMATORI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '712',stipula = {d '2014-07-28'},title = 'FORMAZIONE ISTRUZIONE E UNIVERSITA''' WHERE idccnl = '712'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('712','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNFI, ANFOP, ISA, FEDERFORMATORI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'712',{d '2014-07-28'},'FORMAZIONE ISTRUZIONE E UNIVERSITA''')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '713')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FORMEZPA, FP CGIL, CISL FP, UIL PA, CISAL FIALP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '713',stipula = {d '2018-01-11'},title = 'FORMEZ' WHERE idccnl = '713'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('713','S','ENTI E ISTITUZIONI PRIVATE (108) ','FORMEZPA, FP CGIL, CISL FP, UIL PA, CISAL FIALP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'713',{d '2018-01-11'},'FORMEZ')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '714')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'COPIMI, FEDERAZIONE PIER GIORGIO FRASSATI, FITESC, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-03'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-02'},sortcode = '714',stipula = {d '2017-04-03'},title = 'Imprese Sociali e Cooperative operanti nel settore Cultura e Spettacolo' WHERE idccnl = '714'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('714','S','ENTI E ISTITUZIONI PRIVATE (108) ','COPIMI, FEDERAZIONE PIER GIORGIO FRASSATI, FITESC, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-03'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-02'},'714',{d '2017-04-03'},'Imprese Sociali e Cooperative operanti nel settore Cultura e Spettacolo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '715')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'COPIMI, FEDERAZIONE PIER GIORGIO FRASSATI, FITESC, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-08-31'},sortcode = '715',stipula = {d '2017-05-04'},title = 'Imprese Sociali e Cooperative operanti nel settore della Scuola Libera' WHERE idccnl = '715'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('715','S','ENTI E ISTITUZIONI PRIVATE (108) ','COPIMI, FEDERAZIONE PIER GIORGIO FRASSATI, FITESC, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-08-31'},'715',{d '2017-05-04'},'Imprese Sociali e Cooperative operanti nel settore della Scuola Libera')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '716')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'COPIMI, FEDERAZIONEORGANIZZAZIONIDIVOLONTARIATOPIER GIORGIO FRASSATI, FITESC, CONFASI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-08-31'},sortcode = '716',stipula = {d '2017-09-19'},title = 'Imprese Sociali ed Enti del Terzo Settore' WHERE idccnl = '716'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('716','S','ENTI E ISTITUZIONI PRIVATE (108) ','COPIMI, FEDERAZIONEORGANIZZAZIONIDIVOLONTARIATOPIER GIORGIO FRASSATI, FITESC, CONFASI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-08-31'},'716',{d '2017-09-19'},'Imprese Sociali ed Enti del Terzo Settore')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '717')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ESAARCO, CEPAA, CEPAAScuola, CEPAAFedercoop, ESAARCOScuoleeFormazioneProfessionale, CIU, SICEL, FENALS, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-10-12'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-10-11'},sortcode = '717',stipula = {d '2016-10-12'},title = 'ISTITUTI SCOLASTICI GESTITI DA ENTI PRIVATI (ESAARCO)' WHERE idccnl = '717'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('717','S','ENTI E ISTITUZIONI PRIVATE (108) ','ESAARCO, CEPAA, CEPAAScuola, CEPAAFedercoop, ESAARCOScuoleeFormazioneProfessionale, CIU, SICEL, FENALS, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-12'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-10-11'},'717',{d '2016-10-12'},'ISTITUTI SCOLASTICI GESTITI DA ENTI PRIVATI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '718')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ESAARCO, CEPAA, CEPAAScuola, CEPAAFedercoop, ADI, ESAARCOScuoleeFormazioneProfessionale, CIU, SICEL, FENALS, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-10-12'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-10-11'},sortcode = '718',stipula = {d '2016-10-12'},title = 'ISTITUTI SCOLASTICI-EDUCATIVI GESTITI DA ENTI ECCLESIASTICI (ESAARCO)' WHERE idccnl = '718'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('718','S','ENTI E ISTITUZIONI PRIVATE (108) ','ESAARCO, CEPAA, CEPAAScuola, CEPAAFedercoop, ADI, ESAARCOScuoleeFormazioneProfessionale, CIU, SICEL, FENALS, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-12'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-10-11'},'718',{d '2016-10-12'},'ISTITUTI SCOLASTICI-EDUCATIVI GESTITI DA ENTI ECCLESIASTICI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '719')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AGESPI, FP CGIL, FISASCAT FIST CISL, UILTUCS UIL, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '719',stipula = {d '2018-01-23'},title = 'ISTITUTI SOCIO-SANITARI-ASSISTENZIALI (AGESPI)' WHERE idccnl = '719'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('719','S','ENTI E ISTITUZIONI PRIVATE (108) ','AGESPI, FP CGIL, FISASCAT FIST CISL, UILTUCS UIL, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'719',{d '2018-01-23'},'ISTITUTI SOCIO-SANITARI-ASSISTENZIALI (AGESPI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '720')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AGIDAE, FP CGIL, FISASCAT FIST CISL, CISL, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '720',stipula = {d '2017-02-20'},title = 'ISTITUTI SOCIO-SANITARI-ASSISTENZIALI (AGIDAE)' WHERE idccnl = '720'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('720','S','ENTI E ISTITUZIONI PRIVATE (108) ','AGIDAE, FP CGIL, FISASCAT FIST CISL, CISL, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'720',{d '2017-02-20'},'ISTITUTI SOCIO-SANITARI-ASSISTENZIALI (AGIDAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '721')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'OPERE E ISTITUTI VALDESI, FP CGIL, CISL FP, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2009-12-31'},sortcode = '721',stipula = {d '2008-11-17'},title = 'ISTITUTI SOCIO-SANITARI-ASSISTENZIALI (VALDESI)' WHERE idccnl = '721'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('721','S','ENTI E ISTITUZIONI PRIVATE (108) ','OPERE E ISTITUTI VALDESI, FP CGIL, CISL FP, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2009-12-31'},'721',{d '2008-11-17'},'ISTITUTI SOCIO-SANITARI-ASSISTENZIALI (VALDESI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '722')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FIINSEI, FIDEF, CONFIMPRESEITALIA, CONFALScuola, FLPScuola, CSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-10-31'},sortcode = '722',stipula = {d '2015-11-04'},title = 'ISTITUZIONI DI ALTA CULTURA, UNIVERSITA'' ED ACCADEMIE LEGALMENTE RICONOSCIUTE' WHERE idccnl = '722'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('722','S','ENTI E ISTITUZIONI PRIVATE (108) ','FIINSEI, FIDEF, CONFIMPRESEITALIA, CONFALScuola, FLPScuola, CSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-10-31'},'722',{d '2015-11-04'},'ISTITUZIONI DI ALTA CULTURA, UNIVERSITA'' ED ACCADEMIE LEGALMENTE RICONOSCIUTE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '723')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FIINSEI, FIDEF, CONFIMPRESEITALIA, CONFALScuola, FLPScuola, CSE ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-10-31'},sortcode = '723',stipula = {d '2015-11-04'},title = 'ISTITUZIONI DI ALTA CULTURA, UNIVERSITA'' ED ACCADEMIE LEGALMENTE RICONOSCIUTE (collaborazione coordinata e continuativa)' WHERE idccnl = '723'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('723','S','ENTI E ISTITUZIONI PRIVATE (108) ','FIINSEI, FIDEF, CONFIMPRESEITALIA, CONFALScuola, FLPScuola, CSE ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-10-31'},'723',{d '2015-11-04'},'ISTITUZIONI DI ALTA CULTURA, UNIVERSITA'' ED ACCADEMIE LEGALMENTE RICONOSCIUTE (collaborazione coordinata e continuativa)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '724')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'CIU, SNALV, CONFSAL, CONFELP, ANASTE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '724',stipula = {d '2017-04-12'},title = 'ISTITUZIONI E SERVIZI SOCIO-ASSISTENZIALI (ANASTE)' WHERE idccnl = '724'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('724','S','ENTI E ISTITUZIONI PRIVATE (108) ','CIU, SNALV, CONFSAL, CONFELP, ANASTE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'724',{d '2017-04-12'},'ISTITUZIONI E SERVIZI SOCIO-ASSISTENZIALI (ANASTE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '725')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNEBA, CISL FP, CISL FISASCAT, CGIL FP, UILTUCS UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2009-12-31'},sortcode = '725',stipula = {d '2009-02-23'},title = 'ISTITUZIONI E SERVIZI SOCIO-ASSISTENZIALI (UNEBA)' WHERE idccnl = '725'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('725','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNEBA, CISL FP, CISL FISASCAT, CGIL FP, UILTUCS UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2009-12-31'},'725',{d '2009-02-23'},'ISTITUZIONI E SERVIZI SOCIO-ASSISTENZIALI (UNEBA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '726')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'CIFA ITALIA, FEDERLAB ITALIA, CONFSAL, FIALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-01-31'},sortcode = '726',stipula = {d '2014-02-18'},title = 'LABORATORI DI ANALISI CLINICHE E CENTRI POLIAMBULATORIALI' WHERE idccnl = '726'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('726','S','ENTI E ISTITUZIONI PRIVATE (108) ','CIFA ITALIA, FEDERLAB ITALIA, CONFSAL, FIALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-01-31'},'726',{d '2014-02-18'},'LABORATORI DI ANALISI CLINICHE E CENTRI POLIAMBULATORIALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '727')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ARIS, ADONP, SNABI SDS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-02-26'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '727',stipula = {d '2013-02-25'},title = 'OSPEDALI CLASSIFICATI, IRCCS E PRESIDI (ARIS)' WHERE idccnl = '727'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('727','S','ENTI E ISTITUZIONI PRIVATE (108) ','ARIS, ADONP, SNABI SDS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-02-26'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'727',{d '2013-02-25'},'OSPEDALI CLASSIFICATI, IRCCS E PRESIDI (ARIS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '728')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'PONTIFICIAUNIVERSITA''GREGORIANA, FLCCGIL, FISCISL, UILPA UR UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2009-12-31'},sortcode = '728',stipula = {d '2008-06-26'},title = 'PONTIFICIA UNIVERSITA'' GREGORIANA' WHERE idccnl = '728'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('728','S','ENTI E ISTITUZIONI PRIVATE (108) ','PONTIFICIAUNIVERSITA''GREGORIANA, FLCCGIL, FISCISL, UILPA UR UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2009-12-31'},'728',{d '2008-06-26'},'PONTIFICIA UNIVERSITA'' GREGORIANA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '729')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'PONTIFICIO ISTITUTO BIBLICO, UILPA UR UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2002-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2005-12-31'},sortcode = '729',stipula = {d '2005-12-13'},title = 'PONTIFICIO ISTITUTO BIBLICO' WHERE idccnl = '729'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('729','S','ENTI E ISTITUZIONI PRIVATE (108) ','PONTIFICIO ISTITUTO BIBLICO, UILPA UR UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2002-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2005-12-31'},'729',{d '2005-12-13'},'PONTIFICIO ISTITUTO BIBLICO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '730')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-21'},sortcode = '730',stipula = {d '2016-11-22'},title = 'REALTA? DEL SETTORE ASSISTENZIALE, SOCIALE, SOCIO-SANITARIO, EDUCATIVO (ESAARCO)' WHERE idccnl = '730'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('730','S','ENTI E ISTITUZIONI PRIVATE (108) ','ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-21'},'730',{d '2016-11-22'},'REALTA? DEL SETTORE ASSISTENZIALE, SOCIALE, SOCIO-SANITARIO, EDUCATIVO (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '731')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AIOP, UGLSANITA'', FISMICCONFSAL, SICEL, FIALS, CONFSAL, FSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-03-31'},sortcode = '731',stipula = {d '2012-03-22'},title = 'RESIDENZE SANITARIE ASSISTENZIALI (AIOP)' WHERE idccnl = '731'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('731','S','ENTI E ISTITUZIONI PRIVATE (108) ','AIOP, UGLSANITA'', FISMICCONFSAL, SICEL, FIALS, CONFSAL, FSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-03-31'},'731',{d '2012-03-22'},'RESIDENZE SANITARIE ASSISTENZIALI (AIOP)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '732')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ARIS, CISL FP, UIL FPL, UGL SANITA''',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-12-31'},sortcode = '732',stipula = {d '2012-12-05'},title = 'RESIDENZE SANITARIE ASSISTENZIALI (ARIS)' WHERE idccnl = '732'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('732','S','ENTI E ISTITUZIONI PRIVATE (108) ','ARIS, CISL FP, UIL FPL, UGL SANITA''',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-12-31'},'732',{d '2012-12-05'},'RESIDENZE SANITARIE ASSISTENZIALI (ARIS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '733')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-21'},sortcode = '733',stipula = {d '2016-11-22'},title = 'RSA E ALTRE STRUTTURE RESIDENZIALI E SOCIO-ASSISTENZIALI (ESAARCO)' WHERE idccnl = '733'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('733','S','ENTI E ISTITUZIONI PRIVATE (108) ','ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-21'},'733',{d '2016-11-22'},'RSA E ALTRE STRUTTURE RESIDENZIALI E SOCIO-ASSISTENZIALI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '734')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'CEPA A, CEPA SANITA'', USAE, FNAOPS USAE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-07-06'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2015-07-05'},sortcode = '734',stipula = {d '2012-07-06'},title = 'RSA, ALTRE STRUTTURE RESIDENZIALI E SOCIO-ASSISTENZIALI, COOP.SOCIO-SANITARIE-CEPA-USAE' WHERE idccnl = '734'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('734','S','ENTI E ISTITUZIONI PRIVATE (108) ','CEPA A, CEPA SANITA'', USAE, FNAOPS USAE',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-07-06'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2015-07-05'},'734',{d '2012-07-06'},'RSA, ALTRE STRUTTURE RESIDENZIALI E SOCIO-ASSISTENZIALI, COOP.SOCIO-SANITARIE-CEPA-USAE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '735')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNSIC, UNSICOOP, FEDERDAT, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-06-30'},sortcode = '735',stipula = {d '2017-06-27'},title = 'SANITA'' E SERVIZI ASSISTENZIALI: Personalenonmedico' WHERE idccnl = '735'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('735','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNSIC, UNSICOOP, FEDERDAT, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-06-30'},'735',{d '2017-06-27'},'SANITA'' E SERVIZI ASSISTENZIALI: Personalenonmedico')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '736')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleSanit?eWelfare, UNIMPRESAFederazione NazionaleOpereSociali, CONFINTESA, CONFINTESA Sanit?',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '736',stipula = {d '2017-05-04'},title = 'SANITA'' PRIVATA (UNIMPRESA - CONFINTESA)' WHERE idccnl = '736'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('736','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNIMPRESA, UNIMPRESAFederazione NazionaleSanit?eWelfare, UNIMPRESAFederazione NazionaleOpereSociali, CONFINTESA, CONFINTESA Sanit?',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'736',{d '2017-05-04'},'SANITA'' PRIVATA (UNIMPRESA - CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '737')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ANFFAS ONLUS, CGIL FP, CISL FP, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2009-12-31'},sortcode = '737',stipula = {d '2009-04-16'},title = 'SANITA'': Dipendenti ANFFAS' WHERE idccnl = '737'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('737','S','ENTI E ISTITUZIONI PRIVATE (108) ','ANFFAS ONLUS, CGIL FP, CISL FP, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2009-12-31'},'737',{d '2009-04-16'},'SANITA'': Dipendenti ANFFAS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '738')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AVIS, FP CGIL, FP CISL, FPL UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-12-31'},scadenza = {d '2009-12-31'},sortcode = '738',stipula = {d '2008-06-13'},title = 'SANITA'': Dipendenti AVIS' WHERE idccnl = '738'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('738','S','ENTI E ISTITUZIONI PRIVATE (108) ','AVIS, FP CGIL, FP CISL, FPL UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-12-31'},{d '2009-12-31'},'738',{d '2008-06-13'},'SANITA'': Dipendenti AVIS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '739')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AVIS, FP CGIL, FP CISL, FPL UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2009-12-31'},sortcode = '739',stipula = {d '2011-06-09'},title = 'SANITA'': Dirigenti AVIS' WHERE idccnl = '739'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('739','S','ENTI E ISTITUZIONI PRIVATE (108) ','AVIS, FP CGIL, FP CISL, FPL UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2009-12-31'},'739',{d '2011-06-09'},'SANITA'': Dirigenti AVIS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '740')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ARIS, CIMOP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-12-31'},sortcode = '740',stipula = {d '2009-04-07'},title = 'SANITA'': Personale medico area privata' WHERE idccnl = '740'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('740','S','ENTI E ISTITUZIONI PRIVATE (108) ','ARIS, CIMOP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-12-31'},'740',{d '2009-04-07'},'SANITA'': Personale medico area privata')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '741')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AIOP, CIMOP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2010-12-31'},sortcode = '741',stipula = {d '2009-02-11'},title = 'SANITA'': Personale medico area privata' WHERE idccnl = '741'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('741','S','ENTI E ISTITUZIONI PRIVATE (108) ','AIOP, CIMOP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2010-12-31'},'741',{d '2009-02-11'},'SANITA'': Personale medico area privata')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '742')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AIOP, CGIL FP, CISL FP, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2007-12-31'},sortcode = '742',stipula = {d '2010-09-15'},title = 'SANITA'': Personale non medico area privata' WHERE idccnl = '742'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('742','S','ENTI E ISTITUZIONI PRIVATE (108) ','AIOP, CGIL FP, CISL FP, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2007-12-31'},'742',{d '2010-09-15'},'SANITA'': Personale non medico area privata')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '743')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ARIS, CISL FP, UGL SANITA'' ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2007-12-31'},sortcode = '743',stipula = {d '2008-12-17'},title = 'SANITA'': Personale non medico area privata' WHERE idccnl = '743'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('743','S','ENTI E ISTITUZIONI PRIVATE (108) ','ARIS, CISL FP, UGL SANITA'' ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2007-12-31'},'743',{d '2008-12-17'},'SANITA'': Personale non medico area privata')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '744')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNCI, FIALS CONFSAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-03-31'},scadenza = {d '2011-04-01'},sortcode = '744',stipula = {d '2011-04-18'},title = 'SANITA'': Personale non medico Cooperative' WHERE idccnl = '744'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('744','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNCI, FIALS CONFSAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-03-31'},{d '2011-04-01'},'744',{d '2011-04-18'},'SANITA'': Personale non medico Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '745')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FILINS, UGL SCUOLA, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-08-31'},scadenza = {d '2017-09-01'},sortcode = '745',stipula = {d '2017-08-28'},title = 'SCUOLA NON STATALE (FILINS - UGL)' WHERE idccnl = '745'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('745','S','ENTI E ISTITUZIONI PRIVATE (108) ','FILINS, UGL SCUOLA, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-08-31'},{d '2017-09-01'},'745',{d '2017-08-28'},'SCUOLA NON STATALE (FILINS - UGL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '746')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleScuolaPrivataedEnti di Formazione, CONFINTESA, CONFINTESA LC',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-04-30'},scadenza = {d '2017-05-01'},sortcode = '746',stipula = {d '2017-04-26'},title = 'SCUOLA NON STATALE ED ENTI DI FORMAZIONE PROFESSIONALE (UNIMPRESA - CONFINTESA)' WHERE idccnl = '746'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('746','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNIMPRESA, UNIMPRESAFederazione NazionaleScuolaPrivataedEnti di Formazione, CONFINTESA, CONFINTESA LC',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-04-30'},{d '2017-05-01'},'746',{d '2017-04-26'},'SCUOLA NON STATALE ED ENTI DI FORMAZIONE PROFESSIONALE (UNIMPRESA - CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '747')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ESAARCO, ESAARCOScuola, ESAARCOUniversity, UGLScuola, FENALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2017-01-08'},sortcode = '747',stipula = {d '2017-01-08'},title = 'SCUOLA NON STATALE, AGENZIE FORMATIVE, FORMAZIONE PROFESSIONALE ED ALTA FORMAZIONE (ESAARCO)' WHERE idccnl = '747'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('747','S','ENTI E ISTITUZIONI PRIVATE (108) ','ESAARCO, ESAARCOScuola, ESAARCOUniversity, UGLScuola, FENALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2017-01-08'},'747',{d '2017-01-08'},'SCUOLA NON STATALE, AGENZIE FORMATIVE, FORMAZIONE PROFESSIONALE ED ALTA FORMAZIONE (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '748')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ANINSEICONFINDUSTRIAFEDERVARIE, FLCCGIL, CISLSCUOLA, UIL SCUOLA, SNALS CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2015-09-01'},sortcode = '748',stipula = {d '2016-01-26'},title = 'SCUOLA PRIVATE (ANINSEI)' WHERE idccnl = '748'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('748','S','ENTI E ISTITUZIONI PRIVATE (108) ','ANINSEICONFINDUSTRIAFEDERVARIE, FLCCGIL, CISLSCUOLA, UIL SCUOLA, SNALS CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2015-09-01'},'748',{d '2016-01-26'},'SCUOLA PRIVATE (ANINSEI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '749')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FLCCGIL, CISLSCUOLA, UILSCUOLA, SNALSCONFSAL, CGIL, CISL, UIL, FORMA, CENFOP, (adesione di UGL dall''11/12/2012)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-12-31'},scadenza = {d '2011-01-01'},sortcode = '749',stipula = {d '2012-06-08'},title = 'SCUOLE (Formazione Professionale sistema regionale)' WHERE idccnl = '749'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('749','S','ENTI E ISTITUZIONI PRIVATE (108) ','FLCCGIL, CISLSCUOLA, UILSCUOLA, SNALSCONFSAL, CGIL, CISL, UIL, FORMA, CENFOP, (adesione di UGL dall''11/12/2012)',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-12-31'},{d '2011-01-01'},'749',{d '2012-06-08'},'SCUOLE (Formazione Professionale sistema regionale)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '750')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FISM, FLC CGIL, CISL SCUOLA, UIL SCUOLA, SNALS CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2016-01-01'},sortcode = '750',stipula = {d '2016-12-12'},title = 'SCUOLE MATERNE NON STATALI' WHERE idccnl = '750'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('750','S','ENTI E ISTITUZIONI PRIVATE (108) ','FISM, FLC CGIL, CISL SCUOLA, UIL SCUOLA, SNALS CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2016-01-01'},'750',{d '2016-12-12'},'SCUOLE MATERNE NON STATALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '751')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ESAARCO, CEPAA, CEPAAScuola, CEPAAFedercoop, ESAARCOScuoleeFormazioneProfessionale, CIU, SICEL, FENALS, ONAPS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-10-11'},scadenza = {d '2016-10-12'},sortcode = '751',stipula = {d '2016-10-12'},title = 'SCUOLE NON STATALI (ESAARCO)' WHERE idccnl = '751'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('751','S','ENTI E ISTITUZIONI PRIVATE (108) ','ESAARCO, CEPAA, CEPAAScuola, CEPAAFedercoop, ESAARCOScuoleeFormazioneProfessionale, CIU, SICEL, FENALS, ONAPS',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-10-11'},{d '2016-10-12'},'751',{d '2016-10-12'},'SCUOLE NON STATALI (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '752')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FIINSEI, FIDEF, CONFIMPRESEITALIA, CONFALSCUOLA, FLPSCUOLA, CSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-08-31'},scadenza = {d '2015-09-01'},sortcode = '752',stipula = {d '2015-08-31'},title = 'SCUOLE NON STATALI (Fiinsei-Fidef-Confimpreseitalia)' WHERE idccnl = '752'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('752','S','ENTI E ISTITUZIONI PRIVATE (108) ','FIINSEI, FIDEF, CONFIMPRESEITALIA, CONFALSCUOLA, FLPSCUOLA, CSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-08-31'},{d '2015-09-01'},'752',{d '2015-08-31'},'SCUOLE NON STATALI (Fiinsei-Fidef-Confimpreseitalia)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '753')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FEDERTERZIARIOSCUOLA, FEDERTERZIARIO, CONFIMEA, CFC, UGL SCUOLA, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-08-31'},scadenza = {d '2017-09-01'},sortcode = '753',stipula = {d '2017-05-31'},title = 'SCUOLE NON STATALI,ENTI DI FORMAZIONE, SCUOLE DI PREPARAZIONE, SCUOLE DELL''INFANZIA, ASILI NIDO' WHERE idccnl = '753'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('753','S','ENTI E ISTITUZIONI PRIVATE (108) ','FEDERTERZIARIOSCUOLA, FEDERTERZIARIO, CONFIMEA, CFC, UGL SCUOLA, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-08-31'},{d '2017-09-01'},'753',{d '2017-05-31'},'SCUOLE NON STATALI,ENTI DI FORMAZIONE, SCUOLE DI PREPARAZIONE, SCUOLE DELL''INFANZIA, ASILI NIDO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '754')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ASILS, AISLI, UGL SCUOLA, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-04-30'},scadenza = {d '2015-05-01'},sortcode = '754',stipula = {d '2016-07-11'},title = 'SCUOLE NON STATALI: ASILS UGL' WHERE idccnl = '754'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('754','S','ENTI E ISTITUZIONI PRIVATE (108) ','ASILS, AISLI, UGL SCUOLA, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-04-30'},{d '2015-05-01'},'754',{d '2016-07-11'},'SCUOLE NON STATALI: ASILS UGL')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '755')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FIINSEI, FIDEF, CONFIMPRESEITALIA, CONFALSCUOLA, FLPSCUOLA, CSE',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-08-31'},scadenza = {d '2015-09-01'},sortcode = '755',stipula = {d '2015-08-31'},title = 'SCUOLE NON STATALI: Collaborazione Coordinata e Continuativa (Fiinsei-Fidef-Confimprese italia)' WHERE idccnl = '755'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('755','S','ENTI E ISTITUZIONI PRIVATE (108) ','FIINSEI, FIDEF, CONFIMPRESEITALIA, CONFALSCUOLA, FLPSCUOLA, CSE',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-08-31'},{d '2015-09-01'},'755',{d '2015-08-31'},'SCUOLE NON STATALI: Collaborazione Coordinata e Continuativa (Fiinsei-Fidef-Confimprese italia)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '756')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ASPA, UGL SCUOLA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-09-19'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-09-18'},scadenza = {d '2017-09-18'},sortcode = '756',stipula = {d '2013-11-28'},title = 'SCUOLE PARITARIE: ASPA UGL' WHERE idccnl = '756'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('756','S','ENTI E ISTITUZIONI PRIVATE (108) ','ASPA, UGL SCUOLA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-09-19'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-09-18'},{d '2017-09-18'},'756',{d '2013-11-28'},'SCUOLE PARITARIE: ASPA UGL')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '757')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AGIDAE, FLCCGIL, CISLSCUOLA, UILSCUOLA, SNALSCONFSAL, SINASCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2016-01-01'},sortcode = '757',stipula = {d '2016-07-07'},title = 'SCUOLE PRIVATE (Istituti Ecclesiastici - AGIDAE)' WHERE idccnl = '757'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('757','S','ENTI E ISTITUZIONI PRIVATE (108) ','AGIDAE, FLCCGIL, CISLSCUOLA, UILSCUOLA, SNALSCONFSAL, SINASCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2016-01-01'},'757',{d '2016-07-07'},'SCUOLE PRIVATE (Istituti Ecclesiastici - AGIDAE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '758')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FILINS, FIINSEI, AISPEF,(sottoscrizionediCNAIdal15/6/2010), CISAL, CISAL SCUOLA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-08-31'},scadenza = {d '2009-09-01'},sortcode = '758',stipula = {d '2009-05-03'},title = 'SCUOLE: Istituti d''Istruzione associati alla Filins-Fiinsei (collaborazione coordinata e continuativa a progetto)' WHERE idccnl = '758'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('758','S','ENTI E ISTITUZIONI PRIVATE (108) ','FILINS, FIINSEI, AISPEF,(sottoscrizionediCNAIdal15/6/2010), CISAL, CISAL SCUOLA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-08-31'},{d '2009-09-01'},'758',{d '2009-05-03'},'SCUOLE: Istituti d''Istruzione associati alla Filins-Fiinsei (collaborazione coordinata e continuativa a progetto)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '759')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FILINS, FIINSEI, CEFIR, CISAL TERZIARIO, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-08-31'},sortcode = '759',stipula = {d '2013-09-24'},title = 'SCUOLE:Licei Linguistici e Istituti d''Istruzione associati alla Filins-Fiinsei-Aispef' WHERE idccnl = '759'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('759','S','ENTI E ISTITUZIONI PRIVATE (108) ','FILINS, FIINSEI, CEFIR, CISAL TERZIARIO, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-08-31'},'759',{d '2013-09-24'},'SCUOLE:Licei Linguistici e Istituti d''Istruzione associati alla Filins-Fiinsei-Aispef')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '760')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-03-14'},scadenza = {d '2016-03-15'},sortcode = '760',stipula = {d '2016-03-15'},title = 'SERVIZI ALLA PERSONA: Cooperative' WHERE idccnl = '760'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('760','S','ENTI E ISTITUZIONI PRIVATE (108) ','SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-03-14'},{d '2016-03-15'},'760',{d '2016-03-15'},'SERVIZI ALLA PERSONA: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '761')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AIAS, FIALS, ISA ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2012-12-31'},scadenza = {d '2010-01-01'},sortcode = '761',stipula = {d '2011-10-05'},title = 'SERVIZI ASSISTENZIALI: Personale AIAS' WHERE idccnl = '761'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('761','S','ENTI E ISTITUZIONI PRIVATE (108) ','AIAS, FIALS, ISA ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-12-31'},{d '2010-01-01'},'761',{d '2011-10-05'},'SERVIZI ASSISTENZIALI: Personale AIAS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '762')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AIAS, UGL SANITA''',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '762',stipula = {d '2011-09-21'},title = 'SERVIZI ASSISTENZIALI: Personale AIAS' WHERE idccnl = '762'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('762','S','ENTI E ISTITUZIONI PRIVATE (108) ','AIAS, UGL SANITA''',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'762',{d '2011-09-21'},'SERVIZI ASSISTENZIALI: Personale AIAS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '763')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ANPAS, CGIL FP, CISL FP, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '763',stipula = {d '2014-01-17'},title = 'SERVIZI ASSISTENZIALI: Personale ANPAS' WHERE idccnl = '763'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('763','S','ENTI E ISTITUZIONI PRIVATE (108) ','ANPAS, CGIL FP, CISL FP, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'763',{d '2014-01-17'},'SERVIZI ASSISTENZIALI: Personale ANPAS')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '764')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FENASCOP, CISL FP, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '764',stipula = {d '2013-07-03'},title = 'SERVIZI ASSISTENZIALI: Personale FENASCOP' WHERE idccnl = '764'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('764','S','ENTI E ISTITUZIONI PRIVATE (108) ','FENASCOP, CISL FP, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'764',{d '2013-07-03'},'SERVIZI ASSISTENZIALI: Personale FENASCOP')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '765')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ISSIM, FILCAMS CGIL, FISASCAT CISL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '765',stipula = {d '2017-02-09'},title = 'SERVIZI ASSISTENZIALI: Personale ISSIM' WHERE idccnl = '765'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('765','S','ENTI E ISTITUZIONI PRIVATE (108) ','ISSIM, FILCAMS CGIL, FISASCAT CISL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'765',{d '2017-02-09'},'SERVIZI ASSISTENZIALI: Personale ISSIM')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '766')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ANPAS, CONFEDERAZIONEMISERICORDIE, CGILFP, CISLFP, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2009-12-31'},sortcode = '766',stipula = {d '2009-10-01'},title = 'SERVIZI ASSISTENZIALI: Personale MISERICORDIE' WHERE idccnl = '766'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('766','S','ENTI E ISTITUZIONI PRIVATE (108) ','ANPAS, CONFEDERAZIONEMISERICORDIE, CGILFP, CISLFP, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2009-12-31'},'766',{d '2009-10-01'},'SERVIZI ASSISTENZIALI: Personale MISERICORDIE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '767')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNCI, ANCOS, FIALS, CONFSAL FISALS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2007-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2011-06-30'},sortcode = '767',stipula = {d '2007-07-11'},title = 'SERVIZI SETTORE SOCIO-SANITARIO: Cooperative' WHERE idccnl = '767'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('767','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNCI, ANCOS, FIALS, CONFSAL FISALS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2011-06-30'},'767',{d '2007-07-11'},'SERVIZI SETTORE SOCIO-SANITARIO: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '768')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNCI, ANCOS, CISAL, CISAL Terziario',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-06-30'},scadenza = {d '2020-06-30'},sortcode = '768',stipula = {d '2017-02-15'},title = 'SERVIZI SETTORE SOCIO-SANITARIO: Cooperative sociali' WHERE idccnl = '768'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('768','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNCI, ANCOS, CISAL, CISAL Terziario',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-06-30'},{d '2020-06-30'},'768',{d '2017-02-15'},'SERVIZI SETTORE SOCIO-SANITARIO: Cooperative sociali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '769')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNIMPRESA, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-03-16'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-03-16'},sortcode = '769',stipula = {d '2009-03-16'},title = 'SERVIZI SOCIO-ASSISTENZIALI (UNIMPRESA)' WHERE idccnl = '769'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('769','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNIMPRESA, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-03-16'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-03-16'},'769',{d '2009-03-16'},'SERVIZI SOCIO-ASSISTENZIALI (UNIMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '770')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'AGCISOLIDARIETA'',LEGACOOPSOCIALI, FEDERSOLIDARIETA''CONFCOOPERATIVE, FP CGIL, CISL FP, FISASCAT CISL, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '770',stipula = {d '2011-12-16'},title = 'SERVIZI SOCIO-ASSISTENZIALI: Cooperative' WHERE idccnl = '770'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('770','S','ENTI E ISTITUZIONI PRIVATE (108) ','AGCISOLIDARIETA'',LEGACOOPSOCIALI, FEDERSOLIDARIETA''CONFCOOPERATIVE, FP CGIL, CISL FP, FISASCAT CISL, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'770',{d '2011-12-16'},'SERVIZI SOCIO-ASSISTENZIALI: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '771')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaleSanit?eWelfare, UNIMPRESAFederazione NazionaleOpereSociali, CONFINTESA, CONFINTESA Sanit?',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '771',stipula = {d '2017-05-04'},title = 'SETTORE SOCIO-SANITARIO-ASSISTENZIALE-EDUCATIVO (UNIMPRESA - CONFINTESA)' WHERE idccnl = '771'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('771','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNIMPRESA, UNIMPRESAFederazione NazionaleSanit?eWelfare, UNIMPRESAFederazione NazionaleOpereSociali, CONFINTESA, CONFINTESA Sanit?',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'771',{d '2017-05-04'},'SETTORE SOCIO-SANITARIO-ASSISTENZIALE-EDUCATIVO (UNIMPRESA - CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '772')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'CEPA A SANITA'', CEPA A, UGL SANITA''',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-05-23'},scadenza = {d '2016-05-22'},sortcode = '772',stipula = {d '2013-05-23'},title = 'STRUTTURE E COOPERATIVE SOCIOSANITARIE E ASSISTENZIALI: Personale non medico' WHERE idccnl = '772'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('772','S','ENTI E ISTITUZIONI PRIVATE (108) ','CEPA A SANITA'', CEPA A, UGL SANITA''',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-05-23'},{d '2016-05-22'},'772',{d '2013-05-23'},'STRUTTURE E COOPERATIVE SOCIOSANITARIE E ASSISTENZIALI: Personale non medico')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '773')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'CEPA A SANITA'', CEPA A, UGL SANITA''',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-23'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2015-05-22'},scadenza = {d '2016-05-22'},sortcode = '773',stipula = {d '2013-05-23'},title = 'STRUTTURE SANITARIE PRIVATE: Personale Dipendente' WHERE idccnl = '773'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('773','S','ENTI E ISTITUZIONI PRIVATE (108) ','CEPA A SANITA'', CEPA A, UGL SANITA''',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-23'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-05-22'},{d '2016-05-22'},'773',{d '2013-05-23'},'STRUTTURE SANITARIE PRIVATE: Personale Dipendente')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '774')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'ERSAF, CEUQ, CONFEDIR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '774',stipula = {d '2017-07-05'},title = 'STRUTTURE SANITARIE, SOCIO-SANITARIE E COOPERATIVE SOCIOSANITARIE ASSISTENZIALI ED EDUCATIVE PRIVATE: personale non medico (ERSAF-CEUQ-CONFEDIR)' WHERE idccnl = '774'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('774','S','ENTI E ISTITUZIONI PRIVATE (108) ','ERSAF, CEUQ, CONFEDIR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'774',{d '2017-07-05'},'STRUTTURE SANITARIE, SOCIO-SANITARIE E COOPERATIVE SOCIOSANITARIE ASSISTENZIALI ED EDUCATIVE PRIVATE: personale non medico (ERSAF-CEUQ-CONFEDIR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '775')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FEDERTERZIARIO, CONFIMEA, CFC, UGL SANITA''',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-07-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-06-30'},sortcode = '775',stipula = {d '2014-06-18'},title = 'STRUTTURE SANITARIE, SOCIO-SANITARIEECOOPERATIVESOCIOSANITARIEEDASSISTENZIALI PRIVATE: Personale non medico' WHERE idccnl = '775'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('775','S','ENTI E ISTITUZIONI PRIVATE (108) ','FEDERTERZIARIO, CONFIMEA, CFC, UGL SANITA''',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-07-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-06-30'},'775',{d '2014-06-18'},'STRUTTURE SANITARIE, SOCIO-SANITARIEECOOPERATIVESOCIOSANITARIEEDASSISTENZIALI PRIVATE: Personale non medico')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '776')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FMPI CONAPI, CONAPI, CNAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-15'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-05-14'},sortcode = '776',stipula = {d '2017-05-15'},title = 'STRUTTURE SANITARIE, SOCIO-SANITARIE E COOPERATIVE SOCIOSANITARIE ED ASSISTENZIALI PRIVATE: personale non medico (CONAPI-CNAL)' WHERE idccnl = '776'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('776','S','ENTI E ISTITUZIONI PRIVATE (108) ','FMPI CONAPI, CONAPI, CNAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-15'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-05-14'},'776',{d '2017-05-15'},'STRUTTURE SANITARIE, SOCIO-SANITARIE E COOPERATIVE SOCIOSANITARIE ED ASSISTENZIALI PRIVATE: personale non medico (CONAPI-CNAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '777')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'FMPICONAPI, CONAPI, CONFINTESA, CONFINTESASanit?Nazionale',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-03'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-31'},sortcode = '777',stipula = {d '2017-04-03'},title = 'STRUTTURE SANITARIE, SOCIO-SANITARIE E COOPERATIVE SOCIOSANITARIE ED ASSISTENZIALI PRIVATE: personale non medico (CONAPI-CONFINTESA)' WHERE idccnl = '777'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('777','S','ENTI E ISTITUZIONI PRIVATE (108) ','FMPICONAPI, CONAPI, CONFINTESA, CONFINTESASanit?Nazionale',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-03'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-31'},'777',{d '2017-04-03'},'STRUTTURE SANITARIE, SOCIO-SANITARIE E COOPERATIVE SOCIOSANITARIE ED ASSISTENZIALI PRIVATE: personale non medico (CONAPI-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '778')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNSIC, UNSICOOP, CONFIAL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-07-31'},sortcode = '778',stipula = {d '2017-07-27'},title = 'Terzo Settore (UNSIC-UNSICOOP-CONFIAL)' WHERE idccnl = '778'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('778','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNSIC, UNSICOOP, CONFIAL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-07-31'},'778',{d '2017-07-27'},'Terzo Settore (UNSIC-UNSICOOP-CONFIAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '779')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UIL, Personale UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-12-31'},scadenza = {d '2009-01-01'},sortcode = '779',stipula = {d '2009-02-20'},title = 'UIL (Lavoratori Dipendenti)' WHERE idccnl = '779'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('779','S','ENTI E ISTITUZIONI PRIVATE (108) ','UIL, Personale UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-31'},{d '2009-01-01'},'779',{d '2009-02-20'},'UIL (Lavoratori Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '780')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNICOOP, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-12-31'},scadenza = {d '2009-01-01'},sortcode = '780',stipula = {d '2009-01-12'},title = 'UNICOOP (Lavoratori Dipendenti)' WHERE idccnl = '780'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('780','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNICOOP, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-31'},{d '2009-01-01'},'780',{d '2009-01-12'},'UNICOOP (Lavoratori Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '781')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNIVERSITA''TELEMATICANONSTATALEGIUSTINOFORTUNATO, CISL UNIVERSITA''',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2008-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2010-12-31'},scadenza = {d '2012-12-31'},sortcode = '781',stipula = {d '2008-01-23'},title = 'UNIVERSITA'' TELEMATICA ''GIUSTINO FORTUNATO''' WHERE idccnl = '781'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('781','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNIVERSITA''TELEMATICANONSTATALEGIUSTINOFORTUNATO, CISL UNIVERSITA''',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-12-31'},{d '2012-12-31'},'781',{d '2008-01-23'},'UNIVERSITA'' TELEMATICA ''GIUSTINO FORTUNATO''')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '782')
UPDATE [ccnl] SET active = 'S',area = 'ENTI E ISTITUZIONI PRIVATE (108) ',contraenti = 'UNIPEGASOUNIVERSITA''TELEMATICA, ANPIT, CSACISALUNIVERSITA'', CISAL TERZIARIO, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-08-31'},scadenza = {d '2013-09-01'},sortcode = '782',stipula = {d '2013-09-03'},title = 'UNIVERSITA'' TELEMATICHE E SERVIZI COLLEGATI' WHERE idccnl = '782'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('782','S','ENTI E ISTITUZIONI PRIVATE (108) ','UNIPEGASOUNIVERSITA''TELEMATICA, ANPIT, CSACISALUNIVERSITA'', CISAL TERZIARIO, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-31'},{d '2013-09-01'},'782',{d '2013-09-03'},'UNIVERSITA'' TELEMATICHE E SERVIZI COLLEGATI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '783')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ASSOLAVORO, CGIL, CISL, UIL, FELSACISL,NIDILCGIL, UILTEMP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2014-01-01'},sortcode = '783',stipula = {d '2014-02-27'},title = 'Agenzie di Somministrazione di Lavoro (ASSOLAVORO)' WHERE idccnl = '783'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('783','S','ALTRI VARI (82) ','ASSOLAVORO, CGIL, CISL, UIL, FELSACISL,NIDILCGIL, UILTEMP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2014-01-01'},'783',{d '2014-02-27'},'Agenzie di Somministrazione di Lavoro (ASSOLAVORO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '784')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ASSOSOMM, CGIL, CISL, UIL, FELSA CISL, NIDIL CGIL, UILTEMP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-12-31'},scadenza = {d '2014-01-01'},sortcode = '784',stipula = {d '2014-04-07'},title = 'Agenzie di Somministrazione di Lavoro (ASSOSOMM)' WHERE idccnl = '784'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('784','S','ALTRI VARI (82) ','ASSOSOMM, CGIL, CISL, UIL, FELSA CISL, NIDIL CGIL, UILTEMP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-31'},{d '2014-01-01'},'784',{d '2014-04-07'},'Agenzie di Somministrazione di Lavoro (ASSOSOMM)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '785')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'MINISTERODELLAVOROEDELLEPOLITICHESOCIALI,MINISTERO DEGLI AFFARI ESTERI, CGIL, CISL FP, UIL PA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2017-01-01'},sortcode = '785',stipula = {d '2017-01-30'},title = 'AMBASCIATE E ORGAN. INTERNAZ. (Dipendenti)' WHERE idccnl = '785'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('785','S','ALTRI VARI (82) ','MINISTERODELLAVOROEDELLEPOLITICHESOCIALI,MINISTERO DEGLI AFFARI ESTERI, CGIL, CISL FP, UIL PA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2017-01-01'},'785',{d '2017-01-30'},'AMBASCIATE E ORGAN. INTERNAZ. (Dipendenti)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '786')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CNAFedermoda, CNAProduzione, CNAArtisticoeTradizionale, CNAServiziallacomunit?, CONFARTIGIANATOModa, CONFARTIGIANATOChimica, CONFARTIGIANATOCeramica, CASARTIGIANI, CLAAI, FILCTEM CGIL, FEMCA CISL, UILTEC UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '786',stipula = {d '2017-12-14'},title = 'Area TESSILE MODA e CHIMICA CERAMICA (Artigiane)' WHERE idccnl = '786'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('786','S','ALTRI VARI (82) ','CNAFedermoda, CNAProduzione, CNAArtisticoeTradizionale, CNAServiziallacomunit?, CONFARTIGIANATOModa, CONFARTIGIANATOChimica, CONFARTIGIANATOCeramica, CASARTIGIANI, CLAAI, FILCTEM CGIL, FEMCA CISL, UILTEC UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'786',{d '2017-12-14'},'Area TESSILE MODA e CHIMICA CERAMICA (Artigiane)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '787')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFIMPRESEITALIA, CONFIMPRESEITALIACoordinamentoTerzoSettore, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-03-24'},scadenza = {d '2016-03-25'},sortcode = '787',stipula = {d '2016-03-25'},title = 'ASSOCIAZIONI ED ALTRE ORGANIZZAZIONI DEL TERZO SETTORE' WHERE idccnl = '787'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('787','S','ALTRI VARI (82) ','CONFIMPRESEITALIA, CONFIMPRESEITALIACoordinamentoTerzoSettore, FESICA CONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-03-24'},{d '2016-03-25'},'787',{d '2016-03-25'},'ASSOCIAZIONI ED ALTRE ORGANIZZAZIONI DEL TERZO SETTORE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '788')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNSIC, UNSICOOP, ASNALI, FNACONFSAL, SNALVCONFSAL, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-05-31'},scadenza = {d '2016-06-01'},sortcode = '788',stipula = {d '2016-05-19'},title = 'ATTIVITA'' STAGIONALE' WHERE idccnl = '788'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('788','S','ALTRI VARI (82) ','UNSIC, UNSICOOP, ASNALI, FNACONFSAL, SNALVCONFSAL, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-05-31'},{d '2016-06-01'},'788',{d '2016-05-19'},'ATTIVITA'' STAGIONALE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '789')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNSIC, FEDERDAT, CONFIAL, CONSIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-07-31'},scadenza = {d '2016-08-01'},sortcode = '789',stipula = {d '2016-07-21'},title = 'AZIENDE ARTIGIANE (UNSIC-FEDERDAT-CONFIAL-CONSIL)' WHERE idccnl = '789'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('789','S','ALTRI VARI (82) ','UNSIC, FEDERDAT, CONFIAL, CONSIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-07-31'},{d '2016-08-01'},'789',{d '2016-07-21'},'AZIENDE ARTIGIANE (UNSIC-FEDERDAT-CONFIAL-CONSIL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '790')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFIMPRENDITORI, USIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-03-08'},scadenza = {d '2015-03-09'},sortcode = '790',stipula = {d '2015-03-05'},title = 'AZIENDE ARTIGIANE, DEL SETTORE INDUSTRIA E COOPERATIVE' WHERE idccnl = '790'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('790','S','ALTRI VARI (82) ','CONFIMPRENDITORI, USIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-03-08'},{d '2015-03-09'},'790',{d '2015-03-05'},'AZIENDE ARTIGIANE, DEL SETTORE INDUSTRIA E COOPERATIVE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '791')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'JCPCITALY, U.S.NAVALFORCES, U.S.ARMY, U.S.AIRFORCES, UILTUCS, FISASCAT CISL, CISL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-10-31'},scadenza = {d '2013-11-01'},sortcode = '791',stipula = {d '2013-09-06'},title = 'BASI USA Dipendenti Civili non Statunitensi' WHERE idccnl = '791'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('791','S','ALTRI VARI (82) ','JCPCITALY, U.S.NAVALFORCES, U.S.ARMY, U.S.AIRFORCES, UILTUCS, FISASCAT CISL, CISL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-10-31'},{d '2013-11-01'},'791',{d '2013-09-06'},'BASI USA Dipendenti Civili non Statunitensi')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '792')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'COMFIE, ASSEOPE, CONFAEL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2017-09-30'},scadenza = {d '2014-10-01'},sortcode = '792',stipula = {d '2014-09-02'},title = 'CODISTA: PMI di tutti i settori produttivi' WHERE idccnl = '792'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('792','S','ALTRI VARI (82) ','COMFIE, ASSEOPE, CONFAEL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-09-30'},{d '2014-10-01'},'792',{d '2014-09-02'},'CODISTA: PMI di tutti i settori produttivi')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '793')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ANASFIM, SERIM CONSULTING, CLACS CISL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-12-31'},scadenza = {d '2009-01-01'},sortcode = '793',stipula = {d '2008-11-18'},title = 'COLLABORAZIONI autonome agenzie marketing' WHERE idccnl = '793'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('793','S','ALTRI VARI (82) ','ANASFIM, SERIM CONSULTING, CLACS CISL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-12-31'},{d '2009-01-01'},'793',{d '2008-11-18'},'COLLABORAZIONI autonome agenzie marketing')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '794')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ANCIC, ASSEPRIM, ASSINTEL, FEDERTELSERVIZI, CONFCOMMERCIO, CONFCOMMERCIOMILANO, FILCAMSCGIL, FISASCAT CISL, UILTUCS UIL, NIDIL CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2018-12-31'},scadenza = {d '2016-07-14'},sortcode = '794',stipula = {d '2016-07-14'},title = 'COLLABORAZIONI Coordinate e Continuative (CallCenter, Servizinonditelefonia, Servizirealizzatiattraverso operatori telefonici)' WHERE idccnl = '794'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('794','S','ALTRI VARI (82) ','ANCIC, ASSEPRIM, ASSINTEL, FEDERTELSERVIZI, CONFCOMMERCIO, CONFCOMMERCIOMILANO, FILCAMSCGIL, FISASCAT CISL, UILTUCS UIL, NIDIL CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-12-31'},{d '2016-07-14'},'794',{d '2016-07-14'},'COLLABORAZIONI Coordinate e Continuative (CallCenter, Servizinonditelefonia, Servizirealizzatiattraverso operatori telefonici)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '795')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CISI, FAICA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2004-04-03'},scadenza = {d '2000-04-04'},sortcode = '795',stipula = {d '2000-04-04'},title = 'COLLABORAZIONI Coordinate e Continuative (CISI)' WHERE idccnl = '795'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('795','S','ALTRI VARI (82) ','CISI, FAICA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2004-04-03'},{d '2000-04-04'},'795',{d '2000-04-04'},'COLLABORAZIONI Coordinate e Continuative (CISI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '796')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FEDERTERZIARIO, FEDERTERZIARIO SUD, ALE UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2002-09-30'},scadenza = {d '2000-10-01'},sortcode = '796',stipula = {d '2000-10-03'},title = 'COLLABORAZIONI Coordinate e Continuative (FEDERTERZIARIO)' WHERE idccnl = '796'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('796','S','ALTRI VARI (82) ','FEDERTERZIARIO, FEDERTERZIARIO SUD, ALE UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2002-09-30'},{d '2000-10-01'},'796',{d '2000-10-03'},'COLLABORAZIONI Coordinate e Continuative (FEDERTERZIARIO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '797')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'INTERSOS, ALAI CISL, CGIL NIDIL, CPO UIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2003-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2006-01-31'},sortcode = '797',stipula = {d '2003-01-20'},title = 'COLLABORAZIONI Coordinate e Continuative (INTERSOS)' WHERE idccnl = '797'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('797','S','ALTRI VARI (82) ','INTERSOS, ALAI CISL, CGIL NIDIL, CPO UIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2003-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2006-01-31'},'797',{d '2003-01-20'},'COLLABORAZIONI Coordinate e Continuative (INTERSOS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '798')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'PROFESSIONE IN FAMIGLIA, UNAI, UIL FPL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '798',stipula = {d '2016-11-28'},title = 'COLLABORAZIONI Coordinate e Continuative (Servizidi assistenza famigliare integrativi e sostitutivi)' WHERE idccnl = '798'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('798','S','ALTRI VARI (82) ','PROFESSIONE IN FAMIGLIA, UNAI, UIL FPL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'798',{d '2016-11-28'},'COLLABORAZIONI Coordinate e Continuative (Servizidi assistenza famigliare integrativi e sostitutivi)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '799')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'PROFESSIONE IN FAMIGLIA CONFASSOCIAZIONI, UNAI, SUL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-04-07'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '799',stipula = {d '2016-04-07'},title = 'COLLABORAZIONI Coordinate e Continuative (Servizidi assistenza famigliare integrativi e sostitutivi)' WHERE idccnl = '799'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('799','S','ALTRI VARI (82) ','PROFESSIONE IN FAMIGLIA CONFASSOCIAZIONI, UNAI, SUL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-04-07'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'799',{d '2016-04-07'},'COLLABORAZIONI Coordinate e Continuative (Servizidi assistenza famigliare integrativi e sostitutivi)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '800')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNPEC, CONFILL, FILC, CUSAL, CASIL, CISMI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '1998-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2002-12-31'},sortcode = '800',stipula = {d '1998-10-29'},title = 'COLLABORAZIONI Coordinate e Continuative (UNPEC)' WHERE idccnl = '800'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('800','S','ALTRI VARI (82) ','UNPEC, CONFILL, FILC, CUSAL, CASIL, CISMI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '1998-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2002-12-31'},'800',{d '1998-10-29'},'COLLABORAZIONI Coordinate e Continuative (UNPEC)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '801')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ANCORS, SAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-02-25'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-02-24'},sortcode = '801',stipula = {d '2013-01-24'},title = 'COMMERCIO, TERZIARIO, DISTRIBUZIONE, TRASPORTI E SERVIZI' WHERE idccnl = '801'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('801','S','ALTRI VARI (82) ','ANCORS, SAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-02-25'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-02-24'},'801',{d '2013-01-24'},'COMMERCIO, TERZIARIO, DISTRIBUZIONE, TRASPORTI E SERVIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '802')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'NORD INDUSTRIALE, FAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-04-30'},sortcode = '802',stipula = {d '2015-04-30'},title = 'COMMERCIO, TERZIARIO, SERVIZI, TRASPORTI E LOGISTICA, ARTIGIANATO (NORDINDUSTRIALE-FAL)' WHERE idccnl = '802'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('802','S','ALTRI VARI (82) ','NORD INDUSTRIALE, FAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-04-30'},'802',{d '2015-04-30'},'COMMERCIO, TERZIARIO, SERVIZI, TRASPORTI E LOGISTICA, ARTIGIANATO (NORDINDUSTRIALE-FAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '803')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'LAIF, ANPIT, CISAL TERZIARIO, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2022-01-31'},sortcode = '803',stipula = {d '2018-02-05'},title = 'Dipendenti da Aziende esercenti LAVORAZIONI CONTO TERZI A FACON' WHERE idccnl = '803'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('803','S','ALTRI VARI (82) ','LAIF, ANPIT, CISAL TERZIARIO, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2022-01-31'},'803',{d '2018-02-05'},'Dipendenti da Aziende esercenti LAVORAZIONI CONTO TERZI A FACON')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '804')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FEDERAZIENDE, FEDERDIPENDENTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-12-31'},sortcode = '804',stipula = {d '2013-01-01'},title = 'Dipendenti del Settore ARTIGIANATO' WHERE idccnl = '804'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('804','S','ALTRI VARI (82) ','FEDERAZIENDE, FEDERDIPENDENTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-12-31'},'804',{d '2013-01-01'},'Dipendenti del Settore ARTIGIANATO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '805')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FIDAP IMPRESE, FISAL ITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2021-12-31'},sortcode = '805',stipula = {d '2017-10-27'},title = 'Dipendenti del Settore ARTIGIANATO ad esclusione del Settore Edile (FIDAP IMPRESE - FISAL ITALIA)' WHERE idccnl = '805'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('805','S','ALTRI VARI (82) ','FIDAP IMPRESE, FISAL ITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2021-12-31'},'805',{d '2017-10-27'},'Dipendenti del Settore ARTIGIANATO ad esclusione del Settore Edile (FIDAP IMPRESE - FISAL ITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '806')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'MIDA, SNIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-05-16'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-16'},sortcode = '806',stipula = {d '2013-04-16'},title = 'Dipendenti delle PICCOLE E MEDIE IMPRESE-MIDA-SNIAL' WHERE idccnl = '806'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('806','S','ALTRI VARI (82) ','MIDA, SNIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-05-16'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-16'},'806',{d '2013-04-16'},'Dipendenti delle PICCOLE E MEDIE IMPRESE-MIDA-SNIAL')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '807')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'AF24, ANOP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-11-13'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-11-12'},sortcode = '807',stipula = {d '2017-11-03'},title = 'Dipendenti in ambiti riguardanti la Sicurezza sul Lavoro' WHERE idccnl = '807'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('807','S','ALTRI VARI (82) ','AF24, ANOP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-11-13'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-11-12'},'807',{d '2017-11-03'},'Dipendenti in ambiti riguardanti la Sicurezza sul Lavoro')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '808')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNSIC, ASNALI, SNALVCONFSAL, FNACONFSAL, CONFIAL, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '808',stipula = {d '2015-01-29'},title = 'DIPENDENTI ORGANIZZAZIONI SINDACALI' WHERE idccnl = '808'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('808','S','ALTRI VARI (82) ','UNSIC, ASNALI, SNALVCONFSAL, FNACONFSAL, CONFIAL, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'808',{d '2015-01-29'},'DIPENDENTI ORGANIZZAZIONI SINDACALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '809')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFEURO, EUROTER, EUROFORM, EUROSIL, ASPI, E-ACADEMY',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-12-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-30'},sortcode = '809',stipula = {d '2015-11-18'},title = 'DIPENDENTI ORGANIZZAZIONI SINDACALI (CONFEURO)' WHERE idccnl = '809'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('809','S','ALTRI VARI (82) ','CONFEURO, EUROTER, EUROFORM, EUROSIL, ASPI, E-ACADEMY',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-12-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-30'},'809',{d '2015-11-18'},'DIPENDENTI ORGANIZZAZIONI SINDACALI (CONFEURO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '810')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FENAPI, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '810',stipula = {d '2011-07-27'},title = 'DIRIGENTI e QUADRI (FENAPI)' WHERE idccnl = '810'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('810','S','ALTRI VARI (82) ','FENAPI, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'810',{d '2011-07-27'},'DIRIGENTI e QUADRI (FENAPI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '811')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNIMPRESA, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-03-19'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-03-19'},sortcode = '811',stipula = {d '2009-03-19'},title = 'DIRIGENTI e QUADRI (UNIMPRESA)' WHERE idccnl = '811'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('811','S','ALTRI VARI (82) ','UNIMPRESA, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-03-19'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-03-19'},'811',{d '2009-03-19'},'DIRIGENTI e QUADRI (UNIMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '812')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFINDUSTRIA, FEDERMANAGER',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '812',stipula = {d '2014-12-30'},title = 'DIRIGENTI: Aziende Industriali' WHERE idccnl = '812'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('812','S','ALTRI VARI (82) ','CONFINDUSTRIA, FEDERMANAGER',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'812',{d '2014-12-30'},'DIRIGENTI: Aziende Industriali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '813')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'LEGACOOP, AGCI, CGIL, CISL, UIL, CoordinamentoNazionaleCGIL-CISL-UIL dei Dirigenti di Azienda delle Imprese Cooperative',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2012-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2014-12-31'},sortcode = '813',stipula = {d '2013-09-30'},title = 'DIRIGENTI: Cooperative' WHERE idccnl = '813'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('813','S','ALTRI VARI (82) ','LEGACOOP, AGCI, CGIL, CISL, UIL, CoordinamentoNazionaleCGIL-CISL-UIL dei Dirigenti di Azienda delle Imprese Cooperative',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2012-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2014-12-31'},'813',{d '2013-09-30'},'DIRIGENTI: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '814')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FCA, CNH INDUSTRIAL, FEDERMANAGER',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '814',stipula = {d '2016-03-02'},title = 'DIRIGENTI: FIAT' WHERE idccnl = '814'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('814','S','ALTRI VARI (82) ','FCA, CNH INDUSTRIAL, FEDERMANAGER',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'814',{d '2016-03-02'},'DIRIGENTI: FIAT')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '815')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFSERVIZI, FEDERMANAGER',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-12-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '815',stipula = {d '2009-12-22'},title = 'DIRIGENTI: Imprese Pubbliche Locali' WHERE idccnl = '815'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('815','S','ALTRI VARI (82) ','CONFSERVIZI, FEDERMANAGER',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'815',{d '2009-12-22'},'DIRIGENTI: Imprese Pubbliche Locali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '816')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CISPEL, FEDERMANAGER ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2009-12-22'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '816',stipula = {d '2009-12-22'},title = 'DIRIGENTI: Imprese Pubbliche Locali' WHERE idccnl = '816'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('816','S','ALTRI VARI (82) ','CISPEL, FEDERMANAGER ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2009-12-22'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'816',{d '2009-12-22'},'DIRIGENTI: Imprese Pubbliche Locali')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '817')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFAPI, FEDERMANAGER',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '817',stipula = {d '2010-12-22'},title = 'DIRIGENTI: P.M.I.' WHERE idccnl = '817'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('817','S','ALTRI VARI (82) ','CONFAPI, FEDERMANAGER',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'817',{d '2010-12-22'},'DIRIGENTI: P.M.I.')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '818')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UAI, UNAPRI, ASSIDAL, ANIF, CONFSALFASPI, FEDARMEC, CONFSAAP, FIRAS SPP, UIPS, ALPPI, IMMEXA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-07-27'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-26'},sortcode = '818',stipula = {d '2016-07-27'},title = 'ENTIEPMIESERCENTILAFORMAZIONEPROFESSIONALE' WHERE idccnl = '818'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('818','S','ALTRI VARI (82) ','UAI, UNAPRI, ASSIDAL, ANIF, CONFSALFASPI, FEDARMEC, CONFSAAP, FIRAS SPP, UIPS, ALPPI, IMMEXA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-07-27'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-26'},'818',{d '2016-07-27'},'ENTIEPMIESERCENTILAFORMAZIONEPROFESSIONALE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '819')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CEPI UCI, ANFOS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-07-10'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-07-09'},sortcode = '819',stipula = {d '2017-07-10'},title = 'FORMATORINELCAMPODELLASICUREZZASUILUOGHI DI LAVORO (CEPI UCI - ANFOS)' WHERE idccnl = '819'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('819','S','ALTRI VARI (82) ','CEPI UCI, ANFOS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-07-10'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-07-09'},'819',{d '2017-07-10'},'FORMATORINELCAMPODELLASICUREZZASUILUOGHI DI LAVORO (CEPI UCI - ANFOS)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '820')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFINNOVA, FEDERSICUREZZA ITALIA, FIADEL CISAL, SINAST',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-09-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-08-31'},sortcode = '820',stipula = {d '2016-09-06'},title = 'FORMATORINELCAMPODELLASICUREZZASUILUOGHIDILAVORO (CONFINNOVA-FEDERSICUREZZA ITALIA-FIADEL CISAL-SINAST)' WHERE idccnl = '820'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('820','S','ALTRI VARI (82) ','CONFINNOVA, FEDERSICUREZZA ITALIA, FIADEL CISAL, SINAST',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-09-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-08-31'},'820',{d '2016-09-06'},'FORMATORINELCAMPODELLASICUREZZASUILUOGHIDILAVORO (CONFINNOVA-FEDERSICUREZZA ITALIA-FIADEL CISAL-SINAST)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '821')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNIMPRESA, UNIMPRESAFederazione NazionaledeiServizi, UNIMPRESAFederazione Nazionale dell''Agricoltura, UNIMPRESAFederazione Nazionale dell''Edilizia, CONFINTESA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-05-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-04-30'},sortcode = '821',stipula = {d '2017-04-26'},title = 'FORMATORINELCAMPODELLASICUREZZASUILUOGHI DI LAVORO (UNIMPRESA-CONFINTESA)' WHERE idccnl = '821'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('821','S','ALTRI VARI (82) ','UNIMPRESA, UNIMPRESAFederazione NazionaledeiServizi, UNIMPRESAFederazione Nazionale dell''Agricoltura, UNIMPRESAFederazione Nazionale dell''Edilizia, CONFINTESA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-05-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-04-30'},'821',{d '2017-04-26'},'FORMATORINELCAMPODELLASICUREZZASUILUOGHI DI LAVORO (UNIMPRESA-CONFINTESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '822')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFIMEA, ADIFER, AECP, ASSIMPRESAITALIA, CONF.AUTONOMIAUTOTRASPORTATORI, FEDERTERZIARIOSUD,ITALIA IMPRESA, UNICA, FISMIC, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-05-31'},scadenza = {d '2015-05-31'},sortcode = '822',stipula = {d '2011-09-08'},title = 'FORMAZIONE E ORIENTAMENTO, SICUREZZA SUL LAVORO, QUALITA'' E AMBIENTE (CONFIMEA)' WHERE idccnl = '822'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('822','S','ALTRI VARI (82) ','CONFIMEA, ADIFER, AECP, ASSIMPRESAITALIA, CONF.AUTONOMIAUTOTRASPORTATORI, FEDERTERZIARIOSUD,ITALIA IMPRESA, UNICA, FISMIC, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-05-31'},{d '2015-05-31'},'822',{d '2011-09-08'},'FORMAZIONE E ORIENTAMENTO, SICUREZZA SUL LAVORO, QUALITA'' E AMBIENTE (CONFIMEA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '823')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVAsgsl, FITRAITALIA, ASSOCIAZIONEEspertiAmbientali.it, UNAIT, CICAS, ASSOAPI, CEPIUCI, CONFITIP, CONFUNISCO, FEDERIMPRESEITALIA, FENAILP, CONFLAI, FENALCA,ISASindacato, SIASO CONFSAL, SITLAV, UNION FORMATORI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-11-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-10-31'},sortcode = '823',stipula = {d '2015-10-15'},title = 'FORMAZIONEEORIENTAMENTO, SICUREZZASULLAVORO, QUALITA'' E AMBIENTE (ITALIA IMPRESA)' WHERE idccnl = '823'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('823','S','ALTRI VARI (82) ','ITALIAIMPRESA, ASSOCIAZIONEIMPRESEITALIANE, AIVAsgsl, FITRAITALIA, ASSOCIAZIONEEspertiAmbientali.it, UNAIT, CICAS, ASSOAPI, CEPIUCI, CONFITIP, CONFUNISCO, FEDERIMPRESEITALIA, FENAILP, CONFLAI, FENALCA,ISASindacato, SIASO CONFSAL, SITLAV, UNION FORMATORI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-11-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-10-31'},'823',{d '2015-10-15'},'FORMAZIONEEORIENTAMENTO, SICUREZZASULLAVORO, QUALITA'' E AMBIENTE (ITALIA IMPRESA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '824')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'AIFES, AIESIL, UGL TERZIARIO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '824',stipula = {d '2014-07-18'},title = 'FORMAZIONE E ORIENTAMENTO, SICUREZZA SUL LAVORO, QUALITA''EAMBIENTE, SORVEGLIANZAANTINCENDIO' WHERE idccnl = '824'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('824','S','ALTRI VARI (82) ','AIFES, AIESIL, UGL TERZIARIO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'824',{d '2014-07-18'},'FORMAZIONE E ORIENTAMENTO, SICUREZZA SUL LAVORO, QUALITA''EAMBIENTE, SORVEGLIANZAANTINCENDIO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '825')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'SINALF, ASFORM',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '825',stipula = {d '2017-01-09'},title = 'FORMAZIONE SICUREZZA E MACCHINE INDUSTRIALI' WHERE idccnl = '825'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('825','S','ALTRI VARI (82) ','SINALF, ASFORM',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'825',{d '2017-01-09'},'FORMAZIONE SICUREZZA E MACCHINE INDUSTRIALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '826')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNSIC, UNSICOOP, CONFIAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-31'},sortcode = '826',stipula = {d '2017-04-04'},title = 'GRANDE CARPENTERIA, SALDATURA E MOLATURA' WHERE idccnl = '826'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('826','S','ALTRI VARI (82) ','UNSIC, UNSICOOP, CONFIAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-31'},'826',{d '2017-04-04'},'GRANDE CARPENTERIA, SALDATURA E MOLATURA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '827')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FOR ITALY, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-02-09'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '827',stipula = {d '2017-02-09'},title = 'IMPRESE OPERANTI NEL SETTORE MANIFATTURIERO, PRODUZIONE E FABBRICAZIONE DI BENI (FOR.ITALY-FAMAR)' WHERE idccnl = '827'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('827','S','ALTRI VARI (82) ','FOR ITALY, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-02-09'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'827',{d '2017-02-09'},'IMPRESE OPERANTI NEL SETTORE MANIFATTURIERO, PRODUZIONE E FABBRICAZIONE DI BENI (FOR.ITALY-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '828')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FIDAP IMPRESE, FISAL ITALIA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2021-12-31'},sortcode = '828',stipula = {d '2017-11-20'},title = 'INDUSTRIA (FIDAP IMPRESE - FISAL ITALIA)' WHERE idccnl = '828'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('828','S','ALTRI VARI (82) ','FIDAP IMPRESE, FISAL ITALIA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2021-12-31'},'828',{d '2017-11-20'},'INDUSTRIA (FIDAP IMPRESE - FISAL ITALIA)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '829')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-05-31'},sortcode = '829',stipula = {d '2017-06-01'},title = 'INDUSTRIE (FAPI -CESAC - FILDI CIU)' WHERE idccnl = '829'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('829','S','ALTRI VARI (82) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-05-31'},'829',{d '2017-06-01'},'INDUSTRIE (FAPI -CESAC - FILDI CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '830')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ISTITUTOCENTRALEPERILSOSTENTAMENTODELCLERO, CONFCOMMERCIO, UGL COMMERCIO E TURISMO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '830',stipula = {d '2011-04-28'},title = 'ISTITUTI PER IL SOSTENTAMENTO DEL CLERO' WHERE idccnl = '830'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('830','S','ALTRI VARI (82) ','ISTITUTOCENTRALEPERILSOSTENTAMENTODELCLERO, CONFCOMMERCIO, UGL COMMERCIO E TURISMO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'830',{d '2011-04-28'},'ISTITUTI PER IL SOSTENTAMENTO DEL CLERO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '831')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ISTITUTOCENTRALEPERILSOSTENTAMENTODELCLERO, CONFCOMMERCIO, FISASCAT CISL, FILCAMS CGIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2006-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2008-05-31'},scadenza = {d '2010-05-31'},sortcode = '831',stipula = {d '2007-03-15'},title = 'ISTITUTI PER IL SOSTENTAMENTO DEL CLERO' WHERE idccnl = '831'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('831','S','ALTRI VARI (82) ','ISTITUTOCENTRALEPERILSOSTENTAMENTODELCLERO, CONFCOMMERCIO, FISASCAT CISL, FILCAMS CGIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2006-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2008-05-31'},{d '2010-05-31'},'831',{d '2007-03-15'},'ISTITUTI PER IL SOSTENTAMENTO DEL CLERO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '832')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, ADI, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-11-30'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-11-29'},sortcode = '832',stipula = {d '2016-11-30'},title = 'ISTITUTI PER IL SOSTENTAMENTO DEL CLERO (ESAARCO)' WHERE idccnl = '832'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('832','S','ALTRI VARI (82) ','ESAARCO, CEPAA, CEPAASanit?, CEPAAFedercoop, SAI, FER, ADI, CIU, SI CEL, FNAOPS CGEL, ONAPS, FISNALCTA UGL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-11-30'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-11-29'},'832',{d '2016-11-30'},'ISTITUTI PER IL SOSTENTAMENTO DEL CLERO (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '833')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FEDERAZIENDE, FEDERDIPENDENTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2016-09-30'},scadenza = {d '2012-10-02'},sortcode = '833',stipula = {d '2012-10-01'},title = 'LAVANDERIE, LEGNOARREDAMENTO, PANIFICAZIONE, PULIZIA (FEDERAZIENDE)' WHERE idccnl = '833'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('833','S','ALTRI VARI (82) ','FEDERAZIENDE, FEDERDIPENDENTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-09-30'},{d '2012-10-02'},'833',{d '2012-10-01'},'LAVANDERIE, LEGNOARREDAMENTO, PANIFICAZIONE, PULIZIA (FEDERAZIENDE)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '834')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FEDARCOM, CIFA, FIADEL SP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-07-30'},scadenza = {d '2010-07-31'},sortcode = '834',stipula = {d '2010-07-31'},title = 'LAVANDERIE, LEGNOARREDAMENTO, PANIFICAZIONE, PULIZIA: dip. Az. artigiane ' WHERE idccnl = '834'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('834','S','ALTRI VARI (82) ','FEDARCOM, CIFA, FIADEL SP',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-07-30'},{d '2010-07-31'},'834',{d '2010-07-31'},'LAVANDERIE, LEGNOARREDAMENTO, PANIFICAZIONE, PULIZIA: dip. Az. artigiane ')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '835')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ESAARCO Confederazione Esercenti Agricoltori Artigiani Commercio, ESAARCO Sindacato Emigranti e Immigrati, ESAARCO Commercio, ESAARCO Vigilanza e Sicurezza, ESAARCO Artigianato, ESAARCO Servizi e Terziario, ESAARCO Autotrasporti NCC, ESAARCO Federazione Coltivatori Diretti, ESAARCO Fedrazione Imprenditori Agricoli, CEPAA Assocostruttori, CEPAA Industria, CEPAA Pesca, CEPAA Turismo, CEPAA Costruttori Edili ed Affini, CEPAA Commercio, CEPAA Sanit?, CEPAA Scuola, CEPAAAIMA, CEPAAFEDERCOOP, FER, Federazione Nazionale Lavoratori della Chimica, Federazione Lavoratori del settore Agricoltura, Agriturismo e Florovivaisti, Federazione Lavoratori del settore Turismo, Federazione Nazionale Lavoratori Scuola Federata CSG, Organismo Nazionale Asseveratori della Sicurezza, FENAL Medici Federata, FENALOSS Federata, CIU, Confederazione Lavoro Italia Federata CIU, SICEL, FNAOPSCLI, ONAPS, Coordinamento Nazionale delle Professioni Olistiche, Federazione Nazionale del comparto Pesca CLI, Federazione Nazionale Lavoratori Artigianato CLI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-07-13'},scadenza = {d '2017-07-14'},sortcode = '835',stipula = {d '2017-07-14'},title = 'Lavoratori Autonomi (ESAARCO)' WHERE idccnl = '835'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('835','S','ALTRI VARI (82) ','ESAARCO Confederazione Esercenti Agricoltori Artigiani Commercio, ESAARCO Sindacato Emigranti e Immigrati, ESAARCO Commercio, ESAARCO Vigilanza e Sicurezza, ESAARCO Artigianato, ESAARCO Servizi e Terziario, ESAARCO Autotrasporti NCC, ESAARCO Federazione Coltivatori Diretti, ESAARCO Fedrazione Imprenditori Agricoli, CEPAA Assocostruttori, CEPAA Industria, CEPAA Pesca, CEPAA Turismo, CEPAA Costruttori Edili ed Affini, CEPAA Commercio, CEPAA Sanit?, CEPAA Scuola, CEPAAAIMA, CEPAAFEDERCOOP, FER, Federazione Nazionale Lavoratori della Chimica, Federazione Lavoratori del settore Agricoltura, Agriturismo e Florovivaisti, Federazione Lavoratori del settore Turismo, Federazione Nazionale Lavoratori Scuola Federata CSG, Organismo Nazionale Asseveratori della Sicurezza, FENAL Medici Federata, FENALOSS Federata, CIU, Confederazione Lavoro Italia Federata CIU, SICEL, FNAOPSCLI, ONAPS, Coordinamento Nazionale delle Professioni Olistiche, Federazione Nazionale del comparto Pesca CLI, Federazione Nazionale Lavoratori Artigianato CLI',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-07-13'},{d '2017-07-14'},'835',{d '2017-07-14'},'Lavoratori Autonomi (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '836')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CEPI, UCI, UIL PA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-12-31'},scadenza = {d '2012-01-01'},sortcode = '836',stipula = {d '2012-04-11'},title = 'LAVORATORI DELLE ASSOCIAZIONI' WHERE idccnl = '836'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('836','S','ALTRI VARI (82) ','CEPI, UCI, UIL PA',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-12-31'},{d '2012-01-01'},'836',{d '2012-04-11'},'LAVORATORI DELLE ASSOCIAZIONI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '837')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CEI, CICAS, CONFIMPRESA, ANFOP, CONFAR, FASCOTRAV, FAPI, ISA, SIA CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2013-12-31'},scadenza = {d '2010-12-21'},sortcode = '837',stipula = {d '2010-12-21'},title = 'LAVORATORI DELLE ASSOCIAZIONI' WHERE idccnl = '837'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('837','S','ALTRI VARI (82) ','CEI, CICAS, CONFIMPRESA, ANFOP, CONFAR, FASCOTRAV, FAPI, ISA, SIA CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-12-31'},{d '2010-12-21'},'837',{d '2010-12-21'},'LAVORATORI DELLE ASSOCIAZIONI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '838')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONAPI, CNAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-06-11'},scadenza = {d '2017-06-12'},sortcode = '838',stipula = {d '2017-06-10'},title = 'LAVORATORIDELLEASSOCIAZIONI (CONAPI-CNAL)' WHERE idccnl = '838'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('838','S','ALTRI VARI (82) ','CONAPI, CNAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-06-11'},{d '2017-06-12'},'838',{d '2017-06-10'},'LAVORATORIDELLEASSOCIAZIONI (CONAPI-CNAL)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '839')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2020-03-30'},scadenza = {d '2017-04-05'},sortcode = '839',stipula = {d '2017-04-05'},title = 'LAVORATORIDELLEASSOCIAZIONI (FAPI-CESAC-FILDI CIU)' WHERE idccnl = '839'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('839','S','ALTRI VARI (82) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2020-03-30'},{d '2017-04-05'},'839',{d '2017-04-05'},'LAVORATORIDELLEASSOCIAZIONI (FAPI-CESAC-FILDI CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '840')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'SISTEMALAVORO, SISTEMAIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-14'},scadenza = {d '2016-12-15'},sortcode = '840',stipula = {d '2016-12-12'},title = 'LAVORATORI IN SOMMINISTRAZIONE' WHERE idccnl = '840'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('840','S','ALTRI VARI (82) ','SISTEMALAVORO, SISTEMAIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-14'},{d '2016-12-15'},'840',{d '2016-12-12'},'LAVORATORI IN SOMMINISTRAZIONE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '841')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNCI, CLACS CISL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2011-06-01'},scadenza = {d '2008-06-04'},sortcode = '841',stipula = {d '2008-06-04'},title = 'Lavoratori non dipendenti: Cooperative' WHERE idccnl = '841'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('841','S','ALTRI VARI (82) ','UNCI, CLACS CISL',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-06-01'},{d '2008-06-04'},'841',{d '2008-06-04'},'Lavoratori non dipendenti: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '842')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FOR ITALY, FAMAR, CONFAMAR',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2019-12-31'},scadenza = {d '2017-04-20'},sortcode = '842',stipula = {d '2017-04-20'},title = 'Lavoro Autonomo (FOR.ITALY-FAMAR)' WHERE idccnl = '842'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('842','S','ALTRI VARI (82) ','FOR ITALY, FAMAR, CONFAMAR',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2019-12-31'},{d '2017-04-20'},'842',{d '2017-04-20'},'Lavoro Autonomo (FOR.ITALY-FAMAR)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '843')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CNAFedermoda, CNAProduzione, CNAArtisticoeTradizionale, CONFARTIGIANATOModa, CONFARTIGIANATOChimica, CONFARTIGIANATOCeramica, CASARTIGIANI, CLAAI, FILCTEMCGIL, FEMCA CISL, UILTEC UIL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-12-31'},sortcode = '843',stipula = {d '2017-11-07'},title = 'MODA, CHIMICA CERAMICA E DECORAZIONE PIASTRELLE IN 3? FUOCO (PMI)' WHERE idccnl = '843'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('843','S','ALTRI VARI (82) ','CNAFedermoda, CNAProduzione, CNAArtisticoeTradizionale, CONFARTIGIANATOModa, CONFARTIGIANATOChimica, CONFARTIGIANATOCeramica, CASARTIGIANI, CLAAI, FILCTEMCGIL, FEMCA CISL, UILTEC UIL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-12-31'},'843',{d '2017-11-07'},'MODA, CHIMICA CERAMICA E DECORAZIONE PIASTRELLE IN 3? FUOCO (PMI)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '844')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'NORD INDUSTRIALE, CONFIMI, FASPI, FAL, CONFAEL, SNALP',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-07-31'},sortcode = '844',stipula = {d '2016-07-21'},title = 'MULTISERVIZI, COMMERCIO, TERZIARIO, SERVIZI, TRASPORTI E LOGISTICA, ARTIGIANATO' WHERE idccnl = '844'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('844','S','ALTRI VARI (82) ','NORD INDUSTRIALE, CONFIMI, FASPI, FAL, CONFAEL, SNALP',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-07-31'},'844',{d '2016-07-21'},'MULTISERVIZI, COMMERCIO, TERZIARIO, SERVIZI, TRASPORTI E LOGISTICA, ARTIGIANATO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '845')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'NORD INDUSTRIALE ESAARCO, FAL ESAARCO',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-31'},sortcode = '845',stipula = {d '2017-04-01'},title = 'MULTISERVIZI, PULIZIE, LOGISTICA, TRASPORTIESPEDIZIONI, COMMERCIO, TERZIARIO, SERVIZI, TURISMO E PUBBLICI ESERCIZI' WHERE idccnl = '845'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('845','S','ALTRI VARI (82) ','NORD INDUSTRIALE ESAARCO, FAL ESAARCO',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-31'},'845',{d '2017-04-01'},'MULTISERVIZI, PULIZIE, LOGISTICA, TRASPORTIESPEDIZIONI, COMMERCIO, TERZIARIO, SERVIZI, TURISMO E PUBBLICI ESERCIZI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '846')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFIMPRESAITALIA, LEGA IMPRESA, CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-10-31'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-10-31'},sortcode = '846',stipula = {d '2017-10-24'},title = 'MULTISETTORIALE: micro, piccole e medieimprese (CONFIMPRESAITALIA - LEGA IMPRESA - CIU)' WHERE idccnl = '846'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('846','S','ALTRI VARI (82) ','CONFIMPRESAITALIA, LEGA IMPRESA, CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-10-31'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-10-31'},'846',{d '2017-10-24'},'MULTISETTORIALE: micro, piccole e medieimprese (CONFIMPRESAITALIA - LEGA IMPRESA - CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '847')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CIFA, CONFOMEF, CONFSAL, CONFSAL FALMEF',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2013-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2016-05-31'},sortcode = '847',stipula = {d '2013-05-28'},title = 'ORGANISMI DI MEDIAZIONE ED ENTI DI FORMAZIONE PER MEDIATORI' WHERE idccnl = '847'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('847','S','ALTRI VARI (82) ','CIFA, CONFOMEF, CONFSAL, CONFSAL FALMEF',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2013-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2016-05-31'},'847',{d '2013-05-28'},'ORGANISMI DI MEDIAZIONE ED ENTI DI FORMAZIONE PER MEDIATORI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '848')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'COOPITALIANE,IMPRESAITALIA, CONFSAAP, AECP, UPLA, CEPAA, CEPAATERZIARIO, CEPAAAIMA, FASPICONFSAL, ALDEPI, ALPPI, FENALPI, CONFLAVORATORI CONFSAL, CONFAIL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-05-31'},sortcode = '848',stipula = {d '2014-05-28'},title = 'OUTSOURCING: dipendentidallePMI,sociedipendenti delle cooperative' WHERE idccnl = '848'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('848','S','ALTRI VARI (82) ','COOPITALIANE,IMPRESAITALIA, CONFSAAP, AECP, UPLA, CEPAA, CEPAATERZIARIO, CEPAAAIMA, FASPICONFSAL, ALDEPI, ALPPI, FENALPI, CONFLAVORATORI CONFSAL, CONFAIL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-05-31'},'848',{d '2014-05-28'},'OUTSOURCING: dipendentidallePMI,sociedipendenti delle cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '849')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CPMIITALIA, UNIQUALITY, FESICACONFSAL, CONFSALFISALS, CONFSAL PESCA',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-05-30'},sortcode = '849',stipula = {d '2014-06-01'},title = 'PROFESSIONI NON REGOLAMENTATE' WHERE idccnl = '849'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('849','S','ALTRI VARI (82) ','CPMIITALIA, UNIQUALITY, FESICACONFSAL, CONFSALFISALS, CONFSAL PESCA',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-05-30'},'849',{d '2014-06-01'},'PROFESSIONI NON REGOLAMENTATE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '850')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FAGRI, FAPI, AIC, SISTEMAINDUSTRIADELL''AREAVASTA,IMPRENDITORI&IMPRESE, ASPERA, ASSOTECFAGRI, FORITALY, UGL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-05-14'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-12-31'},sortcode = '850',stipula = {d '2015-05-14'},title = 'Rapporti di lavoro non subordinato (FOR.ITALY)' WHERE idccnl = '850'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('850','S','ALTRI VARI (82) ','FAGRI, FAPI, AIC, SISTEMAINDUSTRIADELL''AREAVASTA,IMPRENDITORI&IMPRESE, ASPERA, ASSOTECFAGRI, FORITALY, UGL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-05-14'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-12-31'},'850',{d '2015-05-14'},'Rapporti di lavoro non subordinato (FOR.ITALY)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '851')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CNA, SLC CGIL, SLP CISL, UIL POST, UILTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '851',stipula = {d '2011-02-08'},title = 'RECAPITO CORRISPONDENZA' WHERE idccnl = '851'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('851','S','ALTRI VARI (82) ','CNA, SLC CGIL, SLP CISL, UIL POST, UILTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'851',{d '2011-02-08'},'RECAPITO CORRISPONDENZA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '852')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FISEARE, SLCCGIL, SLPCISL, UILPOST, UILTRASPORTI,(adesione di UGL COMUNICAZIONI dal 28/3/2012)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2010-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2012-12-31'},sortcode = '852',stipula = {d '2011-02-08'},title = 'RECAPITO CORRISPONDENZA' WHERE idccnl = '852'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('852','S','ALTRI VARI (82) ','FISEARE, SLCCGIL, SLPCISL, UILPOST, UILTRASPORTI,(adesione di UGL COMUNICAZIONI dal 28/3/2012)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2010-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2012-12-31'},'852',{d '2011-02-08'},'RECAPITO CORRISPONDENZA')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '853')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ARI, FEDERTERZIARIO, CONFIMEA, CFC, UGLCOSTRUZIONI, UGL, FEDERMIDDLEMANAGEMENT FMM',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2016-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-05-31'},sortcode = '853',stipula = {d '2016-04-05'},title = 'RESTAURO BENI CULTURALI' WHERE idccnl = '853'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('853','S','ALTRI VARI (82) ','ARI, FEDERTERZIARIO, CONFIMEA, CFC, UGLCOSTRUZIONI, UGL, FEDERMIDDLEMANAGEMENT FMM',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2016-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-05-31'},'853',{d '2016-04-05'},'RESTAURO BENI CULTURALI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '854')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FACI, FIUDACS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2013-12-31'},sortcode = '854',stipula = {d '2011-05-18'},title = 'SACRISTI E DIPENDENTI DA PARROCCHIE' WHERE idccnl = '854'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('854','S','ALTRI VARI (82) ','FACI, FIUDACS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2013-12-31'},'854',{d '2011-05-18'},'SACRISTI E DIPENDENTI DA PARROCCHIE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '855')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FAPI, CESAC, FILDI CIU',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-04-05'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-03-30'},sortcode = '855',stipula = {d '2017-04-05'},title = 'SERVIZI (FAPI-CESAC-FILDI CIU)' WHERE idccnl = '855'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('855','S','ALTRI VARI (82) ','FAPI, CESAC, FILDI CIU',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-04-05'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-03-30'},'855',{d '2017-04-05'},'SERVIZI (FAPI-CESAC-FILDI CIU)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '856')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ANPIT, CIDEC, CONFIMPRENDITORI, PMIITALIA, UAITCS, UNICA, CISAL Terziario, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '856',stipula = {d '2017-11-21'},title = 'SERVIZI AUSILIARI alle Collettivit?, alle Aziende e alle Persone' WHERE idccnl = '856'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('856','S','ALTRI VARI (82) ','ANPIT, CIDEC, CONFIMPRENDITORI, PMIITALIA, UAITCS, UNICA, CISAL Terziario, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'856',{d '2017-11-21'},'SERVIZI AUSILIARI alle Collettivit?, alle Aziende e alle Persone')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '857')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'FISE, SLC CGIL, SLP CISL, UILPOST, UILTRASPORTI',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2005-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2007-07-31'},scadenza = {d '2009-07-31'},sortcode = '857',stipula = {d '2005-07-28'},title = 'SERVIZI POSTALI IN APPALTO' WHERE idccnl = '857'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('857','S','ALTRI VARI (82) ','FISE, SLC CGIL, SLP CISL, UILPOST, UILTRASPORTI',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2005-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2007-07-31'},{d '2009-07-31'},'857',{d '2005-07-28'},'SERVIZI POSTALI IN APPALTO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '858')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'CONFIMPRESA FIPO, SINAPE CISL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-12-31'},sortcode = '858',stipula = {d '2016-12-27'},title = 'SETTORE OLISTICO' WHERE idccnl = '858'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('858','S','ALTRI VARI (82) ','CONFIMPRESA FIPO, SINAPE CISL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-12-31'},'858',{d '2016-12-27'},'SETTORE OLISTICO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '859')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ESAARCO, ESAARCOOlistici, CONFAB, FENALS,ONAPSCIU, SIDOS',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2020-02-28'},sortcode = '859',stipula = {d '2017-03-01'},title = 'SETTORE OLISTICO (ESAARCO)' WHERE idccnl = '859'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('859','S','ALTRI VARI (82) ','ESAARCO, ESAARCOOlistici, CONFAB, FENALS,ONAPSCIU, SIDOS',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2020-02-28'},'859',{d '2017-03-01'},'SETTORE OLISTICO (ESAARCO)')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '860')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2014-08-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2017-07-31'},sortcode = '860',stipula = {d '2014-07-15'},title = 'SETTORE PRODUZIONE E LAVORO-INDUSTRIA E ARTIGIANATO' WHERE idccnl = '860'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('860','S','ALTRI VARI (82) ','SISTEMACOOP, SISTEMACOMMERCIOEIMPRESA, FESICACONFSAL, CONFSAL FISALS, CONFSAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-08-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2017-07-31'},'860',{d '2014-07-15'},'SETTORE PRODUZIONE E LAVORO-INDUSTRIA E ARTIGIANATO')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '861')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'AIESIL, COSNIL ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2011-06-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = {d '2014-05-31'},scadenza = {d '2015-05-31'},sortcode = '861',stipula = {d '2011-07-20'},title = 'SICUREZZA SUL LAVORO, QUALITA'' E AMBIENTE' WHERE idccnl = '861'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('861','S','ALTRI VARI (82) ','AIESIL, COSNIL ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2011-06-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2014-05-31'},{d '2015-05-31'},'861',{d '2011-07-20'},'SICUREZZA SUL LAVORO, QUALITA'' E AMBIENTE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '862')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'AIFES, ANPIT, CIDEC, CISALTerziario, CISAL,(sottoscrittodaUAIil5/6/2017)',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2017-01-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2019-12-31'},sortcode = '862',stipula = {d '2016-12-12'},title = 'SOCIETA'' ED ENTI DI FORMAZIONE' WHERE idccnl = '862'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('862','S','ALTRI VARI (82) ','AIFES, ANPIT, CIDEC, CISALTerziario, CISAL,(sottoscrittodaUAIil5/6/2017)',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2017-01-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2019-12-31'},'862',{d '2016-12-12'},'SOCIETA'' ED ENTI DI FORMAZIONE')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '863')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'ANPIT, CIDEC, CONFIMPRENDITORI, PMIITALIA, UAITCS, UNICA, CISAL Terziario, CISAL',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2018-02-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2021-01-31'},sortcode = '863',stipula = {d '2018-01-31'},title = 'STUDI PROFESSIONALI e AGENZIE DI ASSICURAZIONI' WHERE idccnl = '863'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('863','S','ALTRI VARI (82) ','ANPIT, CIDEC, CONFIMPRENDITORI, PMIITALIA, UAITCS, UNICA, CISAL Terziario, CISAL',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2018-02-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2021-01-31'},'863',{d '2018-01-31'},'STUDI PROFESSIONALI e AGENZIE DI ASSICURAZIONI')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '864')
UPDATE [ccnl] SET active = 'S',area = 'ALTRI VARI (82) ',contraenti = 'UNCI, ANPIT, CISALTerziario, FAILMSCISALMetalmeccanici, CISAL Edili, CISAL, (sottoscritto da UAI il 5/6/2017) ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',decorrenza = {d '2015-03-01'},lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',scadec = null,scadenza = {d '2018-02-28'},sortcode = '864',stipula = {d '2015-02-24'},title = 'TERZIARIO E SERVIZI, FACILITY MANAGEMENT, LAVORAZIONI MECCANICHE, LAVORI EDILI AUSILIARI: Cooperative' WHERE idccnl = '864'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('864','S','ALTRI VARI (82) ','UNCI, ANPIT, CISALTerziario, FAILMSCISALMetalmeccanici, CISAL Edili, CISAL, (sottoscritto da UAI il 5/6/2017) ',{ts '2018-06-11 11:35:00.653'},'ferdinando',{d '2015-03-01'},{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{d '2018-02-28'},'864',{d '2015-02-24'},'TERZIARIO E SERVIZI, FACILITY MANAGEMENT, LAVORAZIONI MECCANICHE, LAVORI EDILI AUSILIARI: Cooperative')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '865')
UPDATE [ccnl] SET active = 'S',area = 'Teste2e Area',contraenti = 'Teste2e contraente',ct = {ts '2019-05-30 10:52:38.187'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-30 10:52:38.187'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-29'},title = 'Teste2e title' WHERE idccnl = '865'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('865','S','Teste2e Area','Teste2e contraente',{ts '2019-05-30 10:52:38.187'},'ASSISTENZA',null,{ts '2019-05-30 10:52:38.187'},'ASSISTENZA',null,null,'0',{d '2019-05-29'},'Teste2e title')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '866')
UPDATE [ccnl] SET active = 'S',area = 'Teste2e Area',contraenti = 'Teste2e contraente',ct = {ts '2019-05-30 11:11:32.557'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-30 11:11:32.557'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-29'},title = 'Teste2e title' WHERE idccnl = '866'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('866','S','Teste2e Area','Teste2e contraente',{ts '2019-05-30 11:11:32.557'},'ASSISTENZA',null,{ts '2019-05-30 11:11:32.557'},'ASSISTENZA',null,null,'0',{d '2019-05-29'},'Teste2e title')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '867')
UPDATE [ccnl] SET active = 'S',area = 'Teste2e Area',contraenti = 'Teste2e contraente',ct = {ts '2019-05-30 16:26:16.363'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-30 16:26:16.363'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-29'},title = 'Teste2e title' WHERE idccnl = '867'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('867','S','Teste2e Area','Teste2e contraente',{ts '2019-05-30 16:26:16.363'},'ASSISTENZA',null,{ts '2019-05-30 16:26:16.363'},'ASSISTENZA',null,null,'0',{d '2019-05-29'},'Teste2e title')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '868')
UPDATE [ccnl] SET active = 'S',area = 'Teste2e Area',contraenti = 'Teste2e contraente',ct = {ts '2019-05-30 16:26:31.787'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-30 16:26:31.787'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-29'},title = 'Teste2e title' WHERE idccnl = '868'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('868','S','Teste2e Area','Teste2e contraente',{ts '2019-05-30 16:26:31.787'},'ASSISTENZA',null,{ts '2019-05-30 16:26:31.787'},'ASSISTENZA',null,null,'0',{d '2019-05-29'},'Teste2e title')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '869')
UPDATE [ccnl] SET active = 'S',area = 'Teste2e Area',contraenti = 'Teste2e contraente',ct = {ts '2019-05-30 16:33:00.777'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-30 16:33:00.777'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-29'},title = 'Teste2e title' WHERE idccnl = '869'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('869','S','Teste2e Area','Teste2e contraente',{ts '2019-05-30 16:33:00.777'},'ASSISTENZA',null,{ts '2019-05-30 16:33:00.777'},'ASSISTENZA',null,null,'0',{d '2019-05-29'},'Teste2e title')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '870')
UPDATE [ccnl] SET active = 'S',area = 'Teste2e Area',contraenti = 'Teste2e contraente',ct = {ts '2019-05-30 16:33:20.297'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-30 16:33:20.297'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-29'},title = 'Teste2e title' WHERE idccnl = '870'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('870','S','Teste2e Area','Teste2e contraente',{ts '2019-05-30 16:33:20.297'},'ASSISTENZA',null,{ts '2019-05-30 16:33:20.297'},'ASSISTENZA',null,null,'0',{d '2019-05-29'},'Teste2e title')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '871')
UPDATE [ccnl] SET active = 'S',area = 'Teste2e Area',contraenti = 'Teste2e contraente',ct = {ts '2019-05-31 12:38:27.827'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-31 12:38:27.827'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-30'},title = 'Teste2e title' WHERE idccnl = '871'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('871','S','Teste2e Area','Teste2e contraente',{ts '2019-05-31 12:38:27.827'},'ASSISTENZA',null,{ts '2019-05-31 12:38:27.827'},'ASSISTENZA',null,null,'0',{d '2019-05-30'},'Teste2e title')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '872')
UPDATE [ccnl] SET active = 'S',area = 'Teste2e Area',contraenti = 'Teste2e contraente',ct = {ts '2019-05-31 12:38:50.567'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-31 12:38:50.567'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-30'},title = 'Teste2e title' WHERE idccnl = '872'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('872','S','Teste2e Area','Teste2e contraente',{ts '2019-05-31 12:38:50.567'},'ASSISTENZA',null,{ts '2019-05-31 12:38:50.567'},'ASSISTENZA',null,null,'0',{d '2019-05-30'},'Teste2e title')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '873')
UPDATE [ccnl] SET active = 'S',area = 'teste2e_Vvxoq',contraenti = 'teste2e_YlRHW',ct = {ts '2019-05-31 14:54:56.810'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-31 14:54:56.810'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-30'},title = 'teste2e_QOdPr' WHERE idccnl = '873'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('873','S','teste2e_Vvxoq','teste2e_YlRHW',{ts '2019-05-31 14:54:56.810'},'ASSISTENZA',null,{ts '2019-05-31 14:54:56.810'},'ASSISTENZA',null,null,'0',{d '2019-05-30'},'teste2e_QOdPr')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '874')
UPDATE [ccnl] SET active = 'S',area = 'teste2e_yERPW',contraenti = 'teste2e_vPWOl',ct = {ts '2019-05-31 15:35:20.553'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-31 15:35:20.553'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-30'},title = 'teste2e_nmnLo' WHERE idccnl = '874'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('874','S','teste2e_yERPW','teste2e_vPWOl',{ts '2019-05-31 15:35:20.553'},'ASSISTENZA',null,{ts '2019-05-31 15:35:20.553'},'ASSISTENZA',null,null,'0',{d '2019-05-30'},'teste2e_nmnLo')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '875')
UPDATE [ccnl] SET active = 'S',area = 'teste2e_zvXau',contraenti = 'teste2e_TQBwh',ct = {ts '2019-05-31 15:42:23.613'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-05-31 15:42:23.613'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-05-30'},title = 'teste2e_gSoon' WHERE idccnl = '875'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('875','S','teste2e_zvXau','teste2e_TQBwh',{ts '2019-05-31 15:42:23.613'},'ASSISTENZA',null,{ts '2019-05-31 15:42:23.613'},'ASSISTENZA',null,null,'0',{d '2019-05-30'},'teste2e_gSoon')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '876')
UPDATE [ccnl] SET active = 'S',area = 'teste2e_ZiTsa',contraenti = 'teste2e_Vsmjn',ct = {ts '2019-06-03 14:09:31.490'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-06-03 14:09:31.490'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-06-02'},title = 'teste2e_xASId' WHERE idccnl = '876'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('876','S','teste2e_ZiTsa','teste2e_Vsmjn',{ts '2019-06-03 14:09:31.490'},'ASSISTENZA',null,{ts '2019-06-03 14:09:31.490'},'ASSISTENZA',null,null,'0',{d '2019-06-02'},'teste2e_xASId')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '877')
UPDATE [ccnl] SET active = 'S',area = 'test_e2e_fNulu',contraenti = 'test_e2e_qccmc',ct = {ts '2019-06-05 14:44:14.643'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-06-05 14:44:14.643'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-06-04'},title = 'test_e2e_ugUXf' WHERE idccnl = '877'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('877','S','test_e2e_fNulu','test_e2e_qccmc',{ts '2019-06-05 14:44:14.643'},'ASSISTENZA',null,{ts '2019-06-05 14:44:14.643'},'ASSISTENZA',null,null,'0',{d '2019-06-04'},'test_e2e_ugUXf')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '878')
UPDATE [ccnl] SET active = 'S',area = 'test_e2e_fUbBI',contraenti = 'test_e2e_PPmzR',ct = {ts '2019-06-11 11:31:42.260'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-06-11 11:31:42.260'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-06-10'},title = 'test_e2e_FuphG' WHERE idccnl = '878'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('878','S','test_e2e_fUbBI','test_e2e_PPmzR',{ts '2019-06-11 11:31:42.260'},'ASSISTENZA',null,{ts '2019-06-11 11:31:42.260'},'ASSISTENZA',null,null,'0',{d '2019-06-10'},'test_e2e_FuphG')
GO

IF exists(SELECT * FROM [ccnl] WHERE idccnl = '879')
UPDATE [ccnl] SET active = 'S',area = 'test_e2e_dEkOB',contraenti = 'test_e2e_ZifXK',ct = {ts '2019-06-12 11:38:16.147'},cu = 'ASSISTENZA',decorrenza = null,lt = {ts '2019-06-12 11:38:16.147'},lu = 'ASSISTENZA',scadec = null,scadenza = null,sortcode = '0',stipula = {d '2019-06-11'},title = 'test_e2e_SqheC' WHERE idccnl = '879'
ELSE
INSERT INTO [ccnl] (idccnl,active,area,contraenti,ct,cu,decorrenza,lt,lu,scadec,scadenza,sortcode,stipula,title) VALUES ('879','S','test_e2e_dEkOB','test_e2e_ZifXK',{ts '2019-06-12 11:38:16.147'},'ASSISTENZA',null,{ts '2019-06-12 11:38:16.147'},'ASSISTENZA',null,null,'0',{d '2019-06-11'},'test_e2e_SqheC')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'ccnl')
UPDATE [tabledescr] SET description = 'VOCABOLARIO dei contratti nazionali del lavoro censiti dal CNEL',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:22:47.730'},lu = 'assistenza',title = 'Contratti nazionali del lavoro' WHERE tablename = 'ccnl'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('ccnl','VOCABOLARIO dei contratti nazionali del lavoro censiti dal CNEL',null,'N',{ts '2018-07-20 11:22:47.730'},'assistenza','Contratti nazionali del lavoro')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','ccnl','1',null,null,null,'S',{ts '2018-07-17 17:49:57.673'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'area' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'area' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('area','ccnl','50',null,null,null,'S',{ts '2018-07-17 17:49:57.673'},'assistenza','N','nvarchar(50)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contraenti' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '1050',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(1050)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'contraenti' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contraenti','ccnl','1050',null,null,null,'S',{ts '2018-07-17 17:49:57.673'},'assistenza','N','nvarchar(1050)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','ccnl','8',null,null,null,'S',{ts '2018-07-17 17:49:57.673'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(64)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','ccnl','64',null,null,null,'S',{ts '2018-07-17 17:49:57.673'},'assistenza','N','nvarchar(64)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'decorrenza' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'decorrenza' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('decorrenza','ccnl','3',null,null,null,'S',{ts '2018-07-17 17:49:57.673'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idccnl' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.673'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idccnl' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idccnl','ccnl','4',null,null,null,'S',{ts '2018-07-17 17:49:57.673'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','ccnl','8',null,null,null,'S',{ts '2018-07-17 17:49:57.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(64)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','ccnl','64',null,null,null,'S',{ts '2018-07-17 17:49:57.677'},'assistenza','N','nvarchar(64)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scadec' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Scadenza ec.',kind = 'S',lt = {ts '2019-02-28 19:33:36.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'scadec' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scadec','ccnl','3',null,null,'Scadenza ec.','S',{ts '2019-02-28 19:33:36.510'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scadenza' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'scadenza' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scadenza','ccnl','3',null,null,null,'S',{ts '2018-07-17 17:49:57.677'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','ccnl','4',null,null,null,'S',{ts '2018-07-17 17:49:57.677'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stipula' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:49:57.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stipula' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stipula','ccnl','3',null,null,null,'S',{ts '2018-07-17 17:49:57.677'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'ccnl')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-09-11 17:32:47.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(150)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'ccnl'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','ccnl','150',null,null,'Denominazione','S',{ts '2019-09-11 17:32:47.860'},'assistenza','N','nvarchar(150)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

