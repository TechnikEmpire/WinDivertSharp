/*
 * WinDivertHelperParam.cs
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

namespace WinDivertSharp
{
    /// <summary>
    /// WinDivert checksum helper flags.
    /// </summary>
    [Flags]
    public enum WinDivertChecksumHelperParam : ulong
    {
        /// <summary>
        /// Performs a full checksum calculation on the packet.
        /// </summary>
        All = 0,

        /// <summary>
        /// Skips IPv4 checksum calculations.
        /// </summary>
        NoIpChecksum = 1,

        /// <summary>
        /// Skips Icmp V4 checksum calculations.
        /// </summary>
        NoIcmpChecksum = 2,

        /// <summary>
        /// Skips Icmp V6 checksum calculations.
        /// </summary>
        NoIcmpV6Checksum = 4,

        /// <summary>
        /// Skips Tcp checksum calculations.
        /// </summary>
        NoTcpChecksum = 8,

        /// <summary>
        /// Skips Udp checksum calculations.
        /// </summary>
        NoUdpChecksum = 16
    }
}