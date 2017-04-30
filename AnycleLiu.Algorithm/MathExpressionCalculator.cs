using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AnycleLiu.Algorithm
{
    /// <summary>
    /// 四则运算计算器
    /// 运算符支持： +、-、*、/
    /// 支持负数，例如-1*2
    /// 支持小数
    /// </summary>
    public class MathExpressionCalculator : IExpressionCalculator
    {
        private bool CanPop(char c1, char c2)
        {
            if ((c1 == '+' || c1 == '-') && (c2 == '+' || c2 == '-'))
            {
                return true;
            }
            else if ((c1 == '*' || c1 == '/') && (c2 == '+' || c2 == '-' || c2 == '*' || c2 == '/'))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 中缀表达式转后缀表达式(https://zh.wikipedia.org/wiki/%E8%B0%83%E5%BA%A6%E5%9C%BA%E7%AE%97%E6%B3%95)
        /// eg: input:(10.02+2.5-3)*4  output: 10.02 2.5 + 3 - 4 *
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<string> InfixToSuffix(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return new string[0];

            StringBuilder s = new StringBuilder();
            Stack<char> op = new Stack<char>();
            if (expression[0] == '-') s.Append('0');

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if ((c >= '0' && c <= '9') || c == '.')
                {
                    s.Append(c);
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    while (op.Count > 0 && CanPop(op.Peek(), c))
                    {
                        s.Append(' ');
                        s.Append(op.Pop());
                    }
                    op.Push(c);
                    s.Append(' ');
                }
                else if (c == '(')
                {
                    s.Append(' ');
                    op.Push(c);
                    if (expression[i + 1] == '-') s.Append('0');
                }
                else if (c == ')')
                {
                    while (op.Count > 0 && op.Peek() != '(')
                    {
                        s.Append(' ');
                        s.Append(op.Pop());
                    }
                    if (op.Peek() != '(')
                    {
                        throw new Exception("表达式错误，存在不匹配的括号");
                    }
                    op.Pop();
                }
                else
                {
                    throw new Exception(string.Format("表达式含有不支持的字符：{0}", c));
                }
            }
            while (op.Count > 0)
            {
                s.Append(' ');
                s.Append(op.Pop());
            }

            Console.WriteLine("中缀表达式： {0}, 转后缀： {1}", expression, s.ToString());

            return s.ToString().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));
        }

        private decimal Calc(decimal n1, decimal n2, string op)
        {
            switch (op)
            {
                case "+": return n2 + n1;
                case "-": return n2 - n1;
                case "*": return n2 * n1;
                case "/": return n2 / n1;
                default:
                    throw new NotSupportedException(string.Format("不支持操作： {0}", op));
            }
        }

        /// <summary>
        /// 计算后缀表达式 eg： 1 2 3 + *
        /// </summary>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public decimal? CalcSuffixExpression(IEnumerable<string> suffix)
        {
            if (suffix.Count() == 0) return null;

            Stack<decimal> num = new Stack<decimal>();

            foreach (string token in suffix)
            {
                if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    decimal n1 = num.Pop(),
                            n2 = num.Pop();
                    num.Push(Calc(n1, n2, token));
                }
                else
                {
                    num.Push(Convert.ToDecimal(token));
                }
            }

            return num.Pop();
        }

        public object Calculate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return null;

            var r = new Regex(@"\s+", RegexOptions.Compiled);
            expression = r.Replace(expression, "");

            var suffix = InfixToSuffix(expression);

            return CalcSuffixExpression(suffix);
        }
    }
}
