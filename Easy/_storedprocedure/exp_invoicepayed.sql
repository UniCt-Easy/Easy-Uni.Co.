
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicepayed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicepayed]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE exp_invoicepayed(
	@ayear 			int,
	@start 			smalldatetime,
	@stop 			smalldatetime,
	@idivaregisterkind int,
	@deferred 		char(1), --(D = Solo fatture ad iva Differita, I = solo fatture ad iva Immediata, T = Tutte)
	@unified char(1)  
) 
AS BEGIN

DECLARE @expphase tinyint
DECLARE @incphase tinyint

SELECT @incphase = MAX(nphase) FROM incomephase
SELECT @expphase = MAX(nphase) FROM expensephase

IF (@unified ='S')
Begin
	SET @idivaregisterkind = ISNULL((SELECT idivaregisterkind from ivaregisterkind WHERE idivaregisterkindunified = @idivaregisterkind),@idivaregisterkind)
End

-- exp_invoicepayed '2010', {ts '2010-01-01 00:00:00.000'}, {ts '2010-05-28 00:00:00.000'}, null, 'T','N'
	CREATE TABLE #invoice
	(	
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
		idivaregisterkind int
	)
	
	INSERT INTO #invoice
	(
		idinvkind,
		invoicekind,
		yinv,
		ninv,
		flagdeferred,
		doc,
		docdate,	
		taxabletotal,
		ivatotal,
		ivatotalpayed,
		idivaregisterkindunified,
		idivaregisterkind
	)
	SELECT 
		I.idinvkind,
		IK.description,
		I.yinv,
		I.ninv,
		I.flagdeferred, 
		I.doc,
		I.docdate,
		SUM(IR.taxabletotal), 
		SUM(IR.ivatotal), 
		SUM(IDF.ivatotalpayed),
		IRK.idivaregisterkindunified,
		IRK.idivaregisterkind
	FROM invoiceresidual  IR
	JOIN invoiceview I 
		ON  I.idinvkind = IR.idinvkind
		AND I.yinv = IR.yinv
		AND I.ninv = IR.ninv 
	JOIN invoicekind  IK
		ON I.idinvkind = IK.idinvkind
	JOIN ivaregister RR 
		ON RR.idinvkind = I.idinvkind
		AND RR.yinv = I.yinv
		AND RR.ninv = I.ninv
	JOIN ivaregisterkind IRK		
		ON IRK.idivaregisterkind = RR.idivaregisterkind
	LEFT OUTER JOIN invoicedeferred IDF 
		ON IDF.idinvkind = I.idinvkind
		AND IDF.yinv = I.yinv
		AND IDF.ninv = I.ninv
	WHERE I.yinv = @ayear 
	AND I.adate between @start AND @stop 
	--AND (I.idinvkind = @idinvkind OR @idinvkind is null)
	AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind is null)
	AND ((I.flagdeferred = 'S' AND @deferred = 'D') OR 
             (I.flagdeferred = 'N' AND @deferred = 'I') OR 
	     (@deferred = 'T'))
	GROUP BY IR.idinvkind, IR.yinv, IR.ninv, 
		 I.idinvkind,IK.description,I.yinv,I.ninv,
		 I.flagdeferred, IK.flag,I.doc,I.docdate,
		 I.description, IDF.idinvkind,IDF.yinv,IDF.ninv,IRK.idivaregisterkind,IRK.idivaregisterkindunified

DECLARE @departmentname varchar(500)

SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')



IF ( (select COUNT(*) FROM #invoice) = 0 )
Begin
	INSERT INTO #invoice(idinvkind,invoicekind,yinv,ninv,flagdeferred,doc,docdate,taxabletotal,ivatotal,ivatotalpayed,idivaregisterkindunified)
	SELECT null,null,null,null,null,null,null,null,null,null, null
End

IF (@unified ='S')
Begin
	SELECT 
	@departmentname as 'Dipartimento',
	invoicekind AS 'Tipo', 
	yinv AS 'Esercizio', 
	ninv AS 'Numero', 
	flagdeferred AS 'IVA Differita', 
	doc AS  'Documento',
	docdate AS  'Data Documento',
	taxabletotal AS 'Tot.Imponibile', 
	ivatotal AS 'Tot.IVA', 
	ivatotalpayed AS 'Totale Iva Liquididata',
	idivaregisterkindunified -- Codice Registro consolidamento
	FROM #invoice 
	order by idinvkind, yinv, ninv
 
End
Else
Begin
	SELECT 
	invoicekind AS 'Tipo', 
	ivaregisterkind.description as 'Registo',
	yinv AS 'Esercizio', 
	ninv AS 'Numero', 
	flagdeferred AS 'IVA Differita', 
	doc AS  'Documento',
	docdate AS  'Data Documento',
	taxabletotal AS 'Tot.Imponibile', 
	ivatotal AS 'Tot.IVA', 
	ivatotalpayed AS 'Totale Iva Liquididata'
	FROM #invoice 
	JOIN ivaregisterkind
		ON #invoice.idivaregisterkind = ivaregisterkind.idivaregisterkind
	order by idinvkind, yinv, ninv

End		
drop table #invoice

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

