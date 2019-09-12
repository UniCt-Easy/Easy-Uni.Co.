if exists (select * from dbo.sysobjects where id = object_id(N'[fill_unifiedclawback]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [fill_unifiedclawback]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [fill_unifiedclawback]
(
	@ayear smallint, 
	@stop datetime

)
as 
BEGIN
--[fill_unifiedclawback] 2011, {d '2011-12-31'}
DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
								WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.fill_departmentclawback'
PRINT @iddbdepartment

	IF EXISTS (
	SELECT  '['+ sysusers.name + ']' + '.'+ sysobjects.name 
	FROM   sysobjects 
	JOIN   sysusers ON sysobjects.uid = sysusers.uid 
	WHERE  sysusers.name  = @iddbdepartment and sysobjects.xtype = 'P' 
	AND    sysobjects.name  = 'fill_departmentclawback'
	)
	BEGIN
		EXEC @dip_nomesp @iddbdepartment, @ayear, @stop
	END

	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment

END


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
