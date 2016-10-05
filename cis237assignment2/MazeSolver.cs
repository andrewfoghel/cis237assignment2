using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;


        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        { }

        // move right and left
        public int moveRight(int x)
        {
            x = x + 1;
            return x;
        }
        public int moveLeft(int x)
        {
            x = x - 1;
            return x;
        }
        //move up and down
        public int moveUp(int y)
        {
            y = y + 1;
            return y;
        }
        public int moveDown(int y)
        {
            y = y - 1;
            return y;
        }

        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            char start = maze[xStart, yStart];
            List<char> visited = new List<char>();
            visited.Add(start);

            //Do work needed to use mazeTraversal recursive call and solve the maze.

            mazeTraversal(start, visited);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(char start, List<char> visited)
        {
            //Implement maze traversal recursive call
            //      char start = maze[xStart, yStart];
            //      List<char> visited = new List<char>();
            char end = maze[8, 10];
            char current = start;
            //      visited.Add(current);

            try
            {
                if (current == end)
                {
                    Console.WriteLine("Maze solved");
                }
                else
                {

                    //     while (current == '.')
                    //     {
                    // MOVE LEFT
                    moveLeft(xStart);
                    current = maze[xStart, yStart];
                    visited.Add(current);
                    //HIT WALL RETURN AND MOVE RIGHT
                    if (current == '#')
                    {
                        current = visited[visited.Count - 1];
                        moveRight(xStart);
                        current = maze[xStart, yStart];
                        visited.Add(current);
                        //HIT WALL RETURN AND MOVE DOWN
                        if (current == '#')
                        {
                            current = visited[visited.Count - 1];
                            moveDown(yStart);
                            current = maze[xStart, yStart];
                            visited.Add(current);
                            //HIT WALL RETURN AND MOVE UP
                            if (current == '#')
                            {
                                current = visited[visited.Count - 1];
                                moveUp(yStart);
                                current = maze[xStart, yStart];
                                visited.Add(current);
                            }
                        }
                    }
                    mazeTraversal(current, visited);
                }
                //    }

                //    for(i=0;i < maze.Lenght; i++){
                //        for (j = 0; j < maze[0].Lenght; j++)
                //        {
                //            moveLeft(xStart);
                //            current = maze[xStart,yStart];
                //            visited[i] = current;
                //            if(current == '#')
                //            {
                //                current = visted[i - 1];
                //                moveRight(xStart)
                //            }
                //        }
                //
                //    }

            }
            catch (StackOverflowException e)
            {
                Console.WriteLine("StackOverFlowException");
            }
        }
    }
}
