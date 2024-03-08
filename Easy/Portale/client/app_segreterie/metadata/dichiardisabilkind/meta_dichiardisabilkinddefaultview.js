(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiardisabilkinddefaultview() {
        MetaData.apply(this, ["dichiardisabilkinddefaultview"]);
        this.name = 'meta_dichiardisabilkinddefaultview';
    }

    meta_dichiardisabilkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiardisabilkinddefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 50);
						this.describeAColumn(table, 'dichiardisabilkind_specification', 'Specifica', null, 20, 50);
						this.describeAColumn(table, 'dichiardisabilkind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'dichiardisabilkind_sortcode', 'Codice', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddichiardisabilkind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc, dichiardisabilkind_specification desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('dichiardisabilkinddefaultview', new meta_dichiardisabilkinddefaultview('dichiardisabilkinddefaultview'));

	}());
