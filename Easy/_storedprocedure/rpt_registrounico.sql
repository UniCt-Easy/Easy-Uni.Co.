
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registrounico_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registrounico_new]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione'
-- exec rpt_registrounico_new 1, 543, null ,null ,null ,null ,null   

CREATE    PROCEDURE rpt_registrounico_new
	@nbegin int,
	@nend int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
AS
BEGIN

CREATE TABLE #registro
(
	iduniqueregister int ,				--	1)	Il codice progressivo di registrazione
	arrivalprotocolnum varchar(20),		--	2)  Il numero di protocollo di entrata
	doc varchar(35),					--  3)	Il numero della fattura o del documento contabile equivalente
	dataemissione datetime,				--4)	La data di emissione della fattura o del documento contabile equivalente
	dataricezione datetime,
	idreg int,							--5)	Il nome del creditore e il relativo codice fiscale
	description varchar(150),			--	6)	L’oggetto della fornitura
	amount decimal(19,2),				--	7)	L’importo totale, al lordo di IVA e di eventuali altri oneri e spese indicati
	scadenza datetime,					--8)	La scadenza della fattura
	impegno varchar(3000),				-- 	9)	Nel caso di enti in contabilità finanziaria, gli estremi dell’impegno indicato nella fattura o nel documento contabile equivalente oppure il capitolo 	e il piano gestionale, o analoghe unità gestionali del bilancio sul quale verrà effettuato il pagamento.
	rilevanteiva char(1),				--10)	Se la spesa è rilevante ai fini IVA
	cigcode varchar(200),				--11)	Il CIG tranne i casi di esclusione
	cupcode varchar(200),				--12)	Il CUP ove è previsto
	annotations varchar(400),				--	13)	Qualsiasi altra informazione che si ritiene necessaria.)
	idinvkind int,
	yinv smallint,
	ninv int,
	ycon smallint,
	ncon int,
	idmankind varchar(20),
	yman smallint,
	nman int,
	tipodocumento varchar(50)
	
)

-- Fattura
insert into #registro(
	idinvkind, yinv, ninv,
	iduniqueregister,
	arrivalprotocolnum,
	doc,
	dataemissione,
	dataricezione,
	idreg,
	description,
	amount,
	scadenza,
	rilevanteiva,
--	cupcode,
--	cigcode,
	annotations,
	tipodocumento
)
SELECT 
	I.idinvkind, I.yinv, I.ninv,
	U.iduniqueregister,
	I.arrivalprotocolnum,
	I.doc,
	I.docdate,	
	I.protocoldate,
	I.idreg,
	I.description,
	isnull(SDI_A.total,I.total) ,	-- ImportoTotaleDocumento, ora lo prendo dalla fatt.elettronica ove presente, vedi task 7360
	-- scadenza,
		case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
		when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
		-- Data documento = Numero gg  D.F.
		when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
		when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
		when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
		when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
		--	Pagamento Immediato  = data registrazione
		when I.idexpirationkind = 5 then I.adate
		-- Data ricezione
		when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
		when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
	else null
	end ,
	-- 	rilevanteiva : per le fatture interrogheremo l''attività del registro associata al documento, 
	-- se commerciale = è rilevante, 
	-- se istituzionale e di tipo intra/extra = rilevante, 
	-- se istituzionale e tipo Italia = non rilevante, 
	-- se promiscua = rilevante, perchè assimiliamo l''attività promiscua a quella commerciale.
	--I 1, C 2, P 3, Q 4
	case	when (IRK.flagactivity = 2) then 'S'
			when (IRK.flagactivity = 3) then 'S'
			when (IRK.flagactivity = 1 and flagintracom <> 'N')  then 'S'
			when (IRK.flagactivity = 1 and flagintracom = 'N') then 'N'
			else 'S'
	end,
--	cupcode,
--	cigcode,
	I.annotations,
	'Fattura'
FROM uniqueregister U
join invoiceview I					on U.idinvkind = I.idinvkind	and U.yinv = I.yinv	and U.ninv = I.ninv
JOIN invoicekind IK					ON I.idinvkind = IK.idinvkind
JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind	and IRK.registerclass = 'A'
left outer join sdi_acquisto SDI_A	on SDI_A.idsdi_acquisto = I.idsdi_acquisto
where U.iduniqueregister between @nbegin and @nend 
	AND (I.idsor01 = @idsor01 OR @idsor01 IS NULL)
	AND (I.idsor02 = @idsor02 OR @idsor02 IS NULL)
	AND (I.idsor03 = @idsor03 OR @idsor03 IS NULL)
	AND (I.idsor04 = @idsor04 OR @idsor04 IS NULL)
	AND (I.idsor05 = @idsor05 OR @idsor05 IS NULL)



