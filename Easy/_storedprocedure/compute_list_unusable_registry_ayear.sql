
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_list_unusable_registry_ayear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_list_unusable_registry_ayear]
GO

CREATE PROCEDURE compute_list_unusable_registry_ayear (
	@esercizio int
)
AS 
BEGIN

/*
Questa sp serve per disattivare le anagrafiche non utilizzate nell'anno @esercizio.
Ho preso preso spunto da: 
compute_list_unusable_registry
dove lui prende quelle NON attive, perchè è il wizard di cancellazione delle anagrafiche Non attive.
Invece con la:
compute_list_unusable_registry_ayear
prendo quelle attive, e disattivo se NON utilizzate.
Il primo IF elabora 'expense' e 'income', usando le viste, perchè le anagrafiche a cui sono imputati dei movimenti residui devono restare attive, NON vanno disattivate
*/
CREATE TABLE #reg(idreg int, usable char(1))

INSERT INTO #reg (idreg, usable)
SELECT idreg, 'N'
FROM registry 
WHERE idregistryclass = '22'
	AND isnull(active,'S') = 'S'


CREATE TABLE #app (n int)

DECLARE @tname varchar(256)
DECLARE @field varchar(30)
DECLARE @isdbo char(1)
DECLARE @ayear varchar(50) 
DECLARE @iddbdepartment varchar(50)
DECLARE @sql nvarchar(4000)

CREATE TABLE #Object (tablename varchar(100), fieldname varchar(100), dbo char(1), ayear varchar(50))

INSERT INTO #Object(tablename, fieldname, dbo)
SELECT o.name, c.name,
CASE
	WHEN o.uid = USER_ID('dbo')
	THEN 'S'
	ELSE 'N'
END
FROM sysobjects o
JOIN syscolumns c
	ON o.id = c.id
WHERE o.xtype = 'U'
	AND
	(
		(
			c.name IN ('idreg', 'iddeputy', 'idsorreg', 'registrymanager', 'idregauto', 'paymentagency', 'refundagency','regionalagency')
			AND o.name NOT IN ('registry', 'registryaddress', 'registryreference', 'registrypaymethod', 'registrylegalstatus',
			'registrytaxablestatus', 'registrycf', 'registrypiva', 'registryrole','taxpaymentpartsetup')
		)
		OR (o.name = 'registrypaymethod' AND c.name = 'iddeputy')
		OR (o.name='registry' and c.name='toredirect')
		OR (o.name='taxregionsetup' and c.name='regionalagency')
		OR (o.name='serviceregistry' and c.name='idconferring')
	)
	AND (o.uid = USER_ID() OR o.uid = USER_ID('dbo'))
ORDER by 
CASE
	WHEN o.name IN ('expense', 'income') THEN 0
	ELSE 1
END
UPDATE #Object SET ayear = 'yservreg' WHERE tablename = 'serviceregistry'
UPDATE #Object SET ayear = 'yadmpay' WHERE tablename = 'admpay_expense'
UPDATE #Object SET ayear = 'yadmpay' WHERE tablename = 'admpay_income'
UPDATE #Object SET ayear = 'yassetload' WHERE tablename = 'assetload'
UPDATE #Object SET ayear = 'yassetunload' WHERE tablename = 'assetunload'
UPDATE #Object SET ayear = 'yauthpayment' WHERE tablename = 'authpayment'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'autoexpensesorting'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'autoincomesorting'
UPDATE #Object SET ayear = 'ycon' WHERE tablename = 'casualcontract'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'config'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'csa_contractregistry'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'csa_importriep'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'csa_importver'
UPDATE #Object SET ayear = 'yddt_in' WHERE tablename = 'ddt_in'
UPDATE #Object SET ayear = 'yentry' WHERE tablename = 'entrydetail'
UPDATE #Object SET ayear = 'yepexp' WHERE tablename = 'epexp'
UPDATE #Object SET ayear = 'yestim' WHERE tablename = 'estimate'
UPDATE #Object SET ayear = 'yestim' WHERE tablename = 'estimatedetail'
UPDATE #Object SET ayear = 'ymov' WHERE tablename = 'expense'
UPDATE #Object SET ayear = 'ymov' WHERE tablename = 'income'
UPDATE #Object SET ayear = 'yinv' WHERE tablename = 'invoice'
UPDATE #Object SET ayear = 'yitineration' WHERE tablename = 'itineration'
UPDATE #Object SET ayear = 'yman' WHERE tablename = 'mandate'
UPDATE #Object SET ayear = 'yman' WHERE tablename = 'mandatedetail'
UPDATE #Object SET ayear = 'ycon' WHERE tablename = 'parasubcontract'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'parasubcontractlist'
UPDATE #Object SET ayear = 'ypay' WHERE tablename = 'payment'
UPDATE #Object SET ayear = 'yoperation' WHERE tablename = 'pettycashoperation'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'pettycashsetup'
UPDATE #Object SET ayear = 'ypro' WHERE tablename = 'proceeds'
UPDATE #Object SET ayear = 'ycon' WHERE tablename = 'profservice'
UPDATE #Object SET ayear = 'yservreg' WHERE tablename = 'serviceregistry'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'sortingexpensefilter'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'sortingincomefilter'
UPDATE #Object SET ayear = 'ystoreunload' WHERE tablename = 'storeunload'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'taxregionsetup'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'taxsetup'
UPDATE #Object SET ayear = 'ayear' WHERE tablename = 'trasmissionmanager'
UPDATE #Object SET ayear = 'ycon' WHERE tablename = 'wageaddition'

