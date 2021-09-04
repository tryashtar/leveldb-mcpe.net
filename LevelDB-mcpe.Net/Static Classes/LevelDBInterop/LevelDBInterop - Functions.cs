using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    public static partial class LevelDBInterop {
        ///DOLATER <summary>Add Description</summary>
        /// <param name="left">FILL IN</param>
        /// <param name="right">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        internal static Boolean BuffersEqual(Byte[] left, Byte[] right) {
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

        ///DOLATER <summary>Add Description</summary>
        /// <param name="lpFileName">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr LoadLibrary(String lpFileName);
    }
}
