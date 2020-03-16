using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1401 // P/Invokes should not be visible
namespace LevelDB {
    public static partial class LevelDBInterop {

        #region Options
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_options_create();

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_destroy(IntPtr /*Options*/ options);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_create_if_missing(IntPtr /*Options*/ options, Byte o);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_error_if_exists(IntPtr /*Options*/ options, Byte o);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_info_log(IntPtr /*Options*/ options, IntPtr /* Logger */ logger);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_paranoid_checks(IntPtr /*Options*/ options, Byte o);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_env(IntPtr /*Options*/ options, IntPtr /*Env*/ env);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_write_buffer_size(IntPtr /*Options*/ options, Int64 size);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_max_open_files(IntPtr /*Options*/ options, Int32 max);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_cache(IntPtr /*Options*/ options, IntPtr /*Cache*/ cache);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_block_size(IntPtr /*Options*/ options, Int64 size);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_block_restart_interval(IntPtr /*Options*/ options, Int32 interval);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_compression(IntPtr /*Options*/ options, Int32 level);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_comparator(IntPtr /*Options*/ options, IntPtr /*Comparator*/ comparer);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_filter_policy(IntPtr /*Options*/ options, IntPtr /*FilterPolicy*/ policy);
        #endregion

        #region ReadOptions
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_readoptions_create();

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_destroy(IntPtr /*ReadOptions*/ options);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_verify_checksums(IntPtr /*ReadOptions*/ options, Byte o);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_fill_cache(IntPtr /*ReadOptions*/ options, Byte o);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_snapshot(IntPtr /*ReadOptions*/ options, IntPtr /*SnapShot*/ snapshot);
        #endregion

        #region WriteBatch
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_writebatch_create();

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_destroy(IntPtr /* WriteBatch */ batch);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_clear(IntPtr /* WriteBatch */ batch);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_put(IntPtr /* WriteBatch */ batch, Byte[] key, IntPtr keylen, Byte[] val, IntPtr vallen);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_delete(IntPtr /* WriteBatch */ batch, Byte[] key, IntPtr keylen);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_iterate(IntPtr /* WriteBatch */ batch, IntPtr state, Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr> put, Action<IntPtr, IntPtr, IntPtr> deleted);
        #endregion

        #region WriteOptions
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_writeoptions_create();

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writeoptions_destroy(IntPtr /*WriteOptions*/ options);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writeoptions_set_sync(IntPtr /*WriteOptions*/ options, Byte o);
        #endregion

        #region Cache
        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_cache_create_lru(IntPtr capacity);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_cache_destroy(IntPtr /*Cache*/ cache);
        #endregion

        #region Comparator

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr /* leveldb_comparator_t* */
            leveldb_comparator_create(
            IntPtr /* void* */ state,
            IntPtr /* void (*)(void*) */ destructor,
            IntPtr
                /* int (*compare)(void*,
                                  const char* a, size_t alen,
                                  const char* b, size_t blen) */
                compare,
            IntPtr /* const char* (*)(void*) */ name);

        [DllImport("LevelDB-MCPE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_comparator_destroy(IntPtr /* leveldb_comparator_t* */ cmp);

        #endregion

        #region Marshal

        internal static IntPtr MarshalSize(Byte[] byteArray) {
            return (IntPtr)(byteArray?.Length ?? 0);
        }

        public class JaggedArrayMarshaler : ICustomMarshaler {
            private GCHandle[] handles;
            private GCHandle buffer;
            private Array[] array;

            public static ICustomMarshaler GetInstance(String cookie) {
                return new JaggedArrayMarshaler();
            }

            public void CleanUpManagedData(Object ManagedObj) {
            }

            public void CleanUpNativeData(IntPtr pNativeData) {
                this.buffer.Free();
                foreach (GCHandle handle in this.handles) {
                    handle.Free();
                }
            }

            public Int32 GetNativeDataSize() {
                return 4;
            }

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

            public Object MarshalNativeToManaged(IntPtr pNativeData) {
                return this.array;
            }
        }

        #endregion
    }
}

#pragma warning restore CA1401 // P/Invokes should not be visible
