(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfindicatoredefaultview() {
        MetaData.apply(this, ["perfindicatoredefaultview"]);
        this.name = 'meta_perfindicatoredefaultview';
    }

    meta_perfindicatoredefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfindicatoredefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 1000, 2048);
						this.describeAColumn(table, 'perfindicatorekind_title', 'Tipo indicatore', null, 2200, 1024);
						this.describeAColumn(table, 'perfindicatore_description', 'Descrizione', null, 3000, -1);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfindicatore"];
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

			//$describeTree$
        });

    window.appMeta.addMeta('perfindicatoredefaultview', new meta_perfindicatoredefaultview('perfindicatoredefaultview'));

	}());
