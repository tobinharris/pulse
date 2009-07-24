using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Pulse.Emmiters.DotNet.Application
{
    internal class RegisteredAssemblies
    {
        private static Nested _instance = new Nested();

        public static List<Assembly> Assemblies
        {
            get { return _instance.Assemblies; }
        }

        #region Nested type: Nested

        internal class Nested
        {
            [CompilerGenerated] private List<Assembly> _assemblies;

            internal Nested()
            {
                Assemblies = new List<Assembly>();
                var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", ""));
                foreach (FileInfo assembly in fileInfo.Directory.GetFiles("*.dll"))
                {
                    Assemblies.Add(Assembly.LoadFile(assembly.FullName));
                }
            }

            public List<Assembly> Assemblies
            {
                [CompilerGenerated]
                get { return _assemblies; }
                [CompilerGenerated]
                set { _assemblies = value; }
            }
        }

        #endregion
    }
}