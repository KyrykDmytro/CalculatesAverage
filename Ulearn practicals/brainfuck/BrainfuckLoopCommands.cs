using System.Collections.Generic;

namespace func.brainfuck
{
	public class BrainfuckLoopCommands
	{
		static Stack<char> brackets = new Stack<char>();
		static Dictionary<int, int> dict = new Dictionary<int, int>();
 		public static void RegisterTo(IVirtualMachine vm)
		{
			vm.RegisterCommand('[', b => 
			{
				int startPos = b.InstructionPointer;

                if (b.Memory[b.MemoryPointer] == 0)
					if (dict.ContainsKey(b.InstructionPointer))
						b.InstructionPointer = dict[b.InstructionPointer];
					else
						while (true)
						{
							var symbol = b.Instructions[b.InstructionPointer];
							if (symbol == '[')
								brackets.Push(symbol);
							else if (symbol == ']')
								brackets.Pop();
							if (brackets.Count == 0)
							{
								dict[startPos] = b.InstructionPointer;
								dict[b.InstructionPointer] = startPos;
                                break;
							}
							b.InstructionPointer++;
						}
			});
			vm.RegisterCommand(']', b =>
            {
                int startPos = b.InstructionPointer;

                if (b.Memory[b.MemoryPointer] != 0)
                    if (dict.ContainsKey(b.InstructionPointer))
                        b.InstructionPointer = dict[b.InstructionPointer];
                    else
                        while (true)
						{
							var symbol = b.Instructions[b.InstructionPointer];
							if (symbol == ']')
								brackets.Push(symbol);
							else if (symbol == '[')
								brackets.Pop();
                            if (brackets.Count == 0)
                            {
                                dict[startPos] = b.InstructionPointer;
                                dict[b.InstructionPointer] = startPos;
                                break;
                            }
                            b.InstructionPointer--;
						}
            });
        }
	}
}