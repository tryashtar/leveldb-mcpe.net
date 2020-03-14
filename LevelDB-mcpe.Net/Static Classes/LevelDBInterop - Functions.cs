using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    public static partial class LevelDBInterop {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static Boolean BuffersEqual(Byte[] left, Byte[] right) {
            if (left.Length != right.Length) {
                return false;
            }

            for (Int32 i = 0; i < left.Length; ++i) {
                if (left[i] != right[i]) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <returns></returns>

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(String lpFileName);
    }
}
