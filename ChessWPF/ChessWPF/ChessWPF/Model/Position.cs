using System;

namespace ChessWPF.Model
{
    class Position : Utils.BindableBase, IEquatable<Position>
    {
        private int column;
        private int row;

        public Position(int column, int row) {
            this.column = column;
            this.row = row;
        }

        public int Column
        {
            get => column;
            set => SetProperty(ref column, value);
        }

        public int Row
        {
            get => row;
            set => SetProperty(ref row, value);
        }

        public bool Equals(Position other)
        {
            return this.column == other.Column && this.row == other.Row;
        }
    }
}
