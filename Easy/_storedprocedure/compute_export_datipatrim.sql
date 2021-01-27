
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
