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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_documents_partially_payed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_documents_partially_payed]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser'amministrazione'
-- EXEC [exp_documents_partially_payed] NULL,'F',		NULL, NULL,NULL, NULL, NULL  
-- EXEC [exp_documents_partially_payed] NULL,'A', 15533, NULL,NULL, NULL, NULL 
-- exp_documents_partially_payed null, 'A', NULL, null, null, null, null, null
CREATE PROCEDURE [exp_documents_partially_payed]
	@ayear	    	int,
	@kind char(1),--All [A], Fatture [F], Contratto passivo [C], Missioni[M] ,Wageaddition[W],casualcontract[S],profservice[P],parasubcontract[B]
	@idreg int = null,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	AS
	BEGIN
	DECLARE @maxexpensephase tinyint
	SELECT  @maxexpensephase = MAX(nphase) FROM   expensephase 
	DECLARE @nfinphase tinyint -- fase bilancio
	SELECT  @nfinphase = expenseregphase FROM uniconfig

	DECLARE @monofase   char(1) = 'N'
	IF ((SELECT COUNT(*) FROM expensephase)) = 1 SET @monofase = 'S'
	CREATE TABLE #alldocument (
	idreg int,	idacc varchar(38),
	idinvkind int, yinv smallint , ninv int, rownum int,

	idmankind varchar(20), yman smallint, nman int,manrownum int,

	iditineration varchar(20),

	ycon int, ncon int, 

	idpettycash varchar(20), yoperation int, noperation int,

	idcsa_import int,
	idpayroll int, --fiscalyear int,
	costo decimal(19,2), notpayed decimal (19,2)
	)
------------------	FATTURE per dettaglio	----------------------------------------------------------------------------------------------------------------
CREATE TABLE #fatturedetail(idreg int, idacc varchar(38),
					idinvkind int, yinv int, ninv int, 
					flagsplit char(1),
					acquistoestera char(1),
					expirationkind	varchar(40),
					paymentexpiring	smallint,
					expiring	date,
					taxabletotal decimal(19,2),
					ivatotal decimal(19,2),
					cost decimal (19,2), notpayed decimal (19,2))
if (@kind = 'A' or @kind ='F')
Begin
insert into #fatturedetail	(idreg, idacc,
					idinvkind , yinv , ninv ,  
					flagsplit,
					acquistoestera,
					expirationkind,
					paymentexpiring,
					expiring,
					taxabletotal, ivatotal,
					cost, notpayed	)
		select	D.idreg, AD.idacc,
				D.idinvkind , I.yinv , I.ninv ,
				CASE
								WHEN ISNULL(I.flag_enable_split_payment, 'N') = 'S' then 'S' else 'N'
				END,
				CASE
								WHEN I.idsdi_acquistoestere is not null then 'S' else 'N'
				END,
				expirationkind.description,
				I.paymentexpiring, 
				dateadd(day,isnull(I.paymentexpiring,0),
				case 
					when (I.idexpirationkind=1) then I.adate
					when (I.idexpirationkind=2) then I.docdate
					when (I.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(I.docdate) ,I.docdate)))
					when (I.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(I.adate) ,I.adate)))
					when (I.idexpirationkind=5) then I.adate
					when (I.idexpirationkind=6) then I.protocoldate
				end
				),
				sum(D.taxabletotal),
				sum(D.ivatotal),
				sum(D.taxabletotal + 
				CASE WHEN 
													(ISNULL(I.flag_enable_split_payment, 'N') = 'S' 
													OR I.idsdi_acquistoestere is not null)
				THEN 0 ELSE D.ivatotal END),
				sum(D.residual)  

		from invoiceexpenseresidual D
		join invoice I on D.idinvkind = I.idinvkind and D.yinv = I.yinv and D.ninv = I.ninv
		left outer join accmotive A on I.idaccmotivedebit = A.idaccmotive 
		left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and AD.ayear = I.yinv
		left outer join expirationkind										ON I.idexpirationkind = expirationkind.idexpirationkind
		where 
		D.flagbuysell = 'A' and D.flagvariation = 'N'
		and D.active='S'
		and ( I.yinv = @ayear or @ayear is null )

		AND (I.idreg = @idreg OR @idreg is null)
		AND (D.idsor01 = @idsor01 OR @idsor01 is null)
		AND (D.idsor02 = @idsor02 OR @idsor02 is null)
		AND (D.idsor03 = @idsor03 OR @idsor03 is null)
		AND (D.idsor04 = @idsor04 OR @idsor04 is null)
		AND (D.idsor05 = @idsor05 OR @idsor05 is null)
		group by 		D.idreg, AD.idacc,D.idinvkind , I.yinv , I.ninv ,
				expirationkind.description,
				I.paymentexpiring, I.idexpirationkind,
				I.adate, I.docdate, I.protocoldate,
				I.flag_enable_split_payment, I.idsdi_acquistoestere
