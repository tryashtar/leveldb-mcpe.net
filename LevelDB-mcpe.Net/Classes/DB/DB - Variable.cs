namespace LevelDB {
    /// <summary>
    /// A DB is a persistent ordered map from keys to values.
    /// A DB is safe for concurrent access from multiple threads without any external synchronization.
    /// </summary>
    public partial class DB {
        private readonly Options _Options;
    }
}