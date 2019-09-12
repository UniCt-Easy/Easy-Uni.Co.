if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_fatture_dateincoerenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_fatture_dateincoerenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE  [esporta_fatture_dateincoerenti]
	@ayear	int,
	@stop	smalldatetime,
	@idinvkind int,
	@unified char(1)  
AS BEGIN
-- EXEC unified_esporta_fatture_dateincoerenti 2008,{ts '2008-12-31 00:00:00'}, null,'N'
	DECLARE @departmentname varchar(500)
	SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento'  
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')



IF (@unified ='S')
Begin
	SELECT
		@departmentname as 'Dipartimento',
		invoicekind.description 'Tipo Documento',
		invoice.yinv 'Eserc.Documento',
		invoice.ninv 'Num. Documento',
		invoice.adate as 'Data Registrazione'
	FROM invoice 
	JOIN invoicekind 
		ON invoicekind.idinvkind = invoice.idinvkind
	WHERE (invoice.idinvkind = @idinvkind OR @idinvkind IS NULL)
			AND invoice.adate <= @stop			
			AND invoice.yinv = @ayear
		AND ( select count(*) from invoice i2
				where i2.yinv = @ayear
					AND i2.idinvkind = invoice.idinvkind
					AND i2.ninv < invoice.ninv
					AND i2.adate <= invoice.adate )
			<>
			(select count(*) from invoice i3
				where i3.yinv = @ayear
					AND i3.idinvkind = invoice.idinvkind
					AND i3.ninv <invoice.ninv)
	ORDER BY invoicekind.description
End
Else
Begin
	SELECT
		invoicekind.description 'Tipo Documento',
		invoice.yinv 'Eserc.Documento',
		invoice.ninv 'Num. Documento',
		invoice.adate as 'Data Registrazione'
	FROM invoice 
	JOIN invoicekind 
		ON invoicekind.idinvkind = invoice.idinvkind
	WHERE (invoice.idinvkind = @idinvkind OR @idinvkind IS NULL)
			AND invoice.adate <= @stop			
			AND invoice.yinv = @ayear
		AND ( select count(*) from invoice i2
				where i2.yinv = @ayear
					AND i2.idinvkind = invoice.idinvkind
					AND i2.ninv < invoice.ninv
					AND i2.adate <= invoice.adate )
			<>
			(select count(*) from invoice i3
				where i3.yinv = @ayear
					AND i3.idinvkind = invoice.idinvkind
					AND i3.ninv <invoice.ninv)
	ORDER BY invoicekind.description

End
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




