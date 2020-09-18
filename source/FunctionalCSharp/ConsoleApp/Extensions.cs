﻿using System;

namespace ConsoleApp
{
	public static class Extensions
	{
		public static Func<T, TReturn2> Compose<T, TReturn1, TReturn2>(this Func<TReturn1, TReturn2> func1, Func<T, TReturn1> func2)
		{
			return x => func1(func2(x));
		}
	}
}