End		
--SELECT * FROM invoiceresidual  WHERE idinvkind =  173 and yinv = 2025 and ninv = 61 
--SELECT * FROM invoiceexpenseresidual  WHERE idinvkind =  173 and yinv = 2025 and ninv = 61 

 --SELECT * FROM #fatturedetail where notpayed <> 0 -- WHERE idinvkind =  173 and yinv = 2025 and ninv = 61 
------------------	CP per dettaglio	----------------------------------------------------------------------------------------------------------------
 CREATE TABLE #contrattopassivo(	idreg int, idacc varchar(38),
					idmankind varchar(20), yman int, nman int,
					expirationkind	varchar(40),
					paymentexpiring	smallint,
					expiring	date,
					taxabletotal decimal(19,2),
					ivatotal decimal(19,2),
					cost decimal(19,2), notpayed decimal (19,2))
 
	 
if (@kind = 'A' or @kind ='C')
Begin
	CREATE TABLE #mandate
	(
		idmankind varchar(20),
		mandatekind varchar(150), 
		yman int, 
		nman int, 
		expirationkind	varchar(40),
		paymentexpiring	smallint,
		expiring	date,
		description varchar(200),
		idreg  int,
		registry  varchar(150),
		idaccmotivedebit varchar(50),
		taxabletotal  decimal(19,2), --  'Imponibile Totale',
		ivatotal decimal(19,2),	   -- 'Iva Totale',
		linkedimpon decimal(19,2), --'Contab. Imponibile',
		linkedimpos decimal(19,2), --'Contab. IVA',
		linkedordin decimal(19,2), --'Contab. Totale',
		residual  decimal(19,2)  --'Importo non Pagato'
	)

	CREATE TABLE #mandate_committed
	(
		idmankind varchar(20),
		yman int, 
		nman int, 
		idreg int,
		linked_amount decimal(19,2) 
	)

	INSERT INTO  #mandate
	(
		idmankind,
		mandatekind, 
		yman, 
		nman, 
		expirationkind,
		paymentexpiring,
		expiring,
		description,
		idreg,
		registry,
		idaccmotivedebit, 
		taxabletotal, --  'Imponibile Totale',
		ivatotal,	 -- 'Iva Totale',
		linkedimpon, --'Contab. Imponibile',
		linkedimpos, --'Contab. IVA',
		linkedordin, --'Contab. Totale',
		residual  --'Importo non Contabilizzato',
		--linked_amount decimal(19,2),
		--cashed_registered decimal(19,2)
	)
	 SELECT
	 mandateresidual.idmankind as '#Cod. Tipo contratto Passivo',
	 mandateresidual.mankind as 'Tipo Contratto Passivo',
	 mandateresidual.yman as 'Eserc. Contratto Passivo',
	 mandateresidual.nman as 'Num. Contratto Passivo',
		expirationkind.description,
			mandate.paymentexpiring, 
			dateadd(day,isnull(mandate.paymentexpiring,0),
			case 
				when (mandate.idexpirationkind=1) then mandate.adate
				when (mandate.idexpirationkind=2) then mandate.docdate
				when (mandate.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(mandate.docdate) ,mandate.docdate)))
				when (mandate.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(mandate.adate) ,mandate.adate)))
				when (mandate.idexpirationkind=5) then mandate.adate
			end
			),

	 mandateresidual.description as 'Descrizione',
	 mandateresidual.idreg as '#ID Anagrafica',
	 mandateresidual.registry as 'Anagrafica',
	 mandate.idaccmotivedebit as '#ID Causale Debito',
	 sum(mandateresidual.taxabletotal) as 'Imponibile Totale',
	 sum(mandateresidual.ivatotal) as 'Iva Totale',
	 sum(mandateresidual.linkedimpon) 'Contab. Imponibile',
	 sum(mandateresidual.linkedimpos) 'Contab. IVA',
	 sum(mandateresidual.linkedordin) 'Contab. Totale',
	 sum(mandateresidual.residual) as 'Importo non Contabilizzato' 
 FROM mandateresidual 
 join mandate on mandateresidual.idmankind = mandate.idmankind 
	and mandateresidual.yman = mandate.yman and mandateresidual.nman = mandate.nman
			left outer join expirationkind	ON mandate.idexpirationkind = expirationkind.idexpirationkind
	-- Contratti Passivi non Collegabili a fattura
 WHERE mandateresidual.linktoinvoice = 'N' and mandateresidual.active = 'S'
			and mandateresidual.isrequest = 'N'
 --AND (mandateresidual.idmankind = @idmankind OR @idmankind is null)
 AND (mandateresidual.idreg = @idreg OR @idreg is null)
 AND (mandateresidual.yman = @ayear OR @ayear is null)
 AND (mandateresidual.idsor01 = @idsor01 OR @idsor01 is null)
 AND (mandateresidual.idsor02 = @idsor02 OR @idsor02 is null)
 AND (mandateresidual.idsor03 = @idsor03 OR @idsor03 is null)
 AND (mandateresidual.idsor04 = @idsor04 OR @idsor04 is null)
 AND (mandateresidual.idsor05 = @idsor05 OR @idsor05 is null)
 GROUP BY 
	mandateresidual.idmankind,
	mandateresidual.mankind,
	mandateresidual.yman,
	mandateresidual.nman,
	mandateresidual.description,
	mandateresidual.idreg,
	mandateresidual.registry,
	mandate.idaccmotivedebit,
	mandate.idexpirationkind, 
	mandate.adate,
	mandate.docdate,
	expirationkind.description,
	mandate.paymentexpiring
