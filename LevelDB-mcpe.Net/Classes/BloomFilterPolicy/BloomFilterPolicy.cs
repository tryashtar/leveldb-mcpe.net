using System;

namespace LevelDB {
    /// <summary>
    /// 
    /// </summary>
    public class BloomFilterPolicy : LevelDBHandle {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bits_per_key"></param>
        public BloomFilterPolicy(Int32 bits_per_key) {
            this.Handle = LevelDBInterop.leveldb_filterpolicy_create_bloom(bits_per_key);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void FreeUnManagedObjects() {
            LevelDBInterop.leveldb_filterpolicy_destroy(this.Handle);
        }
    }
}
