using System;
using System.IO;
using System.Threading;

namespace Exercise_2_3
{
    class DecorativeStream : Stream
    {
        private Stream _stream;
        private float _numberReadByte;
        private string _password = "password";
        public int PercentageRead { get; private set; }
        public DecorativeStream(string nameFile, string userPassword)
        {
            if (userPassword == _password)
                _stream = new FileStream(nameFile, FileMode.Open);
            else
                throw new FieldAccessException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int countByte = _stream.Read(buffer, offset, count);
            _numberReadByte += countByte;
            PercentageRead = (int)(_numberReadByte / Length * 100);
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
}
