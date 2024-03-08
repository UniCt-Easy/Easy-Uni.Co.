
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_documentoiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_documentoiva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE  PROCEDURE [exp_documentoiva]
(
	@esercizio int,
	@datainizio datetime,
	@datafine datetime
)
AS BEGIN
	SELECT 
		invoice.adate AS 'Data Registrazione',
		invoicekind.description AS 'Tipo Doc.',
		invoice.yinv AS 'Esercizio Doc.',
		invoice.ninv AS 'Numero Doc.',
		registry.idreg,
		registry.title AS 'Denominazione',
		registry.badgecode as 'Badge',
		registry.cf AS 'Codice Fiscale',
		registry.p_iva AS 'Partita Iva',
		invoice.description AS 'Descrizione Doc.',
		invoice.doc AS 'Documento Rif.',
		invoice.docdate AS 'Data Documento Rif.',
		upb.codeupb AS 'Codice Centro Spesa',
		upb.title AS 'Centro Spesa',
		invoicedetail.rownum AS 'Num. Dettaglio',
		invoicedetail.detaildescription AS 'Descrizione Dett.',
		invoicedetail.taxable AS 'Imponibile',
		ivakind.description AS 'Tipo IVA',	
		ivakind.rate AS 'Aliquota IVA',
		invoicedetail.tax AS 'IVA Applicata',
		invoicedetail.unabatable AS 'IVA indetraibile',
		pianoconti.sortcode AS 'Codice Conto',
		pianoconti.description AS 'Conto',
		space(120) as 'Comune',
		space(2) as 'Provincia'
	into #invoice
		FROM invoice
		JOIN invoicedetail
			ON invoice.idinvkind = invoicedetail.idinvkind
			AND invoice.yinv = invoicedetail.yinv
			AND invoice.ninv = invoicedetail.ninv
		LEFT OUTER JOIN upb
			ON upb.idupb = invoicedetail.idupb
		LEFT OUTER JOIN sorting pianoconti
			ON pianoconti.idsor = invoicedetail.idsor1
		JOIN invoicekind
			ON invoicekind.idinvkind = invoice.idinvkind
		LEFT OUTER JOIN registry
			ON invoice.idreg = registry.idreg
		LEFT OUTER JOIN ivakind
			ON ivakind.idivakind = invoicedetail.idivakind
		WHERE invoice.yinv = @esercizio
		AND invoice.adate BETWEEN @datainizio AND @datafine
		ORDER BY invoice.adate, invoice.idinvkind,
		invoice.yinv, invoice.ninv, invoicedetail.rownum

	DECLARE @stand int
	SELECT @stand = idaddress from address where codeaddress = '07_SW_DEF'
	set @stand = isnull(@stand, 0)

	DECLARE @nostand int
	SELECT @nostand = idaddress from address where codeaddress = '07_SW_AVV'
	set @nostand = isnull(@nostand, 0)


	SELECT 
		registryaddress.idreg,
		registryaddress.start,
		registryaddress.idaddresskind,
		comune = ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,''),
		provincia = geo_country.province
	into #indirizzoversante
		FROM registryaddress
		LEFT OUTER JOIN geo_city
			ON geo_city.idcity = registryaddress.idcity
		LEFT OUTER JOIN geo_country
			ON geo_city.idcountry = geo_country.idcountry
		LEFT OUTER JOIN geo_nation
			ON geo_nation.idnation = registryaddress.idnation
		WHERE registryaddress.active <>'N' and
			registryaddress.idreg in (select idreg from #invoice)

	DELETE #indirizzoversante
		WHERE #indirizzoversante.idaddresskind <> @nostand
		AND EXISTS(
			SELECT * FROM #indirizzoversante r2 
			WHERE #indirizzoversante.idreg = r2.idreg
			AND r2.idaddresskind = @nostand
		)
	DELETE #indirizzoversante
		WHERE #indirizzoversante.idaddresskind NOT IN (@nostand, @stand)
		AND EXISTS(
			SELECT * FROM #indirizzoversante r2 
			WHERE #indirizzoversante.idreg = r2.idreg
			AND r2.idaddresskind = @stand
		)
	
	DELETE #indirizzoversante
		WHERE EXISTS(
			SELECT * FROM #indirizzoversante r2 
			WHERE r2.idreg = r2.idreg
			AND (r2.start > r2.start
				or r2.start = r2.start 
				and r2.idaddresskind <> r2.idaddresskind)
		)

	update #invoice set #invoice.comune=#indirizzoversante.comune, provincia=#indirizzoversante.provincia
		from #indirizzoversante
		where #indirizzoversante.idreg=#invoice.idreg

	select * from #invoice
		
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
