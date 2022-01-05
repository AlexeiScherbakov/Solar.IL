using System;

using NUnit.Framework;

namespace Solar.IL.Tests
{
	public class FlagEnumUtilTest
	{

		[Test]
		public void ByteEnumTests()
		{
			ByteEnum value = ByteEnum.Bit0 | ByteEnum.Bit4;
			value = value.Or(ByteEnum.Bit7);
			Assert.AreEqual(ByteEnum.Bit0 | ByteEnum.Bit4 | ByteEnum.Bit7, value);
			value = value.Or(ByteEnum.Bit0);
			Assert.AreEqual(ByteEnum.Bit0 | ByteEnum.Bit4 | ByteEnum.Bit7, value);
			value = value.Or(ByteEnum.Bit1);
			Assert.AreNotEqual(ByteEnum.Bit0 | ByteEnum.Bit4 | ByteEnum.Bit7, value);
		}

		[Test]
		public void SByteEnumTests()
		{
			SByteEnum value = SByteEnum.Bit0 | SByteEnum.Bit4;
			value = value.Or(SByteEnum.Bit7);
			Assert.AreEqual(SByteEnum.Bit0 | SByteEnum.Bit4 | SByteEnum.Bit7, value);
			value = value.Or(SByteEnum.Bit0);
			Assert.AreEqual(SByteEnum.Bit0 | SByteEnum.Bit4 | SByteEnum.Bit7, value);
			value = value.Or(SByteEnum.Bit1);
			Assert.AreNotEqual(SByteEnum.Bit0 | SByteEnum.Bit4 | SByteEnum.Bit7, value);
		}

		[Test]
		public void UInt16EnumTests()
		{
			UShortEnum value = UShortEnum.Bit0 | UShortEnum.Bit4;
			value = value.Or(UShortEnum.Bit15);
			Assert.AreEqual(UShortEnum.Bit0 | UShortEnum.Bit4 | UShortEnum.Bit15, value);
			value = value.Or(UShortEnum.Bit0);
			Assert.AreEqual(UShortEnum.Bit0 | UShortEnum.Bit4 | UShortEnum.Bit15, value);
			value = value.Or(UShortEnum.Bit1);
			Assert.AreNotEqual(UShortEnum.Bit0 | UShortEnum.Bit4 | UShortEnum.Bit15, value);
		}

		[Test]
		public void Int16EnumTests()
		{
			ShortEnum value = ShortEnum.Bit0 | ShortEnum.Bit4;
			value = value.Or(ShortEnum.Bit15);
			Assert.AreEqual(ShortEnum.Bit0 | ShortEnum.Bit4 | ShortEnum.Bit15, value);
			value = value.Or(ShortEnum.Bit0);
			Assert.AreEqual(ShortEnum.Bit0 | ShortEnum.Bit4 | ShortEnum.Bit15, value);
			value = value.Or(ShortEnum.Bit1);
			Assert.AreNotEqual(ShortEnum.Bit0 | ShortEnum.Bit4 | ShortEnum.Bit15, value);
		}

		[Test]
		public void UInt32EnumTests()
		{
			UIntEnum value = UIntEnum.Bit0 | UIntEnum.Bit4;
			value = value.Or(UIntEnum.Bit31);
			Assert.AreEqual(UIntEnum.Bit0 | UIntEnum.Bit4 | UIntEnum.Bit31, value);
			value = value.Or(UIntEnum.Bit0);
			Assert.AreEqual(UIntEnum.Bit0 | UIntEnum.Bit4 | UIntEnum.Bit31, value);
			value = value.Or(UIntEnum.Bit1);
			Assert.AreNotEqual(UIntEnum.Bit0 | UIntEnum.Bit4 | UIntEnum.Bit31, value);
		}

		[Test]
		public void Int32EnumTests()
		{
			IntEnum value = IntEnum.Bit0 | IntEnum.Bit4;
			value = value.Or(IntEnum.Bit31);
			Assert.AreEqual(IntEnum.Bit0 | IntEnum.Bit4 | IntEnum.Bit31, value);
			value = value.Or(IntEnum.Bit0);
			Assert.AreEqual(IntEnum.Bit0 | IntEnum.Bit4 | IntEnum.Bit31, value);
			value = value.Or(IntEnum.Bit1);
			Assert.AreNotEqual(IntEnum.Bit0 | IntEnum.Bit4 | IntEnum.Bit31, value);
		}


