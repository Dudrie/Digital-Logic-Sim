namespace DLS.Simulation
{
	// Builtin chips handle the core logic operations that the simulation is built on, such as AND and NOT.
	// Other higher-level chips may be implemented here for efficiency and convience if needed (such as a builtin RAM chip, and so on).
	public abstract class BuiltinSimChip
	{

		protected readonly SimPin[] inputPins;
		protected readonly SimPin[] outputPins;
		protected readonly int numInputs;
		int numUnprocessedInputsReceived;


		public BuiltinSimChip(SimPin[] inputPins, SimPin[] outputPins)
		{
			this.inputPins = inputPins;
			this.outputPins = outputPins;
			numInputs = inputPins.Length;
		}

		public void SetInputPin(int index, SimPin pin)
		{
			inputPins[index] = pin;
		}

		public void SetOutputPin(int index, SimPin pin) => outputPins[index] = pin;

		public void InputReceived()
		{
			numUnprocessedInputsReceived++;
			//UnityEngine.Debug.Log(GetType().ToString() + "  Received input: " + numUnprocessedInputsReceived + " / " + numConnectedInputs);
			if (numUnprocessedInputsReceived == numInputs)
			{
				ProcessInputs();
				numUnprocessedInputsReceived = 0;
			}
		}

		protected abstract void ProcessInputs();
	}
}