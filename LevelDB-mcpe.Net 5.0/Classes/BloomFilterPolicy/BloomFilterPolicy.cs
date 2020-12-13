using System;

namespace LevelDB {
    public class BloomFilterPolicy : LevelDBHandle {
        public BloomFilterPolicy(Int32 bits_per_key) {
            this.Handle = LevelDBInterop.leveldb_filterpolicy_create_bloom(bits_per_key);
        }

        protected override void FreeUnManagedObjects() {
            LevelDBInterop.leveldb_filterpolicy_destroy(this.Handle);
        }
    }
}
