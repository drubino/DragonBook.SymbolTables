using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.SymbolTables
{ 
    public class Token
    {
        public string Type { get; private set; }
        public string Value { get; private set; }

        public Token(string type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value}:{this.Type}";
        }
    }
}
