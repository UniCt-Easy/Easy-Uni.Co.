
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


IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_inventario]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_inventario
END

CREATE TABLE lookup_inventario (
	codiceente varchar(20),
	descrizioneente varchar(150),	
	codiceinventario varchar(20),
	descrizioneinventario varchar(100), --va troncata a 50 però
	tipo_LIB_ORD varchar(3),
	id_inventario varchar(10) not null
)

/****** Object:  Index [PK_lookup_inventario]    Script Date: 18/12/2013 07.48.26 ******/
ALTER TABLE [dbo].[lookup_inventario] ADD  CONSTRAINT [PK_lookup_inventario] PRIMARY KEY CLUSTERED 
(
	[id_inventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

insert into lookup_inventario(codiceente, descrizioneente,codiceinventario , descrizioneinventario, id_inventario)
	select 	isnull(U.codeupb,I.id_inventario), coalesce(U.descrizione,I.descrizione,I.id_inventario), I.id_inventario, 
				isnull(I.descrizione,I.id_inventario), I.id_inventario		
	from ID_INVENTARIO I
		left outer join rel_uo_inventario ruo on ruo.id_inventario= I.ID_INVENTARIO and esercizio= 2013 /* ULTIMO ANNO USO CIA */
			AND (select count(*) from rel_uo_inventario A where A.ID_INVENTARIO= I.ID_INVENTARIO) =1
		left outer join lookup_upb U on ruo.unita_organizzativa  = U.chiave_completa 
			


/*
select * from ID_INVENTARIO I
	left outer join rel_uo_inventario ruo on ruo.id_inventario= I.ID_INVENTARIO and esercizio= 2013 /* ULTIMO ANNO USO CIA */
		--left outer join lookup_upb U on ruo.unita_organizzativa  = U.chiave_completa 
 where ruo.unita_organizzativa= 'A.AMMCE.SMFN'  --'A.AMMCE.SICS'

select * from ID_INVENTARIO I
	left outer join rel_uo_inventario ruo on ruo.id_inventario= I.ID_INVENTARIO and esercizio= 2013 /* ULTIMO ANNO USO CIA */
		--left outer join lookup_upb U on ruo.unita_organizzativa  = U.chiave_completa 
 where I.id_inventario= 'I0070307'
 */

-- INIZIO DELLA PARTE DIVERSA DA CLIENTE A CLIENTE
--sistema i codici degli inventari - 
-- in questo cliente i ID_INVENTARIO della tabella ID_INVENTARIO finiscono con MOB O BIBL
-- prendiamo quella parte per discriminare il tipo, e quallo che precede come CODICE ENTE 
/*
update lookup_inventario  set codiceente= SUBSTRING(id_inventario,1,len(id_inventario)-3) where id_inventario like '%MOB'
update lookup_inventario  set codiceente= SUBSTRING(id_inventario,1,len(id_inventario)-4) where id_inventario like '%BIBL'

update lookup_inventario  set codiceinventario=  id_inventario 
*/

update lookup_inventario  set tipo_LIB_ORD= 'ORD' where id_inventario like '%MOB'
update lookup_inventario  set tipo_LIB_ORD= 'LIB' where id_inventario like '%BIBL'






---- FINE DELLA PARTE DIVERSA DA CLIENTE A CLIENTE


--la descrizione dell'ente - libri deve essere uguale a quello dell'ordinario ove entrambi presenti
update lookup_inventario set descrizioneente=  I2.descrizioneente
from lookup_inventario 
	join lookup_inventario I2 ON  I2.codiceente= [lookup_inventario].codiceente and I2.tipo_LIB_ORD='ORD'
where [lookup_inventario].tipo_LIB_ORD='LIB'

--rende più previ le descr. per non sforare i 50 caratteri inutilmente
update lookup_inventario set descrizioneinventario= substring(REPLACE(descrizioneinventario,'dipartimento','Dip.') ,1,50)

GO



