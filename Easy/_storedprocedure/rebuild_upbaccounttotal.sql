
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



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_upbaccounttotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_upbaccounttotal]
GO

CREATE     PROCEDURE [rebuild_upbaccounttotal]
(
	@ayear int = null, @idupb varchar(36)='%'
)
AS BEGIN
SET @idupb = @idupb + '%'
IF (@ayear IS NULL) 
BEGIN
	DELETE FROM upbaccounttotal WHERE idupb like @idupb
	INSERT INTO upbaccounttotal (idacc, idupb, previsionvariation, previsionvariation2, previsionvariation3,
				 previsionvariation4,previsionvariation5) 
	SELECT   acc_parent.idacc, D.idupb,
				sum(D.amount ),
				sum(D.amount2 ),
				sum(D.amount3 ),
				sum(D.amount4 ),
				sum(D.amount5 )
	from accountvardetail D 
			join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join account A ON D.idacc=A.idacc
			join account  acc_parent ON A.idacc like acc_parent.idacc+'%' and A.ayear=acc_parent.ayear
			
			where V.idaccountvarstatus = 5 and V.variationkind <> 5 and D.idupb like @idupb
	group by acc_parent.idacc, D.idupb


	INSERT INTO upbaccounttotal (idacc, idupb, previsionvariation, previsionvariation2, previsionvariation3,
				 previsionvariation4,previsionvariation5)
	SELECT DISTINCT acc_parent.idacc, IY.idupb, 0,0,0,0,0		
	FROM account A
	join account  acc_parent ON A.idacc like acc_parent.idacc+'%' and A.ayear=acc_parent.ayear
	JOIN epexpyear IY
		ON IY.idacc = A.idacc
	WHERE NOT EXISTS
		(SELECT upbaccounttotal.idacc FROM upbaccounttotal
		WHERE upbaccounttotal.idacc = acc_parent.idacc AND upbaccounttotal.idupb = IY.idupb) 
		and IY.idupb like @idupb


	INSERT INTO upbaccounttotal (idacc, idupb, previsionvariation, previsionvariation2, previsionvariation3,
				 previsionvariation4,previsionvariation5)
	SELECT DISTINCT acc_parent.idacc, IY.idupb, 0,0,0,0,0		
	FROM account A
	join account  acc_parent ON A.idacc like acc_parent.idacc+'%' and A.ayear=acc_parent.ayear
	JOIN epaccyear IY
		ON IY.idacc = A.idacc
	WHERE NOT EXISTS
		(SELECT upbaccounttotal.idacc FROM upbaccounttotal
		WHERE upbaccounttotal.idacc = acc_parent.idacc AND upbaccounttotal.idupb = IY.idupb) 
		and IY.idupb like @idupb
	
	INSERT INTO upbaccounttotal (idacc, idupb, previsionvariation, previsionvariation2, previsionvariation3,
				 previsionvariation4,previsionvariation5) 
	SELECT DISTINCT acc_parent.idacc, FY.idupb,0,0,0,0,0		
		
	FROM account A
	join account  acc_parent ON A.idacc like acc_parent.idacc+'%' and A.ayear=acc_parent.ayear
	JOIN accountyear FY
		ON FY.idacc = A.idacc
	WHERE ( 
			ISNULL(FY.prevision,0) <> 0 OR
			ISNULL(FY.prevision2,0) <> 0 OR
			ISNULL(FY.prevision3,0) <> 0 OR
			ISNULL(FY.prevision4,0) <> 0 OR
			ISNULL(FY.prevision5,0) <> 0
		)
	AND NOT EXISTS
		(SELECT upbaccounttotal.idacc FROM upbaccounttotal
		WHERE upbaccounttotal.idacc = acc_parent.idacc AND upbaccounttotal.idupb = FY.idupb)
		AND FY.idupb like @idupb


	UPDATE upbaccounttotal SET 
	currentprev = 
		(SELECT t2.prevision
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision IS NOT NULL)
	WHERE idupb like @idupb 
