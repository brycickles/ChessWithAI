using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Piece[,] board = new Piece[8, 8];
            Player p1 = new Player();
            Player p2 = new Player();
            initializeBoard(board);
            displayBoard(board);
            playGame(board, p1, p2);
        }

        private static void playGame(Piece[,] board, Player p1, Player p2)
        {
            bool gameOver = false; 
            while(gameOver == false)
            {

            }
        }

        private static void initializeBoard(Piece[,] board) 
        {
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    board[i,j] = determinePiece(i, j);
                }
            }
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
            Console.WriteLine("   0  1  2  3  4  5  6  7");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("0 ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("[" + displayPiece(board[i,j]) + "]");
                }
                Console.WriteLine();
            }
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
    }
}
