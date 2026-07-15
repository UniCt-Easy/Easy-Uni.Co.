/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_finsorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_check_finsorting
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--setuser'amministrazione'
 
CREATE      PROCEDURE exp_check_finsorting
 (
	@idsorkind int,
	@ayear int,				-- esercizio del piano dei conti finanziario, obbligatorio
	@finpart char(1),		-- [E]:Entrate / [S]:Spese / [A]: All/Tutte
	@kind varchar(20),		-- 'CLASSIFICATI', 'NONCLASSIFICATI','ERRORI'
	@nlevel int = null 
)
--EXEC exp_check_finsorting 29 ,2025,'E','CLASSIFICATI', null		--29,30  
--EXEC exp_check_finsorting 30 ,2025,'S','CLASSIFICATI', null		--29,30  
--EXEC exp_check_finsorting 29 ,2025,'E','NONCLASSIFICATI', null	--29,30  
--EXEC exp_check_finsorting 30 ,2025,'S','NONCLASSIFICATI', null	--29,30  
--EXEC exp_check_finsorting 29 ,2025,'E','ERRORI', null				--29,30  
--EXEC exp_check_finsorting 30 ,2025,'S','ERRORI', null				--29,30  
--EXEC exp_check_finsorting 31 ,2025,'E','ERRORI', null				--31,32  
--EXEC exp_check_finsorting 32 ,2025,'S','ERRORI', null				--31,32  

AS  BEGIN
	IF (@idsorkind IS NULL) RETURN
	--select * from sortingkind
	declare @codesorkind varchar(20)
	declare @sortingkind varchar(50)
 
	select @codesorkind = codesorkind,
	@sortingkind = description
	FROM sortingkind WHERE 
	idsorkind = @idsorkind
	
	DECLARE @minoplevel tinyint
	SELECT  @minoplevel = min(nlevel)
	FROM    finlevel
	WHERE   ayear = @ayear and (flag&2)<>0

 

	IF ISNULL(@kind, 'CLASSIFICATI') = 'NONCLASSIFICATI'
	BEGIN
			SELECT 
				'Voce non classificata' as 'Nota',
				@ayear AS 'Eserc.',
				@codesorkind as '# Tipo Class.',
				@sortingkind as 'Tipo Class.',
				CASE WHEN ((F.flag&1) = 0) THEN 'ENTRATE' ELSE 'SPESE' END as 'Parte',
				FL.description as 'Livello',
				CASE WHEN FLast.idfin IS NOT NULL THEN 'S' ELSE 'N' END as 'Leaf',
				--F.idfin as '#Bil.',
				F.codefin as 'Cod. Bil.',
				F.title as 'Bilancio',
				manager.title as 'Responsabile',
				FLParent.description as 'Livello Padre',
				--FParent.idfin as '# Bilancio Padre',
				FParent.codefin as 'Cod. Bil. Padre',
				FParent.title as 'Bilancio Padre' 
			FROM fin F 
			JOIN finlevel FL
				 ON F.nlevel = FL.nlevel AND F.ayear = FL.ayear
			LEFT OUTER JOIN fin FParent
				 ON F.paridfin = FParent.idfin
			LEFT OUTER JOIN finlevel FLParent
				 ON FParent.nlevel = FLParent.nlevel AND FParent.ayear = FLParent.ayear
			JOIN finlast FLast
				 ON FLast.idfin = F.idfin 
			LEFT OUTER JOIN manager 
				 ON FLast.idman = manager.idman 
		 	WHERE ( 
					(((F.flag&1) = 0) AND @finpart = 'E')   OR -- solo la parte Entrata  
				    (((F.flag&1) <>0) AND @finpart = 'S')   OR -- solo la parte Spesa 
					 @finpart = 'A' -- Sia Entrata che Spesa
				  ) 
	 			AND  F.ayear = @ayear
				AND (F.nlevel = @nlevel OR @nlevel IS NULL)
				AND NOT EXISTS (SELECT * FROM finsorting 
							JOIN sorting  
							  ON finsorting.idsor =  sorting.idsor 
						   WHERE finsorting.idfin = F.idfin 
							 AND sorting.idsorkind = @idsorkind)
				ORDER BY  F.codefin, F.nlevel
				RETURN
