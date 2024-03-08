
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


-- setuser'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[show_budget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_budget]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec show_budget {ts '2016-03-31 00:00:00'},'000100020096','160002000300010004'

CREATE        PROCEDURE [show_budget]
	@date datetime,
	@idupb varchar(36), 
	@idacc varchar(38) 
AS
BEGIN

DECLARE	@ayear int 
SELECT  @ayear = YEAR(@date)

-- Tabella della situazione 
CREATE TABLE #situation	(value varchar(200), amount decimal(19,2), kind char(1))

DECLARE	@levelusable tinyint -- Livello operativo del Piano dei conti
SELECT  @levelusable = MIN(nlevel) FROM accountlevel WHERE ayear =@ayear and flagusable = 'S'

DECLARE	@codeacc varchar(50) -- Codice del Conto
DECLARE	@acctitle varchar(150) -- Descrizione del Conto 
DECLARE	@nlevel tinyint  -- Livello del Conto
DECLARE	@leveldesc varchar(50)
SELECT  @nlevel = nlevel, 
	    @codeacc = codeacc,
	    @acctitle = title 	
FROM    account  
WHERE   idacc = @idacc

SELECT @leveldesc = description 
FROM accountlevel  
WHERE ayear = @ayear AND @nlevel = nlevel

DECLARE @upbtitle varchar(200)
DECLARE @codeupb varchar(50)
SELECT  @upbtitle = title,  @codeupb = codeupb
FROM    upb
WHERE   idupb = @idupb

-- Previsione Principale
DECLARE	@mainprev decimal(19,2) 

IF (@nlevel < @levelusable) OR (@nlevel IS NULL)
	BEGIN
		print 'Then '
		SELECT @mainprev = SUM(ISNULL(AP.prevision,0)) 
		FROM accountprevisionview AP
		WHERE AP.nlevel  = @levelusable
                        AND AP.ayear  =@ayear
        		AND AP.idupb = @idupb
        	        AND AP.nlevel = @levelusable
                        AND SUBSTRING(idacc, 1, DATALENGTH(@idacc)) = @idacc	
	END
ELSE
	BEGIN
	SELECT @mainprev = prevision
		FROM accountyear
		WHERE idacc = @idacc
		        AND idupb = @idupb
                        AND ayear = @ayear
	END


-- Variazione della previsione
DECLARE	@mainprev_var decimal(19,2) 


SELECT @mainprev_var = SUM(AVD.amount)
FROM accountvardetail AVD  
JOIN accountvar AV
	ON AV.yvar = AVD.yvar
	AND AV.nvar = AVD.nvar
