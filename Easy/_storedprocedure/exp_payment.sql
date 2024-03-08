
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amm'
-- setuser 'amministrazione'
-- exec exp_payment 2023, {d '2023-01-01'}, {d '2023-11-06'}, '%', 'N', null, null
CREATE            PROCEDURE [exp_payment]
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

declare @fasecontrattopassivo int
select @fasecontrattopassivo = expensephase from config where ayear=@ayear

DECLARE @expenseregphase	tinyint
SELECT @expenseregphase = expenseregphase FROM  uniconfig

DECLARE @maxphase tinyint
SELECT @maxphase =  MAX(nphase) FROM expensephase

CREATE TABLE #payment
(
	man_title varchar(150),
	fin_codefin varchar(50),
	fin_title varchar(150),
	phase_description varchar(50),
	ymov int, 
	nmov int,
	idexp int,
	expense_description varchar(150),
	exy_amount decimal(19,2),
	curramount decimal(19,2),
	ex_doc varchar(35),
	ex_docdate datetime,
	ex_adate datetime,
	ex_expiration datetime,
	reg_title varchar(150),
	codeupb varchar(50),
	upb_title varchar(150),
	ser_description varchar(50),
	exl_servicestart datetime,
	exl_servicestop datetime,
	flagcr varchar(50),
	pay_ypay int,
	pay_npay int,
	pay_adate datetime,
	pay_printdate datetime,
	transmissiondate datetime,
	ypaymenttransmission int,
	npaymenttransmission int,
	CUP varchar(15),
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15),
	cupcodeexpense varchar(15),
	CIG varchar(10),
	cigcodeexpense varchar(10),
	cigcodemandate varchar(10)
)

insert into #payment
(
	man_title,
	fin_codefin,
	fin_title,
	phase_description,
	ymov, 
	nmov,
	idexp,
	expense_description,
	exy_amount,
	curramount,
	ex_doc,
	ex_docdate,
	ex_adate,
	ex_expiration,
	reg_title,
	codeupb,
	upb_title,
	ser_description,
	exl_servicestart,
	exl_servicestop,
	flagcr,
	pay_ypay,
	pay_npay,
	pay_adate,
	pay_printdate,
	transmissiondate,
	ypaymenttransmission,
	npaymenttransmission,
	cupcodefin,
	cupcodeupb,
	cupcodeexpense,
	cupcodedetail,	
	cigcodeexpense,
	cigcodemandate
)
SELECT 
    MAN.title,
	F.codefin,
	F.title,
	PHASE.description,
	EX.ymov,
	EX.nmov,
	EX.idexp,
	EX.description,
	EXY.amount,
	EXT.curramount,
	EX.doc,
	EX.docdate,
	EX.adate,
	EX.expiration,
	REG.title,	
	U.codeupb,
	U.title,
	SER.description,
	EXL.servicestart,
	EXL.servicestop,
   	CASE
		when (( EXT.flag & 1)=0) then 'C/Residui'
		when (( EXT.flag & 1)=1) then 'C/Competenza' 
	End,
	PAY.ypay,
	PAY.npay,
	PAY.adate,
    PAY.printdate,
    TX.transmissiondate,
	TX.ypaymenttransmission,
	TX.npaymenttransmission,
	ltrim(rtrim(finlast.cupcode)),
	ltrim(rtrim(U.cupcode)),
	ltrim(rtrim(RegPhase.cupcode)),
	null,
	ltrim(rtrim(RegPhase.cigcode)),
	null
FROM expense EX (NOLOCK)
JOIN expensephase PHASE (NOLOCK)				ON PHASE.nphase = EX.nphase
JOIN expenseyear EXY(NOLOCK)					ON EXY.idexp = EX.idexp
JOIN expensetotal EXT(NOLOCK)					ON EXT.idexp = EX.idexp AND EXT.ayear = EXY.ayear
JOIN expenselast EXL(NOLOCK)					ON EXL.idexp = EX.idexp
LEFT JOIN fin F (NOLOCK)						ON F.idfin = EXY.idfin
LEFT JOIN upb U(NOLOCK)							ON U.idupb = EXY.idupb
LEFT JOIN registry REG(NOLOCK)					ON REG.idreg = EX.idreg
LEFT JOIN manager MAN(NOLOCK) 					ON MAN.idman = EX.idman
LEFT JOIN service SER(NOLOCK)					ON SER.idser = EXL.idser
LEFT JOIN payment PAY(NOLOCK)					ON EXL.kpay = PAY.kpay 
LEFT JOIN paymenttransmission TX(NOLOCK)		ON PAY.kpaymenttransmission = TX.kpaymenttransmission 
left join finlast (NOLOCK)						ON finlast.idfin = F.idfin
-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
JOIN expenselink as RegPhaseELK	(NOLOCK)		ON RegPhaseELK.idchild = EXL.idexp AND RegPhaseELK.nlevel = @expenseregphase
-- fase del Creditore
JOIN expense RegPhase (NOLOCK)					ON RegPhase.idexp = RegPhaseELK.idparent
WHERE EX.adate BETWEEN @start AND @stop 
	AND EX.nphase = @maxphase	
	AND EXY.ayear = @ayear 
	AND F.codefin LIKE @codefin 
	AND (EX.idman = @idman or @idman is null)
	AND (EXY.idupb LIKE @idupb)
