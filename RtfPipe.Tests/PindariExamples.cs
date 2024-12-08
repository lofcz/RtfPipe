using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtfPipe.Tests
{
  /// <summary>
  /// Adapted from http://www.pindari.com/
  /// </summary>
  [TestClass()]
  public class PindariExamples
  {
    [TestMethod()]
    public void Pindari_Colors()
    {
      this.VerifyCurrentLegacyScenario(@"{\rtf1\ansi\deff0
{\colortbl;\red0\green0\blue0;\red255\green0\blue0;}
This line is the default color\line
\cf2
This line is red\line
\cf1
This line is the default color
}");
    }

    [TestMethod()]
    public void Pindari_DefaultTabs()
    {
      this.VerifyCurrentLegacyScenario(@"{\rtf1\ansi\deff0 {\fonttbl {\f0 Courier;}}
{\colortbl;\red0\green0\blue0;\red255\green0\blue0;}
This line is the default color\line
\cf2
\tab This line is red and has a tab before it\line
\cf1
\page This line is the default color and the first line on page 2
}
");
    }


    [TestMethod()]
    public void Pindari_Tabs()
    {
      this.VerifyCurrentLegacyScenario(@"{\rtf1\ansi\deff0 {\fonttbl {\f0 Courier;}}
{\colortbl;\red0\green0\blue0;\red255\green0\blue0;}
\tx720\tx1440\tx2880\tx5760
This line is the default color\line
\tab this line has 1 tab\line
\tab\tab this line has 2 tabs\line
\tab\tab\tab this line has 3 tabs\line
\tab\tab\tab\tab this line has 4 tabs\line
\cf2
\tab This line is red and has a tab before it\line
\cf1
\page This line is the default color and the first line on page 2
}");
    }

    [TestMethod()]
    public void Pindari_Formatting()
    {
      this.VerifyCurrentLegacyScenario(@"{\rtf1\ansi\deff0 {\fonttbl {\f0 Courier;}}
{\colortbl;\red0\green0\blue0;\red255\green0\blue0;}
\landscape
\paperw15840\paperh12240\margl720\margr720\margt720\margb720
\tx720\tx1440\tx2880\tx5760
This line is the default color\line
\tab this line has 1 tab\line
\tab\tab this line has 2 tabs\line
\tab\tab\tab this line has 3 tabs\line
\tab\tab\tab\tab this line has 4 tabs\line
\cf2
\tab This line is red and has a tab before it\line
\cf1
\page
\par\pard\tx1440\tx2880
This line is the default color and the first line on page 2\line
\tab\tab This is the second tab on the second line on the second page\line
\page
\par\pard
This is the third page with formatting examples\line
\fs30 First line with 15 point text\line
\fs20 Second line with 10 point test\line
\i Italics on \i0 Italics off\line
\b Bold on \b0 Bold off\line
\scaps Small Caps On \scaps0 Small Caps Off\line
\strike Stike through on \strike0 Strike Off\line
\caps All Capitals On \caps0 All Capitals Off\line
\outl Outline on \outl0 Outline Off\line
\ul Underline on \ul0 Underline Off\line
\uldb Double Underline on \ul0 Double Underline Off\line
\ulth Thick Underline on \ul0 Thick Underline Off\line
\ulw Underline words only on \ul0 Underline words only off\line
\ulwave Wave Underline on \ul0 Wave underline off\line
\uld Dotted Underline on \ul0 Dotted underline off\line
\uldash Dash Underline on \ul0 Dash underline off\line
\uldashd Dot Dash Underline on \ul0 Dot Dash underline off\line
}
");
    }

    [TestMethod()]
    public void Pindari_Table()
    {
      this.VerifyCurrentLegacyScenario(@"{\rtf1\ansi\deff0
\trowd
\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs
\cellx1000
\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs
\cellx2000
\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs
\cellx3000
cell 1\intbl\cell
lots of text in cell two\intbl\cell
cell 3\intbl\cell
\row
}");
    }

    [TestMethod()]
    public void Pindari_Table_Borders()
    {
      this.VerifyCurrentLegacyScenario(@"{\rtf1\ansi\deff0
Below are the border types\line\par

\trowd\trgaph144
\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs
\cellx5000
Single border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrdot\clbrdrl\brdrdot\clbrdrb\brdrdot\clbrdrr\brdrdot
\cellx5000
Dotted border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrdb\clbrdrl\brdrdb\clbrdrb\brdrdb\clbrdrr\brdrdb
\cellx5000
Double thickness border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrdash\clbrdrl\brdrdash\clbrdrb\brdrdash\clbrdrr\brdrdash
\cellx5000
Dashed border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrdashsm\clbrdrl\brdrdashsm\clbrdrb\brdrdashsm\clbrdrr\brdrdashsm
\cellx5000
Small dashed border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrdashd\clbrdrl\brdrdashd\clbrdrb\brdrdashd\clbrdrr\brdrdashd
\cellx5000
Dot dash border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrdashdd\clbrdrl\brdrdashdd\clbrdrb\brdrdashdd\clbrdrr\brdrdashdd
\cellx5000
Dot dot dash border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrtriple\clbrdrl\brdrtriple\clbrdrb\brdrtriple\clbrdrr\brdrtriple
\cellx5000
Triple border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrtnthlg\clbrdrl\brdrtnthlg\clbrdrb\brdrthtnlg\clbrdrr\brdrthtnlg
\cellx5000
Thick thin border (large)\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrtnthlg\clbrdrl\brdrtnthlg\clbrdrb\brdrthtnlg\clbrdrr\brdrthtnlg
\cellx5000
Thin thick border (large)\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrtnthtnlg\clbrdrl\brdrtnthtnlg\clbrdrb\brdrtnthtnlg\clbrdrr\brdrtnthtnlg
\cellx5000
Thin thick thin border (large)\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrwavy\clbrdrl\brdrwavy\clbrdrb\brdrwavy\clbrdrr\brdrwavy
\cellx5000
Wavy border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrdashdotstr\clbrdrl\brdrdashdotstr\clbrdrb\brdrdashdotstr\clbrdrr\brdrdashdotstr
\cellx5000
Striped border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdremboss\clbrdrl\brdremboss\clbrdrb\brdrengrave\clbrdrr\brdrengrave
\cellx5000
Emboss border\intbl\cell
\row\pard\par

\trowd\trgaph144
\clbrdrt\brdrengrave\clbrdrl\brdrengrave\clbrdrb\brdremboss\clbrdrr\brdremboss
\cellx5000
Engrave border\intbl\cell
\row\pard\par

End of border types.
} ");
    }
  }
}
