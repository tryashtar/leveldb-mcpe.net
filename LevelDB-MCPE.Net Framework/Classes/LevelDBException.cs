using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LevelDBException : Exception {
        /// <summary> </summary>
        /// <param name="message"></param>
        public LevelDBException(String message) : base(message) { }

        ///DOLATER <summary>Add Description</summary>
        /// <param name="error">FILL IN</param>
        public static void Check(IntPtr error) {
            if (error != IntPtr.Zero) {
                try {
                    String message = Marshal.PtrToStringAnsi(error);
                    throw new LevelDBException(message);
                }
                finally {
                    LevelDBInterop.leveldb_free(error);
                }
            }
        }
    }
}
