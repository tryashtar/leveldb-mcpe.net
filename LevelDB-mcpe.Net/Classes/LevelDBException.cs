using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LevelDBException : Exception {
        public LevelDBException(String message) : base(message) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
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
