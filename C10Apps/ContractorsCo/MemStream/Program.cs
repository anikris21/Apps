using System;
using System.Text;
using System.IO;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        byte[] byteArray = new byte[100];
        byte[] byteArray1 = new byte[100];


        string str = "Hello Mono World";
        string str1 = "welcome PL";
        int c = Encoding.UTF8.GetBytes(str, 0, str.Length, byteArray, 0);
        int c1 = Encoding.UTF8.GetBytes(str1, 0, str1.Length, byteArray1, 0);
        MemoryStream bufferStream = new MemoryStream(byteArray, 0, c, writable: true);
        Console.WriteLine("bufferStream Position {0}", bufferStream.Position);
        bufferStream.Write(byteArray1, 0, c1);
        Console.WriteLine("bufferStream Position {0}", bufferStream.Position);
        bufferStream.Close();
        Console.WriteLine("byteArray {0}", Encoding.UTF8.GetString(byteArray, 0, c + c1));

        Console.WriteLine("Hello Mono World");
    }
}