
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


-- Aggiornamento tabella TAX e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [tax] ALTER COLUMN taxkindint smallint NULL 
END
GO

-- LOOKUP F = 1; A = 2; P = 3; N = 4; R = 5; O = 6
UPDATE tax SET taxkindint = 
CASE
	WHEN taxkind = 'F' THEN 1
	WHEN taxkind = 'A' THEN 2
	WHEN taxkind = 'P' THEN 3
	WHEN taxkind = 'N' THEN 4
	WHEN taxkind = 'R' THEN 5
	WHEN taxkind = 'O' THEN 6
	ELSE 6 -- Caso di valore NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'tax'
		and C.name ='taxkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [tax] DROP COLUMN taxkind
	DELETE FROM columntypes WHERE tablename = 'tax' AND field = 'taxkind'
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxkind smallint NULL
END
GO

UPDATE tax SET taxkind = taxkindint
GO

ALTER TABLE [tax] ALTER COLUMN taxkind smallint NOT NULL 
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'tax'
		and C.name ='taxkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [tax] DROP COLUMN taxkindint
END
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'tax' AND field = 'taxkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'tax' AND field = 'taxkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('tax','taxkind','N','smallint','1',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO
