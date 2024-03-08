
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_indicatori_consorzio_toscana_cespiti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_indicatori_consorzio_toscana_cespiti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
--	exec exp_indicatori_consorzio_toscana_cespiti 2023, {d '2023-01-01'}, {d '2023-07-16'}  
 
CREATE PROCEDURE [exp_indicatori_consorzio_toscana_cespiti]
(
	@ayear			int,
	@start			date ,
	@stop			date  
)
AS
BEGIN


-- beni inventario

SELECT 
	'Cespiti inventariati ' as 'Oggetto' ,
	assetacquire.nassetacquire as 'N.Carico cespite',
	convert(varchar, assetacquire.ct, 105) + ' ' + convert(varchar, assetacquire.ct, 108) as 'Creazione', --114
	assetacquire.cu as 'Utente creazione', 
	convert(varchar, assetacquire.lt, 105) + ' ' + convert(varchar, assetacquire.lt, 108) as 'Ultima modifica', 
	assetacquire.lu as 'Ultimo utente' 
	FROM asset 
	JOIN assetacquire  
ON asset.nassetacquire = assetacquire.nassetacquire
WHERE YEAR(adate) = @ayear AND   adate between @start and @stop and asset.idpiece = 1


END

GO
