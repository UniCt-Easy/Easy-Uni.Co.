
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[calc_corr_sitpatrim]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [calc_corr_sitpatrim]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [calc_corr_sitpatrim]
	@ayear int 
AS BEGIN

DECLARE @datevar datetime
SET 	@datevar = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
	
-- setuser 'amm'
-- calc_corr_sitpatrim 2011
CREATE TABLE #tot_currentvalue
(
	 idinventoryagency int,
	 inventoryagency varchar(150),
	 idinventory int,
	 inventory varchar(150),
	 idinv int,
	 totcurrentvalue decimal(19,2)
)

INSERT INTO #tot_currentvalue
(
	idinventoryagency,
	inventoryagency,
	idinventory,
	inventory,
	idinv,
	totcurrentvalue
)
select  inventoryagency.idinventoryagency, inventoryagency.description  , 
assetview.idinventory, inventory, idinv, sum(assetview_current.currentvalue)  
from  assetview_current  
join assetview on assetview_current.idasset = assetview.idasset and assetview_current.idpiece = assetview.idpiece 
join inventory on inventory.idinventory = assetview.idinventory
join inventoryagency on inventoryagency.idinventoryagency = inventory.idinventoryagency
where assetview_current.is_loaded='S' AND assetview_current.is_unloaded  = 'N' AND assetview_current.currentvalue>0
		 and  ( substring(assetview.codeinv,1,1)  in ('1','4','7')  )
group by assetview.idinventory,assetview.inventory, idinv , inventoryagency.idinventoryagency, inventoryagency.description
order by  assetview.idinventory,assetview.inventory, idinv 

CREATE TABLE #tot_assetvarvalue
(
	 idinventoryagency int,
	 inventoryagency varchar(150),
	 idinventory int,
	 inventory varchar(150),
	 idinv int,
	 totassetvarvalue decimal(19,2)
)

INSERT INTO #tot_assetvarvalue
(
	idinventoryagency,
	inventoryagency,
	idinventory,
	inventory,
	idinv,
	totassetvarvalue
)
select  assetvardetailview.idinventoryagency, assetvardetailview.inventoryagency , 
assetvardetailview.idinventory, assetvardetailview.inventory, assetvardetailview.idinv, sum(assetvardetailview.amount)
from  assetvardetailview
where yvar = @ayear + 1   AND variationkind = 'I' -- situazione patrimoniale iniziale
		and  ( substring(assetvardetailview.codeinv,1,1)  in ('1','4','7')  )
group by assetvardetailview.idinventoryagency, assetvardetailview.inventoryagency ,  
assetvardetailview.idinventory, assetvardetailview.inventory, assetvardetailview.idinv
order by  assetvardetailview.idinventoryagency, assetvardetailview.inventoryagency, 
assetvardetailview.idinventory, assetvardetailview.inventory, assetvardetailview.idinv


CREATE TABLE #corr_consistenza
(
	 idinventoryagency int,
	 inventoryagency varchar(150),
	 idinventory int,
	 inventory varchar(150),
	 idinv int,
	 diff decimal(19,2)
)

INSERT INTO #corr_consistenza
(
	idinventoryagency,
	inventoryagency,
	idinventory,
	inventory,
	idinv,
	diff
)
SELECT 
	idinventoryagency,
	inventoryagency,
	idinventory,
	inventory,
	idinv,
	totcurrentvalue
FROM  #tot_currentvalue

INSERT INTO #corr_consistenza
(
	idinventoryagency,
	inventoryagency,
	idinventory,
	inventory,
	idinv,
	diff
)
SELECT 
	idinventoryagency,
	inventoryagency,
	idinventory,
	inventory,
	idinv,
	0
FROM 
	#tot_assetvarvalue
