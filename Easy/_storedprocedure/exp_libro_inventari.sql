
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_libro_inventari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_libro_inventari]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 --setuser 'amm'
-- exec exp_libro_inventari '31-12-2016', 3
 
 
CREATE    PROCEDURE [exp_libro_inventari]
(
	@data_rif     datetime,   --- data di riferimento per l'inizio della simulazione
	@levelinv	 int
)
AS BEGIN

-------------------------------------------------------------------------------------------------
-------------- Elenco cespiti e accessori  in carico alla data di riferimento -------------------
-------------------------------------------------------------------------------------------------
declare @ayear_rif int
set @ayear_rif=year(@data_rif)

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@ayear_rif), 105)
DECLARE @lastday datetime
SET @lastday = CONVERT(datetime, '31-12-' + CONVERT(char(4),@ayear_rif), 105)
DECLARE @codelen1 int
DECLARE @codelen2 int
DECLARE @codelen3 int
DECLARE @codelen4 int

SELECT @codelen1 = codelen FROM inventorysortinglevel WHERE nlevel = 1
SELECT @codelen2 = codelen FROM inventorysortinglevel WHERE nlevel = 2
SELECT @codelen3 = codelen FROM inventorysortinglevel WHERE nlevel = 3
SELECT @codelen4 = codelen FROM inventorysortinglevel WHERE nlevel = 4

--DECLARE @MostraClassificazioneCompleta char(1)
--SELECT @MostraClassificazioneCompleta = isnull(paramvalue,'N') 
--FROM reportadditionalparam WHERE paramname = 'MostraClassificazioneCompleta'
 
-- Tabella temporanea destinata a contenere gli ammortamenti dell'esercizio corrente
 
declare @curr_idupb varchar(38)
declare @curr_idinv int

CREATE TABLE #simula_assetamortization
(
 	idinv int,	
	paridinv int,
	nlevel int,
	codeinv varchar(50), 
	description varchar(200),
	valore_iniziale decimal(19,2),
	amm decimal(19,2),
	sval decimal(19,2),
	rival decimal(19,2),
	subtr decimal(19,2)
) 
 