;

--SELECT * FROM #mandate WHERE residual > 0;
WITH CONTRATTI_NON_CONTABILIZZATI AS
	(
		SELECT  
			idmankind,
			yman, 
			nman,
			idreg
		FROM #mandate
		WHERE 	
		(linkedimpon +		 --'Contab. Imponibile',
		linkedimpos +		 --'Contab. IVA',
		linkedordin) = 0     --'Contab. Totale',
	)
 	INSERT INTO #mandate_committed
	(
			idmankind,
			yman, 
			nman,
		idreg,
		linked_amount
	)
	SELECT 
		idmankind,
			yman, 
			nman,
		idreg,
		0 AS  'Importo Pagamento' 
	FROM CONTRATTI_NON_CONTABILIZZATI C
	;


	--select * from #mandate where idmankind = 'ING_NOFATT' and yman = 2015 and nman = 4;
	--- PAGATO (SU CONTABILIZZATO)
	WITH CONTRATTI_CONTABILIZZATI AS
	(
		SELECT  
			idmankind,
			yman, 
			nman,
			idreg
		FROM #mandate
		WHERE 	
		(linkedimpon +		 --'Contab. Imponibile',
		linkedimpos +		 --'Contab. IVA',
		linkedordin) > 0     --'Contab. Totale',
	)
	--- per chi non ha monofase calcolo il pagato per i contratti passivi contabilizzati
 	INSERT INTO #mandate_committed
	(
			idmankind,
			yman, 
			nman,
			idreg,
			linked_amount
	)
	SELECT 
		idmankind,
		yman, 
		nman,
		idreg,
		ISNULL((select  sum(expensetotal.curramount)
			FROM expenseyear
			JOIN expense
				ON expenseyear.idexp = expense.idexp 
			JOIN expensetotal
				ON  expenseyear.idexp = expensetotal.idexp
				AND expenseyear.ayear = expensetotal.ayear		
			JOIN expenselink EL2
				ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase
			JOIN expensemandate IES
				ON IES.idmankind = C.idmankind
				AND IES.yman = C.yman
				AND IES.nman = C.nman
			where EL2.idparent = IES.idexp
			and expense.nphase = @maxexpensephase
			and expense.idreg = C.idreg
			),0)AS  'Importo Pagamento' 
	FROM CONTRATTI_CONTABILIZZATI C
	WHERE @monofase  = 'N'
	UNION ALL 
	--- per chi ha monofase importo pagato coincide con importo contabilizzato
	SELECT 
		C.idmankind,
		C.yman, 
		C.nman,
		C.idreg,
		(MR.linkedimpon +		 --'Contab. Imponibile',
		 MR.linkedimpos +		 --'Contab. IVA',
		 MR.linkedordin) AS  'Importo Pagamento' 
	FROM CONTRATTI_CONTABILIZZATI C
	JOIN mandateresidual MR ON MR.idmankind = C.idmankind AND MR.yman = C.yman  AND MR.nman = C.nman 
	WHERE @monofase  = 'S';

	--SELECT '#mandate_committed', * FROM #mandate_committed
	INSERT INTO #contrattopassivo	
				   (idreg, idacc, idmankind, yman, nman,
					expirationkind,
					paymentexpiring,
					expiring,
					taxabletotal,
					ivatotal,
					cost, notpayed)
			select #mandate.idreg, A.idacc, #mandate.idmankind,	 #mandate.yman, #mandate.nman,
				#mandate.expirationkind,
				#mandate.paymentexpiring,
				#mandate.expiring,
				#mandate.taxabletotal, #mandate.ivatotal,
				#mandate.taxabletotal + #mandate.ivatotal,
				---- RESIDUO TOTALE DA PAGARE: RESIDUO DA IMPEGNARE + RESIDUO DA PAGARE SU IMPORTO GIA' IMPEGNATO
				#mandate.taxabletotal + #mandate.ivatotal - #mandate_committed.linked_amount
