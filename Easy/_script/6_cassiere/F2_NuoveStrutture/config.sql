
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

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'fin_kind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD fin_kind tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN fin_kind tinyint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'cashvaliditykindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD cashvaliditykindint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN cashvaliditykindint tinyint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'taxvaliditykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD taxvaliditykind tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN taxvaliditykind tinyint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'flag_paymentamount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD flag_paymentamount tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN flag_paymentamount tinyint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'automanagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD automanagekind int NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN automanagekind int NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'flag_autodocnumbering' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD flag_autodocnumbering int NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN flag_autodocnumbering int NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'flagbank_grouping' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD flagbank_grouping int NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN flagbank_grouping int NULL 
END
GO

-- Inizializzazione dei campi
UPDATE config SET fin_kind = 0, flag_paymentamount = 0, automanagekind = 0, flag_autodocnumbering = 0, flagbank_grouping = 0

-- previsiokind, secprevisionkind -> fin_kind (bit 0: competency; bit 1 cash)
UPDATE config SET fin_kind = 
CASE
	WHEN ISNULL(previsionkind ,'') = 'C' AND ISNULL(secprevisionkind, '') <> 'S' THEN 1
	WHEN ISNULL(previsionkind ,'') = 'S' THEN 2
	WHEN ISNULL(previsionkind ,'') = 'C' AND ISNULL(secprevisionkind, '') = 'S' THEN 3
	ELSE 0
END

-- cashvaliditykind 1 = E; 2 = S; 3 = T; 4 = B
UPDATE config SET cashvaliditykindint = 
CASE
	WHEN cashvaliditykind = 'E' THEN 1
	WHEN cashvaliditykind = 'S' THEN 2
	WHEN cashvaliditykind = 'T' THEN 3
	WHEN cashvaliditykind = 'B' THEN 4
END

-- flagtaxcompetency -> taxvaliditykind 1 = N; 2 = U; 3 = M; 4 = S; 5 = T; 6 = E
UPDATE config SET taxvaliditykind = 
CASE
	WHEN flagtaxcompetency = 'N' THEN 1
	WHEN flagtaxcompetency = 'U' THEN 2
	WHEN flagtaxcompetency = 'M' THEN 3
	WHEN flagtaxcompetency = 'S' THEN 4
	WHEN flagtaxcompetency = 'T' THEN 5
	WHEN flagtaxcompetency = 'E' THEN 6
END

-- flagclawback, flagadmintax, flagtax --> flag_paymentamount (bit 0: flagclawback,  bit 1: flagadmintax, bit 2 = flagtax)
UPDATE config SET flag_paymentamount = flag_paymentamount + 1 WHERE flagclawback = 'S'
UPDATE config SET flag_paymentamount = flag_paymentamount + 2 WHERE flagadmintax = 'S'
UPDATE config SET flag_paymentamount = flag_paymentamount + 4 WHERE flagtax = 'S'
GO

/*
admintaxkind, clawbackkind, employtaxkind -> automanagekind (int)
	bit  0; mask 1; 0x01: admintaxkind 0 - no contr.
	bit  1; mask 2; 0x02: admintaxkind 1 - mov. spesa + mov. entrata
	bit  2; mask 4; 0x04: admintaxkind 2 - var. spesa + mov. entrata
	bit  3; mask 8; 0x08: admintaxkind 3 - liq. diretta
	bit  4; mask 16; 0x10: clawbackkind 0, 1 - no / si
	bit  5; -: inutilizzato
	bit  6; -: inutilizzato
	bit  7; -: inutilizzato
	bit  8; mask 256; 0x100: employtaxkind 0 - no
	bit  9; mask 512; 0x200: employtaxkind 1 - mov. entrata
	bit 10; mask 1024; 0x400: employtaxkind 2 - var. spesa negativa
	bit 11; -: inutilizzato
*/
UPDATE config SET automanagekind = automanagekind + 1 WHERE ISNULL(admintaxkind,'') = '0'
UPDATE config SET automanagekind = automanagekind + 2 WHERE ISNULL(admintaxkind,'') = '1'
UPDATE config SET automanagekind = automanagekind + 4 WHERE ISNULL(admintaxkind,'') = '2'
UPDATE config SET automanagekind = automanagekind + 8 WHERE ISNULL(admintaxkind,'') = '3'
UPDATE config SET automanagekind = automanagekind + 16 WHERE ISNULL(clawbackkind,'') = 'S'
UPDATE config SET automanagekind = automanagekind + 256 WHERE ISNULL(employtaxkind,'') = '0'
UPDATE config SET automanagekind = automanagekind + 512 WHERE ISNULL(employtaxkind,'') = '1'
UPDATE config SET automanagekind = automanagekind + 1024 WHERE ISNULL(employtaxkind,'') = '2'

