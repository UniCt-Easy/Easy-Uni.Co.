
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_registry_used]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_registry_used]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [exp_registry_used] (		
	@esercizio int,
	@registry varchar(100),
	@cf varchar(16),
	@foreigncf varchar(40),
	@p_iva varchar(15),
	@idregistryclass int,
	@filteractive char(1)
) AS
BEGIN

DECLARE @filter varchar(1000)

IF (@registry IS NOT NULL)
BEGIN
	SET @registry = @registry + '%' 
	SET @filter  =  ' R.title like ' + '''' +  @registry + ''''
	print @filter
END
IF (@cf IS NOT NULL)
BEGIN
	SET @cf = @cf + '%' 
	IF  (@filter IS NOT NULL) SET @filter = @filter + ' AND ' + ' R.cf like ' + ''''+  @cf + ''''
	ELSE SET @filter = ' R.cf like ' + ''''+  @cf + ''''
	print @filter
	
END

IF (@foreigncf IS NOT NULL)
BEGIN
	SET @foreigncf = @foreigncf + '%' 
	IF  (@filter IS NOT NULL) SET @filter = @filter + ' AND ' + ' R.foreigncf like ' + ''''+  @foreigncf + ''''
	ELSE SET @filter = ' R.cf like ' + ''''+  @foreigncf + '''' 
	print @filter
END
IF (@p_iva IS NOT NULL)
BEGIN
	SET @p_iva = @p_iva + '%' 
	IF  (@filter IS NOT NULL) SET @filter = @filter + ' AND ' + ' R.p_iva like ' +  ''''+ @p_iva + ''''
	ELSE SET @filter = ' R.p_iva like ' + ''''+  @p_iva + ''''
	print @filter
END

IF (@idregistryclass IS NOT NULL)
BEGIN
	IF  (@filter IS NOT NULL) SET @filter = @filter + ' AND ' + ' R.idregistriclass =  ' + convert(varchar(3),@idregistryclass)
	ELSE SET @filter = ' R.idregistryclass =  ' + convert(varchar(3),@idregistryclass)
	print @filter
END

IF (@filteractive = 'S')
BEGIN
	IF  (@filter IS NOT NULL)  SET  @filter = @filter +  ' AND ((ISNULL(R.active,''S'') = ''S'')) ' 
	ELSE SET  @filter = ' ((ISNULL(R.active,''S'') = ''S'')) ' 
	print @filter
END

IF  (@filter IS NOT NULL)  SET  @filter = @filter + ' AND ' 
print @filter
	
CREATE TABLE #result (
		iddbdepartment varchar(50), 
		idreg int, 
		ECidexp int,
		ECBidexp int,
		EIidexp int,
		EITidexp int,
		EMidexp int,
		EPYidexp int,
		EPidexp int,
		EWidexp int,
		IEidinc int,
		IIidinc int
		)
		
--EXECUTE [exp_registry_used]  2010, 'uni' , null, null, NULL, null,'N'

DECLARE @iddbdepartment varchar(50)
DECLARE @sql nvarchar(4000)
-- cicla sui dipartimenti
DECLARE @cursore CURSOR
SET 	@cursore = CURSOR FOR SELECT  iddbdepartment FROM  dbdepartment
OPEN  	@cursore
FETCH NEXT FROM @cursore INTO @iddbdepartment