		[Test]
		public void TopFlagCountTest()
		{
			Assert.AreEqual(8, (SByteEnum.Bit0 | SByteEnum.Bit1 | SByteEnum.Bit2 | SByteEnum.Bit3 | SByteEnum.Bit4
				| SByteEnum.Bit5 | SByteEnum.Bit6 | SByteEnum.Bit7).FlagCount());
			Assert.AreEqual(8, (ShortEnum.Bit0 | ShortEnum.Bit1 | ShortEnum.Bit2 | ShortEnum.Bit3 | ShortEnum.Bit4
				| ShortEnum.Bit5 | ShortEnum.Bit6 | ShortEnum.Bit15).FlagCount());
			Assert.AreEqual(8, (IntEnum.Bit0 | IntEnum.Bit1 | IntEnum.Bit2 | IntEnum.Bit3 | IntEnum.Bit4
				| IntEnum.Bit5 | IntEnum.Bit6 | IntEnum.Bit31).FlagCount());
			Assert.AreEqual(8, (LongEnum.Bit0 | LongEnum.Bit1 | LongEnum.Bit2 | LongEnum.Bit3 | LongEnum.Bit4
				| LongEnum.Bit5 | LongEnum.Bit6 | LongEnum.Bit63).FlagCount());
		}

		[Test]
		public void FlagCountTest()
		{
			byte uint8 = 0;
			sbyte int8 = 0;
			for (int i = 0; i < 8; i++)
			{
				uint8 |= (byte) (1 << i);
				int8 |= (sbyte) (1 << i);

				var enumUint8 = (ByteEnum) uint8;
				var enumInt8 = (SByteEnum) int8;

				Assert.AreEqual(i + 1, enumUint8.FlagCount());
				Assert.AreEqual(i + 1, enumInt8.FlagCount());
			}

			ushort uint16 = 0;
			short int16 = 0;
			for (int i = 0; i < 16; i++)
			{
				uint16 |= (ushort) (1 << i);
				int16 |= (short) (1 << i);

				var enumUint16 = (UShortEnum) uint16;
				var enumInt16 = (ShortEnum) int16;

				Assert.AreEqual(i + 1, enumUint16.FlagCount());
				Assert.AreEqual(i + 1, enumInt16.FlagCount());
			}

			uint uint32 = 0;
			int int32 = 0;
			for (int i = 0; i < 32; i++)
			{
				uint32 |= (uint) (1u << i);
				int32 |= (int) (1 << i);

				var enumUint32 = (UIntEnum) uint32;
				var enumInt32 = (IntEnum) int32;

				Assert.AreEqual(i + 1, enumUint32.FlagCount());
				Assert.AreEqual(i + 1, enumInt32.FlagCount());
			}

			ulong uint64 = 0;
			long int64 = 0;
			for (int i = 0; i < 64; i++)
			{
				uint64 |= (ulong) (1ul << i);
				int64 |= (long) (1L << i);

				var enumUint64 = (ULongEnum) uint64;
				var enumInt64 = (LongEnum) int64;

				Assert.AreEqual(i + 1, enumUint64.FlagCount());
				Assert.AreEqual(i + 1, enumInt64.FlagCount());
			}
		}
	}


	[Flags]
	public enum ByteEnum
		: byte
	{
		None = 0,
		Bit0 = 1,
		Bit1 = 1 << 1,
		Bit2 = 1 << 2,
		Bit3 = 1 << 3,
		Bit4 = 1 << 4,
		Bit5 = 1 << 5,
		Bit6 = 1 << 6,
		Bit7 = 1 << 7,
	}

	[Flags]
	public enum SByteEnum
		: sbyte
	{
		None = 0,
		Bit0 = 1,
		Bit1 = 1 << 1,
		Bit2 = 1 << 2,
		Bit3 = 1 << 3,
		Bit4 = 1 << 4,
		Bit5 = 1 << 5,
		Bit6 = 1 << 6,
		Bit7 = unchecked((sbyte) (1 << 7)),
	}

	[Flags]
	public enum UShortEnum
		: ushort
	{
		None = 0,
		Bit0 = 1,
		Bit1 = 1 << 1,
		Bit2 = 1 << 2,
		Bit3 = 1 << 3,
		Bit4 = 1 << 4,
		Bit5 = 1 << 5,
		Bit6 = 1 << 6,
		Bit7 = 1 << 7,
		Bit8 = 1 << 8,
		Bit9 = 1 << 9,
		Bit10 = 1 << 10,
		Bit11 = 1 << 11,
		Bit12 = 1 << 12,
		Bit13 = 1 << 13,
		Bit14 = 1 << 14,
		Bit15 = 1 << 15,
	}

