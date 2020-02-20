using UnityEngine;

namespace RTS.Core
{
	[CreateAssetMenu(menuName = RTSConstant.PlayerMenu + nameof(PlayerRace), order = RTSConstant.PlayerOrder)]
	public class PlayerRace : ScriptableObject
	{
		public string raceName = default;
	}
}