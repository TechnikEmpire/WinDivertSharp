/*
 * WinDivertBuffer.cs
 * (C) 2018, all rights reserved,
 *
 * This file is part of WinDivertSharp.
 *
 * WinDivertSharp is free software: you can redistribute it and/or modify it under
 * the terms of the GNU Lesser General Public License as published by the
 * Free Software Foundation, either version 3 of the License, or (at your
 * option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * WinDivertSharp is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free
 * Software Foundation; either version 2 of the License, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
 * for more details.
 *
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 */

using System;
using System.Runtime.CompilerServices;

namespace WinDivertSharp
{
    /// <summary>
    /// Represents the result of an attempt packet parsing operation.
    /// </summary>
    public unsafe class WinDivertParseResult
    {
        internal IPv4Header* _pip4Header = null;
        internal IPv6Header* _pip6Header = null;
        internal IcmpV4Header* _picmp4Header = null;
        internal IcmpV6Header* _picmp6Header = null;
        internal TcpHeader* _ptcpHdr = null;
        internal UdpHeader* _pudpHdr = null;

        internal byte* _pdataPtr;
        internal uint _dataLen = 0;

        /// <summary>
        /// Gets whether or not the parsed packet contains an IpV4 header.
        /// </summary>
        public bool IsIPv4
        {
            get
            {
                return _pip4Header != null;
            }
        }

        /// <summary>
        /// Gets whether or not the parsed packet contains an IpV6 header.
        /// </summary>
        public bool IsIPv6
        {
            get
            {
                return _pip6Header != null;
            }
        }

        /// <summary>
        /// Gets whether or not the parsed packet contains an IcmpV4 header.
        /// </summary>
        public bool IsIcmpV4
        {
            get
            {
                return _picmp4Header != null;
            }
        }

        /// <summary>
        /// Gets whether or not the parsed packet contains an IcmpV6 header.
        /// </summary>
        public bool IsIcmpV6
        {
            get
            {
                return _picmp6Header != null;
            }
        }

        /// <summary>
        /// Gets whether or not the parsed packet contains a Tcp header.
        /// </summary>
        public bool IsTcp
        {
            get
            {
                return _ptcpHdr != null;
            }
        }

        /// <summary>
        /// Gets whether or not the parsed packet contains a Udp header.
        /// </summary>
        public bool IsUdp
        {
            get
            {
                return _pudpHdr != null;
            }
        }

        /// <summary>
        /// Gets the parsed IPv4 header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso cref="IsIPv4" /> is true before attempting access.
        /// </remarks>
        /// <exception cref="NullReferenceException">
        /// If <see cref="IsIPv4" /> is false, calling this property will throw.
        /// </exception>
        public ref IPv4Header IPv4Header
        {
            get
            {
                return ref Unsafe.AsRef<IPv4Header>(_pip4Header);
            }
        }

        /// <summary>
        /// Gets the parsed IPv6 header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso cref="IsIPv6" /> is true before attempting access.
        /// </remarks>
        /// <exception cref="NullReferenceException">
        /// If <see cref="IsIPv6" /> is false, calling this property will throw.
        /// </exception>
        public ref IPv6Header IPv6Header
        {
            get
            {
                return ref Unsafe.AsRef<IPv6Header>(_pip6Header);
            }
        }

        /// <summary>
        /// Gets the parsed IcmpV4 header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso cref="IsIcmpV4" /> is true before attempting access.
        /// </remarks>
        /// <exception cref="NullReferenceException">
        /// If <see cref="IsIcmpV4" /> is false, calling this property will throw.
        /// </exception>
        public ref IcmpV4Header IcmpV4Header
        {
            get
            {
                return ref Unsafe.AsRef<IcmpV4Header>(_picmp4Header);
            }
        }

        /// <summary>
        /// Gets the parsed IcmpV6 header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso cref="IsIcmpV6" /> is true before attempting access.
        /// </remarks>
        /// <exception cref="NullReferenceException">
        /// If <see cref="IsIcmpV6" /> is false, calling this property will throw.
        /// </exception>
        public ref IcmpV6Header IcmpV6Header
        {
            get
            {
                return ref Unsafe.AsRef<IcmpV6Header>(_picmp6Header);
            }
        }

        /// <summary>
        /// Gets the parsed Tcp header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso cref="IsTcp" /> is true before attempting access.
        /// </remarks>
        /// <exception cref="NullReferenceException">
        /// If <see cref="IsTcp" /> is false, calling this property will throw.
        /// </exception>
        public ref TcpHeader TcpHeader
        {
            get
            {
                return ref Unsafe.AsRef<TcpHeader>(_ptcpHdr);
            }
        }

        /// <summary>
        /// Gets the parsed Udp header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso cref="IsUdp" /> is true before attempting access.
        /// </remarks>
        /// <exception cref="NullReferenceException">
        /// If <see cref="IsUdp" /> is false, calling this property will throw.
        /// </exception>
        public ref UdpHeader UdpHeader
        {
            get
            {
                return ref Unsafe.AsRef<UdpHeader>(_pudpHdr);
            }
        }

        /// <summary>
        /// Gets the parsed packet payload, if any.
        /// </summary>
        public Span<byte> PacketPayload
        {
            get
            {
                return new Span<byte>(_pdataPtr, (int)_dataLen);
            }
        }
    }
}