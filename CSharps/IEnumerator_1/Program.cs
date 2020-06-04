using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using System.Linq;

namespace IEnumerator_1
{
    /// <summary>
    /// 实现一个自己的迭代器
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = new string[5] { "a", "b", "c", "d", "e" };

            var list = new ArrayEnumerable(data);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            var list2 = new FileEnumerable2<string>("Program.cs");
            var list3 = list2.Where(s => s.Contains("E"));
            //var list4 = list3.Where(s => s.Contains("P"));
            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    #region 数组迭代器

    public class ArrayEnumerable : IEnumerable
    {
        object[] data;

        public ArrayEnumerable(object[] data)
        {
            this.data = data;
        }

        public IEnumerator GetEnumerator()
        {
            return new ArrayEnumerator(this.data);
        }

        class ArrayEnumerator : IEnumerator
        {
            object[] data;
            int index = 0;

            public ArrayEnumerator(object[] data)
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
    #endregion

    #region 文件行迭代器
    public class FileEnumerable : IEnumerable, IDisposable
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

    public class FileEnumerable2<T> : IEnumerable<T>, IEnumerator<T> where T : class
    {
        string filepath;
        FileStream fileStream;
        StreamReader streamReader;
        T line;

        public T Current { get { return line; } }

        object IEnumerator.Current { get { return this.Current; } }

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
                while ((line = streamReader.ReadLine() as T) != null)
                {
                    yield return line;
                }

                Console.WriteLine("IEnumerator");

                yield break;
            }
            finally
            {

            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            try
            {
                while ((line = streamReader.ReadLine() as T) != null)
                {
                    yield return line;
                }

                Console.WriteLine("IEnumerator");

                yield break;
            }
            finally
            {

            }
        }

        internal IEnumerable<T> Where(Func<T, bool> p)
        {
            var enumerator = this.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (p(line))
                {
                    yield return line;
                }
            }

            yield break;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
