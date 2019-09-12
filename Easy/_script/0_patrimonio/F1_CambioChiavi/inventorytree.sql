-- Aggiornamento tabella INVENTORYTREE e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- assetacquire, assetvardetail, inventorysortingamortizationyear, inventorytreesorting, mandatedetail

-- Passo 0: Cancellazione di righe che violano l'integrità referenziale
DELETE FROM inventorytreesorting WHERE NOT EXISTS(SELECT * FROM inventorytree WHERE inventorytree.idinv = inventorytreesorting.idinv)
GO

DELETE FROM inventorysortingamortizationyear WHERE NOT EXISTS(SELECT * FROM inventorytree WHERE inventorytree.idinv = inventorysortingamortizationyear.idinv)
GO

INSERT INTO inventorytree (idinv, codeinv, description, paridinv, nlevel, ct, cu, lt, lu)
SELECT DISTINCT idinv, idinv, idinv, CASE WHEN LEN(idinv) > 4 THEN SUBSTRING(idinv, 1, LEN(idinv)-4) ELSE NULL END,
LEN(idinv) / 4, GETDATE(), 'SA', GETDATE(), 'SA' 
FROM assetacquire
WHERE idinv NOT IN (SELECT idinv FROM inventorytree WHERE inventorytree.idinv = assetacquire.idinv)

INSERT INTO inventorytree (idinv, codeinv, description, paridinv, nlevel, ct, cu, lt, lu)
SELECT DISTINCT idinv, idinv, idinv, CASE WHEN LEN(idinv) > 4 THEN SUBSTRING(idinv, 1, LEN(idinv)-4) ELSE NULL END,
LEN(idinv) / 4, GETDATE(), 'SA', GETDATE(), 'SA' 
FROM assetvardetail
WHERE idinv NOT IN (SELECT idinv FROM inventorytree WHERE inventorytree.idinv = assetvardetail.idinv)

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD idinvint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'paridinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD paridinvint int NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorytree] ALTER COLUMN paridinvint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idinvint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idinvint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ADD idinvint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetvardetail] ALTER COLUMN idinvint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ADD idinvint int NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ALTER COLUMN idinvint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD idinvint int NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorytreesorting] ALTER COLUMN idinvint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idinvint int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatedetail] ALTER COLUMN idinvint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'paridinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytree SET paridinvint =
		(SELECT idinvint FROM inventorytree i2 WHERE i2.idinv = inventorytree.paridinv)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idinvint = inventorytree.idinvint
	FROM inventorytree
	WHERE assetacquire.idinv = inventorytree.idinv
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvardetail SET idinvint = inventorytree.idinvint
	FROM inventorytree
	WHERE assetvardetail.idinv = inventorytree.idinv
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorysortingamortizationyear SET idinvint = inventorytree.idinvint
	FROM inventorytree
	WHERE inventorysortingamortizationyear.idinv = inventorytree.idinv
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytreesorting SET idinvint = inventorytree.idinvint
	FROM inventorytree
	WHERE inventorytreesorting.idinv = inventorytree.idinv
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idinvint = inventorytree.idinvint
	FROM inventorytree
	WHERE mandatedetail.idinv = inventorytree.idinv
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono inventorytree, inventorysortingamortizationyear, inventorytreesorting

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorytree') and constid=object_id('xpkinventorytree'))
BEGIN
	ALTER TABLE [inventorytree] drop constraint xpkinventorytree
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorytree') and constid=object_id('PK_inventorytree'))
BEGIN
	ALTER TABLE [inventorytree] drop constraint PK_inventorytree
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('assetvardetail') and constid=object_id('xpkassetvardetail'))
BEGIN
	ALTER TABLE [assetvardetail] drop constraint xpkassetvardetail
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetvardetail') and constid=object_id('PK_assetvardetail'))
BEGIN
	ALTER TABLE [assetvardetail] drop constraint PK_assetvardetail
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorysortingamortizationyear') and constid=object_id('xpkinventorysortingamortizationyear'))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] drop constraint xpkinventorysortingamortizationyear
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorysortingamortizationyear') and constid=object_id('PK_inventorysortingamortizationyear'))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] drop constraint PK_inventorysortingamortizationyear
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorytreesorting') and constid=object_id('xpkinventorytreesorting'))
BEGIN
	ALTER TABLE [inventorytreesorting] drop constraint xpkinventorytreesorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorytreesorting') and constid=object_id('PK_inventorytreesorting'))
