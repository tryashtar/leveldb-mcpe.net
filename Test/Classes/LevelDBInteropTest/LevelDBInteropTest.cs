using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelDB.Test {
    [TestClass]
    public partial class LevelDBInteropTest {
        ///DOLATER <summary>Add Description</summary>
        [TestMethod]
        public void TestDllimport() {
            MethodInfo[] methods = typeof(LevelDBInterop).GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            List<String> Errors = new List<String>(2);

            foreach (MethodInfo M in methods) {
                Object[] Attributes = M.GetCustomAttributes(typeof(DllImportAttribute), true);

                for (Int32 I = 0; I < Attributes.Length; I++) {
                    if (Attributes[I] is DllImportAttribute DLLAtr) {
                        if (DLLAtr.CharSet == CharSet.Unicode) {
                            Errors.Add($"{M.Name} uses charset unicode but that usually leads to problems");
                        }
                    }
                }
            }

            if (Errors.Count > 0) {
                Assert.Fail(String.Join("\n", Errors));
            }
        }
    }
}
