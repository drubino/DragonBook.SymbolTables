using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.SymbolTables
{
    public class Lexer
    {
        public IEnumerable<Token> Scan(string input)
        {
            StringBuilder identifier = null;
            foreach (var c in input)
            {
                switch (c)
                {
                    case '{':
                        if (identifier != null)
                            yield return CreateIdentifier(ref identifier);
                        yield return new Token("LeftBrace", "{");
                        break;
                    case '}':
                        if (identifier != null)
                            yield return CreateIdentifier(ref identifier);
                        yield return new Token("RightBrace", "}");
                        break;
                    case ';':
                        if (identifier != null)
                            yield return CreateIdentifier(ref identifier);
                        yield return new Token("Semicolon", ":");
                        break;
                    case ' ':
                        if (identifier != null)
                            yield return CreateIdentifier(ref identifier);
                        break;
                    default:
                        if (identifier == null)
                            identifier = new StringBuilder();
                        identifier.Append(c);
                        break;
                }
            }
        }

        private Token CreateIdentifier(ref StringBuilder identifier)
        {
            var id = new Token("Identifier", identifier.ToString());
            identifier = null;
            return id;
        }
    }
}
