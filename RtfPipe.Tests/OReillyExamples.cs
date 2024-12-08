using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RtfPipe.Tests
{
  /// <summary>
  /// Examples taken from https://www.safaribooksonline.com/library/view/rtf-pocket-guide/9781449302047/ch01.html
  /// </summary>
  [TestClass]
  public class OReillyExamples
  {
    [TestMethod()]
    public void HelloWorld()
    {
      this.VerifyCurrentLegacyScenario(@"{\rtf1\ansi\deff0 {\fonttbl {\f0 Times New Roman;}}
\f0\fs60 Hello, World!
}");
    }

    [TestMethod()]
    public void HelloWorld_Centered()
    {
      this.VerifyCurrentLegacyScenario(@"{\rtf1\ansi\deff0 {\fonttbl {\f0 Monotype Corsiva;}}
\qc\f0\fs120\i\b Hello,\line World!
}");
    }

    [TestMethod()]
    public void HelloWorld_XElement()
    {
      var rtf = @"{\rtf1\ansi\deff0 {\fonttbl {\f0 Monotype Corsiva;}}
\qc\f0\fs120\i\b Hello,\line World!
}";
      var doc = new XDocument();
      using (var writer = doc.CreateWriter())
      {
        Rtf.ToHtml(rtf, writer);
      }
      Assert.AreEqual(@"<div style=""font-size:12pt;font-family:&quot;Monotype Corsiva&quot;;"">
  <p style=""text-align:center;font-size:60pt;margin:0;"">
    <strong>
      <em>Hello,<br />World!</em>
    </strong>
  </p>
</div>", doc.Root.ToString());
    }
  }
}
