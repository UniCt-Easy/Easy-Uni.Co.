
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


-- Aggiornamento tabella expense, income, expensevar, incomevar

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expense]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expensevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expensevar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_income]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_income]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
--
-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD autocodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expense] ALTER COLUMN autocodeint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD autocodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensevar] ALTER COLUMN autocodeint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD autocodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [income] ALTER COLUMN autocodeint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET autocodeint = 
	CASE
		WHEN autokind IN (2, 4)
		THEN (SELECT taxcode FROM tax WHERE tax.taxref = expense.autocode)
		WHEN autokind = 6
		THEN (SELECT idclawback FROM clawback WHERE clawback.clawbackref = expense.autocode)
		WHEN autokind IN (1, 3)
		THEN (SELECT idpettycash FROM pettycash WHERE pettycash.pettycode = expense.autocode)
		ELSE NULL
	END
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensevar SET autocodeint = 
	CASE
		WHEN autokind IN (2, 4)
		THEN (SELECT taxcode FROM tax WHERE tax.taxref = expensevar.autocode)
		WHEN autokind = 6
		THEN (SELECT idclawback FROM clawback WHERE clawback.clawbackref = expensevar.autocode)
		WHEN autokind IN (1, 3)
		THEN (SELECT idpettycash FROM pettycash WHERE pettycash.pettycode = expensevar.autocode)
		ELSE NULL
	END
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET autocodeint = 
	CASE
		WHEN autokind IN (2, 4)
		THEN (SELECT taxcode FROM tax WHERE tax.taxref = income.autocode)
		WHEN autokind = 6
		THEN (SELECT idclawback FROM clawback WHERE clawback.clawbackref = income.autocode)
		WHEN autokind = 7
		THEN (SELECT idpettycash FROM pettycash WHERE pettycash.pettycode = income.autocode)
		ELSE NULL
	END
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi (non ci sono chiavi da cambiare)

-- Passo 4.2: Indici (non ci sono chiavi da droppare)

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='autocode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN autocode
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'autocode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='autocode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN autocode
	DELETE FROM columntypes WHERE tablename = 'expensevar' AND field = 'autocode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='autocode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN autocode
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'autocode'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'autocode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD autocode int NULL
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN autocode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'autocode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD autocode int NULL
END
ELSE
	ALTER TABLE [income] ALTER COLUMN autocode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'autocode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD autocode int NULL
END
ELSE
	ALTER TABLE [expensevar] ALTER COLUMN autocode int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET autocode = autocodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET autocode = autocodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'autocodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensevar SET autocode = autocodeint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave (non ci sono campi chiave)

-- Passo 7.2: Campi non Chiave (non ci sono campi non chiave da impostare a not null)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi (non ci sono chiavi)
-- Passo 8.2: Indici (non ci sono indici)

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expense' AND field = 'autocode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-05-12 11:53:33.217'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2007-05-12 11:53:33.217'} WHERE tablename = 'expense' AND field = 'autocode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expense','autocode','N','int','4','','','System.Byte','int','S','','','N',{ts '2007-05-12 11:53:33.217'},'''SA''','NINO',{ts '2007-05-12 11:53:33.217'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensevar' AND field = 'autocode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-04-20 14:36:29.407'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.217'} WHERE tablename = 'expensevar' AND field = 'autocode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensevar','autocode','N','int','4','','','System.Byte','int','S','','','N',{ts '2007-04-20 14:36:29.407'},'''SARA''','SA',{ts '2007-05-12 11:53:33.217'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'income' AND field = 'autocode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:08.077'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.217'} WHERE tablename = 'income' AND field = 'autocode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('income','autocode','N','int','4','','','System.Byte','int','S','','','N',{ts '2006-10-12 10:22:08.077'},'''NINO''','SA',{ts '2007-05-12 11:53:33.217'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='autocodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN autocodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='autocodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN autocodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='autocodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN autocodeint
END
GO