FROM #mandate_committed 
JOIN #mandate
	on #mandate_committed.idmankind = #mandate.idmankind 
	and #mandate_committed.yman = #mandate.yman 
	and #mandate_committed.nman = #mandate.nman 
	and #mandate_committed.idreg = #mandate.idreg 
LEFT OUTER JOIN accmotive AD WITH (NOLOCK)							
ON AD.idaccmotive = #mandate.idaccmotivedebit
LEFT OUTER JOIN accmotivedetail ADT WITH (NOLOCK)							
ON AD.idaccmotive = ADT.idaccmotive AND ADT.ayear = #mandate.yman 
LEFT OUTER JOIN account A  WITH (NOLOCK)							
ON A.idacc  = ADT.idacc  AND A.ayear = #mandate.yman 
WHERE (#mandate.taxabletotal + #mandate.ivatotal - #mandate_committed.linked_amount) > 0 

--SELECT '#contrattopassivo',* FROM #contrattopassivo	 --WHERE idmankind = 'CP_GEN' and yman = 2023 and nman = 70 ;
END

-------------------------- Missioni ---------------------------------------------------------------------------------------------
CREATE TABLE #missioni( idreg int, idacc varchar(38),
					iditineration varchar(20), yitineration int, nitineration int,
					cost decimal(19,2), notpayed decimal (19,2))
if (@kind = 'A' or @kind ='M')
Begin
 --- RESIDU0 DA CONTABILIZZARE
	insert into #missioni			
			select 	D.idreg, AD.idacc,
					D.iditineration,
					D.yitineration ,
					D.nitineration,
					D.totalgross,
					D.residual
			from itinerationresidual D
			join itineration I on D.iditineration = I.iditineration
			left outer join accmotive A on D.idaccmotive = A.idaccmotive 
			left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and AD.ayear = D.yitineration
			where 
			( I.yitineration = @ayear or @ayear is null )
			AND D.residual > 0
			AND D.active='S' AND I.completed = 'S'
			AND (I.idreg = @idreg OR @idreg is null)
			AND (D.idsor01 = @idsor01 OR @idsor01 is null)
			AND (D.idsor02 = @idsor02 OR @idsor02 is null)
			AND (D.idsor03 = @idsor03 OR @idsor03 is null)
			AND (D.idsor04 = @idsor04 OR @idsor04 is null)
			AND (D.idsor05 = @idsor05 OR @idsor05 is null)

			--- RESIDUO DA PAGARE (SU CONTABILIZZATO)
			insert into #missioni			
			select 	D.idreg, AD.idacc,
					D.iditineration,
					D.yitineration ,
					D.nitineration,
					I.totalgross,
					D.available
			from expenseitinerationview D
			join itineration I on D.iditineration = I.iditineration
			left outer join accmotive A on D.idaccmotive = A.idaccmotive 
			left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and AD.ayear = D.yitineration
			where 
			( I.yitineration = @ayear or @ayear is null )
			AND D.available > 0
			and D.ayear = (SELECT MAX(ayear) FROM expenseitinerationview M
			WHERE M.iditineration = I.iditineration   AND D.idexp = M.idexp) 
			AND I.completed = 'S' AND I.active = 'S' 
			AND @monofase  = 'N'
			AND (I.idreg = @idreg OR @idreg is null)
			AND (D.idsor01 = @idsor01 OR @idsor01 is null)
			AND (D.idsor02 = @idsor02 OR @idsor02 is null)
			AND (D.idsor03 = @idsor03 OR @idsor03 is null)
			AND (D.idsor04 = @idsor04 OR @idsor04 is null)
			AND (D.idsor05 = @idsor05 OR @idsor05 is null)
