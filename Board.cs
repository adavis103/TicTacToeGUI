using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public class Win
    {
        public List<Ref<char>> points = new List<Ref<char>>();
        public Win(Ref<char> p0, Ref<char> p1, Ref<char> p2, Ref<char> p3)
        {
            points.Add(p0);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
        }

        public char filled()
        {
            if (points[0].Value == '0')
            {
                return '0';
            }
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Value != points[0].Value)
                {
                    return '0';
                }
            }
            return points[0].Value;
        }

        public int xStrength()
        {
            int s = 0;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Value == 'X')
                {
                    s += 1;
                }
            }
            return s;
        }
        public int oStrength()
        {
            int s = 0;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Value == 'O')
                {
                    s += 1;
                }
            }
            return s;
        }

        public bool isSplit()
        {

            return (this.xStrength()) > 0 && (this.oStrength()) > 0;
        }

    }

    public class Ref<T> where T : struct
    {
        public T Value { get; set; }
    }

    public class Board
    {

        Dictionary<int, int> numToScore = new Dictionary<int, int>();
        List<Ref<char>> allPoints = new List<Ref<char>>();
        List<Win> allWins = new List<Win>();
        public Board()
        {
            numToScore.Add(0, 0);
            numToScore.Add(1, 1);
            numToScore.Add(2, 10);
            numToScore.Add(3, 2000);
            numToScore.Add(4, 50000);
            for (int i = 0; i < 64; i++)
            {
                allPoints.Add(new Ref<char>());
            }
            for (int i = 0; i < 64; i++)
            {
                allPoints[i].Value = '0';
            }
            for (int i = 0; i < 64; i += 4)
            {//rows
                allWins.Add(new Win(allPoints[i], allPoints[i + 1], allPoints[i + 2], allPoints[i + 3]));
            }

            for (int i = 0; i < 64; i += 16)
            {//columns
                for (int j = 0; j < 4; j++)
                {
                    allWins.Add(new Win(allPoints[i + j], allPoints[i + j + 4], allPoints[i + j + 8], allPoints[i + j + 12]));
                }
            }
            for (int i = 0; i < 16; i++)
            {//verticals
                allWins.Add(new Win(allPoints[i], allPoints[i + 16], allPoints[i + 32], allPoints[i + 48]));
            }
            for (int i = 0; i < 64; i += 16)
            {//right x-z diagonals
                allWins.Add(new Win(allPoints[i], allPoints[i + 5], allPoints[i + 10], allPoints[i + 15]));
            }
            for (int i = 3; i < 64; i += 16)
            {//left x-z diagonals
                allWins.Add(new Win(allPoints[i], allPoints[i + 3], allPoints[i + 6], allPoints[i + 9]));
            }
            for (int i = 0; i < 4; i++)
            {//upward y-z diagonals
                allWins.Add(new Win(allPoints[i], allPoints[i + 20], allPoints[i + 40], allPoints[i + 60]));
            }
            for (int i = 12; i < 16; i++)
            {//downward y-z diagonals
                allWins.Add(new Win(allPoints[i], allPoints[i + 12], allPoints[i + 24], allPoints[i + 36]));
            }
            for (int i = 0; i < 16; i += 4)
            {//right x-y diagonals
                allWins.Add(new Win(allPoints[i], allPoints[i + 17], allPoints[i + 34], allPoints[i + 51]));
            }
            for (int i = 3; i < 17; i += 4)
            {//left x-y diagonals
                allWins.Add(new Win(allPoints[i], allPoints[i + 15], allPoints[i + 30], allPoints[i + 45]));
            }
            //2-D diagonals
            allWins.Add(new Win(allPoints[0], allPoints[21], allPoints[42], allPoints[63]));
            allWins.Add(new Win(allPoints[3], allPoints[22], allPoints[41], allPoints[60]));
            allWins.Add(new Win(allPoints[12], allPoints[25], allPoints[38], allPoints[51]));
            allWins.Add(new Win(allPoints[15], allPoints[26], allPoints[37], allPoints[48]));
        }

        public void move(char mover, int pos)
        {
            this.allPoints[pos].Value = mover;
        }

        public char gameOver()
        {
            foreach (Win w in allWins)
            {
                char wc = w.filled();
                if (wc != '0')
                {
                    return wc;
                }
            }
            return '0';
        }

        public int utilityFunction()
        {
            int score = 0;
            foreach (Win win in allWins)
            {
                if (!win.isSplit())
                {
                    int sX = win.xStrength();
                    //Console.WriteLine("x STrength");
                    //Console.WriteLine(sX);
                    score += numToScore[sX];
                    int sO = win.oStrength();
                    if (sO == 4)
                        score -= 2 * numToScore[sO];
                    else
                        score -= numToScore[sO];
                }
                //Console.WriteLine("Utility Score");
                //Console.WriteLine(score);
            }
            return score;
        }

        public bool isMovesLeft()
        {
            for (int i = 0; i < 64; i++)
                if (allPoints[i].Value != '0')
                    return true;
            return false;
        }

        public int minimax(bool isMax, int currentDepth, int maxDepth, char mover)
        {

            int score = utilityFunction();

            if (this.gameOver() != '0' || currentDepth == maxDepth || (!this.isMovesLeft()))
            {
                return score;
            }

            if (isMax)
            {
                int best = -1000000;
                for (int i = 0; i < 64; i++)
                {
                    if (allPoints[i].Value == '0')
                    {
                        allPoints[i].Value = mover;
                        best = Math.Max(best, minimax(!isMax, currentDepth + 1, maxDepth, mover));
                        allPoints[i].Value = '0';
                    }

                }
                return best;
            }
            else
            {
                char opponent;
                if (mover == 'X')
                {
                    opponent = 'O';
                }
                else
                {
                    opponent = 'X';
                }
                int best = 1000000;
                for (int i = 0; i < 64; i++)
                {
                    if (allPoints[i].Value == '0')
                    {
                        allPoints[i].Value = opponent;
                        best = Math.Min(best, minimax(!isMax, currentDepth + 1, maxDepth, mover));
                        allPoints[i].Value = '0';
                    }
                }
                return best;
            }
        }

        public int findBestMove(char mover, int depth)
        {

            int bestScore;
            int bestMove = -1;
            if (mover == 'X')
            {
                bestScore = -1000000;
                for (int i = 0; i < 64; i++)
                {
                    if (allPoints[i].Value == '0')
                    {

                        allPoints[i].Value = mover;

                        int val = minimax(true, 1, depth, mover);
                        allPoints[i].Value = '0';
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
                for (int i = 0; i < 64; i++)
                {
                    if (allPoints[i].Value == '0')
                    {
                        allPoints[i].Value = mover;

                        int val = minimax(false, 1, depth, mover);
                        allPoints[i].Value = '0';
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
       /* static void Main(string[] args)
        {
            char player = 'X';
            char ai = 'O';
            Board b = new Board();
            player = 'X';
            ai = 'O';
            b.move(player, 0);
            b.move(ai, 23);
            b.move(player, 3);
            b.move(ai, 23);
            b.move(player, 1);
            b.move(ai, 2);
            Console.WriteLine(b.findBestMove(player, 3));
            Console.Read();

        }
        */
    }
}




