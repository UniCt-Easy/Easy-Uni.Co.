
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace esse3service {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEasyStudenti {

        [OperationContract]
        string registraCrediti(registraCreditiData value);
        string annullaCrediti(annullaCreditiData value);

        [OperationContract]      
        string registraIncassi(registraIncassiData composite);

        // TODO: Add your service operations here
    }

    

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class registraCreditiData {
        [DataMember (IsRequired = true)] public string codiceVoce;
        [DataMember(IsRequired = true)]public string codiceTassa;
        [DataMember(IsRequired = true)] public string codiceCorsoLaurea;
        [DataMember(IsRequired = true)] public string CFStudente;
        [DataMember(IsRequired = true)] public string causale;
        [DataMember (IsRequired = true)] public string IUV;
        [DataMember] public DateTime inizioCompetenza;
        [DataMember] public DateTime fineCompetenza;
        [DataMember (IsRequired = true)] public decimal importo;
        [DataMember (IsRequired = true)] public string nome;
        [DataMember (IsRequired = true)] public string cognome;
        [DataMember (IsRequired = true)] public DateTime dataContabile;
        [DataMember] public string nBollettinoSegreteriaStudenti;
        [DataMember] public DateTime scadenza;
    }

    [DataContract]
    public class annullaCreditiData {
        [DataMember(IsRequired = true)] public string codiceVoce;
        [DataMember(IsRequired = true)] public string codiceTassa;
        [DataMember(IsRequired = true)] public string IUV;
        [DataMember(IsRequired = true)] public DateTime dataContabile;
        [DataMember(IsRequired = true)] public decimal importo;

    }

    [DataContract]
    public class registraIncassiData {
        [DataMember(IsRequired = true)] public string CFStudente;
        [DataMember(IsRequired = true)] public string IUV;      
        [DataMember(IsRequired = true)] public decimal importo;
        [DataMember(IsRequired = true)] public string TRN;
        [DataMember(IsRequired = true)] public DateTime dataContabile;

    }

}
