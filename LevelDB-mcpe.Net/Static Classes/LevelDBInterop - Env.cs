using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    public static partial class LevelDBInterop {

        #region Env
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_default_env();

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_env_destroy(IntPtr /*Env*/ cache);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_filterpolicy_create_bloom(Int32 bits_per_key);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_filterpolicy_destroy(IntPtr /*leveldb_filterpolicy_t*/ policy);
        #endregion
    }
}
