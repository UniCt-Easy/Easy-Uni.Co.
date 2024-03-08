
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prevavailable_upb_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prevavailable_upb_fin]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exec exp_prevavailable_upb_fin 2020,'S',null,null,null,null,null,null 
CREATE PROCEDURE exp_prevavailable_upb_fin
(
	@ayear int,
	@finpart char(1),
	@idman int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)
AS BEGIN
DECLARE @finphase tinyint
DECLARE @maxphase tinyint
DECLARE @fin_kind tinyint
SELECT  @fin_kind = fin_kind 
FROM    config WHERE ayear = @ayear

CREATE TABLE #previsionupbfin
(
	ayear int,
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),
	idfin int,
	codefin varchar(50),
	fin varchar(150),
	finlevel varchar(50),
	manager varchar(150),
	incomeprevavailable_comp decimal(19,2),	
	incomeprevavailable_cash decimal(19,2),
	expenseprevavailable_comp decimal(19,2),
	expenseprevavailable_cash decimal(19,2),

	varprevprinc decimal(19,2),
	varprevsec decimal(19,2),
	incomeprevavailableNonApprovato_comp decimal(19,2),	
	incomeprevavailableNonApprovato_cash decimal(19,2),
	expenseprevavailableNonApprovato_comp decimal(19,2),
	expenseprevavailableNonApprovato_cash decimal(19,2)
)


IF (@finpart = 'S') 
BEGIN
	SELECT @finphase = expensefinphase FROM uniconfig
	SELECT @maxphase = MAX (nphase) FROM expensephase
	
	-- Competenza / Competenza e Cassa
	IF (@fin_kind IN (1,3))  
		insert into #previsionupbfin(idupb, idfin, expenseprevavailable_comp)
		SELECT UT.idupb, UT.idfin,
			sum( ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) - 		ISNULL(UET.totalcompetency,0) )
		FROM  upbtotal UT 
		join finlast FS ON UT.idfin = FS.idfin 
		join fin F on FS.idfin = F.idfin
		join upb U on U.idupb = UT.idupb
		LEFT OUTER JOIN upbexpensetotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @finphase
		left outer join manager M	on M.idman = U.idman
		where F.ayear = @ayear 
			AND  ((F.flag & 1) <> 0) 
			AND ((U.idman = @idman) or (@idman is null )) 
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by UT.idupb,   UT.idfin
		
	-- Cassa
	IF (@fin_kind = 2 )   
		insert into #previsionupbfin(idupb, idfin, expenseprevavailable_cash)
		SELECT UT.idupb, UT.idfin,
			sum(	ISNULL(UT.currentprev,0) + 		ISNULL(UT.previsionvariation,0) - 		ISNULL(UET.totalcompetency,0) -		ISNULL(UET.totalarrears, 0))
		FROM  upbtotal UT 
		join finlast FS ON UT.idfin = FS.idfin 
		join fin F on FS.idfin = F.idfin
		join upb U on U.idupb = UT.idupb
		LEFT OUTER JOIN upbexpensetotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @maxphase
		left outer join manager M	on M.idman = U.idman
		where F.ayear = @ayear 
			AND  ((F.flag & 1) <> 0) 
			AND ((U.idman = @idman) or (@idman is null )) 
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by UT.idupb,   UT.idfin

	
	-- Competenza e Cassa	
	IF (@fin_kind = 3 )   
		insert into #previsionupbfin(idupb, idfin, expenseprevavailable_cash ) 
		SELECT UT.idupb, UT.idfin,
			sum(	ISNULL(UT.currentsecondaryprev,0) + 		ISNULL(UT.secondaryvariation,0) - 		ISNULL(UET.totalcompetency,0) -		ISNULL(UET.totalarrears, 0))
		FROM  upbtotal UT 
		join finlast FS ON UT.idfin = FS.idfin 
		join fin F on FS.idfin = F.idfin
		join upb U on U.idupb = UT.idupb
		LEFT OUTER JOIN upbexpensetotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @maxphase
		left outer join manager M	on M.idman = U.idman
		where F.ayear = @ayear 
			AND  ((F.flag & 1) <> 0) 
			AND ((U.idman = @idman) or (@idman is null )) 
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by UT.idupb,   UT.idfin

