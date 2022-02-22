
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


-- Aggiornamento tabella UNDERWRITER e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- upb

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO underwriter (idunderwriter, description, ct, cu, lt, lu)
SELECT DISTINCT idunderwriter, idunderwriter, GETDATE(), 'SA', GETDATE(), 'SA'
FROM upb e
WHERE NOT EXISTS(SELECT * FROM underwriter k WHERE k.idunderwriter = e.idunderwriter)
AND e.idunderwriter IS NOT NULL

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'underwriter' and C.name = 'idunderwriterint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [underwriter] ADD idunderwriterint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idunderwriterint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idunderwriterint int NULL
END
ELSE
BEGIN
	ALTER TABLE [upb] ALTER COLUMN idunderwriterint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idunderwriterint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upb SET idunderwriterint = underwriter.idunderwriterint
	FROM underwriter
	WHERE underwriter.idunderwriter = upb.idunderwriter
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivakind
IF exists(SELECT * FROM sysconstraints where id=object_id('underwriter') and constid=object_id('xpkunderwriter'))
BEGIN
	ALTER TABLE [underwriter] drop constraint xpkunderwriter
END

IF exists(SELECT * FROM sysconstraints where id=object_id('underwriter') and constid=object_id('PK_underwriter'))
BEGIN
	ALTER TABLE [underwriter] drop constraint PK_underwriter
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono NON CI SONO INDICI

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'underwriter'
		and C.name ='idunderwriter'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [underwriter] DROP COLUMN idunderwriter
	DELETE FROM columntypes WHERE tablename = 'underwriter' AND field = 'idunderwriter'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upb'
		and C.name ='idunderwriter'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upb] DROP COLUMN idunderwriter
	DELETE FROM columntypes WHERE tablename = 'upb' AND field = 'idunderwriter'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'underwriter' and C.name = 'idunderwriter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [underwriter] ADD idunderwriter int NULL 
END
ELSE
	ALTER TABLE [underwriter] ALTER COLUMN idunderwriter int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idunderwriter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idunderwriter int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idunderwriter int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'underwriter' and C.name = 'idunderwriter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE underwriter SET idunderwriter = idunderwriterint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idunderwriter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upb SET idunderwriter = idunderwriterint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'underwriter' and C.name = 'idunderwriter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [underwriter] ALTER COLUMN idunderwriter int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave NON CI SONO CAMPI NON CHIAVE

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('underwriter') and constid=object_id('xpkunderwriter'))
BEGIN
	ALTER TABLE [underwriter] ADD CONSTRAINT xpkunderwriter PRIMARY KEY (idunderwriter)
END
GO

-- Passo 8.2: Indici NON CI SONO INDICI

-- Passo 9. Scrittura in COLUMNTYPES

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'underwriter'
		and C.name ='idunderwriterint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [underwriter] DROP COLUMN idunderwriterint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upb'
		and C.name ='idunderwriterint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upb] DROP COLUMN idunderwriterint
END
GO
