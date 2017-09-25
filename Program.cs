using System;
using System.Collections;
using System.Text;

namespace tictactoe
{
	class MainClass
	{
		public static void MainLoop(ref Field f, ref Player p1, ref Player p2){
			short stat = 0;
			p1.set_index(Field.X); 	// players got they numbers automatically, but we can renumerate them.
			p2.set_index(Field.O);
			p1.first_move(); 		// make sense only at AI first step.
			f.print();
			while (stat == 0){
				p2.move();
				f.print ();
				stat = f.status();
				if (stat != 0) break;
				p1.move();
				f.print ();
				stat = f.status();
			}
			if (stat == Field.P1_WIN)
				Console.WriteLine ("P1 wins!");
			else if (stat == Field.P2_WIN)
				Console.WriteLine ("P2 wins!");
			else
				Console.WriteLine ("Tie");
		}
		public static void Main (string[] args)
		{
			Field f = new Field ();
			Player r = new Robot (ref f);
			Player h = new Human (ref f);
			int continue_flag = 1;
			int order;
			while (continue_flag == 1) {
				do {
					Console.Write ("Chose player (1 - X, 2 - O): ");
					order = Convert.ToInt32 (Console.ReadLine ());
					if (order == 1)
						MainLoop (ref f, ref h, ref r);
					else if (order == 2)
						MainLoop (ref f, ref r, ref h);
				} while(order != 1 && order != 2);
				Console.Write ("1 - continue, any other number - exit: ");
				continue_flag = Convert.ToInt32 (Console.ReadLine ());
				f.clear ();
			}
		}
	}
}
