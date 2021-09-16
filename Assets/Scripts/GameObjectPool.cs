using System;
using UnityEngine;

public class GameObjectPool<T> : Pool<T> where T : MonoBehaviour, IPoolable
{
	private readonly Transform poolParent;

	public GameObjectPool(Func<T> factoryMethod, Transform poolParent = null, int capacity = 0, int startAmount = 0) : base(factoryMethod, capacity, startAmount)
	{
		this.poolParent = poolParent != null ? poolParent : CreatePoolParent();
		foreach (var item in pool)
		{
			item.transform.SetParent(this.poolParent);
			item.gameObject.SetActive(false);
		}
	}
	public virtual T GetObject(Transform parent = null)
	{
		var result = base.GetObject();
		result.transform.SetParent(parent);
		result.gameObject.SetActive(true);
		return result;
	}

	public sealed override T GetObject()
	{
		return GetObject();
	}

	public override void ReleaseObject(T item)
	{
		item.gameObject.SetActive(false);
		item.transform.SetParent(poolParent);
		base.ReleaseObject(item);
	}

	private Transform CreatePoolParent()
	{
		return new GameObject($"{typeof(T).Name}Pool").transform;
	}
}
