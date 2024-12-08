using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using AngleSharp.Html;
using AngleSharp.Html.Parser;
using SmartAnalyzers.ApprovalTestsExtensions;

namespace RtfPipe.Tests;

public static class TestExtension
{
  public static void VerifyCurrentScenario(this object testClass, [CallerFilePath] string currentTestFile = "",
    [CallerMemberName] string testMethodName = "")
  {
    var inputPayload = ReadInputRtfPayload(currentTestFile, testMethodName);
    var transformResult = Rtf.ToHtml(inputPayload);
    var formattedOutput = FormatHtml(transformResult);
    var approver = new ExplicitApprover(currentTestFile, testMethodName);
    approver.VerifyText(formattedOutput, "html");
  }
  
  public static void VerifyCurrentLegacyScenario(this object testClass, string inputRtf,
    RtfHtmlSettings settings = null, [CallerFilePath] string currentTestFile = "",
    [CallerMemberName] string testMethodName = "")
  {
    var transformResult = Rtf.ToHtml(inputRtf, settings ?? new RtfHtmlSettings());
    var formattedOutput = FormatHtml(transformResult);
    var approver = new ExplicitApprover(currentTestFile, testMethodName);
    approver.VerifyText(formattedOutput, "html");
  }

  private static string ReadInputRtfPayload(string currentTestFile, string testMethodName)
  {
    var inputFileName = GenerateFileName(currentTestFile, testMethodName, "input.rtf");
    if (File.Exists(inputFileName) == false)
    {
      File.WriteAllText(inputFileName, "", Encoding.UTF8);
      throw new InvalidOperationException("Missing input data");
    }

    var inputPayload = File.ReadAllText(inputFileName);
    if (string.IsNullOrWhiteSpace(inputPayload))
    {
      throw new InvalidOperationException("Missing input data");
    }

    return inputPayload;
  }

  private static string GenerateFileName(string currentTestFile, string testMethodName, string suffix)
  {
    var className = Path.GetFileNameWithoutExtension(currentTestFile);
    var directory = Path.GetDirectoryName(currentTestFile)!;
    var inputFileName = Path.Combine(directory, $"{className}.{testMethodName}.{suffix}");
    return inputFileName;
  }

  private static string FormatHtml(string transformResult)
  {
    var sb = new StringBuilder();
    var intd = -1;
    foreach (var line in transformResult.Replace("<", "\r\n<").Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
    {
      if (line.StartsWith("<") && line.StartsWith("</") == false)
      {
        intd++;
      }
      sb.AppendLine(" ".PadLeft(Math.Max(intd,0) * 4) + line);
      if(line.Contains("/>") || line.Contains("</"))
      {
        intd--;
      }
    }

    return sb.ToString().Trim();
  }
}
