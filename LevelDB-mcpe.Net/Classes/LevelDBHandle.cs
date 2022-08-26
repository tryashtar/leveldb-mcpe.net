﻿using System;

namespace LevelDB {
    /// <summary>
    /// Base class for all LevelDB objects
    /// Implement IDisposable as prescribed by http://msdn.microsoft.com/en-us/library/b1yfkh5e.aspx by overriding the two additional virtual methods
    /// </summary>
    public abstract class LevelDBHandle : IDisposable {
        /// <summary> </summary>
        public Boolean IsDisposed { get; private set; }

        /// <summary> </summary>
        public IntPtr Handle { protected set; get; }

        /// <summary> </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary> </summary>
        protected virtual void FreeManagedObjects() { }

        /// <summary> </summary>
        protected virtual void FreeUnManagedObjects() {}

        /// <summary> </summary>
        /// <param name="disposing"></param>
        private void Dispose(Boolean disposing) {
            if (!this.IsDisposed) {
                if (disposing) {
                    this.FreeManagedObjects();
                }
                if (this.Handle != IntPtr.Zero) {
                    this.FreeUnManagedObjects();
                    this.Handle = IntPtr.Zero;
                }
                this.IsDisposed = true;
            }
        }

        /// <summary> </summary>
        ~LevelDBHandle() {
            this.Dispose(false);
        }
    }
}
