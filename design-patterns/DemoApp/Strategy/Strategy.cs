public interface IStrategy
{
    public int DoOperation(int num1, int num2);
}
public class OperationAdd : IStrategy
{
    public int DoOperation(int num1, int num2)
    {
        return num1 + num2;
    }
}
public class OperationSubtract : IStrategy
{
    public int DoOperation(int num1, int num2)
    {
        return num1 - num2;
    }
}
public class OperationMultiply : IStrategy
{
    public int DoOperation(int num1, int num2)
    {
        return num1 * num2;
    }
}
public class OperationDivide : IStrategy
{
    public int DoOperation(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }
        return num1 / num2;
    }
}
