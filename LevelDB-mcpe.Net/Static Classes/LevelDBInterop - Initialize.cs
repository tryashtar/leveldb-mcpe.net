using System;
using System.IO;
using System.Reflection;

namespace LevelDB {
    public static partial class LevelDBInterop {
        /// <summary>
        /// 
        /// </summary>
        static LevelDBInterop() {
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Library provide should be the same platform/archetecture
            String folder = Path.GetDirectoryName(assembly.Location);
            String path = Path.Combine(folder, "LevelDB-MCPE.dll");

            IntPtr h = LoadLibrary(path);
            if (h == IntPtr.Zero) {
                throw new ApplicationException("Cannot load LevelDB-MCPE.dll");
            }
        }
    }
}
