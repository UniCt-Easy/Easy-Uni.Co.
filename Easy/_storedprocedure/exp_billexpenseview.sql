
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_billexpenseview]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_billexpenseview]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--		EXEC exp_billexpenseview 2021, {ts '2021-01-01 00:00:00'}, {ts '2021-12-31 00:00:00'}
CREATE   PROCEDURE [exp_billexpenseview]
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

DECLARE @maxphase tinyint
SELECT @maxphase = MAX(nphase) FROM expensephase

CREATE TABLE #Mybanktransaction (
	yban smallint,
	nban int,
	amount decimal(19,2) ,
--	bankreference varchar(50) NULL,
	idbankimport int ,
	idexp int ,
	idinc int ,
--	idpay int NULL,
--	idpro int NULL,
	kind char(1) ,
--	kpay int NULL,
--	kpro int NULL,
	nbill int ,
	transactiondate date ,
	valuedate date 
	)

	insert into #Mybanktransaction(transactiondate,	amount,  idexp)
	select transactiondate,	amount, idexp
	from banktransaction
	where yban = @ayear and kind = 'D' 

	CREATE TABLE #dati	(
	 adateapertura date,
	 total decimal(19,2),
	 covered decimal(19,2),
	 nbill int,
	 fase varchar(150),
	 ymov int,
	 nmov int,
	 adate date,
	 codefin varchar(50),
	 fin varchar(150),
	 codeupb varchar(50),
	 upb varchar(150),
	 registry varchar(100),
	 cf varchar(16),
	 piva varchar(15),
	 manager varchar(150),
	 ypay int,
	 npay int,
	 idpay int,
	 doc varchar(35),
	 docdate date,
	 description varchar(150),
	 amount decimal(19,2),
	 ayearstartamount decimal(19,2),
	 curramount  decimal(19,2),
	 available  decimal(19,2),
	 transactiondate date,
	 banktransaction_amount decimal(19,2),
	 perc_esitato decimal(19,6),
	 non_esitato  decimal(19,2),
	 perc_non_esitato  decimal(19,6),
	 npaymenttransmission int,
	 transmissiondate date,
	 cigcode varchar(10),
	 cupcode varchar(15),
	 codeaccdebit varchar(50),
	 accountdebit varchar(150),
	 cu varchar(64),
	 lu varchar(64)
	 )
-- BOLLETTE ASSOCIATE DIRETTAMENTE AL MOVIMENTO

insert into  #dati	(
	 adateapertura ,	 total ,	covered, nbill ,
	 fase ,	 ymov ,	 nmov ,	 adate ,
	 codefin ,	 fin ,	 codeupb ,	 upb ,
	 registry,	 cf ,	 piva ,	 manager ,
	 ypay ,	 npay ,	 idpay ,
	 doc ,	 docdate ,	 description ,
	 amount ,	 ayearstartamount ,	 curramount  ,	 available  ,
	 transactiondate ,	 banktransaction_amount ,
	 perc_esitato ,	 
	 non_esitato  ,	 perc_non_esitato  ,
	 npaymenttransmission ,	 transmissiondate ,
	 cigcode ,	 cupcode ,
	 codeaccdebit ,	 accountdebit ,
	 cu,	 lu )
select 
	 B.adate ,	 B.total ,	E.curramount, B.nbill,
	 E.phase ,	 E.ymov,	 E.nmov,	 E.adate,
	 E.codefin ,	 E.finance,	 E.codeupb ,	 E.upb,
	 E.registry ,	 E.CF,	 E.p_iva,	 E.manager,
	 E.ypay,	 E.npay,	 E.idpay,
	 E.doc,	 E.docdate,	 E.description,
	 E.amount ,	 E.ayearstartamount,	 E.curramount,	 E.available,
	 BT.transactiondate ,	 BT.amount ,
	 case when ((isnull(b.total,0) - isnull(b.reduction,0))>0) 
		then  convert(decimal(19,6), ( BT.amount/((isnull(b.total,0)-isnull(b.reduction,0))  ) )) 
		else 0
		end, -- '% esitato dal movimento',
	 null ,-- 'Importo non esitato',
	0 ,-- '% non esitato dal movimento',
	 E.npaymenttransmission,	 E.transmissiondate,
	 E.cigcode,	 E.cupcode,
	 E.codeaccdebit,	 E.accountdebit,
	 E.cu,	 E.lu
from billview B	
	join expenseview E
			ON E.nbill = B.nbill and E.ymov = @ayear and E.nphase = @maxphase
	LEFT OUTER join #Mybanktransaction BT on BT.nbill = B.nbill and BT.yban = @ayear and BT.kind = 'D' and  BT.idexp = E.idexp
