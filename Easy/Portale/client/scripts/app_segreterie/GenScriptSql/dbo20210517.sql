
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


-- CREAZIONE TABELLA contrattokindperiodo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattokindperiodo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[contrattokindperiodo] (
idcontrattokindperiodo int NOT NULL,
idcontrattokind int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
datafrom date NULL,
datato date NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkcontrattokindperiodo PRIMARY KEY (idcontrattokindperiodo,
idcontrattokind
)
)
END
GO

-- VERIFICA STRUTTURA contrattokindperiodo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindperiodo' and C.name = 'idcontrattokindperiodo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindperiodo] ADD idcontrattokindperiodo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokindperiodo') and col.name = 'idcontrattokindperiodo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokindperiodo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindperiodo' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindperiodo] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokindperiodo') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokindperiodo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindperiodo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindperiodo] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [contrattokindperiodo] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindperiodo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindperiodo] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [contrattokindperiodo] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindperiodo' and C.name = 'datafrom' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindperiodo] ADD datafrom date NULL 
END
ELSE
	ALTER TABLE [contrattokindperiodo] ALTER COLUMN datafrom date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindperiodo' and C.name = 'datato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindperiodo] ADD datato date NULL 
END
ELSE
	ALTER TABLE [contrattokindperiodo] ALTER COLUMN datato date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindperiodo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindperiodo] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [contrattokindperiodo] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindperiodo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindperiodo] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [contrattokindperiodo] ALTER COLUMN lu varchar(64) NULL
GO

-- CREAZIONE VISTA rendicontaltrokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontaltrokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontaltrokinddefaultview]
GO

CREATE VIEW [dbo].[rendicontaltrokinddefaultview] AS 
SELECT CASE WHEN rendicontaltrokind.active = 'S' THEN 'Si' WHEN rendicontaltrokind.active = 'N' THEN 'No' END AS rendicontaltrokind_active, rendicontaltrokind.ct AS rendicontaltrokind_ct, rendicontaltrokind.cu AS rendicontaltrokind_cu, rendicontaltrokind.description AS rendicontaltrokind_description, rendicontaltrokind.idrendicontaltrokind, rendicontaltrokind.lt AS rendicontaltrokind_lt, rendicontaltrokind.lu AS rendicontaltrokind_lu, rendicontaltrokind.sortcode AS rendicontaltrokind_sortcode, rendicontaltrokind.title,
 isnull('Tipologia: ' + rendicontaltrokind.title + '; ','') as dropdown_title
FROM [dbo].rendicontaltrokind WITH (NOLOCK) 
WHERE  rendicontaltrokind.idrendicontaltrokind IS NOT NULL 
GO

