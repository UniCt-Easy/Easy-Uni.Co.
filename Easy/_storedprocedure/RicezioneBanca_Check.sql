
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


if exists (select * from dbo.sysobjects where id = object_id(N'[RicezioneBanca_Check]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [RicezioneBanca_Check]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE         PROCEDURE RicezioneBanca_Check
@tipo char(1)
as
BEGIN
IF  @tipo = '1' 
	SELECT * from BancaRxUsciteDef order by ParCheck
IF  @tipo = '2' 
	SELECT  
	'nomefile' = rtrim(ltrim(nomefile))
	,dataelab 
	,TipoRecord 
	,CodIstituto
	,Dipendenza
	,CodEnte 
	,Esercizio 
	,DataContabile
	,CodCausaleMov 
	,NumMandRev 
	,NumProgrSub 
	,Capitolo 
	,Articolo
	,AnnoResiduo 
	,CodVoceEconomica 
	,'Importo'=  
	CONVERT(decimal(19,2),
	SUBSTRING(importo,1,LEN(importo)-2)
	+'.'+
	SUBSTRING(importo, LEN(importo)-1, LEN(importo)))
	,CodEsecPagamento 
	,DestTesoUnica 
	,Causale1 

	,'importo bolli' =
	CONVERT(decimal(19,2),
	SUBSTRING(ImportoBolli,1,LEN(ImportoBolli)-2)
	+'.'+
	SUBSTRING(ImportoBolli, LEN(ImportoBolli)-1, LEN(ImportoBolli)))
	
	,'ImportoSpese'=
	CONVERT(decimal(19,2),
	SUBSTRING(ImportoSpese,1,LEN(ImportoSpese)-2)
	+'.'+
	SUBSTRING(ImportoSpese, LEN(ImportoSpese)-1, LEN(ImportoSpese)))
	
	,Anagrafica1 
	,Anagrafica2 
	,ABI 
	,CAB
	,NumeroCC
	,DataValutaEnte 
	,DataValutaCliente 
	,NumeroProgressivo 
	,DipOrigine
	,DataCarico
	,Causale2
	,Causale3
	,NumQuietanza 
	,Divisa 
	,'ImportoEuro'=
	CONVERT(decimal(19,2),
	SUBSTRING(ImportoEuro,1,LEN(ImportoEuro)-2)
	+'.'+
	SUBSTRING(ImportoEuro, LEN(ImportoEuro)-1, LEN(ImportoEuro)))
	,NumContoTeso 
	,Cin 
	,CodFunzDele 
	,DipCaricoFunzDele 
	,'ImportoLordo' =
	CONVERT(decimal(19,2),
	SUBSTRING(ImportoLordo,1,LEN(ImportoLordo)-2)
	+'.'+
	SUBSTRING(ImportoLordo, LEN(ImportoLordo)-1, LEN(ImportoLordo)))

	,Adisposizione
	from PO_BANCA_LOG01
IF  @tipo = '3' 
SELECT 
	'nomefile' = rtrim(ltrim(nomefile))
,dataelab
,TipoRecord 
,CodIstituto 
,Dipendenza 
,CodEnte 
,Esercizio 
,DescrFiliale 
,DescrEnte 
,TipologiaEnte 
,NumReveEmesse 
,NumReveIncassate 
,NumOperazionisuReve 
,NumProvvisoriEntrata 
,NumProvvisoriUscita 
,NumMandatiEmessi 
,NumMandatiPagati 
,NumOperazionisuMandati 
,'Fondo di cassa anno precedente' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo1,1,LEN(importo1)-2)
	+'.'+
	SUBSTRING(importo1, LEN(importo1)-1, LEN(importo1)))
,'Deficit di cassa anno precedente' =  
	CONVERT(decimal(19,2),
	SUBSTRING(importo2,1,LEN(importo2)-2)
	+'.'+
	SUBSTRING(importo2, LEN(importo2)-1, LEN(importo2)))
,'Reversali emesse' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo3,1,LEN(importo3)-2)
	+'.'+
	SUBSTRING(importo3, LEN(importo3)-1, LEN(importo3)))
,'Reversali incassate' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo4,1,LEN(importo4)-2)
	+'.'+
	SUBSTRING(importo4, LEN(importo4)-1, LEN(importo4)))
,'Operazioni su reversali' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo5,1,LEN(importo5)-2)
	+'.'+
	SUBSTRING(importo5, LEN(importo5)-1, LEN(importo5)))
,'Provvisori entrata' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo5bis,1,LEN(importo5bis)-2)
	+'.'+
	SUBSTRING(importo5bis, LEN(importo5bis)-1, LEN(importo5bis)))
,'Provvisori uscita' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo6,1,LEN(importo6)-2)
	+'.'+
	SUBSTRING(importo6, LEN(importo6)-1, LEN(importo6)))
,'Mandati emessi' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo7,1,LEN(importo7)-2)
	+'.'+
	SUBSTRING(importo7, LEN(importo7)-1, LEN(importo7)))
,'Mandati pagati' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo8,1,LEN(importo8)-2)
	+'.'+
	SUBSTRING(importo8, LEN(importo8)-1, LEN(importo8)))
,'Operazioni su mandati' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo9,1,LEN(importo9)-2)
	+'.'+
	SUBSTRING(importo9, LEN(importo9)-1, LEN(importo9)))
,'Saldo di diritto' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo10,1,LEN(importo10)-2)
	+'.'+
	SUBSTRING(importo10, LEN(importo10)-1, LEN(importo10)))
,'Saldo di fatto' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo11,1,LEN(importo11)-2)
	+'.'+
	SUBSTRING(importo11, LEN(importo11)-1, LEN(importo11)))
,'Anticipazione accordata' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo12,1,LEN(importo12)-2)
	+'.'+
	SUBSTRING(importo12, LEN(importo12)-1, LEN(importo12)))

,'Anticipazione utilizzata' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo13,1,LEN(importo13)-2)
	+'.'+
	SUBSTRING(importo13, LEN(importo13)-1, LEN(importo13)))
,'Disponibilita effettiva' = 
	CONVERT(decimal(19,2),
	SUBSTRING(importo14,1,LEN(importo14)-2)
	+'.'+
	SUBSTRING(importo14, LEN(importo14)-1, LEN(importo14)))
,DataElaborazione 
,ContabSpeciale1 
,ContabSpeciale2 

,GestioneImporti 
,ADisposizione 
 from PO_BANCA_LOG02
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

