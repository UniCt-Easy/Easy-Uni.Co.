(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfrequestobbunatantumdefaultview() {
        MetaData.apply(this, ["perfrequestobbunatantumdefaultview"]);
        this.name = 'meta_perfrequestobbunatantumdefaultview';
    }

    meta_perfrequestobbunatantumdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfrequestobbunatantumdefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo obiettivo', null, 1000, 1024);
						this.describeAColumn(table, 'year', 'Anno solare', null, 2000, null);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Unità organizzativa', null, 3100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Unità organizzativa', null, 3220, 50);
						this.describeAColumn(table, 'perfrequestobbunatantum_description', 'Descrizione', null, 4000, -1);
						this.describeAColumn(table, 'perfrequestobbunatantum_peso', 'Peso', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'perfrequestobbunatantum_inserito', 'Inserito', null, 6000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstruttura", "idperfrequestobbunatantum"];
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

    window.appMeta.addMeta('perfrequestobbunatantumdefaultview', new meta_perfrequestobbunatantumdefaultview('perfrequestobbunatantumdefaultview'));

	}());
