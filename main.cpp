#include "board.cpp"
using namespace std;

int main(){
    char ai = 'X';
	Board b;
    int depth = 3;
    b.moveX(10);
    b.moveO(28);
    b.moveX(15);
    b.moveO(0);
    b.moveX(32);
    b.moveO(55);
    b.moveX(37);
    b.moveO(54);
    int move = b.findBestMove(ai,depth);
    b.moveX(move);
    b.moveO(52);
    move = b.findBestMove(ai, depth);
    b.moveX(move);
    cout << move << endl;
	return 0;
}
