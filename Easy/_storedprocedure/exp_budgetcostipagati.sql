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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_budgetcostipagati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_budgetcostipagati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exp_AnanlizzaDebitiCrediti
-- rpt_situazionebudget_new
-- setuser'amministrazione'
/* ----------------------------------------------------------------
select user
exec exp_budgetcostipagati 2024,  {ts '2024-12-31 00:00:00'},'%', '%', 'L'

exec exp_budgetcostipagati 2024, {ts '2024-02-28 00:00:00'}, '%', '%', 'D'

exec exp_budgetcostipagati 2024, {ts '2024-03-28 00:00:00'}, '%', '%', 'R'

--exec exp_budgetcostipagati 2024,  {ts '2024-12-31 00:00:00'},'00010001000800020033', 'CN1.1.01.01', 'D'
 exec exp_budgetcostipagati 2024,  {ts '2024-12-31 00:00:00'},'00010002000100020777', 'CN1.2.08.04', 'D'
 
 
 exec exp_budgetcostipagati 2024,  {ts '2024-12-31 00:00:00'},'00010002000300020118', 'CN1.2.08.10', 'D'
-------------------------------------------------------------------*/

CREATE PROCEDURE [exp_budgetcostipagati]
	@ayear	    	int,
	@adate datetime,
	@idupb varchar(36)='%',
	@codeacc varchar(50) = '%',
	@kind varchar(1), -- L : tabella lunghezze(è solo per uso interno), D: dettaglio(mostra i dettagli dei costi pagati per documento), R : mostra gli importi raggruppati per upb/conto
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	AS
	BEGIN

	declare @idacc varchar(38)
	if (@codeacc = '%')
	begin
		set @idacc = '%'
	end
	else
	Begin
		set @idacc = (select idacc from account where codeacc = @codeacc and ayear = @ayear)+'%'
	End

	--print 'idacc'
	--print @idacc
	CREATE TABLE #Lunghezze (yentry int,nentry int ,ndetail int ,
		idrelateddetail varchar(50) ,
		Pos1 int, Pos2 int , Pos3 int, Pos4 int, 
		idacc varchar(50), amount decimal (19,2)
		PRIMARY KEY (idrelateddetail, nentry, ndetail)
	)
	
	INSERT INTO #Lunghezze
	select   E.yentry, E.nentry,ndetail,E.idrelated, 
		CHARINDEX('§',E.idrelated) as Pos1,  
		CASE  
			WHEN CHARINDEX('§',E.idrelated,CHARINDEX('§',E.idrelated) +1) < 1  THEN LEN(E.idrelated)+1
			WHEN CHARINDEX('§',E.idrelated,CHARINDEX('§',E.idrelated) +1) > 0 THEN  CHARINDEX('§',E.idrelated,CHARINDEX('§',E.idrelated) +1) 
		END as Pos2,
		CASE 
			WHEN CHARINDEX('§',E.idrelated, CHARINDEX('§',E.idrelated,CHARINDEX('§',E.idrelated) +1)+1 )  < 1  THEN LEN(E.idrelated)+1
			WHEN CHARINDEX('§',E.idrelated, CHARINDEX('§',E.idrelated,CHARINDEX('§',E.idrelated) +1)+1 ) > 0 THEN CHARINDEX('§',E.idrelated, CHARINDEX('§',E.idrelated,CHARINDEX('§',E.idrelated) +1)+1 ) 
		END as Pos3,
		CHARINDEX('§',E.idrelated, CHARINDEX('§',E.idrelated, CHARINDEX('§',E.idrelated,CHARINDEX('§',E.idrelated) +1)+1 )  +1) as Pos4,
		 E.idacc, 
		 amount
	from entrydetail E
	join entry on e.nentry =entry.nentry and  e.yentry =entry.yentry
	join account A on E.idacc = A.idacc
	where 
		(A.flagaccountusage &320 <>0)		-- scritture di costo
		and entry.identrykind NOT IN (6,7,11,12) -- da rivedere 
		and E.yentry = @ayear	
		and E.idrelated is not null
		and (
		 E.idrelated like 'inv§%' or E.idrelated like 'man§%' or E.idrelated like 'itineration§%'or E.idrelated like 'wageadd§%' or E.idrelated like 'cascon§%'
		 or E.idrelated like 'profservice§%' or E.idrelated like 'payroll§%' 
		 or E.idrelated like 'pettycashoperation§%' or  E.idrelated like 'csaimport%'
		 or e.idrelated like '%§riten%' /*costi per contributi*/
		)
		and A.idacc +'%' like @idacc
		and e.idupb like @idupb
		and entry.adate<= @adate

		--select * from #Lunghezze
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if (@kind ='L')
begin

	select * from #Lunghezze

	return

