/**
 * @class Config
 * @description
 * Contains global variables for the configuration
 */
(function () {

	/**
	 * Contains the global variables for the configuration
	 */
	var config = {

		// ********** variabili di configurazione del framework, impostate nella funz init del main
		backendUrl: "http://localhost:54471", // "http://localhost:54471", // "http://151.97.242.179/Segreterie_BE/", //http://193.206.62.206:8081" , //"http://10.10.10.201:54471", //"http://localhost:54471",  // url del backend "http://185.56.8.51:8085"
		ssoPath: "/saml/DefaultSAML.aspx",
		ssoEnable: false,
		ssoLogoutUrl: "https://auth.unict.it/cas/logout",
		basePath: "../", // path relativo dove si trovano i components del framework
		basePathMetadata: "metadata/",
		rootElement: "#metaRoot", // id dell'elemento html root dove vengono ospitate le metaPage
		rootLogin: "#login", // id dell'elemento html root dove vengono ospitate le metaPage

		registrationUserTableName: "registrationuser",
		registrationUserEditType: "usr",

		enableSearchLikeOnTextBox: true,
		env: appMeta.config.envEnum.DEV,
		defaultDecimalFormat: 'n',
		defaultDecimalPrecision: 0,

		//NB: dipende dall'anno contabile di EASY a cui si è connessi
		dataContabileYear: new Date().getFullYear(),
		codiceDipartimento: 'amministrazione',
		virtualUserUserKind: 3,
		
		copyright : '© 2022-2023 Tempo s.r.l. All rights reserved'
	};

	// override path dei template. Devono stare sotto  components/userTemplate
	appMeta.config.path_maintoolBarTemplate = "components/userTemplate/mainToolBar_Template.html";

	appMeta.appMainConfig = config;
}());