-- In questa tabella saranno scritte le indo della Fattura + impegno + CIG e CUP. Poi tramite la tabella @TabInfoConcat le info di Impegni / CIG e CUP verranno concatenti 
declare @TabInfoInvoice table   (idinvkind int, yinv smallint, ninv int, idexp int, idexp_iva int, cupcode varchar(15), cigcode varchar(10) , impegno varchar(2000))

-- IMPEGNI letti da dettagli contratto passivo
-- CUP: letto dal dettaglio contratto passivo
-- CIG: letto dal dettaglio contratto passivo
--------------------------------------------------------------------------- Fatture associate a Contratto Passivo -------------------------------------------------
;WITH t1(idinvkind, yinv, ninv, idexp, cupcode, cigcode)
as
(SELECT	distinct ID.idinvkind, ID.yinv, ID.ninv, 
			case	when (MD.idexp_iva = MD.idexp_taxable) then MD.idexp_taxable
					when (MD.idexp_taxable is not null  and  MD.idexp_taxable <> isnull(MD.idexp_iva,'') ) then MD.idexp_taxable
					when (MD.idexp_iva IS NOT NULL and  MD.idexp_iva <> isnull(MD.idexp_taxable,'') ) then MD.idexp_iva
			end, 
		MD.cupcode,  isnull(MD.cigcode, M.cigcode)
	from  #registro R 
	join invoicedetail ID 	(nolock)		on ID.idinvkind = R.idinvkind and ID.yinv = R.yinv and ID.ninv = R.ninv
	join mandatedetail MD	(nolock)			on ID.idmankind = MD.idmankind and ID.yman = MD.yman and ID.nman = MD.nman and ID.manrownum = MD.rownum
	join mandate M			on ID.idmankind = M.idmankind	and ID.yman = M.yman	and ID.nman = M.nman
	where  ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			 and (isnull(ID.flagbit,0) & 4) = 0
)
insert into @TabInfoInvoice(idinvkind , yinv , ninv , idexp, cupcode, cigcode, impegno)
select t1.idinvkind, t1.yinv, t1.ninv, 
	E.idexp,
	t1.cupcode, 
	t1.cigcode,  
	'Es.'+convert(varchar(10),E.ymov) + ' N.'+convert(varchar(20),E.nmov)+'. '
from t1
join expense E
	on t1.idexp = E.idexp


--------------------------------------------------------------------------- Fatture NON associate a Contratto Passivo -------------------------------------------------
declare @finphase tinyint
SET @finphase = (SELECT top 1 expensephase
FROM config
order by ayear desc)

-- Impegni letti dalla contabilizzazione di Contratti Professionali o senza professionale
-- CUP: letto dall'impegno
-- CIG: letto dall'impegno

;WITH t2(idinvkind, yinv, ninv, idexp, cupcode, cigcode)
as
	(SELECT distinct ID.idinvkind, ID.yinv, ID.ninv,
			EI.idexp, 
			isnull(E.cupcode, ID.cupcode), isnull(E.cigcode,ID.cigcode)
		from  #registro R 
		join invoicedetail ID		on ID.idinvkind = R.idinvkind and ID.yinv = R.yinv and ID.ninv = R.ninv
		JOIN expenseinvoice EI			ON   EI.idinvkind = R.idinvkind and	 EI.yinv = R.yinv and	 EI.ninv = R.ninv
		JOIN expenselink				ON expenselink.idchild = EI.idexp
		JOIN expense E					on expenselink.idparent = E.idexp and E.nphase = @finphase
		Where ID.idmankind is null-------------->>> NON COLLEGATE A CP. Prende le fatture indipendentemente dall'associazione con la parcella. IMPORTANTE!!!
 		AND ISNULL(ID.rounding,'N') <>'S'  
		 and (isnull(ID.flagbit,0) & 4) = 0
		 )
insert into @TabInfoInvoice(idinvkind , yinv , ninv , idexp, cupcode, cigcode, impegno)
select t2.idinvkind, t2.yinv, t2.ninv, 
	E.idexp,
	t2.cupcode, 
	t2.cigcode,  
	'Es.'+convert(varchar(10),E.ymov) + ' N.'+convert(varchar(20),E.nmov)+'. '
from t2
join expense E
	on t2.idexp = E.idexp

