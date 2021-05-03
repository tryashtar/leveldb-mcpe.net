using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    public static partial class LevelDBInterop {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_destroy(IntPtr /*Iterator*/ iterator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Byte leveldb_iter_valid(IntPtr /*Iterator*/ iterator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek_to_first(IntPtr /*Iterator*/ iterator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek_to_last(IntPtr /*Iterator*/ iterator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="key"></param>
        /// <param name="length"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek(IntPtr /*Iterator*/ iterator, Byte[] key, IntPtr length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_next(IntPtr /*Iterator*/ iterator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_prev(IntPtr /*Iterator*/ iterator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_iter_key(IntPtr /*Iterator*/ iterator, out IntPtr length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_iter_value(IntPtr /*Iterator*/ iterator, out IntPtr length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="error"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_get_error(IntPtr /*Iterator*/ iterator, out IntPtr error);
    }
}
