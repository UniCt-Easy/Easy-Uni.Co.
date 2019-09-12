if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fin_finmotive]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fin_finmotive]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 /*
  [exp_fin_finmotive] 2016,'ASSOCIATI' 
  go
  [exp_fin_finmotive] 2016,'BIL_NONASSOC' 
  go
  [exp_fin_finmotive] 2016,'CAUSALINONASSOC' 
  go
  */

CREATE    PROCEDURE [exp_fin_finmotive] 
(
	@ayear int,
	@kind  varchar(20) -- 'ASSOCIATI', 'BIL_NONASSOC', 'CAUSALINONASSOC'
)
AS
BEGIN
IF ISNULL(@kind, 'ASSOCIATI') = 'ASSOCIATI'
BEGIN
	SELECT 
		finmotivedetail.ayear AS 'Esercizio',
		finmotive.codemotive AS 'Codice Causale', 
		finmotive.title AS 'Causale', 
		fin.codefin as 'Codice Bilancio',
		fin.title as 'Bilancio',
   		CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
		End as 'E/S'
	FROM finmotive
		JOIN finmotivedetail
			ON finmotive.idfinmotive = finmotivedetail.idfinmotive
		JOIN fin 
			ON finmotivedetail.idfin = fin.idfin
			AND finmotivedetail.ayear = fin.ayear
	WHERE finmotivedetail.ayear = @ayear
	order by finmotive.codemotive
	RETURN
END

IF ISNULL(@kind, 'ASSOCIATI') = 'BIL_NONASSOC'
BEGIN
SELECT 
	fin.codefin as 'Codice Bilancio',
	fin.title as 'Denominazione Bilancio',
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End as 'E/S'
FROM fin 
join finlast
	on fin.idfin = finlast.idfin
WHERE fin.ayear = @ayear
	AND NOT EXISTS (SELECT * FROM finmotivedetail WHERE finmotivedetail.idfin = fin.idfin
				AND finmotivedetail.ayear = fin.ayear )
order by fin.flag & 1, fin.codefin
RETURN
END 


IF ISNULL(@kind, 'ASSOCIATI') = 'CAUSALINONASSOC'
BEGIN
	SELECT 
	@ayear AS 'Esercizio',
	finmotive.codemotive AS 'Codice Causale', 
	finmotive.title AS 'Denominazione Causale',
	finmotive.active AS 'Attiva',
	PARfinmotive.codemotive AS 'Codice Causale Padre', 
	PARfinmotive.title AS 'Denominazione Causale Padre'

	FROM finmotive 
	LEFT OUTER JOIN finmotive PARfinmotive
		ON PARfinmotive.idfinmotive = finmotive.paridfinmotive 
	WHERE  NOT EXISTS (SELECT * FROM finmotivedetail WHERE finmotivedetail.idfinmotive = finmotive.idfinmotive
			AND finmotivedetail.ayear = @ayear )
	AND NOT EXISTS (SELECT * FROM finmotive CHILD WHERE CHILD.paridfinmotive = finmotive.idfinmotive)
	AND finmotive.active = 'S' 
	order by finmotive.codemotive
END 



END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



