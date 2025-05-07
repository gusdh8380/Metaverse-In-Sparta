using UnityEngine;

[CreateAssetMenu(menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite thumbnail;       // UI�� �Ѹ� ���� �̹���
    public Sprite defaultSprite;   // SpriteRenderer�� �ٷ� ������ �⺻ ������
    public RuntimeAnimatorController animatorController; // ��Ų ���� �ִϸ�����
}
