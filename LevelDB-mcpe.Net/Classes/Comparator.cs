using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LevelDB {
    public class Comparator : LevelDBHandle {
        private IntPtr NativeName;
        private Comparison<NativeArray> Comparison;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DestructorSignature(IntPtr GCHandleThis);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Int32 CompareSignature(IntPtr GCHandleThis, IntPtr data1, IntPtr size1, IntPtr data2, IntPtr size2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr GetNameSignature(IntPtr GCHandleThis);

        public Comparator(String name, IComparer<NativeArray> comparer) : this(name, (a, b) => comparer.Compare(a, b)) { }

        public Comparator(String name, Comparison<NativeArray> comparison) {
            GCHandle selfHandle = default;
            try {
                Byte[] utf = Encoding.UTF8.GetBytes(name);
                this.NativeName = Marshal.AllocHGlobal(utf.Length + 1);
                Marshal.Copy(utf, 0, this.NativeName, utf.Length);

                this.Comparison = comparison;

                selfHandle = GCHandle.Alloc(this);

                this.Handle = LevelDBInterop.leveldb_comparator_create(
                    GCHandle.ToIntPtr(selfHandle),
                    Marshal.GetFunctionPointerForDelegate(Destructor),
                    Marshal.GetFunctionPointerForDelegate(Compare),
                    Marshal.GetFunctionPointerForDelegate(GetName));
                if (this.Handle == IntPtr.Zero) {
                    throw new ApplicationException("Failed to initialize LevelDB comparator");
                }
            }
            catch {
                if (selfHandle != default(GCHandle)) {
                    selfHandle.Free();
                }

                if (this.NativeName != IntPtr.Zero) {
                    Marshal.FreeHGlobal(this.NativeName);
                }

                throw;
            }
        }

        protected override void FreeUnManagedObjects() {
            if (this.Handle != IntPtr.Zero) {
                LevelDBInterop.leveldb_comparator_destroy(this.Handle);
            }

            if (this.NativeName != IntPtr.Zero) {
                Marshal.FreeHGlobal(this.NativeName);
            }
        }

        private static DestructorSignature Destructor = (selfHandle) => {
            var gcHandle = GCHandle.FromIntPtr(selfHandle);
            var self = (Comparator)gcHandle.Target;
            self.Dispose();
            gcHandle.Free();
        };
        private static CompareSignature Compare = (selfHandle, data1, size1, data2, size2) => {
            var self = (Comparator)GCHandle.FromIntPtr(selfHandle).Target;
            return self.ExecuteComparison(data1, size1, data2, size2);
        };
        private static GetNameSignature GetName = (selfHandle) => {
            var self = (Comparator)GCHandle.FromIntPtr(selfHandle).Target;
            return self.NativeName;
        };

        private unsafe Int32 ExecuteComparison(IntPtr data1, IntPtr size1, IntPtr data2, IntPtr size2) {
            return this.Comparison(
                new NativeArray() { Data = (Byte*)data1, Length = (Int32)size1 },
                new NativeArray() { Data = (Byte*)data2, Length = (Int32)size2 });
        }

        public unsafe struct NativeArray {
            public Byte* Data;
            public Int32 Length;
        }
    }
}
