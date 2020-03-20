using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

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

            if (File.Exists(path)) {
                IntPtr h = LoadLibrary(path);

                if (h == IntPtr.Zero) {
                    Int32 Value = Marshal.GetLastWin32Error();
                    throw new ApplicationException($"Cannot load LevelDB-MCPE.dll, Error Code: {Value}");
                }
            }
            else {
                throw new ApplicationException("Cannot find LevelDB-MCPE.dll");
            }
        }
    }
}
