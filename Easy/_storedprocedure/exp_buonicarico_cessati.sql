
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_buonicarico_cessati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_buonicarico_cessati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exp_buonicarico_cessati 'amm',null


CREATE       PROCEDURE [exp_buonicarico_cessati](
@dep varchar(30) ,  --codice dipartimento di origine = owner di questo dipartimento, diventa l'ente inventariale della dest.
@codeinventoryagency varchar(20) ='DEP'  -- codice dell'ente inventariale da considerare, di norma dovrebbe essere sempre DEP
)
AS BEGIN
	select 
		CASE when LKINV.codeinventory_dest is null then	@dep+'-'+I_S.codeinventory 
											 else   LKINV.dipdest+'-'+I_S.codeinventory  + convert(varchar(3),LKINV.num)	
		END as  codtipobuonocar,   ---;Codice tipo buono carico;Stringa;20", COME CODICE INVENTARIO
		
		CASE  WHEN LKINV.codeinventory_dest is null AND I_S.codeinventory = 'ORD' then   @dep+'-'+ 'Ordinario'
			  WHEN LKINV.codeinventory_dest is null AND I_S.codeinventory = 'ORD_BIS' then   @dep+'-'+ 'Ordinario Bis'
			  WHEN     LKINV.codeinventory_dest is null AND I_S.codeinventory = 'LIB' then   @dep+'-'+ 'Libri'	
			  WHEN	  LKINV.codeinventory_dest is not null AND I_S.codeinventory = 'ORD' then   LKINV.dipdest+'-'+ 'Ordinario'  + ' da '+@dep
			  WHEN LKINV.codeinventory_dest is not null AND I_S.codeinventory = 'ORD_BIS' then   LKINV.dipdest+'-'+ 'Ordinario Bis' + ' da '+@dep
			  ELSE  LKINV.dipdest+'-'+ 'Libri'  + ' da '+@dep			
		END as  descrtipobuonocar,   ---;      ";Descr. tipo buono carico;Stringa;50",
		CASE	when LKINV.codeinventory_dest is null then	@dep+'-'+I_S.codeinventory 
											 else   LKINV.dipdest+'-'+I_S.codeinventory  + convert(varchar(3),LKINV.num)	
		END as codiceinv,   --Codice Inventario;Stringa;20",  codicedip-lib/ord- num (per distinguere provenienza)
		CASE WHEN LKINV.codeinventory_dest is null AND I_S.codeinventory = 'ORD' then   @dep+'-'+ 'Ordinario'
		WHEN LKINV.codeinventory_dest is null AND I_S.codeinventory = 'ORD_BIS' then   @dep+'-'+ 'Ordinario'
			 WHEN     LKINV.codeinventory_dest is null AND I_S.codeinventory = 'LIB' then   @dep+'-'+ 'Libri'					
			 WHEN	  LKINV.codeinventory_dest is not null AND I_S.codeinventory = 'ORD' then   LKINV.dipdest+'-'+ 'Ordinario'  + ' da '+@dep
			 WHEN	  LKINV.codeinventory_dest is not null AND I_S.codeinventory = 'ORD_BIS' then   LKINV.dipdest+'-'+ 'Ordinario Bis'  + ' da '+@dep
			 ELSE LKINV.dipdest+'-'+ 'Libri'  + ' da '+@dep						 
		END as descrinv ,   --Descrizione Inventario;Stringa;50"
	 
		  
        CASE when I_S.codeinventory = 'ORD' then  'DEPMAIN'
			 when I_S.codeinventory = 'ORD_BIS' then  'DEPMAIN'
			 else   'DEPBOOK'
        END as codeinvkind ,		   --;Codice Tipo Inventario;Stringa;20",
        CASE when I_S.codeinventory = 'ORD' then 'Inventario Ordinario'
         when I_S.codeinventory = 'ORD_BIS' then 'Inventario Ordinario'
			 else  'Inventario Libri'
        END as descrinvkind ,		    --;Descr. Tipo Inventario;Stringa;50",
        CASE when LKINV.codeinventory_dest is null then	@dep 
												  else  LKINV.dipdest												
		END 	as codeinvagency,   -- Codice Ente Inventariale;Stringa;20",
        CASE when LKINV.codeinventory_dest is null then  @dep+'-'+IA_S.description 
         else  LKINV.dipdest	
		END as descrinvagency, 		  --Descrizione Ente Inventariale;Stringa;150",
        2013 as annobuono,		--Anno buono carico;Intero;4",
        1	 as numbuono,		--;Numero buono carico;Intero;8",
        '07_BUY' as codicecausalecar, --Codice Causale di carico;Stringa;10",  
        'Carico' as descrcausalecar, --;Descrizione Causale di carico;Stringa;30",
        null as doc, --Documento buono carico;Stringa;35",
        null as datadoc, --;Data documento buono carico;Data;8",
        null as provv, --;Documento buono carico;Stringa;150",
        null as dataprovv, --;Data documento buono carico;Data;8",
        'Trasferimento iniziale' as descrizione, --;Descrizione buono carico;Stringa;150",
        convert (datetime,'01-01-2013',105)  as databuono, --;Data buono carico;Data;8",
        convert (datetime,'01-01-2013',105)  as datarat, --;Data ratifica buono carico;Data;8",
        null as cedente --;Codice cedente (di anagrafica);Intero;10"        		   	
	from INVENTORY I_S 
		JOIN assetloadkind ALK on I_S.idinventory= ALK.idinventory 
		join inventorykind IK_S on I_S.idinventorykind = IK_S.idinventorykind  --tipo inventario di origine
		join inventoryagency IA_S on IA_S.idinventoryagency = I_S.idinventoryagency  --ente inventariale di origine
		left outer join lookup_inventory LKINV ON LKINV.diporigine=@dep 
												AND LKINV.idinventory_origine=I_S.idinventory
	where exists(select * from assetview AV where AV.is_loaded='S' and AV.is_unloaded='N' and AV.idinventory= I_S.idinventory)
				AND isnull(@codeinventoryagency,IA_S.codeinventoryagency)=IA_S.codeinventoryagency			
			
				
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

