
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


-- Aggiornamento tabella BANKTRANSACTIONSORTING e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale NULLA

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) -

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate) -

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate -

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivakind
IF exists(SELECT * FROM sysconstraints where id=object_id('banktransactionsorting') and constid=object_id('xpkbanktransactionsorting'))
BEGIN
	ALTER TABLE [banktransactionsorting] drop constraint xpkbanktransactionsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('banktransactionsorting') and constid=object_id('PK_banktransactionsorting'))
BEGIN
	ALTER TABLE [banktransactionsorting] drop constraint PK_banktransactionsorting
END
GO

-- Passo 4.2: Indici -
-- Tabelle interessate sono -

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransactionsorting'
		and C.name ='yban'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransactionsorting] ALTER COLUMN yban smallint NOT NULL
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) -
-- Tabelle interessate foreigncountry e tabelle collegate

-- Passo 6. Valorizzazione nuovo campo -

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave -

-- Passo 7.2: Campi non Chiave -

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('banktransactionsorting') and constid=object_id('xpkbanktransactionsorting'))
BEGIN
	ALTER TABLE [banktransactionsorting] ADD CONSTRAINT xpkbanktransactionsorting PRIMARY KEY (yban, nban, idsor)
END
GO

-- Passo 8.2: Indici -

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'banktransactionsorting' AND field = 'yban')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-30 10:05:42.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-30 10:05:42.577'} WHERE tablename = 'banktransactionsorting' AND field = 'yban'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('banktransactionsorting','yban','S','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-11-30 10:05:42.577'},'''NINO''','NINO',{ts '2007-11-30 10:05:42.577'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
