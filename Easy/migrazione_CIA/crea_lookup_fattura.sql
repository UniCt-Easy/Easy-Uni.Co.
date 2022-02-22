
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


IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_fattura]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_fattura
END

create table lookup_fattura(
codtipofatturaeasy varchar(20) NOT NULL,
codtipofatturacia varchar(20),
notadicredito char(1),
rich_fatturazione char(1),
a_v char(1)
)
GO

ALTER TABLE [dbo].[lookup_fattura] ADD  CONSTRAINT [PK_lookup_fattura] PRIMARY KEY CLUSTERED 
(
	[codtipofatturaeasy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


go

/*
insert into lookup_fattura(codtipofatturaeasy, codtipofatturacia, notadicredito)
select distinct 	
	case when substring(numero_fattura,1,1)='C' then  'ACQ.COMM-'+substring(numero_fattura,7,4)
		 when substring(numero_fattura,1,1)='I' then  'ACQ.IST-'+substring(numero_fattura,7,4)
		 when substring(numero_fattura,1,1)='P' then  'ACQ.PROM-'+substring(numero_fattura,7,4)
	end,
	substring(numero_fattura,1,1)+substring(numero_fattura,7,4),
	'N'
from fattura

insert into lookup_fattura(codtipofatturaeasy, codtipofatturacia, notadicredito)
select distinct 	
	case when substring(numero_fattura,1,1)='C' then  'NC ACQ.COMM-'+substring(numero_fattura,7,4)
		 when substring(numero_fattura,1,1)='I' then  'NC ACQ.IST-'+substring(numero_fattura,7,4)
		 when substring(numero_fattura,1,1)='P' then  'NC ACQ.PROM-'+substring(numero_fattura,7,4)
	end,
	substring(numero_fattura,1,1)+substring(numero_fattura,7,4),
	'S'
from fattura_dettaglio
where numero_fattura_collegata is not null
*/

insert into lookup_fattura(codtipofatturaeasy, codtipofatturacia, notadicredito,a_v)
select distinct 	
	case when tipo_fattura = 'C' then  'ACQ.COMM-'+substring(numero_fattura,7,4)
		 when tipo_fattura = 'I' then  'ACQ.IST-'+substring(numero_fattura,7,4)
		 when tipo_fattura = 'P' then  'ACQ.PROM-'+substring(numero_fattura,7,4)
	end,
	upper(tipo_fattura) + substring(numero_fattura,7,4),
	'N',
	'A'
from fattura
WHERE  LEN (sezionale) = 4  -- NELLA MAGGIOR PARTE DEI CASI IL SEZIONALE HA LUNGHEZZA 4
AND NOTA_CREDITO_DEBITO = 'F'  


insert into lookup_fattura(codtipofatturaeasy, codtipofatturacia, notadicredito,a_v)
select distinct 	
	case when tipo_fattura = 'C' then  'ACQ.COMM-'+substring(numero_fattura,8,3)
		 when tipo_fattura = 'I' then  'ACQ.IST-'+substring(numero_fattura,8,3)
		 when tipo_fattura = 'P' then  'ACQ.PROM-'+substring(numero_fattura,8,3)
	end,
	upper(tipo_fattura) + substring(numero_fattura,8,3),
	'N',
	'A'
from fattura
WHERE LEN (sezionale) = 3 -- IN ALTRI CASI IL SEZIONALE HA LUNGHEZZA 3 MA IL NUMERO FATTURA è SEMPRE COSTITUITO DA 10 CIFRE
AND NOTA_CREDITO_DEBITO = 'F'  
 

insert into lookup_fattura(codtipofatturaeasy, codtipofatturacia, notadicredito,a_v)
select distinct 	
	case when tipo_fattura = 'C' then  'NC ACQ.COMM-'+substring(numero_fattura,7,4)
		 when tipo_fattura = 'I' then  'NC ACQ.IST-'+substring(numero_fattura,7,4)
		 when tipo_fattura = 'P' then  'NC ACQ.PROM-'+substring(numero_fattura,7,4)
	end,
	upper(tipo_fattura)+substring(numero_fattura,7,4),
	'S',
	'A'
from fattura
where NOTA_CREDITO_DEBITO <> 'F'  
 AND  LEN (sezionale) = 4  
 
 
 insert into lookup_fattura(codtipofatturaeasy, codtipofatturacia, notadicredito,a_v)
select distinct 	
	case when tipo_fattura = 'C' then  'NC ACQ.COMM-'+substring(numero_fattura,8,3)
		 when tipo_fattura = 'I' then  'NC ACQ.IST-'+substring(numero_fattura,8,3)
		 when tipo_fattura = 'P' then  'NC ACQ.PROM-'+substring(numero_fattura,8,3)
	end,
	upper(tipo_fattura)+substring(numero_fattura,8,3),
	'S',
	'A'
from fattura
where NOTA_CREDITO_DEBITO <> 'F'  
 AND  LEN (sezionale) = 3  
 
 
 
insert into lookup_fattura(codtipofatturaeasy, codtipofatturacia, notadicredito,rich_fatturazione, a_v)
select distinct 	
	case 
		when F.RICHIESTA_FATTURAZIONE='Y'  and D.numero_fattura_collegata is null		then  F.TIPO_FATTURA + '_RICHFATT'
		when F.RICHIESTA_FATTURAZIONE='Y'  and D.numero_fattura_collegata is not null	then 'ND-'+ F.TIPO_FATTURA + '_RICHFATT'
		when F.RICHIESTA_FATTURAZIONE='N'  and D.numero_fattura_collegata is null		then  F.TIPO_FATTURA +  '_NORICHFATT'
		when F.RICHIESTA_FATTURAZIONE='N'  and D.numero_fattura_collegata is not null	then  'ND-'+F.TIPO_FATTURA +  '_NORICHFATT'
	End,
	upper(F.tipo_fattura),
	case
		WHEN D.numero_fattura_collegata is not null THEN 'S'
		ELSE 'N'
	end,
	case
		WHEN  F.RICHIESTA_FATTURAZIONE='Y' THEN 'S'
		ELSE 'N'
	end,
	'V'
from fattura_att F
join fattura_att_dettaglio d
	on F.bilancio = D.bilancio 
	and F.numero_fattura = D.numero_fattura
	and F.esercizio = D.esercizio
	and F.RICHIESTA_FATTURAZIONE = D.RICHIESTA_FATTURAZIONE


GO


