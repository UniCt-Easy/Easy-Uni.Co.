(function () {

	// Deriva da MetaPage
	var MetaPage = window.appMeta.MetaPage;
	var sec = appMeta.security;
	var metaModel = appMeta.metaModel;

	// Enumerato dei tipi di campi di cui controllare un formato specifico.
	// Utilizzato sulla validateRow()
	var EnumformatFields = {
		E_email: "email",
		E_ip: "ip"
	};


	/********** classe ausiliaria QueryHelper **********************/
	function QueryHelper() {
	}

	QueryHelper.prototype = {
		constructor: QueryHelper,

        /**
         * @method getClausoleInFromRows
         * @private
         * @description ASYNC
         * Return an array of value of field "field" on rows  
         * @param {ObjectRows[]} rows
         * @param {string} field
         * @returns [] an array of value 
         */
		getValuesOfFieldFromRows: function (rows, field) {
			return _.uniq(
				_.map(rows, function (r) {
					return r[field];
				}));
		},

        /**
         * Returns true if the two dates are equal, false otherwise
         * @param {Date} d1
         * @param {Date} d2
         * @returns {boolean}
         */
		dateCompare: function (d1, d2) {
			var same = d1.getTime() === d2.getTime();
			return same;
		}
	};
	appMeta.QueryHelper = new QueryHelper();
	/******** fine classe statica ***********/


	/********** classea usiliaria QueryCreator **********************/
	function QueryCreator() {
	}

	QueryCreator.prototype = {
		constructor: QueryCreator,

        /**
         * 
         */
		emptyDate: function () {
			return new Date(1000, 1, 1);
		}
	};
	appMeta.QueryCreator = new QueryCreator();

	/******** fine classe statica ***********/

	function MetaEasyPage() {
		MetaPage.apply(this, arguments);
		// oggetto con le var di sicurezza
		this.sec = sec;
		// var di sicurezza notevoli
		this.datacontabile = new Date(sec.sys("datacontabile"));
		this.esercizio = sec.sys("esercizio");

		// oggetto di helper per la costruzione di filtri tramite jsDataquery
		this.queryHelper = appMeta.QueryHelper;
		// oggetto jsDataQuery
		this.q = window.jsDataQuery;

	}

	MetaEasyPage.prototype = _.extend(
		new MetaPage(),
		{
			constructor: MetaEasyPage,
			superClass: MetaPage.prototype,

            /**
             * @method getName
             * @private
             * @description SYNC
             * To override. sets the name of the page
             */
			getName: function () {
				return "EasyPage " + ((this.name !== undefined) ? this.name : "");
			},


			showHideEl: function (el, bool) {
				// Cerco la label associata all'elemento
				var lab = this.getLabelForEle(el);
				// Controllo che non sia una "Select2"
				el = this.checkElIsSelect2(el);
				// Visibilità
				this.setVisibility(el, bool);
				this.setVisibility(lab, bool);
			},

			setVisibility: function (el, bool) {
				if (el) {
					if (bool) {
						$(el).css("visibility", "visible");
					} else {
						$(el).css("visibility", "hidden");
					}
				}
			},

			checkElIsSelect2: function (el) {
				// Controllo se l'elemento è una "Select2"
				if ($(el).hasClass("select2-hidden-accessible")) {
					// Next è la struttura "Select2" che segue la select nascosta
					el = $(el).next();
				}
				return el;
			},

			getLabelForEle: function (el) {
				var lab = $(el).prev();
				if (!lab.is("label")) {
					lab = $(el).parent().prev();
					if (!lab.is("label")) {
						lab = null;
					}
				}
				return lab;
			},

            /**
            * @method disableEl
            * @private
            * @description SYNC
            * if bool = true enable the html node, otherwise it disable it
            * @param {html node} el
            * @param {boolean} bool
            */
			enableEl: function (el, bool) {
				$(el).prop("disabled", !bool);
			},

            /**
             * @method readOnlyEl
             * @private
             * @description SYNC
             * @param {html node} el
             * @param {boolean} bool
             */
			readOnlyEl: function (el, bool) {
				$(el).prop("readonly", bool);
			},

            /**
             * @method showHideEl
             * @private
             * @description SYNC
             * Shows/hides an html elemnt. preserve the sapce
             * @param {html node} el
             * @param {bool} if true shows the element, false hides it
             */
			displayFlexNoneEl: function (el, bool) {
				if (bool) {
					$(el).css("display", "flex");
				} else {
					$(el).css("display", "none");
				}
			},

            /**
             *
             * @returns {Deferred}
             */
			afterLink: function () {
				return MetaPage.prototype.afterLink.call(this);
			},

			checkDisableInputFile:function (){
				var disable = this.state.isSearchState();
				_.forEach($("[type=file]"), function (inputFile) {
					$(inputFile).prop("disabled", disable);
				});
			},

            /**
             *
             * @param {string} tag
             * @returns {Object} the instantiated class of custom control
             */
			getCustomControl: function (tag) {
				var ctrl = $("[data-tag='" + tag + "']");
				return ctrl.data("customController");
			}
		});

	appMeta.MetaEasyPage = MetaEasyPage;
	appMeta.EnumformatFields = EnumformatFields;
}());
