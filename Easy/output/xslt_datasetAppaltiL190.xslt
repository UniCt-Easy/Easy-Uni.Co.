<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
   <xsl:template match="/">
      <html>
         <body>
            <xsl:comment>XSLT per Dataset Appalti Legge 190 - USR Umbria</xsl:comment>
            <table border="1" cellspacing="0" cellpadding="2" style="font: 80% arial, sans-serif;">
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Titolo:</th>
                  <td>
                     <strong>
                        <xsl:value-of select="//metadata/titolo"/>
                     </strong>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Abstract:</th>
                  <td>
                     <xsl:value-of select="//metadata/abstract"/>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Data di pubblicazione:</th>
                  <td>
                     <xsl:variable name="dateP">
                        <xsl:value-of select="//metadata/dataPubbicazioneDataset"/>
                     </xsl:variable>
                     <xsl:value-of select="concat(substring($dateP,9,2),'/',substring($dateP,6,2),'/',substring($dateP,1,4))"/>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Ente pubblicatore:</th>
                  <td>
                     <xsl:value-of select="//metadata/entePubblicatore"/>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Data ultimo aggiornamento:</th>
                  <td>
                     <xsl:variable name="dateA">
                        <xsl:value-of select="//metadata/dataUltimoAggiornamentoDataset"/>
                     </xsl:variable>
                     <xsl:value-of select="concat(substring($dateA,9,2),'/',substring($dateA,6,2),'/',substring($dateA,1,4))"/>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Anno di riferimento:</th>
                  <td>
                     <xsl:value-of select="//metadata/annoRiferimento"/>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">URL file:</th>
                  <td>
                     <xsl:element name="a">
                        <xsl:attribute name="href">
                           <xsl:value-of select="//metadata/urlFile"/>
                        </xsl:attribute>
                        <xsl:attribute name="target">_top</xsl:attribute>
                        <xsl:value-of select="//metadata/urlFile"/>
                     </xsl:element>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Licenza:</th>
                  <td>
                     <xsl:value-of select="//metadata/licenza"/>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Struttura Proponente</th>
                  <td>
                     <br/>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Codice fiscale:</th>
                  <td>
                     <strong>
                        <xsl:value-of select="//data/lotto/strutturaProponente/codiceFiscaleProp"/>
                     </strong>
                  </td>
               </tr>
               <tr>
                  <th style="text-align:right;" bgcolor="#ddddff">Denominazione:</th>
                  <td>
                     <strong>
                        <xsl:value-of select="//data/lotto/strutturaProponente/denominazione"/>
                     </strong>
                  </td>
               </tr>
            </table>
            <br/>
            <table border="1" cellspacing="0" cellpadding="2" style="font: 80% arial, sans-serif;">
               <tr bgcolor="#ddddff">
                  <th>CIG</th>
                  <th>Oggetto</th>
                  <th>Scelta Contraente</th>
                  <th>
                     Partecipanti
                     <br/>
                     Codice fiscale
                     <br/>
                     Ragione sociale
                  </th>
                  <th>
                     Aggiudicatari
                     <br/>
                     Codice fiscale
                     <br/>
                     Ragione sociale
                  </th>
                  <th>Importo Aggiudicazione</th>
                  <th>Importo somme liquidate</th>
                  <th>Data inzio</th>
                  <th>Data ultimazione</th>
               </tr>
               <xsl:for-each select="//data/lotto">
                  <tr>
                     <td>
                        <xsl:value-of select="cig"/>
                     </td>
                     <td>
                        <xsl:value-of select="oggetto"/>
                     </td>
                     <td>
                        <xsl:value-of select="sceltaContraente"/>
                     </td>
                     <td>
                        <ul>
                           <xsl:choose>
                              <xsl:when test="partecipanti/partecipante/codiceFiscale=''">
                                 <xsl:for-each select="aggiudicatari/aggiudicatario">
                                    <li>
                                       <xsl:value-of select="codiceFiscale"/>
                                       <br/>
                                       <xsl:value-of select="ragioneSociale"/>
                                    </li>
                                 </xsl:for-each>
                              </xsl:when>
                              <xsl:otherwise>
                                 <xsl:for-each select="partecipanti/partecipante">
                                    <li>
                                       <xsl:value-of select="codiceFiscale"/>
                                       <br/>
                                       <xsl:value-of select="ragioneSociale"/>
                                    </li>
                                 </xsl:for-each>
                              </xsl:otherwise>
                           </xsl:choose>
                        </ul>
                     </td>
                     <td>
                        <ul>
                           <xsl:for-each select="aggiudicatari/aggiudicatario">
                              <li>
                                 <xsl:value-of select="codiceFiscale"/>
                                 <br/>
                                 <xsl:value-of select="ragioneSociale"/>
                              </li>
                           </xsl:for-each>
                        </ul>
                     </td>
                     <td style="text-align:right;">
                        <xsl:value-of select="importoAggiudicazione"/>
                     </td>
                     <td style="text-align:right;">
                        <xsl:value-of select="importoSommeLiquidate"/>
                        <xsl:if test="importoSommeLiquidate=''">0.00</xsl:if>
                     </td>
                     <td>
                        <xsl:variable name="dateI">
                           <xsl:value-of select="tempiCompletamento/dataInizio"/>
                        </xsl:variable>
                        <xsl:value-of select="concat(substring($dateI,9,2),'/',substring($dateI,6,2),'/',substring($dateI,1,4))"/>
                     </td>
                     <td>
                        <xsl:variable name="dateU">
                           <xsl:value-of select="tempiCompletamento/dataUltimazione"/>
                        </xsl:variable>
                        <xsl:value-of select="concat(substring($dateU,9,2),'/',substring($dateU,6,2),'/',substring($dateU,1,4))"/>
                     </td>
                  </tr>
               </xsl:for-each>
            </table>
         </body>
      </html>
   </xsl:template>
</xsl:stylesheet>