if exists (select * from dbo.sysobjects where id = object_id(N'[exp_esterometroriepilogo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_esterometroriepilogo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 --setuser 'amministrazione'
CREATE procedure exp_esterometroriepilogo(
	@esercizio int,		-- anno solare
	@trimestre int,		-- vale 1 o 2 o 3 o 4
	@mese int,			-- vale da 1 a 12
	@kind char(1) 
	) as
begin
DECLARE @meseinizio int
DECLARE @mesefine int
 
 
IF (@mese is not null)
BEGIN
	SELECT @meseinizio = @mese
	SELECT @mesefine = @mese
END 
ELSE
BEGIN
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9
			when @trimestre = 4 then 12
	END
END
-- exec exp_esterometroriepilogo 2016,1,'A'
----------------- Calcola la Sede dell' Anagrafica ------------------------------------------
 CREATE TABLE #SedeAnagrafica
(
	idaddresskind int,
    idreg int,
	address varchar(60),	
	location varchar(60),
	cap varchar(5),		
	province varchar(2),
	nation varchar(2)
)

INSERT INTO #SedeAnagrafica(idaddresskind, idreg, address,	location, cap, province, nation)
SELECT * FROM f_get_esterometrosede(	@esercizio, @trimestre,@mese, @kind   )
-------------------- Fine calcolo della Sede del Anagrafica -------------------------------------------------

-- Importi raggruppati per Aliquota, o Natua, se l'operazione non rientra tra quelle imponibili (ossia aliquota = 0)
	select 
		ID.invoicekind,
		I.idinvkind, I.yinv, I.ninv,
		CONVERT(decimal(19,2),ivakind.rate*100) as 'AliquotaIVA',
		null as 'Natura',
		isnull(sum(ID.taxable_euro),0) as 'ImponibileImporto',
		isnull(sum(ID.iva_euro),0) as 'Imposta',
		0 as 'Detraibile', -- è un campo facoltativo, per cui lo escludiamo
		'' as 'Deducibile', -- è un campo facoltativo, per cui lo escludiamo
		case 
			when isnull(I.flag_enable_split_payment,'N')='S' then 'S' --> Scissione dei pagamenti
			when isnull(I.flagdeferred,'N')='S' then 'D'
			else 'I' 
		end as 'EsigibilitaIVA'
	from invoice I 
	join invoicedetailview ID
		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
	join registry R
		on R.idreg = I.idreg
	join ivakind
		on ivakind.idivakind = ID.idivakind
	join invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN #SedeAnagrafica				ON #SedeAnagrafica.idreg = I.idreg
	where  month(I.adate) between @meseinizio and @mesefine and YEAR(I.adate) = @esercizio
			AND IRK.flagactivity = 2-- Commerciale 
			AND IRK.registerclass = @kind
			AND isnull(IK.enable_fe,'N')='N' --> dobbiamo escludere i tipo :  Utilizzabile nella Fattura Elettronica = S
			AND isnull(IRK.compensation,'N') = 'N' -- Esclude i registri corrispettivi
			AND (
				 @kind = 'V' AND (flagbuysell  ='V')  AND I.idsdi_vendita is null /* Esclude le F.E.*/
				OR
				@kind = 'A' AND (flagbuysell  ='A')   	AND I.idsdi_acquisto is null /* Esclude le F.E.*/
			)
			AND isnull(ivakind.rate ,0) >0
			AND isnull(taxable_euro,0) <>0 
			and (isnull(I.flagbit,0)&8)=0   --- non escludere da invio dati fatture
			and (isnull(I.flagbit,0)&1)=0   --- no bolletta doganale
	group by I.idinvkind,ID.invoicekind, I.yinv, I.ninv,ivakind.rate,I.flagdeferred,I.flag_enable_split_payment, ID.fereferencerule

	union 

	select 
		ID.invoicekind,
		I.idinvkind, I.yinv, I.ninv,
		0 as 'AliquotaIVA',
		ivakind.idfenature as 'Natura',
		sum(ID.taxable_euro) as 'ImponibileImporto',
		isnull(sum(ID.iva_euro),0) as 'Imposta',
		0 as 'Detraibile', -- è un campo facoltativo, per cui lo escludiamo
		'' as 'Deducibile', -- è un campo facoltativo, per cui lo escludiamo
		case 
			when isnull(I.flag_enable_split_payment,'N')='S' then 'S' --> Scissione dei pagamenti
			when isnull(I.flagdeferred,'N')='S' then 'D'
			else 'I' 
		end as 'EsigibilitaIVA'
	from invoice I 
	join invoicedetailview ID
		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
	join invoicekind IK				ON IK.idinvkind = I.idinvkind
	join ivakind
		on ivakind.idivakind = ID.idivakind
	join registry R
		on R.idreg = I.idreg
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN #SedeAnagrafica				ON #SedeAnagrafica.idreg = I.idreg
	where  month(I.adate) between @meseinizio and @mesefine and YEAR(I.adate) = @esercizio
		AND (
			@kind = 'V' AND (flagbuysell  ='V')  AND I.idsdi_vendita is null /* Esclude le F.E.*/
			OR
			@kind = 'A' AND (flagbuysell  ='A')   AND I.idsdi_acquisto is null /* Esclude le F.E.*/
			)
		AND IRK.flagactivity = 2-- Commerciale 
		AND IRK.registerclass = @kind
		AND isnull(IRK.compensation,'N') = 'N' -- Esclude i registri corrispettivi
		and isnull(ivakind.rate ,0) =0
		AND isnull(taxable_euro,0) <>0 
		and (isnull(I.flagbit,0)&8)=0   --- non escludere da invio dati fatture
		and (isnull(I.flagbit,0)&1)=0   --- no bolletta doganale
	group by I.idinvkind,ID.invoicekind, I.yinv, I.ninv,ivakind.idfenature,I.flagdeferred,ID.fereferencerule,I.flag_enable_split_payment
	order by ID.invoicekind, I.yinv, I.ninv
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
  