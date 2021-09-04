using System;
using System.Runtime.InteropServices;

namespace LevelDB {
    public static partial class LevelDBInterop {

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options"><see cref="Options"/> pointer</param>
        /// <param name="name">The name of the instance</param>
        /// <param name="error">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        //DO NOT USE CharSet.Unicode, C++ is UTF8 which is 1 Byte big and not two
        internal static extern IntPtr leveldb_open(IntPtr /* Options*/ options, String name, out IntPtr error);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_close(IntPtr /*DB */ db);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="options"><see cref="Options"/> pointer</param>
        /// <param name="key">FILL IN</param>
        /// <param name="keylen">FILL IN</param>
        /// <param name="val">FILL IN</param>
        /// <param name="vallen">FILL IN</param>
        /// <param name="errptr">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_put(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, Byte[] key, IntPtr keylen, Byte[] val, IntPtr vallen, out IntPtr errptr);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="options"><see cref="Options"/> pointer</param>
        /// <param name="key">FILL IN</param>
        /// <param name="keylen">FILL IN</param>
        /// <param name="errptr">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_delete(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, Byte[] key, IntPtr keylen, out IntPtr errptr);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="options"><see cref="Options"/> pointer</param>
        /// <param name="batch">FILL IN</param>
        /// <param name="errptr">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_write(IntPtr db, IntPtr /* WriteOptions*/ options, IntPtr /* WriteBatch */ batch, out IntPtr errptr);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="options"><see cref="Options"/> pointer</param>
        /// <param name="key">FILL IN</param>
        /// <param name="keylen">FILL IN</param>
        /// <param name="vallen">FILL IN</param>
        /// <param name="errptr">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_get(IntPtr /* DB */ db, IntPtr /* ReadOptions*/ options, Byte[] key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="options"><see cref="Options"/> pointer</param>
        /// <param name="key">FILL IN</param>
        /// <param name="keylen">FILL IN</param>
        /// <param name="vallen">FILL IN</param>
        /// <param name="errptr">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_get(IntPtr /* DB */ db, IntPtr /* ReadOptions*/ options, IntPtr key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="num_ranges">FILL IN</param>
        /// <param name="startKeys">FILL IN</param>
        /// <param name="startKeysLens">FILL IN</param>
        /// <param name="limitKeys">FILL IN</param>
        /// <param name="limitKeysLens">FILL IN</param>
        /// <param name="sizeList">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_approximate_sizes(IntPtr /* DB */ db, Int32 num_ranges,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))] Byte[][] startKeys,
            IntPtr[] startKeysLens,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))] Byte[][] limitKeys,
            IntPtr[] limitKeysLens,
            [In, Out] Int64[] sizeList);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="options"><see cref="Options"/> pointer</param>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_create_iterator(IntPtr /* DB */ db, IntPtr /* ReadOption */ options);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_create_snapshot(IntPtr /* DB */ db);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="snapshot">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_release_snapshot(IntPtr db, IntPtr /* SnapShot*/ snapshot);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="propname">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        internal static extern IntPtr leveldb_property_value(IntPtr db, String propname);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options"><see cref="Options"/> pointer</param>
        /// <param name="name">The name of the instance</param>
        /// <param name="error">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        internal static extern void leveldb_repair_db(IntPtr options, String name, out IntPtr error);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options"><see cref="Options"/> pointer</param>
        /// <param name="name">The name of the instance</param>
        /// <param name="error">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        internal static extern void leveldb_destroy_db(IntPtr options, String name, out IntPtr error);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="db"><see cref="DB"/> Pointer</param>
        /// <param name="startKey">FILL IN</param>
        /// <param name="startKeyLen">FILL IN</param>
        /// <param name="limitKey">FILL IN</param>
        /// <param name="limitKeyLen">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_compact_range(IntPtr db, Byte[] startKey, IntPtr startKeyLen, Byte[] limitKey, IntPtr limitKeyLen);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="ptr">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_free(IntPtr /* void */ ptr);
    }
}
