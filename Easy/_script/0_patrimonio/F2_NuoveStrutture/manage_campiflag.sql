
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


-- Script che crea i campi flag, travasa il contenuto dei vecchi campi nei nuovi e cancella i vecchi campi
-- Tab. INVENTORYSORTINGLEVEL:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortinglevel] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorysortinglevel] ALTER COLUMN flag tinyint NULL 
END
GO

-- Codifica - codekind (bit 0), flagusable (bit 1), flagrestart (bit 2)
-- codekind (N = 0; A = 1), flagusable (N = 0; S = 1), flagrestart (N = 0; S = 1)
UPDATE inventorysortinglevel SET flag = 0
UPDATE inventorysortinglevel SET flag = flag + 1 WHERE codekind = 'A'
UPDATE inventorysortinglevel SET flag = flag + 2 WHERE flagusable = 'S'
UPDATE inventorysortinglevel SET flag = flag + 4 WHERE flagrestart = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortinglevel'
		and C.name ='codekind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortinglevel] DROP COLUMN codekind
	DELETE FROM columntypes WHERE tablename = 'inventorysortinglevel' AND field = 'codekind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortinglevel'
		and C.name ='flagusable'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortinglevel] DROP COLUMN flagusable
	DELETE FROM columntypes WHERE tablename = 'inventorysortinglevel' AND field = 'flagusable'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortinglevel'
		and C.name ='flagrestart'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortinglevel] DROP COLUMN flagrestart
	DELETE FROM columntypes WHERE tablename = 'inventorysortinglevel' AND field = 'flagrestart'
END
GO

ALTER TABLE [inventorysortinglevel] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorysortinglevel' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'inventorysortinglevel' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorysortinglevel','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO

-- Tab. ASSETLOADKIND:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [assetloadkind] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - flaglinear (bit 0) - flaglinear (N = 0; S = 1)
UPDATE assetloadkind SET flag = 0
UPDATE assetloadkind SET flag = flag + 1 WHERE flaglinear = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadkind'
		and C.name ='flaglinear'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadkind] DROP COLUMN flaglinear
	DELETE FROM columntypes WHERE tablename = 'assetloadkind' AND field = 'flaglinear'
END
GO

ALTER TABLE [assetloadkind] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadkind' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.860'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.860'} WHERE tablename = 'assetloadkind' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadkind','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.860'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.860'})
GO

-- Tab. ASSETUNLOADKIND:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadkind] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [assetunloadkind] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - flaglinear (bit 0) - flaglinear (N = 0; S = 1)
UPDATE assetunloadkind SET flag = 0
UPDATE assetunloadkind SET flag = flag + 1 WHERE flaglinear = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadkind'
		and C.name ='flaglinear'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadkind] DROP COLUMN flaglinear
	DELETE FROM columntypes WHERE tablename = 'assetunloadkind' AND field = 'flaglinear'
END
GO

ALTER TABLE [assetunloadkind] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadkind' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:25.377'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:25.377'} WHERE tablename = 'assetunloadkind' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunloadkind','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:25.377'},'''NINO''','NINO',{ts '2007-10-24 17:16:25.377'})
GO

-- Tab. ASSETLOADMOTIVE:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadmotive' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadmotive] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [assetloadmotive] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - flagnewasset (bit 0) - flagnewasset (N = 0; S = 1)
UPDATE assetloadmotive SET flag = 0
UPDATE assetloadmotive SET flag = flag + 1 WHERE ISNULL(flagnewasset,'S') = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadmotive'
		and C.name ='flagnewasset'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadmotive] DROP COLUMN flagnewasset
	DELETE FROM columntypes WHERE tablename = 'assetloadmotive' AND field = 'flagnewasset'
END
GO

ALTER TABLE [assetloadmotive] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadmotive' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:23.907'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:23.907'} WHERE tablename = 'assetloadmotive' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadmotive','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:23.907'},'''NINO''','NINO',{ts '2007-10-24 17:16:23.907'})
GO

-- Tab. ASSET:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [asset] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - flagunload (bit 0) - flagunload (N = 0; S = 1)
UPDATE asset SET flag = 0
UPDATE asset SET flag = flag + 1 WHERE ISNULL(flagunload,'S') = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='flagunload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN flagunload
	DELETE FROM columntypes WHERE tablename = 'asset' AND field = 'flagunload'
