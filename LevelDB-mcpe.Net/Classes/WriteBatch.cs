using System;
using System.Text;

namespace LevelDB {
    /// <summary>
    /// WriteBatch holds a collection of updates to apply atomically to a DB.
    ///
    /// The updates are applied in the order in which they are added
    /// to the WriteBatch.  For example, the value of "key" will be "v3"
    /// after the following batch is written:
    ///
    ///    batch.Put("key", "v1");
    ///    batch.Delete("key");
    ///    batch.Put("key", "v2");
    ///    batch.Put("key", "v3");
    /// </summary>
    public class WriteBatch : LevelDBHandle {
        public WriteBatch() {
            this.Handle = LevelDBInterop.leveldb_writebatch_create();
        }

        /// <summary>
        /// Clear all updates buffered in this batch.
        /// </summary>
        public void Clear() {
            LevelDBInterop.leveldb_writebatch_clear(this.Handle);
        }

        /// <summary>
        /// Store the mapping "key->value" in the database.
        /// </summary>
        public WriteBatch Put(String key, String value) {
            return this.Put(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Store the mapping "key->value" in the database.
        /// </summary>
        public WriteBatch Put(Byte[] key, Byte[] value) {
            LevelDBInterop.leveldb_writebatch_put(this.Handle, key, (IntPtr)key.Length, value, (IntPtr)value.Length);
            return this;
        }

        /// <summary>
        /// If the database contains a mapping for "key", erase it.  
        /// Else do nothing.
        /// </summary>
        public WriteBatch Delete(String key) {
            return this.Delete(Encoding.UTF8.GetBytes(key));
        }

        /// <summary>
        /// If the database contains a mapping for "key", erase it.  
        /// Else do nothing.
        /// </summary>
        public WriteBatch Delete(Byte[] key) {
            LevelDBInterop.leveldb_writebatch_delete(this.Handle, key, (IntPtr)key.Length);
            return this;
        }

        /// <summary>
        /// Support for iterating over a batch.
        /// </summary>
        public void Iterate(IntPtr state, Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr> put, Action<IntPtr, IntPtr, IntPtr> deleted) {
            LevelDBInterop.leveldb_writebatch_iterate(this.Handle, state, put, deleted);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void FreeUnManagedObjects() {
            LevelDBInterop.leveldb_writebatch_destroy(this.Handle);
        }
    }
}
