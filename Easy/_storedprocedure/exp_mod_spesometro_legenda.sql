
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_spesometro_legenda]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_spesometro_legenda]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_mod_spesometro_legenda]

AS BEGIN
CREATE TABLE #RECORD(
	quadro varchar(50),
	descrizione varchar(500)
)

	insert into #RECORD(quadro, descrizione)
	values('FA','Operazioni documentate da fattura')

	insert into #RECORD(quadro, descrizione)
	values('FA001003','Num.operazioni attive aggregate')

	insert into #RECORD(quadro, descrizione)
	values('FA001004','Num.operazioni passive aggregate')

	insert into #RECORD(quadro, descrizione)
	values('FA001005','Noleggio/Leasing')

	insert into #RECORD(descrizione)
	values('Operazioni Attive')

	insert into #RECORD(quadro, descrizione)
	values('FA001006','Tot. Operazioni imponibili,nonimponibili ed esenti')

	insert into #RECORD(quadro, descrizione)
	values('FA001007','Tot.Imposta')

	insert into #RECORD(quadro, descrizione)
	values('FA001008','Tot.Operazioni con IVA non esposta')

	insert into #RECORD(quadro, descrizione)
	values('FA001009','Tot.Note di variazione a debito')

	insert into #RECORD(quadro, descrizione)
	values('FA001010','Tot.imposta sulle Note di variazione a debito')

	insert into #RECORD(descrizione)
	values('Operazioni Passive')

	insert into #RECORD(quadro, descrizione)
	values('FA001011','Tot. Operazioni imponibili,nonimponibili ed esenti')

	insert into #RECORD(quadro, descrizione)
	values('FA001012','Tot.Imposta')
	insert into #RECORD(quadro, descrizione)
	values('FA001013','Tot.Operazioni con IVA non esposta')
	insert into #RECORD(quadro, descrizione)
	values('FA001014','Tot.note di variazone acredito')
	insert into #RECORD(quadro, descrizione)
	values('FA001015','Tot.imposta sulle Note di variazione a credito')
	
	insert into #RECORD(quadro,descrizione)
	values('BL','OPERAZIONI CON SOGGETTI AVENTI SEDE, RESIDENZA O DOMICILIO IN PAESI CON FISCALITÀ PRIVILEGIATA')
	insert into #RECORD(quadro,descrizione)
	values('BL','OPERAZIONI CON SOGGETTI NON RESIDENTI IN FORMA AGGREGATA')
	insert into #RECORD(quadro,descrizione)
	values('BL','ACQUISTI DI SERVIZI DA NON RESIDENTI IN FORMA AGGREGATA')

	insert into #RECORD(quadro, descrizione)
	values('BL002001','Codice identificativi IVA')
	insert into #RECORD(quadro, descrizione)
	values('BL002002','Operazioni con paesi con fiscalità privilegiata')
	insert into #RECORD(quadro, descrizione)
	values('BL002003','Operazioni con soggetti Non Residenti')
	insert into #RECORD(quadro, descrizione)
	values('BL002004','Acquisti di servizi da soggetti Non Residenti')
	insert into #RECORD(quadro, descrizione)
	values('','Operazioni ATTIVE')
-- Operazioni ATTIVE
-- BL003 - Operazioni imponibili, non imponibili ed esenti. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" o "Operazioni con soggetti non residenti" 
	insert into #RECORD(quadro, descrizione)
	values('BL003001','Importo complessivo(Op. Imponibili, non imponibili ed esenti per "Operazioni con paesi a fiscalità privilegiata" o "Operazioni con soggetti non residenti" )')
	insert into #RECORD(quadro, descrizione)
	values('BL003002','Imposta(Op. imponibili, non imponibili ed esenti per "Operazioni con paesi a fiscalità privilegiata" o "Operazioni con soggetti non residenti" )')
	-- BL004 - Operazioni non soggette ad IVA. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata"
	insert into #RECORD(quadro, descrizione)
	values('BL004001','Cessione di beni-importo complessivo(Operazioni con paesi a fiscalità privilegiata, non soggette a IVA )')
	insert into #RECORD(quadro, descrizione)
	values('BL004002','Prestazione di servizi-importo complessivo(Operazioni con paesi a fiscalità privilegiata, non soggette a IVA )')
--BL005 - Note di variazione. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" (caselle BL002002) 
	insert into #RECORD(quadro, descrizione)
	values('BL005001','Note di Variazione-Importo Complessivo(Operazioni con paesi a fiscalità privilegiata)')
	insert into #RECORD(quadro, descrizione)
	values('BL005002','Note di Variazione - Imposta(Operazioni con paesi a fiscalità privilegiata')
	insert into #RECORD(quadro, descrizione)
	values('','Operazioni PASSIVE')
-- Operazioni PASSIVE
--BL006 - Operazioni imponibili, non imponibili ed esenti. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" o "Operazioni con soggetti non residenti" 
	insert into #RECORD(quadro, descrizione)
	values('BL006001','Importo complessivo(Op. Imponibili, non imponibili ed esenti per "Operazioni con paesi a fiscalità privilegiata" o "Operazioni con soggetti non residenti" )')
	insert into #RECORD(quadro, descrizione)
	values('BL006002','Imposta(Op. imponibili, non imponibili ed esenti per "Operazioni con paesi a fiscalità privilegiata" o "Operazioni con soggetti non residenti" )')
-- BL007 - Operazioni non soggette ad IVA. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" 
	insert into #RECORD(quadro, descrizione)
	values('BL007001','Importo Complessivo(Operazioni con paesi a fiscalità privilegiata, Op. non soggette a IVA)')
-- BL008 - Note di variazione. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" 
	insert into #RECORD(quadro, descrizione)
	values('BL008001','Note di Variazione-Importo Complessivo(Operazioni con paesi a fiscalità privilegiata)')
	insert into #RECORD(quadro, descrizione)
	values('BL008002','Note di Variazione - Imposta(Operazioni con paesi a fiscalità privilegiata')

	insert into #RECORD(quadro, descrizione)
	values('SE','Acquisti da operatori di San Marino')

	insert into #RECORD(quadro, descrizione)
	values('SE001012','Data emissione documento/fattura')

	insert into #RECORD(quadro, descrizione)
	values('SE001013','Data registrazione fattura(la data deve essere inclusa nell''anno di riferimento)')

	insert into #RECORD(quadro, descrizione)
	values('SE001014','N°fattura')
	insert into #RECORD(quadro, descrizione)
	values('SE001015','Imponibile')
	insert into #RECORD(quadro, descrizione)
	values('SE001016','Imposta')
	insert into #RECORD(quadro, descrizione)
	values('SE001017','Conferma importo(Dato obbligatorio se l''importo è maggiore di 999999)')

	SELECT * FROM #RECORD
	DROP TABLE #RECORD
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

