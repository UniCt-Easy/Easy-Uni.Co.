-- Script che sposta il valore dei campi idman e idlocation di asset in assetmanager e assetlocation
-- Passo 1: Inserimento dei dati nelle tabelle figlie (assetmanager e assetlocation)
INSERT INTO assetmanager (idasset, idassetmanager, idman, ct, cu, lt, lu)
SELECT asset.idasset, 1 + ISNULL((SELECT COUNT(*) FROM assetmanager m WHERE m.idasset = asset.idasset),0),
asset.idman, GETDATE(), 'SA', GETDATE(), 'SA'
FROM asset
JOIN assetacquire
	ON asset.nassetacquire = assetacquire.nassetacquire
WHERE asset.idpiece = 1
	AND asset.idman IS NOT NULL

INSERT INTO assetlocation (idasset, idassetlocation, idlocation, ct, cu, lt, lu)
SELECT asset.idasset, 1 + ISNULL((SELECT COUNT(*) FROM assetlocation l WHERE l.idasset = asset.idasset),0),
asset.idlocation, GETDATE(), 'SA', GETDATE(), 'SA'
FROM asset
JOIN assetacquire
	ON asset.nassetacquire = assetacquire.nassetacquire
WHERE asset.idpiece = 1
	AND asset.idlocation IS NOT NULL
GO

-- Passo 2: Rimozione di eventuali indici di asset
IF EXISTS (SELECT * FROM sysindexes where name='xi2asset' and id=object_id('asset'))
	drop index asset.xi2asset

IF EXISTS (SELECT * FROM sysindexes where name='xi3asset' and id=object_id('asset'))
	drop index asset.xi3asset
GO

-- Passo 3: Cancellazione del campo da asset
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'asset' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='idlocation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN idlocation
	DELETE FROM columntypes WHERE tablename = 'asset' AND field = 'idlocation'
END
GO


