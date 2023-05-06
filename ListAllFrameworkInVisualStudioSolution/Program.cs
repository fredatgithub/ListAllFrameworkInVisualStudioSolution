using System;
using System.Collections.Generic;
using System.IO;

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
      var solutionPath = "..\\..";
      var projectSuffix = "csproj,vbproj";
      if (arguments.Length > 0)
      {
        solutionPath = arguments[0];
      }

      Display(solutionPath);
      // get all csproj and vbproj
      string pattern = "*.csproj";
      string keyword = "TargetFrameworkVersion";
      var result = new List<string>();
      foreach (var file in Directory.GetFiles(solutionPath, pattern))
      {
        result.Add($"{Path.GetFileName(file)} is in Framework {SearchFile(keyword, file).Replace(keyword, "").Replace("<", "").Replace(">", "").Replace("/", "").Replace(" ", "")}");
      }

      foreach (var item in result)
      {
        Display(item);
      }

      Display("Press any key to exit:");
      Console.ReadKey();
    }

    private static string SearchFile(string keywordToSearch, string filename)
    {
      var result = string.Empty;
      try
      {
        using (var sr = new StreamReader(filename))
        {
          var line = string.Empty;
          do
          {
            line = sr.ReadLine();
            if ( line != null && line.Contains(keywordToSearch))
            {
              result = line;
            }
          }
          while (!(line is null));
        }
      }
      catch (Exception)
      {
      }

      return result;
    }
  }
}
