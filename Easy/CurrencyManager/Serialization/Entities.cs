using System;
using System.Collections.Generic;

namespace CurrencyManager.Serialization {

    public class LatestRate {
        public string country;
        public string currency;
        public string isoCode;
        public string uicCode;
        public string eurRate;
        public string usdRate;
        public string usdExchangeConvention;
        public string usdExchangeConventionCode;
        public string referenceDate;
    }

    public class Country {
        public string currencyISO;
        public string country;
        public string countryISO;
        public DateTime? validityStartDate;
        public DateTime? validityEndDate;
    }

    public class Currency {
        public List<Country> countries;
        public string isoCode;
        public string name;
        public bool graph;
    }

    class IsoCodeEqualityComparer : IEqualityComparer<Currency> {
        public bool Equals(Currency c1, Currency c2) {

            return string.Compare(c1.isoCode, c2.isoCode, true) == 0;
        }

        public int GetHashCode(Currency c) {
            return c.isoCode.GetHashCode();
        }
    }

    public class Rate {
        public string country;
        public string currency;
        public string isoCode;
        public string uicCode;
        public string avgRate;
        public string exchangeConvention;
        public string exchangeConventionCode;
        public DateTime referenceDate;
    }
}
