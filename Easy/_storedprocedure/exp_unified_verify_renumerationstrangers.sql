
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_verify_remunerationstrangers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_verify_remunerationstrangers]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [exp_unified_verify_remunerationstrangers]
  
	@ayear int
   
AS
BEGIN
-- setuser 'amm'
-- exp_unified_verify_remunerationstrangers 2010

	CREATE TABLE #unifiedexpense (
		department varchar(200),
		ymov int,
		nmov int, 
		descriptionmov varchar(200),
		import decimal(19,2),
		namemaxexpphase VARCHAR(20),
		title VARCHAR(100), 
		idreg int,
		descr_service varchar(200),
		motive varchar(200) )



DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
								WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.exp_verify_remunerationstrangers'


	/*
	 'department', 
	 'ymov', 
	E.nmov AS 'nmov', 
	'descriptionmov',
	'namemaxexpphase',
	 'title', 
	 'idreg',
	descr_service,
	 'motive'

	*/

		INSERT INTO #unifiedexpense (
				department,
				ymov,
				nmov, 
				descriptionmov,
				namemaxexpphase,
				title, 
				idreg,
				descr_service,
				motive
    	)
		EXEC @dip_nomesp @ayear

	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
END

SELECT 
	department AS 'Dipartimento', 
	ymov AS 'Esercizio',
	nmov AS 'Num. Mov.', 
	descriptionmov AS 'Descr. Movimento',
	import as 'Importo',
	namemaxexpphase AS 'Tipologia',
	title AS 'Anagrafica',
	idreg AS 'Cod. Anagrafica' ,
	descr_service AS 'Descr. Prestazione',
	motive AS 'Motivazione'
FROM #unifiedexpense


END 


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
