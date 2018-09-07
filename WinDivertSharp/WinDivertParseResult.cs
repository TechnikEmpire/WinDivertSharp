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
        /// Gets the parsed IPv4 header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso c="IsIPv4" /> is true before attempting access.
        /// </remarks>
        /// <exception c="NullerenceException">
        /// If <see c="IsIPv4" /> is false, calling this property will throw.
        /// </exception>
        public IPv4Header* IPv4Header
        {
            get
            {
                return _pip4Header;
            }
        }

        /// <summary>
        /// Gets the parsed IPv6 header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso c="IsIPv6" /> is true before attempting access.
        /// </remarks>
        /// <exception c="NullerenceException">
        /// If <see c="IsIPv6" /> is false, calling this property will throw.
        /// </exception>
        public IPv6Header* IPv6Header
        {
            get
            {
                return _pip6Header;
            }
        }

        /// <summary>
        /// Gets the parsed IcmpV4 header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso c="IsIcmpV4" /> is true before attempting access.
        /// </remarks>
        /// <exception c="NullerenceException">
        /// If <see c="IsIcmpV4" /> is false, calling this property will throw.
        /// </exception>
        public IcmpV4Header* IcmpV4Header
        {
            get
            {
                return _picmp4Header;
            }
        }

        /// <summary>
        /// Gets the parsed IcmpV6 header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso c="IsIcmpV6" /> is true before attempting access.
        /// </remarks>
        /// <exception c="NullerenceException">
        /// If <see c="IsIcmpV6" /> is false, calling this property will throw.
        /// </exception>
        public IcmpV6Header* IcmpV6Header
        {
            get
            {
                return _picmp6Header;
            }
        }

        /// <summary>
        /// Gets the parsed Tcp header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso c="IsTcp" /> is true before attempting access.
        /// </remarks>
        /// <exception c="NullerenceException">
        /// If <see c="IsTcp" /> is false, calling this property will throw.
        /// </exception>
        public TcpHeader* TcpHeader
        {
            get
            {
                return _ptcpHdr;
            }
        }

        /// <summary>
        /// Gets the parsed Udp header.
        /// </summary>
        /// <remarks>
        /// Ensure that <seealso c="IsUdp" /> is true before attempting access.
        /// </remarks>
        /// <exception c="NullerenceException">
        /// If <see c="IsUdp" /> is false, calling this property will throw.
        /// </exception>
        public UdpHeader* UdpHeader
        {
            get
            {
                return _pudpHdr;
            }
        }

        /// <summary>
        /// Gets the parsed packet payload, if any.
        /// </summary>
        public byte* PacketPayload
        {
            get
            {
                return _pdataPtr;
            }
        }

        /// <summary>
        /// Gets the packet payload length;
        /// </summary>
        public uint PacketPayloadLength
        {
            get
            {
                return _dataLen;
            }
        }
    }
}