
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


-- CREAZIONE TABELLA didprog --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprog] (
iddidprog int NOT NULL,
idcorsostudio int NOT NULL,
aa nvarchar(9) NULL,
annosolare int NULL,
attribdebiti nvarchar(max) NULL,
ciclo int NULL,
codice varchar(50) NULL,
codicemiur varchar(50) NULL,
dataconsmaxiscr date NULL,
freqobbl char(1) NULL,
idareadidattica int NULL,
idconvenzione int NULL,
iddidprognumchiusokind int NULL,
iddidprogsuddannokind int NULL,
iderogazkind int NULL,
idgraduatoria int NULL,
idnation_lang int NULL,
idnation_lang2 int NULL,
idnation_langvis int NULL,
idreg_docenti int NULL,
idsede int NULL,
idsessione int NULL,
idtitolokind int NULL,
immatoltreauth char(1) NULL,
modaccesso nvarchar(max) NULL,
modaccesso_en nvarchar(max) NULL,
obbformativi nvarchar(max) NULL,
obbformativi_en nvarchar(max) NULL,
preimmatoltreauth char(1) NULL,
progesamamm nvarchar(max) NULL,
prospoccupaz nvarchar(max) NULL,
provafinaledesc nvarchar(max) NULL,
regolamentotax nvarchar(max) NULL,
regolamentotaxurl varchar(512) NULL,
startiscrizioni datetime NULL,
stopiscrizioni datetime NULL,
title varchar(1024) NULL,
title_en varchar(1024) NULL,
utenzasost int NULL,
website varchar(512) NULL,
 CONSTRAINT xpkdidprog PRIMARY KEY (iddidprog,
idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA didprog --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprog') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprog') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD aa nvarchar(9) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN aa nvarchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'annosolare' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD annosolare int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN annosolare int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'attribdebiti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD attribdebiti nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN attribdebiti nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'ciclo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD ciclo int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN ciclo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'codicemiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD codicemiur varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN codicemiur varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'dataconsmaxiscr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD dataconsmaxiscr date NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN dataconsmaxiscr date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'freqobbl' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD freqobbl char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN freqobbl char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idareadidattica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idareadidattica int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idareadidattica int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idconvenzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idconvenzione int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idconvenzione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprognumchiusokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprognumchiusokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iddidprognumchiusokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprogsuddannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprogsuddannokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iddidprogsuddannokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iderogazkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iderogazkind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iderogazkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idgraduatoria int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idgraduatoria int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_lang' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_lang int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_lang int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_lang2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_lang2 int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_lang2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_langvis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_langvis int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_langvis int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idreg_docenti int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idreg_docenti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idsede int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idsede int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idsessione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idsessione int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idsessione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idtitolokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idtitolokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idtitolokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'immatoltreauth' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD immatoltreauth char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN immatoltreauth char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'modaccesso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD modaccesso nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN modaccesso nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'modaccesso_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD modaccesso_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN modaccesso_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'obbformativi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD obbformativi nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN obbformativi nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'obbformativi_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD obbformativi_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN obbformativi_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'preimmatoltreauth' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD preimmatoltreauth char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN preimmatoltreauth char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'progesamamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD progesamamm nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN progesamamm nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'prospoccupaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD prospoccupaz nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN prospoccupaz nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'provafinaledesc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD provafinaledesc nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN provafinaledesc nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'regolamentotax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD regolamentotax nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN regolamentotax nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'regolamentotaxurl' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD regolamentotaxurl varchar(512) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN regolamentotaxurl varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'startiscrizioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD startiscrizioni datetime NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN startiscrizioni datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'stopiscrizioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD stopiscrizioni datetime NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN stopiscrizioni datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD title_en varchar(1024) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN title_en varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'utenzasost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD utenzasost int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN utenzasost int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'website' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD website varchar(512) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN website varchar(512) NULL
GO

