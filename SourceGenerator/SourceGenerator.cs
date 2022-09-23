using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
#if DEBUG && GENERATOR_DEBUG
using System.Diagnostics;
#endif
using System.Linq;
using System.Text;

namespace ContentSecurityPolicy.AspNetCore;

[Generator]
internal class SourceGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
#if DEBUG && GENERATOR_DEBUG
        if (!Debugger.IsAttached)
        {
            Debugger.Launch();
        }
#endif

        context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
    }


    private readonly string[] _policyOptionAdditionalAttributes = { "AddNone", "AddReportSample", "AddScript", "AddSelf", "AddStrictDynamic", "AddUnsafeEval", "AddUnsafeHashes", "AddUnsafeInline" };


    public void Execute(GeneratorExecutionContext context)
    {
        Extensions.LinesGenerated = 0;

        // retreive the populated receiver 
        if (context.SyntaxReceiver is not SyntaxReceiver receiver)
        {
            return;
        }
        
        // we're going to create a new compilation that contains the attribute.
        // TODO: we should allow source generators to provide source during initialize, so that this step isn't required.
        //CSharpParseOptions options = (context.Compilation as CSharpCompilation).SyntaxTrees[0].Options as CSharpParseOptions;
        Compilation compilation = context.Compilation;

        List<INamedTypeSymbol> policyClasseSymbols = new();
        INamedTypeSymbol cspOptionsClassSymbol = null;

        foreach (var classNode in receiver.Classes)
        {
            var modifiers = classNode.Modifiers.Select(m => m.Text).ToList();
            SemanticModel classModel = compilation.GetSemanticModel(classNode.SyntaxTree);
            INamedTypeSymbol classSymbol = classModel.GetDeclaredSymbol(classNode);

            if (GetClassTypeName(classSymbol) == "ContentSecurityPolicyOptions")
            {
                cspOptionsClassSymbol = classSymbol;
            }
            else
            {
                StringBuilder sb = new();

                sb.AppendLinesIndented(0, "using System;");
                sb.AppendLinesIndented(0, "using System.Linq;");
                sb.AppendLinesIndented(0, "");
                sb.AppendLinesIndented(0, $"namespace ContentSecurityPolicy.AspNetCore;");
                sb.AppendLinesIndented(0, "");
                sb.AppendLinesIndented(0, $"public sealed partial class {GetClassTypeName(classSymbol)} : {GetClassBaseTypeName(classSymbol)}");
                sb.AppendLinesIndented(0, "{");

                var codeAdded = false;

                codeAdded = ProcessPolicyAttribute(classSymbol, sb, codeAdded);

                codeAdded = ProcessPolicyOptionsAttribute(classSymbol, sb, codeAdded);

                foreach (var additionalAtributeName in _policyOptionAdditionalAttributes)
                {
                    codeAdded = ProcessAdditionalPolicyOptionsAttribute(classSymbol, additionalAtributeName, sb, codeAdded);
                }

                codeAdded = ProcessGroupNamePolicyOptionsAttribute(classSymbol, sb, codeAdded);
                codeAdded = ProcessHashValuePolicyOptionsAttribute(classSymbol, sb, codeAdded);
                codeAdded = ProcessHostSourcePolicyOptionsAttribute(classSymbol, sb, codeAdded);
                codeAdded = ProcessNoncePolicyOptionsAttribute(classSymbol, sb, codeAdded);
                codeAdded = ProcessPolicyNamePolicyOptionsAttribute(classSymbol, sb, codeAdded);
                codeAdded = ProcessSchemeSourcePolicyOptionsAttribute(classSymbol, sb, codeAdded);
                codeAdded = ProcessUriPolicyOptionsAttribute(classSymbol, sb, codeAdded);

                sb.AppendLinesIndented(0, "}");

                if (codeAdded)
                {
                    if (!GetClassTypeName(classSymbol).Contains("Options"))
                    {
                        policyClasseSymbols.Add(classSymbol);
                    }

                    context.AddSource($"{GetClassTypeName(classSymbol, true)}.AddedFunctions.g.cs", sb.ToString());
                }
            }
        }

        context.AddSource($"{GetClassTypeName(cspOptionsClassSymbol, true)}.AddedFunctions.g.cs", ProcessContentSecurityPolicyOptions(cspOptionsClassSymbol, policyClasseSymbols).ToString());
    }


    private StringBuilder ProcessContentSecurityPolicyOptions(INamedTypeSymbol cspOptionsClassSymbol, List<INamedTypeSymbol> policyClassSymbols)
    {
        StringBuilder sb = new();
        var isFirst = true;

        sb.AppendLinesIndented(0, "using System;");
        sb.AppendLinesIndented(0, "using System.Linq;");
        sb.AppendLinesIndented(0, "");
        sb.AppendLinesIndented(0, $"namespace ContentSecurityPolicy.AspNetCore;");
        sb.AppendLinesIndented(0, "");
        sb.AppendLinesIndented(0, $"public sealed partial class {GetClassTypeName(cspOptionsClassSymbol)}");
        sb.AppendLinesIndented(0, "{");

        foreach (var policyClassSymbol in policyClassSymbols.OrderBy(x => x.Name))
        {
            var attribute = policyClassSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"PolicyAttribute").FirstOrDefault();
            var cspPolicyName = attribute.ConstructorArguments.FirstOrDefault().Value;
            var policyClassTypeName = GetClassTypeName(policyClassSymbol);

            if (!isFirst)
            {
                sb.AppendLinesIndented(1, "");
                sb.AppendLinesIndented(1, "");
            }

            isFirst = false;

            sb.AppendLinesIndented(1, "/// <summary>");
            sb.AppendLinesIndented(1, $"/// Adds a {cspPolicyName} policy.");
            sb.AppendLinesIndented(1, "/// </summary>");
            sb.AppendLinesIndented(1, "/// <param name=\"configureOptions\">Configures policy options</param>");
            sb.AppendLinesIndented(1, "/// <returns></returns>");
            sb.AppendLinesIndented(1, $"public ContentSecurityPolicyOptions Add{policyClassTypeName}(Action<{policyClassTypeName}Options> configureOptions)");
            sb.AppendLinesIndented(1, "{");
            sb.AppendLinesIndented(2, "PolicyString = string.Empty;");
            sb.AppendLinesIndented(2, "");
            sb.AppendLinesIndented(2, $"Policies.Add(new {policyClassTypeName}(\"nonce\", configureOptions));");
            sb.AppendLinesIndented(2, "");
            sb.AppendLinesIndented(2, "return this;");
            sb.AppendLinesIndented(1, "}");
        }

        sb.AppendLinesIndented(0, "}");

        return sb;
    }


    private bool ProcessPolicyAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"PolicyAttribute").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        var policyName = attribute.ConstructorArguments.FirstOrDefault().Value;

        sb.AppendLinesIndented(1, "/// <inheritdoc/>");
        sb.AppendLinesIndented(1, $"private protected override string PolicyName => \"{policyName}\";");

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, $"private {GetClassTypeName(classSymbol)}Options Options {{ get; set; }}");

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)}(string nonceValue, Action<{GetClassTypeName(classSymbol)}Options> configureOptions)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "Options = new(nonceValue);");
        sb.AppendLinesIndented(2, "configureOptions.Invoke(Options);");
        sb.AppendLinesIndented(1, "}");

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "/// <inheritdoc />");
        sb.AppendLinesIndented(1, $"public override string GetPolicyValue()");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "return Options.PolicyValues.Any() ? $\"{PolicyName} {string.Join(' ', Options.PolicyValues)};\" : $\"{PolicyName}\";");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessPolicyOptionsAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"PolicyOptionsAttribute").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)}(string nonceValue)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "NonceValue = nonceValue;");
        sb.AppendLinesIndented(1, "}");

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, "/// Adds a policy value.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <param name=\"value\">The value to be added to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"private {GetClassTypeName(classSymbol)} AddValue(string value)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "PolicyValues.Add(value);");
        sb.AppendLinesIndented(2, "return this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessAdditionalPolicyOptionsAttribute(INamedTypeSymbol classSymbol, string attributeName, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"{GetLongAttributeName(attributeName)}").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        var policyValue = (attribute.AttributeClass.GetMembers().Where(x => x.Name == "PolicyValue").FirstOrDefault() as IFieldSymbol).ConstantValue;

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Adds {policyValue} to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} {attributeName}()");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return AddValue(\"{policyValue}\");");
        sb.AppendLinesIndented(1, "}");



        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Conditionally adds {policyValue} to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, $"/// <param name=\"conditionalFunc\">The conditional function delegate determining whether to add {policyValue} to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} {attributeName}If(Func<bool> conditionalFunc)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return conditionalFunc.Invoke() ? {attributeName}() : this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessGroupNamePolicyOptionsAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"{GetLongAttributeName("AddGroupName")}").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Adds a group name to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddGroupName(string groupName)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "return AddValue(groupName);");
        sb.AppendLinesIndented(1, "}");



        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Conditionally adds a group name to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, $"/// <param name=\"conditionalFunc\">The conditional function delegate determining whether to add the nonce to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddGroupNameIf(string groupName, Func<bool> conditionalFunc)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return conditionalFunc.Invoke() ? AddGroupName(groupName) : this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessHashValuePolicyOptionsAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"{GetLongAttributeName("AddHashValue")}").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Adds a hash value to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddHashValue(HashAlgorithm hashAlgorithm, string hashValue)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "return AddValue($\"'{hashAlgorithm.ToString().ToLower()}-{hashValue}'\");");
        sb.AppendLinesIndented(1, "}");



        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Conditionally adds a hash value to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, $"/// <param name=\"conditionalFunc\">The conditional function delegate determining whether to add the nonce to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddHashValueIf(HashAlgorithm hashAlgorithm, string hashValue, Func<bool> conditionalFunc)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return conditionalFunc.Invoke() ? AddHashValue(hashAlgorithm, hashValue) : this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessHostSourcePolicyOptionsAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"{GetLongAttributeName("AddHostSourceValue")}").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Adds a host source value to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddHostSource(string hostSourceValue)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "return AddValue($\"'{hostSourceValue}'\");");
        sb.AppendLinesIndented(1, "}");



        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Conditionally adds a host source value to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, $"/// <param name=\"conditionalFunc\">The conditional function delegate determining whether to add the nonce to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddHostSourceIf(string hostSourceValue, Func<bool> conditionalFunc)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return conditionalFunc.Invoke() ? AddHostSource(hostSourceValue) : this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessNoncePolicyOptionsAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"{GetLongAttributeName("AddNonce")}").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Adds a nonce to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddNonce()");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "return AddValue($\"'nonce-{NonceValue}'\");");
        sb.AppendLinesIndented(1, "}");



        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Conditionally adds a nonce to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, $"/// <param name=\"conditionalFunc\">The conditional function delegate determining whether to add the nonce to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddNonceIf(Func<bool> conditionalFunc)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return conditionalFunc.Invoke() ? AddNonce() : this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessPolicyNamePolicyOptionsAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"{GetLongAttributeName("AddPolicyName")}").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Adds a policy name to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddPolicyName(string policyName)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "return AddValue(policyName);");
        sb.AppendLinesIndented(1, "}");



        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Conditionally adds a policy name to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, $"/// <param name=\"conditionalFunc\">The conditional function delegate determining whether to add the nonce to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddPolicyNameIf(string policyName, Func<bool> conditionalFunc)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return conditionalFunc.Invoke() ? AddPolicyName(policyName) : this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessSchemeSourcePolicyOptionsAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"{GetLongAttributeName("AddSchemeSource")}").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Adds a scheme source to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddSchemeSource(SchemeSource schemeSource)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "return AddValue($\"{schemeSource.ToString().ToLower()}:\");");
        sb.AppendLinesIndented(1, "}");



        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Conditionally adds a scheme source to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, $"/// <param name=\"conditionalFunc\">The conditional function delegate determining whether to add the nonce to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddSchemeSourceIf(SchemeSource schemeSource, Func<bool> conditionalFunc)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return conditionalFunc.Invoke() ? AddSchemeSource(schemeSource) : this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    private bool ProcessUriPolicyOptionsAttribute(INamedTypeSymbol classSymbol, StringBuilder sb, bool codeAdded)
    {
        var attribute = classSymbol.GetAttributes().Where(ad => ad.AttributeClass.Name == $"{GetLongAttributeName("AddUri")}").FirstOrDefault();

        if (attribute == default)
        {
            return codeAdded;
        }

        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Adds a uri to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddUri(string uri)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, "return AddValue(uri);");
        sb.AppendLinesIndented(1, "}");



        sb.AppendLinesIndented(1, "");
        sb.AppendLinesIndented(1, "");

        sb.AppendLinesIndented(1, "/// <summary>");
        sb.AppendLinesIndented(1, $"/// Conditionally adds a uri to the policy.");
        sb.AppendLinesIndented(1, "/// </summary>");
        sb.AppendLinesIndented(1, $"/// <param name=\"conditionalFunc\">The conditional function delegate determining whether to add the nonce to the policy</param>");
        sb.AppendLinesIndented(1, "/// <returns></returns>");
        sb.AppendLinesIndented(1, $"public {GetClassTypeName(classSymbol)} AddUriIf(string uri, Func<bool> conditionalFunc)");
        sb.AppendLinesIndented(1, "{");
        sb.AppendLinesIndented(2, $"return conditionalFunc.Invoke() ? AddUri(uri) : this;");
        sb.AppendLinesIndented(1, "}");

        return true;
    }


    /// <summary>
    /// Created on demand before each generation pass
    /// </summary>
    class SyntaxReceiver : ISyntaxReceiver
    {
        ///// <summary>
        ///// Dictionary keyed by class nodes that have a ViewModelRecord attribute and with value being a list of
        ///// properties with the ViewModelProperty attribute in that record.
        ///// </summary>
        //public readonly Dictionary<ClassDeclarationSyntax, List<PropertyDeclarationSyntax>> ClassNodes = new();


        /// <summary>
        /// List of classes with the ViewModelRecord attribute. Diagnostic reporting will be created for these classes
        /// because the attribute is for partial records only.
        /// </summary>
        public readonly List<ClassDeclarationSyntax> Classes = new();


        /// <summary>
        /// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
        /// </summary>
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            // any field with at least one attribute is a candidate for property generation
            if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax)
            {
                Classes.Add(classDeclarationSyntax);
            }
        }
    }


    private static string GetClassTypeName(INamedTypeSymbol classSymbol, bool suppressGeneric = false)
    {
        if (suppressGeneric)
        {
            return classSymbol.Name;
        }

        return classSymbol.ConstructedFrom.ToString().Substring(classSymbol.ConstructedFrom.ToString().IndexOf(classSymbol.Name));
    }


    public static string GetClassBaseTypeName(INamedTypeSymbol classSymbol)
    {
        if (classSymbol.BaseType.ToString() == "object")
        {
            return "";
        }

        var namespacePrefix = classSymbol.BaseType.ToString().Substring(0, classSymbol.BaseType.ToString().IndexOf(classSymbol.BaseType.Name));
        return classSymbol.BaseType.ToString().Replace(namespacePrefix, "");
    }


    private static string GetLongAttributeName(string shortAttributeName)
    {
        return shortAttributeName + "Attribute";
    }
}
