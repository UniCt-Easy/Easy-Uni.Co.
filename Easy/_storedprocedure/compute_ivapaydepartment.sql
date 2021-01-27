
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_ivapaydepartment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_ivapaydepartment]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  procedure [compute_ivapaydepartment] (	
	@ayear int,
	@nmonth int,
	@flag tinyint
) as begin

	CREATE TABLE #currivapayed (
		iddbdepartment varchar(50),
		idregauto int,
		refundamount decimal(19,2), 
		paymentamount decimal(19,2),
		refundamount12 decimal(19,2), 
		paymentamount12 decimal(19,2)
	)
	--[compute_ivapaydepartment] 2011, 12, 8
	declare @query nvarchar(3000)
	declare @iddbdepartment varchar(50)
	declare @ivapay varchar(50)
	declare @config varchar(50)

	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment 
	where   (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	order by iddbdepartment
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
	print @iddbdepartment
		declare @s varchar(300)
    	SET @ivapay = @iddbdepartment + '.ivapay'
    	SET @config = @iddbdepartment + '.config'
        SET  @query = 
		' SELECT 
			'''+@iddbdepartment+''',
				C.idregauto,
				I.refundamount, 
				I.paymentamount,
				I.refundamount12, 
				I.paymentamount12
			FROM '+ @ivapay + ' I
			JOIN '+ @config + ' C
					ON i.yivapay = c.ayear
		WHERE MONTH(I.stop) = ' + CONVERT(varchar(4),@nmonth) + ' ' + 
		' AND YEAR(I.stop) = ' + CONVERT(varchar(4),@ayear) + ' '  +
		' AND (I. flag & 3) = ('+convert(varchar(1),@flag & 3)+')'     

		insert into #currivapayed 
			(
			iddbdepartment,
			idregauto,
			refundamount, 
			paymentamount,
			refundamount12, 
			paymentamount12
			)
		EXEC sp_executesql @query

		fetch next from @crsdepartment into @iddbdepartment
	end

SELECT
		I.iddbdepartment, 
		D.description AS department,
		I.idregauto,
		R.title AS regautotitle,
		--ISNULL(I.refundamount,0) AS refundamount, 
		--ISNULL(I.paymentamount,0) AS paymentamount
		ISNULL(paymentamount,-refundamount) AS ivapay,
		ISNULL(paymentamount12,-refundamount12) AS ivapay12
FROM #currivapayed I
JOIN dbdepartment D
	ON D.iddbdepartment=I.iddbdepartment
LEFT OUTER JOIN registry R
	ON R.idreg = I.idregauto
DROP TABLE #currivapayed

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- compute_ivapaydepartment 2010,1,1
