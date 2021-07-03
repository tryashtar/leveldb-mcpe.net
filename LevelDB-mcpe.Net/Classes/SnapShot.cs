using System;

namespace LevelDB {
    /// <summary>
    /// A Snapshot is an immutable object and can therefore be safely
    /// accessed from multiple threads without any external synchronization.
    /// </summary>
    public class SnapShot : LevelDBHandle {
        /// <summary>pointer to parent so that we can call ReleaseSnapshot(this) when disposed</summary>
        public WeakReference Parent;  // as DB

        /// <summary> </summary>
        /// <param name="handle"></param>
        /// <param name="parent"></param>
        internal SnapShot(IntPtr handle, DB parent) {
            this.Handle = handle;
            this.Parent = new WeakReference(parent);
        }

        /// <summary> </summary>
        /// <param name="handle"></param>
        internal SnapShot(IntPtr handle) {
            this.Handle = handle;
            this.Parent = new WeakReference(null);
        }

        /// <summary> </summary>
        protected override void FreeUnManagedObjects() {
            if (this.Parent.Target is DB parent) {
                LevelDBInterop.leveldb_release_snapshot(parent.Handle, this.Handle);
            }
        }
    }
}
