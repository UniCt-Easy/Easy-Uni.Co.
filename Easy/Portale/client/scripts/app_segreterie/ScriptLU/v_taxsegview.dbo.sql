
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


-- CREAZIONE VISTA taxsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[taxsegview]
GO



CREATE VIEW [dbo].[taxsegview] AS SELECT CASE WHEN tax.active = 'S' THEN 'Si' WHEN tax.active = 'N' THEN 'No' END AS tax_active,CASE WHEN tax.appliancebasis = 'S' THEN 'Si' WHEN tax.appliancebasis = 'N' THEN 'No' END AS tax_appliancebasis, tax.ct AS tax_ct, tax.cu AS tax_cu, tax.description, tax.fiscaltaxcode AS tax_fiscaltaxcode, tax.fiscaltaxcodecredit AS tax_fiscaltaxcodecredit,CASE WHEN tax.flagunabatable = 'S' THEN 'Si' WHEN tax.flagunabatable = 'N' THEN 'No' END AS tax_flagunabatable,CASE WHEN tax.geoappliance = 'S' THEN 'Si' WHEN tax.geoappliance = 'N' THEN 'No' END AS tax_geoappliance, accmotivecost.codemotive AS accmotivecost_codemotive, accmotivecost.title AS accmotivecost_title, tax.idaccmotive_cost, accmotivedebit.codemotive AS accmotivedebit_codemotive, accmotivedebit.title AS accmotivedebit_title, tax.idaccmotive_debit, accmotivepay.codemotive AS accmotivepay_codemotive, accmotivepay.title AS accmotivepay_title, tax.idaccmotive_pay, tax.insuranceagencycode AS tax_insuranceagencycode, tax.lt AS tax_lt, tax.lu AS tax_lu, tax.maintaxcode AS tax_maintaxcode, tax.taxablecode AS tax_taxablecode, tax.taxcode, tax.taxkind AS tax_taxkind, tax.taxref AS tax_taxref, isnull('Descrizione: ' + tax.description + '; ','') + ' ' + isnull('Codice ritenuta: ' + tax.taxref + '; ','') as dropdown_title FROM [dbo].tax WITH (NOLOCK)  LEFT OUTER JOIN [dbo].accmotive AS accmotivecost WITH (NOLOCK) ON tax.idaccmotive_cost = accmotivecost.idaccmotive LEFT OUTER JOIN [dbo].accmotive AS accmotivedebit WITH (NOLOCK) ON tax.idaccmotive_debit = accmotivedebit.idaccmotive LEFT OUTER JOIN [dbo].accmotive AS accmotivepay WITH (NOLOCK) ON tax.idaccmotive_pay = accmotivepay.idaccmotive WHERE  tax.active = 'S' AND tax.taxcode IS NOT NULL 

GO

