
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


if exists (select * from dbo.sysobjects where id = object_id(N'[split_invoicedetail_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [split_invoicedetail_expense]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- ultima,  aggiorna anche il db
CREATE             PROCEDURE [split_invoicedetail_expense]
(
	@ayear int 
)
AS
BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
-- questa sp elabora fatture pure contab. con + pagamenti aventi idexp_taxable e idexp_iva a null 
-- liquidate con 1 liq. o non liquidate
CREATE    TABLE #invoicedetail(
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
	idivakind int ,
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
declare @contarighe int
declare @nidexp int
declare @idgroup int
declare @maxrownum int 
declare @row_i int
declare @totalefattura decimal (19,2)
declare @nrow int
declare @prorata decimal (19,2)
declare @mixed decimal (19,2) 
declare @flagmixed char 	
declare @idexp int
declare @exchangerate float
declare @liquidata int
declare @elabora int	

declare @epsilon_impon double precision
declare @totimponibile_desiderato decimal (19,2)
declare @totimponibileeffettivo decimal (19,2)
declare @epsilon_Max double precision 
declare @epsilon_c double precision
declare @epsilon_min double precision

declare @totiva_desiderata decimal (19,2)
declare @totivaeffettivo decimal (19,2)

declare @epsilon_iva_Max double precision
declare @epsilon_iva_c double precision
declare @epsilon_iva_min double precision

declare @detraibiledesiderato decimal (19,2)
declare @detraibileeffettivo decimal (19,2)
declare @epsilon_ivaun double precision
declare @epsilon_ivaun_Max double precision
declare @epsilon_ivaun_c double precision 
declare @epsilon_ivaun_min double precision

declare @fmin decimal (19,2)
declare @fmax decimal (19,2)
declare @erroreprecedente decimal (19,2)
declare @totalpayed decimal (19,2)
declare @rapportopag double precision
declare @desideratoprec decimal(19,2)
declare @detraibile_desideratoprec decimal(19,2)
declare @totaleimponibile decimal (19,2)
declare @detraibiletotale decimal (19,2)
declare @erroredetraibileprec double precision

DECLARE invoicecursor INSENSITIVE CURSOR FOR

SELECT COUNT(DISTINCT expenseinvoice.idexp),invoice.idinvkind,invoice.yinv,invoice.ninv
FROM invoice 
JOIN invoicedetail
	ON invoice.idinvkind = invoicedetail.idinvkind
	and invoice.yinv = invoicedetail.yinv
	and invoice.ninv = invoicedetail.ninv
join expenseinvoice
	ON invoice.idinvkind = expenseinvoice.idinvkind
	and invoice.yinv = expenseinvoice.yinv
	and invoice.ninv = expenseinvoice.ninv
join invoicekind
	on invoicekind.idinvkind = invoice.idinvkind
WHERE invoicedetail.yinv = @ayear and expenseinvoice.movkind = 1
	AND ((invoicekind.flag & 1) = 0)  AND  ((invoicekind.flag & 4 ) =0 )
	AND ISNULL(invoice.flagdeferred,'N') ='S'
	AND (
		(select COUNT(*) from invoicedeferred
		where idinvkind = invoicedetail.idinvkind
		    and yinv = invoicedetail.yinv 
		    and ninv = invoicedetail.ninv)=1
		AND
		ISNULL((select SUM(ISNULL(taxabletotal,0) + ISNULL(ivatotal,0)) from invoiceresidual 
			where idinvkind = invoicedetail.idinvkind
			    and yinv = invoicedetail.yinv 
			    and ninv = invoicedetail.ninv),0)
			 =
		ISNULL((select sum(ISNULL(totalpayed,0)) from invoicedeferred
		        where  idinvkind = invoicedetail.idinvkind
			    and yinv = invoicedetail.yinv 
			    and ninv = invoicedetail.ninv),0)
		OR (select COUNT(*) from invoicedeferred
		where idinvkind = invoicedetail.idinvkind
		    and yinv = invoicedetail.yinv 
		    and ninv = invoicedetail.ninv)=0)
	AND ((select COUNT(DISTINCT rate) from ivakind  
		where ivakind.idivakind = invoicedetail.idivakind) = 1)-- 	> 1
	AND invoicedetail.idexp_taxable is null AND invoicedetail.idexp_iva is null
	AND invoicedetail.idmankind is null AND invoicedetail.yman is null AND invoicedetail.nman is null

GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv
HAVING COUNT(DISTINCT expenseinvoice.idexp) >1	
ORDER BY invoice.idinvkind,invoice.yinv,invoice.ninv 
FOR READ ONLY
OPEN invoicecursor FETCH NEXT FROM invoicecursor INTO @nidexp,@idinvkind,@yinv,@ninv
WHILE @@FETCH_STATUS = 0
BEGIN

-- prendo i pagamenti della fattura
	INSERT INTO #expense 
	SELECT idexp 
	FROM expenseinvoice
	WHERE idinvkind = @idinvkind and yinv = @yinv and ninv = @ninv

-- faccio la copia di invoicedetail
	INSERT INTO #invoicedetail
	(
		idinvkind,yinv,ninv,rownum,idgroup,
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
	SELECT
		@idinvkind,@yinv,@ninv,rownum,idgroup,
		taxable,tax,unabatable,disCOUNT,
		idmankind,yman,nman,manrownum,
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
	FROM invoicedetail 
	WHERE idinvkind = @idinvkind AND yinv = @yinv AND ninv = @ninv
	SET @erroreprecedente=0
	SET @erroredetraibileprec = 0 

-- Servirà dopo nello split
	select  @nrow = max(rownum)  
	from invoicedetail 
	where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv

	select @exchangerate = exchangerate 
	from invoice
	where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv

-- controlla se la fattura è stata liquidata
	if (select COUNT(*) from invoicedeferred 
			    where idinvkind = @idinvkind and yinv = @yinv and ninv = @ninv)>0	 
		set @liquidata = 1
	else 	
		set @liquidata = 0

-- Per ogni pagamento della fattura: si calcola @epsilon_impon_c, @epsilon_iva_c, @epsilon_ivaun_c
	select @prorata = prorata from iva_prorata where ayear = @ayear
	select @mixed = mixed from iva_mixed 
	SET @flagmixed = (SELECT	 
	CASE
		WHEN (flag & 2 <>0) THEN 'S'
		ELSE	 'N'
	END
	FROM invoicekind WHERE idinvkind = @idinvkind )
	
	set @desideratoprec = 0	
	set @detraibile_desideratoprec = 0

	if (@liquidata = 1)
	Begin
		select @totaleimponibile = isnull(totalpayed,0) - isnull(ivatotalpayed,0)
		from invoicedeferred 
		where invoicedeferred.idinvkind = @idinvkind 
			and invoicedeferred.yinv = @yinv 
			and invoicedeferred.ninv = @ninv 
	End
	Else
	Begin
		select @totaleimponibile = isnull(taxabletotal,0)
		from invoiceresidual
		where invoiceresidual.idinvkind = @idinvkind 
			and invoiceresidual.yinv = @yinv 
			and invoiceresidual.ninv = @ninv 
	End
	
	while (@nidexp > 0) 
	begin
		set @nidexp = @nidexp-1
		set @idexp = (select top 1 idexp from #expense)

		if (@liquidata = 1)
			Begin
				set @rapportopag = (select isnull(amount,0)
					from expenseyear
					where idexp = @idexp )
					/
					(select (isnull(totalpayed,0))
					from invoicedeferred
					where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv)

			End
		if (@liquidata = 0)
			Begin
				select @totalefattura = CONVERT(DECIMAL(19,2),
							ISNULL(SUM(  ROUND(taxable * number * 
							     	     CONVERT(decimal(19,6),@exchangerate) * 
							     	     (1 - CONVERT(decimal(19,6),ISNULL(discount, 0.0))),2)
						   ),0)
						)
						+
						CONVERT(DECIMAL(19,2),
							ISNULL(SUM(ROUND(tax * CONVERT(decimal(19,6), @exchangerate),2)
						   ),0)
						)
				from invoicedetail
				where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv
				
				set @rapportopag = (select ISNULL(amount,0) 
					from expenseyear
					where idexp = @idexp )
					/
					@totalefattura
				
			End

		if (@nidexp = 0)
			Begin
				set @totimponibile_desiderato = @totaleimponibile - @desideratoprec
			End
		 else 
			Begin
			   set @totimponibile_desiderato = Round(@totaleimponibile*@rapportopag,2)
			   set @desideratoprec = @desideratoprec + @totimponibile_desiderato
			End
		set @totimponibile_desiderato = @totimponibile_desiderato+@erroreprecedente

-- Ora cerca i tre epsilon 
		set @elabora = 0
		
		set @epsilon_Max = 1
		set @epsilon_c = 0.5
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

		while (@elabora<30)-- questo cicla finchè non quadra 
		begin
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

			set @elabora = @elabora + 1

			IF (@elabora<30)
			   set @epsilon_c = @epsilon_min + ((@epsilon_Max-@epsilon_min)*(@totimponibile_desiderato -@fmin))/(@fmax-@fmin)
		end
	        SET @erroreprecedente = @totimponibile_desiderato - @totimponibileeffettivo 
	
---------------------------------- ciclo x trovare l'epsilon IVA --------------------------------------

		set @elabora = 0
		set @epsilon_iva_Max = 1
		set @epsilon_iva_c = @epsilon_c
		set @epsilon_iva_min = 0

		set @fmin = 0	
		select @fmax =	 CONVERT(DECIMAL(19,2),
			ISNULL(SUM(Round(Round(tax,2)
			*CONVERT(decimal(19,6), @exchangerate),2)	
			   ),0)
			)
		from #invoicedetail
		where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
			and idexp_taxable is null and idexp_iva is null

		--if (@liquidata = 1)
		--Begin
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
		--End

		while (@elabora<30 and @epsilon_c<>1)-- questo cicla finchè non quadra 
		begin
			select @totivaeffettivo =  CONVERT(DECIMAL(19,2),
						ISNULL(SUM(Round(Round(tax*@epsilon_iva_c,2)*CONVERT(decimal(19,6), @exchangerate),2)	
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
			IF -- abbiamo quadrato e trovato @epsilon_c 
			(@totivaeffettivo = @totiva_desiderata OR @fmin = @fmax)
				Begin
					set @elabora = 200
				End

			set @elabora = @elabora +1

			IF (@elabora < 30)
			   set @epsilon_iva_c = @epsilon_iva_min + ((@epsilon_iva_Max-@epsilon_iva_min)*(@totiva_desiderata -@fmin))/(@fmax-@fmin)
		end

---------------------------------- ciclo x trovare l'epsilon IVA UNABATABLE     --------------------------------------------------
		set @elabora = 0
		set @epsilon_ivaun_Max = 1
		set @epsilon_ivaun_c = @epsilon_c
		set @epsilon_ivaun_min = 0
		declare @rapporto decimal(19,6)
		declare @totfattura decimal (19,6)
		
	        select @totfattura= isnull(taxabletotal,0) + isnull(ivatotal,0) 
	        from totinvoiceview 
	        where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
		if (@liquidata = 1)
		Begin
		   set @rapporto= (select isnull(totalpayed,0) from invoicedeferred 
					where  idinvkind = @idinvkind 
					and yinv = @yinv and ninv = @ninv)
				/@totfattura
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
		End	
		Else
		Begin
		   set @rapporto= (select isnull(taxabletotal,0)+isnull(ivatotal,0)from invoiceresidual
					where  idinvkind = @idinvkind 
					and yinv = @yinv and ninv = @ninv)
				/@totfattura
		   select @detraibiletotale =  SUM(ROUND(
						(tax - ISNULL(unabatable,0)) * @exchangerate * @rapporto
					       ,2))
		   from invoicedetail
		   where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
		   and idexp_taxable is null and idexp_iva is null
		End

		if (@nidexp = 0)
			Begin
			     set @detraibiledesiderato = @detraibiletotale - @detraibile_desideratoprec
			End
		   else 
			Begin
			     set @detraibiledesiderato = Round(@detraibiletotale*@rapportopag,2)
			     set @detraibile_desideratoprec = @detraibile_desideratoprec + @detraibiledesiderato
			End
	   	set @detraibiledesiderato = @detraibiledesiderato+@erroredetraibileprec

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

		while (@elabora<30 and @epsilon_c<>1)-- questo cicla finchè non quadra 
		begin
			if (@liquidata = 1)
			Begin
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
			End

			if (@liquidata = 0)
			Begin
			       select @detraibileeffettivo =  SUM(
				       ROUND( (Round(tax * @epsilon_iva_c,2)-Round(unabatable*@epsilon_ivaun_c,2)) * @exchangerate
					    ,2))

			   	from #invoicedetail
			  	where idinvkind = @idinvkind and yinv = @yinv and ninv =@ninv
			   	and idexp_taxable is null and idexp_iva is null
			End

			IF -- dobbiamo diminuire epsilon
			(@detraibileeffettivo < @detraibiledesiderato)
			Begin
				 set @epsilon_ivaun_Max = @epsilon_ivaun_c
				  set @fmax = @detraibileeffettivo
			End

			IF  -- dobbiamo aumentare epsilon
			(@detraibileeffettivo > @detraibiledesiderato)
			Begin
				set @epsilon_ivaun_min = @epsilon_ivaun_c
				set @fmin = @detraibileeffettivo
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

	 SET @erroredetraibileprec =@detraibiledesiderato - @detraibileeffettivo 


	IF (@epsilon_c=1) BEGIN
		UPDATE #invoicedetail SET 
			idexp_iva=@idexp,	
			idexp_taxable =@idexp
		WHERE idinvkind = @idinvkind and yinv = @yinv and ninv = @ninv and rownum <= @nrow
			and idexp_taxable is null and idexp_iva is null
	END
	ELSE 
	BEGIN
		------- Split della fattura ----------------------------------------------------------------------------------

		   select  @maxrownum = max (rownum) 
					from #invoicedetail
					where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv

		   select @idgroup = max(idgroup) 
					from #invoicedetail
				 	where idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv
		   set @row_i = 1
		   set @contarighe=1

		   if (@nidexp>0) 
		   Begin
			while (@row_i <= @nrow)
			Begin
				if exists(select * from #invoicedetail where rownum=@row_i) 
				begin
				  insert into #invoicedetail(idinvkind,yinv,ninv,rownum,idgroup,
					taxable,tax,unabatable,disCOUNT,
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
				  select @idinvkind,@yinv,@ninv,@contarighe+@maxrownum,idgroup,
					Round(dbo.GetImponibileNear(taxable*@epsilon_c, taxable, number,discount,@exchangerate),2),
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

			End --while (@row_i <= @maxrownum)

		-- Ora fa l'update della riga originale :
			UPDATE #invoicedetail SET 
			taxable = 
				ISNULL(( ISNULL(taxable,0) - 
					Round(dbo.GetImponibileNear(taxable*@epsilon_c, taxable, number,disCOUNT,@exchangerate),2)	
					),0) 
				,
			 tax = 
				ISNULL(( ISNULL(tax,0) - 
					round(tax*@epsilon_iva_c,2)	
					),0) 
				,
			unabatable = 
				ISNULL(( ISNULL(unabatable,0) -
					round(unabatable*@epsilon_ivaun_c,2)	
					),0) 
				
			WHERE idinvkind = @idinvkind and yinv = @yinv and ninv = @ninv and rownum <= @nrow--= @k
		    	  and idexp_taxable is null and idexp_iva is null

		   End -- end dell'if

		END

--------------------------------- Fine split fattura  --------------------------------------------------

		delete from #expense where idexp = @idexp
	
	end --while (@nidexp > 0) 


	FETCH NEXT FROM invoicecursor INTO @nidexp,@idinvkind,@yinv,@ninv
END
DEALLOCATE invoicecursor


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
		invoicedetail.rownum = #invoicedetail.rownum and 
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


drop table #invoicedetail




END










GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

