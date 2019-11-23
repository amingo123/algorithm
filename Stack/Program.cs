using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> s = new ArrayStack<int>(10);
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);
            s.Pop();
            s.Push(6);
            s.Push(7);
            //s.ToString();

            ExpressionCalculation expression = new ExpressionCalculation("5-1-2");
            expression.Result();
            Console.ReadLine();
        }
    }

    public class ArrayStack<T>
    {
        private int top = -1;
        private int maxsize;
        private T[] array;

        public ArrayStack(int maxsize = 50)
        {
            this.maxsize = maxsize;
            array = new T[maxsize];
        }

        public void Push(T num)
        {
            if (IsFull()) return;
            top++;
            array[top] = num;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("stack is empty!");
            }
            
            T num = array[top];
            array[top] = default(T);
            top--;
            return num;
        }

        public bool IsFull()
        {
            return top == maxsize - 1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public override string ToString()
        {
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
            return base.ToString();
        }
    }

    public class ExpressionCalculationHou
    {

    }

    public class ExpressionCalculation //中缀
    {
        ArrayStack<int> number = new ArrayStack<int>();
        ArrayStack<string> operation = new ArrayStack<string>();
        string expression;
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"+",1 },
            {"-",1 },
            {"*",2 },
            {"/",2 },
        };

        public ExpressionCalculation(string expression)
        {
            this.expression = expression;
        }

        public int calc(int x, int y, string op)
        {
            switch (op)
            {
                case "+":
                    {
                        return x + y;
                    }
                case "-":
                    {
                        return y - x;
                    }
                case "*":
                    {
                        return x * y;
                    }
                case "/":
                    {
                        return y / x;
                    }                    
            }
            return 0;
        }

        public int Result()
        {
            int result = 0;
            int lastop = 0;
            try
            {
                char[] c = expression.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    bool b = int.TryParse(c[i].ToString(), out int m);
                    if (b)
                    {
                        number.Push(m);
                    }
                    else
                    {
                        if (operation.IsEmpty())
                        {
                            operation.Push(c[i].ToString());
                            lastop = dict[c[i].ToString()];
                        }
                        else if (lastop > dict[c[i].ToString()])
                        {
                            //下面代码有问题不能连乘
                            int x = number.Pop();
                            int y = number.Pop();
                            string op = operation.Pop();
                            int r = calc(x, y, op);
                            number.Push(r);
                            lastop = dict[c[i].ToString()];
                            operation.Push(c[i].ToString());
                        }
                        else
                        {
                            operation.Push(c[i].ToString());
                            lastop = dict[c[i].ToString()];
                        }
                    }
                }

                while (!operation.IsEmpty())
                {
                    int x = number.Pop();
                    int y = number.Pop();
                    string op = operation.Pop();
                    int r = calc(x, y, op);
                    number.Push(r);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            result = number.Pop();
            Console.WriteLine(result);
            return result;
        }
    }
}