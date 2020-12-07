using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LevelDB {
    public class Comparator : LevelDBHandle {
        /// <summary>
        /// 
        /// </summary>
        private IntPtr _NativeName;

        /// <summary>
        /// 
        /// </summary>
        private Comparison<NativeArray> _Comparison;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GCHandleThis"></param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DestructorSignature(IntPtr GCHandleThis);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GCHandleThis"></param>
        /// <param name="data1"></param>
        /// <param name="size1"></param>
        /// <param name="data2"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Int32 CompareSignature(IntPtr GCHandleThis, IntPtr data1, IntPtr size1, IntPtr data2, IntPtr size2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GCHandleThis"></param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr GetNameSignature(IntPtr GCHandleThis);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="comparer"></param>
        public Comparator(String name, IComparer<NativeArray> comparer) : this(name, (a, b) => comparer.Compare(a, b)) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="comparison"></param>
        public Comparator(String name, Comparison<NativeArray> comparison) {
            GCHandle selfHandle = default;
            try {
                Byte[] utf = Encoding.UTF8.GetBytes(name);
                this._NativeName = Marshal.AllocHGlobal(utf.Length + 1);
                Marshal.Copy(utf, 0, this._NativeName, utf.Length);

                this._Comparison = comparison;

                selfHandle = GCHandle.Alloc(this);

                this.Handle = LevelDBInterop.leveldb_comparator_create(
                    GCHandle.ToIntPtr(selfHandle),
                    Marshal.GetFunctionPointerForDelegate(_Destructor),
                    Marshal.GetFunctionPointerForDelegate(Compare),
                    Marshal.GetFunctionPointerForDelegate(_GetName));
                if (this.Handle == IntPtr.Zero) {
                    throw new ApplicationException("Failed to initialize LevelDB comparator");
                }
            }
            catch {
                if (selfHandle != default) {
                    selfHandle.Free();
                }

                if (this._NativeName != IntPtr.Zero) {
                    Marshal.FreeHGlobal(this._NativeName);
                }

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void FreeUnManagedObjects() {
            if (this.Handle != IntPtr.Zero) {
                LevelDBInterop.leveldb_comparator_destroy(this.Handle);
            }

            if (this._NativeName != IntPtr.Zero) {
                Marshal.FreeHGlobal(this._NativeName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static DestructorSignature _Destructor = (selfHandle) => {
            var gcHandle = GCHandle.FromIntPtr(selfHandle);
            var self = (Comparator)gcHandle.Target;
            self.Dispose();
            gcHandle.Free();
        };

        /// <summary>
        /// 
        /// </summary>
        private static CompareSignature Compare = (selfHandle, data1, size1, data2, size2) => {
            var self = (Comparator)GCHandle.FromIntPtr(selfHandle).Target;
            return self.ExecuteComparison(data1, size1, data2, size2);
        };

        /// <summary>
        /// 
        /// </summary>
        private static GetNameSignature _GetName = (selfHandle) => {
            var self = (Comparator)GCHandle.FromIntPtr(selfHandle).Target;
            return self._NativeName;
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="size1"></param>
        /// <param name="data2"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        private unsafe Int32 ExecuteComparison(IntPtr data1, IntPtr size1, IntPtr data2, IntPtr size2) {
            return this._Comparison(
                new NativeArray() { Data = (Byte*)data1, Length = (Int32)size1 },
                new NativeArray() { Data = (Byte*)data2, Length = (Int32)size2 });
        }

        /// <summary>
        /// 
        /// </summary>
        public unsafe struct NativeArray {
            public Byte* Data;
            public Int32 Length;
        }
    }
}
