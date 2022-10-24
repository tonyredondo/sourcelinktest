// See https://aka.ms/new-console-template for more information

using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var assemblyAttributes = assembly.GetCustomAttributes();
foreach (var attr in assemblyAttributes)
{
    Console.WriteLine(attr.ToString());
}