where B.ybill = @ayear
	and B.billkind = 'D'
	--and b.nbill = 19
	and B.adate between @start and @stop
	AND (@idsor01 IS NULL OR B.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR B.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR B.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR B.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR B.idsor05 = @idsor05)

	
	--MOVIMENTI CON ASSOCIAZIONE MULTIPLA
insert into  #dati	(
	 adateapertura ,	 total ,	covered, nbill ,
	 fase ,	 ymov ,	 nmov ,	 adate ,
	 codefin ,	 fin ,	 codeupb ,	 upb ,
	 registry,	 cf ,	 piva ,	 manager ,
	 ypay ,	 npay ,	 idpay ,
	 doc ,	 docdate ,	 description ,
	 amount ,	 ayearstartamount ,	 curramount  ,	 available  ,
	 transactiondate ,	 banktransaction_amount ,
	 perc_esitato ,	 
	 non_esitato  ,	 perc_non_esitato  ,
	 npaymenttransmission ,	 transmissiondate ,
	 cigcode ,	 cupcode ,
	 codeaccdebit ,	 accountdebit ,
	 cu,	 lu )
select 
	 B.adate ,	 B.total ,	 
	isnull(EB.amount,0),
	 B.nbill,
	 E.phase ,	 E.ymov,	 E.nmov,	 E.adate,
	 E.codefin ,	 E.finance,	 E.codeupb ,	 E.upb,
	 E.registry ,	 E.CF,	 E.p_iva,	 E.manager,
	 E.ypay,	 E.npay,	 E.idpay,
	 E.doc,	 E.docdate,	 E.description,
	 E.amount ,	 E.ayearstartamount,	 E.curramount,	 E.available,
	 BT.transactiondate ,	 BT.amount ,
	 case when ((isnull(b.total,0) - isnull(b.reduction,0))>0) 
		then  convert(decimal(19,6), ( BT.amount/((isnull(b.total,0)-isnull(b.reduction,0))  ) )) 
		else 0
		end, -- '% esitato dal movimento',
	 null ,-- 'Importo non esitato',
	0 ,-- '% non esitato dal movimento',
	 E.npaymenttransmission,	 E.transmissiondate,
	 E.cigcode,	 E.cupcode,
	 E.codeaccdebit,	 E.accountdebit,
	 E.cu,	 E.lu
from billview B	
	 join expensebill EB 
			on B.nbill = EB.nbill and  B.ybill = EB.ybill
	join expenseview E on EB.idexp = E.idexp
	left outer join #Mybanktransaction BT on BT.nbill = B.nbill and BT.yban = @ayear and BT.kind = 'D' and  BT.idexp = EB.idexp
where B.ybill = @ayear
	and B.billkind = 'D'
	--and b.nbill = 19
	and B.adate between @start and @stop
	AND (@idsor01 IS NULL OR B.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR B.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR B.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR B.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR B.idsor05 = @idsor05)
	
	-- BOLLETTE ASSOCIATE AL FONDO ECONOMALE
insert into  #dati	(
	 adateapertura ,	 total ,	 covered, nbill ,
	 fase ,	 ymov ,	 nmov ,	 adate ,
	 codefin ,	 fin ,	 codeupb ,	 upb ,
	 registry,	 cf ,	 piva ,	 manager ,
	 ypay ,	 npay ,	 idpay ,
	 doc ,	 docdate ,	 description ,
	 amount ,	 ayearstartamount ,	 curramount  ,	 available  ,
	 transactiondate ,	 banktransaction_amount ,
	 perc_esitato ,	 
	 non_esitato  ,	 perc_non_esitato  ,
	 npaymenttransmission 
	 ,	 
	 transmissiondate ,
	 cigcode ,	 cupcode ,
	 codeaccdebit ,	 accountdebit ,
	 cu,	 lu 
	 )
select 
	 B.adate ,	 B.total ,	E.amount,  B.nbill,
	 E.pettycash ,	 E.yoperation,	 E.noperation,	 E.adate,
	 E.codefin ,	 E.finance,	 E.codeupb ,	 E.upb,
	 E.registry ,	null, /*E.CF*/null,	 /*E.p_iva,*/	 E.manager,
	 null, null,null,/*E.ypay,	 E.npay,	 E.idpay,*/
	 E.doc,	 E.docdate,	 E.description,
	 E.amount ,	null, null, null, /*E.ayearstartamount,	 E.curramount,	 E.available,*/
	 BT.transactiondate ,	 BT.amount ,
	 case when ((isnull(b.total,0) - isnull(b.reduction,0))>0) 
		then  convert(decimal(19,6), ( BT.amount/((isnull(b.total,0)-isnull(b.reduction,0))  ) )) 
		else 0
		end, -- '% esitato dal movimento',
	 null,	 -- 'Importo non esitato',
	 0 ,	-- '% non esitato dal movimento',
	 null	,
	 null,		-- E.npaymenttransmission,	 E.transmissiondate,
	 null,null,	-- E.cigcode,	 E.cupcode,
	 null,null,	--E.codeaccdebit,	 E.accountdebit,
	 E.cu,	 E.lu