END
IF ISNULL(@kind, 'CLASSIFICATI') = 'CLASSIFICATI'
	BEGIN
			SELECT 
				'Voce classificata' as 'Nota',
				@ayear AS 'Eserc.',
				@codesorkind as '# Tipo Class.',
				@sortingkind as 'Tipo Class.',
				CASE WHEN ((F.flag&1) = 0) THEN 'ENTRATE' ELSE 'SPESE' END as 'Parte',
				FL.description as 'Livello',
				CASE WHEN FLast.idfin IS NOT NULL THEN 'S' ELSE 'N' END as 'Leaf',
				--F.idfin as '#Bil.',
				F.codefin as 'Cod. Bil.',
				F.title as 'Bilancio',
				manager.title as 'Responsabile',
				FLParent.description as 'Livello Padre',
				--FParent.idfin as '# Bilancio Padre',
				FParent.codefin as 'Cod. Bil. Padre',
				FParent.title as 'Bilancio Padre',
				sorting.sortcode as 'Cod. Voce Class',
				sorting.description as 'Voce Class',
				finsorting.quota * 100 as 'Quota %'
			FROM fin F 
			JOIN finlevel FL
				 ON F.nlevel = FL.nlevel AND F.ayear = FL.ayear
			LEFT OUTER JOIN fin FParent
				 ON F.paridfin = FParent.idfin
			LEFT OUTER JOIN finlevel FLParent
				 ON FParent.nlevel = FLParent.nlevel AND FParent.ayear = FLParent.ayear
			JOIN finlast FLast
				 ON FLast.idfin = F.idfin 
			LEFT OUTER JOIN manager 
				 ON FLast.idman = manager.idman 
			JOIN finsorting  ON finsorting.idfin = F.idfin
				JOIN sorting   ON finsorting.idsor =  sorting.idsor AND sorting.idsorkind = @idsorkind 
		 	WHERE ( 
					(((F.flag&1) = 0) AND @finpart = 'E')   OR -- solo la parte Entrata  
				    (((F.flag&1) <>0) AND @finpart = 'S')   OR -- solo la parte Spesa 
					 @finpart = 'A' -- Sia Entrata che Spesa
				  ) 
	 			AND  F.ayear = @ayear
				AND (F.nlevel = @nlevel OR @nlevel IS NULL)
				
				ORDER BY  F.codefin, F.nlevel
 
