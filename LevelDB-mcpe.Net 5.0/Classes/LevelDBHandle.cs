using System;

namespace LevelDB {
    /// <summary>
    /// Base class for all LevelDB objects
    /// Implement IDisposable as prescribed by http://msdn.microsoft.com/en-us/library/b1yfkh5e.aspx by overriding the two additional virtual methods
    /// </summary>
    public abstract class LevelDBHandle : IDisposable {
        private Boolean Disposed;

        public IntPtr Handle { protected set; get; }

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void FreeManagedObjects() {
        }

        protected virtual void FreeUnManagedObjects() {
        }

        private void Dispose(Boolean disposing) {
            if (!this.Disposed) {
                if (disposing) {
                    this.FreeManagedObjects();
                }
                if (this.Handle != IntPtr.Zero) {
                    this.FreeUnManagedObjects();
                    this.Handle = IntPtr.Zero;
                }
                this.Disposed = true;
            }
        }

        ~LevelDBHandle() {
            this.Dispose(false);
        }
    }
}
