
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


-- CREAZIONE VISTA upbsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbsegview]
GO



CREATE VIEW [upbsegview] AS SELECT CASE WHEN upb.active = 'S' THEN 'Si' WHEN upb.active = 'N' THEN 'No' END AS upb_active,CASE WHEN upb.assured = 'S' THEN 'Si' WHEN upb.assured = 'N' THEN 'No' END AS upb_assured, upb.cigcode AS upb_cigcode, upb.codeupb, upb.cofogmpcode AS upb_cofogmpcode, upb.ct AS upb_ct, upb.cu AS upb_cu, upb.cupcode AS upb_cupcode, upb.expiration AS upb_expiration, upb.flag AS upb_flag, upb.flagactivity AS upb_flagactivity, upb.flagkind AS upb_flagkind, upb.granted AS upb_granted, upb.idepupbkind AS upb_idepupbkind, upb.idtreasurer AS upb_idtreasurer, upb.idunderwriter AS upb_idunderwriter, upb.idupb, upb.idupb_capofila AS upb_idupb_capofila, upb.lt AS upb_lt, upb.lu AS upb_lu, upb.newcodeupb AS upb_newcodeupb, upb.paridupb AS upb_paridupb, upb.previousappropriation AS upb_previousappropriation, upb.previousassessment AS upb_previousassessment, upb.printingorder AS upb_printingorder, upb.requested AS upb_requested, upb.ri_ra_quota AS upb_ri_ra_quota, upb.ri_rb_quota AS upb_ri_rb_quota, upb.ri_sa_quota AS upb_ri_sa_quota, upb.rtf AS upb_rtf, upb.start AS upb_start, upb.stop AS upb_stop, upb.title AS upb_title, upb.txt AS upb_txt, upb.uesiopecode AS upb_uesiopecode, isnull('Codice: ' + upb.codeupb + '; ','') + ' ' + isnull('Denominazione: ' + upb.title + '; ','') as dropdown_title FROM upb WITH (NOLOCK)  WHERE  upb.idupb IS NOT NULL 

GO

