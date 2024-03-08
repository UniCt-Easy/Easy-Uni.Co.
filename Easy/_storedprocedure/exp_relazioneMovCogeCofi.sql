
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_relazioneMovCogeCofi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_relazioneMovCogeCofi]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--- setuser 'amministrazione'
-- exec [exp_relazioneMovCogeCofi] 2016, 'Z'
-- sp_help 'mandatekind'   inv§395§2016§3§1
CREATE     PROCEDURE [exp_relazioneMovCogeCofi]
	@ayear int ,
	@tipo  varchar(1) -- A Fatture Acquisto; V Fatture Vendita
AS 
BEGIN
CREATE TABLE #Lunghezze (yentry int,nentry int ,ndetail int ,idrelateddetail varchar(50), Pos1 int, Pos2 int , Pos3 int, Pos4 int, idepexp int , idacc varchar(50), amount decimal (19,2))
CREATE TABLE #Scritture (TipoDoc Varchar(100), EsDoc int,NumDoc int ,RigaDoc int ,UpbDoc varchar(50), CodConto Varchar(50), DesConto varchar(150), amount decimal(19,2), Dare decimal(19,2), Avere decimal(19,2), 
						NumDocForn varchar(50), DataDocForn datetime, AnnoLiq int, NumLiq int, AnnoImp int, NumImp int, AnnoPre int, NumPre int,
						VoceBil int, idrelateddetail varchar(50), idepexp int, idexp int  )

IF @tipo = 'Z'
	BEGIN
		SELECT  ED.yentry as 'Anno Scrittura' , ED.nentry as 'Num. Scrittura',ED.ndetail as 'Riga scrittura', ED.description as 'Descr. Scrittura', 'Fatt. '+ID.invoicekind as 'Tipo documento', ID.Yinv as 'Es. documento', ID.ninv as 'Num. doc', --ID.rownum,ID.idgroup, 

			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.idrelateddetail ,
			ED.idepacc
	from  entrydetailview ED 
	LEFT OUTER JOIN income E3 ON E3.idinc = SUBSTRING(SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)))-1)  
	JOIN invoicedetailview ID ON ID.idinc_taxable = E3.idinc AND ID.yinv < @ayear
	WHERE (ED.idrelateddetail like 'income%' OR ED.idrelateddetail  is null)
	UNION
	SELECT ED.yentry as 'Anno Scrittura' , ED.nentry as 'Num. Scrittura',ED.ndetail as 'Riga scrittura', ED.description as 'Descr. Scrittura', 'Fatt. '+ID.invoicekind as 'Tipo documento', ID.Yinv as 'Es. documento', ID.ninv as 'Num. doc', --ID.rownum,ID.idgroup, 
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.idrelateddetail ,
			ED.idepacc
	from  entrydetailview ED 
	LEFT OUTER JOIN income E3 ON E3.idinc = SUBSTRING(SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)))-1)  
	JOIN invoicedetailview ID ON ID.idinc_iva = E3.idinc AND ID.yinv < @ayear AND ID.idinc_iva<>ID.idinc_taxable
	WHERE (ED.idrelateddetail like 'income%' OR ED.idrelateddetail  is null)
		UNION
	SELECT  ED.yentry as 'Anno Scrittura' , ED.nentry as 'Num. Scrittura',ED.ndetail as 'Riga scrittura', ED.description as 'Descr. Scrittura', 'C.P. '+ID.estimkind as 'Tipo documento', ID.yestim as 'Es. documento', ID.nestim as 'Num. doc', --ID.rownum,ID.idgroup, 

			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.idrelateddetail ,
			ED.idepacc
	from  entrydetailview ED 
	LEFT OUTER JOIN income E3 ON E3.idinc = SUBSTRING(SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)))-1)  
	JOIN income E2 ON E2.idinc = E3.parentidinc
	JOIN estimatedetailview ID ON ID.idinc_taxable = E2.idinc AND ID.yestim < @ayear
	JOIN estimatekind ON estimatekind.idestimkind = ID.idestimkind
	WHERE (ED.idrelateddetail like 'income%' OR ED.idrelateddetail  is null)
		AND estimatekind.linktoinvoice = 'N'
	END

