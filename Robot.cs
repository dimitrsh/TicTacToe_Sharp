using System;

namespace tictactoe
{
	public class Robot : Player
	{
		private int max_depth = 7;
		public Robot(ref Field f, short max_depth_) : base(ref f){
			max_depth = max_depth_;
		}
		public Robot(ref Field f) : base(ref f) {}

		private short miny(int cur_depth){
			short status = field.status();
			if (status != Field.EMPTY || cur_depth == max_depth) return status;
			short res_stat = 10;                                     // there may be any other positive number that greater than 4.
			for(int i = 0; i < 9; i++){
				if(field[i] == Field.EMPTY) {
					field[i] = Field.O;
					short cur_stat = maxy(cur_depth + 1);
					field[i] = Field.EMPTY;
					if (cur_stat < res_stat) res_stat = cur_stat;
					if (res_stat == Field.P2_WIN ) return res_stat;
				}
			}
			return res_stat;
		}
		private short maxy(int cur_depth){
			short status = field.status();
			if (status != Field.EMPTY || cur_depth == max_depth) return status;
			short res_stat = -10;                                    // there may be any other negative number that less than -4.
			for(int i = 0; i < 9; i++){
				if(field[i] == Field.EMPTY) {
					field[i] = Field.X;                           // put current player sign in the first empty cell
					short cur_stat = miny(cur_depth + 1);     // try to find the better position for opponent, if this cell was used.
					field[i] = Field.EMPTY;                          // return field to previous state,
					if (cur_stat > res_stat) res_stat = cur_stat;    // find the worst state for opponent.
					if (res_stat == Field.P1_WIN ) return res_stat;  // use first better position. All others will not be better than this.
																	 // it accelerates first wise ai step for about 12 times!
				}
			}
			return res_stat;
		}
		public override void move ()
		{
			int mind = -1;  // index of next position.
						    // next two conditions are just the first steps of 'miny' or 'maxy' functions, depends on what player it is.
			if(index == Field.X){
				short res_stat = -10;
				for(int i = 0; i < 9; i++){
					if(field[i] == Field.EMPTY){
						field[i] = Field.X;
						short cur_stat = miny(1);
						field[i] = Field.EMPTY;
						if (cur_stat > res_stat){
							res_stat = cur_stat;
							mind = i;
						}
						if (res_stat == Field.P1_WIN) break;
					}
				}
			}
			else{
				short res_stat = 10;
				for(int i = 0; i < 9; i++){
					if(field[i] == Field.EMPTY){
						field[i] = Field.O;
						short cur_stat = maxy(1);
						field[i] = Field.EMPTY;
						if (cur_stat < res_stat){
							res_stat = cur_stat;
							mind = i;
						}
						if (res_stat == Field.P2_WIN) break;
					}
				}
			}
			// now 'mind' contains the index of cell, that AI should use.
			field[mind] = index;
		}
		public override void first_move(){
			// just random position.
			Random rnd = new Random();
			int lind = rnd.Next(0, 9);
			field[lind] = index;
		}
	}
}

