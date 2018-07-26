/*
 * WinDivert.cs
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
using System.Runtime.InteropServices;
using System.Threading;

namespace WinDivertSharp
{
    /// <summary>
    /// The static WinDivert class contains all free functions defined in the WinDivert library.
    /// </summary>
    public static unsafe class WinDivert
    {
        /// <summary>
        /// Opens a WinDivert handle for the given filter. Unless otherwise specified by flags, any
        /// packet that matches the filter will be diverted to the handle. Diverted packets can be
        /// read by the application with <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />
        /// </summary>
        /// <param name="filter">
        /// A packet filter string specified in the WinDivert filter language.
        /// </param>
        /// <param name="layer">
        /// The layer.
        /// </param>
        /// <param name="priority">
        /// The priority of the handle.
        /// </param>
        /// <param name="flags">
        /// Additional flags.
        /// </param>
        /// <returns>
        /// A valid WinDivert handle on success, or IntPtr.Zero if an error occurred. Use
        /// <see cref="Marshal.GetLastWin32Error" /> to get the reason for the error.
        /// </returns>
        /// <remarks>
        /// A typical application is only interested in a subset of all network traffic. In this case
        /// the filter should match as closely as possible to the subset of interest. This avoids
        /// unnecessary overheads introduced by diverting packets to the user-mode application. See
        /// the filter language section for more information. The layer of the WinDivert handle is
        /// determined by the layer parameter.
        /// </remarks>
        public static IntPtr WinDivertOpen(string filter, WinDivertLayer layer, short priority, WinDivertOpenFlags flags)
        {
            return WinDivertNative.WinDivertOpen(filter, layer, priority, (ulong)flags);
        }

        /// <summary>
        /// Receives a diverted packet that matched the filter passed to
        /// <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />. The
        /// received packet is guaranteed to match the filter.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />
        /// </param>
        /// <param name="packet">
        /// A buffer for the captured packet.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> of the captured packet.
        /// </param>
        /// <param name="readLen">
        /// The total number of bytes written to packet.
        /// </param>
        /// <returns>
        /// TRUE if a packet was successfully received, or FALSE if an error occurred. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason for the error.
        /// </returns>
        /// <remarks>
        /// The contents of the captured packet are written to packet. If the captured packet is
        /// larger than the packet buffer length, then the packet will be truncated. If recvLen is
        /// non-NULL, then the total number of bytes written to packet is placed there. If non-NULL,
        /// the address of the captured packet is written to pAddr.
        ///
        /// An application should call
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />
        /// as soon as possible after a successful call to WinDivertOpen(). When a WinDivert handle
        /// is open, any packet that matches the filter will be captured and queued until handled by
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />.
        /// Packets are not queued indefinitely, and if not handled in a timely manner, any captured
        /// packet may be dropped. The amount of time a packet is queued can be controlled with the
        /// <seealso cref="WinDivertSetParam(IntPtr, WinDivertParam, ulong)" /> function.
        ///
        /// Captured packets are guaranteed to have correct checksums, or pseudo checksums, as
        /// indicated by the Pseudo*Checksum flags from the WINDIVERT_ADDRESS.
        ///
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />
        /// should not be used on any WinDivert handle created with the
        /// <seealso cref="WinDivertOpenFlags.Drop" /> set.
        /// </remarks>
        public static bool WinDivertRecv(IntPtr handle, WinDivertBuffer packet, ref WinDivertAddress address, ref uint readLen)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                fixed (uint* pReadLen = &readLen)
                {
                    var result = WinDivertNative.WinDivertRecv(handle, packet.BufferPointer, (uint)packet.Length, ref address, ref readLen);
                    return result;
                }
            }
        }

        /// <summary>
        /// Receives a diverted packet that matched the filter passed to
        /// <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />. The
        /// received packet is guaranteed to match the filter.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />
        /// </param>
        /// <param name="packet">
        /// A buffer for the captured packet.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> of the captured packet.
        /// </param>
        /// <returns>
        /// TRUE if a packet was successfully received, or FALSE if an error occurred. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason for the error.
        /// </returns>
        /// <remarks>
        /// The contents of the captured packet are written to packet. If the captured packet is
        /// larger than the packet buffer length, then the packet will be truncated. If recvLen is
        /// non-NULL, then the total number of bytes written to packet is placed there. If non-NULL,
        /// the address of the captured packet is written to pAddr.
        ///
        /// An application should call
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />
        /// as soon as possible after a successful call to WinDivertOpen(). When a WinDivert handle
        /// is open, any packet that matches the filter will be captured and queued until handled by
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />.
        /// Packets are not queued indefinitely, and if not handled in a timely manner, any captured
        /// packet may be dropped. The amount of time a packet is queued can be controlled with the
        /// <seealso cref="WinDivertSetParam(IntPtr, WinDivertParam, ulong)" /> function.
        ///
        /// Captured packets are guaranteed to have correct checksums, or pseudo checksums, as
        /// indicated by the Pseudo*Checksum flags from the WINDIVERT_ADDRESS.
        ///
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />
        /// should not be used on any WinDivert handle created with the
        /// <seealso cref="WinDivertOpenFlags.Drop" /> set.
        /// </remarks>
        public static bool WinDivertRecv(IntPtr handle, WinDivertBuffer packet, ref WinDivertAddress address)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                uint readLen = 0;

                var result = WinDivertNative.WinDivertRecv(handle, packet.BufferPointer, (uint)packet.Length, ref address, ref readLen);
                return result;
            }
        }

        /// <summary>
        /// This function is equivalent to
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />
        /// except that it supports overlapped I/O via the lpOverlapped parameter.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />
        /// </param>
        /// <param name="packet">
        /// A buffer for the captured packet.
        /// </param>
        /// <param name="flags">
        /// Reserved, set to zero.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> of the captured packet.
        /// </param>
        /// <param name="readLen">
        /// The total number of bytes written to packet.
        /// </param>
        /// <param name="lpOverlapped">
        /// An optional <seealso cref="NativeOverlapped" /> instance.
        /// </param>
        /// <returns>
        /// TRUE if a packet was successfully received, or FALSE otherwise. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason. The error code
        /// ERROR_IO_PENDING indicates that the overlapped operation has been successfully initiated
        /// and that completion will be indicated at a later time. All other codes indicate an error.
        /// </returns>
        public static bool WinDivertRecvEx(IntPtr handle, WinDivertBuffer packet, uint flags, ref WinDivertAddress address, ref uint readLen, ref NativeOverlapped lpOverlapped)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                fixed (NativeOverlapped* pOverlapped = &lpOverlapped)
                {
                    fixed (uint* pReadLen = &readLen)
                    {
                        // Presently, flags is simply "reserved"
                        var result = WinDivertNative.WinDivertRecvEx(handle, packet.BufferPointer, (uint)packet.Length, 0, ref address, ref readLen, ref lpOverlapped);

                        return result;
                    }
                }
            }
        }

        /// <summary>
        /// This function is equivalent to
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress)" /> except
        /// that it supports overlapped I/O via the lpOverlapped parameter.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />
        /// </param>
        /// <param name="packet">
        /// A buffer for the captured packet.
        /// </param>
        /// <param name="flags">
        /// Reserved, set to zero.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> of the captured packet.
        /// </param>
        /// <param name="lpOverlapped">
        /// An optional <seealso cref="NativeOverlapped" /> instance.
        /// </param>
        /// <returns>
        /// TRUE if a packet was successfully received, or FALSE otherwise. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason. The error code
        /// ERROR_IO_PENDING indicates that the overlapped operation has been successfully initiated
        /// and that completion will be indicated at a later time. All other codes indicate an error.
        /// </returns>
        public static bool WinDivertRecvEx(IntPtr handle, WinDivertBuffer packet, uint flags, ref WinDivertAddress address, ref NativeOverlapped lpOverlapped)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                uint readLen = 0;

                // Presently, flags is simply "reserved"
                var result = WinDivertNative.WinDivertRecvEx(handle, packet.BufferPointer, (uint)packet.Length, 0, ref address, ref readLen, ref lpOverlapped);

                return result;
            }
        }

        /// <summary>
        /// Injects a packet into the network stack. The injected packet may be one received from
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />,
        /// or a modified version, or a completely new packet. Injected packets can be captured and
        /// diverted again by other WinDivert handles with lower priorities.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />.
        /// </param>
        /// <param name="packet">
        /// A buffer containing the packet to be injected.
        /// </param>
        /// <param name="packetLength">
        /// A buffer containing the packet to be injected.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> for the injected packet.
        /// </param>
        /// <returns>
        /// TRUE if a packet was successfully injected, or FALSE if an error occurred. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason for the error.
        /// </returns>
        public static bool WinDivertSend(IntPtr handle, WinDivertBuffer packet, uint packetLength, ref WinDivertAddress address)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                uint sendLen = 0;

                var result = WinDivertNative.WinDivertSend(handle, packet.BufferPointer, packetLength, ref address, ref sendLen);
                return result;
            }
        }

        /// <summary>
        /// Injects a packet into the network stack. The injected packet may be one received from
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />,
        /// or a modified version, or a completely new packet. Injected packets can be captured and
        /// diverted again by other WinDivert handles with lower priorities.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />.
        /// </param>
        /// <param name="packet">
        /// A buffer containing the packet to be injected.
        /// </param>
        /// <param name="packetLength">
        /// A buffer containing the packet to be injected.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> for the injected packet.
        /// </param>
        /// <param name="sendLen">
        /// The total number of bytes injected.
        /// </param>
        /// <returns>
        /// TRUE if a packet was successfully injected, or FALSE if an error occurred. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason for the error.
        /// </returns>
        public static bool WinDivertSend(IntPtr handle, WinDivertBuffer packet, uint packetLength, ref WinDivertAddress address, ref uint sendLen)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                fixed (uint* pWriteLen = &sendLen)
                {
                    var result = WinDivertNative.WinDivertSend(handle, packet.BufferPointer, packetLength, ref address, ref sendLen);
                    return result;
                }
            }
        }

        /// <summary>
        /// Injects a packet into the network stack. The injected packet may be one received from
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />,
        /// or a modified version, or a completely new packet. Injected packets can be captured and
        /// diverted again by other WinDivert handles with lower priorities.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />.
        /// </param>
        /// <param name="packet">
        /// A buffer containing the packet to be injected.
        /// </param>
        /// <param name="packetLength">
        /// A buffer containing the packet to be injected.
        /// </param>
        /// <param name="flags">
        /// Reserved, set to zero.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> for the injected packet.
        /// </param>
        /// <param name="sendLen">
        /// The total number of bytes injected.
        /// </param>
        /// <param name="lpOverlapped">
        /// An optional <seealso cref="NativeOverlapped" /> instance.
        /// </param>
        /// <returns>
        /// TRUE if a packet was successfully injected, or FALSE otherwise. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason. The error code
        /// ERROR_IO_PENDING indicates that the overlapped operation has been successfully initiated
        /// and that completion will be indicated at a later time. All other codes indicate an error.
        /// </returns>
        public static bool WinDivertSendEx(IntPtr handle, WinDivertBuffer packet, uint packetLength, ulong flags, ref WinDivertAddress address, ref uint sendLen, ref NativeOverlapped lpOverlapped)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                fixed (uint* pWriteLen = &sendLen)
                {
                    var result = WinDivertNative.WinDivertSendEx(handle, packet.BufferPointer, (uint)packetLength, flags, ref address, ref sendLen, ref lpOverlapped);

                    return result;
                }
            }
        }

        /// <summary>
        /// Injects a packet into the network stack. The injected packet may be one received from
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />,
        /// or a modified version, or a completely new packet. Injected packets can be captured and
        /// diverted again by other WinDivert handles with lower priorities.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />.
        /// </param>
        /// <param name="packet">
        /// A buffer containing the packet to be injected.
        /// </param>
        /// <param name="packetLength">
        /// A buffer containing the packet to be injected.
        /// </param>
        /// <param name="flags">
        /// Reserved, set to zero.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> for the injected packet.
        /// </param>
        /// <returns>
        /// TRUE if a packet was successfully injected, or FALSE otherwise. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason. The error code
        /// ERROR_IO_PENDING indicates that the overlapped operation has been successfully initiated
        /// and that completion will be indicated at a later time. All other codes indicate an error.
        /// </returns>
        public static bool WinDivertSendEx(IntPtr handle, WinDivertBuffer packet, uint packetLength, ulong flags, ref WinDivertAddress address)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                var result = WinDivertNative.WinDivertSendEx(handle, packet.BufferPointer, packetLength, flags, ref address, IntPtr.Zero, IntPtr.Zero);

                return result;
            }
        }

        /// <summary>
        /// Closes a WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />.
        /// </param>
        /// <returns>
        /// TRUE if successful, FALSE if an error occurred. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason for the error.
        /// </returns>
        public static bool WinDivertClose(IntPtr handle)
        {
            return WinDivertNative.WinDivertClose(handle);
        }

        /// <summary>
        /// Sets a WinDivert parameter.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />.
        /// </param>
        /// <param name="param">
        /// A <seealso cref="WinDivertParam" />.
        /// </param>
        /// <param name="value">
        /// The parameter's new value.
        /// </param>
        /// <returns>
        /// TRUE if successful, FALSE if an error occurred. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason for the error.
        /// </returns>
        public static bool WinDivertSetParam(IntPtr handle, WinDivertParam param, ulong value)
        {
            return WinDivertNative.WinDivertSetParam(handle, param, value);
        }

        /// <summary>
        /// Gets a WinDivert parameter.
        /// </summary>
        /// <param name="handle">
        /// A valid WinDivert handle created by <seealso cref="WinDivertOpen(string, WinDivertLayer, short, WinDivertOpenFlags)" />.
        /// </param>
        /// <param name="param">
        /// A <seealso cref="WinDivertParam" />.
        /// </param>
        /// <param name="value">
        /// The parameter's current value.
        /// </param>
        /// <returns>
        /// TRUE if successful, FALSE if an error occurred. Use
        /// <seealso cref="Marshal.GetLastWin32Error" /> to get the reason for the error.
        /// </returns>
        public static bool WinDivertGetParam(IntPtr handle, WinDivertParam param, out ulong value)
        {
            return WinDivertNative.WinDivertGetParam(handle, param, out value);
        }

        /// <summary>
        /// Parses a raw packet (e.g. from
        /// <seealso cref="WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />)
        /// into the various packet headers and/or payloads that may or may not be present.
        /// </summary>
        /// <param name="packet">
        /// The packet to be parsed.
        /// </param>
        /// <param name="packetDataLength">
        /// The total length of the packet pPacket.
        /// </param>
        /// <returns>
        /// TRUE if all expected (non-NULL) outputs were present, FALSE otherwise. Note that FALSE
        /// may sometimes be a legitimate return value, e.g., when both ppIpHdr and ppIpv6Hdr are non-NULL.
        /// </returns>
        /// <remarks>
        /// Each output parameter may be NULL or non-NULL. For non-NULL parameters, this function
        /// will write the pointer to the corresponding header/payload if it exists, or will write
        /// NULL otherwise. Any non-NULL pointer that is returned Is pointer into the original
        /// pPacket packet, and, there is enough space in pPacket to fit the header. This function
        /// does not do any verification of the header/payload contents beyond checking the header
        /// length and any other minimal information required for parsing.
        /// </remarks>
        public static WinDivertParseResult WinDivertHelperParsePacket(WinDivertBuffer packet, uint packetDataLength)
        {
            IPv4Header* _pip4Header = null;
            IPv6Header* _pip6Header = null;
            IcmpV4Header* _picmp4Header = null;
            IcmpV6Header* _picmp6Header = null;
            TcpHeader* _ptcpHdr = null;
            UdpHeader* _pudpHdr = null;

            byte* _pdataPtr;
            uint _dataLen = 0;

            var retVal = new WinDivertParseResult();

            WinDivertNative.WinDivertHelperParsePacket(packet.BufferPointer, packetDataLength, &_pip4Header, &_pip6Header, &_picmp4Header, &_picmp6Header, &_ptcpHdr, &_pudpHdr, &_pdataPtr, ref _dataLen);

            retVal._pip4Header = _pip4Header;
            retVal._pip6Header = _pip6Header;
            retVal._picmp4Header = _picmp4Header;
            retVal._picmp6Header = _picmp6Header;
            retVal._ptcpHdr = _ptcpHdr;
            retVal._pudpHdr = _pudpHdr;
            retVal._pdataPtr = _pdataPtr;
            retVal._dataLen = _dataLen;

            return retVal;
        }

        /// <summary>
        /// (Re)calculates the checksum for any IPv4/ICMP/ICMPv6/TCP/UDP checksum present in the
        /// given packet. Individual checksum calculations may be disabled via the appropriate flag.
        /// Typically this function should be invoked on a modified packet before it is injected with <seealso cref="WinDivertSend(IntPtr, WinDivertBuffer, uint, ref WinDivertAddress, ref uint)" />.
        /// </summary>
        /// <param name="packet">
        /// The packet to be modified.
        /// </param>
        /// <param name="packetLength">
        /// The total length of the packet pPacket.
        /// </param>
        /// <param name="address">
        /// A reference to a <seealso cref="WinDivertAddress" /> structure.
        /// </param>
        /// <param name="flags">
        /// One or more <seealso cref="WinDivertChecksumHelperParam" /> flags.
        /// </param>
        /// <returns>
        /// The number of checksums calculated.
        /// </returns>
        public static uint WinDivertHelperCalcChecksums(WinDivertBuffer packet, uint packetLength, ref WinDivertAddress address, WinDivertChecksumHelperParam flags)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                return WinDivertNative.WinDivertHelperCalcChecksums(packet.BufferPointer, packetLength, ref address, (ulong)flags);
            }
        }

        /// <summary>
        /// (Re)calculates the checksum for any IPv4/ICMP/ICMPv6/TCP/UDP checksum present in the
        /// given packet. Individual checksum calculations may be disabled via the appropriate flag.
        /// Typically this function should be invoked on a modified packet before it is injected with <seealso cref="WinDivertSend(IntPtr, WinDivertBuffer, uint, ref WinDivertAddress, ref uint)" />.
        /// </summary>
        /// <param name="packet">
        /// The packet to be modified.
        /// </param>
        /// <param name="packetLength">
        /// The total length of the packet pPacket.
        /// </param>
        /// <param name="flags">
        /// One or more <seealso cref="WinDivertChecksumHelperParam" /> flags.
        /// </param>
        /// <returns>
        /// The number of checksums calculated.
        /// </returns>
        public static uint WinDivertHelperCalcChecksums(WinDivertBuffer packet, uint packetLength, WinDivertChecksumHelperParam flags)
        {
            return WinDivertNative.WinDivertHelperCalcChecksums(packet.BufferPointer, packetLength, IntPtr.Zero, (ulong)flags);
            //fixed (byte* buff = packet._buffer)
            {
                //return WinDivertNative.WinDivertHelperCalcChecksums(buff, packetLength, IntPtr.Zero, (ulong)flags);
            }
        }

        /// <summary>
        /// Checks if the given packet filter string is valid with respect to the filter language. If
        /// the filter is invalid, then a human readable description of the error is returned by
        /// errorStr (if non-NULL), and the error's position is returned by errorPos (if non-NULL).
        /// </summary>
        /// <param name="filter">
        /// The packet filter string to be checked.
        /// </param>
        /// <param name="layer">
        /// The layer.
        /// </param>
        /// <param name="errorMessage">
        /// The error description.
        /// </param>
        /// <param name="errorPosition">
        /// The error position.
        /// </param>
        /// <returns>
        /// TRUE if the packet filter string is valid, FALSE otherwise.
        /// </returns>
        public static bool WinDivertHelperCheckFilter(string filter, WinDivertLayer layer, out string errorMessage, ref uint errorPosition)
        {
            errorMessage = null;
            errorPosition = 0;

            char* pErrorString = null;

            uint errPosTmp = 0;
            var retVal = WinDivertNative.WinDivertHelperCheckFilter(filter, layer, &pErrorString, ref errorPosition);
            if (pErrorString != null)
            {
                errorMessage = Marshal.PtrToStringAnsi((IntPtr)pErrorString);
                errorPosition = errPosTmp;
            }

            return retVal;
        }

        /// <summary>
        /// </summary>
        /// <param name="filter">
        /// The packet filter string to be evaluated.
        /// </param>
        /// <param name="layer">
        /// The layer.
        /// </param>
        /// <param name="packet">
        /// The packet.
        /// </param>
        /// <param name="packetLen">
        /// The total length of the packet.
        /// </param>
        /// <param name="address">
        /// The <seealso cref="WinDivertAddress" /> of the packet pPacket.
        /// </param>
        /// <returns>
        /// TRUE if the packet matches the filter string, FALSE otherwise.
        /// </returns>
        /// <remarks>
        /// Evaluates the given packet against the given packet filter string. This function returns
        /// TRUE if the packet matches, and returns FALSE otherwise.
        ///
        /// This function also returns FALSE if an error occurs, in which case
        /// <seealso cref="Marshal.GetLastWin32Error" /> can be used to get the reason for the
        /// error.Otherwise, if no error occurred, GetLastError() will return 0.
        ///
        /// Note that this function is relatively slow since the packet filter string will be (re)
        /// compiled for each call. This function is mainly intended for debugging or testing purposes.
        /// </remarks>
        public static bool WinDivertHelperEvalFilter(string filter, WinDivertLayer layer, WinDivertBuffer packet, uint packetLen, ref WinDivertAddress address)
        {
            fixed (WinDivertAddress* pAddress = &address)
            {
                var retVal = WinDivertNative.WinDivertHelperEvalFilter(filter, layer, packet.BufferPointer, packetLen, ref address);

                return retVal;
            }
        }
    }
}