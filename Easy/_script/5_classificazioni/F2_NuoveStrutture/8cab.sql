IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'cab'
		and C.name ='country'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [cab] DROP COLUMN country
	DELETE FROM columntypes WHERE tablename = 'cab' AND field = 'country'
END
GO