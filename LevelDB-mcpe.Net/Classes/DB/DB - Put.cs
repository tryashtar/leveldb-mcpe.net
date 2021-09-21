using System;
using System.Text;

namespace LevelDB {
    public partial class DB {
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
    }
}
