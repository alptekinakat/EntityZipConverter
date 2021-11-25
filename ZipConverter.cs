using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace AlpDb.Helper
{
    public static class ZipConverter
    {
        private static byte[] Compress(byte[] data)
        {
            if ((data != null) && (data.Length > 1024))
            {
                using (MemoryStream output = new MemoryStream())
                {
                    using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
                    {
                        dstream.Write(data, 0, data.Length);
                    }
                    return output.ToArray();
                }
            }
            else
            {
                return data;
            }
        }
        private static byte[] Decompress(byte[] data)
        {
            if (data != null)
            {
                using (MemoryStream input = new MemoryStream(data))
                using (MemoryStream output = new MemoryStream())
                {
                    using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
                    {
                        dstream.CopyTo(output);
                    }
                    return output.ToArray();
                }
            }
            else
            {
                return data;
            }
        }

        public static ValueConverter<byte[], byte[]> ZipConvert = new ValueConverter<byte[], byte[]>(
           v => Compress(v),
           v => Decompress(v));
    }
}
