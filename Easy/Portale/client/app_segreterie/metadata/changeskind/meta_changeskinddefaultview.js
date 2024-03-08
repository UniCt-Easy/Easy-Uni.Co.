(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_changeskinddefaultview() {
        MetaData.apply(this, ["changeskinddefaultview"]);
        this.name = 'meta_changeskinddefaultview';
    }

    meta_changeskinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_changeskinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 256);
						this.describeAColumn(table, 'changeskind_description', 'Descrizione', null, 30, 10);
						this.describeAColumn(table, 'changeskind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'changes_title', 'Changes', null, 50, 256);
						this.describeAColumn(table, 'changeskind_sortcode', 'Sortcode', null, 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idchangeskind"];
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

    window.appMeta.addMeta('changeskinddefaultview', new meta_changeskinddefaultview('changeskinddefaultview'));

	}());
