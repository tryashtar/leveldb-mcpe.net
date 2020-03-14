using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelDB.Test {
    [TestClass]
    public partial class OptionsTest {
        [TestMethod]
        public void TestNew() {
            //If this doesn't work then something is really wrong
            Options O = new Options();

            Assert.IsFalse(O == null, "Object not loaded");
            Assert.IsFalse(O.Handle == null || O.Handle == IntPtr.Zero, "No object is referenced");
        }
    }
}
