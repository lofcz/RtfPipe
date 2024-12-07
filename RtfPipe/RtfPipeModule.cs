using System.Runtime.CompilerServices;
using System.Text;


namespace System.Runtime.CompilerServices
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
  internal sealed class ModuleInitializerAttribute : Attribute
  {
  }
}

namespace RtfPipe
{
  internal static class RtfPipeModule
  {
    [ModuleInitializer]
    internal static void Init()
    {
      Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
  }
}
