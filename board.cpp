#include <curses.h>
#include <iostream>
#include "win.h"
#include <map>

using namespace std;


struct Board{
	private:
    map <int,int> numToScore {{1,1}, {2,10}, {3,2000},{4,50000}};
	Point* allPoints[64];
	vector<Win*> allWins;
	
	public:
	WINDOW* window;
	
	Board(){
		//initialize points as 0-63
		 for(int i=0; i<64; i++){
        allPoints[i] = new Point(i);
    }
    
    //initialize wins
    for(int i=0; i<64; i+=4){//rows
        allWins.push_back(new Win(allPoints[i], allPoints[i+1], allPoints[i+2], allPoints[i+3]));
    }
    for(int i=0; i<64; i+=16){//columns
        for(int j=0; j<4; j++){
            allWins.push_back(new Win(allPoints[i+j], allPoints[i+j+4], allPoints[i+j+8], allPoints[i+j+12]));
        }
    }
	for(int i=0; i<16; i++){//verticals
		allWins.push_back(new Win(allPoints[i], allPoints[i+16], allPoints[i+32], allPoints[i+48]));
	}
    for(int i=0; i<64; i+=16){//right x-z diagonals
        allWins.push_back(new Win(allPoints[i], allPoints[i+5], allPoints[i+10], allPoints[i+15]));
    }
    for(int i=3; i<64; i+=16){//left x-z diagonals
        allWins.push_back(new Win(allPoints[i], allPoints[i+3], allPoints[i+6], allPoints[i+9]));
    }
    for(int i=0; i<4; i++){//upward y-z diagonals
        allWins.push_back(new Win(allPoints[i], allPoints[i+20], allPoints[i+40], allPoints[i+60]));
    }
    for(int i=12; i<16; i++){//downward y-z diagonals
        allWins.push_back(new Win(allPoints[i], allPoints[i+12], allPoints[i+24], allPoints[i+36]));
    }
    for(int i=0; i<16; i+=4){//right x-y diagonals
        allWins.push_back(new Win(allPoints[i], allPoints[i+17], allPoints[i+34], allPoints[i+51]));
    }
    for(int i=3; i<17; i+=4){//left x-y diagonals
        allWins.push_back(new Win(allPoints[i], allPoints[i+15], allPoints[i+30], allPoints[i+45]));
    }
    //2-D diagonals
    allWins.push_back(new Win(allPoints[0], allPoints[21], allPoints[42], allPoints[63]));
    allWins.push_back(new Win(allPoints[3], allPoints[22], allPoints[41], allPoints[60]));
    allWins.push_back(new Win(allPoints[12], allPoints[25], allPoints[38], allPoints[51]));
    allWins.push_back(new Win(allPoints[15], allPoints[26], allPoints[37], allPoints[48]));
		//make ncurses stuff
	}
	
	~Board(){
		for(int i=0; i<64; i++){
			delete(allPoints[i]);
		}
		for(Win* w:allWins){
			delete(w);
		}
		
	}

	void clear_board() {
    for(Point * p : allPoints)
       p->reset();
	}
	
