using Snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Bot
{
    public class FindApath
    {
        private Stack<ConsoleKey> ConsoleKeys;
        private Stack<Point> Points;
        private HashSet<Point> Visted;

        public FindApath()
        {
            ConsoleKeys = new Stack<ConsoleKey>();
            Points = new Stack<Point>();
            Visted = new HashSet<Point>();
        }

        public Queue<ConsoleKey> FindAPath(Models.Snake snake,Food food)
        {
            Points.Push(snake.Head);
            Visted.Add(snake.Head);
            while (true)
            {
                Point currentPoint = Points.Peek();
                Point nextPoint = GetNextPoint(currentPoint, food, snake);
                if (nextPoint!=null)
                {
                    Visted.Add(new Point(nextPoint.X, nextPoint.Y));
                    // For Debugging
                    //Console.SetCursorPosition(nextPoint.X, nextPoint.Y);
                    //Console.Write('.');
                    Points.Push(nextPoint);
                    if (nextPoint.X-currentPoint.X==-1)
                    {
                        ConsoleKeys.Push(ConsoleKey.LeftArrow);
                    }
                    else if (nextPoint.X - currentPoint.X == 1)
                    {
                        ConsoleKeys.Push(ConsoleKey.RightArrow);
                    }
                    if (nextPoint.Y - currentPoint.Y == -1)
                    {
                        ConsoleKeys.Push(ConsoleKey.UpArrow);
                    }
                    else if (nextPoint.Y - currentPoint.Y == 1)
                    {
                        ConsoleKeys.Push(ConsoleKey.DownArrow);
                    }
                    double distance = CalculateDistance(food, nextPoint);
                    if ( distance == 0)
                    {
                        break;
                    }
                }
                else
                {
                    Points.Pop();
                    if (Points.Count==0)
                    {
                        break;
                    }
                    ConsoleKeys.Pop();
                }
            }
            Stack<ConsoleKey> temp = new Stack<ConsoleKey>();
            Queue<ConsoleKey> output = new Queue<ConsoleKey>();
            while (ConsoleKeys.Count!=0)
            {
                temp.Push(ConsoleKeys.Pop());
            }
            while (temp.Count != 0)
            {
                output.Enqueue(temp.Pop());
            }
            return output;
        }

        private double CalculateDistance(Point a,Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        private List<Point> ValidPoints(Point p, Models.Snake snake)
        {
            List<Point> output = new List<Point>();
            Point currentPoint;
            currentPoint = new Point(p.X + 1, p.Y);
            if (IsValidPoint(currentPoint,snake))
            {
                output.Add(currentPoint);
            }
            currentPoint = new Point(p.X - 1, p.Y);
            if (IsValidPoint(currentPoint, snake))
            {
                output.Add(currentPoint);
            }
            currentPoint = new Point(p.X, p.Y+1);
            if (IsValidPoint(currentPoint, snake))
            {
                output.Add(currentPoint);
            }
            currentPoint = new Point(p.X, p.Y-1);
            if (IsValidPoint(currentPoint, snake))
            {
                output.Add(currentPoint);
            }
            return output;
        }

        private bool IsValidPoint(Point p,Models.Snake snake)
        {
            if (snake.Body.Any(a => a.X == p.X && a.Y == p.Y))
            {
                return false;
            }
            if (Visted.Any(a=>a.X==p.X && a.Y==p.Y))
            {
                return false;
            }
            if (Points.Any(a => a.X == p.X && a.Y == p.Y))
            {
                return false;
            }
            if (p.X<1 ||p.Y<1||p.X>snake.MaxX-2 ||p.Y>snake.MaxY-2)
            {
                return false;
            }
            return true;
        }

        private Point GetTheBestPoint(List<Point> points,Food food)
        {
            return points.OrderBy(x => CalculateDistance(x, food)).FirstOrDefault();
        }

        private Point GetNextPoint(Point p,Food food,Models.Snake snake)
        {
            return GetTheBestPoint(ValidPoints(p, snake), food);
        }
    }
}
