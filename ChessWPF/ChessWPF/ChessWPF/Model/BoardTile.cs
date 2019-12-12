using System.Windows.Media;

namespace ChessWPF.Model
{
	class BoardTile : Utils.BindableBase
	{
		private int index;
		private SolidColorBrush background;
		private SolidColorBrush stroke;
		private bool isActive;
		private BoardFigure figure;

		public int Index
		{
			get => index;
			set => SetProperty(ref index, value);
		}

		public SolidColorBrush Background
		{
			get => background;
			set => SetProperty(ref background, value);
		}

		public SolidColorBrush Stroke
		{
			get => stroke;
			set => SetProperty(ref stroke, value);
		}

		public bool IsActive
		{
			get => isActive;
			set => SetProperty(ref isActive, value);
		}

		public BoardFigure Figure
		{
			get => figure;
			set => SetProperty(ref figure, value);
		}
	}
}
