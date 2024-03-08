
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_indicatori_consorzio_toscana_varbudget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_indicatori_consorzio_toscana_varbudget]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione'
--	exec exp_indicatori_consorzio_toscana_varbudget 2023, {d '2023-01-01'}, {d '2023-07-16'}  
 
CREATE PROCEDURE [exp_indicatori_consorzio_toscana_varbudget]
(
	@ayear			int,
	@start			date ,
	@stop			date  
)
AS
BEGIN


--  9 - Variazioni di Budget

SELECT 
	'Variazione di Budget' as 'Oggetto' ,
	accountvar.yvar as 'Eserc.',
	accountvar.nvar as 'Num.',
	convert(varchar, accountvar.ct, 105) + ' ' + convert(varchar, accountvar.ct, 108) as 'Creazione', --114
	accountvar.cu as 'Utente creazione', 
	convert(varchar, accountvar.lt, 105) + ' ' + convert(varchar, accountvar.lt, 108) as 'Ultima modifica', 
	accountvar.lu as 'Ultimo utente'
FROM accountvar 
WHERE yvar = @ayear and adate between @start and @stop



END

GO

