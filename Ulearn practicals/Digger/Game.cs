﻿

using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public static class Game
{
	private const string mapWithPlayerTerrain = @"
S
 
M";

	private const string mapWithPlayerTerrainSackGold = @"
PTTGTT TS
TST  TSTT
TTTTTTSTT
T TSTS TT
T TTTG ST
TSTSTT TT";

	private const string mapWithPlayerTerrainSackGoldMonster = @"
PTTGTS TST
TST   STTM
TTT T STTT
T TST  TTT
T TTT MSTS
T TMT M TS
TSTST MTTT
S TTS   TG
 TGST MTTT
 T  TMTTTT";

    private const string myMap = @"
P    TTTGTTTGT        TTGTT       TGTT
  TT TTTTTTTG TTTTTTG     T  TGTT    M
  TT      G   TGTTTTTTTTS    TTGT  TTT
 TT GGTTG T TTTTTTTTGTTTSTTTTSGTT TGTT
TTT  TSTT    TS   TTTTT TTTT      TMTT
 TST TT    G    TTTTSTT   TTS TTTTTGTT
 TT     TSTTST TSTTTTTTT    TTTTTTTTTG
 TTTTTGTTTTTTT TTTTTTTSST T  TTSTTTTGT
  TTTTGTTTSTTT GTTTTTTTTTTT  TTTGTTTTT
T TTTTTTSTTTTT TTTTGTTTTTTTTGTTMTTTTTT
T TTSSTTTT                      TSTTGT
TMTTTTTTTT TTTTTGTT  TGT TSGTT   TTTTT
T           GTTTTTTS TTT TTTTSTMTSTTGT
TTT  GTTSTTTTTTTTTTSSTTT TTSTTT TTTTTT
TTGT TTTTSTTGTTGTTTTTTGT        TTSTTT
TT T  T TTT TTTTTTTTTTTTTGTTTGTTTTMTTT
TTT T TTT     TTT TTTT T TTTTTTTTGTTTG
";

    public static ICreature[,] Map;
	public static int Scores;
	public static bool IsOver;

	public static Key KeyPressed;
	public static int MapWidth => Map.GetLength(0);
	public static int MapHeight => Map.GetLength(1);

	public static void CreateMap()
	{
		Map = CreatureMapCreator.CreateMap(mapWithPlayerTerrain);
	}
}