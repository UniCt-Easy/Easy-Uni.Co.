
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


-- CREAZIONE TABELLA variationkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[variationkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[variationkind] (
idvariationkind tinyint NOT NULL,
description varchar(50) NOT NULL,
 CONSTRAINT xpkvariationkind PRIMARY KEY (idvariationkind
)
)
END
GO

-- VERIFICA STRUTTURA variationkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'variationkind' and C.name = 'idvariationkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [variationkind] ADD idvariationkind tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('variationkind') and col.name = 'idvariationkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [variationkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'variationkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [variationkind] ADD description varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('variationkind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [variationkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [variationkind] ALTER COLUMN description varchar(50) NOT NULL
GO

-- VERIFICA DI variationkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'variationkind'
IF exists(SELECT * FROM columntypes WHERE tablename = 'variationkind' AND field = 'idvariationkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'S',tablename = 'variationkind',denynull = 'S',format = '',col_len = '1',field = 'idvariationkind',col_precision = '' where tablename = 'variationkind' AND field = 'idvariationkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','S','variationkind','S','','1','idvariationkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'variationkind' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'variationkind',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'variationkind' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','variationkind','S','','50','description','')
GO

-- VERIFICA DI variationkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'variationkind')
UPDATE customobject set isreal = 'S' where objectname = 'variationkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('variationkind', 'S')
GO

-- GENERAZIONE DATI PER variationkind --
IF exists(SELECT * FROM [variationkind] WHERE idvariationkind = '1')
UPDATE [variationkind] SET description = 'Normale' WHERE idvariationkind = '1'
ELSE
INSERT INTO [variationkind] (idvariationkind,description) VALUES ('1','Normale')
GO

IF exists(SELECT * FROM [variationkind] WHERE idvariationkind = '2')
UPDATE [variationkind] SET description = 'Ripartizione' WHERE idvariationkind = '2'
ELSE
INSERT INTO [variationkind] (idvariationkind,description) VALUES ('2','Ripartizione')
GO

IF exists(SELECT * FROM [variationkind] WHERE idvariationkind = '3')
UPDATE [variationkind] SET description = 'Assestamento' WHERE idvariationkind = '3'
ELSE
INSERT INTO [variationkind] (idvariationkind,description) VALUES ('3','Assestamento')
GO

IF exists(SELECT * FROM [variationkind] WHERE idvariationkind = '4')
UPDATE [variationkind] SET description = 'Storno' WHERE idvariationkind = '4'
ELSE
INSERT INTO [variationkind] (idvariationkind,description) VALUES ('4','Storno')
GO

-- FINE GENERAZIONE SCRIPT --

