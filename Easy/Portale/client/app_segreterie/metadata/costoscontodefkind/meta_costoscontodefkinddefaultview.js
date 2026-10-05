(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_costoscontodefkinddefaultview() {
        MetaData.apply(this, ["costoscontodefkinddefaultview"]);
        this.name = 'meta_costoscontodefkinddefaultview';
    }

    meta_costoscontodefkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_costoscontodefkinddefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, 50);
						this.describeAColumn(table, 'costoscontodefkind_description', 'Descrizione', null, 3000, 256);
						this.describeAColumn(table, 'costoscontodefkind_active', 'Attivo', null, 4000, null);
						this.describeAColumn(table, 'costoscontodefkind_sortcode', 'Ordinamento', null, 5000, null);
						this.describeAColumn(table, 'estimatekind_description', 'Tipo di contratto attivo', null, 10100, 150);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcostoscontodefkind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , costoscontodefkind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('costoscontodefkinddefaultview', new meta_costoscontodefkinddefaultview('costoscontodefkinddefaultview'));

	}());
