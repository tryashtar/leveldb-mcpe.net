using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LevelDB {
    /// <summary>
    /// A DB is a persistent ordered map from keys to values.
    /// A DB is safe for concurrent access from multiple threads without any external synchronization.
    /// </summary>
    public partial class DB {

        /// <summary>If a DB cannot be opened, you may attempt to call this method to
        /// resurrect as much of the contents of the database as possible.
        /// Some data may be lost, so be careful when calling this function
        /// on a database that contains important information.</summary>
        public static void Repair(String name) {
            Repair(name, new Options());
        }

        /// <summary>If a DB cannot be opened, you may attempt to call this method to
        /// resurrect as much of the contents of the database as possible.
        /// Some data may be lost, so be careful when calling this function
        /// on a database that contains important information.
        /// Options should not be modified after calling this method. </summary>
        public static void Repair(String name, Options options) {
            LevelDBInterop.leveldb_repair_db(options.Handle, name, out IntPtr error);
            LevelDBException.Check(error);
            GC.KeepAlive(options);
        }

        /// <summary>Destroy the contents of the specified database.
        /// Be very careful using this method. </summary>
        public static void Destroy(String name) {
            Destroy(name, new Options());
        }

        /// <summary>Destroy the contents of the specified database.
        /// Be very careful using this method.
        /// Options should not be modified after calling this method. </summary>
        public static void Destroy(String name, Options options) {
            LevelDBInterop.leveldb_destroy_db(options.Handle, name, out IntPtr error);
            LevelDBException.Check(error);
            GC.KeepAlive(options);
        }

        /// <summary>Set the database entry for "key" to "value". </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(String key, String value) {
            this.Put(key, value, new WriteOptions());
        }

        /// <summary>Set the database entry for "key" to "value". </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public void Put(String key, String value, WriteOptions options) {
            this.Put(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(value), options);
        }

        /// <summary>Set the database entry for "key" to "value".</summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(Byte[] key, Byte[] value) {
            this.Put(key, value, new WriteOptions());
        }

        /// <summary>Set the database entry for "key" to "value".</summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public void Put(Byte[] key, Byte[] value, WriteOptions options) {
            LevelDBInterop.leveldb_put(this.Handle, options.Handle, key, (IntPtr)key.Length, value, (IntPtr)value.LongLength, out IntPtr error);
            LevelDBException.Check(error);
            GC.KeepAlive(options);
            GC.KeepAlive(this);
        }

        /// <summary> </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void Put(ReadOnlySpan<Byte> Key, ReadOnlySpan<Byte> Value) {
            this.Put(Key.ToArray(), Value.ToArray());
        }

        /// <summary>Remove the database entry (if any) for "key".  
        /// It is not an error if "key" did not exist in the database. </summary>
        public void Delete(String key) {
            this.Delete(key, new WriteOptions());
        }

        /// <summary>Remove the database entry (if any) for "key".  
        /// It is not an error if "key" did not exist in the database. </summary>
        public void Delete(String key, WriteOptions options) {
            this.Delete(Encoding.UTF8.GetBytes(key), options);
        }

        /// <summary>Remove the database entry (if any) for "key".  
        /// It is not an error if "key" did not exist in the database. </summary>
        public void Delete(Byte[] key) {
            this.Delete(key, new WriteOptions());
        }

        /// <summary>Remove the database entry (if any) for "key".  
        /// It is not an error if "key" did not exist in the database. </summary>
        public void Delete(Byte[] key, WriteOptions options) {
            LevelDBInterop.leveldb_delete(this.Handle, options.Handle, key, (IntPtr)key.Length, out IntPtr error);
            LevelDBException.Check(error);
            GC.KeepAlive(options);
            GC.KeepAlive(this);
        }

        ///DOLATER <summary>Add Description</summary>
        /// <param name="batch">FILL IN</param>
        public void Write(WriteBatch batch) {
            this.Write(batch, new WriteOptions());
        }

        ///DOLATER <summary>Add Description</summary>
        /// <param name="batch">FILL IN</param>
        /// <param name="options">FILL IN</param>
        public void Write(WriteBatch batch, WriteOptions options) {
            LevelDBInterop.leveldb_write(this.Handle, options.Handle, batch.Handle, out IntPtr error);
            LevelDBException.Check(error);
            GC.KeepAlive(batch);
            GC.KeepAlive(options);
            GC.KeepAlive(this);
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public String Get(String key) {
            return this.Get(key, new ReadOptions());
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public String Get(String key, ReadOptions options) {
            Byte[] value = this.Get(Encoding.UTF8.GetBytes(key), options);
            return value != null ? Encoding.UTF8.GetString(value) : null;
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public Byte[] Get(Byte[] key) {
            return this.Get(key, new ReadOptions());
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public unsafe Byte[] Get(Byte[] key, ReadOptions options) {
            IntPtr valuePtr = LevelDBInterop.leveldb_get(this.Handle, options.Handle, key, (IntPtr)key.Length, out IntPtr lengthPtr, out IntPtr error);
            LevelDBException.Check(error);
            if (valuePtr == IntPtr.Zero) {
                return null;
            }

            try {
                Int64 length = (Int64)lengthPtr;
                Byte[] value = new Byte[length];
                Byte* valueNative = (Byte*)valuePtr.ToPointer();
                for (Int64 i = 0; i < length; ++i) {
                    value[i] = valueNative[i];
                }

                return value;
            }
            finally {
                LevelDBInterop.leveldb_free(valuePtr);
                GC.KeepAlive(options);
                GC.KeepAlive(this);
            }
        }

        /// <summary>Return an iterator over the contents of the database.
        /// The result of CreateIterator is initially invalid (caller must
        /// call one of the Seek methods on the iterator before using it). </summary>
        public Iterator CreateIterator() {
            return this.CreateIterator(new ReadOptions());
        }

        /// <summary>Return an iterator over the contents of the database.
        /// The result of CreateIterator is initially invalid (caller must
        /// call one of the Seek methods on the iterator before using it). </summary>
        public Iterator CreateIterator(ReadOptions options) {
            var result = new Iterator(LevelDBInterop.leveldb_create_iterator(this.Handle, options.Handle));
            GC.KeepAlive(options);
            GC.KeepAlive(this);
            return result;
        }

        /// <summary>Return a handle to the current DB state.  
        /// Iterators and Gets created with this handle will all observe a stable snapshot of the current DB state.   </summary>
        public SnapShot CreateSnapshot() {
            var result = new SnapShot(LevelDBInterop.leveldb_create_snapshot(this.Handle), this);
            GC.KeepAlive(this);
            return result;
        }

        /// <summary>DB implementations can export properties about their state
        /// via this method.  If "property" is a valid property understood by this
        /// DB implementation, fills "*value" with its current value and returns
        /// true.  Otherwise returns false.
        /// 
        /// Valid property names include:
        ///
        /// "leveldb.num-files-at-level{N}" - return the number of files at level {N},
        /// where {N} is an ASCII representation of a level number (e.g. "0").
        /// "leveldb.stats" - returns a multi-line string that describes statistics
        /// about the internal operation of the DB. </summary>
        /// <paramref name="name"></paramref>
        public String PropertyValue(String name) {
            IntPtr ptr = LevelDBInterop.leveldb_property_value(this.Handle, name);
            if (ptr == IntPtr.Zero) {
                return null;
            }

            try {
                return Marshal.PtrToStringAnsi(ptr);
            }
            finally {
                LevelDBInterop.leveldb_free(ptr);
                GC.KeepAlive(this);
            }
        }

        /// <summary>Compact the underlying storage.
        /// In particular, deleted and overwritten versions are discarded,
        /// and the data is rearranged to reduce the cost of operations
        /// needed to access the data.  This operation should typically only
        /// be invoked by users who understand the underlying implementation. </summary>
        public void Compact() {
            Byte[] startKey = null;
            Byte[] limitKey = null;
            this.CompactRange(startKey, limitKey);
        }

        /// <summary>Compact the underlying storage for the key range [*begin,*end].
        /// In particular, deleted and overwritten versions are discarded,
        /// and the data is rearranged to reduce the cost of operations
        /// needed to access the data.  This operation should typically only
        /// be invoked by users who understand the underlying implementation. </summary>
        /// <param name="startKey">FILL IN</param>
        /// <param name="limitKey">FILL IN</param>
        public void CompactRange(String startKey, String limitKey) {
            this.CompactRange(Encoding.UTF8.GetBytes(startKey), Encoding.UTF8.GetBytes(limitKey));
        }

        /// <summary>Compact the underlying storage for the key range [*begin,*end].
        /// In particular, deleted and overwritten versions are discarded,
        /// and the data is rearranged to reduce the cost of operations
        /// needed to access the data.  This operation should typically only
        /// be invoked by users who understand the underlying implementation. </summary>
        /// <param name="startKey">FILL IN</param>
        /// <param name="limitKey">FILL IN</param>
        public void CompactRange(Byte[] startKey, Byte[] limitKey) {
            try {
                LevelDBInterop.leveldb_compact_range(
                    this.Handle,
                    startKey, LevelDBInterop.MarshalSize(startKey),
                    limitKey, LevelDBInterop.MarshalSize(limitKey));
            }
            catch (Exception ex) {
                while (ex != null) {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);

                    ex = ex.InnerException;
                }
            }

            GC.KeepAlive(this);
        }

        /// <summary>Returns the approximate file system space used by keys in "[start .. limit)".
        ///
        /// Note that the returned sizes measure file system space usage, so
        /// if the user data compresses by a factor of ten, the returned
        /// sizes will be one-tenth the size of the corresponding user data size.
        ///
        /// The results may not include the sizes of recently written data. </summary>
        /// <param name="startKey">FILL IN</param>
        /// <param name="limitKey">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        public unsafe Int64 GetApproximateSize(String startKey, String limitKey) {
            return this.GetApproximateSize(Encoding.UTF8.GetBytes(startKey), Encoding.UTF8.GetBytes(limitKey));
        }

        /// <summary>Returns the approximate file system space used by keys in "[start .. limit)".
        ///
        /// Note that the returned sizes measure file system space usage, so
        /// if the user data compresses by a factor of ten, the returned
        /// sizes will be one-tenth the size of the corresponding user data size.
        ///
        /// The results may not include the sizes of recently written data. </summary>
        /// <param name="startKey">FILL IN</param>
        /// <param name="limitKey">FILL IN</param>
        ///DOLATER <returns>Fill in return</returns>
        public unsafe Int64 GetApproximateSize(Byte[] startKey, Byte[] limitKey) {
            var l1 = (IntPtr)startKey.Length;
            var l2 = (IntPtr)limitKey.Length;
            Int64[] sizes = new Int64[1];

            LevelDBInterop.leveldb_approximate_sizes(this.Handle, 1, new Byte[][] { startKey }, new IntPtr[] { l1 }, new Byte[][] { limitKey }, new IntPtr[] { l2 }, sizes);
            GC.KeepAlive(this);

            return sizes[0];
        }

        /// <summary> </summary>
        public void Close() {
            this.FreeUnManagedObjects();
        }

        /// <summary> </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        private static IntPtr MarshalArray(Byte[] ar) {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Byte)) * ar.Length);
            Marshal.Copy(ar, 0, p, ar.Length);
            return p;
        }

        /// <summary> </summary>
        protected override void FreeUnManagedObjects() {
            if (this.Handle != default) {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("Closing leveldb");
#endif
                LevelDBInterop.leveldb_close(this.Handle);
                this.Handle = default;
            }
        }
    }
}
