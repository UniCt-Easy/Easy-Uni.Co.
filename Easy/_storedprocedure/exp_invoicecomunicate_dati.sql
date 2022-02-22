
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicecomunicate_dati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicecomunicate_dati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure exp_invoicecomunicate_dati(
	@esercizio int,		-- anno solare
	@semestre int,		-- vale 1 o 2
	@kind char(1)		-- Acquisto o Vendita
	) as
begin

-- exec exp_invoicecomunicate_dati 2017, 1,'A'

create table #documento(
	invoicekind varchar(150),
	idinvkind int,
	yinv smallint,
	ninv int,
	position int,
	tipofattura char(1),
	IdTrasmittenteCodice varchar(20),
	ProgressivoInvio varchar(10),
	IdSistema varchar(5),
	ProgressivoFile  varchar(5),
	IdFiscaleIvaCodiceDip  varchar(30),
	DenominazioneDip  varchar(80),
	indirizzoDip varchar(60),
	capDip varchar(5),
	comuneDip varchar(60),
	provinciaDip varchar(2),
	nazioneDip varchar(2),
	IdFiscaleIvaPaeseAnagrafica varchar(2),
	IdFiscaleIvaCodiceAnagrafica varchar(28),
	CFAnagrafica varchar(20),
	flaghuman char(1),
	DenominazioneAnagrafica varchar(80),
	cognomeAnagrafica varchar(60),
	nomeAnagrafica varchar(60),
	
	indirizzoAnagrafica varchar(60),
	comuneAnagrafica varchar(60),
	capAnagrafica varchar(5),
	provinciaAnagrafica  varchar(2),
	nazioneAnagrafica  varchar(2),
	Tipodocumento varchar(50),
	datadocumento datetime,
	dataregistrazione datetime,
	numero  varchar(200),
	coderesidence char(1)
)

INSERT INTO #documento 
exec exp_invoicecomunicate @esercizio,	@semestre , @kind 

create table #dati_riepilogo(
	invoicekind varchar(50),
	idinvkind int,
	yinv smallint,
	ninv int,
	AliquotaIVA decimal(19,2),
	Natura varchar(10),
	ImponibileImporto  decimal(19,2),
	Imposta  decimal(19,2),
	Detraibile int,
	Deducibile char(1),
	EsigibilitaIVA char(1)
)
INSERT INTO #dati_riepilogo
EXEC  exp_invoicecomunicateriepilogo  @esercizio,	@semestre , @kind 


select 
	D.invoicekind as 'TipoDoc',
	--idinvkind,
	D.yinv as 'Eserc.Doc',
	D.ninv as 'Num.Doc',
	--D.tipofattura ,
	D.IdTrasmittenteCodice ,
	D.IdFiscaleIvaCodiceDip ,
	D.DenominazioneDip  ,
	D.indirizzoDip ,
	D.capDip ,
	D.comuneDip ,
	D.provinciaDip ,
	D.nazioneDip,
	D.IdFiscaleIvaPaeseAnagrafica ,
	D.IdFiscaleIvaCodiceAnagrafica,
	D.CFAnagrafica,
	D.DenominazioneAnagrafica,
	D.cognomeAnagrafica ,
	D.nomeAnagrafica,
	D.indirizzoAnagrafica ,
	D.comuneAnagrafica,
	D.capAnagrafica ,
	D.provinciaAnagrafica,
	D.nazioneAnagrafica ,
	D.Tipodocumento,
	D.datadocumento as 'DataDocumento',
	D.dataregistrazione	as'DataRegistrazione',

	R.AliquotaIVA,
	R.Natura,
	R.ImponibileImporto,
	R.Imposta,
	R.EsigibilitaIVA  ,
	coderesidence as 'codresidenza',
	'' as 'error'
from #documento D
join #dati_riepilogo R
	ON R.idinvkind = D.idinvkind
	AND R.yinv = D.yinv
	AND R.ninv = D.ninv 

end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
