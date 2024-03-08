
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoice_intrastatunified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_invoice_intrastatunified
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amm'


--  exec exp_invoice_intrastatunified 2019,null,null,'A','M','T','N'
CREATE  PROCEDURE exp_invoice_intrastatunified (
	-- A seconda della periodicità ossia T, M o A, si dovrà indicare il periodo di riferimento
	@anno int,
	@mese int, 
	@trimestre int,
	@tipoRiepilogo char(1),	-- A = acquisti, C = cessioni
	@periodicita char(1),	-- M = dichiarazione Mensile, T = dichiarazione Trimestrale
	@tiporecord char(1),    -- B -->Beni, S -->Servizi, T -- >Beni e Servizi
	@unified char(1)
)
AS
BEGIN

IF(isnull(@unified,'N')<>'S')
Begin
	EXEC exp_invoice_intrastat @anno, @mese, @trimestre, @tipoRiepilogo, @periodicita, @tiporecord 
	RETURN
End

DECLARE @meseinizio int
DECLARE @mesefine int
DECLARE @idcurrency int
SELECT @idcurrency = idcurrency FROM currency WHERE codecurrency='EUR'

IF (@periodicita = 'T')
begin
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7 
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9 
			when @trimestre = 4	then 12
			End
end

CREATE TABLE #unifiedinvoice (
	iddbdepartment varchar(50),
	tipoRiepilogo varchar(20),
	tipoRecord varchar(20),
	periodicita varchar(20),
	anno int,
	Mese varchar(20),
	trimestre int,
	MeseFattura varchar(20), 
	segno_variazione char(1),
	ClienteFornitore varchar(100),  
	p_iva varchar(15),  
	cf varchar(16), 
	birthdate smalldatetime,
	invoicekind varchar(50), 
	yinv smallint, 
	ninv int, 
	protocolnum int,
	adate smalldatetime,	
	currency varchar(50), 
	exchangerate float,
	rownum int,
	detaildescription varchar(150), 
	taxable decimal(19,2),	
	number decimal(19,2),	 
	discount float,
	ivakind varchar(50),
	iva_euro decimal(19,2), 
	unabatable_euro decimal(19,2),  
	amount_euro decimal(19,2),  
	amount_currency decimal(19,2), 
	intrastatkind varchar(200), 
	code varchar(8), 
	intrastatcode varchar(1000) , 
	intrastatmeasure varchar(50), 
	weight decimal(19,2),
	OrigDescription varchar(100), 
	ProvDescription varchar(100), 
	geo_country_destination varchar(50), 
	Destination  varchar(100), 
	geo_country_origin varchar(50), 
	numerofattura varchar(15),				
	datafattura  varchar(6),			
	codServizio varchar(100), 	
	intrastatservice varchar(400),							
	intrastatsupplymethod varchar(50),				
	intrastatpaymethod varchar(50),				
	intrastatnation varchar(100), 		
	va3type varchar(50) 
)

CREATE TABLE #unifiedinvoiceApp (
	tipoRiepilogo varchar(20),
	tipoRecord varchar(20),
	periodicita varchar(20),
	anno int,
	Mese varchar(20),
	trimestre int,
	MeseFattura varchar(20), 
	segno_variazione char(1),
	ClienteFornitore varchar(100),  
	p_iva varchar(15),  
	cf varchar(16), 
	birthdate smalldatetime,
	invoicekind varchar(50), 
	yinv smallint, 
	ninv int, 
	protocolnum int,
	adate smalldatetime,	
	currency varchar(50), 
	exchangerate float,
	rownum int,
	detaildescription varchar(150), 
	taxable decimal(19,2),	
	number decimal(19,2),	 
	discount float,
	ivakind varchar(50),
	iva_euro decimal(19,2), 
	unabatable_euro decimal(19,2),  
	amount_euro decimal(19,2),  
	amount_currency decimal(19,2), 
	intrastatkind varchar(200), 
	code varchar(8), 
	intrastatcode varchar(1000) , 
	intrastatmeasure varchar(50), 
	weight decimal(19,2),
	OrigDescription varchar(100), 
	ProvDescription varchar(100), 
	geo_country_destination varchar(50), 
	Destination  varchar(100), 
	geo_country_origin varchar(50), 
	numerofattura varchar(15),				
	datafattura varchar(6),			
	codServizio varchar(100), 	
	intrastatservice varchar(400),							
	intrastatsupplymethod varchar(50),				
	intrastatpaymethod varchar(50),				
	intrastatnation varchar(100), 		
	va3type varchar(50) 
)
DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR 
SELECT iddbdepartment FROM dbdepartment
WHERE (start is null or start <= @anno ) AND ( stop is null or stop >= @anno)
OPEN @crsdepartment


FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.exp_invoice_intrastat'

		INSERT INTO #unifiedinvoiceApp (
				tipoRecord,tipoRiepilogo,periodicita,anno,Mese,trimestre,
				MeseFattura,segno_variazione,ClienteFornitore, p_iva,  cf, birthdate,
				invoicekind, yinv, ninv,rownum, protocolnum, currency,exchangerate, 
				amount_euro, amount_currency,	intrastatkind, code, intrastatcode, intrastatmeasure, weight,
				OrigDescription, ProvDescription, geo_country_destination, Destination, geo_country_origin,
				numerofattura, datafattura, codServizio, intrastatservice,							
				intrastatsupplymethod,intrastatpaymethod,intrastatnation,
				adate,detaildescription, taxable ,	number, discount,ivakind ,
				iva_euro, unabatable_euro, 
				va3type
		)
           EXEC @dip_nomesp @anno, @mese, @trimestre, @tipoRiepilogo, @periodicita ,@tiporecord
		   --EXEC exp_invoice_intrastat @anno, @mese, @trimestre, @tipoRiepilogo, @periodicita, @tiporecord 

		INSERT INTO #unifiedinvoice (
				iddbdepartment,
				tipoRecord, tipoRiepilogo,periodicita,anno,Mese,trimestre ,
				MeseFattura, segno_variazione, ClienteFornitore, p_iva,  cf, birthdate,
				invoicekind, yinv, ninv,rownum, protocolnum, currency,exchangerate, 
				amount_euro, amount_currency,	intrastatkind, code, intrastatcode, intrastatmeasure, weight,
				OrigDescription, ProvDescription, geo_country_destination, Destination, geo_country_origin,
				numerofattura, datafattura, codServizio, intrastatservice,							
				intrastatsupplymethod,intrastatpaymethod,intrastatnation,
				adate,detaildescription, taxable ,	number, discount,ivakind ,
				iva_euro, unabatable_euro, 
				va3type
		)
		SELECT @iddbdepartment,
				tipoRecord, tipoRiepilogo,periodicita,anno,Mese,trimestre ,
				MeseFattura, segno_variazione, ClienteFornitore, p_iva,  cf, birthdate,
				invoicekind, yinv, ninv,rownum, protocolnum, currency,exchangerate, 
				amount_euro, amount_currency,	intrastatkind, code, intrastatcode, intrastatmeasure, weight,
				OrigDescription, ProvDescription, geo_country_destination, Destination, geo_country_origin,
				numerofattura, datafattura, codServizio, intrastatservice,							
				intrastatsupplymethod,intrastatpaymethod,intrastatnation,
				adate,detaildescription, taxable ,	number, discount,ivakind ,
				iva_euro, unabatable_euro, 
				va3type
		FROM #unifiedinvoiceApp

		DELETE FROM #unifiedinvoiceApp

	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
end

SELECT 
	dbdepartment.iddbdepartment,
	dbdepartment.description,
	tipoRiepilogo as  'Tipo riep.',
	tipoRecord as 'Tipo record',
	@periodicita as 'Periodicità',
	anno as 'Anno',
	case when  @periodicita = 'M' 
			then Mese
			else null
	end  as 'Mese Rif.',
	case when @periodicita = 'T' 
			then trimestre
			else null
	end  as 'Trimestre Rif.',
	Mesefattura as 'Mese Fattura',
	segno_variazione as 'Segno Var',
	ClienteFornitore as 'Cliente/Fornitore',
	p_iva as 'P.Iva', 
	cf as 'Codice Fiscale',
	birthdate as 'Data Nasc.',
	invoicekind as 'Tipo Doc. Iva', 
	yinv as 'Anno Fattura',
	ninv as 'Num. Fattura', 	
	rownum as '# Dett.',
	protocolnum as 'Num. Protocollo', 	
	Currency as 'Valuta',
	exchangerate as 'Tasso Cambio',
	amount_euro as 'Ammont. In Euro',
	amount_currency as 'Ammont. In Valuta',
	intrastatkind as 'Natura Transazione',
	code as 'Cod. Nomencl. Combinata',
	intrastatcode as 'Nomencl. Combinata',
	intrastatmeasure as 'Unità di Misura Suppl.',
	weight as 'Peso in Kg',
	OrigDescription as 'Paese Orig.',
	ProvDescription as 'Paese Proven.',
	geo_country_destination as 'Provincia Destin.',
	Destination as 'Paese Destin.',
	geo_country_origin as 'Provincia Orig.',
	numerofattura as 'Numero Fattura', 
	datafattura as 'Data Fattura', 
	codServizio as 'Cod. Servizio', 
	intrastatservice as 'Servizio',							
	intrastatsupplymethod as 'Modalità erogazione',
	intrastatpaymethod as 'Modalità pagamento/incasso',
	intrastatnation as 'Paese di pagamento',
	adate as 'Data Cont.',
	detaildescription as 'Descr. Dettaglio',
	taxable as 'Impon. Unitario',
	number as 'Quantità',
	discount as 'Sconto',
	ivakind as 'Tipo Iva',
	iva_euro as 'Iva',
	unabatable_euro as 'Iva Indetr.',
	va3type as 'Tipologia VF24'
FROM #unifiedinvoice
JOIN dbdepartment
	ON #unifiedinvoice.iddbdepartment = dbdepartment.iddbdepartment
ORDER BY  dbdepartment.description, tipoRecord, MONTH(adate), yinv, ninv, rownum


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
