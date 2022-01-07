using System;

using NUnit.Framework;

namespace Solar.IL.Tests
{
	public partial class FlagEnumUtilTest
	{
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

		[Test]
		public void HasFlagsTest()
		{
			Assert.IsTrue((ByteEnum.Bit2 | ByteEnum.Bit3 | ByteEnum.Bit7).HasFlags(ByteEnum.Bit3 | ByteEnum.Bit7));
			Assert.IsTrue((SByteEnum.Bit2 | SByteEnum.Bit3 | SByteEnum.Bit7).HasFlags(SByteEnum.Bit3 | SByteEnum.Bit7));

			Assert.IsFalse((ByteEnum.Bit2 | ByteEnum.Bit3 | ByteEnum.Bit7).HasFlags(ByteEnum.Bit3 | ByteEnum.Bit1));
		}
	}
}


// ByteEnum
namespace Solar.IL.Tests
{
	using static Solar.IL.Tests.ByteEnum;

	using TestCase = TestCase<ByteEnum>;
	using UnaryTestCase = UnaryTestCase<ByteEnum>;

	partial class FlagEnumUtilTest
	{
		[Test]
		public void ByteEnumOrTests()
		{
			TestCase orCase = new()
			{
				Initial = Bit0 | Bit4,
				Phase1 = Bit7,
				Phase1Result = Bit0 | Bit4 | Bit7,
				Phase2 = Bit0,
				Phase2Result = Bit0 | Bit4 | Bit7,
				Phase3 = Bit1,
				Phase3Result = Bit0 | Bit1 | Bit4 | Bit7,
				InvalidPhase3Result = Bit0 | Bit4 | Bit7
			};

			orCase.Process((x, y) => x.Or(y));
		}

		[Test]
		public void ByteEnumAndTests()
		{
			TestCase andCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit7,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit0 | Bit1 | Bit6,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1,
				Phase3 = Bit0,
				Phase3Result = Bit0,
				InvalidPhase3Result = Bit0 | Bit1
			};

			andCase.Process((x, y) => x.And(y));
		}

		[Test]
		public void ByteEnumXorTests()
		{
			TestCase xorCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit7,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit7,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1 | Bit7,
				Phase3 = Bit0,
				Phase3Result = Bit1 | Bit7,
				InvalidPhase3Result = Bit0 | Bit1 | Bit7,
			};

			xorCase.Process((x, y) => x.Xor(y));
		}

		[Test]
		public void ByteEnumNotTests()
		{
			UnaryTestCase notCase = new()
			{
				Initial = Bit0 | Bit7,
				Phase1Result = Bit1 | Bit2 | Bit3 | Bit4 | Bit5 | Bit6,
				Phase2Result = Bit0 | Bit7
			};

			notCase.Process(x => x.Not());
		}
	}
}

// SByteEnum
namespace Solar.IL.Tests
{
	using static Solar.IL.Tests.SByteEnum;

	using TestCase = TestCase<SByteEnum>;
	using UnaryTestCase = UnaryTestCase<SByteEnum>;

	partial class FlagEnumUtilTest
	{
		[Test]
		public void SByteEnumOrTests()
		{
			TestCase orCase = new()
			{
				Initial = Bit0 | Bit4,
				Phase1 = Bit7,
				Phase1Result = Bit0 | Bit4 | Bit7,
				Phase2 = Bit0,
				Phase2Result = Bit0 | Bit4 | Bit7,
				Phase3 = Bit1,
				Phase3Result = Bit0 | Bit1 | Bit4 | Bit7,
				InvalidPhase3Result = Bit0 | Bit4 | Bit7
			};

			orCase.Process((x, y) => x.Or(y));
		}

		[Test]
		public void SByteEnumAndTests()
		{
			TestCase andCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit7,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit0 | Bit1 | Bit6,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1,
				Phase3 = Bit0,
				Phase3Result = Bit0,
				InvalidPhase3Result = Bit0 | Bit1
			};

			andCase.Process((x, y) => x.And(y));
		}

		[Test]
		public void SByteEnumXorTests()
		{
			TestCase xorCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit7,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit7,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1 | Bit7,
				Phase3 = Bit0,
				Phase3Result = Bit1 | Bit7,
				InvalidPhase3Result = Bit0 | Bit1 | Bit7,
			};

