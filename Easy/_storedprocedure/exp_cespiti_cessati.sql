
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_cespiti_cessati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_cespiti_cessati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exp_cespiti_cessati 'amm',null

/*
Il dipartimento di destinazione normalmente dovrebbe essere quello di lookup_inventory MA se c'è corrispondenza tra
 codice dip. e idmanager presenti in lookup_manager, il dipartimento di destinazione cambia

*/

CREATE       PROCEDURE [exp_cespiti_cessati](
@dep varchar(30) ,  --codice dipartimento di origine = owner di questo dipartimento, diventa l'ente inventariale della dest.
@datacarico datetime, 
@codeinventoryagency varchar(20) ='DEP'  -- codice dell'ente inventariale da considerare, di norma dovrebbe essere sempre DEP
)
AS BEGIN
	select 
		CASE when  AV.idpiece=1 then 'C' else 'A' END as tipocespite,  --Tipo Cespite (Cespite/Accessorio);Codificato;1;C|A",

		--  Codice inventario = @DEP-codeinventory 
		--	oppure DEPDEST-codeinventory1 2 3 etc.
		CASE when LKINV.codeinventory_dest is null then	@dep+'-'+I_S.codeinventory 
											 else   LKINV.dipdest+'-'+I_S.codeinventory  + convert(varchar(3),LKINV.num)	
				END as codiceinv,   --Codice Inventario;Stringa;20",  codicedip-lib/ord- num (per distinguere provenienza)

		-- descr.inventario  = @dep - descr.inventario
		-- oppure   DEPDEST - descri.inventario DA @dep
		CASE WHEN LKINV.codeinventory_dest is null AND I_S.codeinventory = 'ORD' then   @dep+'-'+ 'Ordinario'
			 WHEN     LKINV.codeinventory_dest is null AND I_S.codeinventory = 'LIB' then   @dep+'-'+ 'Libri'					
			 WHEN	  LKINV.codeinventory_dest is not null AND I_S.codeinventory = 'ORD' then   LKINV.dipdest+'-'+ 'Ordinario'  + ' da '+@dep
			 ELSE LKINV.dipdest+'-'+ 'Libri'  + ' da '+@dep						 
		END as descrinv ,   --Descrizione Inventario;Stringa;50"

	        CASE when I_S.codeinventory = 'ORD' then  'DEPMAIN'
			 else   'DEPBOOK'
        END as codeinvkind ,		   --;Codice Tipo Inventario;Stringa;20",
        CASE when I_S.codeinventory = 'ORD' then 'Inventario Libri'
			else  'Inventario Ordinario'
        END as descrinvkind ,		    --;Descr. Tipo Inventario;Stringa;50",
        
        CASE when LKINV.codeinventory_dest is null then	@dep 
												  else  LKINV.dipdest												
		END 	as codeinvagency,   -- Codice Ente Inventariale;Stringa;20",
        CASE when LKINV.codeinventory_dest is null then  @dep
												  else  LKINV.dipdest 
        END as descrinvagency ,		  --Descrizione Ente Inventariale;Stringa;150",
        AV.ninventory as  numinv,	 --	;Numero di inventario;Intero;8",
        AV.idpiece as  nprogr,		--;Numero progressivo. 1 per i cespiti, 2 o più per gli accessori;Intero;5",
		AV.lifestart as inizioesist,	--;Inizio esistenza;Data;8",
		AV.codeinv as codiceclass, --Codice classificazione inventariale;Stringa;20",
		AV.description as	descr, --;Descrizione Cespite;Stringa;150",
		AC.currentvalue as impon,		--;Imponibile;Numero;22",
		0 as iva,			--;Iva;Numero;22",
        0 as ivadetr,		--;Iva Detraibile;Numero;22",
        0 as ivaperc,		--Aliquota Iva;Numero;22",
        0 as scontoperc,	--;Percentuale Sconto;Numero;22",                
        AC.start as  valorestorico, --;Valore Storico;Numero;22",
        '07_BUY' as codicecausalecar, --Codice Causale di carico;Stringa;10",  
        'Carico' as descrcausalecar, --;Descrizione Causale di carico;Stringa;30",
        AQ.idreg as codicecedente,  --;Codice Cedente (di anagrafica);Intero;10",
        @datacarico as datacar, --;Data di Carico;Data;8", //era convert (datetime,'01-01-2013',105)
        'N' as posseduto, --;Posseduto(S/N);Codificato;1;S|N",
        'S' as includibuonocar, --;Da includere in buono di carico (S/N);Codificato;1;S|N",
		CASE when LKINV.codeinventory_dest is null then	@dep+'-'+I_S.codeinventory 
											 else   LKINV.dipdest+'-'+I_S.codeinventory  + convert(varchar(3),LKINV.num)	
				END as  codicetipobuonocar, ---;Codice tipo buono carico;Stringa;20", COME CODICE INVENTARIO
		year(@datacarico)as annobuonocar,		--;Anno buono carico;Intero;4", era 2013
        1 as numbuonocar,		--;Numero buono carico;Intero;8",
        isnull(LKMAN.newtitle,AV.currmanager) as resp, --;Responsabile;Stringa;150",
        LOC.newlocationcode as  codeubic, --;Codice ubicazione;Stringa;50",
        'S' as includibuonoscar, --;Da includere in buono di scarico (S/N);Codificato;1;S|N",
        null as codicetipobuonoscar, --;Codice tipo buono scarico;Stringa;20",
        null as annobuonoscar, --;Anno buono scarico;Intero;4",
        null as numbuonoscar, --;Numero buono scarico;Intero;8",
        AV.txt as  note  --;Note;Stringa;400"
	from assetview AV 
		join assetview_current AC on AV.idasset=AC.idasset and AV.idpiece=AC.idpiece
		join assetacquire AQ on AV.nassetacquire= AQ.nassetacquire
		join inventory I_S on AV.idinventory = I_S.idinventory	--inventario di origine
		join inventorykind IK_S on I_S.idinventorykind = IK_S.idinventorykind  --tipo inventario di origine
		join inventoryagency IA_S on IA_S.idinventoryagency = I_S.idinventoryagency  --ente inventariale di origine
		left outer join location LOC on LOC.idlocation = AV.idcurrlocation
		left outer join lookup_manager LKMAN on		LKMAN.diporigine=@dep 
												AND LKMAN.idmanager= AV.idcurrman 
		left outer join lookup_inventory LKINV ON	LKINV.diporigine= @dep 
												AND LKINV.idinventory_origine=I_S.idinventory
	where AV.is_loaded='S' and AV.is_unloaded='N'
				AND isnull(@codeinventoryagency,IA_S.codeinventoryagency)=IA_S.codeinventoryagency

				--se c'è un collegamento responsabile -> nuovo dipartimento allora dipdest deve essere quello
				--se invece non c'è allora va preso la riga LKINV con dipdest = null ossia che 
				and  (		(LKMAN.dipdest = LKINV.dipdest )
						or	(LKMAN.dipdest is null AND  LKINV.default_dest  = 'S')
					 )
			 --prende solo l'ente inventariale principale
	order by AV.idasset, AV.idpiece
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

