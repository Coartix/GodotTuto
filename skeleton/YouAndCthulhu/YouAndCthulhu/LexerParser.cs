using System;
using System.Diagnostics;

namespace YouAndCthulhu
{
    public class LexerParser
    {
        public enum CommandToken
        // Tokens used in parsing a function's command line.
              {
                  TOKEN_INCREMENT, //i
                  TOKEN_DECREMENT, //d
                  TOKEN_CALL,      //[
                  TOKEN_CALL_ACC,  //]
                  TOKEN_OUTPUT,    //o
                  TOKEN_INPUT,     //*
                  TOKEN_MOVE_OUT,  //E
                  TOKEN_MOVE_IN,    //e
                  TOKEN_DEFAULT    //error
              }

        public static Function LineToFunction(string s, FunctionTable ftable)
        {
            char[] delimiter = {' '};
            string[] parts = s.Trim().Split(delimiter);
            if (parts.Length != 2)
                throw new Exception("Line does not respect syntax");

            int index = 0;
            ulong idnum = GetIdNatural(parts[0], ref index);
            char idchar = GetIdLetter(parts[0], ref index);
            if (index != parts[0].Length)
                throw new Exception("Wrong line format !");
            Function f = new Function(idnum, idchar, parts[1], ftable);

            return f;
        }

        public static char GetIdLetter(string s, ref int index)
        // given a string and index pointing to the supposed place of an IdLetter, returns said letter.
        {
            char id;

            if (string.IsNullOrEmpty(s))
            {
                throw new Exception("String is empty in GetIdLetter");
            } 
            id = s[index];
            if (id != 'A' && id != 'B' && id != 'C' && id != 'D') 
            { 
                throw new Exception("Not a valid letter in GetIdLetter");
            }
            index += 1;
            return id;
        }

        public static UInt64 GetIdNatural(string s, ref int index)
        // given a string and index pointing to the supposed place of an Id's Natural, returns said natural.
        {
            string str = "";
            UInt64 id;
            int l = s.Length - 1;
            while (index <= l && char.IsDigit(s[index]))
            {
                str += s[index];
                index += 1;
            }
            try
            {
                id = Convert.ToUInt64(str);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return id;
        }

        public static CommandToken CommandLexer(string s, int index)
        // returns CommandToken of the given index.
        {
            CommandToken res;
            if (string.IsNullOrEmpty(s))
            {
                throw new Exception("String is empty in CommandLexer");
            }

            char c = s[index];

            switch (c)
            {
                case 'i':
                    res = CommandToken.TOKEN_INCREMENT;
                    break;
                case 'd':
                    res = CommandToken.TOKEN_DECREMENT;
                    break;
                case '*':
                    res = CommandToken.TOKEN_INPUT;
                    break;
                case 'o':
                    res = CommandToken.TOKEN_OUTPUT;
                    break;
                case '[':
                    res = CommandToken.TOKEN_CALL;
                    break;
                case ']':
                    res = CommandToken.TOKEN_CALL_ACC;
                    break;
                case 'e':
                    res = CommandToken.TOKEN_MOVE_IN;
                    break;
                case 'E':
                    res = CommandToken.TOKEN_MOVE_OUT;
                    break;
                default:
                    res = CommandToken.TOKEN_DEFAULT;
                    break;
            }

            return res;
        }
    }
}