			xorCase.Process((x, y) => x.Xor(y));
		}

		[Test]
		public void SByteEnumNotTests()
		{
			UnaryTestCase notCase = new()
			{
				Initial = Bit0 | Bit7,
				Phase1Result = Bit1 | Bit2 | Bit3 | Bit4 | Bit5 | Bit6,
				Phase2Result = Bit0 | Bit7
			};

			notCase.Process(x => x.Not());
		}
	}
}

// UShortEnum
namespace Solar.IL.Tests
{
	using static Solar.IL.Tests.UShortEnum;

	using TestCase = TestCase<UShortEnum>;
	using UnaryTestCase = UnaryTestCase<UShortEnum>;

	partial class FlagEnumUtilTest
	{
		[Test]
		public void UShortEnumOrTests()
		{
			TestCase orCase = new()
			{
				Initial = Bit0 | Bit4,
				Phase1 = Bit15,
				Phase1Result = Bit0 | Bit4 | Bit15,
				Phase2 = Bit0,
				Phase2Result = Bit0 | Bit4 | Bit15,
				Phase3 = Bit1,
				Phase3Result = Bit0 | Bit1 | Bit4 | Bit15,
				InvalidPhase3Result = Bit0 | Bit4 | Bit15
			};

			orCase.Process((x, y) => x.Or(y));
		}

		[Test]
		public void UShortEnumAndTests()
		{
			TestCase andCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit15,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit0 | Bit1 | Bit6,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1,
				Phase3 = Bit0,
				Phase3Result = Bit0,
				InvalidPhase3Result = Bit0 | Bit1
			};

			andCase.Process((x, y) => x.And(y));
		}

		[Test]
		public void UShortEnumXorTests()
		{
			TestCase xorCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit15,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit15,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1 | Bit15,
				Phase3 = Bit0,
				Phase3Result = Bit1 | Bit15,
				InvalidPhase3Result = Bit0 | Bit1 | Bit15,
			};

			xorCase.Process((x, y) => x.Xor(y));
		}

		[Test]
		public void UShortEnumNotTests()
		{
			UnaryTestCase notCase = new()
			{
				Initial = Bit0 | Bit1 | Bit7 | Bit14 | Bit15,
				Phase1Result = Bit2 | Bit3 | Bit4 | Bit5 | Bit6 | Bit8 | Bit9 | Bit10 | Bit11 | Bit12 | Bit13,
				Phase2Result = Bit0 | Bit1 | Bit7 | Bit14 | Bit15,
			};

			notCase.Process(x => x.Not());
		}
	}

}

// ShortEnum
namespace Solar.IL.Tests
{
	using static Solar.IL.Tests.ShortEnum;

	using TestCase = TestCase<ShortEnum>;
	using UnaryTestCase = UnaryTestCase<ShortEnum>;

	partial class FlagEnumUtilTest
	{
		[Test]
		public void ShortEnumOrTests()
		{
			TestCase orCase = new()
			{
				Initial = Bit0 | Bit4,
				Phase1 = Bit15,
				Phase1Result = Bit0 | Bit4 | Bit15,
				Phase2 = Bit0,
				Phase2Result = Bit0 | Bit4 | Bit15,
				Phase3 = Bit1,
				Phase3Result = Bit0 | Bit1 | Bit4 | Bit15,
				InvalidPhase3Result = Bit0 | Bit4 | Bit15
			};

			orCase.Process((x, y) => x.Or(y));
		}

		[Test]
		public void ShortEnumAndTests()
		{
			TestCase andCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit15,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit0 | Bit1 | Bit6,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1,
				Phase3 = Bit0,
				Phase3Result = Bit0,
				InvalidPhase3Result = Bit0 | Bit1
			};

			andCase.Process((x, y) => x.And(y));
		}

		[Test]
		public void ShortEnumXorTests()
		{
			TestCase xorCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit15,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit15,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1 | Bit15,
				Phase3 = Bit0,
				Phase3Result = Bit1 | Bit15,
				InvalidPhase3Result = Bit0 | Bit1 | Bit15,
			};

