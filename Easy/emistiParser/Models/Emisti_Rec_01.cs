
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


using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace ServizioPa.Models
{
    //[Table("Emisti_Rec_01", Schema = "dbo")]
    public class Emisti_Rec_01
    {
        public int Id_importo { get; set; }

        public int Progressivo { get; set; }

        public string Iscrizione { get; set; }

        //[StringLength(7)]
        public string Rata { get; set; }

        //[Display(Name = "Data Emissione")]
        public DateTime DataEmissione { get; set; }

        //[StringLength(3)]
        public string Dpt { get; set; }

        //[Display(Name = "Codice Fiscale")]
        //[StringLength(16)]
        public string CodiceFiscale { get; set; }

        //[Display(Name = "Cognome")]
        //[StringLength(30)]
        public string Cognome1 { get; set; }

        //[Display(Name = "Nome")]
        //[StringLength(30)]
        public string Nome1 { get; set; }

        //[Display(Name = "Modalità Pagamento")]
        public int ModalPagamento { get; set; }

        //[Display(Name = "Tipo Servizio")]
        public int TipoServizio { get; set; }

        //[StringLength(4)]
        public string Iban { get; set; }

        //[StringLength(1)]
        public string Cin { get; set; }

        //[StringLength(5)]
        public string Abi { get; set; }

        //[StringLength(5)]
        public string Cab { get; set; }

        //[Display(Name = "Conto Corrente")]
        //[StringLength(12)]
        public string ContoCorrente { get; set; }

        public string UfficioServizio { get; set; }

        public int CapitoloSpesa { get; set; }

        public int CapitoloBilancio { get; set; }

        //[StringLength(4)]
        public string Qualifica { get; set; }

        public int Livello { get; set; }

        public int Classe { get; set; }

        public int Scatti { get; set; }

        public int ImponibileRataAnnoCorrente { get; set; }

        public int IRPEFRataAnnoCorrente { get; set; }

        public int IRPEFArretratiAnnoCorrente { get; set; }
        public int IRPEFArretratiAnnoPrecedente { get; set; }
        public int IRPEFTotaleNetta { get; set; }

        //[Display(Name = "Importo Annuo Lordo")]
        public int ImportoAnnuoLordo { get; set; }
        public int ImportoMensileLordo { get; set; }
        public int ImportoMensileNetto { get; set; }
        public int ImportoNetto13ma { get; set; }
        public int ImportoPrev13ma { get; set; }
        public int ImportoIrpef13ma { get; set; }

        public int DetrazioniBase { get; set; }
        public int DetrazioniConiuge { get; set; }
        public int DetrazioniFigli { get; set; }
        public int DetrazioniAltriFam { get; set; }
        public int TotaleDetrazioni { get; set; }

        //[Display(Name = "Codice Regime Contributivo")]
        //[StringLength(3)]
        public string CodiceRegimeContributivo { get; set; }

        //[Display(Name = "Codice Regione Irap")]
        //[StringLength(2)]
        public string CodRegioneIrap { get; set; }

        //[Display(Name = "Codice Comune Acconto")]
        //[StringLength(4)]
        public string CodiceComuneAccon { get; set; }

        //[Display(Name = "Codice Comune Saldo")]
        //[StringLength(4)]
        public string CodiceComuneSaldo { get; set; }

        //[Display(Name = "Regime Contributivo")]
        //[StringLength(3)]
        public string RegimeContributivoCud { get; set; }

        //[Display(Name = "Credito Irpef")]
        //[Column("creditoirpef", TypeName = "bigint")]
        public Int64 CreditoIrpef { get; set; }
    }
}