	[Flags]
	public enum ShortEnum
		: short
	{
		None = 0,
		Bit0 = 1,
		Bit1 = 1 << 1,
		Bit2 = 1 << 2,
		Bit3 = 1 << 3,
		Bit4 = 1 << 4,
		Bit5 = 1 << 5,
		Bit6 = 1 << 6,
		Bit7 = 1 << 7,
		Bit8 = 1 << 8,
		Bit9 = 1 << 9,
		Bit10 = 1 << 10,
		Bit11 = 1 << 11,
		Bit12 = 1 << 12,
		Bit13 = 1 << 13,
		Bit14 = 1 << 14,
		Bit15 = unchecked((short) (1 << 15)),
	}

	[Flags]
	public enum UIntEnum
		: uint
	{
		None = 0,
		Bit0 = 1,
		Bit1 = 1 << 1,
		Bit2 = 1 << 2,
		Bit3 = 1 << 3,
		Bit4 = 1 << 4,
		Bit5 = 1 << 5,
		Bit6 = 1 << 6,
		Bit7 = 1 << 7,
		Bit8 = 1 << 8,
		Bit9 = 1 << 9,
		Bit10 = 1 << 10,
		Bit11 = 1 << 11,
		Bit12 = 1 << 12,
		Bit13 = 1 << 13,
		Bit14 = 1 << 14,
		Bit15 = 1 << 15,
		Bit16 = 1 << 16,
		Bit17 = 1 << 17,
		Bit18 = 1 << 18,
		Bit19 = 1 << 19,
		Bit20 = 1 << 20,
		Bit21 = 1 << 21,
		Bit22 = 1 << 22,
		Bit23 = 1 << 23,
		Bit24 = 1 << 24,
		Bit25 = 1 << 25,
		Bit26 = 1 << 26,
		Bit27 = 1 << 27,
		Bit28 = 1 << 28,
		Bit29 = 1 << 29,
		Bit30 = 1 << 30,
		Bit31 = 1u << 31,
	}

	[Flags]
	public enum IntEnum
		: int
	{
		None = 0,
		Bit0 = 1,
		Bit1 = 1 << 1,
		Bit2 = 1 << 2,
		Bit3 = 1 << 3,
		Bit4 = 1 << 4,
		Bit5 = 1 << 5,
		Bit6 = 1 << 6,
		Bit7 = 1 << 7,
		Bit8 = 1 << 8,
		Bit9 = 1 << 9,
		Bit10 = 1 << 10,
		Bit11 = 1 << 11,
		Bit12 = 1 << 12,
		Bit13 = 1 << 13,
		Bit14 = 1 << 14,
		Bit15 = 1 << 15,
		Bit16 = 1 << 16,
		Bit17 = 1 << 17,
		Bit18 = 1 << 18,
		Bit19 = 1 << 19,
		Bit20 = 1 << 20,
		Bit21 = 1 << 21,
		Bit22 = 1 << 22,
		Bit23 = 1 << 23,
		Bit24 = 1 << 24,
		Bit25 = 1 << 25,
		Bit26 = 1 << 26,
		Bit27 = 1 << 27,
		Bit28 = 1 << 28,
		Bit29 = 1 << 29,
		Bit30 = 1 << 30,
		Bit31 = 1 << 31,
	}

