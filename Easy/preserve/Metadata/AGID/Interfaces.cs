using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preserve.Metadata.AGID {

    public interface IVerificaType {
        bool FirmatoDigitalmente { get; set; }
        bool SigillatoElettronicamente { get; set; }
        bool MarcaturaTemporale { get; set; }
        bool ConformitaCopieImmagineSuSupportoInformatico { get; set; }
    }

    public interface IPFType {
        string CodiceFiscale { get; set; }
        string Cognome { get; set; }
        string Nome { get; set; }
    }
}
