<%@ Page Title="Ricerca voce di listino" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="listino_parametri.aspx.cs" Inherits="listino_parametri" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >
    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Descrizione</legend>
                <div class="row">
                    <div class="col-md-12">
                        <label for="txtDescrizione">Inserire parte della descrizione del listino desiderato e poi premere Ok</label>
                        <cc1:hwTextBox runat="server"  CssClass="form-control" ID="txtDescrizione" Tag="listino.description" TabIndex="10"></cc1:hwTextBox>
                    </div>
                    </div>
            </fieldset>

            <br />
            <br />
                    <div class="row"></div>
                    <div class="row">
                        <div class="col-md-12">
                            <cc1:hwPanel GroupingText="Class.Merceologica" CssClass="gbox stdfieldset form-group" ID="grpClassMerceologica" runat="server" 
                                        Tag="AutoChoose.txtCodClassMerc.default">
                                <div class="row">
                                    <div class="col-md-6">
                                         <div class="row">
                                         <div class="col-md-12">
                                             Selezionare la classificazione mercelogica e premere OK
                                        </div>
                                             </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <cc1:hwButton ID="btnClassMerc" runat="server" Text="Classificazione" class="btn" Tag="manage.listclass.mandatetree" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <cc1:hwTextBox runat="server" ID="txtCodClassMerc" Tag="listclass.codelistclass?x" CssClass="input-md form-control"  TabIndex="20"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <cc1:hwTextBox runat="server" ID="txtDescClassMerc" Tag="listclass.title?x" CssClass="input-md form-control" TextMode="MultiLine" Rows="4" ReadOnly="True" TabIndex="20"></cc1:hwTextBox>
                                    </div>

                                </div>

                            </cc1:hwPanel>

                        </div>
                    </div>
                     <div class="row">
                         <div class="col-md-4 col-md-offset-8">
                           <cc1:hwButton ID="btnOk" runat="server" Text="Ok" class="btn btn-success" Tag="Accetta" />
                            <cc1:hwButton ID="btnCancel" runat="server" Text="Annulla" class="btn btn-default" Tag="Annulla" />
                          </div>
                     </div>
                </div>
            
        </div>


</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="JScriptBeforeLibs" Runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="JScriptAfterLibs" Runat="Server">
</asp:Content>

