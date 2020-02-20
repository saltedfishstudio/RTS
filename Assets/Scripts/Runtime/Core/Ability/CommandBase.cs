namespace RTS.Core.Ability
{
	public abstract class CommandBase
	{
		public virtual bool CanCast<T>(Actor<T> actor) where T : Entity
		{
			return false;
		}

		public virtual bool IsReady<T>(Actor<T> actor) where T : Entity
		{
			return false;
		}
	}
}