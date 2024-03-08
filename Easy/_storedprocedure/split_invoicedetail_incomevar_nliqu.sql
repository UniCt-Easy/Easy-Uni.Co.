
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


if exists (select * from dbo.sysobjects where id = object_id(N'[split_invoicedetail_incomevar_nliqu]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [split_invoicedetail_incomevar_nliqu]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE [split_invoicedetail_incomevar_nliqu]
(
	@ayear int -- nel codice della sp c'è @ayear 
)
AS
BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
CREATE TABLE #invoicedetail
(
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

CREATE TABLE #incomevar (idinc int, nvar int)-- contiene i pagamenti della fattura

DECLARE @idinvkind int
DECLARE @yinv int
DECLARE @ninv int
DECLARE @rownum int
DECLARE @yivapay int
DECLARE @nivapay int
DECLARE @contarighe int

DECLARE @totimponibile_desiderato decimal (19,2)
DECLARE @totiva_desiderata decimal (19,2)
DECLARE @epsilon_impon double precision
DECLARE @nidexp int 
DECLARE @nidinc_pay int 
DECLARE @idgroup int
DECLARE @maxrownum int 
DECLARE @row_i int
DECLARE @totalefattura decimal (19,2)
DECLARE @nliquidazioni int

DECLARE @elabora int
DECLARE @totimponibileeffettivo decimal (19,2)

DECLARE @totivaeffettivo decimal (19,2)

DECLARE @epsilon_Max double precision
DECLARE @epsilon_c double precision
DECLARE @epsilon_min double precision

DECLARE @epsilon_iva_Max double precision
DECLARE @epsilon_iva_c double precision
DECLARE @epsilon_iva_min double precision

DECLARE @fmin decimal (19,2)
DECLARE @fmax decimal (19,2)
DECLARE @erroreprecedente decimal (19,2)
DECLARE @totalpayed decimal (19,2)

DECLARE invoicecursor INSENSITIVE CURSOR FOR
-- fatture pure contab. con + pagamenti aventi idexp_taxable e idexp_iva a null 

SELECT invoicedeferred.idinvkind,invoicedeferred.yinv,invoicedeferred.ninv,invoicedeferred.yivapay,invoicedeferred.nivapay
FROM invoice 
JOIN invoicedetail
	ON invoice.idinvkind = invoicedetail.idinvkind
	AND invoice.yinv = invoicedetail.yinv
	AND invoice.ninv = invoicedetail.ninv
JOIN incomevar
	ON invoice.idinvkind = incomevar.idinvkind
	AND invoice.yinv = incomevar.yinv
	AND invoice.ninv = incomevar.ninv
JOIN proceedsemitted
	ON proceedsemitted.idinc = incomevar.idinc
JOIN invoicedeferred
	on incomevar.idinvkind = invoicedeferred.idinvkind
	AND incomevar.yinv = invoicedeferred.yinv 
	AND incomevar.ninv = invoicedeferred.ninv
JOIN ivapay
	ON invoicedeferred.yivapay = ivapay.yivapay
	AND invoicedeferred.nivapay = ivapay.nivapay
JOIN invoicekind
	ON invoicekind.idinvkind = invoice.idinvkind
WHERE invoicedetail.yinv = @ayear AND incomevar.movkind = 1
	AND ivapay.paymentkind ='C'
	AND (ISNULL(invoice.flagdeferred,'N') = 'S')
	AND (
		(SELECT COUNT(*) FROM invoicedeferred 
		WHERE idinvkind = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) > 1
		OR -- la fattura non è stata liquidata totalmentema parzialmente
		ISNULL(
			(SELECT SUM(ISNULL(taxabletotal,0) + ISNULL(ivatotal,0))
			FROM invoiceresidual 
			WHERE idinvkind = invoicedetail.idinvkind
			    AND yinv = invoicedetail.yinv 
			    AND ninv = invoicedetail.ninv)
		,0)
		>
		ISNULL(
			(SELECT SUM(ISNULL(totalpayed,0))
			FROM invoicedeferred
		        WHERE idinvkind = invoicedetail.idinvkind
			    AND yinv = invoicedetail.yinv 
			    AND ninv = invoicedetail.ninv)
		,0)
	)
	AND (
		(SELECT COUNT(DISTINCT rate) FROM ivakind  
		WHERE ivakind.idivakind = invoicedetail.idivakind) = 1
	)
	AND invoicedetail.idinc_taxable IS NULL
	AND invoicedetail.idinc_iva IS NULL
	AND invoicedetail.idestimkind IS NULL
	AND invoicedetail.yestim IS NULL
	AND invoicedetail.nestim IS NULL
	AND ((invoicekind.flag &1)<> 0 )
	AND ((invoicekind.flag &4)<> 0)
GROUP BY invoicedeferred.idinvkind, invoicedeferred.yinv, invoicedeferred.ninv, invoicedeferred.yivapay, invoicedeferred.nivapay
ORDER BY invoicedeferred.idinvkind,invoicedeferred.yinv,invoicedeferred.ninv

FOR READ ONLY

OPEN invoicecursor FETCH NEXT FROM invoicecursor INTO @idinvkind, @yinv, @ninv, @yivapay, @nivapay
WHILE (@@FETCH_STATUS = 0)
BEGIN
	SELECT @totalpayed = totalpayed FROM invoicedeferred
	WHERE invoicedeferred.idinvkind = @idinvkind
		AND invoicedeferred.yinv = @yinv
		AND invoicedeferred.ninv = @ninv
		AND nivapay = @nivapay
		AND yivapay = @yivapay

	PRINT @idinvkind PRINT @yinv PRINT @ninv PRINT @yivapay PRINT @nivapay
	-- prendo gli incassi della fattura
	INSERT INTO #incomevar (idinc, nvar)
	SELECT incomevar.idinc, incomevar.nvar
	FROM incomevar
	JOIN proceedsemitted
		ON proceedsemitted.idinc = incomevar.idinc
	JOIN invoicedeferred
		ON incomevar.idinvkind = invoicedeferred.idinvkind
		AND incomevar.yinv = invoicedeferred.yinv 
		AND incomevar.ninv = invoicedeferred.ninv
	JOIN ivapay
		ON invoicedeferred.yivapay = ivapay.yivapay
		AND invoicedeferred.nivapay = ivapay.nivapay
	WHERE invoicedeferred.idinvkind = @idinvkind
		AND invoicedeferred.yinv = @yinv
		AND invoicedeferred.ninv = @ninv
		AND invoicedeferred.yivapay = @yivapay
		AND invoicedeferred.nivapay = @nivapay
		AND proceedsemitted.competencydate BETWEEN ivapay.start AND ivapay.stop

	SELECT @nidinc_pay = COUNT(*) FROM #incomevar

	-- Faccio la copia di invoicedetail
	IF NOT EXISTS (SELECT * FROM #invoicedetail WHERE idinvkind = @idinvkind AND yinv = @yinv AND ninv = @ninv) 
	BEGIN
		INSERT INTO #invoicedetail
		(
			idinvkind, yinv, ninv, rownum, idgroup,
			taxable, tax, unabatable, discount,
			idmankind, yman, nman, manrownum,
			idestimkind, yestim, nestim, estimrownum,
			idaccmotive,
			idexp_iva, idexp_taxable,
			idinc_iva, idinc_taxable,
			idivakind,
			annotations,
			competencystart, competencystop,
			detaildescription,
			idsor1, idsor2, idsor3,
			number
		)
		SELECT
			@idinvkind, @yinv, @ninv, rownum, idgroup,
			taxable, tax, unabatable, discount,
			idmankind, yman, nman, manrownum,
			idestimkind, yestim, nestim, estimrownum,
			idaccmotive,
			idexp_iva, idexp_taxable,
			idinc_iva, idinc_taxable,
			idivakind,
			annotations,
			competencystart, competencystop ,
			detaildescription,
			idsor1, idsor2, idsor3,
			number
			from invoicedetail 
		WHERE idinvkind = @idinvkind AND yinv = @yinv AND ninv = @ninv

		SET @erroreprecedente = 0
	END

	-- Servirà dopo nello split
	DECLARE @nrow int 

	SELECT @nrow = MAX(rownum)
	FROM invoicedetail 
	WHERE idinvkind = @idinvkind AND yinv = @yinv AND ninv = @ninv

	DECLARE @exchangerate float

	SELECT @exchangerate = exchangerate FROM invoice
	WHERE idinvkind = @idinvkind AND yinv = @yinv AND ninv = @ninv

	DECLARE @curramount decimal (19,2)

	-- Per ogni pagamento della fattura: si calcola @epsilon_impon_c, @epsilon_iva_c, @epsilon_ivaun_c
	DECLARE @desiderato_precedente decimal(19,2)

	DECLARE @totaleimponibile decimal(19,2)

	SET @totaleimponibile =
		(SELECT (ISNULL(totalpayed,0)-ISNULL(ivatotalpayed,0))
		FROM invoicedeferred
		WHERE idinvkind=@idinvkind and yinv = @yinv and ninv = @ninv 
		AND yivapay = @yivapay and nivapay = @nivapay)

	SET @desiderato_precedente = 0
	DECLARE @idinc int
	DECLARE @yvar int
	DECLARE @nvar int
	WHILE (@nidinc_pay > 0) 
	BEGIN
		SET @nidinc_pay = @nidinc_pay - 1

		SET @idinc = (SELECT TOP 1 idinc FROM #incomevar)
		SET @yvar = @ayear
		SET @nvar = (SELECT TOP 1 nvar FROM #incomevar WHERE idinc = @idinc)

		SET @curramount = (SELECT -(ISNULL(amount,0)) FROM incomevar
		WHERE idinc = @idinc AND yvar = @yvar AND nvar = @nvar)

		SET @epsilon_impon = 0.5

		DECLARE @rapp_incasso decimal(19,6)

		SET @rapp_incasso = @curramount / @totalpayed

		IF (@nidinc_pay = 0)
		BEGIN
			SET @totimponibile_desiderato = @totaleimponibile - @desiderato_precedente
		END
		ELSE
		BEGIN
			SET @totimponibile_desiderato = ROUND(@totaleimponibile * @rapp_incasso,2)
			SET @desiderato_precedente = @desiderato_precedente + @totimponibile_desiderato
		END
		SET @totimponibile_desiderato = @totimponibile_desiderato+@erroreprecedente

		PRINT '@totimponibile_desiderato: '
		PRINT @totimponibile_desiderato
		PRINT '@idinc: '
		PRINT @idinc
		PRINT '@yvar: '
		PRINT @yvar
		PRINT '@nvar: '
		PRINT @nvar

		-- Ora cerca i tre epsilon 
 		SET @elabora = 0
		SET @epsilon_Max = 1
		SET @epsilon_c = @epsilon_impon
		SET @epsilon_min = 0

		SET @fmin = 0

		SELECT @fmax =
			CONVERT(decimal(19,2),
				ISNULL(
					SUM(
						ROUND(taxable * number *
					 		CONVERT(decimal(19,6),@exchangerate) * 
					         	(1 - CONVERT(decimal(19,6),ISNULL(discount, 0)))
						,2)
				 	)
				,0)
			)
		FROM #invoicedetail
		WHERE idinvkind = @idinvkind
			AND yinv = @yinv
			AND ninv = @ninv
			AND idinc_taxable IS NULL
			AND idinc_iva IS NULL

		PRINT '@fmax: 'PRINT @fmax

		WHILE (@elabora < 30)-- questo cicla finchè non quadra 
		BEGIN
			SELECT @totimponibileeffettivo =
				CONVERT(decimal(19,2),
					ISNULL(
						SUM(
							ROUND(
								ROUND(dbo.GetImponibileNear(taxable *
								@epsilon_c, taxable, number,discount, @exchangerate),2)
							 	* number 
							 	* CONVERT(decimal(19,6),@exchangerate) * 
					                 	(1 - CONVERT(decimal(19,6),ISNULL(discount, 0)))
							,2)
					         )
					,0)
				)
			FROM #invoicedetail
			WHERE idinvkind = @idinvkind
				AND yinv = @yinv
				AND ninv = @ninv
				AND idinc_taxable IS NULL
				AND idinc_iva IS NULL
			
			-- dobbiamo diminuire epsilon
			IF (@totimponibileeffettivo > @totimponibile_desiderato)
			BEGIN
				 SET @epsilon_Max = @epsilon_c
				 SET @fmax = @totimponibileeffettivo
			END

			-- dobbiamo aumentare epsilon
			IF (@totimponibileeffettivo < @totimponibile_desiderato)
			BEGIN
				SET @epsilon_min = @epsilon_c
				SET @fmin = @totimponibileeffettivo 
			END

			-- abbiamo quadrato e trovato @epsilon_c 
			IF (@totimponibileeffettivo = @totimponibile_desiderato OR @fmin = @fmax OR @epsilon_min = @epsilon_Max)
			BEGIN
				SET @elabora = 200
			END

			SET @elabora = @elabora + 1
			
			IF (@elabora < 30)
			BEGIN
				SET @epsilon_c = @epsilon_min +
				((@epsilon_Max - @epsilon_min) * (@totimponibile_desiderato - @fmin))
				/(@fmax - @fmin)
			END
		END

		PRINT '--------------------------  @totimponibileeffettivo trovato :  ------------------------'
		PRINT @totimponibileeffettivo
		PRINT '@epsilon_c' PRINT @epsilon_c
		SET @erroreprecedente = @totimponibile_desiderato - @totimponibileeffettivo 
		PRINT '@erroreprecedente' PRINT @erroreprecedente

		---------------------------------- ciclo x trovare l'epsilon IVA ------------------------------
		DECLARE @epsilon_iva float
		SET @epsilon_iva  = @epsilon_c /*@epsilon_impon */
		SET @fmin = 0		
		SELECT @fmax =
			CONVERT(decimal(19,2),
				ISNULL(
					SUM(
						ROUND(
							ROUND(tax,2) *
							CONVERT(decimal(19,6), @exchangerate)
						,2)
				   	)
				,0)
			)
		FROM #invoicedetail
		WHERE idinvkind = @idinvkind
			AND yinv = @yinv
			AND ninv = @ninv
			AND idinc_taxable IS NULL
			AND idinc_iva IS NULL

		SET @totiva_desiderata =
			(SELECT -ISNULL(amount,0)
			FROM incomevar 
			WHERE idinc = @idinc
			AND yvar = @yvar
			AND nvar = @nvar)
			-
			(SELECT
			CONVERT(decimal(19,2),
				ISNULL(
					SUM(
					        ROUND(
							ROUND(dbo.GetImponibileNear(taxable*@epsilon_c, taxable, number,discount,@exchangerate),2)
							 * number 
							 * CONVERT(decimal(19,6),@exchangerate) * 
					                 (1 - CONVERT(decimal(19,6),ISNULL(discount, 0)))
						,2)
				         )
				,0)
			)
			FROM #invoicedetail
			WHERE idinvkind = @idinvkind
				AND yinv = @yinv
				AND ninv = @ninv
				AND idinc_taxable IS NULL
				AND idinc_iva IS NULL)
		
		PRINT 'iva desiderata: ' PRINT @totiva_desiderata

		SET @epsilon_iva_Max = 1
		SET @epsilon_iva_c = @epsilon_iva
		SET @epsilon_iva_min = 0

		SET @elabora = 0

		WHILE (@elabora <30 AND @epsilon_c <> 1)-- questo cicla finchè non quadra 
		BEGIN
			SELECT @totivaeffettivo =
				CONVERT(decimal(19,2),
					ISNULL(
						SUM(
							ROUND(
								ROUND(tax*@epsilon_iva_c,2)
								* CONVERT(decimal(19,6), @exchangerate)
							,2)
						)
					,0)
				)
			FROM #invoicedetail
			WHERE idinvkind = @idinvkind
				AND yinv = @yinv
				AND ninv =@ninv
				AND idinc_taxable IS NULL
				AND idinc_iva IS NULL

			-- dobbiamo diminuire epsilon
			IF (@totivaeffettivo > @totiva_desiderata)
			BEGIN
				SET @epsilon_iva_Max = @epsilon_iva_c
				SET @fmax = @totivaeffettivo
			END

			-- dobbiamo aumentare epsilon
			IF (@totivaeffettivo < @totiva_desiderata)
			BEGIN
				SET @epsilon_iva_min = @epsilon_iva_c
				SET @fmin = @totivaeffettivo 
			END

			-- abbiamo quadrato e trovato @epsilon_c 
			IF (@totivaeffettivo = @totiva_desiderata OR @fmin = @fmax)
			BEGIN
				SET @elabora = 200
			END

			PRINT '@totivaeffettivo: ' PRINT @totivaeffettivo

			SET @elabora = @elabora + 1

			IF (@elabora < 30)
			BEGIN
				SET @epsilon_iva_c = @epsilon_iva_min +
				((@epsilon_iva_Max - @epsilon_iva_min) * (@totiva_desiderata - @fmin))
				/(@fmax - @fmin)
			END
		END

		PRINT '--------------------------  @totivaeffettivo trovato :  -------------------------------'
		PRINT @totivaeffettivo
		
		IF (@epsilon_c = 1)
		BEGIN
			UPDATE #invoicedetail
			SET idinc_iva=@idinc, idinc_taxable = @idinc
			WHERE idinvkind = @idinvkind AND yinv = @yinv
				AND ninv = @ninv
				AND rownum <= @nrow
				AND idinc_taxable IS NULL
				AND idinc_iva IS NULL
		END
		ELSE
		-------------------------------- Split della fattura ------------------------------------------
		BEGIN
			SELECT @maxrownum = MAX(rownum)
			FROM #invoicedetail
			WHERE idinvkind = @idinvkind AND yinv = @yinv AND ninv = @ninv

			SELECT @idgroup = MAX(idgroup) FROM #invoicedetail
			WHERE idinvkind = @idinvkind AND yinv = @yinv AND ninv = @ninv

			SET @row_i = 1
			SET @contarighe = 1

			IF (@nidinc_pay + 1>0)
			BEGIN
				WHILE (@row_i <= @nrow)
				BEGIN
					-- La riga n+1 avrà taxable[n+1] = taxable[1]*epsilon
					-- La riga n+2 avrà taxable[n+2] = taxable[2]*epsilon
					-- ...
					-- la riga n+i avrà taxable[n+i] = taxable[i]*epsilon
					IF EXISTS(SELECT * FROM #invoicedetail WHERE rownum = @row_i)
					BEGIN
						INSERT INTO #invoicedetail
						(
							idinvkind, yinv, ninv, rownum, idgroup,
							taxable,
							tax, unabatable, discount,
							idmankind, yman, nman, manrownum,
							idestimkind, yestim, nestim, estimrownum,
							idaccmotive,
							idexp_iva, idexp_taxable,
							idinc_iva, idinc_taxable,
							idivakind,
							annotations,
							competencystart, competencystop,
							detaildescription,
							idsor1, idsor2, idsor3,
							number
						)
						SELECT 
							@idinvkind, @yinv, @ninv, @contarighe + @maxrownum, idgroup,
							ROUND(dbo.GetImponibileNear(taxable * @epsilon_c, taxable, number, discount, @exchangerate) ,2),
							ROUND(tax * @epsilon_iva_c,2), unabatable, discount,
							idmankind, yman, nman, manrownum,
							idestimkind, yestim, nestim, estimrownum,
							idaccmotive,
							idexp_iva, idexp_taxable,
							@idinc, @idinc,
							idivakind,
							annotations,
							competencystart, competencystop,
							detaildescription,
							idsor1, idsor2, idsor3,
							number
						FROM #invoicedetail as c
						WHERE idinvkind = @idinvkind
							AND yinv = @yinv
							AND ninv = @ninv
							AND rownum = @row_i
							AND idinc_taxable IS NULL
							AND idinc_iva IS NULL

						SET @contarighe = @contarighe + 1
					END
					SET @row_i = @row_i+1
			

				END --> while (@row_i <= @maxrownum)

		--imposta il residuo della fattura nei dettagli originali
		UPDATE #invoicedetail SET 
-- la k-esima riga avrà taxable uguale al suo taxable - la parte che ha ceduto al suo split
-- la 1 riga avrà taxable[1]' = taxable[1]-taxable[1]*epsilon
			taxable = 
				ISNULL(( ISNULL(taxable,0) - 
					ROUND(dbo.GetImponibileNear(taxable*@epsilon_c, taxable, number,discount,@exchangerate),2)	
					),0) 
				,
			 tax = 
				ISNULL(( ISNULL(tax,0) - 
					ROUND(tax*@epsilon_iva_c,2)	
					),0) 
		WHERE idinvkind = @idinvkind and yinv = @yinv and ninv = @ninv and rownum <= @nrow
			and idinc_taxable IS NULL and idinc_iva IS NULL

		end -- end dell'if

		END

--------------------------------- fine split fattura  --------------------------------------------------

		DELETE FROM #incomevar WHERE idinc = @idinc AND nvar = @nvar
	
	end 


	FETCH NEXT FROM invoicecursor INTO @idinvkind,@yinv,@ninv,@yivapay,@nivapay
END
	DEALLOCATE invoicecursor
/*
	SELECT * from #invoicedetail as C
		WHERE 
				exists (SELECT * from invoicedetail CC WHERE 
						CC.idinvkind=C.idinvkind and 
						CC.yinv=C.yinv and 
						CC.ninv=C.ninv and 
						CC.rownum=C.rownum)



	SELECT * from #invoicedetail as c
			WHERE 
				not exists (SELECT * from invoicedetail CC WHERE 
						CC.idinvkind=C.idinvkind and 
						CC.yinv=C.yinv and 
						CC.ninv=C.ninv and 
						CC.rownum=C.rownum)
*/

	--Aggiorna le righe del db 
	update invoicedetail SET 
		taxable=#invoicedetail.taxable,
		tax=#invoicedetail.tax,
		idinc_taxable=#invoicedetail.idinc_taxable,
		idinc_iva=#invoicedetail.idinc_iva
	from #invoicedetail
	WHERE 	invoicedetail.idinvkind = #invoicedetail.idinvkind and 
		invoicedetail.yinv = #invoicedetail.yinv and 
		invoicedetail.ninv = #invoicedetail.ninv and 
		invoicedetail.rownum = #invoicedetail.rownum and -- nrow
		invoicedetail.idinc_taxable IS NULL and invoicedetail.idinc_iva IS NULL
	
	--Aggiunge le nuove righe nel db
	INSERT INTO invoicedetail(idinvkind,yinv,ninv,rownum,idgroup,
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
			SELECT  c.idinvkind,c.yinv,c.ninv,c.rownum,c.idgroup,
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
			WHERE 
				not exists (SELECT * from invoicedetail CC WHERE 
						CC.idinvkind=C.idinvkind and 
						CC.yinv=C.yinv and 
						CC.ninv=C.ninv and 
						CC.rownum=C.rownum)

--	SELECT * from #invoicedetail


drop table #invoicedetail


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

