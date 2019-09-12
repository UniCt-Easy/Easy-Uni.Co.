if exists (select * from dbo.sysobjects where id = object_id(N'[exp_azzeramento_consistenza_finale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_azzeramento_consistenza_finale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 --  exec [exp_azzeramento_consistenza_finale] 2

CREATE  PROCEDURE [exp_azzeramento_consistenza_finale]
(
	@idinv 	int = null
)
AS
BEGIN

DECLARE @inventorytree varchar(150)
DECLARE @inventoryagency varchar(150)
DECLARE @codeinv varchar(50)
DECLARE	@nlevel tinyint

SELECT @codeinv = codeinv, @inventorytree = description, @nlevel = nlevel
FROM inventorytree WHERE idinv = @idinv
 

DECLARE	@departmentname varchar(150)
SET  @departmentname = ISNULL( (SELECT  department from license),'Manca Cfg. Parametri Tutte le stampe')

 

--iddbdepartment, idinv, codeinv, inventorytree, idinv_1, codeinv_1, inventory_tree_1, totalassetunload, totalaamountvaraum, totalaamountvardim
 	--select * from inventorytree
CREATE TABLE #assettotal 
( 
	idinv int,
	level varchar(50),
	assetunload decimal(19,2),
	assetload decimal(19,2),
	amountvaraum decimal(19,2),
	amountvardim decimal(19,2)
)

--select * from #assettotal
----- Estraggo i dettagli variazioni

INSERT INTO  #assettotal
(idinv, 
amountvaraum 
)
SELECT IT.idinv, SUM(assetvardetailview.amount) 
FROM assetvardetailview
JOIN inventorytree IT ON IT.idinv = assetvardetailview.idinv
WHERE assetvardetailview.variationdescription = 'Variazione di azzeramento consistenza'
AND assetvardetailview.yvar = '2013'
AND isnull(assetvardetailview.amount,0) >0
and (IT.codeinv like (@codeinv + '%') OR @codeinv IS NULL)
GROUP BY IT.idinv 
  
 INSERT INTO  #assettotal
(idinv, 
 amountvardim
)
 SELECT IT.idinv,SUM(assetvardetailview.amount) 
FROM assetvardetailview
JOIN inventorytree IT ON IT.idinv = assetvardetailview.idinv
WHERE assetvardetailview.variationdescription = 'Variazione di azzeramento consistenza'
AND assetvardetailview.yvar = '2013'
AND isnull(assetvardetailview.amount,0) < 0
and (IT.codeinv like (@codeinv + '%') OR @codeinv IS NULL)
GROUP BY IT.idinv

----- Estraggo gli scarichi totali
 INSERT INTO  #assettotal
(idinv, 
assetunload
)
SELECT IT.idinv, SUM(AC.currentvalue) 
FROM assetview_current AC
join assetview A  ON  A.idasset = AC.idasset and A.idpiece = AC.idpiece
join assetunload AU ON  AU.idassetunload = A.idassetunload 
join inventory I ON  I.idinventory = A.idinventory 
JOIN inventorytree IT ON IT.idinv = A.idinv
WHERE AU.description = 'Consolidamento patrimonio'
AND AU.cu = 'scaricatutto'
AND year(AU.adate) = 2013
and (IT.codeinv like (@codeinv + '%') OR @codeinv IS NULL)
 GROUP BY IT.idinv
 
----- Estraggo gli carichi totali
 INSERT INTO  #assettotal
(idinv, 
assetload
)
SELECT IT.idinv, SUM(AC.start) 
FROM assetview_current AC
join assetview A  ON  A.idasset = AC.idasset and A.idpiece = AC.idpiece
join assetload AU ON  AU.idassetload = A.idassetload 
join inventory I ON  I.idinventory = A.idinventory 
JOIN inventorytree IT ON IT.idinv = A.idinv
WHERE AU.description = 'Trasferimento iniziale'
AND AU.cu = 'importazione'
and (IT.codeinv like (@codeinv + '%') OR @codeinv IS NULL)
GROUP BY IT.idinv

 
  
--select * from #assettotal
 
SELECT   
@departmentname as 'Dipartimento',
I.codeinv as 'Cod. Class. Inv.',
I.description as 'Class. Inv.',
IL.nlevel as 'Livello',
I_1.codeinv as 'Cod. Categoria Liv.1',
I_1.description as 'Categoria Liv. 1',
isnull(sum(assetload),0) as 'Tot. Carichi',
isnull(sum(assetunload),0) as 'Tot. Scarichi',
isnull(sum(amountvaraum),0) as 'Tot. Var. Azzeramento (Aum)',
-isnull(sum(amountvardim),0) as ' Tot. Var. Azzeramento (Dim)'
FROM #assettotal A
JOIN inventorytree I
ON A.idinv= I.idinv
JOIN inventorysortinglevel IL ON I.nlevel = IL.nlevel
JOIN inventorytreelink L
		ON L.idchild = I.idinv
		AND L.nlevel = 1
JOIN inventorytree I_1
ON  I_1.idinv= L.idparent
GROUP BY I.codeinv  ,
I.description ,
I_1.codeinv,
I_1.description  , IL.nlevel
order by I.codeinv
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