from billview B	
	join pettycashoperationview	E
			ON  E.yoperation = B.ybill 	AND E.nbill = B.nbill
	left outer join #Mybanktransaction BT on BT.nbill = E.nbill and BT.yban = @ayear and BT.kind = 'D' 
where B.ybill = @ayear
	and B.billkind = 'D'
	--and b.nbill = 19
	and B.adate between @start and @stop
	AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
					WHERE restoreop.yoperation = E.yrestore
					AND restoreop.noperation = E.nrestore
					AND restoreop.idpettycash = E.idpettycash)
	AND (@idsor01 IS NULL OR B.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR B.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR B.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR B.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR B.idsor05 = @idsor05)
	
-- BOLLETTE NON COPERTE, E QUINDI NEANCHE REGOLARIZZATE
insert into  #dati	(
	 adateapertura ,	 total ,	covered, nbill ,
	 fase ,	 ymov ,	 nmov ,	 adate ,
	 codefin ,	 fin ,	 codeupb ,	 upb ,
	 registry,	 cf ,	 piva ,	 manager ,
	 ypay ,	 npay ,	 idpay ,
	 doc ,	 docdate ,	 description ,
	 amount ,	 ayearstartamount ,	 curramount  ,	 available  ,
	 transactiondate ,	 banktransaction_amount ,
	 perc_esitato ,	 
	 non_esitato  ,	 perc_non_esitato  ,
	 npaymenttransmission ,	 transmissiondate ,
	 cigcode ,	 cupcode ,
	 codeaccdebit ,	 accountdebit ,
	 cu,	 lu )

select 
     B.adate , B.total ,	0, B.nbill ,
	 null ,	 null ,	 null,	 null ,
	 null,	 null,	 null ,	 null ,
	 null ,	 null ,	 null ,	 null ,
	 null,	 null,	 null ,
	 null ,	 null ,	 null ,
	 null ,	 null ,	 null ,	 null ,	 null ,
	 null ,
	 0,
	 toregularize, --as 'Importo non esitato',
	 	 case when ((isnull(b.total,0) - isnull(b.reduction,0))>0) 
		then  convert(decimal(19,6), ( B.toregularize/((isnull(b.total,0)-isnull(b.reduction,0))  ) ))
		else 0
		end	,--as '% non esitato dal movimento',
	 null ,
	 null ,
	 null ,
	 null ,
	 null ,
	 null ,
	 null ,
	 null 
from billview B	
where B.ybill = @ayear
	and B.billkind = 'D'
	and B.adate between @start and @stop
	and isnull(B.covered,0) = 0
	--and b.nbill = 19
	AND (@idsor01 IS NULL OR B.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR B.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR B.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR B.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR B.idsor05 = @idsor05)
	
	
select 
	 adateapertura as 'Data apertura Bolletta',
	 nbill as 'n.Bolletta',
	 total  as 'Importo apertura',
	 covered as'Importo coperto',
	 transactiondate as 'Data esitazione',
	 banktransaction_amount as 'Importo esitazione',
	 format(perc_esitato,'P6')  as '% esitato dal movimento',
	 non_esitato as 'Importo non esitato',
	 format(perc_non_esitato,'P6') '% non esitato dal movimento',
	 fase as 'Fase/PS',
	 ymov  as 'Eserc.Mov./Eserc.Op',
	 nmov  as 'Num.Mov./Num.Op',
	 adate as 'Data Contabile',
	 codefin  as 'Voce Bil.',
	 fin as 'Denom. Bil.',
	 codeupb as 'Cod. U.P.B.',
	 upb as 'U.P.B.',
	 registry as 'Percipiente',
	 cf ,
	 piva as 'Piva',
	 manager  as 'Responsabile',
	 ypay as 'Eserc.Mand.',
	 npay as 'Num.Mand.',
	 idpay as 'Num. SUB (trasmissione)',
	 doc as 'Documento',
	 docdate  as 'Data Doc.',
	 description as 'Descrizione',
	 amount as 'Importo Originale',
	 ayearstartamount as 'Imp.Esercizio',
	 curramount as 'Imp.Corrente',
	 --available as 'Disponibile',
	 npaymenttransmission  as 'Distinta Trasmissione',
	 transmissiondate as 'Data Trasmissione',
	 cigcode as 'CIG',
	 cupcode as 'CUP',
	 codeaccdebit as 'Cod.Causale Debito',
	 accountdebit as 'Causale Debito',
	 cu,
	 lu 
	 from #dati
	 order by nbill
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

