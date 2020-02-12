using System;
using System.Collections.Generic;
using System.Linq;

namespace Lost_in_Wonderland
{
    public class BinaryMaze
    {
        private static List<Maze.Direction> GetDir(Maze maze, int i, int j)
        {
            //TODO
            // Returns a list of directions you can go from this cell
            throw new NotImplementedException();
        }    
        
        public static Maze GenBinaryMaze(int size)
        {
            //TODO
            // Builds a maze using the binary tree algorithm:
            //    1. Start at the bottom-right corner
            //    2. Choose randomly a direction between North and West
            //    3. Break the wall
            //    4. Repeat on the adjacent cell (right) until the end
            throw new NotImplementedException();
        }
    }
}