END
GO

ALTER TABLE [asset] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'asset' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:22.093'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:22.093'} WHERE tablename = 'asset' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('asset','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:22.093'},'''NINO''','NINO',{ts '2007-10-24 17:16:22.093'})
GO

-- Tab. INVENTORYKIND:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorykind' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorykind] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorykind] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - flagdiscount (bit 0) - flagdiscount (N = 0; S = 1)
-- N.B. flagdiscount è stato impostato a valori NOT null in uno script di LU
UPDATE inventorykind SET flag = 0
UPDATE inventorykind SET flag = flag + 1 WHERE ISNULL(flagdiscount,'S') = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorykind'
		and C.name ='flagdiscount'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorykind] DROP COLUMN flagdiscount
	DELETE FROM columntypes WHERE tablename = 'inventorykind' AND field = 'flagdiscount'
END
GO

ALTER TABLE [inventorykind] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorykind' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.377'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.377'} WHERE tablename = 'inventorykind' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorykind','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.377'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.377'})
GO

-- Tab. INVENTORY:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [inventory] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - flagmixed (bit 0) - flagmixed (N = 0; S = 1)
-- Nella regola CESPI011 il NULL viene considerato N,
-- idem nei form vengono fatti dei cast a string e si valuta rispetto ad S
UPDATE inventory SET flag = 0
UPDATE inventory SET flag = flag + 1 WHERE ISNULL(flagmixed,'N') = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventory'
		and C.name ='flagmixed'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventory] DROP COLUMN flagmixed
	DELETE FROM columntypes WHERE tablename = 'inventory' AND field = 'flagmixed'
END
GO

ALTER TABLE [inventory] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventory' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:30.920'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:30.920'} WHERE tablename = 'inventory' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventory','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:30.920'},'''NINO''','NINO',{ts '2007-10-24 17:16:30.920'})
GO

-- Tab. INVENTORYAMORTIZATION:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryamortization' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryamortization] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [inventoryamortization] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - calculationkind (bit 0), flagofficial (bit 1), flagivaapplying (bit 2), flagamortization (bit 3)
-- calculationkind (A = 0; M = 1), flagofficial (N = 0; S = 1), flagivaapplying (N = 0; S = 1), flagamortization (N = 0; S = 1)
-- N.B. calculationkind nella SP closeyear_asset_ammortization viene considerato = A se NULL
-- N.B. flagofficial in diverse SP viene considerato = N se NULL
-- N.B. flagamortization in LU viene impostato a S se NULL
UPDATE inventoryamortization SET flag = 0
UPDATE inventoryamortization SET flag = flag + 1 WHERE ISNULL(calculationkind,'A') = 'M'
UPDATE inventoryamortization SET flag = flag + 2 WHERE ISNULL(flagofficial,'N') = 'S'
UPDATE inventoryamortization SET flag = flag + 4 WHERE flagivaapplying = 'S'
UPDATE inventoryamortization SET flag = flag + 8 WHERE ISNULL(flagamortization,'S') = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventoryamortization'
		and C.name ='calculationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventoryamortization] DROP COLUMN calculationkind
	DELETE FROM columntypes WHERE tablename = 'inventoryamortization' AND field = 'calculationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventoryamortization'
		and C.name ='flagofficial'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventoryamortization] DROP COLUMN flagofficial
	DELETE FROM columntypes WHERE tablename = 'inventoryamortization' AND field = 'flagofficial'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventoryamortization'
		and C.name ='flagivaapplying'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventoryamortization] DROP COLUMN flagivaapplying
	DELETE FROM columntypes WHERE tablename = 'inventoryamortization' AND field = 'flagivaapplying'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventoryamortization'
		and C.name ='flagamortization'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventoryamortization] DROP COLUMN flagamortization
	DELETE FROM columntypes WHERE tablename = 'inventoryamortization' AND field = 'flagamortization'
END
GO

ALTER TABLE [inventoryamortization] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventoryamortization' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.170'} WHERE tablename = 'inventoryamortization' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventoryamortization','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.170'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.170'})
GO