WHERE   SUBSTRING(AVD.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
	AND AV.adate <=	@date
	AND AV.yvar = @ayear
	AND AVD.idupb = @idupb
	AND AV.variationkind  IN ( 1,3,4 ) -- normale o assestamento o storno
	AND AV.idaccountvarstatus = 5

DECLARE	@departmentname varchar(150) -- Nome del Dipartimento

SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')

declare @iscosto int
declare @isricavo int
declare @flag int

select @flag = isnull(flagaccountusage,0) from account where idacc = @idacc
set @iscosto= @flag & 64
set @isricavo= @flag & 128


DECLARE @currmainprev decimal(19,2) -- Previsione Attuale Principale

SET @currmainprev = ISNULL(@mainprev,0) + ISNULL(@mainprev_var,0)

INSERT INTO #situation	
	VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation	
	VALUES ('Situazione XXX al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation
	VALUES (@codeupb + ' - ' + @upbtitle, NULL, 'H')
INSERT INTO #situation	
	VALUES (@leveldesc + ' ' + @codeacc, NULL, 'H')
INSERT INTO #situation	
	VALUES (@acctitle,	NULL, 'H')
INSERT INTO #situation	
	VALUES ('Esercizio ' + CONVERT(char(4),	@ayear), NULL, 'H')
INSERT INTO #situation	
	VALUES ('', NULL, 'N')

INSERT INTO #situation	
	VALUES ('Budget iniziale '  , @mainprev, '')
	
	INSERT INTO #situation	
	VALUES ('Variazioni di Budget '  , @mainprev_var,	'')
	
	INSERT INTO #situation	
	VALUES ('Budget attuale '  , ISNULL(@currmainprev, 0), 'S')

-- Totale Impegni

--if (@iscosto <>0) 
--BEGIN
		DECLARE @totpreimpegni decimal(19,2) 
		DECLARE @totpreimpegniflagvar decimal(19,2)

		SELECT  @totpreimpegni = ISNULL(SUM(epexpyear.amount),0)
			FROM epexp
			JOIN epexpyear
			  ON epexp.idepexp = epexpyear.idepexp
			WHERE epexp.adate <= @date
        			and epexpyear.ayear = @ayear
						and SUBSTRING(epexpyear.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
						and epexpyear.idupb = @idupb
						and nphase = 1
						and isnull(epexp.flagvariation,'N')='N'
		set @totpreimpegni= isnull(@totpreimpegni,0)
		SELECT  @totpreimpegniflagvar = ISNULL(SUM(epexpyear.amount),0)
			FROM epexp
			JOIN epexpyear
			  ON epexp.idepexp = epexpyear.idepexp
			WHERE epexp.adate <= @date
			 AND  epexpyear.ayear = @ayear
						and SUBSTRING(epexpyear.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
						and epexpyear.idupb = @idupb
						and nphase = 1
						and isnull(epexp.flagvariation,'N')='S'

		set @totpreimpegniflagvar= isnull(@totpreimpegniflagvar,0)                
		set @totpreimpegni = @totpreimpegni -@totpreimpegniflagvar


		-- Totale Variazioni Impegni
		DECLARE @totvarpreimpegni decimal(19,2) 
		DECLARE @totvarpreimpegniflagvar decimal(19,2) 

		SELECT @totvarpreimpegni = ISNULL(SUM(epexpvar.amount),0)
			FROM epexp
			JOIN epexpyear
			  ON epexp.idepexp = epexpyear.idepexp
			 AND  epexpyear.ayear = @ayear
			JOIN epexpvar
			  ON epexp.idepexp = epexpvar.idepexp
			where epexp.adate <= @date
			and  epexpvar.adate <= @date
						and epexpvar.yvar = @ayear
						and SUBSTRING(epexpyear.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
						and epexpyear.idupb = @idupb
						and nphase = 1
						and isnull(epexp.flagvariation,'N')='N'
		set @totvarpreimpegni= isnull(@totvarpreimpegni,0)                


		SELECT @totvarpreimpegniflagvar = ISNULL(SUM(epexpvar.amount),0)
			FROM epexp
			JOIN epexpyear
			  ON epexp.idepexp = epexpyear.idepexp
			 AND  epexpyear.ayear = @ayear
			JOIN epexpvar
			  ON epexp.idepexp = epexpvar.idepexp
			where epexp.adate <= @date
			and  epexpvar.adate <= @date
						and epexpvar.yvar = @ayear
						and SUBSTRING(epexpyear.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
						and epexpyear.idupb = @idupb
						and nphase = 1
						and isnull(epexp.flagvariation,'N')='S'
		set @totvarpreimpegniflagvar= isnull(@totvarpreimpegniflagvar,0)                

		set @totvarpreimpegni = @totvarpreimpegni-@totvarpreimpegniflagvar

	if( isnull(@totpreimpegni,0) + isnull(@totvarpreimpegni,0) <>0)		
	Begin
		INSERT INTO #situation	  VALUES('1) Preimpegni '  , @totpreimpegni, '')
		INSERT INTO #situation	 VALUES('2) Variazioni Preimpegni '    , @totvarpreimpegni, '')
		INSERT INTO #situation   VALUES('3) Totale Preimpegni (incluse le variazioni) '  , ISNULL(@totpreimpegni,0) + ISNULL(@totvarpreimpegni,0),'')
  
		INSERT INTO #situation 
        VALUES('Disponibilità per ulteriori Preimpegni (Budget attuale - 3)',
			ISNULL(@currmainprev, 0) -
			ISNULL(@totpreimpegni, 0) -
			ISNULL(@totvarpreimpegni, 0)
			, 'S')
	End
			
--END

--if (@isricavo<>0) 
--begin
		DECLARE @totpreaccertamenti decimal(19,2) 
		DECLARE @totpreaccertamentiflagvar decimal(19,2)

		SELECT  @totpreaccertamenti = ISNULL(SUM(epaccyear.amount),0)
			FROM epacc
			JOIN epaccyear
			  ON epacc.idepacc = epaccyear.idepacc
			 AND  epaccyear.ayear = @ayear
			WHERE epacc.adate <= @date
        			and epacc.yepacc = @ayear
						and SUBSTRING(epaccyear.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
						and epaccyear.idupb = @idupb
						and nphase = 1
						and isnull(epacc.flagvariation,'N')='N'

		set @totpreaccertamenti= isnull(@totpreaccertamenti,0)
		SELECT  @totpreaccertamentiflagvar = ISNULL(SUM(epaccyear.amount),0)
			FROM epacc
			JOIN epaccyear
			  ON epacc.idepacc = epaccyear.idepacc
			 AND  epaccyear.ayear = @ayear
			WHERE epacc.adate <= @date
        			and epacc.yepacc = @ayear
						and SUBSTRING(epaccyear.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
						and epaccyear.idupb = @idupb
						and nphase = 1
						and isnull(epacc.flagvariation,'N')='S'

		set @totpreaccertamentiflagvar= isnull(@totpreaccertamentiflagvar,0)                
		set @totpreaccertamenti = @totpreaccertamenti -@totpreaccertamentiflagvar


		-- Totale Variazioni Impegni
		DECLARE @totvarpreaccertamenti decimal(19,2) 
		DECLARE @totvarpreaccertamentiflagvar decimal(19,2) 

		SELECT @totvarpreaccertamenti = ISNULL(SUM(epaccvar.amount),0)
			FROM epacc
			JOIN epaccyear
			  ON epacc.idepacc = epaccyear.idepacc
			 AND  epaccyear.ayear = @ayear
			JOIN epaccvar
			  ON epacc.idepacc = epaccvar.idepacc
			where epacc.adate <= @date
			and  epaccvar.adate <= @date
						and epaccvar.yvar = @ayear
						and SUBSTRING(epaccyear.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
						and epaccyear.idupb = @idupb
						and nphase = 1
						and isnull(epacc.flagvariation,'N')='N'
		set @totvarpreaccertamenti= isnull(@totvarpreaccertamenti,0)                


		SELECT @totvarpreaccertamentiflagvar = ISNULL(SUM(epaccvar.amount),0)
			FROM epacc
			JOIN epaccyear
			  ON epacc.idepacc = epaccyear.idepacc
			 AND  epaccyear.ayear = @ayear
			JOIN epaccvar
			  ON epacc.idepacc = epaccvar.idepacc
			where epacc.adate <= @date
			and  epaccvar.adate <= @date
						and epaccvar.yvar = @ayear
						and SUBSTRING(epaccyear.idacc, 1, DATALENGTH(@idacc)) like  @idacc+'%'
						and epaccyear.idupb = @idupb
						and nphase = 1
						and isnull(epacc.flagvariation,'N')='S'
		set @totvarpreaccertamentiflagvar= isnull(@totvarpreaccertamentiflagvar,0)                

		set @totvarpreaccertamenti = @totvarpreaccertamenti-@totvarpreaccertamentiflagvar

	if(isnull(@totpreaccertamenti,0) + isnull(@totvarpreaccertamenti,0)<>0	)	
	Begin
		INSERT INTO #situation	  VALUES('1) Preaccertamenti '  , @totpreaccertamenti, '')
		INSERT INTO #situation	 VALUES('2) Variazioni Preaccertamenti '    , @totvarpreaccertamenti, '')
		INSERT INTO #situation   VALUES('3) Totale Preaccertamenti (incluse le variazioni) '  , ISNULL(@totpreaccertamenti,0) + ISNULL(@totvarpreaccertamenti,0),'')
		INSERT INTO #situation 
			VALUES('Disponibilità per ulteriori Preaccertamenti (Budget attuale - 3)',
				ISNULL(@currmainprev, 0) -
				ISNULL(@totpreaccertamenti, 0) -
				ISNULL(@totvarpreaccertamenti, 0)
				, 'S')
	End
--end


	
SELECT value, amount, kind FROM #situation



END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec show_budget {ts '2016-09-08 00:00:00'}, '00010007' ,  '1600020005'
















 
