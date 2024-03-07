# signup

 Il sito espone nella barra di navigazione le pagine: Home, Privacy, SignUp, Purchase
 La pagina di SignUp deve contenere un form di registrazione.
 Una volta compilato il form di SignUp l'utente viene rimandato ad una pagina di Riepilogo dei dati inseriti (raggiungibile  tramite metodo HTTP-POST).
 La pagina di Purchase deve esporre un form in cui l'utente inserisce: nome del prodotto da acquistare, quantità di interesse.
 Una volta compilato il form di Purchase l'utente viene rimandato alla pagina Cart, in cui comparirà l'elenco dei prodotti inseriti

## Tema bootstrap
Free bootstrap theme: https://bootswatch.com/
Possiamo downloadare un esempio di tema e ci scarichera un file.css, da metter dentro ./wwwroot/css/ e poi linko il tutto 

non va bene per essere pubblicato perche traffico rellanto sia per host sia per server
cdn repository glabale, quando il navigatore naviga in rete mette in cache i css, quindi quando arriva da noi per la prima volta si scaricherà tutti i css
quindi facciamo: vatti a prendere questo robo qua, lui cerca il sito (https://getbootstrap.com/)https://getbootstrap.com/) per inculdere l'ultima versione di bootstrap dobbiamo mettere questo sopra e copiare questo sotto
dite al vostro client di andarlo a prendere dentro il cdn, copio la parte javascript e la copio qui, questo quello vecchio questo quello nuovo queste sono le due robe che fa e adesso va a prendere la versone nuova se serve perche i temi moderni usano la versione nuova e quindi non si comparta come vogliamo cava quello mette l'altro molto bello.
sito di adesso brutto quindi prendo previw di quello, copia e incolla mi copio il navbar e lo metto nel mio codice, sta a sentire dove è la navbar mettiamo il codice che prendiamo dalla preview e abbiamo una nuova navbar, ci piace non ci piace?
dunque dicamo tutto qua, questo sito bootwatch prendi css lo metti nel sito vai a vedere come è fatto prendi le robe che ti interessano, se vuoi una roba per genere, ti dice, fai cosi.