insert into #simula_assetamortization 
SELECT I0.idinv,   I0.paridinv,I0.nlevel, I0.codeinv, I0.description,
		isnull((select sum(A.cost) 
			from  assetview A  
			join inventorytreelink IL on IL.idchild=A.idinv  and IL.idparent=I0.idinv			
			where	(A.unloaddate is null or A.unloaddate > @data_rif) and A.ratificationdate <= @data_rif
			AND  (A.inventorykindvisible = 'S') --- non considero beni a noleggio
		),0),

		--somma AMMORTAMENTI applicati (IA.flag &  8) <>0   ALLA DATA		
		isnull((SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(AM.assetvalue, 0.0) *ISNULL(AM.amortizationquota,0.0),2)))
				FROM assetview A  
				join inventorytreelink IL on IL.idchild=A.idinv  and IL.idparent=I0.idinv			
				JOIN assetamortization    AM on AM.idasset=A.idasset and AM.idpiece=A.idpiece
				JOIN  inventoryamortization	 IA ON    AM.idinventoryamortization =     IA.idinventoryamortization				
				LEFT OUTER JOIN assetunload AA	ON  AM.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL	ON  AM.idassetload = AL.idassetload
				WHERE (A.unloaddate is null or A.unloaddate > @data_rif) and 
						--A.ratificationdate <= @data_rif	AND   task 12599
					(A.inventorykindvisible = 'S') --- non considero beni a noleggio
				AND (
				( (ISNULL(AM.amortizationquota,0)>0) AND
					( ((AM.flag & 1 = 0) 	AND AM.adate <= @data_rif) 
					  OR 
					  ((AM.flag & 1 <> 0)    AND AL.adate <= @data_rif)
					)
			 	)
				OR 			            
				( (ISNULL(AM.amortizationquota,0)<0) AND
					( ((AM.flag & 1 = 0) 	AND AM.adate <= @data_rif) 
					  OR 
					  ((AM.flag & 1 <> 0)    AND AA.adate <= @data_rif)
					)
			 	)
				)
				AND  (IA.flag &  8) <>0
				AND (IA.flag & 2 <> 0)
		),0),	
			
		--somma SVALUTAZIONI applicate (IA.flag &  8) =0   ALLA DATA
		isnull(
		(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(AM.assetvalue, 0.0) *ISNULL(AM.amortizationquota,0.0),2)))
				FROM assetview A  
				join inventorytreelink IL on IL.idchild=A.idinv  and IL.idparent=I0.idinv			
				JOIN assetamortization    AM on AM.idasset=A.idasset and AM.idpiece=A.idpiece
				JOIN  inventoryamortization	 IA ON    AM.idinventoryamortization =     IA.idinventoryamortization				
				LEFT OUTER JOIN assetunload AA	ON  AM.idassetunload = AA.idassetunload
				WHERE (A.unloaddate is null or A.unloaddate > @data_rif) and 
						--A.ratificationdate <= @data_rif AND task 12599
				   (A.inventorykindvisible = 'S') --- non considero beni a noleggio
				AND ( ((AM.flag & 1 = 0) 	AND AM.adate <= @data_rif) 
					  OR 
					  ((AM.flag & 1 <> 0)    AND AA.adate <= @data_rif)
					)			 					
				AND (ISNULL(AM.amortizationquota,0)<0)
				AND (IA.flag & 2 <> 0)
				AND  (IA.flag &  8) =0 		)
				,0),

		--somma RIVALUTAZIONI applicate (IA.flag &  8) =0   ALLA DATA
		isnull(
		(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(AM.assetvalue, 0.0) *ISNULL(AM.amortizationquota,0.0),2)))
				FROM assetview A  
				join inventorytreelink IL on IL.idchild=A.idinv  and IL.idparent=I0.idinv			
				JOIN assetamortization    AM on AM.idasset=A.idasset and AM.idpiece=A.idpiece
				JOIN  inventoryamortization	 IA ON    AM.idinventoryamortization =     IA.idinventoryamortization								
				LEFT OUTER JOIN assetload AL	ON  AM.idassetload = AL.idassetload
				WHERE (A.unloaddate is null or A.unloaddate > @data_rif)   and
					--A.ratificationdate <= @data_rif AND   task 12599
					(A.inventorykindvisible = 'S') --- non considero beni a noleggio
				AND ( ((AM.flag & 1 = 0) 	AND AM.adate <= @data_rif) 
					  OR 
					  ((AM.flag & 1 <> 0)    AND AL.adate <= @data_rif)
					)
			 	
				
				AND ISNULL(AM.amortizationquota,0)>0
						AND (IA.flag & 2 <> 0)
				AND  (IA.flag &  8) =0 		)
				,0),

		--scarico accessori posseduti alla data
		isnull(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			FROM assetview A  
			join inventorytreelink IL on IL.idchild=A.idinv  and IL.idparent=I0.idinv		
			join asset AC 		on AC.idasset = A.idasset  and   AC.idpiece >1
			join assetacquire B  on B.nassetacquire = AC.nassetacquire
			JOIN assetunload AA	ON  AC.idassetunload = AA.idassetunload
				where	-- (A.unloaddate is null or A.unloaddate > @data_rif) and A.ratificationdate <= @data_rif AND  task 12599
						  (A.inventorykindvisible = 'S') --- non considero beni a noleggio
					and A.idpiece=1 
					and  AA.adate <= @data_rif
					and  ((B.flag & 1 <> 1) AND (B.flag & 2 <> 0)))
			,0)		
