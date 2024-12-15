using System;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
        private static void RegisterCommandForRange(char from, char to, Func<char, Action<IVirtualMachine>> createCommand, IVirtualMachine vm)
		{
            for (char i = from; i <= to; i++)
            {
                var symbol = i;
                vm.RegisterCommand(i, createCommand(symbol));
            }
        }
        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
			vm.RegisterCommand('.', b => write((char)b.Memory[b.MemoryPointer]));
			vm.RegisterCommand(',', b => b.Memory[b.MemoryPointer] = (byte)read());
			vm.RegisterCommand('+', b => { unchecked { b.Memory[b.MemoryPointer]++; } });
			vm.RegisterCommand('-', b => { unchecked { b.Memory[b.MemoryPointer]--; } });
			vm.RegisterCommand('>', b => b.MemoryPointer = (b.MemoryPointer + 1) % b.Memory.Length);
			vm.RegisterCommand('<', b => 
			{
				if (b.MemoryPointer - 1 < 0)
					b.MemoryPointer = b.Memory.Length;
                b.MemoryPointer = b.MemoryPointer - 1;
			});
			Func<char, Action<IVirtualMachine>> createCommand = (s) =>
				b => { b.Memory[b.MemoryPointer] = (byte)s; };
            RegisterCommandForRange('0', '9', createCommand, vm);
			RegisterCommandForRange('A', 'Z', createCommand, vm);
			RegisterCommandForRange('a', 'z', createCommand, vm);
		}
	}
}