(function () {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_reportres() {
        MetaData.apply(this, ["reportres"]);
        this.name = 'meta_reportres';
    }

    meta_reportres.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_reportres,
            superClass: MetaData.prototype,

            describeColumns: function (table, listType) {
                var nPos = 1;
                var self = this;
                var cols = [];
                if (table.rows.length) {

                    let cols = []
                    //per ogni riga
                    _.forEach(table.rows, function (row) {
                        //per ogni colonna
                        let lastElement = '';
                        _.forEach(row, function (value, key) {
                            //se non c'è
                            if (!cols.find(item => item === key)) {
                                //aggiungo solo apresso all'ultimo elemento
                                const indice = lastElement = '' ? 0 : cols.indexOf(lastElement);
                                cols.splice(indice + 1, 0, key);
                            }
                            lastElement = key;
                        });
                    });

                    if (cols.length) {
                        _.forEach(cols, function (key) {
                            table.columns[key] = { name: key };
                            self.describeAColumn(table, key, (key.charAt(0).toUpperCase() + key.slice(1)).replace(/_/g, " "), null, nPos, null);
                            nPos++;
                        });
                    }
                }
                return appMeta.Deferred("describeColumns").resolve();
            },

        });

    window.appMeta.addMeta('reportres', new meta_reportres('reportres'));

}());
