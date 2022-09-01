using System;
using System.Collections;
using System.Collections.Generic;

namespace LevelDB {
    /// <summary>
    /// A DB is a persistent ordered map from keys to values.
    /// A DB is safe for concurrent access from multiple threads without any external synchronization.
    /// </summary>
    public partial class DB {
        /// <summary> </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<String, String>> StringPairs() {
            using (SnapShot sn = this.CreateSnapshot())
            using (Iterator iterator = this.CreateIterator(new ReadOptions { Snapshot = sn })) {
                iterator.SeekToFirst();
                while (iterator.Valid()) {
                    yield return new KeyValuePair<String, String>(iterator.StringKey(), iterator.StringValue());
                    iterator.Next();
                }
            }
        }

        /// <summary> </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<Byte[], Byte[]>> BytePairs() {
            using (SnapShot sn = this.CreateSnapshot())
            using (Iterator iterator = this.CreateIterator(new ReadOptions { Snapshot = sn })) {
                iterator.SeekToFirst();
                while (iterator.Valid()) {
                    yield return new KeyValuePair<Byte[], Byte[]>(iterator.Key(), iterator.Value());
                    iterator.Next();
                }
            }
        }

        /// <summary> </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<String, Byte[]>> StringBytePairs()
        {
            using (SnapShot sn = this.CreateSnapshot())
            using (Iterator iterator = this.CreateIterator(new ReadOptions { Snapshot = sn }))
            {
                iterator.SeekToFirst();
                while (iterator.Valid())
                {
                    yield return new KeyValuePair<String, Byte[]>(iterator.StringKey(), iterator.Value());
                    iterator.Next();
                }
            }
        }

        /// <summary> </summary>
        /// <returns></returns>
        public IEnumerable<String> StringKeys()
        {
            using (SnapShot sn = this.CreateSnapshot())
            using (Iterator iterator = this.CreateIterator(new ReadOptions { Snapshot = sn }))
            {
                iterator.SeekToFirst();
                while (iterator.Valid())
                {
                    yield return iterator.StringKey();
                    iterator.Next();
                }
            }
        }

        /// <summary> </summary>
        /// <returns></returns>
        public IEnumerable<Byte[]> ByteKeys()
        {
            using (SnapShot sn = this.CreateSnapshot())
            using (Iterator iterator = this.CreateIterator(new ReadOptions { Snapshot = sn }))
            {
                iterator.SeekToFirst();
                while (iterator.Valid())
                {
                    yield return iterator.Key();
                    iterator.Next();
                }
            }
        }
    }
}
