using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAllFrameworkInVisualStudioSolution
{
  internal class Program
  {
    static void Main(string[] arguments)
    {
      // findstr /s "TargetFrameworkVersion" *.csproj
      // cmd in visual studio solution directory under DOS
      Action<string> Display = Console.WriteLine;
      Display("List all framework versions in a Visual Studio Solution");
      var solutionPath = ".";
      var projectSuffix = "csproj,vbproj";
      if (arguments.Length > 0)
      {
        solutionPath = arguments[0];
      }

      Display(solutionPath);
      // get all csproj and vbproj



      Display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