end

	CREATE TABLE #alldocument (yentry int,nentry int ,ndetail int ,
	idrelateddetail varchar(50) ,
	idinvkind int, yinv smallint , ninv int, rownum int,
	idmankind varchar(20), yman smallint, nman int,manrownum int,
	iditineration varchar(20),
	ycon int, ncon int, 
	idpettycash varchar(20), yoperation int, noperation int,
	idcsa_import int,
	idpayroll int, --fiscalyear int,
	idacc varchar(50), amount decimal (19,2)
	)

	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		idinvkind , yinv  , ninv , rownum,
		idacc , amount )
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
					substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1)  AS 'idinvkind',
					substring(L.idrelateddetail,Pos2+1,Pos3-Pos2-1) as  'yinv', 
					substring(L.idrelateddetail,Pos3+1,Pos4-Pos3-1) as 'ninv',
					substring(L.idrelateddetail,Pos4+1, len(L.idrelateddetail)-Pos4) as 'rownum',
			idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'inv%'		-- > FATTURE
	
	
	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		idmankind , yman  , nman , manrownum,
		idacc , amount )
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
					substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1)  AS 'idmankind',
					substring(L.idrelateddetail,Pos2+1,Pos3-Pos2-1) as  'yman', 
					substring(L.idrelateddetail,Pos3+1,Pos4-Pos3-1) as 'nman',
					substring(L.idrelateddetail,Pos4+1, len(L.idrelateddetail)-Pos4) as 'rownum',
			idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'man%'		-- > CONTRATTI PASSIVI

	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		iditineration,
		idacc , amount )
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
			substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1)  AS 'iditineration',
			idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'itineration%'	-- > MISSIONI

	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		 ycon , ncon ,
		idacc , amount )
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
			substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1), -- as  'ycon', 
			substring(L.idrelateddetail,Pos2+1,Pos3-Pos2-1), -- as 'ncon',
			idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'wageadd%'		-- > COMPENSI A DIPENDENTI

	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		 ycon , ncon ,
		idacc , amount )
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
			substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1) ,-- as  'ycon', 
			substring(L.idrelateddetail,Pos2+1,Pos3-Pos2-1) ,-- as 'ncon',
			idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'cascon%'			-- >  COMPENSI OCCASIONALI
	
	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		 ycon , ncon ,
		idacc , amount )
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
			substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1) as  'ycon', 
			substring(L.idrelateddetail,Pos2+1,Pos3-Pos2-1) as 'ncon',
			idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'profservice%'		-- > COMPENSI PROFESSIONALI

	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		 idpayroll, --fiscaleyear,
		idacc , amount )
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
			substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1),
			idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'payroll%'		-- >  COMPENSI CO.CO.CO.

	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		 idpettycash, yoperation, noperation,
		idacc , amount )
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
			substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1) ,	--  'idpettycash',
			substring(L.idrelateddetail,Pos2+1,Pos3-Pos2-1) ,	--  'yoperation', 
			substring(L.idrelateddetail,Pos3+1, len(L.idrelateddetail)-Pos3), --  'noperation',
			idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'pettycashoperation%'		-- >  OPERAZIONI FONDO ECONOMALE

	
	insert into #alldocument(yentry ,nentry  ,ndetail  ,		idrelateddetail  ,
		idcsa_import,
		idacc , amount 	)
	select yentry ,nentry  ,ndetail  	,idrelateddetail  ,
		substring(L.idrelateddetail,Pos1+1,Pos2-Pos1-1),		-->	idcsa_import
		idacc , amount 
	from #Lunghezze L
	where idrelateddetail like 'csaimport%'
	
	--select * from #alldocument
