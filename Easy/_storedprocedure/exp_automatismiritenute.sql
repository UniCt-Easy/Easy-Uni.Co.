
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_automatismiritenute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_automatismiritenute]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [exp_automatismiritenute]
	@ayear int, 
	@idreg int, 
	@tax   int,
	@idser int,  
	@start date,
	@stop  date,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

AS
BEGIN

DECLARE @maxincomephase tinyint
SELECT @maxincomephase = MAX(nphase) FROM incomephase

DECLARE @maxexpensephase tinyint
SELECT @maxexpensephase = MAX(nphase) FROM expensephase



create table #out(
	taxdescription varchar(150),
	taxtaxref varchar(50),
	idexp int,
	idinc int,
	ntaxpay int, ytaxpay int,
	phase varchar(50),
	ymov int,
	nmov int,
	codefin varchar(50),
	finance varchar(200),
	codeupb varchar(50),
	upb varchar(200),
	registry varchar(150),
	manager varchar(150),
	ypay int,
	npay int,
	ypro  int,
	npro  int,
	doc varchar(50),
	description varchar(200),
	curramount decimal(19,2),
	adate datetime,
	npaymenttransmission int,
	nproceedstransmission int,
	transmissiondate datetime,
	idpayment int
)
insert into #out(
	taxdescription,	taxtaxref ,	idexp,	
	phase , ymov, nmov, 
	ntaxpay, ytaxpay,
	codefin,finance,codeupb,upb,registry,ypay,npay,doc,description,curramount,
	adate,npaymenttransmission,transmissiondate, idpayment)
SELECT
	tax.description, tax.taxref, EL_AUTO.idexp, 
	E_AUTO.phase ,E_AUTO.ymov, E_AUTO.nmov , 
	expensetax.ntaxpay, expensetax.ytaxpay,
	E_AUTO.codefin,E_AUTO.finance,E_AUTO.codeupb,E_AUTO.upb,E_AUTO.registry,E_AUTO.ypay,E_AUTO.npay,E_AUTO.doc,E_AUTO.description,E_AUTO.curramount,
	E_AUTO.adate,E_AUTO.npaymenttransmission,E_AUTO.transmissiondate, E_AUTO.idpayment
FROM  expenselast ELP
join expenseview E_AUTO on ELP.idexp = E_AUTO.idpayment and E_AUTO.nphase = 3
JOIN expenselast EL_AUTO	on E_AUTO.idexp = EL_AUTO.idexp
join expensetax on E_AUTO.idpayment = expensetax.idexp and E_AUTO.autocode = expensetax.taxcode
JOIN tax				ON tax.taxcode = expensetax.taxcode
WHERE 	(ELP.idser = @idser  OR @idser is null) 
	and (E_AUTO.adate BETWEEN @start AND @stop )
	and E_AUTO.nphase = @maxexpensephase
	and  E_AUTO.ymov = @ayear       
	and E_AUTO.idpayment is not null
	AND E_AUTO.ayear = @ayear   
    AND (E_AUTO.autocode = @tax OR @tax IS NULL)
    AND ( E_AUTO.idreg = @idreg OR @idreg IS NULL )
	AND (@idsor01 IS NULL OR E_AUTO.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR E_AUTO.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR E_AUTO.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR E_AUTO.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR E_AUTO.idsor05 = @idsor05)
	--and E_AUTO.idpayment='503992'

insert into #out(
	taxdescription,	taxtaxref ,	idinc,	
	phase ,ymov,nmov,
	ntaxpay, ytaxpay,
	codefin,finance,codeupb,upb,registry, ypay,npay,doc,description,curramount,
	adate,nproceedstransmission,transmissiondate, idpayment)
SELECT
	tax.description, tax.taxref,EL_AUTO.idinc, 
	E_AUTO.phase ,E_AUTO.ymov,E_AUTO.nmov ,
	expensetax.ntaxpay, expensetax.ytaxpay,
	E_AUTO.codefin,E_AUTO.finance,E_AUTO.codeupb,E_AUTO.upb,E_AUTO.registry,E_AUTO.ypro,E_AUTO.npro,E_AUTO.doc,E_AUTO.description,E_AUTO.curramount,
	E_AUTO.adate,E_AUTO.nproceedstransmission,E_AUTO.transmissiondate, E_AUTO.idpayment
FROM expenselast ELP
join incomeview E_AUTO on ELP.idexp = E_AUTO.idpayment and E_AUTO.nphase = 3
JOIN incomelast EL_AUTO	on E_AUTO.idinc = EL_AUTO.idinc
join expensetax on E_AUTO.idpayment = expensetax.idexp and E_AUTO.autocode = expensetax.taxcode
JOIN tax				ON tax.taxcode = expensetax.taxcode
WHERE 	(ELP.idser = @idser  OR @idser is null) 
	and (E_AUTO.adate BETWEEN @start AND @stop )
	and E_AUTO.nphase = @maxincomephase
	and  E_AUTO.ymov = @ayear       
	and E_AUTO.idpayment is not null
	AND E_AUTO.ayear = @ayear   
    AND (E_AUTO.autocode = @tax OR @tax IS NULL)
    AND ( E_AUTO.idreg = @idreg OR @idreg IS NULL )
	AND (@idsor01 IS NULL OR E_AUTO.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR E_AUTO.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR E_AUTO.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR E_AUTO.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR E_AUTO.idsor05 = @idsor05)
	--and E_AUTO.idpayment='503992'


 select 
 
	taxdescription as'Imposta' ,	taxtaxref as 'Codice imposta',
	idpayment as'idexp Pagamento',
	idexp as 'idexp Auto',
	idinc as 'idinc Auto',
    phase as Fase,
	ymov as 'Eserc.Mov. Auto',
	nmov as 'N.Mov. Auto',
	registry as 'Anagrafica',
	doc as'Doc',
	description as 'Descrizione',
	curramount as 'Importo',
	adate as 'Data Contabile',
	ypay as 'Eserc.Manadato',
	npay as 'Num.Mandato',
	ypro as'Eserc.Reversale' ,
	npro  as 'Num.Reversale',
	npaymenttransmission as 'N.Distinta Pag.',
	nproceedstransmission as 'N.Distinta Inc.',
	transmissiondate as 'Data trasmissione',
	ntaxpay as 'Num.Liquidazione',
	ytaxpay as 'Eserc.Liquidazione',
	codefin as 'Cod.Bilancio',
	finance as'Bilancio',
	codeupb as 'Cod.UPB',
	upb as 'UPB'
	from #out
	--where idpayment='503992'
	 order by idpayment, doc, description


END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--exec exp_automatismiritenute 2020, null, null, null, '01-01-2020',  '05-05-2020'


go