WHERE NOT EXISTS 
(SELECT * FROM #corr_consistenza C1
 WHERE isnull(C1.idinventoryagency,0) = isnull(#tot_assetvarvalue.idinventoryagency,0)
 AND   isnull(C1.idinventory,0) = isnull(#tot_assetvarvalue.idinventory,0)
 AND   C1.idinv = #tot_assetvarvalue.idinv)
 
 UPDATE #corr_consistenza 
 SET diff = ISNULL(diff,0) - ISNULL(totassetvarvalue,0)
 FROM #tot_assetvarvalue   
 WHERE isnull(#corr_consistenza.idinventoryagency,0) = isnull(#tot_assetvarvalue.idinventoryagency,0)
 AND   isnull(#corr_consistenza.idinventory,0) = isnull(#tot_assetvarvalue.idinventory,0)
 AND   #corr_consistenza.idinv = #tot_assetvarvalue.idinv
	


CREATE TABLE #consistenza_gruppo
(
	 idinventoryagency int,
	 idinventory int,
	 idinv int,
	 diff decimal(19,2)
)
insert into #consistenza_gruppo (idinventoryagency,idinventory,idinv,diff)
 select C.idinventoryagency, C.idinventory,  CAT.idparent	, sum(C.diff)
	from #corr_consistenza C 
			 join inventorytreelink CAT on CAT.idchild=C.idinv AND CAT.nlevel=1
	group by 		C.idinventoryagency, C.idinventory, CAT.idparent	  
			 

SELECT * FROM #tot_currentvalue	
SELECT * FROM #tot_assetvarvalue	
SELECT * FROM #consistenza_gruppo	


DECLARE @idinventoryagency INT
DECLARE @numvariazione int
DECLARE @idassetvar int

DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT idinventoryagency
FROM inventoryagency
FOR READ ONLY

OPEN rowcursor
FETCH NEXT FROM rowcursor
INTO @idinventoryagency

WHILE @@FETCH_STATUS = 0
BEGIN 
	if (select count(*) from #consistenza_gruppo where idinventoryagency = @idinventoryagency)>0
	BEGIN
	
		SET @numvariazione =
		ISNULL(
			(SELECT MAX(nvar)
			FROM assetvar
			WHERE yvar = @ayear)
		, 0) + 1

		-- l'ID deve essere il MAX indipendentemente dall'esercizio
		SET @idassetvar = 
		ISNULL(
			(SELECT MAX(idassetvar)
			FROM assetvar)
		,0) + 1
	
		print @numvariazione
		INSERT assetvar (idassetvar, yvar, nvar, idinventoryagency, description, flag, adate, cu, ct, lu, lt)
		VALUES (@idassetvar, @ayear, @numvariazione, @idinventoryagency,
		'Variazione correttiva', 1,@datevar , 'ASSISTENZA',
		GETDATE(), 'ASSISTENZA', GETDATE())
		
		INSERT assetvardetail
		(
			idassetvar,
			idassetvardetail,
			idinv,
			amount,
			description,
			idinventory,
			idmot,
			cu,
			ct,
			lu,
			lt
		)
		SELECT
			@idassetvar, 
			isnull((select count(*) from #consistenza_gruppo b
			where b.idinventoryagency = @idinventoryagency
			AND
			(isnull(b.idinventory,0)  < isnull(#consistenza_gruppo.idinventory,0))
			OR  
			( isnull(b.idinventory,0) = isnull(#consistenza_gruppo.idinventory,0) 
				and (isnull(b.idinv,0) < isnull(#consistenza_gruppo.idinv,0))) 
			),0) 
			
			+ 1,
			idinv,
			diff,
			'Correzione Consistenza',
			idinventory,
			null,
			'ASSISTENZA',
			GetDate(),
			'''ASSISTENZA''',
			GetDate()
		FROM #consistenza_gruppo 
		WHERE idinventoryagency = @idinventoryagency AND diff <>0
		END
	
FETCH NEXT FROM rowcursor
INTO @idinventoryagency
END 
DEALLOCATE rowcursor

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
