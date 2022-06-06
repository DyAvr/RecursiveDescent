internal class Program
{
    static string currChain;
    static int currIndex;

    static void Main()
    {
        Console.WriteLine(
            IsDerivable(Console.ReadLine() ?? String.Empty) ? "Success" : "Failure");
    }

    private static bool IsDerivable(String chain)
    {
        currChain = chain;
        currIndex = 0;
        try {
            S();
            return true;
        } catch (Exception) {
            return false;
        }
    }

    private static void ThrowError() => throw new Exception("false");

    private static char GetChar() => currChain[currIndex++];

    private static void S() {
        char c = GetChar();
        if (c != 'a')
            ThrowError();
        E();
        if (currIndex != currChain.Length)
            ThrowError();
    }

    private static void A() {
        char c = GetChar();
        if (c != 'b')
            ThrowError();
        F();
    }

    private static void B() {
        char c = GetChar();
        if (c != 'c')
            ThrowError();
        C();
        G();
    }

    private static void C() {
        char c = GetChar();
        if (c != 'a' && c!= 'b')
            ThrowError();
    }

    private static void D() {
        char c = GetChar();
        if (c == 'a')
        {
            c = GetChar();
            if (c != 'a')
                ThrowError();
            G();
        }
        else
        {
            currIndex--;
            B();
            c = GetChar();
            if (c != 'b')
                ThrowError();
            G();
        }
    }

    private static void E() {
        char c = GetChar();
        if (c == 'b') {
            A();
        }
        else if (c == 'c'){
            A();
            B();
        }
        else if (c == 'a')
        {
            C();
        } else 
            ThrowError();
    }

    private static void F() {
        char c = GetChar();
        if (c == 'c') {
            A();
            B();
        }
        else if (c == 'b'){
            B();
            A();
        }
        else if (c != 'a')
            ThrowError();
    }
    private static void G() {
        char c = GetChar();
        if (c != 'b')
        {
            D();
        }
    }
}