------------------	COSTI PAGATI FINALE ----------------------------------------------------------------------------------------------------------------
CREATE TABLE #costipagati(kind varchar(100),
					idacc varchar(50), idupb varchar(36), 
					cost decimal (19,2), payed decimal (19,2))

------------------	FATTURE per dettaglio	----------------------------------------------------------------------------------------------------------------
CREATE TABLE #fatturedetail(yentry int,nentry int ,ndetail int ,
					idinvkind int, yinv int, ninv int, rownum int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))

--Per la parte imponibile va considerato il pagamento della fattura
insert into #fatturedetail			
			select 
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.idinvkind,
					L.yinv, 
					L.ninv,
					L.rownum,
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,
					IDET.taxable_euro
			from #alldocument L
			JOIN entrydetail ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN invoicedetailview IDET		
					ON IDET.idinvkind = L.idinvkind
					AND IDET.yinv = L.yinv
					AND IDET.ninv = L.ninv
					AND IDET.rownum = L.rownum
			JOIN paymentcommunicated PC1	
					on PC1.idexp = IDET.idexp_taxable and year(PC1.competencydate) = @ayear	 
			WHERE  L.idrelateddetail like 'inv%'
			-- se la fattura non viene contabilizzata col fondo economale 
			and not exists(select  * from pettycashoperationinvoice PCOI
							where IDET.idinvkind = PCOI.idinvkind
								AND IDET.yinv = PCOI.yinv
								AND IDET.ninv = PCOI.ninv)
--select '1', * from #fatturedetail
--where nentry = 10413

declare @prorata decimal(19,2)
set @prorata = isnull((select prorata from iva_prorata where ayear = @ayear ),0)

-- Per la parte iva va considerata la liquidazione iva, ma discriminiamo tra l'applicazione dl prorata o meno
-- la prima query applica il prorata se è una fatt. di acquisto e non istituzionale
-- la seconda query legge l'iva liquidata direttamente da invoicedetaildeferred se è una fatt. di acquisto e istituzionale

insert into #fatturedetail			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.idinvkind,
					L.yinv, 
					L.ninv,
					L.rownum,
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,
					--IDEFF.ivatotalpayed -- >>> Letto da invoicedetaildeferred
					--tax - (tax - unabatable)*(1-prorata)
					IDET.tax - (IDET.tax - isnull(IDET.unabatable,0))*(@prorata)
			from #alldocument L
			JOIN entrydetail ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN invoicedetailview IDET		
					ON IDET.idinvkind = L.idinvkind
					AND IDET.yinv = L.yinv
					AND IDET.ninv = L.ninv
					AND IDET.rownum = L.rownum
			join invoicedetaildeferred IDEFF 
					on IDEFF.idinvkind = IDET.idinvkind  and IDEFF.yinv = IDET.yinv and IDEFF.ninv = IDET.ninv  and IDEFF.rownum = IDET.rownum
			join ivapayexpense IEP 
				on IEP.yivapay = IDEFF.yivapay and  IEP.nivapay = IDEFF.nivapay
			JOIN paymentcommunicated PC1	
					on PC1.idexp = IEP.idexp and year(PC1.competencydate) = @ayear	 
			JOIN ivaregister IR
				ON IR.idinvkind = IDET.idinvkind
				AND IR.yinv = IDET.yinv
				AND IR.ninv = IDET.ninv
			JOIN ivaregisterkind IRK
				ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE L.idrelateddetail like 'inv%'
			and isnull(IDET.iva_euro,0) >0
			AND IRK.flagactivity <>1 -- 1 Istituzionale, 2 Commerciale
			AND IRK.registerclass <> 'P' -- Protocollo generale

--select '2', * from #fatturedetail
-- where nentry = 10413