FROM   inventorytree I0
WHERE I0.nlevel= @levelinv --- o non esiste un livello successivo
  OR (I0.nlevel<@levelinv and not exists (select * from inventorytree II where II.paridinv=I0.idinv))
 
  -- A questo punto, inserisco un livello per volta, i padri delle voci
  -- di classificazione inventariale inserite, in modo da ricostruire 
  -- la gerarchia.
  -- Inoltre totalizzo gli importi dei figli sui padri
  -- Ripeto questa operazione per quattro volte

  --- 1) 
   
  INSERT INTO #simula_assetamortization 
  (idinv, nlevel, paridinv, codeinv, description,valore_iniziale, amm  ,sval  ,rival,subtr)
  select distinct inventorytree.idinv, inventorytree.nlevel,inventorytree.paridinv,
  inventorytree.codeinv, inventorytree.description, null,null,null,null,null
  from   inventorytree
  join     #simula_assetamortization
  on  inventorytree.idinv = #simula_assetamortization.paridinv
  where not exists (select * from #simula_assetamortization 
					where #simula_assetamortization.idinv = inventorytree.idinv )
	
 
    --- 2) 
 
   INSERT INTO #simula_assetamortization 
  (idinv, nlevel, paridinv, codeinv, description,valore_iniziale, amm  ,sval  ,rival,subtr)
  select distinct inventorytree.idinv, inventorytree.nlevel,inventorytree.paridinv,
  inventorytree.codeinv, inventorytree.description, null,null,null,null,null
  from   inventorytree
  join     #simula_assetamortization
  on  inventorytree.idinv = #simula_assetamortization.paridinv
  where not exists (select * from #simula_assetamortization 
					where #simula_assetamortization.idinv = inventorytree.idinv )

 
   --- 3) 
  INSERT INTO #simula_assetamortization 
  (idinv, nlevel, paridinv, codeinv, description,valore_iniziale, amm  ,sval  ,rival,subtr)
  select distinct inventorytree.idinv, inventorytree.nlevel,inventorytree.paridinv,
  inventorytree.codeinv, inventorytree.description, null,null,null,null,null
  from   inventorytree
  join     #simula_assetamortization
  on  inventorytree.idinv = #simula_assetamortization.paridinv
  where not exists (select * from #simula_assetamortization 
					where #simula_assetamortization.idinv = inventorytree.idinv )

 
   --4)
  INSERT INTO #simula_assetamortization 
  (idinv, nlevel, paridinv, codeinv, description,valore_iniziale, amm  ,sval  ,rival,subtr)
  select distinct inventorytree.idinv, inventorytree.nlevel,inventorytree.paridinv,
  inventorytree.codeinv, inventorytree.description, null,null,null,null,null
  from   inventorytree
  join     #simula_assetamortization
  on  inventorytree.idinv = #simula_assetamortization.paridinv
  where not exists (select * from #simula_assetamortization 
					where #simula_assetamortization.idinv = inventorytree.idinv )

update #simula_assetamortization
   set valore_iniziale = 
			isnull( (select sum(valore_iniziale) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0) ,
    amm = 
			isnull( (select sum(amm) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

    sval = 
			isnull((select sum(sval) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0), 

    rival = 
			isnull((select sum(rival) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

   subtr = 
			isnull((select sum(subtr) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0)

   WHERE #simula_assetamortization.valore_iniziale is null and
   #simula_assetamortization.amm is null and  
   #simula_assetamortization.sval is null and
   #simula_assetamortization.rival is null and 
   #simula_assetamortization.subtr is null
   AND nlevel = 5
 
 update #simula_assetamortization
   set valore_iniziale = 
			isnull( (select sum(valore_iniziale) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0) ,
    amm = 
			isnull( (select sum(amm) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

    sval = 
			isnull((select sum(sval) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0), 

    rival = 
			isnull((select sum(rival) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

   subtr = 
			isnull((select sum(subtr) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0)

   WHERE #simula_assetamortization.valore_iniziale is null and
   #simula_assetamortization.amm is null and  
   #simula_assetamortization.sval is null and
   #simula_assetamortization.rival is null and 
   #simula_assetamortization.subtr is null
   AND nlevel = 4
   update #simula_assetamortization
   set valore_iniziale = 
			isnull( (select sum(valore_iniziale) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0) ,
    amm = 
			isnull( (select sum(amm) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

    sval = 
			isnull((select sum(sval) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0), 

    rival = 
			isnull((select sum(rival) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

   subtr = 
			isnull((select sum(subtr) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0)

   WHERE #simula_assetamortization.valore_iniziale is null and
   #simula_assetamortization.amm is null and  
   #simula_assetamortization.sval is null and
   #simula_assetamortization.rival is null and 
   #simula_assetamortization.subtr is null
   AND nlevel = 3
   update #simula_assetamortization
   set valore_iniziale = 
			isnull( (select sum(valore_iniziale) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0) ,
    amm = 
			isnull( (select sum(amm) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

    sval = 
			isnull((select sum(sval) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0), 

    rival = 
			isnull((select sum(rival) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

   subtr = 
			isnull((select sum(subtr) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0)

   WHERE #simula_assetamortization.valore_iniziale is null and
   #simula_assetamortization.amm is null and  
   #simula_assetamortization.sval is null and
   #simula_assetamortization.rival is null and 
   #simula_assetamortization.subtr is null
   AND nlevel = 2
   update #simula_assetamortization
   set valore_iniziale = 
			isnull( (select sum(valore_iniziale) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0) ,
    amm = 
			isnull( (select sum(amm) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

    sval = 
			isnull((select sum(sval) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0), 

    rival = 
			isnull((select sum(rival) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0),

   subtr = 
			isnull((select sum(subtr) from #simula_assetamortization child 
			where child.paridinv = #simula_assetamortization.idinv),0)

   WHERE #simula_assetamortization.valore_iniziale is null and
   #simula_assetamortization.amm is null and  
   #simula_assetamortization.sval is null and
   #simula_assetamortization.rival is null and 
   #simula_assetamortization.subtr is null
   AND nlevel = 1

  --select * from #simula_assetamortization order by 
  --case when paridinv is null then  idinv else paridinv 
  --end  , nlevel desc

select  
	@data_rif as 'data riferimento',
	@levelinv as 'livello stampa',
	inventorysortinglevel.description as 'nome livello',
	S.nlevel as 'livello inventariale',
	S.codeinv as 'codice inventariale',
	S.description as 'descrizione',
	PARENT.codeinv as 'codice inv. padre',
	isnull(S.valore_iniziale,0)-isnull(S.subtr,0) as 'costo storico',
	-isnull(S.amm,0) as 'fondo ammortamenti',
	-isnull(S.sval,0) as 'svalutazioni',
	isnull(S.rival,0)as 'rivalutazioni',
	isnull(S.valore_iniziale,0)-isnull(S.subtr,0)+isnull(S.amm,0)+isnull(S.sval,0)+isnull(S.rival,0) as 'valore contabile'
from #simula_assetamortization S
LEFT OUTER JOIN inventorytree PARENT  ON s.paridinv = PARENT.idinv
LEFT OUTER JOIN inventorysortinglevel  ON s.nlevel = inventorysortinglevel.nlevel
	--where (isnull(S.valore_iniziale,0)-isnull(S.subtr,0)  <> 0)
	order by 
	replace(SUBSTRING(s.codeinv + ' ',1,@codelen1),' ','z') asc,
	replace(SUBSTRING(s.codeinv + ' ',@codelen1 + 1,@codelen2),' ','z') asc,
	replace(SUBSTRING(s.codeinv + ' ',@codelen1 + @codelen2 + 1,@codelen3),' ','z') asc,
	replace(SUBSTRING(s.codeinv + ' ',@codelen1 + @codelen2 + @codelen3 +1, @codelen4),' ','z') asc
END
 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
