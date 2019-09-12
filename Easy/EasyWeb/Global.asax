<%@ Application Language="C#" %>
<%@import namespace="System.IO" %>
<%@import namespace="System.IO.Compression" %>
<script runat="server">

    
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }


    
    
    void Application_BeginRequest(object sender, EventArgs e) {
        HttpCompress((HttpApplication)sender);
    }
    

    private void HttpCompress(HttpApplication app) {
        if (!(app.Context.CurrentHandler is Page) ||
           app.Request["HTTP_X_MICROSOFTAJAX"] != null)
            return;


        try {
            string accept = app.Request.Headers["Accept-Encoding"];
            if (string.IsNullOrEmpty(accept)) return;

            if (CompressScript(Request.ServerVariables["SCRIPT_NAME"])) {
                Stream stream = app.Response.Filter;
                accept = accept.ToLower();
                if (accept.Contains("gzip")) {
                    app.Response.Filter = new GZipStream(stream, CompressionMode.Compress);
                    app.Response.AppendHeader("Content-Encoding", "gzip");
                }
                else if (accept.Contains("deflate")) {
                    app.Response.Filter = new DeflateStream(stream, CompressionMode.Compress);
                    app.Response.AppendHeader("Content-Encoding", "deflate");
                }
            }

        }
        catch (Exception ex) {
            //handle the exception
        }
    }

    private bool CompressScript(string scriptName) {
        if (scriptName.ToLower().EndsWith(".aspx")) return true;
        if (scriptName.ToLower().EndsWith(".axd")) return false;
        if (scriptName.ToLower().EndsWith(".css")) return true;
        if (scriptName.ToLower().EndsWith(".js")) return true;
        if (scriptName.ToLower().EndsWith(".ashx")) return false;
        return false;
    }
</script>
