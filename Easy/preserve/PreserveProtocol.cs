using System;

using Document;

namespace preserve {

    public class PreserveProtocol : PreserveData {

        private readonly string _fileName;
        private readonly byte[] _contents;
        private readonly string _signature;

        private readonly Soggetto _owner;

        public PreserveProtocol(DateTime timestamp, string id, string fileName, byte[] contents, string signature, Soggetto owner) {

            Timestamp = timestamp;
            ID = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentException(nameof(id));

            _fileName = fileName;
            _contents = contents;
            _signature = signature;
            _owner = owner;
        }

        public override string ID { get; set; }
        public override TDocument Type { get; set; }
        public override DateTime Timestamp { get; set; }

        public override string Filename => _fileName;
        public override byte[] Contents => _contents;
        public override string Signature => _signature;

        public override Soggetto Owner => _owner;
        public override string IDOffice => Owner.IPAAmm;
    }
}
