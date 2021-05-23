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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WinDivertSharpTests;

namespace WinDivertTestRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Thanks to the power of WinDiver to screw with testing software run through the IDE, we
            // also have this project where we can run our tests ourselves old school!

            var testClass = new WinDivertTests();

            testClass.Init();

            var methods = typeof(WinDivertTests).GetMethods();

            var testMethods = new List<MethodInfo>();

            foreach (var method in methods)
            {
                var isTest = method.GetCustomAttribute<TestAttribute>() != null;
                if (isTest)
                {
                    testMethods.Add(method);
                }
            }

            testMethods = testMethods.OrderBy(x => x.Name).ToList();

            int passed = 0;
            int failed = 0;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (var method in testMethods)
            {
                Console.ResetColor();

                try
                {
                    method.Invoke(testClass, null);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Test {0} passed.", method.Name);
                    ++passed;
                }
                catch (Exception err)
                {
                    while (err != null)
                    {
                        Console.WriteLine(err.Message);
                        Console.WriteLine(err.StackTrace);
                        err = err.InnerException;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Test {0} failed.", method.Name);
                    ++failed;
                }
            }

            testClass.DeInit();

            if (passed > 0 && failed == 0)
            {
                Console.WriteLine(new string('*', Console.WindowWidth - 1));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All tests passed.");
            }
            else
            {
                Console.WriteLine(new string('*', Console.WindowWidth - 1));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} tests passed and {1} failed.", passed, failed);
            }

            Console.ResetColor();
        }
    }
}