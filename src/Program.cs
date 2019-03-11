using System;
using System.Threading;

namespace src
{
  class Program
  {
    static void Main(string[] args)
    {
      bool cont = true;
      int inputsRead = 0;
      Thread t1 = new Thread(new ThreadStart(ThreadProc));
      t1.Name = "Thread One";
      Thread t2 = new Thread(new ThreadStart(ThreadProc));
      t2.Name = "Thread Two";
      t1.Start();
      t2.Start();

      while (cont)
      {
        var key = Console.ReadKey().Key;
        ++inputsRead;
        switch (inputsRead)
        {
          case 1:
            t1.Interrupt();
            t1.Join();
            break;
          case 2:
            t2.Interrupt();
            t2.Join();
            break;
          case 3:
            Console.WriteLine("All processes terminated");
            break;
          default:
            if (key == ConsoleKey.Escape)
            {
              cont = false;
            }
            else
            {
              Console.WriteLine(key.ToString());
            }
            break;
        }
      }
    }

    public static void ThreadProc()
    {
      bool cont = true;
      while (cont)
      {
        try
        {
          Console.WriteLine($"Message from {Thread.CurrentThread.Name}");
          Thread.Sleep(1000);
        }
        catch (ThreadInterruptedException e)
        {
          Console.WriteLine($"{Thread.CurrentThread.Name} interrupted, terminating...");
          cont = false;
        }
      }
    }
  }
}
