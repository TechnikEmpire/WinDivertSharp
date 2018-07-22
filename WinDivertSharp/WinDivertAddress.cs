/*
 * WinDivertAddress.cs
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

using System.Runtime.InteropServices;

namespace WinDivertSharp
{
    /// <summary>
    /// The WinDivertAddress structure represents the "address" of a captured or injected packet. The
    /// address includes the packet's timestamp, network interfaces, direction and other information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WinDivertAddress
    {
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <remarks>
        /// The Timestamp indicates when the packet was first captured by WinDivert. It uses the same
        /// clock as QueryPerformanceCounter(). The Timestamp value is ignored by <seealso cref="WinDivert.WinDivertSend(System.IntPtr, WinDivertBuffer, uint, ref WinDivertAddress)" />.
        /// </remarks>
        public long Timestamp;

        /// <summary>
        /// Gets or sets the interface index.
        /// </summary>
        /// <remarks>
        /// Ignored for outbound packets
        /// </remarks>
        public uint IfIdx;

        /// <summary>
        /// Gets or sets the sub-interface index.
        /// </summary>
        /// <remarks>
        /// Ignored for outbound packets
        /// </remarks>
        public uint SubIfIdx;

        /// Direction : 1 
        /// Loopback : 1 
        /// Impostor : 1 
        /// PseudoIPChecksum : 1 
        /// PseudoTCPChecksum : 1
        /// PseudoUDPChecksum : 1 
        /// Reserved : 2
        private byte bitvector1;

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <remarks>
        /// The Direction field is set to Outbound (0) for outbound packets, and Inbound (1) for
        /// inbound packets. This field is ignored for forward packets.
        /// </remarks>
        public WinDivertDirection Direction
        {
            get
            {
                return (WinDivertDirection)((byte)((this.bitvector1 & 1u)));
            }
            set
            {
                this.bitvector1 = ((byte)(((byte)value | this.bitvector1)));
            }
        }

        /// <summary>
        /// Gets or sets whether or not the loopback flag is set.
        /// </summary>
        /// <remarks>
        /// The Loopback flag is set for loopback packets. Note that Windows considers any packet
        /// originating from, and destined to, the current machine to be a loopback packet, so
        /// loopback packets are not limited to localhost addresses. Note that WinDivert considers
        /// loopback packets to be outbound only, and will not capture loopback packets on the
        /// inbound path.
        /// </remarks>
        public bool Loopback
        {
            get
            {
                return ((byte)(((this.bitvector1 & 2u)
                            / 2))) == 1;
            }
            set
            {
                this.bitvector1 = ((byte)((((value ? 1U : 0U) * 2)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Gets or sets the imposter flag.
        /// </summary>
        /// <remarks>
        /// The Impostor flag is set for impostor packets. An impostor packet is any packet injected
        /// by another driver rather than originating from the network or Windows TCP/IP stack.
        /// Impostor packets are problematic since they can cause infinite loops, where a packet
        /// injected by
        /// <seealso cref="WinDivert.WinDivertSend(System.IntPtr, WinDivertBuffer, uint, ref WinDivertAddress)" />
        /// is captured again by
        /// <seealso cref="WinDivert.WinDivertRecv(System.IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />.
        /// For more information, see <seealso cref="WinDivert.WinDivertSend(System.IntPtr, WinDivertBuffer, uint, ref WinDivertAddress)" />.
        /// </remarks>
        public bool Impostor
        {
            get
            {
                return ((byte)(((this.bitvector1 & 4u)
                            / 4))) == 1;
            }
            set
            {
                this.bitvector1 = ((byte)((((value ? 1U : 0U) * 4)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Gets or sets whether or not the packet uses pseudo IP checksums.
        /// </summary>
        public bool PseudoIPChecksum
        {
            get
            {
                return ((byte)(((this.bitvector1 & 8u)
                            / 8))) == 1;
            }
            set
            {
                this.bitvector1 = ((byte)((((value ? 1U : 0U) * 8)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Gets or sets whether or not the packet uses pseudo TCP checksums.
        /// </summary>
        public bool PseudoTCPChecksum
        {
            get
            {
                return ((byte)(((this.bitvector1 & 16u)
                            / 16))) == 1;
            }
            set
            {
                this.bitvector1 = ((byte)((((value ? 1U : 0U) * 16)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Gets or sets whether or not the packet uses pseudo UDP checksums.
        /// </summary>
        public bool PseudoUDPChecksum
        {
            get
            {
                return ((byte)(((this.bitvector1 & 32u)
                            / 32))) == 1;
            }
            set
            {
                this.bitvector1 = ((byte)((((value ? 1U : 0U) * 32)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Gets or sets the reserved bit(s).
        /// </summary>
        public uint Reserved
        {
            get
            {
                return ((byte)(((this.bitvector1 & 192u)
                            / 64)));
            }
            set
            {
                this.bitvector1 = ((byte)(((value * 64)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Resets the structure.
        /// </summary>
        public void Reset()
        {
            this.Timestamp = 0;
            this.IfIdx = 0;
            this.SubIfIdx = 0;
            this.bitvector1 = 0;
        }
    }
}