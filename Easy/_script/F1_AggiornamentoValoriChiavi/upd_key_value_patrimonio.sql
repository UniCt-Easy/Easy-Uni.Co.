
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


IF NOT EXISTS(SELECT * FROM assetusagekind WHERE idassetusagekind IN ('07_AC','07_AI'))
BEGIN
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)
	-- Parte 1. Tabelle ASSETUSAGEKIND e ASSETUSAGE
	INSERT INTO #temp VALUES('ATTCOMM', '07_AC')
	INSERT INTO #temp VALUES('ATTISTI', '07_AI')
	
	UPDATE assetusagekind 
	SET idassetusagekind = #temp.newvalue
	FROM #temp WHERE idassetusagekind = #temp.oldvalue
	
	UPDATE assetusage
	SET idassetusagekind = #temp.newvalue
	FROM #temp WHERE idassetusagekind = #temp.oldvalue
	
	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM assetloadmotive WHERE idmot IN ('07_BUY','07_PRE','07_FRE','07_EXC'))
BEGIN
	-- Parte 4. Tabelle ASSETLOADMOTIVE, ASSETACQUIRE, ASSETLOAD
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('ACQUISTO', '07_BUY')
	INSERT INTO #temp VALUES('DONAZIONE', '07_PRE')
	INSERT INTO #temp VALUES('OMAGGIO', '07_FRE')
	INSERT INTO #temp VALUES('SCAMBIO', '07_EXC')

	UPDATE assetloadmotive
	SET idmot = #temp.newvalue
	FROM #temp WHERE idmot = #temp.oldvalue
	
	UPDATE assetacquire
	SET idmot = #temp.newvalue
	FROM #temp WHERE idmot = #temp.oldvalue

	UPDATE assetload
	SET idmot = #temp.newvalue
	FROM #temp WHERE idmot = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM assetunloadmotive WHERE idmot IN ('07_SELL', '07_CFRE', '07_CPAG', '07_STEA', '07_EXCH',
'07_REVA', '07_EASY'))
BEGIN
	-- Parte 5. Tabelle ASSETUNLOADMOTIVE, ASSETUNLOAD
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('ALIEN', '07_SELL')
	INSERT INTO #temp VALUES('CESSGRAT', '07_CFRE')
	INSERT INTO #temp VALUES('CESSONER', '07_CPAG')
	INSERT INTO #temp VALUES('FURTO', '07_STEA')
	INSERT INTO #temp VALUES('PERMUTA', '07_EXCH')
	INSERT INTO #temp VALUES('RIVALUT', '07_REVA')
	INSERT INTO #temp VALUES('SCARSEMP', '07_EASY')

	UPDATE assetunloadmotive
	SET idmot = #temp.newvalue
	FROM #temp WHERE idmot = #temp.oldvalue
	
	UPDATE assetunload
	SET idmot = #temp.newvalue
	FROM #temp WHERE idmot = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM inventoryamortization WHERE idinventoryamortization IN ('07_FISCAL_AMO', '07_FISCAL_REV'))
BEGIN
	-- Parte 7. Tabelle INVENTORYAMORTIZATION, ASSETAMORTIZATION
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('AMMFISC', '07_FISCAL_AMO')
	INSERT INTO #temp VALUES('RIVREGOL', '07_FISCAL_REV')

	UPDATE inventoryamortization
	SET idinventoryamortization = #temp.newvalue
	FROM #temp WHERE idinventoryamortization = #temp.oldvalue
	
	UPDATE assetamortization
	SET idinventoryamortization = #temp.newvalue
	FROM #temp WHERE idinventoryamortization = #temp.oldvalue


	UPDATE inventorysortingamortizationyear
	SET idinventoryamortization = #temp.newvalue
	FROM #temp WHERE idinventoryamortization = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM inventorykind WHERE idinventorykind IN ('BOOK', 'MAIN'))
BEGIN
	-- Parte 8. Tabelle INVENTORYKIND, INVENTORY
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('LIBRI', 'BOOK')
	INSERT INTO #temp VALUES('ORDINARIO', 'MAIN')

	UPDATE inventorykind
	SET idinventorykind = #temp.newvalue
	FROM #temp WHERE idinventorykind = #temp.oldvalue
	
	UPDATE inventory
	SET idinventorykind = #temp.newvalue
	FROM #temp WHERE idinventorykind = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM inventoryagency WHERE idinventoryagency IN ('DEP', 'AMM'))
BEGIN
	-- Parte 9. Tabelle INVENTORYAGENCY, ASSETCONSIGNEE, ASSETVAR, INVENTORY
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('DIP', 'DEP')
	INSERT INTO #temp VALUES('IST', 'AMM')

	UPDATE inventoryagency
	SET idinventoryagency = #temp.newvalue
	FROM #temp WHERE idinventoryagency = #temp.oldvalue
	
	UPDATE assetconsignee
	SET idinventoryagency = #temp.newvalue
	FROM #temp WHERE idinventoryagency = #temp.oldvalue

	UPDATE assetvar
	SET idinventoryagency = #temp.newvalue
	FROM #temp WHERE idinventoryagency = #temp.oldvalue

	UPDATE inventory
	SET idinventoryagency = #temp.newvalue
	FROM #temp WHERE idinventoryagency = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM inventory WHERE idinventory IN ('DEPBOOK', 'DEPMAIN', 'AMMBOOK', 'AMMMAIN'))
