
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


if exists (select * from dbo.sysobjects where id = object_id(N'[split_invoicedetail_expense_nliqu]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [split_invoicedetail_expense_nliqu]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE          PROCEDURE [split_invoicedetail_expense_nliqu]
(
	@ayear int 
)
AS
BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
CREATE TABLE #invoicedetail(
	idinvkind int,
	yinv int,
	ninv int,
	rownum int,
	taxable decimal (19,2),
	tax decimal (19,2),
	unabatable decimal (19,2),
	discount decimal (19,2),
	number int,
	idexp_taxable int,
	idexp_iva int,
	idgroup int,
	idmankind varchar(20),
	yman int , 
	nman int, 
	manrownum int,
	estimrownum int,
	nestim int,
	yestim int,
	idaccmotive varchar(36) ,
	idestimkind varchar(20),
	idinc_iva int,
	idinc_taxable int,
	idivakind int,
	annotations varchar(400),
	competencystart datetime,
	competencystop datetime,
	detaildescription varchar(150),
	idsor1 int,
	idsor2 int,
	idsor3 int
	)

CREATE TABLE #expense (idexp int)-- contiene i pagamenti della fattura

declare @idinvkind int
declare @yinv int
declare @ninv int
declare @rownum int
declare @yivapay int
declare @nivapay int
declare @contarighe int

declare @totimponibile_desiderato decimal (19,2)
declare @totiva_desiderata decimal (19,2)
declare @epsilon_impon double precision
declare @nidexp int 
declare @nidexp_pay int 
declare @idgroup int
declare @maxrownum int 
declare @row_i int
declare @totalefattura decimal (19,2)
declare @nliquidazioni int

declare @elabora int
declare @totimponibileeffettivo decimal (19,2)

declare @totivaeffettivo decimal (19,2)

declare @epsilon_Max double precision
declare @epsilon_c double precision
declare @epsilon_min double precision

declare @epsilon_iva_Max double precision
declare @epsilon_iva_c double precision
declare @epsilon_iva_min double precision

declare @fmin decimal (19,2)
declare @fmax decimal (19,2)
declare @erroreprecedente decimal (19,2)
declare @totalpayed decimal (19,2)

declare @rapporto decimal(19,6)
declare @totfattura decimal (19,6)

declare @totaleimponibile decimal (19,2)
declare @erroredetraibileprec double precision
declare @curramount decimal (19,2)
declare @rapportopag double precision
declare @desideratoprec decimal(19,2)
declare @detraibile_desideratoprec decimal(19,2)
declare @detraibiledesiderato decimal(19,2)
declare @detraibileeffettivo decimal(19,2)
declare @detraibiletotale decimal (19,2)
declare @indetraibileeffettivo decimal (19,2)
declare @epsilon_ivaun_Max double precision 
declare @epsilon_ivaun_c double precision 
declare @epsilon_ivaun_min double precision 


DECLARE invoicecursor INSENSITIVE CURSOR FOR
-- fatture pure contab. con + pagamenti aventi idexp_taxable e idexp_iva a null 

SELECT invoicedeferred.idinvkind,invoicedeferred.yinv,invoicedeferred.ninv,invoicedeferred.yivapay,invoicedeferred.nivapay
FROM invoice 
JOIN invoicedetail
	ON invoice.idinvkind = invoicedetail.idinvkind
	and invoice.yinv = invoicedetail.yinv
	and invoice.ninv = invoicedetail.ninv
join expenseinvoice
	ON invoice.idinvkind = expenseinvoice.idinvkind
	and invoice.yinv = expenseinvoice.yinv
	and invoice.ninv = expenseinvoice.ninv
JOIN paymentcommunicated
	ON paymentcommunicated.idexp = expenseinvoice.idexp
join invoicedeferred
	on expenseinvoice.idinvkind = invoicedeferred.idinvkind
	and expenseinvoice.yinv = invoicedeferred.yinv 
	and expenseinvoice.ninv = invoicedeferred.ninv
join ivapay
	on invoicedeferred.yivapay = ivapay.yivapay
	and invoicedeferred.nivapay = ivapay.nivapay
join invoicekind
	on invoicekind.idinvkind = invoice.idinvkind
WHERE invoicedetail.yinv = @ayear and expenseinvoice.movkind = 1
	AND ((invoicekind.flag & 1) = 0)  AND  ((invoicekind.flag & 4 ) =0 )
	and ivapay.paymentkind ='C'
	AND (isnull(invoice.flagdeferred,'N') ='S')
	AND (
		(select count(*) from invoicedeferred 
		where idinvkind = invoicedetail.idinvkind
		    and yinv = invoicedetail.yinv 
		    and ninv = invoicedetail.ninv)>1
		OR -- la fattura non è stata liquidata totalmentema parzialmente
		ISNULL((select sum(ISNULL(taxabletotal,0) + ISNULL(ivatotal,0)) from invoiceresidual 
			where idinvkind = invoicedetail.idinvkind
			    and yinv = invoicedetail.yinv 
			    and ninv = invoicedetail.ninv),0)
			 >
		ISNULL((select sum(isnull(totalpayed,0)) from invoicedeferred
		        where  idinvkind = invoicedetail.idinvkind
			    and yinv = invoicedetail.yinv 
			    and ninv = invoicedetail.ninv),0)
		)
	AND ((select count(distinct rate) from ivakind  
		where ivakind.idivakind = invoicedetail.idivakind) = 1)
	AND invoicedetail.idexp_taxable is null AND invoicedetail.idexp_iva is null
	AND invoicedetail.idmankind is null AND invoicedetail.yman is null AND invoicedetail.nman is null

GROUP BY invoicedeferred.idinvkind,invoicedeferred.yinv,invoicedeferred.ninv,invoicedeferred.yivapay,invoicedeferred.nivapay
ORDER BY invoicedeferred.idinvkind,invoicedeferred.yinv,invoicedeferred.ninv
--HAVING count(distinct expenseinvoice.idexp) >1	
FOR READ ONLY
OPEN invoicecursor FETCH NEXT FROM invoicecursor INTO /*@nidexp,*/@idinvkind,@yinv,@ninv,@yivapay,@nivapay
WHILE @@FETCH_STATUS = 0
BEGIN

SELECT @totalpayed= totalpayed from invoicedeferred where
	 invoicedeferred.idinvkind = @idinvkind and invoicedeferred.yinv = @yinv and invoicedeferred.ninv = @ninv
				and nivapay=@nivapay and yivapay=@yivapay

print @idinvkind print @yinv print @ninv print @yivapay print @nivapay
-- prendo i pagamenti della fattura
	INSERT INTO #expense 
	SELECT expenseinvoice.idexp 
	FROM expenseinvoice
	JOIN paymentcommunicated
		ON paymentcommunicated.idexp = expenseinvoice.idexp
	join invoicedeferred
		on expenseinvoice.idinvkind = invoicedeferred.idinvkind
		and expenseinvoice.yinv = invoicedeferred.yinv 
		and expenseinvoice.ninv = invoicedeferred.ninv
	join ivapay
		on invoicedeferred.yivapay = ivapay.yivapay
		and invoicedeferred.nivapay = ivapay.nivapay
	WHERE invoicedeferred.idinvkind = @idinvkind and invoicedeferred.yinv = @yinv and invoicedeferred.ninv = @ninv
	and invoicedeferred.yivapay = @yivapay and invoicedeferred.nivapay = @nivapay
	and paymentcommunicated.competencydate BETWEEN ivapay.start AND ivapay.stop

	SELECT @nidexp_pay = COUNT(*) FROM #expense
-- Faccio la copia di invoicedetail
	declare @prorata decimal (19,2) select @prorata = prorata from iva_prorata where ayear = @ayear
	declare @mixed decimal (19,2) 	select @mixed = mixed from iva_mixed 
	declare @flagmixed char 	
	SET @flagmixed = (SELECT	 
	CASE
		WHEN (flag & 2 <>0) THEN 'S'
		ELSE	 'N'
	END
	FROM invoicekind WHERE idinvkind = @idinvkind )

	IF NOT EXISTS (select * from #invoicedetail where  idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv) 
	BEGIN
		INSERT INTO #invoicedetail (idinvkind,yinv,ninv,rownum,idgroup,
				taxable,tax,unabatable,discount,
				idmankind,yman, nman, manrownum,
				idestimkind,yestim,nestim,estimrownum,
				idaccmotive ,
				idexp_iva,idexp_taxable ,
				idinc_iva,idinc_taxable ,
				idivakind,
				annotations ,
				competencystart ,
				competencystop ,
				detaildescription ,
				idsor1,idsor2,idsor3,
				number
			)
			select @idinvkind,@yinv,@ninv,rownum,idgroup,
				taxable,tax,unabatable,discount,
				idmankind,yman,nman,manrownum,
				idestimkind,yestim,nestim,estimrownum,
				idaccmotive ,
				idexp_iva,idexp_taxable ,
				idinc_iva,idinc_taxable ,
				idivakind,
				annotations,
				competencystart ,
				competencystop ,
				detaildescription ,
				idsor1,idsor2,idsor3,
				number
			from invoicedetail 
		where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv
		SET @erroreprecedente=0
		SET @erroredetraibileprec = 0
	END

-- Servirà dopo nello split
	declare @nrow int 
	select  @nrow = max(rownum)  from invoicedetail 
				where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv

	declare @exchangerate float
	select @exchangerate = exchangerate from invoice
				where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv
-- Per ogni pagamento della fattura: si calcola @epsilon_impon_c, @epsilon_iva_c, @epsilon_ivaun_c
	declare @idexp int

	set @desideratoprec = 0	
	set @detraibile_desideratoprec = 0

	select @totaleimponibile = isnull(totalpayed,0) - isnull(ivatotalpayed,0)
	from invoicedeferred 
	where invoicedeferred.idinvkind = @idinvkind and invoicedeferred.yinv = @yinv 
		and invoicedeferred.ninv = @ninv and nivapay=@nivapay and yivapay=@yivapay

	select @totfattura= taxabletotal+ivatotal from totinvoiceview 
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
	
	set @rapporto= @totalpayed/@totfattura

	while (@nidexp_pay>0) 
	begin
		set @nidexp_pay = @nidexp_pay - 1

		set @idexp = (select top 1 idexp from #expense)
		set @curramount = (select isnull(amount,0)	from expenseyear  where idexp = @idexp )

		set @epsilon_impon = 0.5/*(select isnull(curramount,0)
					from expensetotal 
					where idexp = @idexp )
					/
				(select (isnull(totalpayed,0))
				from invoicedeferred
				where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv 
				and yivapay = @yivapay and nivapay = @nivapay)*/
		set @rapportopag = (select isnull(amount,0)
					from expenseyear
					where idexp = @idexp )
					/
				(select (isnull(totalpayed,0))
				from invoicedeferred
				where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv 
				and yivapay = @yivapay and nivapay = @nivapay)

		if (@nidexp_pay = 0)
			Begin
			   set @totimponibile_desiderato = @totaleimponibile - @desideratoprec
			End
		else 
			Begin
			  set @totimponibile_desiderato = Round(@totaleimponibile*@rapportopag,2)
			  set @desideratoprec = @desideratoprec + @totimponibile_desiderato
			End
		set @totimponibile_desiderato = @totimponibile_desiderato+@erroreprecedente

		
print '@totimponibile_desiderato: '
print @totimponibile_desiderato

print '@idexp: ' print @idexp


-- Ora cerca i tre epsilon 
 		set @elabora = 0
		set @epsilon_Max = 1 /*@epsilon_impon + 1*/
		set @epsilon_c = @epsilon_impon
		set @epsilon_min = 0
		set @fmin = 0
		select @fmax = CONVERT(DECIMAL(19,2),
				      ISNULL(SUM(
				              ROUND(taxable
						 * number 
						 * CONVERT(decimal(19,6),@exchangerate) * 
				                 (1 - CONVERT(decimal(19,6),ISNULL(discount, 0.0))),2)           
				         ),0)
				      )
		from #invoicedetail
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
			and idexp_taxable is null and idexp_iva is null
		--SET @fmax= @fmax+@erroreprecedente

print '@fmax: 'print @fmax

		WHILE (@elabora<30)-- questo cicla finchè non quadra 
		Begin
			
			select @totimponibileeffettivo = CONVERT(DECIMAL(19,2),
				      ISNULL(SUM(
				              ROUND(round(dbo.GetImponibileNear(taxable*@epsilon_c, taxable, number,discount,@exchangerate),2)
						 * number 
						 * CONVERT(decimal(19,6),@exchangerate) * 
				                 (1 - CONVERT(decimal(19,6),ISNULL(discount, 0.0))),2)           
				         ),0)
				      )
			from #invoicedetail
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
			and idexp_taxable is null and idexp_iva is null
			
			IF -- dobbiamo diminuire epsilon
			(@totimponibileeffettivo > @totimponibile_desiderato)
			Begin
				 set @epsilon_Max = @epsilon_c
				 set @fmax = @totimponibileeffettivo
			End
			IF  -- dobbiamo aumentare epsilon
			(@totimponibileeffettivo < @totimponibile_desiderato)
			Begin
				set @epsilon_min = @epsilon_c
				set @fmin =@totimponibileeffettivo 
			End
			IF -- abbiamo quadrato e trovato @epsilon_c 
			(@totimponibileeffettivo = @totimponibile_desiderato OR @fmin = @fmax OR @epsilon_min = @epsilon_Max)
				Begin
					set @elabora = 200
				End


/*			
print ''
print 'Elaborazione n. : ' print @elabora
print '@epsilon_Max' print @epsilon_Max
print '@epsilon_c'print @epsilon_c
print '@epsilon_min' print @epsilon_min
*/
--print '@totimponibileeffettivo:'print @totimponibileeffettivo
/*
print '@fmin :' print @fmin
print '@fmax :' print @fmax
*/

			set @elabora = @elabora + 1
			
			if (@elabora<30)
			 set @epsilon_c = @epsilon_min + ((@epsilon_Max-@epsilon_min)*(@totimponibile_desiderato -@fmin))/(@fmax-@fmin)

		End

print '--------------------------  @totimponibileeffettivo trovato :  ------------------------'
print @totimponibileeffettivo
print '@epsilon_c' print @epsilon_c
set @erroreprecedente =@totimponibile_desiderato -@totimponibileeffettivo 
print '@erroreprecedente' print @erroreprecedente
--print 'Fine @elabora : ' print @elabora
---------------------------------- ciclo x trovare l'epsilon IVA --------------------------------------
		declare @epsilon_iva float
		set @epsilon_iva  = @epsilon_c /*@epsilon_impon */
		set @fmin = 0		
		select @fmax =	 CONVERT(DECIMAL(19,2),
				ISNULL(SUM(Round(Round(tax,2)
				*CONVERT(decimal(19,6), @exchangerate),2)	
				   ),0)
				)
			from #invoicedetail
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
			and idexp_taxable is null and idexp_iva is null

		set @totiva_desiderata = (select isnull(amount,0)
					from expenseyear 
					where idexp = @idexp )
					-
				(select CONVERT(DECIMAL(19,2),
				      ISNULL(SUM(
				              ROUND(round(dbo.GetImponibileNear(taxable*@epsilon_c, taxable, number,discount,@exchangerate),2)
						 * number 
						 * CONVERT(decimal(19,6),@exchangerate) * 
				                 (1 - CONVERT(decimal(19,6),ISNULL(discount, 0.0))),2)           
				         ),0)
				      )
			from #invoicedetail
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
			and idexp_taxable is null and idexp_iva is null)
		
		print 'iva desiderata:' print @totiva_desiderata

		set @epsilon_iva_Max = 1/*@epsilon_iva + 0.1*/
		set @epsilon_iva_c = @epsilon_iva
		set @epsilon_iva_min = 0/*@epsilon_iva - 0.1*/
		

		set @elabora = 0

		WHILE (@elabora<30 and @epsilon_c<>1)-- questo cicla finchè non quadra 
		Begin

			select @totivaeffettivo =
						 CONVERT(DECIMAL(19,2),
						ISNULL(SUM(Round(Round(tax*@epsilon_iva_c,2)
						*CONVERT(decimal(19,6), @exchangerate),2)	
						   ),0)
						)
			from #invoicedetail
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
			and idexp_taxable is null and idexp_iva is null

			IF -- dobbiamo diminuire epsilon
			(@totivaeffettivo > @totiva_desiderata)
			Begin
				 set @epsilon_iva_Max = @epsilon_iva_c
				 set @fmax = @totivaeffettivo	
			End
			IF  -- dobbiamo aumentare epsilon
			(@totivaeffettivo < @totiva_desiderata)
			Begin
				set @epsilon_iva_min = @epsilon_iva_c
				set @fmin =@totivaeffettivo 
			End
print '@totivaeffettivo:'print @totivaeffettivo

			IF -- abbiamo quadrato e trovato @epsilon_c 
			(@totivaeffettivo = @totiva_desiderata OR @fmin = @fmax)
				Begin
					set @elabora = 200
				End


			set @elabora = @elabora +1

			if (@elabora < 30)
			 set @epsilon_iva_c = @epsilon_iva_min + ((@epsilon_iva_Max-@epsilon_iva_min)*(@totiva_desiderata -@fmin))/(@fmax-@fmin)

		End

print '--------------------------  @totivaeffettivo trovato :  -------------------------------'
print @totivaeffettivo
print '@epsilon_iva_c' print @epsilon_iva_c
--print 'Fine @elabora : ' print @elabora
---------------------------------- ciclo x trovare l'epsilon IVA UNABATABLE     --------------------------------------------------
		select @detraibiletotale =  SUM(ROUND(
						(tax - ISNULL(unabatable,0)) * @exchangerate * @rapporto
					      * ISNULL(@prorata,0) *
					    CASE
					     WHEN @flagmixed = 'S' THEN ISNULL(@mixed,0)
					     ELSE 1
					    END
					    ,2))
		from invoicedetail
		where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
		and idexp_taxable is null and idexp_iva is null

		/*select @detraibiledesiderato =  SUM(ROUND(
						(tax - ISNULL(unabatable,0)) * @exchangerate * @rapporto
					      * ISNULL(@prorata,0) *
					    CASE
					     WHEN @flagmixed = 'S' THEN ISNULL(@mixed,0)
					     ELSE 1
					    END
					    ,2))
		from invoicedetail
		where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
		and idexp_taxable is null and idexp_iva is null*/

		if (@nidexp_pay = 0)
			Begin
			   set @detraibiledesiderato = @detraibiletotale - @detraibile_desideratoprec
			End
		else 
			Begin
			  set @detraibiledesiderato = Round(@detraibiletotale*@rapportopag,2)
			  set @detraibile_desideratoprec = @detraibile_desideratoprec + @detraibiledesiderato
			End

		set @detraibiledesiderato = @detraibiledesiderato+@erroredetraibileprec

print '@detraibiledesiderato' print @detraibiledesiderato

		set @elabora = 0
		set @epsilon_ivaun_Max = 1
		set @epsilon_ivaun_c = @epsilon_c
		set @epsilon_ivaun_min = 0
				
		select @fmax = SUM(
				Round((Round(tax * @epsilon_iva_c,2)) * @exchangerate
					    * ISNULL(@prorata,0) *
					    CASE
					     WHEN @flagmixed = 'S' THEN ISNULL(@mixed,0)
					     ELSE 1
					    END
					    ,2)
					    )
			from #invoicedetail
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv 
			and idexp_taxable is null and idexp_iva is null

		select @fmin = SUM(
				Round((Round(tax * @epsilon_iva_c,2)-unabatable) * @exchangerate
					    * ISNULL(@prorata,0) *
					    CASE
					     WHEN @flagmixed = 'S' THEN ISNULL(@mixed,0)
					     ELSE 1
					    END
					,2)
					    )
			from #invoicedetail
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv 
			and idexp_taxable is null and idexp_iva is null
			and Round(tax * @epsilon_iva_c,2)>unabatable

--print '@fmin :' print @fmin
--print '@fmax :' print @fmax

		WHILE (@elabora<30 and @epsilon_c<>1)-- questo cicla finchè non quadra 
		Begin
			-- E' calcolato come: (iva lorda - iva detraibile) = ina ivaindetraibile

			select @detraibileeffettivo = SUM(
				ROUND( (Round(tax * @epsilon_iva_c,2)-Round(unabatable*@epsilon_ivaun_c,2)) * @exchangerate
					    * ISNULL(@prorata,0) *
					    CASE
					     WHEN @flagmixed = 'S' THEN ISNULL(@mixed,0)
					     ELSE 1
					    END
					    ,2))
			from #invoicedetail
			where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv 
			and idexp_taxable is null and idexp_iva is null

--print '@detraibileeffettivo' print @detraibileeffettivo

			IF -- dobbiamo diminuire epsilon
			(@detraibileeffettivo < @detraibiledesiderato)
			Begin
				 set @epsilon_ivaun_Max = @epsilon_ivaun_c
				 set @fmax=@detraibileeffettivo
			End
			IF  -- dobbiamo aumentare epsilon
			(@detraibileeffettivo > @detraibiledesiderato)
			Begin
				set @epsilon_ivaun_min = @epsilon_ivaun_c
				 set @fmin=@detraibileeffettivo
			End

			IF -- abbiamo quadrato e trovato @epsilon_c 
			(@detraibileeffettivo = @detraibiledesiderato OR @fmin=@fmax)
				Begin
					set @elabora = 100
				End

		set @elabora = @elabora +1
		if (@elabora < 30)
			 set @epsilon_ivaun_c = @epsilon_ivaun_min + ((@epsilon_ivaun_Max-@epsilon_ivaun_min)*(@detraibiledesiderato -@fmin))/(@fmax-@fmin)

		End
set @erroredetraibileprec =@detraibiledesiderato - @detraibileeffettivo 

print '@detraibileeffettivo' print @detraibileeffettivo

print '@epsilon_ivaun_c' print @epsilon_ivaun_c

		if (@epsilon_c=1) BEGIN
			UPDATE #invoicedetail SET 
				idexp_iva=@idexp,	
				idexp_taxable =@idexp
			WHERE idinvkind = @idinvkind and yinv = @yinv and ninv = @ninv and rownum <= @nrow
				and idexp_taxable is null and idexp_iva is null

		END
		ELSE BEGIN
-------------------------------- Split della fattura ----------------------------------------------------------------------------------
		select  @maxrownum = max (rownum) from #invoicedetail
					where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv

		select @idgroup = max(idgroup) from #invoicedetail
				 	where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv
		set @row_i = 1
		set @contarighe=1

		IF (@nidexp_pay+1>0)---if (@nidexp_pay>1)--if (@nidexp>0)
		Begin
			WHILE (@row_i <= @nrow)
			Begin
-- La riga n+1 avrà taxable[n+1] = taxable[1]*epsilon
-- La riga n+2 avrà taxable[n+2] = taxable[2]*epsilon
-- ...
-- la riga n+i avrà taxable[n+i] = taxable[i]*epsilon
			if exists(select * from #invoicedetail where rownum=@row_i) begin
			Insert into #invoicedetail(idinvkind,yinv,ninv,rownum,idgroup,
				taxable,tax,unabatable,discount,
				idmankind,yman, nman, manrownum,
				idestimkind,yestim,nestim,estimrownum,
				idaccmotive,
				idexp_iva,idexp_taxable ,
				idinc_iva,idinc_taxable ,
				idivakind,
				annotations ,
				competencystart ,
				competencystop ,
				detaildescription ,
				idsor1,idsor2,idsor3,
				number
			)
			Select  @idinvkind,@yinv,@ninv,@contarighe+@maxrownum,idgroup,
				round(dbo.GetImponibileNear(taxable*@epsilon_c, taxable, number,discount,@exchangerate),2),
				Round(tax * @epsilon_iva_c,2),Round(unabatable*@epsilon_ivaun_c,2),discount,
				idmankind,yman,nman,manrownum,
				idestimkind,yestim,nestim,estimrownum,
				idaccmotive ,
				@idexp,@idexp ,
				idinc_iva,idinc_taxable ,
				idivakind,
				annotations ,
				competencystart ,
				competencystop ,
				detaildescription ,
				idsor1,idsor2,idsor3,
				number
			from #invoicedetail as c
			where idinvkind = @idinvkind and yinv = @yinv and ninv = @ninv and rownum=@row_i
				and idexp_taxable is null and idexp_iva is null
			set @contarighe=@contarighe+1
			end

			set @row_i = @row_i+1
			

			End --> while (@row_i <= @maxrownum)

		--imposta il residuo della fattura nei dettagli originali
		UPDATE #invoicedetail SET 
-- la k-esima riga avrà taxable uguale al suo taxable - la parte che ha ceduto al suo split
-- la 1 riga avrà taxable[1]' = taxable[1]-taxable[1]*epsilon
			taxable = 
				ISNULL(( isnull(taxable,0) - 
					round(dbo.GetImponibileNear(taxable*@epsilon_c, taxable, number,discount,@exchangerate),2)	
					),0) 
				,
			 tax = 
				ISNULL(( isnull(tax,0) - 
					round(tax*@epsilon_iva_c,2)	
					),0) 
				,
			unabatable = 
				ISNULL(( isnull(unabatable,0) -
					round(unabatable*@epsilon_ivaun_c,2)	
					),0) 
				
		WHERE idinvkind = @idinvkind and yinv = @yinv and ninv = @ninv and rownum <= @nrow
			and idexp_taxable is null and idexp_iva is null

		end -- end dell'if

		END

--------------------------------- fine split fattura  --------------------------------------------------

		delete from #expense where idexp = @idexp
	
	end 


	FETCH NEXT FROM invoicecursor INTO @idinvkind,@yinv,@ninv,@yivapay,@nivapay
END
	DEALLOCATE invoicecursor
/*
	select * from #invoicedetail as C
		where 
				exists (select * from invoicedetail CC where 
						CC.idinvkind=C.idinvkind and 
						CC.yinv=C.yinv and 
						CC.ninv=C.ninv and 
						CC.rownum=C.rownum)



	select * from #invoicedetail as c
			where 
				not exists (select * from invoicedetail CC where 
						CC.idinvkind=C.idinvkind and 
						CC.yinv=C.yinv and 
						CC.ninv=C.ninv and 
						CC.rownum=C.rownum)
*/

	--Aggiorna le righe del db 
	update invoicedetail set 
		taxable=#invoicedetail.taxable,
		tax=#invoicedetail.tax,
		unabatable=#invoicedetail.unabatable,
		idexp_taxable=#invoicedetail.idexp_taxable,
		idexp_iva=#invoicedetail.idexp_iva
	from #invoicedetail
	WHERE 	invoicedetail.idinvkind = #invoicedetail.idinvkind and 
		invoicedetail.yinv = #invoicedetail.yinv and 
		invoicedetail.ninv = #invoicedetail.ninv and 
		invoicedetail.rownum = #invoicedetail.rownum and -- nrow
		invoicedetail.idexp_taxable is null and invoicedetail.idexp_iva is null
	


	--Aggiunge le nuove righe nel db
	Insert into invoicedetail(idinvkind,yinv,ninv,rownum,idgroup,
				taxable,tax,unabatable,discount,
				idmankind,yman, nman, manrownum,
				idestimkind,yestim,nestim,estimrownum,
				idaccmotive,
				idexp_iva,idexp_taxable ,
				idinc_iva,idinc_taxable ,
				idivakind,
				annotations ,
				competencystart ,
				competencystop ,
				detaildescription ,
				idsor1,idsor2,idsor3,
				number,lt,lu,ct,cu
			)
			Select  c.idinvkind,c.yinv,c.ninv,c.rownum,c.idgroup,
				c.taxable,c.tax,c.unabatable,c.discount,
				c.idmankind,c.yman, c.nman, c.manrownum,
				c.idestimkind,c.yestim,c.nestim,c.estimrownum,
				c.idaccmotive,
				c.idexp_iva,c.idexp_taxable ,
				c.idinc_iva,c.idinc_taxable ,
				c.idivakind,
				c.annotations ,
				c.competencystart ,
				c.competencystop ,
				c.detaildescription ,
				c.idsor1,c.idsor2,c.idsor3,
				c.number,getdate(),'split',getdate(),'split'
			from #invoicedetail as c
			where 
				not exists (select * from invoicedetail CC where 
						CC.idinvkind=C.idinvkind and 
						CC.yinv=C.yinv and 
						CC.ninv=C.ninv and 
						CC.rownum=C.rownum)

	--select * from #invoicedetail


drop table #invoicedetail


END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

