using Hashtable;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class PointTests
        {
            [TestMethod]
            public void Test1()
            {
                var point = new Point<int, string>();
                Assert.IsFalse(point.isDeleted);
            }

            [TestMethod]
            public void Test2()
            {
                var point = new Point<int, string>();
                Assert.AreEqual(point.Key, 0);
            }

            [TestMethod]
            public void Test3()
            {
                var point = new Point<int, string>();
                Assert.IsNull(point.Value);
            }

            [TestMethod]
            public void Test4()
            {
                var key = 10;
                var value = "test";
                var point = new Point<int, string>(key, value);
                Assert.AreEqual(key, point.Key);
                Assert.AreEqual(value, point.Value);
            }

            [TestMethod]
            public void Test5()
            {
                var key = 10;
                var value = "test";
                var point = new Point<int, string>(key, value);
                var clonedPoint = point.Clone();
                Assert.AreNotSame(point, clonedPoint);
                Assert.AreEqual(point.Key, clonedPoint.Key);
                Assert.AreEqual(point.Value, clonedPoint.Value);
            }

            [TestMethod]
            public void Test6()
            {
                var point = new Point<int, string>(10, "test");
                var removedPoint = point.Remove();
                Assert.IsTrue(removedPoint.isDeleted);
            }
        }


        [TestClass]
        public class HashtableTests
        {
            [TestMethod]
            public void Test7()
            {
                var hashtable = new Hashtable<int, string>();
                hashtable = hashtable.AddItem(1, "value1");
                Assert.AreEqual(1, hashtable.Count);
            }

            [TestMethod]
            public void Test8()
            {
                var hashtable = new Hashtable<int, string>();
                hashtable.AddItem(1, "value1");
                Assert.ThrowsException<Exception>(() => hashtable.AddItem(1, "value2"));
            }

            [TestMethod]
            public void Test9()
            {
                var hashtable = new Hashtable<int, string>();
                hashtable.AddItem(1, "value1");
                hashtable.AddItem(2, "value2");
            }

            [TestMethod]
            public void Test10()
            {
                var hashtable = new Hashtable<int, string>();
                hashtable.AddItem(1, "value1");
                Assert.AreEqual(-1, hashtable.FindItem(2));
            }

            [TestMethod]
            public void Test11()
            {
                var hashtable = new Hashtable<int, string>();
                hashtable.AddItem(1, "value1");
                hashtable = hashtable.Delete(1);
                Assert.AreEqual(-1, hashtable.FindItem(1));
            }

            [TestMethod]
            public void Test12()
            {
                var hashtable = new Hashtable<int, string>();
                hashtable.AddItem(1, "value1");
                hashtable.AddItem(2, "value2");
                hashtable = hashtable.Clear();
                Assert.AreEqual(0, hashtable.Count);
            }

            [TestMethod]
            public void Test13()
            {
                Assert.ThrowsException<Exception>(() => new Hashtable<int, string>(-1));
            }

            [TestMethod]
            public void Test14()
            {
                var hashtable = new Hashtable<string, string>();
                Assert.ThrowsException<Exception>(() => hashtable.GetIndex(null));
            }

            [TestMethod]
            public void Test15()
            {
                var hashtable = new Hashtable<int, string>();
                hashtable.AddItem(1, "value1");
                Assert.ThrowsException<Exception>(() => hashtable.AddItem(1, "value2"));
            }

            [TestMethod]
            public void Test16()
            {
                var hashtable = new Hashtable<int, string>(3);
                hashtable.AddItem(1, "value1");
                hashtable.AddItem(2, "value2");
                hashtable.AddItem(3, "value3");
            }

            [TestMethod]
            public void Test17()
            {
                var hashtable = new Hashtable<int, string>(7);
                hashtable.Clear();
                hashtable.AddItem(1, "value1");
                hashtable.AddItem(2, "value2");
                int number = 0;
                while(hashtable.GetIndex(number) != hashtable.GetIndex(1))
                {
                    number++;
                }
                hashtable.AddData(number, "value3");
                
            }

            [TestMethod]
            public void Test18()
            {
                var hashtable = new Hashtable<int, string>();
                hashtable.AddItem(1, "value1");
                hashtable = hashtable.Delete(1);
                Assert.IsNull(hashtable.table[0]); 
            }

            [TestMethod]
            public void Test19()
            {
                var hashtable = new Hashtable<int, string>(2); 
                hashtable.AddItem(1, "value1");
                hashtable.AddItem(2, "value2");
                hashtable = hashtable.Delete(1);
                Assert.AreEqual(true, hashtable.table[1].isDeleted); 
            }

            [TestMethod]
            public void Test20()
            {
                var hashtable = new Hashtable<int, string>();
                Assert.ThrowsException<Exception>(() => hashtable.Delete(1));
            }
            [TestMethod]
            public void Test21()
            {
                var hashtable = new Hashtable<string, int>(8); 
                hashtable.AddItem("zxc",1);
                hashtable.AddItem("xcz", 2);
                hashtable.AddItem("cxz", 3);
                hashtable = hashtable.Delete("zxc"); 
                hashtable = hashtable.Delete("zxc");
                Assert.IsNull(hashtable.table[1]); 
            }
        }
    }
}