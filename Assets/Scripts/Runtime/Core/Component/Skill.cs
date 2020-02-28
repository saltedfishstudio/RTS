using RTS.Core.Ability;
using UnityEngine;

namespace RTS.Core
{
	public abstract  class Skill<T> : MonoBehaviour 
		where T : CommandBase
	{
		protected T command;
	}
}