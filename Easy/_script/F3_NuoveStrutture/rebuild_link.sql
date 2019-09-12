if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_expenselink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_expenselink]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_finlink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_finlink]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_incomelink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_incomelink]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rebuild_expenselink
AS BEGIN
	DELETE FROM expenselink

	INSERT INTO expenselink (idchild, nlevel, idparent)
	SELECT idexp, nphase, idexp
	FROM expense

	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO expenselink (idchild, nlevel, idparent)
		SELECT idchild, (nlevel - 1), parentidexp
		FROM expenselink EL
		JOIN expense E
		ON EL.idparent = E.idexp
		WHERE nlevel > 1
		AND NOT EXISTS(SELECT * FROM expenselink EL2 WHERE EL2.idchild = EL.idchild AND EL2.nlevel = (EL.nlevel - 1))
	END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rebuild_finlink
AS BEGIN
	DELETE FROM finlink

	INSERT INTO finlink (idchild, nlevel, idparent)
	SELECT idfin, nlevel, idfin
	FROM fin

	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO finlink (idchild, nlevel, idparent)
		SELECT idchild, (FL.nlevel - 1), paridfin
		FROM finlink FL
		JOIN fin F
		ON FL.idparent = F.idfin
		WHERE FL.nlevel > 1
		AND NOT EXISTS(SELECT * FROM finlink FL2 WHERE FL2.idchild = FL.idchild AND FL2.nlevel = (FL.nlevel - 1))
	END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rebuild_incomelink
AS BEGIN
	DELETE FROM incomelink

	INSERT INTO incomelink (idchild, nlevel, idparent)
	SELECT idinc, nphase, idinc
	FROM income

	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO incomelink (idchild, nlevel, idparent)
		SELECT idchild, (nlevel - 1), parentidinc
		FROM incomelink IL
		JOIN income I
		ON IL.idparent = I.idinc
		WHERE nlevel > 1
		AND NOT EXISTS(SELECT * FROM incomelink IL2 WHERE IL2.idchild = IL.idchild AND IL2.nlevel = (IL.nlevel - 1))
	END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

