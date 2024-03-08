(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_questionariodefaultview() {
        MetaData.apply(this, ["questionariodefaultview"]);
        this.name = 'meta_questionariodefaultview';
    }

    meta_questionariodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_questionariodefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 50);
						this.describeAColumn(table, 'questionario_description', 'Descrizione', null, 30, 255);
						this.describeAColumn(table, 'questionario_anonimo', 'Anonimo', null, 40, null);
						this.describeAColumn(table, 'questionariokind_title', 'Tipo', null, 50, 128);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idquestionario"];
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

    window.appMeta.addMeta('questionariodefaultview', new meta_questionariodefaultview('questionariodefaultview'));

	}());
