
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_va3type]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_va3type]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amministrazione'
-- exp_unified_va3type 2018,1,12

CREATE   PROCEDURE exp_unified_va3type (	
	@year int,@startmonth smallint,@stopmonth smallint
	) 
AS BEGIN

	declare @dep varchar(30)
		
	if (user='amministrazione') 
		set @dep=null
	else
		set @dep=user

	if @startmonth is null set @startmonth = 1
	if @stopmonth is null set @stopmonth = 12

    DECLARE @flagva3 char(1)
	SELECT  @flagva3 = flagva3 from config where ayear = @year 
	


	CREATE TABLE #riepilogo
	(
		iddbdepartment varchar(50),
		va3type	       char(1),  -- S R N A
		taxabletotal dec(19,2)
	)

/*
ivaregisterkind.flagactivity (valori)
1 - attività istituzionale
2 - attività commerciale
3 - attività promiscuo
*/

/*
IVK.flag bit
0 istituzionale
1 commerciale 
2 altro
*/
DECLARE @mixedrate decimal(19,6)	
SELECT @mixedrate = mixed FROM iva_mixed WHERE ayear = @year
SET @mixedrate= isnull(@mixedrate,1)

declare @iddbdepartment varchar(50)
declare @currCommDifferita nvarchar(4000)
declare @currPromDifferita nvarchar(4000)

declare @currCommImmediata nvarchar(4000)
declare @currPromImmediata nvarchar(4000)

declare @num int

declare @cursore cursor
set 	@cursore = cursor for select  iddbdepartment from dbdepartment
					where (start is null or start <= @year ) AND ( stop is null or stop >= @year)
							and (@dep is null or iddbdepartment=@dep)
open 	@cursore
fetch next from @cursore into @iddbdepartment

