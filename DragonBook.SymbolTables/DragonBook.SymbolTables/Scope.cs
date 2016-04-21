using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.SymbolTables
{
    public class Scope
    {
        public Scope Parent { get; private set; }
        private Dictionary<string, Symbol> symbols = new Dictionary<string, Symbol>();

        public Scope(Scope parentScope = null)
        {
            this.Parent = parentScope;
        }

        public void AddSymbol(Symbol symbol)
        {
            this.symbols.Add(symbol.Name, symbol);
        }

        public Symbol GetSymbol(string name)
        {
            var scope = this;
            while (scope != null)
            {
                if (scope.symbols.ContainsKey(name))
                    return scope.symbols[name];

                scope = scope.Parent;
            }

            return null;
        }
    }
}
