
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



-- GENERAZIONE DATI PER exportfunction --
IF exists(SELECT * FROM [exportfunction] WHERE procedurename = 'exp_profservicerefund')
UPDATE [exportfunction] SET active = 'S',ct = {ts '2021-10-28 13:36:26.723'},cu = 'assistenza',description = 'Spese su Prestazione Professionale',fileextension = null,fileformat = 'E',lt = {ts '2021-10-28 13:40:36.710'},lu = 'assistenza',modulename = 'Compensi - Certificazione Unica',timeout = '10000',webvisible = 'N' WHERE procedurename = 'exp_profservicerefund'
ELSE
INSERT INTO [exportfunction] (procedurename,active,ct,cu,description,fileextension,fileformat,lt,lu,modulename,timeout,webvisible) VALUES ('exp_profservicerefund','S',{ts '2021-10-28 13:36:26.723'},'assistenza','Spese su Prestazione Professionale',null,'E',{ts '2021-10-28 13:40:36.710'},'assistenza','Compensi - Certificazione Unica','10000','N')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER exportfunctionparam --
IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'ayear' AND procedurename = 'exp_profservicerefund')
UPDATE [exportfunctionparam] SET ct = {ts '2021-10-28 13:40:12.220'},cu = 'assistenza',datasource = null,description = 'Esercizio',displaymember = null,filter = null,help = null,hint = null,hintkind = 'ACCOUNTYEAR',iscombobox = 'N',lt = {ts '2021-10-28 13:40:12.220'},lu = 'assistenza',noselectionforall = 'N',number = '1',selectioncode = null,systype = 'Int32',tag = 'g',valuemember = null WHERE paramname = 'ayear' AND procedurename = 'exp_profservicerefund'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('ayear','exp_profservicerefund',{ts '2021-10-28 13:40:12.220'},'assistenza',null,'Esercizio',null,null,null,null,'ACCOUNTYEAR','N',{ts '2021-10-28 13:40:12.220'},'assistenza','N','1',null,'Int32','g',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'annopagamento' AND procedurename = 'exp_profservicerefund')
UPDATE [exportfunctionparam] SET ct = {ts '2021-10-28 13:38:58.210'},cu = 'assistenza',datasource = null,description = 'Anno del pagamento della prestazione professionale',displaymember = null,filter = null,help = null,hint = null,hintkind = 'NOHINT',iscombobox = 'N',lt = {ts '2021-10-28 13:38:58.210'},lu = 'assistenza',noselectionforall = 'S',number = '2',selectioncode = null,systype = 'Int32',tag = 'year',valuemember = null WHERE paramname = 'annopagamento' AND procedurename = 'exp_profservicerefund'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('annopagamento','exp_profservicerefund',{ts '2021-10-28 13:38:58.210'},'assistenza',null,'Anno del pagamento della prestazione professionale',null,null,null,null,'NOHINT','N',{ts '2021-10-28 13:38:58.210'},'assistenza','S','2',null,'Int32','year',null)
GO

-- FINE GENERAZIONE SCRIPT --

if OBJECTPROPERTY(object_id('exp_profservicerefund'), 'IsProcedure') = 1
	drop procedure exp_profservicerefund
go
--setuser 'amm'
--exec exp_profservicerefund 2015, null
CREATE  PROCEDURE [exp_profservicerefund]
(
	@esercizio		int,
	@annopagamento	int
)
AS BEGIN

SELECT  
	p.ycon 'Esercizio parcella',
	p.ncon 'Numero parcella',
	r.title 'Percipiente',
	r.cf 'Codice Fiscale',
	r.p_iva 'Partita IVA',
	r.foreigncf 'CF Estero',
	p.description 'Descrizione Contratto Professionale',	
	s.codeser 'Codice Tipo Prestazione',
	s.description 'Descrizione Tipo Prestazione',
	p.feegross 'Importo prestazione',
	p.totalcost 'Costo totale',
	p.ivaamount 'Importo IVA',
	pst.employtax 'Ritenute',	
	pa.npay 'Numero pagamento',
	pa.adate 'Data pagamento',
	pt.npaymenttransmission 'Numero distinta di trasmissione',
	pt.ypaymenttransmission 'Data distinta di trasmissione',
	pr.amount 'Spese prestazione',
	pf.idlinkedrefund 'Tipo Spesa',
	pf.description 'Descrizione Tipo Spesa',
	pf.flagfiscaldeduction 'Ai fini fiscali',
	pf.flagivadeduction 'Ai fini IVA',
	pf.flagsecuritydeduction 'Ai fini previdenziali'
FROM expense
join expenselast elast				on expense.idexp = elast.idexp
join expenselink el				on el.idchild = expense.idexp 
join expenseprofservice ep		on el.idparent = ep.idexp
join profservice p				on p.ycon = ep.ycon and p.ncon = ep.ncon
left join profservicetax pst	on p.ycon = pst.ycon and p.ncon = pst.ncon
LEFT JOIN service s				ON s.idser = p.idser
left join payment pa			on pa.kpay = elast.kpay
left join paymenttransmission pt on pt.kpaymenttransmission = pa.kpaymenttransmission
left join  profservicerefund pr	on pr.ycon = p.ycon AND  pr.ncon = p.ncon
LEFT JOIN profrefund pf			on pr.idlinkedrefund = pf.idlinkedrefund
left join registry r			on r.idreg = p.idreg
where pr.ncon is not null
and (YEAR(pt.transmissiondate) = @annopagamento or @annopagamento is null) 
and (p.ycon = @esercizio or @esercizio is null) 
order by r.cf
END

