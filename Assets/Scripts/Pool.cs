using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : IPoolable
{
	protected readonly List<T> pool;
	protected readonly Func<T> factoryMethod;

	public Pool(Func<T> factoryMethod, int capacity = 0, int startAmount = 0)
	{
		if (capacity < 0)
			throw new ArgumentException("Capacity can't be negative.", nameof(capacity));
		if (startAmount < 0)
			throw new ArgumentException("Start amount can't be negative.", nameof(startAmount));

		this.factoryMethod = factoryMethod ?? throw new ArgumentException("Factory can't be null", nameof(factoryMethod));

		capacity = Mathf.Max(capacity, startAmount);
		pool = new List<T>(capacity);
		for (int i = 0; i < startAmount; i++)
		{
			T item = factoryMethod.Invoke();
			pool.Add(item);
		}
	}

	public virtual T GetObject()
	{
		T result;
		if (pool.Count > 0)
		{
			result = pool[pool.Count - 1];
			pool.RemoveAt(pool.Count - 1);
			result.PoolReset();
		}
		else
		{
			result = factoryMethod.Invoke();
		}

		return result;
	}

	public virtual void ReleaseObject(T item)
	{
		if (item == null)
			throw new ArgumentException("Item can't be null.", nameof(item));

		if (pool.Contains(item))
			throw new ArgumentException("Pool already contains item.", nameof(item));

		pool.Add(item);
	}
}