-- CUP: letto dal dett. fattura
-- CIG: letto dal dett. fattura
-- Praticamente inserisce CUP e CIG delle fatture non contabilizzare
	insert into @TabInfoInvoice(idinvkind , yinv , ninv ,  idexp, cupcode, cigcode)
	SELECT distinct ID.idinvkind, ID.yinv, ID.ninv,
			null,
			ID.cupcode, ID.cigcode
		from  #registro R 
		join invoicedetail ID		on ID.idinvkind = R.idinvkind and ID.yinv = R.yinv and ID.ninv = R.ninv
		Where ID.idmankind is null-------------->>> NON COLLEGATE A CP. Prende le fatture indipendentemente dall'associazione con la parcella. IMPORTANTE!!!
 		AND ISNULL(ID.rounding,'N') <>'S'  
		 and (isnull(ID.flagbit,0) & 4) = 0
		 and not exists(select * from #registro P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )


declare @TabInfoConcat table  (idinvkind int, yinv smallint, ninv int, 
							idmankind varchar(20),yman smallint, nman int, 
							ycon smallint,	ncon int,
							idexp int,  cupcode varchar(100), cigcode varchar(100), impegni varchar(1000) )

-- In	@TabInfoConcat concateno le info di Impegno / CIG / CUP della Fattura
INSERT INTO  @TabInfoConcat(idinvkind, yinv, ninv, impegni, cupcode, cigcode)
SELECT distinct Tinv.idinvkind , Tinv.yinv , Tinv.ninv,
    SUBSTRING(
        (SELECT ', ' + impegno
            FROM @TabInfoInvoice Tinv2
            WHERE Tinv.idinvkind = Tinv2.idinvkind and Tinv.yinv = Tinv2.yinv and Tinv.ninv = Tinv2.ninv
            FOR XML PATH ('')
        )
    , 3, 1000) Impegni,
    SUBSTRING(
        (SELECT ', ' + cupcode
            FROM @TabInfoInvoice Tinv2
            WHERE Tinv.idinvkind = Tinv2.idinvkind and Tinv.yinv = Tinv2.yinv and Tinv.ninv = Tinv2.ninv
			group by cupcode
            FOR XML PATH ('')
        )
    , 3, 1000) cupcode,
	    SUBSTRING(
        (SELECT ', ' + cigcode
            FROM @TabInfoInvoice Tinv2
            WHERE Tinv.idinvkind = Tinv2.idinvkind and Tinv.yinv = Tinv2.yinv and Tinv.ninv = Tinv2.ninv
			group by cigcode
            FOR XML PATH ('')
        )
    , 3, 1000) cigcode
  FROM @TabInfoInvoice Tinv
  

-- Contratto Passivo NON collegabile a Fattura
insert into #registro(
	idmankind, yman, nman,
	iduniqueregister,
	arrivalprotocolnum,
	doc,
	dataemissione,
	dataricezione,
	idreg,
	description,
	amount,
	scadenza,
	rilevanteiva,
	--cigcode,
	annotations,
	tipodocumento
)
SELECT 
	M.idmankind, M.yman, M.nman,
	U.iduniqueregister,
	M.arrivalprotocolnum,
	M.doc,
	M.docdate,
	M.arrivaldate,
	M.idreg,
	M.description,
	M.total,
	-- scadenza,
		case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when (M.idexpirationkind = 1 AND isnull(M.paymentexpiring,0)>0) then DATEADD(day, M.paymentexpiring, M.adate)
		when (M.idexpirationkind = 1 AND isnull(M.paymentexpiring,0)=0) then M.adate
		-- Data documento = Numero gg  D.F.
		when (M.idexpirationkind = 2 AND M.docdate is not null AND isnull(M.paymentexpiring,0)>0) then DATEADD(day, M.paymentexpiring, M.docdate)
		when (M.idexpirationkind = 2 AND isnull(M.paymentexpiring,0)=0) then M.docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when (M.idexpirationkind = 3 AND M.docdate is not null and isnull(M.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(M.docdate) ,M.docdate))) ) 
		when (M.idexpirationkind = 3 AND M.docdate is not null and isnull(M.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(M.docdate) ,M.docdate)))
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when (M.idexpirationkind = 4  and isnull(M.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(M.adate) ,M.adate))) )
		when (M.idexpirationkind = 4  and isnull(M.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(M.adate) ,M.adate)))
		--	Pagamento Immediato  = data registrazione
		when M.idexpirationkind = 5 then M.adate
		-- Data ricezione
		when (M.idexpirationkind = 6 AND M.arrivaldate is not null AND isnull(M.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, M.arrivaldate)
		when (M.idexpirationkind = 6 AND isnull(M.paymentexpiring,0)=0) then M.arrivaldate

	else null
	end ,
	-- 	rilevanteiva : per le fatture interrogheremo l''attività del registro associata al documento, 
	-- se commerciale = è rilevante, 
	-- se istituzionale e di tipo intra/extra = rilevante, 
	-- se istituzionale e tipo Italia = non rilevante, 
	-- se promiscua = rilevante, perchè assimiliamo l''attività promiscua a quella commerciale.
	--I 1, C 2, P 3, Q 4
	case	when (MK.flagactivity = 2) then 'S'
			when (MK.flagactivity = 3) then 'S'
			when (MK.flagactivity = 1 and flagintracom <> 'N')  then 'S'
			when (MK.flagactivity = 1 and flagintracom = 'N') then 'N'
			else 'S'
	end,
	--cigcode,
	M.annotations,
	'Contratto passivo'
FROM uniqueregister U
join mandateview M		on U.idmankind = M.idmankind	and U.yman = M.yman	and U.nman = M.nman
JOIN mandatekind MK		ON M.idmankind = MK.idmankind
where U.iduniqueregister between @nbegin and @nend 
	AND (isnull(M.idsor01,MK.idsor01) = @idsor01 OR @idsor01 IS NULL)
	AND (isnull(M.idsor02,MK.idsor02) = @idsor02 OR @idsor02 IS NULL)
	AND (isnull(M.idsor03,MK.idsor03) = @idsor03 OR @idsor03 IS NULL)
	AND (isnull(M.idsor04,MK.idsor04) = @idsor04 OR @idsor04 IS NULL)
	AND (isnull(M.idsor05,MK.idsor05) = @idsor05 OR @idsor05 IS NULL)

declare @TabInfoMandate table   (idmankind varchar(20),	yman smallint,	nman int, idexp int, idexp_iva int, cupcode varchar(15), cigcode varchar(10),impegno varchar(100) )

-- Impegno, CIG e CUP
	insert into @TabInfoMandate (idmankind ,yman,nman, idexp , cupcode , cigcode, impegno)
	SELECT distinct mandett.idmankind, mandett.yman, mandett.nman, EM.idexp, mandett.cupcode , isnull(mandett.cigcode, M.cigcode),
	'Es.'+convert(varchar(10),E.ymov) + ' N.'+convert(varchar(20),E.nmov)+'. '
	FROM  #registro R
	join mandatedetail mandett			on R.idmankind = mandett.idmankind	and R.yman = mandett.yman	and R.nman = mandett.nman
	join mandate M						on R.idmankind = M.idmankind		and R.yman = M.yman			and R.nman = M.nman
	left outer join expensemandate EM 	on R.idmankind = EM.idmankind 	and R.yman = EM.yman 	and R.nman = EM.nman --Uso il LEFT perchè se il CUP e CIG li sto prendendo ora, quindi se non ci fosse la contab. non li riuscirei a prendree.
	left outer join expense E on EM.idexp = E.idexp
	where (mandett.cigcode is not null OR M.cigcode is not null or mandett.cupcode is not null or EM.idexp is not null)

-- In @TabInfoConcat concateno le info di Impegno / CIG / CUP del Contratto Passivo
INSERT INTO  @TabInfoConcat(idmankind ,yman,nman, impegni, cupcode, cigcode)
SELECT distinct Tman.idmankind , Tman.yman, Tman.nman,
    SUBSTRING(
        (SELECT ', ' + impegno
            FROM @TabInfoMandate Tman2
            WHERE Tman.idmankind = Tman2.idmankind and Tman.yman = Tman2.yman and Tman.nman = Tman2.nman
            FOR XML PATH ('')
        )
    , 3, 1000) Impegni,
    SUBSTRING(
        (SELECT ', ' + cupcode
            FROM @TabInfoMandate Tman2
            WHERE Tman.idmankind = Tman2.idmankind and Tman.yman = Tman2.yman and Tman.nman = Tman2.nman
			group by cupcode
            FOR XML PATH ('')
        )
    , 3, 1000) cupcode,
	    SUBSTRING(
        (SELECT ', ' + cigcode
            FROM @TabInfoMandate Tman2
            WHERE Tman.idmankind = Tman2.idmankind and Tman.yman = Tman2.yman and Tman.nman = Tman2.nman
			group by cigcode
            FOR XML PATH ('')
        )
    , 3, 1000) cigcode
  FROM @TabInfoMandate Tman

-- Contratto Occasionale
insert into #registro(
	ycon, ncon,	iduniqueregister,	arrivalprotocolnum,	doc,	dataemissione,	dataricezione,	idreg,
	description,	amount,	scadenza,	rilevanteiva,	cupcode,	cigcode,	annotations,	tipodocumento
)
SELECT 
	C.ycon, C.ncon,	U.iduniqueregister,	C.arrivalprotocolnum,	convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),
	C.adate,	C.arrivaldate,	C.idreg,
	C.description,	C.total,	C.expiration,	'N',	C.cupcode,	C.cigcode,	C.annotations,	'Contratto Occasionale'