BEGIN
	ALTER TABLE [inventorytreesorting] drop constraint PK_inventorytreesorting
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorytree' and id=object_id('inventorytree'))
	drop index inventorytree.xi1inventorytree

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetacquire' and id=object_id('assetacquire'))
	drop index assetacquire.xi3assetacquire

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetvardetail' and id=object_id('assetvardetail'))
	drop index assetvardetail.xi2assetvardetail

IF EXISTS (SELECT * FROM sysindexes where name='xi2inventorytreesorting' and id=object_id('inventorytreesorting'))
	drop index inventorytreesorting.xi2inventorytreesorting
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytree'
		and C.name ='idinv'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytree] DROP COLUMN idinv
	DELETE FROM columntypes WHERE tablename = 'inventorytree' AND field = 'idinv'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytree'
		and C.name ='paridinv'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytree] DROP COLUMN paridinv
	DELETE FROM columntypes WHERE tablename = 'inventorytree' AND field = 'paridinv'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='idinv'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idinv
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'idinv'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvardetail'
		and C.name ='idinv'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvardetail] DROP COLUMN idinv
	DELETE FROM columntypes WHERE tablename = 'assetvardetail' AND field = 'idinv'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortingamortizationyear'
		and C.name ='idinv'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] DROP COLUMN idinv
	DELETE FROM columntypes WHERE tablename = 'inventorysortingamortizationyear' AND field = 'idinv'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytreesorting'
		and C.name ='idinv'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytreesorting] DROP COLUMN idinv
	DELETE FROM columntypes WHERE tablename = 'inventorytreesorting' AND field = 'idinv'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name ='idinv'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idinv
	DELETE FROM columntypes WHERE tablename = 'mandatedetail' AND field = 'idinv'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate expense e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD idinv int NULL 
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN idinv int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'paridinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD paridinv int NULL 
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN paridinv int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idinv int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idinv int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ADD idinv int NULL 
END
ELSE
	ALTER TABLE [assetvardetail] ALTER COLUMN idinv int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ADD idinv int NULL 
END
ELSE
	ALTER TABLE [inventorysortingamortizationyear] ALTER COLUMN idinv int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD idinv int NULL 
END
ELSE
	ALTER TABLE [inventorytreesorting] ALTER COLUMN idinv int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idinv int NULL 
END
ELSE
	ALTER TABLE [mandatedetail] ALTER COLUMN idinv int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytree SET idinv = idinvint, paridinv = paridinvint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idinv = idinvint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvardetail SET idinv = idinvint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorysortingamortizationyear SET idinv = idinvint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytreesorting SET idinv = idinvint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idinvint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idinv = idinvint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ALTER COLUMN idinv int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ALTER COLUMN idinv int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytreesorting] ALTER COLUMN idinv int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ALTER COLUMN idinv int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE A NOT NULL)
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idinv int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorytree') and constid=object_id('xpkinventorytree'))
BEGIN
	ALTER TABLE [inventorytree] ADD CONSTRAINT xpkinventorytree PRIMARY KEY (idinv)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetvardetail') and constid=object_id('xpkassetvardetail'))
