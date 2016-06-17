<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>StyleCop Analysis</title>
        <style>
          .violationSummary
          {
          border-bottom-color: black;
          border-bottom-width: 1px;
          border-bottom-style: solid;
          }

          table.violationList
          {
          width: 97%;
          margin-left: 2em;
          margin-top: .5em;
          border-style: solid;
          border-width: 1px;
          border-color: black;
          }

          table.violationList td.lineNumber
          {
          width: 2%;
          }

          table.violationList td.source
          {
          width: 63%;
          }

          table.violationList td.section
          {
          width: 35%;
          }

          .namespaceContainer
          {
          margin-bottom: 1em;
          }

          .ruleContainer
          {
          margin-bottom: 2em;
          margin-left: 1em;
          }

          .ruleName
          {
          font-size: 1.2em;
          font-weight: bold;
          }

          .ruleDescription
          {
          font-style: italic;
          font-size: .8em;
          }
        </style>
      </head>
      <body>
        <div class="violationSummary">
          Number of violations: <xsl:value-of select="count(StyleCopViolations/Violation)" />
        </div>
        <xsl:for-each select="StyleCopViolations/Violation[not(@RuleNamespace=preceding-sibling::Violation/@RuleNamespace)]/@RuleNamespace">
          <xsl:sort select="." />
          <xsl:variable name="rule" select="." />
          <div class="namespaceContainer">
            <h2>
              <xsl:value-of select="$rule" />
            </h2>
            <xsl:for-each select="/StyleCopViolations/Violation[@RuleNamespace=$rule and not(@RuleId=preceding-sibling::Violation/@RuleId)]">
              <xsl:sort select="@RuleId" />
              <xsl:variable name="ruleId" select="@RuleId" />
              <div class="ruleContainer">
                <div>
                  <span class="ruleName">
                    <xsl:value-of select="@RuleId" />: <xsl:value-of select="@Rule" />
                  </span> (<span class="ruleDescription">
                    <xsl:value-of select="." />
                  </span>)
                </div>
                <table class="violationList">
                  <thead>
                    <tr>
                      <th>Line</th>
                      <th>Source</th>
                      <th>Section</th>
                    </tr>
                  </thead>
                  <xsl:for-each select="/StyleCopViolations/Violation[@RuleNamespace=$rule and @RuleId=$ruleId]">
                    <tr>
                      <td class="lineNumber">
                        <xsl:value-of select="@LineNumber" />
                      </td>
                      <td class="source">
                        <a>
                          <xsl:attribute name="href">
                            file://<xsl:value-of select="@Source" />
                          </xsl:attribute>
                          <xsl:value-of select="@Source" />
                        </a>
                      </td>
                      <td class="section">
                        <xsl:value-of select="substring(@Section, 6)" />
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </div>
            </xsl:for-each>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>