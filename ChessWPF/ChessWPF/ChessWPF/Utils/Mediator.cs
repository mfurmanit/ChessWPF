using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWPF.Utils
{
	/// <summary>
	/// Utilities that notify subscribers that some event occured
	/// </summary>
	static public class Mediator
	{
		static IDictionary<string, List<Action<object>>> pl_dict = new Dictionary<string, List<Action<object>>>();

		/// <summary>
		/// Registers the specified token.
		/// </summary>
		/// <param name="token">The token.</param>
		/// <param name="callback">The callback.</param>
		static public void Register(string token, Action<object> callback)
		{
			if (!pl_dict.ContainsKey(token))
			{
				var list = new List<Action<object>>();
				list.Add(callback);
				pl_dict.Add(token, list);
			}
			else
			{
				bool found = false;
				foreach (var item in pl_dict[token])
					if (item.Method.ToString() == callback.Method.ToString())
						found = true;
				if (!found)
					pl_dict[token].Add(callback);
			}
		}

		/// <summary>
		/// Unregisters the specified token.
		/// </summary>
		/// <param name="token">The token.</param>
		/// <param name="callback">The callback.</param>
		static public void Unregister(string token, Action<object> callback)
		{
			if (pl_dict.ContainsKey(token))
				pl_dict[token].Remove(callback);
		}

		/// <summary>
		/// Notifies the colleagues.
		/// </summary>
		/// <param name="token">The token.</param>
		/// <param name="args">The arguments.</param>
		static public void NotifyColleagues(string token, object args)
		{
			if (pl_dict.ContainsKey(token))
				foreach (var callback in pl_dict[token])
					callback(args);
		}

		/// <summary>
		/// Resets the mediator.
		/// </summary>
		static public void ResetMediator()
		{
			pl_dict.Clear();
		}
	}
}