-- Competenza / Competenza e Cassa
		insert into #previsionupbfin(idupb, idfin,varprevprinc ) 
		SELECT U.idupb, isnull(FLK.idparent,D.idfin) , sum(D.amount)  
		FROM finvar V
		JOIN finvardetail D 	
			ON V.yvar = D.yvar
			AND V.nvar = D.nvar	
		join upb U
			on U.idupb = D.idupb	
		join fin
			on D.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = D.idfin
		left outer join manager M	on M.idman = U.idman
		WHERE  V.yvar = @ayear
		AND V.flagprevision = 'S'
		AND ( (fin.flag & 1)<>0 )-- Parte spesa
		AND V.idfinvarstatus < 5 -- 5=approvata, 6=Annullata
		AND V.variationkind <> 5
		AND ((U.idman = @idman) or (@idman is null )) 
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by U.idupb, isnull(FLK.idparent,D.idfin) 

	-- Competenza e Cassa
	IF (@fin_kind =3)  
	Begin
		insert into #previsionupbfin(idupb, idfin, varprevsec ) 
		SELECT  U.idupb, isnull(FLK.idparent,D.idfin), sum(D.amount)  
		FROM finvar V
		JOIN finvardetail D 	
			ON V.yvar = D.yvar
			AND V.nvar = D.nvar	
		join upb U
			on U.idupb = D.idupb	
		join fin
			on D.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = D.idfin
		left outer join manager M	on M.idman = U.idman
		WHERE 	V.yvar = @ayear
		AND V.flagsecondaryprev = 'S'
		AND ( (fin.flag & 1)<>0 )-- Parte spesa
		AND V.idfinvarstatus < 5 -- 5=approvata, 6=Annullata
		AND V.variationkind <> 5
		AND ((U.idman = @idman) or (@idman is null )) 
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by  U.idupb, isnull(FLK.idparent,D.idfin)
	End
/*
	--Competenza / Competenza e cassa
	IF (@fin_kind IN (1,3))  
	UPDATE #previsionupbfin SET expenseprevavailableNonApprovato_comp = isnull(varprevprinc,0)+ isnull(expenseprevavailable_comp,0)

	-- Cassa
	IF (@fin_kind = 2 )   
	UPDATE #previsionupbfin SET expenseprevavailableNonApprovato_cash = isnull(varprevprinc,0)+ isnull(expenseprevavailable_cash,0)
	
	-- Competenza e Cassa	
	IF (@fin_kind = 3 )   
	UPDATE #previsionupbfin  SET expenseprevavailableNonApprovato_cash = isnull(varprevsec,0)+ isnull(expenseprevavailable_cash,0)
	*/