FROM uniqueregister U
join casualcontractview C
	on U.ycon = C.ycon
	and U.ncon = C.ncon
where U.iduniqueregister between @nbegin and @nend 
	AND (C.idsor01 = @idsor01 OR @idsor01 IS NULL)
	AND (C.idsor02 = @idsor02 OR @idsor02 IS NULL)
	AND (C.idsor03 = @idsor03 OR @idsor03 IS NULL)
	AND (C.idsor04 = @idsor04 OR @idsor04 IS NULL)
	AND (C.idsor05 = @idsor05 OR @idsor05 IS NULL)

declare @TabInfoOccasionale table   (ycon smallint,	ncon int, idexp int, impegno varchar(100))
insert into @TabInfoOccasionale(ycon, ncon, idexp, impegno	) 
	SELECT ECC.ycon, ECC.ncon, E.idexp ,
	'Es.'+convert(varchar(10),E.ymov) + ' N.'+convert(varchar(20),E.nmov)+'. '
	FROM  #registro R
	join expensecasualcontract ECC
		on R.ycon = ECC.ycon
		and R.ncon = ECC.ncon
	join expense E
		on E.idexp = ECC.idexp

INSERT INTO  @TabInfoConcat(ycon,ncon, impegni)
SELECT distinct Tcon.ycon, Tcon.ncon,
    SUBSTRING(
        (SELECT ', ' + impegno
            FROM @TabInfoOccasionale Tcon2
            WHERE Tcon.ycon = Tcon2.ycon and Tcon.ncon = Tcon2.ncon
            FOR XML PATH ('')
        )
    , 3, 1000) Impegni
