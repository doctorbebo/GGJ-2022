using UnityEngine;

public class PolarityStates {
  // Using ints for now since they're easier to modulo than Enums.
  public const int WHITE = 0;
  public const int BLACK = 1;

  public static readonly int[] STATES = { PolarityStates.WHITE, PolarityStates.BLACK };
}
