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
    public partial class UpdateIncaricoConsulenteWsDto {
        /// <summary>
        /// Istanzia un Incarico Consulente secondo le specifiche.
        /// </summary>
        /// <param name="t">Istanza del traduttore di campi.</param>
        /// <param name="incaricoConsulente">Oggetto contenente i dati da inviare.</param>
        /// <param name="payments">Enumerabile di DataRow che rappresentano i pagamenti associati all'incarico. Devono contenere i campi "ypay" e "payedamount".</param>
        public UpdateIncaricoConsulenteWsDto(Translator<FieldName, TRole> t, variazione_incarico_consulente incaricoConsulente, DataRow service, string comuneNascita, IEnumerable<DataRow> payments) {

            //UsoRiferimentoRegolamento = ; // NUOVO (abbiamo scelto di non valorizzarlo)
            //RiferimentoRegolamento = ; // NUOVO (abbiamo scelto di non valorizzarlo)
            //CampoTestualeOggetto = ; // NUOVO (abbiamo scelto di non valorizzarlo)
            //ConcludiIncarico = ; // NUOVO

            ConsulenteInformato = true; // NUOVO

            var sipID = t.Translate(FieldName.ServizioIstituzionePubblica, TRole.Consulente, incaricoConsulente.idpublicinstitutionservice)?.ToString();
            if (sipID != null)
                ServizioIstituzionePubblicaId = new Guid(sipID); // TABELLA - NUOVO

            var atcID = t.Translate(FieldName.AmbitoTematico, TRole.Consulente, incaricoConsulente.idthematicscope)?.ToString();
            if (atcID != null)
                AmbitoTematicoConsulenteId = new Guid(atcID); // TABELLA - NUOVO

            AnnoRiferimento = incaricoConsulente.AnnoRiferimento; 

            if (payments != null && payments.Count() > 0) {
                Pagamenti = new List<IncaricoPagamentoDto>(payments.GroupBy(row => row["ypay"])
                    .Select(
                        group => new IncaricoPagamentoDto() {
                            AnnoRiferimento = int.Parse(group.Key.ToString()),
                            Compenso = group.Sum(row => Convert.ToDouble(CfgFn.GetNoNullDecimal(row["payedamount"]))),
                        })
                    );
            }
            else {
                Pagamenti = new List<IncaricoPagamentoDto>();
            }


            if (incaricoConsulente.datiincarico != null) {
                VerificaInsussistenza = incaricoConsulente.datiincarico.attestazioneVerificaInsussistenza == yesNo.Y;
                EstremiIncarico = incaricoConsulente.datiincarico.estremiAttoConferimento;
                TipoRapportoId = (EnumTipoRapporto)int.Parse(incaricoConsulente.datiincarico.tipoRapporto);
                NaturaConferimentoId = (EnumTipoNaturaConferimento)int.Parse(incaricoConsulente.datiincarico.naturaConferimento);

                var oicID = t.Translate(FieldName.OggettoIncarico, TRole.Consulente, incaricoConsulente.datiincarico.oggettoIncarico)?.ToString();
                if (oicID != null)
                    OggettoIncaricoConsulenteId = new Guid(oicID); 
                                
                DataInizio = (DateTime)service["start"];//ic.datiincarico.dataInizio;
                if (incaricoConsulente.datiincarico.dateconomici.dataFineSpecified)
                    DataFine = incaricoConsulente.datiincarico.dateconomici.dataFine;

                // TODO: alla risoluzione del bug da parte di ADP rimuovere l'aggiunta di un giorno alla mezzanotte tra 31 Dicembre e 1 Gennaio
                var dataConferimento = (DateTime)service["authorizationdate"];//ic.datiincarico.dataConferimento;
                DataConferimento = dataConferimento.Date.DayOfYear == 1 ? dataConferimento.AddDays(1) : dataConferimento;

                if (Uri.TryCreate(incaricoConsulente.datiincarico.sitoWebTrasparenza, UriKind.Absolute, out var url)) {
                    SitoTrasparenza = url.ToString().Trim();
                }

                if (incaricoConsulente.datiincarico.dateconomici != null) {
                    var compenso = XmlConvert.ToDouble(incaricoConsulente.datiincarico.dateconomici.compenso);
                    if (compenso == 0) {
                        TipoSaldoId = EnumTipoSaldo.Gratuito;
                    }
                    else {
                        TipoCompensoId = EnumTipoCompenso.Presunto;
                        TipoSaldoId = incaricoConsulente.datiincarico.dateconomici.incaricoSaldato == yesNo.Y ? EnumTipoSaldo.Saldato : EnumTipoSaldo.NonSaldato;
                        Compenso = compenso;
                    }

                    ComponenteVariabileCompenso = incaricoConsulente.datiincarico.dateconomici.componentiVariabilCompenso == yesNo.Y;
                }
            }

            if (service["flaghuman"].ToString().ToUpper() == "S") {
                
                PercettorePersonaFisica = new NewPersonaFisicaDto() {
                    CodiceFiscale = service["cf"].ToString(),
                    Cognome = service["surname"].ToString(),
                    Nome = service["forename"].ToString(),
                    DataNascita = (DateTime)service["birthdate"],
                    LuogoNascita = comuneNascita,
                    Genere = service["gender"].ToString().ToUpper(),
                    Estero = service["flagforeign"].ToString().ToUpper() == "S",
                };
            }
            else {

                PercettorePersonaGiuridica = new NewPersonaGiuridicaDto() {
                    CodiceFiscale = service["p_iva"].ToString(),
                    Denominazione = service["title"].ToString().Replace("\n", "").Replace("\r", ""),
                    Estero = service["flagforeign"].ToString().ToUpper() == "S",
                };
            }

            if (incaricoConsulente.riferimentonormativo != null) {

                var tnID = t.Translate(FieldName.TipologiaNorma, TRole.Dipendente, incaricoConsulente.riferimentonormativo.riferimento)?.ToString();
                if (tnID != null) {
                    TipologiaNormaId = new Guid(tnID);
                }

                DataRiferimentoNorma = incaricoConsulente.riferimentonormativo.data;
                NumeroRiferimentoNorma = incaricoConsulente.riferimentonormativo.numero;
                ArticoloRiferimentoNorma = incaricoConsulente.riferimentonormativo.articolo;
                CommaRiferimentoNorma = incaricoConsulente.riferimentonormativo.comma;
            }

			//if (anagrafeCentralizzata != null) {
			//	CodiceUnivocoPaAoo = anagrafeCentralizzata["codiceAoo"];
			//	CodiceUnivocoPaUo = anagrafeCentralizzata["codiceUnivocoUo"];
			//}

			// TODO: momentaneamente disattivato in quanto l'API non lo riconosce
			if (incaricoConsulente.amministrazionedichiarante != null) {
                if (incaricoConsulente.amministrazionedichiarante.codiceUoIpa != null)
				    CodiceUnivocoPaUo = incaricoConsulente.amministrazionedichiarante.codiceUoIpa;
                if (incaricoConsulente.amministrazionedichiarante.codiceAooIpa != null)
				    CodiceUnivocoPaAoo = incaricoConsulente.amministrazionedichiarante.codiceAooIpa;
			}

			if (incaricoConsulente.allegati != null) {
                CurriculumVitaeBase64 = incaricoConsulente.allegati.fileCv != null ? Convert.ToBase64String((byte[])incaricoConsulente.allegati.fileCv) : string.Empty;
                DichiarazioneSvolgimentoAltriIncarichiBase64 = incaricoConsulente.allegati.fileDichiarazioneIncarichi != null ? Convert.ToBase64String((byte[])incaricoConsulente.allegati.fileDichiarazioneIncarichi) : string.Empty;
            }
        }

        /// <summary>
        /// Restituisce una copia dell'oggetto con un placeholder al posto degli allegati.
        /// </summary>
        /// <returns>Copia dell'oggetto senza gli allegati</returns>
        public UpdateIncaricoConsulenteWsDto WithoutAttachments() {
            UpdateIncaricoConsulenteWsDto copy = (UpdateIncaricoConsulenteWsDto)this.MemberwiseClone();

            copy.CurriculumVitaeBase64 = "PLACEHOLDER";
            copy.DichiarazioneSvolgimentoAltriIncarichiBase64 = "PLACEHOLDER";

            return copy;
        }
    }
}