
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


-- CREAZIONE TABELLA partnerkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[partnerkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[partnerkind] (
idpartnerkind int NOT NULL,
active char(1) NULL,
description varchar(max) NULL,
sortcode int NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkpartnerkind PRIMARY KEY (idpartnerkind
)
)
END
GO

-- VERIFICA STRUTTURA partnerkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'idpartnerkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD idpartnerkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('partnerkind') and col.name = 'idpartnerkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [partnerkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [partnerkind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [partnerkind] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [partnerkind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [partnerkind] ALTER COLUMN title varchar(2048) NULL
GO


-- GENERAZIONE DATI PER partnerkind --
IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '1')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '1',title = 'Partners - Associated Partners (AP)' WHERE idpartnerkind = '1'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('1','S',null,'1','Partners - Associated Partners (AP)')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '2')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '2',title = 'Soggetto terzo - Third parties giving inkind contributions to the action (TP) ' WHERE idpartnerkind = '2'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('2','S',null,'2','Soggetto terzo - Third parties giving inkind contributions to the action (TP) ')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '3')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '3',title = 'Soggetto attuatore' WHERE idpartnerkind = '3'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('3','S',null,'3','Soggetto attuatore')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '4')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '4',title = 'Coordinatore - Coordinator (COO)' WHERE idpartnerkind = '4'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('4','S',null,'4','Coordinatore - Coordinator (COO)')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '5')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '5',title = 'Beneficiari - Beneficiaries (BEN)' WHERE idpartnerkind = '5'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('5','S',null,'5','Beneficiari - Beneficiaries (BEN)')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '6')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '6',title = 'Entità affiliate - Affiliated entities (AE)' WHERE idpartnerkind = '6'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('6','S',null,'6','Entità affiliate - Affiliated entities (AE)')
GO