/*
flag_autodocnumbering: (int)
	bit 0; mask 1; 0x01: estimate_numerationkind {A, M}
	bit 1; mask 2; 0x02: mandate_numerationkind {A, M}
	bit 2; mask 4; 0x04: invoice_numerationkind {A, M}
	bit 3; mask 8; 0x08: asset_numerationkind {A, M}
	bit 4; mask 16; 0x10: parasubcontract_numerationkind {A, M}
	bit 5; mask 32; 0x20: casualcontract_flagnumbering {A, M}
	bit 6; mask 64; 0x40: profservice_flagnumbering {A, M}
	bit 7; mask 128; 0x80: wageaddition_flagnumbering {A, M}
*/

UPDATE config SET flag_autodocnumbering = flag_autodocnumbering + 1 WHERE ISNULL(estimate_numerationkind,'') = 'M'
UPDATE config SET flag_autodocnumbering = flag_autodocnumbering + 2 WHERE ISNULL(mandate_numerationkind,'') = 'M'
UPDATE config SET flag_autodocnumbering = flag_autodocnumbering + 4 WHERE ISNULL(invoice_numerationkind,'') = 'M'
UPDATE config SET flag_autodocnumbering = flag_autodocnumbering + 8 WHERE ISNULL(asset_numerationkind,'') = 'M'
UPDATE config SET flag_autodocnumbering = flag_autodocnumbering + 16 WHERE ISNULL(parasubcontract_numerationkind,'') = 'M'
UPDATE config SET flag_autodocnumbering = flag_autodocnumbering + 32 WHERE ISNULL(casualcontract_flagnumbering,'') = 'M'
UPDATE config SET flag_autodocnumbering = flag_autodocnumbering + 64 WHERE ISNULL(profservice_flagnumbering,'') = 'M'
UPDATE config SET flag_autodocnumbering = flag_autodocnumbering + 128 WHERE ISNULL(wageaddition_flagnumbering,'') = 'M'

/*
flagbank_grouping: (tinyint)
	bit 0; mask 1; 0x01: payments_groupingkind N 
	bit 1; mask 2; 0x02: payments_groupingkind C
	bit 2; mask 4; 0x04: payments_groupingkind P
	bit 3; -: inutilizzato
	bit 4; mask 16; 0x10: proceeds_groupingkind N
	bit 5; mask 32; 0x20: proceeds_groupingkind C
	bit 6; -: inutilizzato
	bit 7; -: inutilizzato
*/

