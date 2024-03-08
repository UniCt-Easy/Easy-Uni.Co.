
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_root_sortingkind_income]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_root_sortingkind_income]
GO

--setuser'amm'


CREATE       PROCEDURE [compute_root_sortingkind_income] 
	@ayear int,
	@idinc int,
	@idreg int,
	@idupb varchar(36),
	@nphase tinyint,
	@idfin int,
	@idman varchar(2),
	@amount decimal
AS
DECLARE @codesorkind_siopeentrate varchar(20)

IF (@ayear<= 2017) 
	BEGIN
		 SET @codesorkind_siopeentrate = '07E_SIOPE'
	END
ELSE
	BEGIN
		 SET @codesorkind_siopeentrate = 'SIOPE_E_18'
	END


CREATE TABLE #tmp (
	[idautosort] [int],
	[idfin] [int],
	[idupb][varchar](36),
	[idsorkindreg] [int],
	[idsorreg][int],
	[idman][int],
	[idsorkind] [int],
	[idsor] [int],
	[jointolessspecifics] [char] (1) 
)


INSERT INTO #tmp 
            (idautosort,idfin,idupb,
		idsorkindreg,idsorreg,idman,
		idsorkind,idsor,jointolessspecifics
) 
SELECT 
	A.idautosort,F.idparent, --A.idfin,
	A.idupb,A.idsorkindreg,A.idsorreg,A.idman,
	A.idsorkind,A.idsor,A.jointolessspecifics
FROM sortingincomefilter A
JOIN sortingkind T 
	on A.idsorkind = T.idsorkind 
LEFT OUTER JOIN finlink F 
	ON F.idparent = A.idfin
WHERE 
	T.nphaseincome = @nphase AND
	((A.idfin is null )OR(@idfin = F.idchild)) AND 
	((A.idupb IS NULL)OR( @idupb LIKE  A.idupb+'%')) AND
	((A.idman is null)OR( @idman =  A.idman)) AND
	((A.idsorkindreg is NULL) OR 
		EXISTS (SELECT * from registrysorting C
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
DELETE from #tmp where 
	(select count(*) from #tmp T2 
	JOIN finlink FLK 
		ON FLK.idchild = T2.idfin
	JOIN sortinglink SLK
		ON SLK.idparent = T2.idsorreg
	WHERE
			-- se #tmp ha il jointolessspecifics='S' non deve essere cancellata
			(#tmp.jointolessspecifics = 'N') AND
			--l'insieme individuato da T2 deve essere diverso da quello di #tmp
			( (#tmp.idfin is null and T2.idfin is not null) or (#tmp.idfin is not null and T2.idfin is null) or (#tmp.idfin<>T2.idfin) or
			  (#tmp.idupb IS NULL and T2.idupb IS NOT NULL) or (#tmp.idupb IS NOT NULL and T2.idupb IS NULL) or (#tmp.idupb<>T2.idupb) or
			  (#tmp.idman is null and T2.idman is not null) or (#tmp.idman is not null and T2.idman is null) or (#tmp.idman<>T2.idman) or
			  (#tmp.idsorkindreg is null and T2.idsorkindreg is not null) or (#tmp.idsorkindreg is not null and T2.idsorkindreg is null) or (#tmp.idsorkindreg<>T2.idsorkindreg) or
			  (#tmp.idsorreg is null and T2.idsorreg is not null) or (#tmp.idsorreg is not null and T2.idsorreg is null) or (#tmp.idsorreg<>T2.idsorreg) 

			) AND
			--l'insieme individuato da T2  deve essere più specifico di quello di #tmp
			(#tmp.idautosort<>T2.idautosort) AND
			((#tmp.idfin IS NULL) or (FLK.idchild = #tmp.idfin )) AND
			((#tmp.idman is null) or (T2.idman = #tmp.idman)) AND 
			((#tmp.idupb IS NULL)or(T2.idupb LIKE #tmp.idupb+'%') ) AND
			(   ((#tmp.idsorkindreg is null)or
			      ( 
				 (T2.idsorkindreg = #tmp.idsorkindreg) AND 
				(SLK.idchild = #tmp.idsorreg)
			      )		
			   )	
			) 		
		)>0





if (SELECT COUNT(*) from #tmp) =0 
BEGIN
 
		SELECT * FROM sortingkind
		WHERE nphaseincome = @nphase
			AND codesorkind <> @codesorkind_siopeentrate
			and (start is null or start<=@ayear) and (stop is null or stop>=@ayear)
	 
END
ELSE
BEGIN
	--Elimina i filtri con idsor = null se nella stesso tipo  classificazione è presente un altra riga a NOT NULL
	DELETE from #tmp where (idsor is  null) and 
			not exists (SELECT * from #tmp T where T.idsorkind=#tmp.idsorkind and T.idsorkind is not null)

	--Elimina i fitri a NOT NULL
	DELETE from #tmp where idsor is not null

	--Seleziona tutti i tipoclass esclusi quelli in #tmp
	begin
		SELECT * from sortingkind where idsorkind not in (SELECT DISTINCT idsorkind from #tmp)
		and codesorkind <> @codesorkind_siopeentrate
		and (start is null or start<=@ayear) and (stop is null or stop>=@ayear)
	end
	 
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

