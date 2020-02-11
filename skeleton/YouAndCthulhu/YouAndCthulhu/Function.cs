using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading;

namespace YouAndCthulhu
{
    public class Function
    {
        // A Function contains an id, composed of a natural and a character,
        // a list of Actions, which are kinds of lambda expressions, and a
        // register.
        private UInt64 idnum;
        private char idchar;
        private List<Action> execution;
        private int accumulator;

        public Function(UInt64 idnum, char idchar, string commands, 
                        FunctionTable ftable)
        {
            this.accumulator = 0;
            this.idnum = idnum;
            this.idchar = idchar;
            ParseCommands(commands,ftable);
        }

        // Getters
        public ulong Idnum => idnum;
        public char Idchar => idchar;
        public int Accumulator => accumulator;

        // Methods implements Function Commands as seen on Esolang.
        public void Increment()
        {
            accumulator ++ ;
        }

        public void Decrement()
        {
            accumulator -- ;
        }

        public void MoveOut(Function f)
        {
            f.accumulator = accumulator;
        }

        public void MoveIn(Function f)
        {
            accumulator = f.accumulator;
        }

        public void Output()
        {
            Console.WriteLine(accumulator);
        }

        public void Input()
        {
            int i = 0;
            Console.Write("Waiting for an integer input: ");
            string s = Console.ReadLine();
            UInt64 id;
            int l = s.Length - 1;
            while (i <= l && char.IsDigit(s[i]))
            {
                i += 1;
            }
            if (i == l + 1)
            {
                id = Convert.ToUInt64(s);
            }
            else
            {
                throw new Exception("Not an integer in Input");
            }
        }
        
        public void Execute()
        {
            List<Action> L = execution;
            int l = L.Count;
            for (int i = 0; i < l; i++)
            {
                L[i]();
            }
        }
        
        private void ParseCommands(string commands, FunctionTable ftable)
        // Given the command string and the ftable, parses commands by creating
        // a lambda expression and adding it to the list every time.
        {
            int index = 0; 
            
            while (index < commands.Length)
            {
                Action act;
                switch (LexerParser.CommandLexer(commands, index++))
                {
                    case LexerParser.CommandToken.TOKEN_INCREMENT:
                    {
                        act = () => { Increment(); };
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_DECREMENT:
                    {
                        act = () => { Decrement(); };
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_OUTPUT:
                    {
                        act = () => { Output(); };
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_INPUT:
                    {
                        act = () => { Input(); };
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_MOVE_IN:
                    {
                        act = () =>
                        {
                            MoveIn(ftable.Search(LexerParser.GetIdNatural(commands, ref index),
                                LexerParser.GetIdLetter(commands, ref index)));
                        };
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_MOVE_OUT:
                    {
                        act = () =>
                        {
                            MoveOut(ftable.Search(LexerParser.GetIdNatural(commands, ref index),
                                LexerParser.GetIdLetter(commands, ref index)));
                        };
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_CALL:
                    {
                        // calling a function simply consists in executing it...
                        act = ftable.Search(LexerParser.GetIdNatural(commands, ref index),
                            LexerParser.GetIdLetter(commands, ref index)).Execute;
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_CALL_ACC:
                    {
                        act = ftable.SearchRegister(accumulator,
                            LexerParser.GetIdLetter(commands, ref index)).Execute;
                        break;
                    }
                    default:
                    {
                        throw new Exception("Unexpected token in parsing");
                    }
                }
                execution.Add(act);
            }
        }
        
    }
}