insert into #fatturedetail			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.idinvkind,
					L.yinv, 
					L.ninv,
					L.rownum,
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,
					IDEFF.ivatotalpayed -- >>> Letto da invoicedetaildeferred
			from #alldocument L
			JOIN entrydetail ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN invoicedetailview IDET		
					ON IDET.idinvkind = L.idinvkind
					AND IDET.yinv = L.yinv
					AND IDET.ninv = L.ninv
					AND IDET.rownum = L.rownum
			join invoicedetaildeferred IDEFF 
					on IDEFF.idinvkind = IDET.idinvkind  and IDEFF.yinv = IDET.yinv and IDEFF.ninv = IDET.ninv  and IDEFF.rownum = IDET.rownum
			join ivapayexpense IEP 
				on IEP.yivapay = IDEFF.yivapay and  IEP.nivapay = IDEFF.nivapay
			JOIN paymentcommunicated PC1	
					on PC1.idexp = IEP.idexp and year(PC1.competencydate) = @ayear	 
			JOIN ivaregister IR
				ON IR.idinvkind = IDET.idinvkind
				AND IR.yinv = IDET.yinv
				AND IR.ninv = IDET.ninv
			JOIN ivaregisterkind IRK
				ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE L.idrelateddetail like 'inv%'
			and isnull(IDET.iva_euro,0) >0
			AND IRK.flagactivity =1 -- 1 Istituzionale, 2 Commerciale
			AND IRK.registerclass <> 'P' -- Protocollo generale

--select '3', * from #fatturedetail
-- where nentry = 10413

INSERT INTO #costipagati(kind, idacc, idupb, payed)
select 	'invoice',idacc, idupb,  sum(payed )
FROM #fatturedetail
group by 	idacc, idupb


------------------	CP per dettaglio	----------------------------------------------------------------------------------------------------------------
CREATE TABLE #contrattopassivo(yentry int,nentry int ,ndetail int ,
					idmankind varchar(20), yman int, nman int, rownum int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))
insert into #contrattopassivo			
			select distinct			-- lo uso perchè stiamo andando in join con le tabelle di spesa, ma stiamo leggendo dalla scrittura. Il join con la tabella di spesa moltiplica le righe
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.idmankind,
					L.yman, 
					L.nman,
					L.rownum,
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN mandatedetailview IDET		
					ON IDET.idmankind = L.idmankind
					AND IDET.yman = L.yman
					AND IDET.nman = L.nman
					AND IDET.rownum = L.manrownum
			JOIN expenselink			 ON expenselink.idparent = IDET.idexp_taxable
			JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
			JOIN paymentcommunicated PC1		
					ON PC1.idexp = expenselast.idexp and year(PC1.competencydate)=@ayear			
			WHERE L.idrelateddetail like 'man%'

INSERT INTO #costipagati(kind, idacc, idupb,  payed)
select 'mandate',	idacc, idupb,  sum(payed )
FROM #contrattopassivo
group by 	idacc, idupb,payed 
-------------------------- Missioni ---------------------------------------------------------------------------------------------
CREATE TABLE #missioni(yentry int,nentry int ,ndetail int ,
					iditineration varchar(20), yitineration int, nitineration int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))
insert into #missioni			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.iditineration,
					I.yitineration ,
					I.nitineration,
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN itineration I		
					ON I.iditineration = L.iditineration
			join expenseitineration EI
					on EI.iditineration = I.iditineration
			JOIN expenselink			 ON expenselink.idparent = EI.idexp
			JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
			JOIN paymentcommunicated PC1		
					ON PC1.idexp = expenselast.idexp and year(PC1.competencydate)=@ayear		
			WHERE  L.idrelateddetail like 'itineration%'

INSERT INTO #costipagati(kind, idacc, idupb,  payed)
select 'itineration',	idacc, idupb,  sum(payed )
FROM #missioni
group by 	idacc, idupb,payed 

----------------------------------------------------------------------------------------------------------------------------------------

-------------------------- Wageaddition ---------------------------------------------------------------------------------------------
CREATE TABLE #dipendenti(yentry int,nentry int ,ndetail int ,
					ycon int, ncon int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))
insert into #dipendenti			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.ycon, 
					L.ncon,
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN wageaddition W		
					ON W.ycon = L.ycon
					and W.ncon = L.ncon
			join expensewageaddition EI
					on EI.ycon = W.ycon and EI.ncon = W.ncon
			JOIN expenselink			 ON expenselink.idparent = EI.idexp
			JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
			JOIN paymentcommunicated PC1		
					ON PC1.idexp = expenselast.idexp and year(PC1.competencydate)=@ayear		
			WHERE  L.idrelateddetail like 'wageadd%'

INSERT INTO #costipagati(kind, idacc, idupb,  payed)
select 	'wageaddition',idacc, idupb, sum(payed )
FROM #dipendenti
group by 	idacc, idupb,payed 

-------------------------- casualcontract ---------------------------------------------------------------------------------------------
CREATE TABLE #occasionali(yentry int,nentry int ,ndetail int ,
					ycon int, ncon int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))
insert into #occasionali			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.ycon, 
					L.ncon,
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END, 
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN casualcontract W		
					ON W.ycon = L.ycon
					and W.ncon = L.ncon
			join expensecasualcontract EI
					on EI.ycon = W.ycon and EI.ncon = W.ncon
			JOIN expenselink			 ON expenselink.idparent = EI.idexp
			JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
			JOIN paymentcommunicated PC1		
					ON PC1.idexp = expenselast.idexp and year(PC1.competencydate)=@ayear		
			WHERE L.idrelateddetail like 'cascon%'

INSERT INTO #costipagati(kind,idacc, idupb,  payed)
select 	'casualcontract',idacc, idupb,  sum(payed )
FROM #occasionali
group by 	idacc, idupb,payed 

-------------------------- professionali ---------------------------------------------------------------------------------------------
CREATE TABLE #professionali(yentry int,nentry int ,ndetail int ,
					ycon int, ncon int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))
insert into #professionali			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.ycon, 
					L.ncon,
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN profservice W		
					ON W.ycon = L.ycon
					and W.ncon = L.ncon
			join expenseprofservice EI
					on EI.ycon = W.ycon and EI.ncon = W.ncon
			JOIN expenselink			 ON expenselink.idparent = EI.idexp
			JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
			JOIN paymentcommunicated PC1		
					ON PC1.idexp = expenselast.idexp and year(PC1.competencydate)=@ayear		
			WHERE L.idrelateddetail like 'profservice%'

INSERT INTO #costipagati(kind,idacc, idupb,  payed)
select 'profservice',	idacc, idupb,  sum(payed )
FROM #professionali
group by 	idacc, idupb,payed 

----------------------------------------------------------------------------------------------------------------------------------------
-------------------------- Cedolini ---------------------------------------------------------------------------------------------
CREATE TABLE #cedolini(yentry int,nentry int ,ndetail int ,
					idpayroll int, fiscalyear int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))
insert into #cedolini			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.idpayroll,
					I.fiscalyear, 
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN payroll I		
					ON I.idpayroll = L.idpayroll 
			join expensepayroll EI
					on EI.idpayroll = I.idpayroll
			JOIN expenselink			 ON expenselink.idparent = EI.idexp
			JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
			JOIN paymentcommunicated PC1		
					ON PC1.idexp = expenselast.idexp and year(PC1.competencydate)=@ayear			
			WHERE L.idrelateddetail like 'payroll%'

INSERT INTO #costipagati(kind,idacc, idupb,  payed)
select 	'payroll',idacc, idupb,  sum(payed )
FROM #cedolini
group by 	idacc, idupb,payed 

----------------------------------------------------------------------------------------------------------------------------------------

-------------------------- CSA ---------------------------------------------------------------------------------------------
CREATE TABLE #csa(yentry int,nentry int ,ndetail int ,
					idcsa_import int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))
insert into #csa			
			select distinct -- serve perchè se la riga di riepilogo importazione ha 2 righe di mov. finanziario, dalla select usciranno 2 righe ma avranno lo stesso importo perchè l'importo viene letto dalla scrittura 
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.idcsa_import, 
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			join csa_importriep_partition_expense CE
					on CE.idcsa_import = L.idcsa_import 
					and L.idrelateddetail = 'csaimport§'+ convert(varchar(20), CE.idcsa_import )+ '§RIEP§'
								+ convert(varchar(20), CE.idriep )+'§'+ convert(varchar(20), CE.ndetail )
			JOIN paymentcommunicated PC1		
					ON PC1.idexp = CE.idexp 
			WHERE year(PC1.competencydate)=@ayear	
			 and isnull(CE.amount,0)<>0

