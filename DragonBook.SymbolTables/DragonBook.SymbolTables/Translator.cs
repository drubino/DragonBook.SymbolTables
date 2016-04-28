using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.SymbolTables
{
    public class Translator
    {
        private Token[] tokens;
        private int index;
        private StringBuilder output = new StringBuilder();
        private Scope scope;

        public string Translate(string input)
        {
            this.tokens = new Lexer().Scan(input).ToArray();
            this.index = 0;

            TranslateBlock();
            return output.ToString();
        }

        private void TranslateDeclarations()
        {
            while (Peek(0).Type == "Identifier" && Peek(1).Type == "Identifier")
                TranslateDeclaration();
        }

        private void TranslateDeclaration()
        {
            var type = Match("Identifier");
            Append(type.Value);
            Append(" ");

            var variable = Match("Identifier");
            Append(variable.Value);

            Match("Semicolon");
            Append("; ");

            var symbol = new Symbol(type.Value, variable.Value);
            this.scope.AddSymbol(symbol);
        }

        private void TranslateStatements()
        {
            while (Peek().Value == "{" || Peek().Type == "Identifier")
                TranslateStatement();
        }

        private void TranslateStatement()
        {
            if (Peek().Value == "{")
            {
                TranslateBlock();
            }
            else
            {
                TranslateFactor();
                Match("Semicolon");
                Append("; ");
            }
        }

        private void TranslateBlock()
        {
            var leftBrace = Match("LeftBrace");
            Append(leftBrace.Value);
            Append(" ");

            this.scope = new Scope(this.scope);
            TranslateDeclarations();
            TranslateStatements();
            this.scope = this.scope.Parent;

            var rightBrace = Match("RightBrace");
            Append(rightBrace.Value);
        }

        private void TranslateFactor()
        {
            var id = Match("Identifier");
            var symbol = this.scope.GetSymbol(id.Value);
            Append($"{ id.Value }: { symbol.Type }");
        }

        private void Append(string output)
        {
            this.output.Append(output);
        }

        private Token Peek(int index = 0)
        {
            if (this.index + index >= this.tokens.Length)
                return new Token("", "");
            return this.tokens[this.index + index];
        }

        private Token Match(string tokenType)
        {
            var currentToken = this.tokens[this.index++];
            if (currentToken.Type != tokenType)
                throw new Exception($"A { tokenType } token was not found");

            return currentToken;
        }
    }
}
