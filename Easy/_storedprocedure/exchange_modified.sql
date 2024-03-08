
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exchange_modified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exchange_modified]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--setuser 'amm'
-- declare @res int
-- exec exchange_modified null, {d '2022-03-29'}, 27, 0.00731743, 7, 0.90211998, @res out
-- select @res
-- 27, 0.00731743, 7, 0.90211998,
GO
/****** Object:  StoredProcedure [amm].[exchange_modified]    Script Date: 05/10/2022 14:42:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [exchange_modified]
@docdate date,
@stoptime date,
@idcurrency int,
@rate decimal(19,6),
@idcurrency_old int,
@rate_old decimal(19,6),
@res int out

as begin
	declare @referencedate date = coalesce(@docdate, (coalesce(@stoptime, getdate())))
	declare @calculated_rate decimal(19,6)

	set @calculated_rate = (
		select top 1 eurocurrencyrate 
		from currencyexchange 
		where referencedate 
			between dateadd(DAY, -7, @referencedate) and @referencedate
			and idcurrency = @idcurrency
		order by referencedate desc
	)
	
	
	if @referencedate IS NULL or @rate IS NULL--or @calculated_rate IS NULL
	begin 
		set @res = 0
		return
	end

	if @idcurrency_old is null and @rate_old is null and isnull(@rate,0) = isnull(@calculated_rate,0)
	begin
		set @res = 0
		return
	end

	if @idcurrency_old <> @idcurrency and isnull(@rate,0) = isnull(@calculated_rate,0)
	begin
		set @res = 0
		return
	end

	if @idcurrency_old = @idcurrency and @rate_old = @rate and isnull(@rate,0) = isnull(@calculated_rate,0)
	begin
		set @res = 0
		return
	end
	else
		set @res = 1

	print @idcurrency
	print @referencedate
	print @rate
	print @calculated_rate
	print @res
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
