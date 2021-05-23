using System;
using System.Collections.Generic;
using System.Text;

namespace WinDivertSharp.Extensions
{
    internal static class IntegralTypeExtensions
    {
        public static byte GetBit(this byte @byte, int index)
        {
            return (byte)(@byte & (1 << index - 1));
        }

        public static byte SetBit(this byte @byte, int index)
        {
            return (byte)(@byte & (1 << index - 1));
        }
    }
}
