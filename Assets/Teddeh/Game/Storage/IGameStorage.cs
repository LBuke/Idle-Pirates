using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teddeh.Game.Storage
{
	public interface IGameStorage<A, B>
	{
		void Save(A elements);

		B Load();

		string GetStorageFileName();
	}
}
