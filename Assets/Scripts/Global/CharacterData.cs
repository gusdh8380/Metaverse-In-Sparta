using UnityEngine;

[CreateAssetMenu(menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite thumbnail;       // UI에 뿌릴 작은 이미지
    public Sprite defaultSprite;   // SpriteRenderer에 바로 적용할 기본 프레임
    public RuntimeAnimatorController animatorController; // 스킨 전용 애니메이터
}
