using System;
using System.Collections.Generic;
using System.Linq;
using CommonBase.Extensions;

namespace MusicStore.Logic.Context
{
	internal abstract class FileContext : ContextObject
	{
		protected IEnumerable<T> GetSaveItems<T>(IEnumerable<T> source) where T : Entities.EntityObject
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			List<T> result = new List<T>();

			foreach (var item in source)
			{
				if (item.State == Entities.EntityState.Added)
				{
					item.Id = source.NextValue(i => i.Id);
					result.Add(item);
				}
				else if (item.State != Entities.EntityState.Deleted)
				{
					result.Add(item);
				}
			}
			return result;
		}

		protected static List<T> LoadFromCsv<T>() where T : class, new()
		{
			return new List<T>(FileHelper.ReadFromCsv<T>(FileHelper.GetCsvFilePath(typeof(T))));
		}

		protected IEnumerable<T> SaveToCsv<T>(IEnumerable<T> source) where T : Entities.EntityObject
		{
			IEnumerable<T> result = GetSaveItems<T>(source);
			string filePath = FileHelper.GetCsvFilePath(typeof(T));

			FileHelper.WriteToCsv<T>(filePath, result.ToArray());
			result.ForeachAction(i => i.State = Entities.EntityState.Unchanged);
			return result;
		}

		protected static List<T> LoadFromSer<T>() where T : class, new()
		{
			string filePath = FileHelper.GetSerFilePath(typeof(T));

			return new List<T>(FileHelper.Deserialize<T>(filePath));
		}

		protected IEnumerable<T> SaveToSer<T>(IEnumerable<T> source) where T : Entities.EntityObject
		{
			IEnumerable<T> result = GetSaveItems<T>(source);
			string filePath = FileHelper.GetSerFilePath(typeof(T));

			FileHelper.Serialize(filePath, result);
			result.ForeachAction(i => i.State = Entities.EntityState.Unchanged);
			return result;
		}
    }
}
