/*
 * WinDivertOpenFlags.cs
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
    /// Represents flags that specialize how a WinDivert handle is opened.
    /// </summary>
    [Flags]
    public enum WinDivertOpenFlags : ulong
    {
        /// <summary>
        /// No flags.
        /// </summary>
        None = 0,

        /// <summary>
        /// Open in packet sniffing mode.
        /// </summary>
        Sniff = 1,

        /// <summary>
        /// Open in packet dropping mode.
        /// </summary>
        /// <remarks>
        /// This mode causes captured packets to be dropped if not reinjected post-capture.
        /// </remarks>
        Drop = 2,

        /// <summary>
        /// Open in debug mode.
        /// </summary>
        /// <remarks>
        /// Causes the
        /// <seealso cref="WinDivert.WinDivertSend(IntPtr, WinDivertBuffer, uint, ref WinDivertAddress)" />
        /// method to block until the packet has left the network stack.
        /// </remarks>
        Debug = 4
    }
}