FROM @TabInfoOccasionale Tcon


declare @headertreasurer varchar(150)
if (select count(*) from treasurer where 
					(idsor01 = @idsor01 OR @idsor01 IS NULL)
				AND (idsor02 = @idsor02 OR @idsor02 IS NULL)
				AND (idsor03 = @idsor03 OR @idsor03 IS NULL)
				AND (idsor04 = @idsor04 OR @idsor04 IS NULL)
				AND (idsor05 = @idsor05 OR @idsor05 IS NULL)
			)=1
	Begin
		select @headertreasurer = header
		from treasurer 
		where 	(idsor01 = @idsor01 OR @idsor01 IS NULL)
				AND (idsor02 = @idsor02 OR @idsor02 IS NULL)
				AND (idsor03 = @idsor03 OR @idsor03 IS NULL)
				AND (idsor04 = @idsor04 OR @idsor04 IS NULL)
				AND (idsor05 = @idsor05 OR @idsor05 IS NULL)
	End

--select  * from @TabInfoConcat where idinvkind = 105 and ninv = 428
SELECT 
	R.iduniqueregister ,	R.arrivalprotocolnum ,	R.doc ,	R.dataemissione ,	R.dataricezione ,	R.idreg ,	R. description,
	R.amount ,
	R.scadenza, ISNULL(I.impegni, isnull(M.impegni, C.impegni)) ,	
	R.rilevanteiva ,	
	ISNULL(I.cigcode, isnull(M.cigcode, isnull(C.cigcode, R.cigcode))) ,
	ISNULL(I.cupcode, isnull(M.cupcode, isnull(C.cupcode, R.cupcode))) ,
	R.annotations,	R.idinvkind ,	R.yinv ,	R.ninv ,
	R.ycon ,	R.ncon ,	
	R.idmankind,	R.yman ,R.nman,	
	A.title as registry,	A.cf ,	R.tipodocumento,
	@headertreasurer as headertreasurer
 FROM #registro R
join registry A
	on R.idreg = A.idreg
left outer join @TabInfoConcat I on R.idinvkind = I.idinvkind and R.yinv = I.yinv and R.ninv = I.ninv and I.idinvkind is not null
left outer join @TabInfoConcat M on R.idmankind = M.idmankind and R.yman = M.yman and R.nman = M.nman and M.idmankind is not null
left outer join @TabInfoConcat C on R.ycon = C.ycon and R.ncon = C.ncon and C.ycon is not null
--where idinvkind = 105 and ninv = 428
order by iduniqueregister
END







GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
