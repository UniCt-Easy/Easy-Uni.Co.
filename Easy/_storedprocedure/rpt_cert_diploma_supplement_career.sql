/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

--setuser setuser 'amministrazione'
-- CREAZIONE PROCEDURE [rpt_cert_diploma_supplement_career]
IF EXISTS (select * from sysobjects where id = object_id(N'[rpt_cert_diploma_supplement_career]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [rpt_cert_diploma_supplement_career]
GO

--exec rpt_cert_diploma_supplement_career 705, 4187, 'it'
CREATE PROCEDURE [rpt_cert_diploma_supplement_career]
	@idreg         				int,
	@idiscrizione				int,
	@lang						char(2)

AS BEGIN

	SELECT
		ins.codice
		,ins.denominazione		as materia
		,ins.denominazione_en	as materia_en
		,(select sum(afc.cf)
            from attivformcaratteristica afc
            where af.idattivform = afc.idattivform
        )                        as crediti
		,doc.forename			as docforename
		,doc.surname			as docsurname
		,s.voto
		,s.votosu
		,s.data
	FROM
		sostenimento s 
		JOIN attivform af on af.idattivform = s.idattivform  
		JOIN insegn ins on af.idinsegn = ins.idinsegn 
		JOIN attivformcaratteristica afc on af.idattivform = afc.idattivform
		LEFT OUTER JOIN canale chan on chan.idattivform = s.idattivform
		LEFT OUTER JOIN  affidamento aff on aff.idcanale = chan.idcanale
		LEFT OUTER JOIN  registry doc on doc.idreg = aff.idreg_docenti 
	WHERE
		s.idreg = @idreg AND s.idiscrizione = @idiscrizione
		and s.idsostenimentoesito in (1,7)
	ORDER BY s.data
END

GO