-- Tab. ASSETVAR:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvar] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [assetvar] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - variationkind (bit 0) - variationkind (I = 0; N = 1)
UPDATE assetvar SET flag = 0
UPDATE assetvar SET flag = flag + 1 WHERE ISNULL(variationkind,'I') = 'N'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvar'
		and C.name ='variationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvar] DROP COLUMN variationkind
	DELETE FROM columntypes WHERE tablename = 'assetvar' AND field = 'variationkind'
END
GO

ALTER TABLE [assetvar] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvar' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:26.313'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:26.313'} WHERE tablename = 'assetvar' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvar','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:26.313'},'''NINO''','NINO',{ts '2007-10-24 17:16:26.313'})
GO

-- Tab. LOCATIONLEVEL:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationlevel' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationlevel] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [locationlevel] ALTER COLUMN flag tinyint NULL
END
GO

-- Codifica - codekind (bit 0), flagusable (bit 1), flagrestart (bit 2)
-- codekind (N = 0; A = 1), flagusable (N = 0; S = 1), flagrestart (N = 0; S = 1)
UPDATE locationlevel SET flag = 0
UPDATE locationlevel SET flag = flag + 1 WHERE codekind = 'A'
UPDATE locationlevel SET flag = flag + 2 WHERE flagusable = 'S'
UPDATE locationlevel SET flag = flag + 4 WHERE flagrestart = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationlevel'
		and C.name ='codekind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationlevel] DROP COLUMN codekind
	DELETE FROM columntypes WHERE tablename = 'locationlevel' AND field = 'codekind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationlevel'
		and C.name ='flagusable'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationlevel] DROP COLUMN flagusable
	DELETE FROM columntypes WHERE tablename = 'locationlevel' AND field = 'flagusable'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationlevel'
		and C.name ='flagrestart'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationlevel] DROP COLUMN flagrestart
	DELETE FROM columntypes WHERE tablename = 'locationlevel' AND field = 'flagrestart'
END
GO

ALTER TABLE [locationlevel] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'locationlevel' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:22.780'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:22.780'} WHERE tablename = 'locationlevel' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('locationlevel','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:22.780'},'''NINO''','NINO',{ts '2007-10-24 17:16:22.780'})
GO

-- Tab. ASSETACQUIRE:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN flag tinyint NULL 
END
GO

-- Codifica - flagload (bit 0), loadkind (bit 1), ispieceacquire (bit 2)
-- flagload (N = 0; S = 1), loadkind (N = 0; R = 1), ispieceacquire (N = 0; S = 1)
UPDATE assetacquire SET flag = 0
UPDATE assetacquire SET flag = flag + 1 WHERE flagload = 'S'
UPDATE assetacquire SET flag = flag + 2 WHERE loadkind = 'R'
UPDATE assetacquire SET flag = flag + 4 WHERE ispieceacquire = 'S'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='flagload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN flagload
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'flagload'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='loadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN loadkind
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'loadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='ispieceacquire'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN ispieceacquire
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'ispieceacquire'
END
GO

ALTER TABLE [assetacquire] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'assetacquire' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO

-- Tab. ASSETAMORTIZATION:
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetamortization] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [assetamortization] ALTER COLUMN flag tinyint NULL 
END
GO

-- Codifica - flagunload (bit 0)
-- flagunload (N = 0; S = 1)
UPDATE assetamortization SET flag = 0
UPDATE assetamortization SET flag = flag + 1 WHERE ISNULL(flagunload,'S') = 'S'
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi4assetamortization' and id=object_id('assetamortization'))
	drop index assetamortization.xi4assetamortization
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetamortization'
		and C.name ='flagunload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetamortization] DROP COLUMN flagunload
	DELETE FROM columntypes WHERE tablename = 'assetamortization' AND field = 'flagunload'
END
GO

ALTER TABLE [assetamortization] ALTER COLUMN flag tinyint NOT NULL 
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetamortization' and id=object_id('assetamortization'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetamortization ON assetamortization (flag, adate)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetamortization
	ON assetamortization (flag, adate)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetamortization' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'assetamortization' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetamortization','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO
