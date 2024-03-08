
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


if exists (select * from dbo.sysobjects where id = object_id(N'[get_ivapay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [get_ivapay]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione'
-- get_ivapay 2021,37

CREATE  PROCEDURE [get_ivapay]
	@yivapay int,
	@nivapay int
AS BEGIN
	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione
	CREATE TABLE #invoice
	(
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		registerclass char(1), --tipo registro A/V
		kind char(1), --tipo fattura A/V
		flagintracom char(1),
		flag_reverse_charge char(1),
		flagsplit char(1),
		flagmixed char(1),
		flagdeferred char(1),
		flagvariation char(1),		
		currivagrosspayed decimal(19,2),  
		currivaunabatable decimal(19,2), --unabatable corrente, applicare segno
		idreg int,
		idivaregisterkind int,
		taxable decimal(19,2),
		idupb varchar(36),
		flagactivity int,
		idupb_epexp varchar(36),
		idupb_epacc varchar(36),
		idrelated_epexp varchar(100),
		idrelated_epacc varchar(100),
		flagbit int
	)

	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita
	
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagintracom,flag_reverse_charge,flagsplit,flagvariation,
		currivagrosspayed,currivaunabatable,
		idreg,idivaregisterkind,taxable,idupb, flagactivity,idupb_epexp,idupb_epacc,idrelated_epexp,idrelated_epacc,
		flagbit
	)
	(SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum,  I.flagdeferred,
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --kind		--tipo fattura (A/V)
		I.flagintracom,I.flag_reverse_charge,
		I.flag_enable_split_payment,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --flagvariation
		ISNULL(IDET.tax,0) ,--cambiare segno
		ISNULL(IDET.unabatable,0)  , --cambiare segno		
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal
		 ,isnull(IDET.idupb_iva, IDET.idupb),
		 IRK.flagactivity ,EY.idupb,EAY.idupb,EE.idrelated,EA.idrelated,
		 I.flagbit
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv
	JOIN invoicedetaildeferred IDD 	on IDD.idinvkind=IDET.idinvkind and IDD.yinv=IDET.yinv and IDD.ninv=IDET.ninv and IDD.rownum=IDET.rownum
	JOIN invoicekind IK				ON I.idinvkind = IK.idinvkind
	--JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv AND IR.idivaregisterkind = IDD.idivaregisterkind
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IDD.idivaregisterkind
	left outer join epexp EE on IDET.idepexp=EE.idepexp
	left outer join epexpyear EY on EE.idepexp=EY.idepexp and EY.ayear=@yivapay
	left outer join epacc EA on IDET.idepacc=EA.idepacc
	left outer join epaccyear EAY on EA.idepacc=EAY.idepacc and EAY.ayear=@yivapay
	WHERE 	IDD.yivapay = @yivapay and IDD.nivapay = @nivapay
			)
	 
--Imposta come "acquisti" e cambia il segno le fatture contabilizzate in entrata ove ci siano due registri collegati. 
	-- Infatti queste vanno trattate come se fossero note di variazione
	update #invoice set kind = 'A',
				currivagrosspayed=-currivagrosspayed,
						currivaunabatable=-currivaunabatable,
						taxable=-taxable
		 where 
				 (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoice.idinvkind
					and RK.registerclass<>'P'
				) = 2
			and kind<>'A'


	
	--cambia il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation
	update #invoice set kind = registerclass,
						currivagrosspayed=-currivagrosspayed,
						currivaunabatable=-currivaunabatable,
						taxable=-taxable
		 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoice.idinvkind
					and RK.registerclass<>'P'
			) = 1 
			


	update #invoice set currivagrosspayed=-currivagrosspayed,
						currivaunabatable=-currivaunabatable,
						taxable=-taxable
		 where flagvariation='S'			--serve solo per le intrastat istituz. acquisti


--task 8715: prendere 0001 per fatture acquisto split istituzionali		
	update #invoice set idupb='0001' where 
					registerclass='A' and kind = 'A'
					and flagintracom='N' 
					and flagsplit='S' 
					and  flagactivity=1  --istituzionale
-- per le fatture con recupero iva estera deve usare l'upb Ateneo [17163]
	update #invoice set idupb='0001' where 
					registerclass='A' and kind = 'A'
					and flagintracom<>'N'  and (flagbit & 64) <> 0
					and  flagactivity=1  --istituzionale

					
	SELECT #invoice.*,ivaregisterkind.codeivaregisterkind, ivaregisterkind.description,
				ID.idepexp,ID.idepacc
	 FROM #invoice
		JOIN ivaregisterkind					ON ivaregisterkind.idivaregisterkind = #invoice.idivaregisterkind
		JOIN invoicedetail ID					on ID.idinvkind=#invoice.idinvkind and ID.yinv=#invoice.yinv and ID.ninv= #invoice.ninv 
													and ID.rownum= #invoice.rownum
	WHERE currivagrosspayed <> 0

	ORDER BY idinvkind,yinv,ninv,rownum,flagdeferred
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


