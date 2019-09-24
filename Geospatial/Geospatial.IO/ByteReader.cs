using System;
using System.Linq;

namespace Geospatial.IO
{
    public class ByteReader
    {
        private byte[] _data;
        private int _index;

        public ByteReader(byte[] data)
        {
            _data = data;
        }

        public byte ReadByte()
        {
            return _data[_index++];
        }

        public int CurrentIndex
        {
            get
            {
                return _index;
            }
        }

        public int ReadInt(bool isLittleEndian)
        {
            int val = 0;

            byte b1 = _data[_index++];
            byte b2 = _data[_index++];
            byte b3 = _data[_index++];
            byte b4 = _data[_index++];

            if(!isLittleEndian)
            {
                val |= b1 << 24;
                val |= b2 << 16;
                val |= b3 << 8;
                val |= b4 << 0;
            }
            else
            {
                val |= b4 << 24;
                val |= b3 << 16;
                val |= b2 << 8;
                val |= b1 << 0;
            }

            return val;
        }

        public double ReadDouble(bool isLittleEndian)
        {
            double val = 0;

            byte[] doubleData = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                doubleData[i] = _data[_index++];
            }

            if(!isLittleEndian)
            {
                doubleData = doubleData.Reverse().ToArray();
            }

            val = System.BitConverter.ToDouble(doubleData, 0);            

            return val;
        }
    }
}