END;
IF ISNULL(@kind, 'CLASSIFICATI') = 'ERRORI'
	BEGIN
	WITH QUOTE_RIPARTIZIONE AS
		( 
		   SELECT fin.idfin as idfin, 
				  SUM(quota)*100 as quota FROM finsorting 
							JOIN sorting  
							  ON finsorting.idsor =  sorting.idsor 
							JOIN fin  
							  ON finsorting.idfin =  fin.idfin 
							 WHERE sorting.idsorkind = @idsorkind
				GROUP BY fin.idfin
		),
	LONGDESCRIPTION AS
	(SELECT  F1.idfin as idfin,  
				(SELECT DISTINCT SUBSTRING(ISNULL(sorting.sortcode +'_'+ sorting.description,'') +';',1,1000) 
							FROM finsorting 
							JOIN sorting  
							  ON finsorting.idsor =  sorting.idsor 
							JOIN fin  
							  ON finsorting.idfin =  fin.idfin 
							 WHERE sorting.idsorkind = @idsorkind AND fin.idfin = F1.idfin
							 FOR XML PATH('') ) AS longdescr,
				(SELECT DISTINCT SUBSTRING(ISNULL(sorting.sortcode,'') +';',1,1000) 
							FROM finsorting 
							JOIN sorting  
							  ON finsorting.idsor =  sorting.idsor 
							JOIN fin  
							  ON finsorting.idfin =  fin.idfin 
							 WHERE sorting.idsorkind = @idsorkind AND fin.idfin = F1.idfin
							 FOR XML PATH('') ) AS longcode
				FROM finsorting 
							JOIN sorting  
							  ON finsorting.idsor =  sorting.idsor 
							JOIN fin F1
							  ON finsorting.idfin =  F1.idfin 
							 WHERE sorting.idsorkind = @idsorkind
				
				GROUP BY F1.idfin
	 )
		SELECT 
				'Errore di Ripartizione' as 'Nota',
				@ayear AS 'Eserc.',
				QUOTE_RIPARTIZIONE.quota AS 'Somma Quote %',
				@codesorkind as '# Tipo Class.',
				@sortingkind as 'Tipo Class.',
				LONGDESCRIPTION.longcode as 'Cod. Voce Class.',
				LONGDESCRIPTION.longdescr  as 'Voce Class.',
				CASE WHEN ((F.flag&1) = 0) THEN 'ENTRATE' ELSE 'SPESE' END as 'Parte',
				F.nlevel as 'n° Livello',
				FL.description as 'Livello',
				CASE WHEN FLast.idfin IS NOT NULL THEN 'S' ELSE 'N' END as 'Bil. Foglia',
				--F.idfin as '#Bil.',
				F.codefin as 'Cod. Bil.',
				F.title as 'Bilancio',
				manager.title as 'Responsabile',
				FLParent.description as 'Livello Padre',
				--FParent.idfin as '# Bilancio Padre',
				FParent.codefin as 'Cod. Bil. Padre',
				FParent.title as 'Bilancio Padre' 
			FROM fin F 
			JOIN finlevel FL
				 ON F.nlevel = FL.nlevel AND F.ayear = FL.ayear
			LEFT OUTER JOIN fin FParent
				 ON F.paridfin = FParent.idfin
			LEFT OUTER JOIN finlevel FLParent
				 ON FParent.nlevel = FLParent.nlevel AND FParent.ayear = FLParent.ayear
			JOIN finlast FLast
				 ON FLast.idfin = F.idfin 
			LEFT OUTER JOIN manager 
				 ON FLast.idman = manager.idman 
			JOIN QUOTE_RIPARTIZIONE ON QUOTE_RIPARTIZIONE.idfin = F.idfin
			JOIN LONGDESCRIPTION ON LONGDESCRIPTION.idfin = F.idfin
		 	WHERE ( 
					(((F.flag&1) = 0) AND @finpart = 'E')   OR -- solo la parte Entrata  
				    (((F.flag&1) <>0) AND @finpart = 'S')   OR -- solo la parte Spesa 
					 @finpart = 'A' -- Sia Entrata che Spesa
				  ) 
	 			AND  F.ayear = @ayear
				AND (F.nlevel = @nlevel OR @nlevel IS NULL)
				AND  QUOTE_RIPARTIZIONE.quota <> 100
			--ORDER BY  F.codefin, F.nlevel
			UNION ALL
			SELECT 
				'Voce di classificazione non Foglia' as 'Nota',
				@ayear AS 'Eserc.',
				finsorting.quota * 100 AS 'Quota %',
				@codesorkind as '# Tipo Class.',
				@sortingkind as 'Tipo Class.',
				S1.sortcode as 'Cod. Voce Class.',
				S1.description as 'Voce Class.',
				CASE WHEN ((F.flag&1) = 0) THEN 'ENTRATE' ELSE 'SPESE' END as 'Parte',
				F.nlevel as 'n° Livello',
				FL.description as 'Livello',
				CASE WHEN FLast.idfin IS NOT NULL THEN 'S' ELSE 'N' END as 'Bil. Foglia',
				--F.idfin as '#Bil.',
				F.codefin as 'Cod. Bil.',
				F.title as 'Bilancio',
				manager.title as 'Responsabile',
				FLParent.description as 'Livello Padre',
				--FParent.idfin as '# Bilancio Padre',
				FParent.codefin as 'Cod. Bil. Padre',
				FParent.title as 'Bilancio Padre' 
			FROM fin F 
			JOIN finlevel FL
				 ON F.nlevel = FL.nlevel AND F.ayear = FL.ayear
			LEFT OUTER JOIN fin FParent
				 ON F.paridfin = FParent.idfin
			LEFT OUTER JOIN finlevel FLParent
				 ON FParent.nlevel = FLParent.nlevel AND FParent.ayear = FLParent.ayear
			JOIN finlast FLast
				 ON FLast.idfin = F.idfin 
			LEFT OUTER JOIN manager 
				 ON FLast.idman = manager.idman 
			JOIN finsorting  ON finsorting.idfin = F.idfin
			JOIN sorting  S1 ON finsorting.idsor =  S1.idsor AND S1.idsorkind = @idsorkind 
		 	WHERE ( 
					(((F.flag&1) = 0) AND @finpart = 'E')   OR -- solo la parte Entrata  
				    (((F.flag&1) <>0) AND @finpart = 'S')   OR -- solo la parte Spesa 
					 @finpart = 'A' -- Sia Entrata che Spesa
				  ) 
	 			AND  F.ayear = @ayear
				AND (F.nlevel = @nlevel OR @nlevel IS NULL)
				AND EXISTS( SELECT * FROM sorting where sorting.paridsor = S1.idsor )
				ORDER BY  F.codefin, F.nlevel

			RETURN
END
 
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 