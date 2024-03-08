
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_unified_totivapay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_unified_totivapay]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec compute_unified_totivapay 2010,1,0
CREATE  procedure [compute_unified_totivapay] (	
	@ayear int,
	@nmonth int,
	@flag tinyint
) as begin

	CREATE TABLE #currivapayed (
		iddbdepartment varchar(50),
		idivaregisterkindunified varchar(20), --idivaregisterkind int,	
-- questi sono i valori al lordo da usare per chi calcola sul TOTALE
		iva_imm	decimal(19,2),						--1)  iva immediata
		iva_diff decimal(19,2),						--2)  iva differita
		unabatable_imm decimal(19,2),				--3)  iva indetraibile  immediata
		unabatable_diff decimal(19,2),				--4)  iva indetraibile  differita
-- questi sono i valori al netto da usare per chi calcola RIGA PER RIGA
		ivanet_imm decimal(19,2),
		ivanet_diff decimal(19,2),
		unabatablenet_imm decimal(19,2),
		unabatablenet_diff decimal(19,2),
-- Sono i valori dell iva immediata e differita dlele fatture INTRA istituzionali
		iva12_imm decimal(19,2) ,
		iva12_diff decimal(19,2),
		taxable12 decimal(19,2),
		taxabledeferred12 decimal(19,2),
		ivapay decimal(19,2)						--  iva liquidata del mese in oggetto
	)

	declare @query nvarchar(3000)
	declare @iddbdepartment varchar(50)
	declare @ivapay varchar(50)
	declare @ivapaydetail varchar(50)
	declare @ivaregisterkind varchar(50)

	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment 
	where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	order by iddbdepartment
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @s varchar(300)
		print @iddbdepartment
    	SET @ivapay = @iddbdepartment + '.ivapay'
    	SET @ivapaydetail = @iddbdepartment + '.ivapaydetail'
		SET @ivaregisterkind = @iddbdepartment + '.ivaregisterkind'
        SET  @query = 
		' SELECT 
			'''+@iddbdepartment+''',
		--  Nome registro
			idivaregisterkindunified, 
-- questi sono i valori al lordo da usare per chi calcola sul TOTALE
			iva,
			ivadeferred,
			unabatable,
			unabatabledeferred,
-- questi sono i valori al netto da usare per chi calcola RIGA PER RIGA
			ivanet,
			ivanetdeferred,
			(ISNULL(iva,0)	-	ISNULL(ivanet,0)) as unabatablenet,
			(ISNULL(ivadeferred,0)	-	ISNULL(ivanetdeferred,0)) as unabatablenetdeferred,
-- Sono i valori dell iva immediata e differita dlele fatture INTRA istituzionali
			iva,
			ivadeferred,
			taxable12,
			taxabledeferred12,

			ISNULL(paymentamount,-refundamount)
		FROM '+ @ivapay + ' I
		JOIN ' + @ivapaydetail + ' D
			ON I.nivapay = D.nivapay AND I.yivapay = D.yivapay
		JOIN '+ @ivaregisterkind +' R
			ON R.idivaregisterkind = D.idivaregisterkind
		WHERE MONTH(I.stop) = ' + CONVERT(varchar(4),@nmonth) + ' ' + 
		' AND YEAR(I.stop) = ' + CONVERT(varchar(4),@ayear) + ' '   +  
		' AND (I. flag & 3) = ('+convert(varchar(1),@flag & 3)+')'


		insert into #currivapayed 
			(
			iddbdepartment,
			idivaregisterkindunified,--idivaregisterkind,
-- questi sono i valori al lordo da usare per chi calcola sul TOTALE
			iva_imm,
			iva_diff,
			unabatable_imm,
			unabatable_diff,
-- questi sono i valori al netto da usare per chi calcola RIGA PER RIGA
			ivanet_imm,
			ivanet_diff,
			unabatablenet_imm,
			unabatablenet_diff,
-- Sono i valori dell'iva immediata e differita dlele fatture INTRA istituzionali
			iva12_imm,
			iva12_diff,
			taxable12,
			taxabledeferred12,

			ivapay 
			)
		EXEC sp_executesql @query

		fetch next from @crsdepartment into @iddbdepartment
	end

SELECT
		I.iddbdepartment, 
		D.description as department,
		R.description AS description,
		R.codeivaregisterkind as codeivaregisterkind,
		R.idivaregisterkind as idivaregisterkind,
		R.registerclass,
		CASE WHEN flagactivity = 3 THEN 'S'	ELSE 'N'
			END AS	 flagmixed,
-- questi sono i valori al lordo da usare per chi calcola sul TOTALE
		iva_imm,			-- iva (currivagrosspayed)
		iva_diff,			-- ivadeferred
		unabatable_imm,		-- unabatable (currivaunabatable)
		unabatable_diff,	-- unabatabledeferred
-- questi sono i valori al netto da usare per chi calcola RIGA PER RIGA
		ivanet_imm,
		ivanet_diff,
		unabatablenet_imm,
		unabatablenet_diff,
-- Sono i valori dell'iva immediata e differita dlele fatture INTRA istituzionali
		iva12_imm,
		iva12_diff,
		taxable12 as taxable12_imm,
		taxabledeferred12 as taxable12_diff,

		ivapay,
		R.flagactivity 
FROM #currivapayed I
JOIN dbdepartment D
	ON D.iddbdepartment=I.iddbdepartment
JOIN ivaregisterkind R
	ON R.idivaregisterkindunified = I.idivaregisterkindunified
order by codeivaregisterkind
DROP TABLE #currivapayed

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


