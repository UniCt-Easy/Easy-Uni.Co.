
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


-- Aggiornamento tabella IVAPAYPERIODICITY e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- config

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO ivapayperiodicity (idivapayperiodicity, description, periodicday, periodicity, periodicmonth, ct, cu, lt, lu)
SELECT DISTINCT idivapayperiodicity, idivapayperiodicity, 0, 0, 0, GETDATE(), 'SA', GETDATE(), 'SA'
FROM config e
WHERE NOT EXISTS(SELECT * FROM ivapayperiodicity k WHERE k.idivapayperiodicity = e.idivapayperiodicity)
AND e.idivapayperiodicity IS NOT NULL

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayperiodicity' and C.name = 'idivapayperiodicityint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayperiodicity] ADD idivapayperiodicityint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idivapayperiodicityint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD idivapayperiodicityint int NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN idivapayperiodicityint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idivapayperiodicityint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE config SET idivapayperiodicityint = ivapayperiodicity.idivapayperiodicityint
	FROM ivapayperiodicity
	WHERE ivapayperiodicity.idivapayperiodicity = config.idivapayperiodicity
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivakind
IF exists(SELECT * FROM sysconstraints where id=object_id('ivapayperiodicity') and constid=object_id('xpkivapayperiodicity'))
BEGIN
	ALTER TABLE [ivapayperiodicity] drop constraint xpkivapayperiodicity
END

IF exists(SELECT * FROM sysconstraints where id=object_id('ivapayperiodicity') and constid=object_id('PK_ivapayperiodicity'))
BEGIN
	ALTER TABLE [ivapayperiodicity] drop constraint PK_ivapayperiodicity
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono NON CI SONO INDICI

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivapayperiodicity'
		and C.name ='idivapayperiodicity'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivapayperiodicity] DROP COLUMN idivapayperiodicity
	DELETE FROM columntypes WHERE tablename = 'ivapayperiodicity' AND field = 'idivapayperiodicity'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='idivapayperiodicity'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN idivapayperiodicity
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'idivapayperiodicity'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayperiodicity' and C.name = 'idivapayperiodicity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayperiodicity] ADD idivapayperiodicity int NULL 
END
ELSE
	ALTER TABLE [ivapayperiodicity] ALTER COLUMN idivapayperiodicity int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idivapayperiodicity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD idivapayperiodicity int NULL 
END
ELSE
	ALTER TABLE [config] ALTER COLUMN idivapayperiodicity int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayperiodicity' and C.name = 'idivapayperiodicity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivapayperiodicity SET idivapayperiodicity = idivapayperiodicityint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idivapayperiodicity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE config SET idivapayperiodicity = idivapayperiodicityint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayperiodicity' and C.name = 'idivapayperiodicity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayperiodicity] ALTER COLUMN idivapayperiodicity int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave NON CI SONO CAMPI NON CHIAVE

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivapayperiodicity') and constid=object_id('xpkivapayperiodicity'))
BEGIN
	ALTER TABLE [ivapayperiodicity] ADD CONSTRAINT xpkivapayperiodicity PRIMARY KEY (idivapayperiodicity)
END
GO

-- Passo 8.2: Indici NON CI SONO INDICI

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'idivapayperiodicity')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 17:31:43.453'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 17:31:43.453'} WHERE tablename = 'config' AND field = 'idivapayperiodicity'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','idivapayperiodicity','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 17:31:43.453'},'''NINO''','NINO',{ts '2007-11-20 17:31:43.453'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivapayperiodicity' AND field = 'idivapayperiodicity')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 17:31:29.843'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 17:31:29.843'} WHERE tablename = 'ivapayperiodicity' AND field = 'idivapayperiodicity'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('ivapayperiodicity','idivapayperiodicity','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 17:31:29.843'},'''NINO''','NINO',{ts '2007-11-20 17:31:29.843'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivapayperiodicity'
		and C.name ='idivapayperiodicityint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivapayperiodicity] DROP COLUMN idivapayperiodicityint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name ='idivapayperiodicityint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN idivapayperiodicityint
END
GO
