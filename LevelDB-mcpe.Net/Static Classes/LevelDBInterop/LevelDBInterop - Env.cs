using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    public static partial class LevelDBInterop {

        #region Env
        /// <summary>Creates the new default enviroment for leveldb</summary>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_create_default_env();

        /// <summary>Destroys the given enviroment</summary>
        /// <param name="cache"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_env_destroy(IntPtr /*Env*/ cache);

        /// <summary>Creates a filter policy</summary>
        /// <param name="bits_per_key"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_filterpolicy_create_bloom(Int32 bits_per_key);

        /// <summary>Destroys a filter policy</summary>
        /// <param name="policy"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_filterpolicy_destroy(IntPtr /*leveldb_filterpolicy_t*/ policy);
        #endregion
    }
}
