using System;
using System.Text;

namespace LevelDB {
    /// <summary>
    /// A DB is a persistent ordered map from keys to values.
    /// A DB is safe for concurrent access from multiple threads without any external synchronization.
    /// </summary>
    public partial class DB {
        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public String GetString(String key) {
            return this.GetString(key, new ReadOptions());
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public String GetString(String key, ReadOptions options) {
            return this.GetString(Encoding.UTF8.GetBytes(key), options);
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public String GetString(Byte[] key) {
            return this.GetString(key, new ReadOptions());
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public String GetString(Byte[] key, ReadOptions options) {
            Byte[] value = this.GetBytes(key, options);
            return value is not null ? Encoding.UTF8.GetString(value) : null;
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public Byte[] GetBytes(String key) {
            return this.GetBytes(Encoding.UTF8.GetBytes(key), new ReadOptions());
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public Byte[] GetBytes(String key, ReadOptions options) {
            return this.GetBytes(Encoding.UTF8.GetBytes(key), options);
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public Byte[] GetBytes(Byte[] key) {
            return this.GetBytes(key, new ReadOptions());
        }

        /// <summary>If the database contains an entry for "key" return the value,
        /// otherwise return null. </summary>
        public unsafe Byte[] GetBytes(Byte[] key, ReadOptions options) {
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
    }
}
