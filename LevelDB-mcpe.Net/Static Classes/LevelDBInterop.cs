using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1401 // P/Invokes should not be visible
namespace LevelDB {
    public static partial class LevelDBInterop {

        #region Options
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_options_create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_destroy(IntPtr /*Options*/ options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="o"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_create_if_missing(IntPtr /*Options*/ options, Byte o);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="o"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_error_if_exists(IntPtr /*Options*/ options, Byte o);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_info_log(IntPtr /*Options*/ options, IntPtr /* Logger */ logger);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="o"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_paranoid_checks(IntPtr /*Options*/ options, Byte o);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="env"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_env(IntPtr /*Options*/ options, IntPtr /*Env*/ env);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="size"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_write_buffer_size(IntPtr /*Options*/ options, Int64 size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="max"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_max_open_files(IntPtr /*Options*/ options, Int32 max);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cache"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_cache(IntPtr /*Options*/ options, IntPtr /*Cache*/ cache);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="size"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_block_size(IntPtr /*Options*/ options, Int64 size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="interval"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_block_restart_interval(IntPtr /*Options*/ options, Int32 interval);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="level"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_compression(IntPtr /*Options*/ options, Int32 level);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="comparer"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_comparator(IntPtr /*Options*/ options, IntPtr /*Comparator*/ comparer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="policy"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_options_set_filter_policy(IntPtr /*Options*/ options, IntPtr /*FilterPolicy*/ policy);
        #endregion

        #region ReadOptions
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_readoptions_create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_readoptions_destroy(IntPtr /*ReadOptions*/ options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="o"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_readoptions_set_verify_checksums(IntPtr /*ReadOptions*/ options, Byte o);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="o"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_readoptions_set_fill_cache(IntPtr /*ReadOptions*/ options, Byte o);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="snapshot"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_readoptions_set_snapshot(IntPtr /*ReadOptions*/ options, IntPtr /*SnapShot*/ snapshot);
        #endregion

        #region WriteBatch
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_writebatch_create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_destroy(IntPtr /* WriteBatch */ batch);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_clear(IntPtr /* WriteBatch */ batch);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="key"></param>
        /// <param name="keylen"></param>
        /// <param name="val"></param>
        /// <param name="vallen"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_put(IntPtr /* WriteBatch */ batch, Byte[] key, IntPtr keylen, Byte[] val, IntPtr vallen);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="key"></param>
        /// <param name="keylen"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_delete(IntPtr /* WriteBatch */ batch, Byte[] key, IntPtr keylen);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="state"></param>
        /// <param name="put"></param>
        /// <param name="deleted"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writebatch_iterate(IntPtr /* WriteBatch */ batch, IntPtr state, Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr> put, Action<IntPtr, IntPtr, IntPtr> deleted);
        #endregion

        #region WriteOptions
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_writeoptions_create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writeoptions_destroy(IntPtr /*WriteOptions*/ options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="o"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_writeoptions_set_sync(IntPtr /*WriteOptions*/ options, Byte o);
        #endregion

        #region Cache
        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr leveldb_cache_create_lru(IntPtr capacity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_cache_destroy(IntPtr /*Cache*/ cache);
        #endregion

        #region Comparator

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="destructor"></param>
        /// <param name="compare"></param>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmp"></param>
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void leveldb_comparator_destroy(IntPtr /* leveldb_comparator_t* */ cmp);

        #endregion

        #region Marshal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        internal static IntPtr MarshalSize(Byte[] byteArray) {
            return (IntPtr)(byteArray?.Length ?? 0);
        }

        /// <summary>
        /// 
        /// </summary>
        public class JaggedArrayMarshaler : ICustomMarshaler {
            private GCHandle[] handles;
            private GCHandle buffer;
            private Array[] array;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cookie"></param>
            /// <returns></returns>
            public static ICustomMarshaler GetInstance(String cookie) {
                return new JaggedArrayMarshaler();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ManagedObj"></param>
            public void CleanUpManagedData(Object ManagedObj) {
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="pNativeData"></param>
            public void CleanUpNativeData(IntPtr pNativeData) {
                this.buffer.Free();
                foreach (GCHandle handle in this.handles) {
                    handle.Free();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public Int32 GetNativeDataSize() {
                return 4;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ManagedObj"></param>
            /// <returns></returns>
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
            /// <param name="pNativeData"></param>
            /// <returns></returns>
            public Object MarshalNativeToManaged(IntPtr pNativeData) {
                return this.array;
            }
        }

        #endregion
    }
}

#pragma warning restore CA1401 // P/Invokes should not be visible
