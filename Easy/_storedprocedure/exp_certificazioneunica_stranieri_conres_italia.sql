
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_stranieri_conres_italia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_stranieri_conres_italia]
GO
 
CREATE PROCEDURE [exp_certificazioneunica_stranieri_conres_italia]
(
	@annodichiarazione int
)
-- estraggo l'elenco dei percipienti stranieri cha hanno un CF straniero ma hanno la Residenza in Italia.
 
AS BEGIN

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1 

	declare @31dic15 datetime
	set @31dic15 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #expense2015_stranieri(
		idexp int,
		idreg int,
		idser int,
		ammontarelordocorrisposto decimal(19,2),
		nmov int,
		motive770 varchar(10),
		error int
	)

	INSERT INTO #expense2015_stranieri(
			idexp,
			idreg,
			idser,
			nmov
		)
		SELECT
			expense.idexp,
			expense.idreg,
			expenselast.idser,
			expense.nmov
		FROM expense
		join expenselast on expense.idexp = expenselast.idexp
		join payment 
			on payment.kpay = expenselast.kpay
		join paymenttransmission
			on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		JOIN service on service.idser=expenselast.idser
		JOIN registry ON expense.idreg = registry.idreg
		WHERE 	registry.idregistryclass <> '10' and registry.idregistryclass <> '24'
			AND year(paymenttransmission.transmissiondate)=@annoredditi
			AND service.rec770kind = 'H'
			AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselast.idexp)
			+ ISNULL(
				(SELECT SUM(amount) FROM expensevar
				WHERE expensevar.idexp = expense.idexp
				AND ISNULL(autokind,0) <> 4)
			,0)) > 0
			and (select count(*) from expensetaxofficial 
			      where expensetaxofficial.idexp=expense.idexp
			      AND   expensetaxofficial.stop IS NULL) > 0
			AND (registry.cf IS NULL) AND (registry.foreigncf IS  NOT NULL) 
 
 	update #expense2015_stranieri set motive770 = motive770service.idmot
		from motive770service 
		where motive770service.idser = #expense2015_stranieri.idser
		AND motive770service.ayear = @annodichiarazione-1

	update #expense2015_stranieri set ammontarelordocorrisposto = (select MAX(ET.taxablegross)
				FROM expensetaxofficial ET
				JOIN tax T 
					ON ET.taxcode=T.taxcode 
				WHERE ET.idexp = #expense2015_stranieri.idexp and  T.taxkind=1
				AND ET.stop IS NULL )

	DECLARE @idreg int
	DECLARE @codiceNazione varchar(20)
	declare @stand int
	declare @domfi int

	select  @stand = idaddress from address where codeaddress = '07_SW_DEF'
	select  @domfi = idaddress from address where codeaddress = '07_SW_DOM'

	DECLARE registry_crs CURSOR FOR 
		SELECT DISTINCT #expense2015_stranieri.idreg FROM #expense2015_stranieri
		
	OPEN registry_crs
		FETCH NEXT FROM registry_crs into   @idreg
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			SELECT TOP 1 
				@codiceNazione = isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end)
				FROM registryaddress 
				LEFT OUTER JOIN geo_nation
					ON registryaddress.idnation = geo_nation.idnation
				LEFT OUTER JOIN geo_nation_agency
					ON geo_nation.idnation = geo_nation_agency.idnation
					AND geo_nation_agency.idagency = 5
					AND geo_nation_agency.idcode = 1
				WHERE registryaddress.idreg = @idreg
					AND registryaddress.start <= @31dic15
					AND (registryaddress.stop IS NULL OR registryaddress.stop >= @31dic15)
				ORDER BY
				CASE idaddresskind
					WHEN @stand THEN 1
					WHEN @domfi THEN 2
					ELSE 3
				END

			if (@codiceNazione is null)
				Begin
					update #expense2015_stranieri set error = 1 where idreg = @idreg
				End
			FETCH NEXT FROM registry_crs into  @idreg
		END
	CLOSE registry_crs
	DEALLOCATE registry_crs

	----------------------------------------------------------
    --- Estrazione dati relativi ai percipienti stranieri ----
    ----------------------------------------------------------
    		
	SELECT 
		registry.idreg		as '#Cod. Anagrafica',
		ltrim(rtrim(registry.title))		as 'Percipiente',
		registry.cf			as 'Codice Fiscale',
		registry.p_iva		as 'Partita IVA',
		registry.foreigncf	as 'Codice Fiscale Estero',
		@annoredditi as 'Eserc.Pagamento',
		#expense2015_stranieri.nmov as 'Num.Pagamento',
		ammontarelordocorrisposto as 'Ammontare Lordo Corrisposto',
		ltrim(rtrim(isnull(service.servicecode770, service.codeser)	+ '	' + service.description))  	as 'Codice Prestazione',
		mod770_exemptioncode.exemptioncode		as 'Codice Causale'
	FROM #expense2015_stranieri
	JOIN registry 
		ON #expense2015_stranieri.idreg = registry.idreg
	JOIN service 
		ON #expense2015_stranieri.idser = service.idser
	LEFT OUTER JOIN motive770service
		ON motive770service.idser = service.idser
		AND   motive770service.ayear = @annoredditi
	LEFT OUTER JOIN mod770_exemptioncode 
		ON mod770_exemptioncode.exemptioncode = motive770service.exemptioncode
		AND mod770_exemptioncode.ayear = @annoredditi
	where isnull(#expense2015_stranieri.error,0)=1
	ORDER BY registry.idreg
	
DROP TABLE #expense2015_stranieri
END
 
 GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

 
