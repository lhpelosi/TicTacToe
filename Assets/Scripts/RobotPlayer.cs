/*
 * RobotPlayer.cs - Entity of the cpu opposite player.
 * @author lhpelosi
 */

using System.Collections.Generic;
using System;

public class RobotPlayer
{
    // Defines the robot side ( cross or nought )
    public BoardModel.SquareType side;

    /*
     * Constructor
     * @param type Side of the robot
     */
    public RobotPlayer( BoardModel.SquareType side )
    {
        this.side = side;
	}

    /*
     * Decides the next play of the robot
     * @param board Current board state
     * @return Robot choice
     */
    public Coordinates decidesPlay( BoardModel board )
    {
        return decidesDeep( board );
    }

    // Decides next play randomly
    private Coordinates decidesRandom( BoardModel board )
    {
        List<Coordinates> freePositions = new List<Coordinates>();

        foreach ( Coordinates position in board.getPositions() )
        {
            if ( board.at( position ) == BoardModel.SquareType.EMPTY )
            {
                freePositions.Add( position );
            }
        }
        
        System.Random random = new System.Random();
        return freePositions[ random.Next( freePositions.Count ) ];
    }

    // Decides next play analysing one play forward
    private Coordinates decidesShallow( BoardModel board )
    {
        List<Coordinates> winningMoves = new List<Coordinates>();
        List<Coordinates> preventLosingMoves = new List<Coordinates>();
        List<Coordinates> neutralMoves = new List<Coordinates>();

        foreach ( Coordinates position in board.getPositions() )
        {
            // Tests only possible moves
            if ( board.at( position ) != BoardModel.SquareType.EMPTY ) continue;
            
            BoardModel testBoard = new BoardModel( board );

            // Tests for a winning move
            testBoard.setPositionTo( position, side );
            if ( testBoard.computeWinner() == side )
            {
                winningMoves.Add( position );
                continue;
            }

            // Tests for a move preventing a losing
            BoardModel.SquareType opponentSide = BoardModel.swapType( side );
            testBoard.setPositionTo( position, opponentSide );
            if ( testBoard.computeWinner() == opponentSide )
            {
                preventLosingMoves.Add( position );
                continue;
            }

            // Else it's just a neutral move
            neutralMoves.Add( position );
        }

        // Makes a random move in order of preference ( win > not lose )
        foreach ( List<Coordinates> moves in new List<Coordinates>[]{
            winningMoves, preventLosingMoves, neutralMoves } )
        {
            if ( moves.Count > 0 )
            {
                System.Random random = new System.Random();
                return moves[ random.Next( moves.Count ) ];
            }
        }

        // Error
        return new Coordinates( -1, -1 );
    }

    // Decides next play analysing all plays forward, using a minmax algorithm
    private Coordinates decidesDeep( BoardModel board )
    {
        List<Coordinates> bestMoves = new List<Coordinates>();

        int maxScore = Int32.MinValue;
        foreach ( Coordinates move in board.getEmptyPositions() )
        {
            BoardModel predictedBoard = new BoardModel( board );
            predictedBoard.setPositionTo( move, this.side );
            int score = getMinMaxScore( predictedBoard, BoardModel.swapType( this.side ) );
            if ( score > maxScore )
            {
                maxScore = score;
                bestMoves.Clear();
                bestMoves.Add( move );
            }
            else if ( score == maxScore )
            {
                bestMoves.Add( move );
            }
        }

        System.Random random = new System.Random();
        return bestMoves[ random.Next( bestMoves.Count ) ];
    }

    // Minmax recursive analysis
    private int getMinMaxScore( BoardModel board, BoardModel.SquareType nextTurn )
    {
        List<Coordinates> possibleMoves = board.getEmptyPositions();
        BoardModel.SquareType winner = board.computeWinner();

        // Case robot wins, it's a positive score relative to decision tree depth
        if ( winner == this.side ) return possibleMoves.Count+1;
        // Case robot loses, it's a negative score relative to decision tree depth
        if ( winner == BoardModel.swapType( side ) ) return -possibleMoves.Count-1;
        // Case it's a draw leaf
        if ( possibleMoves.Count == 0 ) return 0;

        // Robot turn, maximizes score
        if ( nextTurn == this.side )
        {
            int maxScore = Int32.MinValue;
            foreach ( Coordinates move in possibleMoves )
            {
                BoardModel predictedBoard = new BoardModel( board );
                predictedBoard.setPositionTo( move, nextTurn );
                int score = getMinMaxScore( predictedBoard, BoardModel.swapType( nextTurn ) );
                if ( score > maxScore )
                {
                    maxScore = score;
                }
            }
            return maxScore;
        }
        // Opponent turn, minimizes score
        else
        {
            int minScore = Int32.MaxValue;
            foreach ( Coordinates move in possibleMoves )
            {
                BoardModel predictedBoard = new BoardModel( board );
                predictedBoard.setPositionTo( move, nextTurn );
                int score = getMinMaxScore( predictedBoard, BoardModel.swapType( nextTurn ) );
                if ( score < minScore )
                {
                    minScore = score;
                }
            }
            return minScore;
        }
    }
}
