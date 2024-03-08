(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_menuwebtreeview() {
        MetaData.apply(this, ["menuwebtreeview"]);
        this.name = 'meta_menuwebtreeview';
    }

    meta_menuwebtreeview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_menuwebtreeview,
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
					case 'tree':
						this.describeAColumn(table, 'idmenuweb', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'menuweb_editType', 'EditType', null, 20, 60);
						this.describeAColumn(table, 'menuwebparent_label', 'Idmenuwebparent', null, 30, 250);
						this.describeAColumn(table, 'label', 'Label', null, 40, 250);
						this.describeAColumn(table, 'menuweb_link', 'Link', null, 50, 250);
						this.describeAColumn(table, 'menuweb_sort', 'Sort', null, 60, null);
						this.describeAColumn(table, 'menuweb_tableName', 'TableName', null, 70, 60);
//$objCalcFieldConfig_tree$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idmenuweb"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "tree": {
						return "menuwebparent_label asc , menuweb_sort asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('menuwebtreeview', new meta_menuwebtreeview('menuwebtreeview'));

	}());
