
IF exists(SELECT * FROM [auditcheck] WHERE idaudit = 'SYSTM001' AND idcheck = '2' AND opkind = 'I' AND tablename = 'address')
UPDATE [auditcheck] SET flag_both = 'S',flag_cash = 'S',flag_comp = 'S',flag_credit = 'N',flag_proceeds = 'N',lt = {ts '2007-11-13 16:08:23.377'},lu = 'SARA',message = 'Codice del tipo di indirizzo %<codeaddress>% già esistente',precheck = 'S',sqlcmd = '[(SELECT count(*) 
from address 
where codeaddress = %<address.codeaddress>%)]{I} = 0' WHERE idaudit = 'SYSTM001' AND idcheck = '2' AND opkind = 'I' AND tablename = 'address'
ELSE
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('SYSTM001','2','I','address','S','S','S','N','N',{ts '2007-11-13 16:08:23.377'},'SARA','Codice del tipo di indirizzo %<codeaddress>% già esistente','S','[(SELECT count(*) 
from address 
where codeaddress = %<address.codeaddress>%)]{I} = 0')
GO