/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[verify_sdi_acquisto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [verify_sdi_acquisto]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 -- setuser 'amm'
 -- setuser 'amministrazione'
 /*
	declare @res smallint
	exec verify_sdi_acquisto 295, 2025, 312, @res output
	select @res
 */
CREATE    procedure [verify_sdi_acquisto] (
	@idinvkind	int,
	@yinv	smallint,
	@ninv	int,
	--@idivakind int,
	@res smallint out
) as
BEGIN

	DECLARE @aliquota decimal(19, 2)
	DECLARE @imponibile decimal(19, 6)
	DECLARE @imposta decimal(19, 6)

	set @res = 1

	DECLARE @idsdi_acquisto int
	select @idsdi_acquisto = idsdi_acquisto  from invoice where idinvkind= @idinvkind and yinv = @yinv and ninv = @ninv

	declare @xml XML
	select @xml = cast (s.xml as XML)   from sdi_acquisto S 		 where S.idsdi_acquisto= @idsdi_acquisto

	DECLARE riepilogo_cursor CURSOR FOR
	WITH datiriepilogo AS(
		SELECT
			n.v.value('(AliquotaIVA)[1]', 'DECIMAL(19,2)') AS AliquotaIVA,
			n.v.value('(ImponibileImporto)[1]', 'DECIMAL(19,6)') AS Imponibile,
			n.v.value('(Imposta)[1]', 'DECIMAL(19,6)') AS Imposta
		FROM @xml.nodes('//DatiBeniServizi/DatiRiepilogo') AS n(v)
	)
	SELECT
		AliquotaIVA,
		SUM(Imponibile) AS Imponibile,
		SUM(Imposta) AS Imposta
	FROM datiriepilogo
	GROUP BY AliquotaIVA
	HAVING SUM(Imponibile) > 0 or SUM(Imposta) > 0

	OPEN riepilogo_cursor

	FETCH NEXT FROM riepilogo_cursor 
	INTO @aliquota, @imponibile, @imposta

	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		if not exists (select * from invoicedetail
			JOIN ivakind  	ON ivakind.idivakind = invoicedetail.idivakind
			JOIN invoice 	ON invoice.ninv = invoicedetail.ninv AND invoice.yinv = invoicedetail.yinv AND invoice.idinvkind = invoicedetail.idinvkind
			where invoice.idinvkind = @idinvkind
			and invoice.yinv = @yinv
			and invoice.ninv = @ninv
			--and isnull(invoicedetail.rounding,'N')='N'
			--and isnull(invoicedetail.flagbit,0)&4  = 0
			and ivakind.rate = (@aliquota / 100)
		)
		begin
			set @res = 0
			CLOSE riepilogo_cursor
			DEALLOCATE riepilogo_cursor
			RETURN
		end
		
		if (
			(select

				isnull(sum(
					CONVERT(decimal(19,2),
						ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
						  CONVERT(DECIMAL(19,10),invoice.exchangerate) *
						  (1 - CONVERT(DECIMAL(19,6),ISNULL(invoicedetail.discount, 0.0)))
						 ,2)
					)
				), 0)
				+ 
				isnull(SUM(CONVERT(decimal(19,2), ROUND(invoicedetail.tax,2))), 0)

			FROM invoicedetail
			JOIN ivakind  	ON ivakind.idivakind = invoicedetail.idivakind
			JOIN invoice 	ON invoice.ninv = invoicedetail.ninv AND invoice.yinv = invoicedetail.yinv AND invoice.idinvkind = invoicedetail.idinvkind
			where invoice.idinvkind = @idinvkind
			and invoice.yinv = @yinv
			and invoice.ninv = @ninv
			--and isnull(invoicedetail.rounding,'N')='N'
			--and isnull(invoicedetail.flagbit,0)&4  = 0
			and ivakind.rate = (@aliquota / 100)
			)
			<> @imponibile + @imposta
		)
		begin
			set @res = 0
			CLOSE riepilogo_cursor
			DEALLOCATE riepilogo_cursor
			RETURN
		end

		FETCH NEXT FROM riepilogo_cursor
		INTO @aliquota, @imponibile, @imposta

	END

	CLOSE riepilogo_cursor
	DEALLOCATE riepilogo_cursor

	DECLARE invoicedetail_cursor CURSOR FOR
	select 
		ivakind.rate * 100 AS AliquotaIVA
	FROM invoicedetail
	JOIN ivakind  	ON ivakind.idivakind = invoicedetail.idivakind
	JOIN invoice 	ON invoice.ninv = invoicedetail.ninv AND invoice.yinv = invoicedetail.yinv AND invoice.idinvkind = invoicedetail.idinvkind
	where invoice.idinvkind = @idinvkind
	and invoice.yinv = @yinv
	and invoice.ninv = @ninv
	--and isnull(invoicedetail.rounding,'N')='N'
	--and isnull(invoicedetail.flagbit,0)&4  = 0
	
	OPEN invoicedetail_cursor

	FETCH NEXT FROM invoicedetail_cursor 
	INTO @aliquota

	WHILE @@FETCH_STATUS = 0
	BEGIN
		declare @nrows int

		set @nrows = @xml.value('count(//DatiBeniServizi/DatiRiepilogo/AliquotaIVA[text()=  sql:variable("@aliquota") ]/../ImponibileImporto)[1]','int')

		if (@nrows = 0)
		begin
			set @res = 0
			CLOSE invoicedetail_cursor
			DEALLOCATE invoicedetail_cursor
			RETURN
		end
		
		FETCH NEXT FROM invoicedetail_cursor
		INTO @aliquota

	END

	CLOSE invoicedetail_cursor
	DEALLOCATE invoicedetail_cursor

END


GO