			xorCase.Process((x, y) => x.Xor(y));
		}

		[Test]
		public void ShortEnumNotTests()
		{
			UnaryTestCase notCase = new()
			{
				Initial = Bit0 | Bit1 | Bit7 | Bit14 | Bit15,
				Phase1Result = Bit2 | Bit3 | Bit4 | Bit5 | Bit6 | Bit8 | Bit9 | Bit10 | Bit11 | Bit12 | Bit13,
				Phase2Result = Bit0 | Bit1 | Bit7 | Bit14 | Bit15,
			};

			notCase.Process(x => x.Not());
		}
	}
}

// UIntEnum
namespace Solar.IL.Tests
{
	using static Solar.IL.Tests.UIntEnum;

	using TestCase = TestCase<UIntEnum>;
	using UnaryTestCase = UnaryTestCase<UIntEnum>;

	partial class FlagEnumUtilTest
	{
		[Test]
		public void UIntEnumOrTests()
		{
			TestCase orCase = new()
			{
				Initial = Bit0 | Bit4,
				Phase1 = Bit31,
				Phase1Result = Bit0 | Bit4 | Bit31,
				Phase2 = Bit0,
				Phase2Result = Bit0 | Bit4 | Bit31,
				Phase3 = Bit1,
				Phase3Result = Bit0 | Bit1 | Bit4 | Bit31,
				InvalidPhase3Result = Bit0 | Bit4 | Bit31
			};

			orCase.Process((x, y) => x.Or(y));
		}

		[Test]
		public void UIntEnumAndTests()
		{
			TestCase andCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit31,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit0 | Bit1 | Bit6,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1,
				Phase3 = Bit0,
				Phase3Result = Bit0,
				InvalidPhase3Result = Bit0 | Bit1
			};

			andCase.Process((x, y) => x.And(y));
		}

		[Test]
		public void UIntEnumXorTests()
		{
			TestCase xorCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit31,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit31,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1 | Bit31,
				Phase3 = Bit0,
				Phase3Result = Bit1 | Bit31,
				InvalidPhase3Result = Bit0 | Bit1 | Bit31,
			};

			xorCase.Process((x, y) => x.Xor(y));
		}

		[Test]
		public void UIntEnumNotTests()
		{
			UnaryTestCase notCase = new()
			{
				Initial = Bit0 | Bit2 | Bit4 | Bit6 | Bit8 | Bit10 | Bit12 | Bit14 | Bit16 | Bit18 | Bit20 | Bit22 | Bit24 | Bit26 | Bit28 | Bit30,
				Phase1Result = Bit1 | Bit3 | Bit5 | Bit7 | Bit9 | Bit11 | Bit13 | Bit15 | Bit17 | Bit19 | Bit21 | Bit23 | Bit25 | Bit27 | Bit29 | Bit31,
				Phase2Result = Bit0 | Bit2 | Bit4 | Bit6 | Bit8 | Bit10 | Bit12 | Bit14 | Bit16 | Bit18 | Bit20 | Bit22 | Bit24 | Bit26 | Bit28 | Bit30,
			};

			notCase.Process(x => x.Not());
		}
	}
}

// IntEnum
namespace Solar.IL.Tests
{
	using static Solar.IL.Tests.IntEnum;

	using TestCase = TestCase<IntEnum>;
	using UnaryTestCase = UnaryTestCase<IntEnum>;

	partial class FlagEnumUtilTest
	{
		[Test]
		public void IntEnumOrTests()
		{
			TestCase orCase = new()
			{
				Initial = Bit0 | Bit4,
				Phase1 = Bit31,
				Phase1Result = Bit0 | Bit4 | Bit31,
				Phase2 = Bit0,
				Phase2Result = Bit0 | Bit4 | Bit31,
				Phase3 = Bit1,
				Phase3Result = Bit0 | Bit1 | Bit4 | Bit31,
				InvalidPhase3Result = Bit0 | Bit4 | Bit31
			};

			orCase.Process((x, y) => x.Or(y));
		}

		[Test]
		public void IntEnumAndTests()
		{
			TestCase andCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit31,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit0 | Bit1 | Bit6,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1,
				Phase3 = Bit0,
				Phase3Result = Bit0,
				InvalidPhase3Result = Bit0 | Bit1
			};

			andCase.Process((x, y) => x.And(y));
		}

