using ChessWPF.Model.Constants;
using System.Collections.Generic;

namespace ChessWPF.Model
{
	public class BoardFigure : Utils.BindableBase
	{
		private string path;
		private FigureType type;
		private FigureColor color;
		private int tileIndex;
		private List<Position> possiblePositions = new List<Position>();

		public string Path
		{
			get => path;
			set => SetProperty(ref path, value);
		}

		public FigureType Type
		{
			get => type;
			set => SetProperty(ref type, value);
		}

		public FigureColor Color
		{
			get => color;
			set => SetProperty(ref color, value);
		}

		public int TileIndex
		{
			get => tileIndex;
			set => SetProperty(ref tileIndex, value);
		}

        public List<Position> PossiblePositions
        {
            get => possiblePositions;
            set => SetProperty(ref possiblePositions, value);
        }
    }
}
