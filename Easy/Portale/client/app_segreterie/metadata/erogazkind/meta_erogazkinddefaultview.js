(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_erogazkinddefaultview() {
        MetaData.apply(this, ["erogazkinddefaultview"]);
        this.name = 'meta_erogazkinddefaultview';
    }

    meta_erogazkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_erogazkinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'erogazkind_description', 'Descrizione', null, 30, 255);
						this.describeAColumn(table, 'erogazkind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'erogazkind_ans', 'Ans', null, 50, 10);
						this.describeAColumn(table, 'erogazkind_sortcode', 'Ordinamento', null, 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iderogazkind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , erogazkind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('erogazkinddefaultview', new meta_erogazkinddefaultview('erogazkinddefaultview'));

	}());
