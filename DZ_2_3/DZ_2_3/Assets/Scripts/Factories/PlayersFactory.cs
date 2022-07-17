using UnityEngine;


    public class PlayersFactory : MonoBehaviour
    {
        private PlayersData _playersView;

        public PlayersData CreatePlayer(UpdateManager _updateManager)
        {
            _playersView = _updateManager.Player;
            var playerSpawn = new Vector3(0,1,0);
            var player = Instantiate(_playersView, playerSpawn, Quaternion.identity);
            var playerController = player.GetComponent<PlayerControl>();
            playerController.SetUpdateManager(_updateManager);
            playerController.PlayersData = _playersView;
            _updateManager.AddPlayer(player.GetComponent<PlayersData>());
            return player;
        }
    }
