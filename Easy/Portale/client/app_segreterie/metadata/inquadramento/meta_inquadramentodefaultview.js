(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_inquadramentodefaultview() {
        MetaData.apply(this, ["inquadramentodefaultview"]);
        this.name = 'meta_inquadramentodefaultview';
    }

    meta_inquadramentodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_inquadramentodefaultview,
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
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 2000, 2048);
						this.describeAColumn(table, 'inquadramento_tempdef', 'Tempo definito', null, 3000, null);
						this.describeAColumn(table, 'inquadramento_start', 'Inizio validità', 'g', 8000, null);
						this.describeAColumn(table, 'inquadramento_stop', 'Fine validità', 'g', 9000, null);
						this.describeAColumn(table, 'inquadramento_costolordoannuo', 'Costo lordo annuo massimo', 'fixed.2', 10000, null);
						this.describeAColumn(table, 'inquadramento_costolordoannuooneri', 'Costo lordo e oneri annuo massimo', 'fixed.2', 11000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idposition", "idinquadramento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('inquadramentodefaultview', new meta_inquadramentodefaultview('inquadramentodefaultview'));

	}());