ORDER BY EX.idman, F.codefin, EX.nmov

-- Valorizza codice cup da eventuali -----
-- contabilizzazioni di dettagli ordine --
UPDATE #payment SET cupcodedetail = 
	   (SELECT MAX( ltrim(rtrim(cupcode)) )
		  FROM mandatedetail
		 WHERE (idexp_taxable IN (SELECT EL1.idparent 
									FROM expenselink EL1
								   WHERE EL1.idchild = #payment.idexp and EL1.nlevel=@fasecontrattopassivo) 
			OR idexp_iva IN (SELECT EL2.idparent 
							   FROM expenselink EL2
							  WHERE EL2.idchild = #payment.idexp and EL2.nlevel=@fasecontrattopassivo))
		   AND cupcode IS NOT NULL)
	where cupcodeexpense is null

-- Valorizza il codice CIG eventualmente presente del contratto passivo
UPDATE #payment SET cigcodemandate = 
	   (SELECT MAX(ltrim(rtrim(mandate.cigcode)) )
			FROM mandate
			JOIN mandatedetail
				ON	mandate.idmankind = mandatedetail.idmankind 
				AND mandate.yman = mandatedetail.yman 
				AND mandate.nman = mandatedetail.nman
		 WHERE (mandatedetail.idexp_taxable IN (SELECT idparent 
									FROM expenselink 
								   WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo) 
			OR mandatedetail.idexp_iva IN (SELECT idparent 
							   FROM expenselink 
							  WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo))
		 )

		where cigcodeexpense is null

-- Valorizza il codice CIG eventualmente presente nella fattura
UPDATE #payment SET cigcodemandate = 
	   (SELECT MAX( invoicedetail.cigcode )
			FROM invoicedetail 
		WHERE (invoicedetail.idexp_taxable = #payment.idexp
				OR invoicedetail.idexp_iva = #payment.idexp)
		)
where cigcodeexpense is null and cigcodemandate is null

UPDATE #payment SET CIG = ISNULL(cigcodeexpense,ISNULL(cigcodemandate,''))
UPDATE #payment SET CUP = ISNULL(cupcodeexpense,ISNULL(cupcodedetail, ISNULL(cupcodeupb, ISNULL(cupcodefin,''))))

SELECT 
	man_title  AS Responsabile,
	fin_codefin AS 'Codice Bilancio',
	fin_title AS 'Denom. Bilancio' ,
	phase_description AS Fase,
	ymov AS 'Eserc. Movimento',
	nmov AS 'Num. Movimento',
	expense_description AS Descrizione,
	exy_amount AS 'Importo Originale',
	curramount AS 'Importo Corrente',
	ex_doc AS 'Documento collegato',
	ex_docdate AS 'Data Documento collegato',
	ex_adate AS 'Data Contabile Movimento',
	ex_expiration AS 'Data Scadenza',
	reg_title AS Percipiente,	
	codeupb AS 'Codice UPB',
	upb_title AS UPB,
	ser_description AS Prestazione,
	exl_servicestart AS 'Data Inizio Prest.',
	exl_servicestop AS 'Data Fine Prest.',
	flagcr AS 'Competenza',
	pay_ypay AS 'Eserc. Mandato',
	pay_npay AS 'Num. Mandato',
	pay_adate AS 'Data Contabile Mandato',
	pay_printdate AS 'Data Stampa Mandato',
	transmissiondate AS 'Data Trasm. Mandato',
	ypaymenttransmission AS 'Eserc. Elenco Trasm.',
	npaymenttransmission AS 'Num. Elenco Trasm.',
	CUP AS 'CUP',
	CIG AS 'CIG'
FROM #payment
order by man_title, fin_codefin, nmov

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