		[Test]
		public void IntEnumXorTests()
		{
			TestCase xorCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit31,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit31,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1 | Bit31,
				Phase3 = Bit0,
				Phase3Result = Bit1 | Bit31,
				InvalidPhase3Result = Bit0 | Bit1 | Bit31,
			};

			xorCase.Process((x, y) => x.Xor(y));
		}

		[Test]
		public void IntEnumNotTests()
		{
			UnaryTestCase notCase = new()
			{
				Initial = Bit0 | Bit2 | Bit4 | Bit6 | Bit8 | Bit10 | Bit12 | Bit14 | Bit16 | Bit18 | Bit20 | Bit22 | Bit24 | Bit26 | Bit28 | Bit30,
				Phase1Result = Bit1 | Bit3 | Bit5 | Bit7 | Bit9 | Bit11 | Bit13 | Bit15 | Bit17 | Bit19 | Bit21 | Bit23 | Bit25 | Bit27 | Bit29 | Bit31,
				Phase2Result = Bit0 | Bit2 | Bit4 | Bit6 | Bit8 | Bit10 | Bit12 | Bit14 | Bit16 | Bit18 | Bit20 | Bit22 | Bit24 | Bit26 | Bit28 | Bit30,
			};

			notCase.Process(x => x.Not());
		}
	}
}

// ULongEnum
namespace Solar.IL.Tests
{
	using static Solar.IL.Tests.ULongEnum;

	using TestCase = TestCase<ULongEnum>;
	using UnaryTestCase = UnaryTestCase<ULongEnum>;

	partial class FlagEnumUtilTest
	{
		[Test]
		public void ULongEnumOrTests()
		{
			TestCase orCase = new()
			{
				Initial = Bit0 | Bit4,
				Phase1 = Bit63,
				Phase1Result = Bit0 | Bit4 | Bit63,
				Phase2 = Bit0,
				Phase2Result = Bit0 | Bit4 | Bit63,
				Phase3 = Bit1,
				Phase3Result = Bit0 | Bit1 | Bit4 | Bit63,
				InvalidPhase3Result = Bit0 | Bit4 | Bit63
			};

			orCase.Process((x, y) => x.Or(y));
		}

		[Test]
		public void ULongEnumAndTests()
		{
			TestCase andCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit63,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit0 | Bit1 | Bit6,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1,
				Phase3 = Bit0,
				Phase3Result = Bit0,
				InvalidPhase3Result = Bit0 | Bit1
			};

			andCase.Process((x, y) => x.And(y));
		}

		[Test]
		public void ULongEnumXorTests()
		{
			TestCase xorCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit63,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit63,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1 | Bit63,
				Phase3 = Bit0,
				Phase3Result = Bit1 | Bit63,
				InvalidPhase3Result = Bit0 | Bit1 | Bit63,
			};

			xorCase.Process((x, y) => x.Xor(y));
		}

		[Test]
		public void ULongEnumNotTests()
		{
			UnaryTestCase notCase = new()
			{
				Initial = Bit0 | Bit2 | Bit4 | Bit6 | Bit8 | Bit10 | Bit12 | Bit14 | Bit16 | Bit18 | Bit20 | Bit22 | Bit24 | Bit26 | Bit28 | Bit30 | Bit32 | Bit34 | Bit36 | Bit38 | Bit40 | Bit42 | Bit44 | Bit46 | Bit48 | Bit50 | Bit52 | Bit54 | Bit56 | Bit58 | Bit60 | Bit62,
				Phase1Result = Bit1 | Bit3 | Bit5 | Bit7 | Bit9 | Bit11 | Bit13 | Bit15 | Bit17 | Bit19 | Bit21 | Bit23 | Bit25 | Bit27 | Bit29 | Bit31 | Bit33 | Bit35 | Bit37 | Bit39 | Bit41 | Bit43 | Bit45 | Bit47 | Bit49 | Bit51 | Bit53 | Bit55 | Bit57 | Bit59 | Bit61 | Bit63,
				Phase2Result = Bit0 | Bit2 | Bit4 | Bit6 | Bit8 | Bit10 | Bit12 | Bit14 | Bit16 | Bit18 | Bit20 | Bit22 | Bit24 | Bit26 | Bit28 | Bit30 | Bit32 | Bit34 | Bit36 | Bit38 | Bit40 | Bit42 | Bit44 | Bit46 | Bit48 | Bit50 | Bit52 | Bit54 | Bit56 | Bit58 | Bit60 | Bit62,
			};

			notCase.Process(x => x.Not());
		}
	}
}

