-- Aggiornamento tabella PETTYCASH e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
-- Aggiunta dei nuovi campi e/o campi temporanei
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycash'
		and C.name ='flagopening'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycash] DROP COLUMN flagopening
	DELETE FROM columntypes WHERE tablename = 'pettycash' AND field = 'flagopening'
END
GO
