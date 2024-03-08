(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassaconfdefaultview() {
        MetaData.apply(this, ["tassaconfdefaultview"]);
        this.name = 'meta_tassaconfdefaultview';
    }

    meta_tassaconfdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassaconfdefaultview,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 2024);
						this.describeAColumn(table, 'costoscontodef_title', 'Costo', null, 40, 2024);
						this.describeAColumn(table, 'tassaconfkind_title', 'Tipo di tassa', null, 50, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtassaconf"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tassaconfdefaultview', new meta_tassaconfdefaultview('tassaconfdefaultview'));

	}());
