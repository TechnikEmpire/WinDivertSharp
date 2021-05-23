/*
 * WinDivertParam.cs
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
    /// Generic configuration params for an opened WinDivert handle.
    /// </summary>
    [Flags]
    public enum WinDivertParam : uint
    {
        /// <summary>
        /// This option represents the maximum length of the packet queue for <seealso cref="WinDivert.WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />.
        /// </summary>
        /// <remarks>
        /// Currently the default value is 2048, the minimum is 16, and the maximum is 16384.
        /// </remarks>
        QueueLen = 0,

        /// <summary>
        /// This option represents the minimum time, in milliseconds, a packet can be queued before
        /// it is automatically dropped.
        /// </summary>
        /// <remarks>
        /// Packets cannot be queued indefinitely, and ideally, packets should be processed by the
        /// application as soon as is possible. Note that this sets the minimum time a packet can be
        /// queued before it can be dropped. The actual time may be exceed this value. Currently the
        /// default value is 1000 (1s), the minimum is 20 (20ms), and the maximum is 8000 (8s).
        /// </remarks>
        QueueTime = 1,

        /// <summary>
        /// This option represents the maximum number of bytes that can be stored in the packet queue
        /// for <seealso cref="WinDivert.WinDivertRecv(IntPtr, WinDivertBuffer, ref WinDivertAddress, ref uint)" />.
        /// </summary>
        /// <remarks>
        /// Currently the default value is 4194304 (4MB), the minimum is 65535 (64KB), and the
        /// maximum is 33554432 (32MB).
        /// </remarks>
        QueueSize = 2,
    }
}