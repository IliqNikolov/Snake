using SimpleSnake.Enums;
using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Models
{
    public class Snake:GameObject
    {
        public Queue<Body> Body { get; private set; }
        public Head Head { get; private set; }
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public int Score { get; private set; }
        private List<Food> Foods;
        private bool DeadlyWalls;
        public Direction OriginDirection { get; private set; }

        public override void Render()
        {
            Head.Render();
            foreach (var bodiElement in Body)
            {
                bodiElement.Render();
            }
        }

        public Snake(int maxX,int maxY,List<Food> foods,bool deadlyWalla)
        {
            Body = new Queue<Body>();
            GeneratSnake(maxX, maxY, 10);
            this.MaxX = maxX;
            this.MaxY =maxY;
            Score = 0;
            this.Foods = foods;
            this.DeadlyWalls = deadlyWalla;
            //OriginDirection = Direction.Up;
        }

        public bool ContainsPoint(int x,int y)
        {
            return Body.Any(b => b.X == x && b.Y == y) || (Head.X == x && Head.Y == y);

        }

        private void MoveBody(Direction d1)
        {
            Body.Dequeue().DeVisualise();
            Body.Enqueue(new Body(Head.X,Head.Y,d1,OriginDirection));
        }

        private Direction ReverseDirection(Direction d)
        {
            if (d == Direction.Up)
            {
                return Direction.Down;
            }
            else if (d == Direction.Down)
            {
                return Direction.Up;
            }
            else if (d == Direction.Left)
            {
                return Direction.Right;
            }
            else 
            {
                return Direction.Left;
            }
        }

        private void SetOriginDirection(Direction d)
        {
            OriginDirection = ReverseDirection(d);
        }

        private void Eat(Food food,Direction d1)
        {
            Score += food.Score;
            Foods.Remove(food);
            Body.Enqueue(new Body(Head.X, Head.Y, d1, OriginDirection));
        }

        private void GeneratSnake(int maxX,int maxY,int length)
        {
            Random random = new Random();
            int x = random.Next(length+1, maxX - length);
            int y = random.Next(length+1, maxY - length);
            int direction = random.Next(0, 4);
            Stack<Body> temp = new Stack<Body>();
            SetOriginDirection( (Direction)Enum.ToObject(typeof(Direction), direction));
            Head = new Head(x, y, (Direction)Enum.ToObject(typeof(Direction), direction));
            char ch='?';
            if (direction<2)
            {
                ch = '═';
            }
            else
            {
                ch = '║';
            }
            for (int i = 0; i < length; i++)
            {
                if (direction==0)
                {
                    x--;
                }
                else if (direction==1)
                {
                    x++;
                }
                else if (direction ==2)
                {
                    y--;
                }
                else if (direction==3)
                {
                    y++;
                }
               temp.Push(new Body(x, y, ch));
            }
            while (temp.Count!=0)
            {
                Body.Enqueue(temp.Pop());
            }
        }
       
        public void Move(Direction d)
        {
            if (OriginDirection==d)
            {
                d = ReverseDirection(d);
            }          
            Point newHead;
            switch (d)
            {
                case Direction.Right:
                    if (Head.X==MaxX-1)
                    {
                        if (DeadlyWalls)
                        {
                            throw new GameOver(Score.ToString());
                        }
                        newHead = new Point(1, Head.Y);
                    }
                    else
                    {
                        newHead = new Point(Head.X + 1, Head.Y);
                    }
                    break;
                case Direction.Left:
                    if (Head.X == 1)
                    {
                        if (DeadlyWalls)
                        {
                            throw new GameOver(Score.ToString());
                        }
                        newHead = new Point(MaxX-1, Head.Y);
                    }
                    else
                    {

                        newHead = new Point(Head.X - 1, Head.Y);
                    }
                    break;
                case Direction.Down:
                    if (Head.Y == MaxY-1)
                    {
                        if (DeadlyWalls)
                        {
                            throw new GameOver(Score.ToString());
                        }
                        newHead = new Point(Head.X, 1);
                    }
                    else
                    {

                        newHead = new Point(Head.X, Head.Y + 1);
                    }
                    break;
                case Direction.Up:
                    if (Head.Y ==1)
                    {
                        if (DeadlyWalls)
                        {
                            throw new GameOver(Score.ToString());
                        }
                        newHead = new Point(Head.X, MaxY-1);
                    }
                    else
                    {

                        newHead = new Point(Head.X, Head.Y - 1);
                    }
                    break;
                default:
                    newHead = null;
                    break;
            }
            if (Body.Any(b=>b.X==newHead.X &&b.Y==newHead.Y))
            {
                throw new GameOver(Score.ToString());
            }
            Food food = Foods.Where(x => x.X == newHead.X && x.Y == newHead.Y).FirstOrDefault();
            if (food!=null)
            {
                Eat(food,d);
            }
            else
            {
                MoveBody(d);
            }
            SetOriginDirection(d);
            Head = new Head(newHead.X,newHead.Y,d);
        }
    }
}
