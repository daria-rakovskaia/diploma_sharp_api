using diploma_sharp_api.AnalysisModels;
using diploma_sharp_api.Services.AnalysisService;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public class AnalysisService : IAnalysisService
{
    private readonly List<MetadataReference> _defaultReferences;

    private string FormatCode(string code)
    { return code.Replace("\\n", "\n"); }

    public AnalysisService()
    {
        var trustedAssembliesRaw = AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") as string;
        if (string.IsNullOrWhiteSpace(trustedAssembliesRaw))
        {
            throw new InvalidOperationException("TRUSTED_PLATFORM_ASSEMBLIES not found in AppContext.");
        }
        _defaultReferences = trustedAssembliesRaw
            .Split(Path.PathSeparator)
            .Where(path => path.EndsWith("System.Runtime.dll") ||
                           path.EndsWith("mscorlib.dll") ||
                           path.EndsWith("System.Console.dll") ||
                           path.EndsWith("System.Private.CoreLib.dll") ||
                           path.EndsWith("System.Linq.dll") ||
                           path.EndsWith("System.Collections.dll") ||
                           path.EndsWith("System.Runtime.Extensions.dll") ||
                           path.EndsWith("netstandard.dll"))
            .Select(path => (MetadataReference)MetadataReference.CreateFromFile(path))
            .ToList();
    }

    public CodeAnalysisResult AnalyzeCode(string code)
    {
        code = FormatCode(code);
        var result = new CodeAnalysisResult();
        var syntaxTree = CSharpSyntaxTree.ParseText(code);
        var compilation = CSharpCompilation.Create( // создаёт объект компиляции
            "StaticCodeAnalysis", // имя сборки
            new[] { syntaxTree }, // синтаксическое дерево (исходный код)
            _defaultReferences, // базовые библиотеки
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        var diagnostics = compilation.GetDiagnostics(); // сбор базовых ошибок
        foreach (var diagnostic in diagnostics)
        {
            if (diagnostic.Severity == DiagnosticSeverity.Error || diagnostic.Severity == DiagnosticSeverity.Warning)
            {
                var lineSpan = diagnostic.Location.GetLineSpan();
                result.Errors.Add(new CodeIssue
                {
                    Id = diagnostic.Id,
                    Message = diagnostic.GetMessage(),
                    Severity = diagnostic.Severity.ToString(),
                    Line = lineSpan.StartLinePosition.Line + 1,
                    Column = lineSpan.StartLinePosition.Character + 1
                });
            }
        }
        return result;
    }
}
