using ChessWPF.Model;
using ChessWPF.Model.Constants;
using ChessWPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ChessWPF.ViewModel
{
	public class BoardViewModel : BindableBase
	{
		private List<BoardFigure> _FiguresList;
		private List<BoardTileViewModel> _TilesList;

		public BoardViewModel()
		{
			InitializeFiguresList();
			GenerateTilesList();
			Mediator.Register("ChangePlayer", ChangePlayer);
		}

		private void InitializeFiguresList()
		{
			_FiguresList = new List<BoardFigure>
			{
                // Dark figures
                new BoardFigure(FigureType.Rook, FigureColor.Dark, new Position("A8")),
				new BoardFigure(FigureType.Knight, FigureColor.Dark, new Position("B8")),
				new BoardFigure(FigureType.Bishop, FigureColor.Dark, new Position("C8")),
				new BoardFigure(FigureType.Queen, FigureColor.Dark, new Position("D8")),
				new BoardFigure(FigureType.King, FigureColor.Dark, new Position("E8")),
				new BoardFigure(FigureType.Bishop, FigureColor.Dark, new Position("F8")),
				new BoardFigure(FigureType.Knight, FigureColor.Dark, new Position("G8")),
				new BoardFigure(FigureType.Rook, FigureColor.Dark, new Position("H8")),
				new BoardFigure(FigureType.Pawn, FigureColor.Dark, new Position("A7")),
				new BoardFigure(FigureType.Pawn, FigureColor.Dark, new Position("B7")),
				new BoardFigure(FigureType.Pawn, FigureColor.Dark, new Position("C7")),
				new BoardFigure(FigureType.Pawn, FigureColor.Dark, new Position("D7")),
				new BoardFigure(FigureType.Pawn, FigureColor.Dark, new Position("E7")),
				new BoardFigure(FigureType.Pawn, FigureColor.Dark, new Position("F7")),
				new BoardFigure(FigureType.Pawn, FigureColor.Dark, new Position("G7")),
				new BoardFigure(FigureType.Pawn, FigureColor.Dark, new Position("H7")),
			    // White figures
                new BoardFigure(FigureType.Pawn, FigureColor.White, new Position("A2")),
				new BoardFigure(FigureType.Pawn, FigureColor.White, new Position("B2")),
				new BoardFigure(FigureType.Pawn, FigureColor.White, new Position("C2")),
				new BoardFigure(FigureType.Pawn, FigureColor.White, new Position("D2")),
				new BoardFigure(FigureType.Pawn, FigureColor.White, new Position("E2")),
				new BoardFigure(FigureType.Pawn, FigureColor.White, new Position("F2")),
				new BoardFigure(FigureType.Pawn, FigureColor.White, new Position("G2")),
				new BoardFigure(FigureType.Pawn, FigureColor.White, new Position("H2")),
				new BoardFigure(FigureType.Rook, FigureColor.White, new Position("A1")),
				new BoardFigure(FigureType.Knight, FigureColor.White, new Position("B1")),
				new BoardFigure(FigureType.Bishop, FigureColor.White, new Position("C1")),
				new BoardFigure(FigureType.Queen, FigureColor.White, new Position("D1")),
				new BoardFigure(FigureType.King, FigureColor.White, new Position("E1")),
				new BoardFigure(FigureType.Bishop, FigureColor.White, new Position("F1")),
				new BoardFigure(FigureType.Knight, FigureColor.White, new Position("G1")),
				new BoardFigure(FigureType.Rook, FigureColor.White, new Position("H1"))
			};
		}

		private void GenerateTilesList()
		{
			_TilesList = new List<BoardTileViewModel>();

			int tilesCount = 64;
			int row = 0;
			int column = 0;

			for (int tileIndex = 0; tileIndex < tilesCount; tileIndex++)
			{
				var position = new Position(column, row);
				var figure = _FiguresList.FirstOrDefault(f => f.TileIndex == tileIndex);
				BoardTileViewModel tile = new BoardTileViewModel(figure, tileIndex, position);
				tile.Click += Tile_Click;
				tile.MouseEnter += Tile_Enter;
				tile.MouseLeave += Tile_Leave;

				_TilesList.Add(tile);
				if (column == 7)
				{
					row++;
					column = 0;
				}
				else
				{
					column++;
				}
			}
		}

		private BoardTileViewModel selectedTile = null;
		private FigureColor actualPlayerColor = FigureColor.White;
		private void Tile_Click(BoardTileViewModel eventCaller)
		{
			if (selectedTile != null && eventCaller.Position.Equals(ResolveFigurePosition(eventCaller)))
			{
				var oldFigure = eventCaller.Figure;
				var selectedFigure = selectedTile.Figure;
				SetBaseStyle(selectedTile);
				selectedTile.Figure = null;
				selectedTile = null;


				//castling
				if (selectedFigure.Type == FigureType.King)
				{
					if (selectedFigure.Color == FigureColor.White && selectedFigure.Position.ToString() == "E1")
					{
						if (eventCaller.Position.ToString() == "G1")
						{
							var rookOldTile = GetTileViewModelFromPosition("H1");
							var rookNewTile = GetTileViewModelFromPosition("F1");
							rookNewTile.Figure = rookOldTile.Figure;
							rookNewTile.Figure.Position = rookNewTile.Position;
							rookOldTile.Figure = null;
						}
						else if (eventCaller.Position.ToString() == "C1")
						{
							var rookOldTile = GetTileViewModelFromPosition("A1");
							var rookNewTile = GetTileViewModelFromPosition("D1");
							rookNewTile.Figure = rookOldTile.Figure;
							rookNewTile.Figure.Position = rookNewTile.Position;
							rookOldTile.Figure = null;
						}
					}
					else if (selectedFigure.Color == FigureColor.Dark && selectedFigure.Position.ToString() == "E8")
					{
						if (eventCaller.Position.ToString() == "G8")
						{
							var rookOldTile = GetTileViewModelFromPosition("H8");
							var rookNewTile = GetTileViewModelFromPosition("F8");
							rookNewTile.Figure = rookOldTile.Figure;
							rookNewTile.Figure.Position = rookNewTile.Position;
							rookOldTile.Figure = null;
						}
						else if (eventCaller.Position.ToString() == "C8")
						{
							var rookOldTile = GetTileViewModelFromPosition("A8");
							var rookNewTile = GetTileViewModelFromPosition("D8");
							rookNewTile.Figure = rookOldTile.Figure;
							rookNewTile.Figure.Position = rookNewTile.Position;
							rookOldTile.Figure = null;
						}
					}
				}

				selectedFigure.Position = eventCaller.Position;
				eventCaller.Figure = selectedFigure;
				SetBaseStyle(eventCaller);


				if (oldFigure != null)
					BoardFigures.Remove(oldFigure);

				//promotion
				if (selectedFigure.Type == FigureType.Pawn && (eventCaller.Position.Row == 0 || eventCaller.Position.Row == 7))
				{
					PromotionViewModel = new PromotionViewModel(selectedFigure);
					PromotionViewModel.Promotion += () =>
					{
						var fig = new BoardFigure(PromotionViewModel.SelectedFigure.Type, selectedFigure.Color, eventCaller.Position);
						BoardFigures.Remove(eventCaller.Figure);
						eventCaller.Figure = fig;
						ShowPromotionView = false;
						Mediator.NotifyColleagues("ChangePlayer", actualPlayerColor);
					};
					ShowPromotionView = true;
				}
				else
				{
					Mediator.NotifyColleagues("ChangePlayer", actualPlayerColor);
				}
			}
			else if (eventCaller.Figure != null && eventCaller.Figure.Color.Equals(actualPlayerColor))
			{
				selectedTile = eventCaller;
				CheckSelectedStyle(eventCaller);
				GeneratePossiblePositions(selectedTile.Figure);
			}
		}

		private void Tile_Enter(BoardTileViewModel eventCaller)
		{
			if (eventCaller.Figure != null && eventCaller.Figure.Color == actualPlayerColor)
			{
				SetSelectedStyle(eventCaller);
			}
			else if (selectedTile != null && eventCaller.Position.Equals(ResolveFigurePosition(eventCaller)))
			{
				SetEnabledStyle(eventCaller);
			}
			else if (selectedTile != null && !eventCaller.Position.Equals(ResolveFigurePosition(eventCaller)))
			{
				SetDisabledStyle(eventCaller);
			}
			else
			{
				SetBaseStyle(eventCaller);
			}

			CheckSelectedStyle(eventCaller);
		}

		private void Tile_Leave(BoardTileViewModel eventCaller)
		{
			SetBaseStyle(eventCaller);
			CheckSelectedStyle(eventCaller);
		}

		private void CheckSelectedStyle(BoardTileViewModel tile)
		{
			if (selectedTile != null && selectedTile.Figure != null && selectedTile.Equals(tile))
			{
				BoardTiles.Where(boardTile => boardTile.Figure != null).ToList().ForEach(boardTile => SetBaseStyle(boardTile));
				SetSelectedStyle(tile);
			}
		}

		private void SetSelectedStyle(BoardTileViewModel tile)
		{
			tile.Stroke = StaticResources.BORDER_SELECTED_TILE_COLOR;
			tile.StrokeThickness = 3;
			tile.Cursor = Cursors.Hand;
		}

		private void SetBaseStyle(BoardTileViewModel tile)
		{
			tile.Stroke = StaticResources.BORDER_TILE_COLOR;
			tile.StrokeThickness = 1;
			tile.Cursor = Cursors.Arrow;
		}

		private void SetDisabledStyle(BoardTileViewModel tile)
		{
			tile.Stroke = StaticResources.BORDER_DISABLED_TILE_COLOR;
			tile.StrokeThickness = 3;
			tile.Cursor = Cursors.No;
		}

		private void SetEnabledStyle(BoardTileViewModel tile)
		{
			tile.Stroke = StaticResources.BORDER_ENABLED_TILE_COLOR;
			tile.StrokeThickness = 3;
			tile.Cursor = Cursors.Hand;
		}

		private BoardFigure GetFigureFromPosition(Position position)
		{
			return _FiguresList.FirstOrDefault(f => f.Position == position);
		}

		private BoardFigure GetFigureFromPosition(string position)
		{
			var pos = new Position(position);
			return GetFigureFromPosition(pos);
		}

		private BoardTileViewModel GetTileViewModelFromPosition(Position position)
		{
			return _TilesList[position.TileIndex];
		}

		private BoardTileViewModel GetTileViewModelFromPosition(string position)
		{
			var pos = new Position(position);
			return GetTileViewModelFromPosition(pos);
		}

		private void GeneratePossiblePositions(BoardFigure boardFigure)
		{
			switch (boardFigure.Type)
			{
				case FigureType.Pawn:
					boardFigure.PossiblePositions = GeneratePossiblePawnPositions(boardFigure);
					break;
				case FigureType.Rook:
					boardFigure.PossiblePositions = GeneratePossibleRookPositions();
					break;
				case FigureType.Bishop:
					boardFigure.PossiblePositions = GeneratePossibleBishopPositions();
					break;
				case FigureType.Queen:
					boardFigure.PossiblePositions = GeneratePossibleQueenPositions();
					break;
				case FigureType.King:
					boardFigure.PossiblePositions = GeneratePossibleKingPositions();
					break;
				case FigureType.Knight:
					boardFigure.PossiblePositions = GeneratePossibleKnightPositions();
					break;
				default:
					break;
			}
		}

		private List<Position> GeneratePossibleKnightPositions()
		{
			List<Position> possiblePositions = new List<Position>();
			var selectedTilePosition = selectedTile.Position;

			int[] x = { -1, -1, 1, 1, 2, 2, -2, -2 };
			int[] y = { 2, -2, 2, -2, 1, -1, 1, -1 };
			var selectedColumn = selectedTile.Position.Column;
			var selectedRow = selectedTile.Position.Row;

			for (int iterator = 0; iterator < 8; iterator++)
			{
				Position position = new Position(selectedColumn + y[iterator], selectedRow + x[iterator]);
				if (IsWithinBoard(position))
					possiblePositions.Add(position);
			}

			return possiblePositions;
		}

		private List<Position> GeneratePossiblePawnPositions(BoardFigure boardFigure)
		{
			List<Position> possiblePositions = new List<Position>();

			var selectedTilePosition = selectedTile.Position;

			if (boardFigure.Color == FigureColor.White)
			{
				var pos = new Position(selectedTilePosition.Column, selectedTilePosition.Row - 1);
				if (IsWithinBoard(pos) && GetFigureFromPosition(pos) == null)
					possiblePositions.Add(pos);
				if (selectedTilePosition.Row == 6)
				{
					pos = new Position(selectedTilePosition.Column, selectedTilePosition.Row - 2);
					if (IsWithinBoard(pos) && GetFigureFromPosition(pos) == null)
						possiblePositions.Add(pos);
				}

				pos = new Position(selectedTilePosition.Column + 1, selectedTilePosition.Row - 1);
				if (IsWithinBoard(pos) && GetFigureFromPosition(pos) != null)
					possiblePositions.Add(pos);

				pos = new Position(selectedTilePosition.Column - 1, selectedTilePosition.Row - 1);
				if (IsWithinBoard(pos) && GetFigureFromPosition(pos) != null)
					possiblePositions.Add(pos);
			}
			else
			{
				var pos = new Position(selectedTilePosition.Column, Math.Max(0, selectedTilePosition.Row + 1));
				if (GetFigureFromPosition(pos) == null)
					possiblePositions.Add(pos);
				if (selectedTilePosition.Row == 1)
				{
					pos = new Position(selectedTilePosition.Column, Math.Max(0, selectedTilePosition.Row + 2));
					if (GetFigureFromPosition(pos) == null)
						possiblePositions.Add(pos);
				}

				pos = new Position(selectedTilePosition.Column + 1, selectedTilePosition.Row + 1);
				if (IsWithinBoard(pos) && GetFigureFromPosition(pos) != null)
					possiblePositions.Add(pos);

				pos = new Position(selectedTilePosition.Column - 1, selectedTilePosition.Row + 1);
				if (IsWithinBoard(pos) && GetFigureFromPosition(pos) != null)
					possiblePositions.Add(pos);
			}

			return possiblePositions;
		}

		private List<Position> GeneratePossibleRookPositions()
		{
			List<Position> possiblePositions = new List<Position>();

			var selectedColumn = selectedTile.Position.Column;
			var selectedRow = selectedTile.Position.Row;

			bool addUp = true;
			bool addLeft = true;
			bool addRight = true;
			bool addDown = true;

			for (int iterator = 1; iterator < 8; iterator++)
			{
				Position positionUp = new Position(selectedColumn, selectedRow + iterator);
				Position positionDown = new Position(selectedColumn, selectedRow - iterator);
				Position positionLeft = new Position(selectedColumn - iterator, selectedRow);
				Position positionRight = new Position(selectedColumn + iterator, selectedRow);

				if (IsWithinBoard(positionUp) && addUp)
				{
					possiblePositions.Add(positionUp);
					addUp = GetFigureFromPosition(positionUp) == null;
				}

				if (IsWithinBoard(positionDown) && addDown)
				{
					possiblePositions.Add(positionDown);
					addDown = GetFigureFromPosition(positionDown) == null;
				}

				if (IsWithinBoard(positionLeft) && addLeft)
				{
					possiblePositions.Add(positionLeft);
					addLeft = GetFigureFromPosition(positionLeft) == null;
				}

				if (IsWithinBoard(positionRight) && addRight)
				{
					possiblePositions.Add(positionRight);
					addRight = GetFigureFromPosition(positionRight) == null;
				}
			}

			return possiblePositions;
		}

		private List<Position> GeneratePossibleBishopPositions()
		{
			List<Position> possiblePositions = new List<Position>();

			var selectedColumn = selectedTile.Position.Column;
			var selectedRow = selectedTile.Position.Row;
			bool addRightUpDiagonal = true;
			bool addLeftUpDiagonal = true;
			bool addRightDownDiagonal = true;
			bool addLeftDownDiagonal = true;

			for (int iterator = 1; iterator < 8; iterator++)
			{
				Position positionRightUpDiagonal = new Position(selectedColumn + iterator, selectedRow + iterator);
				Position positionLeftUpDiagonal = new Position(selectedColumn - iterator, selectedRow + iterator);
				Position positionRightDownDiagonal = new Position(selectedColumn + iterator, selectedRow - iterator);
				Position positionLeftDownDiagonal = new Position(selectedColumn - iterator, selectedRow - iterator);

				if (IsWithinBoard(positionRightUpDiagonal) && addRightUpDiagonal)
				{
					possiblePositions.Add(positionRightUpDiagonal);
					addRightUpDiagonal = GetFigureFromPosition(positionRightUpDiagonal) == null;
				}

				if (IsWithinBoard(positionLeftUpDiagonal) && addLeftUpDiagonal)
				{
					possiblePositions.Add(positionLeftUpDiagonal);
					addLeftUpDiagonal = GetFigureFromPosition(positionLeftUpDiagonal) == null;
				}

				if (IsWithinBoard(positionRightDownDiagonal) && addRightDownDiagonal)
				{
					possiblePositions.Add(positionRightDownDiagonal);
					addRightDownDiagonal = GetFigureFromPosition(positionRightDownDiagonal) == null;
				}

				if (IsWithinBoard(positionLeftDownDiagonal) && addLeftDownDiagonal)
				{
					possiblePositions.Add(positionLeftDownDiagonal);
					addLeftDownDiagonal = GetFigureFromPosition(positionLeftDownDiagonal) == null;
				}
			}

			return possiblePositions;
		}

		private List<Position> GeneratePossibleQueenPositions()
		{
			List<Position> possiblePositions = new List<Position>();

			possiblePositions.AddRange(GeneratePossibleRookPositions());
			possiblePositions.AddRange(GeneratePossibleBishopPositions());

			return possiblePositions;
		}

		private List<Position> GeneratePossibleKingPositions()
		{
			List<Position> possiblePositions = new List<Position>();

			int[] x = { -1, -1, -1, 1, 1, 1, 0, 0 };
			int[] y = { -1, 0, 1, -1, 0, 1, -1, 1 };
			var selectedColumn = selectedTile.Position.Column;
			var selectedRow = selectedTile.Position.Row;

			for (int iterator = 0; iterator < 8; iterator++)
			{
				Position position = new Position(selectedColumn + y[iterator], selectedRow + x[iterator]);
				if (IsWithinBoard(position))
					possiblePositions.Add(position);
			}


			if (selectedTile.Figure.Color == FigureColor.White && selectedTile.Figure.Position.ToString() == "E1")
			{
				var rook = GetFigureFromPosition("H1");
				if (rook != null && rook.Type == FigureType.Rook && rook.Color == FigureColor.White)
				{
					bool castlingPossible = GetFigureFromPosition("F1") == null;
					castlingPossible = castlingPossible && GetFigureFromPosition("G1") == null;
					if (castlingPossible)
						possiblePositions.Add(new Position("G1"));
				}

				rook = GetFigureFromPosition(new Position("A1"));
				if (rook != null && rook.Type == FigureType.Rook && rook.Color == FigureColor.White)
				{
					bool castlingPossible = GetFigureFromPosition("B1") == null;
					castlingPossible = castlingPossible && GetFigureFromPosition("C1") == null;
					castlingPossible = castlingPossible && GetFigureFromPosition("D1") == null;
					if (castlingPossible)
						possiblePositions.Add(new Position("C1"));
				}
			}

			if (selectedTile.Figure.Color == FigureColor.Dark && selectedTile.Figure.Position.ToString() == "E8")
			{
				var rook = GetFigureFromPosition("H8");
				if (rook != null && rook.Type == FigureType.Rook && rook.Color == FigureColor.Dark)
				{
					bool castlingPossible = GetFigureFromPosition("F8") == null;
					castlingPossible = castlingPossible && GetFigureFromPosition("G8") == null;
					if (castlingPossible)
						possiblePositions.Add(new Position("G8"));
				}

				rook = GetFigureFromPosition("A8");
				if (rook != null && rook.Type == FigureType.Rook && rook.Color == FigureColor.Dark)
				{
					bool castlingPossible = GetFigureFromPosition("B8") == null;
					castlingPossible = castlingPossible && GetFigureFromPosition("C8") == null;
					castlingPossible = castlingPossible && GetFigureFromPosition("D8") == null;
					if (castlingPossible)
						possiblePositions.Add(new Position("C8"));
				}
			}

			return possiblePositions;
		}

		private Position ResolveFigurePosition(BoardTileViewModel caller)
		{
			return selectedTile.Figure.PossiblePositions.Contains(caller.Position) && IsPossibleToMove(caller, caller.Position) ? caller.Position : null;
		}

		private bool IsPossibleToMove(BoardTileViewModel caller, Position newPosition)
		{
			bool isWithinBoard = IsWithinBoard(newPosition);
			bool isAlly = IsAlly(caller);
			return isWithinBoard && !isAlly;
		}

		private bool IsWithinBoard(Position position)
		{
			return position.Column >= 0 && position.Column <= 7 && position.Row >= 0 && position.Row <= 7; ;
		}

		private bool IsAlly(BoardTileViewModel caller)
		{
			return caller.Figure == null ? false : caller.Figure.Color == selectedTile.Figure.Color;
		}

		public void ChangePlayer(object message)
		{
			actualPlayerColor = actualPlayerColor == FigureColor.Dark ? FigureColor.White : FigureColor.Dark;
		}

		public List<BoardFigure> BoardFigures
		{
			get { return _FiguresList; }
			set { _FiguresList = value; }
		}

		public List<BoardTileViewModel> BoardTiles
		{
			get { return _TilesList; }
			set { _TilesList = value; }
		}


		private bool _showPromotionView = false;
		public bool ShowPromotionView
		{
			get { return _showPromotionView; }
			set { SetProperty(ref _showPromotionView, value); }
		}

		private PromotionViewModel promotionViewModel;
		public PromotionViewModel PromotionViewModel
		{
			get { return promotionViewModel; }
			set { SetProperty(ref promotionViewModel, value); }
		}
	}
}
