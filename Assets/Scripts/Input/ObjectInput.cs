using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.Protocol;
using UnityEngine;

/// <summary>
/// Ʈ���� ������ ó���ϴ� �Լ��� ���ִ� Ŭ����
/// </summary>
public class ObjectInput : MonoBehaviour
{
    /// <summary>
    /// Ʈ���� �ɷ����� ó���ϴ� �Լ�
    /// </summary>
    /// <param name="dediPlayerId"></param>
    public void ProcessTrapped(int dediPlayerId, string trapId)
    {
        StartCoroutine(Trapped(dediPlayerId, trapId));
    }

    /// <summary>
    /// Ʈ���� �ɷ�����
    /// </summary>
    /// <param name="dediPlayerId">Ʈ���� �ɸ� �����÷��̾�id</param>
    private IEnumerator Trapped(int dediPlayerId, string trapId)
    {
        float stunDuration = (Managers.Item._itemFactories[4] as TrapFactory).StunDuration;

        GameObject playerGameObject = Managers.Player._players[dediPlayerId];
        Player dediPlayer = playerGameObject.GetComponent<Player>();
        if (dediPlayer._playerStatus._isCurrentTrapped) //�̹� Ʈ���� �ɷ����� ����
        {
            yield break;
        }

        //Ʈ�� �ɷȴٰ� ��ε�ĳ��Ʈ
        DSC_OnHitTrapItem onHitTrapItem = new DSC_OnHitTrapItem();
        onHitTrapItem.PlayerId = dediPlayerId;
        onHitTrapItem.ItemId = 4;
        onHitTrapItem.TrapId = trapId;
        Managers.Player.Broadcast(onHitTrapItem);


        //���� Ʈ���� �ɷȴٰ� ǥ��
        dediPlayer._playerStatus._isCurrentTrapped = true; 
        //��Ʈ ���󰡱� ��� ����
        dediPlayer.ToggleFollowGhost(false);

        //���Ͻð���ŭ ��ٸ�
        yield return new WaitForSeconds(stunDuration);

        //Ʈ���� �ɸ� ���� ����
        dediPlayer._playerStatus._isCurrentTrapped = false;
        //��Ʈ ���󰡱� ��� �簳
        dediPlayer.ToggleFollowGhost(true);
    }
}
