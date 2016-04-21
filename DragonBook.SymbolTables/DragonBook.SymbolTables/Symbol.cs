using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.SymbolTables
{
    public class Symbol
    {
        public string Type { get; private set; }
        public string Name { get; private set; }

        public Symbol(string type, string value)
        {
            this.Type = type;
            this.Name = value;
        }

        public override string ToString()
        {
            return $"{this.Name}:{this.Type}";
        }
    }
}
