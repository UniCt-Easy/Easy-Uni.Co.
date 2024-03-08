
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitgirofondiiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitgirofondiiva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE exp_sitgirofondiiva
	@ayear int,
	@idtreasurersource   int,	 --> Cassiere del Dipartimento
	@showdetail char(1)
	--@idtreasurerdest     int  --> Cassiere dell'Amministrazione

	AS
BEGIN

declare @idtreasurerdest int
select @idtreasurerdest = idtreasurer from treasurer where flagdefault = 'S'

	DECLARE @Dettagli TABLE(
			idtreasurer int, 
			ivaamount decimal(19,2), yivapay smallint, nivapay int, ivaadate datetime, 
			transferamount decimal(19,2), ntransfer int, transferadate datetime
			)

	INSERT INTO @Dettagli(idtreasurer, ivaamount, yivapay, nivapay, ivaadate)
		SELECT 
			IK.idtreasurer,
			-- Se è un registro acquisto è iva a creadito, altrimenti è iva a debito. L'iva a credito la scriviamo con segno - perchè i girofondi
			-- che l'amministrazione fa nei confronti del dipartimento ( per rimborsare l'iva a credito ) vengono visualizzati con segno meno.
			case when (IK.registerclass = 'A'and IK.flagactivity!=1) then -(isnull(ID.ivanet,0) + isnull(ID.ivanetdeferred,0))
				else (isnull(ID.ivanet,0) + isnull(ID.ivanetdeferred,0))
			end,
		ID.yivapay,
			ID.nivapay,
			I.dateivapay	
		FROM  ivapay I
		JOIN ivapaydetail ID
			ON I.yivapay = ID.yivapay and I.nivapay = ID.nivapay
		JOIN ivaregisterkind IK
			on ID.idivaregisterkind = IK.idivaregisterkind 
		WHERE ID.yivapay = @ayear 
			and (IK.idtreasurer = @idtreasurersource  )

	INSERT INTO @Dettagli(idtreasurer, transferamount, ntransfer, transferadate)
		SELECT idtreasurersource,
			isnull(amount,0),
			ntransfer,
			adate
		FROM moneytransfer 
		WHERE ytransfer  = @ayear
			and (idtreasurersource = @idtreasurersource ) 
			and (idtreasurerdest = @idtreasurerdest) 
			and (transferkind = 'I')

	INSERT INTO @Dettagli(idtreasurer, transferamount,  ntransfer, transferadate)
		SELECT idtreasurersource,
			- isnull(amount,0),
			ntransfer,
			adate
		FROM moneytransfer 
		WHERE ytransfer  = @ayear
			and (idtreasurersource = @idtreasurerdest) 
			and (idtreasurerdest = @idtreasurersource) 
			and (transferkind = 'I')

if (@showdetail = 'S')
Begin
		SELECT 
			isnull(T.header, T.description) as 'Cassiere Dipartimento',
			D.yivapay as 'Eserc.Liquidazione iva',
			D.nivapay as 'Num.Liquidazione iva',
			D.ivaadate as 'Data Liquidazione',
			D.ivaamount as 'Iva Liquidata',
			D.ntransfer as  'Num.Girofondo',
			D.transferadate as 'Data Girofondo',
			D.transferamount as 'Importo Girofondato'
		FROM  @Dettagli D
		JOIN treasurer T
			on D.idtreasurer = T.idtreasurer 
		order by isnull(T.header, T.description), isnull(ivaadate, transferadate)

End
Else
Begin


		SELECT 
			isnull(T.header, T.description) as 'Cassiere Dipartimento',
			sum(D.ivaamount) as 'Iva Liquidata',
			sum(D.transferamount) as 'Importo Girofondato dal Dipartimento',
			sum(isnull(D.ivaamount,0) - isnull(D.transferamount,0)) as 'Importo da Girofondare'
		FROM  @Dettagli D
		JOIN treasurer T
			on D.idtreasurer = T.idtreasurer 
		group by isnull(T.header, T.description)
		order by isnull(T.header, T.description)
End

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
