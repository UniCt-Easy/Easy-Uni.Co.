
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mov_blacklistunified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mov_blacklistunified]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE    PROCEDURE [exp_mov_blacklistunified]
(
	@anno int,
	@start smalldatetime,
	@stop smalldatetime,
	@unified char(1)
)
AS
BEGIN

-- [exp_mov_blacklistunified] 2011, {d '2011-01-01'},{d '2011-12-31'},'S'
IF(@unified<>'S')
Begin
	EXEC exp_mov_blacklist @anno, @start, @stop
	RETURN
End

CREATE TABLE #unifiedmovfin (
	iddbdepartment varchar(50),
	phase varchar(50),
	ymov int,
	nmov int,
	adate smalldatetime,
	description varchar(150),
	curramount decimal(19,2),
	ypay int,
	npay int,
	idreg int,
	registry varchar(100),
	blnation varchar(100),
	blcode char(3)
)

CREATE TABLE #unifiedmovfinApp (
	phase varchar(50),
	ymov int,
	nmov int,
	adate smalldatetime,
	description varchar(150),
	curramount decimal(19,2),
	ypay int,
	npay int,
	idreg int,
	registry varchar(100),
	blnation varchar(100),
	blcode char(3)
)
DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR 
SELECT iddbdepartment FROM dbdepartment
WHERE  (start is null or start <= @anno) AND (stop is null or stop >= @anno)

OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.exp_mov_blacklist'

		INSERT INTO #unifiedmovfinApp (
			phase,
			ymov,
			nmov,
			adate,
			description,
			curramount,
			ypay,
			npay,
			idreg,
			registry,
			blnation,
			blcode
		)
        EXEC @dip_nomesp @anno, @start, @stop

		INSERT INTO #unifiedmovfin (
				iddbdepartment,
				phase,
				ymov,
				nmov,
				adate,
				description,
				curramount,
				ypay,
				npay,
				idreg,
				registry,
				blnation,
				blcode
		)
		SELECT @iddbdepartment,
				phase,
				ymov,
				nmov,
				adate,
				description,
				curramount,
				ypay,
				npay,
				idreg,
				registry,
				blnation,
				blcode
		FROM #unifiedmovfinApp

		DELETE FROM #unifiedmovfinApp

	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
end
DEALLOCATE @crsdepartment

SELECT 
	dbdepartment.description as 'Dipartimento',
	phase as 'Fase',
	ymov as 'Eserc.',
	nmov as 'Numero',
	adate as 'Data Contabile',
	#unifiedmovfin.description as 'Descrizione',
	curramount as 'Importo',
	ypay as 'Eserc. Mandato',
	npay as 'Num. Mandato',
	idreg as 'Codice Anagrafica',
	registry as 'Anagrafica',
	blnation as 'Nazione',
	blcode as 'Codice Nazione Black List'
FROM #unifiedmovfin
JOIN dbdepartment
	ON #unifiedmovfin.iddbdepartment = dbdepartment.iddbdepartment
ORDER BY  dbdepartment.description, MONTH(adate), ymov, nmov


END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


