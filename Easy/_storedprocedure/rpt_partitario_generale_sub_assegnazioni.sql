
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_generale_sub_assegnazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure[rpt_partitario_generale_sub_assegnazioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE                  PROCEDURE rpt_partitario_generale_sub_assegnazioni
	@ayear int,			
	@stop datetime,
	@kind char(1),
	@idupb	varchar(36),
	@codelevel tinyint,	---come sempre è il livello di bilancio da cui posso capire se devo visualizzare crediti o incassi..	
	@idfin int
AS
BEGIN

declare @flagcredit varchar(1)
declare @flagproceeds varchar(1)
select	@flagcredit = isnull(flagcredit,'N'),
	@flagproceeds = isnull(flagproceeds,'N')
from config
where ayear=@ayear

DECLARE @MostraAssegnazioni varchar(50)
SELECT @MostraAssegnazioni=isnull(paramvalue,'N') FROM reportadditionalparam
WHERE paramname='MostraAssegnazioni'

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)
-- Caricamento delle assegnazioni crediti/incassi
IF ( @kind ='C' and @MostraAssegnazioni='S' and @flagcredit='S') 	--> nel caso  in cui devo elencare le assegnazioni crediti
BEGIN
	SELECT 
		finexpense.codefin as idfin_S,
		finincome.codefin as idfin_E,
		income.idinc as idmov_E,
		income.nphase as nphase,
		creditpart.adate as operationdate,
		creditpart.ycreditpart as ymov,
		creditpart.ncreditpart as nmov,		
		income.ymov as ymov_E,
		income.nmov as nmov_E,
		creditpart.description ,
		creditpart.amount ,
		incomephase.description incomedescription
	FROM creditpart
	JOIN incomeyear
		ON creditpart.idinc = incomeyear.idinc
		AND creditpart.ycreditpart = incomeyear.ayear  
	JOIN income 
		ON creditpart.idinc=income.idinc
	JOIN incomephase
		ON incomephase.nphase=income.nphase
	JOIN fin finexpense
		ON creditpart.idfin=finexpense.idfin
	JOIN fin finincome
		ON incomeyear.idfin=finincome.idfin
	JOIN finlink 
		ON finlink.idchild = creditpart.idfin
	WHERE creditpart.adate between @firstday AND @stop
		AND creditpart.ycreditpart=@ayear
 		AND finlink.nlevel = @codelevel
		AND isnull(finlink.idparent,creditpart.idfin) = @idfin 	
		AND incomeyear.idupb = @idupb
	ORDER BY operationdate,ymov,nmov
	RETURN
END

IF (@kind ='I' and @MostraAssegnazioni='S' and @flagproceeds='S')  
BEGIN
	SELECT 
		finexpense.codefin as idfin_S,
		finincome.codefin as idfin_E,
		income.idinc as idmov_E,
		income.nphase as nphase,
		proceedspart.adate as operationdate,
		proceedspart.yproceedspart as ymov,
		proceedspart.nproceedspart as nmov,		
		income.ymov as ymov_E,
		income.nmov as nmov_E,
		proceedspart.description ,
		proceedspart.amount  ,
		incomephase.description as incomedescription
	FROM proceedspart
	JOIN incomeyear
		ON proceedspart.idinc = incomeyear.idinc
		AND proceedspart.yproceedspart = incomeyear.ayear  
	JOIN income 
		ON proceedspart.idinc=income.idinc
	JOIN incomephase
		ON incomephase.nphase=income.nphase
	JOIN fin finexpense
		ON proceedspart.idfin=finexpense.idfin
	JOIN finlink FK
		ON FK.idchild=proceedspart.idfin
		AND FK.nlevel=@codelevel
	JOIN fin finincome
		ON incomeyear.idfin=finincome.idfin
	WHERE proceedspart.adate between @firstday AND @stop
		AND isnull(FK.idparent,proceedspart.idfin) = @idfin 	
		and proceedspart.yproceedspart=@ayear
		AND incomeyear.idupb = @idupb
	ORDER BY operationdate,ymov,nmov
	RETURN
END

SELECT 
	null as idfin_S,
	null as idfin_E,
	null as idmov_E,
	null as nphase,
	null as operationdate,
	null as ymov,
	null as nmov,		
	null as ymov_E,
	null as nmov_E,
	null as description,
	null as amount,
	null as incomedescription

END























GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