DECLARE #crs INSENSITIVE CURSOR FOR
SELECT tablename, fieldname, dbo, ayear
FROM #Object
FOR READ ONLY
OPEN #crs

FETCH NEXT FROM #crs INTO @tname, @field, @isdbo, @ayear

WHILE(@@FETCH_STATUS = 0)
BEGIN
	IF(@tname ='expense' or @tname='income')
	Begin
				SET @sql = N'UPDATE #reg SET #reg.usable = ''S''
				FROM [' + @iddbdepartment + '].' + @tname + 'view T
				WHERE T.' + @field + ' = #reg.idreg
				AND #reg.usable = ''N''
				AND  T.' + @ayear + ' = '+convert(varchar(4),@esercizio)+ ''	
	
		EXEC sp_executesql @sql
PRINT @sql

		IF (SELECT COUNT(*) FROM #reg WHERE usable = 'N') = 0 BREAK
	End

	IF (@isdbo = 'S')
	BEGIN
		if (@ayear is not null)
		Begin
			SET @sql = N'UPDATE #reg SET #reg.usable = ''S''
			FROM [dbo].' + @tname + ' T
			WHERE T.' + @field + ' = #reg.idreg
			AND #reg.usable = ''N'' 
			AND  T.' + @ayear + ' = '+convert(varchar(4),@esercizio)+ ''
		End
		Else
		Begin
			SET @sql = N'UPDATE #reg SET #reg.usable = ''S''
			FROM [dbo].' + @tname + ' T
			WHERE T.' + @field + ' = #reg.idreg
			AND #reg.usable = ''N'' '
		End

		 EXEC sp_executesql @sql
PRINT @sql

		IF (SELECT COUNT(*) FROM #reg WHERE usable = 'N') = 0 BREAK
	END
	ELSE
	BEGIN
		DECLARE #dip INSENSITIVE CURSOR FOR
		SELECT iddbdepartment FROM dbdepartment
	
		FOR READ ONLY
		
		OPEN #dip
	
		FETCH NEXT FROM #dip INTO @iddbdepartment
	
		WHILE(@@FETCH_STATUS = 0)
		BEGIN
			If(@ayear is not null)
			Begin
				SET @sql = N'UPDATE #reg SET #reg.usable = ''S''
				FROM [' + @iddbdepartment + '].' + @tname + ' T
				WHERE T.' + @field + ' = #reg.idreg
				AND #reg.usable = ''N''
				AND  T.' + @ayear + ' = '+convert(varchar(4),@esercizio)+ ''
			End
			Else
			Begin	
				SET @sql = N'UPDATE #reg SET #reg.usable = ''S''
				FROM [' + @iddbdepartment + '].' + @tname + ' T
				WHERE T.' + @field + ' = #reg.idreg
				AND #reg.usable = ''N'''
			End

		 EXEC sp_executesql @sql
PRINT @sql
	
			FETCH NEXT FROM #dip INTO @iddbdepartment
	
			IF (SELECT COUNT(*) FROM #reg WHERE usable = 'N') = 0 BREAK
		END
	
		CLOSE #dip
		DEALLOCATE #dip
	END

	IF (SELECT COUNT(*) FROM #reg WHERE usable = 'N') = 0 BREAK
	FETCH NEXT FROM #crs INTO @tname, @field, @isdbo, @ayear
END
CLOSE #crs
DEALLOCATE #crs

UPDATE registry SET active = 'N', lu='myscriptsp'
				FROM #reg
				WHERE registry.idreg = #reg.idreg 
					AND #reg.usable = 'N'

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


