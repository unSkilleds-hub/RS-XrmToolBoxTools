using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using XrmToolBox.Forms;

namespace RS_Security_Center
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "RS Security Center"),
        ExportMetadata("Description", "Manage your users security roles"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}