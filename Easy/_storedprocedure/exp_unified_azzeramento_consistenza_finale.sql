
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_azzeramento_consistenza_finale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_azzeramento_consistenza_finale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--  exec [exp_unified_azzeramento_consistenza_finale] null, 'S'
--  Non totalizza ma elenca i dati dei vari dipartimenti
CREATE  PROCEDURE [exp_unified_azzeramento_consistenza_finale]
(
@idinv 	int = null,
@unified char(1)-- consolidamento dei dati 
)
AS
BEGIN

IF (@unified <> 'S')
BEGIN
        EXEC [exp_azzeramento_consistenza_finale] @idinv
        RETURN
END 

CREATE TABLE #unified (
    departmentname  varchar(150),
	totassetload  decimal(19,2),
	totassetunload  decimal(19,2),
	totamountvaraum decimal(19,2),
	totamountvardim decimal(19,2),
	codeinv  varchar(50),
	inventorytree  varchar(150),
	codeinv_1  varchar(50),
	inventorytree_1  varchar(150),
	level varchar(50)
)

 
DECLARE @iddbdepartment varchar(50)

 DECLARE crsdepartment  cursor LOCAL STATIC FOR 
SELECT iddbdepartment FROM dbdepartment 
WHERE (start is null or start <= Year(GetDate()) ) AND ( stop is null or stop >= Year(GetDate()))
AND   iddbdepartment <> 'amministrazione'
FOR READ ONLY

OPEN crsdepartment

FETCH NEXT FROM crsdepartment INTO @iddbdepartment
			 
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
        SET @dip_nomesp = '['+@iddbdepartment+']'+ '.exp_azzeramento_consistenza_finale'
PRINT @iddbdepartment
		INSERT INTO #unified (
					departmentname,
					codeinv,
					inventorytree,
					level,
					codeinv_1 ,
					inventorytree_1 ,
					totassetload,
					totassetunload,
					totamountvaraum,
					totamountvardim		
		)
		EXEC @dip_nomesp @idinv 

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
end

DEALLOCATE crsdepartment


SELECT   
	departmentname  as 'Dipartimento',
	codeinv as 'Cod. Class. Inv.',
	inventorytree as 'Class. Inv.',
	level as 'Livello',
    codeinv_1 as 'Cod. Categoria Liv.1',
	inventorytree_1  as 'Categoria Liv. 1',
	totassetload as  'Tot. Carichi',
	totassetunload  as 'Tot. Scarichi',
	totamountvaraum as 'Tot. Var. Azzeramento (Aum)',
    totamountvardim as 'Tot. Var. Azzeramento (Dim)'
FROM #unified

DROP TABLE #unified
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