IF @tipo = 'Y'
	BEGIN
	SELECT  ED.yentry as 'Anno Scrittura' , ED.nentry as 'Num. Scrittura',ED.ndetail as 'Riga scrittura', ED.description as 'Descr. Scrittura', 'Fatt. '+ID.invoicekind as 'Tipo documento', ID.Yinv as 'Es. documento', ID.ninv as 'Num. doc', --ID.rownum,ID.idgroup, 

			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.idrelateddetail ,
			ED.idepexp
	from  entrydetailview ED 
	LEFT OUTER JOIN EXPENSE E3 ON E3.idexp = SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1)  
	JOIN invoicedetailview ID ON ID.idexp_taxable = E3.idexp AND ID.yinv < @ayear
	WHERE (ED.idrelateddetail like 'expense%' OR ED.idrelateddetail  is null)
	UNION
	SELECT ED.yentry as 'Anno Scrittura' , ED.nentry as 'Num. Scrittura',ED.ndetail as 'Riga scrittura', ED.description as 'Descr. Scrittura', 'Fatt. '+ID.invoicekind as 'Tipo documento', ID.Yinv as 'Es. documento', ID.ninv as 'Num. doc', --ID.rownum,ID.idgroup, 
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.idrelateddetail ,
			ED.idepexp
	from  entrydetailview ED 
	LEFT OUTER JOIN EXPENSE E3 ON E3.idexp = SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1)  
	JOIN invoicedetailview ID ON ID.idexp_iva = E3.idexp AND ID.yinv < @ayear AND ID.idexp_iva<>ID.idexp_taxable
	WHERE (ED.idrelateddetail like 'expense%' OR ED.idrelateddetail  is null)
	UNION
		SELECT  ED.yentry as 'Anno Scrittura' , ED.nentry as 'Num. Scrittura',ED.ndetail as 'Riga scrittura', ED.description as 'Descr. Scrittura', 'C.P. '+ID.mankind as 'Tipo documento', ID.Yman as 'Es. documento', ID.Nman as 'Num. doc', --ID.rownum,ID.idgroup, 

			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.idrelateddetail ,
			ED.idepexp
	from  entrydetailview ED 
	LEFT OUTER JOIN EXPENSE E3 ON E3.idexp = SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1)  
	JOIN expense E2 ON E2.idexp = E3.parentidexp
	JOIN mandatedetailview ID ON ID.idexp_taxable = E2.idexp AND ID.yman < @ayear
	JOIN mandatekind ON mandatekind.idmankind = ID.idmankind
	WHERE (ED.idrelateddetail like 'expense%' OR ED.idrelateddetail  is null)
		AND mandatekind.linktoinvoice = 'N'
	ORDER BY 5,6,7,9
	END
