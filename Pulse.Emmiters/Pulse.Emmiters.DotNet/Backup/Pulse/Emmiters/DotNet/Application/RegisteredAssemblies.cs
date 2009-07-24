namespace Pulse.Emmiters.DotNet.Application
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    internal class RegisteredAssemblies
    {
        private static Nested _instance = new Nested();

        public static List<Assembly> Assemblies
        {
            get
            {
                return _instance.Assemblies;
            }
        }

        internal class Nested
        {
            [CompilerGenerated]
            private List<Assembly> <Assemblies>k__BackingField;

            internal Nested()
            {
                this.Assemblies = new List<Assembly>();
                FileInfo fileInfo = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", ""));
                foreach (FileInfo assembly in fileInfo.Directory.GetFiles("*.dll"))
                {
                    this.Assemblies.Add(Assembly.LoadFile(assembly.FullName));
                }
            }

            public List<Assembly> Assemblies
            {
                [CompilerGenerated]
                get
                {
                    return this.<Assemblies>k__BackingField;
                }
                [CompilerGenerated]
                set
                {
                    this.<Assemblies>k__BackingField = value;
                }
            }
        }
    }
}

