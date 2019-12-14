using ChessWPF.Model.Constants;

namespace ChessWPF.Model
{
	class BoardFigure : Utils.BindableBase
	{
		private string path;
		private FigureType type;
		private FigureColor color;
		private int tileIndex;

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
	}
}
