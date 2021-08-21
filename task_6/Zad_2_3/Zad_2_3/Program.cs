using System;
using System.IO;
using System.Threading;

namespace Zad_2_3
{
    class DecorateStream : Stream
    {
        private Stream _stream;
        private float _numberReadByte;
        private string _password = "password";
        public DecorateStream(string nameFile)
        {
            Console.Write("Введите пароль для чтения файла: ");
            string password = Console.ReadLine();
            if (password == _password)
                _stream = new FileStream(nameFile, FileMode.Open);
            else
                throw new FieldAccessException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int countByte = _stream.Read(buffer, offset, count);
            _numberReadByte += countByte;
            int procent = (int)(_numberReadByte / Length * 100) ;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Ожидание чтения файла.");
            Console.WriteLine("Выполнено {0}%", procent);
            Thread.Sleep(100);
            return countByte;
        }

        public override bool CanRead
        {
            get { return _stream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _stream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _stream.CanWrite; }
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override long Length
        {
            get { return _stream.Length; }
        }

        public override long Position
        {
            get { return _stream.Position; }
            set { _stream.Position = value; }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DecorateStream decorateStream = new DecorateStream("file.txt");
                byte[] bytes = new byte[100];
                while (decorateStream.Read(bytes, 0, 20) != 0) ;
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File is not exists.");
            }
            catch(FieldAccessException)
            {
                Console.WriteLine("Incorrect password.");
            }
            Console.ReadLine();
        }
    }
}
