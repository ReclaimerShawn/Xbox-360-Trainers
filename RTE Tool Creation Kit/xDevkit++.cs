//Coded by CraigChrist8239
//Custom functions for reading mem...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XDevkit;

namespace XDevkitPlusPlus
{
    public static class XDevkitExtensions
    { 
        private static byte[] myBuffer = new byte[0x20];
        private static byte[] myBuffer2 = new byte[0x40];
        private static uint outInt;
        public static int DataType = 69;
        public static uint Offset;
        public static IXboxDebugTarget temp;

        public static void ChangeDataType(int Type)
        {
            DataType = Type;
        }

        public static int GetDataType()
        {
            return DataType;
        }

        public static sbyte ReadSByte(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 1, myBuffer, out outInt);
            return (sbyte)myBuffer[0];
        }

        public static bool ReadBool(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 1, myBuffer, out outInt);
            return myBuffer[0] != 0;
        }

        public static short ReadInt16(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 2, myBuffer, out outInt);
            Array.Reverse(myBuffer, 0, 2);
            return BitConverter.ToInt16(myBuffer, 0);
        }

        public static int ReadInt32(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 4, myBuffer, out outInt);
            Array.Reverse(myBuffer, 0, 4);
            return BitConverter.ToInt32(myBuffer, 0);
        }

        public static long ReadInt64(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 8, myBuffer, out outInt);
            Array.Reverse(myBuffer, 0, 8);
            return BitConverter.ToInt64(myBuffer, 0);
        }

        public static byte ReadByte(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 1, myBuffer, out outInt);
            return myBuffer[0];
        }

        public static ushort ReadUInt16(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 2, myBuffer, out outInt);
            Array.Reverse(myBuffer, 0, 2);
            return BitConverter.ToUInt16(myBuffer, 0);
        }

        public static uint ReadUInt32(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 4, myBuffer, out outInt);
            Array.Reverse(myBuffer, 0, 4);
            return BitConverter.ToUInt32(myBuffer, 0);
        }

        public static ulong ReadUInt64(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 8, myBuffer, out outInt);
            Array.Reverse(myBuffer, 0, 8);
            return BitConverter.ToUInt64(myBuffer, 0);
        }

        public static float ReadFloat(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 4, myBuffer, out outInt);
            Array.Reverse(myBuffer, 0, 4);
            return BitConverter.ToSingle(myBuffer, 0);
        }

        public static double ReadDouble(this IXboxDebugTarget xdt, uint offset)
        {
            xdt.GetMemory(offset, 8, myBuffer, out outInt);
            Array.Reverse(myBuffer, 0, 8);
            return BitConverter.ToDouble(myBuffer, 0);
        }

        public static string ReadString(this IXboxDebugTarget xdt, uint offset, byte[] readBuffer)      //My buffer is only 0x20 bytes, so you can use ur own
        {
            xdt.GetMemory(offset, (uint)readBuffer.Length, readBuffer, out outInt);
            return new String(System.Text.Encoding.ASCII.GetChars(readBuffer)).Split('\0')[0];
        }

        public static string ReadString(this IXboxDebugTarget xdt, uint offset)
        {
            return ReadString(xdt, offset, myBuffer);
        }

        public static void WriteSByte(this IXboxDebugTarget xdt, uint offset, sbyte input)
        {
            myBuffer[0] = (byte)input;
            xdt.SetMemory(offset, 1, myBuffer, out outInt);
        }

        public static void WriteBool(this IXboxDebugTarget xdt, uint offset, bool input)
        {
            myBuffer[0] = input ? (byte)1 : (byte)0;
            xdt.SetMemory(offset, 1, myBuffer, out outInt);
        }

        public static void WriteInt16(this IXboxDebugTarget xdt, uint offset, short input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            Array.Reverse(myBuffer, 0, 2);
            xdt.SetMemory(offset, 2, myBuffer, out outInt);
        }

        public static void WriteInt32(this IXboxDebugTarget xdt, uint offset, int input, bool bigEndien = true)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            if(bigEndien) Array.Reverse(myBuffer, 0, 4);
            xdt.SetMemory(offset, 4, myBuffer, out outInt);
        }

        public static void WriteInt64(this IXboxDebugTarget xdt, uint offset, long input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            Array.Reverse(myBuffer, 0, 8);
            xdt.SetMemory(offset, 8, myBuffer, out outInt);
        }

        public static void WriteByte(this IXboxDebugTarget xdt, uint offset, byte input)
        {
            myBuffer[0] = input;
            xdt.SetMemory(offset, 1, myBuffer, out outInt);
        }

        public static void WriteUInt16(this IXboxDebugTarget xdt, uint offset, ushort input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            Array.Reverse(myBuffer, 0, 2);
            xdt.SetMemory(offset, 2, myBuffer, out outInt);
        }

        public static void WriteUInt32(this IXboxDebugTarget xdt, uint offset, uint input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            Array.Reverse(myBuffer, 0, 4);
            xdt.SetMemory(offset, 4, myBuffer, out outInt);
        }

        public static void WriteUInt64(this IXboxDebugTarget xdt, uint offset, ulong input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            Array.Reverse(myBuffer, 0, 8);
            xdt.SetMemory(offset, 8, myBuffer, out outInt);
        }

        public static void WriteDouble(this IXboxDebugTarget xdt, uint offset, double input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            Array.Reverse(myBuffer, 0, 8);
            xdt.SetMemory(offset, 8, myBuffer, out outInt);
        }

        public static void WriteString(this IXboxDebugTarget xdt, uint offset, string input)
        {
            Encoding.ASCII.GetBytes(input).CopyTo(myBuffer2, 0);
            xdt.SetMemory(offset, 16, myBuffer2, out outInt);
        }

        public static void WriteFloat(this IXboxDebugTarget xdt, uint offset, float input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            Array.Reverse(myBuffer, 0, 4);
            xdt.SetMemory(offset, 4, myBuffer, out outInt);
        }

        public static void MW2Float(this IXboxDebugTarget xdt, uint offset, float input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuffer, 0);
            Array.Reverse(myBuffer, 0, 4);
            xdt.SetMemory(offset, 4, myBuffer, out outInt);
        }
    }
}