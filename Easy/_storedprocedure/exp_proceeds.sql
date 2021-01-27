
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE            PROCEDURE [exp_proceeds]
@ayear int,
@start datetime,
@stop  datetime,
@idupb varchar(36),
@showchildupb char(1),
@codefin varchar(50),
@idman int
AS BEGIN 

SET @codefin = ISNULL(@codefin,'')+'%'
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb+'%' 
END

DECLARE @maxphase tinyint
SELECT @maxphase =  MAX(nphase) FROM incomephase
SELECT 
    MAN.title AS Responsabile,
	F.codefin AS 'Codice Bilancio',
	F.title AS 'Denom. Bilancio' ,
	PHASE.description AS Fase,
	I.ymov  AS 'Eserc. Movimento',
	I.nmov AS 'Num. Movimento',
	I.description AS Descrizione,
	IY.amount AS 'Importo Originale',
	IT.curramount AS 'Importo Corrente',
	I.doc AS 'Documento collegato',
	I.docdate AS 'Data Documento collegato',
	I.adate AS 'Data Contabile Movimento',
	I.expiration AS 'Data Scadenza',
	REG.title AS Percipiente,	
	U.codeupb AS 'Codice UPB',
	U.title AS UPB,
   	CASE
		when (( IT.flag & 1)=0) then 'C/Residui'
		when (( IT.flag & 1)=1) then 'C/Competenza' 
	End AS Competenza,
	PRO.ypro AS 'Eserc. Reversale',
	PRO.npro AS 'Num. Reversale',
	PRO.adate AS 'Data Contabile Reversale',
    PRO.printdate AS 'Data Stampa Reversale',
    T.transmissiondate AS 'Data Trasm. Reversale',
	T.yproceedstransmission AS 'Eserc. Elenco Trasm.',
	T.nproceedstransmission AS 'Num. Elenco Trasm.'
FROM income I (NOLOCK)
JOIN incomephase PHASE (NOLOCK)
	ON PHASE.nphase = I.nphase
JOIN incomeyear IY(NOLOCK)
	ON IY.idinc = I.idinc
JOIN incometotal IT(NOLOCK)
	ON IT.idinc = I.idinc
	AND IT.ayear = IY.ayear
JOIN incomelast IL(NOLOCK)
	ON IL.idinc = I.idinc
LEFT OUTER JOIN fin F (NOLOCK)
	ON F.idfin = IY.idfin
LEFT OUTER JOIN upb U(NOLOCK)
	ON U.idupb = IY.idupb
LEFT OUTER JOIN registry REG(NOLOCK)
	ON REG.idreg = I.idreg
LEFT OUTER JOIN manager MAN(NOLOCK) 
	ON MAN.idman = I.idman
LEFT OUTER JOIN proceeds PRO(NOLOCK)
	ON IL.kpro = PRO.kpro 
LEFT OUTER JOIN proceedstransmission T(NOLOCK)
	ON PRO.kproceedstransmission = T.kproceedstransmission 
WHERE I.adate BETWEEN @start AND @stop 
	AND I.nphase = @maxphase	
	AND IY.ayear = @ayear 
	AND F.codefin LIKE @codefin 
	AND (I.idman = @idman or @idman is null)
	AND (IY.idupb LIKE @idupb)
ORDER BY I.idman, F.codefin, I.nmov
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
