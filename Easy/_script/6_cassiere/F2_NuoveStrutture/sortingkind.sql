
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


-- Aggiornamento tabella SORTINGKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingkind] ALTER COLUMN flag tinyint NULL 
END
GO

-- Codifica - flagforced (bit 0), flagcheckavailability (bit 1)
-- flagforced (N = 0; S = 1), flagcheckavailability (N = 0; S = 1)
UPDATE sortingkind SET flag = 0
UPDATE sortingkind SET flag = flag + 1 WHERE flagforced = 'S'
UPDATE sortingkind SET flag = flag + 2 WHERE flagcheckavailability = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name ='flagforced'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN flagforced
	DELETE FROM columntypes WHERE tablename = 'sortingkind' AND field = 'flagforced'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name ='flagcheckavailability'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN flagcheckavailability
	DELETE FROM columntypes WHERE tablename = 'sortingkind' AND field = 'flagcheckavailability'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name ='sortinglevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN sortinglevel
	DELETE FROM columntypes WHERE tablename = 'sortingkind' AND field = 'sortinglevel'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name ='flagmultiple'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN flagmultiple
	DELETE FROM columntypes WHERE tablename = 'sortingkind' AND field = 'flagmultiple'
END
GO

ALTER TABLE [sortingkind] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingkind' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'sortingkind' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingkind','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO
