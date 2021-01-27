
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


 
if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_asset_ammortization_corrige]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_asset_ammortization_corrige]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'


CREATE PROCEDURE [closeyear_asset_ammortization_corrige]
(
	@ayear int,
	@buonoscarico char(1) = 'S',
	@data_ammortamenti  datetime=null
)
AS BEGIN
declare @me varchar(30)
set @me='corrige'+CONVERT(char(4), @ayear)
DECLARE @dec_31 datetime
SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)

declare @descr_amm varchar(150)

if (@data_ammortamenti is null) BEGIN 
	SET  @data_ammortamenti = @dec_31
END


--cerca il codice di un ammortamento ufficiale 
declare @idinventoryamortization int


select @idinventoryamortization = MAX(idinventoryamortization) from inventoryamortization
			WHERE active='S' 
					and ((flag&8)<>0)   /* ammortamento */
					and ((flag & 1) =0)   /* annuale */

					
BEGIN /* Creazione ALL_AMM   con le aliquote di ammortamento di tutta la class.inventariale 
			sono considerate solo quelle con aliquota<0, ufficiali, attive
			le età sono prese pari pari dalla configurazione
		*/

create table #all_amm (
	idinv int,
	amortizationquota float,
	eta_min int,
	eta_max int,
	valuemin decimal(19,2),
	valuemax decimal(19,2)
) 

insert into #all_amm (idinv, eta_min,eta_max,valuemin,valuemax,amortizationquota)
SELECT C.idinv, 
	tr.age,	tr.agemax,tr.valuemin,tr.valuemax,
	coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)
from inventorytree C
  
	LEFT OUTER JOIN inventorytreelink IL1     		ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2  	    	ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3 	    	ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4 	    	ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
	LEFT OUTER JOIN inventoryamortization tr
		ON tr.idinventoryamortization = 
		ISNULL(t4.idinventoryamortization,ISNULL(t3.idinventoryamortization,
		ISNULL(t2.idinventoryamortization,t1.idinventoryamortization)))
	where 
		(C.idinv NOT IN (SELECT  IT.paridinv FROM   inventorytree IT WHERE  (IT.paridinv IS NOT NULL))) /* foglia */
		AND
		coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota) < 0
		AND
		tr.active='S'
		AND 
		((tr.flag & 2)<>0)
		
			
			
END


		
		
BEGIN 	/* Creazione #SUM_AMM ed EVERY_AMM
				#SUM_AMM		somma degli ammortamenti da applicare dall'inizio esistenza sino a quell'età
				#EVERY_AMM		aliquote di ammortamento per tutte le voci di classificazione per tutte le età
		*/


create table #sum_amm (
	idinv int,
	sum_quota float, --somma degli ammortamenti da applicare dall'inizio esistenza sino a quell'età
	valuemin decimal(19,2),
	valuemax decimal(19,2),
	eta int
) 
create table #every_amm (
				idinv int,
				ammquota float,
				valuemin decimal(19,2),
				valuemax decimal(19,2),
				eta int
			) 
			
declare @curr_eta int
set @curr_eta=1
while (@curr_eta<=50) 
BEGIN
  
  insert into #sum_amm(idinv,sum_quota,valuemin,valuemax,eta)
  select Itree.idinv,
		isnull(A.amortizationquota,0)+ isnull(S.sum_quota,0),A.valuemin,A.valuemax,
		@curr_eta
  from inventorytree Itree
  left outer join #all_amm A on A.idinv = Itree.idinv 
			AND   @curr_eta >= isnull(A.eta_min,0) AND  @curr_eta <= isnull(A.eta_max,99)
  left outer join #sum_amm S on S.idinv = Itree.idinv 
							AND S.eta= @curr_eta-1 
							AND isnull(S.valuemin,0)= isnull(A.valuemin,0) 
							AND isnull(S.valuemax,-1) = isnull(A.valuemax,-1)
   where        
	   (ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 
 
  insert into #every_amm(idinv,ammquota,valuemin,valuemax,eta)
			  select Itree.idinv,
					isnull(A.amortizationquota,0),A.valuemin,A.valuemax,
					@curr_eta
			  from inventorytree Itree
			  left outer join #all_amm A on A.idinv = Itree.idinv 
							AND   @curr_eta >= isnull(A.eta_min,0)    AND	   @curr_eta <= isnull(A.eta_max,99)			 							
			   where        
				   (ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 
				   
 
 set @curr_eta= @curr_eta+1  
END

--elimina tutte le class.inventariali dove non ci sono ammortamenti (libri, immobili etc.)
delete from #sum_amm  where not exists(select * from #all_amm where #all_amm.idinv=#sum_amm.idinv)
update #sum_amm set sum_quota=-1  where sum_quota<-1

update #sum_amm set sum_quota=-1  where round(sum_quota,2)=-1


/*
select * from #every_amm where (select count(*) from #sum_amm S where S.idinv=#every_amm.idinv and
									isnull(S.valuemin,-1) = isnull(#every_amm.valuemin,-1) 
									AND isnull(S.valuemax,-1) = isnull(#every_amm.valuemax,-1) 
									AND S.eta= #every_amm.eta-1
									)>1
*/


--cancella da every_amm tutti gli ammortamenti su eta ove il bene dovrebbe essere già stato ammortizzato completamente negli anni prec.
delete from #every_amm where isnull((select sum_quota from #sum_amm S where S.idinv=#every_amm.idinv and
									isnull(S.valuemin,-1) = isnull(#every_amm.valuemin,-1) 
									AND isnull(S.valuemax,-1) = isnull(#every_amm.valuemax,-1) 
									AND S.eta= #every_amm.eta-1
									),0)=-1;

--a questo punto #every_amm contiene gli ammortamenti da fare, anno per anno, ossia non cumulativo

--corregge l'aliquota in #EVERY_AMM per l'ultimo anno. Ad esempio se si ammortizza il 15% l'anno, l'ultimo anno si 
--  deve ammortizzare la quota residua che è il 10% e non il 15%
with CRG (idinv,valuemin,valuemax,eta,ammquota) as (
select S1.idinv,S1.valuemin,S1.valuemax, S1.eta,S1.sum_quota-S2.sum_quota 
		from #sum_amm S1 
		join #sum_amm S2 on S1.idinv=S2.idinv 
				AND isnull(S1.valuemin,-1) = isnull(S2.valuemin,-1) 
				AND isnull(S1.valuemax,-1) = isnull(S2.valuemax,-1) 
				AND S1.eta= S2.eta+1
		where S1.sum_quota=-1
)
update #every_amm set ammquota=  CRG.ammquota 
	from #every_amm 
	join CRG ON
				CRG.idinv=#every_amm.idinv 
				AND isnull(CRG.valuemin,-1) = isnull(#every_amm.valuemin,-1) 
				AND isnull(CRG.valuemax,-1) = isnull(#every_amm.valuemax,-1) 
				AND CRG.eta= #every_amm.eta

  select * from #all_amm
END


--la stored procedure GetAssetValue è usata per valutare l'importo corrente dei cespiti
--la stored procedure get_originalassetvalue è usata per valutare l'importo iniziale dei cespiti, su cui calcolare l'ammortamento
-- se l'ammortamento calcolato è tale da rendere il valore corrente negativo viene considerata una base per l'ammortamento opportunamente ridotta
--   in modo da far si che l'aliquota di ammortamento per la base di ammortamento vada ad azzerare il valore residuo del cespite

DECLARE @namortization int
DECLARE @idasset int
DECLARE @idpiece int
DECLARE @description varchar(150)
DECLARE @assetvalue decimal(19,2)
DECLARE @amortizationquota float
DECLARE @actualvalue decimal(19,2)
DECLARE @reval decimal(19,2)
declare @totamortization decimal(19,2)
declare @totamortization_expected decimal(19,2)
declare @totamortizationquota_expected float
declare @totamortizationquota float
declare @startvalue decimal(19,2)
declare @subtractions decimal(19,2)
declare @val_iniziale decimal(19,2)
declare @val_corrente decimal(19,2)
declare @lastyearammquota float

-- Caso in cui il cespite ha data di inizio esistenza NOT NULL
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classificazione del cespite e che hanno ETA NULL
DECLARE amt_crs INSENSITIVE CURSOR FOR
SELECT  
	b.idasset,	b.idpiece,	
	--@totamortizationquota   somma delle aliquote di ammortamento applicate al cespite
	-- lo ricavo in base alla differenza tra val. attuale e iniziale diviso val. iniziale 
	/* isnull ( (SELECT SUM(AA.amortizationquota)
									from assetamortization AA
									LEFT OUTER JOIN assetunload AU  ON  AA.idassetunload = AU.idassetunload
											where 
										AA.idasset=B.idasset and AA.idpiece=B.idpiece 
									  AND
									  ( ((AA.flag & 1 = 0) 	AND YEAR(AA.adate)<=@ayear ) 
										OR 
										((AA.flag & 1 <> 0)    AND YEAR(AU.adate)<=@ayear)
				      				  )			
								)
								,0) 								
						,
		*/
		
						
	--@totamortization		somma degli ammortamenti applicati al cespite				
/*	isnull ( (SELECT SUM(CONVERT(DECIMAL(19,2),
									ROUND(isnull(AA.amortizationquota,0)*isnull(AA.assetvalue,0),2)
												)) from assetamortization AA
									LEFT OUTER JOIN assetunload AU  ON  AA.idassetunload = AU.idassetunload
											where 
										AA.idasset=B.idasset and AA.idpiece=B.idpiece 
									  AND
									  ( ((AA.flag & 1 = 0) 	AND YEAR(AA.adate)<=@ayear ) 
										OR 
										((AA.flag & 1 <> 0)    AND YEAR(AU.adate)<=@ayear)
				      				  )			
								)
								,0) */
	-(ISNULL(C.historicalvalue,AC.start)-isnull(AC.subtractions,0)-isnull(AC.currentvalue,0))
								,
								
	--@subtractions		   scarichi accessori posseduti applicati al cespite					
	isnull ( (SELECT SUM( CONVERT(decimal(19,2),ROUND(ISNULL(B_1.taxable, 0)
							* (1 - CONVERT(decimal(19,6),ISNULL(B_1.discount, 0))),2)
							+ ROUND(ISNULL(B_1.tax,0) / B_1.number,2)
							- ROUND(ISNULL(B_1.abatable,0) / B_1.number,2))				
						)
			from  asset A_1	
				  JOIN assetacquire B_1	on B_1.nassetacquire = A_1.nassetacquire
					JOIN assetunload AU_1		ON A_1.idassetunload = AU_1.idassetunload				
			where A_1.idasset = B.idasset and B.idpiece=1 
					and   A_1.idpiece >1
					and  ((B_1.flag & 1 = 0) AND (B_1.flag & 2 <> 0))
					AND (year(AU_1.adate) <= @ayear)	
			)  ,0),
			
										
	--@totamortizationquota_expected			somma delle aliquote di ammortamento attese in base al piano di ammortamento attuale		
	isnull( (select  sum(S.ammquota) from #every_amm S where S.idinv=C.idinv 
											AND S.eta BETWEEN 1 AND  (@ayear - YEAR(B.lifestart)+1) 
											AND (S.valuemin is null OR S.valuemin< ISNULL(C.historicalvalue,AC.start))
											AND (S.valuemax is null OR S.valuemax>=ISNULL(C.historicalvalue,AC.start))
							  ),0)
								,ISNULL(C.historicalvalue,AC.start)-isnull(AC.subtractions,0)
								,isnull(AC.currentvalue,0)
	,isnull(E_A.ammquota,0)
	--,	ISNULL(C.historicalvalue,AC.start) 
FROM asset B			
JOIN assetacquire C					ON B.nassetacquire = C.nassetacquire
JOIN inventory						ON C.idinventory = inventory.idinventory
JOIN inventorykind					ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN #sum_amm S						ON C.idinv = S.idinv
left outer join #EVERY_AMM E_A		ON E_A.idinv=S.idinv AND  E_A.eta=S.eta
LEFT OUTER JOIN assetload AL		ON AL.idassetload = c.idassetload
JOIN assetview_current ac			ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
JOIN assetload						ON assetload.idassetload = c.idassetload			
LEFT OUTER JOIN assetunload AU		ON AU.idassetunload = B.idassetunload    	
WHERE   
	B.amortizationquota is null -- >>> Agisce solo sui cespiti che non hanno una aliquota di ammortamento sul cespite stesso
		--cespiti il cui anno di inizio esistenza è <= @ayear
	AND		YEAR(b.lifestart) <= @ayear  --AND YEAR(AL.ratificationdate)<=@ayear

		AND ( (inventorykind.flag&2)=0) --nuovo flag in tipoinventario

		-- prende come età cumulativa quella del cespite, volendo prendere un anno di meno forse si potrebbe togliere il +1 
		AND S.eta = (@ayear - YEAR(b.lifestart)) + 1
		AND	((S.valuemin is null or S.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (S.valuemax is null or S.valuemax>=ISNULL(C.historicalvalue,AC.start)))
		-- solo cespiti di cui esiste un piano di ammortamento
		AND exists(select * from #all_amm where #all_amm.idinv = C.idinv) 				

		-- prende solo cespiti in carico
		AND AC.is_loaded = 'S'		

		-- non scaricati o scaricati dopo l'anno considerato. Si può cambiarla in (AU.adate is null) se si vogliono saltare i cespiti scaricati
		AND (AU.adate is null OR YEAR(AU.adate)>@ayear )  --AND AC.is_unloaded='N'

		AND 
		(	--la somma degli ammortamenti caricati è diversa dalla somma degli ammortamenti che sarebbero dovuti essere applicati
			-- considerando il valore storico ove presente
			-- @totamortization <> @totamortizationquota_expected 	* 	ISNULL(C.historicalvalue,AC.start)	
			 (	/*isnull ( (SELECT SUM(CONVERT(DECIMAL(19,2),
									ROUND(isnull(AA.amortizationquota,0)*isnull(AA.assetvalue,0),2)
												)) from assetamortization AA
									LEFT OUTER JOIN assetunload AU  ON  AA.idassetunload = AU.idassetunload
											where 
										AA.idasset=B.idasset and AA.idpiece=B.idpiece 
									  AND
									  ( ((AA.flag & 1 = 0) 	AND YEAR(AA.adate)<=@ayear ) 
										OR 
										((AA.flag & 1 <> 0)    AND YEAR(AU.adate)<=@ayear)
				      				  )			
								)
								,0) */
				-(ISNULL(C.historicalvalue,AC.start)-isnull(AC.subtractions,0)-isnull(AC.currentvalue,0))
							
			<>		
				convert(decimal(19,2),ROUND(isnull( (select  sum(S.ammquota) from #every_amm S where S.idinv=C.idinv 
											AND S.eta BETWEEN 1 AND  (@ayear - YEAR(B.lifestart))+1 
											AND (S.valuemin is null OR S.valuemin< ISNULL(C.historicalvalue,AC.start))
											AND (S.valuemax is null OR S.valuemax>=ISNULL(C.historicalvalue,AC.start))
							  ),0) * ISNULL(C.historicalvalue,AC.start) ,2))	
			)
		or 
		    ( --ci sono accessori posseduti scaricati ossia @subtractions<>0
		    isnull ( (SELECT SUM(  CONVERT(decimal(19,2),ROUND(ISNULL(B_1.taxable, 0)
										* (1 - CONVERT(decimal(19,6),ISNULL(B_1.discount, 0))),2)
										+ ROUND(ISNULL(B_1.tax,0) / B_1.number,2)
										- ROUND(ISNULL(B_1.abatable,0) / B_1.number,2))				
								)
			from  asset A_1	
				  JOIN assetacquire B_1	on B_1.nassetacquire = A_1.nassetacquire
					JOIN assetunload AU_1		ON A_1.idassetunload = AU_1.idassetunload				
			where A_1.idasset = B.idasset and B.idpiece=1			-- è accessorio del cespite principale in questione B 
					and   A_1.idpiece >1
					and  ((B_1.flag & 1 = 0) AND (B_1.flag & 2 <> 0)) --accessorio posseduto da non includere in buono carico
					AND (year(AU_1.adate) <= @ayear)			--accessorio scaricato 
			)  ,0)<>0
		    )
		 
		)
FOR READ ONLY

OPEN amt_crs
FETCH NEXT FROM amt_crs INTO @idasset, @idpiece, @totamortization,@subtractions,
			@totamortizationquota_expected,@val_iniziale,@val_corrente,@lastyearammquota
		
WHILE (@@FETCH_STATUS = 0)
BEGIN
	execute get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue OUTPUT, @actualvalue OUTPUT 
	if @val_corrente<> @actualvalue  begin
		print '***************************************************'
		print 'idasset:'+convert(varchar(30),@idasset)+' idpiece:'+convert(varchar(30),@idpiece)+
				'valore corrente:'+convert(varchar(30),@val_corrente)+' calcolato:'+convert(varchar(30),@actualvalue)
					+' subtractions:'+ convert(varchar(30), @subtractions)
	end
	if @val_iniziale<> @assetvalue  begin
		print '***************************************************'
		print 'idasset:'+convert(varchar(30),@idasset)+' idpiece:'+convert(varchar(30),@idpiece)+
				'valore iniziale:'+convert(varchar(30),@val_iniziale)+' calcolato:'+convert(varchar(30),@assetvalue)
					+' subtractions:'+ convert(varchar(30), @subtractions)
	end

	--@val_iniziale è il valore iniziale già decurtato del valore INIZIALE degli accessori posseduti
	 set @totamortization_expected= convert(decimal(19,2),
			round(@totamortizationquota_expected* @val_iniziale ,2))

	 if (@totamortizationquota_expected=-1 or @actualvalue<0) BEGIN
			set @totamortization_expected=-@assetvalue				
	 END
	
	
    SET @reval = @totamortization_expected - @totamortization
    if (@reval<>0) BEGIN
		
		print  'idasset:'+convert(varchar(30),@idasset)+' idpiece:'+convert(varchar(30),@idpiece)+' expected:' + 
					convert(varchar(30), @totamortization_expected )+' found:'+ convert(varchar(30),@totamortization)
		set @descr_amm = 'valore iniziale:'+convert(varchar(30),@assetvalue)+
							' attuale:'+convert(varchar(30),@actualvalue)+
							' amm.attesi:'+convert(varchar(30),@totamortization_expected)+
							' amm.trovati:'+convert(varchar(30),@totamortization)
		
		SET @amortizationquota = @reval / @assetvalue
		SELECT @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
		declare @newammflag  int
		set @newammflag=0
		if (@buonoscarico='S') set @newammflag=@newammflag+1
		if (@lastyearammquota <> @amortizationquota)  begin
		  set @newammflag=@newammflag+2 -- correttivo
		  set @descr_amm=@descr_amm+' aliq.normale:'+convert(varchar(30),@lastyearammquota*100)
								   +' aliq.applicata:'+	convert(varchar(30),@amortizationquota*100)
		end
		INSERT INTO assetamortization
				(namortization,	idinventoryamortization, idasset,	idpiece,	description,	
					assetvalue,		amortizationquota,		adate,flag,		cu, ct, lu, lt	)
		VALUES
			( 	@namortization,	@idinventoryamortization,	@idasset,		@idpiece,	@descr_amm,
				@assetvalue,	@amortizationquota,			@data_ammortamenti,
				@newammflag,
				@me, GETDATE(), @me, GETDATE()
			)
	END
	
	FETCH NEXT FROM amt_crs INTO @idasset, @idpiece, @totamortization,@subtractions,
				@totamortizationquota_expected, @val_iniziale,@val_corrente,@lastyearammquota
END
DEALLOCATE amt_crs

drop table #all_amm

drop table #sum_amm


-- La sequente query è uguale a quella precedente MA agisce solo sui cespiti che hanno valorizzata l'aliquota di ammortamento sul cespite stesso
-- Caso in cui il cespite ha data di inizio esistenza NOT NULL
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classificazione del cespite e che hanno ETA NULL
DECLARE amt_crs INSENSITIVE CURSOR FOR
SELECT  
	b.idasset,	b.idpiece,	
	-(ISNULL(C.historicalvalue,AC.start)-isnull(AC.subtractions,0)-isnull(AC.currentvalue,0)),
								
	--@subtractions		   scarichi accessori posseduti applicati al cespite					
	isnull ( (SELECT SUM( CONVERT(decimal(19,2),ROUND(ISNULL(B_1.taxable, 0)
							* (1 - CONVERT(decimal(19,6),ISNULL(B_1.discount, 0))),2)
							+ ROUND(ISNULL(B_1.tax,0) / B_1.number,2)
							- ROUND(ISNULL(B_1.abatable,0) / B_1.number,2))				
						)
			from  asset A_1	
				  JOIN assetacquire B_1	on B_1.nassetacquire = A_1.nassetacquire
					JOIN assetunload AU_1		ON A_1.idassetunload = AU_1.idassetunload				
			where A_1.idasset = B.idasset and B.idpiece=1 
					and   A_1.idpiece >1
					and  ((B_1.flag & 1 = 0) AND (B_1.flag & 2 <> 0))
					AND (year(AU_1.adate) <= @ayear)	
			)  ,0),
			
	--@totamortizationquota_expected	aliquota di ammortamento del cespite ( e non del piano di ammortamento)
	b.amortizationquota,
	ISNULL(C.historicalvalue,AC.start)-isnull(AC.subtractions,0),
	isnull(AC.currentvalue,0),
	b.amortizationquota
FROM asset B			
JOIN assetacquire C					ON B.nassetacquire = C.nassetacquire
JOIN inventory						ON C.idinventory = inventory.idinventory
JOIN inventorykind					ON inventory.idinventorykind= inventorykind.idinventorykind
LEFT OUTER JOIN assetload AL		ON AL.idassetload = c.idassetload
JOIN assetview_current ac			ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
JOIN assetload						ON assetload.idassetload = c.idassetload			
LEFT OUTER JOIN assetunload AU		ON AU.idassetunload = B.idassetunload    	
WHERE   
		B.amortizationquota is NOT null
		--cespiti il cui anno di inizio esistenza è <= @ayear
		AND YEAR(b.lifestart) <= @ayear  --- SARA: E SE FOSSE NULL?

		AND ( (inventorykind.flag&2)=0) --nuovo flag in tipoinventario
		
		-- prende solo cespiti in carico
		AND AC.is_loaded = 'S'		

		-- non scaricati o scaricati dopo l'anno considerato. 
		AND (AU.adate is null OR YEAR(AU.adate)>@ayear )  
		

		AND 
		(	--la somma degli ammortamenti caricati è diversa dalla somma degli ammortamenti che sarebbero dovuti essere applicati
			-- considerando il valore storico ove presente
			-- @totamortization <> @totamortizationquota_expected 	* 	ISNULL(C.historicalvalue,AC.start)	
			 (	
				-(ISNULL(C.historicalvalue,AC.start)-isnull(AC.subtractions,0)-isnull(AC.currentvalue,0))
							
			<>		
				convert(decimal(19,2),ROUND(B.amortizationquota * ISNULL(C.historicalvalue,AC.start) ,2))	
			)
		or 
		    ( --ci sono accessori posseduti scaricati ossia @subtractions<>0
		    isnull ( (SELECT SUM(  CONVERT(decimal(19,2),ROUND(ISNULL(B_1.taxable, 0)
										* (1 - CONVERT(decimal(19,6),ISNULL(B_1.discount, 0))),2)
										+ ROUND(ISNULL(B_1.tax,0) / B_1.number,2)
										- ROUND(ISNULL(B_1.abatable,0) / B_1.number,2))				
								)
			from  asset A_1	
				  JOIN assetacquire B_1	on B_1.nassetacquire = A_1.nassetacquire
					JOIN assetunload AU_1		ON A_1.idassetunload = AU_1.idassetunload				
			where A_1.idasset = B.idasset and B.idpiece=1			-- è accessorio del cespite principale in questione B 
					and   A_1.idpiece >1
					and  ((B_1.flag & 1 = 0) AND (B_1.flag & 2 <> 0)) --accessorio posseduto da non includere in buono carico
					AND (year(AU_1.adate) <= @ayear)			--accessorio scaricato 
			)  ,0)<>0
		    )
		 
		)
FOR READ ONLY

OPEN amt_crs
FETCH NEXT FROM amt_crs INTO @idasset, @idpiece, @totamortization,@subtractions,
			@totamortizationquota_expected,@val_iniziale,@val_corrente,@lastyearammquota
		
WHILE (@@FETCH_STATUS = 0)
BEGIN
	execute get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue OUTPUT, @actualvalue OUTPUT 
	if @val_corrente<> @actualvalue  begin
		print '---------------------------------------------------------'
		print 'idasset:'+convert(varchar(30),@idasset)+' idpiece:'+convert(varchar(30),@idpiece)+
				'valore corrente:'+convert(varchar(30),@val_corrente)+' calcolato:'+convert(varchar(30),@actualvalue)
					+' subtractions:'+ convert(varchar(30), @subtractions)
	end
	if @val_iniziale<> @assetvalue  begin
		print '-----------------------------------------------------------'
		print 'idasset:'+convert(varchar(30),@idasset)+' idpiece:'+convert(varchar(30),@idpiece)+
				'valore iniziale:'+convert(varchar(30),@val_iniziale)+' calcolato:'+convert(varchar(30),@assetvalue)
					+' subtractions:'+ convert(varchar(30), @subtractions)
	end

	--@val_iniziale è il valore iniziale già decurtato del valore INIZIALE degli accessori posseduti
	 set @totamortization_expected= convert(decimal(19,2),
			round(@totamortizationquota_expected* @val_iniziale ,2))

	 if (@totamortizationquota_expected=-1 or @actualvalue<0) BEGIN
			set @totamortization_expected=-@assetvalue				
	 END
	
	
    SET @reval = @totamortization_expected - @totamortization
    if (@reval<>0) BEGIN
		
		print  'idasset:'+convert(varchar(30),@idasset)+' idpiece:'+convert(varchar(30),@idpiece)+' expected:' + 
					convert(varchar(30), @totamortization_expected )+' found:'+ convert(varchar(30),@totamortization)
		set @descr_amm = 'valore iniziale:'+convert(varchar(30),@assetvalue)+
							' attuale:'+convert(varchar(30),@actualvalue)+
							' amm.attesi:'+convert(varchar(30),@totamortization_expected)+
							' amm.trovati:'+convert(varchar(30),@totamortization)
		
		SET @amortizationquota = @reval / @assetvalue
		SELECT @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
		--declare @newammflag  int
		set @newammflag=0
		if (@buonoscarico='S') set @newammflag=@newammflag+1
		if (@lastyearammquota <> @amortizationquota)  begin
		  set @newammflag=@newammflag+2 -- correttivo
		  set @descr_amm=@descr_amm+' aliq.normale:'+convert(varchar(30),@lastyearammquota*100)
								   +' aliq.applicata:'+	convert(varchar(30),@amortizationquota*100)
		end
		INSERT INTO assetamortization
				(namortization,	idinventoryamortization, idasset,	idpiece,	description,	
					assetvalue,		amortizationquota,		adate,flag,		cu, ct, lu, lt	)
		VALUES
			( 	@namortization,	@idinventoryamortization,	@idasset,		@idpiece,	@descr_amm,
				@assetvalue,	@amortizationquota,			@data_ammortamenti,
				@newammflag,
				@me, GETDATE(), @me, GETDATE()
			)
	END
	
	FETCH NEXT FROM amt_crs INTO @idasset, @idpiece, @totamortization,@subtractions,
				@totamortizationquota_expected, @val_iniziale,@val_corrente,@lastyearammquota
END
DEALLOCATE amt_crs



END








GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--closeyear_asset_ammortization_corrige 2014,'N'
--select idasset,idpiece,ninventory,inventory,amount,* from assetamortizationview where cu='GENER.CORRIGE' order by namortization
--delete from assetamortization where cu like'CORRIGE%'
--delete from assetamortization where year(adate)=2013
--select * from assetamortization where cu like'CORRIGE%'
--setuser 'amministrazione'
--select * from assetview where idasset=255 and idpiece=1
--select * from assetview_current where idasset=255 and idpiece=1
--select * from assetamortizationview where idasset=255 and idpiece=1 
--select idasset,idpiece,ninventory,codeinv,inventory,currentvalue,is_loaded,is_unloaded,* from assetview where currentvalue<0
/* 
setuser 'amm'
***************************************************
idasset:255 idpiece:1valore corrente:672.00 calcolato:696.00 subtractions:0.00
idasset:255 idpiece:1 expected:-800.00 found:-128.00
iniz.800 revals 800 rev.pending 24 current 1600 total 960
valore iniziale:800.00 attuale:696.00 amm.attesi:-800.00 amm.trovati:-128.00
*/