insert into #csa			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.idcsa_import, 
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE		WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			join csa_importver_partition_expense CE
					on  CE.idcsa_import = L.idcsa_import
					and L.idrelateddetail = 'csaimport§'+ convert(varchar(20), CE.idcsa_import )+ '§VER§'
								+ convert(varchar(20), CE.idver )+'§'+ convert(varchar(20), CE.ndetail )
			JOIN paymentcommunicated PC1		
					ON PC1.idexp = CE.idexp 
			WHERE 
			year(PC1.competencydate)=@ayear	
			and isnull(CE.amount,0)<>0
 
			--select '#alldocument', * from #alldocument
			--select '#csa',* from #csa
--select 'diff', abs(max(ED.amount)), sum(C.payed), L.idrelateddetail  FROM #csa  C left outer join #alldocument L ON L.idrelateddetail = C.idrelateddetail
--	JOIN entrydetailview ED 
--				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
--	group by L.idrelateddetail 
--having abs(max(ED.amount)) <> sum(C.payed)

INSERT INTO #costipagati(kind,idacc, idupb,  payed)
select 'csa',	idacc, idupb,  sum(payed )
FROM #csa
group by 	idacc, idupb,payed 

----------------------------------------------------------------------------------------------------------------------------------------

------------------	Fondo economale	----------------------------------------------------------------------------------------------------------------
-- Questi sono costi. Alle operazioni potrebbe essere associato un documento
CREATE TABLE #fondoeconomale(yentry int,nentry int ,ndetail int ,
					idpettycash varchar(20), yoperation int, noperation int,
					yrestore int, nrestore int,
					idacc varchar(50), idupb varchar(36), 
					give  decimal (19,2), have  decimal (19,2), 
					idrelateddetail  varchar(50), payed decimal (19,2))
--					30§1	5§1
insert into #fondoeconomale			
			select distinct
					ED.yentry,	ED.nentry,	 ED.ndetail,	
					L.idpettycash,
					L.yoperation, 
					L.noperation,
					PO.yrestore, PO.nrestore, 
					ed.idacc,	ed.idupb,
					--ED.give	,	
					CASE	WHEN ISNULL(ed.amount,0) < 0 THEN -ed.amount	ELSE NULL END,
					--ED.have	, 
					CASE	WHEN ISNULL(ed.amount,0) >= 0 THEN ed.amount		ELSE NULL	END,
					L.idrelateddetail ,-- Pos1, Pos2, Pos3, Pos4,
					-L.amount
			from #alldocument L
			JOIN entrydetailview ED 
				ON L.yentry = ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
			JOIN pettycashoperation PO		
					ON PO.idpettycash = L.idpettycash
					AND PO.yoperation = L.yoperation
					AND PO.noperation = L.noperation
			JOIN pettycashexpense pce		ON  po.yrestore = pce.yoperation		AND po.nrestore = pce.noperation		AND po.idpettycash = pce.idpettycash
			join expenselast el		on el.idexp = pce.idexp 
			join expenseyear	on el.idexp = expenseyear.idexp
			join payment   on el.kpay = payment.kpay
			join paymenttransmission     on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
			WHERE  L.idrelateddetail like 'pettycashoperation%'
				and  (PO.flag& 8)<> 0  -->  'spesa'
				and expenseyear.idupb = po.idupb and expenseyear.idfin = po.idfin

-- per il pagato, consideriamo il reintegro della spesa
-- Uso due tabelle per poter controllare meglio la situazione
------insert into #fondoeconomale	(idpettycash , yoperation ,noperation )
------select 
------	PO.idpettycash ,PO.yoperation ,PO.noperation 
------	--po.yrestore, po.nrestore, 
------	  -- po.amount --> lo abbiamo letto prima dalla scrittura
------	from pettycashoperation po
------	JOIN pettycashexpense pce		ON  po.yrestore = pce.yoperation		AND po.nrestore = pce.noperation		AND po.idpettycash = pce.idpettycash
------	join expenselast el		on el.idexp = pce.idexp 
------	join expenseyear	on el.idexp = expenseyear.idexp
------	join payment   on el.kpay = payment.kpay
------	join paymenttransmission     on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
------	join #fondoeconomale F		
------		ON  po.yrestore = F.yrestore		AND po.nrestore = F.nrestore		AND po.idpettycash = F.idpettycash
------where expenseyear.idupb = po.idupb and expenseyear.idfin = po.idfin

