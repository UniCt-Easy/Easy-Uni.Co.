using System;
using System.Data;
using System.Linq;
using System.Xml;
using System.Collections.Generic;

using funzioni_configurazione;

using ANP2018;
using Translator;
using ADPv2.Translator;

namespace ADPv2 {

    /// <summary>
    /// https://adp-api-coll.dfp.gov.it/swagger/index.html
    /// https://adp-api.perlapa.gov.it/swagger/index.html
    /// </summary>
    public partial class UpdateIncaricoDipendenteWsDto {
        /// <summary>
        /// Modifica un Incarico Dipendente secondo le specifiche.
        /// </summary>
        /// <param name="t">Istanza del traduttore di campi.</param>
        /// <param name="incaricoDipendente">Oggetto contenente i dati da inviare.</param>
        /// <param name="payments">Enumerabile di DataRow che rappresentano i pagamenti associati all'incarico. Devono contenere i campi "ypay" e "payedamount".</param>
        public UpdateIncaricoDipendenteWsDto(Translator<FieldName, TRole> t, variazione_incarico_dipendente incaricoDipendente, DataRow service, IEnumerable<DataRow> payments) {

            //CampoTestualeOggetto = ; // NUOVO (abbiamo scelto di non valorizzarlo)
            //ConcludiIncarico = ; // NUOVO

            var atdID = t.Translate(FieldName.AmbitoTematico, TRole.Dipendente, incaricoDipendente.idthematicscope)?.ToString();
            if (atdID != null)
                AmbitoTematicoDipendenteId = new Guid(atdID); // TABELLA - NUOVO

            AnnoRiferimento = incaricoDipendente.AnnoRiferimento;

            if (payments != null && payments.Count() > 0) {
                Pagamenti = new List<IncaricoPagamentoDto>(payments.GroupBy(row => row["ypay"])
                    .Select(
                        group => new IncaricoPagamentoDto() {
                            AnnoRiferimento = int.Parse(group.Key.ToString()),
                            Compenso = group.Sum(row => Convert.ToDouble(CfgFn.GetNoNullDecimal(row["payedamount"]))),
                        })
                    );
            } else {
                Pagamenti = new List<IncaricoPagamentoDto>();
            }

            if (incaricoDipendente.conferente != null) {
                TipoSoggettoConferenteId = Translations.SoggettoConferente[incaricoDipendente.conferente.tipologia];

                switch (TipoSoggettoConferenteId) {

                    case EnumTipoSoggettoConferente.Pubblico:

                        var pubblico = (conferentepubblico)incaricoDipendente.conferente.Item;

                        CodiceFiscaleConferentePa = incaricoDipendente.amministrazionedichiarante.codiceFiscalePa;//pubblico.codiceFiscalePa;//pubblico.codicePaIpa;

                        break;

                    case EnumTipoSoggettoConferente.Privato:

                        TConferente c = TConferente.Sconosciuto;

                        if (incaricoDipendente.conferente.Item.TryCast(out conferentepf pf))
                            c = TConferente.PersonaFisica;

                        if (incaricoDipendente.conferente.Item.TryCast(out conferentepg pg))
                            c = TConferente.PersonaGiuridica;

                        switch (c) {

                            case TConferente.Sconosciuto: // Non valorizziamo i campi del nuovo oggetto
                                //throw Errors.Conferente(id.conferente.Item);
                                break;

                            case TConferente.PersonaFisica:
                                //[18550] Se il soggetto non ha codice fiscale (soggetto estero) vanno impostati i campi “nome”, “cognome”, “dataNascita” e “genere” settando il flag “estero” a true
                                if (incaricoDipendente.conferenteEstero) {
                                    ConferentePersonaFisica = new NewPersonaFisicaDto() {
                                        //CodiceFiscale = pf.codiceFiscale,
                                        Cognome = pf.cognome,
                                        Nome = pf.nome,
                                        DataNascita = pf.dataNascita,
                                        //LuogoNascita = pf.comuneNascita,
                                        Genere = pf.genere == Sesso.M ? Sesso.M.ToString() : Sesso.F.ToString(),

                                        Estero = incaricoDipendente.conferenteEstero,
                                    };
                                }
                                //[18550] Se il soggetto ha codice fiscale rilasciato in italia occorrerà popolare i soli campi “codiceFiscale” e “estero” impostato a false
                                ConferentePersonaFisica = new NewPersonaFisicaDto() {
                                    CodiceFiscale = pf.codiceFiscale,
                                    //Cognome = pf.cognome,
                                    //Nome = pf.nome,
                                    //DataNascita = pf.dataNascita,
                                    //LuogoNascita = pf.comuneNascita,
                                    //Genere = pf.genere == Sesso.M ? Sesso.M.ToString() : Sesso.F.ToString(),

                                    Estero = incaricoDipendente.conferenteEstero,
                                };
                                break;

                            case TConferente.PersonaGiuridica:
                                ConferentePersonaGiuridica = new NewPersonaGiuridicaDto() {
                                    CodiceFiscale = pg.codiceFiscale,
                                    Denominazione = pg.denominazione,

                                    Estero = incaricoDipendente.conferenteEstero,
                                };
                                break;

                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
            
            if (incaricoDipendente.percettore != null) {
                PercettorePersonaFisicaCf = service["cf"].ToString();//id.percettore.codiceFiscale;
                QualificaPercettoreId = Translations.QualificaPercettore[incaricoDipendente.percettore.qualifica];
            }

            if (incaricoDipendente.datiincarico != null) {

                var oidID = t.Translate(FieldName.OggettoIncarico, TRole.Dipendente, incaricoDipendente.datiincarico.oggettoIncarico)?.ToString();
                if (oidID != null)
                    OggettoIncaricoDipendenteId = new Guid(oidID);

                DataInizio = (DateTime)service["start"];//id.datiincarico.dataInizio;
                if (incaricoDipendente.datiincarico.dateconomici.dataFineSpecified)
                    DataFine = incaricoDipendente.datiincarico.dateconomici.dataFine;

                // TODO: alla risoluzione del bug da parte di ADP rimuovere l'aggiunta di un giorno alla mezzanotte tra 31 Dicembre e 1 Gennaio
                var dataConferimento = (DateTime)service["authorizationdate"];//id.datiincarico.dataAutorizzazioneConferimento;
                DataConferimento = dataConferimento.Date.DayOfYear == 1 ? dataConferimento.AddDays(1) : dataConferimento;

                if (Uri.TryCreate(incaricoDipendente.datiincarico.sitoWebTrasparenza, UriKind.Absolute, out var url)) {
                    SitoTrasparenza = url.ToString().Trim();
                }

                if (incaricoDipendente.datiincarico.dateconomici != null) {
                    var compenso = XmlConvert.ToDouble(incaricoDipendente.datiincarico.dateconomici.compenso);
                    if (compenso == 0) {
                        TipoSaldoId = EnumTipoSaldo.Gratuito;
                    } else {
                        TipoCompensoId = EnumTipoCompenso.Presunto;
                        TipoSaldoId = incaricoDipendente.datiincarico.dateconomici.incaricoSaldato == yesNo.Y ? EnumTipoSaldo.Saldato : EnumTipoSaldo.NonSaldato;
                        Compenso = compenso;
                    }
                }
            }

            if (incaricoDipendente.riferimentonormativo != null) {

                var tnID = t.Translate(FieldName.TipologiaNorma, TRole.Dipendente, incaricoDipendente.riferimentonormativo.riferimento)?.ToString();
                if (tnID != null) {
                    TipologiaNormaId = new Guid(tnID);
                }

                DataRiferimentoNorma = incaricoDipendente.riferimentonormativo.data;
                NumeroRiferimentoNorma = incaricoDipendente.riferimentonormativo.numero;
                ArticoloRiferimentoNorma = incaricoDipendente.riferimentonormativo.articolo;
                CommaRiferimentoNorma = incaricoDipendente.riferimentonormativo.comma;
            }

			//if (anagrafeCentralizzata != null) {
			//    CodiceUnivocoPaAoo = anagrafeCentralizzata["codiceAoo"];
			//    CodiceUnivocoPaUo = anagrafeCentralizzata["codiceUnivocoUo"];
			//}

			// TODO: momentaneamente disattivato in quanto l'API non lo riconosce
			if (incaricoDipendente.amministrazionedichiarante != null) {
                if (incaricoDipendente.amministrazionedichiarante.codiceUoIpa != null)
				    CodiceUnivocoPaUo = incaricoDipendente.amministrazionedichiarante.codiceUoIpa;
                if (incaricoDipendente.amministrazionedichiarante.codiceAooIpa != null)
				    CodiceUnivocoPaAoo = incaricoDipendente.amministrazionedichiarante.codiceAooIpa;
			}
		}
    }
}