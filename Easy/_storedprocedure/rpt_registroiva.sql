
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


--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registroiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registroiva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- rpt_registroiva 2,2017,11,12,'S'
-- rpt_registroiva 1, 2011, 3, 'N'
CREATE PROCEDURE [rpt_registroiva]
	@idivaregisterkind int,
	@year int,
	@month_start int,
	@month_stop int,
	@official char(1),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
AS BEGIN
	
	IF @month_start IS NULL OR @month_start < 1
	BEGIN
		SET @month_start = 1
	END
	IF @month_start > 12
	BEGIN
		SET @month_start = 12
	END

	IF @month_stop IS NULL OR @month_stop < 1
	BEGIN
		SET @month_stop = 1
	END
	IF @month_stop > 12
	BEGIN
		SET @month_stop = 12
	END


declare @DenominazioneUniversita varchar(50)
select @DenominazioneUniversita = paramvalue from generalreportparameter where idparam='DenominazioneUniversita'

CREATE TABLE #invoice
(
	idinvkind int,		
	yinv int,
	ninv int,
	idivaregisterkind int,	
	registerclass char(1), --tipo registro A/V
	kind char(1), --tipo fattura A/V

	flagdeferred char(1),
	ivagross decimal(19,2),
	ivaabatable decimal(19,2),
	ivaunabatable decimal(19,2),
	taxabletotal decimal(19,2),
	idivakind int		
)
	
	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione
	CREATE TABLE #invoicedet
	(
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		registerclass char(1), --tipo registro A/V
		kind char(1), --tipo fattura A/V
		flagmixed char(1),
		flagdeferred char(1),
		flagvariation char(1),
		taxabletotal decimal(19,2),
		ivagross decimal(19,2),
		ivaunabatable decimal(19,2), --unabatable corrente, applicare segno
		ivaabatable decimal(19,2),   -- calcolato qui
		idivaregisterkind int, 
		idivakind int,
		flagintracom char(1)			
	)
	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita
	



	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagvariation,
		taxabletotal,ivagross,	ivaunabatable,
		idivakind,idivaregisterkind, flagintracom
	)
	(SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum, I.flagdeferred,
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END,	--flagmixed
		IRK.registerclass,											--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'	     ELSE 'V'	END, --kind		--tipo fattura (A/V)
		CASE WHEN (IK.flag & 4) = 0 THEN 'N'	ELSE 'S'	END, --flagvariation		
		ROUND(IDET.taxable * IDET.npackage * 	 CONVERT(decimal(19,10),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2 ), --taxabletotal
		ISNULL(IDET.tax,0), --ivagross
		ISNULL(IDET.unabatable,0)  , --cambiare segno				
		IDET.idivakind,IRK.idivaregisterkind,
		I.flagintracom
	FROM invoice I
	join invoicedetail IDET				ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv AND IDET.ninv=I.ninv
	JOIN invoicekind IK					ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 	
		YEAR(I.adate) = @year AND MONTH(I.adate) between @month_start and @month_stop
		AND IRK.idivaregisterkind = @idivaregisterkind
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)

-- Stessa INSERT precedente ma interroga SOLO le autofatture senza dettagli:
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagvariation,
		taxabletotal,ivagross,	ivaunabatable,
		idivakind,idivaregisterkind, flagintracom
	)
	(SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum, M.flagdeferred,
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END,		--flagmixed
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'     ELSE 'V'	END, --kind		--tipo fattura (A/V)
		CASE	WHEN (IK.flag & 4) = 0 THEN 'N'		ELSE 'S'	END, --flagvariation		
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2 ), --taxabletotal
		ISNULL(IDET.tax,0), --ivagross
		ISNULL(IDET.unabatable,0)  , --cambiare segno				
		IDET.idivakind,IRK.idivaregisterkind,		M.flagintracom 
	FROM invoice I
	JOIN invoice M				ON I.idinvkind_real = M.idinvkind	AND I.yinv_real = M.yinv	AND I.ninv_real = M.ninv	--> fattura Madre
	join invoicedetail IDET		ON IDET.idinvkind = M.idinvkind		AND IDET.yinv = M.yinv		AND IDET.ninv = M.ninv
	JOIN invoicekind IK			ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 	
		YEAR(I.adate) = @year AND MONTH(I.adate) between @month_start and @month_stop
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)

	


	DECLARE @registerclass char(1)
	SELECT @registerclass = registerclass	FROM ivaregisterkind	WHERE idivaregisterkind = @idivaregisterkind
	
	DECLARE @proratarate decimal(19,6)
	SELECT @proratarate = prorata 	FROM iva_prorata WHERE ayear = @year
	set @proratarate= isnull(@proratarate,1)
	
	DECLARE @mixedrate decimal(19,6)	
	SELECT @mixedrate = mixed FROM iva_mixed WHERE ayear = @year
	set @mixedrate= isnull(@mixedrate,1)
	

	DECLARE @flagivapaybyrow char(1)
	SELECT @flagivapaybyrow= flagivapaybyrow from config WHERE ayear = @year
	--Per chi scegli di applicare il calcolo sul totale, anche il promiscuo sarà applicato sul totale.
	if (@flagivapaybyrow='N') 
	Begin
		SET @proratarate=1 --non applica il prorata in questo caso
		SET @mixedrate = 1
	End


	update #invoicedet set ivaabatable= CONVERT(decimal(19,2),	(ivagross-ivaunabatable)*@proratarate*@mixedrate )
		where registerclass='A' and flagmixed='S'

	update #invoicedet set ivaabatable= CONVERT(decimal(19,2),	(ivagross-ivaunabatable)*@proratarate )
		where registerclass='A' and flagmixed='N'


	update #invoicedet set ivaabatable= ivagross	
		where registerclass='V'


	UPDATE #invoicedet SET ivaunabatable = ISNULL(ivagross,0) - ISNULL(ivaabatable,0)



	
	--aggiusta il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation
	
	update #invoicedet set  kind = registerclass, taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
			) = 1
		--AND flagintracom = 'N'

	update #invoicedet set taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where flagvariation='S'

		--Imposta come "acquisti" e cambia il segno le fatture contabilizzate in entrata ove ci siano due registri collegati. 
	-- Infatti queste vanno trattate come se fossero note di variazione
	update #invoicedet set kind = 'A',
				taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where 
				 (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
				) = 2
			and kind<>'A'


	insert into #invoice (idinvkind ,yinv , ninv ,	idivaregisterkind ,
			registerclass ,	kind ,	flagdeferred ,	
			ivagross ,ivaabatable ,	ivaunabatable ,	taxabletotal ,
				idivakind )
	(select idinvkind ,yinv , ninv ,	idivaregisterkind ,
			registerclass ,	kind ,	flagdeferred ,	
			sum(ivagross) , sum(ivaabatable) , sum(ivaunabatable) ,sum(taxabletotal) ,
			idivakind
	from #invoicedet
		group by idinvkind ,yinv , ninv ,	idivaregisterkind ,
			registerclass ,	kind ,	flagdeferred ,	idivakind 
	)



	DECLARE @month_startname varchar(20)
	SELECT @month_startname = title
	FROM monthname
	WHERE code = @month_start

	DECLARE @month_stopname varchar(20)
	SELECT @month_stopname = title
	FROM monthname
	WHERE code = @month_stop