END

-------------------------- Wageaddition ---------------------------------------------------------------------------------------------
CREATE TABLE #dipendenti(idreg int, idacc varchar(38),
					ycon int, ncon int,
					cost decimal(19,2), notpayed decimal (19,2))
if (@kind = 'A' or @kind ='W')
Begin
 --- RESIDU0 DA CONTABILIZZARE
	insert into #dipendenti			
			select 	D.idreg, AD.idacc,
					D.ycon, 
					D.ncon,
					D.feegross,
					D.residual
			from wageadditionresidual D
			join wageaddition W on D.ycon = W.ycon and D.ncon = W.ncon
			left outer join accmotive A on W.idaccmotivedebit = A.idaccmotive  
			left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and AD.ayear = D.ycon
			WHERE  
			( W.ycon = @ayear or @ayear is null )
			and D.residual > 0 AND W.completed = 'S'
			AND (W.idreg = @idreg OR @idreg is null)
			AND (D.idsor01 = @idsor01 OR @idsor01 is null)
			AND (D.idsor02 = @idsor02 OR @idsor02 is null)
			AND (D.idsor03 = @idsor03 OR @idsor03 is null)
			AND (D.idsor04 = @idsor04 OR @idsor04 is null)
			AND (D.idsor05 = @idsor05 OR @idsor05 is null)

			--- RESIDUO DA PAGARE (SU CONTABILIZZATO)
			insert into #dipendenti			
			select 	D.idreg, AD.idacc,
					D.ycon, 
					D.ncon,
					W.feegross,
					D.available
			from expensewageadditionview D
			join wageaddition W on D.ycon = W.ycon and D.ncon = W.ncon
			left outer join accmotive A on W.idaccmotivedebit = A.idaccmotive  
			left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and AD.ayear = D.ycon
			WHERE  ( W.ycon = @ayear or @ayear is null )
			AND D.available > 0 AND W.completed = 'S'
			and D.ayear = (SELECT MAX(ayear) FROM expensewageadditionview M
			WHERE M.ycon = W.ycon and M.ncon = W.ncon AND D.idexp = M.idexp) 
			AND @monofase  = 'N'
			AND (W.idreg = @idreg OR @idreg is null)
			AND (D.idsor01 = @idsor01 OR @idsor01 is null)
			AND (D.idsor02 = @idsor02 OR @idsor02 is null)
			AND (D.idsor03 = @idsor03 OR @idsor03 is null)
			AND (D.idsor04 = @idsor04 OR @idsor04 is null)
			AND (D.idsor05 = @idsor05 OR @idsor05 is null)

			--SELECT * FROM #dipendenti
end

-------------------------- casualcontract ---------------------------------------------------------------------------------------------
CREATE TABLE #occasionali(idreg int, idacc varchar(38),
					ycon int, ncon int,
				cost decimal(19,2), notpayed decimal (19,2))
