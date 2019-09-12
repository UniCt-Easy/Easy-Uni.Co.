if exists (select * from dbo.sysobjects where id = object_id(N'[compute_export_datipatrim]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [compute_export_datipatrim]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [compute_export_datipatrim]
(
	@rfid varchar(30),
	@all char(1) = null
)
AS BEGIN
if (@all is null)
	set @all='N'

if (@all='N')
	BEGIN
		SELECT				 asset.rfid, registry.title AS Fornitore, invoice.doc AS NFattura, invoice.docdate AS DataFattura, assetloadkind.description AS Tipo, assetview.yassetload AS Anno, assetview.nassetload AS Numero, 
							 assetview.loadmotive AS Causale, assetacquire.taxable AS Imponibile, assetacquire.discount AS Sconto, 
							 assetacquire.taxable + assetacquire.tax AS ImportoTotale, assetacquire.taxrate AS AliquotaIva, assetacquire.tax AS IvaTotale, assetacquire.tax - assetacquire.abatable AS IvaIndetraibile, 
							 assetacquire.taxable - assetacquire.discount AS CostoEffettivo,  assetview.currentvalue AS ValoreAttuale, assetview.revals AS TotaleAmmortamenti
		FROM            asset LEFT OUTER JOIN
							 assetacquire ON asset.nassetacquire = assetacquire.nassetacquire 
							 LEFT OUTER JOIN assetview ON asset.idasset = assetview.idasset
							 LEFT OUTER JOIN registry ON assetacquire.idreg = registry.idreg
							 LEFT OUTER JOIN assetloadkind ON assetview.idassetloadkind = assetloadkind.idassetloadkind
							 LEFT OUTER JOIN invoice ON assetacquire.ninv = invoice.ninv AND assetacquire.yinv = invoice.yinv AND assetacquire.idinvkind = invoice.idinvkind
		where asset.rfid = @rfid
		order by asset.rfid
	END
	ELSE
	BEGIN
		SELECT			 asset.rfid, registry.title AS Fornitore, invoice.doc AS NFattura, invoice.docdate AS DataFattura, assetloadkind.description AS Tipo, assetview.yassetload AS Anno, assetview.nassetload AS Numero, 
                         assetview.loadmotive AS Causale, assetacquire.taxable AS Imponibile, assetacquire.discount AS Sconto, 
                         assetacquire.taxable + assetacquire.tax AS ImportoTotale, assetacquire.taxrate AS AliquotaIva, assetacquire.tax AS IvaTotale, assetacquire.tax - assetacquire.abatable AS IvaIndetraibile, 
                         assetacquire.taxable - assetacquire.discount AS CostoEffettivo,  assetview.currentvalue AS ValoreAttuale, assetview.revals AS TotaleAmmortamenti
		FROM            asset LEFT OUTER JOIN
							 assetacquire ON asset.nassetacquire = assetacquire.nassetacquire 
							 LEFT OUTER JOIN assetview ON asset.idasset = assetview.idasset
							 LEFT OUTER JOIN registry ON assetacquire.idreg = registry.idreg
							 LEFT OUTER JOIN assetloadkind ON assetview.idassetloadkind = assetloadkind.idassetloadkind
							 LEFT OUTER JOIN invoice ON assetacquire.ninv = invoice.ninv AND assetacquire.yinv = invoice.yinv AND assetacquire.idinvkind = invoice.idinvkind
		order by asset.rfid
	END

END