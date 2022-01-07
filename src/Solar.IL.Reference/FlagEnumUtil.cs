using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Solar
{
	public static class FlagEnumUtil
	{
		/// <summary>
		/// Combines two flag enum varibles
		/// </summary>
		/// <param name="this"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int OrInt(this int @this, int value)
		{
			return @this | value;
		}

		/// <summary>
		/// Performs bitwise AND operation to enum variables
		/// </summary>
		/// <param name="this"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int AndInit(this int @this,int value)
		{
			return @this & value;
		}

		/// <summary>
		/// Removes <paramref name="value"/> flags from <paramref name="this"/>
		/// </summary>
		/// <param name="this"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ClearFlags(this int @this,int value)
		{
			return @this & (~value);
		}

		/// <summary>
		/// Performs bitwise OR "|" operation to enum variables
		/// </summary>
		/// <typeparam name="TEnum">Flags enum type</typeparam>
		/// <param name="this"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TEnum OrEnum<TEnum>(this TEnum @this, TEnum value)
			where TEnum : struct, Enum
		{
			throw new NotImplementedException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static bool HasFlags(this int @this, int flags)
		{
			return (@this & flags) == flags;
		}

		public static int BitCountTest( long op3,ulong op4)
		{
			var i1 = BitOperations.PopCount((ulong)op3);
			var i2 = BitOperations.PopCount(op4);
			return i1 + i2;
		}

		public static int FlagCount<TEnum>(this TEnum @this)
			where TEnum : unmanaged, Enum
		{
			var size = SizeOf(@this);
			switch (size)
			{
				case 1:
					return BitOperations.PopCount(ToByte(@this));
				case 2:
					return BitOperations.PopCount(ToUInt64(@this));
				case 4:
					return BitOperations.PopCount(ToUInt32(@this));
				case 8:
					return BitOperations.PopCount(ToUInt64(@this));
			}
			return -1;
		}

		private static int SizeOf<TEnum>(this TEnum @this)
		{
			throw new NotImplementedException();
		}

		private static byte ToByte<TEnum>(this TEnum @this)
		{
			throw new NotImplementedException();
		}

		private static ushort ToUInt16<TEnum>(this TEnum @this)
		{
			throw new NotImplementedException();
		}

		private static uint ToUInt32<TEnum>(this TEnum @this)
		{
			throw new NotImplementedException();
		}

		private static ulong ToUInt64<TEnum>(this TEnum @this)
		{
			throw new NotImplementedException();
		}


		public static int Popcount(uint value)
		{
			const uint c1 = 0x_55555555u;
			const uint c2 = 0x_33333333u;
			const uint c3 = 0x_0F0F0F0Fu;
			const uint c4 = 0x_01010101u;

			value -= (value >> 1) & c1;
			value = (value & c2) + ((value >> 2) & c2);
			value = (((value + (value >> 4)) & c3) * c4) >> 24;

			return (int) value;
		}

		public static int SoftwareFallback(ulong value)
		{
			const ulong c1 = 0x_55555555_55555555ul;
			const ulong c2 = 0x_33333333_33333333ul;
			const ulong c3 = 0x_0F0F0F0F_0F0F0F0Ful;
			const ulong c4 = 0x_01010101_01010101ul;

			value -= (value >> 1) & c1;
			value = (value & c2) + ((value >> 2) & c2);
			value = (((value + (value >> 4)) & c3) * c4) >> 56;

			return (int) value;
		}
	}
}