if (@kind = 'A' or @kind ='S')
Begin
--SELECT @monofase
 --- RESIDU0 DA CONTABILIZZARE
	insert into #occasionali			
			select 	D.idreg, AD.idacc,
					D.ycon, 
					D.ncon,
					D.feegross,
					D.residual
			from casualcontractresidual D
			join casualcontract C on D.ycon = C.ycon and D.ncon = C.ncon
			left outer join accmotive A on C.idaccmotivedebit = A.idaccmotive 
			left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and  AD.ayear = D.ycon
			WHERE
			( D.ycon = @ayear or @ayear is null )
			and D.residual > 0 AND C.completed = 'S'
			AND (C.idreg = @idreg OR @idreg is null)
			AND (D.idsor01 = @idsor01 OR @idsor01 is null)
			AND (D.idsor02 = @idsor02 OR @idsor02 is null)
			AND (D.idsor03 = @idsor03 OR @idsor03 is null)
			AND (D.idsor04 = @idsor04 OR @idsor04 is null)
			AND (D.idsor05 = @idsor05 OR @idsor05 is null)
		
		--select 'casualcontractresidual', * from casualcontractresidual D where D.ycon = 2025 and D.ncon = 1
		--select 'expensecasualcontractview',* from expensecasualcontractview D where D.ycon = 2025 and D.ncon = 1
			--- RESIDUO DA PAGARE (SU CONTABILIZZATO)
			--- I FONDI ECONOMALI SONO DA CONSIDERARSI CONTABILIZZAZIONI/PAGAMENTI ESEGUITI
			insert into #occasionali			
			select 	D.idreg, AD.idacc,
					D.ycon, 
					D.ncon,
					C.feegross,
					D.available
			from expensecasualcontractview D
			join casualcontract C on D.ycon = C.ycon and D.ncon = C.ncon
			left outer join accmotive A on C.idaccmotivedebit = A.idaccmotive 
			left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and AD.ayear = C.ycon
			WHERE 
			D.available > 0 AND C.completed = 'S'
			and D.ayear = (SELECT MAX(ayear) FROM expensecasualcontractview M
			WHERE M.ycon = C.ycon and M.ncon = C.ncon AND D.idexp = M.idexp) 
			AND @monofase  = 'N'
			And ( D.ycon = @ayear or @ayear is null)
			AND (C.idreg = @idreg OR @idreg is null)
			AND (D.idsor01 = @idsor01 OR @idsor01 is null)
			AND (D.idsor02 = @idsor02 OR @idsor02 is null)
			AND (D.idsor03 = @idsor03 OR @idsor03 is null)
			AND (D.idsor04 = @idsor04 OR @idsor04 is null)
			AND (D.idsor05 = @idsor05 OR @idsor05 is null)
			--SELECT * FROM #occasionali 
			--SELECT * FROM #occasionali where ycon = 2016 and ncon = 68
			--SELECT * FROM expensecasualcontractview where ycon = 2016 and ncon = 68
End

-------------------------- Cedolini ---------------------------------------------------------------------------------------------
CREATE TABLE #cedolini(idreg int, idcon int, ycon int, ncon int, idacc varchar(38),
					idpayroll int, npayroll int, fiscalyear int,
					cost decimal(19,2), notpayed decimal (19,2))
