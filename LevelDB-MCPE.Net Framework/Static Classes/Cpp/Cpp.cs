using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace LevelDB {
    ///DOLATER <summary>add description for class: Cpp</summary>
    public static partial class Cpp {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Byte[] ToByteArray(String data) {
            return Encoding.UTF8.GetBytes(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String ToString(Byte[] data) {
            return Encoding.UTF8.GetString(data);
        }
    }
}
