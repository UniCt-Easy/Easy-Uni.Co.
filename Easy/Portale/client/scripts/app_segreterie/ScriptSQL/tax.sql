
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


-- CREAZIONE TABELLA tax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tax] (
taxcode int NOT NULL,
active char(1) NULL,
appliancebasis char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
fiscaltaxcode varchar(20) NULL,
fiscaltaxcodecredit varchar(20) NULL,
flagunabatable char(1) NULL,
geoappliance char(1) NULL,
idaccmotive_cost varchar(36) NULL,
idaccmotive_debit varchar(36) NULL,
idaccmotive_pay varchar(36) NULL,
insuranceagencycode varchar(10) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maintaxcode int NULL,
taxablecode varchar(20) NULL,
taxkind smallint NOT NULL,
taxref varchar(20) NOT NULL,
 CONSTRAINT xpktax PRIMARY KEY (taxcode
)
)
END
GO

-- VERIFICA STRUTTURA tax --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tax') and col.name = 'taxcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tax] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'appliancebasis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD appliancebasis char(1) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN appliancebasis char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tax') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tax] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tax') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tax] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD description varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tax') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tax] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN description varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'fiscaltaxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD fiscaltaxcode varchar(20) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN fiscaltaxcode varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'fiscaltaxcodecredit' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD fiscaltaxcodecredit varchar(20) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN fiscaltaxcodecredit varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'flagunabatable' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD flagunabatable char(1) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN flagunabatable char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'geoappliance' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD geoappliance char(1) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN geoappliance char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'idaccmotive_cost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD idaccmotive_cost varchar(36) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN idaccmotive_cost varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'idaccmotive_debit' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD idaccmotive_debit varchar(36) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN idaccmotive_debit varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'idaccmotive_pay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD idaccmotive_pay varchar(36) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN idaccmotive_pay varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'insuranceagencycode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD insuranceagencycode varchar(10) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN insuranceagencycode varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tax') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tax] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tax') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tax] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'maintaxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD maintaxcode int NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN maintaxcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxablecode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxablecode varchar(20) NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN taxablecode varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxkind smallint NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tax') and col.name = 'taxkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tax] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN taxkind smallint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxref' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxref varchar(20) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tax') and col.name = 'taxref' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tax] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN taxref varchar(20) NOT NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='uktax' and id=object_id('tax'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uktax
     ON tax (taxref )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uktax
     ON tax (taxref )
ON [PRIMARY]
END
GO

-- VERIFICA DI tax IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tax'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tax','int','ASSISTENZA','taxcode','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','char(1)','ASSISTENZA','appliancebasis','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tax','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tax','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tax','varchar(50)','ASSISTENZA','description','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','varchar(20)','ASSISTENZA','fiscaltaxcode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','varchar(20)','ASSISTENZA','fiscaltaxcodecredit','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','char(1)','ASSISTENZA','flagunabatable','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','char(1)','ASSISTENZA','geoappliance','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','varchar(36)','ASSISTENZA','idaccmotive_cost','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','varchar(36)','ASSISTENZA','idaccmotive_debit','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','varchar(36)','ASSISTENZA','idaccmotive_pay','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','varchar(10)','ASSISTENZA','insuranceagencycode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tax','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tax','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','int','ASSISTENZA','maintaxcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tax','varchar(20)','ASSISTENZA','taxablecode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tax','smallint','ASSISTENZA','taxkind','2','S','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tax','varchar(20)','ASSISTENZA','taxref','20','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tax IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tax')
UPDATE customobject set isreal = 'S' where objectname = 'tax'
ELSE
INSERT INTO customobject (objectname, isreal) values('tax', 'S')
GO

