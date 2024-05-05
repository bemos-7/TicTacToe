using System;

namespace bemostictactoe
{
	class Program
	{
		static void Main(string[] args)
		{
            tictactoe tictactoe = new tictactoe();
            tictactoe.Game();
            Console.ReadLine();
        }
	}
}