----- Contratti Attivi
IF @tipo = 'E'
	BEGIN
	INSERT INTO #Lunghezze
	select  yentry,nentry,ndetail,idrelateddetail, 
	CHARINDEX('§',idrelateddetail) as Pos1,  
	CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)  as Pos2,
	CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)+1 ) as Pos3,
	CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)+1 )  +1) as Pos4,
	idepacc, idacc, CONVERT( decimal(19,2),amount)
	from entrydetailview
	where idrelateddetail like 'estim%' and yentry = @ayear ;
	Print 'Insert scritture'
	INSERT INTO #Scritture
	select estimatekind.description								as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1)	as 'Esercizio documento', 
			substring(ED.idrelateddetail,Pos3+1,Pos4-Pos3-1)	as 'Num. documento',  
			substring(ED.idrelateddetail,Pos4+1,LEN(ED.idrelateddetail))			as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount ,
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.doc												as 'Num. Documento fornitore',
			ED.docdate											as 'Data documento fornitore',
			NULL												as 'Anno Liquidazione',
			NULL												as 'Num. Liquidazione',
			E2.ymov												as 'Anno Impegno',
			E2.nmov												as 'Num. Impegno',
			E1.ymov												as 'Anno PreImpegno',
			E1.nmov												as 'Num. PreImpegno',
			fin.codefin											as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepacc,
			ID.idinc_taxable
	from #lunghezze L
	JOIN entrydetailview ED ON L.yentry =ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
	JOIN estimatekind ON estimatekind.idestimkind = CONVERT(varchar(50), substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1))
	JOIN estimatedetail ID ON ID.idestimkind = CONVERT(varchar(50), substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) )
			AND ID.yestim = CONVERT(int, substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1))
			AND ID.nestim = CONVERT(int, substring(ED.idrelateddetail,Pos3+1,Pos4-Pos3-1) )
			AND ID.rownum = CONVERT(int, substring(ED.idrelateddetail,Pos4+1,LEN(ED.idrelateddetail)))
	LEFT OUTER JOIN income E2 ON E2.idinc = ID.idinc_taxable
	LEFT OUTER JOIN incomeyear EY2 ON EY2.idinc = E2.idinc AND EY2.ayear = @ayear
	LEFT OUTER JOIN fin ON fin.idfin = EY2.idfin
	LEFT OUTER JOIN income E1 ON E2.parentidinc = E1.idinc
	WHERE estimatekind.linktoinvoice = 'N'

	INSERT INTO #Scritture
	SELECT  (SELECT distinct TipoDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)	as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			(SELECT distinct EsDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc  and #Scritture.idepexp is not null)	as 'Esercizio documento', 
			(SELECT MIN(NumDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc  and #Scritture.idepexp is not null)		as 'Num. documento',  
			(SELECT MIN(RigaDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc  and #Scritture.idepexp is not null)		as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount, 
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			(SELECT MIN(NumDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)		as 'Num. Documento fornitore',
			(SELECT MIN(DataDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)		as 'Data documento fornitore',
			E3.ymov			as 'Anno Liquidazione',
			E3.nmov			as 'Num. Liquidazione',
			(SELECT MIN(AnnoImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Anno Impegno',
			(SELECT MIN(NumImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Num. Impegno',
			(SELECT MIN(AnnoPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Anno PreImpegno',
			(SELECT MIN(NumPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Num. PreImpegno',
			(SELECT MIN(VoceBil) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepacc, 
			--SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',ED.idrelateddetail)-2) 
			SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1) 
	from  entrydetailview ED -- ON ED.idepexp = #Scritture.idepexp and ED.amount =  -#Scritture.amount--and ED.codeacc = #Scritture.CodConto and ED.amount =  -#Scritture.amount
	LEFT OUTER JOIN income E3 ON E3.idinc = SUBSTRING(SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)))-1)  
	WHERE (ED.idrelateddetail like 'income%' OR ED.idrelateddetail  is null)
	AND ED.idepacc IN (SELECT distinct idepexp from #Scritture Where idepexp is not null)

	SELECT  TipoDoc as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			EsDoc as 'Esercizio documento', 
			NumDoc as 'Num. documento',  
			RigaDoc as 'Riga documento' ,
			UpbDoc  as 'UPB scrittura',
			CodConto as 'Codice Conto',
			DesConto as 'Denominazione Conto',
			Dare as 'Dare',
			Avere as 'Avere',
			NumDocForn as 'Num. Documento fornitore',
			DataDocForn as 'Data documento fornitore',
			AnnoLiq as 'Anno Incasso',
			NumLiq as 'Num. Incasso',
			AnnoImp as 'Anno Accertamento',
			NumImp as 'Num. Accertamento',
			AnnoPre as 'Anno Pre Accertamento',
			NumPre as 'Num. Pre Accertamento',
			VoceBil as 'Voce finanziaria',
			idrelateddetail ,
			idepexp as idapAcc
	from #Scritture
	Where idepexp is not null
	ORDER BY idepexp, SUBSTRING( #Scritture.idrelateddetail,1,3) asc, CodConto desc
END

----- Fatture di Vendita
IF @tipo = 'V'
	BEGIN
	INSERT INTO #Lunghezze
	select  yentry,nentry,ndetail,idrelateddetail, 
	CHARINDEX('§',idrelateddetail) as Pos1,  
	CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)  as Pos2,
	CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) + CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1) )  as Pos3,
	CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) + CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1) ) +1) as Pos4,
	idepacc, idacc, CONVERT( decimal(19,2),amount)
	from entrydetailview
	where idrelateddetail like 'inv%' and yentry = @ayear ;

	INSERT INTO #Scritture
	select invoicekind.description								as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1)	as 'Esercizio documento', 
			substring(ED.idrelateddetail,Pos3+1,Pos4-Pos3-1)	as 'Num. documento',  
			substring(ED.idrelateddetail,Pos4+1,LEN(ED.idrelateddetail))			as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount ,
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.doc												as 'Num. Documento fornitore',
			ED.docdate											as 'Data documento fornitore',
			E3.ymov												as 'Anno Incasso',
			E3.nmov												as 'Num. Incasso',
			E2.ymov												as 'Anno Accertamento',
			E2.nmov												as 'Num. Accertamento',
			E1.ymov												as 'Anno PreAccertamento',
			E1.nmov												as 'Num. PreAccertamento',
			fin.codefin											as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepacc,
			ID.idinc_taxable
	from #lunghezze L
	JOIN entrydetailview ED ON L.yentry =ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
	JOIN invoicekind ON invoicekind.idinvkind = CONVERT(int, substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1))
	JOIN invoicedetail ID ON ID.idinvkind = CONVERT(int, substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) )
			AND ID.yinv = CONVERT(int, substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1))
			AND ID.ninv = CONVERT(int, substring(ED.idrelateddetail,Pos3+1,Pos4-Pos3-1) )
			AND ID.rownum = CONVERT(int, substring(ED.idrelateddetail,Pos4+1,LEN(ED.idrelateddetail)))
	LEFT OUTER JOIN income E3 ON E3.idinc = ID.idinc_taxable
	LEFT OUTER JOIN incomeyear EY3 ON EY3.idinc = E3.idinc AND EY3.ayear = @ayear
	LEFT OUTER JOIN fin ON fin.idfin = EY3.idfin
	LEFT OUTER JOIN income E2 ON E3.parentidinc = E2.idinc
	LEFT OUTER JOIN income E1 ON E2.parentidinc = E1.idinc
	WHERE (invoicekind.flag & 1) <> 0

	INSERT INTO #Scritture
	SELECT  (SELECT distinct TipoDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)	as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			(SELECT distinct EsDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc  and #Scritture.idepexp is not null)	as 'Esercizio documento', 
			(SELECT MIN(NumDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc  and #Scritture.idepexp is not null)		as 'Num. documento',  
			(SELECT MIN(RigaDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc  and #Scritture.idepexp is not null)		as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount, 
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			(SELECT MIN(NumDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)		as 'Num. Documento fornitore',
			(SELECT MIN(DataDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)		as 'Data documento fornitore',
			(SELECT MIN(AnnoLiq) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Anno Liquidazione',
			(SELECT MIN(NumLiq) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Num. Liquidazione',
			(SELECT MIN(AnnoImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Anno Impegno',
			(SELECT MIN(NumImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Num. Impegno',
			(SELECT MIN(AnnoPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Anno PreImpegno',
			(SELECT MIN(NumPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Num. PreImpegno',
			(SELECT MIN(VoceBil) FROM #Scritture WHERE #Scritture.idepexp= ED.idepacc and #Scritture.idepexp is not null)			as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepacc, 
			--SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',ED.idrelateddetail)-2) 
			SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1) 
	from  entrydetailview ED -- ON ED.idepexp = #Scritture.idepexp and ED.amount =  -#Scritture.amount--and ED.codeacc = #Scritture.CodConto and ED.amount =  -#Scritture.amount
	LEFT OUTER JOIN income E3 ON E3.idinc = SUBSTRING(SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 8,LEN(ED.idrelateddetail)))-1)  
	WHERE (ED.idrelateddetail like 'income%' OR ED.idrelateddetail  is null)
	AND ED.idepacc IN (SELECT distinct idepexp from #Scritture Where idepexp is not null)

	SELECT  TipoDoc as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			EsDoc as 'Esercizio documento', 
			NumDoc as 'Num. documento',  
			RigaDoc as 'Riga documento' ,
			UpbDoc  as 'UPB scrittura',
			CodConto as 'Codice Conto',
			DesConto as 'Denominazione Conto',
			Dare as 'Dare',
			Avere as 'Avere',
			NumDocForn as 'Num. Documento fornitore',
			DataDocForn as 'Data documento fornitore',
			AnnoLiq as 'Anno Incasso',
			NumLiq as 'Num. Incasso',
			AnnoImp as 'Anno Accertamento',
			NumImp as 'Num. Accertamento',
			AnnoPre as 'Anno Pre Accertamento',
			NumPre as 'Num. Pre Accertamento',
			VoceBil as 'Voce finanziaria',
			idrelateddetail ,
			idepexp
	from #Scritture
	Where idepexp is not null
	ORDER BY idepexp, SUBSTRING( #Scritture.idrelateddetail,1,3) desc, CodConto desc
END
--- Fatture d'Acquisto
IF @tipo = 'A'
	BEGIN
	INSERT INTO #Lunghezze
	select  yentry,nentry,ndetail,idrelateddetail, 
	CHARINDEX('§',idrelateddetail) as Pos1,  
	CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)  as Pos2,
	CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) + CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1) )  as Pos3,
	CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) + CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1) ) +1) as Pos4,
	idepexp, idacc, CONVERT( decimal(19,2),amount)
	from entrydetailview
	where idrelateddetail like 'inv%' and yentry = @ayear ;

	INSERT INTO #Scritture
	select invoicekind.description								as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1)	as 'Esercizio documento', 
			substring(ED.idrelateddetail,Pos3+1,Pos4-Pos3-1)	as 'Num. documento',  
			substring(ED.idrelateddetail,Pos4+1,LEN(ED.idrelateddetail))			as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount ,
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.doc												as 'Num. Documento fornitore',
			ED.docdate											as 'Data documento fornitore',
			E3.ymov												as 'Anno Liquidazione',
			E3.nmov												as 'Num. Liquidazione',
			E2.ymov												as 'Anno Impegno',
			E2.nmov												as 'Num. Impegno',
			E1.ymov												as 'Anno PreImpegno',
			E1.nmov												as 'Num. PreImpegno',
			fin.codefin											as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepexp,
			ID.idexp_taxable
	from #lunghezze L
	JOIN entrydetailview ED ON L.yentry =ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
	JOIN invoicekind ON invoicekind.idinvkind = CONVERT(int, substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1))
	JOIN invoicedetail ID ON ID.idinvkind = CONVERT(int, substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) )
			AND ID.yinv = CONVERT(int, substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1))
			AND ID.ninv = CONVERT(int, substring(ED.idrelateddetail,Pos3+1,Pos4-Pos3-1) )
			AND ID.rownum = CONVERT(int, substring(ED.idrelateddetail,Pos4+1,LEN(ED.idrelateddetail)))
	LEFT OUTER JOIN expense E3 ON E3.idexp = ID.idexp_taxable
	LEFT OUTER JOIN expenseyear EY3 ON EY3.idexp = E3.idexp AND EY3.ayear = @ayear
	LEFT OUTER JOIN fin ON fin.idfin = EY3.idfin
	LEFT OUTER JOIN expense E2 ON E3.parentidexp = E2.idexp
	LEFT OUTER JOIN expense E1 ON E2.parentidexp = E1.idexp
		WHERE (invoicekind.flag & 1) = 0
	INSERT INTO #Scritture
	SELECT  (SELECT distinct TipoDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)	as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			(SELECT distinct EsDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp  and #Scritture.idepexp is not null)	as 'Esercizio documento', 
			(SELECT MIN(NumDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp  and #Scritture.idepexp is not null)		as 'Num. documento',  
			(SELECT MIN(RigaDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp  and #Scritture.idepexp is not null)		as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount, 
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			(SELECT MIN(NumDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)		as 'Num. Documento fornitore',
			(SELECT MIN(DataDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)		as 'Data documento fornitore',
			(SELECT MIN(AnnoLiq) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Anno Liquidazione',
			(SELECT MIN(NumLiq) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Num. Liquidazione',
			(SELECT MIN(AnnoImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Anno Impegno',
			(SELECT MIN(NumImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Num. Impegno',
			(SELECT MIN(AnnoPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Anno PreImpegno',
			(SELECT MIN(NumPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Num. PreImpegno',
			(SELECT MIN(VoceBil) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepexp, 
			--SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',ED.idrelateddetail)-2) 
			SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1) 
	from  entrydetailview ED -- ON ED.idepexp = #Scritture.idepexp and ED.amount =  -#Scritture.amount--and ED.codeacc = #Scritture.CodConto and ED.amount =  -#Scritture.amount
	LEFT OUTER JOIN EXPENSE E3 ON E3.idexp = SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1)  
	WHERE (ED.idrelateddetail like 'expense%' OR ED.idrelateddetail  is null)
	AND ED.idepexp IN (SELECT distinct idepexp from #Scritture Where idepexp is not null)

	SELECT  TipoDoc as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			EsDoc as 'Esercizio documento', 
			NumDoc as 'Num. documento',  
			RigaDoc as 'Riga documento' ,
			UpbDoc  as 'UPB scrittura',
			CodConto as 'Codice Conto',
			DesConto as 'Denominazione Conto',
			Dare as 'Dare',
			Avere as 'Avere',
			NumDocForn as 'Num. Documento fornitore',
			DataDocForn as 'Data documento fornitore',
			AnnoLiq as 'Anno Liquidazione',
			NumLiq as 'Num. Liquidazione',
			AnnoImp as 'Anno Impegno',
			NumImp as 'Num. Impegno',
			AnnoPre as 'Anno PreImpegno',
			NumPre as 'Num. PreImpegno',
			VoceBil as 'Voce finanziaria',
			idrelateddetail ,
			idepexp
	from #Scritture
	Where idepexp is not null
	ORDER BY idepexp, SUBSTRING( #Scritture.idrelateddetail,1,2) DESC, CodConto
END
----- Contratti Passivi
IF @tipo = 'M'
	BEGIN
	INSERT INTO #Lunghezze
	select  yentry,nentry,ndetail,idrelateddetail, 
	CHARINDEX('§',idrelateddetail) as Pos1,  
	CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)  as Pos2,
	CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)+1 ) as Pos3,
	CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)+1 )  +1) as Pos4,
	idepexp, idacc, CONVERT( decimal(19,2),amount)
	from entrydetailview
	where idrelateddetail like 'man%' and yentry = @ayear ;
	Print 'Insert scritture'
	INSERT INTO #Scritture
	select mandatekind.description								as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1)	as 'Esercizio documento', 
			substring(ED.idrelateddetail,Pos3+1,Pos4-Pos3-1)	as 'Num. documento',  
			substring(ED.idrelateddetail,Pos4+1,LEN(ED.idrelateddetail))			as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount ,
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.doc												as 'Num. Documento fornitore',
			ED.docdate											as 'Data documento fornitore',
			NULL												as 'Anno Liquidazione',
			NULL												as 'Num. Liquidazione',
			E2.ymov												as 'Anno Impegno',
			E2.nmov												as 'Num. Impegno',
			E1.ymov												as 'Anno PreImpegno',
			E1.nmov												as 'Num. PreImpegno',
			fin.codefin											as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepexp,
			ID.idexp_taxable
	from #lunghezze L
	JOIN entrydetailview ED ON L.yentry =ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
	JOIN mandatekind ON mandatekind.idmankind = CONVERT(varchar(50), substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1))
	JOIN mandatedetail ID ON ID.idmankind = CONVERT(varchar(50), substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) )
			AND ID.yman = CONVERT(int, substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1))
			AND ID.nman = CONVERT(int, substring(ED.idrelateddetail,Pos3+1,Pos4-Pos3-1) )
			AND ID.rownum = CONVERT(int, substring(ED.idrelateddetail,Pos4+1,LEN(ED.idrelateddetail)))
	LEFT OUTER JOIN expense E2 ON E2.idexp = ID.idexp_taxable
	LEFT OUTER JOIN expenseyear EY2 ON EY2.idexp = E2.idexp AND EY2.ayear = @ayear
	LEFT OUTER JOIN fin ON fin.idfin = EY2.idfin
	LEFT OUTER JOIN expense E1 ON E2.parentidexp = E1.idexp
	WHERE mandatekind.linktoinvoice = 'N'

	INSERT INTO #Scritture
	SELECT  (SELECT distinct TipoDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)	as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			(SELECT distinct EsDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp  and #Scritture.idepexp is not null)	as 'Esercizio documento', 
			(SELECT MIN(NumDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp  and #Scritture.idepexp is not null)		as 'Num. documento',  
			(SELECT MIN(RigaDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp  and #Scritture.idepexp is not null)		as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount, 
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			(SELECT MIN(NumDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)		as 'Num. Documento fornitore',
			(SELECT MIN(DataDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)		as 'Data documento fornitore',
			E3.ymov			as 'Anno Liquidazione',
			E3.nmov			as 'Num. Liquidazione',
			(SELECT MIN(AnnoImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Anno Impegno',
			(SELECT MIN(NumImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Num. Impegno',
			(SELECT MIN(AnnoPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Anno PreImpegno',
			(SELECT MIN(NumPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Num. PreImpegno',
			(SELECT MIN(VoceBil) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepexp, 
			--SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',ED.idrelateddetail)-2) 
			SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1) 
	from  entrydetailview ED -- ON ED.idepexp = #Scritture.idepexp and ED.amount =  -#Scritture.amount--and ED.codeacc = #Scritture.CodConto and ED.amount =  -#Scritture.amount
	LEFT OUTER JOIN expense E3 ON E3.idexp = SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1)  
	WHERE (ED.idrelateddetail like 'expense%' OR ED.idrelateddetail  is null)
	AND ED.idepexp IN (SELECT distinct idepexp from #Scritture Where idepexp is not null)

	SELECT  TipoDoc as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			EsDoc as 'Esercizio documento', 
			NumDoc as 'Num. documento',  
			RigaDoc as 'Riga documento' ,
			UpbDoc  as 'UPB scrittura',
			CodConto as 'Codice Conto',
			DesConto as 'Denominazione Conto',
			Dare as 'Dare',
			Avere as 'Avere',
			NumDocForn as 'Num. Documento fornitore',
			DataDocForn as 'Data documento fornitore',
			AnnoLiq as 'Anno Incasso',
			NumLiq as 'Num. Incasso',
			AnnoImp as 'Anno Accertamento',
			NumImp as 'Num. Accertamento',
			AnnoPre as 'Anno Pre Accertamento',
			NumPre as 'Num. Pre Accertamento',
			VoceBil as 'Voce finanziaria',
			idrelateddetail ,
			idepexp as idapAcc
	from #Scritture
	Where idepexp is not null
	ORDER BY idepexp, SUBSTRING( #Scritture.idrelateddetail,1,3) desc, CodConto asc
END
----- Contratti Occasionali
IF @tipo = 'C'
	BEGIN
	INSERT INTO #Lunghezze
	select  yentry,nentry,ndetail,idrelateddetail, 
	CHARINDEX('§',idrelateddetail) as Pos1,  
	CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)  as Pos2,
	CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)+1 ) as Pos3,
	CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail, CHARINDEX('§',idrelateddetail,CHARINDEX('§',idrelateddetail) +1)+1 )  +1) as Pos4,
	idepexp, idacc, CONVERT( decimal(19,2),amount)
	from entrydetailview
	where idrelateddetail like 'cascon%' and yentry = @ayear ;
	Print 'Insert scritture'
	INSERT INTO #Scritture
	select 'Parcella Occasionale'								as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1)	as 'Esercizio documento', 
			substring(ED.idrelateddetail,Pos2+1,LEN(ED.idrelateddetail))	as 'Num. documento',  
			NULL			as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount ,
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.doc												as 'Num. Documento fornitore',
			ED.docdate											as 'Data documento fornitore',
			NULL												as 'Anno Liquidazione',
			NULL												as 'Num. Liquidazione',
			E2.ymov												as 'Anno Impegno',
			E2.nmov												as 'Num. Impegno',
			E1.ymov												as 'Anno PreImpegno',
			E1.nmov												as 'Num. PreImpegno',
			fin.codefin											as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepexp,
			IDE.idexp
	from #lunghezze L
	JOIN entrydetailview ED ON L.yentry =ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
	JOIN casualcontract ID ON  ID.ycon =substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1)
			AND ID.ncon = substring(ED.idrelateddetail,Pos2+1,LEN(ED.idrelateddetail))
	LEFT OUTER JOIN expensecasualcontract IDE ON IDE.ycon = ID.ycon and IDE.ncon = ID.ncon
	LEFT OUTER JOIN expense E2 ON E2.idexp = IDE.idexp
	LEFT OUTER JOIN expenseyear EY2 ON EY2.idexp = E2.idexp 
	LEFT OUTER JOIN fin ON fin.idfin = EY2.idfin
	LEFT OUTER JOIN expense E1 ON E2.parentidexp = E1.idexp
	WHERE EY2.ayear = @ayear
	AND POS3 = 0
	INSERT INTO #Scritture
	select 'Parcella Occasionale'								as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1)	as 'Esercizio documento', 
			substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1)	as 'Num. documento',  
			NULL			as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount ,
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			ED.doc												as 'Num. Documento fornitore',
			ED.docdate											as 'Data documento fornitore',
			NULL												as 'Anno Liquidazione',
			NULL												as 'Num. Liquidazione',
			E2.ymov												as 'Anno Impegno',
			E2.nmov												as 'Num. Impegno',
			E1.ymov												as 'Anno PreImpegno',
			E1.nmov												as 'Num. PreImpegno',
			fin.codefin											as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepexp,
			IDE.idexp
	from #lunghezze L
	JOIN entrydetailview ED ON L.yentry =ED.yentry AND L.nentry = ED.nentry AND L.ndetail = ED.ndetail
	JOIN casualcontract ID ON  ID.ycon =substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1)
			AND ID.ncon = substring(ED.idrelateddetail,Pos2+1,Pos3-Pos2-1)
	LEFT OUTER JOIN expensecasualcontract IDE ON IDE.ycon = ID.ycon and IDE.ncon = ID.ncon
	LEFT OUTER JOIN expense E2 ON E2.idexp = IDE.idexp
	LEFT OUTER JOIN expenseyear EY2 ON EY2.idexp = E2.idexp 
	LEFT OUTER JOIN fin ON fin.idfin = EY2.idfin
	LEFT OUTER JOIN expense E1 ON E2.parentidexp = E1.idexp
	WHERE EY2.ayear = @ayear
	AND pos3 > 0
	INSERT INTO #Scritture
	SELECT  'Parcella Occasionale'	as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			(SELECT distinct EsDoc FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp  and #Scritture.idepexp is not null)	as 'Esercizio documento', 
			(SELECT MIN(NumDoc) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp  and #Scritture.idepexp is not null)		as 'Num. documento',  
			NULL		as 'Riga documento' ,
			ED.codeupb											as 'UPB scrittura',
			ED.codeacc											as 'Codice Conto',
			ED.account											as 'Denominazione Conto',
			ED.amount, 
			ED.give												as 'Dare',
			ED.have												as 'Avere',
			(SELECT MIN(NumDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)		as 'Num. Documento fornitore',
			(SELECT MIN(DataDocForn) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)		as 'Data documento fornitore',
			E3.ymov			as 'Anno Liquidazione',
			E3.nmov			as 'Num. Liquidazione',
			(SELECT MIN(AnnoImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Anno Impegno',
			(SELECT MIN(NumImp) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Num. Impegno',
			(SELECT MIN(AnnoPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Anno PreImpegno',
			(SELECT MIN(NumPre) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Num. PreImpegno',
			(SELECT MIN(VoceBil) FROM #Scritture WHERE #Scritture.idepexp= ED.idepexp and #Scritture.idepexp is not null)			as 'Voce finanziaria',
			ED.idrelateddetail ,
			ED.idepexp, 
			--SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',ED.idrelateddetail)-2) 
			SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1) 
	from  entrydetailview ED -- ON ED.idepexp = #Scritture.idepexp and ED.amount =  -#Scritture.amount--and ED.codeacc = #Scritture.CodConto and ED.amount =  -#Scritture.amount
	LEFT OUTER JOIN expense E3 ON E3.idexp = SUBSTRING(SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)),1, CHARINDEX('§',SUBSTRING(ED.idrelateddetail, 9,LEN(ED.idrelateddetail)))-1)  
	WHERE (ED.idrelateddetail like 'expense%' OR ED.idrelateddetail  is null)
	AND ED.idepexp IN (SELECT distinct idepexp from #Scritture Where idepexp is not null)

	SELECT  TipoDoc as 'Tipo documento', --substring(ED.idrelateddetail,Pos1+1,Pos2-Pos1-1) as idinvkind, 
			EsDoc as 'Esercizio documento', 
			NumDoc as 'Num. documento',  
			RigaDoc as 'Riga documento' ,
			UpbDoc  as 'UPB scrittura',
			CodConto as 'Codice Conto',
			DesConto as 'Denominazione Conto',
			Dare as 'Dare',
			Avere as 'Avere',
			NumDocForn as 'Num. Documento fornitore',
			DataDocForn as 'Data documento fornitore',
			AnnoLiq as 'Anno Liquidazione',
			NumLiq as 'Num. Liquidazione',
			AnnoImp as 'Anno Impegno',
			NumImp as 'Num. Impegno',
			AnnoPre as 'Anno Pre Impegno',
			NumPre as 'Num. Pre Impegno',
			VoceBil as 'Voce finanziaria',
			idrelateddetail ,
			idepexp as idapAcc
	from #Scritture
	Where idepexp is not null
	ORDER BY 2,3, idepexp, SUBSTRING( #Scritture.idrelateddetail,1,3) asc, CodConto asc
END



	DROP TABLE #Lunghezze
	DROP TABLE #Scritture
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