// LongEnum
namespace Solar.IL.Tests
{
	using static Solar.IL.Tests.LongEnum;

	using TestCase = TestCase<LongEnum>;
	using UnaryTestCase = UnaryTestCase<LongEnum>;

	partial class FlagEnumUtilTest
	{
		[Test]
		public void LongEnumOrTests()
		{
			TestCase orCase = new()
			{
				Initial = Bit0 | Bit4,
				Phase1 = Bit63,
				Phase1Result = Bit0 | Bit4 | Bit63,
				Phase2 = Bit0,
				Phase2Result = Bit0 | Bit4 | Bit63,
				Phase3 = Bit1,
				Phase3Result = Bit0 | Bit1 | Bit4 | Bit63,
				InvalidPhase3Result = Bit0 | Bit4 | Bit63
			};

			orCase.Process((x, y) => x.Or(y));
		}

		[Test]
		public void LongEnumAndTests()
		{
			TestCase andCase = new()
			{
				Initial = Bit0 | Bit1 | Bit6 | Bit63,
				Phase1 = Bit0 | Bit1 | Bit6,
				Phase1Result = Bit0 | Bit1 | Bit6,
				Phase2 = Bit0 | Bit1,
				Phase2Result = Bit0 | Bit1,
				Phase3 = Bit0,
				Phase3Result = Bit0,
				InvalidPhase3Result = Bit0 | Bit1
			};

			andCase.Process((x, y) => x.And(y));
		}

		[Test]
		public void LongEnumNotTests()
		{
			UnaryTestCase notCase = new()
			{
				Initial = Bit0 | Bit2 | Bit4 | Bit6 | Bit8 | Bit10 | Bit12 | Bit14 | Bit16 | Bit18 | Bit20 | Bit22 | Bit24 | Bit26 | Bit28 | Bit30 | Bit32 | Bit34 | Bit36 | Bit38 | Bit40 | Bit42 | Bit44 | Bit46 | Bit48 | Bit50 | Bit52 | Bit54 | Bit56 | Bit58 | Bit60 | Bit62,
				Phase1Result = Bit1 | Bit3 | Bit5 | Bit7 | Bit9 | Bit11 | Bit13 | Bit15 | Bit17 | Bit19 | Bit21 | Bit23 | Bit25 | Bit27 | Bit29 | Bit31 | Bit33 | Bit35 | Bit37 | Bit39 | Bit41 | Bit43 | Bit45 | Bit47 | Bit49 | Bit51 | Bit53 | Bit55 | Bit57 | Bit59 | Bit61 | Bit63,
				Phase2Result = Bit0 | Bit2 | Bit4 | Bit6 | Bit8 | Bit10 | Bit12 | Bit14 | Bit16 | Bit18 | Bit20 | Bit22 | Bit24 | Bit26 | Bit28 | Bit30 | Bit32 | Bit34 | Bit36 | Bit38 | Bit40 | Bit42 | Bit44 | Bit46 | Bit48 | Bit50 | Bit52 | Bit54 | Bit56 | Bit58 | Bit60 | Bit62,
			};

			notCase.Process(x => x.Not());
		}
	}
}

namespace Solar.IL.Tests
{
	public sealed class TestCase<T>
	{
		public T Initial;
		public T Phase1;
		public T Phase1Result;
		public T Phase2;
		public T Phase2Result;
		public T Phase3;
		public T Phase3Result;
		public T InvalidPhase3Result;


		public void Process(Func<T, T, T> testFunc)
		{
			var value = Initial;
			value = testFunc(value, Phase1);
			Assert.AreEqual(Phase1Result, value);
			value = testFunc(value, Phase2);
			Assert.AreEqual(Phase2Result, value);
		}
	}

	public sealed class UnaryTestCase<T>
	{
		public T Initial;
		public T Phase1Result;
		public T Phase2Result;

		public void Process(Func<T,T> testFunc)
		{
			var value = Initial;
			value = testFunc(value);
			Assert.AreEqual(Phase1Result, value);
			value = testFunc(value);
			Assert.AreEqual(Phase2Result, value);
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
