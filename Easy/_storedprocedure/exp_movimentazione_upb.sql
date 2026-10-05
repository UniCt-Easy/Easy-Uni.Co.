/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_movimentazione_upb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_movimentazione_upb]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione'
/*
DECLARE @lista_codeupb AS codeupb_list;
insert into @lista_codeupb values ('AMCE.Immobili di Proprietà'),('AMCE.Rice.Base.NOVARTIS FARMA PATG RTDA'),('AMCE.Rice.Base.RTDA_AIL_AGOP'),('AMCE.INGEGNERIA_MASTER_INSI'),('MATE.Rice');
exec exp_movimentazione_upb '2024', '2024', '3', '3', @lista_codeupb, 'S', null, null, null, null, null
*/
if not exists (select * from systypes where name = 'codeupb_list') begin 
	CREATE TYPE dbo.codeupb_list AS TABLE      (codeupb varchar(50))  
end
GO

CREATE PROCEDURE [exp_movimentazione_upb]
(
	@ayearstart int = null,
	@ayearstop int = null,
	@snphase int = null,
	@enphase int = null,
	@lista_codeupb dbo.codeupb_list READONLY,
	@showchildupb char(1) = 'N',
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
AS BEGIN

	--select * from @lista_codeupb

	DECLARE @SnphaseMax int = (SELECT MAX(nphase) FROM Expensephase )
	DECLARE @EnphaseMax int = (SELECT MAX(nphase) FROM Incomephase )

	CREATE TABLE #movimupb
	(
		tipo char(1),
		phase varchar(50),
		idmov int,
		ymov int,
		nmov int,
		ayear int,
		codefin varchar(50),
		finance varchar(150),
		codeupb varchar(50),
		upb varchar(150),
		registry varchar(150),
		p_iva varchar(15),
		cf varchar(16),
		manager varchar(150),
		doc varchar(35),
		docdate date,
		eserc_ord varchar(50),
		num_ord varchar(50),
		ord_date date,
		dist_trasm varchar(100),
		transmissiondate date,
		description varchar(150),
		curramount decimal(19,2),
		netamount decimal(19, 2),
		available decimal(19,2)
	)

	INSERT INTO #movimupb
	(
		tipo,
		phase,
		idmov,
		ymov,
		nmov,
		ayear,
		codefin,
		finance,
		codeupb,
		upb,
		registry,
		p_iva,
		cf,
		manager,
		doc,
		docdate,
		eserc_ord,
		num_ord,
		ord_date,
		dist_trasm,
		transmissiondate,
		description,
		curramount,
		netamount,
		available
	)
	SELECT 
		'S',
		E.phase,
		E.idexp,
		E.ymov,
		E.nmov,
		E.ayear,
		E.codefin,
		E.finance,
		E.codeupb,
		E.upb,
		E.registry,
		E.p_iva,
		E.cf,
		E.manager,
		E.doc,
		E.docdate,
		'Mandato '+Convert(Varchar(10),E.ypay),
		'Mandato '+Convert(Varchar(10),E.npay),
		E.paymentadate,
		'Trasmissione Mandati '+Convert(Varchar(10),E.npaymenttransmission),
		E.transmissiondate,
		E.description,
		E.curramount,
		E.netamount,
		CASE
			WHEN @snphase = @SnphaseMax THEN 0 ELSE E.available
		END
	FROM expenseview E
	LEFT OUTER JOIN expense E3 ON E.idexp = E3.parentidexp
	LEFT OUTER JOIN expenselast EL3 ON EL3.idexp = E3.idexp
	LEFT OUTER JOIN payment P ON EL3.kpay = P.kpay
	LEFT JOIN @lista_codeupb cu ON (cu.codeupb = E.codeupb or (@showchildupb = 'S' and E.codeupb like cu.codeupb + '%'))
	WHERE (E.ymov >=@ayearstart or @ayearstart is null)
	and (E.ymov <=@ayearstop or @ayearstop is null)
		and (E.nphase = @snphase or @snphase is null)
		and (cu.codeupb = E.codeupb or (@showchildupb = 'S' and E.codeupb like cu.codeupb + '%'))
		and (E.idsor01 = @idsor01 or @idsor01 is null)
		and (E.idsor02 = @idsor02 or @idsor02 is null)
		and (E.idsor03 = @idsor03 or @idsor03 is null)
		and (E.idsor04 = @idsor04 or @idsor04 is null)
		and (E.idsor05 = @idsor05 or @idsor05 is null)
	
	INSERT INTO #movimupb
	(
		tipo,
		phase,
		idmov,
		ymov,
		nmov,
		ayear,
		codefin,
		finance,
		codeupb,
		upb,
		registry,
		p_iva,
		cf,
		manager,
		doc,
		docdate,
		eserc_ord,
		num_ord,
		ord_date,
		dist_trasm,
		transmissiondate,
		description,
		curramount,
		netamount,
		available
	)
	SELECT 
		'E',
		I.phase,
		I.idinc,
		I.ymov,
		I.nmov,
		I.ayear,
		I.codefin,
		I.finance,
		I.codeupb,
		I.upb,
		I.registry,
		I.p_iva,
		I.cf,
		I.manager,
		I.doc,
		I.docdate,
		'Reversale '+Convert(Varchar(10),I.ypro),
		'Reversale '+Convert(Varchar(10),I.npro),
		I.adate,
		'Trasmissione Reversale '+Convert(Varchar(10),I.nproceedstransmission),
		I.transmissiondate,
		I.description,
		I.curramount,
		I.curramount,
		CASE
			WHEN @enphase = @EnphaseMax THEN 0 ELSE I.available
		END
	FROM incomeview I
	LEFT OUTER JOIN income I3 ON I.idinc = I3.parentidinc
	LEFT OUTER JOIN incomelast IL3 ON IL3.idinc = I3.idinc
	LEFT OUTER JOIN proceeds P ON IL3.kpro = P.kpro
	LEFT JOIN @lista_codeupb cu ON (cu.codeupb = I.codeupb or (@showchildupb = 'S' and I.codeupb like cu.codeupb + '%'))
	WHERE (I.ymov >=@ayearstart or @ayearstart is null)
		and (I.ymov <=@ayearstop or @ayearstop is null)
		and (I.nphase = @enphase or @enphase is null)
		and (cu.codeupb = I.codeupb or (@showchildupb = 'S' and I.codeupb like cu.codeupb + '%'))
		and (I.idsor01 = @idsor01 or @idsor01 is null)
		and (I.idsor02 = @idsor02 or @idsor02 is null)
		and (I.idsor03 = @idsor03 or @idsor03 is null)
		and (I.idsor04 = @idsor04 or @idsor04 is null)
		and (I.idsor05 = @idsor05 or @idsor05 is null)

	SELECT
		tipo AS 'Tipo',
		phase AS 'Fase',
		ymov AS 'Eserc.Mov.',
		nmov AS 'Num.Mov.',
		ayear AS 'Eserc. di Riferimento',
		codefin AS 'Voce Bil.',
		finance AS 'Denom. Bil.',
		codeupb AS 'Cod. U.P.B.',
		upb AS 'U.P.B.',
		registry AS 'Anagrafica',
		p_iva AS 'Partita iva',
		cf AS 'Codice Fiscale',
		manager AS 'Responsabile',
		doc AS 'Documento',
		docdate AS 'Data Doc.',
		eserc_ord AS 'Eserc.Ordinativo',
		num_ord AS 'Num.Ordinativo',
		ord_date AS 'Data Cont. Ordinativo',
		dist_trasm AS 'Distinta Trasmissione',
		transmissiondate AS 'Data Trasmissione',
		description AS 'Descrizione',
		curramount AS 'Importo Lordo',
		netamount AS 'Importo Netto',
		available AS 'Importo Disponibile'
	FROM #movimupb
	ORDER BY tipo, codeupb, registry, phase, ord_date, idmov, ayear


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

