using System;
using System.Collections.Generic;

namespace LevelDB {
    /// <summary>
    /// A DB is a persistent ordered map from keys to values.
    /// A DB is safe for concurrent access from multiple threads without any external synchronization.
    /// </summary>
    public partial class DB : LevelDBHandle {
        /// <summary>Open the database with the specified "name".</summary>
        /// <param name="name">The name (subfolder) of the database</param>
        public DB(String name) : this(name, new Options()) {
        }

        /// <summary> Open the database with the specified "name". Options should not be modified after calling this method. </summary>
        /// <param name="name">The name (subfolder) of the database</param>
        /// <param name="options">Options should not be modified after calling this method.</param>
        public DB(String name, Options options) {
            this.Options = options ?? new Options();
            this.Handle = LevelDBInterop.leveldb_open(this.Options.Handle, name, out IntPtr error);
            LevelDBException.Check(error);
            GC.KeepAlive(this.Options);

#if DEBUG
            System.Diagnostics.Debug.WriteLine("Opened leveldb: " + name);
#endif
        }

        /// <summary>When the database is getting destroyed, close the database handle</summary>
        protected override void FreeUnManagedObjects() {
            if (this.Handle != default) {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("Closing leveldb");
#endif
                LevelDBInterop.leveldb_close(this.Handle);
            }
        }
    }
}
