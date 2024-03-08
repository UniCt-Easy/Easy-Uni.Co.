
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


/****** Object:  StoredProcedure [exp_ammortamenti_con_simulazione_pluriennale]    Script Date: 09/09/2021 09:15:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 --setuser 'amministrazione'
 --setuser 'amm'
-- exec exp_ammortamenti_con_simulazione_pluriennale 2023,{ts '2023-09-20 00:00:00.000'}, '2710', null, null, null, null, null, null
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_ammortamenti_con_simulazione_pluriennale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_ammortamenti_con_simulazione_pluriennale]
GO

CREATE    PROCEDURE [exp_ammortamenti_con_simulazione_pluriennale]
(
	@ayear_rif  int,    	--- Anno di riferimento per la configurazione del piano di ammortamento
	@data_rif   datetime,   --- data di riferimento per l'inizio della simulazione
	@codeinv	varchar(50),
	@idupb      varchar(38),
	@idsor01	int,
	@idsor02	int,
	@idsor03	int,
	@idsor04	int,
	@idsor05	int
)
AS BEGIN

-------------------------------------------------------------------------------------------------
-------------- Elenco cespiti e accessori  in carico alla data di riferimento -------------------
-------------------------------------------------------------------------------------------------
DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@ayear_rif), 105)
DECLARE @lastday datetime
SET @lastday = CONVERT(datetime, '31-12-' + CONVERT(char(4),@ayear_rif), 105)

DECLARE @lastday_year_plus_1 datetime
SET @lastday_year_plus_1 = CONVERT(datetime, '31-12-' + CONVERT(char(4),@ayear_rif + 1), 105)

DECLARE @lastday_year_plus_2 datetime
SET @lastday_year_plus_2 = CONVERT(datetime, '31-12-' + CONVERT(char(4),@ayear_rif + 2), 105)

DECLARE @lastday_year_plus_3 datetime
SET @lastday_year_plus_3 = CONVERT(datetime, '31-12-' + CONVERT(char(4),@ayear_rif + 3), 105)
 
DECLARE @lastday_year_plus_4 datetime
SET @lastday_year_plus_4 = CONVERT(datetime, '31-12-' + CONVERT(char(4),@ayear_rif + 4), 105)


DECLARE @ayear_rif_plus_1 INT
SET  @ayear_rif_plus_1 =  @ayear_rif + 1 

DECLARE @ayear_rif_plus_2 INT
SET @ayear_rif_plus_2 =  @ayear_rif + 2 

DECLARE @ayear_rif_plus_3 INT
SET @ayear_rif_plus_3 =  @ayear_rif + 3 
 
DECLARE @ayear_rif_plus_4 INT
SET @ayear_rif_plus_4 =  @ayear_rif + 4  


--DECLARE @MostraClassificazioneCompleta char(1)
--SELECT @MostraClassificazioneCompleta = isnull(paramvalue,'N') 
--FROM reportadditionalparam WHERE paramname = 'MostraClassificazioneCompleta'
 
-- Tabella temporanea destinata a contenere gli ammortamenti dell'esercizio corrente
 
declare @curr_idupb varchar(38)
declare @curr_idinv int

CREATE TABLE #simula_assetamortization
(
 	idasset int,
	idpiece int,
	valore_iniziale decimal(19,2),
	amm_0 decimal(19,2),
	amm_1 decimal(19,2),
	amm_2 decimal(19,2),
	amm_3 decimal(19,2),
	amm_4 decimal(19,2),
	valore_corrente  decimal(19,2),
	valore_corrente_0 decimal(19,2),
	valore_corrente_1 decimal(19,2),
	valore_corrente_2 decimal(19,2),
	valore_corrente_3 decimal(19,2),
	valore_corrente_4 decimal(19,2),
	idinv int,
	idupb varchar(38)
) 
 
DECLARE @idasset decimal(19,2)
DECLARE @idpiece decimal(19,2)
DECLARE @valore_iniziale decimal(19,2)
DECLARE @valore_corrente  decimal(19,2)


	 DECLARE @amm_0 decimal(19,2)
	 DECLARE @amm_1 decimal(19,2)
	 DECLARE @amm_2 decimal(19,2)
	 DECLARE @amm_3 decimal(19,2)
	 DECLARE @amm_4 decimal(19,2)

	 DECLARE @valore_corrente_0 decimal(19,2)
	 DECLARE @valore_corrente_1 decimal(19,2)
	 DECLARE @valore_corrente_2 decimal(19,2)
	 DECLARE @valore_corrente_3 decimal(19,2)
	 DECLARE @valore_corrente_4 decimal(19,2)
	 

DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT A.idasset,A.idpiece, ISNULL( A.historical,A.cost), A.currentvalue , A.idinv, A.idupb
FROM   assetview A
WHERE (@codeinv is null or A.codeinv like @codeinv+'%') 
AND   (@idupb IS NULL  OR A.idupb like '%' )
AND   (A.is_loaded='S') AND (A.is_unloaded='N')
AND A.currentvalue<>0
AND (@idsor01 IS NULL OR A.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR A.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR A.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR A.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR A.idsor05 = @idsor05)
ORDER BY A.idasset, A.idpiece
FOR READ ONLY

OPEN rowcursor
FETCH NEXT FROM rowcursor INTO @idasset, @idpiece,@valore_iniziale, @valore_corrente,@curr_idinv,@curr_idupb
WHILE @@FETCH_STATUS = 0
BEGIN 
	set @amm_0=null
	set @amm_1=null
	set @amm_2=null
	set @amm_3=null
	set @amm_4=null

	set @valore_corrente_0=null
	set @valore_corrente_1=null
	set @valore_corrente_2=null
	set @valore_corrente_3=null
	set @valore_corrente_4=null

	 -- Valore Corrente del cespite alla data di riferimento
	 -- EXECUTE get_assetvalueatdate @idasset,@idpiece, @data_rif, @valore_iniziale OUTPUT, @altro_valore_corrente  OUTPUT 
	 EXEC calcola_ammortamento @idasset, @idpiece, @ayear_rif,@ayear_rif, @valore_iniziale,@valore_corrente,  @amm_0 OUTPUT
	 SET     @valore_corrente_0 = @valore_corrente + @amm_0

	 IF (ISNULL(@valore_corrente_0,0) > 0)
	 BEGIN
		EXEC calcola_ammortamento @idasset, @idpiece,@ayear_rif_plus_1, @ayear_rif,@valore_iniziale,@valore_corrente_0 ,@amm_1 OUTPUT
		SET     @valore_corrente_1 = @valore_corrente_0 + @amm_1
	 END

	 IF (ISNULL(@valore_corrente_1,0) > 0)
	 BEGIN
		EXEC calcola_ammortamento @idasset, @idpiece,@ayear_rif_plus_2,@ayear_rif,@valore_iniziale,@valore_corrente_1, @amm_2 OUTPUT
		SET  @valore_corrente_2 = @valore_corrente_1 + @amm_2
	 END

	  IF (ISNULL(@valore_corrente_2,0) > 0)
	 BEGIN
			EXEC calcola_ammortamento @idasset, @idpiece,@ayear_rif_plus_3, @ayear_rif,@valore_iniziale,@valore_corrente_2 , @amm_3 OUTPUT
		SET     @valore_corrente_3 = @valore_corrente_2 + @amm_3
	 END

	 IF (ISNULL(@valore_corrente_3,0) > 0)
	 BEGIN
		EXEC calcola_ammortamento @idasset, @idpiece,@ayear_rif_plus_4, @ayear_rif,@valore_iniziale,@valore_corrente_3 , @amm_4 OUTPUT
		SET     @valore_corrente_4 = @valore_corrente_3 + @amm_4
	 END

	 INSERT INTO #simula_assetamortization
	 (
	 	idasset,
		idpiece,
		valore_iniziale,
		amm_0,
		amm_1,
		amm_2,
		amm_3,
		amm_4,
		valore_corrente,
		valore_corrente_0,
		valore_corrente_1,
		valore_corrente_2,
		valore_corrente_3,
		valore_corrente_4,
		idinv,
		idupb
	)
	SELECT
		@idasset,
		@idpiece,
		@valore_iniziale,
		@amm_0,
		@amm_1,
		@amm_2,
		@amm_3,
		@amm_4,
		@valore_corrente,
		@valore_corrente_0,
		@valore_corrente_1,
		@valore_corrente_2,
		@valore_corrente_3,
		@valore_corrente_4,
		@curr_idinv,
		@curr_idupb
	FETCH NEXT FROM rowcursor INTO @idasset, @idpiece,@valore_iniziale, @valore_corrente,@curr_idinv,@curr_idupb
END 
DEALLOCATE rowcursor

--sp_help assetview
select S.idasset AS '#idasset',
S.idpiece AS '#idpiece', 
A.inventoryagency AS 'Ente Inventariale',
A.codeinventory AS 'Cod. inventario',
A.inventory AS 'Inventario',
A.ninventory AS 'Numero inventario',
A.nassetacquire AS 'Numero carico',
A.description AS 'Descrizione',
A.codeinv AS 'Cod. class. inv.',
A.inventorytree AS 'Class. inv',
A.codeupb AS 'Cod. UPB',
A.upb AS 'UPB',
epupbkind.title as 'Tipo UPB',
ACM.codemotive AS 'Cod Causale EP carico',
ACM.title AS 'Causale',
ACC.codeacc AS 'Codice Conto',
ACC.title AS 'Conto',
@data_rif as 'Data di riferimento',
S.valore_iniziale AS 'Valore Iniziale',
A.yearstart AS 'anno inizio esistenza',
S.valore_corrente AS 'Valore Corrente',
@ayear_rif as 'Anno corrente', 

amm_0  AS 'Amm. Anno corrente',
valore_corrente_0 AS 'Valore Corrente al termine dell''Anno corrente',
@ayear_rif_plus_1 AS 'Primo Anno',  
amm_1 AS 'Amm. Primo Anno',
valore_corrente_1 AS 'Valore Corrente al termine del Primo Anno',
@ayear_rif_plus_2 AS 'Secondo Anno',   
amm_2 AS 'Amm. Secondo  Anno',
valore_corrente_2  AS 'Valore Corrente al termine del Secondo  Anno', 
@ayear_rif_plus_3 AS 'Terzo Anno', 
amm_3 AS 'Amm. Terzo  Anno', 
valore_corrente_3 AS 'Valore Corrente al termine del Terzo  Anno', 
@ayear_rif_plus_4 AS 'Quarto Anno',  
amm_4 AS 'Amm. Quarto  Anno',
valore_corrente_4 AS 'Valore Corrente al termine del Quarto  Anno'

from #simula_assetamortization S
join assetview A on A.idasset = S.idasset and A.idpiece = S.idpiece
LEFT OUTER JOIN inventorytreelink IL1		ON IL1.idchild = A.idinv  AND IL1.nlevel = 1 
LEFT OUTER JOIN inventorytreelink IL2		ON IL2.idchild = A.idinv  AND IL2.nlevel = 2
LEFT OUTER JOIN inventorytreelink IL3		ON IL3.idchild = A.idinv  AND IL3.nlevel = 3 
LEFT OUTER JOIN inventorytreelink IL4		ON IL4.idchild = A.idinv  AND IL4.nlevel = 4 
LEFT OUTER JOIN inventorytree  I1			ON IL1.idparent = I1.idinv   
LEFT OUTER JOIN inventorytree  I2			ON IL2.idparent = I2.idinv  
LEFT OUTER JOIN inventorytree  I3			ON IL3.idparent = I3.idinv   
LEFT OUTER JOIN inventorytree  I4			ON IL4.idparent = I4.idinv   
LEFT OUTER JOIN accmotive	   ACM			ON ACM.idaccmotive =COALESCE(I4.idaccmotiveload,I3.idaccmotiveload,I2.idaccmotiveload,I1.idaccmotiveload)
LEFT OUTER JOIN accmotivedetail  ACMD		ON ACMD.idaccmotive =  ACM.idaccmotive and ACMD.ayear = @ayear_rif
LEFT OUTER JOIN account  ACC		ON ACMD.idacc = ACC.idacc
LEFT OUTER JOIN upb U		ON A.idupb = U.idupb
LEFT OUTER JOIN epupbkind		ON epupbkind.idepupbkind = U.idepupbkind
END
 
