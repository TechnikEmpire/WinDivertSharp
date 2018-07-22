/*
* Copyright © 2018-Present Jesse Nicholson
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace WinDivertSharp
{
    /// <summary>
    /// An enum of known, registered protocols tracked by the IANA via RFC 790.
    /// </summary>
    public enum KnownProtocols : byte
    {
        ///<summary>
        /// IPv6 Hop-by-Hop Option
        ///</summary>
        ///<remarks>
        /// IPv6 Hop-by-Hop Option
        /// RFC 8200
        ///</remarks>
        HopOpt = 0x00,

        ///<summary>
        /// Internet Control Message Protocol
        ///</summary>
        ///<remarks>
        /// Internet Control Message Protocol
        /// RFC 792
        ///</remarks>
        Icmp = 0x01,

        ///<summary>
        /// Internet Group Management Protocol
        ///</summary>
        ///<remarks>
        /// Internet Group Management Protocol
        /// RFC 1112
        ///</remarks>
        Igmp = 0x02,

        ///<summary>
        /// Gateway-to-Gateway Protocol
        ///</summary>
        ///<remarks>
        /// Gateway-to-Gateway Protocol
        /// RFC 823
        ///</remarks>
        Ggp = 0x03,

        ///<summary>
        /// IP in IP (encapsulation)
        ///</summary>
        ///<remarks>
        /// IP in IP (encapsulation)
        /// RFC 2003
        ///</remarks>
        IpInIp = 0x04,

        ///<summary>
        /// Internet Stream Protocol
        ///</summary>
        ///<remarks>
        /// Internet Stream Protocol
        /// RFC 1190, RFC 1819
        ///</remarks>
        St = 0x05,

        ///<summary>
        /// Transmission Control Protocol
        ///</summary>
        ///<remarks>
        /// Transmission Control Protocol
        /// RFC 793
        ///</remarks>
        Tcp = 0x06,

        ///<summary>
        /// Core-based trees
        ///</summary>
        ///<remarks>
        /// Core-based trees
        /// RFC 2189
        ///</remarks>
        Cbt = 0x07,

        ///<summary>
        /// Exterior Gateway Protocol
        ///</summary>
        ///<remarks>
        /// Exterior Gateway Protocol
        /// RFC 888
        ///</remarks>
        Egp = 0x08,

        ///<summary>
        /// Interior Gateway Protocol (any private interior gateway (used by Cisco for their IGRP))
        ///</summary>
        ///<remarks>
        /// Interior Gateway Protocol (any private interior gateway (used by Cisco for their IGRP))
        ///</remarks>
        Igp = 0x09,

        ///<summary>
        /// BBN RCC Monitoring
        ///</summary>
        ///<remarks>
        /// BBN RCC Monitoring
        ///</remarks>
        BbnRccMon = 0x0A,

        ///<summary>
        /// Network Voice Protocol
        ///</summary>
        ///<remarks>
        /// Network Voice Protocol
        /// RFC 741
        ///</remarks>
        NvpIi = 0x0B,

        ///<summary>
        /// Xerox PUP
        ///</summary>
        ///<remarks>
        /// Xerox PUP
        ///</remarks>
        Pup = 0x0C,

        ///<summary>
        /// ARGUS
        ///</summary>
        ///<remarks>
        /// ARGUS
        ///</remarks>
        Argus = 0x0D,

        ///<summary>
        /// EMCON
        ///</summary>
        ///<remarks>
        /// EMCON
        ///</remarks>
        EmCon = 0x0E,

        ///<summary>
        /// Cross Net Debugger
        ///</summary>
        ///<remarks>
        /// Cross Net Debugger
        /// IEN 158
        ///</remarks>
        XNet = 0x0F,

        ///<summary>
        /// Chaos
        ///</summary>
        ///<remarks>
        /// Chaos
        ///</remarks>
        Chaos = 0x10,

        ///<summary>
        /// User Datagram Protocol
        ///</summary>
        ///<remarks>
        /// User Datagram Protocol
        /// RFC 768
        ///</remarks>
        Udp = 0x11,

        ///<summary>
        /// Multiplexing
        ///</summary>
        ///<remarks>
        /// Multiplexing
        /// IEN 90
        ///</remarks>
        Mux = 0x12,

        ///<summary>
        /// DCN Measurement Subsystems
        ///</summary>
        ///<remarks>
        /// DCN Measurement Subsystems
        ///</remarks>
        DcnMeas = 0x13,

        ///<summary>
        /// Host Monitoring Protocol
        ///</summary>
        ///<remarks>
        /// Host Monitoring Protocol
        /// RFC 869
        ///</remarks>
        Hmp = 0x14,

        ///<summary>
        /// Packet Radio Measurement
        ///</summary>
        ///<remarks>
        /// Packet Radio Measurement
        ///</remarks>
        Prm = 0x15,

        ///<summary>
        /// XEROX NS IDP
        ///</summary>
        ///<remarks>
        /// XEROX NS IDP
        ///</remarks>
        XnsIdp = 0x16,

        ///<summary>
        /// Trunk-1
        ///</summary>
        ///<remarks>
        /// Trunk-1
        ///</remarks>
        Trumk1 = 0x17,

        ///<summary>
        /// Trunk-2
        ///</summary>
        ///<remarks>
        /// Trunk-2
        ///</remarks>
        Trunk2 = 0x18,

        ///<summary>
        /// Leaf-1
        ///</summary>
        ///<remarks>
        /// Leaf-1
        ///</remarks>
        Leaf1 = 0x19,

        ///<summary>
        /// Leaf-2
        ///</summary>
        ///<remarks>
        /// Leaf-2
        ///</remarks>
        Leaf2 = 0x1A,

        ///<summary>
        /// Reliable Data Protocol
        ///</summary>
        ///<remarks>
        /// Reliable Data Protocol
        /// RFC 908
        ///</remarks>
        Rdp = 0x1B,

        ///<summary>
        /// Internet Reliable Transaction Protocol
        ///</summary>
        ///<remarks>
        /// Internet Reliable Transaction Protocol
        /// RFC 938
        ///</remarks>
        Irtp = 0x1C,

        ///<summary>
        /// ISO Transport Protocol Class 4
        ///</summary>
        ///<remarks>
        /// ISO Transport Protocol Class 4
        /// RFC 905
        ///</remarks>
        IsoTp4 = 0x1D,

        ///<summary>
        /// Bulk Data Transfer Protocol
        ///</summary>
        ///<remarks>
        /// Bulk Data Transfer Protocol
        /// RFC 998
        ///</remarks>
        NetBlt = 0x1E,

        ///<summary>
        /// MFE Network Services Protocol
        ///</summary>
        ///<remarks>
        /// MFE Network Services Protocol
        ///</remarks>
        MfeNsp = 0x1F,

        ///<summary>
        /// MERIT Internodal Protocol
        ///</summary>
        ///<remarks>
        /// MERIT Internodal Protocol
        ///</remarks>
        MeridInp = 0x20,

        ///<summary>
        /// Datagram Congestion Control Protocol
        ///</summary>
        ///<remarks>
        /// Datagram Congestion Control Protocol
        /// RFC 4340
        ///</remarks>
        Dccp = 0x21,

        ///<summary>
        /// Third Party Connect Protocol
        ///</summary>
        ///<remarks>
        /// Third Party Connect Protocol
        ///</remarks>
        ThirdPartyConnect = 0x22,

        ///<summary>
        /// Inter-Domain Policy Routing Protocol
        ///</summary>
        ///<remarks>
        /// Inter-Domain Policy Routing Protocol
        /// RFC 1479
        ///</remarks>
        Idpr = 0x23,

        ///<summary>
        /// Xpress Transport Protocol
        ///</summary>
        ///<remarks>
        /// Xpress Transport Protocol
        ///</remarks>
        Xtp = 0x24,

        ///<summary>
        /// Datagram Delivery Protocol
        ///</summary>
        ///<remarks>
        /// Datagram Delivery Protocol
        ///</remarks>
        Ddp = 0x25,

        ///<summary>
        /// IDPR Control Message Transport Protocol
        ///</summary>
        ///<remarks>
        /// IDPR Control Message Transport Protocol
        ///</remarks>
        IdprCmtp = 0x26,

        ///<summary>
        /// TP++ Transport Protocol
        ///</summary>
        ///<remarks>
        /// TP++ Transport Protocol
        ///</remarks>
        TpPlusPlus = 0x27,

        ///<summary>
        /// IL Transport Protocol
        ///</summary>
        ///<remarks>
        /// IL Transport Protocol
        ///</remarks>
        Il = 0x28,

        ///<summary>
        /// IPv6 Encapsulation
        ///</summary>
        ///<remarks>
        /// IPv6 Encapsulation
        /// RFC 2473
        ///</remarks>
        IPv6 = 0x29,

        ///<summary>
        /// Source Demand Routing Protocol
        ///</summary>
        ///<remarks>
        /// Source Demand Routing Protocol
        /// RFC 1940
        ///</remarks>
        Sdrp = 0x2A,

        ///<summary>
        /// Routing Header for IPv6
        ///</summary>
        ///<remarks>
        /// Routing Header for IPv6
        /// RFC 8200
        ///</remarks>
        IPv6Route = 0x2B,

        ///<summary>
        /// Fragment Header for IPv6
        ///</summary>
        ///<remarks>
        /// Fragment Header for IPv6
        /// RFC 8200
        ///</remarks>
        IPv6Frag = 0x2C,

        ///<summary>
        /// Inter-Domain Routing Protocol
        ///</summary>
        ///<remarks>
        /// Inter-Domain Routing Protocol
        ///</remarks>
        Idrp = 0x2D,

        ///<summary>
        /// Resource Reservation Protocol
        ///</summary>
        ///<remarks>
        /// Resource Reservation Protocol
        /// RFC 2205
        ///</remarks>
        Rsvp = 0x2E,

        ///<summary>
        /// Generic Routing Encapsulation
        ///</summary>
        ///<remarks>
        /// Generic Routing Encapsulation
        /// RFC 2784, RFC 2890
        ///</remarks>
        Gres = 0x2F,

        ///<summary>
        /// Dynamic Source Routing Protocol
        ///</summary>
        ///<remarks>
        /// Dynamic Source Routing Protocol
        /// RFC 4728
        ///</remarks>
        Dsr = 0x30,

        ///<summary>
        /// Burroughs Network Architecture
        ///</summary>
        ///<remarks>
        /// Burroughs Network Architecture
        ///</remarks>
        Bna = 0x31,

        ///<summary>
        /// Encapsulating Security Payload
        ///</summary>
        ///<remarks>
        /// Encapsulating Security Payload
        /// RFC 4303
        ///</remarks>
        Esp = 0x32,

        ///<summary>
        /// Authentication Header
        ///</summary>
        ///<remarks>
        /// Authentication Header
        /// RFC 4302
        ///</remarks>
        Ah = 0x33,

        ///<summary>
        /// Integrated Net Layer Security Protocol
        ///</summary>
        ///<remarks>
        /// Integrated Net Layer Security Protocol
        /// TUBA
        ///</remarks>
        Inlsp = 0x34,

        ///<summary>
        /// SwIPe
        ///</summary>
        ///<remarks>
        /// SwIPe
        /// IP with Encryption
        ///</remarks>
        Swipe = 0x35,

        ///<summary>
        /// NBMA Address Resolution Protocol
        ///</summary>
        ///<remarks>
        /// NBMA Address Resolution Protocol
        /// RFC 1735
        ///</remarks>
        Narp = 0x36,

        ///<summary>
        /// IP Mobility (Min Encap)
        ///</summary>
        ///<remarks>
        /// IP Mobility (Min Encap)
        /// RFC 2004
        ///</remarks>
        Mobile = 0x37,

        ///<summary>
        /// Transport Layer Security Protocol (using Kryptonet key management)
        ///</summary>
        ///<remarks>
        /// Transport Layer Security Protocol (using Kryptonet key management)
        ///</remarks>
        Tlsp = 0x38,

        ///<summary>
        /// Simple Key-Management for Internet Protocol
        ///</summary>
        ///<remarks>
        /// Simple Key-Management for Internet Protocol
        /// RFC 2356
        ///</remarks>
        Skip = 0x39,

        ///<summary>
        /// ICMP for IPv6
        ///</summary>
        ///<remarks>
        /// ICMP for IPv6
        /// RFC 4443, RFC 4884
        ///</remarks>
        IPv6Icmp = 0x3A,

        ///<summary>
        /// No Next Header for IPv6
        ///</summary>
        ///<remarks>
        /// No Next Header for IPv6
        /// RFC 8200
        ///</remarks>
        IPv6NoNxt = 0x3B,

        ///<summary>
        /// Destination Options for IPv6
        ///</summary>
        ///<remarks>
        /// Destination Options for IPv6
        /// RFC 8200
        ///</remarks>
        IPv6Opts = 0x3C,

        /// <summary>
        /// Any host
        /// </summary>
        /// <remarks>
        /// Internal protocol
        /// </remarks>
        AnyHost = 0x3D,

        ///<summary>
        /// CFTP
        ///</summary>
        ///<remarks>
        /// CFTP
        ///</remarks>
        CFTP = 0x3E,

        /// <summary>
        /// Any local network
        /// </summary>
        AnyLocalNetwork = 0x3F,

        ///<summary>
        /// SATNET and Backroom EXPAK
        ///</summary>
        ///<remarks>
        /// SATNET and Backroom EXPAK
        ///</remarks>
        SatExpak = 0x40,

        ///<summary>
        /// Kryptolan
        ///</summary>
        ///<remarks>
        /// Kryptolan
        ///</remarks>
        KRYPTOLAN = 0x41,

        ///<summary>
        /// MIT Remote Virtual Disk Protocol
        ///</summary>
        ///<remarks>
        /// MIT Remote Virtual Disk Protocol
        ///</remarks>
        RVD = 0x42,

        ///<summary>
        /// Internet Pluribus Packet Core
        ///</summary>
        ///<remarks>
        /// Internet Pluribus Packet Core
        ///</remarks>
        IPPC = 0x43,

        /// <summary>
        /// Any distributed file system
        /// </summary>
        AnyDistributedFileSystem = 0x44,

        ///<summary>
        /// SATNET Monitoring
        ///</summary>
        ///<remarks>
        /// SATNET Monitoring
        ///</remarks>
        SatMon = 0x45,

        ///<summary>
        /// VISA Protocol
        ///</summary>
        ///<remarks>
        /// VISA Protocol
        ///</remarks>
        Visa = 0x46,

        ///<summary>
        /// Internet Packet Core Utility
        ///</summary>
        ///<remarks>
        /// Internet Packet Core Utility
        ///</remarks>
        Ipcu = 0x47,

        ///<summary>
        /// Computer Protocol Network Executive
        ///</summary>
        ///<remarks>
        /// Computer Protocol Network Executive
        ///</remarks>
        CPNX = 0x48,

        ///<summary>
        /// Computer Protocol Heart Beat
        ///</summary>
        ///<remarks>
        /// Computer Protocol Heart Beat
        ///</remarks>
        CPHB = 0x49,

        ///<summary>
        /// Wang Span Network
        ///</summary>
        ///<remarks>
        /// Wang Span Network
        ///</remarks>
        WSN = 0x4A,

        ///<summary>
        /// Packet Video Protocol
        ///</summary>
        ///<remarks>
        /// Packet Video Protocol
        ///</remarks>
        PVP = 0x4B,

        ///<summary>
        /// Backroom SATNET Monitoring
        ///</summary>
        ///<remarks>
        /// Backroom SATNET Monitoring
        ///</remarks>
        BrSatMon = 0x4C,

        ///<summary>
        /// SUN ND PROTOCOL-Temporary
        ///</summary>
        ///<remarks>
        /// SUN ND PROTOCOL-Temporary
        ///</remarks>
        SunNd = 0x4D,

        ///<summary>
        /// WIDEBAND Monitoring
        ///</summary>
        ///<remarks>
        /// WIDEBAND Monitoring
        ///</remarks>
        WbMon = 0x4E,

        ///<summary>
        /// WIDEBAND EXPAK
        ///</summary>
        ///<remarks>
        /// WIDEBAND EXPAK
        ///</remarks>
        WbExpak = 0x4F,

        ///<summary>
        /// International Organization for Standardization Internet Protocol
        ///</summary>
        ///<remarks>
        /// International Organization for Standardization Internet Protocol
        ///</remarks>
        IsoIp = 0x50,

        ///<summary>
        /// Versatile Message Transaction Protocol
        ///</summary>
        ///<remarks>
        /// Versatile Message Transaction Protocol
        /// RFC 1045
        ///</remarks>
        Vmtp = 0x51,

        ///<summary>
        /// Secure Versatile Message Transaction Protocol
        ///</summary>
        ///<remarks>
        /// Secure Versatile Message Transaction Protocol
        /// RFC 1045
        ///</remarks>
        SecureVmtp = 0x52,

        ///<summary>
        /// VINES
        ///</summary>
        ///<remarks>
        /// VINES
        ///</remarks>
        Vines = 0x53,

        ///<summary>
        /// TTP
        ///</summary>
        ///<remarks>
        /// TTP
        ///</remarks>
        Ttp = 0x54,

        ///<summary>
        /// Internet Protocol Traffic Manager
        ///</summary>
        ///<remarks>
        /// Internet Protocol Traffic Manager
        ///</remarks>
        Iptm = 0x54,

        ///<summary>
        /// NSFNET-IGP
        ///</summary>
        ///<remarks>
        /// NSFNET-IGP
        ///</remarks>
        NsfNetIgp = 0x55,

        ///<summary>
        /// Dissimilar Gateway Protocol
        ///</summary>
        ///<remarks>
        /// Dissimilar Gateway Protocol
        ///</remarks>
        Dgp = 0x56,

        ///<summary>
        /// TCF
        ///</summary>
        ///<remarks>
        /// TCF
        ///</remarks>
        Tcf = 0x57,

        ///<summary>
        /// EIGRP
        ///</summary>
        ///<remarks>
        /// EIGRP
        ///</remarks>
        Eigrp = 0x58,

        ///<summary>
        /// Open Shortest Path First
        ///</summary>
        ///<remarks>
        /// Open Shortest Path First
        /// RFC 1583
        ///</remarks>
        Ospf = 0x59,

        ///<summary>
        /// Sprite RPC Protocol
        ///</summary>
        ///<remarks>
        /// Sprite RPC Protocol
        ///</remarks>
        SpriteRpc = 0x5A,

        ///<summary>
        /// Locus Address Resolution Protocol
        ///</summary>
        ///<remarks>
        /// Locus Address Resolution Protocol
        ///</remarks>
        Larp = 0x5B,

        ///<summary>
        /// Multicast Transport Protocol
        ///</summary>
        ///<remarks>
        /// Multicast Transport Protocol
        ///</remarks>
        Mtp = 0x5C,

        ///<summary>
        /// AX.25
        ///</summary>
        ///<remarks>
        /// AX.25
        ///</remarks>
        Ax25 = 0x5D,

        ///<summary>
        /// KA9Q NOS compatible IP over IP tunneling
        ///</summary>
        ///<remarks>
        /// KA9Q NOS compatible IP over IP tunneling
        ///</remarks>
        Os = 0x5E,

        ///<summary>
        /// Mobile Internetworking Control Protocol
        ///</summary>
        ///<remarks>
        /// Mobile Internetworking Control Protocol
        ///</remarks>
        Micp = 0x5F,

        ///<summary>
        /// Semaphore Communications Sec. Pro
        ///</summary>
        ///<remarks>
        /// Semaphore Communications Sec. Pro
        ///</remarks>
        SccSp = 0x60,

        ///<summary>
        /// Ethernet-within-IP Encapsulation
        ///</summary>
        ///<remarks>
        /// Ethernet-within-IP Encapsulation
        /// RFC 3378
        ///</remarks>
        EtherIp = 0x61,

        ///<summary>
        /// Encapsulation Header
        ///</summary>
        ///<remarks>
        /// Encapsulation Header
        /// RFC 1241
        ///</remarks>
        Encap = 0x62,

        /// <summary>
        /// Any private encryption scheme
        /// </summary>
        AnyPrivateEncryptionScheme = 0x63,

        ///<summary>
        /// GMTP
        ///</summary>
        ///<remarks>
        /// GMTP
        ///</remarks>
        Gmtp = 0x64,

        ///<summary>
        /// Ipsilon Flow Management Protocol
        ///</summary>
        ///<remarks>
        /// Ipsilon Flow Management Protocol
        ///</remarks>
        Ifmp = 0x65,

        ///<summary>
        /// PNNI over IP
        ///</summary>
        ///<remarks>
        /// PNNI over IP
        ///</remarks>
        Pnni = 0x66,

        ///<summary>
        /// Protocol Independent Multicast
        ///</summary>
        ///<remarks>
        /// Protocol Independent Multicast
        ///</remarks>
        Pim = 0x67,

        ///<summary>
        /// IBM's ARIS (Aggregate Route IP Switching) Protocol
        ///</summary>
        ///<remarks>
        /// IBM's ARIS (Aggregate Route IP Switching) Protocol
        ///</remarks>
        Aris = 0x68,

        ///<summary>
        /// SCPS (Space Communications Protocol Standards)
        ///</summary>
        ///<remarks>
        /// SCPS (Space Communications Protocol Standards)
        /// SCPS-TP[2]
        ///</remarks>
        Scps = 0x69,

        ///<summary>
        /// QNX
        ///</summary>
        ///<remarks>
        /// QNX
        ///</remarks>
        Qnx = 0x6A,

        ///<summary>
        /// Active Networks
        ///</summary>
        ///<remarks>
        /// Active Networks
        ///</remarks>
        AN = 0x6B,

        ///<summary>
        /// IP Payload Compression Protocol
        ///</summary>
        ///<remarks>
        /// IP Payload Compression Protocol
        /// RFC 3173
        ///</remarks>
        IpComp = 0x6C,

        ///<summary>
        /// Sitara Networks Protocol
        ///</summary>
        ///<remarks>
        /// Sitara Networks Protocol
        ///</remarks>
        Snp = 0x6D,

        ///<summary>
        /// Compaq Peer Protocol
        ///</summary>
        ///<remarks>
        /// Compaq Peer Protocol
        ///</remarks>
        CompaqPeer = 0x6E,

        ///<summary>
        /// IPX in IP
        ///</summary>
        ///<remarks>
        /// IPX in IP
        ///</remarks>
        IpxInIp = 0x6F,

        ///<summary>
        /// Virtual Router Redundancy Protocol, Common Address Redundancy Protocol (not IANA assigned)
        ///</summary>
        ///<remarks>
        /// Virtual Router Redundancy Protocol, Common Address Redundancy Protocol (not IANA assigned)
        /// VRRP:RFC 3768
        ///</remarks>
        Vrrp = 0x70,

        ///<summary>
        /// PGM Reliable Transport Protocol
        ///</summary>
        ///<remarks>
        /// PGM Reliable Transport Protocol
        /// RFC 3208
        ///</remarks>
        PGM = 0x71,

        /// <summary>
        /// Any 0-hop protocol
        /// </summary>
        Any0HopProtocol = 0x72,

        ///<summary>
        /// Layer Two Tunneling Protocol Version 3
        ///</summary>
        ///<remarks>
        /// Layer Two Tunneling Protocol Version 3
        /// RFC 3931
        ///</remarks>
        L2Tp = 0x73,

        ///<summary>
        /// D-II Data Exchange (DDX)
        ///</summary>
        ///<remarks>
        /// D-II Data Exchange (DDX)
        ///</remarks>
        Ddx = 0x74,

        ///<summary>
        /// Interactive Agent Transfer Protocol
        ///</summary>
        ///<remarks>
        /// Interactive Agent Transfer Protocol
        ///</remarks>
        Iatp = 0x75,

        ///<summary>
        /// Schedule Transfer Protocol
        ///</summary>
        ///<remarks>
        /// Schedule Transfer Protocol
        ///</remarks>
        Stp = 0x76,

        ///<summary>
        /// SpectraLink Radio Protocol
        ///</summary>
        ///<remarks>
        /// SpectraLink Radio Protocol
        ///</remarks>
        Srp = 0x77,

        ///<summary>
        /// Universal Transport Interface Protocol
        ///</summary>
        ///<remarks>
        /// Universal Transport Interface Protocol
        ///</remarks>
        Uti = 0x78,

        ///<summary>
        /// Simple Message Protocol
        ///</summary>
        ///<remarks>
        /// Simple Message Protocol
        ///</remarks>
        Smp = 0x79,

        ///<summary>
        /// Simple Multicast Protocol
        ///</summary>
        ///<remarks>
        /// Simple Multicast Protocol
        /// draft-perlman-simple-multicast-03
        ///</remarks>
        Sm = 0x7A,

        ///<summary>
        /// Performance Transparency Protocol
        ///</summary>
        ///<remarks>
        /// Performance Transparency Protocol
        ///</remarks>
        Ptp = 0x7B,

        ///<summary>
        /// Intermediate System to Intermediate System (IS-IS) Protocol over IPv4
        ///</summary>
        ///<remarks>
        /// Intermediate System to Intermediate System (IS-IS) Protocol over IPv4
        /// RFC 1142 and RFC 1195
        ///</remarks>
        IsIsOverIpv4 = 0x7C,

        ///<summary>
        /// Flexible Intra-AS Routing Environment
        ///</summary>
        ///<remarks>
        /// Flexible Intra-AS Routing Environment
        ///</remarks>
        Fire = 0x7D,

        ///<summary>
        /// Combat Radio Transport Protocol
        ///</summary>
        ///<remarks>
        /// Combat Radio Transport Protocol
        ///</remarks>
        Crtp = 0x7E,

        ///<summary>
        /// Combat Radio User Datagram
        ///</summary>
        ///<remarks>
        /// Combat Radio User Datagram
        ///</remarks>
        Crudp = 0x7F,

        ///<summary>
        /// Service-Specific Connection-Oriented Protocol in a Multilink and Connectionless Environment
        ///</summary>
        ///<remarks>
        /// Service-Specific Connection-Oriented Protocol in a Multilink and Connectionless Environment
        /// ITU-T Q.2111 (1999)
        ///</remarks>
        SSCOPMCE = 0x80,

        /// <summary>
        /// IPLT
        /// </summary>
        Iplt = 0x81,

        ///<summary>
        /// Secure Packet Shield
        ///</summary>
        ///<remarks>
        /// Secure Packet Shield
        ///</remarks>
        Sps = 0x82,

        ///<summary>
        /// Private IP Encapsulation within IP
        ///</summary>
        ///<remarks>
        /// Private IP Encapsulation within IP
        /// Expired I-D draft-petri-mobileip-pipe-00.txt
        ///</remarks>
        Pipe = 0x83,

        ///<summary>
        /// Stream Control Transmission Protocol
        ///</summary>
        ///<remarks>
        /// Stream Control Transmission Protocol
        /// RFC 4960
        ///</remarks>
        Sctp = 0x84,

        ///<summary>
        /// Fibre Channel
        ///</summary>
        ///<remarks>
        /// Fibre Channel
        ///</remarks>
        Fc = 0x85,

        ///<summary>
        /// Reservation Protocol (RSVP) End-to-End Ignore
        ///</summary>
        ///<remarks>
        /// Reservation Protocol (RSVP) End-to-End Ignore
        /// RFC 3175
        ///</remarks>
        RsvpE2eIgnore = 0x86,

        ///<summary>
        /// Mobility Extension Header for IPv6
        ///</summary>
        ///<remarks>
        /// Mobility Extension Header for IPv6
        /// RFC 6275
        ///</remarks>
        MobilityHeader = 0x87,

        ///<summary>
        /// Lightweight User Datagram Protocol
        ///</summary>
        ///<remarks>
        /// Lightweight User Datagram Protocol
        /// RFC 3828
        ///</remarks>
        UdpLite = 0x88,

        ///<summary>
        /// Multiprotocol Label Switching Encapsulated in IP
        ///</summary>
        ///<remarks>
        /// Multiprotocol Label Switching Encapsulated in IP
        /// RFC 4023, RFC 5332
        ///</remarks>
        MplsInIp = 0x89,

        ///<summary>
        /// MANET Protocols
        ///</summary>
        ///<remarks>
        /// MANET Protocols
        /// RFC 5498
        ///</remarks>
        Manet = 0x8A,

        ///<summary>
        /// Host Identity Protocol
        ///</summary>
        ///<remarks>
        /// Host Identity Protocol
        /// RFC 5201
        ///</remarks>
        Hip = 0x8B,

        ///<summary>
        /// Site Multihoming by IPv6 Intermediation
        ///</summary>
        ///<remarks>
        /// Site Multihoming by IPv6 Intermediation
        /// RFC 5533
        ///</remarks>
        Shim6 = 0x8C,

        ///<summary>
        /// Wrapped Encapsulating Security Payload
        ///</summary>
        ///<remarks>
        /// Wrapped Encapsulating Security Payload
        /// RFC 5840
        ///</remarks>
        Wesp = 0x8D,

        ///<summary>
        /// Robust Header Compression
        ///</summary>
        ///<remarks>
        /// Robust Header Compression
        /// RFC 5856
        ///</remarks>
        ROHC = 0x8E,

        ///<summary>
        /// RFC 3692
        ///</summary>
        ///<remarks>
        /// RFC 3692
        ///</remarks>
        ExperiementTest1 = 0xFD,

        ///<summary>
        /// RFC 3692
        ///</summary>
        ///<remarks>
        /// RFC 3692
        ///</remarks>
        ExperiementTest2 = 0xFE,

        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 255
    }
}