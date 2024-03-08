
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


if exists (select * from dbo.sysobjects where id = object_id(N'[read_taxable_sdi_acquisto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [read_taxable_sdi_acquisto]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 --setuser 'amm'
  --setuser 'amministrazione'
CREATE    procedure [read_taxable_sdi_acquisto] (
	@idinvkind	int,
	@yinv	smallint,
	@ninv	int,
	@idivakind int,
	@res decimal(19,5) out
) as
BEGIN
	DECLARE @idsdi_acquisto int
	select @idsdi_acquisto = idsdi_acquisto  from invoice where idinvkind= @idinvkind and yinv = @yinv and ninv = @ninv
	declare @f int

	DECLARE @myrate decimal(19,2)
	SELECT	@myrate = rate
	from ivakind where idivakind = @idivakind
	SET @myrate = @myrate *100

	-- Il SUM è stato introdotto perchè nel riepilogo potrebbero esserci due righe : una con imponibile associato a Aliquota 0 e Natura N3, l'altra con imponibile associato a Aliquota 0 e natura N4, 
	-- per cui, se stiamo calcolando l'imponibile per l'aliquota 0 dobbiamo sommare
	
	SET @res =0
	declare @xx float
	declare @x XML
	select @x = cast (s.xml as XML)   from sdi_acquisto S 		 where S.idsdi_acquisto= @idsdi_acquisto

	set @f = @x.value('count(//DatiBeniServizi/DatiRiepilogo/AliquotaIVA[text()=  sql:variable("@myrate") ]/../ImponibileImporto)[1]','int')	 	

	IF (@f > 0) 
	BEGIN
		SET @xx =  isnull(@x.value('sum(//DatiBeniServizi/DatiRiepilogo/AliquotaIVA[text()= sql:variable("@myrate") ]/../ImponibileImporto)[1]','float') ,0)	
		set @res= convert(decimal(19,5),@xx)	
    END

END


GO

