using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Chess
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Piece[,] board = new Piece[8, 8];
            initializeBoard(board);
            Console.ReadLine();
            displayBoard(board);
            Player p1 = new Player(getPlayerNames(1));
            Player p2 = new Player(getPlayerNames(2));
            playGame(board, p1, p2);
        }
        private static void playGame(Piece[,] board, Player p1, Player p2)
        {
            int turns = 0;
            bool gameOver = false;
            while (gameOver == false)
            {
                if (turns % 2 == 0) //if turn is even, starting with player 0 
                {
                    refreshBoard(board, turns % 2);
                    takeTurn(p1, p2, board);
                    if (determineIfAnyoneHasWonYet(p2, p1) == true)
                    {
                        gameOver = true;
                        displayScores(p1, p2);
                        break;
                    }
                    turns++;
                }
                else
                {
                    refreshBoard(board, turns % 2);
                    takeTurn(p2, p1, board);
                    if (determineIfAnyoneHasWonYet(p1, p2) == true)
                    {
                        gameOver = true;
                        displayScores(p1, p2);
                        break;
                    }
                    turns++;
                }
            }
        }
        private static void refreshBoard(Piece[,] board, int v)
        {
            Console.Clear();
            Console.WriteLine("Current Turn: Player" + v + 1);
            displayBoard(board);
        }
        private static void takeTurn(Player currentPlayer, Player opposingPlayer, Piece[,] board)
        {
            bool cont = false;
            while (cont == false)
            {
                string input = "";
                Console.WriteLine(currentPlayer.Name + ", please enter coordinates of piece you wish to move:\nEx) '01'");
                input = Console.ReadLine();
                errorCheckEntry(input);
                int x = ToInt(input[0]);
                int y = ToInt(input[1]);
                Console.WriteLine(currentPlayer.Name + ", please enter coordinates you wish to move your" + board[x, y].Name + " to:\nEx) '01'");
                input = Console.ReadLine();
                errorCheckEntry(input);
                int a = ToInt(input[0]);
                int b = ToInt(input[1]); //x,y is piece to move, a,b is desired location


                //determine if chosen piece is actually able to move to target location. If not, ask player to choose another valid location. 
                //if no valid locations exist for selected piece to move, touch move rule applies and current player loses. Make better choices! 
                //then determine results of that move - i.e is it moving to a blank tile or is taking a piece? If latter, update score
                //if (canItMove(x, y, a, b, board) == true)
                //{
                //    cont = true; 
                //}
            }
            //makePlay(x, y, a, b, board); //this function moves piece in x,y to position a,b on the board. If a piece is taken, relevant points are scored              
        }
        private static void makePlay(int x, int y, int a, int b, Piece[,] board)
        {
            switch (board[x, y].TileId)
            {
                case 0: //tile                    
                    break;
                case 1: //pawn
                    checkIfValidPawn(board[x, y], board[a, b]);
                    pawnMove(board[x, y], board[a, b]);
                    break;
                case 2: //bishop
                    break;
                case 3: //knight
                    break;
                case 4: //Rook
                    break;
                case 5: //Queen
                    break;
                case 6: //King
                    break;
            }
        }

        private static void checkIfValidPawn(Piece piece1, Piece piece2)
        {
            if(piece1.Color == 0) //white 
            {
                //piece will find moves valid only if they can move forward - ex, a white pawn starts at position [1, 0-7], and logically, next move would only be legal if 
                //pawn 
            }else
            {

            }
        }

        private static void pawnMove(Piece piece1, Piece piece2)
        {
            throw new NotImplementedException();
        }

        private static void errorCheckEntry(string input)
        {
            while (input.Length != 2 || (ToInt(input[0]) > 9 || ToInt(input[0]) < 0) || (ToInt(input[1]) > 9 || ToInt(input[1]) < 0))
            {
                Console.WriteLine("Invalid Entry: \nPlease enter a two character string. \nFirst character represents the x coordinate, and second character represents the y coordinate");
                input = Console.ReadLine();
            }
        }
        private static bool determineIfAnyoneHasWonYet(Player p, Player q)
        {
            if (p.KingIsDead == true)
            {
                Console.WriteLine(q.Name + " wins!");
            }
            return p.KingIsDead;
        }
        private static void displayScores(Player p1, Player p2)
        {
            Console.WriteLine("Scores:\n" + p1.Name + ": " + p1.Score + "\n" + p2.Name + ": " + p2.Score);
        }
        private static void initializeBoard(Piece[,] board)
        {
            //set elements in board matrix
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    board[i, j] = determinePiece(i, j);
                }
            }


            //here we will transpose the array and then displayBoard will display the rotated array 

            //before transpose
            //Console.Write("\n\nMatrix before Transpose:\n");
            //for (int i = 0; i < 8; i++)
            //{
            //    Console.Write("\n");
            //    for (int j = 0; j < 8; j++)
            //    {
            //        if (board[i, j].Color == 0)
            //        {
            //            Console.Write("{0}\t", "W" + board[i, j].Name);
            //        }
            //        else if(board[i, j].Color == 1)
            //        {
            //            Console.Write("{0}\t", "B" + board[i, j].Name);
            //        }
            //        else
            //        {
            //            Console.Write("{0}\t", "T" + board[i, j].Name);
            //        }
            //    }
            //}

            //int width = 8;
            //int height = 8;
            //Piece[,] board2 = new Piece[8, 8];
            ////rotate 90 deg clockwise 
            //for(int row = 0; row < height; row++)
            //{
            //    for(int col = 0; col< width; col++)
            //    {
            //        int newRow = col;
            //        int newCol = height - (row + 1);

            //        board2[newCol, newRow] = board[col, row];
            //    }
            //}
            //board = board2;

            ////after transpose
            //Console.Write("\n\nMatrix after Transpose:\n");
            //for (int i = 0; i < 8; i++)
            //{
            //    Console.Write("\n");
            //    for (int j = 0; j < 8; j++)
            //    {
            //        if (board[i, j].Color == 0)
            //        {
            //            Console.Write("{0}\t", "W" + board[i, j].Name);
            //        }
            //        else if (board[i, j].Color == 1)
            //        {
            //            Console.Write("{0}\t", "B" + board[i, j].Name);
            //        }
            //        else
            //        {
            //            Console.Write("{0}\t", "T" + board[i, j].Name);
            //        }
            //    }
            //}
        }
        private static Piece determinePiece(int i, int j)
        {
            string name = "TT";
            int color = 0;
            int titleId = 0;
            int pointsVal = 0;
            bool isPiece = false;

            if (i == 0 || i == 1) //if piece is white
            {
                color = 1;
            }
            else if (i == 6 || i == 7)          //TITLE IDs
            {                                   //Tile:   0
                color = 0;                      //Pawn:   1
            }                                   //Bishop: 2
            else
            {                                   //Knight: 3
                color = 2;                      //Rook:   4
            }                                   //Queen:  5
                                                //King:   6
            if (i == 6 || i == 1)//Pawns
            {
                name = "Pa";
                titleId = 1;
                isPiece = true;
                pointsVal = 1;
            }
            else if ((i == 0 || i == 7) && (j == 2 || j == 5)) //Bishops
            {
                name = "Bi";
                titleId = 2;
                isPiece = true;
                pointsVal = 3;
            }
            else if ((i == 0 || i == 7) && (j == 1 || j == 6))//Knights
            {
                name = "Kn";
                titleId = 3;
                isPiece = true;
                pointsVal = 3;
            }
            else if ((i == 0 || i == 7) && (j == 0 || j == 7)) //Rooks
            {
                name = "Ro";
                titleId = 4;
                isPiece = true;
                pointsVal = 5;
            }
            else if ((i == 0 || i == 7) && j == 3) //Queens
            {
                name = "Qu";
                isPiece = true;
                titleId = 5;
                pointsVal = 9;
            }
            else if ((i == 0 || i == 7) && j == 4) //Kings
            {
                name = "Ki";
                titleId = 6;
                isPiece = true;
                pointsVal = 0;
            }
            else
            {
                name = "TT";
                titleId = 0;
                isPiece = false;
                pointsVal = 0;
            }
            Piece determinedPiece = new Piece(i, j, name, color, titleId, pointsVal, isPiece);
            return determinedPiece;
        }
        private static void displayBoard(Piece[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write((7 - i) + " ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("[" + displayPiece(board[i, 7 - j]) + "]");
                }
                Console.WriteLine();
            }
            Console.WriteLine("    0    1    2    3    4    5    6    7");
            Console.WriteLine("0 = White, 1 = Black");
            Console.WriteLine("ex) [6,0] is " + board[6, 0].Color + " " + board[6, 0].Name + ", [6,1] is " + board[6, 1].Color + " " + board[6, 1].Name + ", [6,2] is " + board[6, 2].Color + " " + board[6, 2].Name);
            Console.WriteLine("ex) [7,0] is " + board[7, 0].Color + " " + board[7, 0].Name + ", [7,1] is " + board[7, 1].Color + " " + board[7, 1].Name + ", [7,2] is " + board[7, 2].Color + " " + board[7, 2].Name);
        }
        private static string getPlayerNames(int n)
        {
            string name = "";
            Console.WriteLine();
            Console.WriteLine("Player " + n + ", please enter your name:");
            name = Console.ReadLine();
            return name;
        }
        private static string displayPiece(Piece piece)
        {
            string p = "";
            if (piece.Color == 0)
            {
                p += "W";
            }
            else if (piece.Color == 1)
            {
                p += "B";
            }
            else
            {
                p += "T";//tile
            }
            return (p + piece.Name);
        }
        private static int ToInt(this char c)
        {
            return (int)(c - '0');
        }
    }
}
class Piece
{
    public string Name { get; set; } //Pawn, //Bishop, Knight, Rook, Queen, King, Tile
    public int X { get; set; } //xcoord
    public int Y { get; set; } //ycoord
    public int Color { get; set; } //white black
    public int TileId { get; set; } //1 Pawn, 2 Bishop, 3 Knight, 4 Rook, 5 Queen, 6 King, 7 Tile
    public int PointsVal { get; set; } //each piece is worth points once taken
    public bool IsPiece { get; set; }
    public Piece()
    {
        Name = "Not initialized";
        X = 0;
        Y = 0;
        Color = 2;
        TileId = 404;
        PointsVal = 0;
        IsPiece = false;
    }
    public Piece(int x, int y, string name, int color, int tileId, int pointsVal, bool isPiece)
    {
        Name = name;
        X = x;
        Y = y;
        Color = color;
        TileId = tileId;
        PointsVal = pointsVal;
        IsPiece = isPiece;
    }
}
class Player
{
    public string Name { get; set; }
    public int Score { get; set; }
    public bool KingIsDead { get; set; }
    public Player()
    {
        this.Name = "uninitialized";
        this.Score = 0;
        this.KingIsDead = false;
    }
    public Player(string name)
    {
        this.Name = name;
        this.Score = 0;
        this.KingIsDead = false;
    }
}
#region AI
//this class is pseudocode at the moment - will begin design following this concept once manual game is finished
//class AiPlaceholder
//{
//    public int miniMax(int[] position, int depth, int alpha, int beta, bool maximizingPlayer)
//    {
//        //alpha and beta used to track best moves for white/black respectively
//        int maxEval = 0;
//        int minEval = 0;
//        int eval = 0; 

//        if (maximizingPlayer)
//        {
//            maxEval = Int32.MinValue;
//            foreach (int childNode of position)
//            {
//                eval = miniMax(childNode, depth - 1, alpha, beta, false);
//                maxEval = max(alpha, eval);
//                alpha = max(alpha, eval); 
//                if(beta <= alpha)
//                {
//                    break;
//                }

//            }
//            return maxEval; 
//        } 
//        else
//        {
//            minEval = Int32.MaxValue;
//            foreach(int childNode of position){
//                eval = miniMax(childNode, depth - 1, alpha, beta, true);
//                minEval = minEval(minEval, eval);
//                beta = minEval(beta, eval); 
//            }
//            return minEval;
//        }
//        return minEval;
//    }

//    private int max(int alpha, int eval)
//    {
//        int r = 0;
//        if(alpha > eval)
//        {
//            r = alpha;
//        }else
//        {
//            r = eval;
//        }
//        return r;
//    }
//}
#endregion


