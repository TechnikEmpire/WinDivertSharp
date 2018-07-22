/*
 * IcmpV6Header.cs
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
    /// Represents an IPv6 Icmp header.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IcmpV6Header
    {
        /// <summary>
        /// Gets or sets the ICMP type.
        /// </summary>
        public byte Type;

        /// <summary>
        /// Gets or sets the ICMP subtype.
        /// </summary>
        public byte Code;

        /// <summary>
        /// Gets or sets the checksum.
        /// </summary>
        public ushort Checksum;

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public uint Body;
    }
}