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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_entrydetail_idrelated_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_entrydetail_idrelated_csa]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- --
--SETUSER 'amministrazione'
-- exec [exp_entrydetail_idrelated_csa] 2024 , 1 --,  '10133578' 
CREATE    PROCEDURE [exp_entrydetail_idrelated_csa]
(
	@yimport int,
	@nimport int,
	@matricola varchar(40) = NULL
) 
AS BEGIN
SELECT 
	EV.idrelateddetail as 'IdRelated', 
	ltrim(rtrim(reverse(Substring(reverse(EV.detaildescription), 0,
	CHARINDEX(reverse('Matricola:  '),reverse(EV.detaildescription))+len('Matricola:  '))))) AS matricola,
	EV.idreg,
	registry as 'Anagrafica Stipendi',
	yentry as 'Eserc. scrittura', nentry as 'Num. scrittura', 
	ndetail as 'Dett. Scritt.', 
	/*amount as 'Importo',*/ give as 'Dare', 
	have as 'Avere',
	idacc,
	codeacc as 'Cod. Conto', 
	account as 'Conto', 
	idupb,
	codeupb as 'Cod. UPB',   
	upb as 'UPB',  

	detaildescription as 'Descrizione',
	--EV.idepacc,
	--EV.idepexp, 
	CHILD.yepexp as 'Eserc. Impegno di Budget', CHILD.nepexp as 'Num. Impegno di Budget',
	PARENT.yepexp as 'Eserc. PreImpegno di Budget', PARENT.nepexp as 'Num. PreImpegno di Budget',
	yepacc as 'Eserc. Accertamento di Budget', nepacc as 'Num. Accertamento di Budget', 
	--EV.idexp, 
	E.ymov as 'Eserc. Pagamento', E.nmov as 'Num. Pagamento', 
	--EV.idinc, 
	I.ymov as 'Eserc. Incasso', I.nmov  as 'Num. Incasso'
	FROM entrydetailview EV
	LEFT OUTER JOIN expense E ON EV.idexp = E.idexp
	LEFT OUTER JOIN income I ON EV.idinc = I.idinc 
	LEFT OUTER JOIN epexp CHILD ON EV.idepexp = CHILD.idepexp 
	LEFT OUTER JOIN epexp PARENT ON PARENT.idepexp = CHILD.paridepexp 
	WHERE EV.idrelated =   'csa_import'+ '§' + convert(varchar(4),@yimport) + + '§' + convert(varchar(4),@nimport)   -- csa_import§2023§1
	AND (@matricola is null or @matricola = ltrim(rtrim(reverse(Substring(reverse(EV.detaildescription), 0,
	CHARINDEX(reverse('Matricola:  '),reverse(EV.detaildescription))+len('Matricola:  ')))) ))
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO				

					