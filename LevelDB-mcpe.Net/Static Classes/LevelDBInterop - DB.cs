using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    public static partial class LevelDBInterop {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="name"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_open(IntPtr /* Options*/ options, String name, out IntPtr error);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_close(IntPtr /*DB */ db);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="options"></param>
        /// <param name="key"></param>
        /// <param name="keylen"></param>
        /// <param name="val"></param>
        /// <param name="vallen"></param>
        /// <param name="errptr"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_put(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, Byte[] key, IntPtr keylen, Byte[] val, IntPtr vallen, out IntPtr errptr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="options"></param>
        /// <param name="key"></param>
        /// <param name="keylen"></param>
        /// <param name="errptr"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_delete(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, Byte[] key, IntPtr keylen, out IntPtr errptr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="options"></param>
        /// <param name="batch"></param>
        /// <param name="errptr"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_write(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, IntPtr /* WriteBatch */ batch, out IntPtr errptr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="options"></param>
        /// <param name="key"></param>
        /// <param name="keylen"></param>
        /// <param name="vallen"></param>
        /// <param name="errptr"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_get(IntPtr /* DB */ db, IntPtr /* ReadOptions*/ options, Byte[] key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="options"></param>
        /// <param name="key"></param>
        /// <param name="keylen"></param>
        /// <param name="vallen"></param>
        /// <param name="errptr"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_get(IntPtr /* DB */ db, IntPtr /* ReadOptions*/ options, IntPtr key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="num_ranges"></param>
        /// <param name="startKeys"></param>
        /// <param name="startKeysLens"></param>
        /// <param name="limitKeys"></param>
        /// <param name="limitKeysLens"></param>
        /// <param name="sizeList"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_approximate_sizes(IntPtr /* DB */ db, Int32 num_ranges,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))] Byte[][] startKeys,
            IntPtr[] startKeysLens,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))] Byte[][] limitKeys,
            IntPtr[] limitKeysLens,
            [In, Out] Int64[] sizeList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_iterator(IntPtr /* DB */ db, IntPtr /* ReadOption */ options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_snapshot(IntPtr /* DB */ db);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="snapshot"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_release_snapshot(IntPtr /* DB */ db, IntPtr /* SnapShot*/ snapshot);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="propname"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_property_value(IntPtr /* DB */ db, String propname);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="name"></param>
        /// <param name="error"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_repair_db(IntPtr /* Options*/ options, String name, out IntPtr error);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="name"></param>
        /// <param name="error"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_destroy_db(IntPtr /* Options*/ options, String name, out IntPtr error);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="startKey"></param>
        /// <param name="startKeyLen"></param>
        /// <param name="limitKey"></param>
        /// <param name="limitKeyLen"></param>
        [DllImport("leveldb", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_compact_range(IntPtr db, Byte[] startKey, IntPtr startKeyLen, Byte[] limitKey, IntPtr limitKeyLen);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_free(IntPtr /* void */ ptr);

    }
}