BEGIN
	ALTER TABLE [assetvardetail] ADD CONSTRAINT xpkassetvardetail PRIMARY KEY (yvar, nvar, idinv, rownum)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorysortingamortizationyear') and constid=object_id('xpkinventorysortingamortizationyear'))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ADD CONSTRAINT xpkinventorysortingamortizationyear PRIMARY KEY (ayear, idinv, idinventoryamortization)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorytreesorting') and constid=object_id('xpkinventorytreesorting'))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD CONSTRAINT xpkinventorytreesorting PRIMARY KEY (idsorkind, idsor, idinv)
END
GO

-- Passo 8.2: Indici

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorytree' and id=object_id('inventorytree'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorytree ON inventorytree (paridinv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorytree
	ON inventorytree (paridinv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetacquire' and id=object_id('assetacquire'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetacquire ON assetacquire (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetacquire
	ON assetacquire (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetacquire' and id=object_id('assetacquire'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetacquire ON assetacquire (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetacquire
	ON assetacquire (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetvardetail' and id=object_id('assetvardetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetvardetail ON assetvardetail (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetvardetail
	ON assetvardetail (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorysortingamortizationyear' and id=object_id('inventorysortingamortizationyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorysortingamortizationyear ON inventorysortingamortizationyear (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorysortingamortizationyear
	ON inventorysortingamortizationyear (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2inventorytreesorting' and id=object_id('inventorytreesorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2inventorytreesorting ON inventorytreesorting (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2inventorytreesorting
	ON inventorytreesorting (idinv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'idinv')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 21:14:38.203'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 21:14:38.203'} WHERE tablename = 'assetacquire' AND field = 'idinv'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','idinv','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 21:14:38.203'},'''NINO''','NINO',{ts '2007-10-23 21:14:38.203'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvardetail' AND field = 'idinv')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 21:14:32.467'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 21:14:32.467'} WHERE tablename = 'assetvardetail' AND field = 'idinv'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvardetail','idinv','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 21:14:32.467'},'''NINO''','NINO',{ts '2007-10-23 21:14:32.467'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorysortingamortizationyear' AND field = 'idinv')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 21:14:46.827'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 21:14:46.827'} WHERE tablename = 'inventorysortingamortizationyear' AND field = 'idinv'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorysortingamortizationyear','idinv','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 21:14:46.827'},'''NINO''','NINO',{ts '2007-10-23 21:14:46.827'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorytree' AND field = 'idinv')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 21:14:47.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 21:14:47.250'} WHERE tablename = 'inventorytree' AND field = 'idinv'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorytree','idinv','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 21:14:47.250'},'''NINO''','NINO',{ts '2007-10-23 21:14:47.250'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorytree' AND field = 'paridinv')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 21:14:47.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 21:14:47.250'} WHERE tablename = 'inventorytree' AND field = 'paridinv'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorytree','paridinv','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-23 21:14:47.250'},'''NINO''','NINO',{ts '2007-10-23 21:14:47.250'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorytreesorting' AND field = 'idinv')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 21:14:47.063'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 21:14:47.063'} WHERE tablename = 'inventorytreesorting' AND field = 'idinv'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorytreesorting','idinv','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 21:14:47.063'},'''NINO''','NINO',{ts '2007-10-23 21:14:47.063'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatedetail' AND field = 'idinv')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 21:14:39.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 21:14:39.420'} WHERE tablename = 'mandatedetail' AND field = 'idinv'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandatedetail','idinv','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-23 21:14:39.420'},'''NINO''','NINO',{ts '2007-10-23 21:14:39.420'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytree'
		and C.name ='idinvint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytree] DROP COLUMN idinvint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytree'
		and C.name ='paridinvint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytree] DROP COLUMN paridinvint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='idinvint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idinvint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvardetail'
		and C.name ='idinvint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvardetail] DROP COLUMN idinvint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortingamortizationyear'
		and C.name ='idinvint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] DROP COLUMN idinvint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytreesorting'
		and C.name ='idinvint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytreesorting] DROP COLUMN idinvint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name ='idinvint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idinvint
END
GO
