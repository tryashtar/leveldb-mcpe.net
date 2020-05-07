using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LevelDB {
    /// <summary>
    /// A DB is a persistent ordered map from keys to values.
    /// A DB is safe for concurrent access from multiple threads without any external synchronization.
    /// </summary>
    public partial class DB : IEnumerable<KeyValuePair<String, String>>, IEnumerable<KeyValuePair<Byte[], Byte[]>> {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator<KeyValuePair<String, String>> IEnumerable<KeyValuePair<String, String>>.GetEnumerator() {
            using (SnapShot sn = this.CreateSnapshot())
            using (Iterator iterator = this.CreateIterator(new ReadOptions { Snapshot = sn })) {
                iterator.SeekToFirst();
                while (iterator.Valid()) {
                    yield return new KeyValuePair<String, String>(iterator.StringKey(), iterator.StringValue());
                    iterator.Next();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<Byte[], Byte[]>> GetEnumerator() {
            using (SnapShot sn = this.CreateSnapshot())
            using (Iterator iterator = this.CreateIterator(new ReadOptions { Snapshot = sn })) {
                iterator.SeekToFirst();
                while (iterator.Valid()) {
                    yield return new KeyValuePair<Byte[], Byte[]>(iterator.Key(), iterator.Value());
                    iterator.Next();
                }
            }
        }
    }
}
