(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_costoscontodefdettagliokind() {
        MetaData.apply(this, ["costoscontodefdettagliokind"]);
        this.name = 'meta_costoscontodefdettagliokind';
    }

    meta_costoscontodefdettagliokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_costoscontodefdettagliokind,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 80, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["active"].caption = "Attivo";
						table.columns["codice"].caption = "Codice";
						table.columns["idaccmotivecredit"].caption = "Casuale di credito che ci indica il conto di credito";
						table.columns["idaccmotiverevenue"].caption = "Casuale di ricavo che ci indica il conto di ricavo";
						table.columns["idaccmotiveundotax"].caption = "Casuale di costo che ci indica il conto di costo per annullo tasse entro l'anno";
						table.columns["idaccmotiveundotaxpost"].caption = "Casuale di costo che ci indica il conto di costo per annullo tasse oltre l'anno";
						table.columns["idfinmotive"].caption = "Causale finanziaria che ci indica il capitolo di bilancio";
						table.columns["idfinmotive_iva"].caption = "Causale finanziaria che ci indica il capitolo di bilancio per l'IVA";
						table.columns["idtassonomia"].caption = "Tassonomia PagoPA";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_costoscontodefdettagliokind");

				//$getNewRowInside$

				dt.autoIncrement('idcostoscontodefdettagliokind', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
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

    window.appMeta.addMeta('costoscontodefdettagliokind', new meta_costoscontodefdettagliokind('costoscontodefdettagliokind'));

	}());
