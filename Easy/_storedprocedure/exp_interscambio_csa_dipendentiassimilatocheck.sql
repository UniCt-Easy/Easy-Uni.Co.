if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_csa_dipendentiassimilatocheck]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_csa_dipendentiassimilatocheck]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE exp_interscambio_csa_dipendentiassimilatocheck (
	@ayear int,
	@start datetime,
	@stop datetime
	)
AS 
BEGIN
/*

exec  exp_interscambio_csa_dipendentiassimilatocheck 2011, {d '2011-01-01'},{d '2011-12-31'}

 */
--------------------------------------------------------------------------------------- Interroghiamo i singoli dipartimenti ----------------------------------------------------------------

CREATE TABLE #AllCompensi(
		ncon	int,
		ycon	int,
		idreg int,
		kind varchar(50),
		departmentname varchar(200)
		)
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
			where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
											  
		set @dip_nomesp = @iddbdepartment + '.exp_interscambio_csa_dipendentiassimilato_singlecheck'

		INSERT INTO #AllCompensi(
				departmentname,
				idreg,
				ncon,
				ycon,
				kind
	)
		exec @dip_nomesp  @ayear, @start, @stop
		fetch next from @crsdepartment into @iddbdepartment
	
	END

SELECT 
	R.title as 'Anagrafica',
	departmentname as 'Dipartimento',
	kind as 'Compenso',
	ycon as 'Eserc.Compensi.',
	ncon as 'Nun.Compenso'
FROM #AllCompensi C
JOIN registry R
	ON C.idreg = R.idreg
ORDER BY R.title, departmentname, ycon, ncon

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




