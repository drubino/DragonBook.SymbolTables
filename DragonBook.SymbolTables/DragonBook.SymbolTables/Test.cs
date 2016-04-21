using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonBook.SymbolTables
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod()
        {
            var translator = new Translator();
            var output = translator.Translate("{ int x; int y; int z; { bool x; bool y; { string x; x; y; z; } x; y; z; } x; y; z; }");
        }
    }
}
