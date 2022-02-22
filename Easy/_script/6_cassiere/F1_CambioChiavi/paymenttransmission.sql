
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


-- Aggiornamento tabella PAYMENTTRANSMISSION e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- payment

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'kpaymenttransmissionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymenttransmission] ADD kpaymenttransmissionint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'kpaymenttransmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymenttransmission] ADD kpaymenttransmission int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'kpaymenttransmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD kpaymenttransmission int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'kpaymenttransmissionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE paymenttransmission SET kpaymenttransmission = kpaymenttransmissionint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'kpaymenttransmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET kpaymenttransmission = paymenttransmission.kpaymenttransmission
	FROM paymenttransmission
	WHERE payment.ypaymenttransmission = paymenttransmission.ypaymenttransmission AND payment.npaymenttransmission = paymenttransmission.npaymenttransmission
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono payment, payment_bank
IF exists(SELECT * FROM sysconstraints where id=object_id('paymenttransmission') and constid=object_id('xpkpaymenttransmission'))
BEGIN
	ALTER TABLE [paymenttransmission] drop constraint xpkpaymenttransmission
END

IF exists(SELECT * FROM sysconstraints where id=object_id('paymenttransmission') and constid=object_id('PK_paymenttransmission'))
BEGIN
	ALTER TABLE [paymenttransmission] drop constraint PK_paymenttransmission
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono payment, expenselast, itinerationtax
IF EXISTS (SELECT * FROM sysindexes where name='xi1payment' and id=object_id('payment'))
	drop index payment.xi1payment
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='ypaymenttransmission'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN ypaymenttransmission
	DELETE FROM columntypes WHERE tablename = 'payment' AND field = 'ypaymenttransmission'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='npaymenttransmission'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN npaymenttransmission
	DELETE FROM columntypes WHERE tablename = 'payment' AND field = 'npaymenttransmission'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE
-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'kpaymenttransmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymenttransmission] ALTER COLUMN kpaymenttransmission int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('paymenttransmission') and constid=object_id('xpkpaymenttransmission'))
BEGIN
	ALTER TABLE [paymenttransmission] ADD CONSTRAINT xpkpaymenttransmission PRIMARY KEY (kpaymenttransmission)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('paymenttransmission') and constid=object_id('ukpaymenttransmission'))
BEGIN
	ALTER TABLE [paymenttransmission] ADD CONSTRAINT ukpaymenttransmission UNIQUE (ypaymenttransmission, npaymenttransmission)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi4paymenttransmission' and id=object_id('paymenttransmission'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4paymenttransmission ON paymenttransmission (ypaymenttransmission, npaymenttransmission)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4paymenttransmission
	ON paymenttransmission (ypaymenttransmission, npaymenttransmission)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1payment' and id=object_id('payment'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1payment ON payment (kpaymenttransmission)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1payment
	ON payment (kpaymenttransmission)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment' AND field = 'kpaymenttransmission')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-03 13:25:49.823'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 13:25:49.823'} WHERE tablename = 'payment' AND field = 'kpaymenttransmission'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('payment','kpaymenttransmission','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-03 13:25:49.823'},'''NINO''','NINO',{ts '2007-12-03 13:25:49.823'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'paymenttransmission' AND field = 'kpaymenttransmission')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 13:25:50.027'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 13:25:50.027'} WHERE tablename = 'paymenttransmission' AND field = 'kpaymenttransmission'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('paymenttransmission','kpaymenttransmission','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 13:25:50.027'},'''NINO''','NINO',{ts '2007-12-03 13:25:50.027'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'paymenttransmission' AND field = 'npaymenttransmission')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 13:25:50.013'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 13:25:50.013'} WHERE tablename = 'paymenttransmission' AND field = 'npaymenttransmission'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('paymenttransmission','npaymenttransmission','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 13:25:50.013'},'''NINO''','NINO',{ts '2007-12-03 13:25:50.013'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'paymenttransmission' AND field = 'ypaymenttransmission')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 13:25:50.013'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 13:25:50.013'} WHERE tablename = 'paymenttransmission' AND field = 'ypaymenttransmission'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('paymenttransmission','ypaymenttransmission','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 13:25:50.013'},'''NINO''','NINO',{ts '2007-12-03 13:25:50.013'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'paymenttransmission'
		and C.name ='kpaymenttransmissionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [paymenttransmission] DROP COLUMN kpaymenttransmissionint
END
GO