	[Flags]
	public enum ULongEnum
		: ulong
	{
		None = 0,
		Bit0 = 1ul,
		Bit1 = 1ul << 1,
		Bit2 = 1ul << 2,
		Bit3 = 1ul << 3,
		Bit4 = 1ul << 4,
		Bit5 = 1ul << 5,
		Bit6 = 1ul << 6,
		Bit7 = 1ul << 7,
		Bit8 = 1ul << 8,
		Bit9 = 1ul << 9,
		Bit10 = 1ul << 10,
		Bit11 = 1ul << 11,
		Bit12 = 1ul << 12,
		Bit13 = 1ul << 13,
		Bit14 = 1ul << 14,
		Bit15 = 1ul << 15,
		Bit16 = 1ul << 16,
		Bit17 = 1ul << 17,
		Bit18 = 1ul << 18,
		Bit19 = 1ul << 19,
		Bit20 = 1ul << 20,
		Bit21 = 1ul << 21,
		Bit22 = 1ul << 22,
		Bit23 = 1ul << 23,
		Bit24 = 1ul << 24,
		Bit25 = 1ul << 25,
		Bit26 = 1ul << 26,
		Bit27 = 1ul << 27,
		Bit28 = 1ul << 28,
		Bit29 = 1ul << 29,
		Bit30 = 1ul << 30,
		Bit31 = 1ul << 31,
		Bit32 = 1ul << 32,
		Bit33 = 1ul << 33,
		Bit34 = 1ul << 34,
		Bit35 = 1ul << 35,
		Bit36 = 1ul << 36,
		Bit37 = 1ul << 37,
		Bit38 = 1ul << 38,
		Bit39 = 1ul << 39,
		Bit40 = 1ul << 40,
		Bit41 = 1ul << 41,
		Bit42 = 1ul << 42,
		Bit43 = 1ul << 43,
		Bit44 = 1ul << 44,
		Bit45 = 1ul << 45,
		Bit46 = 1ul << 46,
		Bit47 = 1ul << 47,
		Bit48 = 1ul << 48,
		Bit49 = 1ul << 49,
		Bit50 = 1ul << 50,
		Bit51 = 1ul << 51,
		Bit52 = 1ul << 52,
		Bit53 = 1ul << 53,
		Bit54 = 1ul << 54,
		Bit55 = 1ul << 55,
		Bit56 = 1ul << 56,
		Bit57 = 1ul << 57,
		Bit58 = 1ul << 58,
		Bit59 = 1ul << 59,
		Bit60 = 1ul << 60,
		Bit61 = 1ul << 61,
		Bit62 = 1ul << 62,
		Bit63 = 1ul << 63,
	}

	[Flags]
	public enum LongEnum
		: long
	{
		None = 0,
		Bit0 = 1L,
		Bit1 = 1L << 1,
		Bit2 = 1L << 2,
		Bit3 = 1L << 3,
		Bit4 = 1L << 4,
		Bit5 = 1L << 5,
		Bit6 = 1L << 6,
		Bit7 = 1L << 7,
		Bit8 = 1L << 8,
		Bit9 = 1L << 9,
		Bit10 = 1L << 10,
		Bit11 = 1L << 11,
		Bit12 = 1L << 12,
		Bit13 = 1L << 13,
		Bit14 = 1L << 14,
		Bit15 = 1L << 15,
		Bit16 = 1L << 16,
		Bit17 = 1L << 17,
		Bit18 = 1L << 18,
		Bit19 = 1L << 19,
		Bit20 = 1L << 20,
		Bit21 = 1L << 21,
		Bit22 = 1L << 22,
		Bit23 = 1L << 23,
		Bit24 = 1L << 24,
		Bit25 = 1L << 25,
		Bit26 = 1L << 26,
		Bit27 = 1L << 27,
		Bit28 = 1L << 28,
		Bit29 = 1L << 29,
		Bit30 = 1L << 30,
		Bit31 = 1L << 31,
		Bit32 = 1L << 32,
		Bit33 = 1L << 33,
		Bit34 = 1L << 34,
		Bit35 = 1L << 35,
		Bit36 = 1L << 36,
		Bit37 = 1L << 37,
		Bit38 = 1L << 38,
		Bit39 = 1L << 39,
		Bit40 = 1L << 40,
		Bit41 = 1L << 41,
		Bit42 = 1L << 42,
		Bit43 = 1L << 43,
		Bit44 = 1L << 44,
		Bit45 = 1L << 45,
		Bit46 = 1L << 46,
		Bit47 = 1L << 47,
		Bit48 = 1L << 48,
		Bit49 = 1L << 49,
		Bit50 = 1L << 50,
		Bit51 = 1L << 51,
		Bit52 = 1L << 52,
		Bit53 = 1L << 53,
		Bit54 = 1L << 54,
		Bit55 = 1L << 55,
		Bit56 = 1L << 56,
		Bit57 = 1L << 57,
		Bit58 = 1L << 58,
		Bit59 = 1L << 59,
		Bit60 = 1L << 60,
		Bit61 = 1L << 61,
		Bit62 = 1L << 62,
		Bit63 = 1L << 63,
	}
}
