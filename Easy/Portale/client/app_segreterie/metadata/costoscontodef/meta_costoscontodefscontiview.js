(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_costoscontodefscontiview() {
        MetaData.apply(this, ["costoscontodefscontiview"]);
        this.name = 'meta_costoscontodefscontiview';
    }

    meta_costoscontodefscontiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_costoscontodefscontiview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'sconti':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2024);
						this.describeAColumn(table, 'costoscontodefparent_title', 'Relativo al costo', null, 40, 2024);
//$objCalcFieldConfig_sconti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcostoscontodef"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "sconti": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('costoscontodefscontiview', new meta_costoscontodefscontiview('costoscontodefscontiview'));

	}());
