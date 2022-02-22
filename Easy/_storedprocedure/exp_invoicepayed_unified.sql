
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicepayed_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicepayed_unified]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE exp_invoicepayed_unified(
	@ayear 			int,
	@start 			smalldatetime,
	@stop 			smalldatetime,
	@idivaregisterkind int,
	@deferred 		char(1), --(D = Solo fatture ad iva Differita, I = solo fatture ad iva Immediata, T = Tutte)
	@unified char(1)  ,
	@detail  char(1) --> S = mostra dettagli fattura, N = non mostra i dettagli, fornisce una sintesi.
) 
AS BEGIN
--  exp_invoicepayed_unified '2010', {ts '2010-01-01 00:00:00.000'}, {ts '2010-05-28 00:00:00.000'}, null, 'T','S','N'

	IF (@unified <> 'S')
	BEGIN
			EXEC exp_invoicepayed @ayear,@start,@stop,@idivaregisterkind,@deferred,@unified
			RETURN
	END 

	CREATE TABLE #invoice_main
	(	
		department varchar(250),	
		idinvkind int,
		invoicekind varchar(50),
		yinv int,
		ninv int,
		flagdeferred char(1),
		doc varchar(35),
		docdate smalldatetime,	
		taxabletotal decimal(19,2),
		ivatotal decimal(19,2),
		ivatotalpayed decimal(19,2),
		idivaregisterkindunified int,
		registername varchar(50)
	)

	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for 
	select  iddbdepartment from dbdepartment
	where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @s varchar(300)
		set @s = @iddbdepartment + '.exp_invoicepayed'
	INSERT INTO #invoice_main
	(
		department,
		invoicekind,
		yinv,
		ninv,
		flagdeferred,
		doc,
		docdate,	
		taxabletotal,
		ivatotal,
		ivatotalpayed,
		idivaregisterkindunified
	)			
	exec @s @ayear,@start,@stop,@idivaregisterkind,@deferred,@unified

		fetch next from @crsdepartment into @iddbdepartment
	end

IF(@detail='S')	
Begin
	SELECT 
	department as 'Dipartimento', 
	ivaregisterkind.description AS 'Registro',
	invoicekind AS 'Tipo', 
	yinv AS 'Esercizio', 
	ninv AS 'Numero', 
	flagdeferred AS 'IVA Differita', 
	doc AS  'Documento',
	docdate AS  'Data Documento',
	taxabletotal AS 'Tot.Imponibile', 
	ivatotal AS 'Tot.IVA', 
	ivatotalpayed AS 'Totale Iva Liquididata' 
	FROM #invoice_main 
	LEFT OUTER JOIN ivaregisterkind -- << LEFT JOUTER JOIN Serve per consentire la visualizzazione dei dip. che non hanno fatture nel periodo.
		ON #invoice_main.idivaregisterkindunified = ivaregisterkind.idivaregisterkindunified
	order by idinvkind, yinv, ninv
End
ELSE
Begin
	SELECT 
	department as 'Dipartimento', 
	ivaregisterkind.description AS 'Registro',
	SUM(taxabletotal) AS 'Tot.Imponibile', 
	SUM(ivatotal) AS 'Tot.IVA', 
	SUM(ivatotalpayed) AS 'Totale Iva Liquididata' 
	FROM #invoice_main 
	LEFT OUTER JOIN ivaregisterkind -- << LEFT JOUTER JOIN Serve per consentire la visualizzazione dei dip. che non hanno fatture nel periodo.
		ON #invoice_main.idivaregisterkindunified = ivaregisterkind.idivaregisterkindunified
	GROUP BY department, ivaregisterkind.description
	order by department, ivaregisterkind.description

End


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




