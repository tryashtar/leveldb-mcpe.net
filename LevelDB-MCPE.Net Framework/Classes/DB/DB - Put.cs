using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LevelDB {
    /// <summary>
    /// A DB is a persistent ordered map from keys to values.
    /// A DB is safe for concurrent access from multiple threads without any external synchronization.
    /// </summary>
    public partial class DB {

        /// <summary>
        /// Set the database entry for "key" to "value".  
        /// </summary>
        public void Put(String key, String value) {
            this.Put(key, value, new WriteOptions());
        }

        /// <summary>
        /// Set the database entry for "key" to "value".  
        /// </summary>
        public void Put(String key, String value, WriteOptions options) {
            this.Put(Cpp.ToByteArray(key), Cpp.ToByteArray(value), options);
        }

        /// <summary>
        /// Set the database entry for "key" to "value".  
        /// </summary>
        public void Put(Byte[] key, Byte[] value) {
            this.Put(key, value, new WriteOptions());
        }

        /// <summary>
        /// Set the database entry for "key" to "value".  
        /// </summary>
        public void Put(Byte[] key, Byte[] value, WriteOptions options) {
            LevelDBInterop.leveldb_put(this.Handle, options.Handle, key, (IntPtr)key.Length, value, (IntPtr)value.LongLength, out IntPtr error);
            LevelDBException.Check(error);
            GC.KeepAlive(options);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Set the database entry for "key" to "value".  
        /// </summary>
        public void Put(KeyValuePair<Byte[], Byte[]> Item) {
            this.Put(Item.Key, Item.Value, new WriteOptions());
        }

        /// <summary>
        /// Set the database entry for "key" to "value".  
        /// </summary>
        public void Put(KeyValuePair<Byte[], Byte[]> Item, WriteOptions options) {
            this.Put(Item.Key, Item.Value, new WriteOptions());
        }
    }
}