END
ELSE -- @finpart = 'E'
BEGIN 
BEGIN
	SELECT @finphase = incomefinphase FROM uniconfig
	SELECT @maxphase = MAX (nphase)  FROM  incomephase
	
	-- Competenza / Competenza e Cassa
	IF (@fin_kind IN (1,3))  
		insert into #previsionupbfin(idupb, idfin,incomeprevavailable_comp)
		SELECT UT.idupb, UT.idfin,
			sum( ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) - 		ISNULL(UET.totalcompetency,0) )
		FROM  upbtotal UT 
		join finlast FS ON UT.idfin = FS.idfin 
		join fin F on FS.idfin = F.idfin
		join upb U on U.idupb = UT.idupb
		LEFT OUTER JOIN upbincometotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @finphase
		left outer join manager M	on M.idman = U.idman
		where F.ayear = @ayear 
			AND  ((F.flag & 1) = 0) 
			AND ((U.idman = @idman) or (@idman is null )) 
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by UT.idupb,   UT.idfin

	-- Cassa
	IF (@fin_kind = 2 )   
		insert into #previsionupbfin(idupb, idfin,incomeprevavailable_cash)
		SELECT UT.idupb, UT.idfin,
			sum(	ISNULL(UT.currentprev,0) + 		ISNULL(UT.previsionvariation,0) - 		ISNULL(UET.totalcompetency,0) -		ISNULL(UET.totalarrears, 0))
		FROM  upbtotal UT 
		join finlast FS ON UT.idfin = FS.idfin 
		join fin F on FS.idfin = F.idfin
		join upb U on U.idupb = UT.idupb
		LEFT OUTER JOIN upbincometotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @maxphase
		left outer join manager M	on M.idman = U.idman
		where F.ayear = @ayear 
			AND  ((F.flag & 1) = 0) 
			AND ((U.idman = @idman) or (@idman is null )) 
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by UT.idupb,   UT.idfin

	
	-- Competenza e Cassa	
	IF (@fin_kind = 3 )   
		insert into #previsionupbfin(idupb, idfin,incomeprevavailable_cash ) 
		SELECT UT.idupb, UT.idfin,
			sum(	ISNULL(UT.currentsecondaryprev,0) + 		ISNULL(UT.secondaryvariation,0) - 		ISNULL(UET.totalcompetency,0) -		ISNULL(UET.totalarrears, 0))
		FROM  upbtotal UT 
		join finlast FS ON UT.idfin = FS.idfin 
		join fin F on FS.idfin = F.idfin
		join upb U on U.idupb = UT.idupb
		LEFT OUTER JOIN upbincometotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @maxphase
		left outer join manager M	on M.idman = U.idman
		where F.ayear = @ayear 
			AND  ((F.flag & 1) = 0) 
			AND ((U.idman = @idman) or (@idman is null )) 
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by UT.idupb,   UT.idfin

-- Competenza / Competenza e Cassa
		insert into #previsionupbfin(idupb, idfin,varprevprinc ) 
		SELECT U.idupb, isnull(FLK.idparent,D.idfin) , sum(D.amount)  
		FROM finvar V
		JOIN finvardetail D 	
			ON V.yvar = D.yvar
			AND V.nvar = D.nvar	
		join upb U
			on U.idupb = D.idupb	
		join fin
			on D.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = D.idfin
		left outer join manager M	on M.idman = U.idman
		WHERE  V.yvar = @ayear
		AND V.flagprevision = 'S'
		AND ( (fin.flag & 1) =0 )-- Parte entrata
		AND V.idfinvarstatus < 5 -- 5=approvata, 6=Annullata
		AND V.variationkind <> 5
		AND ((U.idman = @idman) or (@idman is null )) 
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by U.idupb, isnull(FLK.idparent,D.idfin) 

	-- Competenza e Cassa
	IF (@fin_kind =3)  
	Begin
		insert into #previsionupbfin(idupb, idfin, varprevsec ) 
		SELECT  U.idupb, isnull(FLK.idparent,D.idfin), sum(D.amount)  
		FROM finvar V
		JOIN finvardetail D 	
			ON V.yvar = D.yvar
			AND V.nvar = D.nvar	
		join upb U
			on U.idupb = D.idupb	
		join fin
			on D.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = D.idfin
		left outer join manager M	on M.idman = U.idman
		WHERE 	V.yvar = @ayear
		AND V.flagsecondaryprev = 'S'
		AND ( (fin.flag & 1) =0 )-- Parte entrata
		AND V.idfinvarstatus < 5 -- 5=approvata, 6=Annullata
		AND V.variationkind <> 5
		AND ((U.idman = @idman) or (@idman is null )) 
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)AND (@idsor03 IS NULL OR U.idsor03 = @idsor03) AND (@idsor04 IS NULL OR U.idsor04 = @idsor04) AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		group by  U.idupb, isnull(FLK.idparent,D.idfin)
	End
	End
/*	
	--Competenza / Competenza e cassa
	IF (@fin_kind IN (1,3))  
	UPDATE #previsionupbfin SET incomeprevavailableNonApprovato_comp = isnull(varprevprinc,0)+ isnull(incomeprevavailable_comp,0)

	-- Cassa
	IF (@fin_kind = 2 )   
	UPDATE #previsionupbfin SET incomeprevavailableNonApprovato_cash = isnull(varprevprinc,0)+ isnull(incomeprevavailable_cash,0)
	
	-- Competenza e Cassa	
	IF (@fin_kind = 3 )   
	UPDATE #previsionupbfin  SET incomeprevavailableNonApprovato_cash = isnull(varprevsec,0)+ isnull(incomeprevavailable_cash,0)
	*/
