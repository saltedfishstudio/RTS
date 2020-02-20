namespace RTS.Core.Ability
{
	public class StopCommand : CommandBase
	{
		public override bool CanCast<T>(Actor<T> actor)
		{
			return true;
		}

		public override bool IsReady<T>(Actor<T> actor)
		{
			return true;
		}
	}
}