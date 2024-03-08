(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_costoscontodefmoreview() {
        MetaData.apply(this, ["costoscontodefmoreview"]);
        this.name = 'meta_costoscontodefmoreview';
    }

    meta_costoscontodefmoreview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_costoscontodefmoreview,
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
					case 'more':
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, 2024);
						this.describeAColumn(table, 'costoscontodefkind_title', 'Tipologia', null, 3200, 50);
						this.describeAColumn(table, 'costoscontodefparent_title', 'Relativo al costo', null, 4200, 2024);
//$objCalcFieldConfig_more$
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
					case "more": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('costoscontodefmoreview', new meta_costoscontodefmoreview('costoscontodefmoreview'));

	}());