IF (SELECT COUNT(*) FROM #invoice) =0
Begin
		SELECT
		ivaregisterkind.description AS ivaregisterdescr,
		@month_startname AS month_startname,
		@month_stopname AS month_stopname,
		@year AS ayear,
		null as nivaregister,
		null as flagdeferred,
		null as registrationdate,
		null as idinvkinddescr,
		null as doc,
		null as docdate,
		null as registry,
		null as idcurrency,
		null as exchangerate,
		null as total,
		null as taxabletotal,
		null as ivagross,
		null as ivaabatable,
		null as ivaunabatable,
		null as idivakind,
		null as ivarate,
		null as unifiedivaregisterkind,
		null as unifiedninv,
		null as flag_enable_split_payment
	FROM ivaregisterkind
	WHERE idivaregisterkind = @idivaregisterkind

End
ELSE
Begin
	SELECT
		ivaregisterkind.description AS ivaregisterdescr,
		@month_startname AS month_startname,
		@month_stopname AS month_stopname,
		@year AS ayear,
		ivaregister.nivaregister,
		case
			-- se fattura di acquito, legge il valore
			when (invoicekind.flag & 1)=0 then #invoice.flagdeferred	
			-- se la fattura è soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((invoicekind.flag & 1)<>0 and	isnull(invoice.flag_enable_split_payment,'N')='S') then 'N' 
			else #invoice.flagdeferred
		end as flagdeferred,
		invoice.adate AS registrationdate,
		invoicekind.description AS idinvkinddescr,
		invoice.doc,
		invoice.docdate,
		case when isnull(invoice.autoinvoice,'N')='S' then @DenominazioneUniversita else registry.title end AS registry,
		currency.codecurrency as idcurrency,
		invoice.exchangerate,
		ISNULL(
			(SELECT ISNULL(SUM(i2.taxabletotal),0) + ISNULL(SUM(i2.ivagross),0)
			FROM #invoice i2
			WHERE #invoice.idinvkind = i2.idinvkind
			AND #invoice.yinv = i2.yinv
			AND #invoice.ninv = i2.ninv)
		,0) AS total,
		#invoice.taxabletotal,
		#invoice.ivagross,
		#invoice.ivaabatable,
		#invoice.ivaunabatable,
		ivakind.description AS idivakind,
		ivakind.rate AS ivarate,
		unifiedivaregisterkind.description as unifiedivaregisterkind,
		unifiedivaregister.unifiedninv,
		invoice.flag_enable_split_payment
	FROM #invoice
	JOIN ivaregisterkind						ON #invoice.idivaregisterkind = ivaregisterkind.idivaregisterkind
	JOIN ivaregister							ON #invoice.idivaregisterkind = ivaregister.idivaregisterkind	AND #invoice.idinvkind = ivaregister.idinvkind	AND #invoice.yinv = ivaregister.yinv	AND #invoice.ninv = ivaregister.ninv
	JOIN invoice								ON invoice.idinvkind = #invoice.idinvkind	AND invoice.yinv = #invoice.yinv	AND invoice.ninv = #invoice.ninv
	JOIN registry								ON registry.idreg = invoice.idreg
	JOIN invoicekind							ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivakind								ON ivakind.idivakind = #invoice.idivakind
	left outer join unifiedivaregister			ON unifiedivaregister.idinvkind = #invoice.idinvkind	AND unifiedivaregister.yinv = #invoice.yinv	AND unifiedivaregister.ninv = #invoice.ninv
	left outer join unifiedivaregisterkind		ON unifiedivaregisterkind.idivaregisterkind=unifiedivaregister.idivaregisterkind
	LEFT OUTER JOIN currency					ON currency.idcurrency = invoice.idcurrency
	WHERE ivaregisterkind.registerclass = @registerclass
	ORDER BY nivaregister
End
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


