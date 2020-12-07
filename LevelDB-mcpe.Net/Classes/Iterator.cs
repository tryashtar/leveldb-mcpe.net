using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LevelDB {
    /// <summary>
    /// An iterator yields a sequence of key/value pairs from a database.
    /// </summary>
    public class Iterator : LevelDBHandle {
        internal Iterator(IntPtr handle) {
            this.Handle = handle;
        }

        /// <summary>
        /// An iterator is either positioned at a key/value pair, or
        /// not valid.  
        /// </summary>
        /// <returns>This method returns true iff the iterator is valid.</returns>
        public Boolean Valid() {
            Boolean result = LevelDBInterop.leveldb_iter_valid(this.Handle) != 0;
            GC.KeepAlive(this);
            return result;
        }

        /// <summary>
        /// Position at the first key in the source.  
        /// The iterator is IsValid() after this call iff the source is not empty.
        /// </summary>
        public void SeekToFirst() {
            LevelDBInterop.leveldb_iter_seek_to_first(this.Handle);
            this.Throw();
        }

        /// <summary>
        /// Position at the last key in the source.  
        /// The iterator is IsValid() after this call iff the source is not empty.
        /// </summary>
        public void SeekToLast() {
            LevelDBInterop.leveldb_iter_seek_to_last(this.Handle);
            this.Throw();
        }

        /// <summary>
        /// Position at the first key in the source that at or past target
        /// The iterator is IsValid() after this call iff the source contains
        /// an entry that comes at or past target.
        /// </summary>
        public void Seek(Byte[] key) {
            LevelDBInterop.leveldb_iter_seek(this.Handle, key, (IntPtr)key.Length);
            this.Throw();
        }

        /// <summary>
        /// Position at the first key in the source that at or past target
        /// The iterator is IsValid() after this call iff the source contains
        /// an entry that comes at or past target.
        /// </summary>
        public void Seek(String key) {
            this.Seek(Encoding.UTF8.GetBytes(key));
        }

        /// <summary>
        /// Moves to the next entry in the source.  
        /// After this call, IsValid() is true iff the iterator was not positioned at the last entry in the source.
        /// REQUIRES: IsValid()
        /// </summary>
        public void Next() {
            LevelDBInterop.leveldb_iter_next(this.Handle);
            this.Throw();
        }

        /// <summary>
        /// Moves to the previous entry in the source.  
        /// After this call, IsValid() is true iff the iterator was not positioned at the first entry in source.
        /// REQUIRES: IsValid()
        /// </summary>
        public void Prev() {
            LevelDBInterop.leveldb_iter_prev(this.Handle);
            this.Throw();
        }

        /// <summary>
        /// Return the key for the current entry.  
        /// REQUIRES: IsValid()
        /// </summary>
        public String StringKey() {
            return Encoding.UTF8.GetString(this.Key());
        }

        /// <summary>
        /// Return the key for the current entry.  
        /// REQUIRES: IsValid()
        /// </summary>
        public Byte[] Key() {
            IntPtr key = LevelDBInterop.leveldb_iter_key(this.Handle, out IntPtr length);
            this.Throw();

            Byte[] bytes = new Byte[(Int32)length];
            Marshal.Copy(key, bytes, 0, (Int32)length);
            GC.KeepAlive(this);
            return bytes;
        }

        /// <summary>
        /// Return the value for the current entry.  
        /// REQUIRES: IsValid()
        /// </summary>
        public String StringValue() {
            return Encoding.UTF8.GetString(this.Value());
        }

        /// <summary>
        /// Return the value for the current entry.  
        /// REQUIRES: IsValid()
        /// </summary>
        public unsafe Byte[] Value() {
            IntPtr value = LevelDBInterop.leveldb_iter_value(this.Handle, out IntPtr length);
            this.Throw();

            Byte[] bytes = new Byte[(Int64)length];
            Byte* valueNative = (Byte*)value.ToPointer();
            for (Int64 i = 0; i < (Int64)length; ++i) {
                bytes[i] = valueNative[i];
            }

            GC.KeepAlive(this);
            return bytes;
        }

        /// <summary>
        /// If an error has occurred, throw it.  
        /// </summary>
        private void Throw() {
            LevelDBInterop.leveldb_iter_get_error(this.Handle, out IntPtr error);
            LevelDBException.Check(error);
            GC.KeepAlive(this);
        }

        protected override void FreeUnManagedObjects() {
            LevelDBInterop.leveldb_iter_destroy(this.Handle);
        }
    }
}