if (@kind = 'A' or @kind ='B')
Begin
 --- RESIDU0 DA CONTABILIZZARE
	insert into #cedolini			
			select 	C.idreg, C.idcon,  
					C.ycon, C.ncon, 
					AD.idacc,
					D.idpayroll,
					D.npayroll, 
					D.fiscalyear, 
					D.feegross,
					D.residual
			from payrollresidual D 
			join parasubcontract C on D.idcon = C.idcon
			left outer join accmotive A on C.idaccmotive = A.idaccmotive 
			left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and AD.ayear = D.fiscalyear
			WHERE 
				( D.fiscalyear = @ayear or @ayear is null )
				and D.residual > 0
				and D.flagbalance = 'N' AND D.flagcomputed = 'S'
				AND (C.idreg = @idreg OR @idreg is null)
				AND (D.idsor01 = @idsor01 OR @idsor01 is null)
				AND (D.idsor02 = @idsor02 OR @idsor02 is null)
				AND (D.idsor03 = @idsor03 OR @idsor03 is null)
				AND (D.idsor04 = @idsor04 OR @idsor04 is null)
				AND (D.idsor05 = @idsor05 OR @idsor05 is null)
			
			--- RESIDUO DA PAGARE (SU CONTABILIZZATO)
			insert into #cedolini			
			select 	C.idreg, C.idcon,  
					C.ycon, C.ncon, 
					AD.idacc,
					D.idpayroll,
					D.npayroll, 
					D.fiscalyear,  
					P.feegross,
					D.available
			from expensepayrollview D 
			join payroll P on D.idpayroll = P.idpayroll
			join parasubcontract C on D.idcon = C.idcon
			left outer join accmotive A on C.idaccmotive = A.idaccmotive 
			left outer join accmotivedetail AD on A.idaccmotive =  AD.idaccmotive and AD.ayear = D.fiscalyear
			WHERE 
				( D.fiscalyear = @ayear or @ayear is null )
				and D.available > 0
				and P.flagbalance = 'N' AND P.flagcomputed = 'S'
				and D.ayear = (SELECT MAX(ayear) FROM expensepayrollview M
				WHERE M.idpayroll = P.idpayroll  AND D.idexp = M.idexp) 
				AND (C.idreg = @idreg OR @idreg is null)
				AND @monofase  = 'N'
				AND (D.idsor01 = @idsor01 OR @idsor01 is null)
				AND (D.idsor02 = @idsor02 OR @idsor02 is null)
				AND (D.idsor03 = @idsor03 OR @idsor03 is null)
				AND (D.idsor04 = @idsor04 OR @idsor04 is null)
				AND (D.idsor05 = @idsor05 OR @idsor05 is null)
END					

