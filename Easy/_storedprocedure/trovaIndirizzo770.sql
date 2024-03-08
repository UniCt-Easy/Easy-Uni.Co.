
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trovaIndirizzo770]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trovaIndirizzo770]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure trovaIndirizzo770(@idreg int, @data datetime, @idaddresskind int output, @start datetime output)
as begin
	declare @domfi int
	select  @domfi = idaddress from address where codeaddress = '07_SW_DOM'
	
	
	declare @stand int
	select  @stand = idaddress from address where codeaddress = '07_SW_DEF'

	/*select 
		@start = (select max(registryaddress.start) 
		from registryaddress
		where registryaddress.idreg = @idreg
		and registryaddress.idaddresskind = @domfi
		and registryaddress.start <= @data)*/
	
	SELECT @start = (SELECT TOP 1 start FROM registryaddress WHERE (idreg=@idreg)
	AND(idaddresskind = @domfi)AND(@data 
	BETWEEN start AND ISNULL(stop,@data)))

	if @start is not null
	begin
		select @idaddresskind = @domfi
		return
	end

	/*select  @start = max(registryaddress.start)
		from registryaddress 
		where registryaddress.idreg = @idreg
		and registryaddress.idaddresskind = @stand
		and registryaddress.start <= @data*/
	
	-- In assenza di un domicilio fiscale, si considera un indirizzo di residenza 
	-- valido alla data di riferimento
	SELECT @start = (SELECT TOP 1 start FROM registryaddress WHERE (idreg=@idreg)
	AND(idaddresskind = @stand)AND(@data 
	BETWEEN start AND ISNULL(stop,@data)))

	if @start is not null
	begin
		select @idaddresskind = @stand
		return
	end

	-- Le righe successive, servono a considerare l'indirizzo più recente del 
	-- percipiente, in caso non siano stati inseriti nè domicilio fiscale
	-- nè l'indirizzo di residenza. Tuttavia per il futuro, avendo inserito 
	-- una regola sull'obbligatorietà di uno dei due indirizzi, questa parte potrà 
	-- essere considerata superflua. Al momento è opportuno lasciarla perchè
	-- si devono considerare i contratti vecchi
	select top 1 
		@idaddresskind = registryaddress.idaddresskind,
		@start = registryaddress.start
		from registryaddress 
		where registryaddress.idreg = @idreg
		and registryaddress.start <= @data
		order by registryaddress.start desc
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

