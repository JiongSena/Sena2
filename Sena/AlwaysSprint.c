using UnityEngine;

namespace Sena
{
    public class 自动冲刺 : MonoBehaviour
    {
        private void Update()
        {
            var localUser = RoR2.LocalUserManager.GetFirstLocalUser();
            if (localUser == null || localUser.cachedMasterController == null || localUser.cachedMasterController.master == null) return;
            var controller = localUser.cachedMasterController;
            var body = controller.master.GetBody();
            if (body && !body.isSprinting && !localUser.inputPlayer.GetButton("Sprint"))
                controller.SetField("sprintInputPressReceived", true);
        }
    }
}
