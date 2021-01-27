
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


-- Aggiornamento tabella CONFIG e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
-- Aggiunta dei nuovi campi e/o campi temporanei

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountingyear' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountingyear] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [accountingyear] ALTER COLUMN flag tinyint NULL 
END
GO

-- Calcolo dei bit 0 - 3: 1 = yearcreate 2 = fincopy 3 = finsetupcopy 4 = incomearrears 5 = expensearrears 6 = closed (sono valori, non bit)
UPDATE accountingyear SET flag = 0

UPDATE accountingyear SET flag = 1 WHERE ISNULL(flagyearcreate, 'N') = 'S'
UPDATE accountingyear SET flag = 2 WHERE ISNULL(flagfincopy, 'N') = 'S'
UPDATE accountingyear SET flag = 3 WHERE ISNULL(flagfinsetupcopy, 'N') = 'S'
UPDATE accountingyear SET flag = 4 WHERE ISNULL(flagincomearrearscopy, 'N') = 'S'
UPDATE accountingyear SET flag = 5 WHERE ISNULL(flagexpensearrearscopy, 'N') = 'S'
UPDATE accountingyear SET flag = 6 WHERE ISNULL(flagyearcreate, 'N') = 'S'
	AND (ISNULL(flagfincopy, 'N') = 'S')
	AND (ISNULL(flagfinsetupcopy, 'N') = 'S')
	AND (ISNULL(flagincomearrearscopy, 'N') = 'S')
	AND (ISNULL(flagexpensearrearscopy, 'N') = 'S')

-- Calcolo del bit 4 asset, mi baso sugli altri flag
UPDATE accountingyear SET flag = flag + 16 WHERE ISNULL(flagyearcreate, 'N') = 'S'
	AND (ISNULL(flagfincopy, 'N') = 'S')
	AND (ISNULL(flagfinsetupcopy, 'N') = 'S')
	AND (ISNULL(flagincomearrearscopy, 'N') = 'S')
	AND (ISNULL(flagexpensearrearscopy, 'N') = 'S')

-- Calcolo del bit 5 asset, mi baso sugli altri flag
UPDATE accountingyear SET flag = flag + 32 WHERE ISNULL(flagyearcreate, 'N') = 'S'
	AND (ISNULL(flagfincopy, 'N') = 'S')
	AND (ISNULL(flagfinsetupcopy, 'N') = 'S')
	AND (ISNULL(flagincomearrearscopy, 'N') = 'S')
	AND (ISNULL(flagexpensearrearscopy, 'N') = 'S')
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountingyear'
		and C.name ='flagyearcreate'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountingyear] DROP COLUMN flagyearcreate
	DELETE FROM columntypes WHERE tablename = 'accountingyear' AND field = 'flagyearcreate'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountingyear'
		and C.name ='flagfincopy'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountingyear] DROP COLUMN flagfincopy
	DELETE FROM columntypes WHERE tablename = 'accountingyear' AND field = 'flagfincopy'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountingyear'
		and C.name ='flagfinsetupcopy'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountingyear] DROP COLUMN flagfinsetupcopy
	DELETE FROM columntypes WHERE tablename = 'accountingyear' AND field = 'flagfinsetupcopy'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountingyear'
		and C.name ='flagincomearrearscopy'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountingyear] DROP COLUMN flagincomearrearscopy
	DELETE FROM columntypes WHERE tablename = 'accountingyear' AND field = 'flagincomearrearscopy'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountingyear'
		and C.name ='flagexpensearrearscopy'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountingyear] DROP COLUMN flagexpensearrearscopy
	DELETE FROM columntypes WHERE tablename = 'accountingyear' AND field = 'flagexpensearrearscopy'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountingyear'
		and C.name ='financestatus'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountingyear] DROP COLUMN financestatus
	DELETE FROM columntypes WHERE tablename = 'accountingyear' AND field = 'financestatus'
END
GO

ALTER TABLE accountingyear ALTER COLUMN flag tinyint NOT NULL
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'accountingyear' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-04 14:19:23.590'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.590'} WHERE tablename = 'accountingyear' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('accountingyear','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-12-04 14:19:23.590'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.590'})
GO
