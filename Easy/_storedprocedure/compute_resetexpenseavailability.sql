
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_resetexpenseavailability]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_resetexpenseavailability]
GO


CREATE           PROCEDURE compute_resetexpenseavailability
(
	@ayear int,
	@idexp int 
)
AS BEGIN

declare @nlevel tinyint
select @nlevel = nphase from expense where idexp = @idexp 

CREATE TABLE #toreset (idexp int, nphase tinyint, idunderwriting int,amount decimal(19,2))

--aggiunge le fasi sino alla seconda
INSERT INTO #toreset (idexp,nphase,amount)
SELECT idparent,nlevel,0
FROM expenselink
WHERE idchild = @idexp	and nlevel<@nlevel and nlevel>1



UPDATE #toreset SET amount = 
		(SELECT - SUM (ET.available) 
		FROM expensetotal ET
		JOIN expenselink EL
		ON EL.idparent = ET.idexp
		WHERE EL.idchild = @idexp  AND ET.ayear = @ayear AND EL.nlevel>=#toreset.nphase AND EL.idparent<>@idexp)


declare @disp_prima_fase decimal(19,2)
set @disp_prima_fase= 0

select @disp_prima_fase = 
		(SELECT  SUM (ET.available) 
		FROM expensetotal ET
		JOIN expenselink EL
		ON EL.idparent = ET.idexp
		WHERE EL.idchild = @idexp  AND ET.ayear = @ayear AND EL.nlevel>=1 AND EL.idparent<>@idexp)

 
 declare @idexp_prima_fase int
 select @idexp_prima_fase= idparent from expenselink where idchild=@idexp and nlevel=1
 
if  ( (select count(*) from underwritingpayment where idexp = @idexp)>0 
	 AND ( (select ymov from expense where idexp=	@idexp_prima_fase) =
			(select ymov from expense where idexp=	@idexp) 
		 )
	)
BEGIN
	insert into #toreset (idexp,nphase,amount,idunderwriting)
	select @idexp_prima_fase, 1, -topay, idunderwriting
		from expensecreditproceedsview where idexp= @idexp_prima_fase
 END		
		
declare @subtractions_primafase decimal(19,2)
select 	@subtractions_primafase = -sum(amount) from #toreset where nphase=1

declare @tosubtract_primafase decimal(19,2)
set @tosubtract_primafase = isnull(@disp_prima_fase,0) - isnull(@subtractions_primafase,0)
if @tosubtract_primafase <>0
	insert into #toreset (idexp,nphase,amount,idunderwriting)
			values (@idexp_prima_fase,1, -@tosubtract_primafase,null)


SELECT 
	#toreset.nphase,
	expensephase.description as phase,
      	#toreset.idexp,
      	E.ymov,
	E.nmov,
	'Minore spesa' AS description,
	#toreset.amount,
	idunderwriting
FROM #toreset 
LEFT OUTER JOIN expense E
	ON #toreset.idexp = E.idexp 
LEFT OUTER JOIN expensephase
	ON #toreset.nphase = expensephase.nphase 

ORDER BY #toreset.nphase
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