/*	where ( 
			(len(upbaccounttotal.idacc)-2) /4  <=
			(SELECT min(nlevel) from accountlevel 
			where ayear = '20'+convert(varchar(4),SUBSTRING(upbaccounttotal.idacc,1, 2)) and (flagusable='S'))
			)*/

	UPDATE upbaccounttotal SET 
	currentprev2 = 
		(SELECT t2.prevision2
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision2 IS NOT NULL)
    WHERE idupb like @idupb

	UPDATE upbaccounttotal SET 
	currentprev3 = 
		(SELECT t2.prevision3
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision3 IS NOT NULL)
	WHERE idupb like @idupb

	UPDATE upbaccounttotal SET 
	currentprev4 = 
		(SELECT t2.prevision4
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision4 IS NOT NULL)
	WHERE idupb like @idupb

	UPDATE upbaccounttotal SET 
	currentprev5 = 
		(SELECT t2.prevision5
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision5 IS NOT NULL)
	WHERE idupb like @idupb
END
ELSE -- @ayear specificato
BEGIN 
	DECLARE @minlevelusable tinyint
	SELECT @minlevelusable = min(nlevel) from accountlevel where ayear = @ayear and flagusable='S'

	DELETE FROM upbaccounttotal WHERE EXISTS(SELECT account.idacc FROM account
					 WHERE account.idacc = upbaccounttotal.idacc AND account.ayear = @ayear) 
					 AND idupb like @idupb

	INSERT INTO upbaccounttotal (idacc, idupb, previsionvariation, previsionvariation2, previsionvariation3,
				 previsionvariation4,previsionvariation5) 
	SELECT   acc_parent.idacc, D.idupb,
				sum(D.amount ),
				sum(D.amount2 ),
				sum(D.amount3 ),
				sum(D.amount4 ),
				sum(D.amount5 )	
	from accountvardetail D 
			join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join account A ON D.idacc=A.idacc
			join account  acc_parent ON A.idacc like acc_parent.idacc+'%' and A.ayear=acc_parent.ayear
			
			where V.idaccountvarstatus = 5 and V.variationkind <> 5 and A.ayear = @ayear and D.idupb like @idupb
	group by acc_parent.idacc, D.idupb

	INSERT INTO upbaccounttotal (idacc, idupb, previsionvariation, previsionvariation2, previsionvariation3,
				 previsionvariation4,previsionvariation5)
	SELECT DISTINCT acc_parent.idacc, IY.idupb, 0,0,0,0,0
	FROM account A
	join account  acc_parent ON A.idacc like acc_parent.idacc+'%' and A.ayear=acc_parent.ayear
	JOIN epexpyear IY
		ON IY.idacc = A.idacc
	WHERE A.ayear = @ayear AND NOT EXISTS
		(SELECT upbaccounttotal.idacc FROM upbaccounttotal
		WHERE upbaccounttotal.idacc = acc_parent.idacc AND upbaccounttotal.idupb = IY.idupb)
		and IY.idupb like @idupb


	INSERT INTO upbaccounttotal (idacc, idupb, previsionvariation, previsionvariation2, previsionvariation3,
				 previsionvariation4,previsionvariation5)
	SELECT DISTINCT acc_parent.idacc, IY.idupb, 0,0,0,0,0
	FROM account A
	join account  acc_parent ON A.idacc like acc_parent.idacc+'%' and A.ayear=acc_parent.ayear
	JOIN epaccyear IY
		ON IY.idacc = A.idacc
	WHERE A.ayear = @ayear AND NOT EXISTS
		(SELECT upbaccounttotal.idacc FROM upbaccounttotal
		WHERE upbaccounttotal.idacc = acc_parent.idacc AND upbaccounttotal.idupb = IY.idupb)
		and IY.idupb like @idupb
			
	INSERT INTO upbaccounttotal (idacc, idupb, previsionvariation, previsionvariation2, previsionvariation3,
				 previsionvariation4,previsionvariation5) 
	SELECT DISTINCT acc_parent.idacc, FY.idupb,0,0,0,0,0		
		
	FROM account A
	join account  acc_parent ON A.idacc like acc_parent.idacc+'%' and A.ayear=acc_parent.ayear
	JOIN accountyear FY
		ON FY.idacc = A.idacc
	WHERE A.ayear = @ayear
		AND  ( 
			ISNULL(FY.prevision,0) <> 0 OR
			ISNULL(FY.prevision2,0) <> 0 OR
			ISNULL(FY.prevision3,0) <> 0 OR
			ISNULL(FY.prevision4,0) <> 0 OR
			ISNULL(FY.prevision5,0) <> 0
		)
	AND NOT EXISTS
		(SELECT upbaccounttotal.idacc FROM upbaccounttotal
		WHERE upbaccounttotal.idacc = acc_parent.idacc AND upbaccounttotal.idupb = FY.idupb)

	AND  FY.idupb like @idupb


	UPDATE upbaccounttotal SET 
	currentprev = 
		(SELECT t2.prevision
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision IS NOT NULL)
	FROM account WHERE	account.idacc = upbaccounttotal.idacc AND account.ayear = @ayear 
	and upbaccounttotal.idupb like @idupb

	UPDATE upbaccounttotal SET 
	currentprev2 = 
		(SELECT t2.prevision2
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision2 IS NOT NULL)
	FROM account WHERE	account.idacc = upbaccounttotal.idacc AND account.ayear = @ayear
	and upbaccounttotal.idupb like @idupb

	UPDATE upbaccounttotal SET 
	currentprev3 = 
		(SELECT t2.prevision3
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision3 IS NOT NULL)
	FROM account WHERE	account.idacc = upbaccounttotal.idacc AND account.ayear = @ayear
	and upbaccounttotal.idupb like @idupb

	UPDATE upbaccounttotal SET 
	currentprev4 = 
		(SELECT t2.prevision4
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision4 IS NOT NULL)
	FROM account WHERE	account.idacc = upbaccounttotal.idacc AND account.ayear = @ayear
	and upbaccounttotal.idupb like @idupb

	UPDATE upbaccounttotal SET 
		currentprev5 = 
		(SELECT t2.prevision5
		FROM accountyear t2
		WHERE t2.idacc = upbaccounttotal.idacc
			AND t2.idupb = upbaccounttotal.idupb
			AND t2.prevision5 IS NOT NULL)
	FROM account WHERE	account.idacc = upbaccounttotal.idacc AND account.ayear = @ayear
	and upbaccounttotal.idupb like @idupb
	
