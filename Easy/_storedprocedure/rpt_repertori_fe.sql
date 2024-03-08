
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_repertori_fe]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_repertori_fe]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_repertori_fe]
(
	@ayear int,
	@n_start int,
	@n_stop int,
	@kind char(1), -- Acquisto / Vendita
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
--	exec rpt_repertori_fe 2015, 1, 1000, 'A'
	if(@kind='A')
	Begin
		select 
		sdi_acquisto.arrivalprotocolnum,
		sdi_acquisto.protocoldate,
		sdi_acquisto.title,
		sdi_acquisto.ninvoice,
		sdi_acquisto.adate as 'dataemissione',
		sdi_acquisto.total,
		sdi_acquisto.description,
		sdi_acquisto.riferimento_amministrazione  as 'rifamm',--> destinatario
		sdi_rifamm.nomeufficioricevente as 'descr_rifamm',
		sdi_acquisto.codice_ipa  as 'ipa', --> destinatario 
		ipa.officename as 'descr_ipa',
		case
			when sdi_acquisto.rejectreason is not null then 'Rifiuto con motivazione :' + CHAR(13)+sdi_acquisto.rejectreason
			else null
		end as 'note',
		sdi_status.description as sdi_status,
		null as sdi_deliverystatus
		from sdi_acquisto
		LEFT OUTER JOIN sdi_status 
			ON sdi_acquisto.idsdi_status = sdi_status.idsdi_status
		LEFT OUTER JOIN sdi_rifamm 
			on sdi_acquisto.riferimento_amministrazione = sdi_rifamm.idsdi_rifamm
		LEFT OUTER JOIN ipa
			ON sdi_acquisto.codice_ipa = ipa.ipa_fe
		where sdi_acquisto.idsdi_acquisto between @n_start and @n_stop
			and year(sdi_acquisto.protocoldate) = @ayear
			and (@idsor01 IS NULL OR COALESCE (sdi_rifamm.idsor01,ipa.idsor01)= @idsor01 )
			and (@idsor02 IS NULL OR COALESCE (sdi_rifamm.idsor02,ipa.idsor02)= @idsor02 )
			and (@idsor03 IS NULL OR COALESCE (sdi_rifamm.idsor03,ipa.idsor03)= @idsor03 )
			and (@idsor04 IS NULL OR COALESCE (sdi_rifamm.idsor04,ipa.idsor04)= @idsor04 )
			and (@idsor05 IS NULL OR COALESCE (sdi_rifamm.idsor05,ipa.idsor05)= @idsor05 )
		order by sdi_acquisto.protocoldate

	End
	else
	Begin
		select
		sdi_vendita.arrivalprotocolnum,
		sdi_vendita.adate as protocoldate,
		invoiceview.registry as title,
		invoiceview.doc as ninvoice,
		invoiceview.docdate as 'dataemissione',
		invoiceview.total,
		invoiceview.description,
		sdi_vendita.idsdi_rifamm		as 'rifamm', --> mittente
		sdi_rifamm.nomeufficioricevente as 'descr_rifamm',
		sdi_vendita.ipa_fe	as 'ipa',--> mittente
		ipa.officename		as 'descr_ipa',
		case 
			when (sdi_vendita.filename is not null and sdi_vendita.identificativo_sdi is not null)
				then 'Nome file : ' + CONVERT(varchar(400),sdi_vendita.filename) + char(13)+  ' Identificativo SdI : '+ CONVERT(varchar(100),sdi_vendita.identificativo_sdi) 
			when (sdi_vendita.filename is not null)
				then 'Nome file : ' + CONVERT(varchar(400),sdi_vendita.filename)
			when (sdi_vendita.identificativo_sdi is not null)
				then ' Identificativo SdI : '+ CONVERT(varchar(100),sdi_vendita.identificativo_sdi) 
			else null
			end as note,
		sdi_status.description as sdi_status,
		sdi_deliverystatus.description as sdi_deliverystatus
		from sdi_vendita
		join invoiceview
			on sdi_vendita.idsdi_vendita = invoiceview.idsdi_vendita
		LEFT OUTER JOIN sdi_status 
			ON sdi_vendita.idsdi_status = sdi_status.idsdi_status
		LEFT OUTER JOIN sdi_deliverystatus 
			ON sdi_vendita.idsdi_deliverystatus = sdi_deliverystatus.idsdi_deliverystatus
		LEFT OUTER JOIN sdi_rifamm 
			on sdi_vendita.idsdi_rifamm = sdi_rifamm.idsdi_rifamm
		LEFT OUTER JOIN ipa
			ON sdi_vendita.ipa_fe = ipa.ipa_fe
		where sdi_vendita.idsdi_vendita between @n_start and @n_stop
			and year(sdi_vendita.adate)=@ayear
			AND (@idsor01 IS NULL OR invoiceview.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR invoiceview.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR invoiceview.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR invoiceview.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR invoiceview.idsor05 = @idsor05)
		order by sdi_vendita.adate
	End

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
