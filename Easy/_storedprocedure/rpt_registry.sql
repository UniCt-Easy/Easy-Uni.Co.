
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


/* Versione 1.0.0 del 10/09/2007 ultima modifica: PIERO */

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registry]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE      PROCEDURE [rpt_registry]
(
	@registry varchar(100),
	@start  datetime, 
	@stop  datetime,
	@kind char
)
AS BEGIN
-- exec rpt_registry 'RAPITI ELEONORA', {d '2015-01-01'},{d '2015-12-31'}, 'F'
DECLARE @idreg int

IF @registry = '%' 
BEGIN
	SET  @idreg = null
END
ELSE
BEGIN
	SET  @idreg = (SELECT idreg FROM registry WHERE title like @registry and active ='S')
END

CREATE TABLE #registry(idreg int)

IF (@kind ='f')
BEGIN
	INSERT INTO #registry
	SELECT registry.idreg
	FROM registry
	join expense 
		ON registry.idreg = expense.idreg 
	JOIN expensemandate
		on expensemandate.idexp = expense.idexp
	WHERE (registry.idreg = @idreg OR @idreg is null)
		and expense.adate between @start and @stop
	
	UNION
	
	SELECT registry.idreg
	FROM registry
	join expense 
		ON registry.idreg = expense.idreg 
	JOIN expenseinvoice
		on expenseinvoice.idexp = expense.idexp
	WHERE (registry.idreg = @idreg OR @idreg is null)
		and expense.adate between @start and @stop
END
ELSE
BEGIN
	INSERT INTO #registry
	SELECT registry.idreg
	FROM registry
	join income 
		ON registry.idreg = income.idreg 
	JOIN incomeinvoice
		on incomeinvoice.idinc = income.idinc
	WHERE (registry.idreg = @idreg OR @idreg is null)
		and income.adate between @start and @stop
	
	UNION 
	
	SELECT registry.idreg
	FROM registry
	join income 
		ON registry.idreg = income.idreg 
	JOIN incomeestimate
		on incomeestimate.idinc = income.idinc
	WHERE (registry.idreg = @idreg OR @idreg is null)
		and income.adate between @start and @stop
END


SELECT DISTINCT
	R1.idreg, 
	R1.title, 
	R1.surname, 
	R1.forename, 
	R1.cf, 
	R1.p_iva, 
	R1.birthdate, 
	R1.foreigncf,
	isnull(flaghuman,'n') as flaghuman,
-- birth
	ISNULL(geo_city_birth.title, '') + ' ' + ISNULL(R1.location,'') as geo_city_birth,
	ISNULL(geo_country_birth.province, '') as geo_province_birth,
	ISNULL(geo_nation_birth.title, 'ITALIA') as geo_nation_birth
FROM registry R1
JOIN #registry R2
	on R1.idreg = R2.idreg
JOIN registryclass
	on R1.idregistryclass = registryclass.idregistryclass
-- citta di nascita
LEFT OUTER JOIN geo_city as geo_city_birth
	ON R1.idcity = geo_city_birth.idcity  
LEFT OUTER JOIN geo_country as geo_country_birth
	ON geo_city_birth.idcountry = geo_country_birth.idcountry
LEFT OUTER JOIN geo_nation as geo_nation_birth
	ON R1.idnation = geo_nation_birth.idnation  
WHERE (R1.idreg = @idreg OR @idreg is null)

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

