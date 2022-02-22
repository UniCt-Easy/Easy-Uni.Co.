
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


IF exists (select * from dbo.sysobjects where id = object_id(N'[exp_calcola_integrazione_previsione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_calcola_integrazione_previsione
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amm'
-- setuser'amministrazione' 
--	EXEC exp_calcola_integrazione_previsione 2020, '30-10-2020' , 3,'N','S'
 CREATE PROCEDURE exp_calcola_integrazione_previsione
(
	@ayear int,  --- anno corrente
	@adate datetime,
	@exportazionekind int,
	@prevcorrente char(1) = 'N', --- quando è chiamata da form, ricalcola e mostra solo il budget iniziale, senza invludere variazioni e storni alla data
	/*		0 = Prev. iniziali, 
			1 = Le previsioni triennali di costi di ammortamento,  
			2 = Le previsioni di ricavo per utilizzo riserve ex COFI,  
			3 = Rettifiche
	*/
	@riscontaricavi_ammortamentifuturi char(1) = 'N' -- task 15403
)
AS BEGIN
CREATE TABLE #Expbudget
	(
		idacc 			varchar(38), 
		idupb			varchar(36),
		yvar			int,
		nvar			int,	
		operationdate	datetime,

		idasset int, 
		idpiece int, 
		rownum int,
		kind varchar(20),

		amount			decimal(19,2),
		amount2			decimal(19,2),
		amount3			decimal(19,2),
		initialprevision 	decimal(19,2),
		initialprevision2 	decimal(19,2),
		initialprevision3 	decimal(19,2)
	)

declare @creavar char(1)
set @creavar ='N'


DECLARE @min_levelusable int 
SET @min_levelusable = (select min(nlevel) from accountlevel where ayear = @ayear and (flagusable='S'))
print @min_levelusable 

-- La sp chiama la sp di calcolo, e mostra le righe a seconda del valore di @exportazionekind .
insert into #Expbudget(idacc, 	idupb,
		yvar, nvar,	
		operationdate,
		idasset,idpiece, rownum,
		kind,
		amount,	amount2,amount3,
		initialprevision,initialprevision2,	initialprevision3 	)
exec calcola_integrazione_previsione @ayear, @adate, @exportazionekind, @prevcorrente, @creavar, @riscontaricavi_ammortamentifuturi


if (@exportazionekind= 0)
Begin
		select 
			U.codeupb as 'Cod.UPB',
			A.codeacc as 'Cod. Conto',
			A.title as 'Conto',
			CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
					ELSE ''
			END AS 'Tipo Conto',
			ISNULL(S.sortcode,SParent.sortcode)  as 'Cod. Budget Economico' ,
			ISNULL(S1.sortcode,SParent1.sortcode)  as 'Cod. Budget Investimenti' ,
			--B.kind as 'Tipo operazione',
			--B.operationdate as 'Data Operazione',
			B.initialprevision as 'Importo',
			B.initialprevision2  as 'Importo Eserc.+1',
			B.initialprevision3 as 'Importo Eserc.+2',
			B.yvar as 'Eserc.Variazione',
			B.nvar as 'Num.Variazione',
			B.rownum as 'Num.Riga'
		from  #Expbudget B
		join account A on B.idacc = A.idacc
		join account Parent on Parent.idacc = SUBSTRING(A.idacc, 1, 2 + 4*@min_levelusable) 
		and Parent.nlevel= @min_levelusable
		join upb U on B.idupb = U.idupb
		left outer join sorting S
		on S.idsor = A.idsor_economicbudget
		left outer join sorting SParent
		on SParent.idsor = Parent.idsor_economicbudget
		left outer join sorting S1
		on S1.idsor = A.idsor_investmentbudget
		left outer join sorting SParent1
		on SParent1.idsor = Parent.idsor_investmentbudget
		where A.ayear = @ayear --AND ISNULL(S.sortcode,SParent.sortcode)  IS NOT NULL
End

if (@exportazionekind in (1,2))
Begin
		select 
			U.codeupb as 'Cod.UPB',
			A.codeacc as 'Cod. Conto',
			A.title as 'Conto',
			CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
					ELSE ''
			END AS 'Tipo Conto',
			ISNULL(S.sortcode,SParent.sortcode)   as 'Cod. Budget Economico' ,
			ISNULL(S1.sortcode,SParent1.sortcode)  as 'Cod. Budget Investimenti' ,
			case
				when B.kind ='Asset' then 'Ammortamenti da Cespiti' -- 1 --
				when B.kind ='accountvar' then 'Ammortamenti da Budget Investimenti'-- 1 --
				when B.kind ='RESERVE' then 'Prev.Ricavo'	-- 2 --
				when B.kind ='ADJUSTMENT' then 'Rettifiche Commessa completata'	-- 3 --
				when B.kind ='ADJUSTMENT_F' then  'Risconto per ammortamenti futuri'-- 3 --
			end as 'Tipologia',
			--B.kind as 'Tipo operazione',
			--B.operationdate as 'Data Operazione',
			sum(B.amount) as 'Importo',
			sum(B.amount2) as 'Importo Eserc.+1',
			sum(B.amount3) as 'Importo Eserc.+2',
			B.idasset as 'Num.Cespite',
			B.idpiece as 'Num.Parte',
			B.yvar as 'Eserc.Variazione',
			B.nvar as 'Num.Variazione',
			B.rownum as 'Num.Riga'
		from  #Expbudget B
		join account A on B.idacc = A.idacc
		join account Parent on Parent.idacc = SUBSTRING(A.idacc, 1, 2 + 4*@min_levelusable)
		and Parent.nlevel= @min_levelusable
		join upb U on B.idupb = U.idupb
		left outer join sorting S
		on S.idsor = A.idsor_economicbudget
		left outer join sorting SParent
		on SParent.idsor = Parent.idsor_economicbudget
		left outer join sorting S1
		on S1.idsor = A.idsor_investmentbudget
		left outer join sorting SParent1
		on SParent1.idsor = Parent.idsor_investmentbudget
		where A.ayear = @ayear --AND ISNULL(S.sortcode,SParent.sortcode)  IS NOT NULL
		group by U.codeupb , A.codeacc, B.idasset, B.idpiece, B.yvar, B.nvar,	B.rownum,B.kind,A.flagaccountusage,A.title,
		ISNULL(S.sortcode,SParent.sortcode) ,ISNULL(S1.sortcode,SParent1.sortcode) 
End

if (@exportazionekind  = 3)
Begin
		select 
			U.codeupb as 'Cod.UPB',
			A.codeacc as 'Cod. Conto',
			A.title as 'Conto',
			ISNULL(S.sortcode,SParent.sortcode)   as 'Cod. Budget Economico' ,
			ISNULL(S1.sortcode,SParent1.sortcode)  as 'Cod. Budget Investimenti' ,
			CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
					ELSE ''
			END AS 'Tipo Conto',
			case
				when B.kind ='Asset' then 'Ammortamenti da Cespiti' -- 1 --
				when B.kind ='accountvar' then 'Ammortamenti da Budget Investimenti'-- 1 --
				when B.kind ='RESERVE' then 'Prev.Ricavo'	-- 2 --
				when B.kind ='ADJUSTMENT' then 'Rettifiche Commessa completata'	-- 3 --
				when B.kind ='ADJUSTMENT_F' then  'Risconto per ammortamenti futuri'-- 3 --
			end as 'Tipologia',
			--B.kind as 'Tipo operazione',
			--B.operationdate as 'Data Operazione',
			sum(B.amount) as 'Importo',
			sum(B.amount2) as 'Importo Eserc.+1',
			sum(B.amount3) as 'Importo Eserc.+2',
			B.idasset as 'Num.Cespite',
			B.idpiece as 'Num.Parte'
		from  #Expbudget B
		join account A on B.idacc = A.idacc
		join account Parent on Parent.idacc = SUBSTRING(A.idacc, 1, 2 + 4*@min_levelusable)
		and Parent.nlevel= @min_levelusable
		join upb U on B.idupb = U.idupb
		left outer join sorting S
			on S.idsor = A.idsor_economicbudget
		left outer join sorting SParent
			on SParent.idsor = Parent.idsor_economicbudget
		left outer join sorting S1
			on S1.idsor = A.idsor_investmentbudget
		left outer join sorting SParent1
			on SParent1.idsor = Parent.idsor_investmentbudget
		where A.ayear = @ayear --AND ISNULL(S.sortcode,SParent.sortcode)  IS NOT NULL
		group by U.codeupb , A.codeacc, B.idasset, B.idpiece, B.kind,A.flagaccountusage,A.title,ISNULL(S.sortcode,SParent.sortcode),
		ISNULL(S1.sortcode,SParent1.sortcode) 
End

if (@exportazionekind = 10)
Begin
--- aggiungere le variazioni normali già contemplate nel calcolo
		select 
			U.codeupb as 'Cod.UPB',
			A.codeacc as 'Cod. Conto',
			A.title as 'Conto',
			CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
					ELSE ''
			END AS 'Tipo Conto',
			ISNULL(S.sortcode,SParent.sortcode)   as 'Cod. Budget Economico' ,
			ISNULL(S1.sortcode,SParent1.sortcode)  as 'Cod. Budget Investimenti' ,
			--B.kind as 'Tipo operazione',
			--B.operationdate as 'Data Operazione',
			case
				when B.kind ='INIZIALI' then 'Prev. iniziali' -- 0 -- 
				when B.kind ='Asset' then 'Ammortamenti da Cespiti' -- 1 --
				when B.kind ='accountvar' then 'Ammortamenti da Budget Investimenti'-- 1 --
				when B.kind ='RESERVE' then 'Prev.Ricavo'	-- 2 --
				when B.kind ='ADJUSTMENT' then 'Rettifiche Commessa completata'	-- 3 --
				when B.kind ='ADJUSTMENT_F' then  'Risconto per ammortamenti futuri'-- 3 --
			end as 'Tipologia',
			--B.kind as 'Tipo operazione',
			--B.operationdate as 'Data Operazione',
			sum(B.initialprevision) + sum(B.amount) as 'Importo',
			sum(B.initialprevision2) + sum(B.amount2) as 'Importo Eserc.+1',
			sum(B.initialprevision3) + sum(B.amount3) as 'Importo Eserc.+2',
			B.idasset as 'Num.Cespite',
			B.idpiece as 'Num.Parte',
			B.yvar as 'Eserc.Variazione',
			B.nvar as 'Num.Variazione',
			B.rownum as 'Num.Riga'
		from  #Expbudget B
		join account A on B.idacc = A.idacc
		join account Parent on Parent.idacc = SUBSTRING(A.idacc, 1, 2 + 4*@min_levelusable)
		and Parent.nlevel= @min_levelusable
		join upb U on B.idupb = U.idupb
		left outer join sorting S
		on S.idsor = A.idsor_economicbudget
		left outer join sorting SParent
		on SParent.idsor = Parent.idsor_economicbudget
		left outer join sorting S1
		on S1.idsor = A.idsor_investmentbudget
		left outer join sorting SParent1
		on SParent1.idsor = Parent.idsor_investmentbudget
		where A.ayear = @ayear -- AND ISNULL(S.sortcode,SParent.sortcode)  IS NOT NULL
		group by U.codeupb , A.codeacc, B.idasset, B.idpiece, B.yvar, B.nvar,	B.rownum,B.kind,A.flagaccountusage,A.title,ISNULL(S.sortcode,SParent.sortcode),
		ISNULL(S1.sortcode,SParent1.sortcode) 
 
		UNION  -- if @prevcorrente = 'S', solo se la lancio da menu esportazioni
		SELECT 
			U.codeupb as 'Cod.UPB',
			A.codeacc as 'Cod. Conto',
			A.title as 'Conto',
			CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
					ELSE ''
			END AS 'Tipo Conto',
			ISNULL(S.sortcode,SParent.sortcode)  as 'Cod. Budget Economico' ,
			ISNULL(S1.sortcode,SParent1.sortcode)  as 'Cod. Budget Investimenti' ,
			--B.kind as 'Tipo operazione',
			--B.operationdate as 'Data Operazione',
			case
				when AV.variationkind = 1 then 'Var. Normale' -- 1 -- 
				when AV.variationkind = 2 then 'Var. Ripartizione' -- 2 --
				when AV.variationkind = 3 then 'Var. Assestamento'-- 3 --
				when AV.variationkind = 4 then 'Storno'	-- 4 --
				when AV.variationkind = 5 then 'Var. Iniziale'	-- 5 --
				when AV.variationkind = 6 then 'Var. Non operativa'	-- 6 --
			end as 'Tipologia',
			--B.kind as 'Tipo operazione',
			--B.operationdate as 'Data Operazione',
			sum(B1.amount) as 'Importo',
			sum(B1.amount2) as 'Importo Eserc.+1',
			sum(B1.amount3) as 'Importo Eserc.+2',
			NULL as 'Num.Cespite',
			NULL as 'Num.Parte',
			B1.yvar as 'Eserc.Variazione',
			B1.nvar as 'Num.Variazione',
			B1.rownum as 'Num.Riga'
 
		from accountvar AV
		join accountvardetail	B1		
			ON AV.yvar = B1.yvar
			AND AV.nvar = B1.nvar
		join account A
			on B1.idacc = A.idacc
		join account Parent on Parent.idacc = SUBSTRING(A.idacc, 1, 2 + 4*@min_levelusable)
		and Parent.nlevel= @min_levelusable
		join upb U on B1.idupb = U.idupb
		left outer join sorting S
		on S.idsor = A.idsor_economicbudget
		left outer join sorting SParent
		on SParent.idsor = Parent.idsor_economicbudget
		left outer join sorting S1
		on S1.idsor = A.idsor_investmentbudget
		left outer join sorting SParent1
		on SParent1.idsor = Parent.idsor_investmentbudget
		where AV.adate <= @adate
			and AV.yvar = @ayear
			and AV.idaccountvarstatus=5 
			and AV.variationkind <> 5 and AV.variationkind <> 6 
			AND @prevcorrente = 'S' --AND ISNULL(S.sortcode,SParent.sortcode)  IS NOT NULL
		group by U.codeupb , A.codeacc,  B1.yvar, B1.nvar,	B1.rownum, A.flagaccountusage,
		AV.variationkind,A.title,ISNULL(S.sortcode,SParent.sortcode) ,ISNULL(S1.sortcode,SParent1.sortcode) 



End

		drop table #Expbudget
		return


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



