using System;

namespace tictactoe
{
	public class Field
	{
		private short[] vals;
		private bool is_winner(short player){
			if ((vals[0] == vals[1] && vals[0] == vals[2] && vals[0] == player) || // first row
				(vals[3] == vals[4] && vals[3] == vals[5] && vals[3] == player) || // second row
				(vals[6] == vals[7] && vals[6] == vals[8] && vals[6] == player) || // third row
				(vals[0] == vals[3] && vals[0] == vals[6] && vals[0] == player) || // first column
				(vals[1] == vals[4] && vals[1] == vals[7] && vals[1] == player) || // second column
				(vals[2] == vals[5] && vals[2] == vals[8] && vals[2] == player) || // third column
				(vals[0] == vals[4] && vals[0] == vals[8] && vals[0] == player) || // diagonal from left top to right bottom
				(vals[2] == vals[4] && vals[2] == vals[6] && vals[2] == player))   // diagonal from right top to left bottom
				return true;
			return false;
		}
		private bool is_full(){
			for(int i = 0; i < 9; i++){
				if(vals[i] == EMPTY) return false;
			}
			return true;
		}
		public const short X = 1, O = 2, EMPTY = 0, P1_WIN = 4, P2_WIN = -4, TIE = 2;
		public Field() {
			vals = new short[9];
			for (int i = 0; i < 9; i++) vals[i] = EMPTY;
		}
		public short status(){
			if(this.is_winner(X)) return P1_WIN;       // X is winner.
			else if(this.is_winner(O)) return P2_WIN;  // O is winner.
			else if(this.is_full()) return TIE;        // Tie.
			else return 0;                             // Game continues.
		}
		public short this [int lind]{
			get{
				if (lind >= 0 && lind < 9) {
					return vals [lind];
				}
				return -1;
			}
			set{
				if (lind >= 0 && lind < 9) {
					vals [lind] = value;
				}
			}
		}
		public void print(){
			char[] symbs = { '.', 'X', 'O' };
			for (int i = 0; i < 3; i++) {
				int row = i * 3;
				for (int j = 0; j < 3; j++) {
					int lind = row + j;
					Console.Write (symbs[vals [lind]] + "\t");
				}
				Console.WriteLine ();
			}
		}
		public void clear(){
			for (int i = 0; i < 9; i++) vals[i] = EMPTY;
		}
	}
}

