
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_ricevutatelematica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_ricevutatelematica]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 --		exec rpt_ricevutatelematica 'RF38000000000123456'
 
CREATE  PROCEDURE [rpt_ricevutatelematica]
(
	@iuv varchar(100)
)
AS BEGIN

declare @pos int 
set @pos = len('/PUR/LGPE-RIVERSAMENTO/URI/')+10 +1

SELECT        

	(select paramvalue from generalreportparameter where idparam='license_f') as cfcreditore,
	(select paramvalue from generalreportparameter where idparam='DenominazioneUniversita') as denominazionecreditore,
	FD.p_iva as pivadebitore,
	FD.cf as cfdebitore,
	(select top 1 R.title from flussocreditidetail FD 
				join registry R on R.idreg = FD.idreg
					where FD.iuv=@iuv) as denominazionedebitore,
	FD.dataesitopagamento,--Data dell’operazione 
	-- Codice identificativo del PSP 
	 case 
	 when (FD.codicepsp is not null) then FD.codicepsp
	 when PATINDEX('%/PUR/LGPE-RIVERSAMENTO/URI/%', B.motive)>=1
				then substring(b.motive, 
							@pos, 
							patindex ('%-%',substring(b.motive, @pos, len(b.motive)-@pos))
							-1
							) 
		
	else null
	end as codicepsp,
 
	FD.identificativounivocoriscossione, --Numero univoco assegnato al pagamento dal PSP 
	FD.importo,-- Importo dell’operazione.
	F.causale,
	FD.iuv
	from 	flussoincassi F
	join flussoincassidetail FD
		on F.idflusso = FD.idflusso
	join bill B
		on B.nbill = F.nbill and B.ybill = F.ayear
	where FD.iuv = @iuv
	and B.billkind ='C'
	
	
	
END

GO