	/*void printBoard(){
		string indent = "";
		string space = "              ";
		wmove(window, 0,0);
		wprintw(window, "+----+----+----+----+");
		waddstr(window, space.c_str());
		wprintw(window, "+----+----+----+----+\n");
		
		for(int i=0; i<32; i+=4){
			if(i==16){
				indent = "";
				wmove(window, 10, 0);
				waddstr(window, indent.c_str());
				wprintw(window, "+----+----+----+----+");
				waddstr(window, space.c_str());
				wprintw(window, " +----+----+----+----+\n");
			}
			
			waddstr(window, indent.c_str());
			for(int j=0; j<4; j++){
				wprintw(window, " \\ ");
				if(allPoints[i+j]->isEmpty()){
					wprintw(window, "%2d", i+j);
				}else{
					wprintw(window, "%2c", allPoints[i+j]->value());
				}
			}
			wprintw(window, " \\");
			waddstr(window, space.c_str());
			
			for(int j=0; j<4; j++){
				wprintw(window, " \\ ");
				if(allPoints[i+j+32]->isEmpty()){
					wprintw(window, "%2d", i+j+32);
				}else{
					wprintw(window, "%2c", allPoints[i+j+32]->value());
				}
			}
			
			wprintw(window, " \\\n");
			indent += "  ";
			waddstr(window, indent.c_str());
			wprintw(window, "+----+----+----+----+");
			waddstr(window, space.c_str());
			wprintw(window, " +----+----+----+----+\n");
			
		}
		
		wmove(window, 41, 0);
		wrefresh(window);
		getch();
	}
	*/
	void moveX(int p){
		allPoints[p]->set('X');
	}
	
	void moveO(int p){
		allPoints[p]->set('O');
	}
	
	void reset(int p){
		allPoints[p]->reset();
	}
	
	Point** getPoints(){
		return allPoints;
	}
	
	vector<Win*> getWins(){
		return allWins;
	}
	
    int utilityFunction()
    {
    int score = 0;
    for (Win * win : allWins)
    {
        if (!win->isSplit())
        {
            int sX = win->xStrength();
            score += numToScore[sX];
            int sO = win->oStrength();
            if (sO == 4)
                score -= 2 * numToScore[sO];
            else
                score -= numToScore[sO];
        }
    }
    return score;
    }
    
    bool isMovesLeft()
    {
        for (int i = 0; i < 64; i ++)
        if (allPoints[i]->isEmpty())
        return true;
        return false;
    }
    
	bool gameOver(){
		for(Win* w: allWins){
			if(w->filled()){
				return true;
			}
		}
		return false;
	}
    
    int minimax(bool isMax, int currentDepth, int maxDepth, char player)
    {
        
        int score = utilityFunction();
        
        if (gameOver() || currentDepth == maxDepth || (!isMovesLeft()))
        {
            return score;
        }
        
        if (isMax)
        {
            int best = - 1000000;
            for (int i = 0; i < 64; i++)
            {
                if (allPoints[i]->isEmpty())
                {
                    allPoints[i]->set(player);
                    best = max(best, minimax(!isMax, currentDepth+1, maxDepth, player));
                    allPoints[i]->set('0');
                }
                
            }
            return best;
        }
        else
        {
            char opponent;
            if (player == 'X')
            {
                opponent = 'O';
            } else
            {
                opponent = 'X';
            }
            int best = 1000000;
            for (int i = 0; i < 64; i++)
            {
                if (allPoints[i]->isEmpty())
                {
                    allPoints[i]->set(opponent);
                    best = min(best, minimax(!isMax, currentDepth+1, maxDepth, player));
                    allPoints[i]->set('0');
                }
            }
            return best;
        }
    }
    
    int findBestMove(char player, int depth)
    {
        
        int bestScore;
        int bestMove = -1;
        if (player == 'X')
        {
            bestScore = - 1000000;
            for (int i = 0; i < 64; i ++)
            {
                if (allPoints[i]->isEmpty())
                {
                    
                    allPoints[i]->set(player);
                    
                    int val = minimax(true, 1, depth, player);
                    allPoints[i]->set('0');
                    if (val > bestScore)
                    {
                        bestMove = i;
                        bestScore = val;
                    }
                }
            }
        }
        else
        {
            bestScore = 1000000;
            for (int i = 0; i < 64; i ++)
            {
                if (allPoints[i]->isEmpty())
                {
                    allPoints[i]->set(player);
                    
                    int val = minimax(false, 1, depth, player);
                    allPoints[i]->set('0');
                    if (val < bestScore)
                    {
                        bestMove = i;
                        bestScore = val;
                    }
                }
            }
        }
        return bestMove;
    }
    
};






