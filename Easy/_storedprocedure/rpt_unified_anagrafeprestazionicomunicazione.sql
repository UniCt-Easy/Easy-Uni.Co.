if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_anagrafeprestazionicomunicazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_anagrafeprestazionicomunicazione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE     PROCEDURE [rpt_unified_anagrafeprestazionicomunicazione]
(
	@ayear smallint, 
	@idreg int, 
	@show_addr_anagp char(1),
    @unified char(1), -- consolidamento dei dati 
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
/*

 exec rpt_unified_anagrafeprestazionicomunicazione 2011,21,'N','S'

*/
IF (@unified <> 'S')
BEGIN
        EXEC rpt_anagrafeprestazionicomunicazione @ayear,@idreg,@show_addr_anagp,@idsor01,@idsor02,	@idsor03,@idsor04,	@idsor05  

        RETURN
END 

CREATE TABLE #unified (
        departmentname  varchar(150),
        idreg int,
        registry varchar(100),
        nservreg int,
        cf varchar(16),
        birthdate smalldatetime,
        grossamount decimal (19,2),
        start smalldatetime,
        stop smalldatetime,
        apactivitykind varchar(150),
        authorizationdate smalldatetime,
        annoliquidazione smallint,
        b_city varchar(120),
        b_province varchar(2),
        b_nation varchar(65),
	sent_agency varchar(50),
        sent_office varchar(50),
	sent_address varchar(100),
	sent_idaddresskind varchar(20), 
	sent_location varchar(120),
	sent_cap varchar(20),
	sent_province varchar(2),
	sent_nation varchar(65),
	residence_address varchar(100),
	residence_idaddresskind varchar(20),
	residence_location varchar(120),
	residence_cap varchar(20),
	residence_province varchar(2),
	residence_nation varchar(65),
	description varchar(200)
)

	
declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
			 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)

	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
        SET @dip_nomesp = '['+@iddbdepartment+']'+ '.rpt_anagrafeprestazionicomunicazione'
PRINT @iddbdepartment
		INSERT INTO #unified (
                departmentname,
                idreg,
                registry ,
                nservreg,
                cf ,
                birthdate ,
                grossamount,
                start ,
                stop,
                apactivitykind ,
                authorizationdate ,
                annoliquidazione ,
                b_city,
                b_province,
                b_nation,
		sent_agency,
                sent_office,
                sent_address,
                sent_idaddresskind, 
                sent_location,
                sent_cap,
                sent_province,
                sent_nation,
                residence_address,
                residence_idaddresskind,
                residence_location,
                residence_cap,
                residence_province ,
                residence_nation,
                description  
		)
		EXEC @dip_nomesp @ayear,@idreg,@show_addr_anagp, @idsor01,@idsor02,	@idsor03,@idsor04,	@idsor05 
 

	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
end

DEALLOCATE @crsdepartment

SELECT
        departmentname,
        #unified.idreg,
        ISNULL(#unified.registry,registry.idreg) as registry,
        nservreg,
        #unified.cf ,
        #unified.birthdate ,
        grossamount,
        start ,
        stop,
        apactivitykind ,
        authorizationdate ,
        annoliquidazione ,
        b_city,
        b_province,
        b_nation,
	sent_agency,
        sent_office,
        sent_address,
        sent_idaddresskind, 
        sent_location,
        sent_cap,
        sent_province,
        sent_nation,
        residence_address,
        residence_idaddresskind,
        residence_location,
        residence_cap,
        residence_province ,
        residence_nation,
        description 
FROM #unified
	JOIN registry
		ON #unified.idreg = registry.idreg

DROP TABLE #unified
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO