
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_4certificazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_4certificazioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE     PROCEDURE [rpt_unified_4certificazioni]
(
	@ayear smallint, 
	@idreg int, 
	@start datetime,
	@stop datetime,
	@certificatekind char(1),
    @unified char(1) -- consolidamento dei dati 
)
AS BEGIN

IF (@unified <> 'S')
BEGIN
        EXEC rpt_4certificazioni @ayear, @idreg, @start, @stop, @certificatekind
        RETURN
END 

CREATE TABLE #unified (
        departmentname  varchar(150),
	idexp int,
	idreg int ,
	registry varchar(100),
	b_city varchar(120),
   	birthdate smalldatetime,
	b_province varchar(2),
	b_nation varchar(65),
	cf varchar(16),
	p_iva varchar(15),
	taxdescription varchar(50),
	expensedescription varchar(150),	
	service varchar(50),
	idser int,
	npay int,
	taxablenet decimal(19,2),
	grossamount decimal(19,2), --Importo Lordo del Pagamento
	employtax decimal(19,2),
	admintax decimal(19,2),
	taxablegross decimal(19,2), -- Imponibile Lordo
	sent_address varchar(100),
	sent_location varchar(120),
	sent_cap varchar(20),
	sent_province varchar(2),
	foreigncf varchar(40)
)


DECLARE @iddbdepartment varchar(50)

--DECLARE @crsdepartment cursor
--SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
DECLARE crsdepartment  cursor LOCAL STATIC FOR 
SELECT iddbdepartment FROM dbdepartment 
WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
FOR READ ONLY

OPEN crsdepartment

FETCH NEXT FROM crsdepartment INTO @iddbdepartment
			 
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
        SET @dip_nomesp = '['+@iddbdepartment+']'+ '.rpt_4certificazioni'
PRINT @iddbdepartment
		INSERT INTO #unified (
                        departmentname,
                	idexp,
                	idreg,
                	registry,
                	b_city,
                   	birthdate,
                	b_province,
                	b_nation,
                	cf,p_iva,
                	taxdescription,
                	expensedescription,	
                	service,
                	idser,
                	npay,
                	taxablenet,
                	grossamount,--Importo Lordo del Pagamento
                	employtax,
                	admintax,
                	--taxablegross, -- Imponibile Lordo
                	sent_address,
                	sent_location,
                	sent_cap,
                	sent_province,
					foreigncf
		)
		EXEC @dip_nomesp @ayear, @idreg, @start, @stop, @certificatekind

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
end

DEALLOCATE crsdepartment

SELECT
        departmentname,
	idexp,
	idreg,
	registry,
	b_city,
   	birthdate,
	b_province,
	b_nation,
	cf,p_iva,
	taxdescription,
	expensedescription,	
	service,
	idser,
	npay,
	taxablenet,
	grossamount,--Importo Lordo del Pagamento
	employtax,
	admintax,
--	taxablegross, -- Imponibile Lordo
	sent_address,
	sent_location,
	sent_cap,
	sent_province,
	foreigncf
FROM #unified

DROP TABLE #unified
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