while @@fetch_status=0 begin
	
	/*
	@flagva3 = S >>> Tipo documento commerciale (associato a registro iva commerciale o promiscuo) avente
					Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)  e  tipo imposizione  idivataxablekind diverso da  "5 Fuori Campo" e "6 Escluse art.15" 
	@flagva3=N >>> Non gestito
	*/
	
	IF (@flagva3 = 'S')
	BEGIN
		SET @currCommDifferita = ''
		-- Attività Commerciale	
		SET @currCommDifferita = 'SELECT  ' +  '''' + @iddbdepartment + '''' +  ',  va3type, ' + 
		' CONVERT(DECIMAL(19,2), ' + 
				' ISNULL(SUM(ROUND(IDT.taxable * IDT.npackage * ' +
			     			 ' CONVERT(decimal(19,10),I.exchangerate) * ' + 
			     			 ' (1 - CONVERT(decimal(19,6),ISNULL(IDT.discount, 0.0))),2) ' +
			  ' ),0) ' +
			  ' ) ' + 
		' FROM ' +  @iddbdepartment + '.invoicedetail IDT ' + 
		' JOIN ' +  @iddbdepartment + '.invoice I ' + 
		'	ON   IDT.idinvkind = I.idinvkind ' +
		'       AND  IDT.yinv = I.yinv ' +
		' 	AND  IDT.ninv = I.ninv ' + 
		' JOIN ' +  @iddbdepartment + '.invoicedeferred IDF ' +
		'	ON   IDF.idinvkind = I.idinvkind ' +
		'	AND  IDF.yinv = I.yinv ' +
		'	AND  IDF.ninv = I.ninv ' +
		' JOIN ' +  @iddbdepartment + '.ivapay IP ' +
		'	ON  IP.yivapay = IDF.yivapay ' +
		'	AND IP.nivapay = IDF.nivapay ' +
		' JOIN ' +  @iddbdepartment + '.invoicekind IK ' +
		'	ON I.idinvkind = IK.idinvkind ' +
		' JOIN ' +  @iddbdepartment + '.ivaregister IR ' +
		'	ON IR.idinvkind = I.idinvkind ' +
		'	AND IR.yinv = I.yinv ' +
		'	AND IR.ninv = I.ninv ' +
		' JOIN ' +  @iddbdepartment + '.ivaregisterkind IRK ' +
		'	ON IRK.idivaregisterkind = IR.idivaregisterkind ' +
		' JOIN ' +  @iddbdepartment + '.ivakind IVK ' +
		'	ON IVK.idivakind = IDT.idivakind ' +
		' join ' +  @iddbdepartment + '.ivataxablekind ITK '+
		' on IVK.idivataxablekind = ITK.idivataxablekind ' +
		'	JOIN paymentemitted PE1 '+
		' ON PE1.idexp = IDT.idexp_iva   '+
	'	WHERE 	' +
		'		IP.yivapay = ' + CONVERT(VARCHAR(4),@year) +
		'		and YEAR(PE1.competencydate)  = ' + CONVERT(VARCHAR(4),@year) +
		' 		and ITK.idivataxablekind not in (5,6) '+
		'		AND IRK.registerclass = ''A'' ' + 
		'		AND IRK.flagactivity  = ''2'' ' +      --> 2 - attività commerciale
		'		AND ((ISNULL(IVK.flag,0)&6) <> 0) ' +	-->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		'		AND (datepart(month,IP.dateivapay)) >= '+ 	 CONVERT(VARCHAR(4),@startmonth) + 
		'       AND (datepart(month,IP.dateivapay)) <= '+ 	 CONVERT(VARCHAR(4),@stopmonth) + 
		' group by va3type '
		--print @currCommDifferita
		SET @currCommImmediata = ''
		-- Attività Commerciale	
		SET @currCommImmediata = 'SELECT  ' +  '''' + @iddbdepartment + '''' +  ',  va3type, ' + 
		' CONVERT(DECIMAL(19,2), ' + 
				' ISNULL(SUM(ROUND(IDT.taxable * IDT.npackage * ' +
			     			 ' CONVERT(decimal(19,10),I.exchangerate) * ' + 
			     			 ' (1 - CONVERT(decimal(19,6),ISNULL(IDT.discount, 0.0))),2) ' +
			  ' ),0) ' +
			  ' ) ' + 
		' FROM ' +  @iddbdepartment + '.invoicedetail IDT ' + 
		' JOIN ' +  @iddbdepartment + '.invoice I ' + 
		'	ON   IDT.idinvkind = I.idinvkind ' +
		'       AND  IDT.yinv = I.yinv ' +
		' 	AND  IDT.ninv = I.ninv ' + 
		' JOIN ' +  @iddbdepartment + '.invoicekind IK ' +
		'	ON I.idinvkind = IK.idinvkind ' +
		' JOIN ' +  @iddbdepartment + '.ivaregister IR ' +
		'	ON IR.idinvkind = I.idinvkind ' +
		'	AND IR.yinv = I.yinv ' +
		'	AND IR.ninv = I.ninv ' +
		' JOIN ' +  @iddbdepartment + '.ivaregisterkind IRK ' +
		'	ON IRK.idivaregisterkind = IR.idivaregisterkind ' +
		' JOIN ' +  @iddbdepartment + '.ivakind IVK ' +
		'	ON IVK.idivakind = IDT.idivakind ' +
		' join ' +  @iddbdepartment + '.ivataxablekind ITK '+
		' on IVK.idivataxablekind = ITK.idivataxablekind ' +
		'	WHERE 	' +
		'		I.flagdeferred = ''N'' '+
		'		and YEAR(I.adate)  = ' + CONVERT(VARCHAR(4),@year) +
		' 		and ITK.idivataxablekind not in (5,6) '+
		'		AND IRK.registerclass = ''A'' ' + 
		'		AND IRK.flagactivity  = ''2'' ' +      --> 2 - attività commerciale
		'		AND ((ISNULL(IVK.flag,0)&6) <> 0) ' +	-->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)
		'		AND (datepart(month,I.adate)) >= '+ 	 CONVERT(VARCHAR(4),@startmonth) + 
		'       AND (datepart(month,I.adate)) <= '+ 	 CONVERT(VARCHAR(4),@stopmonth) + 
		' group by va3type '
		--print @currCommImmediata
	END
	
	
	if (@currCommDifferita <> '')
	begin
		insert into #riepilogo (iddbdepartment, va3type,taxabletotal)
		exec sp_executesql @currCommDifferita
	end

	
	if (@currCommImmediata <> '')
	begin
		insert into #riepilogo (iddbdepartment, va3type,taxabletotal)
		exec sp_executesql @currCommImmediata
	end
		