BEGIN
	-- Parte 10. Tabelle INVENTORY, ASSETACQUIRE, ASSETLOADKIND, ASSETUNLOADKIND, ASSETVARDETAIL
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('LIBRIDIP', 'DEPBOOK')
	INSERT INTO #temp VALUES('ORDIDIP', 'DEPMAIN')
	INSERT INTO #temp VALUES('LIBRIIST', 'AMMBOOK')
	INSERT INTO #temp VALUES('ORDIIST', 'AMMMAIN')

	UPDATE inventory
	SET idinventory = #temp.newvalue
	FROM #temp WHERE idinventory = #temp.oldvalue
	
	UPDATE assetacquire
	SET idinventory = #temp.newvalue
	FROM #temp WHERE idinventory = #temp.oldvalue

	UPDATE assetloadkind
	SET idinventory = #temp.newvalue
	FROM #temp WHERE idinventory = #temp.oldvalue

	UPDATE assetunloadkind
	SET idinventory = #temp.newvalue
	FROM #temp WHERE idinventory = #temp.oldvalue

	UPDATE assetvardetail
	SET idinventory = #temp.newvalue
	FROM #temp WHERE idinventory = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM assetloadkind WHERE idassetloadkind IN ('DEPBOOK', 'DEPMAIN', 'AMMBOOK', 'AMMMAIN'))
BEGIN
	-- Parte 11. Tabelle ASSETLOADKIND, ASSETACQUIRE, ASSETLOAD, ASSETLOADEXPENSE
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('LIBRIDIP', 'DEPBOOK')
	INSERT INTO #temp VALUES('ORDIDIP', 'DEPMAIN')
	INSERT INTO #temp VALUES('LIBRIIST', 'AMMBOOK')
	INSERT INTO #temp VALUES('ORDIIST', 'AMMMAIN')

	UPDATE assetloadkind
	SET idassetloadkind = #temp.newvalue
	FROM #temp WHERE idassetloadkind = #temp.oldvalue
	
	UPDATE assetacquire
	SET idassetloadkind = #temp.newvalue
	FROM #temp WHERE idassetloadkind = #temp.oldvalue

	UPDATE assetload
	SET idassetloadkind = #temp.newvalue
	FROM #temp WHERE idassetloadkind = #temp.oldvalue

	UPDATE assetloadexpense
	SET idassetloadkind = #temp.newvalue
	FROM #temp WHERE idassetloadkind = #temp.oldvalue

	UPDATE entry
	SET idrelated = SUBSTRING(idrelated, 1, LEN('assetload§')) +
	#temp.newvalue +
	SUBSTRING(idrelated, LEN('assetload§') +
		CHARINDEX('§', SUBSTRING(idrelated, len('assetload§')+1, LEN(idrelated))) , LEN(idrelated)
	)
	FROM #temp
	WHERE idrelated LIKE 'assetload§%'
	AND SUBSTRING(idrelated, LEN('assetload§') + 1,
	CHARINDEX('§', SUBSTRING(idrelated, LEN('assetload§') + 1, LEN(idrelated))) - 1)
	= #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM assetunloadkind WHERE idassetunloadkind IN ('DEPBOOK', 'DEPMAIN', 'AMMBOOK', 'AMMMAIN'))
BEGIN
	-- Parte 12. Tabelle ASSETUNLOADKIND, ASSET, ASSETAMORTIZATION, ASSETUNLOAD, ASSETUNLOADINCOME
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('LIBRIDIP', 'DEPBOOK')
	INSERT INTO #temp VALUES('ORDIDIP', 'DEPMAIN')
	INSERT INTO #temp VALUES('LIBRIIST', 'AMMBOOK')
	INSERT INTO #temp VALUES('ORDIIST', 'AMMMAIN')

	UPDATE assetunloadkind
	SET idassetunloadkind = #temp.newvalue
	FROM #temp WHERE idassetunloadkind = #temp.oldvalue
	
	UPDATE asset
	SET idassetunloadkind = #temp.newvalue
	FROM #temp WHERE idassetunloadkind = #temp.oldvalue

	UPDATE assetamortization
	SET idassetunloadkind = #temp.newvalue
	FROM #temp WHERE idassetunloadkind = #temp.oldvalue

	UPDATE assetunload
	SET idassetunloadkind = #temp.newvalue
	FROM #temp WHERE idassetunloadkind = #temp.oldvalue

	UPDATE assetunloadincome
	SET idassetunloadkind = #temp.newvalue
	FROM #temp WHERE idassetunloadkind = #temp.oldvalue

	UPDATE entry
	SET idrelated = SUBSTRING(idrelated, 1, LEN('assetunload§')) +
	#temp.newvalue +
	SUBSTRING(idrelated, LEN('assetunload§') +
		CHARINDEX('§', SUBSTRING(idrelated, len('assetunload§')+1, LEN(idrelated))) , LEN(idrelated)
	)
	FROM #temp
	WHERE idrelated LIKE 'assetunload§%'
	AND SUBSTRING(idrelated, LEN('assetunload§') + 1,
	CHARINDEX('§', SUBSTRING(idrelated, LEN('assetunload§') + 1, LEN(idrelated))) - 1)
	= #temp.oldvalue

	DROP TABLE #temp
END
GO
