if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[calc_matricola_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [dbo].[calc_matricola_csa]

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO

-- exec calc_matricola_csa_test

CREATE PROCEDURE [dbo].[calc_matricola_csa] 

AS BEGIN

DECLARE @origine_dato varchar(10)

SET @origine_dato = '849' -- A

CREATE TABLE #MAX (maxcode int, employkind char(1))

INSERT INTO #MAX(maxcode, employkind)
SELECT MAX(MATRICOLA), 'A' FROM EASY_ANAGRAFICA_8000 WHERE ORIGINE_DATO = @origine_dato

SET @origine_dato = '049' -- D
INSERT INTO #MAX(maxcode, employkind)
SELECT MAX(MATRICOLA), 'D' FROM EASY_ANAGRAFICA_8000 WHERE ORIGINE_DATO = @origine_dato

SELECT maxcode, employkind FROM #MAX

END


GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO