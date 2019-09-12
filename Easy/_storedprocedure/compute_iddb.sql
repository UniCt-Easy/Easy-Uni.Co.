if exists (select * from dbo.sysobjects where id = object_id(N'[compute_iddb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_iddb]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE compute_iddb(
	@iddb varchar(5)
)
AS BEGIN

-- exec compute_iddb 1429

CREATE TABLE #AllLicense(
	departmentname	varchar(150)
)

DECLARE @iddbdepartment varchar(50)
DECLARE @dip_nome varchar(300)
declare @query nvarchar(4000)

DECLARE crsdepartment INSENSITIVE CURSOR FOR
	SELECT iddbdepartment FROM dbdepartment
	OPEN crsdepartment 
FETCH NEXT FROM crsdepartment INTO @iddbdepartment

        WHILE @@fetch_status=0 begin
        	SET @dip_nome = @iddbdepartment + '.license'
			
                SET  @query = ' INSERT INTO #AllLicense(departmentname)'
							+ ' SELECT departmentname '       
                            + ' FROM '+@dip_nome
                            + ' WHERE iddb =  '+ convert(varchar(5), @iddb)
               EXEC sp_executesql @query
PRINT @query

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
end

deallocate crsdepartment


SELECT departmentname
FROM #AllLicense
WHERE departmentname IS NOT NULL


END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


exec compute_iddb 1429
