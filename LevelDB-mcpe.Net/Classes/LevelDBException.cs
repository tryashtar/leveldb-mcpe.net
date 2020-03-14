using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    public class LevelDBException : Exception {
        public LevelDBException(String message) : base(message) { }

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