INSERT INTO #costipagati(kind,idacc, idupb,  payed)
select 'pettycash',	F1.idacc, F1.idupb,  sum(F1.payed )
FROM #fondoeconomale F1
join #fondoeconomale F2 on F1.idpettycash = F2.idpettycash and F1.yoperation = F2.yoperation and F1.noperation = F2.noperation 
group by 	F1.idacc, F1.idupb


----------------------------------------------------------------------------------------------------------------------------------------
if (@kind ='D')
begin

		select  'Fatture' as 'Documento', yentry as 'Eserc.Scrittura',nentry as 'Num.Scrittura' ,ndetail as 'Dettaglio scrittura',
				invoicekind.description as 'Tipo Fattura' , yinv  as 'Eserc.Fattura', ninv as 'Num.Fattura', rownum as 'nDetail', -- fatt
				null as 'Tipo CP' , null as 'Eserc. CP', null as 'Num.CP', null as 'nDetail',		--cp
				null as 'Eserc.Compenso', null as 'Num.Compenso',					-- compenso
				null as 'N.Cedolino', null as 'Eserc.Cedolino',		-- cedolino
				null as 'Eserc.Importazione CSA', null as 'N.Importazione CSA',	-- csa import
				null as 'FondoPS', null  as 'Eserc.Operazione', null as 'Num.Operazione' , -- fondo op
				account.codeacc as 'Conto', upb.codeupb as 'UPB',  
				--give , 				have  , 
				idrelateddetail as 'Codice doc.collegato', payed as 'Costo pagato'
		FROM #fatturedetail 
		join invoicekind 	on #fatturedetail.idinvkind = invoicekind.idinvkind
		join account on #fatturedetail.idacc = account.idacc
		join upb on  #fatturedetail.idupb = upb.idupb
		  union
		select 'Contratto Passivo' as 'Documento',  yentry ,nentry ,ndetail ,
				null , null , null , null ,		--- fatt
				mandatekind.description , yman , nman , rownum ,	-- cp
				null , null ,			-- compenso
				null, null,		-- cedolino
				null,null,	-- csa import
				null , null , null , -- fondo op
				account.codeacc, upb.codeupb, 
				--give , have  , 
				idrelateddetail , payed 
		from  #contrattopassivo
		join mandatekind on #contrattopassivo.idmankind = mandatekind.idmankind
		join account on #contrattopassivo.idacc = account.idacc
		join upb on  #contrattopassivo.idupb = upb.idupb

		 union
		select  'Compenso Occasionale' as 'Documento', yentry ,nentry ,ndetail ,
				null , null , null , null ,	-- fatt	
				null , null , null , null ,	-- cp
				ycon , ncon ,		--contratto
				null, null,		-- cedolino
				null,null,	-- csa import
				null , null , null , -- fondo op
				account.codeacc, upb.codeupb, 
				--give , have  , 
				idrelateddetail , payed 
		from #occasionali
		join account on #occasionali.idacc = account.idacc
		join upb on  #occasionali.idupb = upb.idupb
		 union
		select  'Missioni' as 'Documento', yentry ,nentry ,ndetail ,
				null , null , null , null ,	-- fatt
				null , null , null , null ,	-- cp
				yitineration , nitineration ,		-- compenso
				null, null,		-- cedolino
				null,null,	-- csa import
				null , null , null , -- fondo op
				account.codeacc, upb.codeupb, 
				--give , have  , 
				idrelateddetail , payed 
		from #missioni
		join account on #missioni.idacc = account.idacc
		join upb on  #missioni.idupb = upb.idupb
		  union
		select  'Dipendente' as 'Documento', yentry ,nentry ,ndetail ,
				null , null , null , null ,	-- fatt	
				null , null , null , null ,	-- cp
				ycon , ncon ,		--compenso
				null, null,		-- cedolino
				null,null,	-- csa import
				null , null , null , -- fondo op
				account.codeacc, upb.codeupb, 
				--give , have  , 
				idrelateddetail , payed 
		from #dipendenti
		join account on #dipendenti.idacc = account.idacc
		join upb on  #dipendenti.idupb = upb.idupb
		union
		select  'Professionale' as 'Documento', yentry ,nentry ,ndetail ,
				null , null , null , null ,	-- fatt	
				null , null , null , null ,	-- cp
				ycon , ncon ,		--compenso
				null, null,		-- cedolino
				null,null,	-- csa import
				null , null , null , -- fondo op
				account.codeacc, upb.codeupb, 
				--give , have  , 
				idrelateddetail , payed 
		from #professionali
		join account on #professionali.idacc = account.idacc
		join upb on  #professionali.idupb = upb.idupb
		union
		select 'Cedolino' as 'Documento',  yentry ,nentry  ,ndetail,
				null , null , null , null ,	-- fatt	
				null , null , null , null ,	-- cp
				null , null ,		--compenso
				idpayroll,fiscalyear, -- cedolino
				null,null,	-- csa import
				null , null , null , -- fondo op
				account.codeacc, upb.codeupb, 
				--give , have  , 
				idrelateddetail , payed 
		from #cedolini
		join account on #cedolini.idacc = account.idacc
		join upb on  #cedolini.idupb = upb.idupb
		union
		select 'CSA' as 'Documento',  yentry ,nentry ,ndetail,
				null , null , null , null ,	-- fatt	
				null , null , null , null ,	-- cp
				null , null ,		--compenso
				null, null, -- cedolino
				csa_import.yimport, csa_import.nimport,-- csa import
				null , null , null , -- fondo op
				account.codeacc, upb.codeupb, 
				--give , have  , 
				#csa.idrelateddetail , #csa.payed 
		from #csa
		join csa_import on #csa.idcsa_import = csa_import.idcsa_import
		join account on #csa.idacc = account.idacc
		join upb on  #csa.idupb = upb.idupb
		union
		select 'Fondo economale' as 'Documento', yentry ,nentry ,ndetail ,
				null , null , null , null ,	-- fatt	
				null , null , null , null ,	-- cp
				null , null ,		--compenso
				null , null,  -- cedolino
				null, null,	-- csa import
				idpettycash , yoperation , noperation , -- fondo op
				account.codeacc, upb.codeupb, 
				--give , have  , 
				idrelateddetail , payed 
		from #fondoeconomale
		join account on #fondoeconomale.idacc = account.idacc
		join upb on  #fondoeconomale.idupb = upb.idupb
		--order by idrelateddetail
		order by account.codeacc, payed
