
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


-- Script che crea i campi flag, travasa il contenuto dei vecchi campi nei nuovi e cancella i vecchi campi
-- Tab. INVOICEKIND:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekind' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekind] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicekind] ALTER COLUMN flag tinyint NULL 
END
GO

-- Codifica - flagbuysell (bit 0), flagmixed (bit 1), flagvariation (bit 2)
-- flagbuysell (A = 0; V = 1), flagmixed (N = 0; S = 1), flagvariation (N = 0; S = 1)
UPDATE invoicekind SET flag = 0
UPDATE invoicekind SET flag = flag + 1 WHERE flagbuysell = 'V'
UPDATE invoicekind SET flag = flag + 2 WHERE ISNULL(flagmixed,'N') = 'S'
UPDATE invoicekind SET flag = flag + 4 WHERE flagvariation = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekind'
		and C.name ='flagbuysell'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekind] DROP COLUMN flagbuysell
	DELETE FROM columntypes WHERE tablename = 'invoicekind' AND field = 'flagbuysell'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekind'
		and C.name ='flagmixed'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekind] DROP COLUMN flagmixed
	DELETE FROM columntypes WHERE tablename = 'invoicekind' AND field = 'flagmixed'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekind'
		and C.name ='flagvariation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekind] DROP COLUMN flagvariation
	DELETE FROM columntypes WHERE tablename = 'invoicekind' AND field = 'flagvariation'
END
GO

ALTER TABLE [invoicekind] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicekind' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'invoicekind' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicekind','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO
