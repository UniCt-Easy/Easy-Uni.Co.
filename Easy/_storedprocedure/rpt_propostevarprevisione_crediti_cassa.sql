
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_propostevarprevisione_crediti_cassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_propostevarprevisione_crediti_cassa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exec rpt_propostevarprevisione_crediti_cassa 2014,1,60,'previsione','S','N','N','2',null,null,null,null,null,null
CREATE   PROCEDURE rpt_propostevarprevisione_crediti_cassa
	@yvar          	int, 
	@nvarbegin   	int,
	@nvarend     	int,
	@reportkind    	varchar(20),
	@showupb char(1),
	@compress char(1),
	@showcategory char(1),
	@nenactment		int,
	@idman			int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
	AS
	BEGIN
	
	DECLARE @yenactment   		int
	DECLARE @idenactment	int
	
	SET 	@yenactment = @yvar
	SET     @idenactment = 
			 (SELECT idenactment
			    FROM enactment 
			   WHERE enactment.yenactment = @yenactment
	   		     AND enactment.nenactment = @nenactment)	
	
	IF @reportkind = 'PREVISIONE'
	BEGIN
		SELECT  --report variazioni della previsione
			SK.description as 'sortingkind01',
			S01.description as 'sorting01',
			finvar.yvar,
			finvar.nvar,
			finvar.description,
			finvar.enactment,
			finvar.variationkind,
			finvar.nenactment,
			finvar.enactmentdate,
			finvar.adate,
			finvar.flagprevision,
			finvar.flagcredit,
			finvar.flagproceeds,
			finvar.flagsecondaryprev,
			CASE 
				WHEN config.fin_kind IN (1,3) THEN 'C'
				WHEN config.fin_kind = 2 THEN 'S'
			END as 'previsionkind',
			CASE 
				WHEN config.fin_kind = 3 THEN 'S'
				ELSE NULL
			END as 'secprevisionkind',
			finvar.idfinvarstatus,
			finvarstatus.description as finvarstatus,
			finvar.idman,
			manager.title as manager
		FROM finvar 
		JOIN config 
			ON finvar.yvar=config.ayear	
		JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
		JOIN upb
			ON finvardetail.idupb = upb.idupb				
		LEFT OUTER JOIN finvarstatus
				ON finvar.idfinvarstatus = finvarstatus.idfinvarstatus
		LEFT OUTER JOIN manager
				ON finvar.idman = manager.idman
		LEFT OUTER JOIN sorting S01
				ON finvar.idsor01 = S01.idsor
		LEFT OUTER JOIN sortingkind SK
				ON SK.idsorkind = S01.idsorkind
		WHERE
			finvar.yvar = @yvar
			AND (flagprevision = 'S' OR flagsecondaryprev = 'S')
			AND finvar.variationkind <> 5
			AND (finvar.idenactment = @idenactment OR @idenactment IS NULL)	
			AND (finvar.idman = @idman OR @idman IS NULL)	
			AND ((finvar.nvar BETWEEN @nvarbegin AND @nvarend) OR 
		     	     (@nvarbegin IS NULL) OR (@nvarend IS NULL))
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)			     	     
		GROUP BY SK.description, S01.description,finvar.yvar, finvar.nvar, finvar.description, finvar.enactment, finvar.variationkind, finvar.nenactment,
			finvar.enactmentdate, finvar.adate, finvar.flagprevision, finvar.flagcredit,
			finvar.flagproceeds, finvar.flagsecondaryprev, config.fin_kind,	finvar.idfinvarstatus,	finvarstatus.description,finvar.idman,
			manager.title 
		ORDER BY finvar.nvar
		
	END
	IF @reportkind = 'CREDITI'
	BEGIN
		SELECT  --report variazioni dei crediti
			SK.description as 'sortingkind01',
			S01.description as 'sorting01',
			finvar.yvar,
			finvar.nvar,
			finvar.description,
			finvar.enactment,
			finvar.variationkind,
			finvar.flagcredit,
			finvar.flagproceeds,
			finvar.nenactment,
			finvar.enactmentdate,
			finvar.adate,
			NULL as 'flagprevision',
			NULL as 'flagsecondaryprev',
			NULL as 'previsionkind' ,
			NULL as 'secprevisionkind',
			finvar.idfinvarstatus,
			finvarstatus.description as finvarstatus,
			finvar.idman,
			manager.title as manager
		FROM finvar 
		JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
		JOIN upb
			ON finvardetail.idupb = upb.idupb				
		LEFT OUTER JOIN finvarstatus
				ON finvar.idfinvarstatus = finvarstatus.idfinvarstatus
		LEFT OUTER JOIN manager
				ON finvar.idman = manager.idman
		LEFT OUTER JOIN sorting S01
				ON finvar.idsor01 = S01.idsor
		LEFT OUTER JOIN sortingkind SK
				ON SK.idsorkind = S01.idsorkind
			WHERE
				finvar.yvar = @yvar
				and finvar.flagcredit = 'S'
				and (finvar.idenactment = @idenactment or @idenactment IS NULL)	
				AND (finvar.idman = @idman OR @idman IS NULL)	
				and ((finvar.nvar BETWEEN @nvarbegin and @nvarend) or 
			     	     (@nvarbegin IS NULL) or (@nvarend IS NULL))
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)		
		GROUP BY SK.description, S01.description, finvar.yvar, finvar.nvar,finvar.description,finvar.enactment,finvar.variationkind,
			finvar.flagcredit,	finvar.flagproceeds,finvar.nenactment,finvar.enactmentdate,	finvar.adate,
			finvar.idfinvarstatus,	finvarstatus.description ,finvar.idman,manager.title
		ORDER BY finvar.nvar
		END
	IF @reportkind = 'CASSA'
	BEGIN
		SELECT  --report variazioni della cassa
			SK.description as 'sortingkind01',
			S01.description as 'sorting01',
			finvar.yvar,
			finvar.nvar,
			finvar.description,
			finvar.enactment,
			finvar.variationkind,
			finvar.flagcredit,
			finvar.flagproceeds,
			finvar.nenactment,
			finvar.enactmentdate,
			finvar.adate,
			NULL as 'flagprevision',
			NULL as 'flagsecondaryprev',
			NULL as 'previsionkind' ,
			NULL as 'secprevisionkind',
			finvar.idfinvarstatus,
			finvarstatus.description as finvarstatus,
			finvar.idman,
			manager.title as manager
		FROM finvar 
		JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
		JOIN upb
			ON finvardetail.idupb = upb.idupb				
		LEFT OUTER JOIN finvarstatus
			ON finvar.idfinvarstatus = finvarstatus.idfinvarstatus
		LEFT OUTER JOIN manager
			ON finvar.idman = manager.idman
		LEFT OUTER JOIN sorting S01
				ON finvar.idsor01 = S01.idsor
		LEFT OUTER JOIN sortingkind SK
				ON SK.idsorkind = S01.idsorkind
			WHERE
				finvar.yvar = @yvar
				and flagproceeds = 'S'
				and (finvar.idenactment = @idenactment or @idenactment IS NULL)	
				AND (finvar.idman = @idman OR @idman IS NULL)	
				and ((finvar.nvar BETWEEN @nvarbegin AND @nvarend) or 
			     	     (@nvarbegin IS NULL) or (@nvarend IS NULL))
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
			GROUP BY SK.description,S01.description,finvar.yvar,finvar.nvar,finvar.description,finvar.enactment,finvar.variationkind,
			finvar.flagcredit,finvar.flagproceeds,	finvar.nenactment,	finvar.enactmentdate,
			finvar.adate,	finvar.idfinvarstatus,	finvarstatus.description,	finvar.idman,		manager.title			     	     
			ORDER BY finvar.nvar
		END 
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


