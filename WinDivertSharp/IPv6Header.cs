/*
 * IPv6Header.cs
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
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;

namespace WinDivertSharp
{
    /// <summary>
    /// Represents an IPV6 header.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IPv6Header
    {
        /// TrafficClass0 : 4
        /// Version : 4
        /// FlowLabel0 : 4
        /// TrafficClass1 : 4
        private ushort bitvector1;

        /// <summary>
        /// Private member for <see cref="FlowLabel"/>
        /// </summary>
        private ushort FlowLabel1;

        /// <summary>
        /// Gets or sets the payload length.
        /// </summary>
        public ushort Length;

        /// <summary>
        /// Gets or sets the next header type.
        /// </summary>
        public byte NextHdr;

        /// <summary>
        /// Gets or sets the hop limit.
        /// </summary>
        public byte HopLimit;

        /// <summary>
        /// Private member for <see cref="SrcAddr"/>
        /// </summary>
        private uint _srcAddrA;
        private uint _srcAddrB;
        private uint _srcAddrC;
        private uint _srcAddrD;

        /// <summary>
        /// Gets or sets the source IP address.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// When setting, if the supplied address is a not a valid IPv6 address, the setter will throw.
        /// </exception>
        public IPAddress SrcAddr
        {
            get
            {
                var b1 = BitConverter.GetBytes(_srcAddrA);
                var b2 = BitConverter.GetBytes(_srcAddrB);
                var b3 = BitConverter.GetBytes(_srcAddrC);
                var b4 = BitConverter.GetBytes(_srcAddrD);
                var bytes = new byte[] {
                        b1[0], b1[1], b1[2], b1[3],
                        b2[0], b2[1], b2[2], b2[3],
                        b3[0], b3[1], b3[2], b3[3],
                        b4[0], b4[1], b4[2], b4[3]
                    };

                return new IPAddress(bytes);
            }

            set
            {
                var valueBytes = value.GetAddressBytes();

                Debug.Assert(valueBytes.Length == 16, "Not a valid IPV6 address.");

                if (valueBytes.Length != 16)
                {
                    throw new ArgumentException("Not a valid IPV6 address.", nameof(SrcAddr));
                }

                _srcAddrA = BitConverter.ToUInt32(valueBytes, 0);
                _srcAddrB = BitConverter.ToUInt32(valueBytes, 4);
                _srcAddrC = BitConverter.ToUInt32(valueBytes, 8);
                _srcAddrD = BitConverter.ToUInt32(valueBytes, 12);
            }
        }

        /// <summary>
        /// Private member for <see cref="DstAddr"/>
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        private uint _dstAddrA;
        private uint _dstAddrB;
        private uint _dstAddrC;
        private uint _dstAddrD;

        /// <summary>
        /// Gets or sets the destination IP address.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// When setting, if the supplied address is a not a valid IPv6 address, the setter will throw.
        /// </exception>
        public IPAddress DstAddr
        {
            get
            {
                var b1 = BitConverter.GetBytes(_dstAddrA);
                var b2 = BitConverter.GetBytes(_dstAddrB);
                var b3 = BitConverter.GetBytes(_dstAddrC);
                var b4 = BitConverter.GetBytes(_dstAddrD);
                var bytes = new byte[] {
                        b1[0], b1[1], b1[2], b1[3],
                        b2[0], b2[1], b2[2], b2[3],
                        b3[0], b3[1], b3[2], b3[3],
                        b4[0], b4[1], b4[2], b4[3]
                    };

                return new IPAddress(bytes);
            }

            set
            {
                var valueBytes = value.GetAddressBytes();

                Debug.Assert(valueBytes.Length == 16, "Not a valid IPV6 address.");

                if (valueBytes.Length != 16)
                {
                    throw new ArgumentException("Not a valid IPV6 address.", nameof(SrcAddr));
                }

                _dstAddrA = BitConverter.ToUInt32(valueBytes, 0);
                _dstAddrB = BitConverter.ToUInt32(valueBytes, 4);
                _dstAddrC = BitConverter.ToUInt32(valueBytes, 8);
                _dstAddrD = BitConverter.ToUInt32(valueBytes, 12);
            }
        }

        /// <summary>
        /// Private member for <see cref="TrafficClass"/>
        /// </summary>
        private uint TrafficClass0
        {
            get
            {
                return ((ushort)((this.bitvector1 & 15u)));
            }
            set
            {
                this.bitvector1 = ((ushort)((value | this.bitvector1)));
            }
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public uint Version
        {
            get
            {
                return ((ushort)(((this.bitvector1 & 240u)
                            / 16)));
            }
            set
            {
                this.bitvector1 = ((ushort)(((value * 16)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Another private member for <see cref="FlowLabel"/>
        /// </summary>
        private uint FlowLabel0
        {
            get
            {
                return ((ushort)(((this.bitvector1 & 3840u)
                            / 256)));
            }
            set
            {
                this.bitvector1 = ((ushort)(((value * 256)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Another private member for <see cref="TrafficClass"/>
        /// </summary>
        public uint TrafficClass1
        {
            get
            {
                return ((ushort)(((this.bitvector1 & 61440u)
                            / 4096)));
            }
            set
            {
                this.bitvector1 = ((ushort)(((value * 4096)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Gets or sets the traffic class value.
        /// </summary>
        public uint TrafficClass
        {
            get
            {
                return (byte)((this.TrafficClass0 << 4) | (byte)this.TrafficClass1);
            }

            set
            {
                this.TrafficClass0 = (byte)((value) >> 4);
                this.TrafficClass1 = value;
            }
        }

        /// <summary>
        /// Gets the flow label value.
        /// </summary>
        public uint FlowLabel
        {
            get
            {
                return (uint)((this.FlowLabel0 << 16) | this.FlowLabel1);
            }

            set
            {
                this.FlowLabel0 = (uint)(value >> 16);
                this.FlowLabel1 = (ushort)value;
            }
        }
    }
}