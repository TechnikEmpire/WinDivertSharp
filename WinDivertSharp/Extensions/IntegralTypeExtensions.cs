/*
* Copyright © 2018-Present Jesse Nicholson
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Runtime.CompilerServices;

namespace WinDivertSharp.Extensions
{
    /// <summary>
    /// Some handy-dandy extensions for integral types.
    /// </summary>
    public static class IntegralTypeExtensions
    {
        /// <summary>
        /// Swaps the endianness of the short.
        /// </summary>
        /// <param name="val">
        /// The current value.
        /// </param>
        /// <returns>
        /// The short value in reverse-order from its current state.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short SwapByteOrder(this short val)
        {
            return (short)(((ushort)val).SwapByteOrder());
        }

        /// <summary>
        /// Swaps the endianness of the ushort.
        /// </summary>
        /// <param name="val">
        /// The current value.
        /// </param>
        /// <returns>
        /// The ushort value in reverse-order from its current state.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort SwapByteOrder(this ushort val)
        {
            return (ushort)(((val & 0xFF00) >> 8) | ((val & 0x00FF) << 8));
        }

        /// <summary>
        /// Swaps the endianness of the integer.
        /// </summary>
        /// <param name="val">
        /// The current value.
        /// </param>
        /// <returns>
        /// The integer value in reverse-order from its current state.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SwapByteOrder(this int val)
        {
            return (int)(((uint)val).SwapByteOrder());
        }

        /// <summary>
        /// Swaps the endianness of the unsigned integer.
        /// </summary>
        /// <param name="val">
        /// The current value.
        /// </param>
        /// <returns>
        /// The unsigned integer value in reverse-order from its current state.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SwapByteOrder(this uint val)
        {
            val = (val >> 16) | (val << 16);
            return ((val & 0xFF00) >> 8) | ((val & 0x00FF) << 8);
        }

        /// <summary>
        /// Swaps the endianness of the long integer.
        /// </summary>
        /// <param name="val">
        /// The current value.
        /// </param>
        /// <returns>
        /// The long integer value in reverse-order from its current state.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long SwapByteOrder(this long val)
        {
            return (long)(((ulong)val).SwapByteOrder());
        }

        /// <summary>
        /// Swaps the endianness of the unsigned long integer.
        /// </summary>
        /// <param name="val">
        /// The current value.
        /// </param>
        /// <returns>
        /// The unsigned long integer value in reverse-order from its current state.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong SwapByteOrder(this ulong val)
        {
            val = (val >> 32) | (val << 32);
            val = ((val & 0xFFFF0000FFFF0000) >> 16) | ((val & 0x0000FFFF0000FFFF) << 16);
            return ((val & 0xFF00FF00FF00FF00) >> 8) | ((val & 0x00FF00FF00FF00FF) << 8);
        }
    }
}