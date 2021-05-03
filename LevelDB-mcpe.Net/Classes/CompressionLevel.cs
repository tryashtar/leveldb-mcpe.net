﻿namespace LevelDB {
    /// <summary>
    /// DB contents are stored in a set of blocks, each of which holds a
    /// sequence of key,value pairs.  Each block may be compressed before
    /// being stored in a file. The following enum describes which
    /// compression method (if any) is used to compress a block.
    /// </summary>
    public enum CompressionLevel {
        /// <summary>
        /// 
        /// </summary>
        NoCompression = 0,

        /// <summary>
        /// 
        /// </summary>
        SnappyCompression = 1,

        /// <summary>
        /// 
        /// </summary>
        ZlibCompression = 2,

        /// <summary>
        /// 
        /// </summary>
        ZlibRawCompression = 4
    }
}
