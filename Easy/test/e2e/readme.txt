-----------------------------------------------------------------------------
Progetto: DBConn
Data:     14/03/2017 
Autore:   Nunzio Altamura
-----------------------------------------------------------------------------

Descrizione
Il progetto DBConn viene utilizzato nella solution "Test" per istanziare una 
variabile di tipo DataAccess. 

Lo scopo è quello di definire un unico punto del codice i parametri per 
la connessione al database. 

Il progetto memorizza tali informazioni in un file di configurazione che 
può contenere più stringhe di connessione a database.

-----------------------------------------------------------------------------
File di configurazione (DBConn.dll.config)
-----------------------------------------------------------------------------

Il file di configurazione prevede la presenza di più chiavi (Key) in cui configurare l'accesso a diversi database.

Il parametro "key" identificata univocamente la connessione al database cui si fa riferimento.
La stringa "value" invece contiene i parametri utilizzati per la connessione al database.

Tali parametri sono POSIZIONALI, SEPARATI DAL CARATTERE PUNTO E VIRGOLA (;).

E' necessario seguire questa convenzione pena il malfunzionamento della applicazione.

L'ordine e la descrizione dei parametri è il seguente:

DSNDescription: Descrizione della connessione
HostName:	Nome del server di database
DbName:		Nome del database
DbUser:		Utente utilizzato per la connessione
DBPass:		Password per l'accesso

Esempio di parametri

<add key="codicedb" value="descrizione db;nome server;nome db;nome utente;password utente"/>

Nel progetto DBConn è presente un file DBConn.dll.config.sample da utilizzare come esempio.

Prima di utilizzare il progetto occorre copiare questo file nella cartella 
BIN/DEBUG o BIN/RELEASE DELLA SOLUZIONE!

Dopo questa operazione il file va rinominato come DBConn.dll.config e modificati i 
parametri di configurazione per l'accesso ai diversi DataBase.

-----------------------------------------------------------------------------
Esempi di utilizzo della classe
-----------------------------------------------------------------------------

Il costruttore della classe DBConn ha necessità di due parametri in input

Il primo, di tipo string, identifica le informazioni relative alla key DSN all'interno del file di configurazione.
Il secondo parametro, di tipo boolean, va passato come riferimento, e ritorna false se non viene trovata 
alcuna key DSN nel file di configurazione.

Oltre a questo la classe espone un metodo getDataAccess che ritorna una DataAccess utilizzabile.
Per questo metodo viene richiesto in input l'anno di esercizio (tipo int) e la data contabile (tipo DateTime).

Esempio di utilizzo della classe:

// Crea l'oggetto della classe utilizzando le informazioni di connessione della chiave "DSN1"
DBConn.DBConn dbConnection = new DBConn.DBConn("DSN1", out isFoundDSN);      

// Verifica se la chiave è stata trovata nel file di configurazione
if (isFoundDSN){
    conn = dbConnection.getDataAccess(DateTime.Now.Year, DateTime.Now);                     
    QHS = conn.GetQueryHelper();
}
else {
    // Inserire qui il codice per la gestione dell'errore!
    return;
}