----------------------------------------------------------------------------------------------------------------------------------------
		select  'Fatture' as 'Documento', 
				R.idreg as '#ID Anagrafica',
				R.title as 'Anagrafica',
				invoicekind.description as 'Tipo Fattura' , #fatturedetail.yinv  as 'Eserc.Fattura', #fatturedetail.ninv as 'Num.Fattura', -- fatt
				null as 'Tipo CP' , null as 'Eserc. CP', null as 'Num.CP', 		--cp
				#fatturedetail.expirationkind as 'Tipo scad.',
				#fatturedetail.paymentexpiring as 'Giorni Scad.',
				#fatturedetail.expiring as 'Scad',
				P.ycon  as 'Eserc.Compenso', P.ncon as 'Num.Compenso',					-- compenso
				null as 'N.Cedolino', null as 'Eserc.Cedolino',		-- cedolino
				account.codeacc as 'conto di Debito',
				max(#fatturedetail.taxabletotal) as 'Totale Imponibile',
				max(#fatturedetail.ivatotal) as 'Totale Iva',
				max(#fatturedetail.cost) as 'Importo pagabile documento',
				max(#fatturedetail.notpayed) as 'Importo non pagato'
		FROM #fatturedetail 
		join invoicekind 	on #fatturedetail.idinvkind = invoicekind.idinvkind
		LEfT OUTER join account on #fatturedetail.idacc = account.idacc
		join registry R on R.idreg = #fatturedetail.idreg
		left outer join profservice P ON P.idinvkind = #fatturedetail.idinvkind AND P.yinv = #fatturedetail.yinv AND P.ninv = #fatturedetail.ninv
		group by 			R.idreg, R.title,		invoicekind.description , #fatturedetail.yinv , #fatturedetail.ninv,	account.codeacc,
		#fatturedetail.idinvkind, P.idinvkind, P.yinv, P.ninv,P.ycon,P.ncon,
			#fatturedetail.expirationkind,
			#fatturedetail.paymentexpiring,
			#fatturedetail.expiring 
				having   	max(#fatturedetail.cost) >= max(#fatturedetail.notpayed)
				and sum(#fatturedetail.notpayed) <> 0
		union all
		select 'Contratto Passivo' as 'Documento', 
				R.idreg as '#ID Anagrafica',
				R.title as 'Anagrafica',
				null , null , null , 		--- fatt
				mandatekind.description , yman , nman , 	-- cp
				#contrattopassivo.expirationkind as 'Tipo scad.',
				#contrattopassivo.paymentexpiring as 'Giorni Scad.',
				#contrattopassivo.expiring as 'Scad.',
				null , null ,			-- compenso
				null, null,		-- cedolino
				account.codeacc, 
				#contrattopassivo.taxabletotal  as 'Totale Imponibile',
				#contrattopassivo.ivatotal  as 'Totale Iva',
   				#contrattopassivo.cost  as 'Importo pagabile documento',	#contrattopassivo.notpayed  as 'Importo non pagato'
		from  #contrattopassivo
		LEFT OUTER JOIN mandatekind on #contrattopassivo.idmankind = mandatekind.idmankind
		LEFT OUTER JOIN account on #contrattopassivo.idacc = account.idacc
		LEFT OUTER JOIN registry R on R.idreg = #contrattopassivo.idreg

		where #contrattopassivo.notpayed  <> 0
		union all
		select  'Compenso Occasionale' as 'Documento',
				R.idreg as '#ID Anagrafica',
				R.title as 'Anagrafica',
				null , null , null , 	-- fatt	
				null , null , null , 	-- cp
				null , null , null , 
				ycon , ncon ,		--contratto
				null, null,		-- cedolino
				account.codeacc, 
				null as 'Totale Imponibile',
				null as 'Totale Iva',
		max(cost) as 'Importo pagabile documento', sum(notpayed) as 'Importo non pagato'
		from #occasionali
		left outer join account on #occasionali.idacc = account.idacc
		join registry R on R.idreg = #occasionali.idreg
		group by 			R.idreg, R.title,ycon , ncon ,	account.codeacc
		having   	max(#occasionali.cost) >= sum(#occasionali.notpayed)
		and sum(#occasionali.notpayed) <> 0
		union all
		select  'Missioni' as 'Documento', 
						R.idreg as '#ID Anagrafica',
				R.title as 'Anagrafica',
				null , null , null , 	-- fatt
				null , null , null , 	-- cp
							null , null , null , 
				yitineration , nitineration ,		-- compenso
				null, null,		-- cedolino
				account.codeacc, 
				null as 'Totale Imponibile',
				null as 'Totale Iva',
				max(cost) as 'Importo pagabile documento',sum(notpayed) as 'Importo non pagato'
		from #missioni
		left outer join account on #missioni.idacc = account.idacc
		join registry R on R.idreg = #missioni.idreg
		group by 			R.idreg, R.title,yitineration , nitineration ,	account.codeacc
		having   	  max(#missioni.cost) >= sum(#missioni.notpayed)
		and sum(#missioni.notpayed) <> 0

	 union all
		select  'Dipendente' as 'Documento',
				R.idreg as '#ID Anagrafica',
				R.title as 'Anagrafica',
				null , null , null , 	-- fatt	
				null , null , null , 	-- cp
				null , null , null , 
				ycon , ncon ,		--compenso
				null, null,		-- cedolino
				account.codeacc, 
				null as 'Totale Imponibile',
				null as 'Totale Iva',
				max(cost) as 'Importo pagabile documento',sum(notpayed) as 'Importo non pagato'
		from #dipendenti
		left outer join account on #dipendenti.idacc = account.idacc
		join registry R on R.idreg = #dipendenti.idreg
		group by 			R.idreg, R.title,ycon , ncon ,	account.codeacc
		having   	  max(#dipendenti.cost) >= sum(#dipendenti.notpayed)
								and sum(#dipendenti.notpayed) <> 0
		union all
		select 'Cedolino' as 'Documento', 
				R.idreg as '#ID Anagrafica',
				R.title as 'Anagrafica',
				null , null , null ,-- fatt	
				null , null , null , 	-- cp
				null , null , null , 
				C.ycon , C.ncon ,		--compenso
				C.idpayroll,C.fiscalyear, -- cedolino
				account.codeacc, 
				null as 'Totale Imponibile',
				null as 'Totale Iva',
				max(C.cost) as 'Importo pagabile documento',sum(C.notpayed) as 'Importo non pagato'
		from #cedolini C
		left outer join account on C.idacc = account.idacc 
				join registry R on R.idreg = C.idreg
		group by C.ycon , C.ncon,C.npayroll, R.idreg, R.title,C.idpayroll , C.fiscalyear ,	account.codeacc
		having   max(C.cost) >= sum(C.notpayed)
		and sum(C.notpayed) <> 0
		order by 1,13,14, 15,16 desc

END
go


 	

 