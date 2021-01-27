
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_esterometrocheck]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_esterometrocheck]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
CREATE procedure exp_esterometrocheck(
	@esercizio int,		-- anno solare
	@trimestre int,		-- vale 1 o 2 o 3 o 4
	@mese int,			-- vale da 1 1 12
	@kind char(1)		-- Acquisto o Vendita
	) as
begin
--setuser'amm'
-- exec exp_esterometrocheck 2019,2,6,'A'
 

DECLARE @meseinizio int
DECLARE @mesefine int
 
IF (@mese is not null)
BEGIN
	SELECT @meseinizio = @mese
	SELECT @mesefine = @mese
END 
ELSE
BEGIN
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9
			when @trimestre = 4 then 12
	END
END



----------------- Calcola la Sede dell' Anagrafica ------------------------------------------
 CREATE TABLE #SedeAnagrafica
(
	idaddresskind int,
    idreg int,
	address varchar(60),	
	location varchar(60),
	cap varchar(20),		
	province varchar(2),
	nation varchar(2)
)

INSERT INTO #SedeAnagrafica(idaddresskind, idreg, address,	location, cap, province, nation)
SELECT * FROM f_get_esterometrosede(	@esercizio, @trimestre, @mese, @kind   )
-------------------- Fine calcolo della Sede del Anagrafica -------------------------------------------------

CREATE TABLE #error (message varchar(400))

INSERT INTO #error
	select 'L''anagrafica ' + CONVERT(varchar(20), idreg) + ' ha il CAP:'+ CONVERT(varchar(20), cap) + ', di lunghezza maggiore di 5 caratteri.'
	from #SedeAnagrafica
	where len(cap)>5

	select * from #error


end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


