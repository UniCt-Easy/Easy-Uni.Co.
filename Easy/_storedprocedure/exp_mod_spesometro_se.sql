if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_spesometro_SE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_spesometro_SE]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_mod_spesometro_SE](
@ayear int,
@month int
)
AS BEGIN
-- Compiliamo SOLO il quadro SE, ossia quello relativo agli acquisti da San Marino.
-- Inseriamo le Fatture da considerare.
create table #fatture (ninv int, idinvkind int)
insert into #fatture(
	ninv, 
	idinvkind
)
select distinct I.ninv, I.idinvkind 
from invoiceview I
join invoicedetail ID
	ON I.yinv = ID.yinv
	AND I.ninv = ID.ninv
	AND I.idinvkind = ID.idinvkind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
JOIN registryaddress RA
	ON I.idreg = RA.idreg
JOIN address A
	ON RA.idaddresskind = A.idaddress
where YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	and isnull(I.flagintracom,'N')<>'S'
	AND isnull(RA.idnation,0) = 48	 -- SOLO San Marino
	AND month(isnull(I.docdate,I.adate))=@month
	and isnull(IRK.compensation,'N') ='N' -- Esclude i registri Corrispettivi
	AND IRK.flagactivity <> 1 -- esclude i registri istituzionali

-- RECORD "D"
CREATE TABLE #REC_D(
	idreg int,
	ProgressivoModulo int, -- Impostare ad 1 per il primo modulo di ogni quadro compilato, incrementando tale valore di una unità per ogni ulteriore modulo
-->> QUADRO SE - Acquisti da operatori di San Marino
	SE001012_dataemissionefattura datetime,
	SE001013_dataregistrazionefattura datetime,--la data deve essere inclusa nell'anno di riferimento
	SE001014_numfattura varchar(35),
	SE001015_imponibile int,
	SE001016_imposta  int,
	SE001017_confermaimporto int-- dato obbligatorio se l'importo è maggiore di 999999
)
-- Acquisti
INSERT INTO #REC_D(
	idreg,
	SE001012_dataemissionefattura,
	SE001013_dataregistrazionefattura,
	SE001014_numfattura,
	SE001015_imponibile,
	SE001016_imposta,
	SE001017_confermaimporto
)
SELECT 
	I.idreg,
	isnull(I.docdate, I.adate), -- Inseriamo la data del documento, se null, mettiamo la data di registrazione. CONTROLLARE!!!
	I.adate,
	I.doc,
	ISNULL(ROUND(SUM(ID.taxable_euro),0),0),
	ISNULL(ROUND(SUM(ID.iva_euro),0),0),
	0
FROM invoice I
JOIN invoicedetailview ID
	ON I.idinvkind = ID.idinvkind
	AND I.yinv = ID.yinv
	AND I.ninv = ID.ninv
 JOIN ivakind IVK 
	ON  IVK.idivakind = ID.idivakind
JOIN ivataxablekind IVTK
	ON IVTK.idivataxablekind = IVK.idivataxablekind
JOIN invoicekind IK
	ON IK.idinvkind = I.idinvkind
WHERE YEAR(I.adate) = @ayear
	and isnull(ID.usedmodesospesometro,'F')='F' -- F : non escludere
	AND ((IK.flag&4)=0)		-- variation = N
	AND ((IK.flag&1)=0) -- A
	AND I.ninv in (select F.ninv from #fatture F where F.idinvkind = I.idinvkind)
	AND IVTK.idivataxablekind <>5  -- esclude le aliquote Fuori Campo
group by I.idreg, isnull(I.docdate, I.adate), I.adate,	I.doc
	
UPDATE #REC_D SET SE001017_confermaimporto = 1 WHERE SE001015_imponibile>=999999

SELECT 
	idreg,
	SE001012_dataemissionefattura,
	SE001013_dataregistrazionefattura,
	SE001014_numfattura,
	sum(SE001015_imponibile) as  SE001015_imponibile,
	sum(SE001016_imposta) as SE001016_imposta,
	SE001017_confermaimporto
FROM #REC_D
GROUP BY idreg, SE001012_dataemissionefattura,SE001013_dataregistrazionefattura, SE001014_numfattura, SE001017_confermaimporto

DROP TABLE #fatture
DROP TABLE #REC_D
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

