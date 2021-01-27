
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


-- Aggiornamento tabella STAMPHANDLING e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- payment

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO stamphandling (idstamphandling, description, flagdefault, active, ct, cu, lt, lu)
SELECT DISTINCT idstamphandling, idstamphandling, 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM payment e
WHERE NOT EXISTS(SELECT * FROM stamphandling k WHERE k.idstamphandling = e.idstamphandling)
AND e.idstamphandling IS NOT NULL

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stamphandling' and C.name = 'idstamphandlingint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stamphandling] ADD idstamphandlingint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idstamphandlingint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD idstamphandlingint int NULL
END
ELSE
BEGIN
	ALTER TABLE [payment] ALTER COLUMN idstamphandlingint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idstamphandlingint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idstamphandlingint = stamphandling.idstamphandlingint
	FROM stamphandling
	WHERE stamphandling.idstamphandling = payment.idstamphandling
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono stamphandling
IF exists(SELECT * FROM sysconstraints where id=object_id('stamphandling') and constid=object_id('xpkstamphandling'))
BEGIN
	ALTER TABLE [stamphandling] drop constraint xpkstamphandling
END

IF exists(SELECT * FROM sysconstraints where id=object_id('stamphandling') and constid=object_id('PK_stamphandling'))
BEGIN
	ALTER TABLE [stamphandling] drop constraint PK_stamphandling
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoicedetail
IF EXISTS (SELECT * FROM sysindexes where name='xi6payment' and id=object_id('payment'))
	drop index payment.xi6payment
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'stamphandling'
		and C.name ='idstamphandling'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [stamphandling] DROP COLUMN idstamphandling
	DELETE FROM columntypes WHERE tablename = 'stamphandling' AND field = 'idstamphandling'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='idstamphandling'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN idstamphandling
	DELETE FROM columntypes WHERE tablename = 'payment' AND field = 'idstamphandling'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stamphandling' and C.name = 'idstamphandling' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stamphandling] ADD idstamphandling int NULL 
END
ELSE
	ALTER TABLE [stamphandling] ALTER COLUMN idstamphandling int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idstamphandling' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD idstamphandling int NULL 
END
ELSE
	ALTER TABLE [payment] ALTER COLUMN idstamphandling int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stamphandling' and C.name = 'idstamphandling' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE stamphandling SET idstamphandling = idstamphandlingint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idstamphandling' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idstamphandling = idstamphandlingint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stamphandling' and C.name = 'idstamphandling' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stamphandling] ALTER COLUMN idstamphandling int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave NON CI SONO CAMPI NON CHIAVE

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('stamphandling') and constid=object_id('xpkstamphandling'))
BEGIN
	ALTER TABLE [stamphandling] ADD CONSTRAINT xpkstamphandling PRIMARY KEY (idstamphandling)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi6payment' and id=object_id('payment'))
BEGIN
	CREATE NONCLUSTERED INDEX xi6payment ON payment (idstamphandling)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi6payment
	ON payment (idstamphandling)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment' AND field = 'idstamphandling')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 10:09:10.640'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 10:09:10.640'} WHERE tablename = 'payment' AND field = 'idstamphandling'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('payment','idstamphandling','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 10:09:10.640'},'''NINO''','NINO',{ts '2007-11-20 10:09:10.640'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'stamphandling' AND field = 'idstamphandling')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 10:09:11.110'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 10:09:11.110'} WHERE tablename = 'stamphandling' AND field = 'idstamphandling'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('stamphandling','idstamphandling','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 10:09:11.110'},'''NINO''','NINO',{ts '2007-11-20 10:09:11.110'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'stamphandling'
		and C.name ='idstamphandlingint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [stamphandling] DROP COLUMN idstamphandlingint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='idstamphandlingint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN idstamphandlingint
END
GO
