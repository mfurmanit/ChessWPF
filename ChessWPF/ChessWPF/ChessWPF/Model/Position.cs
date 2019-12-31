using System;

namespace ChessWPF.Model
{
    public class Position : IEquatable<Position>
    {
        public Position(int column, int row) {
            Column = column;
            Row = row;
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public bool Equals(Position other)
        {
            return other == null ? false : Column == other.Column && Row == other.Row;
        }
    }
}
