using System;
using System.ComponentModel.DataAnnotations;

namespace Lost_in_Wonderland
{
    public class Maze
    {
        public enum Direction
        {
            NORTH,
            SOUTH,
            EAST,
            WEST,
            NULL
        }
        private Cell[,] maze;
        private int size;

        public Maze(int size)
        {
            this.size = size;
            maze = new Cell[size,size];
            for (int i = 0; i < maze.Length; i++)
            {
                for (int k = 0; k < maze.Length; k++)
                {
                   if (i==0 & k==0)
                       maze[i,k]=new Cell(true,false);
                   else if (i==maze.Length-1 & k==maze.Length-1)
                       maze[i,k]=new Cell(false,true);
                   else
                   {
                       maze[i,k]=new Cell(false,false);
                   }
                }
            }
        }
        
        
        
        
        
        
        #region PrettyPrint
        
        public void CarvePath(int i, int j, Direction dir)
        {
            //TODO
            // Break the wall between the current cell [i, j] and the next cell in the direction dir 
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region PrettyPrint
        
        public string MazeToString()
        {
            //TODO
            // Transforms the maze into a string (follow EXACTLY the output of the subject)
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region Backtracking 

        public bool IsExit(int i, int j)
        {
            //TODO
            throw new NotImplementedException();
        }
        
        public void MarkPath(int i, int j)
        {
            maze[i, j].IsPath = !maze[i, j].IsPath;
        }

        public bool IsPath(int i, int j)
        {
            //TODO
            throw new NotImplementedException();
        }

        public bool IsValidCell(int i, int j)
        {
            //TODO
            throw new NotImplementedException();return (i >= 0 && i < size && j >= 0 && j < size);
        }

        public bool IsValidDirection(int i, int j, Direction direction)
        {
            //TODO
            throw new NotImplementedException();
        }
        
        #endregion
    }
}