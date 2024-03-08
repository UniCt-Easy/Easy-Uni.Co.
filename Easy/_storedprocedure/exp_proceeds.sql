
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amm'
-- setuser 'amministrazione'
-- exec exp_proceeds 2023, {d '2023-01-01'}, {d '2023-11-06'}, '%', 'N', null, null
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

DECLARE @incomeregphase	tinyint
SELECT @incomeregphase = incomeregphase FROM uniconfig

DECLARE @maxphase tinyint
SELECT @maxphase =  MAX(nphase) FROM incomephase

CREATE TABLE #proceeds
(
	man_title varchar(150),
	fin_codefin varchar(50),
	fin_title varchar(150),
	phase_description varchar(50),
	ymov int, 
	nmov int,
	income_description varchar(150),
	iy_amount decimal(19,2),
	curramount decimal(19,2),
	i_doc varchar(35),
	i_docdate datetime,
	i_adate datetime,
	i_expiration datetime,
	reg_title varchar(150),
	codeupb varchar(50),
	upb_title varchar(150),
	flagcr varchar(50),
	pro_ypro int,
	pro_npro int,
	pro_adate datetime,
	pro_printdate datetime,
	transmissiondate datetime,
	yproceedstransmission int,
	nproceedstransmission int,
	CUP varchar(15),
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15),
	cupcodeincome varchar(15)
)

insert into #proceeds
(
	man_title,
	fin_codefin,
	fin_title,
	phase_description,
	ymov, 
	nmov,
	income_description,
	iy_amount,
	curramount,
	i_doc,
	i_docdate,
	i_adate,
	i_expiration,
	reg_title,
	codeupb,
	upb_title,
	flagcr,
	pro_ypro,
	pro_npro,
	pro_adate,
	pro_printdate,
	transmissiondate,
	yproceedstransmission,
	nproceedstransmission,
	cupcodefin,
	cupcodeupb,
	cupcodeincome
)
SELECT 
    MAN.title,
	F.codefin,
	F.title,
	PHASE.description,
	I.ymov,
	I.nmov,
	I.description,
	IY.amount,
	IT.curramount,
	I.doc,
	I.docdate,
	I.adate,
	I.expiration,
	REG.title,	
	U.codeupb,
	U.title,
   	CASE
		when (( IT.flag & 1)=0) then 'C/Residui'
		when (( IT.flag & 1)=1) then 'C/Competenza' 
	End,
	PRO.ypro,
	PRO.npro,
	PRO.adate,
    PRO.printdate,
    T.transmissiondate,
	T.yproceedstransmission,
	T.nproceedstransmission,
	finlast.cupcode,
	u.cupcode,
	RegPhase.cupcode
FROM income I (NOLOCK)
JOIN incomephase PHASE (NOLOCK)				ON PHASE.nphase = I.nphase
JOIN incomeyear IY(NOLOCK)					ON IY.idinc = I.idinc
JOIN incometotal IT(NOLOCK)					ON IT.idinc = I.idinc AND IT.ayear = IY.ayear
JOIN incomelast IL(NOLOCK)					ON IL.idinc = I.idinc
LEFT JOIN fin F (NOLOCK)					ON F.idfin = IY.idfin
LEFT JOIN upb U(NOLOCK)						ON U.idupb = IY.idupb
LEFT JOIN registry REG(NOLOCK)				ON REG.idreg = I.idreg
LEFT JOIN manager MAN(NOLOCK) 				ON MAN.idman = I.idman
LEFT JOIN proceeds PRO(NOLOCK)				ON IL.kpro = PRO.kpro 
LEFT JOIN proceedstransmission T(NOLOCK)	ON PRO.kproceedstransmission = T.kproceedstransmission 
left join finlast (NOLOCK)					ON finlast.idfin = F.idfin
-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
JOIN incomelink as RegPhaseELK	(NOLOCK)	ON RegPhaseELK.idchild = IL.idinc AND RegPhaseELK.nlevel = @incomeregphase
-- fase del Creditore
JOIN income RegPhase (NOLOCK)				ON RegPhase.idinc = RegPhaseELK.idparent
WHERE I.adate BETWEEN @start AND @stop 
	AND I.nphase = @maxphase	
	AND IY.ayear = @ayear 
	AND F.codefin LIKE @codefin 
	AND (I.idman = @idman or @idman is null)
	AND (IY.idupb LIKE @idupb)
ORDER BY I.idman, F.codefin, I.nmov

UPDATE #proceeds SET CUP = ISNULL(cupcodeincome,  ISNULL(cupcodeupb, ISNULL(cupcodefin,'')))

SELECT 
    man_title AS 'Responsabile',
	fin_codefin AS 'Codice Bilancio',
	fin_title AS 'Denom. Bilancio' ,
	phase_description AS 'Fase',
	ymov  AS 'Eserc. Movimento',
	nmov AS 'Num. Movimento',
	income_description AS 'Descrizione',
	iy_amount AS 'Importo Originale',
	curramount AS 'Importo Corrente',
	i_doc AS 'Documento collegato',
	i_docdate AS 'Data Documento collegato',
	i_adate AS 'Data Contabile Movimento',
	i_expiration AS 'Data Scadenza',
	reg_title AS 'Percipiente',	
	codeupb AS 'Codice UPB',
	upb_title AS 'UPB',
   	flagcr AS 'Competenza',
	pro_ypro AS 'Eserc. Reversale',
	pro_npro AS 'Num. Reversale',
	pro_adate AS 'Data Contabile Reversale',
    pro_printdate AS 'Data Stampa Reversale',
    transmissiondate AS 'Data Trasm. Reversale',
	yproceedstransmission AS 'Eserc. Elenco Trasm.',
	nproceedstransmission AS 'Num. Elenco Trasm.',
	CUP AS 'CUP'
FROM #proceeds
order by man_title, fin_codefin, nmov

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
