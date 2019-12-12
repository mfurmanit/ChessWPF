using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using ChessWPF.ViewModel;

namespace ChessWPF.Converters
{
	class TilesToTileConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int index = int.Parse((string)parameter);
			List<BoardTileViewModel> list = (List<BoardTileViewModel>)(value);

			return list[index];
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
