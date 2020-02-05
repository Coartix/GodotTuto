using System;
using System.Collections.Generic;

namespace YouAndCthulhu
{
    public class FunctionTable
    {
        // List of Function objects
        // A FunctionTable is always sorted. It has elements, each corresponding
        // to a List<Function> containing Function of IdLetter A, B, C or D,
        // respectively contained as elements 0, 1, 2, 3 of the table. These
        // lists are sorted in increasing order of the IdNatural.
        protected List<Function>[] ftable;

        // Constructor
        public FunctionTable()
        {
            ftable = new List<Function>[4];
            for (int i = 0; i < 4; i++)
            {
                ftable[i] = new List<Function>();
            }
        }

        // Used in order to keep the table sorted at all time
        // Search idnum in l. If found, return its index, else, returns the index
        // it should be inserted at.
        public int BinarySearch(List<Function> l, ulong idnum)
        {
            int length = l.Count;
            int i = 0;
            int middle = (length + i) / 2;
            while (i < length - 1 && l[middle].Idnum != idnum)
            {
                middle = (i + length) / 2;
                
                if (l[middle].Idnum > idnum)
                {
                    length = middle;
                }
                else
                {
                    i = middle;
                }
            }
            if (l[middle].Idnum == idnum)
                return middle;
            else
            {
                return length;
            }
        }

        // Adds a function at the right place in the table
        public void Add(Function f)
        {
            //Manque l'exception.
            List<Function> p = ftable[f.Idchar - 'A'];
            p.Insert(BinarySearch(p,f.Idnum),f);
                
        }

        // Search method, returns the right function.
        public Function Search(ulong idnum, char idchar)
        {
            throw new NotImplementedException("Do it");
        }

        // Same but with a register which could be negative
        public Function SearchRegister(int register, char idchar)
        {
            throw new NotImplementedException("Do it");
        }

        // Executes the ftable (by executing 0A)
        public void Execute()
        {
            throw new NotImplementedException("Do it");
        }
    }
}