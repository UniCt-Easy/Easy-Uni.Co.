
if exists (select * from dbo.sysobjects where id = object_id(N'[read_taxablebynature_sdi_acquisto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [read_taxablebynature_sdi_acquisto]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  --setuser 'amm'
CREATE    procedure [read_taxablebynature_sdi_acquisto] (
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
	declare @xx float

	DECLARE @idfenature varchar(10)
	SELECT	@idfenature = isnull(idfenature,'') 	from ivakind where idivakind = @idivakind
		
	declare @x XML
	select @x = cast (s.xml as XML)   from sdi_acquisto S 		 where S.idsdi_acquisto= @idsdi_acquisto

	set @f = @x.value('count(//DatiBeniServizi/DatiRiepilogo/Natura[text()=  sql:variable("@idfenature") ]/../ImponibileImporto)[1]','int')	 	
	
	set @res= 0
	IF (@f > 0) 
	BEGIN
		--SET @f =  isnull(@x.value('m(//DatiBeniServizi/DatiRiepilogo/Natura[text()= sql:variable("@idfenature") ]/../ImponibileImporto)[1]','decimal(19,5)') ,0)		
		SET @xx =  isnull(@x.value('sum(//DatiBeniServizi/DatiRiepilogo/Natura[text()= sql:variable("@idfenature") ]/../ImponibileImporto)[1]','float') ,0)
		set @res = convert(decimal(19,5),@xx)	

    END
	
END


GO