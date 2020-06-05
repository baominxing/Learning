using System;
using System.Collections;
using System.IO;

namespace Interface_IEnumerable
{
    /// <summary>
    /// 用于演示IEnumable接口的用法及实现
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 实现一个最简单数组迭代器
            Sample1.Demonstration();
            #endregion

            #region 实现一个文本行读取迭代器
            Sample2.Demonstration();

            //用Yield关键字实现，简化代码
            Sample2.Demonstration2();
            #endregion

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        internal static void Demonstration()
        {
            string[] data = new string[5] { "a", "b", "c", "d", "e" };

            var list = new MyList(data);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        class MyList : IEnumerable
        {
            object[] data;

            public MyList(object[] data)
            {
                this.data = data;
            }

            public IEnumerator GetEnumerator()
            {
                return new MyEnumerator(this.data);
            }

            class MyEnumerator : IEnumerator
            {
                object[] data;
                int index = 0;

                public MyEnumerator(object[] data)
                {
                    this.data = data;
                }

                public object Current
                {
                    get
                    {
                        Console.WriteLine($"Current{index}");
                        return this.data[index++];
                    }
                }

                public bool MoveNext()
                {
                    Console.WriteLine($"MoveNext{index}");

                    return index < this.data.Length;
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }

    public class Sample2
    {
        internal static void Demonstration()
        {
            using (var list = new FileEnumerable("Program.cs"))
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }

        internal static void Demonstration2()
        {
            using (var list = new FileEnumerable2("Program.cs"))
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }

        class FileEnumerable : IEnumerable, IDisposable
        {
            string filepath;
            FileEnumerator fileEnumerator;
            public FileEnumerable(string filepath)
            {
                this.filepath = filepath;
            }

            public void Dispose()
            {
                fileEnumerator.Dispose();
            }

            public IEnumerator GetEnumerator()
            {
                return fileEnumerator = new FileEnumerator(this.filepath);
            }

            class FileEnumerator : IEnumerator
            {
                string filepath;
                object current;
                FileStream fileStream;
                StreamReader streamReader;
                bool disposed;

                public FileEnumerator(string filepath)
                {
                    this.filepath = filepath;
                    fileStream = File.OpenRead(filepath);
                    streamReader = new StreamReader(fileStream);
                }

                public object Current
                {
                    get
                    {
                        return current;
                    }
                }

                public bool MoveNext()
                {
                    return (current = streamReader.ReadLine()) != null;
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }

                public void Dispose()
                {
                    Dispose(true);
                    GC.SuppressFinalize(this);
                }

                protected virtual void Dispose(bool disposing)
                {
                    if (disposed)
                    {
                        return;
                    }

                    if (disposing)
                    {
                        if (streamReader != null)
                        {
                            streamReader.Dispose();
                        }
                        if (fileStream != null)
                        {
                            fileStream.Dispose();
                        }
                    }
                    disposed = true;
                }

                ~FileEnumerator()
                {
                    Dispose(false);
                }
            }
        }

        class FileEnumerable2 : IEnumerable, IDisposable
        {
            string filepath;
            string current;
            FileStream fileStream;
            StreamReader streamReader;
            public FileEnumerable2(string filepath)
            {
                this.filepath = filepath;
                fileStream = File.OpenRead(filepath);
                streamReader = new StreamReader(fileStream);
            }

            public IEnumerator GetEnumerator()
            {
                try
                {
                    while ((current = streamReader.ReadLine()) != null)
                    {
                        yield return current;
                    }

                    Console.WriteLine("IEnumerator Over");

                    yield break;
                }
                finally
                {
                    if (streamReader != null)
                    {
                        streamReader.Dispose();
                    }
                    if (fileStream != null)
                    {
                        fileStream.Dispose();
                    }

                    disposedValue = true;
                }
            }

            #region IDisposable Support
            private bool disposedValue = false; // 要检测冗余调用

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: 释放托管状态(托管对象)。
                    }

                    // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                    // TODO: 将大型字段设置为 null。

                    disposedValue = true;
                }
            }

            // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
            // ~FileEnumerable2()
            // {
            //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            //   Dispose(false);
            // }

            // 添加此代码以正确实现可处置模式。
            public void Dispose()
            {
                // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
                Dispose(true);
                // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
                // GC.SuppressFinalize(this);
            }
            #endregion
        }
    }
}