WHILE @@fetch_status=0 
BEGIN

		SET @sql = N'SELECT R.idreg, ' + '''' + @iddbdepartment + '''' + ', ' +
					' EC.idexp,  ' +
					' ECB.idexp,  ' +
					' EI.idexp,  ' +
					' EIT.idexp, ' + 
					' EM.idexp,  ' +
					' EPY.idexp, ' + 
					' EP.idexp,  ' +
					' EW.idexp   ' +
		' FROM ' + '['+ @iddbdepartment + ']' + '.'+ 'expense E ' + 
		' JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expenselast EL ' +
		' ON EL.idexp = E.idexp ' + 
		' JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expenseyear EY ' +
		' ON EY.idexp = EL.idexp ' +
		' AND EY.ayear = ' + convert(varchar(4),@esercizio) +
		' JOIN registry R ' +
		' ON R.idreg = E.idreg ' +
		' JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expenselink ELI ' +
				' ON  ELI.idchild = EL.idexp ' +
				' AND ELI.nlevel = ' +
					' ( SELECT expensephase ' +
					' 	FROM ' +  '['+ @iddbdepartment + ']' + '.'+ 'config WHERE ayear = ' + convert(varchar(4),@esercizio) + ') ' +
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expensecasualcontract  EC ' +
			' ON EC.idexp  = ELI.idparent ' + 
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expenseclawback ECB ' +
			' ON ECB.idexp  = ELI.idparent ' +
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expenseinvoice EI ' +
			' ON EI.idexp  = EL.idexp ' +
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expenseitineration EIT ' +
			' ON EIT.idexp  = ELI.idparent ' +
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expensemandate EM ' +
			' ON EM.idexp  = ELI.idparent ' +
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expensepayroll EPY ' +
			' ON EPY.idexp  = ELI.idparent ' +
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expenseprofservice EP ' +
			' ON EP.idexp  = ELI.idparent ' +
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'expensewageaddition EW ' +
			' ON EW.idexp  = ELI.idparent ' +
		' WHERE ' + ISNULL(@filter,'') + 
		' (EC.idexp is not null OR ' +
		' ECB.idexp is not null OR ' +
		' EI.idexp is not null OR ' +
		' EIT.idexp is not null OR ' +
		' EM.idexp is not null OR ' +
		' EPY.idexp is not null OR ' +
		' EP.idexp is not null OR ' +
		' EW.idexp is not null) ' 
		
		PRINT @sql
		INSERT INTO  #result(idreg, iddbdepartment, ECidexp,
							 ECBidexp , EIidexp, EITidexp, EMidexp ,
							 EPYidexp, EPidexp, EWidexp )
		EXEC sp_executesql @sql
		
		
		SET @sql = N'SELECT R.idreg, ' + '''' + @iddbdepartment + '''' + ', ' +
				   ' IE.idinc, ' +
				   ' II.idinc ' + 
		' FROM ' + '['+ @iddbdepartment + ']' + '.'+ 'income I ' + 
		' JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'incomelast IL ' +
			' ON IL.idinc = I.idinc ' +
		' JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'incomeyear IY ' +
			' ON IY.idinc = IL.idinc ' +
			' AND IY.ayear = ' + convert(varchar(4),@esercizio) + 
		' JOIN registry R ' +
			' ON R.idreg = I.idreg  ' +
		' JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'incomelink ILI ' +
				' ON  ILI.idchild = IL.idinc ' + 
				' AND ILI.nlevel = ' + 
					' ( SELECT incomephase ' +
     					 '  FROM ' + '['+ @iddbdepartment + ']' + '.'+ 'config WHERE ayear = ' +  
     					 convert(varchar(4),@esercizio) + ' ) '  +
		' LEFT OUTER JOIN ' + '['+ @iddbdepartment + ']' + '.'+ 'incomeestimate  IE ' +
			' ON IE.idinc  = ILI.idparent ' +
		' LEFT OUTER JOIN  ' + '['+ @iddbdepartment + ']' + '.'+ 'incomeinvoice II ' + 
			' ON II.idinc  = IL.idinc ' +
		' WHERE ' + ISNULL(@filter,'') + 
		' (II.idinc is not null OR ' + 
		' IE.idinc is not null)  ' 
		
		PRINT @sql
		INSERT INTO  #result(idreg,iddbdepartment,IEidinc, IIidinc)
		EXEC sp_executesql @sql
		
		FETCH NEXT FROM @cursore INTO @iddbdepartment
END
DEALLOCATE @cursore

SELECT  DISTINCT
D.description as 'Dipart.', 
REG.idreg as '# Anagr.',
REG.title as 'Denominazione',
REG.cf as 'CF',
REG.foreigncf as 'CF Estero',
REG.p_iva as 'P. IVA',
RC.description as 'Tipologia',
ISNULL(REG.active,'S') as 'Utilizzabile',
CASE 
	 WHEN ECidexp is not null THEN		'Contratto Occasionale' 
	 WHEN ECBidexp is not null THEN		'Recupero'
	 WHEN EIidexp is not null THEN		'Fattura Acquisto'
	 WHEN EITidexp is not null THEN		'Missione' 
	 WHEN EMidexp is not null THEN		'Contratto Passivo'
	 WHEN EPYidexp is not null THEN		'Cedolino Parasubordinati'
	 WHEN EPidexp is not null THEN		'Contratto Professionale'
	 WHEN EWidexp is not null THEN		'Contratto a Dipendente'
	 WHEN IEidinc is not null THEN		'Contratto Attivo'
	 WHEN IIidinc is not null THEN		'Fattura di Vendita'
END AS 'Area utilizzo'
FROM #result R
JOIN registry REG ON
	R.idreg = REG.idreg
JOIN dbdepartment D ON
	R.iddbdepartment = D.iddbdepartment
JOIN registryclass RC ON
	RC.idregistryclass = REG.idregistryclass
ORDER BY REG.title,D.description-- , ECidexp, ECBidexp,EIidexp,
	--EITidexp, EMidexp,EPYidexp,EPidexp,EWidexp,IEidinc,IIidinc
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

