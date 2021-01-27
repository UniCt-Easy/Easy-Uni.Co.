
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


-- CREAZIONE TABELLA autokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[autokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[autokind] (
idautokind tinyint NOT NULL,
code varchar(10) NOT NULL,
title varchar(100) NOT NULL,
 CONSTRAINT xpkautokind PRIMARY KEY (idautokind
)
)
END
GO

-- VERIFICA STRUTTURA autokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autokind' and C.name = 'idautokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autokind] ADD idautokind tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('autokind') and col.name = 'idautokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [autokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autokind' and C.name = 'code' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autokind] ADD code varchar(10) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('autokind') and col.name = 'code' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [autokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [autokind] ALTER COLUMN code varchar(10) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autokind] ADD title varchar(100) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('autokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [autokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [autokind] ALTER COLUMN title varchar(100) NOT NULL
GO

-- VERIFICA DI autokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'autokind'
IF exists(SELECT * FROM columntypes WHERE tablename = 'autokind' AND field = 'idautokind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'S',tablename = 'autokind',denynull = 'S',format = '',col_len = '1',field = 'idautokind',col_precision = '' where tablename = 'autokind' AND field = 'idautokind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','S','autokind','S','','1','idautokind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autokind' AND field = 'code')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(10)',iskey = 'N',tablename = 'autokind',denynull = 'S',format = '',col_len = '10',field = 'code',col_precision = '' where tablename = 'autokind' AND field = 'code'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(10)','N','autokind','S','','10','code','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autokind' AND field = 'title')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'autokind',denynull = 'S',format = '',col_len = '100',field = 'title',col_precision = '' where tablename = 'autokind' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(100)','N','autokind','S','','100','title','')
GO

-- VERIFICA DI autokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'autokind')
UPDATE customobject set isreal = 'S' where objectname = 'autokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('autokind', 'S')
GO

-- GENERAZIONE DATI PER autokind --
IF exists(SELECT * FROM [autokind] WHERE idautokind = '1')
UPDATE [autokind] SET code = 'APFPS',title = 'Apertura fondo economale' WHERE idautokind = '1'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('1','APFPS','Apertura fondo economale')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '2')
UPDATE [autokind] SET code = 'LIQRT',title = 'Liquidazione ritenute' WHERE idautokind = '2'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('2','LIQRT','Liquidazione ritenute')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '3')
UPDATE [autokind] SET code = 'REFPS',title = 'Reintegro fondo economale' WHERE idautokind = '3'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('3','REFPS','Reintegro fondo economale')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '4')
UPDATE [autokind] SET code = 'RITEN',title = 'Ritenute/Contributi' WHERE idautokind = '4'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('4','RITEN','Ritenute/Contributi')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '5')
UPDATE [autokind] SET code = 'RIEMI',title = 'Riemissione in conto competenza' WHERE idautokind = '5'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('5','RIEMI','Riemissione in conto competenza')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '6')
UPDATE [autokind] SET code = 'RECUP',title = 'Recupero' WHERE idautokind = '6'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('6','RECUP','Recupero')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '7')
UPDATE [autokind] SET code = 'CHFPS',title = 'Chiusura fondo economale' WHERE idautokind = '7'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('7','CHFPS','Chiusura fondo economale')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '8')
UPDATE [autokind] SET code = 'CONTR',title = 'Contributo' WHERE idautokind = '8'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('8','CONTR','Contributo')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '9')
UPDATE [autokind] SET code = 'ECONO',title = 'Azzeramento Riporti' WHERE idautokind = '9'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('9','ECONO','Azzeramento Riporti')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '10')
UPDATE [autokind] SET code = 'ANPAR',title = 'Annullamento Parziale' WHERE idautokind = '10'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('10','ANPAR','Annullamento Parziale')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '11')
UPDATE [autokind] SET code = 'ANNUL',title = 'Annullamento' WHERE idautokind = '11'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('11','ANNUL','Annullamento')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '12')
UPDATE [autokind] SET code = 'LPIVA',title = 'Liquidazione IVA' WHERE idautokind = '12'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('12','LPIVA','Liquidazione IVA')
GO

IF exists(SELECT * FROM [autokind] WHERE idautokind = '13')
UPDATE [autokind] SET code = 'ACIVA',title = 'Acconto IVA' WHERE idautokind = '13'
ELSE
INSERT INTO [autokind] (idautokind,code,title) VALUES ('13','ACIVA','Acconto IVA')
GO
-- FINE GENERAZIONE SCRIPT --