END

DECLARE @nlevel tinyint
SELECT @nlevel = MAX(nlevel) FROM accountlevel
WHILE (@nlevel>0)
BEGIN
	IF (@ayear IS NULL)
	BEGIN
		
	UPDATE upbaccounttotal SET 
		currentprev =
			(SELECT SUM(t2.currentprev)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev IS NULL
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb
	
	UPDATE upbaccounttotal SET 
		currentprev2 =
			(SELECT SUM(t2.currentprev2)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev2 IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev2 IS NULL
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb
	
	UPDATE upbaccounttotal SET 
		currentprev3 =
			(SELECT SUM(t2.currentprev3)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev3 IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev3 IS NULL
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb
				
	UPDATE upbaccounttotal SET 
		currentprev4 =
			(SELECT SUM(t2.currentprev4)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev4 IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev4 IS NULL
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb
	
	UPDATE upbaccounttotal SET 
		currentprev5 =
			(SELECT SUM(t2.currentprev5)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev5 IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev5 IS NULL
			and account.nlevel <= @minlevelusable	
			and upbaccounttotal.idupb like @idupb
			
	END
	ELSE
	BEGIN
		UPDATE upbaccounttotal SET 
		currentprev =
			(SELECT SUM(t2.currentprev)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev IS NULL
			and account.ayear=@ayear
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb

	UPDATE upbaccounttotal SET 
		currentprev2 =
			(SELECT SUM(t2.currentprev2)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev2 IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev2 IS NULL
			and account.ayear=@ayear
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb
				
	UPDATE upbaccounttotal SET 
		currentprev3 =
			(SELECT SUM(t2.currentprev3)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev3 IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev3 IS NULL
			and account.ayear=@ayear
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb
				
	UPDATE upbaccounttotal SET 
		currentprev4 =
			(SELECT SUM(t2.currentprev4)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev4 IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev4 IS NULL
			and account.ayear=@ayear
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb
				
	UPDATE upbaccounttotal SET 
		currentprev5 =
			(SELECT SUM(t2.currentprev5)
			FROM upbaccounttotal t2
			JOIN account A
				ON A.idacc = t2.idacc
			WHERE t2.currentprev5 IS NOT NULL
				AND A.paridacc = upbaccounttotal.idacc
				AND t2.idupb = upbaccounttotal.idupb) 
		FROM account
		WHERE account.idacc = upbaccounttotal.idacc
			AND account.nlevel = @nlevel
			AND currentprev5 IS NULL
			and account.ayear=@ayear
			and account.nlevel <= @minlevelusable
			and upbaccounttotal.idupb like @idupb
				
	END
	PRINT 'iterazione ' + CONVERT(varchar(4),@nlevel)
	SET @nlevel = @nlevel - 1
END
	
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