UPDATE config SET flagbank_grouping = flagbank_grouping + 1 WHERE ISNULL(payments_groupingkind,'') = 'N'
UPDATE config SET flagbank_grouping = flagbank_grouping + 2 WHERE ISNULL(payments_groupingkind,'') = 'C'
UPDATE config SET flagbank_grouping = flagbank_grouping + 4 WHERE ISNULL(payments_groupingkind,'') = 'P'
UPDATE config SET flagbank_grouping = flagbank_grouping + 16 WHERE ISNULL(proceeds_groupingkind,'') = 'N'
UPDATE config SET flagbank_grouping = flagbank_grouping + 32 WHERE ISNULL(proceeds_groupingkind,'') = 'C'
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='previsionkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN previsionkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'previsionkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='secprevisionkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN secprevisionkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'secprevisionkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='cashvaliditykind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN cashvaliditykind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'cashvaliditykind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='flagtaxcompetency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN flagtaxcompetency
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'flagtaxcompetency'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='flagclawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN flagclawback
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'flagclawback'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='flagadmintax'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN flagadmintax
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'flagadmintax'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='flagtax'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN flagtax
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'flagtax'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='admintaxkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN admintaxkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'admintaxkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='clawbackkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN clawbackkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'clawbackkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='employtaxkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN employtaxkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'employtaxkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='estimate_numerationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN estimate_numerationkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'estimate_numerationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='mandate_numerationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN mandate_numerationkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'mandate_numerationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='invoice_numerationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN invoice_numerationkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'invoice_numerationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='asset_numerationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN asset_numerationkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'asset_numerationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='parasubcontract_numerationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN parasubcontract_numerationkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'parasubcontract_numerationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='casualcontract_flagnumbering'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN casualcontract_flagnumbering
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'casualcontract_flagnumbering'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='profservice_flagnumbering'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN profservice_flagnumbering
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'profservice_flagnumbering'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='wageaddition_flagnumbering'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN wageaddition_flagnumbering
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'wageaddition_flagnumbering'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='payments_groupingkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN payments_groupingkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'payments_groupingkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='proceeds_groupingkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN proceeds_groupingkind
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'proceeds_groupingkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='flagarrearsadmintax'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN flagarrearsadmintax
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'flagarrearsadmintax'
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'cashvaliditykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD cashvaliditykind tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN cashvaliditykind tinyint NULL 
END
GO

UPDATE config SET cashvaliditykind = cashvaliditykindint
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='cashvaliditykindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN cashvaliditykindint
END
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'automanagekind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-04 14:19:23.590'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.590'} WHERE tablename = 'config' AND field = 'automanagekind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','automanagekind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-04 14:19:23.590'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.590'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'cashvaliditykind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-04 14:19:23.590'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.590'} WHERE tablename = 'config' AND field = 'cashvaliditykind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','cashvaliditykind','N','tinyint','1',null,null,'System.Byte','tinyint','S','',null,'N',{ts '2007-12-04 14:19:23.590'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.590'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'fin_kind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-04 14:19:23.573'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.573'} WHERE tablename = 'config' AND field = 'fin_kind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','fin_kind','N','tinyint','1',null,null,'System.Byte','tinyint','S','',null,'N',{ts '2007-12-04 14:19:23.573'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.573'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'flag_autodocnumbering')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-04 14:19:23.590'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.590'} WHERE tablename = 'config' AND field = 'flag_autodocnumbering'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','flag_autodocnumbering','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-04 14:19:23.590'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.590'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'flag_paymentamount')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-04 14:19:23.590'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.590'} WHERE tablename = 'config' AND field = 'flag_paymentamount'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','flag_paymentamount','N','tinyint','1',null,null,'System.Byte','tinyint','S','',null,'N',{ts '2007-12-04 14:19:23.590'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.590'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'flagbank_grouping')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-04 14:19:23.590'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.590'} WHERE tablename = 'config' AND field = 'flagbank_grouping'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','flagbank_grouping','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-04 14:19:23.590'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.590'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'taxvaliditykind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-04 14:19:23.573'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-04 14:19:23.573'} WHERE tablename = 'config' AND field = 'taxvaliditykind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','taxvaliditykind','N','tinyint','1',null,null,'System.Byte','tinyint','S','',null,'N',{ts '2007-12-04 14:19:23.573'},'''NINO''','NINO',{ts '2007-12-04 14:19:23.573'})
GO
