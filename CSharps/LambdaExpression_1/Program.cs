using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25

            Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);
            // Output:
            // x => (x * x)

            int[] numbers1 = { 2, 3, 4, 5 };
            var squaredNumbers = numbers1.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));
            // Output:
            // 4 9 16 25

            #region lambda 表达式和元组
            Func<(int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);
            var numbers2 = (2, 3, 4);
            var doubledNumbers = doubleThem(numbers2);
            Console.WriteLine($"The set {numbers2} doubled: {doubledNumbers}");
            // Output:
            // The set (2, 3, 4) doubled: (4, 6, 8)

            Func<(int n1, int n2, int n3), (int, int, int)> doubleThem2 = ns => (2 * ns.n1, 2 * ns.n2, 2 * ns.n3);
            var numbers3 = (2, 3, 4);
            var doubledNumbers2 = doubleThem(numbers3);
            Console.WriteLine($"The set {numbers3} doubled: {doubledNumbers2}");
            #endregion

            #region 表达式树
            Expression<Func<int, int>> addFive = (num) => num + 5;

            if (addFive.NodeType == ExpressionType.Lambda)
            {
                var lambdaExp = (LambdaExpression)addFive;

                var parameter = lambdaExp.Parameters.First();

                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.Type);
            }

            Console.WriteLine(~0);

            var x2 = 1;

            // Addition is an add expression for "1 + 2"
            var one = Expression.Constant(x2, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two);

            //var func = addition;
            Expression<Func<int, int, bool>> add = (x, y) => x == y;
            var func = add.Compile(); // Create Delegate
            var answer = func; // Invoke Delegate
            Console.WriteLine(answer);

            var createBoundFunc = CreateBoundFunc();

            Console.WriteLine(createBoundFunc(1));

            Expression<Func<int>> sum = () => 1 + 2 + 3 + 4;

            var visitor = Visitor.CreateFromExpression(sum);

            visitor.Visit("");

            Expression<Func<double, double, double>> distanceCalc = (x, y) => Math.Sqrt(x * x + y * y);

            var d1 = distanceCalc.Compile();

            Console.WriteLine(d1(3, 4));

            var xParameter = Expression.Parameter(typeof(double), "x");
            var yParameter = Expression.Parameter(typeof(double), "y");
            var xSquared = Expression.Multiply(xParameter, xParameter);
            var ySquared = Expression.Multiply(yParameter, yParameter);
            var sum2 = Expression.Add(xSquared, ySquared);
            var sqrtMethod = typeof(Math).GetMethod("Sqrt", new[] { typeof(double) });
            var distance = Expression.Call(sqrtMethod, sum2);
            var d2 = (Func<double, double, double>)Expression.Lambda(distance, xParameter, yParameter).Compile();

            Console.WriteLine(d2(3, 4));

            var nArgument = Expression.Parameter(typeof(int), "n");
            var result = Expression.Variable(typeof(int), "result");

            // Creating a label that represents the return value
            LabelTarget label = Expression.Label(typeof(int));

            var initializeResult = Expression.Assign(result, Expression.Constant(1));

            // This is the inner block that performs the multiplication,
            // and decrements the value of 'n'
            var block = Expression.Block(
                Expression.Assign(result,
                    Expression.Multiply(result, nArgument)),
                Expression.PostDecrementAssign(nArgument)
            );

            // Creating a method body.
            BlockExpression body = Expression.Block(
                new[] { nArgument },
                initializeResult,
                Expression.Loop(
                    Expression.IfThenElse(
                        Expression.GreaterThan(nArgument, Expression.Constant(1)),
                        block,
                        Expression.Break(label, result)
                    ),
                    label
                )
            );

            //var b1 = (Func<int, int>)Expression.Lambda(body).Compile();

            //Console.WriteLine(b1(5));
            #endregion



            Action l = () => Console.WriteLine(1);

            Action l1 = () => { Console.WriteLine(1); };

            Func<bool> s = () => true;

            Func<bool> ss = () => { return true; };

            Console.ReadKey();
        }

        private static Func<int, int> CreateBoundFunc()
        {
            var constant = 5; // constant is captured by the expression tree
            Expression<Func<int, int>> expression = (b) => constant + b;
            var rVal = expression.Compile();
            return rVal;
        }

        private static Func<int, int> CreateBoundResource()
        {
            using (var constant = new Resource()) // constant is captured by the expression tree
            {
                Expression<Func<int, int>> expression = (b) => constant.Argument + b;
                var rVal = expression.Compile();
                return rVal;
            }
        }
    }

    public class Resource : IDisposable
    {
        private bool isDisposed = false;
        public int Argument
        {
            get
            {
                if (!isDisposed)
                    return 5;
                else throw new ObjectDisposedException("Resource");
            }
        }

        public void Dispose()
        {
            isDisposed = true;
        }
    }

    // Base Visitor class:
    public abstract class Visitor
    {
        private readonly Expression node;

        protected Visitor(Expression node)
        {
            this.node = node;
        }

        public abstract void Visit(string prefix);

        public ExpressionType NodeType => this.node.NodeType;
        public static Visitor CreateFromExpression(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    return new ConstantVisitor((ConstantExpression)node);
                case ExpressionType.Lambda:
                    return new LambdaVisitor((LambdaExpression)node);
                case ExpressionType.Parameter:
                    return new ParameterVisitor((ParameterExpression)node);
                case ExpressionType.Add:
                    return new BinaryVisitor((BinaryExpression)node);
                default:
                    Console.Error.WriteLine($"Node not processed yet: {node.NodeType}");
                    return default(Visitor);
            }
        }
    }

    // Lambda Visitor
    public class LambdaVisitor : Visitor
    {
        private readonly LambdaExpression node;
        public LambdaVisitor(LambdaExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression type");
            Console.WriteLine($"{prefix}The name of the lambda is {((node.Name == null) ? "<null>" : node.Name)}");
            Console.WriteLine($"{prefix}The return type is {node.ReturnType.ToString()}");
            Console.WriteLine($"{prefix}The expression has {node.Parameters.Count} argument(s). They are:");
            // Visit each parameter:
            foreach (var argumentExpression in node.Parameters)
            {
                var argumentVisitor = Visitor.CreateFromExpression(argumentExpression);
                argumentVisitor.Visit(prefix + "\t");
            }
            Console.WriteLine($"{prefix}The expression body is:");
            // Visit the body:
            var bodyVisitor = Visitor.CreateFromExpression(node.Body);
            bodyVisitor.Visit(prefix + "\t");
        }
    }

    // Binary Expression Visitor:
    public class BinaryVisitor : Visitor
    {
        private readonly BinaryExpression node;
        public BinaryVisitor(BinaryExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This binary expression is a {NodeType} expression");
            var left = Visitor.CreateFromExpression(node.Left);
            Console.WriteLine($"{prefix}The Left argument is:");
            left.Visit(prefix + "\t");
            var right = Visitor.CreateFromExpression(node.Right);
            Console.WriteLine($"{prefix}The Right argument is:");
            right.Visit(prefix + "\t");
        }
    }

    // Parameter visitor:
    public class ParameterVisitor : Visitor
    {
        private readonly ParameterExpression node;
        public ParameterVisitor(ParameterExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This is an {NodeType} expression type");
            Console.WriteLine($"{prefix}Type: {node.Type.ToString()}, Name: {node.Name}, ByRef: {node.IsByRef}");
        }
    }

    // Constant visitor:
    public class ConstantVisitor : Visitor
    {
        private readonly ConstantExpression node;
        public ConstantVisitor(ConstantExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This is an {NodeType} expression type");
            Console.WriteLine($"{prefix}The type of the constant value is {node.Type}");
            Console.WriteLine($"{prefix}The value of the constant value is {node.Value}");
        }
    }
}
