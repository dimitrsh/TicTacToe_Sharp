using System;

namespace tictactoe
{
	public abstract class Player{
		// Abstract, you see.
		protected Field field;       		 // can't exist out of game.
		protected short index;       		 // X or O?
		protected static short count = 0;	 // static to watch over all players.
		public Player(ref Field f) {
			// automatically numerated in creation order.
			this.field = f;
			this.index = ++count;
		}
		public void set_index(short ind){
			// to renumerate players.
			this.index = ind;
		}

		public abstract void move();       // for common interface.
		public abstract void first_move(); // ai first step will be different from all other steps. We don't have to precalculate it.
	};
}

