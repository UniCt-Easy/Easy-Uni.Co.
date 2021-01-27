
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unifiedf24ep_ritenute]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unifiedf24ep_ritenute]
GO


CREATE  PROCEDURE [exp_unifiedf24ep_ritenute]
	  @ayear int, 
	  @idunifiedf24ep int,
	  @tax int,
	  @departmentname varchar(50),
	  @showdepartment char(1)
AS
BEGIN
CREATE TABLE #unifiedtax
(
	department 	varchar(150),
	idunifiedtax 	int,
	fiscaltaxcode 	varchar(20),
	taxref  	varchar(20),
	description  	varchar(50),
	employtax 	decimal(19,2),
	admintax  	decimal(19,2),
	total		decimal(19,2),
	payed_city	varchar(65),
	payed_country	varchar(20),
	payed_fiscaltaxregion varchar(50)
)
	
	INSERT INTO #unifiedtax
	(
		department,
		idunifiedtax,
		fiscaltaxcode,
		taxref,
		description,
		employtax,
		admintax,
		total,
		payed_city,
		payed_country,
		payed_fiscaltaxregion
	)
	SELECT 
		department,
		idunifiedtax,
		fiscaltaxcode,
		taxref,
		description,
		employtax,
		admintax,
		ISNULL(employtax,0) + ISNULL(admintax,0),
		payed_city,
		payed_country,
		payed_fiscaltaxregion
	FROM  unifiedtaxview 
	WHERE ayear = @ayear 
	AND   idunifiedf24ep = @idunifiedf24ep
	AND   (@tax is null OR unifiedtaxview.taxcode = @tax )
        AND  (unifiedtaxview.department = @departmentname  OR @departmentname is null) 

	INSERT INTO #unifiedtax
	(
		department,
		idunifiedtax,
		fiscaltaxcode,
		taxref,
		description,
		employtax,
		admintax,
		total,
		payed_city,
		payed_country,
		payed_fiscaltaxregion	
	)
	SELECT 
		department,
		idunifiedtaxcorrige,
		fiscaltaxcode,
		taxref,
		description,
		employamount,
		adminamount,
		ISNULL(employamount,0) + ISNULL(adminamount,0),
		payed_city,
		payed_country,
		payed_fiscaltaxregion
	FROM  unifiedtaxcorrigeview 
	WHERE ayear = @ayear 
	AND   idunifiedf24ep = @idunifiedf24ep
	AND   (@tax is null OR unifiedtaxcorrigeview.taxcode = @tax )
        AND  (unifiedtaxcorrigeview.department = @departmentname  OR @departmentname is null) 

	
	IF (ISNULL(@showdepartment,'N') = 'S')
	BEGIN
		SELECT 
			department AS 'Dipartimento',
			fiscaltaxcode AS 'Codice Tributo',
			taxref AS 'Codice ritenuta',
			description AS 'Ritenuta',
			payed_city AS 'Comune',
			payed_country AS 'Prov.',
			payed_fiscaltaxregion as 'Regione Fiscale',
			ISNULL(SUM(employtax),0) AS 'C/Percip.',
			ISNULL(SUM(admintax),0) AS 'C/Ammin.',
			ISNULL(SUM(employtax),0) + ISNULL(SUM(admintax),0) AS 'Totale'
		FROM  #unifiedtax
		GROUP BY department, taxref,fiscaltaxcode, description, 
			payed_city, payed_fiscaltaxregion, payed_country
		ORDER BY department,fiscaltaxcode,taxref
	END
	ELSE
	BEGIN
		SELECT 
			fiscaltaxcode AS 'Codice Tributo',
			taxref AS 'Codice ritenuta',
			description AS 'Ritenuta',
			payed_city AS 'Comune',
			payed_country AS 'Prov.',
			payed_fiscaltaxregion as 'Regione Fiscale',
			ISNULL(SUM(employtax),0) AS 'C/Percip.',
			ISNULL(SUM(admintax),0) AS 'C/Ammin.',
			ISNULL(SUM(employtax),0) + ISNULL(SUM(admintax),0) AS 'Totale'
		FROM  #unifiedtax
		GROUP BY taxref,fiscaltaxcode, description, 
			 payed_city, payed_fiscaltaxregion, payed_country
		ORDER BY fiscaltaxcode,taxref
	END
END
