using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1401 // P/Invokes should not be visible
namespace LevelDB {
    public static partial class LevelDBInterop {

        #region Options
        ///DOLATER <summary>Add Description</summary>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)] //This need unicode
        internal static extern IntPtr leveldb_options_create();

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_destroy(IntPtr /*Options*/ options);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="o">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_create_if_missing(IntPtr /*Options*/ options, Byte o);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="o">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_error_if_exists(IntPtr /*Options*/ options, Byte o);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="logger">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_info_log(IntPtr /*Options*/ options, IntPtr /* Logger */ logger);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="o">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_paranoid_checks(IntPtr /*Options*/ options, Byte o);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="env">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_env(IntPtr /*Options*/ options, IntPtr /*Env*/ env);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="size">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_write_buffer_size(IntPtr /*Options*/ options, Int64 size);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="max">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_max_open_files(IntPtr /*Options*/ options, Int32 max);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="cache">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_cache(IntPtr /*Options*/ options, IntPtr /*Cache*/ cache);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="size">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_block_size(IntPtr /*Options*/ options, Int64 size);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="interval">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_block_restart_interval(IntPtr /*Options*/ options, Int32 interval);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="level">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_compression(IntPtr /*Options*/ options, Int32 level);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="comparer">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_comparator(IntPtr /*Options*/ options, IntPtr /*Comparator*/ comparer);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="policy">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_filter_policy(IntPtr /*Options*/ options, IntPtr /*FilterPolicy*/ policy);
        #endregion

        #region ReadOptions
        ///DOLATER <summary>Add Description</summary>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_readoptions_create();

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_readoptions_destroy(IntPtr /*ReadOptions*/ options);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="o">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_readoptions_set_verify_checksums(IntPtr /*ReadOptions*/ options, Byte o);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="o">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_readoptions_set_fill_cache(IntPtr /*ReadOptions*/ options, Byte o);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="snapshot">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_readoptions_set_snapshot(IntPtr /*ReadOptions*/ options, IntPtr /*SnapShot*/ snapshot);
        #endregion

        #region WriteBatch
        ///DOLATER <summary>Add Description</summary>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_writebatch_create();

        ///DOLATER <summary>Add Description</summary>
        /// <param name="batch">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_destroy(IntPtr /* WriteBatch */ batch);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="batch">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_clear(IntPtr /* WriteBatch */ batch);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="batch">FILL IN</param>
        /// <param name="key">FILL IN</param>
        /// <param name="keylen">FILL IN</param>
        /// <param name="val">FILL IN</param>
        /// <param name="vallen">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_put(IntPtr /* WriteBatch */ batch, Byte[] key, IntPtr keylen, Byte[] val, IntPtr vallen);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="batch">FILL IN</param>
        /// <param name="key">FILL IN</param>
        /// <param name="keylen">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_delete(IntPtr /* WriteBatch */ batch, Byte[] key, IntPtr keylen);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="batch">FILL IN</param>
        /// <param name="state">FILL IN</param>
        /// <param name="put">FILL IN</param>
        /// <param name="deleted">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_iterate(IntPtr /* WriteBatch */ batch, IntPtr state, Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr> put, Action<IntPtr, IntPtr, IntPtr> deleted);
        #endregion

        #region WriteOptions
        ///DOLATER <summary>Add Description</summary>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_writeoptions_create();

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writeoptions_destroy(IntPtr /*WriteOptions*/ options);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="options">FILL IN</param>
        /// <param name="o">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writeoptions_set_sync(IntPtr /*WriteOptions*/ options, Byte o);
        #endregion

        #region Cache
        ///DOLATER <summary>Add Description</summary>
        /// <param name="capacity">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_cache_create_lru(IntPtr capacity);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="cache">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_cache_destroy(IntPtr /*Cache*/ cache);
        #endregion

        #region Comparator

        ///DOLATER <summary>Add Description</summary>
        /// <param name="state">FILL IN</param>
        /// <param name="destructor">FILL IN</param>
        /// <param name="compare">FILL IN</param>
        /// <param name="Name">The name of the instance</param>
        ///DOLATER <returns>Fill in return</returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr /* leveldb_comparator_t* */
            leveldb_comparator_create(
            IntPtr /* void* */ state,
            IntPtr /* void (*)(void*) */ destructor,
            IntPtr
                /* int (*compare)(void*,
                                  const char* a, size_t alen,
                                  const char* b, size_t blen) */
                compare,
            IntPtr /* const char* (*)(void*) */ name);

        ///DOLATER <summary>Add Description</summary>
        /// <param name="cmp">FILL IN</param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_comparator_destroy(IntPtr /* leveldb_comparator_t* */ cmp);

        #endregion

        #region Marshal

        ///DOLATER <summary>Add Description</summary>
        /// <param name="byteArray">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        internal static IntPtr MarshalSize(Byte[] byteArray) {
            return (IntPtr)(byteArray?.Length ?? 0);
        }

        ///DOLATER <summary>Add Description</summary>
        public class JaggedArrayMarshaler : ICustomMarshaler {
            private GCHandle[] handles;
            private GCHandle buffer;
            private Array[] array;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cookie">FILL IN</param>
            ///DOLATER <returns>Fill in return</returns>
            public static ICustomMarshaler GetInstance(String cookie) {
                return new JaggedArrayMarshaler();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ManagedObj">FILL IN</param>
            public void CleanUpManagedData(Object ManagedObj) {
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="pNativeData">FILL IN</param>
            public void CleanUpNativeData(IntPtr pNativeData) {
                this.buffer.Free();
                foreach (GCHandle handle in this.handles) {
                    handle.Free();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            ///DOLATER <returns>Fill in return</returns>
            public Int32 GetNativeDataSize() {
                return 4;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ManagedObj">FILL IN</param>
            ///DOLATER <returns>Fill in return</returns>
            public IntPtr MarshalManagedToNative(Object ManagedObj) {
                this.array = (Array[])ManagedObj;
                this.handles = new GCHandle[this.array.Length];
                for (Int32 i = 0; i < this.array.Length; i++) {
                    this.handles[i] = GCHandle.Alloc(this.array[i], GCHandleType.Pinned);
                }
                IntPtr[] pointers = new IntPtr[this.handles.Length];
                for (Int32 i = 0; i < this.handles.Length; i++) {
                    pointers[i] = this.handles[i].AddrOfPinnedObject();
                }
                this.buffer = GCHandle.Alloc(pointers, GCHandleType.Pinned);
                return this.buffer.AddrOfPinnedObject();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="pNativeData">FILL IN</param>
            ///DOLATER <returns>Fill in return</returns>
            public Object MarshalNativeToManaged(IntPtr pNativeData) {
                return this.array;
            }
        }

        #endregion
    }
}

#pragma warning restore CA1401 // P/Invokes should not be visible