-- Attività Promiscua
	IF (@flagva3 = 'S')
	BEGIN
		SET @currPromDifferita = ''
		SET @currPromDifferita = 'SELECT  ' +  '''' + @iddbdepartment + '''' +  ',  va3type, ' + 
		' CONVERT(DECIMAL(19,2), ' + 
				' ISNULL(SUM(ROUND(IDT.taxable * IDT.npackage * ' +
			     			 ' CONVERT(decimal(19,10),I.exchangerate) * ' + 
							+ CONVERT(VARCHAR(25),@mixedrate) + ' * ' +
			     			 ' (1 - CONVERT(decimal(19,6),ISNULL(IDT.discount, 0.0))),2)  ' +
			  ' ),0) ' +
			  ' ) ' + 
		' FROM ' +  @iddbdepartment + '.invoicedetail IDT ' + 
		' JOIN ' +  @iddbdepartment + '.invoice I ' + 
		'	ON   IDT.idinvkind = I.idinvkind ' +
		'       AND  IDT.yinv = I.yinv ' +
		' 	AND  IDT.ninv = I.ninv ' + 
		' JOIN ' +  @iddbdepartment + '.invoicedeferred IDF ' +
		'	ON   IDF.idinvkind = I.idinvkind ' +
		'	AND  IDF.yinv = I.yinv ' +
		'	AND  IDF.ninv = I.ninv ' +
		' JOIN ' +  @iddbdepartment + '.ivapay IP ' +
		'	ON  IP.yivapay = IDF.yivapay ' +
		'	AND IP.nivapay = IDF.nivapay ' +
		' JOIN ' +  @iddbdepartment + '.invoicekind IK ' +
		'	ON I.idinvkind = IK.idinvkind ' +
		' JOIN ' +  @iddbdepartment + '.ivaregister IR ' +
		'	ON IR.idinvkind = I.idinvkind ' +
		'	AND IR.yinv = I.yinv ' +
		'	AND IR.ninv = I.ninv ' +
		' JOIN ' +  @iddbdepartment + '.ivaregisterkind IRK ' +
		'	ON IRK.idivaregisterkind = IR.idivaregisterkind ' +
		' JOIN ' +  @iddbdepartment + '.ivakind IVK ' +
		'	ON IVK.idivakind = IDT.idivakind ' +
		' join ' +  @iddbdepartment + '.ivataxablekind ITK '+
		' on IVK.idivataxablekind = ITK.idivataxablekind ' +
		'	JOIN paymentemitted PE1 '+
		' ON PE1.idexp = IDT.idexp_iva   '+
		'	WHERE 	' +
		'		IP.yivapay = ' + CONVERT(VARCHAR(4),@year) +
		'		and YEAR(PE1.competencydate)  = ' + CONVERT(VARCHAR(4),@year) +
		' 		and ITK.idivataxablekind not in (5,6) '+
		'		AND IRK.registerclass = ''A'' ' + 
		'		AND IRK.flagactivity  = ''3'' ' +   --> 3 - attività promiscuo
		'		AND ((ISNULL(IVK.flag,0)&6) <> 0) ' +	-->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)
		'		AND (datepart(month,IP.dateivapay)) >= '+ 	 CONVERT(VARCHAR(4),@startmonth) + 
		'       AND (datepart(month,IP.dateivapay)) <= '+ 	 CONVERT(VARCHAR(4),@stopmonth) + 
		' group by va3type '
		
		--print @currPromDifferita

		SET @currPromImmediata = ''
		SET @currPromImmediata = 'SELECT  ' +  '''' + @iddbdepartment + '''' +  ',  va3type, ' + 
		' CONVERT(DECIMAL(19,2), ' + 
				' ISNULL(SUM(ROUND(IDT.taxable * IDT.npackage * ' +
			     			 ' CONVERT(decimal(19,10),I.exchangerate) * ' + 
							+ CONVERT(VARCHAR(25),@mixedrate) + ' * ' +
			     			 ' (1 - CONVERT(decimal(19,6),ISNULL(IDT.discount, 0.0))),2)  ' +
			  ' ),0) ' +
			  ' ) ' + 
		' FROM ' +  @iddbdepartment + '.invoicedetail IDT ' + 
		' JOIN ' +  @iddbdepartment + '.invoice I ' + 
		'	ON   IDT.idinvkind = I.idinvkind ' +
		'       AND  IDT.yinv = I.yinv ' +
		' 	AND  IDT.ninv = I.ninv ' + 
		' JOIN ' +  @iddbdepartment + '.invoicekind IK ' +
		'	ON I.idinvkind = IK.idinvkind ' +
		' JOIN ' +  @iddbdepartment + '.ivaregister IR ' +
		'	ON IR.idinvkind = I.idinvkind ' +
		'	AND IR.yinv = I.yinv ' +
		'	AND IR.ninv = I.ninv ' +
		' JOIN ' +  @iddbdepartment + '.ivaregisterkind IRK ' +
		'	ON IRK.idivaregisterkind = IR.idivaregisterkind ' +
		' JOIN ' +  @iddbdepartment + '.ivakind IVK ' +
		'	ON IVK.idivakind = IDT.idivakind ' +
		' join ' +  @iddbdepartment + '.ivataxablekind ITK '+
		' on IVK.idivataxablekind = ITK.idivataxablekind ' +
		'	WHERE 	' +
		'		 I.flagdeferred = ''N'' '+
		'		and YEAR(I.adate)  = ' + CONVERT(VARCHAR(4),@year) +	
		' 		and ITK.idivataxablekind not in (5,6) '+
		'		AND IRK.registerclass = ''A'' ' + 
		'		AND IRK.flagactivity  = ''3'' ' +   --> 3 - attività promiscuo
		'		AND ((ISNULL(IVK.flag,0)&6) <> 0) ' +	-->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)
		'		AND (datepart(month,I.adate)) >= '+ 	 CONVERT(VARCHAR(4),@startmonth) + 
		'       AND (datepart(month,I.adate)) <= '+ 	 CONVERT(VARCHAR(4),@stopmonth) + 
		' group by va3type '
		--print @currPromImmediata
		END
	if (@currPromDifferita <> '')
	begin
		insert into #riepilogo (iddbdepartment, va3type,taxabletotal)
		exec sp_executesql @currPromDifferita
	end

	if (@currPromImmediata <> '')
	begin
		insert into #riepilogo (iddbdepartment, va3type,taxabletotal)
		exec sp_executesql @currPromImmediata
	end

