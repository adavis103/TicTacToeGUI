#include <vector>
struct Win;

using namespace std;
/*
	Stores each square of the game board. 
	pos should be between 0 and 63
	val should be changed to either 'X' or 'O'
	val initialized to '0' for empty
*/
class Point{
	friend class Win;
	protected:
	int pos;
	char val;
	vector<Win*> wins;
	
	void addWin(Win* w){
		wins.push_back(w);
	}
	
	public:
	Point(int p):pos(p), val('0'){};
	
	bool isEmpty(){
		return val=='0';
	}
	
	char value(){
		return val;
	}
	
	void set(char newVal){
		val = newVal;
	}
	
	void reset(){
		val = '0';
	}
	
	void evalWins(){
		//**** somehow returns the states of all Wins in wins
	}
};

/*
	stores possible win scenarios
	
*/
class Win{
	friend class Point;
	protected:
	Point *points[4];
	
	public:
	Win(Point* p0, Point* p1, Point* p2, Point* p3){
		points[0] = p0;
		points[1] = p1;
		points[2] = p2;
		points[3] = p3;
		
		for(int i=0; i<3; i++){
			points[i]->addWin(this);
		}
	}
	
	//returns true if somebody won
	bool filled(){
		if(points[0]->val == '0'){return false;}
		for(int i=1; i<4; i++){
			if(points[i]->val != points[0]->val){return false;}
		}
		return true;
	}
	
	//returns number of x's
	int xStrength(){
		int s = 0;
		for(Point* p: points){
			if(p->val == 'X'){s++;}
		}
		return s;
	}
	
	//returns number of o's
	int oStrength(){
		int s = 0;
		for(Point* p: points){
			if(p->val == 'O'){s++;}
		}
		return s;
	}
	
	//returns true if there is an x and o in this win
	bool isSplit(){
		return (xStrength() >0 && oStrength() >0);
	}
	
	int eval(){
		//**** returns state of this win
        return 0;
	}
};
