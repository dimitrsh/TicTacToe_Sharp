using System;

namespace tictactoe
{
	public class Human : Player
	{
		public Human (ref Field f) : base(ref f) {}
		public override void move(){                                                 // keyboard input. Now it's only console version.
			Console.Write("Insert x, y : ");
			string[] user_input = Console.ReadLine().Split();
			int x = Convert.ToInt32 (user_input [0]);
			int y = Convert.ToInt32 (user_input [1]);
			int lind = (x - 1) * 3 + (y - 1);
			if (lind >= 0 && lind < 9 && field[lind] == Field.EMPTY) field[lind] = index;
			else move();
		}
		public override void first_move(){                                           // the same as other 'move' for human.
			move();
		}
	}
}

