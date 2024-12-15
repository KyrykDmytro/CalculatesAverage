using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		private Dictionary<char, Action<IVirtualMachine>> InstructionsFunctional;

        public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }

		public VirtualMachine(string program, int memorySize)
		{
			InstructionsFunctional = new Dictionary<char, Action<IVirtualMachine>>();
			Instructions = program;
			Memory = new byte[memorySize];
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
			Action<IVirtualMachine> a = execute;
            if (a != null){ 
				InstructionsFunctional[symbol] = a; 
			}
		}

		public void Run()
		{
			while(InstructionPointer < Instructions.Length)
			{
				if (InstructionsFunctional.ContainsKey(Instructions[InstructionPointer]))
					InstructionsFunctional[Instructions[InstructionPointer]](this);
				InstructionPointer++;
			}
		}
	}
}