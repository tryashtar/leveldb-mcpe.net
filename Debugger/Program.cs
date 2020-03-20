using System;
using LevelDB;

namespace Debugger {
    internal class Program {
        private static void Main(String[] args) {
            Options O = new Options {
                CreateIfMissing = true
            };

            DB Values = new DB("test", O);

            Console.ReadLine();
        }
    }
}
