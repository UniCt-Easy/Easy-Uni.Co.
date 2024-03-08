
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_scritture_stipendi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_scritture_stipendi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amm'
-- setuser 'amministrazione'
-- exec exp_scritture_stipendi 2020,18,'S',''
-- select  idcsa_import from csa_import where yimport = 2020 and nimport=19
-- Select * FROM entrydetailview WHERE idrelated = 'csa_import§114' 
CREATE PROCEDURE [exp_scritture_stipendi] 
(
	@yimport int,
	@nimport int,
	@pivot char(1) = 'S',
	@filtroconto varchar(50) = Null
)
AS BEGIN

IF LEN(@filtroconto) = 0  SELECT  @filtroconto = NULL
declare @idcsa_import int
select  @idcsa_import=idcsa_import from csa_import where yimport = @yimport and nimport=@nimport

-- 'csaimport§' + CONVERT(VARCHAR(100), csa_import.idcsa_import) + '§RIEP§' + CONVERT(VARCHAR(100), idriep)
select * INTO #ED
FROM entrydetailview
WHERE idrelated = 'csa_import§' + CONVERT(VARCHAR(10), @yimport)+'§'+CONVERT(VARCHAR(10), @nimport)

INSERT INTO #ED
select ED.* from csa_import C 
JOIN csa_import_expense ce ON C.idcsa_import=CE.idcsa_import
JOIN expense E ON CE.idexp = E.idexp 
JOIN entrydetailview ED ON idrelateddetail='expense§'+CONVERT(VARCHAR(10), E.idexp) 
WHERE C.idcsa_import=@idcsa_import

INSERT INTO #ED
select ED.* from csa_import C 
JOIN csa_import_income ce ON C.idcsa_import=CE.idcsa_import
JOIN income E ON CE.idinc = E.idinc 
JOIN entrydetailview ED ON idrelateddetail='income§'+CONVERT(VARCHAR(10), E.idinc) 
WHERE C.idcsa_import=@idcsa_import

--------------- VERIFICARE
INSERT INTO #ED
select * FROM entrydetailview
WHERE idrelated not like 'csa_import§%'
AND idrelateddetail like 'csaimport§'+ CONVERT(VARCHAR(10), @idcsa_import)+'%' --+CONVERT(VARCHAR(10), @nimport)

If @pivot = 'N'
	select 
		yentry as 'Eserc. Scrittura',
		nentry as 'Num. Scrittura',
		ndetail as 'Num. Dettaglio', 
		give as 'Dare', 
		have as 'Avere', 
		isnull(give,0)-isnull(have,0) as 'Saldo', 
		codeacc as 'Cod. Conto', 
		codeupb as 'Cod. U.P.B.',
		description as 'Descrizione Scrittura',
		detaildescription as 'Descrizione dettaglio', 
		idrelated as 'Chiave EP documento', 
		idrelateddetail as 'Chiave EP dettaglio', 
		account as 'Conto', 
		upb as 'U.P.B.', 
		registry as 'Cliente/Fornitore',
		idreg as 'Codice Anagrafica', 
		patpart as 'Parte Stato Patrim.',
		codepatrimony as 'Cod. Stato Patrim.', 
		placcpart as 'Parte Conto. Econ.', 
		codeplaccount as 'Cod. Conto Econ.',
		doc as 'Documento', 
		docdate as 'Data Documento'
	from #ED	
		WHERE (codeacc = @filtroconto OR @filtroconto IS NULL)
		order by codeacc, detaildescription
ELSE
	select 
		SUM(isnull(give,0)-isnull(have,0)) as 'Saldo',
		codeacc as 'Cod. Conto',
		account as 'Conto',
		codeupb as 'Cod. U.P.B.',
		registry as 'Cliente/Fornitore',
		idreg as 'Codice Anagrafica'
		from #ED	
	WHERE (codeacc = @filtroconto OR @filtroconto IS NULL)
	group by codeacc, account,codeupb, registry, idreg
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