-- GENERAZIONE DATI PER tax --
IF exists(SELECT * FROM [tax] WHERE taxcode = '1')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Addizionale comunale IRPEF',fiscaltaxcode = '384E',fiscaltaxcodecredit = '161E',flagunabatable = 'N',geoappliance = 'C',idaccmotive_cost = null,idaccmotive_debit = '00200001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:44:32.060'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '1',taxref = '05_ADDCOMU' WHERE taxcode = '1'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('1','S',null,{d '2006-01-01'},'Software and more','Addizionale comunale IRPEF','384E','161E','N','C',null,'00200001','00210002',null,{ts '2015-12-11 11:44:32.060'},'assistenza',null,'ADDIRPEF','1','05_ADDCOMU')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '2')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Addizionale regionale IRPEF',fiscaltaxcode = '381E',fiscaltaxcodecredit = '160E',flagunabatable = 'N',geoappliance = 'R',idaccmotive_cost = '0041',idaccmotive_debit = '00200001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:44:27.563'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '1',taxref = '05_ADDREGI' WHERE taxcode = '2'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('2','S',null,{d '2006-01-01'},'Software and more','Addizionale regionale IRPEF','381E','160E','N','R','0041','00200001','00210002',null,{ts '2015-12-11 11:44:27.563'},'assistenza',null,'ADDIRPEF','1','05_ADDREGI')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '3')
UPDATE [tax] SET active = 'S',appliancebasis = 'S',ct = {d '2006-01-01'},cu = 'Software and more',description = 'Ritenuta Inail',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = '00200001',idaccmotive_pay = '00210002',insuranceagencycode = 'P64',lt = {ts '2017-01-04 11:21:05.417'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ASSICUR',taxkind = '4',taxref = '05_INAIL' WHERE taxcode = '3'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('3','S','S',{d '2006-01-01'},'Software and more','Ritenuta Inail',null,null,'N',null,null,'00200001','00210002','P64',{ts '2017-01-04 11:21:05.417'},'assistenza',null,'ASSICUR','4','05_INAIL')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '4')
UPDATE [tax] SET active = 'S',appliancebasis = 'A',ct = {ts '2007-01-24 14:26:49.610'},cu = '''NINO''',description = 'Acconto Addizionale Comunale IRPEF',fiscaltaxcode = '385E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = 'C',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:44:35.677'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '1',taxref = '07_ACC_ADDCOM' WHERE taxcode = '4'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('4','S','A',{ts '2007-01-24 14:26:49.610'},'''NINO''','Acconto Addizionale Comunale IRPEF','385E',null,'N','C',null,null,'00210002',null,{ts '2015-12-11 11:44:35.677'},'assistenza',null,'ADDIRPEF','1','07_ACC_ADDCOM')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '5')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Rit. acconto 20% su 75% lordo',fiscaltaxcode = '104E',fiscaltaxcodecredit = '156E',flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:44:40.150'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_ACC_DAT' WHERE taxcode = '5'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('5','S',null,{d '2006-01-01'},'Software and more','Rit. acconto 20% su 75% lordo','104E','156E','S',null,null,null,'00210002',null,{ts '2015-12-11 11:44:40.150'},'assistenza',null,'IRPEF','1','07_ACC_DAT')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '6')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2007-03-13 15:18:41.890'},cu = '''SA''',description = 'Rit. acconto 20% su 60% lordo',fiscaltaxcode = '104E',fiscaltaxcodecredit = '156E',flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:44:44.960'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_ACC_DAT_40' WHERE taxcode = '6'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('6','S',null,{ts '2007-03-13 15:18:41.890'},'''SA''','Rit. acconto 20% su 60% lordo','104E','156E','S',null,null,null,'00210002',null,{ts '2015-12-11 11:44:44.960'},'assistenza',null,'IRPEF','1','07_ACC_DAT_40')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '7')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Ritenuta d''Acconto',fiscaltaxcode = '104E',fiscaltaxcodecredit = '156E',flagunabatable = 'N',geoappliance = 'N',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:44:49.467'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_ACC_FISC' WHERE taxcode = '7'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('7','S',null,{d '2006-01-01'},'Software and more','Ritenuta d''Acconto','104E','156E','N','N',null,null,'00210002',null,{ts '2015-12-11 11:44:49.467'},'assistenza',null,'IRPEF','1','07_ACC_FISC')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '8')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2006-07-17 16:04:53.850'},cu = 'SA',description = 'Addizionale Comunale da CAF',fiscaltaxcode = '128E',fiscaltaxcodecredit = '154E',flagunabatable = 'N',geoappliance = 'C',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:44:53.033'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '07_ADDCOMCAF' WHERE taxcode = '8'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('8','S',null,{ts '2006-07-17 16:04:53.850'},'SA','Addizionale Comunale da CAF','128E','154E','N','C',null,null,'00210002',null,{ts '2015-12-11 11:44:53.033'},'assistenza',null,'ADDIRPEF','5','07_ADDCOMCAF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '9')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2006-07-17 16:05:09.787'},cu = 'SA',description = 'Addizionale Regionale da CAF',fiscaltaxcode = '126E',fiscaltaxcodecredit = '153E',flagunabatable = 'N',geoappliance = 'R',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2007-07-02 09:52:47.733'},lu = '''SARA''',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '07_ADDREGCAF' WHERE taxcode = '9'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('9','S',null,{ts '2006-07-17 16:05:09.787'},'SA','Addizionale Regionale da CAF','126E','153E','N','R',null,null,null,null,{ts '2007-07-02 09:52:47.733'},'''SARA''',null,'ADDIRPEF','5','07_ADDREGCAF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '10')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Fondo Credito',fiscaltaxcode = 'P909',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = 'P54',lt = {ts '2016-09-14 09:27:25.543'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '07_FDOCRE' WHERE taxcode = '10'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('10','S',null,{d '2006-01-01'},'Software and more','Fondo Credito','P909',null,'N',null,null,null,'00210002','P54',{ts '2016-09-14 09:27:25.543'},'assistenza',null,'PREVIDENZA','3','07_FDOCRE')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '11')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Contributo Previdenziale Ammin.',fiscaltaxcode = 'P101',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0041',idaccmotive_debit = '00210001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2009-10-21 09:58:11.030'},lu = 'SA',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '07_INPDAP_CAMM' WHERE taxcode = '11'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('11','S',null,{d '2006-01-01'},'Software and more','Contributo Previdenziale Ammin.','P101',null,'N',null,'0041','00210001','00210002',null,{ts '2009-10-21 09:58:11.030'},'SA',null,'PREVIDENZA','3','07_INPDAP_CAMM')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '12')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Contributo Previdenziale Dipendenti',fiscaltaxcode = 'P101',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = '00210001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2009-10-21 09:58:15.593'},lu = 'SA',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '07_INPDAP_CDIP' WHERE taxcode = '12'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('12','S',null,{d '2006-01-01'},'Software and more','Contributo Previdenziale Dipendenti','P101',null,'N',null,null,'00210001','00210002',null,{ts '2009-10-21 09:58:15.593'},'SA',null,'PREVIDENZA','3','07_INPDAP_CDIP')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '13')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'INPS soggetti mutuati',fiscaltaxcode = 'C10',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0023',idaccmotive_debit = '00210001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2009-09-30 17:27:07.250'},lu = 'SARA',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '07_INPS_M' WHERE taxcode = '13'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('13','S',null,{d '2006-01-01'},'Software and more','INPS soggetti mutuati','C10',null,'N',null,'0023','00210001','00210002',null,{ts '2009-09-30 17:27:07.250'},'SARA',null,'PREVIDENZA','3','07_INPS_M')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '14')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'INPS soggetti non mutuati',fiscaltaxcode = 'CXX',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0023',idaccmotive_debit = '00210001',idaccmotive_pay = '0022',insuranceagencycode = null,lt = {ts '2009-10-20 15:48:49.717'},lu = 'SA',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '07_INPS_N' WHERE taxcode = '14'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('14','S',null,{d '2006-01-01'},'Software and more','INPS soggetti non mutuati','CXX',null,'N',null,'0023','00210001','0022',null,{ts '2009-10-20 15:48:49.717'},'SA',null,'PREVIDENZA','3','07_INPS_N')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '15')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'INPS titolari pensione diretta',fiscaltaxcode = 'C10',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {d '2006-01-01'},lu = 'Software and more',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '07_INPS_P' WHERE taxcode = '15'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('15','S',null,{d '2006-01-01'},'Software and more','INPS titolari pensione diretta','C10',null,'N',null,null,null,null,null,{d '2006-01-01'},'Software and more',null,'PREVIDENZA','3','07_INPS_P')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '16')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'IRAP dipendenti',fiscaltaxcode = '380E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0041',idaccmotive_debit = '00210001',idaccmotive_pay = '00210002',insuranceagencycode = 'P53',lt = {ts '2016-09-14 09:27:11.257'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = '07_IRAP' WHERE taxcode = '16'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('16','S',null,{d '2006-01-01'},'Software and more','IRAP dipendenti','380E',null,'N',null,'0041','00210001','00210002','P53',{ts '2016-09-14 09:27:11.257'},'assistenza',null,'ASSISTENZA','2','07_IRAP')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '17')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'IRAP autonomi/assimilati',fiscaltaxcode = '380E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0041',idaccmotive_debit = '00200001',idaccmotive_pay = '00210002',insuranceagencycode = 'P53',lt = {ts '2016-09-14 09:27:17.707'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = '07_IRAP_CO' WHERE taxcode = '17'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('17','S',null,{d '2006-01-01'},'Software and more','IRAP autonomi/assimilati','380E',null,'N',null,'0041','00200001','00210002','P53',{ts '2016-09-14 09:27:17.707'},'assistenza',null,'ASSISTENZA','2','07_IRAP_CO')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '18')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Ritenuta IRPEF assimilati',fiscaltaxcode = '100E',fiscaltaxcodecredit = '155E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = '00210001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2007-12-01 15:16:01.170'},lu = 'SA',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_IRPEF_ASS' WHERE taxcode = '18'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('18','S',null,{d '2006-01-01'},'Software and more','Ritenuta IRPEF assimilati','100E','155E','N',null,null,'00210001','00210002',null,{ts '2007-12-01 15:16:01.170'},'SA',null,'IRPEF','1','07_IRPEF_ASS')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '19')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1998-08-06 17:40:41.560'},cu = '''DBO_PO''',description = 'ZZZ - IRPEFBORS',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '1999-06-23 12:10:03.170'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = '07_IRPEF_BRS' WHERE taxcode = '19'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('19','N',null,{ts '1998-08-06 17:40:41.560'},'''DBO_PO''','ZZZ - IRPEFBORS',null,null,'N',null,null,null,null,null,{ts '1999-06-23 12:10:03.170'},'''DBO_PO''',null,null,'1','07_IRPEF_BRS')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '20')
UPDATE [tax] SET active = 'S',appliancebasis = 'S',ct = {d '2006-01-01'},cu = 'Software and more',description = 'IRPEF da dichiarazione C.A.F.',fiscaltaxcode = '134E',fiscaltaxcodecredit = '150E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {d '2006-01-01'},lu = 'Software and more',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '07_IRPEF_CAF' WHERE taxcode = '20'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('20','S','S',{d '2006-01-01'},'Software and more','IRPEF da dichiarazione C.A.F.','134E','150E','N',null,null,null,null,null,{d '2006-01-01'},'Software and more',null,'ADDIRPEF','5','07_IRPEF_CAF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '21')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Rit.IRPEF stranieri con Convenzione',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:47:39.597'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_IRPEF_FC' WHERE taxcode = '21'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('21','S',null,{d '2006-01-01'},'Software and more','Rit.IRPEF stranieri con Convenzione',null,null,'S',null,null,null,'00210002',null,{ts '2015-12-11 11:47:39.597'},'assistenza',null,'IRPEF','1','07_IRPEF_FC')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '22')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Ritenuta IRPEF stranieri',fiscaltaxcode = '104E',fiscaltaxcodecredit = '156E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-11 11:47:35.387'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_IRPEF_FO' WHERE taxcode = '22'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('22','S',null,{d '2006-01-01'},'Software and more','Ritenuta IRPEF stranieri','104E','156E','N',null,null,null,'00210002',null,{ts '2015-12-11 11:47:35.387'},'assistenza',null,'IRPEF','1','07_IRPEF_FO')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '23')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Ritenuta IRPEF dipendenti',fiscaltaxcode = '100E',fiscaltaxcodecredit = '155E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0041',idaccmotive_debit = '00200001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-12-21 15:43:09.190'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_IRPEF_GEN' WHERE taxcode = '23'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('23','S',null,{d '2006-01-01'},'Software and more','Ritenuta IRPEF dipendenti','100E','155E','N',null,'0041','00200001','00210002',null,{ts '2015-12-21 15:43:09.190'},'assistenza',null,'IRPEF','1','07_IRPEF_GEN')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '24')
UPDATE [tax] SET active = 'S',appliancebasis = 'S',ct = {d '2006-01-01'},cu = 'Software and more',description = 'IRPEF Prima Rata di Acconto',fiscaltaxcode = '133E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {d '2006-01-01'},lu = 'Software and more',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '07_IRPEF_R1' WHERE taxcode = '24'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('24','S','S',{d '2006-01-01'},'Software and more','IRPEF Prima Rata di Acconto','133E',null,'N',null,null,null,null,null,{d '2006-01-01'},'Software and more',null,'ADDIRPEF','5','07_IRPEF_R1')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '25')
UPDATE [tax] SET active = 'S',appliancebasis = 'S',ct = {d '2006-01-01'},cu = 'Software and more',description = 'IRPEF Seconda Rata di Acconto',fiscaltaxcode = '133E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {d '2006-01-01'},lu = 'Software and more',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '07_IRPEF_R2' WHERE taxcode = '25'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('25','S','S',{d '2006-01-01'},'Software and more','IRPEF Seconda Rata di Acconto','133E',null,'N',null,null,null,null,null,{d '2006-01-01'},'Software and more',null,'ADDIRPEF','5','07_IRPEF_R2')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '26')
UPDATE [tax] SET active = 'S',appliancebasis = 'S',ct = {d '2006-01-01'},cu = 'Software and more',description = 'Acconto su Tassazione Separata',fiscaltaxcode = '129E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {d '2006-01-01'},lu = 'Software and more',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '07_TASSASEP' WHERE taxcode = '26'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('26','S','S',{d '2006-01-01'},'Software and more','Acconto su Tassazione Separata','129E',null,'N',null,null,null,null,null,{d '2006-01-01'},'Software and more',null,'ADDIRPEF','5','07_TASSASEP')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '27')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:20:06.000'},cu = 'DBO_PO',description = 'Ritenuta IRPEF 30% non residenti',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:20:06.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ACC.STRA' WHERE taxcode = '27'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('27','N',null,{ts '2004-05-08 12:20:06.000'},'DBO_PO','Ritenuta IRPEF 30% non residenti',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:20:06.000'},'''DBO_PO''',null,null,'1','ACC.STRA')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '28')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-06-18 16:16:22.000'},cu = 'DBO_PO ',description = 'IRPEF Riten.d''acc. 20% su 75% lordo',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-06-18 16:17:47.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ACCDIRAUT' WHERE taxcode = '28'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('28','N',null,{ts '2004-06-18 16:16:22.000'},'DBO_PO ','IRPEF Riten.d''acc. 20% su 75% lordo',null,null,'N',null,null,null,null,null,{ts '2004-06-18 16:17:47.000'},'''DBO_PO''',null,null,'1','ACCDIRAUT')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '29')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2007-06-26 15:16:39.640'},cu = '''SARA''',description = 'Ritenuta d''Acconto  1',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2009-10-20 13:44:47.127'},lu = 'SA',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = 'ACCONTO1' WHERE taxcode = '29'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('29','S',null,{ts '2007-06-26 15:16:39.640'},'''SARA''','Ritenuta d''Acconto  1',null,null,'N',null,null,null,null,null,{ts '2009-10-20 13:44:47.127'},'SA',null,'IRPEF','1','ACCONTO1')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '30')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1999-06-21 09:33:20.560'},cu = '''DBO_PO''',description = 'ZZZ - ADDCOM',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2000-06-02 09:08:07.540'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ADDCOM' WHERE taxcode = '30'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('30','N',null,{ts '1999-06-21 09:33:20.560'},'''DBO_PO''','ZZZ - ADDCOM',null,null,'S',null,null,null,null,null,{ts '2000-06-02 09:08:07.540'},'''DBO_PO''',null,null,'1','ADDCOM')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '31')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1999-06-23 09:12:44.100'},cu = '''DBO_PO''',description = 'ZZZ - ADDCOMUN',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '1999-06-23 09:12:44.100'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ADDCOMUN' WHERE taxcode = '31'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('31','N',null,{ts '1999-06-23 09:12:44.100'},'''DBO_PO''','ZZZ - ADDCOMUN',null,null,'N',null,null,null,null,null,{ts '1999-06-23 09:12:44.100'},'''DBO_PO''',null,null,'1','ADDCOMUN')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '32')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1998-08-06 17:40:41.240'},cu = '''DBO_PO''',description = 'ZZZ - ADDIRPEF',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '1999-02-10 06:37:26.110'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ADDIRPEF' WHERE taxcode = '32'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('32','N',null,{ts '1998-08-06 17:40:41.240'},'''DBO_PO''','ZZZ - ADDIRPEF',null,null,'S',null,null,null,null,null,{ts '1999-02-10 06:37:26.110'},'''DBO_PO''',null,null,'1','ADDIRPEF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '33')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:23:44.000'},cu = 'DBO_PO',description = 'Addizionale comunale',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:23:44.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ADDIZCOM' WHERE taxcode = '33'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('33','N',null,{ts '2004-05-08 12:23:44.000'},'DBO_PO','Addizionale comunale',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:23:44.000'},'''DBO_PO''',null,null,'1','ADDIZCOM')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '34')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:24:15.000'},cu = 'DBO_PO',description = 'Addizionale regionale',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2006-03-08 12:40:25.360'},lu = '''SARA''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ADDIZREG' WHERE taxcode = '34'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('34','N',null,{ts '2004-05-08 12:24:15.000'},'DBO_PO','Addizionale regionale',null,null,'N',null,null,null,null,null,{ts '2006-03-08 12:40:25.360'},'''SARA''',null,null,'1','ADDIZREG')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '35')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1999-06-23 09:11:49.000'},cu = '''DBO_PO''',description = 'ZZZ - ADDPROV',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '1999-06-23 09:11:49.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ADDPROV' WHERE taxcode = '35'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('35','N',null,{ts '1999-06-23 09:11:49.000'},'''DBO_PO''','ZZZ - ADDPROV',null,null,'N',null,null,null,null,null,{ts '1999-06-23 09:11:49.000'},'''DBO_PO''',null,null,'1','ADDPROV')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '36')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1999-06-21 09:32:56.710'},cu = '''DBO_PO''',description = 'ZZZ - ADDREG',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2006-03-08 12:40:22.610'},lu = '''SARA''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'ADDREG' WHERE taxcode = '36'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('36','N',null,{ts '1999-06-21 09:32:56.710'},'''DBO_PO''','ZZZ - ADDREG',null,null,'N',null,null,null,null,null,{ts '2006-03-08 12:40:22.610'},'''SARA''',null,null,'1','ADDREG')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '37')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:29:51.000'},cu = 'DBO_PO',description = 'Fondo Credito',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:29:51.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'FONDCRED' WHERE taxcode = '37'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('37','N',null,{ts '2004-05-08 12:29:51.000'},'DBO_PO','Fondo Credito',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:29:51.000'},'''DBO_PO''',null,'ASSISTENZA','2','FONDCRED')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '38')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:32:54.000'},cu = 'DBO_PO',description = 'INPDAP Amministrazione',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2009-01-13 13:52:53.017'},lu = 'SARA',maintaxcode = null,taxablecode = null,taxkind = '3',taxref = 'IMPDAPAMM' WHERE taxcode = '38'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('38','N',null,{ts '2004-05-08 12:32:54.000'},'DBO_PO','INPDAP Amministrazione',null,null,'N',null,null,null,null,null,{ts '2009-01-13 13:52:53.017'},'SARA',null,null,'3','IMPDAPAMM')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '39')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:43:11.000'},cu = 'DBO_PO',description = 'INAIL',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0041',idaccmotive_debit = null,idaccmotive_pay = '00200001',insuranceagencycode = null,lt = {ts '2015-12-11 18:52:16.793'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'INAIL.' WHERE taxcode = '39'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('39','N',null,{ts '2004-05-08 12:43:11.000'},'DBO_PO','INAIL',null,null,'N',null,'0041',null,'00200001',null,{ts '2015-12-11 18:52:16.793'},'assistenza',null,'ASSISTENZA','2','INAIL.')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '40')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:33:43.000'},cu = 'DBO_PO',description = 'INPDAP Dipendenti',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:33:43.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '3',taxref = 'INPDAPDIPE' WHERE taxcode = '40'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('40','N',null,{ts '2004-05-08 12:33:43.000'},'DBO_PO','INPDAP Dipendenti',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:33:43.000'},'''DBO_PO''',null,null,'3','INPDAPDIPE')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '41')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:38:49.000'},cu = 'DBO_PO',description = 'INPS 10%',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:38:49.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '3',taxref = 'INPS.MUT' WHERE taxcode = '41'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('41','N',null,{ts '2004-05-08 12:38:49.000'},'DBO_PO','INPS 10%',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:38:49.000'},'''DBO_PO''',null,null,'3','INPS.MUT')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '42')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:38:27.000'},cu = 'DBO_PO',description = 'INPS 18%',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:38:27.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '3',taxref = 'INPS.NOMUT' WHERE taxcode = '42'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('42','N',null,{ts '2004-05-08 12:38:27.000'},'DBO_PO','INPS 18%',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:38:27.000'},'''DBO_PO''',null,null,'3','INPS.NOMUT')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '43')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:39:17.000'},cu = 'DBO_PO',description = 'INPS 15%',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:39:17.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '3',taxref = 'INPS.PENS' WHERE taxcode = '43'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('43','N',null,{ts '2004-05-08 12:39:17.000'},'DBO_PO','INPS 15%',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:39:17.000'},'''DBO_PO''',null,null,'3','INPS.PENS')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '44')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:40:23.000'},cu = 'DBO_PO',description = 'IRAP assimilati',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-13 11:21:31.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'IRAPASS' WHERE taxcode = '44'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('44','N',null,{ts '2004-05-08 12:40:23.000'},'DBO_PO','IRAP assimilati',null,null,'N',null,null,null,null,null,{ts '2004-05-13 11:21:31.000'},'''DBO_PO''',null,'ASSISTENZA','2','IRAPASS')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '45')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:41:46.000'},cu = 'DBO_PO',description = 'IRAP occasionali',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-13 11:21:34.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'IRAPAUT' WHERE taxcode = '45'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('45','N',null,{ts '2004-05-08 12:41:46.000'},'DBO_PO','IRAP occasionali',null,null,'N',null,null,null,null,null,{ts '2004-05-13 11:21:34.000'},'''DBO_PO''',null,'ASSISTENZA','2','IRAPAUT')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '46')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1999-06-21 09:42:33.000'},cu = '''DBO_PO''',description = 'ZZZ - IRAPBO',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2007-07-02 09:49:34.377'},lu = '''SARA''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'IRAPBO' WHERE taxcode = '46'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('46','N',null,{ts '1999-06-21 09:42:33.000'},'''DBO_PO''','ZZZ - IRAPBO',null,null,'N',null,null,null,null,null,{ts '2007-07-02 09:49:34.377'},'''SARA''',null,'ASSISTENZA','2','IRAPBO')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '47')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:40:52.000'},cu = 'DBO_PO',description = 'IRAP borsisti',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-13 11:21:39.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'IRAPBORS' WHERE taxcode = '47'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('47','N',null,{ts '2004-05-08 12:40:52.000'},'DBO_PO','IRAP borsisti',null,null,'N',null,null,null,null,null,{ts '2004-05-13 11:21:39.000'},'''DBO_PO''',null,'ASSISTENZA','2','IRAPBORS')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '48')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:41:24.000'},cu = 'DBO_PO',description = 'IRAP co.co.co.',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-13 11:21:41.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'IRAPCOCO' WHERE taxcode = '48'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('48','N',null,{ts '2004-05-08 12:41:24.000'},'DBO_PO','IRAP co.co.co.',null,null,'N',null,null,null,null,null,{ts '2004-05-13 11:21:41.000'},'''DBO_PO''',null,'ASSISTENZA','2','IRAPCOCO')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '49')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2007-07-02 09:53:10.063'},cu = '''SARA''',description = 'IRAP autonomi/assimilati 1',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '00210001',idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2015-11-10 20:48:23.720'},lu = 'assistenza',maintaxcode = null,taxablecode = null,taxkind = '2',taxref = 'IRAPCOORD1' WHERE taxcode = '49'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('49','S',null,{ts '2007-07-02 09:53:10.063'},'''SARA''','IRAP autonomi/assimilati 1',null,null,'N',null,'00210001',null,null,null,{ts '2015-11-10 20:48:23.720'},'assistenza',null,null,'2','IRAPCOORD1')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '50')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:39:59.000'},cu = 'DBO_PO',description = 'IRAP dipendenti',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = 'R',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2006-03-08 16:29:06.157'},lu = '''SARA''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'IRAPDIP' WHERE taxcode = '50'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('50','N',null,{ts '2004-05-08 12:39:59.000'},'DBO_PO','IRAP dipendenti',null,null,'N','R',null,null,null,null,{ts '2006-03-08 16:29:06.157'},'''SARA''',null,'ASSISTENZA','2','IRAPDIP')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '51')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:42:25.000'},cu = 'DBO_PO',description = 'IRAP non residenti',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-13 11:21:47.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'IRAPSTRA' WHERE taxcode = '51'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('51','N',null,{ts '2004-05-08 12:42:25.000'},'DBO_PO','IRAP non residenti',null,null,'N',null,null,null,null,null,{ts '2004-05-13 11:21:47.000'},'''DBO_PO''',null,'ASSISTENZA','2','IRAPSTRA')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '52')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:21:20.000'},cu = 'DBO_PO',description = 'Ritenuta IRPEF assimilati',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:21:20.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'IRPEFASS' WHERE taxcode = '52'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('52','N',null,{ts '2004-05-08 12:21:20.000'},'DBO_PO','Ritenuta IRPEF assimilati',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:21:20.000'},'''DBO_PO''',null,null,'1','IRPEFASS')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '53')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1999-06-23 12:40:59.790'},cu = '''DBO_PO''',description = 'ZZZ - IRPEFBO',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '1999-06-23 12:40:59.790'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'IRPEFBO' WHERE taxcode = '53'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('53','N',null,{ts '1999-06-23 12:40:59.790'},'''DBO_PO''','ZZZ - IRPEFBO',null,null,'N',null,null,null,null,null,{ts '1999-06-23 12:40:59.790'},'''DBO_PO''',null,null,'1','IRPEFBO')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '54')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:22:18.000'},cu = 'DBO_PO',description = 'Ritenuta IRPEF borsisti',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:22:18.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'IRPEFBOR' WHERE taxcode = '54'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('54','N',null,{ts '2004-05-08 12:22:18.000'},'DBO_PO','Ritenuta IRPEF borsisti',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:22:18.000'},'''DBO_PO''',null,null,'1','IRPEFBOR')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '55')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:23:03.000'},cu = 'DBO_PO',description = 'Ritenuta IRPEF co.co.co.',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:23:03.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'IRPEFCOCO' WHERE taxcode = '55'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('55','N',null,{ts '2004-05-08 12:23:03.000'},'DBO_PO','Ritenuta IRPEF co.co.co.',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:23:03.000'},'''DBO_PO''',null,null,'1','IRPEFCOCO')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '56')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:20:40.000'},cu = 'DBO_PO',description = 'Ritenuta IRPEF dipendenti',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:20:40.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'IRPEFDIP' WHERE taxcode = '56'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('56','N',null,{ts '2004-05-08 12:20:40.000'},'DBO_PO','Ritenuta IRPEF dipendenti',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:20:40.000'},'''DBO_PO''',null,null,'1','IRPEFDIP')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '57')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2000-07-19 10:02:09.950'},cu = '''DBO_PO''',description = 'ZZZ - IRPEFF',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2008-04-23 10:36:41.280'},lu = 'SARA',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = 'IRPEFF' WHERE taxcode = '57'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('57','N',null,{ts '2000-07-19 10:02:09.950'},'''DBO_PO''','ZZZ - IRPEFF',null,null,'N',null,null,null,null,null,{ts '2008-04-23 10:36:41.280'},'SARA',null,'IRPEF','1','IRPEFF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '58')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2004-05-08 12:19:22.000'},cu = 'DBO_PO',description = 'IRPEF Ritenuta d''acconto 20%',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2004-05-08 12:19:22.000'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '1',taxref = 'RITACC' WHERE taxcode = '58'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('58','N',null,{ts '2004-05-08 12:19:22.000'},'DBO_PO','IRPEF Ritenuta d''acconto 20%',null,null,'N',null,null,null,null,null,{ts '2004-05-08 12:19:22.000'},'''DBO_PO''',null,null,'1','RITACC')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '59')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '1998-08-06 17:40:41.760'},cu = '''DBO_PO''',description = 'ZZZ - SSN',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2007-06-25 11:51:10.953'},lu = '''SARA''',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = 'SSN' WHERE taxcode = '59'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('59','N',null,{ts '1998-08-06 17:40:41.760'},'''DBO_PO''','ZZZ - SSN',null,null,'N',null,null,null,null,null,{ts '2007-06-25 11:51:10.953'},'''SARA''',null,'ASSISTENZA','2','SSN')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '60')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2000-07-19 10:00:47.390'},cu = '''DBO_PO''',description = 'ZZZ - TES',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2000-07-19 10:00:47.390'},lu = '''DBO_PO''',maintaxcode = null,taxablecode = null,taxkind = '3',taxref = 'TES' WHERE taxcode = '60'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('60','N',null,{ts '2000-07-19 10:00:47.390'},'''DBO_PO''','ZZZ - TES',null,null,'N',null,null,null,null,null,{ts '2000-07-19 10:00:47.390'},'''DBO_PO''',null,null,'3','TES')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '61')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2007-12-20 15:43:45.313'},cu = 'SA',description = 'Rit. acconto sul 50% del lordo',fiscaltaxcode = '104E',fiscaltaxcodecredit = '156E',flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2007-12-20 15:43:45.313'},lu = 'SA',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_ACC_DAT_50' WHERE taxcode = '61'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('61','S',null,{ts '2007-12-20 15:43:45.313'},'SA','Rit. acconto sul 50% del lordo','104E','156E','S',null,null,null,null,null,{ts '2007-12-20 15:43:45.313'},'SA',null,'IRPEF','1','07_ACC_DAT_50')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '62')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2017-07-04 11:58:16.110'},cu = 'assistenza',description = 'INPS contributo DIS_COLL',fiscaltaxcode = 'CXX',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2017-07-04 11:58:16.110'},lu = 'assistenza',maintaxcode = '14',taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '17_INPS_DIS_COLL_N' WHERE taxcode = '62'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('62','S',null,{ts '2017-07-04 11:58:16.110'},'assistenza','INPS contributo DIS_COLL','CXX',null,'N',null,null,null,null,null,{ts '2017-07-04 11:58:16.110'},'assistenza','14','PREVIDENZA','3','17_INPS_DIS_COLL_N')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '63')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2018-01-31 12:57:11.180'},cu = 'assistenza',description = 'ENPAPI soggetti mutuati',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2018-01-31 13:31:26.807'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '18_ENPAPI_N' WHERE taxcode = '63'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('63','S',null,{ts '2018-01-31 12:57:11.180'},'assistenza','ENPAPI soggetti mutuati',null,null,'N',null,null,null,null,null,{ts '2018-01-31 13:31:26.807'},'assistenza',null,'PREVIDENZA','3','18_ENPAPI_N')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '64')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {d '2006-01-01'},cu = 'Software and more',description = 'Ritenuta Falsa Inail',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = '00200001',idaccmotive_pay = '0022',insuranceagencycode = null,lt = {ts '2008-07-01 14:11:14.047'},lu = 'SARA',maintaxcode = null,taxablecode = 'ASSICUR',taxkind = '4',taxref = 'FALSA INAIL' WHERE taxcode = '64'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('64','N',null,{d '2006-01-01'},'Software and more','Ritenuta Falsa Inail',null,null,'N',null,null,'00200001','0022',null,{ts '2008-07-01 14:11:14.047'},'SARA',null,'ASSICUR','4','FALSA INAIL')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '65')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2008-02-19 13:42:00.360'},cu = 'SA',description = 'Ritenuta IRPEF legge n. 326 del 2003',fiscaltaxcode = '100E',fiscaltaxcodecredit = '155E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2008-02-19 13:42:00.360'},lu = 'SA',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_IRPEF_L.326/03' WHERE taxcode = '65'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('65','S',null,{ts '2008-02-19 13:42:00.360'},'SA','Ritenuta IRPEF legge n. 326 del 2003','100E','155E','N',null,null,null,null,null,{ts '2008-02-19 13:42:00.360'},'SA',null,'IRPEF','1','07_IRPEF_L.326/03')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '66')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2008-02-22 11:30:00.140'},cu = 'SA',description = 'INPS legge n. 326 del 2003',fiscaltaxcode = 'CXX',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0023',idaccmotive_debit = '00210001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2009-10-02 12:53:30.670'},lu = 'SARA',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '07_INPS_L.326/03' WHERE taxcode = '66'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('66','S',null,{ts '2008-02-22 11:30:00.140'},'SA','INPS legge n. 326 del 2003','CXX',null,'N',null,'0023','00210001','00210002',null,{ts '2009-10-02 12:53:30.670'},'SARA',null,'PREVIDENZA','3','07_INPS_L.326/03')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '67')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2008-04-04 15:34:48.157'},cu = 'SA',description = 'Ritenuta IRPEF stranieri Co.Co.Co.',fiscaltaxcode = '100E',fiscaltaxcodecredit = '155E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2008-04-04 15:34:48.157'},lu = 'SA',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '08_IRPEF_FOC' WHERE taxcode = '67'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('67','S',null,{ts '2008-04-04 15:34:48.157'},'SA','Ritenuta IRPEF stranieri Co.Co.Co.','100E','155E','N',null,null,null,null,null,{ts '2008-04-04 15:34:48.157'},'SA',null,'IRPEF','1','08_IRPEF_FOC')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '68')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2008-05-12 10:35:49.577'},cu = 'SARA',description = 'Ritenuta su premi e vincite art.30 DPR 600/73',fiscaltaxcode = '107E',fiscaltaxcodecredit = null,flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2008-05-12 10:04:24.063'},lu = 'SARA',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '08_IMPOSTA_PREMI' WHERE taxcode = '68'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('68','S',null,{ts '2008-05-12 10:35:49.577'},'SARA','Ritenuta su premi e vincite art.30 DPR 600/73','107E',null,'S',null,null,null,null,null,{ts '2008-05-12 10:04:24.063'},'SARA',null,'IRPEF','1','08_IMPOSTA_PREMI')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '69')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2008-05-29 11:21:53.963'},cu = 'NINO',description = 'Addizionale Comunale Rateizzata',fiscaltaxcode = '384E',fiscaltaxcodecredit = '161E',flagunabatable = 'N',geoappliance = 'C',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2008-05-29 12:52:37.747'},lu = 'NINO',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '08_ADDCOMRATA' WHERE taxcode = '69'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('69','S',null,{ts '2008-05-29 11:21:53.963'},'NINO','Addizionale Comunale Rateizzata','384E','161E','N','C',null,null,null,null,{ts '2008-05-29 12:52:37.747'},'NINO',null,'ADDIRPEF','5','08_ADDCOMRATA')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '70')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2008-05-29 11:22:29.120'},cu = 'NINO',description = 'Addizionale Regionale Rateizzata',fiscaltaxcode = '381E',fiscaltaxcodecredit = '160E',flagunabatable = 'N',geoappliance = 'R',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2008-05-29 12:52:40.980'},lu = 'NINO',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '08_ADDREGRATA' WHERE taxcode = '70'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('70','S',null,{ts '2008-05-29 11:22:29.120'},'NINO','Addizionale Regionale Rateizzata','381E','160E','N','R',null,null,null,null,{ts '2008-05-29 12:52:40.980'},'NINO',null,'ADDIRPEF','5','08_ADDREGRATA')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '71')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {d '2008-06-13'},cu = 'SARA',description = 'Ritenuta d''acconto 4%',fiscaltaxcode = '106E',fiscaltaxcodecredit = null,flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2016-03-17 17:16:53.357'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '08_RITACC_4' WHERE taxcode = '71'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('71','S',null,{d '2008-06-13'},'SARA','Ritenuta d''acconto 4%','106E',null,'S',null,null,null,null,null,{ts '2016-03-17 17:16:53.357'},'assistenza',null,'IRPEF','1','08_RITACC_4')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '72')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2008-07-17 10:41:54.627'},cu = 'NINO',description = 'Acconto Addizionale Comunale da CAF',fiscaltaxcode = '127E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = 'C',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2008-07-17 10:50:01.437'},lu = 'NINO',maintaxcode = null,taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '08_ACCADDCOMCAF' WHERE taxcode = '72'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('72','S',null,{ts '2008-07-17 10:41:54.627'},'NINO','Acconto Addizionale Comunale da CAF','127E',null,'N','C',null,null,null,null,{ts '2008-07-17 10:50:01.437'},'NINO',null,'ADDIRPEF','5','08_ACCADDCOMCAF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '73')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2009-04-17 10:36:08.110'},cu = 'SA',description = 'IRAP autonomi/assimilati attività commerciale',fiscaltaxcode = '380E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2009-04-17 10:36:08.110'},lu = 'SA',maintaxcode = null,taxablecode = null,taxkind = '2',taxref = '09_IRAP_COMMERC' WHERE taxcode = '73'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('73','S',null,{ts '2009-04-17 10:36:08.110'},'SA','IRAP autonomi/assimilati attività commerciale','380E',null,'N',null,null,null,null,null,{ts '2009-04-17 10:36:08.110'},'SA',null,null,'2','09_IRAP_COMMERC')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '74')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2009-05-05 11:14:22.647'},cu = 'SARA',description = 'Ritenuta d''Acconto per prestazioni Esenti',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2009-05-05 11:31:53.803'},lu = 'SARA',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '07_ACC_FISC_ESE' WHERE taxcode = '74'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('74','S',null,{ts '2009-05-05 11:14:22.647'},'SARA','Ritenuta d''Acconto per prestazioni Esenti',null,null,'N',null,null,null,null,null,{ts '2009-05-05 11:31:53.803'},'SARA',null,'IRPEF','1','07_ACC_FISC_ESE')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '75')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2011-04-18 13:35:17.483'},cu = 'sara',description = 'Ritenuta alla fonte su somme pignorate',fiscaltaxcode = '112E',fiscaltaxcodecredit = null,flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2011-06-08 12:16:12.703'},lu = 'sara',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '11_ACC_PIGNORA' WHERE taxcode = '75'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('75','S',null,{ts '2011-04-18 13:35:17.483'},'sara','Ritenuta alla fonte su somme pignorate','112E',null,'S',null,null,null,null,null,{ts '2011-06-08 12:16:12.703'},'sara',null,'IRPEF','1','11_ACC_PIGNORA')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '76')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2012-04-02 14:59:19.610'},cu = 'sa',description = 'Esenzione su Premi',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2012-04-02 15:00:02.280'},lu = 'sa',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '12_PREMI_ES' WHERE taxcode = '76'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('76','S',null,{ts '2012-04-02 14:59:19.610'},'sa','Esenzione su Premi',null,null,'N',null,null,null,null,null,{ts '2012-04-02 15:00:02.280'},'sa',null,'IRPEF','1','12_PREMI_ES')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '77')
UPDATE [tax] SET active = 'S',appliancebasis = 'C',ct = {ts '2012-04-11 12:19:43.813'},cu = 'sa',description = 'Ritenuta ENPALS',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0041',idaccmotive_debit = '00200001',idaccmotive_pay = '00210002',insuranceagencycode = 'P59',lt = {ts '2016-09-14 09:29:18.163'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '3',taxref = '12_ENPALS' WHERE taxcode = '77'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('77','S','C',{ts '2012-04-11 12:19:43.813'},'sa','Ritenuta ENPALS',null,null,'N',null,'0041','00200001','00210002','P59',{ts '2016-09-14 09:29:18.163'},'assistenza',null,'IRPEF','3','12_ENPALS')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '78')
UPDATE [tax] SET active = 'S',appliancebasis = 'C',ct = {ts '2014-02-01 17:09:06.550'},cu = 'Nino',description = 'Ritenuta erariale',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = 'N',idaccmotive_cost = '0025',idaccmotive_debit = '00200001',idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2015-12-15 20:20:53.847'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ERARIALE',taxkind = '6',taxref = '14_ERARIALE' WHERE taxcode = '78'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('78','S','C',{ts '2014-02-01 17:09:06.550'},'Nino','Ritenuta erariale',null,null,'N','N','0025','00200001',null,null,{ts '2015-12-15 20:20:53.847'},'assistenza',null,'ERARIALE','6','14_ERARIALE')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '79')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2014-02-27 09:24:16.073'},cu = 'sa',description = 'Riduzione Erariale',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0025',idaccmotive_debit = '00200001',idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2015-12-15 20:18:19.623'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ERARIALE',taxkind = '6',taxref = '14_RID.ERARIALE' WHERE taxcode = '79'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('79','S',null,{ts '2014-02-27 09:24:16.073'},'sa','Riduzione Erariale',null,null,'N',null,'0025','00200001',null,null,{ts '2015-12-15 20:18:19.623'},'assistenza',null,'ERARIALE','6','14_RID.ERARIALE')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '80')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2014-02-25 10:48:15.393'},cu = 'sa',description = 'Ritenuta fiscale su imponibile 10%',fiscaltaxcode = '100E',fiscaltaxcodecredit = '155E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2014-02-25 10:48:15.393'},lu = 'sa',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '14_IRPEF_IMP10%' WHERE taxcode = '80'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('80','S',null,{ts '2014-02-25 10:48:15.393'},'sa','Ritenuta fiscale su imponibile 10%','100E','155E','N',null,null,null,null,null,{ts '2014-02-25 10:48:15.393'},'sa',null,'IRPEF','1','14_IRPEF_IMP10%')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '81')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2014-05-09 13:05:59.803'},cu = 'assistenza',description = 'Bonus fiscale Decreto 24 aprile 2014, n. 6,  Art 1',fiscaltaxcode = null,fiscaltaxcodecredit = '165E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2014-05-09 13:09:19.637'},lu = 'assistenza',maintaxcode = null,taxablecode = 'BONUSFISCALE',taxkind = '1',taxref = '14_BONUS_FISCALE' WHERE taxcode = '81'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('81','S',null,{ts '2014-05-09 13:05:59.803'},'assistenza','Bonus fiscale Decreto 24 aprile 2014, n. 6,  Art 1',null,'165E','N',null,null,null,null,null,{ts '2014-05-09 13:09:19.637'},'assistenza',null,'BONUSFISCALE','1','14_BONUS_FISCALE')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '82')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2015-10-09 16:37:19.943'},cu = 'assistenza',description = 'Ritenuta IRPEF su imponibile 20% ',fiscaltaxcode = '100E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = '00210001',idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2015-10-09 16:37:19.943'},lu = 'assistenza',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = 'IRPEF_SU_20' WHERE taxcode = '82'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('82','S',null,{ts '2015-10-09 16:37:19.943'},'assistenza','Ritenuta IRPEF su imponibile 20% ','100E',null,'N',null,null,'00210001','00210002',null,{ts '2015-10-09 16:37:19.943'},'assistenza',null,'IRPEF','1','IRPEF_SU_20')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '83')
UPDATE [tax] SET active = 'N',appliancebasis = null,ct = {ts '2015-11-23 09:17:03.313'},cu = 'assistenza',description = 'Enpals - lavoratori dello spettacolo',fiscaltaxcode = 'DM10',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '0041',idaccmotive_debit = '00200001',idaccmotive_pay = null,insuranceagencycode = 'P59',lt = {ts '2016-09-14 09:29:00.553'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = 'ENPALS_SPETTACOLO' WHERE taxcode = '83'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('83','N',null,{ts '2015-11-23 09:17:03.313'},'assistenza','Enpals - lavoratori dello spettacolo','DM10',null,'N',null,'0041','00200001',null,'P59',{ts '2016-09-14 09:29:00.553'},'assistenza',null,'PREVIDENZA','3','ENPALS_SPETTACOLO')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '84')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2016-03-16 11:18:52.337'},cu = 'assistenza',description = 'Enpals Spettacolo Pre95 - 1',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = 'P59',lt = {ts '2016-09-14 09:28:56.257'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '16_ENPALS_PRE95_1' WHERE taxcode = '84'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('84','S',null,{ts '2016-03-16 11:18:52.337'},'assistenza','Enpals Spettacolo Pre95 - 1',null,null,'N',null,null,null,null,'P59',{ts '2016-09-14 09:28:56.257'},'assistenza',null,'PREVIDENZA','3','16_ENPALS_PRE95_1')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '85')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2016-03-16 11:19:59.793'},cu = 'assistenza',description = 'Enpals Spettacolo Pre95 - 2',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = 'P59',lt = {ts '2016-09-14 09:28:52.333'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '16_ENPALS_PRE95_2' WHERE taxcode = '85'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('85','S',null,{ts '2016-03-16 11:19:59.793'},'assistenza','Enpals Spettacolo Pre95 - 2',null,null,'N',null,null,null,null,'P59',{ts '2016-09-14 09:28:52.333'},'assistenza',null,'PREVIDENZA','3','16_ENPALS_PRE95_2')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '86')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2016-03-16 11:20:20.043'},cu = 'assistenza',description = 'Enpals Spettacolo Pre95 - 3',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = 'P59',lt = {ts '2016-09-14 09:28:48.097'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '16_ENPALS_PRE95_3' WHERE taxcode = '86'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('86','S',null,{ts '2016-03-16 11:20:20.043'},'assistenza','Enpals Spettacolo Pre95 - 3',null,null,'N',null,null,null,null,'P59',{ts '2016-09-14 09:28:48.097'},'assistenza',null,'PREVIDENZA','3','16_ENPALS_PRE95_3')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '87')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2016-03-16 11:16:32.973'},cu = 'assistenza',description = 'Enpals Spettacolo Post95 - 1',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = 'P59',lt = {ts '2016-09-14 09:28:43.833'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '16_ENPALS_POST95_1' WHERE taxcode = '87'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('87','S',null,{ts '2016-03-16 11:16:32.973'},'assistenza','Enpals Spettacolo Post95 - 1',null,null,'N',null,null,null,null,'P59',{ts '2016-09-14 09:28:43.833'},'assistenza',null,'PREVIDENZA','3','16_ENPALS_POST95_1')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '88')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2016-03-16 11:16:53.580'},cu = 'assistenza',description = 'Enpals Spettacolo Post95 - 2',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = 'P59',lt = {ts '2016-09-14 09:28:36.957'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '16_ENPALS_POST95_2' WHERE taxcode = '88'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('88','S',null,{ts '2016-03-16 11:16:53.580'},'assistenza','Enpals Spettacolo Post95 - 2',null,null,'N',null,null,null,null,'P59',{ts '2016-09-14 09:28:36.957'},'assistenza',null,'PREVIDENZA','3','16_ENPALS_POST95_2')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '89')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2016-03-16 11:17:07.957'},cu = 'assistenza',description = 'Enpals Spettacolo Post95 - 3',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = 'P59',lt = {ts '2016-09-14 09:28:32.893'},lu = 'assistenza',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '16_ENPALS_POST95_3' WHERE taxcode = '89'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('89','S',null,{ts '2016-03-16 11:17:07.957'},'assistenza','Enpals Spettacolo Post95 - 3',null,null,'N',null,null,null,null,'P59',{ts '2016-09-14 09:28:32.893'},'assistenza',null,'PREVIDENZA','3','16_ENPALS_POST95_3')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '90')
UPDATE [tax] SET active = 'S',appliancebasis = 'S',ct = {ts '2016-10-14 10:37:01.973'},cu = 'assistenza',description = 'Rimborsi IRPEF da dichiarazione C.A.F.',fiscaltaxcode = null,fiscaltaxcodecredit = '150E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2016-10-14 16:27:41.630'},lu = 'assistenza',maintaxcode = '20',taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '16_REFUND_IRPEF_CAF' WHERE taxcode = '90'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('90','S','S',{ts '2016-10-14 10:37:01.973'},'assistenza','Rimborsi IRPEF da dichiarazione C.A.F.',null,'150E','N',null,null,null,null,null,{ts '2016-10-14 16:27:41.630'},'assistenza','20','ADDIRPEF','5','16_REFUND_IRPEF_CAF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '91')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2016-10-14 10:52:46.083'},cu = 'assistenza',description = 'Rimborsi Addizionale Regionale da CAF',fiscaltaxcode = null,fiscaltaxcodecredit = '153E',flagunabatable = 'N',geoappliance = 'R',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2016-10-14 16:27:51.080'},lu = 'assistenza',maintaxcode = '9',taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '16_REFUND_ADDREGCAF' WHERE taxcode = '91'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('91','S',null,{ts '2016-10-14 10:52:46.083'},'assistenza','Rimborsi Addizionale Regionale da CAF',null,'153E','N','R',null,null,null,null,{ts '2016-10-14 16:27:51.080'},'assistenza','9','ADDIRPEF','5','16_REFUND_ADDREGCAF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '92')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2016-10-14 10:53:52.213'},cu = 'assistenza',description = 'Rimborsi Addizionale Comunale da CAF',fiscaltaxcode = null,fiscaltaxcodecredit = '154E',flagunabatable = 'N',geoappliance = 'C',idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00210002',insuranceagencycode = null,lt = {ts '2016-10-14 16:27:58.937'},lu = 'assistenza',maintaxcode = '8',taxablecode = 'ADDIRPEF',taxkind = '5',taxref = '16_REFUND_ADDCOMCAF' WHERE taxcode = '92'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('92','S',null,{ts '2016-10-14 10:53:52.213'},'assistenza','Rimborsi Addizionale Comunale da CAF',null,'154E','N','C',null,null,'00210002',null,{ts '2016-10-14 16:27:58.937'},'assistenza','8','ADDIRPEF','5','16_REFUND_ADDCOMCAF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '93')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2014-03-25 10:18:08.157'},cu = 'assistenza',description = 'IRAP autonomi/assimilati visiting professor',fiscaltaxcode = '380E',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '00140006',idaccmotive_debit = '000500020001',idaccmotive_pay = '00050001000100040005',insuranceagencycode = null,lt = {ts '2016-03-03 15:19:30.077'},lu = 'uccello.super',maintaxcode = null,taxablecode = 'ASSISTENZA',taxkind = '2',taxref = '14_IRAPVISITINGPROF' WHERE taxcode = '93'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('93','S',null,{ts '2014-03-25 10:18:08.157'},'assistenza','IRAP autonomi/assimilati visiting professor','380E',null,'N',null,'00140006','000500020001','00050001000100040005',null,{ts '2016-03-03 15:19:30.077'},'uccello.super',null,'ASSISTENZA','2','14_IRAPVISITINGPROF')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '94')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2014-03-25 10:19:56.707'},cu = 'assistenza',description = 'INPS soggetti non mutuati visting professor',fiscaltaxcode = 'CXX',fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = '00140005',idaccmotive_debit = '000500020003',idaccmotive_pay = '00050001000100040004',insuranceagencycode = null,lt = {ts '2016-03-04 15:51:49.030'},lu = 'assistenza8',maintaxcode = null,taxablecode = 'PREVIDENZA',taxkind = '3',taxref = '14_INPS_N_VISITING' WHERE taxcode = '94'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('94','S',null,{ts '2014-03-25 10:19:56.707'},'assistenza','INPS soggetti non mutuati visting professor','CXX',null,'N',null,'00140005','000500020003','00050001000100040004',null,{ts '2016-03-04 15:51:49.030'},'assistenza8',null,'PREVIDENZA','3','14_INPS_N_VISITING')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '95')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2014-03-25 10:36:52.147'},cu = 'assistenza',description = 'Ritenuta Inail Visiting Professor',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = '000500020004',idaccmotive_pay = '00050001000100040009',insuranceagencycode = null,lt = {ts '2014-03-25 10:36:52.147'},lu = 'assistenza',maintaxcode = null,taxablecode = 'ASSICUR',taxkind = '4',taxref = '14_INAIL_VISITING' WHERE taxcode = '95'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('95','S',null,{ts '2014-03-25 10:36:52.147'},'assistenza','Ritenuta Inail Visiting Professor',null,null,'N',null,null,'000500020004','00050001000100040009',null,{ts '2014-03-25 10:36:52.147'},'assistenza',null,'ASSICUR','4','14_INAIL_VISITING')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '98')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2019-03-18 14:43:48.903'},cu = 'Assistenza11',description = 'Rit.acconto 20% su 10% lordo',fiscaltaxcode = '104E',fiscaltaxcodecredit = '156E',flagunabatable = 'S',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2019-03-18 14:43:48.903'},lu = 'Assistenza11',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '19_ACC_CER' WHERE taxcode = '98'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('98','S',null,{ts '2019-03-18 14:43:48.903'},'Assistenza11','Rit.acconto 20% su 10% lordo','104E','156E','S',null,null,null,null,null,{ts '2019-03-18 14:43:48.903'},'Assistenza11',null,'IRPEF','1','19_ACC_CER')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '99')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2020-03-26 11:06:29.080'},cu = 'Assistenza11',description = 'Ritenuta d''Acconto 0% DL18/2020 Cura Italia',fiscaltaxcode = null,fiscaltaxcodecredit = null,flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = null,insuranceagencycode = null,lt = {ts '2020-03-26 11:06:29.080'},lu = 'Assistenza11',maintaxcode = null,taxablecode = 'IRPEF',taxkind = '1',taxref = '20_ACC_FISC_DL182020' WHERE taxcode = '99'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('99','S',null,{ts '2020-03-26 11:06:29.080'},'Assistenza11','Ritenuta d''Acconto 0% DL18/2020 Cura Italia',null,null,'N',null,null,null,null,null,{ts '2020-03-26 11:06:29.080'},'Assistenza11',null,'IRPEF','1','20_ACC_FISC_DL182020')
GO

IF exists(SELECT * FROM [tax] WHERE taxcode = '100')
UPDATE [tax] SET active = 'S',appliancebasis = null,ct = {ts '2020-09-08 12:51:41.240'},cu = 'Assistenza11',description = 'Bonus fiscale DL 3/2020',fiscaltaxcode = null,fiscaltaxcodecredit = '165E',flagunabatable = 'N',geoappliance = null,idaccmotive_cost = null,idaccmotive_debit = null,idaccmotive_pay = '00050001000100050011',insuranceagencycode = null,lt = {ts '2020-09-08 12:53:31.230'},lu = 'Assistenza11',maintaxcode = '18',taxablecode = 'BONUSFISCALE',taxkind = '1',taxref = '20_BONUS_FISCALE' WHERE taxcode = '100'
ELSE
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,fiscaltaxcodecredit,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,insuranceagencycode,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('100','S',null,{ts '2020-09-08 12:51:41.240'},'Assistenza11','Bonus fiscale DL 3/2020',null,'165E','N',null,null,null,'00050001000100050011',null,{ts '2020-09-08 12:53:31.230'},'Assistenza11','18','BONUSFISCALE','1','20_BONUS_FISCALE')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tax')
UPDATE [tabledescr] SET description = 'Tipi di ritenuta',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 17:43:00.850'},lu = 'assistenza',title = 'Tipi di ritenuta' WHERE tablename = 'tax'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tax','Tipi di ritenuta','3','S',{ts '2021-02-19 17:43:00.850'},'assistenza','Tipi di ritenuta')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '1900-01-01 02:59:57.473'},lu = 'lu',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','tax','1',null,null,'attivo','S',{ts '1900-01-01 02:59:57.473'},'lu','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'appliancebasis' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Principio di applicazione: C Competenza - A Cassa Allargato - S Cassa',kind = 'S',lt = {ts '1900-01-01 03:00:24.070'},lu = 'lu',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'appliancebasis' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('appliancebasis','tax','1',null,null,'Principio di applicazione: C Competenza - A Cassa Allargato - S Cassa','S',{ts '1900-01-01 03:00:24.070'},'lu','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:48.470'},lu = 'lu',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tax','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:48.470'},'lu','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.903'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tax','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.903'},'lu','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:51.823'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','tax','50',null,null,'Descrizione','S',{ts '1900-01-01 02:59:51.823'},'lu','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fiscaltaxcode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice tributo/Causale contributo',kind = 'S',lt = {ts '1900-01-01 03:00:24.073'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'fiscaltaxcode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fiscaltaxcode','tax','20',null,null,'Codice tributo/Causale contributo','S',{ts '1900-01-01 03:00:24.073'},'lu','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagunabatable' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Ritenuta indetraibile',kind = 'C',lt = {ts '2016-02-07 11:10:49.143'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagunabatable' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagunabatable','tax','1',null,null,'Ritenuta indetraibile','C',{ts '2016-02-07 11:10:49.143'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'geoappliance' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Tipo applicazione geografica: N Nulla- R Regionale - P Provinciale - C comunale',kind = 'S',lt = {ts '1900-01-01 02:59:11.967'},lu = 'lu',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'geoappliance' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('geoappliance','tax','1',null,null,'Tipo applicazione geografica: N Nulla- R Regionale - P Provinciale - C comunale','S',{ts '1900-01-01 02:59:11.967'},'lu','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive_cost' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'ID Causale di Costo (tab. Accmotive)',kind = 'S',lt = {ts '1900-01-01 02:59:11.970'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotive_cost' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive_cost','tax','36',null,null,'ID Causale di Costo (tab. Accmotive)','S',{ts '1900-01-01 02:59:11.970'},'lu','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive_debit' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'ID Causale di Debito (tab. Accmotive)',kind = 'S',lt = {ts '1900-01-01 02:59:11.973'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotive_debit' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive_debit','tax','36',null,null,'ID Causale di Debito (tab. Accmotive)','S',{ts '1900-01-01 02:59:11.973'},'lu','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive_pay' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'ID Causale Liquidazione Ritenute (tab. Accmotive)',kind = 'S',lt = {ts '1900-01-01 02:59:11.977'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotive_pay' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive_pay','tax','36',null,null,'ID Causale Liquidazione Ritenute (tab. Accmotive)','S',{ts '1900-01-01 02:59:11.977'},'lu','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'insuranceagencycode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Codice istituto previdenziale DALIA',kind = 'S',lt = {ts '2016-10-09 11:14:16.233'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'insuranceagencycode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('insuranceagencycode','tax','10',null,null,'Codice istituto previdenziale DALIA','S',{ts '2016-10-09 11:14:16.233'},'nino','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:43.277'},lu = 'lu',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tax','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:43.277'},'lu','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:40.307'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tax','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:40.307'},'lu','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'maintaxcode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'ID Ritenuta per Liquidazione (tab. Tax)',kind = 'S',lt = {ts '1900-01-01 02:59:11.987'},lu = 'lu',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'maintaxcode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('maintaxcode','tax','4',null,null,'ID Ritenuta per Liquidazione (tab. Tax)','S',{ts '1900-01-01 02:59:11.987'},'lu','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxablecode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'ID Codice imponibile (tab . Taxablekind)',kind = 'S',lt = {ts '1900-01-01 03:00:27.693'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'taxablecode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxablecode','tax','20',null,null,'ID Codice imponibile (tab . Taxablekind)','S',{ts '1900-01-01 03:00:27.693'},'lu','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxcode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id ritenuta (tabella tax)',kind = 'S',lt = {ts '1900-01-01 03:00:02.403'},lu = 'lu',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'taxcode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxcode','tax','4',null,null,'id ritenuta (tabella tax)','S',{ts '1900-01-01 03:00:02.403'},'lu','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxkind' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Tipo ritenuta: 1 Fiscale- 2 Assistenziale - 3 Previdenziale - 4 Assicurativa - 5 Arretrati - 6 Altro',kind = 'C',lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'taxkind' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxkind','tax','2',null,null,'Tipo ritenuta: 1 Fiscale- 2 Assistenziale - 3 Previdenziale - 4 Assicurativa - 5 Arretrati - 6 Altro','C',{ts '2016-03-10 12:38:52.233'},'nino','N','smallint','smallint','System.Int16')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxref' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'codice riferimento imposta (tabella tax)',kind = 'S',lt = {ts '1900-01-01 03:00:07.363'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'taxref' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxref','tax','20',null,null,'codice riferimento imposta (tabella tax)','S',{ts '1900-01-01 03:00:07.363'},'lu','N','varchar(20)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagunabatable' AND tablename = 'tax' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 11:10:49.143'},lu = 'Nino',title = 'Ritenuta detraibile' WHERE colname = 'flagunabatable' AND tablename = 'tax' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagunabatable','tax','N',null,{ts '2016-02-07 11:10:49.143'},'Nino','Ritenuta detraibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagunabatable' AND tablename = 'tax' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 11:10:49.143'},lu = 'Nino',title = 'Ritenuta indetraibile' WHERE colname = 'flagunabatable' AND tablename = 'tax' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagunabatable','tax','S',null,{ts '2016-02-07 11:10:49.143'},'Nino','Ritenuta indetraibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '1')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Fiscale' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '1'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','1',null,{ts '2016-03-10 12:38:52.233'},'nino','Fiscale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '2')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Assistenziale' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '2'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','2',null,{ts '2016-03-10 12:38:52.233'},'nino','Assistenziale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '3')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Previdenziale' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '3'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','3',null,{ts '2016-03-10 12:38:52.233'},'nino','Previdenziale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '4')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Assicurativa' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '4'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','4',null,{ts '2016-03-10 12:38:52.233'},'nino','Assicurativa')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '5')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Arretrati' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '5'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','5',null,{ts '2016-03-10 12:38:52.233'},'nino','Arretrati')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '6')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Altro' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '6'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','6',null,{ts '2016-03-10 12:38:52.233'},'nino','Altro')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '73')
UPDATE [relation] SET childtable = 'tax',description = 'ID Causale di Costo (tab. Accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Tipi di ritenuta' WHERE idrelation = '73'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('73','tax','ID Causale di Costo (tab. Accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Tipi di ritenuta')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '74')
UPDATE [relation] SET childtable = 'tax',description = 'ID Causale di Debito (tab. Accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Tipi di ritenuta' WHERE idrelation = '74'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('74','tax','ID Causale di Debito (tab. Accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Tipi di ritenuta')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '75')
UPDATE [relation] SET childtable = 'tax',description = 'ID Causale Liquidazione Ritenute (tab. Accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Tipi di ritenuta' WHERE idrelation = '75'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('75','tax','ID Causale Liquidazione Ritenute (tab. Accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Tipi di ritenuta')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3136')
UPDATE [relation] SET childtable = 'tax',description = 'ID Codice imponibile (tab . Taxablekind)',lt = {ts '2017-05-22 15:32:06.610'},lu = 'nino',parenttable = 'taxablekind',title = 'Tipi di ritenuta' WHERE idrelation = '3136'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3136','tax','ID Codice imponibile (tab . Taxablekind)',{ts '2017-05-22 15:32:06.610'},'nino','taxablekind','Tipi di ritenuta')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '73' AND parentcol = 'idaccmotive')
UPDATE [relationcol] SET childcol = 'idaccmotive_cost',lt = {ts '2017-05-20 09:19:36.287'},lu = 'lu' WHERE idrelation = '73' AND parentcol = 'idaccmotive'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('73','idaccmotive','idaccmotive_cost',{ts '2017-05-20 09:19:36.287'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

