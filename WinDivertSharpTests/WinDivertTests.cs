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

using NUnit.Framework;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using WinDivertSharp;
using WinDivertSharp.WinAPI;

namespace WinDivertSharpTests
{
    [TestFixture]
    public unsafe class WinDivertTests
    {
        private static TestData s_testData;

        [OneTimeSetUp]
        public void Init()
        {
            // Let existing packets flush.
            Task.Delay(100).Wait();

            s_testData = new TestData();
        }

        [OneTimeTearDown]
        public void DeInit()
        {
            s_testData.Dispose();
        }

        [Test]
        public void TestFilterMatch1()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "outbound and icmp", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch2()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "outbound", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch3()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "outbound and inbound", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch4()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "loopback", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch5()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "impostor", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch6()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmp", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch7()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "not icmp", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch8()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ip or ipv6", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch9()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "inbound", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch10()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch11()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmp.Type == 8", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch12()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmp.Type == 9", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch13()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(tcp? ip.Checksum == 0: icmp)", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch14()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(udp? icmp: icmp.Body == 5555)", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch15()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(false? false: false)", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch16()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(true? true: true)", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch17()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(tcp or udp or icmpv6 or ipv6? true: false)",
             TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch18()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(ip and ipv6 and tcp and udp? false: icmp > 0)",
             TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch19()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(tcp? tcp.DstPort == 80: true) and (udp? udp.DstPort == 80: true)",
             TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch20()
        {
            // Tests max filter length.

            ProcessTest(s_testData.UpperWinDivertHandle,
                    @"ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip and ip and ip and
                    ip and ip and ip", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch21()
        {
            // All fields:
            ProcessTest(s_testData.UpperWinDivertHandle, @"not true or false or not icmp or
                icmp.Body == 33 or icmp.Checksum==2 or
                icmp.Code == 0x777 or
                icmp.Type == 0x333 or icmpv6 or
                icmpv6.Body or icmpv6.Checksum or
                icmpv6.Code or icmpv6.Type or
                ifIdx == 93923 or inbound or
                not ip or ip.Checksum == 8 or
                not ip.DF or ip.DstAddr == 1.2.3.4 or
                ip.FragOff == 4212 or
                ip.HdrLength == 2 or ip.Id = 0x0987 or
                ip.Length == 788 or ip.MF == 1 or
                ip.Protocol == 999 or
                ip.SrcAddr == 9.8.7.255 or
                ip.TOS == 3 or ip.TTL = 221 or ipv6 or
                ipv6.DstAddr or ipv6.FlowLabel or
                ipv6.HopLimit or ipv6.Length or
                ipv6.NextHdr or ipv6.SrcAddr or
                ipv6.TrafficClass or not outbound or
                subIfIdx == 888 or tcp or tcp.Ack or
                tcp.AckNum or tcp.Checksum or
                tcp.DstPort or tcp.Fin or
                tcp.HdrLength or tcp.PayloadLength or
                tcp.Psh or tcp.Rst or tcp.SeqNum or
                tcp.SrcPort or tcp.Syn or tcp.Urg or
                tcp.UrgPtr or tcp.Window or udp or
                udp.Checksum or udp.DstPort or
                udp.Length or udp.PayloadLength or
                udp.SrcPort", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch22()
        {
            // Deep nesting:

            ProcessTest(s_testData.UpperWinDivertHandle,
                    @"(true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (true and (true and (true and (true and
                    (((((((((((((((icmp)))))))))))))))))))
                    ))))))))))))))))))))))))))))))))))))))
                    ))))))))))))))))))))))))))))))))))))))", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch23()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "not not not not not not not not icmp", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch24()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "not not not not not not not icmp", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch25()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "!!!!!!!icmp", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch26()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "false and true or true", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch27()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "true and false or false", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch28()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "true or true and false", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch29()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "false or false and true", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch30()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp && icmp || ip", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch31()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmp && udp || tcp", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch32()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ip || icmp && icmpv6", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch33()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "!ip || !icmp && !udp", TestData.EchoRequestData, false);
        }

        [Test]
        public void TestFilterMatch34()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, @"(((icmp)? (true): (false)) and (((tcp)? (false): (true)) and ((ipv6)? (false): (true))))", TestData.EchoRequestData, true);
        }

        [Test]
        public void TestFilterMatch35()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp", TestData.HttpRequestData, true);
        }

        [Test]
        public void TestFilterMatch36()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "outbound and tcp and tcp.DstPort == 80", TestData.HttpRequestData, true);
        }

        [Test]
        public void TestFilterMatch37()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "outbound and tcp and tcp.DstPort == 81", TestData.HttpRequestData, false);
        }

        [Test]
        public void TestFilterMatch38()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "outbound and tcp and tcp.DstPort != 80", TestData.HttpRequestData, false);
        }

        [Test]
        public void TestFilterMatch39()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "inbound and tcp and tcp.DstPort == 80", TestData.HttpRequestData, false);
        }

        [Test]
        public void TestFilterMatch40()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.PayloadLength == 469", TestData.HttpRequestData, true);
        }

        [Test]
        public void TestFilterMatch41()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.PayloadLength != 469", TestData.HttpRequestData, false);
        }

        [Test]
        public void TestFilterMatch42()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.PayloadLength >= 469", TestData.HttpRequestData, true);
        }

        [Test]
        public void TestFilterMatch43x()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.PayloadLength <= 469", TestData.HttpRequestData, true);
        }

        [Test]
        public void TestFilterMatch44()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.PayloadLength > 469", TestData.HttpRequestData, false);
        }

        [Test]
        public void TestFilterMatch45()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.PayloadLength < 469", TestData.HttpRequestData, false);
        }

        [Test]
        public void TestFilterMatch46()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(outbound? (ip? (tcp.DstPort == 80? (tcp.PayloadLength > 0? true: false): false): false): false)", TestData.HttpRequestData, true);
        }

        [Test]
        public void TestFilterMatch47()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(outbound? (ip? (tcp.DstPort == 80? (tcp.PayloadLength == 0? true: false): false): false): false)", TestData.HttpRequestData, false);
        }

        [Test]
        public void TestFilterMatch48()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "udp", TestData.DnsRequestData, true);
        }

        [Test]
        public void TestFilterMatch49()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "udp && udp.SrcPort > 1 && ipv6", TestData.DnsRequestData, false);
        }

        [Test]
        public void TestFilterMatch50()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "udp.DstPort == 53", TestData.DnsRequestData, true);
        }

        [Test]
        public void TestFilterMatch51()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "udp.DstPort > 100", TestData.DnsRequestData, false);
        }

        [Test]
        public void TestFilterMatch52()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ip.DstAddr = 8.8.4.4", TestData.DnsRequestData, true);
        }

        [Test]
        public void TestFilterMatch53()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ip.DstAddr = 8.8.8.8", TestData.DnsRequestData, false);
        }

        [Test]
        public void TestFilterMatch54()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ip.DstAddr >= 8.8.0.0 && ip.DstAddr <= 8.8.255.255", TestData.DnsRequestData, true);
        }

        [Test]
        public void TestFilterMatch55()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ip.SrcAddr >= 10.0.0.0 && ip.SrcAddr <= 10.255.255.255", TestData.DnsRequestData, true);
        }

        [Test]
        public void TestFilterMatch56()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ip.SrcAddr < 10.0.0.0 or ip.SrcAddr > 10.255.255.255", TestData.DnsRequestData, false);
        }

        [Test]
        public void TestFilterMatch57()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "udp.PayloadLength == 29", TestData.DnsRequestData, true);
        }

        [Test]
        public void TestFilterMatch58()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch59()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ip", TestData.Ipv6TcpSynData, false);
        }

        [Test]
        public void TestFilterMatch60()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.Syn", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch61()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.Syn == 1 && tcp.Ack == 0", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch62()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.Rst or tcp.Fin", TestData.Ipv6TcpSynData, false);
        }

        [Test]
        public void TestFilterMatch63()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(tcp.Syn? !tcp.Rst && !tcp.Fin: true)", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch64()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "(tcp.Rst? !tcp.Syn: (tcp.Fin? !tcp.Syn: tcp.Syn))", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch65()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.PayloadLength == 0", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch66()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr == 1234:5678:1::aabb:ccdd", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch67()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr == aabb:5678:1::1234:ccdd", TestData.Ipv6TcpSynData, false);
        }

        [Test]
        public void TestFilterMatch68()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.SrcPort == 50046", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch69()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp.SrcPort == 0x0000C37E", TestData.Ipv6TcpSynData, true);
        }

        [Test]
        public void TestFilterMatch70()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmpv6", TestData.Ipv6EchoReplyData, true);
        }

        [Test]
        public void TestFilterMatch71()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmp", TestData.Ipv6EchoReplyData, false);
        }

        [Test]
        public void TestFilterMatch72()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmp or icmpv6", TestData.Ipv6EchoReplyData, true);
        }

        [Test]
        public void TestFilterMatch73()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "not icmp", TestData.Ipv6EchoReplyData, true);
        }

        [Test]
        public void TestFilterMatch74()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmpv6.Type == 129", TestData.Ipv6EchoReplyData, true);
        }

        [Test]
        public void TestFilterMatch75()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmpv6.Code == 0", TestData.Ipv6EchoReplyData, true);
        }

        [Test]
        public void TestFilterMatch76()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "icmpv6.Body == 0x10720003", TestData.Ipv6EchoReplyData, true);
        }

        [Test]
        public void TestFilterMatch77()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.DstAddr >= 1000", TestData.Ipv6EchoReplyData, false);
        }

        [Test]
        public void TestFilterMatch78()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.DstAddr <= 1", TestData.Ipv6EchoReplyData, true);
        }

        [Test]
        public void TestFilterMatch79()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "true", TestData.Ipv6ExtHdrsUdpData, true);
        }

        [Test]
        public void TestFilterMatch80()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "false", TestData.Ipv6ExtHdrsUdpData, false);
        }

        [Test]
        public void TestFilterMatch81()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "udp", TestData.Ipv6ExtHdrsUdpData, true);
        }

        [Test]
        public void TestFilterMatch82()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "tcp", TestData.Ipv6ExtHdrsUdpData, false);
        }

        [Test]
        public void TestFilterMatch83()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr == ::1", TestData.Ipv6ExtHdrsUdpData, true);
        }

        [Test]
        public void TestFilterMatch84()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr == ::2", TestData.Ipv6ExtHdrsUdpData, false);
        }

        [Test]
        public void TestFilterMatch85()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr < abcd::1", TestData.Ipv6ExtHdrsUdpData, true);
        }

        [Test]
        public void TestFilterMatch86()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr <= abcd::1", TestData.Ipv6ExtHdrsUdpData, true);
        }

        [Test]
        public void TestFilterMatch87()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr != abcd::1", TestData.Ipv6ExtHdrsUdpData, true);
        }

        [Test]
        public void TestFilterMatch88()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr >= abcd::1", TestData.Ipv6ExtHdrsUdpData, false);
        }

        [Test]
        public void TestFilterMatch89()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "ipv6.SrcAddr > abcd::1", TestData.Ipv6ExtHdrsUdpData, false);
        }

        [Test]
        public void TestFilterMatch90()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "udp.SrcPort == 4660 and udp.DstPort == 43690",
             TestData.Ipv6ExtHdrsUdpData, true);
        }

        [Test]
        public void TestFilterMatch91()
        {
            ProcessTest(s_testData.UpperWinDivertHandle, "udp.SrcPort == 4660 and udp.DstPort == 12345",
             TestData.Ipv6ExtHdrsUdpData, false);
        }

        [Test]
        public void TestFilterMatch92()
        {
            ProcessTest(s_testData.UpperWinDivertHandle,
                    @"(outbound and tcp? tcp.DstPort == 0xABAB: false) or
                    (outbound and udp? udp.DstPort == 0xAAAA: false) or
                    (inbound and tcp? tcp.SrcPort == 0xABAB: false) or
                    (inbound and udp? udp.SrcPort == 0xAAAA: false)",
                TestData.Ipv6ExtHdrsUdpData, true);
        }

        [Test]
        public void TestFilterMatch93()
        {
            var addr = new WinDivertAddress();

            Assert.AreEqual(addr.Direction, WinDivertDirection.Outbound, "Default direction of the Address structure should be outbound");
            addr.Direction = WinDivertDirection.Inbound;
            Assert.AreEqual(addr.Direction, WinDivertDirection.Inbound, "Direction of the Address structure should be inbound.");
            addr.Direction = WinDivertDirection.Outbound;
            Assert.AreEqual(addr.Direction, WinDivertDirection.Outbound, "Direction of the Address structure should be outbound.");
        }

        [Test]
        public void TestFilterMatch94()
        {
            var tcpPacket = PacketDotNet.TcpPacket.RandomPacket();
            var ipPacket = (PacketDotNet.IPv4Packet)PacketDotNet.IPPacket.RandomPacket(PacketDotNet.IPVersion.IPv4);
            //var ethernetPacket = PacketDotNet.EthernetPacket.RandomPacket();

            // put these all together into a single packet
            ipPacket.PayloadPacket = tcpPacket;
            //ethernetPacket.PayloadPacket = ipPacket;

            // and get a byte array that represents the single packet
            var bytes = ipPacket.Bytes;

            var winDivertBuffer = new WinDivertBuffer(bytes);

            var result = WinDivert.WinDivertHelperParsePacket(winDivertBuffer, winDivertBuffer.Length);

            Assert.AreNotEqual(result.IPv4Header != null, false, "IPv4 header should not be null.");
            Assert.AreNotEqual(result.TcpHeader != null, false, "Tcp header should not be null.");

            //pdmIpv4.UpdateCalculatedValues();
            //pdmIpv4.CalculateIPChecksum();

            //pdmTcp.UpdateCalculatedValues();

            Assert.AreEqual(ipPacket.SourceAddress, result.IPv4Header->SrcAddr, "Source IP addresses do not match.");
            Assert.AreEqual(ipPacket.DestinationAddress, result.IPv4Header->DstAddr, "Destination IP addresses do not match.");

            Assert.AreEqual(tcpPacket.Checksum, result.TcpHeader->Checksum, "Checksums do not match.");
            Assert.AreEqual(ipPacket.Checksum, result.TcpHeader->Checksum, "Checksums do not match.");

            Assert.AreEqual(tcpPacket.Checksum, 0, "Checksums do not match.");
            Assert.AreEqual(result.TcpHeader->Checksum, 0, "Checksums do not match.");

            

            tcpPacket.CalculateTCPChecksum();
            tcpPacket.UpdateCalculatedValues();
            tcpPacket.UpdateTCPChecksum();
            
            ipPacket.CalculateIPChecksum();
            ipPacket.UpdateCalculatedValues();
            ipPacket.UpdateIPChecksum();

            WinDivert.WinDivertHelperCalcChecksums(winDivertBuffer, winDivertBuffer.Length, WinDivertChecksumHelperParam.All);

            //Assert.AreEqual(tcpPacket.Checksum, result.TcpHeader.Checksum, "Checksums do not match.");
            
            Assert.AreEqual(ipPacket.Checksum, (ushort)IPAddress.NetworkToHostOrder((short)result.IPv4Header->Checksum), "Checksums do not match.");
            Assert.AreEqual(tcpPacket.Checksum, (ushort)IPAddress.NetworkToHostOrder((short)result.TcpHeader->Checksum), "Checksums do not match.");

            ipPacket.SourceAddress = IPAddress.Parse("8.8.8.8");
            result.IPv4Header->SrcAddr = IPAddress.Parse("8.8.8.8");

            result.TcpHeader->SrcPort = (ushort)IPAddress.NetworkToHostOrder((short)8888);
            tcpPacket.SourcePort = 8888;

            tcpPacket.CalculateTCPChecksum();
            tcpPacket.UpdateCalculatedValues();
            tcpPacket.UpdateTCPChecksum();

            ipPacket.CalculateIPChecksum();
            ipPacket.UpdateCalculatedValues();
            ipPacket.UpdateIPChecksum();

            WinDivert.WinDivertHelperCalcChecksums(winDivertBuffer, winDivertBuffer.Length, WinDivertChecksumHelperParam.All);

            //Assert.AreEqual(tcpPacket.Checksum, result.TcpHeader.Checksum, "Checksums do not match.");

            Assert.AreEqual(ipPacket.Checksum, (ushort)IPAddress.NetworkToHostOrder((short)result.IPv4Header->Checksum), "Checksums do not match.");
            Assert.AreEqual(tcpPacket.Checksum, (ushort)IPAddress.NetworkToHostOrder((short)result.TcpHeader->Checksum), "Checksums do not match.");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ProcessTest(IntPtr injectHandle, string filter, WinDivertBuffer packet, bool shouldMatch)
        {
            // Ensure the correct checksum:
            WinDivert.WinDivertHelperCalcChecksums(packet, packet.Length, WinDivertChecksumHelperParam.All);

            var buf = new WinDivertBuffer();
            NativeOverlapped overlapped = new NativeOverlapped();

            uint iolen = 0, errorPos = 0;

            IntPtr handle = IntPtr.Zero;
            IntPtr handle0 = IntPtr.Zero;
            IntPtr evt = IntPtr.Zero;

            try
            {
                // Verify the test data.
                if (!WinDivert.WinDivertHelperCheckFilter(filter, WinDivertLayer.Network, out string errorMessage, ref errorPos))
                {
                    Assert.Fail("Filter string is invalid at position {0}.\nError Message:\n{1}", errorPos, errorMessage);
                }

                WinDivertAddress addr = new WinDivertAddress();
                addr.Reset();
                addr.Direction = WinDivertDirection.Outbound;

                // Test the filter string.
                if (WinDivert.WinDivertHelperEvalFilter(filter, WinDivertLayer.Network, packet, packet.Length, ref addr) != shouldMatch)
                {
                    Assert.Fail("Filter doesn't match the given packet.\nFilter:\n{0}", filter);
                }
                handle = WinDivert.WinDivertOpen(filter, WinDivertLayer.Network, 0, WinDivertOpenFlags.None);

                // Open a WinDivert handle for the given filter.
                Assert.AreNotEqual(handle, IntPtr.Zero, "Failed to open WinDivert handle for filter:\n{0}", filter);

                if (!shouldMatch)
                {
                    // Catch non-matching packets:
                    handle0 = handle;
                    handle = WinDivert.WinDivertOpen("true", WinDivertLayer.Network, 33, 0);
                    Assert.AreNotEqual(handle, IntPtr.Zero, "Failed to open WinDivert handle with Win32 error {0}.", Marshal.GetLastWin32Error());
                }
                // Inject the packet.
                if (!WinDivert.WinDivertSend(injectHandle, packet, packet.Length, ref addr))
                {
                    Assert.Fail("Failed to inject test packet with Win32 error {0}.", Marshal.GetLastWin32Error());

                    // Wait for the packet to arrive.
                    // NOTE: This may fail, so set a generous time-out of 250ms.
                    overlapped = new NativeOverlapped();
                    evt = Kernel32.CreateEvent(IntPtr.Zero, false, false, IntPtr.Zero);

                    Assert.AreNotEqual(evt, IntPtr.Zero, "Failed to create event with Win32 error {0}.", Marshal.GetLastWin32Error());
                    Assert.AreNotEqual(evt, new IntPtr(-1), "Failed to create event with Win32 error {0}.", Marshal.GetLastWin32Error());

                    overlapped.EventHandle = evt;

                    //if (!WinDivert.WinDivertRecv(handle, buf, ref addr, ref iolen))
                    if (!WinDivert.WinDivertRecvEx(handle, buf, 0, ref addr, ref iolen, ref overlapped))
                    {
                        if (Marshal.GetLastWin32Error() != 997) // ERROR_IO_PENDING
                        {
                            Assert.Fail("Failed to read packet from WinDivert with Win32 error {0}.", Marshal.GetLastWin32Error());

                            switch (Kernel32.WaitForSingleObject(evt, 250))
                            {
                                case (uint)WaitForSingleObjectResult.WaitObject0:
                                    {
                                    }
                                    break;

                                case (uint)WaitForSingleObjectResult.WaitTimeout:
                                    {
                                        Assert.Fail("Failed to read packet from WinDivert by timeout with Win32 error {0}.", Marshal.GetLastWin32Error());
                                    }
                                    break;

                                default:
                                    {
                                        Assert.Fail("Failed to read packet from WinDivert with Win32 error {0}.", Marshal.GetLastWin32Error());
                                    }
                                    break;
                            }

                            if (!Kernel32.GetOverlappedResult(handle, ref overlapped, ref iolen, true))
                            {
                                Assert.Fail("Failed get overlapped result from WinDivert with Win32 error {0}.", Marshal.GetLastWin32Error());
                            }
                        }
                    }
                    if (addr.Direction == WinDivertDirection.Outbound)
                    {
                        WinDivert.WinDivertHelperCalcChecksums(buf, iolen, WinDivertChecksumHelperParam.All);
                    }
                    // Verify that the packet is the same as the origin.
                    if (iolen != packet.Length)
                    {
                        Assert.Fail("Packet length mismatch. Expected {0}, got {1}.", packet.Length, iolen);

                        for (int i = 0; i < iolen; ++i)
                        {
                            if (packet[i] != buf[i])
                            {
                                Assert.Fail("Packet data mismatch. Expected byte at index {0} to be {1}, instead the value was {2}.", i, packet[i].ToString("X2"), buf[i].ToString("X2"));
                            }
                        }
                    }

                    // (5) Clean-up:
                    if (!WinDivert.WinDivertClose(handle))
                    {   
                        Assert.Fail("Failed to close WinDivert handle with Win32 error {0}.", Marshal.GetLastWin32Error());
                    }

                    if (handle0 != IntPtr.Zero)
                    {
                        if (!WinDivert.WinDivertClose(handle0))
                        {
                            Assert.Fail("Failed to close WinDivert handle with Win32 error {0}.", Marshal.GetLastWin32Error());
                        }
                    }

                    Kernel32.CloseHandle(evt);
                }
            }
            finally
            {
                if (handle0 != IntPtr.Zero)
                {
                    WinDivert.WinDivertClose(handle0);
                }

                if (handle != IntPtr.Zero)
                {
                    WinDivert.WinDivertClose(handle);
                }

                if (evt != IntPtr.Zero)
                {
                    Kernel32.CloseHandle(evt);
                }

                buf.Dispose();
                buf = null;
            }
        }
    }
}