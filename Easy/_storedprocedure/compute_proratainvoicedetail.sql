if exists (select * from dbo.sysobjects where id = object_id(N'[compute_proratainvoicedetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_proratainvoicedetail]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- compute_proratainvoicedetail 2016, 2,2016,12
CREATE  PROCEDURE [compute_proratainvoicedetail]
(
	@ayear int,
	@idinvkind int,
	@yinv int,
	@ninv int,
	@rownum int
)
AS BEGIN


	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione
	CREATE TABLE #invoicedet
	(
		label varchar(50),
		idinvkind int,
		invoicekind varchar(50),
		yinv int,
		ninv int,
		rownum int,
		adate datetime,
		competencydate datetime, 
		registerclass char(1), --tipo registro A/V
		kind char(1), --tipo fattura A/V
		flagmixed char(1),
		flagdeferred char(1),
		flagvariation char(1),
		flagintracom char(1),
		taxabletotal decimal(19,2),
		ivagross decimal(19,2),
		ivaunabatable decimal(19,2), --unabatable corrente, applicare segno
		ivaabatable decimal(19,2) 
	)
	

	INSERT INTO #invoicedet
	(
		idinvkind, invoicekind, yinv, ninv, rownum, 
		flagmixed,
		registerclass,kind,flagvariation,
		taxabletotal, ivagross,	ivaunabatable
	)
	SELECT
		I.idinvkind,IK.description, I.yinv,I.ninv, IDET.rownum, 
		--flagmixed
		CASE WHEN IRK.flagactivity = 3  THEN 'S' ELSE 'N' END,
		--registerclass
		IRK.registerclass,	
		-- kind 
		CASE WHEN (IK.flag & 1)=0 THEN 'A' ELSE 'V' END, 
		-- flagvariation
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, 	
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0), 
		ISNULL(IDET.unabatable,0)  	
	FROM invoice I
	JOIN invoicedetail IDET
		 ON IDET.idinvkind=I.idinvkind
		 AND IDET.yinv=I.yinv
		 AND IDET.ninv=I.ninv
	JOIN invoicekind IK
		 ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR
		 ON IR.idinvkind = I.idinvkind
		 AND IR.yinv = I.yinv
		 AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE I.idinvkind = @idinvkind and I.yinv = @yinv and I.ninv = @ninv and IDET.rownum = @rownum
	
	DECLARE @proratarate decimal(19,6)
	SELECT  @proratarate = prorata 	FROM iva_prorata WHERE ayear = @ayear
	set @proratarate= isnull(@proratarate,1)
	
	DECLARE @mixedrate decimal(19,6)	
	SELECT  @mixedrate = mixed FROM iva_mixed WHERE ayear = @ayear
	set @mixedrate= isnull(@mixedrate,1)
	
	DECLARE @flagivapaybyrow char(1)
	SELECT @flagivapaybyrow= flagivapaybyrow from config WHERE ayear = @ayear

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


	update #invoicedet set ivaabatable= ivagross where registerclass='V'

	UPDATE #invoicedet SET ivaunabatable = ISNULL(ivagross,0) - ISNULL(ivaabatable,0)

	--aggiusta il segno in base a registerclass/kind/flagvariation
	update #invoicedet set 
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		where registerclass<>kind AND flagintracom <> 'S'

	update #invoicedet set 
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where flagvariation='S'

	SELECT 
			#invoicedet.yinv , 
			#invoicedet.ninv ,
			rownum,
			taxabletotal, 
			ivagross,
			ivaunabatable,
			ivaabatable
	FROM  #invoicedet
	where kind = registerclass

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 exec compute_proratainvoicedetail 2016, 2,2016,12,1