End

if ( @kind ='R') 
begin
	select
	-- kind as 'Documento', 
	U.codeupb as 'Cod.UPB',
	C.codeacc as 'Cod.Conto', 
	C.title as 'Conto',
	sum(P.payed)  as 'Costo pagato',
	P.idupb as '(internalcode upb)', 
	P.idacc as '(internalcode acc)'
	from #costipagati P
		join account C on p.idacc = c.idacc
		join upb U on p.idupb = U.idupb
	group by P.idupb, P.idacc, 
		U.codeupb, C.codeacc, C.title
	order by U.codeupb, C.codeacc

end


drop table #csa
drop table #Lunghezze
drop table #costipagati
drop table #fatturedetail
drop table #contrattopassivo
drop table #occasionali
drop table #missioni
drop table #dipendenti
drop table #professionali
drop table #cedolini
drop table #fondoeconomale

END
go


 --exec exp_budgetcostipagati 2024,  {ts '2024-12-31 00:00:00'},'00010002000100020777', 'CN1.2.08.04', 'D'
 --exec exp_budgetcostipagati 2024,  {ts '2024-12-31 00:00:00'},'00010002000300020118', 'CN1.2.08.10', 'D'
 --exec exp_budgetcostipagati 2024,  {ts '2024-12-31 00:00:00'},'00010001000100020136', 'CN1.1.01.04', 'D'
 --exec exp_budgetcostipagati 2024,  {ts '2024-12-31 00:00:00'},'00010001000100020136', 'CN1.1.01.04', 'R'
 