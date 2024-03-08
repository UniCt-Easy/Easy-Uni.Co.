
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_show_asset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_show_asset]
--USE [Unina2_Easy]
GO
/****** Object:  StoredProcedure [amministrazione].[exp_show_asset]    Script Date: 21/03/2017 10:25:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [exp_show_asset]
(
	
	@date datetime,
	@idinventoryagency int,
	@idinventorykind int,	
	@idinventory int

)
AS BEGIN


-- Creo l'elenco degli idasset da iutilizzare
CREATE TABLE #elenco
(
idasset int,
[Data] date, 
[Ente] varchar(150), 
[Inventario] varchar(150), 
[Tipo Inventario] varchar (150),
[Anno inizio esistenza] int, 
[Num. Inventario] int, 
[Descrizione] varchar(150),
[Codice Categoria] varchar(150),
[Categoria] varchar (150),
[Codice Class. Inv.] varchar(150),
[Classificazione Inventariale] varchar(150),
[Carico Cespite] decimal(19,2), 
[Carico Accessori] decimal(19,2), 
[Totale carichi] decimal(19,2),
[Scarico Cespite] decimal(19,2),
[Scarico Accessori] decimal(19,2),
[Totale scarichi]decimal(19,2),
[Totale rivalutazioni e svalutazioni]decimal(19,2),
[Valore residuo cespite e accessori]decimal(19,2)
)

insert into #elenco(idasset,[Data],[Ente],[Inventario], [Tipo Inventario],[Anno inizio esistenza], [Num. Inventario], [Descrizione],
[Codice Categoria] ,
[Categoria],
[Codice Class. Inv.],
[Classificazione Inventariale]
) 
select 
idasset,
@date,
e.description,
v.inventory,
k.description,
year(lifestart),
ninventory,
v.description,
v.codeinv_lev1,
v.inventorytree_lev1,
v.codeinv,
v.inventorytree
from assetview v
join inventory i 
on v.idinventory = i.idinventory
join inventoryagency e
on i.idinventoryagency = e.idinventoryagency
join inventorykind k
on k.idinventorykind = i.idinventorykind
where 
(i.idinventoryagency = @idinventoryagency OR @idinventoryagency is null)
AND (i.idinventorykind = @idinventorykind OR @idinventorykind is null) 	
AND (i.idinventory = @idinventory OR @idinventory is null)
AND lifestart <=@date
AND idpiece=1 --Prendo solo il cespite principale

--select * from #elenco
--order by [Ente], [Inventario], [Tipo Inventario], [Num. Inventario] 

CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))


DECLARE @idasset INT

DECLARE idasset_cr CURSOR GLOBAL FOR select idasset from #elenco FOR UPDATE
	OPEN idasset_cr 
	FETCH NEXT FROM idasset_cr INTO @idasset 

WHILE @@FETCH_STATUS = 0
BEGIN
		-- Valuta lo sconto
		DECLARE @flagdiscount float   
		IF(
			SELECT TOP 1 (inventorykind.flag & 1)
			FROM inventorykind 
			JOIN inventory 
				ON inventory.idinventorykind = inventorykind.idinventorykind
			JOIN assetacquire
				ON assetacquire.idinventory = inventory.idinventory
			JOIN asset 
				ON asset.nassetacquire = assetacquire.nassetacquire
			WHERE idasset = @idasset
		) <> 0
		BEGIN
			SET @flagdiscount = 1
		END
		ELSE 
		BEGIN
			SET @flagdiscount = 0
		END

		IF (
			(SELECT assetload.yassetload
			FROM assetload
			JOIN assetacquire
				ON assetload.idassetload = assetacquire.idassetload
			JOIN asset 
				ON asset.nassetacquire = assetacquire.nassetacquire
			WHERE asset.idasset = @idasset AND asset.idpiece = 1)<2005)
		BEGIN
			SET  @flagdiscount = 1 
		END



		DECLARE	@departmentname varchar(150)
		SET  @departmentname = ISNULL( (SELECT paramvalue from
					 generalreportparameter where idparam='DenominazioneDipartimento' 
						and (start is null or start <= @date) 
						and (stop is null or stop >= @date)
						),'')

		
		INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
		INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')

		--DECLARE @idinventory int
		DECLARE @ninventory int
		DECLARE @tot_assetacquire decimal(19,2)
		SELECT
			@idinventory = assetacquire.idinventory,
			@ninventory = asset.ninventory,
			@tot_assetacquire =
			CONVERT(decimal(19,2),
				ROUND(
					ISNULL(assetacquire.taxable,0)
					*(1-ISNULL(assetacquire.discount*@flagdiscount,0))
					+ ROUND(ISNULL(assetacquire.tax,0),2)/assetacquire.number
					- ROUND(ISNULL(assetacquire.abatable,0),2)/assetacquire.number
				,2)
			)
		FROM assetacquire
		JOIN asset
			ON assetacquire.nassetacquire = asset.nassetacquire
		WHERE asset.idasset = @idasset
			AND assetacquire.adate <= @date
			AND idpiece = 1
			--AND assetacquire.idassetload IS NOT NULL

		DECLARE @descrinventory varchar(20)
		SET @descrinventory = ISNULL((SELECT description FROM inventory WHERE idinventory = @idinventory), 'XXX')

		INSERT INTO #situation VALUES (@descrinventory, NULL, 'H')
		INSERT INTO #situation VALUES ('Numero ' + CONVERT(char(9), @ninventory), NULL, 'H')
		INSERT INTO #situation VALUES ('', NULL, 'N')
		INSERT INTO #situation VALUES ('Carico Cespite', @tot_assetacquire, '')

		DECLARE @tot_pieceacquire decimal(19,2)
		SELECT
			@tot_pieceacquire =
			SUM(
				ROUND(
					ISNULL(assetacquire.taxable,0)
					*(1-ISNULL(assetacquire.discount*@flagdiscount,0))
					+ ROUND(ISNULL(assetacquire.tax,0),2)/assetacquire.number
					- ROUND(ISNULL(assetacquire.abatable,0),2)/assetacquire.number
				,2)
			)
		FROM assetacquire
		JOIN asset
			ON assetacquire.nassetacquire = asset.nassetacquire
		WHERE asset.idasset = @idasset
			AND assetacquire.adate <= @date
			AND idpiece > 1
			AND assetacquire.idassetload IS NOT NULL

		--PRINT @tot_pieceacquire

		INSERT INTO #situation VALUES ('Carico Accessori', @tot_pieceacquire, '')
		INSERT INTO #situation VALUES ('Totale carichi', ISNULL(@tot_assetacquire, 0) + ISNULL(@tot_pieceacquire, 0), 'S')  
		INSERT  INTO #situation VALUES('',NULL,'N')

		--------------------------------------------------------------------------------------------
		----------- Rivalutazioni positive e negative di cespiti e accessori caricati --------------
		----------- Da considerare se non ancora inclusi in un buono di scarico --------------------
		----------- in questo caso considero la data (maria) ---------------------------------------
		--------------------------------------------------------------------------------------------

		DECLARE @amortized_asset decimal(19,2)
		SELECT  @amortized_asset =
			SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			ISNULL(assetamortization.amortizationquota,0),2))
		FROM assetamortization
		JOIN asset
			ON  assetamortization.idasset = asset.idasset
			AND assetamortization.idpiece = asset.idpiece
		JOIN assetacquire
			ON assetacquire.nassetacquire = asset.nassetacquire
		JOIN inventoryamortization
			ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
		LEFT OUTER JOIN assetunload
			ON  assetamortization.idassetunload = assetunload.idassetunload
		LEFT OUTER JOIN assetload
			ON  assetamortization.idassetload = assetload.idassetload
		WHERE asset.idasset = @idasset AND asset.idpiece = 1
			AND (
 					 (assetamortization.amortizationquota >0 AND 
					 (
					  ((assetamortization.flag & 1 <> 1) AND assetamortization.adate <= @date) OR 
					  ((assetamortization.flag & 1 <> 0) AND assetload.ratificationdate <= @date))
					  )		     			

					OR
 					 (assetamortization.amortizationquota <0 AND 
					 (
					  ((assetamortization.flag & 1 <> 1) AND assetamortization.adate <= @date) OR 
					  ((assetamortization.flag & 1 <> 0) AND assetunload.adate <= @date))
					  )
					 )
		
			AND (inventoryamortization.flag & 2 <> 0)
			AND assetacquire.adate <= @date
			AND ((assetacquire.flag & 1 <> 1) OR assetacquire.idassetload IS NOT NULL)

		DECLARE @amortized_piece decimal(19,2)
		SELECT  @amortized_piece =
			SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			ISNULL(assetamortization.amortizationquota,0),2))
		FROM assetamortization
		JOIN asset
			ON  assetamortization.idasset=asset.idasset
			AND assetamortization.idpiece=asset.idpiece
		JOIN assetacquire
			ON assetacquire.nassetacquire = asset.nassetacquire
		JOIN inventoryamortization
			ON assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
		LEFT OUTER JOIN assetunload
			ON  assetamortization.idassetunload = assetunload.idassetunload
		LEFT OUTER JOIN assetload
			ON  assetamortization.idassetload = assetload.idassetload
		WHERE   asset.idasset = @idasset AND asset.idpiece > 1
			AND (

 					 (assetamortization.amortizationquota >0 AND 
					 (
					  ((assetamortization.flag & 1 <> 1) AND assetamortization.adate <= @date) OR 
					  ((assetamortization.flag & 1 <> 0) AND assetload.ratificationdate <= @date))
					  )		     

				OR
 				 (assetamortization.amortizationquota <0 AND 
				 (
				((assetamortization.flag & 1 <> 1) AND assetamortization.adate <= @date) OR 
				((assetamortization.flag & 1 <> 0) AND assetunload.adate <= @date))
 				 )
				)
			AND (inventoryamortization.flag & 2 <> 0)
			AND assetacquire.adate <= @date
			AND ((assetacquire.flag & 1 <> 1) OR assetacquire.idassetload IS NOT NULL) 


		--------------------------------------------------------------------------------------------
		----------- Carichi accessori di cespiti scaricati -----------------------------------------
		--------------------------------------------------------------------------------------------
 
		DECLARE @tot_piece_loaded decimal(19,2)

		SELECT
			@tot_piece_loaded =
			SUM(
				ROUND(
					ISNULL(caricoaccessorio.taxable,0)
					*(1-ISNULL(caricoaccessorio.discount*@flagdiscount,0))
					+ ROUND(ISNULL(caricoaccessorio.tax,0),2)/caricoaccessorio.number
					- ROUND(ISNULL(caricoaccessorio.abatable,0),2)/caricoaccessorio.number
				,2)
			)
		FROM   assetacquire as caricoaccessorio
		JOIN   asset as assetaccessorio
			ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
		JOIN asset as assetcespite
			ON assetcespite.idasset = assetaccessorio.idasset
		JOIN assetunload as assetunloadcespite
			ON assetunloadcespite.idassetunload = assetcespite.idassetunload
		WHERE assetaccessorio.idasset = @idasset and assetaccessorio.idpiece > 1
			AND assetcespite.idpiece = 1
			AND (caricoaccessorio.idassetload IS NOT NULL)

		--------------------------------------------------------------------------------------------
		----------- Rivalutazioni ufficiali di accessori caricati di cespiti scaricati -------------
		----  Da considerare se il cespite principale è incluso in un buono di scarico -------------
		--------------------------------------------------------------------------------------------

		DECLARE @tot_amort_piece_loaded decimal(19,2)

		SELECT
			@tot_amort_piece_loaded =
			SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			ISNULL(assetamortization.amortizationquota,0),2))
		FROM   assetamortization 
		JOIN inventoryamortization
			ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
		JOIN   asset as assetaccessorio
			ON  assetamortization.idasset = assetaccessorio.idasset
			AND assetamortization.idpiece = assetaccessorio.idpiece
		JOIN asset as assetcespite
			ON assetcespite.idasset = assetaccessorio.idasset
		JOIN assetacquire as caricoaccessorio
			ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
		JOIN assetunload as assetunloadcespite
			ON assetunloadcespite.idassetunload = assetcespite.idassetunload
		WHERE assetaccessorio.idasset = @idasset and assetaccessorio.idpiece > 1
			AND assetcespite.idpiece=1
			AND (inventoryamortization.flag & 2 <> 0)
			AND (
				(
				 (ISNULL(assetamortization.amortizationquota,0)>0) AND 
					 ((assetamortization.flag & 1 = 0) OR 
				  (assetamortization.idassetload IS NOT NULL))
				 )	    
			
				OR 
            
				(
				 (ISNULL(assetamortization.amortizationquota,0)<0) AND 
					 ((assetamortization.flag & 1 <> 1) OR 
				  (assetamortization.idassetunload IS NOT NULL))
				 )
				)
			AND caricoaccessorio.idassetload IS NOT NULL

		print @tot_amort_piece_loaded

		--------------------------------------------------------------------------------------------
		-------------------------- Scarichi cespiti e accessori ------------------------------------
		--------------------------------------------------------------------------------------------

		DECLARE @assetunload decimal(19,2)	
		SELECT  @assetunload =
			SUM(
				ROUND(
					ISNULL(assetacquire.taxable,0)
					*(1-ISNULL(assetacquire.discount*@flagdiscount,0))
					+ ROUND(ISNULL(assetacquire.tax,0),2)/assetacquire.number
					- ROUND(ISNULL(assetacquire.abatable,0),2)/assetacquire.number
				,2)
			)
		FROM assetacquire
		JOIN asset
			ON assetacquire.nassetacquire = asset.nassetacquire
		JOIN assetunload
			ON assetunload.idassetunload = asset.idassetunload
		WHERE asset.idasset = @idasset
			AND asset.idpiece=1
			AND assetunload.adate <= @date

		DECLARE @pieceunload decimal(19,2)
		SELECT  @pieceunload =
			SUM(
				ROUND(
					ISNULL(assetacquire.taxable,0)
					*(1-ISNULL(assetacquire.discount*@flagdiscount,0))
					+ ROUND(ISNULL(assetacquire.tax,0),2)/assetacquire.number
					- ROUND(ISNULL(assetacquire.abatable,0),2)/assetacquire.number
				,2)
			)
		FROM assetacquire
		JOIN asset
			ON assetacquire.nassetacquire = asset.nassetacquire
		JOIN assetunload
			ON assetunload.idassetunload = asset.idassetunload
		JOIN asset as cespite
			ON asset.idasset = cespite.idasset
		LEFT OUTER JOIN assetunload as scaricocespite
			ON scaricocespite.idassetunload = cespite.idassetunload
		WHERE asset.idasset = @idasset and cespite.idpiece = 1
			AND asset.idpiece>1 
			AND assetunload.adate <= @date
			AND assetunload.nassetunload <> ISNULL(scaricocespite.nassetunload,0)


		--------------------------------------------------------------------------------------------
		--------------------- Rivalutazioni positive e negative ufficiali --------------------------
		---------------------- associate a scarichi Cespiti e Accessori  ---------------------------
		--------------------------------------------------------------------------------------------

		DECLARE @amortized_asset_unloaded decimal(19,2)
		SELECT  @amortized_asset_unloaded =
			SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			ISNULL(assetamortization.amortizationquota,0),2))
		FROM assetamortization
		JOIN asset
			ON assetamortization.idasset=asset.idasset
			AND assetamortization.idpiece=asset.idpiece
		JOIN inventoryamortization
			ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
		JOIN assetunload
			ON assetunload.idassetunload = asset.idassetunload
		LEFT OUTER JOIN assetload
			ON  assetamortization.idassetload = assetload.idassetload
		WHERE   asset.idasset = @idasset AND asset.idpiece = 1
			AND (
					(
				 (ISNULL(assetamortization.amortizationquota,0)>0) AND 
					 ((assetamortization.flag & 1 <> 1) OR 
				  (assetload.ratificationdate IS NOT NULL))
				 )

				 OR 
					(
				 (ISNULL(assetamortization.amortizationquota,0)<0) AND 
					 ((assetamortization.flag & 1 <> 1) OR 
				  (assetamortization.adate IS NOT NULL))
				 )
				)
			AND (inventoryamortization.flag & 2 <> 0)
			AND assetunload.adate <= @date
	
	
		DECLARE @amortized_piece_unloaded decimal(19,2)
		SELECT  @amortized_piece_unloaded =
			SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			ISNULL(assetamortization.amortizationquota,0),2))
		FROM assetamortization
		JOIN asset 
			ON assetamortization.idasset = asset.idasset
			AND assetamortization.idpiece = asset.idpiece
		JOIN inventoryamortization
			ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
		JOIN assetunload
			ON  assetunload.idassetunload = asset.idassetunload
		JOIN asset as cespite
			ON asset.idasset = cespite.idasset
		LEFT OUTER JOIN assetunload as scaricocespite
			ON scaricocespite.idassetunload = cespite.idassetunload
		LEFT OUTER JOIN assetload A
			ON  assetamortization.idassetload = A.idassetload
		WHERE asset.idasset = @idasset AND asset.idpiece > 1 and cespite.idpiece = 1
			AND (
					 (
				 (ISNULL(assetamortization.amortizationquota,0) > 0) AND 
					 ((assetamortization.flag & 1 <> 1) OR 
				  (A.ratificationdate IS NOT NULL))
				 )

				OR 

					 (
				 (ISNULL(assetamortization.amortizationquota,0) < 0) AND 
					 ((assetamortization.flag & 1 <> 1) OR 
				  (assetamortization.idassetunload IS NOT NULL))
				 )
				)
			AND (inventoryamortization.flag & 2 <> 0)
			AND assetunload.adate <= @date
			AND assetunload.nassetunload <> ISNULL(scaricocespite.nassetunload,0)

		-------------------------------------------------------------------------------------
		---Scarichi Accessori di beni scaricati ---------------------------------------------
		-------------------------------------------------------------------------------------
		DECLARE @pieceunload_asset_unloaded decimal(19,2)
		SELECT  @pieceunload_asset_unloaded =
			SUM(
				ROUND(
					ISNULL(assetacquire.taxable,0)
					*(1-ISNULL(assetacquire.discount*@flagdiscount,0))
					+ ROUND(ISNULL(assetacquire.tax,0),2)/assetacquire.number
					- ROUND(ISNULL(assetacquire.abatable,0),2)/assetacquire.number
				,2)
			)
		FROM assetacquire
		JOIN asset
			ON assetacquire.nassetacquire = asset.nassetacquire
		JOIN asset as cespite
			ON  cespite.idasset = asset.idasset
			AND cespite.idpiece = 1
		JOIN assetunload 
			ON  assetunload.idassetunload = cespite.idassetunload
		WHERE asset.idasset = @idasset
			AND asset.idpiece > 1 
			AND (asset.idassetunload IS NOT NULL OR (asset.flag & 1 <> 1))
			AND assetacquire.idassetload IS NOT NULL
	
		-------------------------------------------------------------------------------------
		--RIVALUTAZIONI POSITIVE E NEGATIVE di Accessori SCARICATI di beni scaricati --------
		-------------------------------------------------------------------------------------
	
		DECLARE @amortization_pieceunload_asset_unloaded decimal(19,2)
		SELECT  @amortization_pieceunload_asset_unloaded =
			SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			ISNULL(assetamortization.amortizationquota,0),2))
		FROM assetamortization
		JOIN asset 
			ON assetamortization.idasset=asset.idasset
			AND assetamortization.idpiece=asset.idpiece
		JOIN assetacquire 
				ON assetacquire.nassetacquire = asset.nassetacquire
		JOIN asset as cespite
			ON cespite.idasset=asset.idasset
			AND cespite.idpiece=1
		JOIN inventoryamortization
			ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
		JOIN assetunload
			ON  assetunload.idassetunload = cespite.idassetunload
		LEFT OUTER JOIN assetload A
			ON  assetamortization.idassetload = A.idassetload
		WHERE asset.idasset = @idasset AND asset.idpiece>1
			AND (
					 (
				 (ISNULL(assetamortization.amortizationquota,0)>0) AND 
					 ((assetamortization.flag & 1 <> 1) OR 
				  (A.ratificationdate IS NOT NULL))
				 )

			OR 
					 (
				 (ISNULL(assetamortization.amortizationquota,0)<0) AND 
					 ((assetamortization.flag & 1 <> 1) OR 
				  (assetamortization.idassetunload IS NOT NULL))
				 )
				)
			AND (inventoryamortization.flag & 2 <> 0)
			AND (asset.idassetunload IS NOT NULL OR (asset.flag & 1 <> 1))
			AND assetacquire.idassetload IS NOT NULL
	
		DECLARE @tot_pieceunload decimal(19,2)
		SELECT  @tot_pieceunload = ISNULL(@pieceunload,0) + ISNULL(@amortized_piece_unloaded,0)

		DECLARE @tot_assetvariation decimal(19,2)

		IF      (ISNULL(@assetunload,0)) >0 
		BEGIN
		SELECT @tot_assetvariation =
			ISNULL(@tot_piece_loaded,0) + 
			ISNULL(@amortized_asset,0)  +
			ISNULL(@tot_amort_piece_loaded,0) -
			ISNULL(@pieceunload,0)  -
			ISNULL(@amortized_piece_unloaded,0)
		END
		print 'inizio'
		--print @assetunload
		print ISNULL(@tot_piece_loaded,0) 
		print ISNULL(@amortized_asset,0)  
		print ISNULL(@tot_amort_piece_loaded,0)
		print ISNULL(@pieceunload_asset_unloaded,0)
		print ISNULL(@amortization_pieceunload_asset_unloaded,0)
		print 'fine'
		print   @assetunload
		print   @tot_assetvariation
		DECLARE @tot_assetunload decimal(19,2)

		IF      (ISNULL(@assetunload,0)) >0 
		BEGIN
			SELECT  @tot_assetunload = ISNULL(@tot_assetacquire,0) + ISNULL(@tot_assetvariation,0)
		END	
		ELSE    
		BEGIN
			SELECT  @tot_assetunload = 0
		END		   

		INSERT  INTO #situation VALUES ('Scarico Cespite', @tot_assetunload,'')
		INSERT  INTO #situation VALUES ('Scarico Accessori', @tot_pieceunload, '')
		INSERT  INTO #situation VALUES ('Totale scarichi', @tot_pieceunload + @tot_assetunload , 'S')

		declare @flagrival char(1)
		set @flagrival='N'



		INSERT  INTO #situation VALUES('',NULL,'H')
		--INSERT INTO #situation VALUES('R I V A L U T A Z I O N I  E  S V A L U T A Z I O N I',NULL,'N')

		DECLARE @idinventoryamortization varchar(20)
		DECLARE @descr_inventoryamortization varchar(50)
		DECLARE @tot_assetamortization decimal(19,2)
		DECLARE @tot_pieceamortization decimal(19,2)
		DECLARE @tot_assetamortization_unloaded decimal(19,2)
		DECLARE @tot_pieceamortization_unloaded decimal(19,2)
		DECLARE @tot_all_amortization decimal(19,2)
		set @tot_all_amortization=0


		DECLARE amortization_crs INSENSITIVE CURSOR FOR	
		SELECT idinventoryamortization, description FROM inventoryamortization
						where (inventoryamortization.flag & 2 <> 0)
		FOR READ ONLY
		OPEN amortization_crs
		FETCH NEXT FROM amortization_crs INTO @idinventoryamortization, @descr_inventoryamortization
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			---- Rivalutazioni e svalutazioni del cespite alla data
			SELECT
				@tot_assetamortization = SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
							 ISNULL(assetamortization.amortizationquota,0),2))
			FROM assetamortization
			JOIN asset
				ON  assetamortization.idasset=asset.idasset
				AND assetamortization.idpiece=asset.idpiece
			JOIN assetacquire
				ON assetacquire.nassetacquire = asset.nassetacquire
			LEFT OUTER JOIN assetunload
				ON  assetamortization.idassetunload = assetunload.idassetunload
			LEFT OUTER JOIN assetload
				ON  assetamortization.idassetload = assetload.idassetload
			WHERE assetamortization.idasset = @idasset
				AND (
 					 (assetamortization.amortizationquota >0 AND 
					 (
					  ((assetamortization.flag & 1 <> 1) AND assetamortization.adate <= @date) OR 
					  ((assetamortization.flag & 1 <> 0) AND assetload.ratificationdate <= @date))
					  )

					OR
 					 (assetamortization.amortizationquota <0 AND 
					 (
					  ((assetamortization.flag & 1 <> 1) AND assetamortization.adate <= @date) OR 
					  ((assetamortization.flag & 1 <> 0) AND assetunload.adate <= @date))
					  )
					)
				AND assetamortization.idpiece = 1   
				AND assetamortization.idinventoryamortization = @idinventoryamortization
				AND assetacquire.adate <= @date
				AND ((assetacquire.flag & 1 <> 1) OR assetacquire.idassetload IS NOT NULL) 


	
			---- Rivalutazioni e svalutazioni degli accessori alla data

			---- Questa SELECT è stata scritta x offrire maggiore chiarezza all'utente
			SELECT
				@tot_pieceamortization = SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
							 ISNULL(assetamortization.amortizationquota,0),2))
			FROM assetamortization
			JOIN asset
				ON  assetamortization.idasset=asset.idasset
				AND assetamortization.idpiece=asset.idpiece
			JOIN assetacquire
				ON assetacquire.nassetacquire = asset.nassetacquire
			LEFT OUTER JOIN assetunload
				ON  assetamortization.idassetunload = assetunload.idassetunload
			LEFT OUTER JOIN assetload
				ON  assetamortization.idassetload = assetload.idassetload
			WHERE assetamortization.idasset = @idasset AND assetamortization.idpiece > 1
				AND (
					(assetamortization.amortizationquota >0 AND 
					 (
					  ((assetamortization.flag & 1 <> 1) AND assetamortization.adate <= @date) OR 
					  ((assetamortization.flag & 1 <> 0) AND assetload.ratificationdate <= @date))
					  )

				OR
 		     
					(assetamortization.amortizationquota <0 AND 
					 (
					  ((assetamortization.flag & 1 <> 1) AND assetamortization.adate <= @date) OR 
					  ((assetamortization.flag & 1 <> 0) AND assetunload.adate <= @date))
					  )
					 )
				AND assetamortization.idinventoryamortization = @idinventoryamortization
				AND assetacquire.adate <= @date
				AND ((assetacquire.flag & 1 <> 1) OR assetacquire.idassetload IS NOT NULL) 

			set @tot_assetamortization = ISNULL(@tot_assetamortization, 0)
			set @tot_pieceamortization= ISNULL(@tot_pieceamortization, 0)
			if (@tot_assetamortization<> 0) 
				INSERT INTO #situation VALUES (@descr_inventoryamortization + 'Cespite', @tot_assetamortization, '')
			if (@tot_pieceamortization <> 0)  
				INSERT INTO #situation VALUES (@descr_inventoryamortization + ' Accessori', @tot_pieceamortization, '')

			if (@tot_pieceamortization<> 0 or @tot_assetamortization <> 0 )  
				set @flagrival='S'
	
			set @tot_all_amortization= @tot_all_amortization + @tot_assetamortization + @tot_pieceamortization
	
		print ISNULL(@tot_pieceacquire,0)
		FETCH NEXT FROM amortization_crs INTO @idinventoryamortization, @descr_inventoryamortization
		END

		-- Valore Storico del Bene
		declare @historical decimal(19,2)
		select @historical = historicalvalue from assetacquire AC 
					join asset A on A.nassetacquire=AC.nassetacquire
					where A.idasset=@idasset and A.idpiece=1
		-- Ammortamenti Pregressi = Valore iniziale storico - Valore caricato
		declare @previous_assetamortization decimal(19,2)
		if( isnull(@historical,0)>0)
		Begin
			SET @previous_assetamortization = @historical - isnull(@tot_assetacquire,0)
			if (@previous_assetamortization <> 0) 
			Begin
				INSERT INTO #situation VALUES ('Ammortamenti Pregressi Cespite', @previous_assetamortization, '')
				SET @flagrival = 'S'
				SET @tot_all_amortization = @tot_all_amortization + @previous_assetamortization
			End
		End

		DEALLOCATE amortization_crs
		if (@flagrival='N')
			INSERT INTO #situation VALUES('Nessuna rivalutazione o svalutazione',NULL,'N')	
		ELSE 
			INSERT INTO #situation VALUES ('Totale rivalutazioni e svalutazioni', @tot_all_amortization, 'S')  


		INSERT INTO #situation VALUES('',NULL,'H')

		DECLARE @currvalue1 decimal(19,2)
		IF ISNULL(@assetunload,0)>0
			BEGIN
			SET @currvalue1 = 
				ISNULL(@tot_assetacquire, 0) 
				+ ISNULL(@tot_pieceacquire, 0)  
				+ ISNULL(@amortized_asset, 0)
				+ ISNULL(@amortized_piece,0)  
				- ISNULL(@assetunload, 0) 
				- ISNULL(@pieceunload_asset_unloaded, 0) 
				- ISNULL(@amortized_asset_unloaded,0)  
				- ISNULL(@amortization_pieceunload_asset_unloaded,0)  
			END
			ELSE
			BEGIN
				SET @currvalue1 = 
				ISNULL(@tot_assetacquire, 0) 
				+ ISNULL(@tot_pieceacquire, 0)  
				+ ISNULL(@amortized_asset, 0)
				+ ISNULL(@amortized_piece,0)  
				- ISNULL(@pieceunload, 0) 
				- ISNULL(@amortized_piece_unloaded,0)  
			END

		print ISNULL(@tot_assetacquire, 0) 
		print ISNULL(@tot_pieceacquire, 0)  
		print ISNULL(@amortized_asset, 0)
		print ISNULL(@amortized_piece,0)  
		print ISNULL(@assetunload, 0) 
		print ISNULL(@pieceunload_asset_unloaded, 0) 
		print ISNULL(@amortized_asset_unloaded,0)  
		print ISNULL(@amortization_pieceunload_asset_unloaded,0)  
		INSERT INTO #situation VALUES ('Valore residuo cespite e accessori', 
			@currvalue1, 'S')	

			
		
		update #elenco
		set
		[Carico Cespite]			= @tot_assetacquire,
		[Carico Accessori]			= @tot_pieceacquire, 
		[Totale carichi]			= ISNULL(@tot_assetacquire, 0) + ISNULL(@tot_pieceacquire, 0),
		[Scarico Cespite]			= @tot_assetunload,
		[Scarico Accessori]			= @tot_pieceunload,
		[Totale scarichi]			= @tot_pieceunload + @tot_assetunload,
		[Totale rivalutazioni e svalutazioni] = @tot_all_amortization,
		[Valore residuo cespite e accessori] = @currvalue1
		where idasset= @idasset


	  --SELECT * FROM #elenco where idasset= @idasset 
   --    order by [Ente], [Inventario], [Tipo Inventario], [Num. Inventario] 

		FETCH NEXT FROM idasset_cr INTO @idasset 

		
END

SELECT
[Data] , 
[Ente] , 
[Inventario], 
[Tipo Inventario], 
[Anno inizio esistenza],
[Num. Inventario], 
[Descrizione],
[Codice Categoria] ,
[Categoria],
[Codice Class. Inv.],
[Classificazione Inventariale],
[Carico Cespite], 
[Carico Accessori], 
[Totale carichi],
[Scarico Cespite],
[Scarico Accessori],
[Totale scarichi],
[Totale rivalutazioni e svalutazioni],
[Valore residuo cespite e accessori]
FROM #elenco
order by [Ente], [Inventario], [Tipo Inventario], [Anno inizio esistenza], [Num. Inventario] 
END