END

	IF (@finpart = 'S') 
	BEGIN
		IF (@fin_kind = 1)  BEGIN
			delete FROM #previsionupbfin
			WHERE ISNULL(expenseprevavailable_comp,0)=0 and isnull(varprevprinc,0)= 0

			SELECT 
			'Spesa' AS 'Parte Bil.',
			U.codeupb AS 'Cod. U.P.B.',
			U.title AS 'U.P.B.',
			M.title as 'Responsabile',
			FL.description AS 'Livello',
			F.codefin AS 'Cod. Bilancio',
			F.title AS 'Bilancio',
			sum(P.expenseprevavailable_comp) AS 'Disponibilità ad Impegnare',
			sum(( isnull(P.varprevprinc,0)+ isnull(P.expenseprevavailable_comp,0))) AS 'Disp.ad Impegnare Non Approvato'
			FROM #previsionupbfin P
			join upb U on P.idupb = U.idupb
			join fin F on F.idfin = P.idfin
			join finlevel FL on F.nlevel = FL.nlevel
			left outer join manager M on M.idman = U.idman
			WHERE  FL.ayear= @ayear
			group by U.codeupb,	U.title,	M.title,FL.description,	F.codefin,	F.title
			
		END
		IF (@fin_kind = 2)   BEGIN

			delete FROM #previsionupbfin
			WHERE isNULL(expenseprevavailable_cash,0)=0 and isnull(varprevprinc,0)=0
		
			SELECT 'Spesa' AS 'Parte Bil.',
			U.codeupb AS 'Cod. U.P.B.',
			U.title AS 'U.P.B.',
			M.title as 'Responsabile',
			FL.description AS 'Livello',
			F.codefin AS 'Cod. Bilancio',
			F.title AS 'Bilancio',			
			sum(P.expenseprevavailable_cash) AS 'Disponibilità a Pagare',
			sum(isnull(P.varprevprinc,0)+ isnull(P.expenseprevavailable_cash,0)) as 'Disp.a Pagare Non Approvato'
			FROM #previsionupbfin P
			join upb U on P.idupb = U.idupb
			join fin F on F.idfin = P.idfin
			join finlevel FL on F.nlevel = FL.nlevel
			left outer join manager M on M.idman = U.idman
			WHERE  FL.ayear= @ayear
			group by U.codeupb,	U.title,	M.title,FL.description,	F.codefin,	F.title
		END

		IF (@fin_kind = 3)   BEGIN

			delete FROM #previsionupbfin
			WHERE ISNULL(expenseprevavailable_cash,0) =0 and   isnull(varprevprinc,0) =0 and ISNULL(expenseprevavailable_comp,0)=0 and isnull(varprevsec,0)=0

			SELECT 'Spesa' AS 'Parte Bil.',
			U.codeupb AS 'Cod. U.P.B.',
			U.title AS 'U.P.B.',
			M.title as 'Responsabile',
			FL.description AS 'Livello',
			F.codefin AS 'Cod. Bilancio',
			F.title AS 'Bilancio',			
			sum(P.expenseprevavailable_comp) AS 'Disponibilità ad Impegnare',
			sum(( isnull(P.varprevprinc,0)+ isnull(P.expenseprevavailable_comp,0)) ) AS 'Disp.ad Impegnare Non Approvato',
			sum(P.expenseprevavailable_cash) AS 'Disponibilità a Pagare',
			sum(isnull(P.varprevsec,0)+ isnull(P.expenseprevavailable_cash,0)) as 'Disp.a Pagare Non Approvato'
			FROM #previsionupbfin P
			join upb U on P.idupb = U.idupb
			join fin F on F.idfin = P.idfin
			join finlevel FL on F.nlevel = FL.nlevel
			left outer join manager M on M.idman = U.idman
			WHERE FL.ayear= @ayear
			GROUP BY U.codeupb,	U.title, M.title, FL.description, F.codefin, F.title
		
		END
	END
	ELSE
	BEGIN
		IF (@fin_kind = 1)  
		BEGIN
			delete FROM #previsionupbfin
			WHERE ISNULL(incomeprevavailable_comp,0)=0 and isnull(varprevprinc,0)= 0

			SELECT 
			'Entrata' AS 'Parte Bil.',
			U.codeupb AS 'Cod. U.P.B.',
			U.title AS 'U.P.B.',
			M.title as 'Responsabile',
			FL.description AS 'Livello',
			F.codefin AS 'Cod. Bilancio',
			F.title AS 'Bilancio',
			sum(P.incomeprevavailable_comp) AS 'Disponibilità ad Accertare',
			sum(( isnull(P.varprevprinc,0)+ isnull(P.incomeprevavailable_comp,0))) AS 'Disp.ad Accertare Non Approvato'
			FROM #previsionupbfin P
			join upb U on P.idupb = U.idupb
			join fin F on F.idfin = P.idfin
			join finlevel FL on F.nlevel = FL.nlevel
			left outer join manager M on M.idman = U.idman
			WHERE  FL.ayear= @ayear
			group by U.codeupb,	U.title,	M.title,FL.description,	F.codefin,	F.title
		END
		IF (@fin_kind = 2)   
		BEGIN
			delete FROM #previsionupbfin
			WHERE isNULL(incomeprevavailable_cash,0)=0 and isnull(varprevprinc,0)=0

			SELECT 
			'Entrata' AS 'Parte Bil.',
			U.codeupb AS 'Cod. U.P.B.',
			U.title AS 'U.P.B.',
			M.title as 'Responsabile',
			FL.description AS 'Livello',
			F.codefin AS 'Cod. Bilancio',
			F.title AS 'Bilancio',			
			sum(P.incomeprevavailable_cash) AS 'Disponibilità ad Incassare',
			sum(isnull(P.varprevprinc,0)+ isnull(P.incomeprevavailable_cash,0)) as 'Disp.ad Incassare Non Approvato'
			FROM #previsionupbfin P
			join upb U on P.idupb = U.idupb
			join fin F on F.idfin = P.idfin
			join finlevel FL on F.nlevel = FL.nlevel
			left outer join manager M on M.idman = U.idman
			WHERE  FL.ayear= @ayear
			group by U.codeupb,	U.title,	M.title,FL.description,	F.codefin,	F.title
		END

		IF (@fin_kind = 3)   
		BEGIN
			delete FROM #previsionupbfin
			WHERE ISNULL(incomeprevavailable_cash,0) =0 and   isnull(varprevprinc,0) =0 and ISNULL(incomeprevavailable_comp,0)=0 and isnull(varprevsec,0)=0

			SELECT 
			'Entrata' AS 'Parte Bil.',
			U.codeupb AS 'Cod. U.P.B.',
			U.title AS 'U.P.B.',
			M.title as 'Responsabile',
			FL.description AS 'Livello',
			F.codefin AS 'Cod. Bilancio',
			F.title AS 'Bilancio',			
			sum(P.incomeprevavailable_comp) AS 'Disponibilità ad Accertare',
			sum(( isnull(P.varprevprinc,0)+ isnull(P.incomeprevavailable_comp,0)) ) AS 'Disp.ad Accertare Non Approvato',
			sum(P.incomeprevavailable_cash) AS 'Disponibilità ad Incassare',
			sum(isnull(P.varprevsec,0)+ isnull(P.incomeprevavailable_cash,0)) as 'Disp.ad Incassare Non Approvato'
			FROM #previsionupbfin P
			join upb U on P.idupb = U.idupb
			join fin F on F.idfin = P.idfin
			join finlevel FL on F.nlevel = FL.nlevel
			left outer join manager M on M.idman = U.idman
			WHERE FL.ayear= @ayear
			GROUP BY U.codeupb,	U.title, M.title, FL.description, F.codefin, F.title
		END
	END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

