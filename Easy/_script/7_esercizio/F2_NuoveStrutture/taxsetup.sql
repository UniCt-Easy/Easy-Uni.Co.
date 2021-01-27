
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

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsetup] ALTER COLUMN flag tinyint NULL 
END
GO

UPDATE taxsetup SET flag = 0

-- flagregionalagency bit 0 = N, bit 1 = S, bit 2 = P, 
UPDATE taxsetup SET flag = flag + 1 WHERE flagregionalagency = 'N'
UPDATE taxsetup SET flag = flag + 2 WHERE flagregionalagency = 'S'
UPDATE taxsetup SET flag = flag + 4 WHERE flagregionalagency = 'P'

-- flagprevcurr bit 3 C = 0; P = 1 
UPDATE taxsetup SET flag = flag + 8 WHERE ISNULL(flagprevcurr, 'C') = 'P'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='flagregionalagency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN flagregionalagency
	DELETE FROM columntypes WHERE tablename = 'taxsetup' AND field = 'flagregionalagency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='flagprevcurr'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN flagprevcurr
	DELETE FROM columntypes WHERE tablename = 'taxsetup' AND field = 'flagprevcurr'
END
GO

ALTER TABLE taxsetup ALTER COLUMN flag tinyint NOT NULL
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsetup' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-04 14:19:23.590'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.590'} WHERE tablename = 'taxsetup' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('taxsetup','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-12-04 14:19:23.590'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.590'})
GO
