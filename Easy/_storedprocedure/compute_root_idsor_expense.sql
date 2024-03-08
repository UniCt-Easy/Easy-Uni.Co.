
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_root_idsor_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_root_idsor_expense]
GO


CREATE        PROCEDURE [compute_root_idsor_expense] 
(
	@idsorkind_target int,
	@ayear int,
	@idexp int, 
	@idreg int,
	@idupb varchar(36),
	@nphase tinyint,
	@idfin int, 
	@idman int, 
	@amount decimal
)
AS
-- Il concetto di base è che l'assenza di configurazione sulla n-pla in ingresso significhi ' FAI QUALSIASI COSA SU QUEL MOVIMENTO '
CREATE TABLE #tmp (
	[idautosort] [int],
	[idfin] [int],
	[idupb][varchar](36),
	[idsorkindreg] [int],
	[idsorreg][int],
	[idman] [int],
	[idsorkind] [int],
	[idsor] [int],
	[jointolessspecifics] [char] (1)
)

INSERT INTO #tmp 
	(idautosort,idfin,idupb,idsorkindreg,idsorreg, idman,
	idsorkind,idsor,jointolessspecifics) 
SELECT 
	A.idautosort,F.idparent,--A.idfin,
	A.idupb,A.idsorkindreg,A.idsorreg,A.idman,
	A.idsorkind,A.idsor,A.jointolessspecifics
FROM sortingexpensefilter A
JOIN sortingkind T
	ON A.idsorkind = T.idsorkind 
LEFT OUTER JOIN finlink F 
	ON F.idparent = A.idfin
WHERE T.idsorkind = @idsorkind_target AND

	((A.idfin IS NULL) OR (@idfin = F.idchild )) AND 
	((A.idupb IS NULL) OR (@idupb LIKE A.idupb+'%')) AND
	((A.idman IS NULL)OR( @idman =  A.idman)) AND
	((A.idsorkindreg IS NULL) OR 
		EXISTS (SELECT * FROM registrysorting C
			JOIN sorting sc
				ON sc.idsor = C.idsor
			JOIN sortinglink
				ON sortinglink.idchild = C.idsor
			where C.idreg=@idreg
			AND sc.idsorkind=A.idsorkindreg
			AND ((A.idsorreg IS NULL) OR (sortinglink.idparent = A.idsorreg))
			)
	)
	
--rimuove quelli meno specifici ove presenti altri più specifici
DELETE FROM #tmp WHERE
	(SELECT COUNT(*) FROM #tmp T2 
	JOIN finlink FLK 
		ON FLK.idparent = T2.idfin
	JOIN sortinglink SLK
		ON SLK.idparent = T2.idsorreg
	WHERE
		-- se #tmp ha il jointolessspecifics='S' non deve essere cancellata
		(T2.jointolessspecifics = 'N') AND
		--l'insieme individuato da T2 deve essere diverso da quello di #tmp
		( (#tmp.idfin IS NULL and T2.idfin is not null) or (#tmp.idfin is not null and T2.idfin IS NULL) or (#tmp.idfin<>T2.idfin) or
		  (#tmp.idman IS NULL and T2.idman is not null) or (#tmp.idman is not null and T2.idman IS NULL) or (#tmp.idman<>T2.idman) or
		  (#tmp.idupb IS NULL and T2.idupb is not null) or (#tmp.idupb is not null and T2.idupb IS NULL) or (#tmp.idupb<>T2.idupb) or
		  (#tmp.idsorkindreg IS NULL and T2.idsorkindreg is not null) or (#tmp.idsorkindreg is not null and T2.idsorkindreg IS NULL) or (#tmp.idsorkindreg<>T2.idsorkindreg) or
		  (#tmp.idsorreg IS NULL and T2.idsorreg is not null) or (#tmp.idsorreg is not null and T2.idsorreg IS NULL) or (#tmp.idsorreg<>T2.idsorreg) 
		) AND
		--l'insieme individuato da T2  deve essere più specifico di quello di #tmp
		(#tmp.idautosort<>T2.idautosort) AND
		((#tmp.idfin IS NULL) or (FLK.idchild = #tmp.idfin )) AND 
		((#tmp.idman IS NULL) or (T2.idman = #tmp.idman)) AND 
		((#tmp.idupb IS NULL)or(T2.idupb LIKE #tmp.idupb+'%') ) AND
		(   ((#tmp.idsorkindreg IS NULL)or
		      ( 
			 (T2.idsorkindreg = #tmp.idsorkindreg) AND 
			(SLK.idchild = #tmp.idsorreg)
		      )		
		   )	
		) 		
	)>0

if (SELECT COUNT(*) from #tmp) = 0 
BEGIN
	SELECT * FROM sorting WHERE idsorkind = @idsorkind_target AND (movkind IS NULL or movkind='S') AND
		(start is null or start <= @ayear) AND
		(stop is null or  stop >= @ayear) 

END
ELSE
BEGIN
	--Elimina i fitri a NULL
	DELETE FROM #tmp WHERE idsor IS NULL
	--Prende solo le foglie 	
	SELECT C.* FROM sorting C
	JOIN #tmp T
		ON C.idsorkind=T.idsorkind 
	JOIN sortinglevel L
		ON C.idsorkind=L.idsorkind
		AND L.nlevel = C.nlevel
	JOIN sortinglink
		ON sortinglink.idchild = C.idsor
	WHERE T.idsor = sortinglink.idparent
		AND ((L.flag & 2) <> 0)
		AND NOT EXISTS(SELECT * FROM sorting C2 WHERE C2.paridsor=C.idsor AND C2.idsorkind=C.idsorkind)
		AND  (C.start is null or C.start <= @ayear) AND
   		     (C.stop is null or  C.stop >= @ayear) 


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