fetch next from @cursore into @iddbdepartment	
end

	SELECT 
		D.description as 'Dipartimento', 
		@year as 'Anno', 
		(SELECT ISNULL(sum(R1.taxabletotal),0)  FROM #riepilogo R1 
		 WHERE  R1.va3type = 'S' 
		   AND  R.iddbdepartment = R1.iddbdepartment) 
		as 'Beni ammortizzabili',
		(SELECT ISNULL(sum(R1.taxabletotal),0)  FROM #riepilogo R1 
		 WHERE  R1.va3type = 'N' 
		   AND  R.iddbdepartment = R1.iddbdepartment) 
		as 'Beni strumentali non ammortizabili',
		(SELECT ISNULL(sum(R1.taxabletotal),0)  FROM #riepilogo R1 
		 WHERE  R1.va3type = 'R' 
		   AND  R.iddbdepartment = R1.iddbdepartment) 
		as 'Beni destinati alla rivendita ovvero alla produzione di beni e servizi',
		(SELECT ISNULL(sum(R1.taxabletotal),0)  FROM #riepilogo R1 
		 WHERE  R1.va3type = 'A' 
		   AND  R.iddbdepartment = R1.iddbdepartment) 
		as 'Altri acquisti e importazioni',
		(SELECT ISNULL(sum(R1.taxabletotal),0) FROM #riepilogo R1 
		 WHERE  R1.va3type IS NULL  
		   AND  R.iddbdepartment = R1.iddbdepartment) 
		as 'Non specificato'
	FROM #riepilogo R
	JOIN dbdepartment D
		ON R.iddbdepartment = D.iddbdepartment
	GROUP BY  D.description, R.iddbdepartment 
	ORDER BY D.description
drop table #riepilogo
end	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


